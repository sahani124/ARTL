<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CorpClt.aspx.cs"
    Inherits="Application_Common_CorpClt" %>

<%@ Register Src="ClientAddress.ascx" TagName="ClientAddress" TagPrefix="uc9" %>
<%@ Register Src="../../App_UserControl/Common/ddlLookup.ascx" TagName="ddlLookup"
    TagPrefix="uc4" %>
<%@ Register Src="../../App_UserControl/Common/popupOccupation.ascx" TagName="popupOccupation"
    TagPrefix="uc5" %>
<%@ Register Src="../../App_UserControl/Common/ctlDate.ascx" TagName="cltDate" TagPrefix="uc7" %>
<%@ Register Src="ClientAML.ascx" TagName="ClientAML" TagPrefix="uc8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/main.css" />
    <script type="text/javascript" src="../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">

        //Added by swapnesh on 14/5/2013 For showing popup start
        function funcShowPopup(strPopUpType) {

            if (strPopUpType == "state") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopState.aspx?Code=" + document.getElementById('<%=txtStateCode.ClientID %>').value
        + "&Desc=" + document.getElementById('<%=txtStateDesc.ClientID %>').value + "&field1=" + document.getElementById('<%=txtStateCode.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtStateDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
        }
        //Added by swapnesh on 14/5/2013 For showing popup end

        var path = "<%=Request.ApplicationPath.ToString()%>";

        function doFormat(args) {
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

        function doValidateName(src, args) {
            var result = true;
            var sString = args.Value;

            //Check for invalid characters
            var iChars = "!$^*_+={}[]|\:;?><";

            for (var i = 0; i < args.Value.length; i++) {
                if (iChars.indexOf(args.Value.charAt(i)) != -1) {
                    result = false;
                }
            }

            if (args.Value.length == 1) {
                result = false;
            }

            args.IsValid = result;
        }

        function CheckPANFormat(src, args) {
            var result = true;
            var pan = document.getElementById("<%=txtPan.ClientID%>").value.split(",");
            var Char;

            var pan2 = pan[0]
            if (pan2 != "") {
                if (pan2.length == 10) {
                    for (j = 0; j < pan2.length && result == true; j++) {
                        Char = pan2.substring(j, j + 1);

                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 9) {
                            if (!isAlphabet(Char)) {
                                result = false;
                            }
                        }
                        if (j == 5 || j == 6 || j == 7 || j == 8) {
                            if (!IsNumeric(Char)) {
                                result = false;
                            }
                        }
                    }
                }
                else {
                    result = false;
                }
            }
            args.IsValid = result;
        }

        function isAlphabet(strText) {
            var inputStr = strText
            for (var intCounter = 0; intCounter < inputStr.length; intCounter++) {
                var oneChar = inputStr.substring(intCounter, intCounter + 1)

                if (oneChar.toUpperCase() < "A" || oneChar.toUpperCase() > "Z") {
                    return false
                    /*If Input Parameter is not Alphabet return false to Parent function*/
                }
            }
            return true
        }


        function doValidateAddress(src, args) {
            var result = true;
            var sString = args.Value;

            //Check for invalid characters
            var iChars = "!@$^*_+={}[]|\:;?><";

            for (var i = 0; i < args.Value.length; i++) {
                if (iChars.indexOf(args.Value.charAt(i)) != -1) {
                    result = false;
                }
            }

            //Check if there's at least one block of 2 characters (valid)
            var sArray = sString.split(" ");
            var blnValid = false;
            for (var i = 0; i < sArray.length; i++) {
                if (sArray[i].length > 1) {
                    blnValid = true;
                }
            }
            if (!blnValid) {
                result = false;
            }

            //Check if there's a hyphen or apostrophe adjacent to space (invalid)
            if ((sString.match("' ") != null) ||
        (sString.match(" '") != null) ||
        (sString.match("- ") != null) ||
        (sString.match(" -") != null)) {
                result = false;
            }

            //Check if there's three same characters in a row (invalid)
            sArray = sString.toUpperCase().split("");
            for (var i = 2; i < sArray.length; i++) {
                if ((sArray[i] == sArray[i - 1]) &&
            (sArray[i] == sArray[i - 2]) &&
            (sArray[i] == sArray[i - 3]) &&
            (!IsNumeric(sArray[i]))) {
                    result = false;
                }
            }

            args.IsValid = result;
        }

        function doTrim(sString) {
            while (sString.substring(0, 1) == " ") {
                sString = sString.substring(1, sString.length);
            }

            while (sString.substring(sString.length - 1, sString.length) == " ") {
                sString = sString.substring(0, sString.length - 1);
            }

            return sString;
        }

        function doCollapse(sString) {
            while (sString.match("  ") != null) {
                sString = sString.replace("  ", " ");
            }

            return sString;
        }

        function doFormatComma(sString) {
            sString = sString.replace(",", ", ");
            sString = sString.replace(" ,", ",");
            sString = sString.replace(",  ", ", ");

            return sString;
        }

        function doCancel2(src, args) {
            var answer = confirm("Do you sure want to cancel ?");
            var vgcn = document.getElementById("<%=txtGCN.ClientID%>").value.split(",");
            var vflag = document.getElementById("<%=txtFlagFind.ClientID%>").value.split(",");

            if (answer != 0) {
                //          location.replace("CorpClt.aspx?ENQ=1&GCN=" + vgcn + "&FLAGFIND=" + vflag);
                location.replace("CorpClt.aspx?ENQ=1&GCN=" + "" + "&FLAGFIND=" + vflag);
            }
        }

        function doCancel(src, args) {
            var answer = confirm("Do you sure want to cancel ?");
            var vgcn = document.getElementById("<%=txtGCN.ClientID%>").value.split(",");
            var vflag = document.getElementById("<%=txtFlagFind.ClientID%>").value.split(",");

            if (answer != 0) {
                //          location.replace("CorpClt.aspx?ENQ=0&GCN=" + vgcn + "&FLAGFIND=" + vflag);
                location.replace("CorpClt.aspx?ENQ=0&GCN=" + "" + "&FLAGFIND=" + vflag);
            }
        }

        function CheckAddress(src, args) {
            var result = true;
            var address = document.getElementById("<%=hdnCnctType.ClientID%>").value.split(",");
            var GCN = document.getElementById("<%=txtGCN.ClientID%>").value.split(",");
            var ddl = document.getElementById("<%=cboCnctType.ClientID%>");

            if (GCN != "") {
                for (i = 0; i < address.length; i++) {
                    var val = ("B" + (i + 2));

                    if (val.length > 2) {
                        switch (val) {
                            case ("B10"):
                                val = "B0";
                                break;
                        }
                    }
                    if (document.getElementById(address[i] + "_hdnAdd1") != null) {
                        if ((document.getElementById(address[i] + "_hdnAdd1").value == "")
                        && (ddl.value == val)) {
                            result = false;
                        }
                    }
                }
            }

            args.IsValid = result;
        }

        function CheckWorkTelFormat(src, args) {
            var result = true;
            var LocalTel = document.getElementById("<%=txtWorkTel.ClientID%>").value.split(",");

            strLocalTel = new String(LocalTel)

            if (strLocalTel.length > 0) {
                //             if (strLocalTel.length != 12)
                //             { 
                //                 result = false;
                //             }
                if (!IsNumeric(strLocalTel)) {
                    result = false;
                }
                strLocalTel = strLocalTel.substr(0, 1)
                if (strLocalTel != "0") {
                    result = false;
                }
            }

            args.IsValid = result;
        }

        function CheckMobileTelFormat(src, args) {
            var result = true;

            if (IsNumeric(args.Value)) {
                //            if (strTel.substr(0,1) == "9")
                //            {
                //                if (strTel.length != 11)
                //                { 
                //                    result = false;
                //                }       
                //            }
                //            else
                //            {
                //                if (strTel.length < 8)
                //                { 
                //                    result = false;
                //                }
                //            }
            }
            else {
                result = false;
            }

            args.IsValid = result;
        }
        //added by priyanka b
        function CheckMobileFormat(src, args) {
            var result = true;


            if (IsNumeric(args.Value)) {
                //            if (strTel.substr(0,1) == "9")
                //            {
                if (document.getElementById("<%=ddlChannels.ClientID%>").value == "CD") {
                    if (args.Value.length != 10) {
                        result = false;
                    }
                }
                //            }
                //            else
                //            {
                //                if (strTel.length < 8)
                //                { 
                //                    result = false;
                //                }
                //            }
            }
            else {
                result = false;
            }

            args.IsValid = result;
        }
        function CheckCmpnyTelFormat(src, args) {
            var result = true;
            var LocalTel = document.getElementById("<%=txtCmpnyTel.ClientID%>").value.split(",");

            strLocalTel = new String(LocalTel)

            if (strLocalTel.length > 0) {
                //             if (strLocalTel.length != 12)
                //             { 
                //                 result = false;
                //             }
                if (!IsNumeric(strLocalTel)) {
                    result = false;
                }
                strLocalTel = strLocalTel.substr(0, 1)
                if (strLocalTel != "0") {
                    result = false;
                }
            }

            args.IsValid = result;
        }

        function CheckList(src, args) {
            var result = true;
            var CountryCode = document.getElementById("<%=txtCountryCode.ClientID%>").value.split(",");
            var CountryDesc = document.getElementById("<%=txtCountryDesc.ClientID%>").value.split(",");

            if ((CountryCode != "") && (CountryDesc == "")) {
                result = false;
            }
            args.IsValid = result;
        }

        function CheckValidEmail(src, args) {
            var result;
            var Email2 = document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value.split(",");

            var Email = Email2[0];
            var Email1 = Email.toUpperCase();
            if (document.getElementById("<%=ddlChannels.ClientID%>").value == "CD") {
                result = ((Email.indexOf(".") > 2) && (Email.indexOf("@") > 0) && (Email1.indexOf("@RELIANCE") < 0));
            }
            else {
                result = ((Email.indexOf(".") > 2) && (Email.indexOf("@") > 0));
            }
            args.IsValid = result;
        }

        function CheckWorkFaxFormat(src, args) {
            var result = true;
            var LocalTel = document.getElementById("<%=txtWorkFax.ClientID%>").value.split(",");

            strLocalTel = new String(LocalTel)

            if (strLocalTel.length > 0) {
                //             if (strLocalTel.length != 12)
                //             { 
                //                 result = false;
                //             }
                if (!IsNumeric(strLocalTel)) {
                    result = false;
                }
                strLocalTel = strLocalTel.substr(0, 1)
                if (strLocalTel != "0") {
                    result = false;
                }
            }

            args.IsValid = result;
        }

        function IsNumeric(sText) {
            var ValidChars = "0123456789";
            var IsNumber = true;
            var Char;

            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }

            return IsNumber;
        }

        function IsInteger(sText) {
            var ValidChars1 = "-0123456789";
            var ValidChars2 = "0123456789";
            var IsNumber = true;
            var Char;


            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (i == 0) {
                    if (ValidChars1.indexOf(Char) == -1)
                        IsNumber = false;
                }
                else {
                    if (ValidChars2.indexOf(Char) == -1)
                        IsNumber = false;
                }
            }

            return IsNumber;
        }

        function CheckCapitalLimit(src, args) {
            var result = true;
            var capital = document.getElementById("<%=txtCapital.ClientID%>").value.split(",");

            if ((capital != null) && capital != 0) {
                if (IsNumeric(capital[0])) {
                    var capital = capital[0]

                    if (IsInteger(capital)) {
                        if ((capital <= 2000000000) && (capital >= -2000000000))
                            result = true;
                        else
                            result = false;
                    }
                }
                else {
                    result = false;
                }
            }
            args.IsValid = result;
        }

        function CheckAnnTurnoverLimit(src, args) {
            var result = true;
            var AnnTurnover = document.getElementById("<%=txtAnnTurnover.ClientID%>").value.split(",");

            if ((AnnTurnover != null) && AnnTurnover != 0) {
                var AnnTurnover = AnnTurnover[0]

                if (IsInteger(AnnTurnover)) {
                    if ((AnnTurnover <= 9000000000000000) && (AnnTurnover >= -9000000000000000))
                        result = true;
                    else
                        result = false;
                }
            }

            args.IsValid = result;
        }


        function CheckStaffSzLimit(src, args) {
            var result = true;
            var StaffSz = document.getElementById("<%=txtStaffSz.ClientID%>").value.split(",");

            if ((StaffSz != null) && StaffSz != 0) {
                var StaffSz = StaffSz[0]

                if (IsInteger(StaffSz)) {
                    if ((StaffSz <= 2000000000) && (StaffSz >= -2000000000))
                        result = true;
                    else
                        result = false;
                }
            }

            args.IsValid = result;
        }

        function SurnametoProperCase(s) {
            document.getElementById("<%=txtSurname.ClientID%>").value = toProperCase(s);
        }

        function ContactPersontoProperCase(s) {
            document.getElementById("<%=txtContactPerson.ClientID%>").value = toProperCase(s);
        }

        function IncorporatedtoProperCase(s) {
            document.getElementById("<%=txtBirthPlace.ClientID%>").value = toProperCase(s);
        }

        function CitytoProperCase(s) {
            //document.getElementById("txtCity.ClientID").value = toProperCase(s);    
        }

        function toProperCase(s) {
            return s.toLowerCase().replace(/^(.)|\s(.)/g, function ($1) { return $1.toUpperCase(); })
        }

        function popCountryOrigin(oCode, oDesc, sCode, sDesc) {
            showPopWin("PopCountry.aspx?Code=" + sCode +
            "&Desc=" + sDesc +
            "&Field1=" + oCode +
            "&Field2=" + oDesc
            , 500, 350, null);
        }

        function popSearchCorpClt(oGCN, oSurname, oCID, oDOB, oTel, sGCN, sSurname, sCID, sDOB, sTel) {
            WriteFlag();
            showPopWin("PopSearchCorpClt.aspx?GCN=" + sGCN +
                    "&Surname=" + sSurname +
                    "&CurrentID=" + sCID +
                    "&DOB=" + sDOB +
                    "&Tel=" + sTel +
                    "&Field1=" + oGCN +
                    "&Field2=" + oSurname +
                    "&Field3=" + oCID +
                    "&Field4=" + oDOB +
                    "&Field5=" + oTel
                    , 500, 350, null);
        }

        function Test(args) {
            document.getElementById("ctl00$ContentPlaceHolder1$btnPostBack").click();
        }

        function WriteFlag() {
            document.getElementById("<%=txtFlagFind.ClientID%>").value = "1";
        }

        function popState(oCode, oDesc, sCode, sDesc) {
            showPopWin("PopState.aspx?Code=" + sCode +
                    "&Desc=" + sDesc +
                    "&Field1=" + oCode +
                    "&Field2=" + oDesc
                    , 500, 350, null);
        }

        function popCountry(oCode, oDesc, sCode, sDesc) {
            showPopWin("PopCountry.aspx?Code=" + sCode +
                    "&Desc=" + sDesc +
                    "&Field1=" + oCode +
                    "&Field2=" + oDesc
                    , 500, 350, null);
        }

        function CheckStateList(src, args) {
            var result = true;
            var StateCode = document.getElementById("<%=txtStateCode.ClientID%>").value.split(",");
            var StateDesc = document.getElementById("<%=txtStateDesc.ClientID%>").value.split(",");

            if ((StateCode != "") && (StateDesc == "")) {
                result = false;
            }
            args.IsValid = result;
        }

        function CheckCountryList(src, args) {
            var result = true;
            var CountryCode = document.getElementById("<%=txtCountryCodeAddr.ClientID%>").value.split(",");
            var CountryDesc = document.getElementById("<%=txtCountryDescAddr.ClientID%>").value.split(",");

            if ((CountryCode != "") && (CountryDesc == "")) {
                result = false;
            }
            args.IsValid = result;
        }

        function pageLoad(sender, args) {
            document.getElementById("<%=trDofB.ClientID%>").style.display = "none";

        }


        function SetValue() {
            document.getElementById("<%=txtPan.ClientID%>").value = "";
            document.getElementById("<%=txtEmail.ClientID%>").value = "";
            document.getElementById("<%=txtCmpnyTel.ClientID%>").value = "";
            document.getElementById("<%=txtPan.ClientID%>").disabled = true;
            document.getElementById("<%=hdnPan.ClientID%>").value = "0";
            //added by ankita on 13.02.2012 for CDA Pan Updation
            document.getElementById("<%=btnVerifyPAN.ClientID%>").disabled = true;
            //added by ank on 20.07.2011 for Gender and Date of Birth
            if (document.getElementById("<%=trDofB.ClientID%>") != null) {
                document.getElementById("<%=trDofB.ClientID%>").style.display = "none";
            }


            if (document.getElementById("<%=ddlChannels.ClientID%>").value == "CD") {
                document.getElementById("<%=trDofB.ClientID%>").style.display = "block";
                //added by ankita on 13.02.2012 for CDA Pan Updation
                document.getElementById("<%=btnVerifyPAN.ClientID%>").disabled = false;
                document.getElementById("<%=txtPan.ClientID%>").disabled = false;
            }
            //end on 20.07.2011
        }
        //end on 01.04.2011
        //added by ank on 21.07.2011 for Gender validation
        function doValidate(src, args) {

            var result = false;
            var title = document.getElementById("<%=cboTitle.ClientID%>").value;

            var sTitle = document.getElementById("<%=hdnGenderTitle1.ClientID%>").value.split(",");
            var sGender = document.getElementById("<%=hdnGenderTitle2.ClientID%>").value.split(",");

            for (var i = 0; i < sTitle.length; i++) {
                if ((sTitle[i] == title) && (sGender[i] == args.Value)) {
                    result = true;
                }
            }

            args.IsValid = result;
        }
        //end by ank
        function CheckPIN(src, args) {
            var result = true;
            var CountryCode = document.getElementById("<%=txtCountryCodeAddr.ClientID%>").value;
            var Pin = document.getElementById("<%=txtPin.ClientID%>").value;

            if (CountryCode.toUpperCase() == "IND") {
                if (!IsNumeric(Pin)) {
                    result = false;
                }
                if (Pin.length != 6) {
                    result = false;
                }
            }

            args.IsValid = result;
        }   
      
    
    </script>
    <asp:ScriptManager runat="server" ID="SM">
        <Scripts>
            <asp:ScriptReference Path="Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="Lookup.asmx" />
        </Services>
    </asp:ScriptManager>
    <div>
        <table id="Table1" runat="server" border="0" cellpadding="3" cellspacing="1" align="center">
            <tr>
                <td style="width: 700px;">
                    <table border="0" cellpadding="3" cellspacing="1" bgcolor="lavender" width="790"
                        align="center">
                        <tr>
                            <td class="test" colspan="5">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td colspan="3">
                                            <asp:UpdatePanel ID="UpdPanelHeader" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    &nbsp;<asp:Label ID="lblHeader" runat="server"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <input id="hdnUpdate" runat="server" type="hidden" />
                                        </td>
                                        <td align="right" colspan="2">
                                            CLTCRP V1.3
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" width="150px">
                                <span>Customer ID</span>
                                <asp:Button ID="btnPostback" runat="server" Visible="true" Width="0" OnClick="RetrievePopClt"
                                    CausesValidation="false" />
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelGCN" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtGCN" runat="server" CssClass="standardtextbox" MaxLength="12"
                                            Width="170px"></asp:TextBox>
                                        <asp:TextBox ID="txtCltStat" runat="server" CssClass="standardtextbox" BorderColor="Transparent"
                                            BorderStyle="None" Style="text-align: center" Width="50px">Active</asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" width="150px">
                                <span>Client Code</span>
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelCltCode" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCltCode" runat="server" CssClass="standardtextbox" MaxLength="12"
                                            Width="230px"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" width="150px">
                                <span>Company Name <font color="Red">*</font></span>
                            </td>
                            <td class="formcontent" colspan="3">
                                <asp:UpdatePanel ID="UpdPanelSurname" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="cboTitle" runat="server" CssClass="standardmenu">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" SetFocusOnError="True" ErrorMessage="Mandatory!"
                                            Display="Dynamic" ControlToValidate="cboTitle"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtSurname" runat="server" Width="510px" CssClass="standardtextbox"
                                            MaxLength="60"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVSurname" runat="server" ErrorMessage="Mandatory!"
                                            Display="Dynamic" ControlToValidate="txtSurname" Enabled="true"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="ctvSurname" runat="server" __designer:dtid="281474976710790"
                                            ErrorMessage="Invalid characters!" Display="Dynamic" ControlToValidate="txtSurname"
                                            ClientValidationFunction="doValidateName" SetFocusOnError="True" __designer:wfdid="w5"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <!--added by ank on 21.07.2011 for Gender validation-->
                                <asp:HiddenField ID="hdnGenderTitle1" runat="server" />
                                <asp:HiddenField ID="hdnGenderTitle2" runat="server" />
                                <!--end by ank-->
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" width="150px">
                                <span>Company Reg. No.</span>
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelCurrentID" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCurrentID" runat="server" Width="230px" CssClass="standardtextbox"
                                            MaxLength="24"></asp:TextBox>&nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" colspan="2">
                                <asp:Button ID="btnSearchClt" runat="server" CausesValidation="False" Visible="true"
                                    CssClass="standardbutton" Text="FIND" Width="60px" />
                                <asp:Button ID="cmdLookup1" runat="server" Text="..." Width="0" CausesValidation="False"
                                    CssClass="standardbutton" />
                            </td>
                        </tr>
                        <%--<tr>
                                <td class="formcontent" width="150">
                                    </td>
                                <td class="formcontent">
                                    </td>
                                <td class="formcontent" colspan="2">
                                </td>
                        </tr>--%>
                        <tr>
                            <td class="formcontent" width="230">
                                <asp:Label ID="lblChannel" runat="server"></asp:Label>
                                <span style="color: Red">*</span>
                            </td>
                            <td class="formcontent" width="230">
                                <asp:DropDownList ID="ddlChannels" runat="server" CssClass="standardmenu">
                                    <asp:ListItem Value=" ">--Select--</asp:ListItem>
                                    <asp:ListItem Value="CD">CDA Franchise</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                    ErrorMessage="Mandatory!" Enabled="true" Display="Dynamic" ControlToValidate="ddlChannels"></asp:RequiredFieldValidator>
                            </td>
                            <td class="formcontent" width="230">
                            </td>
                            <td class="formcontent" width="230">
                            </td>
                        </tr>
                        <!--added by ank on 19.07.2011 for Gender and Dateof Birth for CDA-->
                        <tr id="trDofB" runat="server">
                            <td class="formcontent">
                                <span>Gender <font color="Red">*</font></span>
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelGender" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="cboGender" class="standardmenu" runat="server" CssClass="standardmenu">
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="ctvGender" runat="server" SetFocusOnError="True" ErrorMessage="Invalid &#13;&#10;/Title!"
                                            ControlToValidate="cboGender" ClientValidationFunction="doValidate"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent">
                                <asp:Label ID="lblDofB" runat="server"></asp:Label><span style="color: #ff0000">*</span>
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelDOfB" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <uc7:cltDate ID="txtDOfB" runat="server" Width="180" CssClass="standardtextbox" RequiredField="false"
                                            RequiredValidationMessage="Date of Birth is required"></uc7:cltDate>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <!--end by ank on 19.07.2011 -->
                        <tr>
                            <td class="formcontent" width="150">
                                <span>PAN No.<font color="Red"></font></span>
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelPAN" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPan" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                            MaxLength="10"></asp:TextBox>
                                        <asp:CustomValidator ID="ctvPAN" runat="server" SetFocusOnError="True" ErrorMessage="Invalid PAN format!"
                                            Display="Dynamic" ControlToValidate="txtPan" ClientValidationFunction="CheckPANFormat"></asp:CustomValidator>
                                        <asp:Button ID="btnVerifyPAN" runat="server" Text="Verify" Enabled="false" CssClass="standardbutton"
                                            OnClick="btnVerifyPAN_Click" ValidationGroup="RecruitInfo"></asp:Button>
                                        <div id="divPAN" class="Content" style="display: none">
                                            <img src="../../../App_Themes/Isys/images/spinner.gif" />
                                            Loading...</div>
                                        <br />
                                        <asp:Label ID="lblPANMsg" runat="server" Style="color: #ff0000" Font-Bold="False"
                                            Font-Size="X-Small"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent">
                                Client Create Rule
                            </td>
                            <td class="formcontent">
                                <asp:DropDownList ID="ddlCltCreateRule" runat="server" CssClass="standardmenu">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" width="150">
                                Special Indicator
                            </td>
                            <td class="formcontent">
                                <asp:DropDownList ID="ddlSpecInd" runat="server" CssClass="standardmenu">
                                </asp:DropDownList>
                            </td>
                            <td class="formcontent">
                                Economic Activity
                            </td>
                            <td class="formcontent">
                                <asp:DropDownList ID="ddlEcon" runat="server" CssClass="standardmenu">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" width="150px">
                                <asp:Label ID="lblCnctType" runat="server" Width="160px"></asp:Label>
                            </td>
                            <td class="formcontent" width="230px">
                                <asp:UpdatePanel ID="UpdPanelCnctType" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="cboCnctType" runat="server" CssClass="standardmenu" AppendDataBoundItems="true"
                                            DataValueField="ParamValue" DataTextField="ParamDesc" DataSourceID="dsCnctType">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="dsCnctType" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                        </asp:SqlDataSource>
                                        <asp:RequiredFieldValidator ID="rfvCnctType" runat="server" SetFocusOnError="true"
                                            ErrorMessage="Mandatory!" Enabled="false" Display="None" ControlToValidate="cboCnctType"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="ctvCnctType" runat="server" SetFocusOnError="True" ErrorMessage="Invalid address!"
                                            Display="Dynamic" ControlToValidate="cboCnctType" ClientValidationFunction="CheckAddress"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <input id="hdnCnctType" runat="server" type="hidden" />
                            </td>
                            <td class="formcontent" width="230">
                                Category
                            </td>
                            <td class="formcontent" width="230">
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="standardmenu">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="3" cellspacing="1" width="790" align="center">
                        <tr>
                            <td style="width: 800px;">
                                <%--<uc1:AddAddr ID="CltAddrB1" runat="server" ></uc1:AddAddr>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left;" class="test">
                                &nbsp;<asp:Label ID="lblABHeadear" runat="server" Text="" Font-Size="10pt"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="100%" valign="top">
                                <table cellspacing="1" class="formtable" width="100%">
                                    <tr>
                                        <td nowrap="nowrap" class="formcontent" width="100%">
                                            <asp:Label ID="lblAddr1" runat="server"></asp:Label>
                                            <asp:Label ID="lblEst1" runat="server" Text="*" ForeColor="red"></asp:Label>
                                        </td>
                                        <td nowrap="nowrap" class="formcontent">
                                            <asp:TextBox Width="250px" ID="txtAddr1" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                MaxLength="30"></asp:TextBox>
                                            <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="doValidateAddress"
                                                ControlToValidate="txtAddr1" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator>
                                            <asp:RequiredFieldValidator ID="RFVAddr1" runat="server" ControlToValidate="txtAddr1"
                                                Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="formcontent">
                                            <asp:Label ID="lblAddr2" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td nowrap="nowrap" class="formcontent">
                                            <asp:TextBox Width="250px" ID="txtAddr2" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                MaxLength="30"></asp:TextBox>
                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="doValidateAddress"
                                                ControlToValidate="txtAddr2" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="formcontent">
                                            <asp:Label ID="lblAddr3" runat="server"></asp:Label>
                                        </td>
                                        <td nowrap="nowrap" class="formcontent">
                                            <asp:TextBox Width="250px" ID="txtAddr3" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                MaxLength="30"></asp:TextBox>
                                            <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="doValidateAddress"
                                                ControlToValidate="txtAddr3" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="formcontent">
                                            <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        <td nowrap="nowrap" class="formcontent">
                                            <asp:TextBox Width="250px" ID="txtAddr4" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                MaxLength="30" Visible="False"></asp:TextBox>
                                            <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="doValidateAddress"
                                                ControlToValidate="txtAddr4" Display="Dynamic" ErrorMessage="Invalid Address!"
                                                Visible="False"></asp:CustomValidator>
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
                                            <asp:Label ID="lblState" runat="server"></asp:Label>
                                            <asp:Label ID="lblEst3" runat="server" Text="*" ForeColor="red"></asp:Label>
                                        </td>
                                        <td nowrap="nowrap" class="formcontent">
                                            <asp:UpdatePanel ID="UpdPnlAddrState" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtStateCode" runat="server" CssClass="standardtextbox" Width="50px"
                                                        onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                    <asp:TextBox ID="txtStateDesc" runat="server" CssClass="standardtextbox" Width="130px"
                                                        Enabled="false"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:Button ID="btnState" runat="server" CausesValidation="False" CssClass="standardbutton"
                                                Text="..." Width="20px" />
                                            <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="txtStateDesc"
                                                Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="ctvState" runat="server" SetFocusOnError="True" Enabled="false"
                                                ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateCode"
                                                ClientValidationFunction="CheckStateList"></asp:CustomValidator>
                                            <asp:CustomValidator ID="ctvStateDesc" runat="server" SetFocusOnError="True" Enabled="false"
                                                ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateDesc"
                                                ClientValidationFunction="CheckStateList"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="formcontent" width="150px">
                                            <asp:Label ID="lblPin" runat="server"></asp:Label>
                                            <asp:Label ID="lblEst4" runat="server" Text="*" ForeColor="red"></asp:Label>
                                        </td>
                                        <td nowrap="nowrap" class="formcontent">
                                            <asp:TextBox Width="230" ID="txtPin" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                MaxLength="8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFVPin" runat="server" ControlToValidate="txtPin"
                                                Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="CVPin" runat="server" Enabled="true" ErrorMessage="Invalid Pin!"
                                                Display="Dynamic" ControlToValidate="txtPin" ClientValidationFunction="CheckPIN"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="formcontent" width="150px">
                                            <asp:Label ID="lblCountryCodeAddr" runat="server"></asp:Label>
                                            <asp:Label ID="lblEst5" runat="server" Text="*" ForeColor="red"></asp:Label>
                                        </td>
                                        <td nowrap="nowrap" class="formcontent">
                                            <asp:TextBox ID="txtCountryCodeAddr" runat="server" CssClass="standardtextbox" Width="50px"
                                                onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                            <asp:TextBox ID="txtCountryDescAddr" runat="server" CssClass="standardtextbox" Width="130px"
                                                Enabled="false"></asp:TextBox>
                                            <asp:Button ID="btnCountryAddr" runat="server" CausesValidation="False" CssClass="standardbutton"
                                                Text="..." Width="20px" />
                                            <asp:RequiredFieldValidator ID="rfvCountryAddr" runat="server" ControlToValidate="txtCountryDescAddr"
                                                Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="ctvCountryAddrCode" runat="server" SetFocusOnError="True"
                                                Enabled="false" ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryCodeAddr"
                                                ClientValidationFunction="CheckCountryList"></asp:CustomValidator>
                                            <asp:CustomValidator ID="ctvCountryAddrDesc" runat="server" SetFocusOnError="True"
                                                Enabled="false" ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryDescAddr"
                                                ClientValidationFunction="CheckCountryList"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 800px">
                            </td>
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
                                <asp:Label ID="lblDstbnMethod" runat="server" Width="160"></asp:Label>
                            </td>
                            <td class="test" colspan="1">
                                <asp:UpdatePanel ID="UpdPanelddlDstbnMethod" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <uc4:ddlLookup ID="ddlDstbnMethod" runat="server" RequiredField="false"
                                            LookupCode="DstbnMtd" CssClass="standardmenu"></uc4:ddlLookup>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="test" colspan="1">
                                <asp:Label ID="lblPrivacy" runat="server" Width="145px"></asp:Label>
                            </td>
                            <td class="test">
                                <asp:UpdatePanel ID="UpdPanelddlPrivacy" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <uc4:ddlLookup ID="ddlPrivacy" runat="server"  RequiredField="false" LookupCode="PrvcStat"
                                            CssClass="standardmenu"></uc4:ddlLookup>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        </table>
                        <table>
                        <tr>
                            <td nowrap="nowrap" class="formcontent" style="width: 93%" >
                            <asp:Label ID="Label5" runat="server"  Text = "Work Tel"></asp:Label>
                              
                            </td>
                            <td  nowrap="nowrap" class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelWorkTel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtWorkTel" runat="server" Width="200px" CssClass="standardtextbox"
                                            MaxLength="16"></asp:TextBox>
                                        <asp:CustomValidator ID="ctvWorkTel" runat="server" ErrorMessage="Invalid Tel No!"
                                            Display="Dynamic" ControlToValidate="txtWorkTel" ClientValidationFunction="CheckMobileTelFormat"
                                            SetFocusOnError="True"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent">
                                <span>Mobile No<font color="Red">*</font></span>
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelCmpnyTel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCmpnyTel" runat="server" Width="230px" CssClass="standardtextbox"
                                            MaxLength="16"></asp:TextBox>
                                        <asp:CustomValidator ID="ctvCmpnyTel" runat="server" ErrorMessage="Invalid Tel No!"
                                            Display="Dynamic" ControlToValidate="txtCmpnyTel" ClientValidationFunction="CheckMobileFormat"
                                            SetFocusOnError="True"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 93%">
                                <span>Work Fax</span>
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelWorkFax" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtWorkFax" runat="server" Width="200px" CssClass="standardtextbox"
                                            MaxLength="16"></asp:TextBox>
                                        <asp:CustomValidator ID="ctvWorkFax" runat="server" ErrorMessage="Invalid Tel No!"
                                            Display="Dynamic" ControlToValidate="txtWorkFax" ClientValidationFunction="CheckMobileTelFormat"
                                            SetFocusOnError="True"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent">
                                <span>Email</span>
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelEmail" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtEmail" runat="server" Width="230px" CssClass="standardtextbox"
                                            MaxLength="50"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" __designer:dtid="562949953421617"
                                            ErrorMessage="Invalid Email!" Display="Dynamic" ControlToValidate="txtEmail"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" __designer:wfdid="w5"></asp:RegularExpressionValidator>
                                        <%--added by Priyanka--%>
                                        <asp:CustomValidator ID="cvEmail" runat="server" ErrorMessage="Invalid Email!" Display="Dynamic"
                                            ControlToValidate="txtEmail" ClientValidationFunction="CheckValidEmail" SetFocusOnError="True"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 93%">
                                <span>Website</span>
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelWebsite" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtWebsite" runat="server" Width="200px" CssClass="standardtextbox"
                                            MaxLength="50"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" nowrap = "nowrap" >
                                <span>Converted under VLE project</span>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkVLE" runat="server" Width="300" CssClass="standardcheckbox"
                                    TextAlign="Left"></asp:CheckBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 93%">
                                Contact Person
                            </td>
                            <td class="formcontent" colspan="3">
                                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="standardtextbox" MaxLength="30"
                                    Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <table border="0" cellpadding="3" cellspacing="1" width="790" align="center">
                        <tr>
                            <td class="test" colspan = "4">
                                <span>Company Details</span>
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="formcontent" style="width: 93%">
                                <asp:Label ID="lblDOB" runat="server" Width="120px"></asp:Label>
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelDOB" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <uc7:cltDate ID="txtDOB" runat="server" Width="180" CssClass="standardtextbox" RequiredField="false"
                                            RequiredValidationMessage="Date Incorporated is required"></uc7:cltDate>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>
                            <td class="formcontent" width="200">
                                <asp:UpdatePanel ID="UpdPanelBirthPlace" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtBirthPlace" runat="server" CssClass="standardtextbox" 
                                            MaxLength="30"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 93%">
                                Original Country
                            </td>
                            <td class="formcontent">
                                <asp:UpdatePanel ID="UpdPanelCountry" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCountryCode" runat="server" class="standardtextbox" Width="50px"
                                            onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                        &nbsp;<asp:TextBox ID="txtCountryDesc" runat="server" class="standardtextbox" Width="100px"
                                            Enabled="false"></asp:TextBox>
                                        &nbsp;<asp:Button ID="btnCountry" runat="server" CausesValidation="False" CssClass="standardbutton"
                                            Text="..." Width="20px" />
                                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="txtCountryDesc"
                                            Display="Dynamic" Enabled="false" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="ctvCountry" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Country Code!"
                                            Display="Dynamic" ControlToValidate="txtCountryCode" ClientValidationFunction="CheckList"></asp:CustomValidator>
                                        <asp:CustomValidator ID="ctvCountryDesc" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Country Code!"
                                            Display="Dynamic" ControlToValidate="txtCountryDesc" ClientValidationFunction="CheckList"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent">
                                <asp:Label ID="lblCapital" runat="server"></asp:Label>
                                <font color="Red">*</font>
                            </td>
                            <td class="formcontent" width="160px">
                                <asp:UpdatePanel ID="UpdPanelCapital" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox Style="text-align: right" ID="txtCapital" runat="server" Width="160px"
                                            CssClass="standardtextbox" MaxLength="18"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv3" runat="server" ErrorMessage="Mandatory!" Display="Dynamic"
                                            ControlToValidate="txtCapital" Enabled="false" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CVCapital" runat="server" Display="Dynamic" ControlToValidate="txtCapital"
                                            Type="Currency" Operator="DataTypeCheck" ErrorMessage="Invalid Capital!"></asp:CompareValidator>
                                        <asp:CustomValidator ID="ctvCapital" runat="server" ErrorMessage="Invalid Capital!"
                                            Display="Dynamic" ControlToValidate="txtCapital" ClientValidationFunction="CheckCapitalLimit"
                                            SetFocusOnError="True"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 93%">
                                <asp:Label ID="lblStaffSz" runat="server" Width="160"></asp:Label>
                            </td>
                            <td class="formcontent" width="200">
                                <asp:UpdatePanel ID="UpdPanelStaffSz" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox Style="text-align: right" ID="txtStaffSz" runat="server" CssClass="standardtextbox"
                                            MaxLength="15" Width="160px"></asp:TextBox>
                                        <asp:CompareValidator ID="CVSz" runat="server" Display="Dynamic" ErrorMessage="Invalid Staff size!"
                                            Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtStaffSz"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="rfvStaffSz" runat="server" SetFocusOnError="True"
                                            ErrorMessage="Mandatory!" Enabled="false" Display="Dynamic" ControlToValidate="txtStaffSz"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="ctvStaffSz" runat="server" SetFocusOnError="True" ErrorMessage="Out of range!"
                                            Display="Dynamic" ControlToValidate="txtStaffSz" ClientValidationFunction="CheckStaffSzLimit"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" colspan="2">
                                <asp:UpdatePanel ID="UpdPanelSalesTax" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkSalesTax" runat="server" Width="300" Text="Service Tax Applicable "
                                            CssClass="standardcheckbox" TextAlign="Left" Checked="True"></asp:CheckBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 93%">
                                Annual Turnover
                            </td>
                            <td class="formcontent" width="160px">
                                <asp:UpdatePanel ID="UpdPanelAnnTurnover" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox Style="text-align: right" ID="txtAnnTurnover" runat="server" CssClass="standardtextbox"
                                            MaxLength="21" Width="160px"></asp:TextBox>
                                        <asp:CompareValidator ID="CVATurnOver" runat="server" Display="Dynamic" ErrorMessage="Invalid Annual Turnover!"
                                            Operator="DataTypeCheck" Type="Currency" ControlToValidate="txtAnnTurnover"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="rfvTurnOver" runat="server" SetFocusOnError="True"
                                            ErrorMessage="Mandatory!" Enabled="false" Display="Dynamic" ControlToValidate="txtAnnTurnover"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="ctvTurnOver" runat="server" SetFocusOnError="True" ErrorMessage="Out of range!"
                                            Display="Dynamic" ControlToValidate="txtAnnTurnover" ClientValidationFunction="CheckAnnTurnoverLimit"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent">
                                Prefered Client
                            </td>
                            <td class="formcontent">
                                <asp:CheckBox ID="chkVip" runat="server" CssClass="standardcheckbox" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:RequiredFieldValidator ID="rfvDupFlg" runat="server" SetFocusOnError="True"
                                    ErrorMessage="Please press 'Exact Match' button to check the match client before proceed."
                                    Enabled="true" Display="Dynamic" ControlToValidate="txtDupBtnFlag"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label ID="lblErrMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        </table>
                        <tr>
                            <td class="formcontent" colspan="4">
                                <table id="Table2" runat="server" border="0" cellpadding="3" cellspacing="1">
                                    <tr>
                                        <td align="left" width="400">
                                            &nbsp;<asp:Button ID="btnSave" runat="server" CssClass="standardbutton" Enabled="true"
                                                OnClick="btnSave_Click" Text="Save" Width="80px" />
                                            <asp:Button ID="btnDupCltRecords" runat="server" Text="Exact Match" Enabled="true"
                                                CausesValidation="false" CssClass="standardbutton" />
                                            <asp:Button ID="btnCancel2" runat="server" CausesValidation="false" Width="80px"
                                                Text="Cancel" CssClass="standardbutton" OnClientClick="doCancel2();return false" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Width="80px" Text="Cancel"
                                                CssClass="standardbutton" OnClientClick="doCancel();return false" />
                                        </td>
                                        <td align="right" width="400">
                                            <uc8:ClientAML ID="btnAML" runat="server" CssClass="standardbutton" Visible="false" />
                                            &nbsp;
                                            <%--<uc8:ClientAML ID="btnAML" runat="server" CssClass="standardbutton" Text="AML" Width="80px" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtFlagFind" runat="server" Width="0px" Text="" BorderStyle="None"
                                                BorderColor="transparent"></asp:TextBox>
                                            <asp:Label ID="Label4" Visible="false" runat="server" ForeColor="Red" Text="For CDA Channel PAN No should be updated through Easy CRM only..."></asp:Label>
                                            <%--<asp:RequiredFieldValidator id="rfvFlg" runat="server" SetFocusOnError="True" ErrorMessage="Please press 'FIND' button to check the match client before proceed." Enabled="true" Display="Dynamic" ControlToValidate="txtFlagFind"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnDupFlag" />
                    <asp:HiddenField runat="server" ID="hdnTempClientCode" />
                    <asp:HiddenField runat="server" ID="hdnClientCode" />
                    <asp:TextBox runat="server" ID="txtDupBtnFlag" Width="0px" Text="" BorderStyle="None"
                        BorderColor="transparent" Wrap="true" />
                </td>
            </tr>
            <tr>
                <td style="width: 727px; height: 20px" align="left">
                </td>
            </tr>
        </table>
    </div>

    
    <script language="javascript" type="text/javascript">
        var err = "<%=lblErrMsg.Text%>";
        if (err != "") {
            alert(err);
        }        
    </script>
    
    <!---------------------------------------Error/Confirmation MsgBox--------------------------------------------->
    <asp:Button ID="hdnbtn" runat="server" Text="Button" Style="visibility: hidden" OnClick="hdnbtn_OnClick" />
    <asp:Button ID="hdnComfirmbtn" Style="visibility: hidden" runat="server" Text="Button"
        OnClick="hdnComfirmbtn_OnClick" />
    <asp:Button ID="hdnComfirmbtnM" Style="visibility: hidden" runat="server" Text="Button"
        OnClick="hdnComfirmbtn_OnClick" />
    <!---------------------------------------Error Msg--------------------------------------------->
    <asp:Panel ID="PanelError" runat="server" BackColor="#E0E0E0" HorizontalAlign="Center"
        Style="display: none" Width="400px">
        <br />
        <asp:UpdatePanel runat="server" ID="upderror" RenderMode="Inline" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lblError1" runat="server" Width="380px" Font-Size="8pt" Font-Bold="true"
                    Height="30px"></asp:Label><br />
                <asp:TextBox ID="lblError2" runat="server" Width="380px" Text="Label" Enabled="false"
                    BorderStyle="None" Height="100px" Wrap="true" TextMode="MultiLine"></asp:TextBox><br />
                <asp:Label ID="lblError3" runat="server" Width="380px" Height="30px"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmdYes" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="cmdNo" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="cmdYesM" EventName="Click"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        <asp:Button ID="cmdErrorCancel" runat="server" Width="59px" Text="OK" CssClass="standardbutton"
            CausesValidation="false" OnClick="cmdOk_ClsMsg" /><br />
        <br />
    </asp:Panel>
    <!---------------------------------------Confirm Msg--------------------------------------------->
    <asp:Panel ID="PanelComfirm" DefaultButton="cmdYes" runat="server" BackColor="#E0E0E0"
        HorizontalAlign="Center" Style="display: none" Width="400px">
        <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
            border-bottom: black 1px solid" width="400">
            <tr>
                <td align="left" valign="top" class="test">
                    <asp:Label ID="lblComfirmHeader" runat="server" Font-Size="8pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formcontent2">
                    <br />
                    <asp:UpdatePanel runat="server" ID="updcomfirm" RenderMode="Inline" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lblComfirm1" runat="server" Width="380px" Font-Size="8pt"></asp:Label><br />
                            <asp:Label ID="lblComfirm2" runat="server" Width="380px" Font-Size="8pt"></asp:Label><br />
                            <asp:Label ID="lblComfirm3" runat="server" Width="380px" Font-Size="8pt"></asp:Label><br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdYes" EventName="Click"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="cmdNo" EventName="Click"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="cmdCancel" EventName="Click"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                    <asp:Button ID="cmdYes" runat="server" Width="59px" Text="Yes" CssClass="standardbutton"
                        CausesValidation="false" OnClick="cmdYes_Click" />
                    <asp:Button ID="cmdNo" runat="server" Width="59px" Text="No" CssClass="standardbutton"
                        CausesValidation="false" OnClick="cmdNo_Click" />
                    <asp:Button ID="cmdCancel" runat="server" Width="59px" Text="Cancel" CausesValidation="false"
                        CssClass="standardbutton" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <!---------------------------------------Confirm Msg--------------------------------------------->
    <asp:Panel ID="PanelComfirmM" DefaultButton="cmdYesM" runat="server" BackColor="#E0E0E0"
        HorizontalAlign="Center" Style="display: none" Width="400px">
        <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
            border-bottom: black 1px solid" width="400">
            <tr>
                <td align="left" valign="top" class="test">
                    <asp:Label ID="Label2" runat="server" Font-Size="8pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formcontent2">
                    <br />
                    <asp:UpdatePanel runat="server" ID="updcomfirmM" RenderMode="Inline" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lblComfirmM1" runat="server" Width="380px" Font-Size="8pt"></asp:Label><br />
                            <asp:Label ID="lblComfirmM2" runat="server" Width="380px" Font-Size="8pt"></asp:Label><br />
                            <asp:Label ID="lblComfirmM3" runat="server" Width="380px" Font-Size="8pt"></asp:Label><br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdYesM" EventName="Click"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="cmdCancelM" EventName="Click"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                    <asp:Button ID="cmdYesM" runat="server" Width="59px" Text="Yes" CssClass="standardbutton"
                        CausesValidation="false" OnClick="cmdYes_Click" />
                    <asp:Button ID="cmdCancelM" runat="server" Width="59px" Text="Cancel" CausesValidation="false"
                        CssClass="standardbutton" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <!--added by ankita on 06.02.2012-->
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="updPnlHidden" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hdnAgnCode" runat="server" />
                            <asp:HiddenField ID="hdnPan" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="MPEError" TargetControlID="hdnbtn" runat="server"
        BackgroundCssClass="modalBackground" PopupControlID="PanelError">
    </ajaxToolkit:ModalPopupExtender>
    <%--<ajaxToolkit:ModalPopupExtender ID="MPEComfirm" TargetControlID="hdnComfirmbtn" runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelComfirm" OkControlID="cmdYes" CancelControlID="cmdNo"></ajaxToolkit:ModalPopupExtender>--%>
    <ajaxToolkit:ModalPopupExtender ID="MPEComfirm" TargetControlID="hdnComfirmbtn" runat="server"
        BackgroundCssClass="modalBackground" PopupControlID="PanelComfirm" CancelControlID="cmdCancel"
        OnCancelScript="SetFocus('ctl00_ContentPlaceHolder1_cmdCancel');">
    </ajaxToolkit:ModalPopupExtender>
    <ajaxToolkit:ModalPopupExtender ID="MPEComfirmM" TargetControlID="hdnComfirmbtnM"
        runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelComfirmM"
        CancelControlID="cmdCancelM" OnCancelScript="SetFocus('ctl00_ContentPlaceHolder1_cmdCancelM');">
    </ajaxToolkit:ModalPopupExtender>
    <script type="text/javascript" language="javascript">
        eval("<%=strInit%>");
    </script>
    <script type="text/javascript">
        function funOpenPopWin(strPageName, strPayeeCode, strValue, strCode, strSource) {
            if (strPageName == 'DuplicateCltRecords.aspx') {
                document.getElementById('<%= txtDupBtnFlag.ClientID%>').value = "1";
            }
            showPopWin(strPageName + "?Code=" + strPayeeCode + "&Field1=" + strValue + "&Field2=" + strCode + "&Source=" + strSource, 500, 350, null);
            return false;
        }		
    </script>
<%--Added by rachana on 15-07-2013 for adding panal pnl strat--%>
<asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="322px" Height="221px">
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
                 <center><asp:Label ID="lblpopup" runat="server"></asp:Label><br /><br /></center>                
                 <br />
                 
                 </td>
                 </tr>
                 </table>  
                 <center><asp:Button ID="btnok" CssClass="standardbutton" runat="server" Text="OK" TabIndex="105" 
                        OnClick="cmdOk_ClsMsg"/></center>               
                   </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--Added by rachana on 15-07-2013 for adding panal pnl end--%>
</asp:Content>

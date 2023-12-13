<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClientAddress.ascx.cs" Inherits="Application_Common_ClientAddress" %>
<link href="~/Styles/subModal.css" rel="stylesheet" type="text/css" />
<link href="/Container/Styles/main.css" rel="stylesheet" type="text/css" />
<%--<script type="text/javascript" src="~/Scripts/common.js"></script>
<script type="text/javascript" src="~/Scripts/subModal.js"></script>
--%><script language="javascript" type="text/javascript">
var path = "<%=Request.ApplicationPath.ToString()%>";

    function popAddress(add1, add2, add3, add4, city, state, postcode, country, readonly, title)
    {
        showPopWin("PopAddress.aspx?Add1=" + doEncodeToPopup(add1) +
            "&Add2=" + doEncodeToPopup(add2) +
            "&Add3=" + doEncodeToPopup(add3) +
            "&Add4=" + doEncodeToPopup(add4) +
            "&City=" + doEncodeToPopup(city) +
            "&State=" + doEncodeToPopup(state) +
            "&Postcode=" + doEncodeToPopup(postcode) +
            "&Country=" + doEncodeToPopup(country) +
            "&vAdd1=" + doEncodeToPopup(document.getElementById(add1).value) +
            "&vAdd2=" + doEncodeToPopup(document.getElementById(add2).value) +
            "&vAdd3=" + doEncodeToPopup(document.getElementById(add3).value) +
            "&vAdd4=" + doEncodeToPopup(document.getElementById(add4).value) +
            "&vCity=" + doEncodeToPopup(document.getElementById(city).value) +
            "&vState=" + doEncodeToPopup(document.getElementById(state).value) +
            "&vPostcode=" + doEncodeToPopup(document.getElementById(postcode).value) +
            "&vCountry=" + doEncodeToPopup(document.getElementById(country).value) +
            "&ReadOnly=" + readonly +
            "&Title=" + doEncodeToPopup(title)
            , 700, 350, null);        
    }
    
</script>

<asp:Button ID="btnAddress" Text="Address" runat="server" />
<input id="hdnAdd1" runat="server" type="hidden" />
<input id="hdnAdd2" runat="server" type="hidden" />
<input id="hdnAdd3" runat="server" type="hidden" />
<input id="hdnAdd4" runat="server" type="hidden" />
<input id="hdnCity" runat="server" type="hidden" />
<input id="hdnState" runat="server" type="hidden" />
<input id="hdnPostcode" runat="server" type="hidden" />
<input id="hdnCountry" runat="server" type="hidden" />
<input id="hdnDistrict" runat="server" type="hidden" />
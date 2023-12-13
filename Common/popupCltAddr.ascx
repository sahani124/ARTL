<%@ Control Language="C#" AutoEventWireup="true" CodeFile="popupCltAddr.ascx.cs" Inherits="Application_Common_popupCltAddr" %>
<%@ Register Src="~/App_UserControl/Common/ddlLookup.ascx" TagName="ddlLookup" TagPrefix="uc1" %>
<%@ Register Src="~/App_UserControl/Common/popupLookup.ascx"TagName="popLookup" TagPrefix="uc2" %>

<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline"></asp:UpdatePanel> &nbsp;
<asp:Button ID="cmdSearch" runat="server" Text="Addr" CausesValidation="False" Width="140px" CssClass="standardbutton" /><br/>

<asp:Panel ID="Panel1" runat="server" Width="750px" Height="150px" BackColor="black">
    <table align="center" style="width: 750px" bgcolor="DarkGray" border="0" bordercolor="gainsboro">
        <tr>
            <td colspan="4" style=" text-align: left;" class="test">
                &nbsp;<asp:Label ID="lblABHeadear" runat="server"  Font-Size="10pt"></asp:Label></td>
        </tr>
        <tr>
            <td class="formcontent" width="170px">
                <asp:Label ID="lblAddr1" runat="server"></asp:Label></td>
            <td class="formcontent">
                <asp:TextBox width="250px" ID="txtAddr1" runat="server" Font-Bold="False" CssClass="standardtextbox"></asp:TextBox></td>
            <td class="formcontent">
                <asp:Label ID="lblCity" runat="server" Width="150px"></asp:Label></td>
            <td class="formcontent">
                <asp:TextBox width="230px" ID="txtCity" runat="server" Font-Bold="False" CssClass="standardtextbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="formcontent" width="170px">
                <asp:Label ID="lblAddr2" runat="server" ></asp:Label></td>
            <td class="formcontent" >
                <asp:TextBox width="250px" ID="txtAddr2" runat="server" Font-Bold="False" CssClass="standardtextbox"></asp:TextBox></td>
            <td class="formcontent" >
                <asp:Label ID="lblState" runat="server" Width="150px"></asp:Label></td>
            <td class="formcontent">            
                <uc1:ddlLookup ID="cboState" runat="server" LookupCode="NBState" RequiredField="false" Width="235" /></td>
            </tr>
        <tr>
            <td class="formcontent" width="150px">
                <asp:Label ID="lblAddr3" runat="server"></asp:Label></td>
            <td class="formcontent">
                <asp:TextBox width="250px" ID="txtAddr3" runat="server" Font-Bold="False" CssClass="standardtextbox"></asp:TextBox></td>
            <td class="formcontent" >
                <asp:Label ID="lblPin" runat="server"  Width="150px"></asp:Label></td>
            <td class="formcontent">
                <asp:TextBox width="230" ID="txtPin" runat="server" Font-Bold="False" CssClass="standardtextbox"></asp:TextBox></td>
        </tr>   
        <tr>
            <td class="formcontent" width="150px">
                <asp:Label ID="lblAddr4" runat="server" Text=""></asp:Label></td>
            <td class="formcontent" >
                <asp:TextBox width="250px" ID="txtAddr4" runat="server" Font-Bold="False" CssClass="standardtextbox"></asp:TextBox></td>
            <td class="formcontent" >
                <asp:Label ID="lblCountry" runat="server"  Width="150px"></asp:Label></td>
            <td class="formcontent" >
                <uc1:ddlLookup ID="cboCountry" runat="server" LookupCode="NBLocate" RequiredField="false" Width="235" /></td>
        </tr>  
        <tr>
            <td colspan="4">
               <asp:TextBox ID="txtAddrNo" runat="server" Visible="false" Text=""></asp:TextBox>
               <asp:TextBox ID="txtGCN" runat="server" Visible="false" Text=""></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt;">
            <td align="center" style="width: 736px;" colspan="6">
                &nbsp;<asp:Button ID="CancelButton" runat="server" Text="OK" Width="80px" CausesValidation="False" CssClass="standardbutton" OnClick="CancelButton_Click" />
                &nbsp;
            </td>
        </tr>  
    </table>    
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="cmdSearch" PopupControlID="Panel1" CancelControlID="CancelButton">
</ajaxToolkit:ModalPopupExtender>


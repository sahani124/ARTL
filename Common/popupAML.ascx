<%@ Control Language="C#" AutoEventWireup="true" CodeFile="popupAML.ascx.cs" Inherits="Application_Common_popupAML" %>
<%@ Register Src="~/App_UserControl/Common/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="~/App_UserControl/Common/ddlLookup.ascx" TagName="ddlLookup" TagPrefix="uc1" %>

<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline"></asp:UpdatePanel> &nbsp;
<asp:Button ID="cmdSearch" runat="server" Text="AML" CausesValidation="False" Width="80px" CssClass="standardbutton" /><br/>

<asp:Panel ID="Panel1" runat="server" Width="750px" Height="150px" BackColor="black">
    <table align="center" style="width: 750px" bgcolor="gainsboro" border="0" bordercolor="gainsboro" cellpadding="3">
        <tr>
            <td colspan="4" bgcolor="Navy" height="30px" class="test"  >
                &nbsp;<asp:label ID="lblPersonalDetail" runat="server"></asp:label></td>
        </tr>
        <tr style="font-size: 8pt;">
            <td class="formcontent" rowspan="">
                &nbsp;<asp:label ID="lblHeigth" runat="server"></asp:label></td>
            <td class="formcontent" colspan="1" rowspan="">
                <asp:TextBox ID="txtHeight" runat="server" CssClass="standardtextbox" Width="50" MaxLength="10" CausesValidation="true"></asp:TextBox>
                <asp:CompareValidator id="cvHeight" runat="server" Display="Dynamic" errormessage="Invalid height!" operator="DataTypeCheck" type="Currency" controltovalidate="txtHeight"></asp:CompareValidator> 
            </td>
            <td class="formcontent" ><asp:label ID="lblWeight" runat="server"></asp:label></td>
            <td class="formcontent" >
                &nbsp;<asp:TextBox ID="txtWeight" runat="server" CssClass="standardtextbox" Width="50" MaxLength="10" CausesValidation="true"></asp:TextBox>
                <asp:CompareValidator id="cvWeight" runat="server" Display="Dynamic" errormessage="Invalid weight!" operator="DataTypeCheck" type="Currency" controltovalidate="txtWeight"></asp:CompareValidator> 
            </td>            
        </tr>
        <tr style="font-size: 8pt;">
             <%--Commented by Anoop on 20-11-2007--%>
            <%--<td class="formcontent">
                &nbsp;<span>Age Proof</span></td>
            <td class="formcontent">
                <uc1:ddlLookup id="DdlProofAge" runat="server" RequiredField="true" Width="235" CssClass="standardmenu" LookupCode="NBAgeProof"></uc1:ddlLookup> 
            </td>            --%>    
            <%--End of Comment--%>
            <td class="formcontent">
                <span><span><asp:label ID="lblChangedReason" runat="server"></asp:label></span></span></td>
            <td class="formcontent" width="240">
                <asp:TextBox ID="txtChgWghtReason" CssClass="standardtextbox" MaxLength="50" runat="server" Width="188" />
                <asp:RequiredFieldValidator ID="rfvChgWghtReason" runat="server" SetFocusOnError="true" Enabled="false" Display="None" ControlToValidate="txtChgWghtReason" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator></td>           
        </tr>
        <tr style="font-size: 8pt;">
            <td class="formcontent">
                &nbsp;<span><asp:label ID="lblIncomProof" runat="server"></asp:label></span></td>
            <td class="formcontent" style="width: 235px">
                <uc1:ddlLookup id="DdlProofIncome" runat="server" RequiredField="true" Width="235" CssClass="standardmenu" LookupCode="NBINCProof"></uc1:ddlLookup> 
            </td>
            <td class="formcontent" >
                &nbsp;<asp:label ID="lblAddressProof" runat="server"></asp:label><span></span></td>
            <td class="formcontent">
                <uc1:ddlLookup id="DdlProofAddr" runat="server" RequiredField="true" Width="235" CssClass="standardmenu" LookupCode="NBAddProof"></uc1:ddlLookup>
            </td>           
        </tr>
        <tr style="font-size: 8pt;">
            <td class="formcontent" >
                &nbsp;<span><asp:label ID="lblIdentityProof" runat="server"></asp:label></span></td>
            <td class="formcontent">
                <uc1:ddlLookup id="DdlProofID" runat="server" RequiredField="true" Width="235" CssClass="standardmenu" LookupCode="NBIDProof"></uc1:ddlLookup>
            </td>
            <td class="formcontent">
                <span><asp:label ID="lblIssueAuthority" runat="server"></asp:label></span></td>
            <td class="formcontent">
                <asp:TextBox ID="txtIdIssueAuth" runat="server" CssClass="standardtextbox" Width="188" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvIdIssueAuth" runat="server" SetFocusOnError="true" Enabled="true" Display="None" ControlToValidate="txtIdIssueAuth" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator></td>           
        </tr>
        <tr style="font-size: 8pt;">
            <td class="formcontent">
                &nbsp;<span><asp:label ID="lblIdentityNo" runat="server"></asp:label></span></td>
            <td class="formcontent">
                <asp:TextBox ID="txtIDNo" runat="server" CssClass="standardtextbox" Width="188" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvIDNo" runat="server" SetFocusOnError="true" Enabled="true" Display="None" ControlToValidate="txtIDNo" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator></td>
            <td class="formcontent">
                <span><asp:label ID="lblIsuuedate" runat="server"></asp:label></span></td>
            <td class="formcontent">
                <uc2:txtDate ID="txtIdIssueDate" RequiredField="true" CssClass="standardtextbox" Width="188" runat="server" />
            </td>           
        </tr> 
        <tr style="font-size: 8pt;">
            <td class="formcontent" colspan="2" >                
                <asp:CheckBox ID="chkPhoto" runat="server" TextAlign="Left" /></td>
                <%--Commented by Anoop on 20-11-2007--%>
            <%--<td class="formcontent">
                <span>Photo Id Proof</span></td>
            <td class="formcontent">
                <uc1:ddlLookup id="DdlProofPhtID" runat="server" RequiredField="true" Width="235" CssClass="standardmenu" LookupCode="NBPhtProof"></uc1:ddlLookup>
            </td>   --%>        
            <%--End of Comment--%>
        </tr>  
        <tr style="font-size: 8pt;">
            <td align="center" style="width: 736px;" colspan="6">
                <asp:Button ID="btnSave" runat="server" Text="OK" Width="80px" CausesValidation="true"  OnClick="btnSave_OnClick" CssClass="standardbutton" />
                <%--<asp:Button ID="btnClear" runat="server" Text="Clear" Width="80px" CausesValidation="False" OnClick="btnClear_Click" CssClass="standardbutton" />--%>
                <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" CausesValidation="False" OnClick="doCancel();return false;" CssClass="standardbutton" />--%>
            </td>
        </tr>
    </table>    
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID=cmdSearch PopupControlID="Panel1" CancelControlID="btnSave">
</ajaxToolkit:ModalPopupExtender>







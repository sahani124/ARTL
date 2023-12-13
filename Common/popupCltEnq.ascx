<%@ Control Language="C#" AutoEventWireup="true" CodeFile="popupCltEnq.ascx.cs" Inherits="Application_Common_popupCltEnq" %>

<asp:UpdatePanel ID="UpdatePanel20" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>        
        <asp:TextBox ID="txtCountryCode" Visible="false" runat="server" Width="33px" AutoPostBack="true" OnTextChanged="txtCountryCode_TextChanged"></asp:TextBox>
        <asp:TextBox ID="txtCountryDesc" Visible="false" runat="server" Enabled="false" Width="122px"></asp:TextBox>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostbackTrigger ControlID="txtCountryCode" EventName="TextChanged" />
        <asp:AsyncPostbackTrigger ControlID="gvCountry" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
<asp:Button ID="cmdSearch" runat="server" Text="..." CausesValidation=" False" /><br />
<asp:Panel ID="Panel1" runat="server" Style="display: none" Width="500px" Height="313px" BackColor="#E0E0E0">
    <table align="center" style="width: 500px">              
        <tr >
            <td align="center">
                <br />
                <asp:Label ID="lblSearch" runat="server"  Width="100"></asp:Label>
                <asp:TextBox ID="txtSearchCountry" runat="server" Width="100" ></asp:TextBox>  
            <td align="center" >
                <br />
                <asp:Label ID="lblSearchDescription" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" Width="100"></asp:TextBox>              
        </tr>
        <tr>
            <td align="center" colspan="2" >
                <asp:Label ID="lblSearchDesc" runat="server" ></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </tr>
        <tr>
            <td align="center" colspan="2" >
                <asp:Label ID="lblSearchDescrip2" runat="server"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </tr>
        <tr>
            <td align="center" style="height: 35px">
                <asp:Button ID="cmbPSearch" runat="server" Text="Search" OnClick="cmbPSearch_Click" CausesValidation="False" /></td>
        </tr>
        <tr>
            <td align="center">              
                <asp:UpdatePanel ID="updPnlCountry" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:GridView ID="gvCountry" runat="server" AutoGenerateColumns="False" DataSourceID="dsCountry" 
                            AllowPaging="True" HorizontalAlign="Center" Width="600px" OnSelectedIndexChanged="gvCountry_SelectedIndexChanged"
                            OnPageIndexChanging="gvCountry_PageIndexChanging" DataKeyNames="FullName" Visible=false >
                            <Columns>
                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnInsert" runat="server" CausesValidation=false OnClick="Name_OnClick" CommandName="Select" Text='<%# Bind("GCN") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FullName" HeaderText="Name" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="GenderDesc" HeaderText="Gender" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="BirthRegDate" HeaderText="Date Of Birth" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="IDType" HeaderText="ID Type" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblNoSearchResult" runat="server"></asp:Label>
                            </EmptyDataTemplate>  
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsCountry" runat="server" ConnectionString="<%$ ConnectionStrings:INSCCommonConnectionString %>">
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostbackTrigger ControlID="cmbPSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" height=40>
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" CausesValidation="False" /></td>
        </tr>
    </table>
    
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID=cmdSearch PopupControlID="Panel1" CancelControlID="CancelButton">
</ajaxToolkit:ModalPopupExtender>
<asp:RequiredFieldValidator ID="RFV" runat="server" Enabled=false Display="None" ControlToValidate="txtCountryDesc" ErrorMessage="RequiredFieldValidator">
</asp:RequiredFieldValidator>
<ajaxToolkit:ValidatorCalloutExtender ID="VCE" runat="server" TargetControlID=RFV>
</ajaxToolkit:ValidatorCalloutExtender>
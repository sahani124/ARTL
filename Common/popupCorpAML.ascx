<%@ Control Language="C#" AutoEventWireup="true" CodeFile="popupCorpAML.ascx.cs" Inherits="Application_Common_popupCorpAML" %>
<%@ Register Src="~/App_UserControl/Common/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="~/App_UserControl/Common/popupLookup.ascx" TagName="popupLookup" TagPrefix="uc1" %>

<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline"></asp:UpdatePanel> &nbsp;
<asp:Button ID="cmdSearch" runat="server" Text="AML" CausesValidation="False" Width="80px" /><br/>

<asp:Panel ID="Panel1" runat="server" Width="750px" Height="150px" BackColor="black">
    <table align="center" style="width: 750px" bgcolor="gainsboro" border="0" bordercolor="gainsboro">
        <tr>
            <td colspan="4" bgcolor="Navy" height="30px" style=" color:White; font-weight:bold; "  >
                &nbsp;<asp:label ID="lblCorporateDetail" runat="server"></asp:label></td>
        </tr>
        <tr style="font-size: 8pt;">
            <td class="formcontent" width="300" colspan="2" style="height: 26px"  >
                &nbsp;<span><asp:label ID="lblHeight" runat="server"></asp:label></span>&nbsp;&nbsp;
                <asp:TextBox ID="txtHeight" runat="server" Width="50" MaxLength="10" ></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                            
                <span><asp:label ID="lblWeight" runat="server"></asp:label></span>&nbsp;&nbsp;
                <asp:TextBox ID="txtWeight" runat="server" Width="50" MaxLength="10"></asp:TextBox></td>
            <td class="formcontent" width="130"  >
                &nbsp;<span><asp:label ID="lblChangeReason" runat="server"></asp:label></span></td>
            <td class="formcontent" width="235"  >                                        
                <asp:TextBox ID="txtChgWghtReason" MaxLength="50" runat="server" Width="188" />    
            </td>            
        </tr>
        <tr style="font-size: 8pt;">
            <td class="formcontent" width="110">
                &nbsp;<span><asp:label ID="lblAgeProof" runat="server"></asp:label></span></td>
            <td class="formcontent" width="235">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>                        
                        <asp:TextBox ID="txtProofAgeDoc" MaxLength="8" runat="server" Width="60" AutoPostBack="true" OnTextChanged="txtProofAgeDoc_TextChanged" />
                        <asp:TextBox ID="txtProofAgeDocDesc" runat="server" Width="120" Enabled="false" />                        
                    </ContentTemplate>                   
                </asp:UpdatePanel>
                <asp:Button ID="cmdLookup1" runat="server" Text="..." Width="20px" CausesValidation="False" />
            </td>                
            <td class="formcontent" width="120">
                &nbsp;<span><asp:label ID="lblAddressProof" runat="server"></asp:label></span></td>
            <td class="formcontent" width="240">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server"  RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtProofAddrDoc" MaxLength="8" runat="server" Width="60" AutoPostBack="true" OnTextChanged="txtProofAddrDoc_TextChanged" />
                        <asp:TextBox ID="txtProofAddrDocDesc" runat="server" Width="120" Enabled="false" /> 
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="cmdLookup4" runat="server" Text="..." Width="20px" CausesValidation="False" />
            </td>           
        </tr>
        <tr style="font-size: 8pt;">
            <td class="formcontent" width="110">
                &nbsp;<span><asp:label ID="lblIncomeProof" runat="server"></asp:label></span></td>
            <td class="formcontent" style="width: 235px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtProofIncomeDoc" MaxLength="8" runat="server" Width="60" AutoPostBack="true" OnTextChanged="txtProofIncomeDoc_TextChanged" />
                        <asp:TextBox ID="txtProofIncomeDocDesc" runat="server" Width="120" Enabled="false" />
                    </ContentTemplate>                    
                </asp:UpdatePanel>
                <asp:Button ID="cmdLookup2" runat="server" Text="..." Width="20px" CausesValidation="False" />
            </td>
            <td class="formcontent" width="120">
                &nbsp;<span></span></td>
            <td class="formcontent" width="100"></td>           
        </tr>
        <tr style="font-size: 8pt;">
            <td class="formcontent" width="110">
                &nbsp;<span><asp:label ID="lblIdentityProof" runat="server"></asp:label></span></td>
            <td class="formcontent" style="width: 235px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtProofIDDoc" MaxLength="8" runat="server" Width="60" AutoPostBack="true" OnTextChanged="txtProofIDDoc_TextChanged" />
                        <asp:TextBox ID="txtProofIDDocDesc" runat="server" Width="120" Enabled="false" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="cmdLookup3" runat="server" Text="..." Width="20px" CausesValidation="False" />
            </td>
            <td class="formcontent" width="120">
                &nbsp;<span>Issue Authority</span></td>
            <td class="formcontent" width="100">
                <asp:TextBox ID="txtIdIssueAuth" runat="server" Width="188" MaxLength="30"></asp:TextBox></td>           
        </tr>
        <tr style="font-size: 8pt;">
            <td class="formcontent" width="110">
                &nbsp;<span><asp:label ID="lblIdentityNo" runat="server"></asp:label></span></td>
            <td class="formcontent" style="width: 188px">
                <asp:TextBox ID="txtIDNo" runat="server" Width="188" MaxLength="20"></asp:TextBox></td>
            <td class="formcontent" width="120">
                &nbsp;<span><asp:label ID="lblIssueDate" runat="server"></asp:label></span></td>
            <td class="formcontent" width="235" >
                <uc2:txtDate ID="txtIdIssueDate" Width="188" runat="server" />
            </td>           
        </tr> 
        <tr style="font-size: 8pt;">
            <td class="formcontent" width="110" colspan="2" >                
                <asp:CheckBox ID="chkPhoto" Text="Photos         " runat="server" TextAlign="Left" /></td>
            <td class="formcontent" width="120" >
                &nbsp;<span><asp:label ID="lblPhotoIdProof" runat="server"></asp:label></span></td>
            <td class="formcontent" width="235">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtProofPhtIDDoc" MaxLength="8" runat="server" Width="60" AutoPostBack="true" OnTextChanged="txtProofPhtIDDoc_TextChanged" />
                        <asp:TextBox ID="txtProofPhtIDDocDesc" runat="server" Width="120" Enabled="false" />
                    </ContentTemplate>                    
                </asp:UpdatePanel>
                <asp:Button ID="cmdLookup5" runat="server" Text="..." Width="20px" CausesValidation="False" />               
            </td>           
        </tr>  
        <tr style="font-size: 8pt;">
            <td align="center" style="width: 736px;" colspan="6">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" CausesValidation="False" OnClick="btnSave_Click" />
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" Width="80px" CausesValidation="False" />
            </td>
        </tr>
    </table>    
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID=cmdSearch PopupControlID="Panel1" CancelControlID="CancelButton">
</ajaxToolkit:ModalPopupExtender>

<!-- // Lookup1 = Age Proof -->
<!-- // Lookup2 = Income Proof -->
<!-- // Lookup3 = Indentity Proof -->
<!-- // Lookup4 = Address Proof -->
<!-- // Lookup5 = Photo Id Proof -->

<asp:Panel ID="PanelLookup1" Runat="server">     
    <asp:UpdatePanel ID="UpdatePanelLookup1" runat="server" UpdateMode="Conditional" RenderMode="Inline"></asp:UpdatePanel>
    <table align="center" style="width: 369px" bgcolor="DarkGray">
        <tr>
            <td align="center" style="height: 20px; width: 365px; font-weight:bold;" > 
                <asp:Label ID="lblTitleLookup1" runat="server" BackColor="DarkGray"/>
            </td>
        </tr>
        <tr>        
            <td align="center" style="height: 35px; width: 365px;">
                <asp:Label ID="lblSearch1" runat="server"></asp:Label>
                <asp:TextBox ID="txtSearch1" runat="server"></asp:TextBox>
                <asp:Button ID="cmbSearch1" runat="server" Text="Search" OnClick="cmbSearch1_Click" CausesValidation="False"/></td>
        </tr>
        <tr>
            <td align="center" style="width: 365px">              
                <asp:UpdatePanel ID="updPnlLookup1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:GridView ID="gvLookup1" runat="server" AutoGenerateColumns="False" DataSourceID="dsLookup1"
                            AllowPaging="True" HorizontalAlign="Center" Width="292px" OnSelectedIndexChanged="gvLookup1_SelectedIndexChanged"
                            OnPageIndexChanging="gvLookup1_PageIndexChanging" DataKeyNames="ParamDesc" Visible=false>
                            <Columns>
                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnInsert1" runat="server" CausesValidation=false CommandName="Select" Text='<%# Bind("ParamValue") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ParamDesc" HeaderText="Description" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblMsgLookup1" runat="server"></asp:Label>
                            </EmptyDataTemplate>  
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsLookup1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostbackTrigger ControlID="cmbSearch1" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" height=40 style="width: 365px">               
                <asp:Button ID="cmdLookupCancel1" runat="server" Text="Cancel" CausesValidation="False" /></td>
        </tr>
    </table>
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID=cmdLookup1 PopupControlID="PanelLookup1" CancelControlID="cmdLookupCancel1">
</ajaxToolkit:ModalPopupExtender>

<!-- // Lookup2 = Income Proof -->
<asp:Panel ID="PanelLookup2" Runat="server">     
    <asp:UpdatePanel ID="UpdatePanelLookup2" runat="server" UpdateMode="Conditional" RenderMode="Inline"></asp:UpdatePanel>
    <table align="center" style="width: 369px" bgcolor="DarkGray">
        <tr>
            <td align="center" style="height: 20px; width: 365px; font-weight:bold;" > 
                <asp:Label ID="lblTitleLookup2" runat="server"  BackColor="DarkGray"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 35px; width: 365px;">                
                <asp:Label ID="lblSearch2" runat="server"  ></asp:Label>
                <asp:TextBox ID="txtSearch2" runat="server"></asp:TextBox>
                <asp:Button ID="cmbSearch2" runat="server" Text="Search" OnClick="cmbSearch2_Click" CausesValidation="False"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 365px">              
                <asp:UpdatePanel ID="updPnlLookup2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:GridView ID="gvLookup2" runat="server" AutoGenerateColumns="False" DataSourceID="dsLookup2"
                            AllowPaging="True" HorizontalAlign="Center" Width="292px" OnSelectedIndexChanged="gvLookup2_SelectedIndexChanged"
                            OnPageIndexChanging="gvLookup2_PageIndexChanging" DataKeyNames="ParamDesc" Visible=false>
                            <Columns>
                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:LinkButton  Font-Bold=true ID="btnInsert2" runat="server" CausesValidation=false CommandName="Select" Text='<%# Bind("ParamValue") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ParamDesc" FooterStyle-ForeColor="white" FooterStyle-Font-Bold=true HeaderText="Description" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblMsgLookup1" runat="server"></asp:Label>
                            </EmptyDataTemplate>  
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsLookup2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostbackTrigger ControlID="cmbSearch2" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" height=40 style="width: 365px">               
                <asp:Button ID="cmdLookupCancel2" runat="server" Text="Cancel" CausesValidation="False" /></td>
        </tr>
    </table>
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID=cmdLookup2 PopupControlID="PanelLookup2" CancelControlID="cmdLookupCancel2">
</ajaxToolkit:ModalPopupExtender>

<!-- // Lookup3 = Identity Proof -->
<asp:Panel ID="PanelLookup3" Runat="server">     
    <asp:UpdatePanel ID="UpdatePanelLookup3" runat="server" UpdateMode="Conditional" RenderMode="Inline"></asp:UpdatePanel>
    <table align="center" style="width: 369px" bgcolor="DarkGray">
        <tr>
            <td align="center" style="height: 20px; width: 365px; font-weight:bold;" > 
                <asp:Label ID="lblTitleLookup3" runat="server"  BackColor="DarkGray"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 35px; width: 365px;">                
                <asp:Label ID="lblSearch3" runat="server"></asp:Label>
                <asp:TextBox ID="txtSearch3" runat="server"></asp:TextBox>
                <asp:Button ID="cmbSearch3" runat="server" Text="Search" OnClick="cmbSearch3_Click" CausesValidation="False"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 365px">              
                <asp:UpdatePanel ID="updPnlLookup3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:GridView ID="gvLookup3" runat="server" AutoGenerateColumns="False" DataSourceID="dsLookup3"
                            AllowPaging="True" HorizontalAlign="Center" Width="292px" OnSelectedIndexChanged="gvLookup3_SelectedIndexChanged"
                            OnPageIndexChanging="gvLookup3_PageIndexChanging" DataKeyNames="ParamDesc" Visible=false>
                            <Columns>
                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:LinkButton  Font-Bold=true ID="btnInsert3" runat="server" CausesValidation=false CommandName="Select" Text='<%# Bind("ParamValue") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ParamDesc" FooterStyle-ForeColor="white" FooterStyle-Font-Bold=true HeaderText="Description" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblMsgLookup1" runat="server" ></asp:Label>
                            </EmptyDataTemplate>  
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsLookup3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostbackTrigger ControlID="cmbSearch3" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" height=40 style="width: 365px">               
                <asp:Button ID="cmdLookupCancel3" runat="server" Text="Cancel" CausesValidation="False" /></td>
        </tr>
    </table>
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender4" runat="server" TargetControlID=cmdLookup3 PopupControlID="PanelLookup3" CancelControlID="cmdLookupCancel3">
</ajaxToolkit:ModalPopupExtender>

<asp:Panel ID="PanelLookup4" Runat="server">     
    <asp:UpdatePanel ID="UpdatePanelLookup4" runat="server" UpdateMode="Conditional" RenderMode="Inline"></asp:UpdatePanel>
    <table align="center" style="width: 369px" bgcolor="DarkGray">
        <tr>
            <td align="center" style="height: 20px; width: 365px; font-weight:bold;" > 
                <asp:Label ID="lblTitleLookup4" runat="server" BackColor="DarkGray"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 35px; width: 365px;">                
                <asp:Label ID="lblSearch4" runat="server" ></asp:Label>
                <asp:TextBox ID="txtSearch4" runat="server"></asp:TextBox>
                <asp:Button ID="cmbSearch4" runat="server" Text="Search" OnClick="cmbSearch4_Click" CausesValidation="False"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 365px">              
                <asp:UpdatePanel ID="updPnlLookup4" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:GridView ID="gvLookup4" runat="server" AutoGenerateColumns="False" DataSourceID="dsLookup4"
                            AllowPaging="True" HorizontalAlign="Center" Width="292px" OnSelectedIndexChanged="gvLookup4_SelectedIndexChanged"
                            OnPageIndexChanging="gvLookup4_PageIndexChanging" DataKeyNames="ParamDesc" Visible=false>
                            <Columns>
                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:LinkButton  Font-Bold=true ID="btnInsert4" runat="server" CausesValidation=false CommandName="Select" Text='<%# Bind("ParamValue") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ParamDesc" FooterStyle-ForeColor="white" FooterStyle-Font-Bold=true HeaderText="Description" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblMsgLookup1" runat="server"></asp:Label>
                            </EmptyDataTemplate>  
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsLookup4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostbackTrigger ControlID="cmbSearch4" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" height=40 style="width: 365px">               
                <asp:Button ID="cmdLookupCancel4" runat="server" Text="Cancel" CausesValidation="False" /></td>
        </tr>
    </table>
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender5" runat="server" TargetControlID=cmdLookup4 PopupControlID="PanelLookup4" CancelControlID="cmdLookupCancel4">
</ajaxToolkit:ModalPopupExtender>

<asp:Panel ID="PanelLookup5" Runat="server">     
    <asp:UpdatePanel ID="UpdatePanelLookup5" runat="server" UpdateMode="Conditional" RenderMode="Inline"></asp:UpdatePanel>
    <table align="center" style="width: 369px" bgcolor="DarkGray">
        <tr>
            <td align="center" style="height: 20px; width: 365px; font-weight:bold;" > 
                <asp:Label ID="lblTitleLookup5" runat="server" BackColor="DarkGray"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 35px; width: 365px;">                
                <asp:Label ID="lblSearch5" runat="server" ></asp:Label>
                <asp:TextBox ID="txtSearch5" runat="server"></asp:TextBox>
                <asp:Button ID="cmbSearch5" runat="server" Text="Search" OnClick="cmbSearch5_Click" CausesValidation="False"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 365px">              
                <asp:UpdatePanel ID="updPnlLookup5" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:GridView ID="gvLookup5" runat="server" AutoGenerateColumns="False" DataSourceID="dsLookup5"
                            AllowPaging="True" HorizontalAlign="Center" Width="292px" OnSelectedIndexChanged="gvLookup5_SelectedIndexChanged"
                            OnPageIndexChanging="gvLookup5_PageIndexChanging" DataKeyNames="ParamDesc" Visible=false>
                            <Columns>
                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:LinkButton  Font-Bold=true ID="btnInsert5" runat="server" CausesValidation=false CommandName="Select" Text='<%# Bind("ParamValue") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ParamDesc" FooterStyle-ForeColor="white" FooterStyle-Font-Bold=true HeaderText="Description" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblMsgLookup1" runat="server"></asp:Label>
                            </EmptyDataTemplate>  
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsLookup5" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostbackTrigger ControlID="cmbSearch5" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" height=40 style="width: 365px">               
                <asp:Button ID="cmdLookupCancel5" runat="server" Text="Cancel" CausesValidation="False" /></td>
        </tr>
    </table>
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender6" runat="server" TargetControlID=cmdLookup5 PopupControlID="PanelLookup5" CancelControlID="cmdLookupCancel5">
</ajaxToolkit:ModalPopupExtender>


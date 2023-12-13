<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" Inherits="Application_Admin_AdmUsrGrpSettings" Title="Untitled Page" CodeFile="AdmUsrGrpSettings.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;
    <table>
        <tr>
            <td style="width: 349px">
                <asp:Label ID="Label1" runat="server" Text="User Group : " Width="81px"></asp:Label>
    <asp:DropDownList ID="cmbSort" runat="server" Width="198px" OnSelectedIndexChanged="cmbSort_SelectedIndexChanged" AutoPostBack=true></asp:DropDownList></td>
            <td style="width: 44px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
       <tr><td style="width: 349px">
           <asp:TextBox ID="txtSearchUser" runat="server"></asp:TextBox>
           <asp:Button ID="btnSearchUser" runat="server" Text="Search" OnClick="btnSearchUser_Click" /></td><td></td><td>
           <asp:TextBox ID="txtSearchGroup" runat="server"></asp:TextBox>
           <asp:Button ID="btnSearchGroup" runat="server" Text="Search" OnClick="btnSearchGroup_Click" /></td></tr> 
        <tr>
            <td style="width: 349px" valign="top">
    <asp:GridView ID="UserGrid" runat="server" AutoGenerateColumns="False" Width="347px" OnRowCommand="OpenWindow" DataKeyNames="UserID"  >
        <Columns>
               <asp:TemplateField>       
                      <ItemStyle VerticalAlign="Top" /> 
                      <ItemTemplate>     
                          <asp:CheckBox ID="SelectedUser" runat="server" />      
                      </ItemTemplate>   
               </asp:TemplateField>  
               <asp:TemplateField Visible="false">   
                      <ItemTemplate >     
                          <asp:Label ID="lblUserID" runat="server"><%# DataBinder.Eval(Container.DataItem, "UserID") %></asp:Label>
                      </ItemTemplate>   
               </asp:TemplateField>                 
               <asp:TemplateField HeaderText="User">                  
                      <ItemStyle VerticalAlign="Top" />  
                      <ItemTemplate>  
                          <asp:LinkButton CommandName="User"  ID="LinkGroup" runat="server"><%# DataBinder.Eval(Container.DataItem, "UserName") %></asp:LinkButton>     
                      </ItemTemplate>   
               </asp:TemplateField>  
               <asp:TemplateField HeaderText="Group">                  
                      <ItemStyle VerticalAlign="Top"  />  
                      <ItemTemplate>  
                           <asp:LinkButton CommandName="Group" ID="HyperLink1"  runat="server"><%# DataBinder.Eval(Container.DataItem, "UserGroup") %></asp:LinkButton>        
                      </ItemTemplate>   
               </asp:TemplateField>  
        </Columns>
    </asp:GridView>
            </td>
            <td style="width: 44px" valign="top">
                <asp:Button ID="btnSet" runat="server" OnClick="btnSet_Click" Style="left: 244px;
                    top: 259px" Text="<" Width="44px" /><asp:Button ID="btnSetAll" runat="server" OnClick="btnSetAll_Click"
                        Style="left: 244px; top: 259px" Text=">>" Width="44px" /></td>
            <td style="width: 100px" valign="top">
                <asp:ListBox ID="lstiUsrGrpAcs" runat="server" Height="329px" Width="240px"></asp:ListBox></td>
        </tr>
    </table>
</asp:Content>


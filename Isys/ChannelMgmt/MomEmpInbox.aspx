<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MomEmpInbox.aspx.cs" Inherits="Application_INSC_ChannelMgmt_MomEmpInbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table   align="center" style="border-collapse: separate;  left: 0in; width:100%; position: relative; top: 8px;">
<tr>
<td>
<div class="ImgTab">
<ul >
<li>
<asp:LinkButton ID="lbInbox" runat="server"  style="background-color:#fafafa;" Text="New Emp Inbox"></asp:LinkButton>
</li>
</ul>
  <div class="TabContent">
<asp:GridView ID="GridInbox" runat="server" AllowSorting="True" CssClass="formtable"
    AutoGenerateColumns="false"
    AllowPaging="True" >
    <Columns>
    <asp:TemplateField SortExpression="EmpCode" HeaderText="Employee Code" >
    <ItemTemplate>
    <asp:Label ID="lblEmpCode" runat="server" Text='<%# Eval("EmpCode") %>'></asp:Label>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="110px"  />
    </asp:TemplateField >
    <asp:TemplateField SortExpression="EmpName" HeaderText="Employee Name">
    <ItemTemplate>
    <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="left" />
    </asp:TemplateField>
    <asp:TemplateField SortExpression="EmpType" HeaderText="Designation">
    <ItemTemplate>
    <asp:Label ID="lblEmpDesg" runat="server" Text='<%# Eval("EmpType") %>'></asp:Label>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="left" />
    </asp:TemplateField>
    <asp:TemplateField SortExpression="EmpChn" HeaderText="Channel">
    <ItemTemplate>
    <asp:Label ID="lblEmpChannnel" runat="server" Text='<%# Eval("EmpChn") %>'></asp:Label>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="left" />
    </asp:TemplateField>
    <asp:TemplateField SortExpression="EmpBranch" HeaderText="Branch">
    <ItemTemplate>
    <asp:Label ID="lblEmpUnit" runat="server" Text='<%# Eval("EmpBranch") %>'></asp:Label>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="left" />
    </asp:TemplateField>
    <asp:TemplateField SortExpression="AppNo" HeaderText="">
    <ItemTemplate>
   <asp:LinkButton ID="lbCreteEmp" runat="server" Text = "Create Emp" 
            onclick="lbCreteEmp_Click"></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    
    </Columns>
    <RowStyle CssClass="sublinkodd"></RowStyle>
    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
    </PagerStyle>
    <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White"/>
    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>                                 
                                           
</asp:GridView>
</div>
</div>
</td>

</tr>

</table>
</asp:Content>


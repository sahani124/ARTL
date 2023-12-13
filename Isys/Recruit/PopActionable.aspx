<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopActionable.aspx.cs" Inherits="Application_ISys_Recruit_PopActionable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script>
     function doCancel() {
         window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
     }
    </script>
<table id="tblhdr" runat="server" class="formtable table-condensed" style="border-collapse: separate; left: 0in;" width="80%;" >
    <tr>
     <td class="test" colspan="4" align="left"  style="border-collapse: separate;height:20px;" >
        <asp:Label ID="lblHeader" runat="server" Font-Bold="True" ></asp:Label>
        </td>
    </tr>
</table>
<table id="tblmsg" runat="server" class="formtable table-condensed" >
    <tr id="trmsgS" runat="server">
        <td colspan="2">
        <asp:Label ID="lblmsgS" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblmsgL" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblmsgF" runat="server" Visible="false"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
    </tr>
    <tr>
        <td class="formcontent" align="left" style="height: 24px;width=15px;">
        <asp:Label ID="lblAgCode" runat="server" Text="Agent Code" ></asp:Label>
        </td>
         <td class="formcontent" align="left" style="height: 24px;width=15px;">
        <asp:Label ID="lblAgCodeVal" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
      <td class="formcontent" align="left" style="height: 24px;width=15px;">
        <asp:Label ID="lblLcnNo" runat="server" Text="License No"></asp:Label>
      </td>
     <td class="formcontent" align="left" style="height: 24px;width=15px;">
         <asp:Label ID="lblLcnNoVal" runat="server" ></asp:Label>
      </td>
    </tr>
     <tr>
      <td class="formcontent" align="left" style="height: 24px;width=15px;">
        <asp:Label ID="lblDtExp" runat="server" Text="Date of Expiry"></asp:Label>
      </td>
     <td class="formcontent" align="left" style="height: 24px;width=15px;">
         <asp:Label ID="lblDtExpVal" runat="server" ></asp:Label>
      </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="standardbutton" OnClientClick="doCancel();return false;" />
        </td>
    </tr>
    </table>
</asp:Content>


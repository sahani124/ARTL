<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopWaiverAdvisor.aspx.cs" Inherits="Application_Common_PopWaiverAdvisor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<script type="text/javascript" src="~/Scripts/formatting.js"></script>
<script language="javascript" type="text/javascript">
function doCancel()
{
    window.parent.window.hidePopWin(false);
}
</script>

<head runat="server">
    <title>Waiver Advisor</title>
</head>
<body>
    <form id="form1"  runat="server">
    <div>
    
            <table class="formtable"  width="100%">
            <tr>
            <td>
    <asp:Label ID="lblMsg" runat="server" CssClass="msgerror2" ForeColor="Red" 
                                Visible="true"></asp:Label>
                                </td>
                                </tr>
                                <tr><td>
    <asp:GridView ID="gvWaiver" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" 
                                 PageSize="12" Width="100%">
                                <HeaderStyle CssClass="formlink" />
                                <AlternatingRowStyle CssClass="sublinkeven" />
                                <RowStyle CssClass="sublinkodd" />
                                <PagerStyle CssClass="pagelink" />
                                <Columns>   
                                    <asp:BoundField DataField="CndNo" HeaderText="Candidate ID" SortExpression="Cndno" />                                 
                                    <asp:BoundField DataField="Agentcode" HeaderText="Advisor Code" SortExpression="Agentcode" />
                                    <asp:BoundField DataField="Agentname" HeaderText="Advisor Name" SortExpression="Agentname" />
                                    <asp:BoundField DataField="csccode" HeaderText="Csc Code" SortExpression="csccode" />
                                </Columns>
                            </asp:GridView>
                            </td></tr>
                            </table>
                            
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopLookup.aspx.cs" Inherits="Application_Common_PopLookup" %>
<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="txtDate" TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
<link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<script language="javascript" type="text/javascript">
function doSelect(args1, args2, args3)
{
    if (window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>') != null)
    {
        window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').value = doEncodeToParent(args1);
    }
    if (window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>') != null)
    {
        window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').value = doEncodeToParent(args2);
    }
//    if (window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>') != null)
//    {
//        window.parent.document.getElementById('<%=Request.QueryString["Field3"].ToString()%>').value = args3;
//    }
    window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').focus();
    window.parent.window.hidePopWin(false);
    return false;
}
function doClear()
{
    document.getElementById("txtBranchCode").value = "";
    document.getElementById("txtBranchName").value = "";
}
function doCancel()
{
    window.parent.window.hidePopWin(false);
}
</script>
<head id="Head1" runat="server">
    <title>Branch</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="formtable" width="100%">
            <tr>
                <td class="formcontent" nowrap="nowrap">
                    <asp:Label ID="lblBranchCode" runat="server" ></asp:Label>
                </td>
                <td class="formcontent" width="100%">
                    <asp:TextBox CssClass="standardtextbox" ID="txtBranchCode" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="formcontent" nowrap="nowrap">
                    <asp:Label ID="lblBranchName" runat="server" ></asp:Label>
                </td>
                <td class="formcontent" width="100%">
                    <asp:TextBox CssClass="standardtextbox" ID="txtBranchName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button CssClass="standardbutton" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    <asp:Button CssClass="standardbutton" ID="btnClear" runat="server" Text="Clear" />
                    <asp:Button CssClass="standardbutton" ID="btnCancel" runat="server" Text="Cancel" OnClientClick="doCancel();return false;" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" OnSorting="gv_Sorting" OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" AllowPaging="True" AllowSorting="True">
                        <HeaderStyle CssClass="formlink" />
                        <AlternatingRowStyle CssClass="sublinkeven" />
                        <RowStyle CssClass="sublinkodd" />
                        <PagerStyle CssClass="pagelink" /> 
                        <Columns>
                            <asp:TemplateField HeaderText="Branch Code" SortExpression="ParamValue">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("ParamValue") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ParamDesc" NullDisplayText=" " HeaderText="Branch Name" SortExpression="ParamDesc" />
                            <asp:BoundField DataField="BankCode" NullDisplayText=" " HeaderText="Bank Code" SortExpression="BankCode" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

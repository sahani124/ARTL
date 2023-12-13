<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopNational.aspx.cs" Inherits="Application_Common_PopNational" %>
<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="txtDate" TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../../Styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<script type="text/javascript" src="~/Scripts/formatting.js"></script>
<script language="javascript" type="text/javascript">
function doSelect(args1, args2) {
    
    window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').value = args1;
    window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').value = args2;
    //Added by Rachana on 23-04-2013 for getting value from parent page on popup page start
    window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').focus();
    window.parent.window.hidePopWin(false);
    //Added by Rachana on 23-04-2013 for getting value from parent page on popup page end
    return false;
}

function doClear()
{
    document.getElementById("<%=txtStateCode.ClientID%>").value = "";
    document.getElementById("<%=txtStateDesc.ClientID%>").value = "";
}

function doCancel()
{
    window.parent.window.hidePopWin(false);
}
</script>
<head id="Head1" runat="server">
    <title>State</title>
</head>
<body>
    <atlas:ScriptManager ID="scriptMgr" EnablePartialRendering="true" runat="server" />
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Height="0%" Width="99%" DefaultButton="btnSearch">
        <table class="formtable" width="100%">
            <tr>
                <td class="formcontent" nowrap="nowrap">
                    <asp:Label ID="lblStateCode" runat="server" ></asp:Label>
                </td>
                <td class="formcontent" width="100%">
                    <asp:TextBox CssClass="standardtextbox" ID="txtStateCode" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="formcontent" nowrap="nowrap">
                    <asp:Label ID="lblStateDesc" runat="server" ></asp:Label>
                </td>
                <td class="formcontent" width="100%">
                    <asp:TextBox CssClass="standardtextbox" ID="txtStateDesc" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="formcontent" colspan="2" align="center" style="text-align: center">
                    <asp:Button CssClass="standardbutton" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /><asp:Button CssClass="standardbutton" ID="btnClear" runat="server" Text="Clear" OnClientClick="doClear();return false;" /><asp:Button CssClass="standardbutton" ID="btnCancel" runat="server" Text="Cancel" OnClientClick="doCancel();return false;" />
                </td>
            </tr>
            <tr>
                <td class="formcontent" colspan="2">
                    <atlas:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblErrMsg" runat="server" CssClass="msgerror2" 
                                Visible="False"></asp:Label>
                            <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound"
                                OnSorting="gv_Sorting" PageSize="12" Width="100%">
                                <HeaderStyle CssClass="test" />
                                <AlternatingRowStyle CssClass="sublinkeven" />
                                <RowStyle CssClass="sublinkodd" />
                                <PagerStyle CssClass="pagelink" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Nationality Code" SortExpression="ParamValue">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("ParamValue") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ParamDesc" HeaderText="Nationality Name" SortExpression="ParamDesc" />
                                </Columns>
                            </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <atlas:ControlEventTrigger ControlID="btnSearch" EventName="Click" />
                </Triggers>
            </atlas:UpdatePanel>
            
                </td>
            </tr>            
        </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccountPayeeCode.aspx.cs"
    Inherits="Application_INSC_ChannelMgmt_AccountPayeeCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../../Styles/style.css" type="text/css" rel="Stylesheet" />
    <link href="../../../Styles/main.css" type="text/css" rel="Stylesheet" />
    <link href="../../../assets/css/style-metronic.css" rel="stylesheet" type="text/css" />
    <link href="../../../assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../assets/css/style1.css" rel="stylesheet" type="text/css" />
    <link href="../../../assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">
        function doSelect(args1, args2, args3, strUnitCode, strCompUnitCode)
        {
            var strSource = <%=Request.QueryString["Source"].ToString()%>;
            
            if(strSource == "0")
            {
                window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').value = args3;
                window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').value = args1;
                window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').focus();
            }
            else if(strSource == "1")
            {
                window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').innerText = args3;
                window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').value = args1;
                window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').focus();
            }
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            return false;
        }

        function doClear()
        {
            document.getElementById("<%=txtAgntCode.ClientID%>").value = "";
            document.getElementById("<%=txtAgntName.ClientID%>").value = "";
            document.getElementById("<%=txtCustomerId.ClientID%>").value = "";
            
        }

        function doCancel()
        {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:500px;">
    <table style="width: 100%;" class="formtable2">
        <tr>
            <td class="test formHeader" colspan="4" align="left">
                Agent Search
            </td>
        </tr>
        <tr>
            <td align="left" class="formcontent" style="height: 24px; width: 109px;">
                <asp:Label ID="lblAgntCode" runat="server" Font-Bold="False" Width="103px"></asp:Label>
            </td>
            <td align="left" class="formcontent" style="width: 103px; height: 24px">
                <asp:TextBox ID="txtAgntCode" runat="server" CssClass="TextBox" Width="76px"></asp:TextBox>
            </td>
            <td align="left" class="formcontent" style="height: 24px; width: 86px;">
                <asp:Label ID="lblAgntName" runat="server" Font-Bold="False"></asp:Label>
            </td>
            <td align="left" class="formcontent" style="width: 121px; height: 24px">
                <asp:TextBox ID="txtAgntName" runat="server" CssClass="TextBox" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" class="formcontent" style="height: 24px; width: 109px;">
                <asp:Label ID="lblsalesChannel" runat="server" Width="112px"></asp:Label>
            </td>
            <td align="left" class="formcontent" style="width: 103px; height: 24px">
                <asp:DropDownList ID="ddlSlsChannel" runat="server" CssClass="standardmenu" OnSelectedIndexChanged="ddlSlsChannel_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td align="left" class="formcontent" style="height: 24px; width: 86px;">
                <asp:Label ID="lblChnCls" runat="server" Width="100px"></asp:Label>
            </td>
            <td align="left" class="formcontent" style="width: 121px; height: 24px">
                <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="standardmenu" Width="106px"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" class="formcontent" style="height: 24px; width: 109px;">
                <asp:Label ID="lblAgentType" runat="server" Width="81px"></asp:Label>
            </td>
            <td align="left" class="formcontent" colspan="3" style="width: 210px; height: 24px">
                <asp:DropDownList ID="ddlAgntType" runat="server" CssClass="standardmenu" OnSelectedIndexChanged="ddlAgntType_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" class="formcontent" style="width: 109px; height: 24px">
                <asp:Label ID="lblCustomerId" runat="server" Width="91px"></asp:Label>
            </td>
            <td align="left" class="formcontent" style="width: 103px; height: 24px">
                <asp:TextBox ID="txtCustomerId" runat="server" CssClass="TextBox" Width="74px" OnTextChanged="txtCustomerId_TextChanged"></asp:TextBox>
            </td>
            <td align="left" class="formcontent" style="width: 86px; height: 24px">
                <asp:Label ID="lblSapCode" runat="server"></asp:Label>
            </td>
            <td align="left" class="formcontent" style="width: 121px; height: 24px">
                <asp:TextBox ID="txtSapCode" runat="server" CssClass="TextBox" Width="76px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="formcontent" style="height: 18px; text-align: center;" colspan="4">
                <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" TabIndex="43"
                    Text="SEARCH" Width="80px" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" OnClientClick="doClear();return false;"
                    TabIndex="43" Text="CLEAR" Width="80px" />&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="standardbutton" OnClientClick="doCancel();return false;"
                    Text="CANCEL" Width="80px" />
            </td>
        </tr>
    </table>
    <br />
    <table width="100%" class="formtable2">
        <tr id="trDetails" runat="server">
            <td class="test formHeader" colspan="3" style="width: 70%;" align="left">
                Details
            </td>
            <td align="right" style="border-collapse: separate; width:30%;" class="test formHeader">
                <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trdgDetails" runat="server">
            <td class="formcontent" colspan="4" style="height: 21px">
                <asp:GridView ID="dgDetails" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                    Width="500px" OnRowDataBound="dgDetails_RowDataBound" RowStyle-CssClass="formtable"
                    PagerStyle-ForeColor="blue" PagerStyle-Font-Underline="true" PagerStyle-HorizontalAlign="Center"
                    AllowPaging="True" AllowSorting="True" OnSorting="dgDetails_Sorting" OnPageIndexChanging="dgDetails_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Agent Code" SortExpression="AgentCode">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAgntCode" runat="server" Text='<%# Bind("AgentCode") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Agent Name" DataField="LegalName" SortExpression="LegalName">
                            <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ClientCode" HeaderText="CustomerID" SortExpression="ClientCode">
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Agent Type" DataField="agentType" SortExpression="agentType">
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Immediate Leader" DataField="DirectAgtCode" SortExpression="DirectAgtCode">
                            <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Unit Code" DataField="unitCode" SortExpression="unitCode">
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnCompUntCode" Value='<%# Eval("CompUntCode") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle Font-Names="verdana" />
                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Center"></RowStyle>
                    <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White"/>
                    <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="formcontent" colspan="4">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" Height="10px"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="HierarchySearch.aspx.cs"
    Inherits="INSCL.HierarchySearch" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" width="60%">
        <tr>
            <td align="center" colspan="3" rowspan="3">
                &nbsp;
                <table class="formtable table-condensed" style="width: 100%">
                    <tr>
                        <td align="left" class="test formHeader" colspan="4">
                            Unit Hierarchy
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formcontent" style="width: 124px; height: 21px">
                            <asp:Label ID="lblSalesChannel" runat="server" Height="22px" Width="259px"></asp:Label>
                        </td>
                        <td align="center" class="formcontent" colspan="3" style="width: 524px; height: 21px">
                            <asp:DropDownList ID="ddlSalesChannel" runat="server" CssClass="standardmenu" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvSlsChnnl" runat="server" ControlToValidate="ddlSalesChannel"
                                Display="Dynamic" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" align="left" style="width: 7px">
                            <asp:Label ID="lblChnnlSubClass" runat="server" Width="119px"></asp:Label>
                        </td>
                        <td align="center" class="formcontent">
                            <asp:DropDownList ID="ddlChnnlSubClass" runat="server" CssClass="standardmenu">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvChnnlSubClass" runat="server" ControlToValidate="ddlChnnlSubClass"
                                Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="height: 26px">
                            <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" OnClick="btnSearch_Click"
                                TabIndex="43" Text="SEARCH" Width="80px" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" OnClick="btnClear_Click"
                                TabIndex="43" Text="CLEAR" Width="80px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table align="center" width="60%">
        <tr>
            <td align="center" colspan="4" class="formcontent2">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="False" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <table align="center" width="60%">
        <tr>
            <td align="center" colspan="3" rowspan="3">
                &nbsp;
                <table class="formtable" style="width: 100%">
                    <tr id="trDetails" runat="server">
                        <td align="left" class="test formHeader" colspan="4">
                            Unit Hierarchy Details
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TreeView ID="Trview" runat="server" ShowLines="True" OnSelectedNodeChanged="Trview_SelectedNodeChanged"
                                PopulateNodesFromClient="true" ExpandDepth="0" Width="100%" OnTreeNodePopulate="Trview_TreeNodePopulate"
                                BackColor="Transparent" Font-Bold="True" Font-Italic="False" Font-Size="8pt"
                                ForeColor="Black">
                            </asp:TreeView>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table align="center" width="100%">
        <tr>
            <td>
                <asp:Panel ID="pnlHierarchy" runat="server" Height="100%" Width="100%">
                    <iframe id="iframe1" runat="server" style="width: 100%; height: 600px;"></iframe>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

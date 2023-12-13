<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="AgtSearchHierarchydtls.aspx.cs" Inherits="Application_INSC_ChannelMgmt_AgtSearchHierarchydtls" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table align="center" width="60%">
		<tr>
			<td align="center" colspan="3" rowspan="3">
				&nbsp;
				<table class="formtable" style="width: 100%">
                <%--Added by rachana on 27-05-2013 for change in css class name start--%>
					<tr id="trDetails" runat="server">
						<td align="left" class="test formHeader" colspan="4">
							 Agent Hierarchy Details
						</td>
					</tr>
                    <%--Added by rachana on 27-05-2013 for change in css class name end--%>
					<tr>
						<td>
                            
							<asp:TreeView ID="trMgrHirarchy" runat="server" BackColor="Transparent" ExpandDepth="1"
								Font-Bold="True" Font-Italic="False" Font-Size="8pt" ForeColor="Black" 
								PopulateNodesFromClient="true" ShowLines="true" OnTreeNodePopulate="trMgrHirarchy_TreeNodePopulate">
								<HoverNodeStyle BackColor="Salmon" />
							</asp:TreeView>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
     <table align="center" width="100%">
    <tr>
    
    <td>
    
    <asp:Panel ID="pnlHierarchy" runat="server"  Height="100%"  Width="100%" >
                 
<iframe id="iframe1" runat="server"  style="width: 100%; height: 600px;"> </iframe>
                 
    </asp:Panel>
    </td>
    </tr>
    
    </table>
</asp:Content>


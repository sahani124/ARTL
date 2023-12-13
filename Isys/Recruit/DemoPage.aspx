<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="DemoPage.aspx.cs" Inherits="Application_ISys_Recruit_DemoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <center>
        <table class="container" width="100%">
            <tr>
                <td style="width: 100%;">
                    <table class="formtable" style="border-collapse: separate; left: 0.6in; position: relative;
                        top: 1px; width: 941px; z-index: 4; font-size:16px;">
                        <tr>
                            <td>
                                <asp:Label ID="lblInfo" runat="server" Text="On account of new developments according to IRDA Agent guidelines, ARTL will be closed for process enhancement until further notice." />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>

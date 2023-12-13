<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="ChannelData.aspx.cs" Inherits="Application_ISys_ChannelMgmt_ChannelData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .disablepage
        {
            display: none;
        }
        .formtablehdr 
        {
            background-color:#3399ff;
            color:#FAFAFA;
            FONT-FAMILY: Verdana, Tahoma, Arial;
            font-size: 16px;
            border:0px;
            text-align: left;
        }
    </style>
    <center>
        <asp:ScriptManager ID="scr" runat="server">
        </asp:ScriptManager>
        <table style="width: 80%;">
            <tr style="height: 30px;">
                <td class="formtablehdr">
                    <asp:Label ID="Label9" Text="" runat="server" Style="padding-left: 5px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="lblAgency" Text="Agency Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgAgency" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%# Bind("Agency")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="lblBanca" Text="Bancassurance Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgBanca" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("Banca")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label1" Text="DST Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgDST" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("DST")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label2" Text="Broker Relations" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgBrkRel" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("BrkRel")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label3" Text="Corp and Gov Sol Grp Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgCorp" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("CGSGrp")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label4" Text="Corporate Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgCorporate" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("Corp")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label5" Text="Direct Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgDirect" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("Dir")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label6" Text="Direct and District Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgDD" runat="server" AutoGenerateColumns="false" Width="100%" AllowSorting="True"
                                                        AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("DirDist")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label7" Text="Direct Group Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgDirGrp" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("DirGrp")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label8" Text="Direct-Group Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgDirGroup" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("DirGroup")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label11" Text="Large Corporate Enterprise" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgLarge" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind ("LCE")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label12" Text="Motor Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgMotor" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("Motor")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label13" Text="Other Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgOther" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("Other")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label15" Text="Retail Direct and Telesales Channel" runat="server"
                                                Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgRetail" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind ("Retdirtel")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label17" Text="RGIC Company" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgRGIC" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("RGIC")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label18" Text="Rural Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgRural" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("Rural")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label19" Text="Small Medium Enterprise Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgSME" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind ("SME")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label20" Text="Travel Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgTravel" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("Travel")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 5px;">
                                <table style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td class="formtablehdr">
                                            <asp:Label ID="Label21" Text="Web and Telesales Channel" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgWebTele" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                                        <RowStyle />
                                                        <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblChnl" runat="server" Text='<%#Bind("WebTel")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 50%; padding: 5px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>

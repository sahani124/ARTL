<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="Dataview_Unitrank.aspx.cs" Inherits="Application_ISys_ChannelMgmt_Dataview_Unitrank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../assets1/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
   
    <style type="text/css">
        .margin-top
        {
            margin-top: -109px;
        }
        .BtnGlyphicon
        {
            color: White !important;
        }
        
        .btn-primary
        {
            color: #fff;
            background-color: #428bca;
            border-color: #357ebd;
        }
        
        .modal-footer .btn-group .btn + .btn
        {
            margin-left: -1px;
        }
        
          #div1 { width: 150px; height: 150px; padding: 0.5em; }
  #div1 h3 { text-align: center; margin: 0; }
    </style>

    
  
    <script type="text/javascript">
        debugger;
        $(function () {
            $("#div1").resizable();
        });
    </script>

    <div id="show" runat="server" style="display: none;">
        <asp:Label ID="lblChannel" runat="server" Text="Channel" CssClass="control-label" style="margin-left:40%"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlChannel" runat="server" Width="20%" CssClass="select2-container form-control"
            AutoPostBack="true" OnSelectedIndexChanged="ddlChannel_SelectedIndexChanged">
        </asp:DropDownList>
<%--        <asp:Label ID="lblSubChannel" runat="server" Text="Channel" CssClass="control-label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSubChannel" runat="server" Width="20%" CssClass="select2-container form-control"
            AutoPostBack="true">
        </asp:DropDownList>--%>
    </div>
    <br />
    <div id="div1" runat="server" style="display: none;">
        <table id="tblIFrame" align="left" width="5%" height="495" style="margin-top: 7px;
            border-style: Solid; border-color: gray; border-width: 1px" runat="server">
            <tr>
                <td id="cell1" align="left" runat="server">
                    <%--   <asp:DataList ID="DataList1" runat="server"  style="line-height: 2.1em; margin-top:-146px;width:100%; margin-left:55px; margin-right:87px;">
                <ItemTemplate>
 
               <asp:LinkButton  runat="server" OnClick="lnk2_click" CommandArgument='<%# Eval("UnitRank")%>'>  <%# Eval("UnitRankDesc01")%></asp:LinkButton>
             </ItemTemplate>
            <ItemStyle Wrap="true"/>
    </asp:DataList>    
                    --%>
                    <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" NodeIndent="15" Style="margin-top: -245px;
                        margin-right: 78px;" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                        <NodeStyle Font-Names="Open Sans" Font-Size="10pt" ForeColor="#2a6496" HorizontalPadding="2px"
                            NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
                        <ParentNodeStyle Font-Bold="true" />
                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                    </asp:TreeView>
                    <%--<asp:Panel ID="Panel1" Height="300px" runat="server" ScrollBars="Auto">
            <asp:TreeView ID="TrVModule" runat="server" ShowCheckBoxes="All" ShowLines="True" Enabled="false" Height="300px"
                 Width="334px" CssClass="T1" Style="text-align: left">
                <LeafNodeStyle Font-Names="Tahoma" Font-Size="X-Small" CssClass="T1" />
            </asp:TreeView></asp:Panel>--%>
                </td>
            </tr>
        </table>
    </div>
    <div id="div2" runat="server" style="display: none;">
        <table id="tbList" cellspacing="0" cellpadding="0" height="500" width="80%" runat="server">
            <tr>
                <td>
                    <asp:ListView ID="productList" runat="server" Style="height: 80%;" GroupItemCount="4">
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td id="Td1" runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            <a href="DataView.aspx">
                                                <img src="../../../theme/iflow/Channel.jpg" width="100" height="75" /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>
                                                <asp:LinkButton ID="lnk1" runat="server" OnClick="lnk1_click" CommandArgument='<%# Eval("UnitRank")%>'> <%# Eval("UnitRankDesc01")%></asp:LinkButton>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                </p>
                            </td>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table style="width: 100%; border-style: solid; border-color: gray; border-width: 1px;
                                margin-left: 15px; margin-top: -5px;">
                                <tbody>
                                    <tr>
                                        <td style="border-bottom: 1px solid gray;">
                                            <table id="groupPlaceholderContainer" runat="server" style="width: 100%; margin-left: 118px;
                                                margin-top: 10px;">
                                                <tr id="groupPlaceholder">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </tbody>
                            </table>
                        </LayoutTemplate>
                    </asp:ListView>
                </td>
            </tr>
        </table>
    </div>
    <div id="div3" runat="server" style="display: none;">
        <table id="Table1" style="border-style: solid; width: 80%; border-color: gray; border-width: 1px;
            height: 495px; margin-left: 234px; margin-top: 8px;" runat="server">
            <tr>
                <td>
                    <asp:FormView ID="FormView1" runat="server" DefaultMode="ReadOnly">
                        <EditItemTemplate>
                            <%--              <img src="../../../theme/iflow/Backb.jpg"
                                            width="50" height="25" onclick="Img1_click"/></a>--%>
                            <%--  <img src="../../../theme/iflow/Forward.jpg"
                                            width="50" height="25"  onclick="Img2_click" /></a>--%>
                            <table style="width: 100%; margin-left: 5px; margin-top: -9%;">
                                <tbody>
                                    <tr>
                                        <td>
                                            <a href="DataView.aspx">
                                                <%-- ProductDetails.aspx?productID=<%#:Item.ProductID%>--%>
                                                <img src="../../../theme/iflow/Channel.jpg" width="70%" height="150" style="border: 1px solid gray; margin-top:-62px;" /></a>
                                        </td>
                                        <td style="padding-left: 80px;">
                                            <asp:Label ID="LblH" runat="server" CssClass="control-label2" Text="Unit Rank:"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" CssClass="control-label2" Text='<%# Eval("UnitRank") %>' />
                                            <br />
                                            <asp:Label ID="LabH2" runat="server" CssClass="control-label2" Text="Description:"></asp:Label>
                                            <asp:Label ID="EmployeeIDLabel1" runat="server" CssClass="control-label2" Text='<%# Eval("UnitRankDesc01") %>' />
                                            <br />
                                            <asp:Label ID="LblH3" runat="server" CssClass="control-label2" Text="Hierarchy:"></asp:Label>
                                            <asp:Label ID="LastNameTextBox" runat="server" CssClass="control-label2" Text='<%# Bind("ChannelDesc01") %>' />
                                            <br />
                                            <asp:Label ID="LblH4" runat="server" CssClass="control-label2" Text="Period:"></asp:Label>
                                            <asp:Label ID="FirstNameTextBox" runat="server" CssClass="control-label2" Text='<%# Bind("Period") %>' />
                                            <br />
                                            <asp:Label ID="LblH5" runat="server" CssClass="control-label2" Text="Version:"></asp:Label>
                                            <asp:Label ID="TitleTextBox" runat="server" Text='<%# Bind("Version") %>' CssClass="control-label2" />
                                        </td>
                                        <td>
                                            <asp:LinkButton runat="server" ID="lnkPrevious" Style="margin-left: 315px; font-size: 20px;"
                                                ToolTip="Click to view previous" OnClick="lnkPrevious_Click">
                <span class="glyphicon glyphicon-arrow-left margin-top btn btn-primary BtnGlyphicon"></span>
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton runat="server" ID="lnkNext" Style="margin-top: -107px; margin-left: 6px;
                                                font-size: 20px;" ToolTip="Click to view next" OnClick="lnkNext_Click">
                                <span class="glyphicon glyphicon-arrow-right margin-top btn btn-primary BtnGlyphicon"></span>
                                            </asp:LinkButton>
                                        </td>
                                        <td style="padding-right: 7px;">
                                            <asp:LinkButton ID="lnkBack" runat="server" Style="margin-top: -107px; margin-left: 5px;
                                                font-size: 20px;" ToolTip="Click to go back" OnClick="lnkBack_Click">
                <span class="glyphicon glyphicon-arrow-up margin-top btn btn-primary BtnGlyphicon"></span><%----%>
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                  
                                   <tr>
                                    <td></td>
                                    <td>
                                    <asp:Label ID="LblH8" runat="server" CssClass="control-label2" Text="Description:" style="margin-left: 24%;"></asp:Label>
                                    </td>
                                    </tr>
                                   <tr>
                                    <td colspan="4">
                                    <asp:Label ID="LblH9" runat="server" CssClass="control-label2" Text="ABCDEFGHIJKLMNOPQRSTUVWXYZ12345678910" style="margin-left: 30%;"></asp:Label>
                                    </td>
                                    </tr>
                                   <tr>
                                    <td colspan="4">
                                    <asp:Label ID="Label2" runat="server" CssClass="control-label2" Text="ABCDEFGHIJKLMNOPQRSTUVWXYZ12345678910" style="margin-left: 30%;"></asp:Label>
                                    </td>
                                    </tr>
                                   <tr>
                                    <td colspan="4">
                                    <asp:Label ID="Label3" runat="server" CssClass="control-label2" Text="ABCDEFGHIJKLMNOPQRSTUVWXYZ12345678910" style="margin-left: 30%;"></asp:Label>
                                    </td>
                                    </tr>
                            </table>
                        </EditItemTemplate>
                    </asp:FormView>
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

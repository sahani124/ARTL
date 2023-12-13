<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="Rwd_Desc.aspx.cs" Inherits="Application_Isys_Saim_Rwd_Desc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    

    <CENTER>
      <div id="divqualhdrcollapse" runat="server" style="width: 97%;" class="panel">
                    <div id="Div6" runat="server" class="panel-heading" style="width: 96%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divqual','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%><%--commented by ajay sawant 25/4/2018--%>
                                <asp:Label ID="lblhdr" Text="Reward Description Details" style="font-size:19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                            </div>
                        </div>
                    </div>


           <div id="div4" runat="server" style="width: 100%; border: none; padding: 10px; margin: 0px 0 !important;"
                                        class="table-scrollable">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>

                                                 <asp:GridView ID="dgRWDDESC" runat="server" CssClass="footable" AllowSorting="True"
                                                    AllowPaging="true" AutoGenerateColumns="false">
                                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                                    <PagerStyle CssClass="disablepage" />
                                                    <HeaderStyle CssClass="gridview th" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Compensation code" SortExpression="CMPNSTN_CODE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcmpode" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>' />
                                                              <%--  <asp:HiddenField ID="hdnrulstcd" runat="server" Value='<%# Bind("SUB_CHN")%>' />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RuleSetKey" SortExpression="RULE_SET_KEY">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrulst" runat="server" Text='<%# Bind("RULE_SET_KEY")%>' />
                                                              <%--  <asp:HiddenField ID="hdnrulstcd" runat="server" Value='<%# Bind("SUB_CHN")%>' />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="Reward Description" SortExpression="RWRD_DESC01">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrwdes" runat="server" Text='<%# Bind("RWRD_DESC01")%>' />
                                                              <%--  <asp:HiddenField ID="hdnrulstcd" runat="server" Value='<%# Bind("SUB_CHN")%>' />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        </Columns>
                                                     </asp:GridView>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
               </div>

          </div>
</CENTER>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="Std_Dfntn_Action_Value_Setup.aspx.cs" Inherits="Application_Isys_Saim_Customisation_Std_Dfntn_Action_Value_Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="..//../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>

    <style type="text/css">
        .gvtCenter {
            text-align: center !important;
        }

        .gvtLeft {
            text-align: left !important;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <script type="text/javascript">
        function ShowReqDtl1(divName, btnName) {
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                }
                else {
                    objnewdiv.style.display = "block";
                }
            }
            catch (err) {

            }
        }
        function Enable() {
            document.getElementById('ctl00_ContentPlaceHolder1_divunitcd').style.display = "none";
            document.getElementById('ctl00_ContentPlaceHolder1_Loading_gif').style.display = "block";
        }

        function gotoHome() {
            parent.location.href = parent.location.href;
        }

    </script>

    <asp:UpdatePanel ID="UPD1" runat="server">
        <ContentTemplate>
            <center>
                 <div >  <%--style="padding: 10px;"--%>
                    <div id="divpn" runat="server"  class="panel"  style="width: 97%;">
                        <div id="Divpnlhed" runat="server" class="panel-heading" style="width: 97%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divpnlbdy','myImg');return false;"> <%--;return false;--%>
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left; Font-Size:19px" >
                                    <asp:Label ID="lblhead" Text="STANDARD DEFINITION ACTION VALUE SETUP" runat="server" />
                                </div>
                                <div class="col-sm-2">
                                 <span id="myImg" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                                        padding: 1px 10px ! important; font-size: 18px;"></span> 
                                </div>
                            </div>
                        </div>

                        <div id="divpnlbdy" runat="server"  style="width: 96%; padding: 10px;" class="panel-body">
                              <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblChannel" Text="Channel" style="font-size:14px;" runat="server" CssClass="control-label" />
                                        <asp:Label ID="Label22" Text="*" runat="server" Style="color: Red" />
                                    </div>
                                     <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlChannl" runat="server" CssClass="select2-container form-control"
                                                    AutoPostBack="true" TabIndex="5" OnSelectedIndexChanged="ddlChannl_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                     <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblsubchnl" Text="Sub Channel" style="font-size:14px;" runat="server" CssClass="control-label" />
                                        <asp:Label ID="Label24" Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                            <ContentTemplate>
                                               <asp:DropDownList ID="ddlsubchnl" runat="server" CssClass="select2-container form-control"
                                                    AutoPostBack="true" TabIndex="5" OnSelectedIndexChanged="ddlsubchnl_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    </div>

                             <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblmemtyp" Text="Member Type" style="font-size:14px;" runat="server" CssClass="control-label" />
                                        <asp:Label ID="Label2" Text="*" runat="server" Style="color: Red" />
                                    </div>
                                     <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlmemtype" runat="server" CssClass="select2-container form-control"
                                                    AutoPostBack="true" TabIndex="5" OnSelectedIndexChanged="ddlmemtype_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                     <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblkpi" Text="KPI Description" style="font-size:14px;" runat="server" CssClass="control-label" />
                                        <asp:Label ID="Label4" Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                               <asp:DropDownList ID="ddlkpi" runat="server" CssClass="select2-container form-control"
                                                    AutoPostBack="true" TabIndex="5">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    </div>
                              <div class="dvbtn" style="margin-top: 12px;">
                                        <asp:LinkButton ID="btnsearch" runat="server"  CssClass="btn btn-sample"  TabIndex="25" OnClientClick="Enable()" OnClick="btnsearch_Click">
                                                <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                                        </asp:LinkButton>                                      
                                        <asp:LinkButton ID="btncncl" runat="server" CssClass="btn btn-sample" OnClick="btncncl_Click">
                                        <span class="glyphicon glyphicon-erase"  style="color:White"></span> Clear
                                        </asp:LinkButton>
                                  <asp:LinkButton ID="lnkbtcn" runat="server" CssClass="btn btn-sample" OnClientClick="gotoHome(); return false;">
                                        <span class="glyphicon glyphicon-remove"  style="color:White"></span> Cancel
                                        </asp:LinkButton>
                                              </div>
                             </div>
                        </div>
                     </div>
                    </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- START OF GRIDVIEW --%>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>

            <div id="divsales" runat="server" style="margin-left: 1.5%; margin-right: 2.5%; margin-top: 0.5%" class="panel ">
                <div class="panel-heading" style="width: 97%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divunitcd','myImg');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left; font-size: 19px">



                            <div class="col-sm-6">
                                <asp:Label ID="lblrslt" Text="SEARCH RESULTS" runat="server" />
                            </div>
                            <div class="col-sm-6">
                                <img id="Loading_gif" style="display: none; margin-top: 5px; margin-right: 100px" runat="server"
                                    src="../../Recruit/assets/img/animated_gif_loader.gif" />
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                <ContentTemplate>
                                    <span id="myImg" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                </div>
                <div id="divunitcd" runat="server" style="width: 98%; border: none; padding: 10px; margin: 0px 20px;"
                    class="table-scrollable">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dgmap" runat="server" AutoGenerateColumns="false" Width="100%"
                                PageSize="10" AllowSorting="True" AllowPaging="true" ShowHeader="true" ShowHeaderWhenEmpty="true"
                                CssClass="footable" DataKeyNames="Channel, KPI_CODE, MAP_CODE" Visible="true" OnSorting="dgmap_Sorting"
                                EmptyDataText="No Record Found">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <ItemStyle CssClass="gvtCenter" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblkpi" runat="server" Text='<%# Bind("KPI")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnkpi" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="KPI Description" SortExpression="KPI_DESC_01">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <ItemStyle CssClass="gvtLeft" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblkpidesc" runat="server" Text='<%# Bind("KPI_DESC_01")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnkpidesc" runat="server" Value='<%# Bind("KPI_DESC_01")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Map Code" SortExpression="MAP_CODE">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <ItemStyle CssClass="gvtCenter" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblmapcd" runat="server" Text='<%# Bind("MAP_CODE")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnmapcd" runat="server" Value='<%# Bind("MAP_CODE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Channel" SortExpression="BIZSRC">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <ItemStyle CssClass="gvtLeft" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblbiz" runat="server" Text='<%# Bind("[Channel]")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnbizsrc" runat="server" Value='<%# Bind("Channel")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Channel" SortExpression="CHNCLS">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <ItemStyle CssClass="gvtLeft" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblchncls" runat="server" Text='<%# Bind("[Sub Channel]")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnchncls" runat="server" Value='<%# Bind("[Sub Channel]")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Type" SortExpression="MEMTYPE">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <ItemStyle CssClass="gvtLeft" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblmemtyp" runat="server" Text='<%# Bind("[Member Type]")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnmemtyp" runat="server" Value='<%# Bind("[Member Type]")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Std. Definition" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true">
                                        <HeaderStyle CssClass="gridview th" />
                                        <ItemStyle CssClass="gvtCenter" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSetRule" Text="Set Rule" runat="server" OnClick="lnkSetRule_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <center>
                                <div id="divpg" visible="true" runat="server" class="pagination">
                                   <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                        Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Visible="false" OnClick="btnprevious_Click"/>
                                                    <asp:TextBox runat="server" ID="Txtpage" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" Visible="false" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" Visible="false" OnClick="btnnext_Click"/>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                        </div>
                 </center>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="CntstTrackerRpt.aspx.cs" Inherits="Application_ISys_Saim_CntstTrackerRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .ajax__calendar
        {
            z-index: 100px;
        }
        .new_text_new
        {
            color: #066de7;
        }
        .form-submit-button
        {
        }
        .disablepage
        {
            display: none;
        }
        .divBorder
        {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        .align
        {
            text-align: left;
        }
        .rowalign
        {
            margin-bottom: 15px;
        }
    </style>
    <script type="text/javascript">
        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function funPopUp(cmpcode, cmpdesc) {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCntst.aspx?cmpCode=" + cmpcode + "&cmpdesc=" + cmpdesc + "&mdlpopup=mdlViewBID";
        }

        function doCancel() {
            $find("mdlViewBID").hide();
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="divcmphdrcollapse" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="lblhdr" Text="Contest Details" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="myImg" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divcmphdr','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divcmphdr" runat="server" style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblCycleFrom" Text="Cycle From" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCycleFromVal" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblCycleTo" Text="Cycle To" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCycleToVal" runat="server" CssClass="control-label col-md-5" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblBasedOn" Text="Based On" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblBasedOnVal" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblLastCycleRun" Text="Last Cycle Run" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblLastCycleRunVal" runat="server" CssClass="control-label col-md-5" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblRepDate" Text="Reported Date" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblRepDateVal" runat="server" CssClass="control-label col-md-5" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <center>
                <div id="divcmpsrchhdrcollapse"  runat="server" style="width: 95%;"
                    class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-search"></i>
                                <asp:Label ID="lblCmpSrch" Text="CONTEST AGENT TRACKER SUMMARY" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right;">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate>
                                        <img id="Img2" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                            alt="" onclick="funcall();" />
                                        <img id="Img1" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;"
                                            alt="" onclick="ShowReqDtl('divkpisrch','Img1','#Img1');" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <div id="divkpisrch" runat="server" style="width: 100%; padding: 10px;">
                        <div id="Div1" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                            class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvTrckrSmmry" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                       >
                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                        <RowStyle />
                                        <PagerStyle CssClass="disablepage" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Agent Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="Agent_CODE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkCmpCode" Text='<%# Bind("Agent_CODE")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Agent Name" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="true"
                                                ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCmpDesc" Text='<%# Bind("Agent_Name") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="BAL_CF" HeaderText="Balance C/F" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="BAL_CF" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Curr_Archived" HeaderText="Current Achieved" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="Curr_Archived" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Archived_Slab" HeaderText="Achieved Slab" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="Archived_Slab" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Next_Slab" HeaderText="Next Slab" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="80px" SortExpression="Next_Slab" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Curr_Reward" HeaderText="Current Reward" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="Curr_Reward" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Next_Reward" HeaderText="Next Reward" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="Next_Reward" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

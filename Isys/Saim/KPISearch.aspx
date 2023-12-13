<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="KPISearch.aspx.cs" Inherits="Application_ISys_Saim_KPISearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <style type="text/css">
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }*/

        .form-submit-button {
            box-shadow: none !important;
        }

        .disablepage {
            display: none;
        }

        .divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
            vertical-align: top;
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

        function ShowReqDtl1(divName, btnName) {
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
            }
            catch (err) {
                ////ShowError(err.description);
            }
        }

    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="divkpisrchhdrcollapse" runat="server"  class="panel">
                    <div id="Div6" runat="server" class="panel-heading" style="width: 98%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpisrch','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left; width:81% !important">
                                  <%--<img id="ImageComp" src="../../../images/Compensation_Detail_Icon.png" style="border-width:0px;width: 35px;margin-top: 6px;margin-bottom:10px;height: 35px;"/>--%>
                                <img src="../../../images/KPI_icon.png" style="width:35px; height:35px !important" />
                                <asp:Label ID="lblKPISrch" Text="KPI SEARCH" style="border-width:0px;width: 25px;margin-top: 6px;margin-bottom:10px;height: 25px;" Font-Size="19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 12px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divkpisrch" runat="server" style="width: 96%; padding: 10px;">
                        <div id="div3" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                            class="table-scrollable">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgKPI" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" OnRowDataBound="dgKPI_RowDataBound" AllowPaging="true"
                                        OnSorting="dgKPI_Sorting" CssClass="footable">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="KPI Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="KPI_CODE">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkKPICode" Text='<%# Bind("KPI_CODE")%>' runat="server" OnClick="lnkKPICode_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="KPI Description" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center" SortExpression="KPI_DESC_01">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKpiDesc" Text='<%# Bind("KPI_DESC_01")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="KPI_DESC_02" HeaderText="KPI Description 2" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" SortExpression="KPI_DESC_02">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="KPIType" HeaderText="KPI Type" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="KPIType" ItemStyle-HorizontalAlign="Center">
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="KPIOrigin" HeaderText="KPI Origin" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="KPIOrigin" ItemStyle-HorizontalAlign="Center">
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="KPI Origin" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="KPIOrigin">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKpiOrg" Text='<%# Bind("KPIOrigin")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnKpiOrg" Value='<%# Bind("KPI_ORIGIN")%>' runat="server">
                                                    </asp:HiddenField>
                                                    <asp:HiddenField ID="hdnCatg" Value='<%# Bind("CATG")%>' runat="server"></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="RangeFrm" HeaderText="Eff. From" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="RangeFrm" ItemStyle-HorizontalAlign="Center">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RangeTo" HeaderText="Eff. To" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="80px" SortExpression="RangeTo" ItemStyle-HorizontalAlign="Center">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Version" HeaderText="Version" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="Version" ItemStyle-HorizontalAlign="Center">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="true">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="lnkDelete_Click"
                                                        OnClientClick="confirm('Do you want to delete this KPI')" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Std. Definition" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkSetRule" Text="Set Rule" runat="server" OnClick="lnkSetRule_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="pagination">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                        Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
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
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnAddNew" runat="server" OnClick="btnAddNew_Click"
                                    CssClass="btn btn-sample">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add New
                                    </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" style="background-color:#FFF;color:#f04e5e; width:97px !important" OnClick="btnCancel_Click"
                                    CssClass="btn btn-sample">
                                        <span class="glyphicon glyphicon-remove" style="color:#f04e5e"></span> Cancel
                                    </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

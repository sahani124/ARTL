<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConvRangeSelection.aspx.cs" Inherits="Application_Isys_Saim_Customisation_ConvRangeSelection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="../../../../KMI Styles/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../assets/css/footable.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid" id="container" runat="server">
                    <div class="row" style="min-height: 300px;">
                        <div class="col-sm-5" style="padding:10px">
                            <asp:Label Text="Search" runat="server" style="font-size:14px; margin-top:5px"></asp:Label>
                            <div class="input-group mb-3" style="margin-bottom:10px;">
                                <asp:TextBox runat="server" ID="txtLeftSearch" CssClass="form-control" style="height:34px" />
                                <div class="input-group-addon" style="padding: 0px;background: #fff;border: none;">
                                    <asp:Button Text="Search" runat="server" CssClass="btn btn-primary" OnClick="btnLeftSearch_Click" ID="btnLeftSearch" />
                                </div>
                            </div>
                        <div class="grid-container" style="overflow-x:auto">
                            <asp:GridView ID="GvLeftSide" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="footable"
                                OnPageIndexChanging="GvLeftSide_PageIndexChanging" OnRowDataBound="GvLeftSide_RowDataBound" AllowPaging="true" PageSize="5"
                                EmptyDataText="No Data Left to Select" ShowHeaderWhenEmpty="true" ShowHeader="true" PagerSettings-Mode="Numeric" 
                                PagerStyle-HorizontalAlign="Center" PagerStyle-VerticalAlign="Middle" DataKeyNames="Range">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkLeftAll" runat="server" OnCheckedChanged="chkLeftAll_CheckedChanged" AutoPostBack="true" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkLeft" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Values">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLeft" runat="server" CssClass="control-label" Text='<%# Eval("ParamDesc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         </div>
                        </div>
                        <div class="col-sm-2">
                            <div style="text-align: center; transform: translateY(130%);">
                                <asp:Button Text="Select >>" style="width: 110px !important" runat="server" class="btn btn-sample" OnClick="btnSelectorLeft_Click" ID="btnSelectorLeft" />
                                <asp:Button Text="<< Un-Select" runat="server" class="btn btn-sample" OnClick="btnSelectorRight_Click" ID="btnSelectorRight" />
                            </div>
                        </div>
                        <div class="col-sm-5" style="padding:10px">
                            <asp:Label Text="Search" runat="server" style="font-size:14px; margin-top:5px"></asp:Label>
                            <div class="input-group mb-3" style="margin-bottom:10px;">
                                <asp:TextBox runat="server" ID="txtRightSearch" CssClass="form-control" style="height:34px" />
                                <div class="input-group-addon"  style="padding: 0px;background: #fff;border: none;">
                                    <asp:Button Text="Search" runat="server" CssClass="btn btn-primary" OnClick="btnRightSearch_Click" ID="btnRightSearch" />
                                </div>
                            </div>
                        <div class="grid-container" style="overflow-x:auto">
                            <asp:GridView ID="GvRightSide" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="footable"
                                OnPageIndexChanging="GvRightSide_PageIndexChanging" OnRowDataBound="GvRightSide_RowDataBound" AllowPaging="true" PageSize="5"
                                EmptyDataText="No Data Left to Un-Select" ShowHeaderWhenEmpty="true" ShowHeader="true" PagerSettings-Mode="Numeric"
                                PagerStyle-HorizontalAlign="Center" PagerStyle-VerticalAlign="Middle" DataKeyNames="Range">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkRightAll" runat="server" OnCheckedChanged="chkRightAll_CheckedChanged" AutoPostBack="true" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkRight" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Selected Values">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRight" runat="server" CssClass="control-label" Text='<%# Eval("ParamDesc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        </div>
                    </div>
                    <div class="row">
                        <center>
                        <asp:Button Text="Confirm" runat="server" ID="btnSelect" OnClick="btnSelect_Click" ClientIDMode="Static" CssClass="btn btn-sample" />
                        <asp:Button Text="Reset" runat="server" ID="btnLoadData" OnClick="btnLoadData_Click" ClientIDMode="Static" CssClass="btn btn-sample" />
                            </center>
                    </div>
                </div>
                <div id="loadersvg" runat="server">
                    <%--<img src="../../../../assets/img/ajax-modal-loading.gif" />
                    Loading--%>

                    <div id="iLoading" class="Content" style="position: absolute; top: 50%; left: 50%; margin: -50px 0px 0px -50px; z-index: 9999;">
                        <img src="../../../../assets/img/loading-spinner-blue.gif" alt="LOADING" />
                        Loading...
                    </div>
                </div>
                <asp:HiddenField runat="server" ID="hdnPreviousSelected" ClientIDMode="Static" />
                <asp:HiddenField runat="server" ID="hdnSelectedFixFactor" ClientIDMode="Static" />
                <asp:HiddenField runat="server" ID="hdnCurrentSelected" ClientIDMode="Static" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script src="../../../../assets/scripts/jquery.min.js"></script>
    <script src="../../../../assets/scripts/bootstrap.min.js"></script>
    <script>

        function GetQueryStringValue(url, param) {
            param = param.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regVal = new RegExp("[\\?&]" + param + "=([^&#]*)"),
            results = regVal.exec(url);
            return results === null ? null : decodeURIComponent((results[1]).replace(/\+/g, " "));
        }

        $(document).ready(function () {
            debugger;
            document.getElementById("hdnSelectedFixFactor").value = window.parent.document.getElementById('hdnSelectedFixFactor').value;
            document.getElementById("hdnPreviousSelected").value = window.parent.document.getElementById('hdnSelectedRange').value;
            var VAL_CODE = GetQueryStringValue(window.location, 'VAL_CODE');
            var value = window.parent.document.getElementById('hdnConv' + VAL_CODE).value;
            if (value == '') {
                document.getElementById("hdnCurrentSelected").value = "";
            }
            else {
                document.getElementById("hdnCurrentSelected").value = JSON.stringify({ 'data': JSON.parse(value) });
            }

            document.getElementById("btnLoadData").click();
        });

        function passDataToParent(data, val_code) {
            debugger;
            window.parent.GetDataFromChild(data, val_code);
        }

        function ClosePopup() {
            window.parent.ClosePopup();
        }

    </script>
</body>
</html>

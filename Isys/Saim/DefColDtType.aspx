<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" EnableViewState="true"
    CodeFile="DefColDtType.aspx.cs" Inherits="Application_Isys_Saim_DefColDtType" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10" />

    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />

    <%--<link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />--%>

    <link href="../../../KMI Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>

    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <%--Added References by Daksh for Reports Start--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../../assets/scripts/jquery.min.js"></script>
    <script src="../../../../assets/scripts/bootstrap.min.js"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript" language="javascript">
        function doSelect(Flag, Code) {
            debugger;

            if (Flag == "COL1DT") {
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnMapDataType1').value = Code;

                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_BtnToolTip').click();
            }
            if (Flag == "COL2DT") {
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnMapDataType2').value = Code;

                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_BtnToolTip2').click();
            }

            window.close();
        }
    </script>

    <div id="divmapkpibsetblhdrcollapse" runat="server" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%" class="panel">
        <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divmapColDT','myImg1');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="Label1" Text="Convert Column Data Type" runat="server" Font-Size="19px" />
                </div>
                <div class="col-sm-2">
                    <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>
        <div id="divmapColDT" runat="server" style="width: 96%;" class="panel-body">
            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblDT" Text="Data Type" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                    <asp:Label Text="*" runat="server" Style="color: Red" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlDT" runat="server" CssClass="select2-container form-control" AutoPostBack="true"  OnSelectedIndexChanged="ddlDT_SelectedIndexChanged"
                                TabIndex="1" Height="35px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblCol" Text="Column Name" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                    <asp:Label Text="*" runat="server" Style="color: Red" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <asp:TextBox ID="TextBoxCol" runat="server" CssClass="form-control" Enabled="false"
                                ClientIDMode="Static" Rows="2" />

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


            </div>

            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblLen" Text="Length" runat="server" Style="font-size: 14px;" CssClass="control-label" />

                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>


                            <asp:TextBox ID="txtLen" runat="server" CssClass="form-control"
                                ClientIDMode="Static" Rows="2" />

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblScale" Text="Scale" runat="server" Style="font-size: 14px;" CssClass="control-label" />

                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>


                            <asp:TextBox ID="txtScale" runat="server" CssClass="form-control" Enabled="false"
                                ClientIDMode="Static" Rows="2" />

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


            </div>

            <div class="row" style="margin-bottom: 5px;">



                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="Label3" Text="Style" runat="server" Style="font-size: 14px;" CssClass="control-label" />

                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>


                            <asp:TextBox ID="TextBoxStyle" runat="server" CssClass="form-control"
                                ClientIDMode="Static" Rows="2" />

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>

            <div class="row" style="margin-top: 12px; margin-bottom: 4px">
                <div class="col-sm-12" align="center">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="btnSelect" runat="server" CssClass="btn btn-sample" OnClick="btnSelect_Click">
                                        <span class="glyphicon glyphicon-floppy-save" style="color: White;"></span> Save
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample" OnClick="btnClear_Click">
                                        <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnCncl" runat="server" CssClass="btn btn-sample" OnClick="btnCncl_Click">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                            </asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

        </div>
    </div>
    <asp:HiddenField ID="hndDesc" runat="server" />
    <asp:HiddenField ID="hndCode" runat="server" />
</asp:Content>

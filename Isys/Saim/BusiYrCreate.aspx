<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="BusiYrCreate.aspx.cs" Inherits="Application_ISys_Saim_BusiYrCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
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

    <script type="text/javascript">
        $(function () {
            debugger;
            $("#<%= txtStrtDt.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        $("#<%= txtEndDt.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });
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
    <style type="text/css">
        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
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

        .pnlBorder {
            border: 2px solid #3399ff;
            border-top: 0;
            vertical-align: top;
        }

        .circle {
            width: 25px;
            height: 25px;
            border-radius: 20px;
            font-size: 10px;
            color: white;
            line-height: 25px;
            text-align: center;
            background: red;
            font-family: Verdana;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="divfinhdrcollapse" runat="server" style="width: 95%;text-align:left;" class="panel ">
                    <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divfinhdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                
                                <asp:Label ID="Label1" runat="server"  style="font-size:19px;" />
                            </div>
                            <div class="col-sm-2">
                                  <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 25/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <div id="divfinhdr" runat="server" style="width: 100%;" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblYrCode" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtYrCode" runat="server" CssClass="form-control" TabIndex="14" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblShrtYrDsc" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtShrtYrDsc" runat="server" CssClass="form-control" TabIndex="14" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblYrDesc" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtYrDesc" runat="server" CssClass="form-control" TabIndex="14"
                                    Width="99%" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblStrtDt" Text="Start Date" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtStrtDt" runat="server" CssClass="form-control" TabIndex="14"
                                    placeholder="dd/mm/yyyy" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEndDt" Text="End Date" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtEndDt" runat="server" CssClass="form-control" TabIndex="14"
                                    placeholder="dd/mm/yyyy" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblStCurr" Text="Set Current Year" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkBusiYr" runat="server" AutoPostBack="true" />
                                        <asp:Label ID="lblchkBusiYr" runat="server" CssClass="control-label" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample" TabIndex="24"
                                    OnClick="btnSave_Click">
                                            <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" TabIndex="25"
                                    OnClick="btnCancel_Click">
                                            <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnl" runat="server" BackColor="White">
                <div class="pnlBorder">
                    <table width="100%" class="formtablehdr">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <asp:Label ID="lblinfo" Text="INFORMATION" runat="server" Style="padding-left: 5px;" />
                            </td>
                        </tr>
                    </table>
                    <div style="width: 100%;">
                        <table>
                            <tr>
                                <td style="width: 391px;">
                                    <br />
                                    <center>
                                        <asp:Label ID="lbl3" runat="server" CssClass="control-label"></asp:Label></center>
                                    <br />
                                    <center>
                                        <asp:Label ID="lbl4" runat="server" CssClass="control-label"></asp:Label><br />
                                    </center>
                                    <br />
                                    <center>
                                        <asp:Label ID="lbl5" runat="server" CssClass="control-label"></asp:Label></center>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; padding: 2px;">
                                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn blue" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


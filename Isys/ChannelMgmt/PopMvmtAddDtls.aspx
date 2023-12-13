<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopMvmtAddDtls.aspx.cs"
    Inherits="Application_Isys_ChannelMgmt_PopMvmtAddDtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />

    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../PSSNEW/Script/COMM/CBFRMCommon.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../PSSNEW/Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
            color: white;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            $("#<%= txtEffDate.ClientID  %>").unbind();
            $("#<%= txtEffDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtCseDt.ClientID  %>").unbind();
            $("#<%= txtCseDt.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        }

        function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
            var objnewbtn = document.getElementById(btnName);

            if (objnewdiv.style.display == "block") {
                objnewdiv.style.display = "none";
                objnewbtn.className = 'glyphicon glyphicon-collapse-up'
            }
            else {
                objnewdiv.style.display = "block";
                objnewbtn.className = 'glyphicon glyphicon-collapse-down'
            }
        }
    </script>
    <div>
        <asp:ScriptManager runat="server" ID="src">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="divmkchkrmvmt" runat="server" class="panel">
                    <%--marker div start--%>
                    <div id="div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div5','Span2');return false;"
                        >
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                              <%--  <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Maker Details" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div5" runat="server" class="panel-body">
                        <div id="divmkchkr" runat="server" visible="true">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblTypeMkr" runat="server" Text="Maker Type" />
                                    <span style="color: #ff0000"> *</span>
                                </div>
                                <div class="col-md-9" style="text-align: left">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rblTypeMkr" runat="server" AutoPostBack="true" CellPadding="2"
                                                CellSpacing="2" Width="25%" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblmvmtchn" runat="server" Text="Hierarchy Name" CssClass="control-label"></asp:Label>
                                    <span style="color: #ff0000"> *</span>
                                </div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="upChannel" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlmvmtchnmkr" runat="server" CssClass="form-control" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlmvmtchnmkr_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblmvmtsubcls" runat="server" Text="Sub Class"></asp:Label>
                                    <span style="color: #ff0000"> *</span>
                                </div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="upSubChannel" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlmvmtsubclsmkr" runat="server" CssClass="form-control" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlmvmtsubclsmkr_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblmvmtbsdon" runat="server" Text="Based On"></asp:Label>
                                    <span style="color: #ff0000"> *</span>
                                </div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="upBasedOn" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlmvmtbsdonmkr" runat="server" CssClass="form-control" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlmvmtbsdonmkr_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblmvmtlvlagttyp" runat="server" Text="Relation Member Type"></asp:Label>
                                    <span style="color: #ff0000"> *</span>
                                </div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="upLevelAgtType" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlmvmtlvlagttypmkr" runat="server" CssClass="form-control"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlmvmtlvlagttypmkr_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblEffDate" runat="server" CssClass="control-label" Text="Effective Date" />
                                    <span style="color: #ff0000"> *</span>
                                </div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtEffDate" runat="server" MaxLength="10" CssClass="form-control"
                                                Style="margin-left: 2px" />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" FilterType="Custom, Numbers"
                                                runat="server" ValidChars="/" TargetControlID="txtEffDate">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lbceasedt" runat="server" Text="Cease Date"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtCseDt" runat="server" CssClass="form-control" MaxLength="10" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" FilterType="Custom, Numbers"
                                        runat="server" ValidChars="/" TargetControlID="txtCseDt">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div id="div9" runat="server" style="width: 100%;">
                    <div class="row" id="tbladdcntst" runat="server">
                        <div class="col-md-12" style="text-align: center">
                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-primary" CausesValidation="false"
                                TabIndex="43" OnClick="btnUpdate_Click">
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Save
                            </asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-danger" CausesValidation="false"
                                OnClick="btnCancel_Click" TabIndex="43" OnClientClick="doCancel();">
                                  <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

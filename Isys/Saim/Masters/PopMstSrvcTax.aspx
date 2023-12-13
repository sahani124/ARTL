<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopMstSrvcTax.aspx.cs" Inherits="Application_ISys_Saim_Masters_PopMstSrvcTax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <script type="text/javascript">
        $(function () {
            debugger;
            $("#<%= txtEffDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtCseDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

        });

        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../../assets/img/portlet-collapse-icon-white.png')
            }
        }

        function ShowReqDtl1(divName, btnName) {

            try {
                var objnewdiv = document.getElementById(divName)
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
            catch (err) {
                ////ShowError(err.description);
            }
        }

        function doCancel() {
            window.parent.document.getElementById("ctl00_ContentPlaceHolder1_btntax").click();
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
    <asp:ScriptManager ID="scr" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
        }
        .new_text_new
        {
            color: #066de7;
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
        .disablepage
        {
            display: none;
        }
        
        .box
        {
            background-color: #efefef;
            padding-left: 5px;
        }
    </style>
    <center>
        <div id="divtrghdrcollapse" runat="server" style="width: 95%;" class="panel panel-success">
            <div id="div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divtrg','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;
                        <asp:Label ID="lblhdr" Text="Tax Setup" runat="server" />
                    </div>
                    <div class="col-sm-2">
                        <img id="myImg" src="../../../../assets/img/portlet-expand-icon-white.png" alt=""
                            onclick="ShowReqDtl('divtrg','myImg','#myImg');" />
                    </div>
                </div>
            </div>
            <div id="divtrg" runat="server" style="width: 100%; white-space: nowrap; text-align: left;"
                class="panel-body">
                <div id="tblTax" runat="server" class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblChn" Text="Channel" runat="server" CssClass="control-label" /><span
                            style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlChn" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    OnSelectedIndexChanged="ddlChn_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label1" Text="Sub Class" runat="server" CssClass="control-label" /><span
                            style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSubChn" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblTaxTypDsc" Text="Tax Type Description" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlTaxType" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    OnSelectedIndexChanged="ddlTaxType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:TextBox ID="txtTaxTypDsc" runat="server" CssClass="form-control" placeholder="Tax Type Description"
                            Visible="false"></asp:TextBox>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblTaxTyp" Text="Tax Type" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtTaxType" runat="server" CssClass="form-control" placeholder="Tax Type"
                                    MaxLength="3" Enabled="false"></asp:TextBox></ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCmpBONRt" Text="Company Borne Ratio" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtCmpBONRt" runat="server" CssClass="form-control" placeholder="Company Borne Ratio"></asp:TextBox>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAgtBONRt" Text="Agent Borne Ratio" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtAgtBONRt" runat="server" CssClass="form-control" placeholder="Agent Borne Ratio"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblTaxFrm" Text="Tax Amount From" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtTaxFrm" runat="server" CssClass="form-control" placeholder="Tax Amount From"></asp:TextBox>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblTaxTo" Text="Tax Amount To" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtTaxTo" runat="server" CssClass="form-control" placeholder="Tax Amount To"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblTaxRate" Text="Tax Rate" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtTaxRate" runat="server" CssClass="form-control" placeholder="Tax Rate"></asp:TextBox>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblTaxPytoAgt" Text="Tax Pay To Agent" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="rblTaxPytoAgt" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                    CssClass="radiobtn">
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblEffDate" Text="Effective Date" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtEffDate" runat="server" CssClass="form-control" placeholder="Effective Date"
                            Style="display: inline;"></asp:TextBox>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCseDate" Text="Cease Date" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtCseDate" runat="server" CssClass="form-control" placeholder="Cease Date"
                            Style="display: inline;"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div id="tblsvtrg" runat="server" class="row" style="margin-top: 12px;">
            <div class="col-sm-12" align="center">
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-primary" Enabled="true"
                    OnClick="btnSave_Click">
                        <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                </asp:LinkButton>
                <asp:LinkButton ID="btnCnclTrg" runat="server" CssClass="btn btn-primary" Enabled="true"
                    OnClientClick="doCancel();return false;">
                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                </asp:LinkButton>
            </div>
        </div>
    </center>
</asp:Content>

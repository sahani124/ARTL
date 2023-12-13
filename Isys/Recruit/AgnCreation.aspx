<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="AgnCreation.aspx.cs"
    Inherits="Application_Isys_Recruit_AgnCreation" Title="Untitled Page" %>

<%@ Register Src="../../../App_UserControl/Common/ctlDate.ascx" TagName="ctlDate"
    TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/menu4jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
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
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <style type="text/css">
        .rbl input[type="radio"]
        {
            margin-left: 10px;
            margin-right: 1px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            debugger;

            $("#<%= txtBizLcnExpiry.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

        });
        $(function () {
            debugger;

            $("#<%= txtrecruitDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

        });
        $(function () {
            debugger;

            $("#<%= txtAppdate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

        });
        $(function () {
            debugger;

            $("#<%= txtTerminateDT.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

        });
        function popup() {
            $("#myModal").modal();
        }
        function ShowReqDtl(divName, btnName) {
            debugger;
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
                ShowError(err.description);
            }
        }
        function ShowSubReqDtl(divName, btnName) {
            //debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-resize-small'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-resize-full'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <center>
            <div class="panel  panel-success">
                <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_idpnlBdy','btnWfParam');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                            <asp:Label ID="lblTitle" runat="server" Text="Agent Information"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="btnWfParam" class="glyphicon glyphicon-collapse-down" style="float: right;
                                color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
                <div id="idpnlBdy" runat="server" class="panel-body" style="display: block;">
                    <div class="panel  panel-success">
                        <div class="panel-heading subheader" onclick="ShowSubReqDtl('ctl00_ContentPlaceHolder1_divpersondetails','Span1');return false;"
                            style="background-color: #EDF1cc !important;">
                            <div class="row" align="left">
                                <div class="col-sm-10">
                                    <span class="glyphicon glyphicon-menu-hamburger" style="margin-right: 5px; color: Orange;">
                                    </span>
                                    <asp:Label ID="lblPerson" runat="server" Text="Personal Particular" Font-Bold="False"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <span id="Span1" class="glyphicon glyphicon-resize-full" style="float: right; padding: 1px 10px ! important;
                                        font-size: 18px; color: Orange;"></span>
                                </div>
                                <%-- <asp:Label ID="Label1" runat="server" CssClass="standardlabel" Font-Bold="True" Text=""></asp:Label>--%>
                            </div>
                        </div>
                        <div id="divpersondetails" runat="server" class="panel-body" style="display: block">
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgnCode" runat="server" Text="Agent Code" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtAgnCode" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgnStatus" runat="server" Text="Agent Status" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlAgnStatus" runat="server" Enabled="false" CssClass="form-control">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1" Selected="true">Pending</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblCustomId" runat="server" Text="Customer ID(Client Code)" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left;">
                                      <div  class="input-group">
                                    <asp:TextBox ID="txtCustomId" runat="server"  Enabled="False" CssClass="form-control" ></asp:TextBox>   <%-- Width="80%"--%>
                                    
                             <span class="input-group-addon input-addon_extended">
                                 <asp:TextBox ID="txtCustomId1" runat="server" Enabled="false" Text="..." CssClass="form-control"
                                        Width="20%"></asp:TextBox></span>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblEx" runat="server" Text="Exclusive?" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:RadioButtonList ID="rdbEx" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                                        <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                    </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblPan" runat="server" Text="PAN No." CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtPan" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgnName" runat="server" Text="Agent Name" CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtAgnName" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblSaleChn" runat="server"  Text="Sales Channel" CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlSaleChn" runat="server" Enabled="False" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblContact" runat="server" Text="Client/Contact Details" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:LinkButton ID="lnkView" runat="server" Text="View Details"></asp:LinkButton>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblChnSubClass" runat="server" Text="Channel Sub Class" CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlChnSubClass" runat="server" Enabled="False" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblBizLcn" runat="server" Text="Biz License No." CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtBizLcn" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgnType" runat="server" Text="Agent Type" CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtAgnType" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblBizLcnExp" runat="server" Text="Biz License Expiry Date" CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtBizLcnExpiry" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgnClass" runat="server" Text="Agent Class" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlAgnClass" runat="server" Enabled="false" CssClass="form-control">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="NAGN" Selected="True">Normal Agent</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblPayMethod" runat="server" Text="Pay Method" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlPayMethod" runat="server" Enabled="false" CssClass="form-control">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="Pay" Selected="True">Computer Cheque</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblCurrency" runat="server" Text="Currency" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlCurrency" runat="server" Enabled="false" CssClass="form-control">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="IND" Selected="True">Indian Rupees</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblBankAcc" runat="server" Text="Bank Account No." CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtBankAcc" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblBankHolder" runat="server" Text="Bank Acc Holder Name" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtBankHolder" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblBankCode" runat="server" Text="Bank Code" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlBankCode" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblBankBrn" runat="server" Text="Bank Branch" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlBankBrn" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblDeduct" runat="server" Text="Deduct Tax" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlDeduct" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblTax" runat="server" Text="Bank Branch" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlTax" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblComClass" runat="server" Text="Commission Class" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlComClass" runat="server" Enabled="False" CssClass="form-control">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="STD" Selected="true">Standard</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblPayFreq" runat="server" Text="Pay Frequency" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:DropDownList ID="ddlPayFreq" runat="server" Enabled="False" CssClass="form-control">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="Month" Selected="true">Monthly</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left;">
                                    <asp:Label ID="lblAccPay" runat="server" Text="Account Payee Code" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left; display: flex;">
                                    <asp:TextBox ID="txtAccPay" runat="server" CssClass="form-control" Width="80%"></asp:TextBox>
                                    <asp:TextBox ID="txtAccPayCode" runat="server" Enabled="false" Text="..." CssClass="form-control"
                                        Width="20%"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAmt" runat="server" Text="Minimum Amount" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtAmt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblUser" runat="server" Text="UserId" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtUser" runat="server" Enabled="false" Text="ADMIN" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel  panel-success">
                        <div class="panel-heading subheader" onclick="ShowSubReqDtl('ctl00_ContentPlaceHolder1_divrecruitdetails','Span2');return false;"
                            style="background-color: #EDF1cc !important;">
                            <div class="row" align="left">
                                <div class="col-sm-10">
                                    <span class="glyphicon glyphicon-menu-hamburger" style="margin-right: 5px; color: Orange;">
                                    </span>
                                    <asp:Label ID="lblRecruitInfo" runat="server" Text="Recruiting Info/Reporting Info"
                                        Font-Bold="False"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <span id="Span2" class="glyphicon glyphicon-resize-full" style="float: right; padding: 1px 10px ! important;
                                        font-size: 18px; color: Orange;"></span>
                                </div>
                                <%-- <asp:Label ID="Label1" runat="server" CssClass="standardlabel" Font-Bold="True" Text=""></asp:Label>--%>
                            </div>
                        </div>
                        <div id="divrecruitdetails" runat="server" class="panel-body" style="display: block">
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblrecruitDt" runat="server" Text="Recruit Date" CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtrecruitDate" runat="server"  Enabled="False" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblBEBrnCode" runat="server" Text="BE Branch Code" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtBEBrnCode" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblRecruitAgtCode" runat="server" Text="Recruit Agent Code" CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left; display: flex;">
                                    <asp:TextBox ID="txtRecruitAgtCode" runat="server"  Enabled="False" CssClass="form-control" Width="80%"></asp:TextBox>
                                    <asp:TextBox ID="txtRecruitAgtCode1" runat="server" Enabled="false" Text="..." Width="20%"
                                        CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblBEAreaCode" runat="server" Text="BE Area Code" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtBEAreaCode" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblMgrCode" runat="server" Text="Manager Code" CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left; display: flex;">
                                    <asp:TextBox ID="txtMgrCode" runat="server"  Enabled="False" CssClass="form-control" Width="80%"></asp:TextBox>
                                    <asp:TextBox ID="txtMgrCode1" runat="server" Enabled="false" Text="..." Width="20%"
                                        CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblCSC" runat="server" Text="CSC Prefix" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtCSC" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblFranCode" runat="server" Text="Immediate/Franchise Code" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left; display: flex;">
                                    <asp:TextBox ID="txtFranCode" runat="server" CssClass="form-control" Width="80%"></asp:TextBox>
                                    <asp:TextBox ID="txtFranCode1" runat="server" Enabled="false" Text="..." Width="20%"
                                        CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblBECSC" runat="server" Text="BE SM/CSC Code" CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtBECSC" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgnOR" runat="server" Text="Agent OR" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left;">
                                    <asp:LinkButton ID="lnkAgnOR" runat="server" Text="Agent OR Details" />
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblEmpCode" runat="server" Text="Employee Code" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                </div>
                                <div class="col-sm-3" style="text-align: left;">
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblUnitCode" runat="server" Text="Unit Code" CssClass="control-label"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="col-sm-3" style="text-align: left;">
                                    <asp:TextBox ID="txtUnitCode" runat="server"  Enabled="False" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblTerminateDT" runat="server" Text="Date Terminated" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left;">
                                    <asp:TextBox ID="txtTerminateDT" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblComUnitCode" runat="server" Text="Company Unit Code" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtComUnitCode" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblBlackStatus" runat="server" Text="BlackList Status" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left;">
                                    <asp:DropDownList ID="ddlBlackStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAppdate" runat="server" Text="Application Date" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left;">
                                    <asp:TextBox ID="txtAppdate" runat="server"  Enabled="False" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAppNo" runat="server" Text="Application No" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtAppNo" runat="server"  Enabled="False" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <center>
                            <div class="col-sm-12" style='margin-top: 15px;'>
                                <asp:LinkButton ID="btnSubmit" CssClass="btn btn-primary"  OnClick="btnSubmit_Click" runat="server">
                                               
                                                <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span> Update
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnClear" CssClass="btn btn-danger" runat="server" OnClick="btnCancel_Click">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> Cancel </asp:LinkButton>
                                <asp:LinkButton ID="btnReport" Enabled="false" runat="server" CssClass="btn btn-primary">
                                             <span class="glyphicon glyphicon-ok-sign BtnGlyphicon"></span> Goal Sheet Report </asp:LinkButton>
                                <asp:LinkButton ID="btnLetter" Enabled="false" runat="server" CssClass="btn btn-primary">
                                             <span class="glyphicon glyphicon-ok-sign BtnGlyphicon"></span> Gen Letter Report </asp:LinkButton>
                            </div>
                        </center>
                    </div>
                </div>
            </div>
        </center>
    </div>
    <div class="modal fade" id="myModal" role="dialog" style="padding-top: 10px">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
                    <asp:Label ID="Label161" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lblpopup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span> OK
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

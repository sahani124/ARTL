<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Application_Isys_Recruit_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <script src="../../../CropScript/js/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../CropScript/js/jquery.Jcrop.min.js" type="text/javascript"></script>
    <link href="../../../CropScript/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />




    <%--        <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/jquery.ui.all.css" rel="stylesheet" />
    <script src="../../../Scripts/JQuery/jquery-latest.js"></script>
    <script src="../../Common/Scripts/jquery-1.10.2.min.js"></script>--%>
    <%--   
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>--%>
    <%--    <script src="../../../KMI%20Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../../../KMI%20Styles/assets/css/jquery-ui.css" rel="stylesheet" />--%>
    <style>
        tr.spaceUnder > td {
            padding-bottom: 1em;
        }

        .rcorners1 {
            border-radius: 10px;
        }
    </style>
    <script type="text/javascript">
        function ShowReqDtl(divName, btnName) {            try {                debugger;                var objnewdiv = document.getElementById(divName)                var objnewbtn = document.getElementById(btnName);                if (objnewdiv.style.display == "block") {                    objnewdiv.style.display = "none";                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'                }                else {                    objnewdiv.style.display = "block";                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'                }            }            catch (err) {                ////ShowError(err.description);            }        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
            <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divContactInformation','btnContactInformation');return false;">
                <div class="row" style="background-color: #00b4bf; height: 40px;">
                    <div class="col-sm-1" style="text-align: left">
                        <img src="../../../image/on-boarding_dashboard_icon.png" />
                    </div>
                    <div class="col-sm-9" style="text-align: left">

                        <asp:Label ID="Label6" runat="server" Text="ON-BOARDING DASHBOARD" CssClass="control-label" Style="color: White; font-size: 19px; margin-left: -78px;"></asp:Label>

                    </div>
                    <div class="col-sm-2">
                        <span id="btnContactInformation" class="glyphicon glyphicon-minus icon" style="float: right; color: white; padding: 1px 10px ! important; font-size: 18px;display:none"></span>
                    </div>
                </div>
            </div>
            <div id="divContactInformation" style="display: block; margin-top: -11px !important; background-color: white !important" runat="server" class="panel-body">
                <div class="col-md-12">
                    <div class="col-md-8" style="margin-bottom: 15px;">
                        <asp:Label ID="lbldb" runat="server" Text="Welcome to On-boarding dashboard status" CssClass="control-label" Font-Size="28px"></asp:Label>
                    </div>
                    <div class="col-md-2" style="margin-bottom: 15px;">
                    </div>
                    <div class="col-md-2" style="margin-bottom: 15px;">
                        <asp:DropDownList ID="ddlDashBoard" runat="server" Width="183px" Height="28px" AutoPostBack="true" OnSelectedIndexChanged="ddlDashBoard_SelectedIndexChanged">
                            <asp:ListItem Value="IS" Selected="True">INDIVIDUAL AGENT</asp:ListItem>
                            <asp:ListItem Value="PS">POSP</asp:ListItem>
                            <asp:ListItem Value="SP">SPRTL</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <%--INDIVIDUAL AGENT--%>
                <div id="divimg" class="col-md-12" runat="server" style="display: block;">
                    <table width="100%" align="center" class="tableIsys">
                        <tr>
                            <td>
                                <table width="100%">
                                    <%--1row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fbe1e2" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label4" runat="server"></asp:Label>
                                                            <asp:Label ID="lblIndPndngCndReg" runat="server" Font-Size="35px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblIndPndngCndReg1" runat="server" Font-Size="Small" Text="Pending for Candidate Registration"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ffefd9" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label1" runat="server"></asp:Label>
                                                            <asp:Label ID="lblinPndngDocUpld" runat="server" Font-Size="35px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblinPndngDocUpld1" runat="server" Font-Size="Small" Text="Pending for Document Upload"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fff7c0" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label8" runat="server"></asp:Label>
                                                            <asp:Label ID="lblinPndngAgntPro" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblinPndngAgntPro1" runat="server" Font-Size="Small" Text="Pending for Agent Profiling"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #e5fde6" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label11" runat="server"></asp:Label>
                                                            <asp:Label ID="lblinAgntProCom" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblinAgntProCom1" runat="server" Font-Size="Small" Text="Agent Profiling Completed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fffbd5" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label14" runat="server"></asp:Label>
                                                            <asp:Label ID="lblinPndngFees" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblinPndngFees2" runat="server" Font-Size="Small" Text="Pending fees"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #d5fcf3" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label17" runat="server"></asp:Label>
                                                            <asp:Label ID="lblinPndngFeesWaiApp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblinPndngFeesWaiApp1" runat="server" Font-Size="Small" ForeColor="black" Text="Pending fees Waiver Approval"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--2row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #f4e1fb" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label20" runat="server"></asp:Label>
                                                            <asp:Label ID="lblinPndngQltychk" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblinPndngQltychk1" runat="server" Font-Size="Small" Text="Pending Quality Check"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #d6f1fe" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label23" runat="server"></asp:Label>
                                                            <asp:Label ID="lblinCFRRaised" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblinCFRRaised1" runat="server" Font-Size="Small" Text="CFR Raised"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ecfdc1" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label26" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindQltyChckCom" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindQltyChckCom1" runat="server" Font-Size="Small" Text="Quality Check Completed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fae2c0" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label29" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindPndngCmpstApp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindPndngCmpstApp1" runat="server" Font-Size="Small" Text="Pending Composite Approval"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #bafbfc" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label32" runat="server"></asp:Label>
                                                            <asp:Label ID="lblinPndngURNGnrtn" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblinPndngURNGnrtn1" runat="server" Font-Size="Small" Text="Pending for URN Generation"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #bafcc8" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label35" runat="server"></asp:Label>
                                                            <asp:Label ID="lblinURNGenReq" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblinURNGenReq1" runat="server" Font-Size="Small" ForeColor="black" Text="URN Generation Requested"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--3row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #f4cccc" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label38" runat="server"></asp:Label>
                                                            <asp:Label ID="lblSpoPenQltyChk" runat="server" Font-Size="35px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblSpoPenQltyChk1" runat="server" Font-Size="Small" Text="Pending Quality Check"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ead1dc" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label41" runat="server"></asp:Label>
                                                            <asp:Label ID="lblinPndngMoCkTstComp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblinPndngMoCkTstComp1" runat="server" Font-Size="Small" Text="Pending for Mock Test Completion"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #cfe2f3" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label44" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindTrainSltAllc" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindTrainSltAllc1" runat="server" Font-Size="Small" Text="Training Slot Allocated"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #f9cb9c" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label47" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindPndngPrfrdDtSlctn" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindPndngPrfrdDtSlctn1" runat="server" Font-Size="Small" Text="Pending Preferred Date Selection"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ffe599" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label50" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindPndngPrfrdDtApp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindPndngPrfrdDtApp1" runat="server" Font-Size="Small" Text="Preferred Exam Date Approved"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #feffbe" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label53" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindExmSchRqustd" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindExmSchRqustd1" runat="server" Font-Size="Small" ForeColor="black" Text="Exam Schedule Requested"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--4row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #94ccff" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label56" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindSpnsrdExmSltAll" runat="server" Font-Size="35px"></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindSpnsrdExmSltAll1" runat="server" Font-Size="Small" Text="Exam Slot Allocated "></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fae2c0" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label59" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindPndngngRexm" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindPndngngRexm1" runat="server" Font-Size="Small" Text="Pending for Re-exam  "></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #b2e6d4" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label62" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindLicensed" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindLicensed1" runat="server" Font-Size="Small" Text="Licensed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ffc8c8" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label65" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindLcnsdExprd" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindLcnsdExprd1" runat="server" Font-Size="Small" Text="License Expired"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fbe1e2" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label68" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindCndRjctd" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindCndRjctd1" runat="server" Font-Size="Small" Text="Candidate Rejected"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #d6f1fe" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label71" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindNOCRqustd" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindNOCRqustd1" runat="server" Font-Size="Small" ForeColor="black" Text="NOC Requested"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--5row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #e7ffac" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label74" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindNOCAppByBM" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindNOCAppByBM1" runat="server" Font-Size="Small" Text="NOC approved by BM "></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fbe1e2" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label77" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindPndngslsApp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindPndngslsApp1" runat="server" Font-Size="Small" Text="Pending for Sales Team Approval"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #bafcc8" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label80" runat="server"></asp:Label>
                                                            <asp:Label ID="lblindNOCApproved" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblindNOCApproved1" runat="server" Font-Size="Small" Text="NOC Approved"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
                <%--POSP--%>
                <div id="divPosp" class="col-md-12" runat="server" style="display: none">
                    <table width="100%" align="center" class="tableIsys">
                        <tr>
                            <td>
                                <table width="100%">
                                    <%--1row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #bafcc8" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label83" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospPndngPANVrfctn" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospPndngPANVrfctn1" runat="server" Font-Size="Small" Text="Pending for PAN Verification"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fbe1e2" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label86" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospPndngCndReg" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospPndngCndReg1" runat="server" Font-Size="Small" Text="Pending for Candidate Registration"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ffefd9" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label89" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospPndngDocUpld" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospPndngDocUpld1" runat="server" Font-Size="Small" Text="Pending for Document Upload"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fff7c0" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label92" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospPndngAgntPro" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospPndngAgntPr1" runat="server" Font-Size="Small" Text="Pending for Agent Profiling"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #e5fde6" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label95" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospAgntProCom" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospAgntProCom1" runat="server" Font-Size="Small" Text="Agent Profiling Completed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fffbd5" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label98" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospPndngFees" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospPndngFees1" runat="server" Font-Size="Small" ForeColor="black" Text="Pending fees"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #d5fcf3" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label101" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospPndngFeesWaiApp" runat="server" Font-Size="Small" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospPndngFeesWaiApp1" runat="server" Font-Size="Small" Text="Pending fees Waiver Approval"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #f4e1fb" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label104" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospPndngQltychk" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospPndngQltychk1" runat="server" Font-Size="Small" Text="Pending Quality Check"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #d6f1fe" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label107" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospCFRRaised" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospCFRRaised1" runat="server" Font-Size="Small" Text="CFR Raised"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ecfdc1" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label110" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospQltyChckCom" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospQltyChckCom1" runat="server" Font-Size="Small" Text="Quality Checked Completed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #bafbfc" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label113" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospPndngMoCkTstComp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospPndngMoCkTstComp1" runat="server" Font-Size="Small" Text="Pending for Mock Test Completion"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #bafcc8" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label116" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospTrainSltAllc" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospTrainSltAllc1" runat="server" Font-Size="Small" ForeColor="black" Text="Training Slot Allocated"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #e5fde6" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label119" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpopExmSchRqustd" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpopExmSchRqustd1" runat="server" Font-Size="Small" Text="Exam Schedule Requested"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #cfe2f3" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label122" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospExmSltAll" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospExmSltAll1" runat="server" Font-Size="Small" Text="Examination Slot Allocated"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ffefd9" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label125" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospUIDGnrtnpndng" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospUIDGnrtnpndng1" runat="server" Font-Size="Small" Text="UID Genration Pending"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #b2e6d4" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label128" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospLicensed" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospLicensed1" runat="server" Font-Size="Small" Text="Licensed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fae2c0" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label131" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospPndngngRexm" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospPndngngRexm1" runat="server" Font-Size="Small" Text="Pending for Re-exam"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fbe1e2" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label134" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospCndRej" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospCndRej1" runat="server" Font-Size="Small" ForeColor="black" Text="Candidate Rejected"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #d6f1fe" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label137" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospNOCRqustd" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospNOCRqustd1" runat="server" Font-Size="Small" Text="NOC Requested"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #e7ffac" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label140" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospNOCAppByBM" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospNOCAppByBM1" runat="server" Font-Size="Small" Text="NOC Approved By BM"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fbe1e2" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label143" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospPndngslsApp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospPndngslsApp1" runat="server" Font-Size="Small" Text="Pending for Sales Team Approval"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #bafcc8" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label146" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpospNOCApproved" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblpospNOCApproved1" runat="server" Font-Size="Small" Text="NOC Approved"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
                <%--SPRTL--%>
                <div id="divsprtl" class="col-md-12" runat="server" style="display: block;">
                    <table width="100%" align="center" class="tableIsys">
                        <tr>
                            <td>
                                <table width="100%">
                                    <%--1row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fbe1e2" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label2" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlPndngCndReg" runat="server" Font-Size="35px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlPndngCndReg1" runat="server" Font-Size="Small" Text="Pending for Candidate Registration"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ffefd9" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label3" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlPndngDocUpld" runat="server" Font-Size="35px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlPndngDocUpld1" runat="server" Font-Size="Small" Text="Pending for Document Upload"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fff7c0" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label5" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlPndngAgntPro" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlPndngAgntPro1" runat="server" Font-Size="Small" Text="Pending for Agent Profiling"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #e5fde6" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label7" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlAgntProCom" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlAgntProCom1" runat="server" Font-Size="Small" Text="Agent Profiling Completed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fffbd5" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label9" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlPndngFees" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlPndngFees2" runat="server" Font-Size="Small" Text="Pending fees"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #d5fcf3" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label10" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlPndngFeesWaiApp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlPndngFeesWaiApp1" runat="server" Font-Size="Small" ForeColor="black" Text="Pending fees Waiver Approval"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--2row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #f4e1fb" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label12" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlPndngQltychk" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlPndngQltychk1" runat="server" Font-Size="Small" Text="Pending Quality Check"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #d6f1fe" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label13" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlCFRRaised" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlCFRRaised1" runat="server" Font-Size="Small" Text="CFR Raised"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ecfdc1" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label15" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldQltyChckCom" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldQltyChckCom1" runat="server" Font-Size="Small" Text="Quality Check Completed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fae2c0" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label16" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldPndngCmpstApp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldPndngCmpstApp1" runat="server" Font-Size="Small" Text="Pending Composite Approval"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #bafbfc" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label18" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlPndngURNGnrtn" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlPndngURNGnrtn1" runat="server" Font-Size="Small" Text="Pending for URN Generation"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #bafcc8" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label19" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlURNGenReq" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlURNGenReq1" runat="server" Font-Size="Small" ForeColor="black" Text="URN Generation Requested"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--3row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #f4cccc" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label21" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlSpoPenQltyChk" runat="server" Font-Size="35px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlSpoPenQltyChk1" runat="server" Font-Size="Small" Text="Pending Quality Check"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ead1dc" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label25" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtlPndngMoCkTstComp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtlPndngMoCkTstComp1" runat="server" Font-Size="Small" Text="Pending for Mock Test Completion"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #cfe2f3" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label27" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldTrainSltAllc" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldTrainSltAllc1" runat="server" Font-Size="Small" Text="Training Slot Allocated"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #f9cb9c" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label28" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldPndngPrfrdDtSlctn" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldPndngPrfrdDtSlctn1" runat="server" Font-Size="Small" Text="Pending Preferred Date Selection"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ffe599" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label30" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldPndngPrfrdDtApp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldPndngPrfrdDtApp1" runat="server" Font-Size="Small" Text="Preferred Exam Date Approved"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #feffbe" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label31" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldExmSchRqustd" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldExmSchRqustd1" runat="server" Font-Size="Small" ForeColor="black" Text="Exam Schedule Requested"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--4row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #94ccff" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label33" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldSpnsrdExmSltAll" runat="server" Font-Size="35px"></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldSpnsrdExmSltAll1" runat="server" Font-Size="Small" Text="Exam Slot Allocated "></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fae2c0" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label34" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldPndngngRexm" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldPndngngRexm1" runat="server" Font-Size="Small" Text="Pending for Re-exam  "></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #b2e6d4" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label36" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldLicensed" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldLicensed1" runat="server" Font-Size="Small" Text="Licensed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #ffc8c8" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label37" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldLcnsdExprd" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldLcnsdExprd1" runat="server" Font-Size="Small" Text="License Expired"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fbe1e2" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label39" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldCndRjctd" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldCndRjctd1" runat="server" Font-Size="Small" Text="Candidate Rejected"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #d6f1fe" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label40" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldNOCRqustd" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldNOCRqustd1" runat="server" Font-Size="Small" ForeColor="black" Text="NOC Requested"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--5row--%>
                                    <tr class="spaceUnder">
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #e7ffac" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label42" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldNOCAppByBM" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldNOCAppByBM1" runat="server" Font-Size="Small" Text="NOC approved by BM "></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #fbe1e2" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label43" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldPndngslsApp" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldPndngslsApp1" runat="server" Font-Size="Small" Text="Pending for Sales Team Approval"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 15%;">
                                            <div style="height: 100px; width: 213px; background-color: #bafcc8" class="rcorners1">
                                                <table align="center" style="width: 90%">
                                                    <tr style="height: 20%">
                                                        <td rowspan="2" style="width: 20%; color: White;">
                                                            <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                        </td>
                                                        <td style="width: 80%; padding-top: 10px;" align="right">
                                                            <asp:Label Font-Size="22px" ID="Label45" runat="server"></asp:Label>
                                                            <asp:Label ID="sprtldNOCApproved" runat="server" Font-Size="35px" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="sprtldNOCApproved1" runat="server" Font-Size="Small" Text="NOC Approved"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
            </div>
        </div>
    </form>
</body>
</html>









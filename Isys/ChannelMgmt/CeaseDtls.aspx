<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CeaseDtls.aspx.cs" Inherits="Application_Isys_ChannelMgmt_CeaseDtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />

    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />

    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
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
    <%--<script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>--%>

    <script type="text/javascript">
        function ClosePanel() {
            debugger
            window.parent.$find("mdlpopup").hide();
            window.parent.document.getElementById("btnProductDtls").click();
        }

        function ShowReqDtl(divName, btnName) {
            debugger;
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
                ShowError(err.description);
            }
        }
    </script>

    <script type="text/javascript">
        debugger;

        $(function () {
            var date = new Date();
            date.setDate(date.getDate());
            $("#<%= txtceaseDtim.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                minDate: 0
            });

        });

        $('.input-group').find('.glyphicon glyphicon-calendar').on('click', function () {
            $('#txtceaseDtim').trigger('focus');
        });
    </script>


    <script type="text/javascript">
        function callupdate() {
            $("#divpopshow").modal('show');

        }
    </script>

    <style type="text/css">
        .gvItemCenter {
            text-align: center !important;
        }

        .disablepage {
            display: none;
        }

        ul#menu {
            padding: 0;
            margin-right: 69%;
        }

            ul#menu li {
                display: inline;
            }

                ul#menu li a {
                    background-color: Silver;
                    color: black;
                    cursor: pointer;
                    padding: 10px 20px;
                    text-decoration: none;
                    border-radius: 4px 4px 0 0;
                }

                    ul#menu li a:active {
                        background: white;
                    }

                    ul#menu li a:hover {
                        background-color: red;
                    }

        #GrdStateDtls tr.rowHover:hover {
            background-color: #FCF8E3;
        }

        .hidScroll {
            margin-left: 0px !important;
            margin-right: 0px !important;
            margin-top: 0px !important;
            margin-bottom: 0px !important;
            border-color: #d6e9c6 !important;
        }
    </style>

    <asp:ScriptManager ID="scriptMgr" runat="server" />

    <asp:UpdatePanel ID="updnlCease" runat="server">
        <ContentTemplate>
            <div class="panel hidScroll" id="divAlert" style="max-height: 500px;">
                <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_TrEmpSearch','spngly');return false;">
                    <div class="row" style="text-align: left">
                        <div class="col-sm-10">
                            <asp:Label ID="lblBS" runat="server" Text="Product Cease Details" Font-Bold="False" Height="14px"
                                Font-Size="Small" Style="font-size: 19px"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="spngly" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; margin-top: -21px; padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>

                <div id="divlobsearch" runat="server" class="panel panel-body" style="margin-bottom: 25px">
                    <div class="container" style="width: 100%">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Label ID="lblProductCode" runat="server" Text="Product Code" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtprodCode" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblProdName" runat="server" Text="Product Name" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtprodname" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Label ID="Label1" runat="server" Text="Effective Date" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txteffDtim" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="Label2" runat="server" Text="Cease Date" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <div class="input-group">
                                    <asp:TextBox ID="txtceaseDtim" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon" id="startdate" style="font-size: 11px!important; line-height: 0!important;"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                            </div>


                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <center>
                            <asp:LinkButton ID="lnkbtnUpdate" CssClass="btn btn-sample"
                                runat="server" OnClick="lnkbtnUpdate_Click">
                                 <span class="glyphicon glyphicon-floppy-disk"  style="color:White"> </span> Update
                            </asp:LinkButton>

                            <asp:LinkButton ID="btnlnkcancel" runat="server" CssClass="btn btn-sample"
                                TabIndex="33" OnClick="btnCancel_Click">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> Cancel
                            </asp:LinkButton>
                                 </center>
                        </div>
                    </div>

                </div>
            </div>
            </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="container" id="divpopshow" style="display: none">
        <h2>Alert Messages</h2>
        <div class="alert alert-success alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
            Product is ceased.
        </div>
    </div>



</asp:Content>


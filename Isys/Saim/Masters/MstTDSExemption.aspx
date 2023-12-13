<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MstTDSExemption.aspx.cs" MasterPageFile="~/iFrame.master" Inherits="Application_Isys_Saim_Masters_MstTDSExemption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <style type="text/css">
        .ccsalignCenter {
            text-align: center !important;
        }

        .cssalingleft {
            text-align: left !important;
        }

        .cssalingright {
            text-align: right !important;
        }

        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
            color: white;
        }

        .new_text_new {
            color: #066de7;
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
        }

        .disablepage {
            display: none;
        }

        .box {
            background-color: #efefef;
            padding-left: 5px;
        }
    </style>
    <script type="text/javascript">

        function Enable() {
            document.getElementById('ctl00_ContentPlaceHolder1_divkpisrch').style.display = "none";
            document.getElementById('ctl00_ContentPlaceHolder1_Loading_gif').style.display = "block";
        }

        function AppliacbleToDate() {
            debugger;

            $("#<%= txtAppTo.ClientID  %>").datepicker({
                minDate: new Date(),
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }


        function AppliacbleFromDate() {
            debugger;

            $("#<%= txtAppAson.ClientID  %>").datepicker({
                minDate: new Date(),
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        function AppliFromDate() {
            debugger;

            $("#<%= TxtApplicableFrom.ClientID  %>").datepicker({
                minDate: new Date(),
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }


        function AppliToDate() {
            debugger;

            $("#<%= TxtApplicableTo.ClientID  %>").datepicker({
                minDate: new Date(),
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        $(document).ready(function () {
            $("th").click(function () {
                var columnIndex = $(this).index();
                var tdArray = $(this).closest("table").find("tr td:nth-child(" + (columnIndex + 1) + ")");
                tdArray.sort(function (p, n) {
                    var pData = $(p).text();
                    var nData = $(n).text();
                    return pData < nData ? -1 : 1;
                });
                tdArray.each(function () {
                    var row = $(this).parent();
                    $("#dgCntst").append(row);
                });
            });

            $("#start_datepicker").datepicker();
        })
    </script>
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
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ////ShowError(err.description);
            }
        }


        function funcall() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
        }

        function callsearch() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
        }
    </script>
    <script type="text/javascript" src="../../../Scripts/jquery.min.js"></script>
    <script type="text/javascript">
        debugger;
        $("[src*=btnexp]").live("click", function () {
            debugger;
            $(this).closest("tr").after("<tr><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../images/btncol.png");

        });
        $("[src*=btncol]").live("click", function () {
            debugger;
            $(this).attr("src", "../../../images/btnexp.png");
            $(this).closest("tr").next().remove();
        });
    </script>

    <style type="text/css">
        .radio-group label {
            overflow: hidden;
        }

        .radio-group input {
            /* This is on purpose for accessibility. Using display: hidden is evil. This makes things keyboard friendly right out tha box! */
            height: 1px;
            width: 1px;
            position: absolute;
            top: -20px;
        }

        .radio-group .not-active {
            color: #3276b1;
            background-color: #fff;
        }
    </style>



    <center> 


<%--        added by  ajay--%>



        <div id="div1" runat="server" style="width: 97%;" class="panel">
            <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div3','myImages');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">

                        <asp:Label ID="Label2" Text="NON STANDARD RULE" style="margin-left: 8px;font-size:19px;" runat="server" />
                    </div>
                    <div class="col-sm-2">
                             <span id="myImages" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> 

                    </div>
                </div>
            </div>
            <div id="div3" runat="server" style="width: 96%;" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                     <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblFinancialYear" Text="Financial Year" runat="server" CssClass="control-label" />
                    </div>
                     <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>
                                 <asp:DropDownList ID="ddlFinancialYear" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                </asp:DropDownList>             
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>                  
                     <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblNatureOfPayment" Text="Nature Of Payment" runat="server" CssClass="control-label"/>
                    </div>
                     <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                            <ContentTemplate>                           
                                 <asp:DropDownList ID="ddlNatureOfPayment" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                     <asp:ListItem Value="0">Select</asp:ListItem>
                                     <asp:ListItem Value="194D - Insurance Commision">194D - Insurance Commission</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                     <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblEntityType" Text="Entity Type" runat="server" CssClass="control-label"/>
                    </div>
                     <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                            <ContentTemplate>                           
                                 <asp:DropDownList ID="ddlEntityType" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>   
                <div class="row" style="margin-bottom: 5px;">

                     <div class="col-sm-2" style="text-align: left">
                         <asp:Label ID="lblExmCode" Text="Exemption Code" runat="server" CssClass="control-label"/>
                    </div>
                     <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                            <ContentTemplate>
                             
                                 <asp:DropDownList ID="ddlExmCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                 </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-2" style="text-align: left">
                         <asp:Label ID="lblPanSt" Text="PAN Status" runat="server" CssClass="control-label"/>
                    </div>
                    <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                            <ContentTemplate>
                             
                                 <asp:DropDownList ID="ddlPanSt" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                 </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblRate" Text="Rate %" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                            <ContentTemplate>
                            
                                <asp:TextBox ID="TxtRate" runat="server" CssClass="form-control" placeholder="Rate" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                       <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblBusiCode" Text="Busi Code " runat="server" CssClass="control-label" />
                    </div>
                      <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                            
                                <asp:TextBox ID="txtBusiCode" runat="server" CssClass="form-control" placeholder="Busi Code" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                      <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblApplicableFrom" Text="Applicable From" runat="server" CssClass="control-label" />
                    </div>
                     <div class="col-sm-2">
                     
                                <asp:TextBox ID="TxtApplicableFrom" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control" onmousedown="AppliFromDate()" onmouseup="AppliacbleFromDate()"/>

                    </div>

                      <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblApplicableTo" Text="Applicable To" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-2">
                      
                                <asp:TextBox ID="TxtApplicableTo" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control" onmousedown="AppliToDate()" onmouseup="AppliacbleToDate()"/>

                         
                    </div>
                    </div>

                <div class="row" style="margin-bottom: 5px;">
                       <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblMemberCode" Text="Member Code" runat="server" CssClass="control-label" />
                    </div>
                      <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                            <ContentTemplate>
                            
                              <%--  <asp:TextBox ID="txtMemberCode" runat="server" CssClass="form-control" placeholder="Member Code" />--%>
                                                            
                                 <asp:DropDownList ID="txtMemberCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                </asp:DropDownList>
                            
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                      <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblCommAmtFrm" Text="COMM. AMT. (Rs) FROM" runat="server" CssClass="control-label" />
                    </div>
                     <div class="col-sm-2">
                     
                                <asp:TextBox ID="txtlblCommAmtFrm" runat="server" placeholder="COMM. AMT. (Rs) FROM" CssClass="form-control"></asp:TextBox> 

                    </div>

                      <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblCommAmtTO" Text="COMM. AMT. (Rs) TO" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-2">
                      
                                <asp:TextBox ID="txtlblCommAmtTO" runat="server" placeholder="COMM. AMT. (Rs) TO" CssClass="form-control"></asp:TextBox> 

                         
                    </div>
                    </div>

                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                            <ContentTemplate>
                                 <asp:LinkButton ID="btnAddNew" runat="server"  CssClass="btn btn-sample" OnClick="btnAddNew_Click">
                                 <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Add New
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancl" runat="server" CssClass="btn btn-sample" OnClick="btnCancl_Click">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

               
            </div>
        </div>


        <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel">

           <%-- <input type="text" name="startdate" id="start_datepicker"  onmouseup="$('#start_datepicker').datepicker({ changeMonth: true, changeYear: true });"   onmousedown="$('#start_datepicker').datepicker({ changeMonth: true, changeYear: true });">--%>
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">

                        <asp:Label ID="lblhdr" Text="SEARCH CRITERIA" style="margin-left: 8px;font-size:19px;" runat="server" />
                    </div>
                    <div class="col-sm-2">
                             <span id="myImg" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>

                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" style="width: 96%;" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                     <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblPanStatus" Text="Financial Year" runat="server" CssClass="control-label" />
                    </div>
                     <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                 <asp:DropDownList ID="ddlFinYr" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                </asp:DropDownList>             
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>                  
                     <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblNaturePay" Text="Nature Of Payment" runat="server" CssClass="control-label"/>
                    </div>
                     <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>                           
                                 <asp:DropDownList ID="ddlNtrOfPay" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                     <asp:ListItem Value="0">Select</asp:ListItem>
                                     <asp:ListItem Value="194D - Insurance Commision">194D - Insurance Commission</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                     <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblEntityTyp" Text="Entity Type" runat="server" CssClass="control-label"/>
                    </div>
                     <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>                           
                                 <asp:DropDownList ID="ddlEntityTyp" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblMemCode" Text="Member Code" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                            
                                <asp:TextBox ID="txtMemCode" runat="server" CssClass="form-control" placeholder="" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblAppAson" Text="Applicable From" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-2">
                     
                                <asp:TextBox ID="txtAppAson" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control" onmousedown="AppliacbleFromDate()" onmouseup="AppliacbleFromDate()"/>

                    </div>
                    <div class="col-sm-2" style="text-align: left">
                        <asp:Label ID="lblAppTo" Text="Applicable To" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-2">
                      
                                <asp:TextBox ID="txtAppTo" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control" onmousedown="AppliacbleToDate()" onmouseup="AppliacbleToDate()"/>

                         
                    </div>
                     </div>
                   <div class="row" style="margin-bottom: 5px;">

                     <div class="col-sm-2" style="text-align: left">
                         <asp:Label ID="lblExemCode" Text="Exemption Code" runat="server" CssClass="control-label"/>
                    </div>
                     <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>
                             
                                 <asp:DropDownList ID="ddlExempCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                 </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                         <asp:Label ID="lblFinYr" Text="PAN Status" runat="server" CssClass="control-label" Visible="false"/>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                             
                                 <asp:DropDownList ID="ddlPanStatus" runat="server" AutoPostBack="true" CssClass="select2-container form-control" Visible="false"
                                    TabIndex="4">
                                 </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                 
                </div>

                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
         
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" OnClientClick="Enable()" OnClick="btnSearch_Click">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample" OnClick="btnClear_Click">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
      
        <%--Start By bhau--%>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <div id="divChanlWiseCompenDsn" runat="server" style="width: 97%;" class="panel" visible="false">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divResultDtls','ImgResultDtls');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>&nbsp;--%><%-- added and commented by ajay sawant 25/4/2018--%>
                                <asp:Label ID="lblchnldesgin" Text="Channel Wise Compensations in Design" Style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <span id="ImgResultDtls" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divResultDtls" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                             
                                    <div style="margin-right: 0%; margin-left: 11px;" id="dvNewReg">
                                        <div class="row" style="color: White;">
                                            <div class="col-sm-4" style="text-align: center; width: 31%; padding: 20px; margin: 1% 1% 1% 1%;
                                                box-shadow: 0 5px 5px #ACACAC; border-radius: 5px; background-color: #58caf0;"> <%--#5bc0de--%>
                                          
                                                 <asp:Label runat="server" ID="SpnAgency" Text="0" style="font-size: large; font-weight: bold;"></asp:Label>
                                                <br />
                                                <span id="Span2" style="font-size: small; font-weight: bold;">AGENCY </span>
                                            </div>
                                            <div class="col-sm-4" style="margin: 1% 1% 1% 1%; text-align: center; width: 31%;
                                                padding: 20px; box-shadow: 0 5px 5px #ACACAC; border-radius: 5px; background-color: #aaf058;"> <%--#5cb85c--%>
                                               <%-- <span id="SpanHealth" style="font-size: 200%; font-weight: bold" runat="server">0</span>--%>
                                                  <asp:Label runat="server" ID="SpanHealth" Text="0" style="font-size: large; font-weight: bold;"></asp:Label>
                                                <br />
                                                <span id="Span3" style="font-size: small; font-weight: bold;">HEALTH</span>
                                            </div>
                                            <div class="col-sm-4" style="margin: 1% 1% 1% 1%; width: 31%; text-align: center;
                                                padding: 20px; box-shadow: 0 5px 5px #ACACAC; border-radius: 5px; background-color: #f2b852;"> <%--#f0ad4e--%>
                                               <%-- <span id="SpanDirect" style="font-size: 200%; font-weight: bold" runat="server">0</span>--%>
                                                  <asp:Label runat="server" ID="SpanDirect" Text="0" style="font-size: large; font-weight: bold;"></asp:Label>
                                                <br />
                                                <span id="Span4" style="font-size: small; font-weight: bold;">DIRECT</span>
                                            </div>
                                        </div>
                                    </div>
                                <%--</div>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--End by bhau--%>
       
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="divcmpsrchhdrcollapse" runat="server" style="width: 97%;" class="panel ">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpisrch','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                             <div class="col-sm-6">
                                 <asp:Label ID="lblCmpSrch" Text="MEMBER WISE TDS EXEMPTION MASTER" style="margin-left:15px;font-size:19px;" runat="server" />
                             </div>
                                <div class="col-sm-6">
                                      <img id="Loading_gif" style="display:none;  margin-top:5px;margin-right:100px" runat="server" 
                                    src="../../Recruit/assets/img/animated_gif_loader.gif" />
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate>
                                        <span id="Img1" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay text sawant 24/4/2018--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divkpisrch" runat="server" style="width: 96%; padding: 10px;overflow-x:scroll;">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgCmp" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="20" AllowSorting="True" OnSorting="dgCmp_Sorting" AllowPaging="true"
                                    CssClass="footable" OnRowDataBound="dgCmp_RowDataBound"  >
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                     
                                         <asp:TemplateField HeaderText="SR.NO" SortExpression="[SR NO]" Visible="false">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblSrNo"  Text='<%# Bind("[SR NO]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="FIN. YEAR" SortExpression="[Financial Year]">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblFinYearr"  Text='<%# Bind("[Financial Year]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="ccsalignCenter" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="MEM. CODE" SortExpression="[Member Code]">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblMemCode"  Text='<%# Bind("[Member Code]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="MEM. NAME" SortExpression="[Member Name]">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblMemNAME"  Text='<%# Bind("[Member Name]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="MEM. TYPE" SortExpression="MemTypeDesc">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblMemType"  Text='<%# Bind("MemTypeDesc")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="CHANNEL" SortExpression="ChannelDesc01">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblChannel"  Text='<%# Bind("ChannelDesc01")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="SUB CHANNEL" SortExpression="ChnClsDesc01">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblSubChannel"  Text='<%# Bind("ChnClsDesc01")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="NATURE OF PAYMENT" SortExpression="[Nature Of Payment]">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblNatrPay"  Text='<%# Bind("[Nature Of Payment]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="ccsalignCenter" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="EXEMPTION CODE" SortExpression="[Exemption Code] ">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblExmpCode"  Text='<%# Bind("[Exemption Code]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="PAN STATUS" SortExpression="[PAN Status]">
                                            <ItemTemplate>          
                                                <asp:Label ID="Label1"  Text='<%# Bind("[PAN Status]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="ENTITY TYPE" SortExpression="[Entity Type]">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblEntType"  Text='<%# Bind("[Entity Type]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="COMM. AMT. (Rs) FROM" SortExpression="[Comm Amt Frm]">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblCommAmtFrm"  Text='<%# Bind("[Comm Amt Frm]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="COMM. AMT. (Rs) TO" SortExpression="[Comm Amt To]">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblCommAmtTo"  Text='<%# Bind("[Comm Amt To]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="RATE %" SortExpression="RATE">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblRate"  Text='<%# Bind("RATE")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="APPLICABLE FROM" SortExpression="[FROM DATE]" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblAppfrom"  Text='<%# Bind("[FROM DATE]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="APPLICABLE TO" SortExpression="[TO DATE]" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>          
                                                <asp:Label ID="lblAppTo"  Text='<%# Bind("[TO DATE]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>


                             <asp:TemplateField ItemStyle-Width="20%" HeaderText="Upload">
                            <ItemTemplate>
                                <div style="width: 100%;">
                                    <i class="fa fa-map-marker"></i>
                                    <asp:LinkButton ID="lblUpld" Text="Upload" runat="server"></asp:LinkButton>&nbsp;&nbsp;
                                   
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>

                                      
                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="View">
                            <ItemTemplate>
                                <div style="width: 100%;">
                                    <i class="fa fa-map-marker"></i>
                                    <asp:LinkButton ID="lblView" Text="View" runat="server"></asp:LinkButton>&nbsp;&nbsp;
                                   
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <%--ajay paging--%>
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
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 50px; border-style: solid;
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

                         <%--ajay paging--%>



                     
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MSTACTSU.aspx.cs" Inherits="Application_Isys_Saim_Customisation_MSTACTSU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
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
    <script type="text/javascript" src="..//../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <style type="text/css">
        .location {
            text-align: right;
        }


        .CenterAlign {
            text-align: center !important;
        }

        .LeftAlign {
            text-align: left !important;
        }

        .RightAlign {
            text-align: right !important;
        }
    </style>


    <script type="text/javascript">
        debugger;

        $(document).ready(function () {
            debugger;
            window.history.forward();

	$("#<%=TextSrAcNo.ClientID%>").keypress(function (event) {
                debugger;
                var keycode = event.which;
                if (!(keycode >= 48 && keycode <= 57)) {
                    event.preventDefault();
                }
            });
        });
        function PopulateLDFrom() {
            debugger;
            //minDate:new Date()
            $("#<%= txtEffDtFrm.ClientID  %>").datepicker({
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


        function PopulateLDFrom() {
            debugger;
            //minDate:new Date()
            $("#<%= txtEffDtFrm.ClientID  %>").datepicker({
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



        function PopulateLDFromGrid(obj,Flag) {
            debugger;
            //minDate:new Date()
            $(obj).datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDateGRD(obj,Flag);
                    }
                }
            });
        }


        function PopulateCeasedtGrid(obj,Flag) {
            debugger;
            //minDate:new Date()
            $(obj).datepicker({
                dateFormat: 'dd/mm/yy',
                minDate: new Date(),
                changeMonth: true,
                changeYear: true,
                onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDateGRD(obj, Flag);
                    }
                }
            });
        }



        function PopulateCeaseDate() {
            debugger;

            $("#<%= txtceasedt.ClientID  %>").datepicker({
                //minDate: new Date(),
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


        function checkDate() {
            debugger;

            var EffDate = $('#<%= txtEffDtFrm.ClientID  %>').val();
            var CeDate = $('#<%= txtceasedt.ClientID  %>').val();
            var strcontent = "ctl00_ContentPlaceHolder1_";
            debugger;
            if (EffDate != "" && CeDate != "") {
                if (!checkDateIsGreaterThanToday(EffDate, CeDate)) {
                    alert("Please select the correct cease date");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtceasedt").value = "";
                    return false;
                }
                else {
                    //alert("step2");
                }
            }
        }

        function checkDateGRD(OBJ,Flag) {
            debugger;

           // alert("hi")

            var n = OBJ.id.length

            


            if (Flag == 1) {
                 n = n - 13;
                 var EffDateID = OBJ.id.substring(0, n) + "DateTimeValue";

                 var CeDateID = OBJ.id.substring(0, n) + "txtceasedtedit";
            }
            else
            {
                 n = n - 14;
                 var EffDateID = OBJ.id.substring(0, n) + "DateTimeValue";

                 var CeDateID = OBJ.id.substring(0, n) + "txtceasedtedit";

            }

            var EffDate = document.getElementById(EffDateID).value;
            var CeDate = document.getElementById(CeDateID).value;

           // var CeDate2 = document.getElementById(CeDateID).value;
            var strcontent = "ctl00_ContentPlaceHolder1_";
            //ctl00_ContentPlaceHolder1_grvaddedresult_ctl02_DateTimeValue
            //ctl00_ContentPlaceHolder1_grvaddedresult_ctl02_txtceasedtedit
             debugger;
             if (EffDate != "" && CeDate != "") {
                 if (!checkDateIsGreaterThanToday(EffDate, CeDate)) {
                     alert("Please select the correct cease date");
                     document.getElementById(CeDateID).value = "";
                     return false;
                 }
                 else {
                     //alert("step2");
                 }
             }
         }

        function checkDateIsGreaterThanToday(fromDay, toDay) {
            debugger;
            var fromArr = fromDay.split('/');
            var toArr = toDay.split('/');

            if (fromArr[2] == toArr[2]) {
                if (fromArr[1] < toArr[1]) {
                    if (fromArr[0] <= toArr[0]) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else if (fromArr[1] == toArr[1]) {
                    if (fromArr[0] <= toArr[0]) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return false;
                }
            }
            else if (fromArr[2] < toArr[2]) {

                return true;

            }
            else {
                return false;
            }
        }


    </script>


    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindPicker);
            bindPicker();
        });
        function bindPicker() {
            $("input[type=text][id*=DateTimeValue]").datepicker({
                changeMonth: true,
                changeYear: true
            });
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
                ShowError(err.description);
            }
        }
    </script>
    <style>
        input[type='text'] {
            padding: 0px !important;
        }
    </style>

    <%--Added by Prity for parent action code--%>


    <center>
     <div id="divParentAct" runat="server" style="width: 97%;" class="panel" >
        <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divprntAct','prntAct');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="Label3" Text="Merge Parent Map" Font-Size="19px" runat="server" />
                    
                </div>
                <div class="col-sm-2">
                    <span id="prntAct" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 24/4/2018--%>
                </div>
            </div>
        </div>
        <div id="divprntAct" runat="server" style="width: 96%;" class="panel-body">
            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="Label4" Text="Parent Map code" runat="server" CssClass="control-label" />
                    
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlActCode" CssClass="select2-container form-control" ClientIDMode="Static" runat="server"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
            <div id="divprntBTN" runat="server" class="row" style="margin-top: 12px;">
                <div class="col-sm-12" align="center">

                    <asp:LinkButton ID="btnY" runat="server" CssClass="btn btn-sample" OnClick="btnY_Click" >
                                    <span class="glyphicon glyphicon-ok" style="color: White;"></span> YES
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnN" runat="server" CssClass="btn btn-sample" OnClick="btnN_Click" >
                                    <span class="glyphicon glyphicon-remove" style="color: White;"></span> NO
                    </asp:LinkButton>

                    <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-sample" OnClientClick="history.go(-1); return false;" >
                                    <span class="glyphicon glyphicon-arrow-left" style="color: White;"></span> Back
                    </asp:LinkButton>
                </div>
            </div>
        </div>

    </div>

    <%--Ended by Prity for parent action code--%>

    <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel">
        <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="lblhdr" Text="Add Action" Font-Size="19px" runat="server" />
                </div>
                <div class="col-sm-2">
                    <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 24/4/2018--%>
                </div>
            </div>
        </div>
        <div id="divcmphdr" runat="server" style="width: 96%;" class="panel-body">
            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblMappedCd" Text="Mapped code." runat="server" CssClass="control-label" />
                      <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtMappedCd" runat="server" Text="1001" Enabled="false" CssClass="form-control" TabIndex="1"
                                MaxLength="8" placeholder="Mapped code." />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>


            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblCompCode" Text="Action No." runat="server" CssClass="control-label" />
                      <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtActionNo" runat="server" Onclick="lblCompCode_Click" Enabled="false" CssClass="form-control" TabIndex="1"
                                MaxLength="8" placeholder="Action No." />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblRulVer" Text="Action Ver" runat="server"  CssClass="control-label" />
                      <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="updateActionver" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtActionVer" runat="server"  Enabled="false"  CssClass="form-control" Text="1.0" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
             <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblActionName" Text="Action Name" runat="server" CssClass="control-label" />
                      <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">

                    <asp:UpdatePanel ID="updateActionname" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtActionName" runat="server" CssClass="form-control" placeholder="Action Name" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblActionDesc" Text="Action Description" runat="server" CssClass="control-label" />
                      <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdateActionDesc" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtActionDesc" runat="server" CssClass="form-control" placeholder="Action Description" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>

            </div>

            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblAuthfls" Text="Status" runat="server" CssClass="control-label" />
                      <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:DropDownList ID="ddlAuthFlg" CssClass="select2-container form-control" ClientIDMode="Static" runat="server"></asp:DropDownList>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblActionType" Text="Action Type" runat="server" CssClass="control-label" />
                      <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:DropDownList ID="ddlActionType" CssClass="select2-container form-control" Enabled="false" ClientIDMode="Static" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblEffDate" Text="Effective Date" runat="server" CssClass="control-label" />
                      <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtEffDtFrm" runat="server" CssClass="form-control" onmousedown="PopulateLDFrom()" onmouseup="PopulateLDFrom()"
                                placeholder="DD/MM/YYYY" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblceasedt" Text="Cease Date" runat="server" CssClass="control-label" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtceasedt" runat="server"  CssClass="form-control" onmousedown="PopulateCeaseDate()" onmouseup="PopulateCeaseDate()" placeholder="DD/MM/YYYY" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>

           

            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblExecOrder" Text="Execution Order" runat="server" CssClass="control-label" />
                      <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                          <%--  <asp:DropDownList ID="ddlExecOrder" CssClass="select2-container form-control" ClientIDMode="Static" runat="server" AutoPostBack="true">
                            </asp:DropDownList>--%>
                             <asp:TextBox ID="txtExecOrder" runat="server" Enabled="false" CssClass="form-control" />

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>




            <div id="tbladdcmpst" runat="server" class="row" style="margin-top: 12px;">
                <div class="col-sm-12" align="center">

                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-sample" TabIndex="17">
                                            <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnCnclCmp" OnClick="btnCnclCmp_Click" runat="server" CssClass="btn btn-sample" TabIndex="18">
                        <span class="glyphicon glyphicon-remove"  style="color:White"></span> Cancel
                    </asp:LinkButton>
                </div>
            </div>


        </div>
    </div>

    <div id="divsrchdrcollapse" runat="server" style="width: 97%;" class="panel"  >
        <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmpSrch','SrchImg');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <%--                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;commennted by ajay sawant 25/4/2018--%>
                    <asp:Label ID="Label2" Text="Search Action" Font-Size="19px" runat="server" />
                </div>
                <div class="col-sm-2">
                    <span id="SrchImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 24/4/2018--%>
                </div>
            </div>
        </div>

        <div id="divcmpSrch" runat="server" style="width: 96%;display:none" class="panel-body"   >
            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblSrAcNo" Text="Action No." runat="server" CssClass="control-label" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TextSrAcNo" runat="server" CssClass="form-control" TabIndex="1"
                                MaxLength="8" placeholder="Enter Action No." />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblSrAcDesc" Text="Action Description" runat="server" CssClass="control-label" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TextSrAcDesc" runat="server" CssClass="form-control" TabIndex="1"
                              placeholder="Enter Action Description"   />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
            <div id="tblSrch" runat="server" class="row" style="margin-top: 12px;">
                <div class="col-sm-12" align="center">

                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" OnClick="btnSearch_Click">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                    </asp:LinkButton>

                     <asp:LinkButton ID="btnBackSearch" runat="server" CssClass="btn btn-sample" OnClick="btnCnclCmp_Click">
                                    <span class="glyphicon glyphicon-remove" style="color: White;"></span> Cancel
                    </asp:LinkButton>
                </div>
            </div>

        </div>

    </div>

    <div id="divResult" runat="server" style="width: 97%;" class="panel">


        <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div3','myImg1');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="Label1" Text="Added Action Results" Font-Size="19px" runat="server" />
                </div>
                <div class="col-sm-2">
                    <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>

       
        <div id="div3" runat="server" style="width: 96%; overflow-x:scroll" >
            <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grvaddedresult" runat="server" AutoGenerateColumns="false"
                        OnRowEditing="grvaddedresult_RowEditing"
                        OnRowUpdating="grvaddedresult_RowUpdating"
                        OnRowCancelingEdit="grvaddedresult_RowCancelingEdit"
                        OnRowDeleting="grvaddedresult_RowDeleting"
                        OnSorting="grvaddedresult_Sorting"
                        OnRowDataBound="grvaddedresult_RowDataBound"
                        Style="margin-right: 1%; margin-top: 0.3%; margin-bottom: 0.3%"
                        CssClass="footable"
                        CellPadding="4" AllowSorting="True" ShowHeaderWhenEmpty="true" ShowFooter="false"
                        DataKeyNames="ACT_TYP_code"
                        AllowPaging="True" PageSize="5" ForeColor="#333333" GridLines="None" EmptyDataText="No Record found..!">
                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                        <PagerStyle CssClass="disablepage" />
                        <HeaderStyle CssClass="gridview th" />
                        <Columns>
                            <asp:TemplateField HeaderText="Mapped Code" SortExpression="MAP_CODE" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" CssClass="CenterAlign" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMappedCd" runat="server" Text='<%# Bind("MAP_CODE")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMappedCd" ToolTip='<%# Bind("MAP_CODE")%>' Enabled="false" CssClass="form-control" Text='<%# Bind("MAP_CODE")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Mapper Description" SortExpression="ACT_DESC" ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left"  CssClass="LeftAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMappedDesc" runat="server" Text='<%# Bind("MapDesc")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMappedDesc" ToolTip='<%# Bind("MapDesc")%>' CssClass="form-control" Enabled="false" Text='<%# Bind("MapDesc")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>

                            </asp:TemplateField>


                            
                            <asp:TemplateField HeaderText="Action No." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                SortExpression="ACT_NO">
                                <ItemStyle HorizontalAlign="Center" CssClass="CenterAlign" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblCompCode" runat="server" Text='<%# Bind("ACT_NO")%>' OnClick="lblCompCode_Click"> </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtActionNo" ToolTip='<%# Bind("ACT_NO")%>' Text='<%# Bind("ACT_NO")%>' CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action Version" SortExpression="ACT_VER" ItemStyle-HorizontalAlign="Right" > 
                               
                                <ItemStyle HorizontalAlign="Right"  CssClass="RightAlign" />
                                <HeaderStyle CssClass="location" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRulVer" runat="server" Text='<%# Bind("ACT_VER")%>' CssClass="location" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtActionVer" ToolTip='<%# Bind("ACT_VER")%>' CssClass="form-control" Enabled="false" Text='<%# Bind("ACT_VER")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField HeaderText="Action Name" SortExpression="ACT_NAME" ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" CssClass="LeftAlign" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblActionName" runat="server" Text='<%# Bind("ACT_NAME")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtActionNameEdit" ToolTip='<%# Bind("ACT_NAME")%>' CssClass="form-control" Text='<%# Bind("ACT_NAME")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action Description" SortExpression="ACT_DESC" ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left"  CssClass="LeftAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="txtAct_Desc" runat="server" Text='<%# Bind("ACT_DESC")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAct_DescEdit" ToolTip='<%# Bind("ACT_DESC")%>'  CssClass="form-control" Text='<%# Bind("ACT_DESC")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status" SortExpression="STATUS" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"  CssClass="LeftAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAuthfls" runat="server" Text='<%# Bind("STATUS_DESC")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlAuthEdit" Width="100px" CssClass="form-control"   ClientIDMode ="Static" runat="server">
                                    </asp:DropDownList>
                                     <asp:HiddenField ID="hdnSTATUS"  runat="server" Value='<%# Bind("STATUS")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action Type" SortExpression="ACT_TYP" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" CssClass="LeftAlign" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblActionType" runat="server" Text='<%# Bind("ACT_TYP")%>' />
                                </ItemTemplate>
                               <%-- <EditItemTemplate>
                                    <asp:DropDownList ID="ddlActionEdit" Width="100px" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:DropDownList>
                                    <asp:HiddenField ID="hdnAction" runat="server" Value='<%# Bind("ACT_TYP_code")%>' />
                                  
                                </EditItemTemplate>--%>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Effective Date" SortExpression="EFF_DTIM" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" CssClass="RightAlign" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEffDate" runat="server" Text='<%# Bind("EFF_DTIM")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="DateTimeValue" onmousedown="PopulateLDFromGrid(this,1)"  ToolTip='<%# Bind("EFF_DTIM")%>' CssClass="form-control" Text='<%# Bind("EFF_DTIM")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cease Date" SortExpression="CSE_DTIM" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" CssClass="RightAlign" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblceasedt" runat="server" Text='<%# Bind("CSE_DTIM")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtceasedtedit" onmousedown="PopulateCeasedtGrid(this,2)" ToolTip='<%# Bind("CSE_DTIM")%>' CssClass="form-control" Text='<%# Bind("CSE_DTIM")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                           

                            <asp:TemplateField HeaderText="Execution Order" SortExpression="EXCTN_ORDR" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"  CssClass="CenterAlign"/>
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblexecorder" runat="server" Text='<%# Bind("EXCTN_ORDR")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                  <%--  <asp:DropDownList ID="ddlEcecuteEdit" CssClass="form-control" ClientIDMode="Static" Width="100px" runat="server"></asp:DropDownList>--%>
                                      <asp:TextBox ID="txtexcuteOrder" Text='<%# Bind("EXCTN_ORDR")%>' ToolTip='<%# Bind("EXCTN_ORDR")%>' CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:LinkButton Text="Edit" ShowEditButton="true" CommandName="Edit" runat="server" />
                                   <%-- <asp:LinkButton Text="Delete" ShowEditButton="true" CommandName="delete" runat="server" />--%>

                                    <%-- <asp:LinkButton ID="lnkDelAct" runat="server" ShowEditButton="true" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                    OnClick="lnkDelAct_Click"></asp:LinkButton>--%>

                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" ShowEditButton="true" CommandName="Update" runat="server" />
                                    <asp:LinkButton ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" ShowEditButton="true" CommandName="Cancel" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
             <center> 
            <div class="pagination" style="padding: 10px;">
                      
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <%--background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />--%>
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                    <%--float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />--%>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                
                        </div>
              
 </center> 
        </div>






    </div>


    </center>




</asp:Content>


<%--protected void grvMapping_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                string lblChannel = ((Label)grvMapping.Rows[e.NewEditIndex].FindControl("lblChannel")).Text;
                string lblsubChannel = ((Label)grvMapping.Rows[e.NewEditIndex].FindControl("lblsubChannel")).Text;
                string lblUnitType = ((Label)grvMapping.Rows[e.NewEditIndex].FindControl("lblUnitType")).Text;
                string lblUnitCode = ((Label)grvMapping.Rows[e.NewEditIndex].FindControl("lblUnitCode")).Text;

                int index = e.NewEditIndex;
                //DataBindGridView();  // this is a method which assigns the DataSource and calls GridView1.DataBind()
                //DropDownList DdlCountry = GridView1.Rows[index].FindControl("DdlCountry") as DropDownList;

                grvMapping.EditIndex = index;
                BindUserMapping();

                DropDownList ddlchn = grvMapping.Rows[index].FindControl("GridDdlchn") as DropDownList;
                DropDownList ddlsubchn = grvMapping.Rows[index].FindControl("GridDdlsubchn") as DropDownList;
                DropDownList ddlunittyp = grvMapping.Rows[index].FindControl("GridDdlunittyp") as DropDownList;
                DropDownList ddlUnitCode = grvMapping.Rows[index].FindControl("GridDdlUnitCode") as DropDownList;

                htParam.Clear();
                dsResult.Clear();
                dsResult = objDal.GetDataSet("Prc_GetChannelType", htParam, "demoConn");
                FillDropdowns(dsResult, ddlchn, true, "Select (Channel)");
                ddlchn.Items.FindByText(lblChannel).Selected = true;


                Hashtable htparam1 = new Hashtable();
                DataSet dsDDL1 = new DataSet();
                htparam1.Add("@channelType", ddlchn.SelectedValue);
                dsDDL1 = objDal.GetDataSet("Prc_GetSubChannelType", htparam1, "demoConn");
                if (dsDDL1.Tables.Count != 0)
                {
                    bindDropdown(ddlsubchn, dsDDL1);
                }
                else
                {
                    ddlsubchn.Items.Clear();
                    ddlunittyp.Items.Clear();                  
                    ddlUnitCode.Items.Clear();
                  
                }
                //ddlsubchn.SelectedValue = lblsubChannel;
                ddlsubchn.Items.FindByText(lblsubChannel).Selected = true;

                Hashtable htparam3 = new Hashtable();
                DataSet dsDDL3 = new DataSet();
                htparam3.Add("@channelType", ddlchn.SelectedValue);
                htparam3.Add("@ddlsubchn", ddlsubchn.SelectedValue);
                dsDDL3 = objDal.GetDataSet("Prc_GetUnitType", htparam3, "demoConn");
                if (dsDDL3.Tables.Count != 0)
                {
                    bindDropdown(ddlunittyp, dsDDL3);
                }
                else
                {
                    ddlunittyp.Items.Clear();
                }
                //ddlunittyp.SelectedValue = lblUnitType;
                ddlunittyp.Items.FindByText(lblUnitType).Selected = true;

                
                Hashtable htparam5 = new Hashtable();
                DataSet dsDDL5 = new DataSet();
                htparam5.Add("@chnl", ddlchn.SelectedValue);
                htparam5.Add("@unttype", ddlunittyp.SelectedValue);
                dsDDL5 = objDal.GetDataSet("Prc_GetUntCodeForLoggedinUser_UserCreation", htparam5, "demoConn");
                if (dsDDL5.Tables.Count != 0)
                {
                    bindDropdown(ddlUnitCode, dsDDL5);
                }
                else
                {
                    ddlUnitCode.Items.Clear();
                  
                }
                //ddlUnitCode.SelectedValue = lblUnitCode;
                ddlUnitCode.Items.FindByText(lblUnitCode).Selected = true;
                ddlsubchn.Items.Insert(0, new ListItem("Select (Sub Channel)", "0"));
                ddlunittyp.Items.Insert(0, new ListItem("Select (Unit Type)", "0"));
                ddlUnitCode.Items.Insert(0, new ListItem("Select (Unit Name)", "0"));
            }

            catch (Exception Ex)
            {
                ErrorLog errObj = new ErrorLog();
            }
        }--%>
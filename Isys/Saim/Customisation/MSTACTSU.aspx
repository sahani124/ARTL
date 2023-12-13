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


    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <style>
        #sortable {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 60%;
        }

            #sortable li {
                margin: 0 3px 3px 3px;
                padding: 0.4em;
                padding-left: 1.5em;
                font-size: 1.4em;
                height: 18px;
            }

                #sortable li span {
                    position: absolute;
                    margin-left: -1.3em;
                }
    </style>

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



        function PopulateLDFromGrid(obj) {
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
                        checkDate();
                    }
                }
            });
        }


        function PopulateCeasedtGrid(obj) {
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
                        checkDate();
                    }
                }
            });
        }



        function PopulateCeaseDate() {
            debugger;

            $("#<%= txtceasedt.ClientID  %>").datepicker({
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
                    <asp:LinkButton ID="btnResetExecOrder" OnClientClick="openPopup(); return false" runat="server" CssClass="btn btn-sample" TabIndex="18">
                        <span class="glyphicon glyphicon-edit" style="color:White"></span> 
                        <%--<span class="glyphicon glyphicon-remove"  style="color:White"></span>--%>
                         Modify Execution order
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
                        AllowPaging="True" PageSize="50" ForeColor="#333333" GridLines="None" EmptyDataText="No Record found..!">
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
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlActionEdit" Width="100px" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:DropDownList>
                                    <asp:HiddenField ID="hdnAction" runat="server" Value='<%# Bind("ACT_TYP_code")%>' />
                                  
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Effective Date" SortExpression="EFF_DTIM" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" CssClass="RightAlign" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEffDate" runat="server" Text='<%# Bind("EFF_DTIM")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="DateTimeValue" onmousedown="PopulateLDFromGrid(this)"  ToolTip='<%# Bind("EFF_DTIM")%>' CssClass="form-control" Text='<%# Bind("EFF_DTIM")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cease Date" SortExpression="CSE_DTIM" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" CssClass="RightAlign" />
                                <HeaderStyle CssClass="gridview th" />
                                <ItemTemplate>
                                    <asp:Label ID="lblceasedt" runat="server" Text='<%# Bind("CSE_DTIM")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtceasedtedit" onmousedown="PopulateCeasedtGrid(this)" ToolTip='<%# Bind("CSE_DTIM")%>' CssClass="form-control" Text='<%# Bind("CSE_DTIM")%>' runat="server"></asp:TextBox>
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
    <div>
        <div class="modal fade" id="ExecOrderPopup" tabindex="-1" role="dialog" aria-labelledby="ExecOrderPopup" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <span style="font-size: 20px" class="modal-title">Modify Execution Order</span>
                        <br />
                        <span  style="font-size: 14px; color:red" >Note: Please arrange the Actions according to execution order(Ascending)</span>
                    </div>
                    <div class="modal-body">
                        <div id="iLoading_new" class="Content" style="position: relative; top: 50%; left: 45%; z-index: 9999;">
                            <img src="../../../../assets/img/loading-spinner-blue.gif" alt="LOADING" />
                            Loading...
                        </div>
                        <div id="popup-body">
                             <table id="tblActions" class="footable">
                            </table>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <center>
                        <button type="button" id="btnSaveExecOrder"  onclick="saveExecOrder()" style="margin-bottom: 0px;" class="btn btn-sample">
                            <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span>
                            Update
                        </button>
                        <%--<button type="button" id="btnReset" onclick="resetExecOrder()" class="btn btn-sample">Reset</button>--%>
                        <button type="button" id="btnClose" class="btn btn-sample" onclick="closePopup()">
                            <span class="glyphicon glyphicon-remove" style="color:White"></span>
                            Close
                        </button>
                            </center>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        var action_data = null;
        function resetExecOrder() {
            //$("#tblActions").sortable('refresh');
            $("#tblActions").sortable( "refreshPositions" )
        }

        function saveExecOrder() {
            debugger;
            var toArray = $("#tblActions").sortable('toArray');
            var rowArray = toArray.map(function (x, i) {
                let data = $($("#" + x)[0]).data('obj');
                data["NEW_EXEC_ORDER"] = (i+1)
                return data;
            })

            $("#iLoading_new").show();

            var exec_data = {
                data : rowArray
            }
            $.ajax({
                url: "mstactsu.aspx/SaveExecutionOrder",
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(exec_data),
                async: false,
                dataType: 'json',
                success: function (resp) {
                    $("#iLoading_new").hide();
                    var d = resp.d
                    if (d["status"] == '0') {
                        alert('Execution order for Actions updated sucessfully .')
                        closePopup();
                        setTimeout(function () { window.location.href = window.location.href }, 1000);
                    }
                    else {
                        alert('something went wrong');
                    }
                },
                error: function () {
                    alert('something went wrong');
                }
            })
        }

        function openPopup() {
            debugger;
            $("#iLoading_new").show();
            var MAP_CODE = $("#<%= txtMappedCd.ClientID %>").val();
            var action_type = $("#<%= ddlActionType.ClientID %>").val();
            var data = {
                "map_code": MAP_CODE,
                "action_type": action_type,
            }
            $.ajax({
                url: "mstactsu.aspx/GetActionData",
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                async: false,
                dataType: 'json',
                success: function (resp) {
                    $("#iLoading_new").hide();
                    var d = resp.d
                    if (d["status"] == '0') {
                        $("#ExecOrderPopup").modal({
                            keyboard: false,
                            backdrop: "static"
                        });
                        var headerrow = '<thead><tr>'
                            + '<th>Current Execution Order</th>'
                            + '<th>Action</th>'
                            + '<th>Updated Execution Order</th>'
                            + '</tr></thead>'
                        var data = d['data'];
                        action_data = data;
                        var datarows = "<tbody>" + data.map(function (x, i) {
                            return "<tr id='sort_row"  + i +"' data-obj='" + JSON.stringify(x) +"'>"
                                        +'<td>' + x["EXCTN_ORDR"] + '</td>'
                                        + '<td>' + x["ACT_DESC"] + '</td>' 
                                        + '<td>' + (i + 1) + '</td> </tr>'
                        }).join('') + "</tbody>" 
                        $("#tblActions").html(headerrow + datarows)
                        $("#tblActions").sortable({
                            items: 'tbody tr',
                            cursor: 'pointer',
                            axis: 'y',
                            dropOnEmpty: false,
                            start: function (e, ui) {
                                ui.item.addClass("selected");
                            },
                            stop: function (e, ui) {
                                ui.item.removeClass("selected");
                                $(this).find("tr").each(function (index) {
                                    if (index > 0) {
                                        $(this).find("td").eq(2).html(index);
                                    }
                                });
                            },
                            update: function (e, ui) {
                            }
                        });
                    }
                    else {
                        alert(d["message"]);
                    }
                },
                error: function () {
                    alert('something went wrong');
                }
            })
            return false;
        }

        function closePopup() {
            $("#ExecOrderPopup").modal('hide')
            $("#tblActions").sortable("destroy");
            $("#tblActions").empty();
        }
    </script>

</asp:Content>

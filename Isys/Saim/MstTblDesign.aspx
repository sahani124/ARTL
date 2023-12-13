<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="MstTblDesign.aspx.cs" Inherits="Application_INSC_Recruit_MstTblDesign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        //loading image icon
        function LdWait(delay) {
            //debugger;
            document.getElementById("ctl00_ContentPlaceHolder1_divLoader").style.display = 'block';
            setTimeout("RemoveLoading12()", delay);
        }

        function RemoveLoading12() {
            //debugger;
            //hide loading status...
            document.getElementById("ctl00_ContentPlaceHolder1_divLoader").style.display = 'none';

        }

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

        function CloseDiv(divId) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + divId) != null) {
                document.getElementById(strContent + divId).style.display = 'none';
            }
        }

        function funMandatory() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtDoctype").value == "") {
                RemoveLoading12();
                alert("Document Type is mandatory.");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDoctype").focus();

                return false;
            }

            if (document.getElementById("ctl00_ContentPlaceHolder1_txtDocDesc").value == "") {

                alert("Document Description is mandatory.");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDocDesc").focus();
                return false;
                var strContent = "ctl00_ContentPlaceHolder1";
                var id = strContent.dgMstDesign.Rows(Me.dgMstDesign.EditItemIndex).FindControl("txtColName").ClientId
                RemoveLoading12();
            }

            if (document.getElementById("ctl00_ContentPlaceHolder1_txtShrtDocName").value == "") {
                RemoveLoading12();
                alert("Document short code is mandatory.");
                document.getElementById("ctl00_ContentPlaceHolder1_txtShrtDocName").focus();
                return false;
            }

            if (document.getElementById("ctl00_ContentPlaceHolder1_txtColcnt").value == "") {
                RemoveLoading12();
                alert("Column count is mandatory.");
                document.getElementById("ctl00_ContentPlaceHolder1_txtColcnt").focus();
                return false;
            }
        }

        //    function ShowReqDtl(divId, btnId) {
        //        //debugger;
        //        if (document.getElementById(divId).style.display == "block") {
        //            document.getElementById(divId).style.display = "none";
        //            document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
        //        }
        //        else {
        //            document.getElementById(divId).style.display = "block";
        //            document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '-';
        //        }
        //    }
        //shreela
        function RestrictSpaceSpecial() {
            //debugger;
            if ((event.keyCode == 33 || event.keyCode == 34 || event.keyCode == 35 || event.keyCode == 36 || event.keyCode == 37 || event.keyCode == 38 || event.keyCode == 39 || event.keyCode == 40 || event.keyCode == 41 || event.keyCode == 42 || event.keyCode == 43 || event.keyCode == 44 || event.keyCode == 45 || event.keyCode == 46 || event.keyCode == 47 || event.keyCode == 64)) {
                alert("Special characters restricted");
                event.returnValue = false;

            }
        }
        function Restrict() {
            //debugger;
            if (!(event.keyCode == 48 || event.keyCode == 49 || event.keyCode == 50 || event.keyCode == 51 || event.keyCode == 52 || event.keyCode == 53 || event.keyCode == 54 || event.keyCode == 55 || event.keyCode == 56 || event.keyCode == 57)) {
                alert("Only numeric values are allowed");
                event.returnValue = false;
            }
        }

        function StartProgressBar() {
            // debugger;
            var myExtender = $find('ProgressBarModalPopupExtender');
            myExtender.show();
            return true;
        }

        //shreela

        function AlertMsgs(msgs) {
            alert(msgs);
        }

    </script>
    <asp:ScriptManager ID="SmMstdesign" runat="server">
    </asp:ScriptManager>
     <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
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
    <style type="text/css">
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
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
            vertical-align: top;
        }
        
    </style>
    <div style="width: 100%;">
    <br />
        <div id="divdefhdrcollapse" runat="server" style="width: 95%;" class="panel panel-success">
            <div id="Div6" runat="server" class="panel-heading" style="width: 100%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_tblMstDesign','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                        <asp:Label ID="lblMstDocDesign" runat="server" Style="padding-left: 5px;" />
                    </div>
                    <div class="col-sm-2">
                        <span id="myImg" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="tblMstDesign" runat="server" style="width: 100%;" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblUDoctype" runat="server" CssClass="control-label" /><asp:Label
                            ID="Label2" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtDoctype" runat="server" CssClass="form-control" TabIndex="3"
                            onChange="javascript:this.value=this.value.toUpperCase();" />
                        <asp:HiddenField ID="hdntxtDoctype" runat="server" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblDecDesc" runat="server" CssClass="control-label" /><asp:Label ID="Label3"
                            Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtDocDesc" runat="server" CssClass="form-control" TabIndex="4"
                            onChange="javascript:this.value=this.value.toUpperCase();" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblshrtDocName" runat="server" CssClass="control-label" /><asp:Label
                            ID="Label4" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtShrtDocName" runat="server" CssClass="form-control" TabIndex="3"
                            onChange="javascript:this.value=this.value.toUpperCase();" />
                        <asp:Label ID="lblshrt" Text="(eg.UAAAAAA)" runat="server" CssClass="control-label"
                            Style="color: red" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblColcnt" runat="server" CssClass="control-label" /><asp:Label ID="Label5"
                            Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtColcnt" runat="server" CssClass="form-control" TabIndex="4" onkeypress="Restrict()"
                            onChange="javascript:this.value=this.value.toUpperCase();" />
                        <asp:HiddenField ID="hdnColcnt" runat="server" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblFileSize" Text="File Size" runat="server" CssClass="control-label" /><asp:Label
                            ID="Label12" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="upldFileSize" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlFileSize" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="10" Width="97%">
                                </asp:DropDownList>
                                <asp:Label ID="Label1" runat="server" Text="(In KB's)" Style="color: red"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3">
                        <%-- <div class="btn btn-xs btn-primary" style="width:130px;"><i class="fa fa-flash"></i>--%>
                        <asp:LinkButton ID="btnInsert" runat="server" OnClick="btnInsert_Click"
                            OnClientClick="LdWait(100000)" CssClass="btn btn-primary">
                            <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> START DESIGN
                        </asp:LinkButton>
                    </div>
                    <div class="col-sm-3">
                        <div id="divloader" runat="server" style="display: none;">
                            &nbsp;&nbsp;
                            <img id="Img1" alt="" src="../../../app_themes/isys/images/spinner.gif" runat="server" />
                            Loading...
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <table id="tblDocType" runat="server" class="tableIsys" style="width: 100%;" visible="false">
            <tr style="width: 100%">
                <td id="Td1" class="test" colspan="4" runat="server" style="height: 20px;">
                    <asp:Label ID="lblformat" runat="server" Font-Bold="true">Upload New Version</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formcontent" align="center">
                    <asp:Label ID="lblName" runat="server" Text="Document Name" Style="color: Black"></asp:Label>
                </td>
                <td class="formcontent" align="center">
                    <%--<asp:UpdatePanel ID="updName" runat="server">
                      <ContentTemplate>--%>
                    <asp:DropDownList ID="ddlName" DataTextField="ParamDesc" runat="server" CssClass="standardmenu"
                        AutoPostBack="true" TabIndex="11" Width="400px" OnSelectedIndexChanged="ddlName_SelectIndexChanged">
                    </asp:DropDownList>
                    <%--  </ContentTemplate>
                  </asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <%-- <asp:UpdatePanel ID="updView" runat="server">
                      <ContentTemplate>--%>
                    <%-- <div class="btn btn-xs btn-primary" style="width:120px;">--%>
                    <%-- <i class="fa fa-external-link"></i> --%>
                    <asp:Button ID="btnView" runat="server" CssClass="standardbutton" Text="View Format"
                        Width="100px" Visible="true" OnClick="btnView_Click" /><%--</div>--%>
                    <%--</ContentTemplate>
                  </asp:UpdatePanel>--%>
                </td>
            </tr>
        </table>
    <div id="div1" runat="server" style="width: 100%;" class="panel panel-success">
        <div style="text-align: left" class="panel-heading">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                    <asp:Label ID="lblMstDocName" Text="Master Document Details" runat="server" Style="padding-left: 5px;" />
                </div>
                <div class="col-sm-2">
                    <img id="Img3" src="../../../assets/img/portlet-collapse-icon-white.png" style="padding-right: 10px;"
                        alt="" onclick="ShowReqDtl('divEditDesign','Img3','#Img3');" />
                </div>
            </div>
        </div>
        <div id="divEditDesign" runat="server" style="width: 100%;">
            <table id="tblEditDesign" runat="server" style="width: 100%;" visible="false">
                <tr>
                    <td style="height: 10px;">
                    </td>
                </tr>
                <tr style="height: 20px;">
                    <td colspan="4">
                        <asp:UpdatePanel ID="UpdGrid1" runat="server">
                            <ContentTemplate>
                                <div id="div4" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                    class="table-scrollable">
                                    <asp:GridView ID="dgMstDesign" runat="server" AllowSorting="True" CssClass="table table-striped table-bordered table-hover dataTable"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                        HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="false" Width="99%"
                                        PageSize="1" OnRowDataBound="dgMstDesign_RowDataBound" Height="23px">
                                        <HeaderStyle ForeColor="Black" Width="100%" />
                                        <RowStyle />
                                        <PagerStyle CssClass="disablepage" />
                                        <Columns>
                                            <asp:TemplateField SortExpression="" HeaderText="ColumnName" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtColName" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                        MaxLength="50" Width="100%" onkeypress="RestrictSpaceSpecial()" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="9%" />
                                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="" HeaderText="Primary" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlIsPrim" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                        TabIndex="22" Width="97%">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="" HeaderText="DataType" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlDataType" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                        TabIndex="22" Width="97%">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="9%" />
                                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="" HeaderText="Length" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtLength" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                        MaxLength="50" Width="100%" onkeypress="Restrict()" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="" HeaderText="Mandatory" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlIsMandatory" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                        TabIndex="22" Width="97%">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="8%" />
                                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="" HeaderText="Verif Req" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlVerifReq" OnSelectedIndexChanged="ddlVerifReq_SelectedIndexChanged"
                                                        runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                        TabIndex="22" Width="97%">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="8%" />
                                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="" HeaderText="Permissible" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPermisibleValues" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                        MaxLength="50" Width="100%" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="" HeaderText="Database" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlDB" runat="server" OnSelectedIndexChanged="ddlDB_SelectedIndexChanged"
                                                        runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                        TabIndex="22" Width="97%">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="9%" />
                                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="" HeaderText="Table" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddltbl" runat="server" OnSelectedIndexChanged="ddltbl_SelectedIndexChanged"
                                                        AutoPostBack="true" CssClass="select2-container form-control" TabIndex="22" Width="97%">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="9%" />
                                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="" HeaderText="Column" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlCol" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                        TabIndex="22" Width="97%">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="9%" />
                                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField SortExpression="" HeaderText="where">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtwhere" runat="server" CssClass="standardtextbox" MaxLength="35"
                                                            Width="100%" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" />
                                        </asp:TemplateField>--%>
                                        </Columns>
                                        <%-- <RowStyle CssClass="sublinkodd"></RowStyle>
                                    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                    </PagerStyle>
                                    <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>--%>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px;">
                    </td>
                </tr>
            </table>
        </div>
    </div>
        <div class="row" style="margin-top: 12px;">
            <div class="col-sm-12" align="center">
                <asp:LinkButton ID="btnIns" runat="server" OnClick="btnIns_Click" CssClass="btn btn-primary">
                        <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Add
                </asp:LinkButton>
                <span style="padding-left: 3px;"></span>
                <asp:LinkButton ID="btnClr" runat="server" OnClick="btnClr_Click" CssClass="btn btn-primary">
                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Clear
                </asp:LinkButton>
            </div>
        </div>
        <div id="div2" runat="server" style="width: 100%; padding-top: 10px;" class="divBorder1" visible="false">
            <table id="tbl_grid" class="formtablehdr" style="width: 99%;" runat="server" visible="false">
                <tr id="tr_grid" align="left" style="visibility: hidden">
                    <td colspan="4" style="padding-left: 5px;">
                        <i class="fa fa-list"></i>
                        <asp:Label ID="lblNotes" Text="Notes" runat="server" Style="padding-left: 5px;" />
                    </td>
                    <td style="height: 32px; text-align: right;">
                        <img id="Img4" src="../../../assets/img/portlet-collapse-icon-white.png" style="padding-right: 10px;"
                            alt="" onclick="ShowReqDtl('divSearchDetails','Img4','#Img4');" />
                    </td>
                </tr>
            </table>
            <%--   <table id="tbl_grid" class="test table-condensed" style="width: 99%;" runat="server" visible="false">
                <tr id="tr_grid" align="left" style="visibility:hidden">
                    <td align="left" class="test" style="width:100%;">
                    <input runat="server" class="standardbutton" type="button" value="-" id="btnUploadDtls"  
                        style="width:20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearchDetails','ctl00_ContentPlaceHolder1_btnUploadDtls');"/> 
                    <asp:Label ID="lblNotes" runat="server"  Text="Notes" Font-Bold="true"></asp:Label>
                    </td>

                </tr>
                </table>
            --%>
            <div id="divSearchDetails" runat="server" style="display: block;">
                <table id="tblnotes" runat="server" width="99%" visible="false">
                    <tr runat="server" style="height: 10px;">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" align="left" class="test" style="width: 20%;">
                            Description
                        </td>
                        <td nowrap="nowrap" align="left" class="test" style="width: 30%;" colspan="3">
                            Values
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 20%;">
                            <span style="color: red">Permissible Values</span>
                        </td>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 30%;" colspan="3">
                            <span style="color: red">Values should be comma (,) separator</span>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 20%; height: 18px;">
                            <span style="color: red">Verification Required</span>
                        </td>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 30%; height: 18px;"
                            colspan="3">
                            <span style="color: red">0 (Not Required)</span>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 20%;">
                        </td>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 30%;">
                            <span style="color: red">1 (Check Permissible value)</span>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 20%;">
                        </td>
                        <td nowrap="nowrap" align="left" class="formcontent" style="width: 30%;" colspan="3">
                            <span style="color: red">2 (Chk verify table)</span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="div3" runat="server" style="width: 100%;" class="divBorder1">
            <table id="tbldgMstDocs" class="formtablehdr" style="width: 100%;" runat="server"
                visible="false">
                <tr id="tr1" align="left">
                    <td colspan="4" style="padding-left: 5px;">
                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                        <asp:Label ID="lblMstDocDsgn" Text="Master Document Design" runat="server" Style="padding-left: 5px;" />
                    </td>
                    <td style="height: 32px; text-align: right;">
                        <img id="Img5" src="../../../assets/img/portlet-collapse-icon-white.png" style="padding-right: 10px;"
                            alt="" onclick="ShowReqDtl('divsearch','Img5','#Img5');" />
                    </td>
                </tr>
            </table>
            <div id="divsearch" runat="server" style="display: block;">
                <table id="tbldgMstDocDesign" runat="server" style="width: 99%; margin-right: 0px;"
                    visible="false">
                    <%--class="formtable"--%>
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="div5" runat="server" style="width: 87%; border: none; margin: 0px 0 !important;"
                                class="table-scrollable">
                                <asp:GridView ID="dgMstDocDesign" runat="server" AllowSorting="True" PagerStyle-HorizontalAlign="Center"
                                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" CssClass="table table-striped table-bordered table-hover dataTable"
                                    HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%"
                                    PageSize="10" OnRowDataBound="dgMstDocDesign_RowDataBound" OnRowCommand="dgMstDocDesign_RowCommand"
                                    OnRowDeleting="dgMstDocDesign_RowDeleting" OnPageIndexChanging="dgMstDocDesign_PageIndexChanging">
                                    <HeaderStyle ForeColor="Black" Width="100%" />
                                    <RowStyle />
                                    <PagerStyle CssClass="disablepage" />
                                    <Columns>
                                        <asp:TemplateField SortExpression="Column1" HeaderText="DocType" Visible="false"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl1" runat="server" Text='<%# Eval("DocType") %>' Width="70" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField SortExpression="Column12" HeaderText="SeqNo" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblseqno" runat="server" Text='<%# Eval("Column12") %>'   Width="50" />
                                                </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField SortExpression="Column2" HeaderText="Column Name" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2" runat="server" Text='<%# Eval("ColumnName") %>' Width="80" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column6" HeaderText="Isprimary" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl6" runat="server" Text='<%# Eval("Isprimary") %>' Width="100" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column3" HeaderText="DataType" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl3" runat="server" Text='<%# Eval("Datatype") %>' Width="100" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column4" HeaderText="Length" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl4" runat="server" Text='<%# Eval("Length") %>' Width="70" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column5" HeaderText="XLHDR" Visible="false" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl5" runat="server" Text='<%# Eval("XLHDR") %>' Width="100" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column7" HeaderText="Mandatory" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl7" runat="server" Text='<%# Eval("Mandatory") %>' Width="80" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column9" HeaderText="VerifReq" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl9" runat="server" Text='<%# Eval("VrifReq") %>' Width="100" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column8" HeaderText="PermissibleValues" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl8" runat="server" Text='<%# Eval("PermissibleValues") %>' Width="100"
                                                    AutoPostBack="true" CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column10" HeaderText="VerifDb" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl10" runat="server" Text='<%# Eval("VrifDb") %>' Width="100" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column11" HeaderText="VerifDb" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl11" runat="server" Text='<%# Eval("VerifTbl") %>' Width="70" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column11" HeaderText="VerifTblColumn" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl12" runat="server" Text='<%# Eval("VerifTblColumn") %>' Width="70"
                                                    AutoPostBack="true" CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column11" HeaderText="Status" Visible="false"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl14" runat="server" Text='<%# Eval("Status") %>' Width="70" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField SortExpression="Column11" HeaderText="VerifWhereCond">
                                            <ItemTemplate>                                                
                                                <asp:Label ID="lbl13" runat="server" Text='<%# Eval("VerifWhereCond") %>' Width="70" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField SortExpression="Column11" HeaderText="Createby" Visible="false"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl15" runat="server" Text='<%# Eval("Createby") %>' Width="70" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column11" HeaderText="CreatedDTime" Visible="false"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl16" runat="server" Text='<%# Eval("CreatedDTime") %>' Width="70"
                                                    AutoPostBack="true" CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column11" HeaderText="UpdateBy" Visible="false"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl17" runat="server" Text='<%# Eval("UpdateBy") %>' Width="70" AutoPostBack="true"
                                                    CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Column11" HeaderText="UpdatedDTime" Visible="false"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl18" runat="server" Text='<%# Eval("UpdatedDTime") %>' Width="70"
                                                    AutoPostBack="true" CssClass="select2-container form-control" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <div style="width: 100%;">
                                                    <i class="fa fa-trash-o"></i>
                                                    <asp:LinkButton ID="DeleteBtn" Text="Delete" CommandName="Delete" runat="server"
                                                        ForeColor="Red" AutoPostBack="true" CssClass="select2-container form-control" /></div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                            <ControlStyle Font-Underline="True" />
                                            <FooterStyle Font-Underline="False" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <%-- <RowStyle CssClass="sublinkodd"></RowStyle>
                                    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                    </PagerStyle>
                                    <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>--%>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%-- <asp:UpdatePanel ID="updMsttblDesign" runat="server">
             <ContentTemplate>--%>'
        <div id="tblUpload" runat="server" style="width: 95%;" class="panel panel-success">
            <div id="Div7" runat="server" class="panel-heading" style="width: 100%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpisrch','Span1');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                        <asp:Label ID="lblUpload" runat="server" Text="Master Document Design" Font-Bold="false"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span style="padding-left: 70%;"></span>
                        <asp:Label ID="lblUPageInfo" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                        <span id="Span1" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divkpisrch" runat="server" style="width: 100%; padding: 10px;" class="panel-body">
                <div id="div8" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                    class="table-scrollable">
                    <asp:GridView ID="dgUpload" runat="server" AllowSorting="True" CssClass="footable"
                        HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="false" Width="100%"
                        PageSize="10" OnRowCommand="dgUpload_RowCommand" OnRowDataBound="dgUpload_RowDataBound"
                        OnRowDeleting="dgUpload_RowDeleting" OnRowEditing="dgUpload_RowEditing">
                        <RowStyle CssClass="GridViewRow"></RowStyle>
                        <PagerStyle CssClass="disablepage" />
                        <HeaderStyle CssClass="gridview th" />
                        <Columns>
                            <asp:TemplateField HeaderText="DocType" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblUDocType" runat="server" Text='<%# Eval("DocType") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Column Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblUColumnName" runat="server" Text='<%# Eval("ColumnName") %>' Width="100%" />
                                </ItemTemplate>
                                <ItemStyle Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Isprimary">
                                <ItemTemplate>
                                    <asp:Label ID="lblUIsprimary" runat="server" Text='<%# Eval("Isprimary") %>' Width="100%" />
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DataType">
                                <ItemTemplate>
                                    <asp:Label ID="lblUDataType" runat="server" Text='<%# Eval("Datatype") %>' Width="100%" />
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Length">
                                <ItemTemplate>
                                    <asp:Label ID="lblULength" runat="server" Text='<%# Eval("Length") %>' Width="100%" />
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="XLHDR" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblUXLHDR" runat="server" Text='<%# Eval("XLHDR") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mandatory">
                                <ItemTemplate>
                                    <asp:Label ID="lblUMandatory" runat="server" Text='<%# Eval("MandatoryFlag") %>'
                                        Width="100%" />
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VerifReq">
                                <ItemTemplate>
                                    <asp:Label ID="lblUVrifReq" runat="server" Text='<%# Eval("VerifReq") %>' Width="100%" />
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PermissibleValues">
                                <ItemTemplate>
                                    <asp:Label ID="lblUPermissibleValues" runat="server" Text='<%# Eval("PremissibleValues") %>'
                                        Width="100%" />
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Database">
                                <ItemTemplate>
                                    <asp:Label ID="lblUVrifDb" runat="server" Text='<%# Eval("VerifDb") %>' Width="100%" />
                                </ItemTemplate>
                                <ItemStyle Width="14%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Table">
                                <ItemTemplate>
                                    <asp:Label ID="lblUVerifTbl" runat="server" Text='<%# Eval("VerifTbl") %>' Width="100%" />
                                </ItemTemplate>
                                <ItemStyle Width="14%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Column">
                                <ItemTemplate>
                                    <asp:Label ID="lblUVerifTblColumn" runat="server" Text='<%# Eval("VerifTblColumn") %>'
                                        Width="100%" />
                                </ItemTemplate>
                                <ItemStyle Width="14%" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                    <div style="width: 100%;">
                                        <i class="fa fa-edit"></i>
                                        <asp:LinkButton ID="EditBtn" runat="server" Text="Edit" ForeColor="Green" CommandName="Edit"
                                            CommandArgument='<%# Eval("ColumnName") %>' /></div>
                                </ItemTemplate>
                                <ItemStyle Width="3%" />
                                <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                <ControlStyle Font-Underline="True" />
                                <FooterStyle Font-Underline="False" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <div style="width: 100%;">
                                        <i class="fa fa-trash-o"></i>
                                        <asp:LinkButton ID="DeleteBtn" runat="server" Text="Delete" CommandName="Delete"
                                            ForeColor="Red" />
                                </ItemTemplate>
                                <ItemStyle Width="3%" />
                                <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                <ControlStyle Font-Underline="True" />
                                <FooterStyle Font-Underline="False" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="pagination" style="display: block;">
                    <center>
                        <table>
                            <tr>
                                <td style="white-space: nowrap;">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" />
                                            <asp:TextBox runat="server" ID="txtPage" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                            <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                float: left; margin: 0; height: 30px;" Width="40px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </div>
            <div style="height: 20px;display:none;">
                <%--<div class="btn btn-xs btn-primary" style="width:120px;"><i class="fa fa-plus"></i>--%>
                <asp:Button ID="btnAdd" runat="server" CssClass="standardbutton" Text="Add" Width="114px"
                    OnClick="btnAdd_Click" /><%--</div>--%>
            </div>
        </div>
        <%--</table>--%>
        <table id="tblButton" runat="server" class="form-actions fluid" style="width: 99%;">
            <tr>
                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;">
                    <%-- <div class="btn btn-xs btn-primary" style="width:120px;"><i class="fa fa-lightbulb-o"></i>--%>
                    <asp:Button ID="btnConfirm" runat="server" CssClass="btn blue" TabIndex="11" Text="CONFIRM"
                        Width="114px" OnClick="btnConfirm_Click" /><%--</div>--%>
                    <span style="padding-left: 3px;"></span>
                    <%--<div class="btn btn-xs btn-primary" style="width:120px;"><i class="fa fa-lightbulb-o"></i>--%>
                    <asp:Button ID="btnFinish" runat="server" CssClass="btn blue" TabIndex="11" Text="FINISH"
                        Width="114px" OnClick="btnFinish_Click" /><%--</div>--%>
                    <span style="padding-left: 3px;"></span>
                    <%-- <div class="btn btn-xs btn-primary" style="width:120px;"><i class="fa fa-times"></i>--%>
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn default" TabIndex="11" Text="CANCEL"
                        Width="114px" OnClick="btnCancel_Click" /><%--</div>--%>
                </td>
            </tr>
        </table>
    </div>
    <%--  <table id="Table1" runat="server" class="formtable">
         <tr>
                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4" class="form-actions fluid">
                    <asp:Button ID="btnC" Text="CANCEL" runat="server" CssClass="btn blue" 
                        Width="80px" TabIndex="24" OnClientClick="doCancel();" />
                </td>
            </tr>
        </table>--%>
    <%--</ContentTemplate>
             <Triggers><asp:AsyncPostBackTrigger ControlID="ddlName" EventName="SelectedIndexChanged" /></Triggers>
             <Triggers><asp:AsyncPostBackTrigger ControlID="btnView" EventName="Click" /></Triggers>
        </asp:UpdatePanel>--%>
    <asp:HiddenField ID="hdnGridRowId" runat="server" />
    <asp:HiddenField ID="hdnColumnName" runat="server" />
    <asp:HiddenField ID="hdnIsprimary" runat="server" />
    <asp:HiddenField ID="hdnDataType" runat="server" />
    <asp:HiddenField ID="hdnLength" runat="server" />
    <asp:HiddenField ID="hdnMandatory" runat="server" />
    <asp:HiddenField ID="hdnVrifReq" runat="server" />
    <asp:HiddenField ID="hdnPermissibleValues" runat="server" />
    <asp:HiddenField ID="hdnVrifDb" runat="server" />
    <asp:HiddenField ID="hdnVerifTbl" runat="server" />
    <asp:HiddenField ID="hdnVerifTblColumn" runat="server" />
    <%--For Displaying Information Pop-up Start--%>
    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="409px" Height="157px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <table>
            <tr>
                <td style="width: 391px">
                    <br />
                    <center>
                        <asp:Label ID="lbl_popup" runat="server"></asp:Label><br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center style="height: 36px">
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="40px" /></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl_popup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--For Displaying Information Pop-up End--%>
</asp:Content>

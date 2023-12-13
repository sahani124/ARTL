<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="Popdatedefsetup.aspx.cs" Inherits="Application_ISys_Saim_Popdatedefsetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
<%--        $(function () {
            debugger;
            $("#<%= TxtEffFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= TxtEffTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });--%>

        function checkDateIsGreaterThanToday(fromDay, toDay) {

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

        function checkDate() {
            var EffDate = $('#<%= TxtEffFrom.ClientID  %>').val();
            var CeDate = $('#<%= TxtEffTo.ClientID  %>').val();
            var strcontent = "ctl00_ContentPlaceHolder1_";

            if (EffDate != "" && CeDate != "") {
                if (!checkDateIsGreaterThanToday(EffDate, CeDate)) {
                    alert("Please enter the correct Effective to date");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtCeDate").value = "";
                    return false;
                }
                else {
                    //alert("step2");
                }
            }
        }

        function PopulateCalender() {
            //minDate:new Date()
            $("#<%= TxtEffFrom.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        $(document).ready(function () {
            debugger;
            $("#<%= TxtEffFrom.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });

            $("#<%= TxtEffTo.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });
        })

        function populateGridCalender(obj) {
            $(obj).datepicker({
                dateFormat: 'dd/mm/yy'
                , changeMonth: true,
                changeYear: true
            });
        }

        function PopulateCalender1() {
            $("#<%= TxtEffTo.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
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
        function doCancel() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
<%--        $(function () {
            var strcontent = "ctl00_ContentPlaceHolder1_";
            $("#<%=txtRSKDesc.ClientID %>").keypress(function () {
                alert("Please add master using ADD MASTER...")
                document.getElementById(strcontent + "txtRSKDesc").value == "";
                //document.getElementById(strcontent + "txtRSKDesc").value = "";
                return false;


            });
        });--%>

<%--        function doCancel(rultyp) {

            if (rultyp == "Q") {
                /////alert('akshayQ');
                window.parent.document.getElementById("btnqual").click();
            }
            else if (rultyp == "R") {
                /////alert('akshayR');
                window.parent.document.getElementById("btnrwd").click();
            }
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }--%>

<%--        function validate() {

            var strcontent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strcontent + "txtRSKDesc") != null) {
                if (document.getElementById(strcontent + "txtRSKDesc").value == "") {
                    alert("Please add master using ADD MASTER...");
                    document.getElementById(strcontent + "txtRSKDesc").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlRSKDesc") != null) {
                if (document.getElementById(strcontent + "ddlRSKDesc").value == "") {
                    alert("Please Select Rule Set Key Description...");
                    document.getElementById(strcontent + "ddlRSKDesc").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlKPICode") != null) {
                if (document.getElementById(strcontent + "ddlKPICode").value == "") {
                    alert("Please Select KPI Description");
                    document.getElementById(strcontent + "ddlKPICode").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlAccMode") != null) {
                if (document.getElementById(strcontent + "ddlAccMode").value == "") {
                    alert("Please Select Accumulation Mode");
                    document.getElementById(strcontent + "ddlAccMode").focus();
                    return false;
                }
            }





            if (document.getElementById(strcontent + "txtVrEffFrm") != null) {
                if (document.getElementById(strcontent + "txtVrEffFrm").value == "") {
                    alert("Please enter Eff. From");
                    document.getElementById(strcontent + "txtVrEffFrm").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtVrEffTo") != null) {
                if (document.getElementById(strcontent + "txtVrEffTo").value == "") {
                    alert("Please enter Eff. To");
                    document.getElementById(strcontent + "txtVrEffTo").focus();
                    return false;
                }
            }

            var RB1 = document.getElementById("<%=rblCRYFWD.ClientID%>");
            var radio = RB1.getElementsByTagName("input");
            var isChecked = false;
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {
                    isChecked = true;
                    break;
                }
            }
            if (!isChecked) {
                alert("Please select Carry Forward Rule");
                return false;
            }

            if (document.getElementById(strcontent + "ddlRwdCmpRul") != null) {
                if (document.getElementById(strcontent + "ddlRwdCmpRul").value == "") {
                    alert("Please Select Reward Computation Rule");
                    document.getElementById(strcontent + "ddlRwdCmpRul").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtMaxLmt") != null) {
                if (document.getElementById(strcontent + "txtMaxLmt").value == "") {
                    alert("Please enter Max Limit");
                    document.getElementById(strcontent + "txtMaxLmt").focus();
                    return false;
                }
            }

        }--%>
</script>
    <%--<Added by bhaurao>--%>
    <style type="text/css">
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }*/
        .new_text_new {
            color: #066de7;
        }

        .ajax__calendar {
            position: relative;
            z-index: 9999;
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

        .custom {
            width: 150px !important;
        }

        .custommodalPopup {
            height: 300px !important;
        }

        .clscenter {
            text-align: center !important;
        }
    </style>
    <center>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="divqualhdrcollapse" runat="server" style="width: 97%;" class="panel">
                    <div id="Div6" runat="server" class="panel-heading" style="width: 96%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divqual','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               <%-- <span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>--%><%--commented by ajay sawant 25/4/2018--%>
                                <asp:Label ID="lblhdr" Text="DATE DEFINITION SETUP" style="font-size:19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="myImg" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                            </div>
                        </div>
                    </div>
                <div id="divqual" runat="server" class="panel-body">                       
                    <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblkpicode" Text="KPI Code" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblkpicode1" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlkpicode" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlkpicode_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDatetyp" Text="Date Type" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblDatetyp1" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDatetyp" runat="server" CssClass="select2-container form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDatetyp_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEffDtFrm" Text="Date Effective From" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblEffDtFrm_1" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TxtEffFrom" runat="server" CssClass="form-control" AutoPostBack="true" onmousedown="PopulateCalender()"
                                        onmouseup="PopulateCalender()" OnTextChanged="TxtEffFrom_TextChanged"
                                     placeholder="DD/MM/YYYY" Enabled="true" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEffDtTo" Text="Date Effective To" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblEffDtTo_1" Text="*" runat="server" ForeColor="red" />
                                <%--col-md-5--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TxtEffTo" runat="server" CssClass="form-control" onmousedown="PopulateCalender1()"
                                        onmouseup="PopulateCalender1()"
                                     placeholder="DD/MM/YYYY" Enabled="true" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample" OnClick="btnSave_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> SAVE
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnUpdate" Text="UPDATE" runat="server" CssClass="btn btn-sample"
                                    style="display:none;" OnClick="btnUpdate_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> UPDATE
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnsearch" runat="server" CssClass="btn btn-sample" OnClick="btnsearch_Click">
                                        <span class="glyphicon glyphicon-search" style="color: White;"></span> SEARCH
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCncl" style="background-color:#FFF;color:#f04e5e; width:85px !important"  Text="CANCEL" runat="server" CssClass="btn btn-sample"
                                    OnClientClick="doCancel();">
                                        <span class="glyphicon glyphicon-remove" style="color:#f04e5e"></span> CANCEL
                                </asp:LinkButton>
<%--                                <asp:LinkButton ID="LinkButton1" style="display:none;" Text="SET RULE" runat="server" CssClass="btn btn-sample"
                                    OnClick="LinkButton1_Click"> SET RULE
                                </asp:LinkButton>
                                <asp:Button ID="btnKPI" runat="server" style="display: none;" ClientIDMode="Static"
                                    OnClick="btnKPI_Click" />--%>
                                 
                                   <%--  <img id="Loading_gif" style="margin-top:5px;margin-right:100px" runat="server" 
                                    src="../Recruit/assets/img/animated_gif_loader.gif" />--%>
                                

                            </div>
                        </div>
                    <div id="div1" runat="server" style="width:98%; border: none; margin: 0px 0 !important;overflow-x:scroll"
                        class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgDateDef" runat="server" CssClass="footable" PageSize="100" AllowSorting="True"
                                    AllowPaging="true" AutoGenerateColumns="false">
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="KPI Code" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="KPI_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblkpicode" runat="server" Text='<%# Bind("KPI_CODE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="KPI Description" HeaderStyle-HorizontalAlign="Left" SortExpression="KPI_DESC_01">
                                            <ItemTemplate>
                                                <asp:Label ID="lblkpidesc" runat="server" Text='<%# Bind("KPI_DESC_01")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date Type" HeaderStyle-HorizontalAlign="Left" SortExpression="DESC01">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateType" runat="server" Text='<%# Bind("DESC01")%>'></asp:Label>
                                                <asp:Label ID="lblcyccod" runat="server" Visible="false" Text='<%# Bind("CYCLE_CODE")%>'></asp:Label>
                                                <asp:Label ID="lblmapcod" runat="server" Visible="false" Text='<%# Bind("MAPPED_CODE")%>'></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Visible="false" Text='<%# Bind("DateType")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date Eff From " HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="DateEffectiveFrom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateEffFrom" runat="server" Text='<%# Bind("DateEffectiveFrom")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" CssClass="clscenter" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date Eff To" HeaderStyle-HorizontalAlign="Left" SortExpression="DateEffectiveTo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateEffTo" runat="server" Text='<%# Bind("DateEffectiveTo")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" CssClass="clscenter" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Cycle Description" SortExpression="BUSI_DESC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcycldesc" runat="server" Text='<%# Bind("BUSI_DESC")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="left" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="dgDateDefedit" runat="server" OnClick="dgDateDefedit_Click" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="dgDateDefDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                OnClick="dgDateDefDelete_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <center>
<%--                        <div id="div7" visible="true" runat="server" class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <center>
                                                        <asp:Button ID="btnprevStdLOB" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" Onclick="btnprevStdLOB_Click"/>
                                                        <asp:TextBox runat="server" ID="txtStdLOBPage" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnextStdLOB" Text=">" CssClass="form-submit-button" runat="server"
                                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                            Enabled="false" Onclick="btnnextStdLOB_Click"/>
                                                    </center>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>--%>
                    </center>


                    </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <%--    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

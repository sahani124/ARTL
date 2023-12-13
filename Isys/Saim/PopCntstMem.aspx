<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopCntstMem.aspx.cs" Inherits="Application_ISys_Saim_PopCntst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <%--  <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
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
    <style type="text/css">
        .ajax__calendar
        {
            z-index: 100px;
        }
        .new_text_new
        {
            color: #066de7;
        }
        .form-submit-button
        {
            box-shadow: none !important;
        }
        .disablepage
        {
            display: none;
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
        .align
        {
            text-align: left;
        }
        .rowalign
        {
            margin-bottom: 15px;
        }
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }
    </style>
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

        function doOk() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (window.parent.document.getElementById("btncmp") != null) {
                ////alert("btncmp");
                window.parent.document.getElementById("btncmp").click();
                ////alert("btncmp2564654");
            }
            else {
                ///alert("no btncmp");
            }
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (window.parent.document.getElementById("btncmp") != null) {
                ////alert("btncmp");
                window.parent.document.getElementById("btncmp").click();
                ////alert("btncmp2564654");
            }
            else {
                ///alert("no btncmp");
            }
        }

        function ShowReqDtl1(divName, btnName) {
            debugger;
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
                ShowError(err.description);
            }
        }
    </script>
    <center>
        <div id="divcmphdrcollapse" runat="server" class="panel panel-success">
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <span class="" style="color: Orange;"></span>
                        <asp:Label ID="lblhdr" Text="CONTENSTANT DETAILS" runat="server" Style="padding-left: 5px;" />
                    </div>
                    <div class="col-sm-2">
                        <span id="myImg" class="glyphicon glyphicon-chevron-down" style="float: right;  
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" class="panel-body">
                <%--   <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblSlsChnl" Text="Sales Channel" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSlsChnl" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4" OnSelectedIndexChanged="ddlSlsChnl_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label1" Text="Sub Class" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlChnCls" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4" OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>--%>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row" id="divmem" runat="server" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblMemtype" Text="Member Code" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMemtype" runat="server" CssClass="form-control"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEmpName" Text="Member Name" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtEmpname" runat="server" CssClass="form-control"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--<div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label3" Text="Unit Rank" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlUnitRank" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>--%>
                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" OnClick="btnSearch_Click">
                                        <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnClear" runat="server" style="background-color:#FFF;color:#f04e5e; width:85px !important" CssClass="btn btn-sample" OnClick="btnCancel_Click">
                                        <span class="glyphicon glyphicon-erase" style="color: #f04e5e;"></span> Clear
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="panel-body">
                            <asp:GridView ID="dgCntst" runat="server" AutoGenerateColumns="false" Width="100%"
                                PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" OnPageIndexChanging="dgCntst_PageIndexChanging"
                                OnSorting="dgCntst_Sorting">
                                <RowStyle CssClass="GridViewRow"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("MemCode")%>' />
                                            <%--<asp:HiddenField ID="hdnSlsChnl" runat="server" Value='<%# Bind("BizSrc")%>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Name" SortExpression="LegalName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubCls" runat="server" Text='<%# Bind("LegalName")%>'></asp:Label>
                                            <%--<asp:HiddenField ID="hdnSubCls" runat="server" Value='<%# Bind("ChnClsVal")%>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Type" SortExpression="MemTypeDesc01">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemTypeDesc01")%>'></asp:Label>
                                            <%--<asp:HiddenField ID="hdnMemType" runat="server" Value='<%# Bind("MemTypeVal")%>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Unit Rank" SortExpression="UnitRank">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUntRnk" runat="server" Text='<%# Bind("UnitRank")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnUntRnk" runat="server" Value='<%# Bind("UnitRank")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChkSelect_CheckedChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div id="divPage" visible="false" runat="server" class="pagination">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div id="tblOK" runat="server" visible="false" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnOK" runat="server" CssClass="btn btn-sample" OnClick="btnOK_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                </asp:LinkButton>
                                &nbsp;  
                                <asp:LinkButton ID="btnCncl" runat="server" CssClass="btn btn-sample"
                                    OnClientClick="doCancel();return false;">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--<div id="Table1" runat="server" class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                    </div>
                </div>--%>
            </div>
        </div>
    </center>
</asp:Content>

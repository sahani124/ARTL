<%@ Page StylesheetTheme="Admin" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" Inherits="Application_Admin_SysModule"
    Title="System Module Setup" CodeFile="SysModule.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />
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
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <script type="text/javascript" language="javascript">        
        function doBasicSearch() {
            __doPostBack('ctl00$ContentPlaceHolder1_txtSearchString', '');
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

    </script>
    <style type="text/css">
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

        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #F04E5E;
            color: White;
            white-space: nowrap
        }
    </style>
    <div id="divfinhdrcollapse" runat="server" style="width: 95%;" class="panel">
        <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0">
            <asp:View ID="v0" runat="server">

                <%--<table cellpadding="3" cellspacing="1" border="0"  style="width: 1300px">
     <tr>   
        <td colspan="4">
            <table cellpadding="0" cellspacing="0" border="0"  style="width: 100%">
            <tr>
            <td class="titlebar">
                <asp:Label ID="lblTitle" runat="server" Text="" CssClass="formtitle"></asp:Label>
            </td>
            <td align="right" class="titlebar">
                <asp:Label ID="lblModVer" runat="server" Text="" ></asp:Label>
            </td>
            </tr>
            </table> 
        </td>
    </tr>
    </table> --%>
                <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divfinhdr','myImg');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">

                            <asp:Label ID="lblTitle" runat="server" Style="font-size: 19px;" />
                        </div>
                        <div class="col-sm-2">
                            <asp:Label ID="lblModVer" Visible="false" runat="server" Style="font-size: 19px;" />
                            <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearchAdv">

                    <div id="divSearch" runat="server" style="display: block;" class="panel-body">
                        <div class="row" style="margin-left: 2%; margin-right: 2%">
                            <div class="col-sm-4">
                                <asp:Label ID="lblSearch" runat="server" Text="" Width="38px" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblContains" runat="server" Text="" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblShowRecords" runat="server" Text="" CssClass="ontrol-label"></asp:Label>
                            </div>
                        </div>

                    </div>
                    <%-- <tr>
            <td>
                <asp:Label ID="lblSearch" runat="server" Text="" Width="38px" CssClass="subtitle"></asp:Label></td>
            <td>
                <asp:Label ID="lblContains" runat="server" Text="" CssClass="subtitle"></asp:Label></td>
            <td style="width: 90px">
                <asp:Label ID="lblShowRecords" runat="server" Text="" CssClass="subtitle"/></td>
            <td style="width: 238px">
                &nbsp;
            </td>
        </tr>--%>
                    <%--  <table style="width: 600px">
        <tr>--%>
                    <div id="div1" runat="server" style="display: block;" class="panel-body">
                        <%--  <td class="formcontent">--%>
                        <div class="row">
                            <div class="col-sm-4" style="text-align: center; color: #034ea2; top: 0px; left: 0px;">
                                <asp:DropDownList ID="ddlSearchCol" runat="server" Width="120px"
                                    OnSelectedIndexChanged="ddlSearchCol_SelectedIndexChanged" CssClass="form-control" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                            <%--</td>--%>
                            <div class="col-sm-4" style="text-align: center; color: #034ea2; top: 0px; left: 0px;">
                                <asp:TextBox ID="txtSearchString" runat="server" Width="170px" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-4" style="text-align: center; color: #034ea2; top: 0px; left: 0px;">
                                <asp:DropDownList ID="cboShowRecord" runat="server" CssClass="form-control" OnSelectedIndexChanged="cboShowRecord_OnSelectedIndexChanged"
                                    Width="80px" AutoPostBack="True">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="40">40</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--  </td>--%>

                        <%-- <asp:Button ID="btnSearchAdv" CssClass ="standardbutton" Text="Search" runat ="server" OnClick="btnSearchAdv_Click" 
                   ValidationGroup="checkSearch"/>
                <asp:Button ID="btnHClear" CssClass="standardbutton" OnClientClick="aspnetForm.reset();return false;" runat="server" />            
                        --%>

                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSearchAdv" runat="server" CssClass="btn btn-sample" OnClick="btnSearchAdv_Click"
                                    ValidationGroup="checkSearch">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Search
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnHClear" runat="server" CssClass="btn btn-sample" OnClientClick="aspnetForm.reset();return false;">
                                <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Close
                                </asp:LinkButton>
                            </div>
                        </div>

                        <asp:SqlDataSource ID="sdsSearchCol" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"
                            SelectCommand="select 'Module ID' SearchCol, 1 Seq&#13;&#10;union select 'Module Name' SearchCol, 2 Seq&#13;&#10;union select 'Module Level' SearchCol, 3 Seq&#13;&#10;union select 'Module Status' SearchCol, 4 Seq&#13;&#10;union select 'Parent Module ID' SearchCol, 5 Seq&#13;&#10;order by Seq"></asp:SqlDataSource>
                        <%--       
        </tr>
    </table> --%>
                    </div>
                </asp:Panel>

                <%-- <table width="1740px" class="tableborder" >--%>
                <%--<tr>
            <td align ="left" class="titlebar">
                <asp:Label ID="lblSearchResult"  Text="" runat="server"></asp:Label>
            </td>
            <td align="right" class="titlebar"> 
                <asp:UpdatePanel ID="UpdatePanel" runat="server"> 
                <ContentTemplate>
                    <asp:Label ID="lblPageIndex" runat="server"  Text="1"></asp:Label>
                </ContentTemplate> 
                </asp:UpdatePanel>           
             </td>
        </tr>--%>
                <div id="div2" runat="server" style="width: 100%;" class="panel">
                    <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divfinhdr','myImg1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">

                                <asp:Label ID="lblSearchResult" Text="" runat="server" Style="font-size: 19px;" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Label ID="lblPageIndex" Text="" Visible="false" runat="server" Style="font-size: 19px;" />
                                <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divfinhdr" runat="server" style="width: 120%;" class="panel-body">
                        <%--  <tr>
            <td colspan="3">--%>
                        <asp:UpdatePanel ID="upd1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound"
                                    AutoGenerateColumns="False" DataKeyNames="ModuleId" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                                    CellPadding="1" GridLines="Vertical" Width="100%" OnPreRender="GridView1_PreRender" CssClass="footable">
                                    <RowStyle CssClass="GridViewRowNEW"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>

                                        <asp:TemplateField HeaderText="Module ID" SortExpression="ModuleId" ItemStyle-Width="100px">
                                            <EditItemTemplate>
                                                <asp:Label ID="txtModuleId2" runat="server" Text='<%# Bind("ModuleId") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelModuleId2" runat="server" Text='<%# Bind("ModuleId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Module Code" SortExpression="ModuleCode" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                                            <EditItemTemplate>
                                                <asp:Label ID="txtModuleCode2" runat="server" Text='<%# Bind("ModuleCode") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelModuleCode2" runat="server" Text='<%# Bind("ModuleCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Parent Module ID" SortExpression="ParentModuleID" ItemStyle-Width="80px">
                                            <EditItemTemplate>
                                                <asp:Label ID="txtParentID2" runat="server" Text='<%# Bind("ParentModuleID") %>' CssClass="T1"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelParentID2" runat="server" Text='<%# Bind("ParentModuleID") %>' CssClass="T1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Root Module ID" SortExpression="RootModuleID" ItemStyle-Width="120px">
                                            <EditItemTemplate>
                                                <asp:Label ID="txtRootModuleID2" runat="server" Text='<%# Bind("RootModuleID") %>' CssClass="T1"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelRootModuleID2" runat="server" Text='<%# Bind("RootModuleID") %>' CssClass="T1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Module Name" SortExpression="ModuleName" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                            <EditItemTemplate>
                                                <asp:Label ID="txtModuleName2" runat="server" Text='<%# Bind("ModuleName") %>' CssClass="T1"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelModuleName2_0" runat="server" Text='<%# Bind("ModuleName") %>' CssClass="T1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Module Name1" SortExpression="ModuleName01" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtModuleName2_1" runat="server" Text='<%# Bind("ModuleName01") %>' CssClass="form-control" MaxLength="80">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVModuleName2_1" runat="server" ControlToValidate="txtModuleName2_1"
                                                    Display="Dynamic" ErrorMessage="" Font-Size="8pt" CssClass="msgerror">
                                                </asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelModuleName2_1" runat="server" Text='<%# Bind("ModuleName01") %>' CssClass="T1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Module Name2" SortExpression="ModuleName02" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtModuleName2_2" runat="server" Text='<%# Bind("ModuleName02") %>' CssClass="form-control" MaxLength="80">
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelModuleName2_2" runat="server" Text='<%# Bind("ModuleName02") %>' CssClass="T1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Module Name3" SortExpression="ModuleName03" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtModuleName2_3" runat="server" Text='<%# Bind("ModuleName03") %>' CssClass="form-control" MaxLength="80">
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelModuleName2_3" runat="server" Text='<%# Bind("ModuleName03") %>' CssClass="T1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Module Desc1" SortExpression="ModuleDesc01" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtModuleDesc2_1" runat="server" Text='<%# Bind("ModuleDesc01") %>' CssClass="form-control" MaxLength="255">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVModuleDesc2_1" runat="server" ControlToValidate="txtModuleDesc2_1"
                                                    Display="Dynamic" ErrorMessage="" Font-Size="8pt" CssClass="msgerror">
                                                </asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelModuleDesc2_1" runat="server" Text='<%# Bind("ModuleDesc01") %>' CssClass="T1">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Module Desc2" SortExpression="ModuleDesc02" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtModuleDesc2_2" runat="server" Text='<%# Bind("ModuleDesc02") %>' CssClass="form-control" MaxLength="255">
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelModuleDesc2_2" runat="server" Text='<%# Bind("ModuleDesc02") %>' CssClass="T1">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Module Desc3" SortExpression="ModuleDesc03" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtModuleDesc2_3" runat="server" Text='<%# Bind("ModuleDesc03") %>' CssClass="form-control" MaxLength="255">
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelModuleDesc2_3" runat="server" Text='<%# Bind("ModuleDesc03") %>' CssClass="T1">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Module Sequence" SortExpression="ModuleSequence" ItemStyle-Width="50px">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtModuleSequence2" runat="server" Text='<%# Bind("ModuleSequence") %>' CssClass="form-control" MaxLength="2147483647">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVModuleSequence2" runat="server" ControlToValidate="txtModuleSequence2"
                                                    Display="Dynamic" ErrorMessage="" Font-Size="8pt" CssClass="msgerror">
                                                </asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RVtxtModuleSequence2" Type="Integer" ControlToValidate="txtModuleSequence2" runat="server"
                                                    Display="Dynamic" ErrorMessage="" Font-Size="8pt" CssClass="msgerror" MinimumValue="1" MaximumValue="2147483647">
                                                </asp:RangeValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelModuleSequence2" runat="server" Text='<%# Bind("ModuleSequence") %>' CssClass="T1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Module Status" SortExpression="ModuleStatus" ItemStyle-Width="50px">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtModuleStatus2" Text='<%#Bind("ModuleStatus")%>' runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVModuleStatus2" runat="server" ControlToValidate="txtModuleStatus2"
                                                    Display="Dynamic" ErrorMessage="" Font-Size="8pt" CssClass="msgerror">
                                                </asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RVModuleStatus2" ControlToValidate="txtModuleStatus2" runat="server" ErrorMessage=""
                                                    Display="Dynamic" Font-Size="8pt" CssClass="msgerror" Type="Integer" MinimumValue="0" MaximumValue="32767">
                                                </asp:RangeValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="ModuleStatus2" runat="server" Text='<%# Bind("ModuleStatus") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Module Level" SortExpression="ModuleLevel" ItemStyle-Width="50px">
                                            <EditItemTemplate>
                                                <asp:Label ID="txtModuleLevel2" runat="server" Text='<%# Bind("ModuleLevel") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="ModuleLevel2" runat="server" Text='<%# Bind("ModuleLevel") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Target Name" SortExpression="TargetName" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px">
                                            <EditItemTemplate>
                                                <asp:Label ID="txtTargetName2" runat="server" Text='<%# Bind("TargetName") %>' CssClass="T1"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelTargetName2" runat="server" Text='<%# Bind("TargetName") %>' CssClass="T1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Carrier Code" SortExpression="CarrierCode" ItemStyle-Width="50px">
                                            <EditItemTemplate>
                                                <asp:Label ID="txtCarrierCode2" runat="server" Text='<%# Bind("CarrierCode") %>' CssClass="T1"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelCarrierCode2" runat="server" Text='<%# Bind("CarrierCode") %>' CssClass="T1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="100px">
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="LnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                                    Text="[Update]"></asp:LinkButton>
                                                <asp:LinkButton ID="LnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                                    Text="[Cancel]"></asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" ToolTip="Edit" CssClass="T1">[Edit]</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="LinkButton2" Visible="false" runat="server" CommandName="Delete" ToolTip="Delete" CssClass="T1" OnClientClick="return confirm('Are you sure you want to delete this module?');">[Delete]</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>


                                    <EmptyDataTemplate>
                                        <center>
                        <asp:Label ID="lblNoRecord" runat="server" Text="No Record Found" Cssclass="msgerror"></asp:Label>
                    </center>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cboShowRecord" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                <asp:AsyncPostBackTrigger ControlID="txtSearchString" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                                <asp:AsyncPostBackTrigger ControlID="ddlSearchCol" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                <asp:AsyncPostBackTrigger ControlID="btnSearchAdv" EventName="Click"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="pagination" style="padding-left: 40%;">
                            <center>
                        <table>
                            <tr>
                                <td style="white-space: nowrap;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnprevfin" Text="<" CssClass="form-submit-button" 
                                                runat="server" Width="40px"
                                                Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" 
                                                onclick="btnprevfin_Click"/>
                                            <asp:TextBox runat="server" ID="txtPageFin" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                            <asp:Button ID="btnnextfin" Text=">" CssClass="form-submit-button" 
                                                runat="server" Style="border-style: solid;
                                                border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                float: left; margin: 0; height: 30px;" Width="40px" 
                                                onclick="btnnextfin_Click"/>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </center>
                        </div>
                    </div>
                    <%--</td></tr>--%>

                    <%--<tr><td colspan="3" align="center">
                            <asp:Button ID="linkAddNew" runat="server" OnClick="linkAddNew_Click" CssClass="standardbutton" Text="Add" Width="50px" />
                        </td></tr>--%>

                    <div class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="linkAddNew" runat="server" CssClass="btn btn-sample" OnClick="linkAddNew_Click">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Add
                            </asp:LinkButton>

                        </div>
                    </div>

                </div>
                <%-- </table>--%>


                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Admin.AdminDAL"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetSysModule" UpdateMethod="UpdateSystemModule"
                    DeleteMethod="DeleteSysModule" InsertMethod="InsertSysModule">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="v0$ddlSearchCol" Name="SearchCol" Type="String" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="v0$txtSearchString" Name="SearchString" Type="String" PropertyName="text" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ModuleId" Type="String" />
                        <asp:Parameter Name="Modulecode" Type="String" />
                        <asp:Parameter Name="ParentModuleID" Type="String" />
                        <asp:Parameter Name="RootModuleID" Type="String" />
                        <asp:Parameter Name="ModuleName" Type="String" />
                        <asp:Parameter Name="ModuleName01" Type="String" />
                        <asp:Parameter Name="ModuleName02" Type="String" />
                        <asp:Parameter Name="ModuleName03" Type="String" />
                        <asp:Parameter Name="ModuleDesc01" Type="String" />
                        <asp:Parameter Name="ModuleDesc02" Type="String" />
                        <asp:Parameter Name="ModuleDesc03" Type="String" />
                        <asp:Parameter Name="ModuleSequence" Type="String" />
                        <asp:Parameter Name="ModuleStatus" Type="String" />
                        <asp:Parameter Name="ModuleLevel" Type="String" />
                        <asp:Parameter Name="TargetName" Type="String" />
                        <asp:Parameter Name="CarrierCode" Type="String" />
                        <asp:Parameter Name="original_ModuleId" Type="String" />
                    </UpdateParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="original_ModuleId" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ModuleID" Type="String" />
                        <asp:Parameter Name="ModuleCode" Type="String" />
                        <asp:ControlParameter ControlID="v2$DetailsView1$cboParentID" Name="ParentModuleID" Type="String" PropertyName="SelectedValue" />
                        <asp:Parameter Name="RootModuleID" Type="String" />
                        <asp:Parameter Name="ModuleName" Type="String" />
                        <asp:Parameter Name="ModuleName01" Type="String" />
                        <asp:Parameter Name="ModuleName02" Type="String" />
                        <asp:Parameter Name="ModuleName03" Type="String" />
                        <asp:Parameter Name="ModuleDesc01" Type="String" />
                        <asp:Parameter Name="ModuleDesc02" Type="String" />
                        <asp:Parameter Name="ModuleDesc03" Type="String" />
                        <asp:Parameter Name="ModuleSequence" Type="String" />
                        <asp:ControlParameter ControlID="v2$DetailsView1$cboModuleStatus" Name="ModuleStatus" Type="String" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="v2$DetailsView1$cboModuleLevel" Name="ModuleLevel" Type="String" PropertyName="SelectedValue" />
                        <asp:Parameter Name="TargetName" Type="String" />
                        <asp:Parameter Name="CarrierCode" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </asp:View>

            <asp:View ID="v2" runat="server">
                <div style="text-align: center;">

                    <table cellpadding="3" cellspacing="1" border="0" style="width: 100%">
                        <tr>
                            <td colspan="4">
                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                    <tr>
                                        <td class="titlebar" align="left">
                                            <asp:Label ID="Label6" runat="server" Text="New Module" CssClass="formtitle"></asp:Label>
                                        </td>
                                        <td align="right" class="titlebar">
                                            <asp:Label ID="Label7" runat="server" Text="Admin/UserGroup New Module ver1.0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:DetailsView ID="DetailsView1" runat="server" DataKeyNames="ModuleID"
                        DataSourceID="ObjectDataSource1" DefaultMode="Insert" OnItemCommand="DetailsView1_ItemCommand"
                        OnItemInserted="DetailsView1_ItemInserted" AutoGenerateRows="False" Width="100%" OnPreRender="DetailsView1_PreRender" CssClass="footable">

                        <Fields>

                            <asp:TemplateField HeaderText="Module ID" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtModuleID" runat="server" Text='<%# Bind("ModuleID") %>' CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVModuleID" runat="server" ControlToValidate="DVtxtModuleID"
                                        ErrorMessage="" Font-Size="8pt" CssClass="msgerror" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RVModuleID" Type="Integer" ControlToValidate="DVtxtModuleID" runat="server" ErrorMessage=""
                                        Font-Size="8pt" CssClass="msgerror" Display="Dynamic" MinimumValue="1" MaximumValue="2147483647">
                                    </asp:RangeValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleID" runat="server" Text='<%# Bind("ModuleID") %>' CssClass="T1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Code" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtModuleCode" runat="server" Text='<%# Bind("ModuleCode") %>' CssClass="form-control" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVModuleCode" runat="server" ControlToValidate="DVtxtModuleCode"
                                        ErrorMessage="" Font-Size="8pt" CssClass="msgerror" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleCode" runat="server" Text='<%# Bind("ModuleCode") %>' CssClass="T1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Parent Module ID" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="cboParentID" runat="server" DataSourceID="sqlParentID" CssClass="form-control"
                                        DataTextField="Description" DataValueField="ModuleID">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelParentID" runat="server" Text='<%# Bind("ParentModuleID") %>' CssClass="T1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Root Module ID" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtRootModuleID" runat="server" Text='<%# Bind("RootModuleID") %>' CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVRootModuleID" runat="server" ControlToValidate="DVtxtRootModuleID"
                                        ErrorMessage="" Font-Size="8pt" CssClass="msgerror" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RVRootModuleID" Type="Integer" ControlToValidate="DVtxtRootModuleID" runat="server" ErrorMessage=""
                                        Font-Size="8pt" CssClass="msgerror" Display="Dynamic" MinimumValue="1" MaximumValue="2147483647">
                                    </asp:RangeValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelRootModuleID" runat="server" Text='<%# Bind("RootModuleID") %>' CssClass="T1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Name" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtModuleName" runat="server" Text='<%# Bind("ModuleName") %>' CssClass="form-control" MaxLength="80">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVModuleName" runat="server" ControlToValidate="DVtxtModuleName"
                                        ErrorMessage="" Font-Size="8pt" CssClass="msgerror" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleName" runat="server" Text='<%# Bind("ModuleName") %>' CssClass="control-label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Name1" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtModuleName1" runat="server" Text='<%# Bind("ModuleName01") %>' CssClass="form-control" MaxLength="80">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVModuleName1" runat="server" ControlToValidate="DVtxtModuleName1"
                                        ErrorMessage="" Font-Size="8pt" CssClass="msgerror" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleName1" runat="server" Text='<%# Bind("ModuleName01") %>' CssClass="control-label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Name2" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtModuleName2" runat="server" Text='<%# Bind("ModuleName02") %>' CssClass="form-control" MaxLength="80">
                                    </asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleName2" runat="server" Text='<%# Bind("ModuleName02") %>' CssClass="control-label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Name3" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtModuleName3" runat="server" Text='<%# Bind("ModuleName03") %>' CssClass="form-control" MaxLength="80">
                                    </asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleName3" runat="server" Text='<%# Bind("ModuleName03") %>' CssClass="T1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Desc1" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtModuleDesc1" runat="server" Text='<%# Bind("ModuleDesc01") %>' CssClass="form-control" MaxLength="1000">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVModuleDesc1" runat="server" ControlToValidate="DVtxtModuleDesc1"
                                        ErrorMessage="" Font-Size="8pt" CssClass="msgerror" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleDesc1" runat="server" Text='<%# Bind("ModuleDesc01") %>' CssClass="control-label">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Desc2" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtModuleDesc2" runat="server" Text='<%# Bind("ModuleDesc02") %>' CssClass="form-control" MaxLength="1000">
                                    </asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleDesc2" runat="server" Text='<%# Bind("ModuleDesc02") %>' CssClass="control-label">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Desc3" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtModuleDesc3" runat="server" Text='<%# Bind("ModuleDesc03") %>' CssClass="form-control" MaxLength="1000">
                                    </asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleDesc3" runat="server" Text='<%# Bind("ModuleDesc03") %>' CssClass="control-label">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Sequence" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtModuleSequence" runat="server" Text='<%# Bind("ModuleSequence") %>' CssClass="form-control" MaxLength="2147483647">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVModuleSequence" runat="server" ControlToValidate="DVtxtModuleSequence"
                                        ErrorMessage="" Font-Size="8pt" CssClass="msgerror" Display="Dynamic">
                                    </asp:RequiredFieldValidator>

                                    <asp:RangeValidator ID="RVModuleSequence" Type="Integer" ControlToValidate="DVtxtModuleSequence" runat="server"
                                        ErrorMessage="" Font-Size="8pt" CssClass="msgerror" Display="Dynamic" MinimumValue="1" MaximumValue="2147483647">
                                    </asp:RangeValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleSequence" runat="server" Text='<%# Bind("ModuleSequence") %>' CssClass="control-label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Status" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="cboModuleStatus" runat="server" DataSourceID="sqlModuleStatus" DataTextField="ModuleStatus"
                                        DataValueField="ModuleStatus" CssClass="form-control">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleStatus" runat="server" Text='<%# Bind("ModuleStatus") %>' CssClass="control-label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Level" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="cboModuleLevel" runat="server" DataSourceID="sqlModuleLevel" DataTextField="ModuleLevel"
                                        DataValueField="ModuleLevel" CssClass="form-control">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelModuleLevel" runat="server" Text='<%# Bind("ModuleLevel") %>' CssClass="T1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Target Name" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtTargetName" runat="server" Text='<%# Bind("TargetName") %>' CssClass="form-control" MaxLength="255">
                                    </asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelTargetName" runat="server" Text='<%# Bind("TargetName") %>' CssClass="control-label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Carrier Code" HeaderStyle-CssClass="subtitle">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="DVtxtCarrierCode" runat="server" Text='<%# Bind("CarrierCode") %>' CssClass="form-control" MaxLength="2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVCarrierCode" runat="server" ControlToValidate="DVtxtCarrierCode"
                                        ErrorMessage="" Font-Size="8pt" CssClass="msgerror" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelCarrierCode" runat="server" Text='<%# Bind("CarrierCode") %>' CssClass="control-label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:CommandField ShowInsertButton="True" ControlStyle-CssClass="btn btn-sample" ButtonType="Button" ControlStyle-Width="70px" />
                        </Fields>
                    </asp:DetailsView>
                </div>
                <asp:SqlDataSource ID="sqlParentID" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"
                    SelectCommand="Select '--Select--' as Description,null as ModuleID  
                               union SELECT DISTINCT convert(varchar,[ModuleID]) as Description,
                               ModuleID FROM [iModule] WHERE ([ModuleID] IS NOT NULL) order by ModuleID"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlModuleStatus" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"
                    SelectCommand="SELECT DISTINCT [ModuleStatus] FROM [iModule]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlModuleLevel" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"
                    SelectCommand="SELECT DISTINCT [ModuleLevel] FROM [iModule]"></asp:SqlDataSource>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

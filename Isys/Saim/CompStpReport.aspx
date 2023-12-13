<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CompStpReport.aspx.cs" Inherits="Application_ISys_Saim_CompStpReport" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <%--<script src="../../../assets/css/plugins.css" type="text/javascript"></script>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .dataTable {  
  width: 100% !important;
  clear: both;
  margin-top: 5px;
  border:none;
}

.dataTables_filter label {
  line-height: 32px ;
}

.dataTable .row-details {  
  margin-top: 3px;
  display: inline-block;
  cursor: pointer;
  width: 14px;
  height: 14px;
}

.dataTable .row-details.row-details-close {
  background: url("../img/datatable-row-openclose.png") no-repeat 0 0;
}

.dataTable .row-details.row-details-open {  
  background: url("../img/datatable-row-openclose.png") no-repeat 0 -23px ;
}

.dataTable .details {
  background-color: #eee ;
}

.dataTable .details td,
.dataTable .details th {
  padding: 4px;
  background: none ;
  border:0;
}

.dataTable .details tr:hover td,
.dataTable .details tr:hover th {
  background: none ;
}

.dataTable .details tr:nth-child(odd) td,
.dataTable .details tr:nth-child(odd) th {
  background-color: #eee ;
}

.dataTable .details tr:nth-child(even) td,
.dataTable .details tr:nth-child(even) th {
  background-color: #eee ;
}

.dataTable > thead > tr > th.sorting,
.dataTable > thead > tr > th.sorting_asc,
.dataTable > thead > tr > th.sorting_desc {
   padding-right: 18px;
}

.dataTable .table-checkbox {
  width: 8px !important;
}

@media (max-width: 768px) {  
  .dataTables_wrapper .dataTables_length .form-control,
  .dataTables_wrapper .dataTables_filter .form-control {
    display: inline-block;
  }

  .dataTables_wrapper .dataTables_info {
    top: 17px;
  }

  .dataTables_wrapper .dataTables_paginate {
    margin-top: -15px;
  }
}

@media (max-width: 480px) {  
  .dataTables_wrapper .dataTables_filter .form-control {
    width: 175px !important;
  }

  .dataTables_wrapper .dataTables_paginate {
    float: left;
    margin-top: 20px;
  }
}

.dataTables_processing {
  position: fixed;
  top: 50%;
  left: 50%;
  min-width: 125px;
  margin-left: 0;
  padding: 7px;
  text-align: center;
  color: #333;
  font-size: 13px;
  border: 1px solid #ddd;
  background-color: #eee;  
  vertical-align: middle;
  -webkit-box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
     -moz-box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
          box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);  
}

.dataTables_processing span {
  line-height:15px;
  vertical-align: middle;
}

.dataTables_empty {
  text-align: center; 
}

        .ajax__calendar
        {
            z-index: 100px;
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
        
        .transbox
        {
            width: 400px;
            height: 180px;
            margin: 30px 50px;
            background-color: #ffffff;
            border: 1px solid black;
            opacity: 0.6;
            filter: alpha(opacity=60); /* For IE8 and earlier */
            z-index: inherit;
        }
        
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
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

        function funcall() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
        }

    </script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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
    <center>
        <div id="divcmphdrcollapse" runat="server" style="width: 90%;" class="divBorder1">
            <table class="formtablehdr" style="width: 100%;">
                <tr style="height: 30px;">
                    <td style="padding-left: 5px;">
                        <i class="fa fa-search"></i>
                        <asp:Label ID="lblhdr" Text="Compensation Rule Setup" runat="server" Style="padding-left: 5px;" />
                    </td>
                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                        <img id="myImg" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divcmphdr','myImg','#myImg');" />
                    </td>
                </tr>
            </table>
            <div id="divcmphdr" runat="server" style="width: 100%;">
                <table style="width: 100%;">
                    <tr>
                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                            <asp:Label ID="lblCompCode" Text="Compensation Code" runat="server" CssClass="control-label" />
                            <asp:Label ID="Label1" Text="*" runat="server" Style="color: Red" />
                        </td>
                        <td style="width: 30%;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtCompCode" runat="server" CssClass="form-control" TabIndex="1"
                                        placeholder="Compensation Code" /></ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                            <asp:Label ID="lblCompDesc1" Text="Compensation Description" runat="server" CssClass="control-label" />
                            <asp:Label ID="Label3" Text="*" runat="server" Style="color: Red" />
                        </td>
                        <td style="width: 30%;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtCompDesc1" runat="server" CssClass="form-control" TabIndex="2"
                                        placeholder="Compensation Description" /></ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                            <asp:Label ID="lblCompTyp" Text="Compensation Type" runat="server" CssClass="control-label" />
                        </td>
                        <td style="width: 30%;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCompType" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5"
                                        TabIndex="4">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                            <asp:Label ID="lblCompStat" Text="Status" runat="server" CssClass="control-label" />
                        </td>
                        <td style="width: 30%;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5"
                                        TabIndex="4" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <table class="form-actions fluid" style="width: 100%;">
                    <tr>
                        <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnSearch" Text="SEARCH" runat="server" Width="100px" CssClass="btn blue"
                                        OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnClear" Text="CLEAR" runat="server" Width="100px" CssClass="btn default"
                                        OnClick="btnClear_Click" Visible="false" />
                                    <asp:Button ID="btnCancel" Text="CANCEL" runat="server" Width="100px" CssClass="btn default"
                                        OnClick="btnCancel_Click" /></ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <br />  
        <br />
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="divcmpsrchhdrcollapse" visible="false" runat="server" style="width: 90%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-search"></i>
                                <asp:Label ID="lblCmpSrch" Text="Compensation Rule Search Results" runat="server"
                                    Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right;">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate>
                                        <img id="Img2" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                            alt="" onclick="funcall();" />
                                        <img id="Img1" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;"
                                            alt="" onclick="ShowReqDtl('divkpisrch','Img1','#Img1');" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <div id="divkpisrch" runat="server" style="width: 100%;padding: 10px;">
                        <div id="Div1" runat="server" style="width: 100%; border:none;margin: 0px 0 !important;" class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgCmp" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                        OnRowDataBound="dgCmp_RowDataBound" OnSorting="dgCmp_Sorting" DataKeyNames="CMPNSTN_CODE">
                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                        <RowStyle />
                                        <PagerStyle CssClass="disablepage" />
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                    <div id="divChild" runat="server" style="display: none; margin: 0px 0 !important;"
                                                        class="table-scrollable">
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="dgCntst" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="dataTable details"
                                                                    OnRowDataBound="dgCntst_RowDataBound" OnSorting="dgCntst_Sorting" DataKeyNames="CNTSTNT_CODE">
                                                                    <HeaderStyle ForeColor="Black" />
                                                                    <RowStyle />
                                                                    <PagerStyle CssClass="disablepage" />
                                                                    <EmptyDataTemplate>
                                                                        <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                                            runat="server" />
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Contestant Code" SortExpression="CNTSTNT_CODE" HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'
                                                                                    OnClick="lnkCnstCode_Click" ></asp:LinkButton>
                                                                                <asp:HiddenField ID="hdnCnstCode" runat="server" Value='<%# Bind("CNTSTNT_CODE")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Compensation Description" SortExpression="CMPNSTN_CODE"
                                                                            HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCmpDesc" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>' />
                                                                                <asp:HiddenField ID="lblCmpDsc" runat="server" Value='<%# Bind("CMPNSTN_CODEVAL")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sales Channel" SortExpression="CHN" HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("CHN")%>' />
                                                                                <asp:HiddenField ID="hdnSlsChnl" runat="server" Value='<%# Bind("BizSrc")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sub Class" SortExpression="CHNCLS" HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSubCls" runat="server" Text='<%# Bind("CHNCLS")%>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnSubCls" runat="server" Value='<%# Bind("ChnClsVal")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Member Type" SortExpression="MEMTYPE" HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MEMTYPE")%>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnMemType" runat="server" Value='<%# Bind("MemTypeVal")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Unit Rank" SortExpression="UnitRank" HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUntRnk" runat="server" Text='<%# Bind("UnitRank")%>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnUntRnk" runat="server" Value='<%# Bind("UnitRank")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Action" HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDelCntst" runat="server" Text="Delete" Enabled="false"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comp Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="CMPNSTN_CODE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkCmpCode" Text='<%# Bind("CMPNSTN_CODE")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comp Description" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCmpDesc" Text='<%# Bind("CMPNSTN_DESC01") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="CMPNSTN_DESC02" HeaderText="Comp Description" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" SortExpression="CMPNSTN_DESC02">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="ACC_CYCLE" HeaderText="Accumulation Cycle" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="ACC_CYCLE" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ACC_YEAR" HeaderText="Accumulation Year" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="ACC_YEAR" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STATUS" HeaderText="Status" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="STATUS" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EFF_FROM" HeaderText="Eff. From" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="80px" SortExpression="EFF_FROM" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EFF_TO" HeaderText="Eff. To" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="EFF_TO" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkViewRpt" runat="server" Text="View Report"  OnClick="lnkCmpCode_Click" ></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
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
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 35px; border-style: solid;
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
                        <table runat="server" visible="false" class="form-actions fluid" style="width: 100%;">
                            <tr>
                                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                    <asp:Button ID="btnAddNew" Text="ADD NEW" runat="server" Width="100px" CssClass="btn blue"
                                        OnClick="btnAddNew_Click" />
                                    <asp:Button ID="btnCncl" Text="CANCEL" runat="server" Width="100px" CssClass="btn default"
                                        OnClick="btnCncl_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>

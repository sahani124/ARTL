<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="ViewReport.aspx.cs" Inherits="Application_ISys_Saim_ViewReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
            /*border-top: 0;*/
        }

        .disablepage {
            display: none;
        }

        .box {
            background-color: #efefef;
            padding-left: 5px;
        }

        .dataTable {
            width: 100% !important;
            clear: both;
            margin-top: 5px;
        }

        .dataTables_filter label {
            line-height: 32px;
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
                background: url("../img/datatable-row-openclose.png") no-repeat 0 -23px;
            }

        .dataTable .details {
            background-color: #eee;
        }

            .dataTable .details td, .dataTable .details th {
                padding: 4px;
                background: none;
                border: 0;
                border: 1px solid #ddd;
            }

            .dataTable .details tr:hover td, .dataTable .details tr:hover th {
                background: none;
            }

            .dataTable .details tr:nth-child(odd) td, .dataTable .details tr:nth-child(odd) th {
                background-color: #eee;
            }

            .dataTable .details tr:nth-child(even) td, .dataTable .details tr:nth-child(even) th {
                background-color: #eee;
            }

        .dataTable > thead > tr > th.sorting, .dataTable > thead > tr > th.sorting_asc, .dataTable > thead > tr > th.sorting_desc {
            padding-right: 18px;
        }

        .dataTable .table-checkbox {
            width: 8px !important;
        }

        @media (max-width: 768px) {
            .dataTables_wrapper .dataTables_length .form-control, .dataTables_wrapper .dataTables_filter .form-control {
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
                line-height: 15px;
                vertical-align: middle;
            }

        .dataTables_empty {
            text-align: center;
        }
    </style>
    <center>
 <%--       <div id="divcmphdrcollapse" runat="server" style="width: 90%;" class="divBorder1">
            <table class="formtablehdr" style="width: 100%;">
                <tr style="height: 30px;">
                    <td style="padding-left: 5px;">
                        <i class="fa fa-list"></i>
                        <asp:Label ID="lblhdr" Text="Compensation Details Search" runat="server" Style="padding-left: 5px;" />
                    </td>
                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                       
                        <img id="myImg" src="../../../assets/img/portlet-collapse-icon-white.png" alt=""
                            onclick="ShowReqDtl('divcmphdr','myImg','#myImg');" />
                    </td>
                </tr>
            </table>
            <div id="divcmphdr" runat="server" style="width: 100%;">
                <table style="width: 100%;">
                    <tr>
                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                            <asp:Label ID="lblCompTyp" Text="Compensation Code" runat="server" CssClass="control-label" />
                            <asp:Label ID="lblCompDesc_s" Text="*" runat="server" ForeColor="red" />
                        </td>
                        <td style="width: 30%;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCompCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                        TabIndex="1" OnSelectedIndexChanged="ddlCompCode_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                            <asp:Label ID="Label2" Text="Contestant Code" runat="server" CssClass="control-label" />
                            <asp:Label ID="Label3" Text="*" runat="server" ForeColor="red" />
                        </td>
                        <td style="width: 30%;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCntstCd" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                        TabIndex="1">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                            <asp:Label ID="lblCycCd" Text="Cycle Code" runat="server" CssClass="control-label" />
                        </td>
                        <td style="width: 30%;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCycCd" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                        TabIndex="1">
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
                                    <asp:Button ID="btnClear" Text="CLEAR" runat="server" Width="100px" CssClass="btn default" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>--%>
 

        <%--Added by Rajkapoor Yadav--%>
        <div id="div4" runat="server" style="width: 97%;border: 1px solid #7dd5fa;padding: 5px 0 3px 0;" class="panel">
            <div id="Div6" runat="server" class="panel-heading" style="border:none !important; padding:0px !important" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImgNEW');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
<%--                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;commennted by ajay sawant 25/4/2018--%>
                                                       <span style="margin-left:6px">
                                    <img id="imgCodeIcon1" src="../../../KMI%20Styles/assets/css/Images/compensation_icon.png"/>
                                </span>&nbsp;<%--commented by ajay sawant 25/4/2018--%>
                        <asp:Label ID="Label4" Text="COMPENSATION DETAILS SEARCH" Font-Size="16px" runat="server" />
                    </div>  
                    <div class="col-sm-2">
                    <span id="myImgNEW" class="glyphicon glyphicon-chevron-down" style="float: right;  color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px; margin-top:12px"> </span> <%--added by ajay sawant 24/4/2018--%>

                    </div>
                </div>
            </div>



                       <%-- <div id="div5" runat="server" style="width: 96%; border:none;padding:0px !important" class="panel-body">--%>
                                        <div id="divcmphdr" runat="server"  style="width: 96%; border:none;padding:0px !important" class="panel-body">
                <table style="width: 100%;">
                    <tr>
                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                            <asp:Label ID="lblCompTyp" Text="Compensation Code" runat="server" CssClass="control-label" />
                            <asp:Label ID="lblCompDesc_s" Text="*" runat="server" ForeColor="red" />
                        </td>
                        <td style="width: 30%;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCompCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                        TabIndex="1" OnSelectedIndexChanged="ddlCompCode_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                            <asp:Label ID="Label2" Text="Contestant Code" runat="server" CssClass="control-label" />
                            <asp:Label ID="Label3" Text="*" runat="server" ForeColor="red" />
                        </td>
                        <td style="width: 30%;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCntstCd" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                        TabIndex="1">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                            <asp:Label ID="lblCycCd" Text="Cycle Code" runat="server" CssClass="control-label" />
                        </td>
                        <td style="width: 30%;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCycCd" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                        TabIndex="1">
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
                                    <asp:Button ID="btnClear" Text="CLEAR" runat="server" Width="100px" CssClass="btn default" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
            <%--</div>--%>
            </div>



                <div id="div7" runat="server" style="width: 97%;border: 1px solid #7dd5fa;padding: 5px 0 3px 0;" class="panel">
            <div id="Div8" runat="server" class="panel-heading" style="border:none !important; padding:0px !important" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div9','myImgNEW1');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                                                       <span style="margin-left:6px">
                                    <img id="imgCodeIcon2" src="../../../KMI%20Styles/assets/css/Images/compensation_icon.png"/>
                                </span>&nbsp; 
                        <asp:Label ID="Label5" Text="COMPENSATION DETAILS SEARCH RESULTS" Font-Size="16px" runat="server" />
                    </div>  
                    <div class="col-sm-2">
                             <span id="myImgNEW1" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px; margin-top:12px"></span> <%--added by ajay sawant 24/4/2018--%>

                    </div>
                </div>
            </div>
                    
         <div id="div9" runat="server" style="width: 96%; border:none;padding:0px !important" class="panel-body">
                         <div id="div2" runat="server" style="width: 100%;padding:10px;">
                <div id="Div3" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                    class="table-scrollable">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dgCmp" runat="server" AutoGenerateColumns="false" Width="100%"
                                PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable">
                                <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                <RowStyle />
                                <PagerStyle CssClass="disablepage" />
                                <Columns>
                                <asp:TemplateField HeaderText="Sales Manager">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server" />
                                        <asp:HiddenField ID="hdnName" Value='<%# Bind("MEM_CODE") %>' runat="server" />
                                    </ItemTemplate>    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SAP Code" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpCode" Text='<%# Bind("[EmpCode]") %>' runat="server" />
                                    </ItemTemplate>    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="W.Prem (Total)" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWRPAll" Text='<%# Bind("[TotalWRP]") %>' runat="server" />
                                    </ItemTemplate>    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="W.Prem(Fire)" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWRPFire" Text='<%# Bind("[WRP Fire]") %>' runat="server" />
                                    </ItemTemplate>    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="W.Prem (Health)" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWRPHlth" Text='<%# Bind("[WRP Health]") %>' runat="server" />
                                    </ItemTemplate>    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="W.Prem (Motor)" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWRPMotor" Text='<%# Bind("[WRP Motor]") %>' runat="server" />
                                    </ItemTemplate>    
                                </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
             </div>
                    </div>


        <%--Added by Rajkapoor Yadav--%>


    </center>
</asp:Content>

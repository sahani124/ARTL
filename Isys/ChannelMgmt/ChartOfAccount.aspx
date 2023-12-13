<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChartOfAccount.aspx.cs" Inherits="Application_Isys_ChannelMgmt_ChartOfAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <link href="../../../KMI%20Styles/Bootstrap/css/tree.css" rel="stylesheet" />
  

      <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
     
      <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
   

    
      <script type="text/javascript" src="../../../Scripts/jquery.min.js"></script>
    <style>
        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
            color: #FFFFFF;
            border-color: #f04e5e;
            text-align: left !important;
            font-family: VAG Rounded Std Light;
            font-size: 15px;
            white-space: nowrap;
        }
    </style>
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

         function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
            var objnewbtn = document.getElementById(btnName);

            if (objnewdiv.style.display == "block") {
                objnewdiv.style.display = "none";
              //  objnewbtn.className = 'glyphicon glyphicon-collapse-up'
            }
            else {
                objnewdiv.style.display = "block";
                //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
            }
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="updatepanel1" runat="server">
            <ContentTemplate>
        <div class="panel" id="divChart" runat="server">
            <div id="divChartAccount" runat="server" class="panel-heading" onclick="ShowReqDtl('divCOA','btnChart');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lblChart" runat="server" Text="Chart of Accounts (COA)" CssClass="control-label" Font-Size="19px"></asp:Label>
                        <asp:HiddenField ID="hdnChart" runat="server" />

                    </div>
                    <div class="col-sm-2">
                        <span id="btnChart" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>


            <div id="divChartbody" runat="server" class="panel-body" style="display: block">
                   <div class="row" style="text-align: right;margin-bottom: 4px;">
                            <div class="col-sm-12" style="text-align: right">
                                <asp:LinkButton ID="lnkbtnaddprod" runat="server" CssClass="btn btn-sample" OnClick="lnkBtnSavePopup_Click">
                     Add New
                                </asp:LinkButton>
                                <asp:LinkButton ID="lnkBtnViewData" runat="server" CssClass="btn btn-sample" OnClick="lnkBtnViewData_Click">
                   View/Edit/Delete
                                </asp:LinkButton>
                            </div>
                        </div>
               
                <div id="divCOA" runat="server" style="width: 100%">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dgFirstLevel" runat="server" AutoGenerateColumns="false" Width="100%"
                                PageSize="10" AllowSorting="True" OnSorting="dgFirstLevel_Sorting" AllowPaging="true"
                                CssClass="footable" OnRowDataBound="dgFirstLevel_RowDataBound" DataKeyNames="GRP_CODE">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                            <div id="divChild" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                class="table-scrollable,divBorder1">
                                                <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="dgSecondLevel" runat="server" AutoGenerateColumns="false" Width="100.5%"
                                                            PageSize="10" AllowSorting="False" AllowPaging="true" CssClass="footable" OnRowDataBound="dgSecondLevel_RowDataBound"
                                                            DataKeyNames="GRP_CODE">

                                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                            <PagerStyle CssClass="disablepage" />
                                                            <HeaderStyle CssClass="gridview th" />
                                                            <EmptyDataTemplate>
                                                                <asp:Label ID="lbl3" Text="No Record Found" ForeColor="Red" CssClass="control-label"
                                                                    runat="server" />
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                                        <div id="divChildThird" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                                            class="table-scrollable,divBorder1">
                                                                            <asp:UpdatePanel ID="UpdatePanel62" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:GridView ID="dgThirdLevel" runat="server" AutoGenerateColumns="false" Width="100.5%"
                                                                                        PageSize="10" AllowSorting="False" AllowPaging="true" CssClass="footable" OnRowDataBound="dgThirdLevel_RowDataBound"
                                                                                        DataKeyNames="GRP_CODE">

                                                                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                                        <PagerStyle CssClass="disablepage" />
                                                                                        <HeaderStyle CssClass="gridview th" />
                                                                                        <EmptyDataTemplate>
                                                                                            <asp:Label ID="lbl4" Text="No Record Found" ForeColor="Red" CssClass="control-label"
                                                                                                runat="server" />
                                                                                        </EmptyDataTemplate>
                                                                                        <Columns>

                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                                                                    <div id="divChildFourth" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                                                                        class="table-scrollable,divBorder1">
                                                                                                        <asp:UpdatePanel ID="UpdatePanel63" runat="server">
                                                                                                            <ContentTemplate>
                                                                                                                <asp:GridView ID="dgFourthLevel" runat="server" AutoGenerateColumns="false" Width="100.5%"
                                                                                                                    PageSize="10" AllowSorting="False" AllowPaging="true" CssClass="footable" OnRowDataBound="dgFourthLevel_RowDataBound"
                                                                                                                    DataKeyNames="GRP_CODE">

                                                                                                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                                                                    <PagerStyle CssClass="disablepage" />
                                                                                                                    <HeaderStyle CssClass="gridview th" />
                                                                                                                    <EmptyDataTemplate>
                                                                                                                        <asp:Label ID="lbl5" Text="No Record Found" ForeColor="Red" CssClass="control-label"
                                                                                                                            runat="server" />
                                                                                                                    </EmptyDataTemplate>
                                                                                                                    <Columns>

                                                                                                                        <asp:TemplateField>
                                                                                                                            <ItemTemplate>
                                                                                                                                <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                                                                                                <div id="divChildFive" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                                                                                                    class="table-scrollable,divBorder1">
                                                                                                                                    <asp:UpdatePanel ID="UpdatePanel64" runat="server">
                                                                                                                                        <ContentTemplate>
                                                                                                                                            <asp:GridView ID="dgFifthLevel" runat="server" AutoGenerateColumns="false" Width="100.5%"
                                                                                                                                                PageSize="10" AllowSorting="False" AllowPaging="true" CssClass="footable" OnRowDataBound="dgFifthLevel_RowDataBound"
                                                                                                                                                DataKeyNames="GRP_CODE">

                                                                                                                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                                                                                                <PagerStyle CssClass="disablepage" />
                                                                                                                                                <HeaderStyle CssClass="gridview th" />
                                                                                                                                                <EmptyDataTemplate>
                                                                                                                                                    <asp:Label ID="lbl6" Text="No Record Found" ForeColor="Red" CssClass="control-label"
                                                                                                                                                        runat="server" />
                                                                                                                                                </EmptyDataTemplate>
                                                                                                                                                <Columns>
                                                                                                                                                    <asp:TemplateField HeaderText="Group Code" HeaderStyle-HorizontalAlign="Center"
                                                                                                                                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                                                                        <ItemTemplate>
                                                                                                                                                            <asp:Label ID="lblGRP_Code5" Text='<%# Bind("GRP_CODE")%>' runat="server" />
                                                                                                                                                        </ItemTemplate>
                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="Group Name" HeaderStyle-HorizontalAlign="Center"
                                                                                                                                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                                                                        <ItemTemplate>
                                                                                                                                                            <asp:Label ID="lblGRP_Name5" Text='<%# Bind("GRP_NAME")%>' runat="server" />
                                                                                                                                                        </ItemTemplate>
                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="Type Desc" HeaderStyle-HorizontalAlign="Center"
                                                                                                                                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                                                                        <ItemTemplate>
                                                                                                                                                            <asp:Label ID="lblType_Desc5" Text='<%# Bind("TYPE_DESC") %>' runat="server" />
                                                                                                                                                        </ItemTemplate>
                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="Parent Group Code" HeaderStyle-HorizontalAlign="Center"
                                                                                                                                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                                                                        <ItemTemplate>
                                                                                                                                                            <asp:Label ID="lblPRNT_GRP_CODE5" Text='<%# Bind("PRNT_GRP_CODE")%>' runat="server" />
                                                                                                                                                        </ItemTemplate>
                                                                                                                                                    </asp:TemplateField>
                                                                                                                                                </Columns>
                                                                                                                                            </asp:GridView>
                                                                                                                                        </ContentTemplate>
                                                                                                                                    </asp:UpdatePanel>
                                                                                                                                </div>
                                                                                                                            </ItemTemplate>
                                                                                                                            <ItemStyle Width="1%" CssClass="AlignCenter" />
                                                                                                                        </asp:TemplateField>


                                                                                                                        <asp:TemplateField HeaderText="Group Code" HeaderStyle-HorizontalAlign="Center"
                                                                                                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblGRP_Code4" Text='<%# Bind("GRP_CODE")%>' runat="server" />
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField HeaderText="Group Name" HeaderStyle-HorizontalAlign="Center"
                                                                                                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblGRP_Name4" Text='<%# Bind("GRP_NAME")%>' runat="server" />
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField HeaderText="Type Desc" HeaderStyle-HorizontalAlign="Center"
                                                                                                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblType_Desc4" Text='<%# Bind("TYPE_DESC") %>' runat="server" />
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField HeaderText="Parent Group Code" HeaderStyle-HorizontalAlign="Center"
                                                                                                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblPRNT_GRP_CODE4" Text='<%# Bind("PRNT_GRP_CODE")%>' runat="server" />
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                    </Columns>
                                                                                                                </asp:GridView>
                                                                                                            </ContentTemplate>
                                                                                                        </asp:UpdatePanel>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle Width="1%" CssClass="AlignCenter" />
                                                                                            </asp:TemplateField>


                                                                                            <asp:TemplateField HeaderText="Group Code" HeaderStyle-HorizontalAlign="Center"
                                                                                                HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblGRP_Code3" Text='<%# Bind("GRP_CODE") %>' runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Group Name" HeaderStyle-HorizontalAlign="Center"
                                                                                                HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblGRP_Name3" Text='<%# Bind("GRP_NAME") %>' runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Type Desc" HeaderStyle-HorizontalAlign="Center"
                                                                                                HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblType_Desc3" Text='<%# Bind("TYPE_DESC") %>' runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Parent Group Code" HeaderStyle-HorizontalAlign="Center"
                                                                                                HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblPRNT_GRP_CODE3" Text='<%# Bind("PRNT_GRP_CODE") %>' runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>


                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="1%" CssClass="AlignCenter" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Group Code" HeaderStyle-HorizontalAlign="Center"
                                                                    HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGRP_Code2" Text='<%# Bind("GRP_CODE") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Group Name" HeaderStyle-HorizontalAlign="Center"
                                                                    HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGRP_Name2" Text='<%# Bind("GRP_NAME") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Type Desc" HeaderStyle-HorizontalAlign="Center"
                                                                    HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblType_Desc2" Text='<%# Bind("TYPE_DESC") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Parent Group Code" HeaderStyle-HorizontalAlign="Center"
                                                                    HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPRNT_GRP_CODE2" Text='<%# Bind("PRNT_GRP_CODE") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Width="1%" CssClass="AlignCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Code" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGRP_Code" Text='<%# Bind("GRP_CODE") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Group Name" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGRP_Name" Text='<%# Bind("GRP_NAME") %>' runat="server" />

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Type Desc" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType_Desc" Text='<%# Bind("TYPE_DESC") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Parent Group Code" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPRNT_GRP_CODE" Text='<%# Bind("PRNT_GRP_CODE") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>

                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>
            </div>
        </div>

                
                <div class="modal" id="myModal1" role="dialog" data-backdrop="">
                    <div class="modal-dialog modal-sm" style="width: auto; padding: 49px">
                        <!-- Modal content-->
                        <%--<div class="modal-content" style="height: 380px; width: 706px">--%>
                        <div class="modal-content">
                            <div class="modal-header" style="text-align: center; text-align: initial; background-color: #f04e5e; height: 45px; padding-top: 11px;">
                                <asp:Label ID="Label31" Text="Add Group" runat="server" Font-Bold="true" Style="font-size: initial"></asp:Label>

                            </div>




                            <div class="modal-body" style="text-align: center">

                                <div id="divsrch" runat="server" class="panel-body" style="display: block; overflow: auto">
                                    <div class="row">

                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:Label ID="lblGrpCodeId" runat="server" CssClass="control-label" Font-Size="16px">Group Code</asp:Label>
                                            <asp:Label Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtGrpCodeId" CssClass="form-control" Enabled="false" placeholder="Group Code" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:Label ID="Label1" runat="server" CssClass="control-label" Font-Size="16px">Group Name</asp:Label>
                                            <asp:Label Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtgrpName" CssClass="form-control" placeholder="Group Name" runat="server"></asp:TextBox>

                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:Label ID="lblType" runat="server" CssClass="control-label" Font-Size="16px">Type</asp:Label>
                                            <asp:Label Text="*" runat="server" Style="color: Red" />

                                        </div>
                                        <div class="col-sm-3" style="text-align: left;">

                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" ToolTip="Type">
                                                <asp:ListItem Value="">Select (Type)</asp:ListItem>
                                            </asp:DropDownList>


                                        </div>

                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:Label ID="lblPrntGrpCode" runat="server" CssClass="control-label" Font-Size="16px">Parent Group Name</asp:Label>
                                            <asp:Label Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlPrntGrpCode" runat="server" CssClass="form-control" ToolTip="Parent Group Code">
                                                <asp:ListItem Value="">Select (Parent Group Code)</asp:ListItem>
                                            </asp:DropDownList>



                                        </div>

                                    </div>



                                </div>
                            </div>
                            <div class="row " id="btnrow">

                                <div class="col-sm-12" style="text-align: center">
                                    <asp:LinkButton ID="lnkBtnSave" runat="server" CssClass="btn btn-primary" Width="100px" OnClick="lnkBtnSave_Click">
                                   <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> SAVE
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkBtnClear" runat="server"
                                        CssClass="btn btn-primary" Width="100px" OnClick="lnkBtnClear_Click">
                                   <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> CLEAR
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkHideModel" runat="server" CssClass="btn btn-danger"
                                        Width="100px" data-dismiss="modal">
                                   <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> CANCEL
                                    </asp:LinkButton>
                                    <%-- <button type="button" class="btn btn-sample" data-dismiss="modal">
                                <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span> CANCEL
                            </button>--%>
                                </div>
                            </div>

                            <div class="modal-footer" id="DivButton" visible="true" runat="server" style="text-align: center">
                            </div>
                        </div>
                    </div>
                </div>

                  <div class="modal" data-backdrop="false" id="myModalRaise" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 0px; margin-top: 50px;">

                    <div class="modal-dialog" style="padding-top: 0px; margin-top: 2px; width: 95%;">
                        <div class="modal-content">
                            <div class="modal-header" style="margin-top: -10px; background-color: #f04e5e; color: white; margin-bottom: -20px; padding-bottom: 10px ! important;">
                                View/Edit/Delete
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>

                            </div>
                            <div class="modal-body">
                                <br />
                                <asp:GridView ID="gvGrpMater" runat="server" AutoGenerateColumns="False" CssClass="footable"
                                    PageSize="10" AllowSorting="True" AllowPaging="True" OnRowDeleting="gvGrpMater_RowDeleting" OnRowDataBound="gvGrpMater_RowDataBound" OnRowEditing="gvGrpMater_RowEditing" OnRowUpdating="gvGrpMater_RowUpdating" OnRowCancelingEdit="gvGrpMater_RowCancelingEdit">
                                    <%--OnRowDataBound="GridProdDtls_RowDataBound"--%>
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" HorizontalAlign="Left" />


                                    <Columns>
                                        <asp:TemplateField HeaderText="Group Code" HeaderStyle-CssClass="AlignCenter" SortExpression="DocID">
                                            <ItemTemplate>

                                                <asp:Label ID="lblGrpCode" runat="server" Text='<%# Eval("GRP_CODE") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                               <asp:Label ID="lblGrpCodeEdit" runat="server" Visible="true" Text='<%# Eval("GRP_CODE") %>'></asp:Label>  
                                            </EditItemTemplate>
                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="AlignCenter" />

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Group Name" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>

                                                <asp:Label ID="lblGrpName" runat="server" Text='<%# Eval("GRP_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblGrpNameEdit" runat="server" Visible="false" Text='<%# Eval("GRP_NAME") %>'></asp:Label>
                                                <asp:TextBox ID="txtGrpNameEdit" runat="server" CssClass="form-control" Style="background-color: #FFE5B4" Text='<%# Eval("GRP_NAME") %>'></asp:TextBox>
                                            </EditItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="AlignCenter" />

                                        </asp:TemplateField>

                                        <%--<asp:TemplateField HeaderText="TYPE" HeaderStyle-CssClass="AlignCenter" SortExpression="DocID">
                                            <ItemTemplate>

                                                <asp:Label ID="lblType" runat="server" Text='<%# Eval("TYPE") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="AlignCenter" />

                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Type Desc" HeaderStyle-CssClass="AlignCenter" SortExpression="DocID">
                                            <ItemTemplate>

                                                <asp:Label ID="lblTypeDesc" runat="server" Text='<%# Eval("TYPE_DESC") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="AlignCenter" />

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Parent Group Name" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>

                                                <asp:Label ID="lblPrntGrpName" runat="server" Text='<%# Eval("PRNT_GRP_CODE") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblPrntGrpNameEdit" runat="server" Visible="false" Text='<%# Eval("PRNT_GRP_CODE") %>'></asp:Label>
                                                <asp:DropDownList ID="ddlPrntGrpNameEdit" runat="server" CssClass="form-control" Style="background-color: #FFE5B4; ">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                
                                            </EditItemTemplate>
                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="AlignCenter" />

                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Created By" HeaderStyle-CssClass="AlignCenter" SortExpression="DocID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Eval("CreatedBy") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle Width="4%" CssClass="AlignCenter" />
                                          
                                            <FooterTemplate>
                                                <asp:Label ID="lblCreatedByFt" runat="server"></asp:Label>
                                            </FooterTemplate>
                                            <FooterStyle CssClass="AlignCenter" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Created Date" HeaderStyle-CssClass="AlignCenter" SortExpression="DocID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreatedDtim" runat="server" Text='<%# Eval("CreatedDtim") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle Width="4%" CssClass="AlignCenter" />
                                           
                                            
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Updated By" HeaderStyle-CssClass="AlignCenter" SortExpression="DocID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUpdatedBy" runat="server" Text='<%# Eval("UpdatedBy") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle Width="4%" CssClass="AlignCenter" />
                                          
                                            
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Updated Date" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUpdatedDtim" runat="server" Text='<%# Eval("UpdatedDtim") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle Width="4%" CssClass="AlignCenter" />
                                           
                                            
                                        </asp:TemplateField>
                                       


                                        <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit"
                                                    Text="Edit" ToolTip="Edit">
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Delete" ToolTip="Delete">
                                                </asp:LinkButton>



                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Update" Text="Update">
                                                </asp:LinkButton>
                                              
                                          
                                                  |
                                             <i class="fa fa-trash-o"></i>
                                            <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                        
                                            </EditItemTemplate>


                                            <HeaderStyle CssClass="AlignCenter" Width="100px"></HeaderStyle>
                                            <ItemStyle Width="100px" CssClass="AlignCenter" />

                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>
                                <br />
                                <center>
                     <div id="div5" visible="true" runat="server">
                         <center>
                             <table>
                                 <tr>
                                     <td >
                                      
                                                 <asp:Button ID="btnCompprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                     Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                     background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnCompprevious_Click"  />
                                                 <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                     border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                     text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                 <asp:Button ID="btnCompnext" Text=">" CssClass="form-submit-button" runat="server"
                                                     Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                     background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnCompnext_Click"/>

                                         <%-- <asp:LinkButton ID="lnkHidePopup" runat="server" CssClass="btn btn-danger" style="display:inline-block;width:100px;margin-left: 10px;margin-top: -2px;" 
                                 Width="100px" data-dismiss="modal" >
                                   <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> CANCEL
                                  </asp:LinkButton>--%>
                                            <button type="button" class="btn btn-sample"  style="margin-top: -3px;" onclick="ClosePopupAD(); return false;">
                                <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span> CANCEL
                            </button>
                                            
                                     </td>
                                 </tr>
                             </table>
                         </center>
                     </div>
                     </center>

                                <%--<iframe id="iframeElement" src="" width="100%" height="450" frameborder="0" allowtransparency="true"></iframe>--%>
                            </div>
                            <div class="modal-footer" style="display: none">
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                </ContentTemplate>

        </asp:UpdatePanel>
    </form>
</body>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
<script>
    function showDiv(divName, btnName) {
        debugger;
        var objnewdiv = document.getElementById(divName);
        var objnewbtn = document.getElementById(btnName);

        if (objnewdiv.style.display == "block") {
            objnewdiv.style.display = "none";
            objnewbtn.className = 'glyphicon glyphicon-minus'
        }
        else {
            objnewdiv.style.display = "block";
            objnewbtn.className = 'glyphicon glyphicon-plus'
        }
    }
      function OpenElement() {
        // debugger;
        var modal = document.getElementById('myModalRaise');

        $('#myModalRaise').modal();
    }
    function ClosePopupAD() {
            debugger;
        $('modal-backdrop in').hide();
        $('#myModalRaise').modal('hide');
        $('.modal-backdrop').remove();

    }
     function alertMessage() {
        alert('Record Save Succesfully');
    }
    function popupHist() {
        $("#myModal1").modal();
    }

</script>
</html>

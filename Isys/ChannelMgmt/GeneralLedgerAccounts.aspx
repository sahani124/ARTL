<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GeneralLedgerAccounts.aspx.cs" Inherits="Application_Isys_ChannelMgmt_GeneralLedgerAccounts" %>

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
    <script src="../../Common/Scripts/MainPageFunction.js" type="text/javascript"></script>

    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />

    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/tree.css" rel="stylesheet" />
    <script type="text/javascript" src="../../../Scripts/jquery.min.js"></script>

    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
   

  
    



    <%--  <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>--%>


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    

</head>
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

    function popupHist() {
        $('#myModal1').removeData();
        $("#myModal1").modal();
    }
    function ClosePopup() {
        debugger;
        $('#myModal1').modal('hide');

    }
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
<body>


    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updatepanel44" runat="server">
            <ContentTemplate>

                <div class="panel " id="divcmphdrcollapse" runat="server">
                    <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('divcmphdr','btndivcmphdr');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblUnitMaintanance" runat="server" Font-Size="19px"> Ledger Accounts</asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="btndivcmphdr" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>

                        </div>
                    </div>
                    <div id="divcmphdr" runat="server" class="panel-body" style="display: block">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="lblLDGR_ACC_CODE" CssClass="control-label" runat="server"> Account Code </asp:Label>&nbsp;
                                   
                            </div>
                            <div class="col-md-3" style="text-align: left">
                                <asp:TextBox ID="txtLDGRACCCODE" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="LBLGRPCODE" CssClass="control-label" runat="server">Group Name</asp:Label>&nbsp;
                                
                            </div>
                            <div class="col-md-3" style="text-align: left">
                                <asp:DropDownList ID="ddlGRPCODE" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="lblisActive" CssClass="control-label" runat="server">Status</asp:Label>&nbsp;
                                
                            </div>
                            <div class="col-md-3" style="text-align: left">
                                <asp:DropDownList ID="ddlIsactive" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="Y">Active</asp:ListItem>
                                    <asp:ListItem Value="N">Inactive</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-md-12" style="text-align: left">
                                <br />
                                <br />
                                <center>
                            <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample"
                                CausesValidation="false" OnClick="btnSearch_Click">
                                  <span class="glyphicon glyphicon-search" style="color:White"> </span> Search
                            </asp:LinkButton>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample" onClick="btnClear_Click">
                                  <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color:White"> </span> Clear
                            </asp:LinkButton>
                             <asp:LinkButton ID="lnkAddNew" runat="server" CssClass="btn btn-sample" OnClick="lnkAddNew_Click">
                                  <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color:White"> </span> Add New
                            </asp:LinkButton>

                                </center>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel " id="div3" runat="server">
                    <div id="DivSearchResult" runat="server" class="panel-heading" onclick="ShowReqDtl('div1','btndiv_UnitContact');return false;">
                        <div class="row" id="trDetails" runat="server">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lbltitleresult" runat="server" Font-Size="19px">Search Result</asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="btndiv_UnitContact" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div1" runat="server" class="panel-body" style="display: block">
                        <div class="" style="margin-bottom: 5px;">
                            <asp:GridView ID="dgDetails" runat="server" CssClass="footable" AllowSorting="true"
                                AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1" Style="margin-top: 10px" OnRowDeleting="dgDetails_RowDeleting" OnRowEditing="dgDetails_RowEditing" OnRowUpdating="dgDetails_RowUpdating" OnRowDataBound="dgDetails_RowDataBound" OnRowCancelingEdit="dgDetails_RowCancelingEdit">

                                <FooterStyle CssClass="GridViewFooter" />
                                <RowStyle CssClass="GridViewRowNew" />
                                <HeaderStyle CssClass="gridview th" />
                                <PagerStyle CssClass="disablepage" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Account Code" ShowHeader="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLedgeraccount" runat="server" Text='<%# Bind("LDGR_ACC_CODE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditLedgeraccount" runat="server" Text='<%# Bind("LDGR_ACC_CODE") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account Name" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblaccname" Text='<%# Bind("LDGR_ACC_NAME") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditaccname" Text='<%# Bind("LDGR_ACC_NAME") %>' runat="server" Visible="false" />
                                            <asp:TextBox ID="txtEditaccname" runat="server" Visible="true" CssClass="form-control" Text='<%# Eval("LDGR_ACC_NAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Name" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="Gruop" Text='<%# Bind("GRP_CODE") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lbleditgrpcode" Text='<%# Bind("GRP_CODE") %>' runat="server" Visible="false" />
                                            <asp:DropDownList ID="ddlEditGrpCode" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FA GL Code" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                             <asp:Label ID="lblFaGlcode" Text='<%# Bind("FA_GL_CODE") %>' runat="server" />
                                        </ItemTemplate>
                                         <EditItemTemplate>
                                            <asp:Label ID="lblFaGlcodeEdit" Text='<%# Bind("FA_GL_CODE") %>' runat="server" Visible="false" />
                                            <asp:TextBox ID="txtFaGlcodeEdit" runat="server" Visible="true" CssClass="form-control" Text='<%# Eval("FA_GL_CODE") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Create Date" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                             <asp:Label ID="lblCeaseDate" Text='<%# Bind("CREATEDTIM") %>' runat="server" />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsactivee" Text='<%# Bind("IS_ACTIVE") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditIsactivee" Text='<%# Bind("IS_ACTIVE") %>' runat="server" Visible="false" />
                                            <asp:DropDownList ID="ddlEditIsActive" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                <asp:ListItem Value="Y">Active</asp:ListItem>
                                                <asp:ListItem Value="N">Inactive</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgrpCreatedDtim" Text='<%# Bind("CEASE_DATE") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                   

                                   <%-- <asp:TemplateField HeaderText="Ledger Deactive Dtim" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblctiveDtim" Text='<%# Bind("LDGR_DEACTIVATED_DTIM") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <%--                                <asp:TemplateField HeaderText="Created By" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedBy" Text='<%# Bind("CREATED_BY") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                             <asp:TemplateField HeaderText="CREATEDTIM" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreateddtim" Text='<%# Bind("CREATEDTIM") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                               <asp:TemplateField HeaderText="UPDATED_BY" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdatedBy" Text='<%# Bind("UPDATED_BY") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="UPDATEDTIM" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdateddtim" Text='<%# Bind("UPDATEDTIM") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Action" ShowHeader="True">
                                        <ItemTemplate>
                                            <div style="width: 100%;">
                                                <i class="fa fa-trash-o"></i>
                                                <asp:LinkButton ID="BtnEdit" runat="server" Text="Edit" CommandName="Edit" />
                                                |
                                            <i class="fa fa-trash-o"></i>
                                                <asp:LinkButton ID="BtnDel" runat="server" Text="Delete" CommandName="Delete" />
                                            </div>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <i class="fa fa-trash-o"></i>
                                            <asp:LinkButton ID="Btnupdate" runat="server" Text="Update" CommandName="Update" />
                                            |
                                             <i class="fa fa-trash-o"></i>
                                            <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
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
                                                     background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnCompprevious_Click"/>
                                                 <asp:TextBox runat="server" ID="txtPage" Style="Width:40px;border-style: solid;
                                                     border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                     text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                 <asp:Button ID="btnCompnext" Text=">" CssClass="form-submit-button" runat="server"
                                                     Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                     background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnCompnext_Click"/>

                                            
                                     </td>
                                 </tr>
                             </table>
                         </center>
                     </div>
                     </center>



                        </div>
                    </div>
                </div>

                <div class="modal" id="myModal1" role="dialog" data-backdrop="">
                    <div class="modal-dialog modal-sm" style="width: auto; padding: 49px">
                        <!-- Modal content-->
                        <%--<div class="modal-content" style="height: 380px; width: 706px">--%>
                        <div class="modal-content">
                            <div class="modal-header" style="text-align: center; text-align: initial; background-color: #f04e5e; height: 45px; padding-top: 11px;">
                                <asp:Label ID="Label31" Text="Add Ledger Account" runat="server" Font-Bold="true" Style="font-size: initial"></asp:Label>

                            </div>




                            <div class="modal-body" style="text-align: center">

                                <div id="divsrch" runat="server" class="panel-body" style="display: block; overflow: auto">
                                    <div class="row">

                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:Label ID="lblLegAcntCode" runat="server" CssClass="control-label" Font-Size="16px">Account Code</asp:Label>
                                            <asp:Label Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtLegAcntCode" CssClass="form-control" Enabled="false" placeholder="Ledger Account Code" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:Label ID="lblLegAcntName" runat="server" CssClass="control-label" Font-Size="16px">Account Name</asp:Label>
                                            <asp:Label Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtLegAcntName" CssClass="form-control" placeholder="Ledger Account Name" runat="server"></asp:TextBox>

                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:Label ID="lblGrpName" runat="server" CssClass="control-label" Font-Size="16px">Group Name</asp:Label>
                                            <asp:Label Text="*" runat="server" Style="color: Red" />

                                        </div>
                                        <div class="col-sm-3" style="text-align: left;">

                                            <asp:DropDownList ID="ddlGrpName" runat="server" CssClass="form-control" ToolTip="Type">
                                                <asp:ListItem Value="">Select (Group Name)</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:Label ID="lblFaglCode" runat="server" CssClass="control-label" Font-Size="16px">FA GL Code</asp:Label>
                                            <asp:Label Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtFaglCode" CssClass="form-control" placeholder="FA GL CODE" runat="server"></asp:TextBox>

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
                                            Width="100px" OnClientClick="ClosePopup();">
                                   <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> CANCEL
                                        </asp:LinkButton>
                                        <%-- <button type="button" class="btn btn-sample" data-dismiss="modal">
                                <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span> CANCEL
                            </button>--%>
                                    </div>
                                </div>

                            </div>
                        </div>


                        <div class="modal-footer" id="DivButton" visible="true" runat="server" style="text-align: center">
                        </div>
                    </div>
                </div>
                </div>


            </ContentTemplate>

        </asp:UpdatePanel>


    </form>

</body>
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />
 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        $('[id*=TxtCeaseDate]').datepicker({
            changeMonth: true,
            changeYear: true,
            format: "dd/mm/yyyy",
            language: "tr"
        });
    });
</script>

</html>

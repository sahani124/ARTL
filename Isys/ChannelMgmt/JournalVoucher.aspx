<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JournalVoucher.aspx.cs" Inherits="Application_Isys_ChannelMgmt_JournalVoucher" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--VAPT Points Added by Ashish P--%>
    <meta http-equiv="cache-control" content="max-age=0" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-store" />
    <meta http-equiv="cache-control" content="private" />
    <meta http-equiv="cache-control" content="pre-check=0" />
    <meta http-equiv="cache-control" content="post-check=0" />
    <%--VAPT Points Added by Ashish P--%>

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

    <%--<script type="text/javascript" src="https://ajax.cdnjs.com/ajax/libs/json2/20110223/json2.js"></script>--%>

    <script src="../../../KMI%20Styles/Bootstrap/js/json2.js"></script>



    <%--  <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>--%>


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>


    <script type="text/javascript">


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
    <style>
        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
            color: #FFFFFF;
            border-color: #f04e5e;
            font-family: VAG Rounded Std Light;
            font-size: 15px;
            white-space: nowrap;
        }

        .ccsalignCenter {
            text-align: center !important;
        }

        .cssalingleft {
            text-align: left !important;
        }

        .cssalingright {
            text-align: right !important;
        }

        tbody {
            text-align: left !important;
        }

        .close {
            color: white !important;
        }
    </style>
</head>
<script type="text/javascript">

    function OpenElement() {
        // debugger;


        $('#myModalRaise').modal();
    }
    function popupHist() {
        debugger;

        $("#myModal1").modal();
        var returnObjName = localStorage.getItem('JournalVoucherTable');
        if (returnObjName && Object.keys(returnObjName).length > 0) {
            document.getElementById("tblTxnJouVoucher").innerHTML = localStorage.getItem("JournalVoucherTable");
        } else {
            //Non Exist data block
        }

    }
    function ClosePopup() {
        debugger;
        $('#myModal1').modal('hide');
        localStorage.setItem("JournalVoucherTable", "");

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

    function Add() {
        debugger;
        var txtTransType = document.getElementById("ddlTransType");
        var txtddlAccountName = document.getElementById("ddlAccountName");
        var strAccountName = txtddlAccountName.options[txtddlAccountName.selectedIndex].text;
        var strAccode = txtddlAccountName.options[txtddlAccountName.selectedIndex].value;
        var txtAmount = document.getElementById("txtAmount");
        var Debit = "";
        var Credit = "";

        if (txtTransType.value == "DR") {
            Debit = txtAmount.value;
        }
        else {
            Credit = txtAmount.value;

        }

        AddRow(txtTransType.value, strAccode + "-" + strAccountName, Debit, Credit);
        document.getElementById("ddlTransType").selectedIndex = 0;
        document.getElementById("ddlAccountName").selectedIndex = 0;
        document.getElementById("txtAmount").value = "";

        $("#myModal1").modal();
    };

    function Remove(button) {
        debugger;
        //Determine the reference of the Row using the Button.
        var row = button.parentNode.parentNode;
        var name = row.getElementsByTagName("TD")[0].innerHTML;
        if (confirm("Do you want to delete: " + name)) {

            //Get the reference of the Table.
            var table = document.getElementById("tblTxnJouVoucher");

            //Delete the Table row using it's Index.
            table.deleteRow(row.rowIndex);
        }
    };

    function AddRow(TransType, AccountName, Debit, Credit) {
        debugger;
        //Get the reference of the Table's TBODY element.
        var tBody = document.getElementById("tblTxnJouVoucher").getElementsByTagName("TBODY")[0];

        //Add Row.
        row = tBody.insertRow(-1);

        //Add TransType cell.
        var cell = row.insertCell(-1);

        cell.innerHTML = TransType;

        //Add AccountName cell.
        cell = row.insertCell(-1);
        cell.innerHTML = AccountName;

        ////Add AccountCode cell.
        //cell = row.insertCell(-1);
        //cell.innerHTML = AccountCode;

        //Add Debit cell.
        cell = row.insertCell(-1);
        cell.innerHTML = Debit;

        //Add Credit cell.
        cell = row.insertCell(-1);
        cell.innerHTML = Credit;


        //Add Button cell.
        cell = row.insertCell(-1);
        var btnRemove = document.createElement("INPUT");
        btnRemove.type = "button";
        btnRemove.value = "Remove";
        btnRemove.setAttribute("style", "color: red;border-style: none;background-color: white;");
        btnRemove.setAttribute("onclick", "Remove(this);");
        cell.appendChild(btnRemove);
    }

    function GetTableValues() {
        debugger;
        //Create an Array to hold the Table values.
        var PaymentVouchers = new Array();

        localStorage.setItem("JournalVoucherTable", document.getElementById("tblTxnJouVoucher").innerHTML);
        //Reference the Table.
        var table = document.getElementById("tblTxnJouVoucher");

        //Loop through Table Rows.
        for (var i = 1; i < table.rows.length; i++) {
            //Reference the Table Row.
            var row = table.rows[i];

            //Copy values from Table Cell to JSON object.
            var PaymentVoucher = {};
            PaymentVoucher.TransactionType = row.cells[0].innerHTML;
            PaymentVoucher.AccountName = row.cells[1].innerHTML;
            if (row.cells[2].innerHTML != "")
                PaymentVoucher.Debit = parseFloat(row.cells[2].innerHTML).toFixed(2);
            else
                PaymentVoucher.Debit = "";
            if (row.cells[3].innerHTML != "")
                PaymentVoucher.Credit = parseFloat(row.cells[3].innerHTML).toFixed(2);
            else
                PaymentVoucher.Credit = "";
            PaymentVouchers.push(PaymentVoucher);
        }

        //Convert the JSON object to string and assign to Hidden Field.
        document.getElementsByName("JournalVoucherJSON")[0].value = JSON.stringify(PaymentVouchers);
    }

    function SetTableTemp() {
        localStorage.setItem("JournalVoucherTable", document.getElementById("tblTxnJouVoucher").innerHTML);
    }
</script>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="updatepanel1" runat="server">
            <ContentTemplate>

                <div class="panel " id="divcmphdrcollapse" runat="server">
                    <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('divcmphdr','btndivcmphdr');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblJournalV" runat="server" Font-Size="19px">Journal Voucher</asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="btndivcmphdr" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>

                        </div>
                    </div>
                    <div id="divcmphdr" runat="server" class="panel-body" style="display: block">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="lblJournalVoucher" CssClass="control-label" runat="server"> Journal Voucher No </asp:Label>&nbsp;
                                 

                            </div>
                            <div class="col-md-3" style="text-align: left">
                                <asp:TextBox ID="txtJournalVoucher" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-md-12" style="text-align: left">

                                <center>
                            <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample"
                                CausesValidation="false" OnClick="btnSearch_Click">
                                  <span class="glyphicon glyphicon-search" style="color:White"> </span> Search
                            </asp:LinkButton>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample" OnClick="btnClear_Click" >
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

                            <br />
                            <asp:GridView ID="gvJournal" runat="server" CssClass="footable" AllowSorting="true"
                                AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1" Style="margin-top: 10px" OnRowEditing="gvJournal_RowEditing" OnRowCommand="gvJournal_RowCommand" OnRowDeleting="gvJournal_RowDeleting" OnRowCancelingEdit="gvJournal_RowCancelingEdit" OnRowUpdating="gvJournal_RowUpdating">

                                <HeaderStyle BackColor="#f04e5e" ForeColor="#ffffff" Font-Size="13px" Height="33px" />
                                <FooterStyle CssClass="GridViewFooter" />
                                <RowStyle CssClass="GridViewRowNew" />
                                <HeaderStyle CssClass="gridview th" />
                                <PagerStyle CssClass="disablepage" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Journal Voucher No" ShowHeader="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJournalVoNo" Style="text-align: center" runat="server" Text='<%# Bind("JV_NO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblJournalVoNoEdit" runat="server" Visible="true" Text='<%# Eval("JV_NO") %>'></asp:Label>

                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10% " CssClass="ccsalignCenter"></ItemStyle>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Created Date" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedDate" Text='<%# Bind("CREATED_DATE") %>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="13% " CssClass="ccsalignCenter"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Narration" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNarration" Text='<%# Bind("NARRATION") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblNarrationEdit" runat="server" Visible="false" Text='<%# Eval("NARRATION") %>'></asp:Label>
                                            <asp:TextBox ID="txtNarrationEdit" runat="server" CssClass="form-control" Style="background-color: #FFE5B4" Text='<%# Eval("NARRATION") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="40% " CssClass="cssalingleft"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reference Document No" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRefNO" Text='<%# Bind("REF_DOC_NO") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblRefDocNoEdit" runat="server" Visible="false" Text='<%# Eval("REF_DOC_NO") %>'></asp:Label>
                                            <asp:TextBox ID="txtRefDocNoEdit" runat="server" CssClass="form-control" Style="background-color: #FFE5B4" Text='<%# Eval("REF_DOC_NO") %>'></asp:TextBox>
                                        </EditItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action" ShowHeader="True">


                                        <ItemTemplate>
                                            <div style="width: 100%;">

                                                <i class="fa fa-trash-o"></i>
                                                <asp:LinkButton ID="btnView" runat="server" CommandName="View"
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="View" ToolTip="View ">
                                                </asp:LinkButton>
                                                |
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

                                        <ItemStyle HorizontalAlign="Center" Width="13% " CssClass="ccsalignCenter"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                            <br />
                            <center>
                     <div id="div2" visible="true" runat="server">
                         <center>
                             <table>
                                 <tr>
                                     <td >
                                      
                                                 <asp:Button ID="btnCompprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                     Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                     background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnCompprevious_Click"/>
                                                 <asp:TextBox runat="server" ID="TextBox1" Style="width: 40px; border-style: solid;
                                                     border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                     text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                 <asp:Button ID="btnCompnext" Text=">" CssClass="form-submit-button" runat="server"
                                                     Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                     background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnCompnext_Click" />

                                        
                                            
                                     </td>
                                 </tr>
                             </table>
                         </center>
                     </div>
                     </center>



                        </div>
                    </div>
                </div>


                <div class="modal" id="myModal1" role="dialog" data-backdrop="" style="margin-top: -80px;">
                    <div class="modal-dialog modal-sm" style="width: auto; padding: 49px">
                        <!-- Modal content-->
                        <%--<div class="modal-content" style="height: 380px; width: 706px">--%>
                        <div class="modal-content">
                            <div class="modal-header" style="text-align: center; text-align: initial; background-color: #f04e5e; height: 45px; padding-top: 11px;">
                                <asp:Label ID="Label31" Text="Add Journal Voucher" runat="server" Font-Bold="true" Style="font-size: initial"></asp:Label>
                                <button type="button" class="close" onclick="ClosePopup();" style="color: white;" aria-hidden="true">&times;</button>

                            </div>

                            <div class="modal-body" style="text-align: center">
                                <div class="row">

                                    <div class="col-sm-2" style="text-align: left; margin-left: 21px;">
                                        <asp:Label ID="lblJounalVoucherNo" runat="server" CssClass="control-label" Font-Size="16px">Journal Voucher No</asp:Label>
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtJounalVoucherNo" CssClass="form-control" disabled="disabled" placeholder="Journal Voucher No" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-2" style="text-align: left;">
                                    </div>
                                    <div class="col-sm-1" style="text-align: left;">
                                        <asp:Label ID="lblDate" runat="server" CssClass="control-label" Font-Size="16px">Date</asp:Label>
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtDate" CssClass="form-control" disabled="disabled" placeholder="Date" runat="server"></asp:TextBox>

                                    </div>


                                </div>

                                <div class="row" style="margin-left: 5px; margin-right: 5px; margin-top: -35px;">
                                    <div class="col-sm-3" style="text-align: left;">
                                        <asp:Label ID="lblParticulars" runat="server" CssClass="control-label" Font-Size="16px">Add Particulars</asp:Label>

                                    </div>
                                </div>

                                <div id="divsrch" runat="server" class="panel-body" style="display: block; height: 85px; margin-top: -1px;">

                                    <div class="row" style="margin-left: 5px; margin-right: 5px; color: red;">

                                        <div class="col-sm-3" style="text-align: left;">

                                            <asp:Label ID="lblTransType" runat="server" CssClass="control-label" Font-Size="16px">Transaction Type</asp:Label>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left;">

                                            <asp:Label ID="lblAccountName" runat="server" CssClass="control-label" Font-Size="16px">Account Name</asp:Label>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:Label ID="lblAmmount" runat="server" CssClass="control-label" Font-Size="16px">Amount</asp:Label>

                                        </div>
                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:Label ID="lblAction" runat="server" CssClass="control-label" Font-Size="16px">Action</asp:Label>

                                        </div>


                                    </div>

                                    <div class="row" style="margin-left: 5px; margin-right: 5px; color: red;">

                                        <div class="col-sm-3" style="text-align: left;">

                                            <asp:DropDownList ID="ddlTransType" runat="server" CssClass="form-control" onchange="SetTableTemp();" AutoPostBack="true" OnSelectedIndexChanged="ddlTransType_SelectedIndexChanged">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                <asp:ListItem Value="DR">Debit</asp:ListItem>
                                                <asp:ListItem Value="CR">Credit</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlAccountName" runat="server" CssClass="form-control" ToolTip="Type">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left;">
                                            <asp:TextBox ID="txtAmount" runat="server" Style="text-align: right;" CssClass="form-control" placeholder="Amount"></asp:TextBox>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:LinkButton ID="btnAdd" runat="server" Text="Add" ForeColor="Red" Style="margin-right: 180px" OnClientClick="Add();return false;" />

                                        </div>


                                    </div>

                                </div>

                                <div class="panel-body">
                                    <table id="tblTxnJouVoucher" runat="server" cellpadding="0" cellspacing="0" border="0">
                                        <thead>
                                            <tr>
                                                <th style="color: red; width: 300px;">Transaction Type</th>
                                                <th style="color: red; width: 300px;">Account Name</th>
                                                <th style="color: red; width: 300px;">Debit</th>
                                                <th style="color: red; width: 300px;">Credit</th>
                                            </tr>
                                        </thead>
                                        <tbody style="text-align: left!important;">
                                        </tbody>
                                    </table>
                                </div>

                                <div id="divNarration">
                                    <div class="row">
                                        <div class="col-sm-3" style="text-align: left; margin-left: 21px;">
                                            <asp:Label ID="Label1" runat="server" CssClass="control-label" Font-Size="16px" Style="text-align: left;">Reference Document No</asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtRefDocNo" CssClass="form-control" placeholder="Reference Document No" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:LinkButton ID="lnkBtnRefeDocUpload" runat="server" Text="Reference Document Upload" ForeColor="Red" />
                                        </div>
                                    </div>


                                    <div class="row" style="text-align: left; margin-left: 2%;">

                                        <asp:Label ID="lblNarration" runat="server" CssClass="control-label" Font-Size="16px">Narration</asp:Label>

                                    </div>
                                    <div class="row">
                                        <textarea id="txtNarration" runat="server" rows="2" style="width: 94%"></textarea>
                                    </div>


                                    <div class="row " id="btnrow">

                                        <div class="col-sm-12" style="text-align: center">

                                            <asp:LinkButton ID="lnkBtnSave" runat="server" CssClass="btn btn-sample" Width="100px" OnClientClick="GetTableValues();" OnClick="lnkBtnSave_Click">
                                   <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> SAVE
                                            </asp:LinkButton>
                                            &nbsp;&nbsp;
                             <asp:LinkButton ID="lnkHideModel" runat="server" CssClass="btn btn-sample"
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

                <div class="modal" data-backdrop="false" id="myModalRaise" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 0px; margin-top: 50px;">

                    <div class="modal-dialog" style="padding-top: 0px; margin-top: 2px; width: 95%;">
                        <div class="modal-content">
                            <div class="modal-header" style="margin-top: -10px; background-color: #f04e5e; color: white; margin-bottom: -20px; padding-bottom: 10px ! important;">
                                View Journal Voucher Transaction
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>

                            </div>
                            <div class="modal-body">
                                <br />
                                <asp:GridView ID="gvTxnDetails" runat="server" AutoGenerateColumns="False" CssClass="footable"
                                    PageSize="10" AllowSorting="True" AllowPaging="True" OnRowEditing="gvTxnDetails_RowEditing" OnRowCancelingEdit="gvTxnDetails_RowCancelingEdit" OnRowUpdating="gvTxnDetails_RowUpdating" OnRowDataBound="gvTxnDetails_RowDataBound">
                                    <%--OnRowDataBound="GridProdDtls_RowDataBound"--%>
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" HorizontalAlign="Left" />


                                    <Columns>
                                        <asp:TemplateField HeaderText="JV Transaction No" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>

                                                <asp:Label ID="lblJournalTxnNo" runat="server" Text='<%# Eval("JV_TXN_NO") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblJournalTxnNoEdit" runat="server" Visible="true" Text='<%# Eval("JV_TXN_NO") %>'></asp:Label>
                                            </EditItemTemplate>


                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>
                                            <ItemStyle Width="4%" CssClass="ccsalignCenter" />

                                            <%-- <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="AlignCenter" />--%>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Journal Voucher No" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>

                                                <asp:Label ID="lblJournalVoucherNo" runat="server" Text='<%# Eval("JV_NO") %>'></asp:Label>

                                            </ItemTemplate>
                                            <EditItemTemplate>

                                                <asp:Label ID="lblJournalVoucherNoEdit" runat="server" Visible="false" Text='<%# Eval("JV_NO") %>'></asp:Label>

                                            </EditItemTemplate>



                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="ccsalignCenter" />

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Transaction Type" HeaderStyle-CssClass="AlignCenter" SortExpression="DocID">
                                            <ItemTemplate>

                                                <asp:Label ID="lblTxnType" runat="server" Text='<%# Eval("TXN_TYPE") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>

                                                <asp:Label ID="lblTxnTypeEdit" runat="server" Visible="true" Text='<%# Eval("TXN_TYPE") %>'></asp:Label>
                                                <%--                                                <asp:TextBox ID="txtGrpNameEdit" runat="server" CssClass="form-control" Style="background-color: #FFE5B4" Text='<%# Eval("GRP_NAME") %>'></asp:TextBox>--%>
                                            </EditItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="ccsalignCenter" />

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Account Name" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>

                                                <asp:Label ID="lblAccountName" runat="server" Text='<%# Eval("ACCOUNT_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblAccountNameEdit" runat="server" Visible="false" Text='<%# Eval("ACCOUNT_NAME") %>'></asp:Label>
                                                <asp:DropDownList ID="ddlAccountNameEdit" runat="server" CssClass="form-control" Style="background-color: #FFE5B4;">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>

                                            </EditItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="ccsalignCenter" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account Code" Visible="false" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>

                                                <asp:Label ID="lblAccountCode" runat="server" Text='<%# Eval("ACCOUNT_CODE") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="AlignCenter" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Debit Amount" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>

                                                <asp:Label ID="lblDebitAmount" runat="server" Text='<%# Eval("DEBIT_AMT") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblDebitAmountEdit" runat="server" Style="display: none" Text='<%# Eval("DEBIT_AMT") %>'></asp:Label>
                                                <asp:TextBox ID="txtDebitAmountEdit" runat="server" CssClass="form-control" Style="display: block; background-color: #FFE5B4" Text='<%# Eval("DEBIT_AMT") %>'></asp:TextBox>
                                            </EditItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="ccsalignCenter" />

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Credit Amount" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>

                                                <asp:Label ID="lblCreditAmount" runat="server" Text='<%# Eval("CREDIT_AMT") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblCreditAmountEdit" runat="server" Visible="false" Text='<%# Eval("CREDIT_AMT") %>'></asp:Label>
                                                <asp:TextBox ID="txtCreditAmountEdit" runat="server" CssClass="form-control" Style="background-color: #FFE5B4" Text='<%# Eval("CREDIT_AMT") %>'></asp:TextBox>
                                            </EditItemTemplate>

                                            <HeaderStyle CssClass="AlignCenter"></HeaderStyle>

                                            <ItemStyle CssClass="ccsalignCenter" />

                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="AlignCenter">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit"
                                                    Text="Edit" ToolTip="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
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
                                            <ItemStyle Width="100px" CssClass="ccsalignCenter" />

                                        </asp:TemplateField>



                                    </Columns>

                                </asp:GridView>
                                <br />
                                <center>
                     <div id="div7" visible="true" runat="server">
                         <center>
                             <table>
                                 <tr>
                                     <td >
                                      
                                                 <asp:Button ID="btnCompprevious1" Text="<" CssClass="form-submit-button" runat="server"
                                                     Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                     background-color: transparent; float: left; margin: 0; height: 30px;"  OnClick="btnCompprevious1_Click"/>
                                                 <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                     border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                     text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                 <asp:Button ID="btnCompnext1" Text=">" CssClass="form-submit-button" runat="server"
                                                     Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                     background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnCompnext1_Click" />

                                        
                                            
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
                <asp:HiddenField ID="JournalVoucherJSON" runat="server" />
            </ContentTemplate>

        </asp:UpdatePanel>
    </form>
</body>


</html>





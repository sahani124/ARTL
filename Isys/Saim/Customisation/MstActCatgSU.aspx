<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MstActCatgSU.aspx.cs" Inherits="Application_Isys_Saim_Customisation_MstActCatgSU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <%--<script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>--%>
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />

    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <%--Added References by Daksh for Reports Start--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />

    <%--Added Gridvi by DAksh for Reports End--%>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <style>
        /*body {
            background-color: #eee;
        }

        table th, table td {
            text-align: center;
        }*/
        .onhover {
            color: white !important;
        }

        .clsCenter {
            text-align: center !important;
        }

        table tr:nth-child(even) {
            background-color: #f3fff6;
        }

        .pagination li:hover {
            cursor: pointer;
        }

        .pagination > li > span {
            border-radius: 30px !important;
            border: 1px solid;
        }
        /*table tbody tr {
            display: none;
        }*/
    </style>
    <style type="text/css">
        ul#menu li a:active {
            background: white;
        }

        .disablepage {
            display: none;
        }

        ul#menu {
            padding: 0;
            margin-right: 69%;
        }

            ul#menu li {
                display: inline;
            }

                ul#menu li a {
                    background-color: Silver;
                    color: black;
                    cursor: pointer;
                    padding: 10px 20px;
                    text-decoration: none;
                    border-radius: 4px 4px 0 0;
                }

                    ul#menu li a:active {
                        background: white;
                    }

                    ul#menu li a:hover {
                        background-color: red;
                    }

        .multiselect {
            overflow: hidden;
            width: 279px;
        }

        .btn-group {
            margin-right: 155px;
        }

        .btn.focus, .btn:focus, .btn:hover {
            color: #fff;
        }

        .multiselect-container > li > a > .checkbox {
            margin-top: 5px !important;
            margin-bottom: 5px !important;
            margin-left: 20px !important;
        }
    </style>
    <center>

        <%--Added by DAksh for Reports Start--%>

        <div id="div1" runat="server" style="width: 97%;" class="panel">
            <div id="divRprtPanelHeading" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRprtPanelBody','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lbldtls" Text="Action Category Setup" Font-Size="19px" runat="server" />
                    </div>
                    <div class="col-sm-2">
                             <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>

                    </div>
                </div>
            </div>
           <asp:updatepanel runat="server">
               <contenttemplate>
                     <div id="divRprtPanelBody" runat="server" style="width: 96%;" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblrulNo" Text="Action Number" runat="server" CssClass="control-label" />
                        <span style="color: red;">*</span>
                    </div>
                    <div class="col-sm-3">
                       <asp:TextBox ID="txtrulNo" runat="server" Enabled="false" CssClass="form-control"  placeholder="Action Number" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblactver" Text="Action Version" runat="server" CssClass="control-label" />
                        <span style="color: red;">*</span>
                    </div>
                    <div class="col-sm-3">
                       <asp:TextBox ID="txtactver" runat="server"  Enabled="false" CssClass="form-control" Text="1.00"  placeholder="Action Version" />
                    </div>

                    <div id="divrate" style="display:none;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblrating" Text="Rating" runat="server" CssClass="control-label" />
                        <span style="color: red;">*</span>
                    </div>
                     <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlrating" runat="server" AutoPostBack="true" onmouseup="bindValFactor()" onmousedown="bindValFactor()"  CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    </div>
                </div>

                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblfixfactors" Text="Fix factors" runat="server" CssClass="control-label" />
                        <span style="color: red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:ListBox ID="lstfixfactors" runat="server" class="select2-container form-control" SelectionMode="Multiple"></asp:ListBox>
                    </div>
                     <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblrangeFactors" Text="Range factors" runat="server" CssClass="control-label" />
                         <%--<span style="color: red;">*</span>--%>
                    </div>
                    <div class="col-sm-3">
                        <asp:ListBox ID="lstrangeFactors" runat="server" class="select2-container form-control" SelectionMode="Multiple"></asp:ListBox>
                    </div>
                    
                     
                </div>

                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3 col-md-3" style="text-align: left">
                        
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtareaFixfactor" style="overflow:auto;resize:none" rows="5" cols="20" runat="server" placeholder="Fix Factors" Enabled="false" TextMode="MultiLine" CssClass="form-control"  />
                    </div>
                    <div class="col-sm-3 col-md-3" style="text-align: left">
                        
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtareaRangefactor" style="overflow:auto;resize:none" rows="5" cols="20" runat="server" placeholder="Range Factors" Enabled="false" TextMode="MultiLine" CssClass="form-control"  />
                    </div>
                </div>

                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblvaluefactors" Text="Value Factors" runat="server" CssClass="control-label" />
                        <span style="color: red;">*</span>
                    </div>
                    <div class="col-sm-3" >
                       <asp:TextBox ID="txtvaluefactors" runat="server" Enabled="false" style="overflow:auto;resize:none" rows="5" cols="20" TextMode="MultiLine"  CssClass="form-control"  placeholder="Value Factors" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblactbehtyp" Text="Action Behaviour Type" runat="server" CssClass="control-label" />
                        <span style="color: red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlactbehtyp" runat="server" AutoPostBack="true"  CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                     
                </div>

                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblEffDFrom" Text="Effective Date" runat="server" CssClass="control-label" />

                        <span style="color: red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        
                                <asp:TextBox ID="txtEffDFrom" runat="server" CssClass="form-control"   onclick="callEffectiveDate()"
                                     placeholder="DD/MM/YYYY" />
                                 <%--onmouseup="populateEffDateF()"  onmousedown="populateEffDateF()"--%>
                            
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblEffDTo" Text="Cease Date" runat="server" CssClass="control-label" />
                       
                    </div>
                    <div class="col-sm-3">
                        
                                <asp:TextBox ID="txtEffDTo" runat="server"  CssClass="form-control" onclick="callCeaseDate()"  placeholder="DD/MM/YYYY" />
                                <%--onmouseup="populateEffDateT()"  onmousedown="populateEffDateT()" --%>
                            
                    </div>
                </div>

                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblexcOrdr" Text="Execution Order" runat="server" CssClass="control-label" />
                        <span style="color: red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <%--<asp:DropDownList ID="ddlexcOrdr" runat="server" AutoPostBack="true"  CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtExecOrder" runat="server" Enabled="false" CssClass="form-control" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblstatus" Text="Status" runat="server" CssClass="control-label" />
                        <span style="color: red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true"  CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="row" style="margin-bottom: 5px;">
                    
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblschmKey" Text="Action Scheme Key" runat="server" CssClass="control-label" />
                        <span style="color: red;">*</span>
                    </div>
                     <div class="col-sm-3" >
                       <asp:TextBox ID="txtschmKey" runat="server" Enabled="false" CssClass="form-control"  placeholder="Action Scheme Key" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblactschno" Text="Action Scheme No" runat="server" CssClass="control-label" />
                        <span style="color: red;">*</span>
                    </div>
                    <div class="col-sm-3">
                       <asp:TextBox ID="txtactschno" runat="server" Enabled="false" CssClass="form-control"  placeholder="Action Scheme No" />
                    </div>
                </div>

                 <%--<div class="row" style="margin-bottom: 5px;">
                    

                    
                </div>--%>

                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                            <ContentTemplate>
                                <%--<asp:LinkButton ID="lnkSave" runat="server" CssClass="btn btn-sample" OnClick="lnkSave_Click" OnClientClick="fnValidate()">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Save
                                </asp:LinkButton>--%>
                                
                                <button class="btn btn-sample onhover" runat="server" type="button" style="display:none;" id="btnUpdate" onclick="fnValidate()">
                                    <span class="glyphicon glyphicon-floppy-disk" style="color:white;"></span> Update
                                </button>
                                <button class="btn btn-sample onhover" runat="server" type="button"  style="display:inline-block;" id="btnSave" onclick="fnValidate()">
                                    <span class="glyphicon glyphicon-floppy-disk" style="color:white;"></span> Save
                                </button>
                                <asp:LinkButton ID="lnkCancel" runat="server" OnClick="lnkCancel_Click" CssClass="btn btn-sample onhover" >
                                    <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> Cancel
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btnResetExecOrder" OnClientClick="openPopup(); return false" runat="server" CssClass="btn btn-sample" TabIndex="18">
                        <span class="glyphicon glyphicon-edit" style="color:White"></span> 
                        <%--<span class="glyphicon glyphicon-remove"  style="color:White"></span>--%>
                         Modify Execution order
                    </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
               </contenttemplate>
            </asp:updatepanel>
            
        </div>
         <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="divcmpsrchhdrcollapse" runat="server" style="width: 97%;" class="panel ">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divGridReslts','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               
                                <asp:Label ID="lblCmpSrch" Text="Category Setup Details" style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate>
                                       
                                        <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color:#034ea2; padding: 1px 10px !important; font-size: 18px;"></span>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divGridReslts" runat="server" style="width: 100%;" class="">
                    <div id="divGrid" runat="server" style="width: 98%; padding: 10px; overflow-x:scroll">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvcatgStp" runat="server" AutoGenerateColumns="false" Width="100%" 
                                    AllowPaging="true" PageSize="10" AllowSorting="True" OnSorting="gvcatgStp_Sorting" 
                                    CssClass="footable" OnRowDataBound="gvcatgStp_RowDataBound"
                                    ShowHeader="true">
                                    
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <EmptyDataTemplate>
                                                <asp:Label ID="lblerror" Text="No records found" ForeColor="Red"
                                                    CssClass="control-label" runat="server" />
                                            </EmptyDataTemplate>
                                       <Columns>
                                        <asp:TemplateField HeaderText="Action Code" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="ACT_NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActNo" Text='<%# Bind("ACT_NO") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" CssClass="clsCenter"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fix Factor" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltxtareafixfactor" Text='<%# Bind("FIX_FCTR") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Range Factor" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="RNG_FCTR">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltxtareaRngFactor"  Text='<%# Bind("RNG_FCTR") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Value Factor" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="VAL_FCTR">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltxtareavalFactor"  Text='<%# Bind("VAL_FCTR") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme No" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="ACT_SCHM_NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActSchNo"  Text='<%# Bind("ACT_SCHM_NO") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Execution Order" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="EXCTN_ORDR">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEXCTN_ORDR"  Text='<%# Bind("EXCTN_ORDR") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="Action" Visible="false" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBlkUpd" Text='Bulk Upload' runat="server"
                                                    ></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme Key"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="ACT_SCHM_KEY" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkActSchKey" Text='<%# Bind("ACT_SCHM_KEY")%>' runat="server"
                                                    OnClick="lnkActSchKey_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter" />
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Scheme Key"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="ACT_SCHM_KEY">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDYNKey" Text='<%# Bind("ACT_SCHM_KEY")%>' runat="server"
                                                    OnClick="lnkDYNKey_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action">
                                            <HeaderStyle CssClass="gridview th" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit"  runat="server" Text="Edit"  OnClick="lnkEdit_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="MPL View" Visible="false">
                                            <HeaderStyle CssClass="gridview th" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkMPLView"  runat="server" Text="MPLView"  OnClick="lnkMPLView_Click"></asp:LinkButton>
                                            </ItemTemplate>
											<ItemStyle HorizontalAlign="Center" CssClass="clsCenter" />
                                        </asp:TemplateField>
										 <asp:TemplateField HeaderText="View Module">
                                            <HeaderStyle CssClass="gridview th" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkIncludeExcludView"  runat="server" Text="View"  OnClick="lnkIncludeExcludView_Click"></asp:LinkButton>
                                            </ItemTemplate>
											<ItemStyle HorizontalAlign="Center" CssClass="clsCenter" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action Behaviour Type" Visible="false"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="ACT_BEH_TYPE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActBehTyp"  Text='<%# Bind("ACT_BEH_TYPE") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Eff. Date" Visible="false"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="EFF_DTIM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEffdate"  Text='<%# Bind("EFF_DTIM") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cease Date" Visible="false"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="CSE_DTIM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCSEdate"  Text='<%# Bind("CSE_DTIM") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Execution Order" Visible="false"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="EXCTN_ORDR">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcOrder"  Text='<%# Bind("EXCTN_ORDR") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status" Visible="false"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="STATUS">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatus"  Text='<%# Bind("STATUS") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter" />
                                        </asp:TemplateField>

                                        

                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                                                    <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 50px; border-style: solid;
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
                    </div>
                        </div>

                  
                </div>
                  <asp:LinkButton ID="btnCancelAll" runat="server" CssClass="btn btn-sample" Enabled="true" 
                        OnClick="lnkCancel_Click">
                                <span class="glyphicon glyphicon-arrow-left BtnGlyphicon" style="color: White;"></span> Back    
                    </asp:LinkButton>
                    <asp:HiddenField ID="hdnBackUrl" runat="server"/>   
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--Added by DAksh for Reports End--%>

        <asp:Panel runat="server" Height="365px" Width="863px" ID="Panel1" display="none" Style="text-align: center;top:59px !important; padding: 5px;left:-22px;" CssClass="panel panel-success">
            <iframe runat="server" id="Iframe1" scrolling="yes" width="80%" frameborder="0" display="none" style="height: 100%; "></iframe>
        </asp:Panel>
        <asp:Label runat="server" ID="Label10" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlPopBIDHybrid"
        DropShadow="false" TargetControlID="Label10" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg"  X="-4" Y="0">
        </ajaxToolkit:ModalPopupExtender>
       
    </center>

    <div>
        <div class="modal fade" id="ExecOrderPopup" tabindex="-1" role="dialog" aria-labelledby="ExecOrderPopup" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <span style="font-size: 20px" class="modal-title">Modify Execution Order</span>
                        <br />
                        <span  style="font-size: 14px; color:red" >Note: Please arrange the Scheme Key according to execution order(Ascending)</span>
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

    <script src="../../../../assets/scripts/jquery.min.js"></script>
    <script src="../../../../assets/scripts/bootstrap.min.js"></script>
    <script src="../../../../assets/scripts/bootstrap-multiselect.js"></script>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>--%>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <%--Added Script Tag by DAksh for Reports Start--%>
    <script>
        var fixcolumnNames = "";
        var rangecolumnNames = "";
        var valueFactor = "";

        var rangeFactorLength = 0;
        var fixFactorLength = 0;


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

        $(document).ready(function () {
            debugger;
            window.history.forward();
            //populateCalendar()

            $('#ctl00_ContentPlaceHolder1_lstfixfactors').multiselect({
                includeSelectAllOption: true,
                onDropdownHidden: function (e) {
                    bindValFactor()
                }
            });

            $('#ctl00_ContentPlaceHolder1_lstrangeFactors').multiselect({
                includeSelectAllOption: true,
                onDropdownHidden: function (e) {
                    bindValFactor()
                }
            });


        });


        function pageLoad(sender, args) {

            $('#ctl00_ContentPlaceHolder1_lstfixfactors').multiselect({
                includeSelectAllOption: true,
                onDropdownHidden: function (e) {
                    bindValFactor()
                }
            });

            $('#ctl00_ContentPlaceHolder1_lstrangeFactors').multiselect({
                includeSelectAllOption: true,
                onDropdownHidden: function (e) {
                    bindValFactor()
                }
            });
            bindValFactor()
            // window.scrollTo(0, 0);
        }

        function fnCallPOP(ActNo, ActSchNo) {
            debugger;
            $find("mdlPopBIDHybrid").show();
            var Mode = "S";
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = ("FRMCtgStpDtlsPopUp.aspx?ActNo=" + ActNo + "&ActSchNo=" + ActSchNo + "&Mode=" + Mode + "&mdlpopup=mdlPopBIDHybrid");
            return false;
        }

        function callEffectiveDate() {
            var dateArr = $("#<%=txtEffDFrom.ClientID%>").val().split('-');
            $("#<%= txtEffDFrom.ClientID%>").datepicker({ minDate: new Date(), changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });
            $.datepicker.initialized = true;
            $("#<%= txtEffDFrom.ClientID%>").focus();
            $("#<%=txtEffDTo.ClientID%>").val('')
        }
        function callCeaseDate() {
            var previousCommDate = '';
            debugger;
            $.datepicker.initialized = false;
            if ($("#<%=txtEffDFrom.ClientID%>").val().trim() == '') {
                alert("Please select Effective Date.");
                $("#<%= txtEffDTo.ClientID%>").val('');
                $("#<%=txtEffDFrom.ClientID%>").focus();
                return;
            }

            if (previousCommDate != $("#<%=txtEffDFrom.ClientID%>").val().trim()) {
                previousCommDate = $("#<%=txtEffDFrom.ClientID%>").val().trim();
                $("#<%= txtEffDTo.ClientID%>").val('');
            }
            $("#<%= txtEffDTo.ClientID%>").focus();
            var dateArr = $("#<%=txtEffDFrom.ClientID%>").val().split('/');
            $("#<%= txtEffDTo.ClientID%>").datepicker({ minDate: new Date(dateArr[2], dateArr[1] - 1, dateArr[0]), changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });
            $.datepicker.initialized = true;
            $("#<%= txtEffDTo.ClientID%>").focus();
        }





        function bindValFactor() {
            debugger;
            document.getElementById("<%=txtvaluefactors.ClientID%>").value = "";
            document.getElementById("<%=txtareaFixfactor.ClientID%>").value = "";
            document.getElementById("<%=txtareaRangefactor.ClientID%>").value = "";
            document.getElementById("<%=txtactschno.ClientID%>").value = "";
            fixcolumnNames = "";
            rangecolumnNames = "";
            valueFactor = "";
            rangeFactorLength = 0;
            fixFactorLength = 0;
            var val_factors = []

            var obj = {}
            var object = {}
            var dataObj = [];

            var sel = document.getElementById('<%= lstfixfactors.ClientID %>');
            var fixlistLength = sel.options.length;
            //var fixFactorLength = 0;
            //for (var i = 0; i < fixlistLength; i++) {
            //    if (sel.options[i].selected) {
            //        fixFactorLength += 1;
            //        obj[sel.options[i].value] = sel.options[i].value;
            //        if (fixcolumnNames != "") {
            //            fixcolumnNames = fixcolumnNames + '|' + sel.options[i].value;
            //        }
            //        else {
            //            fixcolumnNames = sel.options[i].value;
            //        }
            //    }
            //}

            for (var i = 0; i < fixlistLength; i++) {
                if (sel.options[i].selected) {
                    val_factors.push(sel.options[i].value);
                }
            }
            fixFactorLength = val_factors.length;
            fixcolumnNames = val_factors.join('|');

            var obj1 = {}
            var object = {}
            var dataObj = [];

            var sel1 = document.getElementById('<%= lstrangeFactors.ClientID %>'); //options: selected
            var rangelistLength = sel1.options.length;
            //var rangeFactorLength = 0;
            //for (var i = 0; i < rangelistLength; i++) {
            //    if (sel1.options[i].selected) {
            //        rangeFactorLength += 1;
            //        obj1[sel1.options[i].value] = sel1.options[i].value;
            //        if (rangecolumnNames != "") {
            //            rangecolumnNames = rangecolumnNames + '|' + sel1.options[i].value;
            //        }
            //        else {
            //            rangecolumnNames = sel1.options[i].value;
            //        }
            //    }
            //}
            var range_ff = []
            for (var i = 0; i < rangelistLength; i++) {
                if (sel1.options[i].selected) {
                    val_factors.push(sel1.options[i].value);
                    range_ff.push(sel1.options[i].value);
                }
            }
            rangeFactorLength = range_ff.length;
            debugger;
            //if (fixcolumnNames != "" || rangecolumnNames != "") {
            //    valueFactor = fixcolumnNames + "|" + rangecolumnNames;
            //} else {
            //    valueFactor = "";
            //}
            rangecolumnNames = range_ff.join('|');
            valueFactor = val_factors.join('|');
            document.getElementById("<%=txtvaluefactors.ClientID%>").value = valueFactor;
            document.getElementById("<%=txtareaFixfactor.ClientID%>").value = fixcolumnNames;
            document.getElementById("<%=txtareaRangefactor.ClientID%>").value = rangecolumnNames;
            document.getElementById("<%=txtactschno.ClientID%>").value = rangeFactorLength;
            //$('#txtvaluefactors').value = valueFactor;
            populateCalendar()
        }

        function fnValidate() {
            if ((document.getElementById("<%=txtactver.ClientID%>").value).length == 0) {
                alert("Please enter Action Version");
                return false;
            }
            if (fixFactorLength == 0) {
                alert("Please select fix factors");
                return false;
            }
            //if (rangeFactorLength == 0) {
            //    alert("Please select range factors");
            //    return false;
            //}
            if ((document.getElementById("<%=txtactver.ClientID%>").value).length == 0) {
                alert("Please enter Action Version");
                return false;
            }

            var e = document.getElementById("<%=ddlactbehtyp.ClientID%>");
            var optionSelIndex = e.options[e.selectedIndex].value;
            if (optionSelIndex == 0) {
                alert("Please select behaviour type.");
                return false;
            }
            if ((document.getElementById("<%=txtEffDFrom.ClientID%>").value).length == 0) {
                alert("Please select effective date");
                return false;
            }
            if ((document.getElementById("<%=txtExecOrder.ClientID%>").value).length == 0) {
                alert("Please enter execution order");
                return false;
            }

            var ddlstatus = document.getElementById("<%=ddlstatus.ClientID%>");
            var optionSelIndex2 = ddlstatus.selectedIndex;
            if (optionSelIndex2 == 0) {
                alert("Please select status");
                return false;
            }
            if (document.getElementById("<%=btnUpdate.ClientID%>").style.display == 'inline-block') {
                btnUpdateRprt()
            }
            if (document.getElementById("<%=btnSave.ClientID%>").style.display == 'inline-block') {
                btnSaveRprt()
            }
        }

        function btnSaveRprt() {
            debugger;
            var obj = {}
            var object = {}
            var dataObj = [];
            //var ActNo = getQueryVal('uid', window.location);
            object["ActNo"] = document.getElementById("<%=txtrulNo.ClientID%>").value;
            object["Rating"] = $('#<%=ddlrating.ClientID %>').val();
            object["Fixfactors"] = document.getElementById("<%=txtareaFixfactor.ClientID%>").value;
            object["Rangefactors"] = document.getElementById("<%=txtareaRangefactor.ClientID%>").value;
            object["Valuefactors"] = document.getElementById("<%=txtvaluefactors.ClientID%>").value;
            object["Actschkey"] = document.getElementById("<%=txtschmKey.ClientID%>").value;
            object["EffDateFrom"] = document.getElementById("<%=txtEffDFrom.ClientID%>").value;
            object["EffDateTo"] = document.getElementById("<%=txtEffDTo.ClientID%>").value;
            object["Excordr"] = $('#<%=txtExecOrder.ClientID %>').val();
            object["ActVer"] = document.getElementById("<%=txtactver.ClientID%>").value;
            object["ActBehTyp"] = $('#<%=ddlactbehtyp.ClientID %>').val();
            object["ActSchNo"] = document.getElementById("<%=txtactschno.ClientID%>").value;
            object["Status"] = $('#<%=ddlstatus.ClientID %>').val();

            dataObj.push(object);
            sendObj = {
                data: (dataObj)
            }

            $.ajax({
                type: "POST",
                url: "MstActCatgSU.aspx/actionSetupDetails",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    debugger;
                    if (response.d == "0") {
                        alert("Action category details has been saved successfully .");
                        location.reload(true);
                    }
                    else {
                        alert("Something went wrong.");
                    }
                },
                failure: function (response) {
                    alert("Something went wrong.");
                }
            });

        }


        function btnUpdateRprt() {
            debugger;
            var obj = {}
            var object = {}
            var dataObj = [];
            //var ActNo = getQueryVal('uid', window.location);
            object["ActNo"] = document.getElementById("<%=txtrulNo.ClientID%>").value;
            object["Rating"] = $('#<%=ddlrating.ClientID %>').val();
            object["Fixfactors"] = document.getElementById("<%=txtareaFixfactor.ClientID%>").value;
            object["Rangefactors"] = document.getElementById("<%=txtareaRangefactor.ClientID%>").value;
            object["Valuefactors"] = document.getElementById("<%=txtvaluefactors.ClientID%>").value;
            object["Actschkey"] = document.getElementById("<%=txtschmKey.ClientID%>").value;
            object["EffDateFrom"] = document.getElementById("<%=txtEffDFrom.ClientID%>").value;
            object["EffDateTo"] = document.getElementById("<%=txtEffDTo.ClientID%>").value;
            object["Excordr"] = $('#<%=txtExecOrder.ClientID %>').val();
            object["ActVer"] = document.getElementById("<%=txtactver.ClientID%>").value;
            object["ActBehTyp"] = $('#<%=ddlactbehtyp.ClientID %>').val();
            object["ActSchNo"] = document.getElementById("<%=txtactschno.ClientID%>").value;
            object["Status"] = $('#<%=ddlstatus.ClientID %>').val();

            dataObj.push(object);
            sendObj = {
                data: (dataObj)
            }

            $.ajax({
                type: "POST",
                url: "MstActCatgSU.aspx/actionSetupUpdateDetails",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    debugger;
                    if (response.d == "0") {
                        alert("Action category details has been updated successfully .");
                        location.reload(true);
                    }
                    else {
                        alert("Something went wrong.");
                    }
                },
                failure: function (response) {
                    alert("Something went wrong.");
                }
            });

        }


    </script>
    <%--Added Script Tag by DAksh for Reports End--%>

    <script>
        var action_data = null;
        function resetExecOrder() {
            $("#tblActions").sortable("refreshPositions")
        }

        function saveExecOrder() {
            debugger;
            var toArray = $("#tblActions").sortable('toArray');
            var rowArray = toArray.map(function (x, i) {
                let data = $($("#" + x)[0]).data('obj');
                data["NEW_EXEC_ORDER"] = (i + 1)
                return data;
            })

            $("#iLoading_new").show();

            var exec_data = {
                data: rowArray
            }
            $.ajax({
                url: "MstActCatgSU.aspx/SaveExecutionOrder",
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(exec_data),
                async: false,
                dataType: 'json',
                success: function (resp) {
                    $("#iLoading_new").hide();
                    var d = resp.d
                    if (d["status"] == '0') {
                        alert('Execution order for Scheme Keys updated sucessfully .')
                        closePopup();
                        setTimeout(function () {
                            window.location.href = window.location.href
                        }, 1000);
                        //setTimeout(, 1000)
                    }
                    else {
                        alert(d["message"]);
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
            var Action_no = $("#<%= txtrulNo.ClientID %>").val();
            var data = {
                "Action_no": Action_no,
            }
            $.ajax({
                url: "MstActCatgSU.aspx/GetActionSchemeKeyData",
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
                            + '<th>Val Factor</th>'
                            + '<th>Updated Execution Order</th>'
                            + '</tr></thead>'
                        var data = d['data'];
                        action_data = data;
                        var datarows = "<tbody>" + data.map(function (x, i) {
                            return "<tr id='sort_row" + i + "' data-obj='" + JSON.stringify(x) + "'>"
                                        + '<td>' + x["EXCTN_ORDR"] + '</td>'
                                        + '<td>' + x["VAL_FCTR"] + '</td>'
                                        + '<td>' + (i +1) + '</td> </tr>'
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


<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="KPIMapBseSrcFormulaPopUp.aspx.cs" Inherits="Application_Isys_Saim_KPIMapBseSrcFormulaPopUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />

    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <%--Added References by Daksh for Reports Start--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />

    <%--Added References by DAksh for Reports End--%>
    <script type="text/javascript">

        function ShowReqDtl1(divName, btnName) {
            debugger
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ////ShowError(err.description);
            }
        }



    </script>

    <style type="text/css">
        /*td {
            border: 1px solid black;
        }*/

        .footable > tbody > tr > td, .footable > thead > tr > th {
            border-left: 1px solid ;
            border-top: 1px solid;
            padding: 10px;
            text-align: left;
        }

        .footable > tbody > tr > td{
            width:55px;
        }

        .footable > tbody > tr > td:hover{
            background-color:lavender;
        }

        .noColor {
            background-color: Transparent;
            background-repeat: no-repeat;
            border: 1px solid;
            cursor: pointer;
            overflow: hidden;
            outline: none;
        }

        input[type=button]:hover {
            background-color: lavender;
            background-repeat: no-repeat;
            border: none;
            cursor: pointer;
            overflow: hidden;
            outline: none;
        }

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
            text-align: left;
            padding: 3px;
            height: 40px;
            background-color: #F04E5E;
            color: White;
            white-space: nowrap;
        }
    </style>

    <style>
        /* Style the tab */
        .tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #e6f7ff;
        }

            /* Style the buttons inside the tab */
            .tab button {
                background-color: inherit;
                float: left;
                border: none;
                outline: none;
                cursor: pointer;
                padding: 2px 90px;
                transition: 0.3s;
                font-size: 13px;
                font-family: Tahoma;
                font-weight: bold;
            }

                /* Change background color of buttons on hover */
                .tab button:hover {
                    background-color: #ddd;
                }

                /* Create an active/current tablink class */
                .tab button.active {
                    background-color: #ccc;
                }

        /* Style the tab content */
        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }
    </style>


    <style type="text/css">
        .nav-tabs {
            border-bottom: 2px solid #DDD;
        }

            .nav-tabs > li.active > a, .nav-tabs > li.active > a:focus, .nav-tabs > li.active > a:hover {
                border-width: 0;
            }

            .nav-tabs > li > a {
                border: none;
                color: #666;
            }

                .nav-tabs > li.active > a, .nav-tabs > li > a:hover {
                    border: none;
                    color: #4285F4 !important;
                    background: transparent;
                }

                .nav-tabs > li > a::after {
                    content: "";
                    background: #4285F4;
                    height: 2px;
                    position: absolute;
                    width: 100%;
                    left: 0px;
                    bottom: -1px;
                    transition: all 250ms ease 0s;
                    transform: scale(0);
                }

            .nav-tabs > li.active > a::after, .nav-tabs > li:hover > a::after {
                transform: scale(1);
            }

        .tab-nav > li > a::after {
            background: #21527d none repeat scroll 0% 0%;
            color: #fff;
        }

        .tab-pane {
            padding: 15px 0;
        }

        .tab-content {
            padding: 20px;
        }

        .card {
            background: #FFF none repeat scroll 0% 0%;
            box-shadow: 0px 1px 3px rgba(0, 0, 0, 0.3);
            margin-bottom: 30px;
        }

        body {
            /*background: #EDECEC;*/
            /*padding: 50px;*/
        }
    </style>

    <style type="text/css">
        .pad {
            text-align: center !important;
        }

        .pad1 {
            padding-left: 0.5% !important;
        }
    </style>

    <style type="text/css">
        a:hover, a:focus {
                outline: none;
                text-decoration: none;
        }

        .tab .nav-tabs {
                border: none;
                margin-bottom: 10px;
        }

            .tab .nav-tabs li a {
                    padding: 10px 20px;
                    margin-right: 15px;
                    background: #f8333c;
                    font-size: 17px;
                    font-weight: 600;
                    color: #fff;
                    text-transform: uppercase;
                    border: none;
                    border-top: 3px solid #f8333c;
                    border-bottom: 3px solid #f8333c;
                    border-radius: 0;
                    overflow: hidden;
                    position: relative;
                    transition: all 0.3s ease 0s;
            }

                .tab .nav-tabs li.active a,
                .tab .nav-tabs li a:hover {
                        border: none;
                        border-top: 3px solid #f8333c;
                        border-bottom: 3px solid #f8333c;
                        background: #fff;
                        color: #f8333c;
                }

                .tab .nav-tabs li a:before {
                        content: "";
                        border-top: 15px solid #f8333c;
                        border-right: 15px solid transparent;
                        border-bottom: 15px solid transparent;
                        position: absolute;
                        top: 0;
                        left: -50%;
                        transition: all 0.3s ease 0s;
                }

                .tab .nav-tabs li a:hover:before,
                .tab .nav-tabs li.active a:before {
                    left: 0;
                }

                .tab .nav-tabs li a:after {
                        content: "";
                        border-bottom: 15px solid #f8333c;
                        border-left: 15px solid transparent;
                        border-top: 15px solid transparent;
                        position: absolute;
                        bottom: 0;
                        right: -50%;
                        transition: all 0.3s ease 0s;
                }

                .tab .nav-tabs li a:hover:after,
                .tab .nav-tabs li.active a:after {
                    right: 0;
                }

        .tab .tab-content {
                padding: 20px 30px;
                border-top: 3px solid #384d48;
                border-bottom: 3px solid #384d48;
                font-size: 17px;
                color: #384d48;
                letter-spacing: 1px;
                line-height: 30px;
                position: relative;
        }

            .tab .tab-content:before {
                    content: "";
                    border-top: 25px solid #384d48;
                    border-right: 25px solid transparent;
                    border-bottom: 25px solid transparent;
                    position: absolute;
                    top: 0;
                    left: 0;
            }

            .tab .tab-content:after {
                    content: "";
                    border-bottom: 25px solid #384d48;
                    border-left: 25px solid transparent;
                    border-top: 25px solid transparent;
                    position: absolute;
                    bottom: 0;
                    right: 0;
            }

            .tab .tab-content h3 {
                    font-size: 24px;
                    margin-top: 0;
            }

        @media only screen and (max-width: 479px) {
                 .tab .nav-tabs li {
                        width: 100%;
                        text-align: center;
                        margin-bottom: 15px;
            }
        }

        .disablepage {
            display: none;
        }

        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #F04E5E;
            /*color: #337ab7;*/
        }

        .imgheight {
            display: block;
            max-width: 100%;
            height: 50px;
        }

        .textalign th {
            padding-left: 42%;
        }

        .modal-dialog {
            position: relative;
            display: table;
            overflow-y: auto;
            overflow-x: auto;
            width: auto;
            min-width: 50px;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updRl" runat="server">
        <ContentTemplate>
            <center>
                <div id="div8" runat="server" style="padding: 25px;" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblmdlTblName" Text="Table Name" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlmdlTblName" runat="server" CssClass="form-control" TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="ddlmdlTblName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label2" Text="Operation Type" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlmdlOpType" runat="server" CssClass="form-control" TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="ddlmdlOpType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            
                        </div>

                     <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblmdlColName" Text="Column Name" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddltmdlColName" runat="server" CssClass="form-control" TabIndex="4">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                         </div>

                        <div id="div9" runat="server" class="row" style="margin-top: 12px;text-align:center;">


                            <div class="col-sm-12">
                                <asp:LinkButton ID="lnkbtnModalSave" runat="server" CssClass="btn btn-sample" TabIndex="17"  OnClientClick="return fnValidateModal();" OnClick="lnkbtnModalSave_Click" > <%-- OnClientClick="return fnValidateModal();"--%>
                            <span class="glyphicon glyphicon-plus" style="color: White;"></span> Save
                                </asp:LinkButton>

                                <asp:LinkButton ID="lnkbtnModalClear" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="lnkbtnModalClear_Click">
                            <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                                </asp:LinkButton>

                                <asp:LinkButton ID="lnkbtnModalCancel" runat="server" CssClass="btn btn-sample" TabIndex="17"  OnClientClick="doCancel()">
                            <span class="glyphicon glyphicon-remove" style="color: White;"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div id="div10" runat="server" style="width: 100%;text-align:center;" class="table-scrollable">
                            <div id="div11" runat="server" style="width: 98%; padding:10px; overflow-x: scroll">
                                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvMODAL" runat="server" AutoGenerateColumns="false" Width="100%"
                                            AllowPaging="true" PageSize="10" AllowSorting="True"
                                            CssClass="footable" OnSorting="gvMODAL_Sorting" OnRowDataBound="gvMODAL_RowDataBound"
                                            ShowHeader="true">
                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" />
                                            <EmptyDataTemplate>
                                                <asp:Label ID="lblerror" Text="No records found" ForeColor="Red"
                                                    CssClass="control-label" runat="server" />
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Table Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                                    SortExpression="TBL_desc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSTBL_NAME" Text='<%# Bind("TBL_desc") %>' runat="server" />
                                                         <asp:HiddenField ID="hdnSEQNO" runat="server" Value='<%# Eval("SEQNO") %>' />
                                                        <asp:HiddenField ID="hdnTblNm" runat="server" Value='<%# Eval("TBL_NAME") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Column Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                                    SortExpression="COL_NAME">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCOL_NAME" Text='<%# Bind("COL_NAME") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Operation Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                                    SortExpression="OpTypeDesc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOpTypeDesc" Text='<%# Bind("OpTypeDesc") %>' runat="server" />
                                                         <asp:HiddenField ID="hdnOpType" runat="server" Value='<%# Eval("OPRTN_TYPE") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PARAMETER" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                                    SortExpression="PARAMETER">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPARAMETER" Text='<%# Bind("PARAMETER") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Source Table Column" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                                    SortExpression="SRC_TBL_COL">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRC_TBL_COL" Text='<%# Bind("SRC_TBL_COL") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="FORMULA" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                                    SortExpression="FORMULA">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFORMULA" Text='<%# Bind("FORMULA") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <%--<HeaderStyle CssClass="gridview th" />--%>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkGRIDDel" runat="server" Text="Delete" 
                                                        OnClientClick="return confirm('Are you sure you want to Delete?');" OnClick="lnkGRIDDel_Click"></asp:LinkButton>
                                                </ItemTemplate>
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
                                            <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btmModalprev" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btmModalprev_Click" />
                                                    <asp:TextBox runat="server" ID="txtmodalPage" Text="1" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btmModalnxt" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btmModalnxt_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="width:100%;">
                <div class="col-md-12">
                    <div class="card">
                        <ul id="myTab" class="nav nav-tabs">
                            <li id="liConcat" style="display:none"><a id="tabConcat" onclick="return fnSetTabs('1',0);" style="font-weight: bold;">Concatenate </a></li>
                            <li id="liMathOP" style="display:none"><a id="tabMathOP" onclick="return fnSetTabs('2',0);" style="font-weight: bold;">Mathematical Operation</a></li>
                        </ul>
                        <asp:UpdatePanel runat="server" RenderMode="Inline">
                            <ContentTemplate>
                                <div id ="divConcatenate" class="tab-pane active" runat="server" style="display:none">
                                     <div id="DivPnlHdConcat" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divCalcBody','');return false;">
                                        <div class="row">
                                            <div class="col-sm-10" style="text-align: left">
                                            <asp:Label ID="lblPnlHd" Text="Formula for the Concatenate" Font-Size="19px" runat="server" />
                                            </div>
                                            <div class="col-sm-2">
                                           <%-- <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="LinkButton1_Click" >
                            <span class="glyphicon glyphicon-plus" style="color: White;"></span> Define
                                </asp:LinkButton>
                                        </div>
                                    <div id="div3" runat="server" style="padding: 25px;" class="panel-body">
                                        <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-6" style="text-align: left">
                                            <div class="table-container" id="divTableConcat">

                                            </div>
                                        </div>
                                        <div class="col-sm-6" style="text-align: left">
                                            <asp:TextBox ID="txtConcat" placeholder="Formula" TextMode="MultiLine" rows="10" Columns="40" runat="server" ToolTip = "" CssClass="form-control" TabIndex="1"/>
                                        </div>
                                    </div>
                                        <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-6" style="text-align: left">
                                            
                                        </div>
                                        <div class="col-sm-6" style="text-align: left">
                                            <asp:LinkButton ID="lnbtnUpdConcat" runat="server" style="display:none;"  CssClass="btn btn-sample" TabIndex="17" OnClick="lnbtnUpdConcat_Click"
                                                OnClientClick="return fnValidateConcatTxt();">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Update
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="lnbtnSaveConcat" runat="server" style="display:inline-block;" Enabled="false" CssClass="btn btn-sample" TabIndex="17" OnClick="lnbtnSaveConcat_Click"
                                                OnClientClick="return fnValidateConcatTxt();">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Save
                                            </asp:LinkButton>
                                        
                                            <asp:LinkButton ID="lnbtnClrConcat" runat="server" CssClass="btn btn-sample" TabIndex="17" onclick="lnbtnClrConcat_Click">
                                                <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="lnbtnBckSpConcat" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClientClick="backSpaceConcate();return false;">
                                                <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color: White;"></span> Backspace
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                    </div>
                                </div>
                                <div id ="divMathOpr" class="tab-pane active" runat="server" style="display:none">
                                    <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divCalcBody','');return false;">
                                        <div class="row">
                                            <div class="col-sm-10" style="text-align: left">
                                            <asp:Label ID="Label1" Text="Formula for the calculation" Font-Size="19px" runat="server" />
                                            </div>
                                            <div class="col-sm-2">
                                           <%-- <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="LinkButton2_Click" >
                            <span class="glyphicon glyphicon-plus" style="color: White;"></span> Define
                                </asp:LinkButton>
                                        </div>
                                    <div id="divCalcBody" runat="server" style="padding: 25px;" class="panel-body">
                                        <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-6" style="text-align: left">
                                            <div class="table-container" id="divTable">

                                            </div>
                                        </div>
                                        <div class="col-sm-6" style="text-align: left">
                                            <asp:TextBox ID="txtFormCALC" placeholder="Formula" TextMode="MultiLine" rows="10" Columns="40" runat="server" ToolTip = "" CssClass="form-control" TabIndex="1"/>
                                        </div>
                                    </div>
                                        <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-6" style="text-align: left">
                                            
                                        </div>
                                        <div class="col-sm-6" style="text-align: left">
                                            <asp:LinkButton ID="lnkbtnCalcUpd" runat="server" style="display:none;"  CssClass="btn btn-sample" TabIndex="17" OnClick="lnkbtnCalcUpd_Click" OnClientClick="return fnValidateCalcTxt();">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Update
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="lnkbtnCalc" runat="server" style="display:inline-block;" Enabled="false" CssClass="btn btn-sample" TabIndex="17" OnClick="lnkbtnCalc_Click" OnClientClick="return fnValidateCalcTxt();">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Save
                                            </asp:LinkButton>
                                        
                                            <asp:LinkButton ID="lnkbtnCalcClr" runat="server" CssClass="btn btn-sample" TabIndex="17" onclick="lnkbtnCalcClr_Click">
                                                <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="lnkbtnCalcCancel" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClientClick="backSpace();return false;">
                                                <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color: White;"></span> Backspace
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                    </div>
                                </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
                    </div>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdnTabIndex" runat="server" />
    <asp:HiddenField ID="hdnPCount" runat="server" />
    <script src="../../../../assets/scripts/jquery.min.js"></script>
    <script src="../../../../assets/scripts/bootstrap.min.js"></script>
    <script src="../../../../assets/scripts/bootstrap-multiselect.js"></script>
    <script>
        var PCount;
        function fnValidateModal() {
            debugger;
            var ddlmdlTblName = document.getElementById("<%=ddlmdlTblName.ClientID%>");
            var optionSelIndex = ddlmdlTblName.options[ddlmdlTblName.selectedIndex].value;
            if (optionSelIndex == 0) {
                alert("Please Select Table Name.");
                return false;
            }
            var ddlmdlOpType = document.getElementById("<%=ddlmdlOpType.ClientID%>");
            var optionSelIndex = ddlmdlOpType.options[ddlmdlOpType.selectedIndex].value;
            if (optionSelIndex == 0) {
                alert("Please Select Operation Type.");
                return false;
            }

            var ddltmdlColName = document.getElementById("<%=ddltmdlColName.ClientID%>");
            var optionSelIndex = ddltmdlColName.options[ddltmdlColName.selectedIndex].value;
            if (optionSelIndex == 0) {
                alert("Please Select Column Name.");
                return false;
            }
        }

        function fnValidateCalcTxt() {
            debugger;
            if (document.getElementById("<%=txtFormCALC.ClientID%>").value == "") {
                alert("Formula for Mathematical Operation cannot be blank.");
                return false;
            }
        }

        function fnValidateConcatTxt() {
            debugger;
            if (document.getElementById("<%=txtConcat.ClientID%>").value == "") {
                alert("Formula for Conactenation cannot be blank.");
                return false;
            }
        }

        function doCancel() {
            debugger;
          
            //$(parent.document.getElementById('BtnGrp')).trigger('click');
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            //parent.location.href = parent.location.href
        }

          function doCancelClick() {
              debugger;
            //  window.opener.document.getElementById('ctl00_ContentPlaceHolder1_BtnGrp').click();
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            //parent.location.href = parent.location.href
        }

        //$(document).ready(function () {
        //    fnSetTabs('2',0);
        //});

        function fnSetTabs(strTabIndex, Count) {
            debugger;
            if (strTabIndex == '1') {
                document.getElementById("ctl00_ContentPlaceHolder1_divConcatenate").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_divMathOpr").style.display = "none";
                document.getElementById("liConcat").className = "active";
                document.getElementById("liMathOP").classList.remove("active");
                document.getElementById("ctl00_ContentPlaceHolder1_hdnTabIndex").value = "1";
                BindTableConcat(Count)
            }
            if (strTabIndex == '2') {
                document.getElementById("ctl00_ContentPlaceHolder1_divConcatenate").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_divMathOpr").style.display = "block";
                document.getElementById("liConcat").classList.remove("active");
                document.getElementById("liMathOP").className = "active";
                document.getElementById("ctl00_ContentPlaceHolder1_hdnTabIndex").value = "2";
                PCount = Count
                BindTable(Count)
            }

            if (strTabIndex == '11') {
                document.getElementById("ctl00_ContentPlaceHolder1_divConcatenate").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_divMathOpr").style.display = "none";
                document.getElementById("liConcat").className = "active";
                document.getElementById("liMathOP").classList.remove("active");
                document.getElementById("ctl00_ContentPlaceHolder1_hdnTabIndex").value = "11";

                document.getElementById("liMathOP").style.display = "none"
                document.getElementById("liConcat").style.display = "block"
                BindTableConcat(Count)

            }
            if (strTabIndex == '22') {
                document.getElementById("ctl00_ContentPlaceHolder1_divConcatenate").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_divMathOpr").style.display = "block";
                document.getElementById("liConcat").classList.remove("active");
                document.getElementById("liMathOP").className = "active";
                document.getElementById("ctl00_ContentPlaceHolder1_hdnTabIndex").value = "22";
                document.getElementById("liConcat").style.display = "none"
                document.getElementById("liMathOP").style.display = "block";
                PCount = Count
                BindTable(Count)
            }

        }

        function pageLoad() {
        }
        

        function BindTable(ParamCount) {
            debugger;
            var html = ''
            html += '<table class="footable" style="width:60%">'
            html += '<tbody>'

            html += '<tr>'
            html += '<td class="noColor" onclick="addText(this);">1</td>';
            html += '<td class="noColor" onclick="addText(this);">2</td>';
            html += '<td class="noColor" onclick="addText(this);">3</td>';
            html += '<td class="noColor" onclick="addText(this);">4</td>';
            html += '</tr>'

            html += '<tr>'
            html += '<td class="noColor" onclick="addText(this);">5</td>';
            html += '<td class="noColor" onclick="addText(this);">6</td>';
            html += '<td class="noColor" onclick="addText(this);">7</td>';
            html += '<td class="noColor" onclick="addText(this);">8</td>';
            html += '</tr>'

            html += '<tr>'
            html += '<td class="noColor" onclick="addText(this);">9</td>';
            html += '<td class="noColor" onclick="addText(this);">0</td>';
            html += '<td class="noColor" onclick="addText(this);">/</td>';
            html += '<td class="noColor" onclick="addText(this);">=</td>';
            html += '</tr>'

            html += '<tr>'
            html += '<td class="noColor" onclick="addText(this);">x</td>';
            html += '<td class="noColor" onclick="addText(this);">-</td>';
            html += '<td class="noColor" onclick="addText(this);">%</td>';
            html += '<td class="noColor" onclick="addText(this);">+</td>';
            html += '</tr>'

            for (var i = 1; i <= ParamCount; i++) {
                if (i == 1 || 2 == (i % 4 + 1)) {
                    html += '<tr>'
                }
                html += '<td class="noColor" onclick="addText(this);">P' + (i) + '</td>';

                if (1 == (i % 4 + 1)) {
                    html += '</tr>'
                }
            }
            html += '</tbody>'
            html += '</table>'


            document.getElementById("divTable").innerHTML = html;
        }

        function BindTableConcat(ParamCount) {
            debugger;
            var html = ''
            html += '<table class="footable" style="width:30%">'
            html += '<tbody>'

            html += '<tr>'
            html += '<td class="noColor" onclick="addTextConcat(this);">+</td>';
            html += '<td class="noColor" onclick="addTextConcat(this);">,</td>';
           
            html += '</tr>'

            html += '<tr>'
            html += '<td class="noColor" onclick="addTextConcat(this);">\'</td>';
            html += '<td class="noColor" onclick="addTextConcat(this);">|</td>';
            html += '</tr>'

           

            for (var i = 1; i <= ParamCount; i++) {
                if (i == 1 || 2 == (i % 4 + 1)) {
                    html += '<tr>'
                }
                html += '<td class="noColor" onclick="addTextConcat(this);">P' + (i) + '</td>';

                if (1 == (i % 4 + 1)) {
                    html += '</tr>'
                }
            }
            html += '</tbody>'
            html += '</table>'


            document.getElementById("divTableConcat").innerHTML = html;
        }

        function addText(text) {
            debugger;
            //alert(text.innerHTML);
            var txtFormCALC = document.getElementById('<%= txtFormCALC.ClientID %>');
            txtFormCALC.value += text.innerHTML;
        }

        function addTextConcat(text) {
            debugger;
            //alert(text.innerHTML);
            var txtConcat = document.getElementById('<%= txtConcat.ClientID %>');
            txtConcat.value += text.innerHTML;
        }

        function clearText() {
            var txtFormCALC = document.getElementById('<%= txtFormCALC.ClientID %>');
            txtFormCALC.value = "";

        }

        function backSpace() {
            debugger;
            var txtFormCALC = document.getElementById('<%= txtFormCALC.ClientID %>');
            txtFormCALC.value = txtFormCALC.value.slice(0, -1);
           
        }
        
        function backSpaceConcate() {
            debugger;
            var txtConcat = document.getElementById('<%= txtConcat.ClientID %>');
            txtConcat.value = txtConcat.value.slice(0, -1);
          
        }

    </script>
</asp:Content>


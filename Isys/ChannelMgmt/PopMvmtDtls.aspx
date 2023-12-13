<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopMvmtDtls.aspx.cs" Inherits="Application_Isys_ChannelMgmt_PopMvmtDtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />

    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../PSSNEW/Script/COMM/CBFRMCommon.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../PSSNEW/Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: ##f04e5e;
            color: white;
        }
    </style>
    <script type="text/javascript">
        function doCancel(flag) {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (flag == 1) {
                window.parent.document.getElementById("btn").click();
            }
        }

        function validation() {
            //            if(document.getElementById("")
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

        function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
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
       
    </script>
    <asp:ScriptManager ID="scr" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="divmkchkrhdr" runat="server">
                <div class="panel" style="border-style:none; margin:40px !important">
                    <div id="div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divsubchk','Span1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblmvmthdr" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divsubchk" runat="server" class="panel-body">
                        <div id="divmkchkrtrf" runat="server" visible="false" class="row" style="margin-bottom: 10px;">
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="Label1" Text="Transfer Type" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-md-9">
                                <asp:UpdatePanel ID="updtrftyp" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBoxList ID="rblTrfTyp" runat="server" CssClass="radiobtn" AutoPostBack="True"
                                            Width="55%" CellPadding="2" CellSpacing="2" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblTrfTyp_SelectedIndexChanged">
                                        </asp:CheckBoxList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="divmkchkrmvmt" runat="server" class="panel" style="border-style:none;">
                            <%--marker div start--%>
                            <div id="div3" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div5','Span2');return false;"
                                >
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <%--<span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>--%>
                                        <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="MAKER DETAILS"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="div5" runat="server" class="panel-body">
                                <div class="row" style="margin-bottom: 2%;">
                                    <div class="col-md-3" style="text-align: left;">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chkMaker" runat="server" OnCheckedChanged="chkMaker_CheckedChanged"
                                                    AutoPostBack="true" />
                                                <asp:Label ID="Label4" Text="Maker" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
 
                                <%--div to be shown on checking - end--%>
                                <div id="divmkchkr2" runat="server" visible="false">
                                    <%--gridview to be shown on checking - start--%>
                                    <asp:GridView AllowSorting="True" ID="MakerDetails" runat="server" CssClass="footable"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                        OnSorting="MakerDetails_Sorting" 
                                        OnRowDataBound="MakerDetails_RowDataBound"  >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRow" />
                                        <HeaderStyle CssClass="gridview" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                        
                                        <Columns>
                                            <%--Edited by vijendra on 06-12-2013 to create these Boundfields as a template fields Start--%>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Maker Type" SortExpression="ParamDesc">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnUserType" runat="server" Value='<%# Eval("UserType") %>' /> 
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("ParamDesc") %>' CommandArgument='<%# Eval("ParamDesc") %>'></asp:Label>
                                                    <asp:Label ID="lblerrmsg" runat="server" Visible="false"/>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="BizSrcDesc" HeaderText="Hierarchy Name" 
                                                Visible="true">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnChannel" runat="server" Value='<%# Eval("Channel") %>' /> 
                                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("BizSrcDesc") %>' CommandArgument='<%# Eval("BizSrcDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Sub Class" SortExpression="ChnClsDesc">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnSubChannel" runat="server" Value='<%# Eval("SubChannel") %>' />
                                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("ChnClsDesc") %>' CommandArgument='<%# Eval("ChnClsDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Based On" SortExpression="BasedOnDesc">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnBasedOn" runat="server" Value='<%# Eval("BasedOn") %>' />
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("BasedOnDesc") %>' CommandArgument='<%# Eval("BasedOnDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Relation Member Type"
                                                SortExpression="MemTypeDesc">
                                                <ItemTemplate>
                                                     <asp:HiddenField ID="hdnMemOrLevelType" runat="server" Value='<%# Eval("MemOrLevelType") %>' />
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("MemTypeDesc") %>' CommandArgument='<%# Eval("MemTypeDesc") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnEffDate" runat="server" Value='<%# Eval("EffectiveDate") %>' />
                                                    <asp:HiddenField ID="hdnCseDate" runat="server" Value='<%# Eval("CeaseDate") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False" ></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <div>
                                                        <i class="fa fa-edit"></i>&nbsp;
                                                        <asp:LinkButton ID="EditBtn" runat="server" OnClick="Edit_Click"></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="false"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <div>
                                                        <i class="fa fa-edit"></i>&nbsp;
                                                        <asp:LinkButton ID="DeleteBtn" runat="server" Text='<%# Eval("CeaseDateDesc") %>' OnClick="Delete_Click"></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="false" Width="10%"></ItemStyle>
                                            </asp:TemplateField>
                                            <%--Created by vijendra on 06-12-2013 to create these Boundfields as a template fields End--%>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12" style="text-align: center">
                                            <%--<asp:Button ID="btnAddNew" runat="server" CssClass="btn blue" 
                                OnClick="btnAddNew_Click" TabIndex="43" Text="ADD NEW"  
                                Width="100px" />--%>
                                            <asp:LinkButton ID="btnAddNew" runat="server" CssClass="btn btn-primary" CausesValidation="false"
                                                OnClick="btnAddNew_Click" TabIndex="43">
                                  <span class="glyphicon glyphicon-plus" style="color:White"> </span> Add New
               
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div id="div2" runat="server" class="panel" style="border-style:none;">
                            <div id="div6" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div7','Span3');return false;"
                                >
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <%--<span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>--%>
                                        <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="CHECKER DETAILS"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="div7" runat="server" class="panel-body">
                                <div id="div1" runat="server" class="row" style="margin-bottom: 2%;">
                                    <div class="col-md-3" style="text-align: left;">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chkChecker" runat="server" AutoPostBack="true" OnCheckedChanged="chkChecker_CheckedChanged" />
                                                <asp:Label Text="Checker" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="divlblchkr" runat="server" class="col-md-3" style="text-align: left" visible="false">
                                        <asp:Label Text="Number of checkers" runat="server" />
                                        <span style="color: #ff0000"> *</span>
                                    </div>
                                    <div id="divtxtchkr" runat="server" class="col-md-3" visible="false">
                                        <asp:DropDownList ID="ddlnochkrs" runat="server" AutoPostBack="true" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlnochkrs_OnSelectedIndexChanged">
                                            <asp:ListItem Text="Select" Value="" />
                                            <asp:ListItem Text="1" Value="1" />
                                            <asp:ListItem Text="2" Value="2" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                                    <ContentTemplate>
                                        <asp:GridView ID="grdMKCHKR" runat="server" AllowSorting="True" GridLines="None"
                                            Width="100%" ShowHeader="false" AllowPaging="true" AutoGenerateColumns="false"
                                            OnRowDataBound="grdMKCHKR_RowDataBound">
                                            <RowStyle></RowStyle>
                                            <%--<PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <RowStyle CssClass="GridViewRow"></RowStyle>--%>
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black">
                                                    <ItemTemplate>
                                                        <div class="panel panel-success" style="width: 100%; margin-left: 0px; margin-right: 0px;">
                                                            <div id="div4" runat="server" class="panel-heading subHeader" style="background-color: #EDF1cc !important">
                                                                <div class="row">
                                                                    <div class="col-sm-10" style="text-align: left">
                                                                        <span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>
                                                                        <asp:Label ID="lblmvtitle" runat="server" CssClass="control-label" Text="Checker Details" />
                                                                        <asp:HiddenField ID="hdnmvtitle" runat="server" Value='<%#Bind("ParamValue")%>' />
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <span id="Span1" runat="server" class="glyphicon glyphicon-resize-full" style="float: right;
                                                                            color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="divMvmt" runat="server" class="panel-body" style="display: block">
                                                                <asp:GridView AllowSorting="True" ID="CheckerDetails" runat="server" CssClass="footable"
                                                                    AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1" OnRowDataBound="CheckerDetails_RowDataBound" OnSorting="MakerDetails_Sorting">
                                                                    <FooterStyle CssClass="GridViewFooter" />
                                                                    <RowStyle CssClass="GridViewRow" />
                                                                    <HeaderStyle CssClass="gridview" />
                                                                    <PagerStyle CssClass="disablepage" />
                                                                    <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                                                    <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Checker Type" SortExpression="ParamDesc">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("ParamDesc") %>' CommandArgument='<%# Eval("ParamDesc") %>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnUserType" runat="server" Value='<%# Eval("UserType") %>' />
                                                                                <asp:Label ID="lblerrmsg" runat="server" Visible="false"/>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField SortExpression="BizSrcDesc" HeaderText="Hierarchy Name" 
                                                                            Visible="true">
                                                                            <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnChannel" runat="server" Value='<%# Eval("Channel") %>' />
                                                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("BizSrcDesc") %>'
                                                                                    CommandArgument='<%# Eval("BizSrcDesc") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Sub Class" SortExpression="ChnClsDesc">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("ChnClsDesc") %>' CommandArgument='<%# Eval("ChnClsDesc") %>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnSubChannel" runat="server" Value='<%# Eval("SubChannel") %>' />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Based On" SortExpression="BasedOnDesc">
                                                                            <ItemTemplate>
                                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("BasedOnDesc") %>'
                                                                                    CommandArgument='<%# Eval("BasedOnDesc") %>'></asp:Label>
                                                                                    <asp:HiddenField ID="hdnBasedOn" runat="server" Value='<%# Eval("BasedOn") %>' />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Relation Member Type"
                                                                            SortExpression="MemTypeDesc">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("MemTypeDesc") %>' CommandArgument='<%# Eval("MemTypeDesc") %>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnMemOrLvlType" runat="server" Value='<%# Eval("MemOrLevelType") %>' />
                                                                                <asp:HiddenField ID="hdnEffDate" runat="server" Value='<%# Eval("EffectiveDate") %>' />
                                                                                <asp:HiddenField ID="hdnCseDate" runat="server" Value='<%# Eval("CeaseDate") %>' />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False" ></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Action" >
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <i class="fa fa-edit"></i>&nbsp;
                                                                                    <asp:LinkButton ID="EditBtn" runat="server" OnClick="EditChecker_Click"></asp:LinkButton>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="false"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <%--Created by vijendra on 06-12-2013 to create these Boundfields as a template fields End--%>
                                                                        <asp:TemplateField HeaderText="Action">
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <i class="fa fa-edit"></i>&nbsp;
                                                                                    <asp:LinkButton ID="DeleteChecker" runat="server" Text='<%# Eval("CeaseDateDesc") %>'
                                                                                        OnClick="DeleteChecker_Click"></asp:LinkButton>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="false" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                                <br/>
                                                                <div class="row">
                                                                    <div class="col-md-12" style="text-align: center">
                                                                        <%--<asp:Button ID="btnAddNew" runat="server" CssClass="btn blue" 
                                OnClick="btnAddNew_Click" TabIndex="43" Text="ADD NEW"  
                                Width="100px" />--%>
                                                                        <asp:LinkButton ID="btnAddNewCh" runat="server" CssClass="btn btn-primary" CausesValidation="false"
                                                                            OnClick="btnAddNewCh_Click" TabIndex="43">
                                                                         <span class="glyphicon glyphicon-plus" style="color:White"> </span> Add New
               
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                    </ItemTemplate>
                                                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="div9" runat="server" style="width: 100%;">
                            <div class="row" id="tbladdcntst" runat="server">
                                <div class="col-md-12" style="text-align: center">
                                    <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-primary" CausesValidation="false"
                                        TabIndex="43" OnClick="btnUpdate_Click">
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Save
                                    </asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="btnCancel" runat="server" style="background-color:#FFF;color:#f04e5e; width:85px !important" CssClass="btn btn-danger" CausesValidation="false"
                                        OnClick="btnCancel_Click" TabIndex="43">
                                  <span class="glyphicon glyphicon-remove" style="color:#f04e5e"> </span> Cancel
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

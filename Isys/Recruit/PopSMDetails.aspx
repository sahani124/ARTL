<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopSMDetails.aspx.cs" Inherits="Application_ISys_Recruit_PopSMDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">
        function doSelect(args1, args2, args3, args4, args5, args6, args7, args8, args9, args10, args11, args12, args13, args14, args15) {
            debugger;
            window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').value = args2;
            window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').value = args3;
            window.parent.document.getElementById('<%=Request.QueryString["Field3"].ToString()%>').value = args1;
            window.parent.document.getElementById('<%=Request.QueryString["Field4"].ToString()%>').value = args6;
            window.parent.document.getElementById('<%=Request.QueryString["Field5"].ToString()%>').value = args7;
            window.parent.document.getElementById('<%=Request.QueryString["Field6"].ToString()%>').value = args8;
            window.parent.document.getElementById('<%=Request.QueryString["Field7"].ToString()%>').value = args9;
            window.parent.document.getElementById('<%=Request.QueryString["Field8"].ToString()%>').value = args10;
            window.parent.document.getElementById('<%=Request.QueryString["Field11"].ToString()%>').value = args11;
            window.parent.document.getElementById('<%=Request.QueryString["Field12"].ToString()%>').value = args12;
            window.parent.document.getElementById('<%=Request.QueryString["Field13"].ToString()%>').value = args13;
            window.parent.document.getElementById('<%=Request.QueryString["Field14"].ToString()%>').value = args14;
            window.parent.document.getElementById('<%=Request.QueryString["Field15"].ToString()%>').value = args15;
            window.parent.document.getElementById('<%=Request.QueryString["Field16"].ToString()%>').value = args1;
            window.parent.document.getElementById('<%=Request.QueryString["Field17"].ToString()%>').value = args6;
            window.parent.document.getElementById('<%=Request.QueryString["Field18"].ToString()%>').value = args7;
            window.parent.document.getElementById('<%=Request.QueryString["Field19"].ToString()%>').value = args2;
            window.parent.document.getElementById('<%=Request.QueryString["Field20"].ToString()%>').value = args3;
            window.parent.document.getElementById('<%=Request.QueryString["Field21"].ToString()%>').value = args8;
            window.parent.document.getElementById('<%=Request.QueryString["Field22"].ToString()%>').value = args10;
            window.parent.document.getElementById('<%=Request.QueryString["Field23"].ToString()%>').value = args9;
            ///window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').focus();

            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            return false;
        }
        function doCancel() {
            window.parent.$find('mdlViewBID').hide();
            //window.parent.window.hidePopWin(false);
            //window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
    <style type="text/css">
        .disablepage
        {
            display: none;
        }
    </style>
    <asp:ScriptManager ID="scriptMgr" runat="server">
    </asp:ScriptManager>
    <div class="container" style="overflow:auto;">
        <center>
            <div class="panel panel-success" id="divAlert" runat="server" style="width: 90%;overflow:auto;
                display: block; border: 2px; border-radius: 15px; background-color: white; border: solid;
                border-color: blue; border-width: 2px;" cellpadding="0" cellspacing="0" >
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="False" Width="310px"></asp:Label>
                    </div>
                </div>
                <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnWfParam');return false;">
                    <div class="row" style="text-align: left">
                        <div class="col-sm-10">
                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                            <asp:Label ID="lblSMDtls" runat="server" Text="SM Details" Font-Bold="False" Height="14px"
                                Font-Size="Small"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="btnWfParam" class="glyphicon glyphicon-collapse-down" style="float: right;
                                color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
                <div id="TrEmpSearch" runat="server" class="panel-body" style="overflow:auto">
                    <div class="row">
                        <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lblEmpCode" Text="Employee Code" CssClass="control-label" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtEmpCode" runat="server" style="margin-bottom: 5px;" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lblEmpName" runat="server" Text="Employee Name" CssClass="control-label"
                                Font-Bold="False"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtEmpName" runat="server"  style="margin-bottom: 5px;" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" AutoPostBack="false"
                            TabIndex="43" OnClick="btnSearch_Click">
                                     <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample" OnClick="btnClear_Click">
                          <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear
                        </asp:LinkButton>
                        <%--<asp:Button ID="btnClear" runat="server" CssClass="standardbutton" TabIndex="43"
                                    Text="Clear" Width="80px" OnClick="btnClear_Click" />--%>
                    </div>
                    <div class="row">
                        <%--  <tr>--%>
                        <div id="trErrorMsg" runat="server" visible="false" class="col-sm-12" style="margin-bottom: 5px;">
                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Green"></asp:Label>
                        </div>
                    </div>
                    <div id="trDgDetails" runat="server" class="panel-body" style="overflow:auto;height:150Px;">
                        <asp:GridView ID="gvSMDtls" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                            CssClass="footable" AllowSorting="true" PageSize="10" OnPageIndexChanging="gvSMDtls_PageIndexChanging"
                            PagerStyle-Font-Underline="true" PagerStyle-HorizontalAlign="Center" OnRowDataBound="gvSMDtls_RowDataBound">
                            <FooterStyle CssClass="GridViewFooter" />
                            <RowStyle CssClass="GridViewRow" />
                            <PagerStyle CssClass="disablepage" />
                            <SelectedRowStyle CssClass="GridViewSelectedRow" />
                            <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="EmpCode" SortExpression="EmpCode" Visible="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblEmpCode" runat="server" Text='<%# Bind("EmpCode") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name" SortExpression="LegalName" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLegalName" runat="server" Text='<%# Bind("LegalName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MemCode" SortExpression="MemCode" Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkmemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="pad" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HierarchyName" SortExpression="HierarchyName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBizSrc" runat="server" Text='<%# Bind("HierarchyName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubClass" SortExpression="SubClass" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChnCls" runat="server" Text='<%# Bind("SubClass") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                    <ItemStyle CssClass="pad" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch" SortExpression="BranchName" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBrnchNm" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AgentTypeDesc01" SortExpression="AgentTypeDesc01"
                                    Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAgentTypeDesc01" runat="server" Text='<%# Bind("AgentTypeDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch" SortExpression="Branch" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Branch") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AgentTypeDesc" SortExpression="AgentTypeDesc" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAgentTypeDesc" runat="server" Text='<%# Bind("AgentTypeDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--pranjali--%>
                                <asp:TemplateField SortExpression="BizSrc" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBizSrcvalue" runat="server" Text='<%# Bind("BizSrc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="ChnCls" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChnClsvalue" runat="server" Text='<%# Bind("ChnCls") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AgentType" SortExpression="AgentType" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAgentType" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AgnType" SortExpression="AgnType" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAgnType" runat="server" Text='<%# Bind("AgnType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UnitCode" SortExpression="UnitCode" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <%-- <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"  />
                            <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                            <RowStyle CssClass="sublinkodd"></RowStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>--%>
                        </asp:GridView>
                        <br />
                        <div id="trButton" runat="server">
                            <div align="center" class="col-sm-12">
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-danger" OnClientClick="doCancel();return false;">
                                 <span class="glyphicon glyphicon-remove"> </span> Cancel
                                </asp:LinkButton>
                                <%--<asp:Button CssClass="standardbutton" ID="btnCancel" runat="server" Text="Cancel" OnClientClick="doCancel();return false;" /><%--</div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </center>
    </div>
</asp:Content>

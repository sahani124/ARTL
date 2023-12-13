<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FrmMstExmLng.aspx.cs" Inherits="Application_ISys_Recruit_FrmMstExmLng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="sm50HrsSearch" runat="server">
    </asp:ScriptManager>
    <br />
    <center>
    <asp:UpdatePanel ID="up_prospect" runat="server">
    <ContentTemplate>
    <table class="container" width="80%">
            <tr id="trSearchDetails" runat="server">
                <td align="center" >
<table id="tblExmLngdtl" 
                style="border-collapse: separate; left: 0in; top: 0px; width:100%;" 
                class="tableIsys" runat="server">
                <tr>
                    <td class="test" colspan="4" align="left"  style="height:20px; vertical-align:baseline;">
                        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Height="10px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblExmMode" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%" align="left">
                        <asp:TextBox ID="txtExmMode" runat="server" CssClass="standardtextbox"></asp:TextBox>
                        
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblExmLng" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%" align="left">
                        <asp:TextBox ID="txtExmLng" runat="server" CssClass="standardtextbox"></asp:TextBox>
                        
                    </td>
                </tr> 
                <tr>
                    <td colspan="4" align="center" style="height: 20px">

                        <%--<div class="btn btn-xs btn-primary" style="width:100px;">   
                            <i class="fa fa-search"></i>--%>
                            <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" TabIndex="43"
                                Text="Search" Width="90px" OnClick="btnSearch_Click" />
                                <%--  </div>--%>
                       <%-- <div class="btn btn-xs btn-primary" style="width:100px;">
                            <i class="fa fa-times"></i>--%>
                        <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" TabIndex="43"
                            Text="Clear" Width="114px" OnClick="btnClear_Click" />
                               <%-- </div>--%>
                       <%-- <div class="btn btn-xs btn-primary" style="width:100px;">
                            <i class="fa fa-plus"></i>--%>
                            <asp:Button ID="btnAddNew" runat="server" CssClass="standardbutton" TabIndex="43"
                            Text="Add New" Width="114px" OnClick="btnAddNew_Click" />
                            <%--  </div>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="red" Visible="false"></asp:Label>
                    </td>
                </tr>
                
            </table>
            </td>
            </tr>

                   <tr id="trMstExmLng" runat="server">
            <td align="center" >
            <table style="border-collapse: separate; left: 0in; position: relative; top: 0px;
                width: 100%;" class="formtable">
                <tr id="trtitle" runat="server">
                    <td style="border-collapse: separate" class="test" height="30px;">
                        <asp:UpdatePanel ID="updPageInfo" runat="server">
                            <ContentTemplate>
                            <asp:Label ID="lblprospectsearch" runat="server" Text="Exam Language Search" Font-Bold="true" Font-Size="Small"></asp:Label>
                                        <span style="padding-left:500px;"></span>
                                 <span style="padding-right"></span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                            <td class="test" align="right">
                         <asp:Label ID="lblPageInfo"  runat="server" Font-Bold="true" Width="160px"></asp:Label>
                            </td>
                  
                  
                </tr>
                <tr id="trgridMstExmLng" runat="server">
                   <td colspan="2">
                        <asp:UpdatePanel ID="UpdPanelAgtDetails" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgMstExmLng" runat="server" AllowSorting="True" CssClass="formtable"
                                    PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                    RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True"  
                                    Width="100%" OnRowCommand="dgMstExmLng_RowCommand" OnRowDataBound="dgMstExmLng_RowDataBound" OnPageIndexChanging="dgMstExmLng_PageIndexChanging"> 
                                  
                                    <Columns>
                                        <asp:BoundField SortExpression="SeqNo" HeaderText="Seq No" DataField="SeqNo" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField SortExpression="ExamLanguage" HeaderText="Exam Language" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblLng" runat="server" Text='<%# Eval("ExamLanguage") %>' CommandArgument='<%# Eval("ExamLanguage") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ExamMode" HeaderText="Exam Mode" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblMode" runat="server" Text='<%# Eval("ExamMode") %>' CommandArgument='<%# Eval("ExamMode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="IsActive" HeaderText="Status" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <div>
                                                <i class="fa fa-flash" style="text-align:left;"></i>
                                                    <asp:LinkButton ID="lnkStatus" runat="server" Text='<%# Eval("IsActive") %>' CommandArgument='<%# Eval("SeqNo") %>'></asp:LinkButton></div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="IsActiveFlag" HeaderText="Status1" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblStatusFlag" runat="server" Text='<%# Eval("IsActiveFlag") %>' CommandArgument='<%# Eval("IsActiveFlag") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="sublinkodd"></RowStyle>
                                    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                    </PagerStyle>
                                    <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                                    </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                
            </table>
            </td>
            </tr>
            <tr>
            <td>
            <table id="tblExmLngdtlValue" 
                style="border-collapse: separate; left: 0in; top: 0px; width:100%;" 
                class="tableIsys" runat="server">
                <tr>
                    <td class="test" colspan="4" align="left"  style="height:20px; vertical-align:baseline;">
                        <asp:Label ID="lblTitleValue" runat="server" Font-Bold="True" Height="10px" Text="Exam Language"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblExmModeValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%" align="left">
                    <asp:DropDownList ID="ddlExam" runat="server" CssClass="standardmenu" AutoPostBack="true" Width="185px">
                    </asp:DropDownList>
                        
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblExmLngValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%" align="left">
                        <asp:TextBox ID="txtExmLngValue" runat="server" CssClass="standardtextbox"></asp:TextBox>
                        
                    </td>
                </tr> 
                <tr>
                    <td colspan="4" align="center" style="height: 20px">
                       <%-- <div class="btn btn-xs btn-primary" style="width:100px;">
                            <i class="fa fa-plus"></i>--%>
                        <asp:Button ID="btnAdd" runat="server" CssClass="standardbutton" TabIndex="43"
                            Text="Add" Width="114px" OnClick="btnAdd_Click" />
                             <%--</div>--%>
                    </td>
               </tr>
               
            </table>
            </td>
            </tr>
            <asp:HiddenField ID="hdnCrtDtim" runat="server" />
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
            </center>

</asp:Content>


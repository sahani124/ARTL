<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FrmMstExmCentre.aspx.cs" Inherits="Application_ISys_Recruit_FrmMstExmCentre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <center>
    <asp:UpdatePanel ID="up_prospect" runat="server">
    <ContentTemplate>
    <table class="container" width="80%">
            <tr id="trSearchDetails" runat="server">
                <td align="center" >
<table id="tblExmCntrdtl" 
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
                        <asp:Label ID="lblExmBdy" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%" align="left">
                        <asp:TextBox ID="txtExmBdy" runat="server" CssClass="standardtextbox"></asp:TextBox>
                    </td>
                </tr> 
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblExmCntr" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%" align="left">
                        <asp:TextBox ID="txtExmCntr" runat="server" CssClass="standardtextbox"></asp:TextBox>
                        
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <%--<asp:Label ID="Label2" runat="server" Font-Bold="False"></asp:Label>--%>
                    </td>
                    <td class="formcontent" style="width: 30%" align="left">
                        <%--<asp:TextBox ID="TextBox2" runat="server" CssClass="standardtextbox"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="height: 20px">

                        <%--<div class="btn btn-primary btn-xs" style="width:114px;white-space:nowrap;">
                        <i class="fa fa-search" style="text-align:left;"></i>--%>
                      <%--  <div class="btn btn-xs btn-primary" style="width:100px;">
                            <i class="fa fa-search"></i>--%>
                            <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" TabIndex="43"
                                Text="Search" Width="114px" OnClick="btnSearch_Click" />
                       <%-- </div>--%>
                       <%-- <div class="btn btn-xs btn-primary" style="width:100px;">   
                            <i class="fa fa-times"></i>--%>
                        <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" TabIndex="43"
                            Text="Clear" Width="114px" OnClick="btnClear_Click" />
                        <%-- </div>--%>
                        <%--<div class="btn btn-xs btn-primary" style="width:100px;">
                           <i class="fa fa-plus"></i>--%>
                            <asp:Button ID="btnAddNew" runat="server" CssClass="standardbutton" TabIndex="43"
                            Text="Add New" Width="114px" OnClick="btnAddNew_Click" />
                       <%-- </div>--%>
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

                   <tr id="trMstExmCntre" runat="server">
            <td align="center" >
            <table style="border-collapse: separate; left: 0in; position: relative; top: 0px;
                width: 100%;" class="formtable">
                <tr id="trtitle" runat="server">
                    <td style="border-collapse: separate" class="test" height="30px;">
                        <asp:UpdatePanel ID="updPageInfo" runat="server">
                            <ContentTemplate>
                            <asp:Label ID="lblExmCntrSrch" runat="server" Text="Exam Centre Search" Font-Bold="true" Font-Size="Small"></asp:Label>
                                        <span style="padding-left:500px;"></span>
                                 <span style="padding-right"></span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                            <td class="test" align="right">
                         <asp:Label ID="lblPageInfo"  runat="server" Font-Bold="true" Width="160px"></asp:Label>
                            </td>
                  
                  
                </tr>
                <tr id="trgridMstExmCntr" runat="server">
                   <td colspan="2">
                        <asp:UpdatePanel ID="UpdPanelAgtDetails" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgMstExmCntr" runat="server" AllowSorting="True" CssClass="formtable"
                                    PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                    RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True"  
                                    Width="100%" OnRowCommand="dgMstExmCntr_RowCommand" OnRowDataBound="dgMstExmCntr_RowDataBound" OnPageIndexChanging="dgMstExmCntr_PageIndexChanging">
                                    <%--OnSorting="dgMstExmLng_Sorting" --%>
                                    <Columns>
                                        <asp:BoundField SortExpression="SeqNo" HeaderText="Seq No" DataField="SeqNo" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField SortExpression="ExamMode" HeaderText="Exam Mode" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblMode" runat="server" Text='<%# Eval("ExamMode") %>' CommandArgument='<%# Eval("ExamMode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ExamBody" HeaderText="Exam Body" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblBody" runat="server" Text='<%# Eval("ExamBody") %>' CommandArgument='<%# Eval("ExamBody") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="ExamCentre" HeaderText="Exam Centre" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblCntre" runat="server" Text='<%# Eval("ExamCentre") %>' CommandArgument='<%# Eval("ExamCentre") %>'></asp:Label>
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
            <table id="tblExmCntrdtlValue" 
                style="border-collapse: separate; left: 0in; top: 0px; width:100%;" 
                class="tableIsys" runat="server">
                <tr>
                    <td class="test" colspan="4" align="left"  style="height:20px; vertical-align:baseline;">
                        <asp:Label ID="lblTitleValue" runat="server" Font-Bold="True" Height="10px" Text="Exam Centre"></asp:Label>
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
                        <asp:Label ID="lblExmBdyValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%" align="left">
                        <asp:TextBox ID="txtExmBdyValue" runat="server" CssClass="standardtextbox"></asp:TextBox>
                        
                    </td>
                </tr> 
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblExmCntrValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%" align="left">
                    <asp:TextBox ID="txtExmCntrValue" runat="server" CssClass="standardmenu" Width="185px">
                    </asp:TextBox>
                        
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <%--<asp:Label ID="Label2" runat="server" Font-Bold="False"></asp:Label>--%>
                    </td>
                    <td class="formcontent" style="width: 30%" align="left">
                        <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="standardtextbox"></asp:TextBox>--%>
                        
                    </td>
                </tr> 
                <tr>
                    <td colspan="4" align="center" style="height: 20px">
                      <%--<div class="btn btn-xs btn-primary" style="width:100px;">
                          <i class="fa fa-plus"></i>--%>
                         <asp:Button ID="btnAdd" runat="server" CssClass="standardbutton" TabIndex="43"
                            Text="Add" Width="114px" OnClick="btnAdd_Click" />
                     <%-- </div>--%>
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


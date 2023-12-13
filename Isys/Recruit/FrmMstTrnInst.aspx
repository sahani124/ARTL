<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FrmMstTrnInst.aspx.cs" Inherits="Application_ISys_Recruit_FrmMstTrnInst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
    <asp:updatepanel id="Up_TrnInst" runat="server">
    <ContentTemplate>
    <table class="container" runat="server" width="80%">
        <tr id="trSearchDetails" runat="server">
            <td align="center">
            <table id="tblTrnInstDtl" runat="server" class="tableIsys" style="border-collapse: separate; left: 0in; top: 0px; width:100%;">
                <tr>
                    <td class="test" colspan="4" align="left"  style="height:20px; vertical-align:baseline;">
                        <asp:Label ID="lbltitle" runat="server" Text="Training Institute Search" Font-Bold="true" Height="10px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lbltrntype" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" align="center" style="width: 30%">
                        <asp:DropDownList ID="ddltrntype" runat="server" CssClass="standardmenu" AutoPostBack="true" Width="185px" align="left" OnSelectedIndexChanged="ddltrntype_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lbltrnloc" runat="server" Font-Bold="false"></asp:Label>
                    </td>
                    <td  class="formcontent" align="center" style="width: 30%">
                        <asp:TextBox ID="txttrnloc" runat="server" CssClass="standardtextbox" align="left" Width="70%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblTrnInst" runat="server" Font-Bold="false"></asp:Label>
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:TextBox ID="txtTrnInst" runat="server" CssClass="standardtextbox" align="left" Width="185px"></asp:TextBox>
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblAcc" runat="server" Font-Bold="false"></asp:Label>
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:TextBox ID="txtAcc" runat="server" CssClass="standardtextbox" align="left" Width="70%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="height: 20px">
                     <%-- <div class="btn btn-xs btn-primary" style="width:100px;">
                       <i class="fa fa-search"></i> --%>  
                        <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" TabIndex="43"
                                Text="Search" Width="114px" OnClick="btnSearch_Click" />
                      <%-- </div>--%>
                        <%--<div class="btn btn-xs btn-primary" style="width:100px;">
                            <i class="fa fa-times"></i>  --%>
                        <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" TabIndex="43"
                            Text="Clear" Width="114px" OnClick="btnClear_Click" />
                          <%--   </div>--%>
                    <%--    <div class="btn btn-xs btn-primary" style="width:100px;">
                         <i class="fa fa-plus"></i>  --%>
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
        <tr id="trMstTrnInst" runat="server">
            <td align="center">
                <table class="formtable" style="border-collapse:separate; left:0in; position:relative; top:0px; width:100%;">
                    <tr id="trtitle" runat="server" visible="false">
                        <td style="border-collapse: separate" class="test" height="30px;">
                            <asp:UpdatePanel ID="updPageInfo" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblExmCntrSrch" runat="server" Text="Training Institute Search" Font-Bold="true" Font-Size="Small" align="left"></asp:Label>
                                        <span style="padding-left:500px;"></span>
                                <span style="padding-right"></span>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="test" align="right">
                            <asp:Label ID="lblPageInfo"  runat="server" Font-Bold="true" Width="160px"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trgridMstTrnInst" runat="server">
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdPanelAgtDetails" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgMstTrnInst" runat="server" AllowSorting="True" CssClass="formtable"
                                    PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                    RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True"  
                                    Width="100%" OnRowCommand="dgMstTrnInst_RowCommand" OnRowDataBound="dgMstTrnInst_RowDataBound" OnPageIndexChanging="dgMstTrnInst_PageIndexChanging"> 
                                    <Columns>
                                        <asp:TemplateField SortExpression="TrnCode" HeaderText="" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblTrnCode" runat="server" Text='<%# Eval("TrnCode") %>' CommandArgument='<%# Eval("TrnCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="TrnType" HeaderText="Training Type" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("TrnType") %>' CommandArgument='<%# Eval("TrnType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="TrnLoc" HeaderText="Training Location" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblLoc" runat="server" Text='<%# Eval("TrnLoc") %>' CommandArgument='<%# Eval("TrnLoc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="TrnInst" HeaderText="Training Institute" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblInst" runat="server" Text='<%# Eval("TrnInst") %>' CommandArgument='<%# Eval("TrnInst") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField SortExpression="AccLoc" HeaderText="Accrediation No" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblAcc" runat="server" Text='<%# Eval("AccLoc") %>' CommandArgument='<%# Eval("AccLoc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="IsActive" HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <div>
                                                <i class="fa fa-flash" style="text-align:left;"></i>
                                                    <asp:LinkButton ID="lnkStatus" runat="server" Text='<%# Eval("IsActive") %>' CommandArgument='<%# Eval("TrnCode") %>'></asp:LinkButton>
                                                </div>
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
            <table id="tblTrn" runat="server" class="tableIsys" visible="false" style="border-collapse: separate; left: 0in; top: 0px; width:100%;">
                <tr>
                    <td class="test" colspan="4" align="left"  style="height:20px; vertical-align:baseline;">
                        <asp:Label ID="lblTrnSearch" runat="server" Text="Training Institute" Font-Bold="true" Height="10px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblTrnTypeVal" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" align="center" style="width: 30%">
                        <asp:DropDownList ID="ddlTrnTypeVal" runat="server" CssClass="standardmenu" AutoPostBack="true" Width="185px" align="left" OnSelectedIndexChanged="ddlTrnTypeVal_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lbltrnlocval" runat="server" Font-Bold="false"></asp:Label>
                    </td>
                    <td  class="formcontent" align="center" style="width: 30%">
                        <asp:TextBox ID="txttrnlocVal" runat="server" CssClass="standardtextbox" align="left" Width="70%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblTrnInstVal" runat="server" Font-Bold="false"></asp:Label>
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:TextBox ID="txtTrnInstVal" runat="server" CssClass="standardtextbox" align="left" Width="185px"></asp:TextBox>
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblAccVal" runat="server" Font-Bold="false"></asp:Label>
                    </td>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:TextBox ID="txtAccVal" runat="server" CssClass="standardtextbox" align="left" Width="70%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="height: 20px">
                        <%--<div class="btn btn-xs btn-primary" style="width:100px;">
                            <i class="fa fa-plus"></i>--%>
                        <asp:Button ID="btnAdd" runat="server" CssClass="standardbutton" TabIndex="43"
                                Text="ADD" Width="114px" OnClick="btnAdd_Click" />
                                 <%-- </div>--%>
                    </td>
                </tr>
            </table>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:updatepanel>
    <asp:HiddenField ID="hdnTrnCode" runat="server" />
     <asp:HiddenField ID="hdnCrtDtim" runat="server" />
    </center>
</asp:Content>


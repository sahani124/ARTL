<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FrmMstUpldDocs.aspx.cs" Inherits="Application_ISys_Recruit_FrmMstUpldDocs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">

        function funcopen() {
            debugger;
            $find("MdlPopRaise").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaise").src = "../../../Application/ISys/Recruit/FrmMstUpldPop.aspx?" +
           "&mdlpopup=MdlPopRaise";

        }
    </script>
<center>
<asp:UpdatePanel ID="Up_UpldDocs" runat="server">
<ContentTemplate>
    <table id="table1" class="container" runat="server" width="80%">
        <tr  id="trSearchDetails" runat="server">
            <td align="center">
              <table id="tblmstupldcs" runat="server" class="tableIsys" style="border-collapse: separate; left: 0in; top: 0px; width:100%;">
                <tr>
                    <td class="test" colspan="4" align="left"  style="height:20px; vertical-align:baseline;">
                        <asp:Label ID="lbltitle" runat="server" Text="Upload Documents Search" Font-Bold="true" Height="10px"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblPrcstype" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" align="center" style="width: 30%">
                      <asp:DropDownList ID="ddlPrcsType" CssClass="standardmenu" runat="server" Width="185px" align="left"></asp:DropDownList>
                    </td>
                   
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblCandType" runat="server" Font-Bold="false"></asp:Label>
                    </td>
                    <td  class="formcontent" align="center" style="width: 30%">
                        <asp:DropDownList ID="ddlCndType" CssClass="standardmenu" runat="server" Width="185px" align="left"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblStatus" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" align="center" style="width: 30%">
                        <asp:DropDownList ID="ddlstatus" CssClass="standardmenu" runat="server" Width="185px" align="left" ></asp:DropDownList>
                    </td>
                     <td class="formcontent" align="left" style="width: 20%">
                        <asp:Label ID="lblDesc" runat="server" Font-Bold="false"></asp:Label>
                    </td>
                    <td  class="formcontent" align="center" style="width: 30%">
                       <%--<asp:DropDownList ID="ddlDesc" runat="server" Width="185px" align="left" ></asp:DropDownList>--%> 
                       <asp:TextBox ID="textDesc" runat="server" CssClass="standardtextbox" Width="185px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td colspan="4" align="center" style="height: 20px">
                         <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" TabIndex="43"
                                Text="Search" Width="114px" OnClick="btnSearch_Click" />
                  
                          <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" TabIndex="43"
                            Text="Clear" Width="114px" OnClick="btnClear_Click" />
                        
                         <asp:Button ID="btnAddNew" runat="server" CssClass="standardbutton" TabIndex="43"
                            Text="Add New" Width="114px" OnClick="btnAddNew_Click" />
                          
                    </td>
                </tr>
               </table>
               <table class="container" runat="server"  width="100%" >
               <tr id="trtitle" runat="server" visible="false">
                        <td style="border-collapse: separate" class="test" height="30px;">
                            <asp:UpdatePanel ID="updPageInfo" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblExmCntrSrch" runat="server" Text="Upload Documents Search" Font-Bold="true" Font-Size="Small" align="left"></asp:Label>
                                        <span style="padding-left:500px;"></span>
                                <span style="padding-right"></span>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="test" align="right">
                            <asp:Label ID="lblPageInfo"  runat="server" Font-Bold="true" Width="160px"></asp:Label>
                        </td>
               </tr>
               <tr>
               <td colspan="2">
               <asp:GridView ID="dgMstUpldDocs" runat="server" AllowSorting="True" CssClass="formtable"
                                    PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                    RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True"  
                                    Width="100%" OnRowCommand="dgMstUpldDocs_RowCommand" OnRowDataBound="dgMstUpldDocs_RowDataBound" OnPageIndexChanging="dgMstUpldDocs_PageIndexChanging"> 
                                    <Columns>
                                         <asp:TemplateField SortExpression="ImgCode" HeaderText="" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblImgCode" runat="server" Text='<%# Eval("ImgCode") %>' CommandArgument='<%# Eval("ImgCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ProcessType" HeaderText="Process Type" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblPrcsType" runat="server" Text='<%# Eval("ProcessType") %>' CommandArgument='<%# Eval("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="CandType" HeaderText="Candidate Type" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblCandType" runat="server" Text='<%# Eval("CandType") %>' CommandArgument='<%# Eval("CandType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ImgDesc" HeaderText="Document Discription" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblImgDesc" runat="server" Text='<%# Eval("ImgDesc") %>' CommandArgument='<%# Eval("ImgDesc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField SortExpression="status" HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <div>
                                                <i class="fa fa-flash" style="text-align:left;"></i>
                                                    <asp:LinkButton ID="lnkStatus" runat="server" Text='<%# Eval("status") %>' CommandArgument='<%# Eval("ImgCode") %>'></asp:LinkButton>
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
                                
               </td>
               </tr>
               <tr>
                <td>
                <asp:Button ID="btnrefresh" runat="server" Visible="false" OnClick="btnrefresh_Click" />
                </td>
               </tr>
               </table>
              
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
<asp:Panel runat="server" ID="PnlRaise" Width="1000px" display="none">
        <iframe runat="server" id="IframeRaise" frameborder="0" display="none" style="width:800px;
            height:350px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaise" BehaviorID="MdlPopRaise" DropShadow="false"
       TargetControlID="lbl" PopupControlID="PnlRaise" BackgroundCssClass="modalPopupBg">
 </ajaxToolkit:ModalPopupExtender>
</center>
</asp:Content>


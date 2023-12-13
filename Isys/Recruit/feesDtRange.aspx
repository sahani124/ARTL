<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="feesDtRange.aspx.cs" Inherits="Application_ISys_Recruit_feesDtRange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
    
    <table class="container" width="95%">
            <tr >
                <td>
                    <table class="formtable table-condensed">
                    <tr>
                            <td class="test" colspan="4" align="left" style="border-collapse: separate; height: 20px;">
                                <asp:Label ID="lbltitle" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                            </td>
                        </tr>
                    <tr id="trAll" runat="Server">
                            <td class="formcontent" align="left" style="height: 24px;">
                                <asp:Label ID="lblprtDtfrm" runat="server" Text="Date From"></asp:Label>
                                <span style="color: #CC0000">*</span></td>
                            <td class="formcontent" align="left" style="height: 24px;">
                                <asp:TextBox ID="txtrptDtfrmval" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox CssClass="standardtextbox" ID="TextBox2" Style="display: none" runat="server"
                                    Width="80px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                    ValidChars="1234567890/" FilterMode="ValidChars" TargetControlID="txtrptDtfrmval"
                                    FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtrptDtfrmval"
                                    PopupButtonID="Image1" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                    ControlToValidate="txtrptDtfrmval" Enabled="true" ErrorMessage="Mandatory!"
                                    Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Invalid date!"
                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtrptDtfrmval" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtrptDtfrmval"
                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                    MinimumValue="1900-01-01" Type="Date" Visible="false"></asp:RangeValidator>
                            </td>
                            <td class="formcontent" align="left" style="height: 24px;">
                                <asp:Label ID="lblprtDtto" runat="server" Text="Date To"></asp:Label>
                                <span style="color: #CC0000">*</span></td>
                            <td class="formcontent" align="left" style="height: 24px;">
                                <asp:TextBox ID="txtrptDttoval" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox CssClass="standardtextbox" ID="TextBox1" Style="display: none" runat="server"
                                    Width="80px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    ValidChars="1234567890/" FilterMode="ValidChars" TargetControlID="txtrptDttoval"
                                    FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtrptDttoval"
                                    PopupButtonID="Image2" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                                    ControlToValidate="txtrptDttoval" Enabled="true" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Invalid date!"
                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtrptDttoval" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtrptDttoval"
                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                    MinimumValue="1900-01-01" Type="Date" Visible="false" ></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                           <td class="formcontent" align="left" style="height: 24px;">
                                <asp:Label ID="lblReference" runat="server" Text="Reference"></asp:Label>
                                <span style="color: #CC0000">*</span></td>
                            <td class="formcontent" align="left" style="height: 24px;" colspan="3">
                                           <asp:TextBox ID="txtReference" runat="server" CssClass="standardtextbox" style='margin-right:80px' 
                                                    ></asp:TextBox>
                                           </td>
                        </tr>
                         <tr>
                            <td class="formcontent2" align="right" colspan="4">
                                <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" Text="Submit"
                                    Width="80px" OnClientClick="LdWait(100000)" OnClick="btnSearch_Click" />
                                    <div id="divloader" runat="server" style="display:none;">
                                &nbsp;&nbsp; <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                                </div>
                            </td>
                        </tr>

                        <tr id="trLbl" runat="server">
                            <td colspan="4" align="center">
                                <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>

                         <tr id="tr2" runat="server">
                            <td class="test"  align="left"   colspan="4" style="border-collapse: separate;height:20px;">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="Fees Waiver Details"  Font-Bold="true" style="text-align:left;" Font-Size="Small"></asp:Label>
                                        <span style="padding-left:500px;"></span>
                                       <%-- <asp:Label ID="lblPageInfo1" runat="server"></asp:Label>--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            </tr>

   <tr style="width: 100%" id="trDgFees" runat="server">
                <td colspan="4">
                                <asp:UpdatePanel ID="UpdatePanel002" runat="server">
                                    <ContentTemplate>

                                        <asp:GridView Style="color: blue; margin-top: 0px;" ID="dgFees" 
                                            runat="server" AllowSorting="True"
                                            PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                            RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                            AllowPaging="True" 
                                            Width="100%">
                                               <Columns>
                                                <asp:TemplateField SortExpression="CreatedDt" HeaderText="Date of Submission" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreatedDt" runat="server" Text='<%# Eval("CreatedDt") %>' ToolTip='<%# Eval("CreatedDt") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                </asp:TemplateField>
                                                   <asp:TemplateField SortExpression="Reference" HeaderText="Reference" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReference" runat="server" Text='<%# Eval("Reference") %>' ToolTip='<%# Eval("Reference") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="FrmDt" HeaderText="From Date" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFrmDt" runat="server" Text='<%# Eval("FromDate") %>' ToolTip='<%# Eval("FromDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="ToDate" HeaderText="To Date" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblToDate" runat="server" Text='<%# Eval("ToDate") %>' ToolTip='<%# Eval("ToDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                </asp:TemplateField>
                                               </Columns>
                                              <RowStyle CssClass="sublinkodd"></RowStyle>
                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                            </PagerStyle>
                                            <HeaderStyle  Height="10px" CssClass="portlet blue" ForeColor="White" Font-Bold="true" HorizontalAlign="Center"></HeaderStyle>
                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
            </td>
            </tr>
                    </table>
                </td>
            </tr>
            </table>
    </center>
      <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
                    BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
                    TargetControlID="hiddenField1" PopupControlID="Panel1">
                </ajaxToolkit:ModalPopupExtender>
                 <asp:HiddenField ID="hiddenField1" runat="server" />
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopChannelClassMas.aspx.cs" Inherits="Application_ISys_ChannelMgmt_PopChannelClassMas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <link href="../../../Styles/subModal.css" rel="Stylesheet" type="text/css" />
     <link href="../../../Styles/main.css" rel="Stylesheet" />
    <style type="text/css"    >
   
    .pagelink span{font-weight:bold;}
    .table 
    { border-collapse : none !important;
      border-spacing : none !important;
    }
    </style>
    <script language="javascript" type="text/javascript">

        function funShowDeleteMsg() {
            alert('hello');
            return confirm("Do You Want To Delete The Record?");
        }

        function ShowReqDtl(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                //document.getElementById(divId).value = '+'
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }

    </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

        <table class="tableIsys"  align="center"  width="90%">
                            <tr>
                            <td class="formcontent">
                                <asp:Label Text="Financial Year" ID="lblFincYear" runat="server" />
                            </td>
                                <td class="formcontent">
                                    <asp:UpdatePanel ID="updfinyr" runat="server">
                                    <ContentTemplate>
                                    <asp:DropDownList runat="server" CssClass="standardmenu" AutoPostBack="true" 
                                        ID="ddlFincYear" onselectedindexchanged="ddlFincYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent">
                                    <asp:Label Text="Version" ID="lblBaseVersion" runat="server" />
                                </td>    
                                <td class="formcontent">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                 <asp:DropDownList runat="server" CssClass="standardmenu" AutoPostBack="true" ID="ddlBaseVersion">
                                    </asp:DropDownList>
                                     </ContentTemplate>
                                     <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlFincYear" EventName="selectedindexchanged" />
                                     </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                          <tr>
                          <td colspan="4" align="center">
                             <asp:Button ID="btnSearch" runat="server" Text="Search" TabIndex="1205" 
                                Width="80px" CssClass="standardbutton" onclick="btnSearch_Click"/>
                          </td>
                          </tr>
                        </table>
           
            <table id="tblHierDtls" runat="server" visible="false" align="center" width="90%" >
                        <tr>
                           
                            <td align="center" colspan="3" style="height: 40px;">
                               
                                <table width="100%" align="center" class="formtable3">
                                    <tr id="trComDetails" runat="server" style="width: 90%">
                                        <td colspan="4" align="left" class="test formHeader" >
                                        <asp:UpdatePanel runat="server" ID="updpage">
                                            <ContentTemplate>
                                            <input runat="server" type="button" class="standardlink" value="-" id="Button1" style="width: 20px;"
                                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divComDetails','ctl00_ContentPlaceHolder1_Button1');" />
                                            <asp:Label ID="lblCmpySetup" runat="server" Font-Bold="True" Text="Company Setup"></asp:Label>
                                            <span style="padding-left: 400px;"></span>
                                            <asp:Label ID="lblpgcom" runat="server"></asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                 <asp:AsyncPostBackTrigger ControlID="dgComDetails" EventName="PageIndexChanging" />
                                             </Triggers>
                                         </asp:UpdatePanel>
                                        </td>
                                        <%-- <td align="right" style="border-collapse: separate;" class="test formHeader">
                            <asp:Label ID="lblComPageInfo" runat="server"></asp:Label>
                        </td>--%>
                                    </tr>
                                </table>
                                <div id="divComDetails" runat="server" style="display: block;">
                                    <table width="100%" align="center" class="formtable3">
                                        <tr id="trGvComDetails" runat="server">
                                            <td align="left" class="formcontent" colspan="4" style="height: 21px;">
                                                <asp:UpdatePanel runat="server" ID="upddgcom" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="dgComDetails" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                                            RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue" PagerStyle-Font-Underline="true"
                                                            PagerSettings-Mode="NextPreviousFirstLast" PagerStyle-HorizontalAlign="Center"
                                                            AllowSorting="true" Width="100%" AllowPaging="True"
                                                            OnSorting="dgComDetails_Sorting" PageSize="10"
                                                            OnPageIndexChanging="dgComDetails_PageIndexChanging" >
                                                            <Columns>
                                                                <asp:TemplateField SortExpression="BizSrc" HeaderText="Company" ItemStyle-Width="10%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbComBizSrc" runat="server" Text='<%# Eval("BizSrc") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField SortExpression="ChnCls" HeaderText="Sub Class" ItemStyle-Width="10%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbComBizSrc" runat="server" Text='<%# Eval("ChnCls") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="ChannelDesc01" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderText="Sub Class Desc" ItemStyle-Width="20%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblComChannelDesc01" runat="server" Text='<%# Eval("ChnClsDesc01") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="SortOrder" HeaderText="Sort Order" ItemStyle-Width="10%"
                                                                    Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblComSortOrder" runat="server" Text='<%# Eval("SortOrder") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="10%"></ItemStyle>
                                                                </asp:TemplateField>
                                                              <asp:TemplateField HeaderText="Period" SortExpression="Period" ItemStyle-Width="10%">
                                                             <ItemTemplate>
                                                                 <asp:Label ID="lblFincYear" Text='<%# Eval("Period")%>' runat="server" />
                                                             </ItemTemplate>
                                                             </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Version"  SortExpression="BaseVersion" ItemStyle-Width="10%">
                                                             <ItemTemplate>
                                                                 <asp:Label ID="lblVersion" Text='<%# Eval("BaseVersion")%>' runat="server" />
                                                             </ItemTemplate>
                                                             </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Effective Date" SortExpression="EffDate" ItemStyle-Width="15%">
                                                             <ItemTemplate>
                                                                 <asp:Label ID="lblEffDate" Text='<%# Eval("EffDate")%>' runat="server" />
                                                             </ItemTemplate>
                                                             </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Cease Date" SortExpression="CeaseDate" ItemStyle-Width="15%">
                                                             <ItemTemplate>
                                                                 <asp:Label ID="lblCeaseDate" Text='<%# Eval("CeaseDate")%>' runat="server" />
                                                             </ItemTemplate>
                                                             </asp:TemplateField>
                                                              
                                                              
                                                            </Columns>
                                                            <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center"/>
                                                            <%--Added by rachana on 14/05/2013 for change in CSS class--%>
                                                            <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                                                            <RowStyle CssClass="sublinkodd"></RowStyle>
                                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                                            <PagerSettings FirstPageImageUrl="~/Images/iFirst.gif" LastPageImageUrl="~/Images/iLast.gif"
                                                                Mode="Numeric" NextPageImageUrl="~/Images/iNext.gif" PreviousPageImageUrl="~/Images/iPrev.gif" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="dgComDetails" EventName="Sorting" />
                                                        <asp:AsyncPostBackTrigger ControlID="dgComDetails" EventName="RowCommand" />
                                                        <asp:AsyncPostBackTrigger ControlID="dgComDetails" EventName="PageIndexChanging" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                              
                                <br />
                                <table align="center" class="formtable3" width="100%">
                                    <tr id="trDetails" runat="server" style="width: 90%">
                                        <td colspan="4" align="left" class="test formHeader" style="border-right-width: 0;">
                                        <asp:UpdatePanel runat="server" ID="updpginf">
                                                <ContentTemplate>
                                            <input runat="server" type="button" class="standardlink" value="-" id="Button3" style="width: 20px;"
                                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divChnDetails','ctl00_ContentPlaceHolder1_Button3');" />
                                            <%--Added by Rachana 14/05/2013 for changing CSS class name start--%>
                                            
                                            <asp:Label ID="lblChnlSetup" runat="server" Font-Bold="True" Text="Channel Setup"></asp:Label>
                                               <span style="padding-left: 405px;"></span>
                                                    <asp:Label ID="lblpginf" runat="server"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="dgDetails" EventName="PageIndexChanging" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                       
                                    </tr>
                                    
                                </table>
                                <div id="divChnDetails" runat="server" style="display: block;">
                                    <table align="center" class="formtable3" width="100%">
                                        <tr id="trGvChnDetails" runat="server">
                                            <td align="left" class="formcontent" colspan="4" style="height: 21px;">
                                                <asp:UpdatePanel ID="upddgDetails" runat="server" UpdateMode="Conditional" > 
                                                    <ContentTemplate>
                                                        <asp:GridView ID="dgDetails" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                                            RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue" PagerStyle-Font-Underline="true"
                                                            PagerSettings-Mode="NextPreviousFirstLast" PagerStyle-HorizontalAlign="Center" PageSize="10"
                                                             Width="100%" AllowPaging="True" OnPageIndexChanging="dgDetails_PageIndexChanging"
                                                           AllowSorting="True" OnSorting="dgDetails_Sorting">
                                                            <Columns>
                                                                <%--Edited by vijendra on 06-12-2013 to create these Boundfields as a template fields Start--%>
                                                                <asp:TemplateField HeaderText="Channel" ItemStyle-Width="10%" SortExpression="BizSrc">
                                                                    <ItemTemplate>
                                                                    <div>
                                                                        <asp:Label ID="lbBizSrc" runat="server" Text='<%# Eval("BizSrc") %>'  ></asp:Label>
                                                                    </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField SortExpression="ChnCls" HeaderText="Sub Class" ItemStyle-Width="10%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbComBizSrc" runat="server" Text='<%# Eval("ChnCls") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Sub Class Desc" SortExpression="ChannelDesc01" ItemStyle-Width="20%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblChannelDesc01" runat="server" Text='<%# Eval("ChnClsDesc01") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="SortOrder" HeaderText="Sort Order" ItemStyle-Width="10%"
                                                                    Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSortOrder" runat="server" Text='<%# Eval("SortOrder") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Period" SortExpression="Period" ItemStyle-Width="10%">
                                                             <ItemTemplate>
                                                                 <asp:Label ID="lblFincYear" Text='<%# Eval("Period")%>' runat="server" />
                                                             </ItemTemplate>
                                                             </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Version"  SortExpression="BaseVersion" ItemStyle-Width="10%">
                                                             <ItemTemplate>
                                                                 <asp:Label ID="lblVersion" Text='<%# Eval("BaseVersion")%>' runat="server" />
                                                             </ItemTemplate>
                                                             </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Effective Date" SortExpression="EffDate" ItemStyle-Width="15%">
                                                             <ItemTemplate>
                                                                 <asp:Label ID="lblEffDate" Text='<%# Eval("EffDate")%>' runat="server" />
                                                             </ItemTemplate>
                                                             </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Cease Date" SortExpression="CeaseDate" ItemStyle-Width="15%">
                                                             <ItemTemplate>
                                                                 <asp:Label ID="lblCeaseDate" Text='<%# Eval("CeaseDate")%>' runat="server" />
                                                             </ItemTemplate>
                                                             </asp:TemplateField>
                                                               
                                                            </Columns>
                                                            <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center"/>
                                                            <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                                                            <RowStyle CssClass="sublinkodd"></RowStyle>
                                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                                            <PagerSettings FirstPageImageUrl="~/Images/iFirst.gif" LastPageImageUrl="~/Images/iLast.gif"
                                                                Mode="Numeric" NextPageImageUrl="~/Images/iNext.gif" PreviousPageImageUrl="~/Images/iPrev.gif" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="dgDetails" EventName="Sorting" />
                                                        <asp:AsyncPostBackTrigger ControlID="dgDetails" EventName="RowCommand" />
                                                        <asp:AsyncPostBackTrigger ControlID="dgDetails" EventName="PageIndexChanging" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                             
                            </td>
                        </tr>
                    
                    </table>  
           
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


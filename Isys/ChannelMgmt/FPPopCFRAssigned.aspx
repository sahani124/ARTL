<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FPPopCFRAssigned.aspx.cs" MasterPageFile="~/iFrame.master"  Inherits="Application_ISys_ChannelMgmt_FPPopCFRAssigned" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
  
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
       <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>



 <style>
         .clscenter{
           text-align:center!important;
           }
           .clsLeft{
           text-align:left !important;
           padding: 9px;
           }
    </style>
    <script>
        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
    <div id="divResponded" class="card PanelInsideTab_body" runat="server">
    <table id="tb1" class="formtable" runat="server">
        <tr id ="tr_header" runat="server"> <%--added by pranjali on 25022014--%>
            <td align="center" style="text-align:left;" colspan="4">
                <asp:Label ID="lblHeader" runat="server" Text="Assigned CFR" CssClass="HeaderColor "></asp:Label>
            </td>
        </tr>
    </table>
     <table id="tb2" style="border-collapse: separate; left: 0in; position: relative; top: 8px;"
        class="tableIsys" runat="server">
        <tr id ="trcfrcount" runat="server"> <%--added by pranjali on 25022014--%>
            <td align="left" class="" colspan="4" style="width:30px">
                <asp:Label ID="lblcfrraised" runat="server" Text="Raised CFR" ></asp:Label>&nbsp;
                <asp:Label ID="lblcfrraisedcount" runat="server" ></asp:Label>&nbsp;
                <asp:Label ID="lblresponded" runat="server" Text="Responded CFR" ></asp:Label>
                <asp:Label ID="lblcfrrespondedcount" runat="server" ></asp:Label>&nbsp;
                 <asp:Label ID="lblcfrclosed" runat="server" Text="Closed CFR" ></asp:Label>
                <asp:Label ID="lblcfrclosedcount" runat="server" ></asp:Label>&nbsp;
            </td>
        </tr>
        <tr style="width: 100%" id="trDgDetails" runat="server">
            <td>
                <asp:GridView Style="background-color:white;" ID="dgDetails" runat="server" PagerStyle-HorizontalAlign="Center"  CssClass="footable"
                  
                    HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%"
                    OnPageIndexChanging="dgDetails_PageIndexChanging" PageSize="5">
                    <Columns>
                        <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="False" />
                        <asp:TemplateField HeaderStyle-Wrap="false" ItemStyle-Width="6%" Visible="false">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkAssigned" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" CssClass="test"></HeaderStyle>
                            <ItemStyle></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CFR Remark" HeaderText="CFR Remarks">
                            <ItemTemplate>
                                <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRDesc") %>'></asp:Label>
                            </ItemTemplate>
                           <ItemStyle CssClass="clsLeft" />
                          <HeaderStyle CssClass="clsLeft" />
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR Raised For">
                            <ItemTemplate>
                                <asp:Label ID="lblcfr" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="RemarkId" HeaderText="" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarkid" runat="server" Text='<%# Eval("RemarkId") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CFRRemarkID" HeaderText="" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblCFRRemarkid" runat="server" Text='<%# Eval("CFRRemarkID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="test" />
                            <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Responded" HeaderText="Responded">
                            <ItemTemplate>
                                <asp:Label ID="Responded" runat="server" Text='<%# Eval("Responded") %>'></asp:Label>
                            </ItemTemplate>
                          <ItemStyle CssClass="clsLeft" />
                          <HeaderStyle CssClass="clsLeft" />
                        </asp:TemplateField>
                    </Columns>
                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                </asp:GridView>
            </td>
        </tr>
    </table>
   <%-- <br />
    <br />--%>
    <table id="tb3" style="border-collapse: separate; left: 0in; position: relative; top: 8px;"
        class="formtable" runat="server">
        <tr style="width: 100%" runat="server" id="tr_rmrk">
            <td id="Td1" class="HeaderColor" runat="server" style="height: 18px">
                <asp:Label ID="lblremark" runat="server" Text="Remarks"></asp:Label>
            </td>
        </tr>
        <tr style="width: 100%" id="tr1" runat="server">
            <td>
                <asp:GridView Style="background-color:white;" ID="GridView1" runat="server" PagerStyle-HorizontalAlign="Center" CssClass="footable" 
                    PagerStyle-Font-Underline="true"  RowStyle-CssClass="formtable"
                    HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                    PageSize="5">
                    <Columns>
                        <asp:TemplateField SortExpression="RemarkID" HeaderText="RemarkID" HeaderStyle-Width="20%" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("Remarkid") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR Type" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="lblcfr" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                            </ItemTemplate>
                          <ItemStyle CssClass="clsLeft" />
                          <HeaderStyle CssClass="clsLeft" />
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Remark" HeaderText="Remark" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="lblCFRRemark" runat="server" Text='<%# Eval("CFRRemark") %>'></asp:Label>
                            </ItemTemplate>
                          <ItemStyle CssClass="clsLeft" />
                          <HeaderStyle CssClass="clsLeft" />
                        </asp:TemplateField>
                    </Columns>
                   
                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                </asp:GridView>
            </td>
        </tr>
    </table>
        </div>
     <%-- added by pranjali on 25022014 for CFR grid deatil start--%>
    <table style="border-collapse: separate; left: 0in; position: relative; top: 8px;"
        class="formtable">
        <tr id="Tr2" style="width: 100%" runat="server" Visible ="false">
            <td id="Td2" class="test" runat="server" style="height: 18px">
                <asp:Label ID="Label1" runat="server" Text="Remarks" CssClass="standardlink "></asp:Label>
            </td>
        </tr>
        <tr style="width: 100%" id="tr3" runat="server" Visible = "false">
            <td>
                <asp:GridView Style="color: blue" ID="GridCFRStatus" runat="server" PagerStyle-HorizontalAlign="Center"
                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable"
                    HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%" OnPageIndexChanging="GridCFRStatus_PageIndexChanging"
                    PageSize="5" Visible = "false">
                    <Columns>
                        <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR For" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="LblCFRFor" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="test" />
                            <ItemStyle HorizontalAlign="left" Font-Bold="False" Width="40%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="RemarkDesc01" HeaderText="Remark" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("RemarkDesc01") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="test" />
                            <ItemStyle HorizontalAlign="left" Font-Bold="False" Width="40%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Status" HeaderText="Status" HeaderStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="test" />
                            <ItemStyle HorizontalAlign="left" Font-Bold="False" Width="20%"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                    <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Blue"></PagerStyle>
                    <RowStyle CssClass="formsublinkeven" HorizontalAlign="Left" ForeColor="Blue" Font-Size="Small">
                    </RowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <%-- added by pranjali on 25022014 for CFR grid deatil end--%>
  
    
    <br />
    <table style="border-collapse: separate; left: 0in; position: relative; top: 8px;"
        class="formtable">
        <tr>
            <td align="center" style="text-align:center;">
          <%--    <div class="btn btn-xs btn-primary"> 
                    <i class="fa fa-reply"></i>--%>
                <asp:Button ID="btnRespond" runat="server" CssClass="standardbutton" Text="Respond"
                    OnClick="btnRespond_Click" Visible="false" /><%--</div>--%>
                     <span style=" padding-left:4px;"></span>
                   <%-- <div class="btn btn-xs btn-primary"> 
                    <i class="fa fa-check"></i>--%>
                <asp:Button ID="btnSubmit" runat="server" CssClass="standardbutton" Text="Submit"
                    OnClick="btnSubmit_Click" /><%--</div>--%>
                     <span style=" padding-left:4px;"></span>
                   <%-- <div class="btn btn-xs btn-primary"> 
                    <i class="fa fa-times"></i>--%>
                <%--<asp:Button ID="btnCancel" runat="server" OnClientClick="doCancel();return false;"
                    CssClass="btn btn-clear" Text="CANCEL" />--%><%--</div>--%>

                                     <asp:LinkButton  ID="btnCancel" runat="server" Text="" CssClass="btn btn-clear" OnClientClick="doCancel();return false;" style="margin-left: 184px;margin-top: -28px;" >   <span   class="glyphicon glyphicon-remove" style="color:red;" ></span> CANCEL </asp:LinkButton> 
                <asp:Label ID="lblMessage" ForeColor="red" runat="server" Visible="false"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdnuserid" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

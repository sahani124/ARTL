<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="POPCFRAssigned.aspx.cs" Inherits="Application_INSC_Recruit_POPCFRAssigned" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
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
     <style type="text/css">
          .disablepage
        {
            display: none;
        }
    .gridview th {
    padding: 3px;
}
         </style>
    <script>
        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
     <%-- <div class="container" style="overflow:auto;width: 100%;">--%>
      <center>
               <div class="panel" id="divAlert" runat="server" style="width: 100%;overflow:auto; height:60%;
                display: block; border-radius: 15px; background-color: white;
                border-color: #d6e9c6; " cellpadding="0" cellspacing="0"  >
              <div id="tb1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divDtls','btnheader');return false;">           
                          <div class="row" id ="tr_header" runat="server">
                    <div class="col-xs-10" style="text-align:left">
                   <%--   <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                     <asp:Label ID="lblHeader" runat="server" CssClass="control-label" Font-Size="19px"  ></asp:Label>
                 
                    </div>
                    <div class="col-xs-2">
                        <span id="btnheader" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
      <div id="divDtls" runat="server" class="panel-body" style="display:block">
         <div id="tb2" runat="server" class="row" style="margin-bottom:5px; margin-left:6%; margin-right:6%; display:block">
     <div id="trcfrcount" class="row" runat="server" >
         <div class="col-md-12" style="margin-bottom:5px;">
                <asp:Label ID="lblcfrraised" runat="server" Text="Raised CFR" CssClass="control-label"></asp:Label>&nbsp;
               <%-- </div>
                  <div class="col-md-2">--%>
                <asp:Label ID="lblcfrraisedcount" runat="server" CssClass="control-label"></asp:Label>&nbsp;
                <%--</div>
                  <div class="col-md-2">--%>
                <asp:Label ID="lblresponded" runat="server" Text="Responded CFR" CssClass="control-label"></asp:Label>
               <%-- </div>
                  <div class="col-md-2">--%>
                <asp:Label ID="lblcfrrespondedcount" runat="server" CssClass="control-label"></asp:Label>&nbsp;
               <%-- </div>
                  <div class="col-md-2">--%>
                 <asp:Label ID="lblcfrclosed" runat="server" Text="Closed CFR" CssClass="control-label"></asp:Label>
                <%-- </div>
                   <div class="col-md-2">--%>
                <asp:Label ID="lblcfrclosedcount" runat="server" CssClass="control-label"></asp:Label>&nbsp;
           </div>
     </div>
       <div id="trDgDetails" class="row" style="margin-bottom:5px;  width:95%; overflow:auto;" runat="server" >
           <%--
                <asp:GridView Style="color: blue" ID="dgDetails" runat="server" PagerStyle-HorizontalAlign="Center"
                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable"
                    HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%"
                    OnPageIndexChanging="dgDetails_PageIndexChanging" PageSize="5">--%>      
                        <asp:GridView  AllowSorting="True" ID="dgDetails" runat="server" CssClass="footable"
                                  
                                       AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                        >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRow" />
                                        <HeaderStyle CssClass="gridview" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>

                    <Columns>
                        <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="False" />
                        <asp:TemplateField HeaderStyle-Wrap="false" ItemStyle-Width="6%" Visible="false">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkAssigned" runat="server" />
                            </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CFR Remark" HeaderText="CFR Remarks">
                            <ItemTemplate>
                                <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRDesc") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR Raised For">
                            <ItemTemplate>
                                <asp:Label ID="lblcfr" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                            </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="RemarkId" HeaderText="" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarkid" runat="server" Text='<%# Eval("RemarkId") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CFRRemarkID" HeaderText="" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblCFRRemarkid" runat="server" Text='<%# Eval("CFRRemarkID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Responded" HeaderText="Responded">
                            <ItemTemplate>
                                <asp:Label ID="Responded" runat="server" Text='<%# Eval("Responded") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                   <%-- <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                    <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Blue"></PagerStyle>
                    <RowStyle CssClass="formsublinkeven" HorizontalAlign="Left" ForeColor="Blue" Font-Size="Small">
                    </RowStyle>--%>
                </asp:GridView>
           
       </div>
    </div>
   <%-- <br />
    <br />--%>
      <div id="tb3" runat="server" class="row" style="margin-bottom:5px; margin-left:6%; margin-right:6%; display:block">
     <div id="tr_rmrk" class="row" runat="server" >
                <asp:Label ID="lblremark" runat="server" Text="Remarks" CssClass="control-label"></asp:Label>
           
       </div>
         <div id="tr1" class="row" style="margin-bottom:5px;  width:95%; overflow:auto;" runat="server" >
           
                <%--<asp:GridView Style="color: blue" ID="GridView1" runat="server" PagerStyle-HorizontalAlign="Center"
                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable"
                    HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                    PageSize="5">--%>
                     <asp:GridView  AllowSorting="True" ID="GridView1" runat="server" CssClass="footable"
                                  
                                       AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                        >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRow" />
                                        <HeaderStyle CssClass="gridview" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField SortExpression="RemarkID" HeaderText="RemarkID" HeaderStyle-Width="20%" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("Remarkid") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR Type" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="lblcfr" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                            </ItemTemplate>
                              <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Remark" HeaderText="Remark" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="lblCFRRemark" runat="server" Text='<%# Eval("CFRRemark") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                   <%-- <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                    <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Blue"></PagerStyle>
                    <RowStyle CssClass="formsublinkeven" HorizontalAlign="Left" ForeColor="Blue" Font-Size="Small">
                    </RowStyle>--%>
                </asp:GridView>
        
      </div>
   </div>
     <%-- added by pranjali on 25022014 for CFR grid deatil start--%>
    <div runat="server" class="row" style="margin-bottom:5px; margin-left:6%; margin-right:6%; display:block">
        <div id="Tr2" class="row" runat="server" Visible ="false" >
                <asp:Label ID="Label1" runat="server" Text="Remarks" CssClass="standardlink "></asp:Label>
          </div>
            <div id="tr3" class="row" runat="server" style="margin-bottom:5px;  width:95%; overflow:auto;" Visible ="false" >
           
               <%-- <asp:GridView Style="color: blue" ID="GridCFRStatus" runat="server" PagerStyle-HorizontalAlign="Center"
                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable"
                    HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%" OnPageIndexChanging="GridCFRStatus_PageIndexChanging"
                    PageSize="5" Visible = "false">--%>
                     <asp:GridView  AllowSorting="True" ID="GridCFRStatus" runat="server" CssClass="footable"
                                  
                                       AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                        >
                    <Columns>
                        <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR For" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="LblCFRFor" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="RemarkDesc01" HeaderText="Remark" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("RemarkDesc01") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Status" HeaderText="Status" HeaderStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                   <%-- <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                    <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Blue"></PagerStyle>
                    <RowStyle CssClass="formsublinkeven" HorizontalAlign="Left" ForeColor="Blue" Font-Size="Small">
                    </RowStyle>--%>
                </asp:GridView>
          
     </div>
   </div>
    <%-- added by pranjali on 25022014 for CFR grid deatil end--%>
  
    
    <br />
   <div>
      <div class="row">
         <div class="col-md-12" style="text-align:center">
          <%--    <div class="btn btn-xs btn-primary"> 
                    <i class="fa fa-reply"></i>--%>
              <%--  <asp:Button ID="btnRespond" runat="server" CssClass="standardbutton" Text="Respond"
                    OnClick="btnRespond_Click" Visible="false" />--%><%--</div>--%>
                 <%--    <span style=" padding-left:4px;"></span>--%>
                       <asp:LinkButton ID="btnRespond" runat="server"  CssClass="btn btn-primary" Text="Respond"
                                    CausesValidation="false" OnClick="btnRespond_Click" Visible="false" >
                                    </asp:LinkButton>
                   <%-- <div class="btn btn-xs btn-primary"> 
                    <i class="fa fa-check"></i>--%>
              <%--  <asp:Button ID="btnSubmit" runat="server" CssClass="standardbutton" Text="Submit"
                    OnClick="btnSubmit_Click" />--%><%--</div>--%>
                     <%--<span style=" padding-left:4px;"></span>--%>
                     <asp:LinkButton ID="btnSubmit" runat="server"  CssClass="btn btn-primary" Text="Submit"
                                    CausesValidation="false" OnClick="btnSubmit_Click"  >
                                    </asp:LinkButton>
                   <%-- <div class="btn btn-xs btn-primary"> 
                    <i class="fa fa-times"></i>--%>
               <%-- <asp:Button ID="btnCancel" runat="server" OnClientClick="doCancel();return false;"
                    CssClass="standardbutton" Text="Cancel" />--%><%--</div>--%>
                     <asp:LinkButton ID="btnCancel" runat="server"  CssClass="btn btn-sample" Text="Cancel"
                                    CausesValidation="false"  OnClientClick="doCancel();return false;" >
                                    </asp:LinkButton>
                <asp:Label ID="lblMessage" ForeColor="red" runat="server" Visible="false" />
       </div>
            </div>
        <div class="row">
            <td>
                <asp:HiddenField ID="hdnuserid" runat="server" />
            </td>
       </div>
  </div>
    </div>
    </div>
    </center>
 <%--   </div>--%>
</asp:Content>

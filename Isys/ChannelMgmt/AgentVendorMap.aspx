<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="AgentVendorMap.aspx.cs" Inherits="Application_INSC_ChannelMgmt_AgentVendorMap" %>

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
    
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />
   <%-- <script src="assets/KMI%20Styles/Bootstrap/datepicker/datetimepicker.js" type="text/javascript"></script>
    <script src="assets/jqueryCalendar/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>--%>
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
 <%-- <link href="../../../assets/KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
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
    <script type="text/javascript" language="javascript">
      
        function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
            var objnewbtn = document.getElementById(btnName);

            if (objnewdiv.style.display == "block") {
                objnewdiv.style.display = "none";
                objnewbtn.className = 'glyphicon glyphicon-collapse-up'
            }
            else {
                objnewdiv.style.display = "block";
                objnewbtn.className = 'glyphicon glyphicon-collapse-down'
            }
        }
         </script>
       <div class="panel panel-success" id="div1" runat="server">
         <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgentdtls','btnAgentdtls');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="lblTitle" runat="server"  CssClass="control-label" ></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnAgentdtls" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                       <div id="divAgentdtls" runat="server" class="panel-body" style="display:block"> 
                        <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">
                                <asp:Label  ID="lblAgentID" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                       <div class="col-md-3">
                                <asp:TextBox ID="lblAgentIDDesc" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                      </div>
                   <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblAgentName"  runat="server" CssClass="control-label"></asp:Label>
                       </div>
                       <div class="col-md-3">
                                <asp:TextBox ID="lblAgentNameDesc" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                      </div>
                      </div>
                            <div class="row" style="margin-bottom:5px;">
                          <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblChannel"  runat="server" CssClass="control-label"></asp:Label>
                          </div>
                         <div class="col-md-3">
                                <asp:TextBox ID="lblChannelVal" class="formcontent" CssClass="form-control"   Enabled="false"  runat="server"></asp:TextBox>
                           </div>
                            <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblSubclass"  runat="server" CssClass="control-label"></asp:Label>
                            </div>
                         <div class="col-md-3">
                                <asp:TextBox ID="lblSubclassVal" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                          </div>
                      </div>
                        </div>
                  </div>
      <div class="panel panel-success" id="div2" runat="server" >
       <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgentmap','btnAgentmap');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="lbltitle2" runat="server"  CssClass="control-label" ></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnAgentmap" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                            <div id="divAgentmap" runat="server" class="panel-body" style="display:block"> 
                     
                             <%--   <asp:GridView ID="gv_AgentVendorMap" runat="server" Width="100%" AutoGenerateColumns="False"
                                    HorizontalAlign="center" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                                    PagerStyle-ForeColor="blue" AllowPaging="True" PageSize="5" OnPageIndexChanging="gv_AgentVendorMap_PageIndexChanging"
                                    OnSorting="gv_AgentVendorMap_Sorting" 
                                    onrowdatabound="gv_AgentVendorMap_RowDataBound">--%>
                                          <asp:GridView  AllowSorting="True" ID="gv_AgentVendorMap" runat="server" CssClass="footable"
                                             OnSorting="gv_AgentVendorMap_Sorting" onrowdatabound="gv_AgentVendorMap_RowDataBound"
                                                         OnPageIndexChanging="gv_AgentVendorMap_PageIndexChanging"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRow" />
                                            <HeaderStyle CssClass="gridview" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:TemplateField  SortExpression="Vendor Code" ItemStyle-HorizontalAlign="Center" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblAgentCode" runat="server" Text='<%# Eval("Agent_SapCode") %>'> </asp:Label>
                                            </ItemTemplate>
                                                 <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField  SortExpression="Vendor Code" ItemStyle-HorizontalAlign="Center" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblVendorCode" runat="server" Text='<%# Eval("HNIN_Sapcode") %>'></asp:Label>
                                            </ItemTemplate>
                                                 <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField  SortExpression="Vendor Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                            </ItemTemplate>
                                                 <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField  SortExpression="Vendor Code" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAgentBasID" runat="server" Text='<%# Eval("Agent_Bas_ID") %>'>
               
                                                </asp:Label>
                                            </ItemTemplate>
                                                 <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField  SortExpression="Vendor Code" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'>
               
                                                </asp:Label>
                                            </ItemTemplate>
                                                 <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                                                               
                                        <asp:TemplateField  SortExpression="Vendor Code" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVendorBasID" runat="server" Text='<%# Eval("VendorBasID") %>'>
               
                                                </asp:Label>
                                            </ItemTemplate>
                                                 <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField >
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrimary" runat="server" Text='<%# Eval("PrmyFlag") %>'>
               
                                                </asp:Label>
                                            </ItemTemplate>
                                                 <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <i class="fa fa-plus-square-o"></i>&nbsp;
                                                <asp:LinkButton runat="server" ID="lbViewIRC" Text="ViewIRC" OnClick="lbViewIRC_Active_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                                <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                            <i class="fa fa-plus"></i>&nbsp;
                                                <asp:LinkButton runat="server" ID="lbAddNew" Text="Add IRC" OnClick="lbAddNew_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                                <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                 <%--   <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White"/>
                                    <PagerStyle HorizontalAlign="Center" Font-Underline="True" ForeColor="Blue"></PagerStyle>
                                    <RowStyle CssClass="formsublinkeven" HorizontalAlign="Left" ForeColor="Blue"></RowStyle>--%>
                                </asp:GridView>
                           
                   </div>
                   </div>
        <tr>
            <td>
                <%--
   <div>
      <table class="formtable" align="center" style="border-collapse: separate;  left: 0in; width:70%; position: relative; top: 8px;" >
         <tr>
            <td align="center" class="test formHeader">
                <b><asp:Label ID="Label3" runat="server" Font-Names="FONT-FAMILY:Verdana, Tahoma, Arial;" Font-Size="12px"  Text="Non Active Vendor List"></asp:Label></b>
            </td>
        </tr>
         <tr>
          <td colspan="2">
             <asp:GridView ID="gv_NonActiveVendor" runat="server" Width="100%" 
                   AutoGenerateColumns="False"  HorizontalAlign="center"  
                   PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                   PagerStyle-ForeColor="blue" AllowPaging="True" PageSize="5" 
                   >
               <Columns>

               
               <asp:TemplateField HeaderText="View IRC Details">
                   <ItemTemplate>
                   <asp:LinkButton runat="server" ID="lbNonActiveViewIRC" Text="ViewIRC" 
                           onclick="lbViewIRC_NonActive_Click1"></asp:LinkButton>
                   
                   </ItemTemplate>
                   
                   </asp:TemplateField>

               </Columns>
                   <HeaderStyle CssClass="standardlink" />
                   <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Blue"></PagerStyle>
                   <RowStyle  CssClass ="formsublinkeven" HorizontalAlign = "Left" ForeColor = "Blue" ></RowStyle>
            </asp:GridView>
    
           
          </td>
         </tr>
     </table>
   </div>--%>
            </td>
        </tr>
          <div class="panel panel-success" id="div5" runat="server" style="display: none">
           <div id="trGridIRC" runat="server" visible="false" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divIRC','btnIRC');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="lblTitle3" runat="server"  CssClass="control-label" ></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnIRC" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                         <div id="divIRC" runat="server" class="panel-body" style="display:block"> 
                        <%--        <asp:GridView ID="gv_IRCCODE" runat="server" Width="100%" AutoGenerateColumns="False"
                                    HorizontalAlign="center" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                                    PagerStyle-ForeColor="blue" AllowPaging="True" PageSize="5" OnPageIndexChanging="gv_IRCCODE_PageIndexChanging"
                                    OnSorting="gv_IRCCODE_Sorting">--%>
                                      <asp:GridView  AllowSorting="True" ID="gv_IRCCODE" runat="server" CssClass="footable"
                                              OnSorting="gv_IRCCODE_Sorting" 
                                                        OnPageIndexChanging="gv_IRCCODE_PageIndexChanging"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRow" />
                                            <HeaderStyle CssClass="gridview" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIRCCOde" runat="server" Text='<%# Eval("IRCCODE") %>'></asp:Label>
                                            </ItemTemplate>
                                                  <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIRCCOde" runat="server" Text='<%# Eval("IRCNAME") %>'></asp:Label>
                                            </ItemTemplate>
                                                  <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAgentCOde" runat="server" Text='<%# Eval("MemCode") %>'></asp:Label>
                                                <%--<asp:Label ID="lblAgentCOde" runat="server" Text='<%# Eval("MemCode") %>'></asp:Label>--%>
                                            </ItemTemplate>
                                                  <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblLegalName" runat="server" Text='<%# Eval("LegalName") %>'></asp:Label>
                                            </ItemTemplate>
                                                  <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAgentType" runat="server" Text='<%# Eval("MemType") %>'></asp:Label>
                                            </ItemTemplate>
                                                  <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblBizSrc" runat="server" Text='<%# Eval("BizSrc") %>'></asp:Label>
                                            </ItemTemplate>
                                                  <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblChnCls" runat="server" Text='<%# Eval("ChnCls") %>'></asp:Label>
                                            </ItemTemplate>
                                                  <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
                                            </ItemTemplate>
                                                  <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                   <%-- <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White"/>
                                    <PagerStyle HorizontalAlign="Center" Font-Underline="True" ForeColor="Blue" CssClass="pagelink">
                                    </PagerStyle>
                                    <RowStyle CssClass="formsublinkeven" HorizontalAlign="Left" ForeColor="Blue"></RowStyle>--%>
                                </asp:GridView>
                          </div>
                        </div>   
             <div class="row">
             <div class="col-md-12" style="text-align:center">
                         <%--       <asp:Button ID="btnAddNew" runat="server" CssClass="standardbutton" OnClick="btnAddNew_Click" Width="100px"/>--%>
                                  <asp:LinkButton ID="btnAddNew" runat="server"  CssClass="btn btn-primary" 
                          OnClick="btnAddNew_Click" TabIndex="43" >
                                  <span class="glyphicon glyphicon-plus" style="color:White"> </span> Add New IRC
                                  </asp:LinkButton>&nbsp;&nbsp;
                           <%--     <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CssClass="standardbutton" Width="80px"
                                    OnClick="btnCancel_Click" TabIndex="189" />--%>
                                      <asp:LinkButton ID="btnCancel" runat="server"   CssClass="btn btn-danger" 
                            OnClick="btnCancel_Click" TabIndex="43" >
                                  <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                                 </asp:LinkButton>
             </div>
                     </div>
                  
</asp:Content>

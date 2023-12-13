<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="AgtVenMapping.aspx.cs" Inherits="Application_INSC_ChannelMgmt_AgtVenMapping" %>

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
        function popup() {
            $("#myModal").modal();
        }


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
        ////debugger;
        function funpopup(a) {
            debugger;
            alert('san');
            if (a == 'Vendor') {
                var myExtender = $find('mdlViewBID');
                myExtender.show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../ISys/ChannelMgmt/AgentVendorSearch.aspx?strVendCd=" + document.getElementById('<%=txtVendoreCode.ClientID %>').value
            + "&strVendName=" + document.getElementById('<%=lblVenNameData.ClientID %>').id
            + "&strVendChn=" + document.getElementById('<%=lblVenChnData.ClientID %>').id
            + "&strVendChnCls=" + document.getElementById('<%=lblSubclassData.ClientID %>').id
            + "&strHidden=" + document.getElementById('<%=hdnVendCode.ClientID %>').value
            + "&strHidden=" + document.getElementById('<%=hdnVendName.ClientID %>').value
            + "&strHidden=" + document.getElementById('<%=hdnVendBizSrc.ClientID %>').value
            + "&strHidden=" + document.getElementById('<%=hdnVendChnCls.ClientID %>').value
            + "&mdlpopup=mdlViewBID"
            + "&agntype=" + a + "";
                //return false;
            }
        }
        function funValidate() {
            ////debugger;
            alert('Please enter mandatory field(s)');
            return false;
        }
//        function ShowReqDtl(divId, btnId) {
//            if (document.getElementById(divId).style.display == "block") {
//                document.getElementById(divId).style.display = "none";
//                //document.getElementById(divId).value = '+'
//                document.getElementById(btnId).value = '+';
//            }
//            else {
//                document.getElementById(divId).style.display = "block";
//                //document.getElementById(btnId).value = '-'
//                document.getElementById(btnId).value = '-';
//            }
//        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    
              <div class="panel panel-success" id="div1" runat="server">
                 <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgentdtls','btnAgentdtls');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="lblTitle" runat="server" Text="Agent Details"  CssClass="control-label" ></asp:Label>
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

                                        <asp:Label CssClass="control-label" ID="lblAgentID" Text="Agent Code" runat="server"></asp:Label>
                               </div>
                                 <div class="col-md-3">
                                        <asp:TextBox ID="lblAgentIDDesc" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                              </div>
                                    <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblAgentName" Text="Agent Name" CssClass="control-label" runat="server"></asp:Label>
                                </div>
                                      <div class="col-md-3">
                                        <asp:TextBox ID="lblAgentNameDesc" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                                 </div>
                            </div>
                            <div class="row" style="margin-bottom:5px;">
                            <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblChannel" CssClass="control-label" Text="Hierarchy Name" runat="server"></asp:Label>
                            </div>
                                 <div class="col-md-3">
                                        <asp:TextBox ID="lblChannelVal" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                                 </div>
                                    <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblSubclass" CssClass="control-label" Text="Sub Class" runat="server"></asp:Label>
                                </div>
                                 <div class="col-md-3">
                                        <asp:TextBox ID="lblSubclassVal" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                              </div>
                             </div>
                                </div>
                         </div>
                          <div class="panel panel-success" id="div2" style="display: none" runat="server">
               <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgentVendorMap','btnPersonal');return false;"> 
                    <div class="row" id="trTitle" runat="server" visible="false">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="lbltitle2" runat="server" Text="Agent Vendor Mapping Details"  CssClass="control-label" ></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnPersonal" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div> 
                    <div id="divAgentVendorMap" runat="server" class="panel-body" style="display:block"> 
                           
                               <%--         <asp:GridView ID="gv_AgentVendorMap" runat="server" Width="100%" AutoGenerateColumns="False"
                                            HorizontalAlign="center" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                                            PagerStyle-ForeColor="blue" AllowPaging="True" PageSize="5" OnPageIndexChanging="gv_AgentVendorMap_PageIndexChanging"
                                            OnSorting="gv_AgentVendorMap_Sorting" AllowSorting="true">--%>
                                                  <asp:GridView  AllowSorting="True" ID="gv_AgentVendorMap" runat="server" CssClass="footable"
                                             OnSorting="gv_AgentVendorMap_Sorting"
                                                         OnPageIndexChanging="gv_AgentVendorMap_PageIndexChanging"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                                       
                                          <RowStyle CssClass="GridViewRow"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Agent Code"  SortExpression="AgentCode" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgentCode" runat="server" Text='<%# Eval("MemCode") %>'> </asp:Label>
                                                    </ItemTemplate>
                                                         <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Vendor Code" SortExpression="VendorCode" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVendorCode" runat="server" Text='<%# Eval("VendorCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                       <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Vendor Name" SortExpression="VendorName" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                           <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="Status" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'>
               
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                           <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Relationship Code"  SortExpression="VendorBasID" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVendorBasID" runat="server" Text='<%# Eval("VendorBasID") %>'>
               
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                      <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Primary"  SortExpression="PrmyFlag" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPrimary" runat="server" Text='<%# Eval("PrmyFlag") %>'>
               
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                           <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rel Start Date" SortExpression="RelStartDate" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRelStartDate" runat="server" Text='<%# Eval("RelStartDate") %>'>
               
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                         <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                         
                                        </asp:GridView>
                                  
                        </div>
                   
                </div>
                 <div class="panel panel-success" id="trVendDtls"  visible="false" runat="server">
                    <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divVendordtls','btnVendordtls');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="Label1" runat="server" Text="Vendor Details"  CssClass="control-label" ></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnVendordtls" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                       <div id="divVendordtls" runat="server" class="panel-body" style="display:block"> 
                                 <div class="row" style="margin-bottom:5px;">
                                <div class="col-md-3" style="text-align:left">
                                        <asp:Label runat="server" CssClass="control-label" Text="IsPrimary" ID="Label2"></asp:Label>
                              </div>
                                <div class="col-md-3">
                                        <asp:CheckBox ID="chkPrimary" runat="server" />
                              </div>
                                  <div class="col-md-3">
                                  </div>
                                  <div class="col-md-3">
                                  </div>
                             </div>
                                <div class="row" style="margin-bottom:5px;">
                                <div class="col-md-3" style="text-align:left">
                                        <asp:Label runat="server" Text="Vendor Code" CssClass="control-label" ID="lblVendorcode"></asp:Label>
                               </div>
                                <div class="col-md-3" style="display: flex">
                                        <asp:TextBox ID="txtVendoreCode" runat="server" TabIndex="2"  CssClass="form-control" ></asp:TextBox>
                                        <asp:LinkButton ID="btnVendorSrch" style="margin-left: 2px"  runat="server" Text="...." CssClass="btn btn-primary" ></asp:LinkButton>
                                  </div>
                                        <div class="col-md-3" style="text-align:left">
                                        <asp:Label runat="server" Text="Vendor Name" CssClass="control-label" ID="lblVendorName"></asp:Label>
                               </div>
                                <div class="col-md-3" >
                                        <asp:TextBox runat="server" CssClass="form-control"   Enabled="false" ID="lblVenNameData"></asp:TextBox>
                                  </div>
                               </div>
                                <div class="row" style="margin-bottom:5px;">
                                 <div class="col-md-3" style="text-align:left">
                                        <asp:Label runat="server" Text="Hierarchy Name" CssClass="control-label" ID="lblVenChn"></asp:Label>
                                  </div>
                                  <div class="col-md-3">
                                        <asp:TextBox runat="server" CssClass="form-control"   Enabled="false" ID="lblVenChnData"></asp:TextBox>
                                 </div>
                                 <div class="col-md-3" style="text-align:left">
                                        <asp:Label runat="server" Text="Sub Class" CssClass="control-label" ID="lblSubClass1"></asp:Label>
                                 </div>
                                 <div class="col-md-3">
                                        <asp:TextBox runat="server" CssClass="form-control"   Enabled="false" ID="lblSubclassData"></asp:TextBox>
                                 </div>
                               </div>
                                </div>
                </div>
                <div class="row">
                  <div class="col-md-12" style="text-align:center">
                        <%--<asp:Button ID="btnAddNew" runat="server" Text="ADD MAPPING" CssClass="standardbutton" Width="100px"
                            OnClick="btnAddNew_Click" />&nbsp;&nbsp;--%>
                            <asp:LinkButton ID="btnAddNew" runat="server"  CssClass="btn btn-primary" 
                          OnClick="btnAddNew_Click" TabIndex="43" >
                                  <span class="glyphicon glyphicon-plus" style="color:White"> </span> Add Mapping
                                  </asp:LinkButton>&nbsp;&nbsp;
                        <%--<asp:Button ID="btnCreateMap" runat="server" Text="CREATE" Visible="false" CssClass="standardbutton" Width="80px"
                            OnClick="btnCreateMap_Click" />--%>
                             <asp:LinkButton ID="btnCreateMap" runat="server" Visible="false"  CssClass="btn btn-primary" 
                            OnClick="btnCreateMap_Click" TabIndex="43" >
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Save
                                  </asp:LinkButton>&nbsp;&nbsp;
                     <%--   <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CssClass="standardbutton" Width="80px"
                            OnClick="btnCancel_Click" TabIndex="189" />--%>
                              <asp:LinkButton ID="btnCancel" runat="server"   CssClass="btn btn-danger" 
                            OnClick="btnCancel_Click" TabIndex="43" >
                                  <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                                 </asp:LinkButton>
                 </div>
            </div>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdnAgtCode"  runat="server"/>
            <asp:HiddenField ID="hdnAgentName"  runat="server"/>
            <asp:HiddenField ID="hdnAgnBizSrc"  runat="server"/>
            <asp:HiddenField ID="hdnAgnChnCls"  runat="server"/>
                        <asp:HiddenField ID="hdnVendCode" runat="server" />
                        <asp:HiddenField ID="hdnVendBizSrc" runat="server" />
                        <asp:HiddenField ID="hdnVendName" runat="server" />
                        <asp:HiddenField ID="hdnVendChnCls" runat="server" />
                    </td>
                </tr>
          
    <asp:Label runat="server" ID="Label3" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="Label3" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnlMdl" Width="700px"  display="none">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div>
                            <iframe runat="server" id="ifrmMdlPopup"  width="900px" height="400px"
                                frameborder="1" display="none"></iframe>
                    </div>   
                      <div class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">
                            <asp:Button ID="btnclose" Visible="false" Text="Close" runat="server" CssClass="btn btn-primary" />
                        </div>
                    </div>
                
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnclose" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
          <div class="modal-content" >
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label13" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl_popup" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-primary" data-dismiss="modal" style='margin-top:-6px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      </div>
  </div>
</asp:Content>

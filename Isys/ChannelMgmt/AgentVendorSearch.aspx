<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="AgentVendorSearch.aspx.cs" Inherits="Application_INSC_ChannelMgmt_AgentVendorSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
     <style type="text/css">
           
          .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
        }
        .disablepage
        {
            display: none;
        }
   
        .pagelink span
        {
            font-weight: bold;
        }
        /*Added: Parag @ 25032014*/
    </style>
    <script type="text/javascript" language="javascript">

   

        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
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
            catch (err) {
                ShowError(err.description);
            }
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();


        }

        function doSelect(args1, args2, args3, args4, args5) {
            debugger;

            if (args5 == "Agent") {
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_txtAgtCode").value = args1;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdnAgtCode").value = args1;
                
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_lblNameData").value = args2;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdnAgentName").value = args2;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_lblAgnChnData").value = args3;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdnAgnBizSrc").value = args3;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_lblAgnSubClsData").value = args4;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdnAgnChnCls").value = args4;
                window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
                
                return false;
            }
            if (args5 == "Vendor") {
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_txtVendoreCode").value = args1;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdnVendCode").value = args1;
                
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_lblVenNameData").value = args2;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdnVendName").value = args2;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_lblVenChnData").value = args3;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdnVendBizSrc").value = args3;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_lblSubclassData").value = args4;
                window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdnVendChnCls").value = args4;
                window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
               
                return false;
            }
        }
    
    </script>
    <script type="text/javascript" language="javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() != undefined) {
                args.set_errorHandled(true);
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div class="panel panel-success" runat="server">
            <div class="panel panel-success" id="divHdr" runat="server" style='margin-top:10px;'>
                   <div id="Div7" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divsrch1','demo');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="lblTitle" runat="server"  CssClass="control-label"  Font-Bold="false"></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="demo" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                      <div id="divsrch1" runat="server" class="panel-body">
            <div class="row" style="margin-bottom:5px;">
                <div class="col-md-3" style="text-align:left">
                        <asp:Label ID="lblSalesChannel" CssClass="control-label" runat="server"></asp:Label>
                 </div>
                   <div class="col-md-3">
                        <asp:DropDownList ID="ddlSalesChannel" runat="server" AutoPostBack="true"
                       CssClass="form-control" OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                        </asp:DropDownList>
                   </div>
                <div class="col-md-3" style="text-align:left">
                        <asp:Label ID="lblChannelSubClass" CssClass="control-label" runat="server"></asp:Label>
                   </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlChannelSubClass"  runat="server"
                            AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlChannelSubClass_SelectedIndexChanged">
                        </asp:DropDownList>
                  </div>
            </div>
                 <div class="row" style="margin-bottom:5px;">
                 <div class="col-md-3" style="text-align:left">
                        <asp:Label ID="lblAgentType" CssClass="control-label" runat="server"></asp:Label>
                  </div>
                   <div class="col-md-3">
                        <asp:DropDownList ID="ddlAgentType" AutoPostBack="true" CssClass="form-control" 
                            runat="server">
                        </asp:DropDownList>
                  </div>
                   <div class="col-md-3" style="text-align:left">
                        <asp:Label ID="lblAgentName" CssClass="control-label" runat="server"></asp:Label>
                 </div>
                  <div class="col-md-3">
                        <asp:TextBox ID="txtAgentName" CssClass="form-control"  runat="server"></asp:TextBox>
                  </div>
              </div>
            <div class="row" style="margin-bottom:5px;">
                   <div class="col-md-3" style="text-align:center">
                   <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" AutoPostback="false"
                                    OnClick="btnSearch_Click" visble="true">
                                 <span class="glyphicon glyphicon-search" style='color:White;'></span> 
                                </asp:LinkButton> 
                                   <%-- <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClientClick="doCancel();return false;">
                             <span class="glyphicon glyphicon-remove btnglyphicon"> </span> CANCEL </asp:LinkButton>--%>
                      <%--  <asp:Button ID="btnSearch" CssClass="standardbutton" runat="server" Width="80px"
                            OnClick="btnSearch_Click" />--%>
                   </div>
            </div>
              <div class="row" style="margin-bottom:5px;">
               <div class="col-md-12">
                      <%--  <asp:GridView ID="gv_AgentVendorMap" runat="server" Width="100%" AutoGenerateColumns="False"
                            HorizontalAlign="center" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                            PagerStyle-ForeColor="blue" AllowPaging="True" AllowSorting="true" PageSize="10"
                            OnPageIndexChanging="gv_AgentVendorMap_PageIndexChanging" OnSorting="gv_AgentVendorMap_Sorting">--%>
                              <asp:GridView  AllowSorting="True" ID="gv_AgentVendorMap" runat="server" CssClass="footable"
                                                   OnPageIndexChanging="gv_AgentVendorMap_PageIndexChanging" OnSorting="gv_AgentVendorMap_Sorting" 
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   >
                                       <RowStyle CssClass="GridViewRow"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                            <EmptyDataTemplate>
                                <center>
                                    <asp:Label ID="lblNoRecord" runat="server" CssClass="msgerror" Text="No Record Found"></asp:Label>
                                </center>
                            </EmptyDataTemplate>
                            <Columns>
                             <asp:TemplateField ItemStyle-HorizontalAlign="Center" SortExpression="AgtBrCode" HeaderText="Ins Ref Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAgtBrCode" runat="server" Text='<%# Eval("AgtBrCode") %>' > </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" SortExpression="AgentCode"
                                    HeaderText="Member Code">
                                    <ItemTemplate>
                                    <i class="fa fa-edit"></i>&nbsp;
                                        <asp:LinkButton ID="lblAgentCode" runat="server" Text='<%# Eval("MemCode") %>'  ForeColor="Green" OnClick="lblAgentCode_Click"> </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="LegalName" HeaderText="Member Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAgentName" runat="server" Text='<%# Eval("LegalName") %>'></asp:Label>
                                    </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="ChannelDesc01" HeaderText="Channel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChannelDesc" runat="server" Text='<%# Eval("ChannelDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="ChnClsDesc01" HeaderText="Sub Class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChnCLsDesc" runat="server" Text='<%# Eval("ChnClsDesc01") %>'>
               
                                        </asp:Label>
                                    </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                           
                        </asp:GridView>
                        </div>
                        <div id="divPage" visible="false" style='margin-left:338px;'  runat="server" class="pagination">
                <center>
                    <table>
                        <tr>

                           <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 44px; border-style: solid;
                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />  
                          <%--  <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 44px; border-style: solid;
                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                        </ContentTemplate>
                            </asp:UpdatePanel>--%>
                              
                        </tr>
                    </table>
                </center>
                <br />
            </div>
                </div>
                </div>
                </div>

                 <div class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="btnclose"  runat="server" CssClass="btn btn-primary" OnClientClick="doCancel();return false;">
                              <span class="glyphicon glyphicon-ban-circle"  style='color:White;'> Close</span> 
                              </asp:LinkButton>
                        </div>
                    </div>
                    <br />
        </div>
 <div class="col-md-12" style="text-align: center">
                    <asp:Label ID="lblMessage" runat="server" Visible="false" style="text-align: center" ForeColor="Red"></asp:Label>
                    </div>

</asp:Content>

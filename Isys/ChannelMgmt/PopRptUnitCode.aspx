<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopRptUnitCode.aspx.cs" Inherits="Application_INSC_ChannelMgmt_PopRptUnitCode" %>

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
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">

        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        function doSelect(args1, args2, args3,args4) {
            window.parent.document.getElementById('<%=Request.QueryString["Unitdesc"].ToString()%>').value = args2;
            window.parent.document.getElementById('<%=Request.QueryString["RptUntCode"].ToString()%>').value = args1;
            window.parent.document.getElementById('<%=Request.QueryString["UnitCode"].ToString()%>').innerText = args1;
            window.parent.document.getElementById('<%=Request.QueryString["ddl"].ToString()%>').value = args3;
            window.parent.document.getElementById('<%=Request.QueryString["ddlsch"].ToString()%>').value = args4;
            window.parent.document.getElementById('<%=Request.QueryString["Unitdesc"].ToString()%>').focus();
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            return false;
        }

        function doClear() {
            document.getElementById("<%=txtUntCode.ClientID%>").value = "";
            document.getElementById("<%=txtUntName.ClientID%>").value = "";
        }



        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>

     <style type="text/css">
         .btn-tab
        {
            color:#3c763d;
            background-color:#dff0d8;
            border-color:#d6e9c6;
        }
            
             /*.nav-tabs > li.active > a,
        .nav-tabs > li.active > a:hover,
        .nav-tabs > li.active > a:focus{
            color: #555555;
            background-color: #dff0d8;  
        } 
        
        ul#menu li a:active{background:white;}
            
            
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
            ul#menu
            {
                padding: 0;
                margin-right: 69%;
            }
            
            ul#menu li
            {
                display: inline;
            }
            
            
            
            ul#menu li a
            {
                background-color: Silver;
                color: black;
                cursor: pointer;
                padding: 10px 20px;
                text-decoration: none;
                border-radius: 4px 4px 0 0;
            }
            ul#menu li a:active
            {
                background: white;
            }
            
            ul#menu li a:hover
            {
                background-color: red;
            }*/
        </style>
  
    <asp:ScriptManager ID="scriptMgr" runat="server" />
    <div>
       <div class="panel " id="div1" runat="server" style='margin-right:0px;'>
         <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divAgentdtls','span1');return false;"> 
                    <div class="row">
                    <div class="col-xs-10" style="text-align:left">
                     <asp:Label ID="lblhdr" runat="server" Text="Manager Search" Font-Size="19px" ></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-xs-2">
                    <span id="span1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                      <div id="divAgentdtls" runat="server" class="panel-body" style="display:block"> 
         <div class="row" style="margin-bottom:5px;">
               <div class="col-md-3" style="text-align:left">
                    <asp:Label ID="lblUntCode" runat="server" CssClass="control-label" Text="Unit Code"></asp:Label>
              </div>
               <div class="col-md-3">
                    <asp:TextBox ID="txtUntCode" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                  <div class="col-md-3" style="text-align:left">
                    <asp:Label ID="lblUntName" runat="server" CssClass="control-label" Text="Unit Name"></asp:Label>
                </div>
               <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="txtUntName" runat="server"></asp:TextBox>
               </div>
         </div>
         
         <br />
         <div class="row" style="margin-bottom:5px;">
             <div class="col-md-12" style="text-align:center">
                <%--    <asp:Button CssClass="standardbutton" ID="btnSearch" runat="server" Text="SEARCH"
                        Width="80px" onclick="btnSearch_Click" />&nbsp;&nbsp;--%>
                           <asp:LinkButton ID="btnSearch" runat="server"  CssClass="btn btn-sample" 
                          OnClick="btnSearch_Click" >
                                  <span class="glyphicon glyphicon-search BtnGlyphicon" > </span> Search
                                  </asp:LinkButton>&nbsp;&nbsp;
                <%--    <asp:Button class="standardbutton" ID="btnClear" runat="server" Width="80px" Text="CLEAR"
                        OnClientClick="doClear();return false;" />&nbsp;&nbsp;--%>
                           <asp:LinkButton ID="btnClear" runat="server"  CssClass="btn btn-sample" 
                       OnClientClick="doClear();return false;">
                                  <span class="glyphicon glyphicon-erase BtnGlyphicon" > </span> Clear
                                  </asp:LinkButton>&nbsp;&nbsp;
                  <%--  <asp:Button CssClass="standardbutton" ID="btnCancel" runat="server" Text="CANCEL"
                        Width="80px" OnClientClick="doCancel();return false;" />--%>
                            <asp:LinkButton ID="btnCancel" runat="server"  CssClass="btn btn-sample" 
                       OnClientClick="doCancel();return false;">
                                  <span class="glyphicon glyphicon-remove BtnGlyphicon" > </span> Cancel
                                  </asp:LinkButton>&nbsp;&nbsp;
               </div>
            </div>
            <br />
            <div class="row" style="margin-bottom:5px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            
                            <asp:Label ID="lblErrMsg" runat="server" CssClass="msgerror2" Visible="False"></asp:Label>
                          <%--  <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                PageSize="10" Width="100%" onrowdatabound="gv_RowDataBound" 
                                onsorting="gv_Sorting" onpageindexchanging="gv_PageIndexChanging" >
                                <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White"/>
                                <AlternatingRowStyle CssClass="sublinkeven" />
                                <RowStyle CssClass="sublinkodd" />
                                <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />--%>
                                 <asp:GridView  AllowSorting="True" ID="gv" runat="server" CssClass="footable"
                                             onrowdatabound="gv_RowDataBound" 
                                onsorting="gv_Sorting" onpageindexchanging="gv_PageIndexChanging" style="margin-top:10px"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   >
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Unit Code" SortExpression="UNitcode">
                                        <ItemTemplate>
                                            <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                            <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("UNitcode") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CmsUnitCode" HeaderText="CMS Unit Code" SortExpression="CmsUnitCode" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" />
                                    <asp:BoundField DataField="UnitLegalName" HeaderText="Unit Name" SortExpression="UnitLegalName" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="UnitDesc01" HeaderText="Unit Type" SortExpression="UnitDesc01" ItemStyle-HorizontalAlign="Left" />
                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="UnitType" Visible="false">
                                        <ItemTemplate>
                                            <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                            <asp:LinkButton ID="lnkunttyp" runat="server" Text='<%# Bind("UnitType") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                      <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Class" SortExpression="ChnCls" Visible="false">
                                        <ItemTemplate>
                                            <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                            <asp:Label ID="lbluntschnl" runat="server" Text='<%# Bind("ChnCls") %>'></asp:Label>
                                        </ItemTemplate>
                                     <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            <br/>
                              <center>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                        <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 35px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                            border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                            float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                
                </div>
            </div>
               </div>
    </div>
</asp:Content>

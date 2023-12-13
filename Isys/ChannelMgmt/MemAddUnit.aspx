<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MemAddUnit.aspx.cs" Inherits="Application_Isys_ChannelMgmt_MemAddUnit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
   
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
   
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
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
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>

    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
 
    <style>
        .hidscroll {
            margin-left: 0px !important;
            margin-right: 0px !important;
            margin-top: 0px !important;
            margin-bottom: 0px !important;
            border-color: #d6e9c6 !important;
        }
    </style>

    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script type="text/javascript">

        //Comented by usha   for multiselection 
        function CheckSingleCheckbox(ob) {
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = true;
                    }
                }
            }
        }
    </script>
    <script language="javascript" type="text/javascript">

        function doSelect(strUnitCode, strUnitDesc, strCmpUntCode, struntadr) {

            debugger;
            window.parent.document.getElementById('<%=Request.QueryString["OutUntCode"].ToString()%>').value = strUnitDesc + '(' + strCmpUntCode + ')';
            window.parent.document.getElementById('<%=Request.QueryString["OutUntDesc"].ToString()%>').value = strUnitDesc;

            window.parent.document.getElementById('<%=Request.QueryString["CmpUntObj"].ToString()%>').innerText = strUnitCode;
            window.parent.document.getElementById('<%=Request.QueryString["hdn1"].ToString()%>').value = strUnitCode;

            window.parent.document.getElementById('<%=Request.QueryString["UntAdr"].ToString()%>').innerText = struntadr;
            window.parent.document.getElementById('<%=Request.QueryString["hdn2"].ToString()%>').value = struntadr;
            window.parent.document.getElementById('<%=Request.QueryString["OutUntCode"].ToString()%>').focus();



            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            return false;
        }


        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

        function doOk() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();

            window.parent.document.getElementById("btnAddunitgrid").click();
        }

        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";

                }
                else {
                    objnewdiv.style.display = "block";

                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }






    </script>
    <asp:ScriptManager ID="scrUnt" runat="server">
    </asp:ScriptManager>
    <center>
       
      
       <div class="panel hidscroll" style="max-height:500px; overflow-y:scroll">
         <div class="panel" style="margin-left:0px;margin-right:0px">
             
                               <div id="Div4" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_demo','Span3');return false;">           
                          <div class="row">
                    <div class="col-xs-10" style="text-align:left">
                    <asp:Label ID="lblUnitDetails" Text="Unit Details" style="font-size:19px" runat="server" Font-Bold="true"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="Span3" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>    
           
           
                                <div id="demo" runat="server" style="display: block;" class="panel-body">
           
           <div class="row" style="margin-top: 7px;">
                 <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblUntCode" runat="server" CssClass="control-label" Text="Unit Code"></asp:Label>
                </div>
               <div class="col-sm-3" style="margin-bottom: 7px;">
                    <asp:TextBox ID="txtUntCode" runat="server"  CssClass="form-control" TabIndex="1"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftx_txtuntcd" runat="server"
                    TargetControlID="txtUntCode" FilterType="Custom, Numbers">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
                <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblUntName" runat="server" CssClass="control-label" Text="Unit Description"></asp:Label>
                </div>
             <div class="col-sm-3">
                    <asp:TextBox  CssClass="form-control" ID="txtUntName" runat="server" TabIndex="2"></asp:TextBox>
                     <ajaxToolkit:FilteredTextBoxExtender ID="ftx_untName" runat="server"
                     TargetControlID="txtUntName" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
          </div>

          <div class="row" style="margin-top: 7px;">
                     <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblUntType" CssClass="control-label" Text="Unit Type" runat="server" />
                </div>
              <div class="col-sm-3">
                    <asp:TextBox ID="txtUntType" CssClass="form-control" runat="server" TabIndex="3" />  
                     <ajaxToolkit:FilteredTextBoxExtender ID="ftx_UnitTyp" runat="server"
                     TargetControlID="txtUntType" FilterType="UppercaseLetters, LowercaseLetters, Custom">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
           </div>
        
           
            <br />

              <div class="row">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" CausesValidation="false"
                                    Text="SEARCH" OnClick="btnSearch_Click" OnClientClick="javascript:validate();"
                                    TabIndex="4">
                         <span class="glyphicon glyphicon-search" style='color: White;'></span> Search
                        </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" CausesValidation="False"
                                     OnClientClick="doCancel();return false;" OnClick="btnClear_Click" TabIndex="5">
                              <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> Cancel
                             </asp:LinkButton>
                            </div>
                        </div>

         <br />

        <div class="panel " id="div1" runat="server">
              <asp:UpdatePanel ID="updUntLst" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvUntLst" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="footable"
                                AllowSorting="true"  RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue"
                                PageSize="20" PagerStyle-Font-Underline="true" PagerStyle-HorizontalAlign="Center"
                                OnRowDataBound="gvUntLst_RowDataBound" OnPageIndexChanging="gvUntLst_PageIndexChanging"
                                OnSorting="gvUntLst_Sorting">
                                 <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <EmptyDataTemplate>
                                    <center>
                                        <asp:Label ID="lblMessage" runat="server" Text="0 record found" ForeColor="Red"></asp:Label>
                                    </center>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Unit Code" SortExpression="UnitCode">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkUntCode" runat="server" Text='<%# Bind("UnitCode") %>' Enabled="false"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Description" SortExpression="UnitDesc01">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitDesc" Text='<%#Bind("UnitDesc01") %>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="UnitTypDesc">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitType" Text='<%#Bind("UnitTypDesc") %>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CmsUnitCode" HeaderText="Unit Code" SortExpression="CmsUnitCode" Visible="false">
                                        <HeaderStyle Width="20%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <%--added by akshay on 17-02-14 added template field for unit address start--%>
                                    <asp:TemplateField HeaderText="Unit Address" SortExpression="Adr1" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUntAddr" runat="server" Text='<%# Bind("Adr1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--added by akshay on 17-02-14 added template field for unit address end--%>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                           <%--<asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChkSelect_CheckedChanged"
                                                onclick ="CheckSingleCheckbox(this)"  />  --%>  
                                              <asp:CheckBox ID="ChkSelect" runat="server"  OnCheckedChanged="ChkSelect_CheckedChanged"   />
                                      
                                        </ItemTemplate>
                                          <ItemStyle CssClass="gvItemCenter" />
                                    </asp:TemplateField>
                                </Columns>
                               
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
           
           
            <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                    <asp:LinkButton ID="btnOK" runat="server" CssClass="btn btn-sample"  onclick="btnOK_Click"  style='margin-top: -6px;border-radius: 15px;'>
                     <span class="	glyphicon glyphicon-ok" style='color: White;'></span> OK
                    </asp:LinkButton>
               </div>
               </div>       
               

</div>
        
        </div>
   </div>

    </center>
</asp:Content>



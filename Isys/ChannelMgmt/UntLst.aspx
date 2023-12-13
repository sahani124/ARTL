<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="UntLst.aspx.cs"
    Inherits="Application_INSC_ChannelMgmt_UntLst" Title="Unit List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
     <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"  type="text/css" />
  <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
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


 
    <style>
        .gridview th {
    padding: 0px;
    height: 40px;
    border-color: #53accd !important;
    text-align: left;
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
}
        .clsleft{
            text-align:left;
        }
         .clscenter{
            text-align:center;
        }

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
        function CheckSingleCheckbox(ob) {
            //var grid = ob.parentNode.parentNode.parentNode;
            //var inputs = grid.getElementsByTagName("input");
            //for (var i = 0; i < inputs.length; i++) {
            //    if (inputs[i].type == "checkbox") {
            //        if (ob.checked && inputs[i] != ob && inputs[i].checked) {
            //            inputs[i].checked = true;
            //        }
            //    }
            //}
        }
    </script>
    <script language="javascript" type="text/javascript">

        function doSelect(strUnitCode, strUnitDesc, strCmpUntCode, struntadr) {
            /*Added by swapnesh
            removed doEncodeToParent function
            Added by swapnesh end*/
            debugger;
            window.parent.document.getElementById('<%=Request.QueryString["OutUntCode"].ToString()%>').value = strUnitDesc + '(' + strCmpUntCode + ')';
            window.parent.document.getElementById('<%=Request.QueryString["OutUntDesc"].ToString()%>').value = strUnitDesc;

            window.parent.document.getElementById('<%=Request.QueryString["CmpUntObj"].ToString()%>').innerText = strUnitCode;
            window.parent.document.getElementById('<%=Request.QueryString["hdn1"].ToString()%>').value = strUnitCode;

            window.parent.document.getElementById('<%=Request.QueryString["UntAdr"].ToString()%>').innerText = struntadr;
            window.parent.document.getElementById('<%=Request.QueryString["hdn2"].ToString()%>').value = struntadr;
            window.parent.document.getElementById('<%=Request.QueryString["OutUntCode"].ToString()%>').focus();



            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            //Added By Ibrahim 28-05-2013 After select a value the popup will hide 
            return false;
        }


        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
                  }

                  function doOk() {
                      window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();

            window.parent.document.getElementById("btnunitgrid").click();
        }

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
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-down'
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
       
       
       
       
           <%-- <tr>
                <td align="center" class="test" colspan="4">
                    <asp:Label ID="lblUnitDetails" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>--%>
       <div class="card PanelInsideTab" style="max-height:500px;">
         <div class="PanelInsideTab_body" style="margin-left:0px;margin-right:0px">
             
                               <div id="Div4" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_demo','Span3');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                    <asp:Label ID="lblUnitDetails" Text="Unit Details" style="font-size:19px" runat="server" Font-Bold="true"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="Span3" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc !important;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>    
           
           
                                <div id="demo" runat="server" style="display: block;" class="panel-body">
           
           <div class="row" style="margin-top: 7px;">
                 <div class="col-sm-4" style="text-align:left">
                    <asp:Label ID="lblUntCode" runat="server" CssClass="control-label" Text="Unit Code"></asp:Label>
                     <asp:TextBox ID="txtUntCode" runat="server"  CssClass="form-control" TabIndex="1"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftx_txtuntcd" runat="server"
                    TargetControlID="txtUntCode" FilterType="Custom, Numbers">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
             
                <div class="col-sm-4" style="text-align:left">
                    <asp:Label ID="lblUntName" runat="server" CssClass="control-label" Text="Unit Name"></asp:Label>
                    <asp:TextBox  CssClass="form-control" ID="txtUntName" runat="server" TabIndex="2"></asp:TextBox>
                     <ajaxToolkit:FilteredTextBoxExtender ID="ftx_untName" runat="server"
                     TargetControlID="txtUntName" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
                  <div class="col-sm-4" style="text-align:left">
                    <asp:Label ID="lblUntType" CssClass="control-label" Text="Unit Type" runat="server" />
                
                    <asp:TextBox ID="txtUntType" CssClass="form-control" runat="server" TabIndex="3" />  
                     <ajaxToolkit:FilteredTextBoxExtender ID="ftx_UnitTyp" runat="server"
                     TargetControlID="txtUntType" FilterType="UppercaseLetters, LowercaseLetters, Custom">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
          </div>

          <div class="row" style="margin-top: 7px;">
                  
           </div>
            <br />

              <div class="row">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success" CausesValidation="false"
                                    Text="SEARCH" OnClick="btnSearch_Click" OnClientClick="javascript:validate();"
                                    TabIndex="4">
                         <span class="glyphicon glyphicon-search" style='color: White;'></span> SEARCH
                        </asp:LinkButton>  <%--changed by sanoj 18052023--%>
                                  <asp:LinkButton ID="btnClear1" runat="server" CssClass="btn btn-clear" CausesValidation="true"
                             OnClick="btnClear1_Click" >  CLEAR 

                        </asp:LinkButton> 
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-clear" CausesValidation="False"
                                     OnClientClick="doCancel();return false;" OnClick="btnClear_Click" TabIndex="5">
                              <span class="glyphicon glyphicon-remove" style="color:red;"></span> CANCEL
                             </asp:LinkButton>
                            </div>
                        </div>

         <br />

        <div id="div1" runat="server">
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
                                        <asp:Label ID="lblMessage" runat="server" Text="No record found" ForeColor="Red"></asp:Label>
                                    </center>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Unit Code" SortExpression="UnitCode" Visible="false">
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
                                        <ItemStyle CssClass="clsleft" />
                                        <HeaderStyle CssClass="clsleft"  />

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="UnitTypDesc">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitType" Text='<%#Bind("UnitTypDesc") %>' runat="server" />
                                        </ItemTemplate>
                                          <ItemStyle CssClass="clsleft" />
                                        <HeaderStyle CssClass="clsleft"  />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CmsUnitCode" HeaderText="Unit Code" SortExpression="CmsUnitCode">
                                        <HeaderStyle Width="20%" />
                                        <ItemStyle CssClass="clscenter" />
                                        <HeaderStyle CssClass="clscenter"  />
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
                                            <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChkSelect_CheckedChanged" onclick ="CheckSingleCheckbox(this)"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                               
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
           
           
            <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                    <asp:LinkButton ID="btnOK" runat="server" CssClass="btn btn-success"  onclick="btnOK_Click"  style='margin-top: -6px;border-radius: 15px;'>
                     <span class="	glyphicon glyphicon-ok" style='color: White;'></span> OK
                    </asp:LinkButton>
               </div>
               </div>       
               

</div>
        
        </div>
   </div>
</div>
    </center>
</asp:Content>

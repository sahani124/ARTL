<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnitMaint.aspx.cs" Inherits="INSCL.UnitMaint" MasterPageFile="~/iFrame.master" Title="Unit Maintenance Search" %>

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
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
  
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <style type="text/css">
  .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
            color: white;
            text-align:left;
        }
    </style>

     <script language="javascript" type="text/javascript">
         function popup() {
             $("#myModal").modal('show');
            // $(document).ready(function () { $("#myModal").modal('show'); });
         }
         var path = "<%=Request.ApplicationPath.ToString()%>";


         function ShowReqDtl(divName, btnName) {
             //debugger;
             var objnewdiv = document.getElementById(divName);
             var objnewbtn = document.getElementById(btnName);

             if (objnewdiv.style.display == "block") {
                 objnewdiv.style.display = "none";
                // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
             }
             else {
                 objnewdiv.style.display = "block";
                 //objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
             }
         }

         function funUntDetailsPopup(args1) {
             $find("mdl_UntDetails").show();
             document.getElementById("ctl00_ContentPlaceHolder1_ifrm_UntDetails").src = args1;
         }
      
  </script>

    <div class="container">
    <center>
        <br />
        <asp:UpdatePanel ID="up_UnitM" runat="server">
            <ContentTemplate>

            <div class="panel " id="divcmphdrcollapse" runat="server">
             <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmphdr','btndivcmphdr');return false;"> 
                <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblUnitMaintanance" runat="server" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btndivcmphdr" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>  
             
          </div>
          <div id="divcmphdr" runat="server" class="panel-body" style="display:block"> 
                               <%-- <tr>
                                    <td class="test" colspan="4" align="left" style="height: 20px;">
                                        <asp:Label ID="lblUnitMaintanance" runat="server" Font-Bold="true" CssClass="caption"></asp:Label>
                                    </td>
                                </tr>--%>
               <div class="row" style="margin-bottom:5px;">
             <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblSalesChannel" CssClass="control-label"  runat="server"></asp:Label>&nbsp;
                                        <span style="color:Red; margin-left:0px;">
                                        *</span>
                         </div>
                <div class="col-md-3">
                                        <asp:UpdatePanel runat="server" ID="upnlSalesChannel">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSalesChannel" runat="server" CssClass="form-control" 
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvSlsChnnl" runat="server" ControlToValidate="ddlSalesChannel"
                                                  SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                 </div>
           <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblChnnlSubClass" CssClass="control-label" runat="server"></asp:Label>&nbsp;&nbsp;
                                        <span style="color:Red; margin-left:0px;">*</span>
                           </div>
                      <div class="col-md-3">
                                        <asp:UpdatePanel runat="server" ID="upnlChnnlSubClass">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlChnnlSubClass"  runat="server" CssClass="form-control"  
                                                    OnSelectedIndexChanged="ddlChnnlSubClass_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvChnnlSubClass" runat="server" ControlToValidate="ddlChnnlSubClass"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged">
                                                </asp:AsyncPostBackTrigger>
                                            </Triggers>
                                        </asp:UpdatePanel>
                     </div>
               </div>
                  <div class="row" style="margin-bottom:5px;">
                   <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblUnitLevel" CssClass="control-label"  runat="server"></asp:Label>&nbsp;
                                        <span style="color:Red; margin-left:0px;">
                                        *</span>
                      </div>
                    <div class="col-md-3">
                                        <asp:UpdatePanel runat="server" ID="upnlChnCls">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUnitLevel"  runat="server" CssClass="form-control" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlUnitLevel_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <%--Modifcation by Parag @06022014--%>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged">
                                                </asp:AsyncPostBackTrigger>
                                            </Triggers>
                                        </asp:UpdatePanel>
                     </div>
                     <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblUnitCode" CssClass="control-label" runat="server" ></asp:Label>
                              </div>
                       <div class="col-md-3">
                                        <asp:TextBox ID="txtUnitCode" runat="server" CssClass="form-control"
                                            MaxLength="10"></asp:TextBox>
                     </div>
                </div>
          </div>

                                </div>
                                <br/>
           
                <%--Section Added: Parag @ 05022014--%>
                <%--<tr>
                                    <td colspan="4" align="left" class="test" style="height: 20px;">
                                        <asp:Label ID="lblReportingUnit" runat="server" Font-Bold="true" CssClass="caption"></asp:Label>
                                    </td>
                                </tr>--%>
            <div class="panel " id="div1" runat="server">
               <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div2','btndiv2');return false;"> 
                      <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblReportingUnit" runat="server"   Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btndiv2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>  
                </div>
                 <div id="div2" runat="server" class="panel-body" style="display:block"> 
                      <div class="row" style="margin-bottom:5px;">
                    <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblReportingUnitType" runat="server" CssClass="control-label"></asp:Label>&nbsp;
                                                <span style="color:Red; margin-left:0px;">
                                        *</span>
                                        </div>
                      <div class="col-md-3">
                                                <asp:UpdatePanel ID="upnlReprtngUnt" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlReportingUnitType" runat="server" AutoPostBack="True" 
                                                            CssClass="form-control" 
                                                            OnSelectedIndexChanged="ddlReportingUnitType_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <%--Modifcation: Parag @06022014--%>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <ajax:AsyncPostBackTrigger ControlID="ddlSalesChannel" 
                                                            EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                        </div>
                 <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblReportingUnitCode" runat="server" CssClass="control-label"></asp:Label>
                    </div>
                  <div class="col-md-3">
                                                <asp:TextBox ID="txtReportingUnitCode" runat="server" 
                                                    CssClass="form-control" MaxLength="10"></asp:TextBox>
                  </div>
                </div>
                    </div>
                </div>
                <%--Section Addition Ends --%>
                <%-- <tr>
                                    <td colspan="4" align="center">
                                        <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" TabIndex="43"
                                            Text="SEARCH" Width="80px" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                                     
                                        <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" TabIndex="43"
                                            Text="CLEAR" Width="80px" OnClick="btnClear_Click" CausesValidation="False" />
                                    </td>
                                </tr>--%>
                <div ID="tbladdcntst" runat="server" style="width: 98%;">
                    <div class="row">
                          <div class="col-md-12" style="text-align:center">

                                <input id="hidFlag" runat="server" type="hidden" />
                                &nbsp;
                             <%--   <asp:Button ID="btnSearch" runat="server" CausesValidation="True" 
                                    CssClass="btn blue" OnClick="btnSearch_Click" 
                                    OnClientClick="javascript:validate();" TabIndex="43" Text="SEARCH" 
                                    Width="100px" />--%>
                                      <asp:LinkButton ID="btnSearch" runat="server"  CssClass="btn btn-sample" 
                              CausesValidation="false" OnClick="btnSearch_Click" >
                                  <span class="glyphicon glyphicon-search" style="color:White"> </span> Search
                                  </asp:LinkButton>
                                &nbsp;&nbsp;
                              <%--  <asp:Button ID="btnClear" runat="server" CausesValidation="False" 
                                    CssClass="btn default" OnClick="btnClear_Click" TabIndex="43" Text="CLEAR" 
                                    Width="100px" />--%>
                                        <asp:LinkButton ID="btnClear" runat="server"  CssClass="btn btn-sample" 
                              CausesValidation="false" OnClick="btnClear_Click" >
                                  <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color:White"> </span> Clear
                                  </asp:LinkButton>
                 </div>
                 </div>
                </div>
              
                <br />
                 <div class="panel " id="div3" runat="server">
                  <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div_UnitContact','btndiv_UnitContact');return false;"> 
                      <div class="row" ID="trDetails" runat="server">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblTitleUnitMaintanance" runat="server"  Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btndiv_UnitContact" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>  
                </div>
                  <div id="div_UnitContact" runat="server" style="display:block"> 
                 
                  <div ID="tbDetails" runat="server">
                    
                    <%--<tr ID="trDetails" runat="server" style="width: 80%">
                        <td align="left" class="test" colspan="3" style="border-collapse: separate; border-right-width: 0;
                            height: 32px;">
                            <asp:Label ID="lblTitleUnitMaintanance" runat="server" CssClass="caption" 
                                Font-Bold="true"></asp:Label>
                            <span style="padding-left: 500px;"></span>
                            <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>--%>
                    <%--Radio Button List "Hidden": Parag @ 05022014--%>
                      <div class="row" ID="trRdoList" runat="server" visible="false">
                    <div class="col-md-12" style="text-align:left">
                            <asp:RadioButtonList ID="rdbUnit" runat="server" AutoPostBack="True" 
                                CssClass="radiobtnHidden" Enabled="false" Height="11px" 
                                OnSelectedIndexChanged="rdbUnit_SelectedIndexChanged" 
                                RepeatDirection="Horizontal" Visible="false">
                            </asp:RadioButtonList>
                      </div>
                    </div>
                    <%--Hidden Row Ends--%>
                         <div class="row" ID="trlblMsg" runat="server" >
                       <div class="col-md-3" style="text-align:center">
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="False" CssClass="control-label" ForeColor="Red"></asp:Label>
                      </div>
                   </div>
                
           </div>
                    
                    
                 <div ID="trDgDetails" runat="server" style="width:97%">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                   <%-- <asp:GridView ID="dgDetails" runat="server" AllowPaging="true" RowStyle-VerticalAlign="Middle"
                                        AllowSorting="True" AutoGenerateColumns="false" DataKeyNames="UnitCode"  PageSize="10"
                                        HorizontalAlign="Left" OnPageIndexChanging="dgDetails_PageIndexChanging" 
                                        OnRowCommand="dgDetails_RowCommand" OnRowDataBound="dgDetails_RowDataBound" 
                                        OnRowDeleting="dgDetails_RowDeleting" OnSorting="dgDetails_Sorting" 
                                        CssClass="table table-striped table-bordered table-hover table-scrollable dataTable">
                                         <HeaderStyle ForeColor="Black"  />
                                        <RowStyle />
                                        <PagerStyle CssClass="disablepage" />--%>
                                        
                                        <asp:GridView   ID="dgDetails" runat="server" CssClass="footable" AllowSorting="true"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1" DataKeyNames="UnitCode"  OnRowCommand="dgDetails_RowCommand" OnRowDataBound="dgDetails_RowDataBound" 
                                        OnRowDeleting="dgDetails_RowDeleting" OnSorting="dgDetails_Sorting" style="margin-top:10px" >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                       <%-- <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                       --%> 
                                        <Columns>
                                            <asp:TemplateField HeaderText="Unit Code" ShowHeader="true" 
                                                SortExpression="UnitCode"><%--0--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnitCode"  Visible="false" runat="server" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                                    <asp:Label ID="Label1"  runat="server" Text='<%# Bind("NewLegalName") %>'></asp:Label>
                                                </ItemTemplate>
                                                  <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="LegalName" Visible="false" HeaderText="Unit Description" 
                                                SortExpression="LegalName"><%--1--%>
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RptUnitName" HeaderText="Reporting Unit" 
                                                SortExpression="RptUnitName"><%--2--%>
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UnitMgrName" HeaderText="Unit Manager" 
                                                SortExpression="UnitMgrName"><%--3--%>
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UnitType" HeaderText="Unit Type" 
                                                SortExpression="UnitType"><%--4--%>
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <%--Change: Parag @ 10022014 Added Two new columns--%>
                                            <asp:BoundField DataField="CmsUnitCode" HeaderText="Insurer Code" 
                                                SortExpression="CmsUnitCode"><%--5--%>
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RptCmsUnitCode" HeaderText="Insc Reporting Code" 
                                                SortExpression="RptCmsUnitCode"><%--6--%>
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UnitCode" HeaderText="Action" 
                                               ><%--7--%>
                                               <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                                            </asp:BoundField>
                                            <%--Change: END--%>
                                            <asp:TemplateField HeaderText="Action" ShowHeader="True"><%--8--%>
                                                <ItemTemplate>
                                                    <div style="width: 100%;">
                                                        <i class="fa fa-trash-o"></i>
                                                        <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" 
                                                            Text="Delete" />
                                                    </div>
                                                </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                       
                                    </asp:GridView>
                                </ContentTemplate>
                             <%--   <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                </Triggers>--%>
                            </asp:UpdatePanel>
                 </div>

                 <br />

                <div id="divPage" visible="true" runat="server">
                        <center>
                            <table>
                                <tr>
                                    <td style="white-space: nowrap;">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>

                      <br />

                     <div>     
                     <div class="row" ID="trBtnNew" runat="server">
                        <div class="col-md-12" style="text-align:center">
                          <%--  <asp:Button ID="btnAddNewUnit" runat="server" 
                                OnClick="btnAddNewUnit_Click" TabIndex="43" Text="ADD NEW UNIT" Visible="False"    
                               CssClass="btn blue" Width="110px" />--%>
                                 <asp:LinkButton ID="btnAddNewUnit" runat="server"  CssClass="btn btn-sample" 
                              CausesValidation="false" OnClick="btnAddNewUnit_Click">
                                  <span class="glyphicon glyphicon-plus" style="color:White"> </span> Add New Unit
               
                                </asp:LinkButton>
                   </div>
                   </div>
                
                </div>
             
               <br />
               
               </div>
               </div>
                                
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <%--Parag 10022014 For Runtime Lable update--%>
  
<%--Parag 10022014 For Runtime Lable update--%>
<%--Added by Pranjali on 28-05-2013 for modal popup start--%>
<asp:UpdatePanel runat="server">
<ContentTemplate>
     <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header" style="text-align: center;background-color:#034ea2;">
            <asp:Label ID="Label161" Text="INFORMATION" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center; background-color:white">
          <asp:Label ID="lblpopup" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center;  background-color:white">
          <button type="button" class="btn btn-sample" data-dismiss="modal" >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>
  
    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid" style="display:none;"
        BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="150px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    <asp:Label ID="lblModalTitle" runat="server" /><%--Parag @ 10022014 - To make the hardcoded Text as lable--%>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px">
                    <br />
                    <center>
                      <asp:Label ID="Lbl" runat="server"></asp:Label>
                        <br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" Width="81px" CssClass="standardbutton" />
        </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
  </ContentTemplate>
  </asp:UpdatePanel>
        </div>
    <%--Added by Pranjali on 28-05-2013 for modal popup end--%>
    <%--Parag 10022014 For Runtime Lable update--%>
     
    <%--Parag End--%>
</asp:Content>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopKPITrg.aspx.cs"  MasterPageFile="~/iFrame.master"  Inherits="Application_Isys_Saim_PopKPITrg"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

      <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript" src="../../../Scripts/jquery.min.js">

    </script>
    <script>
    function closeWin() {
  myWindow.close();   // Closes the new window
    }
        </script>
     <asp:UpdatePanel runat="server">
        <ContentTemplate>
            
                <div id="divrwdrulcollapse" runat="server" style="width: 97%;" class="panel">
                    <div id="divC" runat="server" class="panel-heading" style="width: 96%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','Img2');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                             
                                <asp:Label ID="lblhdr" Text="Target Setup As Per KPI" style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                 <span id="Img2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divcmphdr" runat="server" style="width: 96%;"  class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                             <div class="col-sm-3" style="text-align: left">
                                        
                                 <asp:Label ID="lblRulSetKy" Text="Rule Set Key" runat="server" CssClass="control-label" />
                                        
                                </div>

                            <div class="col-sm-3" >
                                        
                                <asp:Label ID="txtRulSetKy"  runat="server" CssClass="form-control-static new_text_new" />
                                        
                               </div>


                            <div class="col-sm-3" style="text-align: left">
                                     
                                   <asp:Label ID="lblKPICode" Text="KPI Code" runat="server" CssClass="control-label" />
                                        
                                    </div>

                            <div class="col-sm-3" >
                                       
                                 <asp:Label ID="txtKPICode"  runat="server" CssClass="form-control-static new_text_new" />
                                        
                                    </div>
                          </div>

                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCycle" Text="Cycle" runat="server" CssClass="control-label" />
                           </div>
                              <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCycle"   runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                               </div>
                              <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblTrg" Text="Target" runat="server" CssClass="control-label" />
                           </div>
                              <div class="col-sm-3">
                                <asp:TextBox ID="txtTrg" runat="server" CssClass="select2-container form-control" />
                               </div>

                           
                        </div>

                         <div class="row" style="margin-bottom: 5px;">
                          

                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblMemCode" Text="Member Code" runat="server" CssClass="control-label" />
                           </div>
                              <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlMemCode"   runat="server" AutoPostBack="true" CssClass="select2-container form-control" OnSelectedIndexChanged="ddlMemCode_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                               </div>

                             <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label1" Text="Location" runat="server" CssClass="control-label"  Visible="false"/>
                           </div>
                              <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlLocation"   runat="server" AutoPostBack="true" CssClass="select2-container form-control" Visible="false">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                               </div>


                        </div>

                        <div class="row" style="margin-bottom: 5px;">
                          
                         <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblMemCycle" Text="Member Pay Cycle" runat="server" Visible="false" CssClass="control-label" />
                           </div>
                              <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlMemPayCycle"   runat="server" Visible="false" AutoPostBack="true" CssClass="select2-container form-control">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                               </div>

                            </div>
                        
                        <div class="row" style="margin-bottom: 5px; ">
                            <div class="col-sm-6" style="text-align: left" visible="false" >
     
                                <asp:CheckBox ID="chkCyc" runat="server" AutoPostBack="true" Visible="true"  />
                                <asp:Label ID="lbl12" Text="Apply to all Cycles" runat="server"  Visible="true"/>
                            </div>


                             
                        </div>


                          <div id="tblrwd" runat="server" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                              
                                 <asp:LinkButton ID="btnAddTrg" runat="server" CssClass="btn btn-sample"
                                    Enabled="true"   OnClick="btnAddTrg_Click">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Save Target
                                 </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample"  onClick="btnCancel_Click" >
                                        <span class="glyphicon glyphicon-remove"  style="color:White"></span> Cancel
                                </asp:LinkButton>
                                                           
                            </div>
                        </div>

                        </div>
                    </div>

               <div id="div4" runat="server" style="width: 100%; border: none; padding: 10px; margin: 0px 0 !important;"
                                        class="table-scrollable">
            <asp:GridView ID="KPITrgt" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable"  >
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                        
                                             <Columns>

                                               <asp:TemplateField HeaderText="Compensation Code" SortExpression="CMPNSTN_CODE">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCMPNSTN_CODE" runat="server" Text='<%# Bind("CMP_DESC")%>'></asp:Label>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                                   <asp:TemplateField HeaderText="Contestant Code" SortExpression="CNTSTNT_CODE">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCNTSTNT_CODE" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'></asp:Label>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               

                                                   <asp:TemplateField HeaderText="Rule Set Code" SortExpression="RULE_SET_KEY">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRULE_SET_KEY" runat="server" Text='<%# Bind("RuleSetCode")%>'></asp:Label>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                                  <asp:TemplateField HeaderText="KPI Description" SortExpression="KPI_DESC">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKPI_CODE" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                                 
                                                  <asp:TemplateField HeaderText="Member Name" SortExpression="MEM_CODE">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMEM_CODE" runat="server" Text='<%# Bind("MemName")%>'></asp:Label>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                                   <asp:TemplateField HeaderText="Cycle Description" SortExpression="CYCLE">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCYCLE" runat="server" Text='<%# Bind("Cycle_Desc")%>'></asp:Label>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                               <asp:TemplateField HeaderText="Member Location" SortExpression="Location">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMEMBER_Loc" runat="server" Text='<%# Bind("Location")%>'></asp:Label>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                                 <asp:TemplateField HeaderText="Member Cycle" SortExpression="MEMBER_CYCLE">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMEMBER_CYCLE" runat="server" Text='<%# Bind("Member_Desc")%>'></asp:Label>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                                  <asp:TemplateField HeaderText="KPI Target From" SortExpression="KPI_TRGT_FROM">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKPI_TRGT_FROM" runat="server" Text='<%# Bind("KPI_TRGT_FROM")%>'></asp:Label>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="KPI Target To" SortExpression="KPI_TRGT_TO">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKPI_TRGT_TO" runat="server" Text='<%# Bind("KPI_TRGT_TO")%>'></asp:Label>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            

                                                 </columns>
                           </asp:GridView>

                   </div>

            <center>
                                <div id="div11" visible="true" runat="server" class="pagination">
                            
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnpre" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                        Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnpre_Click" />
                                                    <asp:TextBox runat="server" ID="txtpage" Style="width: 40px; border-style: solid;
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
                           
                        </div>
                 </center>
                  </ContentTemplate>
         </asp:UpdatePanel>

            <asp:HiddenField ID="hdnCount" runat="server" />
            <asp:HiddenField ID="hdnBusiCode" runat="server" />
            <asp:HiddenField ID="hdnFINYEAR" runat="server" />

    </asp:Content>
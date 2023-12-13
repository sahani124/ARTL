<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="NonStdCommApproval.aspx.cs" Inherits="Application_Isys_Saim_NonStdCommApproval" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
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
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/dgKPI.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }*

        .form-submit-button {
            box-shadow: none !important;
        }

        .disablepage {
            display: none;
        }
        /*.divBorder
        {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
            vertical-align: top;
        }*/
        .lblmaxraetValue {
            text-align: center !important;
        }


        .shadow-textarea textarea.form-control::Placeholder {
            font-weight: 300;
        }

        .shadow-textarea textarea.form-control {
            padding-left: 0.8rem;
        }
    </style>

    <script type="text/javascript">



    </script>


    <asp:UpdatePanel ID="Uplcollapse" runat="server">
        <ContentTemplate>
            <center>
                 <div id="divkpisrchhdrcollapse" runat="server" style="width: 97%;" class="panel">
                    <div id="Div6" runat="server" class="panel-heading" style="width: 97%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divMemberWiseSearch','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblMemberWiseSearch" Text="Standard/Non-Standard Commission Approval Criteria" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divMemberWiseSearch" runat="server" style="width: 96%; padding: 10px;" class="panel-body">

                         <div class="row"  id="divChannel" style="margin-bottom: 5px;" visible="true" runat="server">
                            <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="LblChannel" Text="Channel" runat="server" CssClass="control-label" />
                                <span style="color: red;">*</span> 
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlChannel" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" OnSelectedIndexChanged="ddlChannel_SelectedIndexChanged">
                                     
                                    
                                    
                                 </asp:DropDownList>
                                </div>
                            
                            
                               <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="LblSubChannel" Text="Sub Channel" runat="server"   CssClass ="control-label" />
                                   <span style="color: red;">*</span> 
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                
                                      <asp:DropDownList runat="server" ID="ddlSubChannel" 
                                            CssClass="form-control" Width="100%"   AutoPostBack="true"  OnSelectedIndexChanged="ddlSubChannel_SelectedIndexChanged">
                                    
    
                                
                                 </asp:DropDownList>
                  
                             
                                </div>
                          </div>
                           <div class="row"  id="divCmp" style="margin-bottom: 5px;" visible="true" runat="server">
                            <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="LblCmpcode" Text="Compensation Code" runat="server" CssClass="control-label" />
                                <span style="color: red;">*</span> 
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlCmpCode" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%"  OnSelectedIndexChanged="ddlCmpCode_SelectedIndexChanged">
                                     
                                    
                                    
                                 </asp:DropDownList>
                                </div>
                            
                            
                               <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="Lblcntcode" Text="Contestant Code" runat="server"   CssClass ="control-label" />
                                   <span style="color: red;">*</span> 
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                
                                      <asp:DropDownList runat="server" ID="ddlCntCode" 
                                            CssClass="form-control" Width="100%"   AutoPostBack="true"   OnSelectedIndexChanged="ddlCntCode_SelectedIndexChanged">
                                    
    
                                
                                 </asp:DropDownList>
                  
                             
                                </div>
                          </div>
                        <div class="row" runat="server">
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="lbl" Text="Rule Set Code" runat="server" CssClass="control-label" />
                                 <span style="color: red;">*</span> 
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlRuleSetCode" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%"  OnSelectedIndexChanged="ddlRuleSetCode_SelectedIndexChanged" >
                                     
                                    
                                    
                                 </asp:DropDownList>
                                </div>
                            
                        
                           
                            
                            <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="LblCommType" Text="Commission Type" runat="server" CssClass="control-label" />
                            <span style="color: red;">*</span> 
                                </div>
                        <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlCommType" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" OnSelectedIndexChanged="ddlCommType_SelectedIndexChanged" >
                                     
                                   <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                     <asp:ListItem Text="STANDARD COMMISSION" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="NON STANDARD COMMISSION" Value="2"></asp:ListItem>
                                    
                                 </asp:DropDownList>
                                </div>
                            
                             
                            </div>


                        <br>
                        <div class="row" runat="server">

                            <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="LblMemberCode" Text="Member Code" runat="server" CssClass="control-label" />
                            <span id="spnMemCode" style="color: red;" runat="server">*</span> 
                                </div>
                        <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlMemberCode" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" >
                                     
                                    
                                    
                                 </asp:DropDownList>
                                </div>


                           
                              <div class="col-sm-3" style="text-align: left">
                                 <asp:LinkButton ID="lnkStdRate" runat="server" Text="View Standard Rate Setup" onclick="lnkStdRate_click" data-toggle="modal" data-target="#myModal" />
                              </div>
                        </div>


                      
                       
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                <asp:LinkButton ID="btnSearch" runat="server"  CssClass="btn btn-sample" OnClick="btnSearch_click">
                                        <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server"  CssClass="btn btn-sample" OnClick="btnCancel_Click">
                                        <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color:White"></span> Clear
                                </asp:LinkButton>
                              <%-- <asp:LinkButton ID="LinkButton1" runat="server" Text="View Standard Rate Setup"  OnClick="btnSearch_click"/>
                              --%>      </ContentTemplate>

                                    </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                   
                     <div id="DivResultHeading" runat="server" visible="false" class="panel-heading" style="width: 97%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divGridView','myImg1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                               
                                <asp:Label ID="Label1" Text="Standard/Non-Standard Commission Approval Result" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                     <div id="divGridView" runat="server" style="width: 97%; padding: 10px;" visible="false">
                         <div id="div1" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow:auto;"
                                    class="table-scrollable">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgRwdRul" runat="server" CssClass="footable" AllowSorting="True" PageSize="200"
                                                 AutoGenerateColumns="false">   
                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <EmptyDataTemplate>
                                                        <asp:Label ID="Label2" Text="No Data Found" ForeColor="Red" CssClass="control-label"
                                                         runat="server" />
                                                </EmptyDataTemplate>
                                                      <Columns>

                                                           <asp:TemplateField HeaderText="Action">  
                                                               <HeaderTemplate>
                                                                <asp:CheckBox ID="chkall" runat="server" AutoPostBack="true" OnCheckedChanged="chkall_CheckedChanged" />
                                                                </HeaderTemplate>
                                                       <%--<EditItemTemplate>  
                                                        <asp:CheckBox ID="chkValue" runat="server" />  
                                                    </EditItemTemplate> --%> 
                                                     <ItemTemplate>  
                                                            <asp:CheckBox ID="chkOne" runat="server" />  
                                                       </ItemTemplate>  
                                                     </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Reward Rule Code" SortExpression="RewardCode">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRwdCode" runat="server" Text='<%# Bind("RWD_RUL_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRWD_RUL_CODE" runat="server" Value='<%# Bind("RWD_RUL_CODE")%>' />
                                                          
                                                          </ItemTemplate>
                                                    </asp:TemplateField>

                                               <%--     <asp:TemplateField HeaderText="Reward Description" SortExpression="RWRD_DESC01">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            
                                                            <asp:Label ID="lblRwdCodeDesc" runat="server" Text='<%# Bind("RWRD_DESC01")%>'></asp:Label>
                                                            </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText="Member Code" SortExpression="MEMBERCODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMemberCode" runat="server" Text='<%# Bind("MEMBERCODE")%>'></asp:Label>
                                                            </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Member Name" SortExpression="MemberName">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMemberName" runat="server" Text='<%# Bind("MemberName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Cycle" SortExpression="CycleDesc">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCYCLE" runat="server" Text='<%# Bind("CycleDesc")%>'></asp:Label>
                                                            
                                                            <asp:HiddenField ID="hdnCycCd" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                 <%--    <asp:TemplateField HeaderText="RS Key" SortExpression="RuleSetDesc">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKyDesc" runat="server" Text='<%# Bind("RuleSetDesc")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText="Category Description" SortExpression="CATG_DESC01">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatgCd" runat="server" Text='<%# Bind("CATG_DESC01")%>'></asp:Label>
                                                             <asp:HiddenField ID="hdnCatgCode" runat="server" Value='<%# Bind("CATG_CODE")%>' />
                                                             <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                   
                                                    <asp:TemplateField HeaderText="Reward Type" SortExpression="RwdTypDesc">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            
                                                            <asp:Label ID="lblCatDsc" runat="server" Text='<%# Bind("RwdTypDesc")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatCd" runat="server" Value='<%# Bind("RwdCode")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="TYPE_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTypeCode" runat="server" Text='<%# Bind("TYPE_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTypeCode" runat="server" Value='<%# Bind("TYPE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Product Name" SortExpression="Product_Name">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProduct_Name" runat="server" Text='<%# Bind("Product_Name")%>'></asp:Label>
                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                <%--    <asp:TemplateField HeaderText="Based On KPI" SortExpression="KPI_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            
                                                            <asp:Label ID="lblBsdKpi" runat="server" Text='<%#Bind("KPI_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnBsdKpi" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Value" SortExpression="VALUE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblValue" runat="server" Text='<%# Bind("VALUE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnValue" runat="server" Value='<%# Bind("VALUE")%>' />
                                                             <asp:HiddenField ID="hdnBsdKpi" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                           </ItemTemplate>
                                                    </asp:TemplateField>
                                                 
                                                    <%--<asp:TemplateField HeaderText="Rate" SortExpression="RATE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRATE" runat="server" Text='<%# Bind("RATE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRATE1" runat="server" Value='<%# Bind("RATE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                               --%>
                                                     
                                                  
                                                </Columns>
                                            </asp:GridView>

                                            
                                        </ContentTemplate>
                                      <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                         </div>
                         </div>
                        
                     <div class="pagination" id="divPagination" runat="server" visible="false">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                 <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;"  />
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px"  onClick="btnnext_Click"/>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>

                     <div id="divRemarkHeading" runat="server" visible="false" class="panel-heading" style="width: 97%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div1','myImg1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                               
                                <asp:Label ID="Label3" Text="Approval-Rejection Section" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                     <div id="divRemark" runat="server"  style="width: 96%; padding: 10px;" class="panel-body"  visible="false">
                         <div class="row">
                          <div class="col-sm-2" style="text-align: left;font-size:25px;font-family:Algerian">
                              <asp:Label ID="lblremark" Text="Remark" runat="server"  CssClass="control-label"/>
                              <span style="color: red;">*</span>
                            </div>
                              <div class="col-sm-6" style="text-align: left;font-size:25px;">
                      
                                   <textarea class="form-control z-depth-1" style="padding:5px;" runat="server" id="TextareaRemark" rows="3" Placeholder="Write something here..."></textarea>
                            </div>

                            <div class="col-sm-4" style="text-align: right;font-size:25px;font-family:Algerian">
                            </div>
                          </div>
                              
                                <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                <asp:LinkButton ID="btnAccepted" runat="server"  CssClass="btn btn-sample" OnClick="btnAccepted_click">
                                        <span class="glyphicon glyphicon-share" style="color: White;"></span> Accepted
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-sample" OnClick="btnRejected_click">
                                        <span class="glyphicon glyphicon-remove-circle" style="color:White"></span> Rejected
                                </asp:LinkButton>
                                    </ContentTemplate>

                                    </asp:UpdatePanel>
                            </div>
                        </div>
                            
                         </div>
                        
                </div>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <%-- <div class="modal-header">--%>
                <div id="divModel" runat="server" style="width: 97%;" class="panel">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <div id="Div2" runat="server" class="panel-heading" style="width: 99%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divMemberWiseSearch','myImg5');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left; font-size: 19px;">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label4" Text="View Standard Rate Setup " runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg5" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div id="divModelBody" runat="server" style="width: 97%; padding: 10px;" visible="true">
                        <div id="div4" runat="server" style="width: 100%; border: none; margin: 0px 0 !important; overflow: auto;"
                            class="table-scrollable">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="StdRateGrid" runat="server" CssClass="footable" AllowSorting="True" PageSize="10"
                                        AllowPaging="true" AutoGenerateColumns="false">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label3" Text="No Data Found" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                        <Columns>


                                            <asp:TemplateField HeaderText="Reward Code" SortExpression="RewardCode">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSdRtRwdCode" runat="server" Text='<%# Bind("RewardCode")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnSdRtRWD_RUL_CODE" runat="server" Value='<%# Bind("RWD_RUL_CODE")%>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reward Description" SortExpression="RWRD_DESC01">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>

                                                    <asp:Label ID="lblSdRtRwdCodeDesc" runat="server" Text='<%# Bind("RWRD_DESC01")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%-- <asp:TemplateField HeaderText="Member Code" SortExpression="MEMBERCODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSdRtMemberCode" runat="server" Text='<%# Bind("MEMBERCODE")%>'></asp:Label>
                                                            </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Member Name" SortExpression="MemberName">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSdRtMemberName" runat="server" Text='<%# Bind("MemberName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                    </asp:TemplateField>--%>


                                            <asp:TemplateField HeaderText="Cycle" SortExpression="CycleDesc">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSdRtCYCLE" runat="server" Text='<%# Bind("CycleDesc")%>'></asp:Label>

                                                    <asp:HiddenField ID="hdnSdRtCycCd" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="RS Key" SortExpression="RuleSetDesc">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSdRtRulStKyDesc" runat="server" Text='<%# Bind("RuleSetDesc")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnSdRtRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Category Description" SortExpression="CATG_DESC01">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSdRtCatgCd" runat="server" Text='<%# Bind("CATG_DESC01")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnSdRtCatgCode" runat="server" Value='<%# Bind("CATG_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Reward Type" SortExpression="RwdTypDesc">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <asp:Label ID="lblSdRtCatDsc" runat="server" Text='<%# Bind("RwdTypDesc")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnSdRtCatCd" runat="server" Value='<%# Bind("RwdCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Unit Type" SortExpression="TYPE_DESC">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSdRtTypeCode" runat="server" Text='<%# Bind("TYPE_DESC")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnSdRtTypeCode" runat="server" Value='<%# Bind("TYPE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Based On KPI" SortExpression="KPI_DESC">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <asp:Label ID="lblSdRtBsdKpi" runat="server" Text='<%#Bind("KPI_DESC")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnSdRtBsdKpi" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Value" SortExpression="VALUE">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSdRtValue" runat="server" Text='<%# Bind("VALUE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnSdRtValue" runat="server" Value='<%# Bind("VALUE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Rate" SortExpression="RATE">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSdRtRATE" runat="server" Text='<%# Bind("RATE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnSdRtRATE1" runat="server" Value='<%# Bind("RATE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                        </Columns>
                                    </asp:GridView>

                                </ContentTemplate>
                                <%-- <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlRuleSet" EventName="SelectedIndexChanged" />
                                        </Triggers>--%>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div id="popButton" runat="server" class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">

                            <asp:LinkButton ID="lnkClose" runat="server" CssClass="btn btn-sample">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

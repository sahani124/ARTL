<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="Receiptmodule.aspx.cs" Inherits="Application_INSC_Recruit_Receiptmodule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
     <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>

    <script language="javascript" type="text/javascript">
        function doCancel() {
            //window.parent.$find('<%=Request.QueryString["Type"].ToString()%>').hide();
//            alert("hi");
            window.location = "CndApproval.aspx?Type=Recp";
        }

        function popup() {
          
            $("#myModal").modal();
        }

   
       
        
        function ShowReqDtl(divName, btnName) {
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
        function ShowReqDtl12(divName, btnName) {
            //debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-resize-small'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-resize-full'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

   </script>
      <script type="text/javascript">

       
        $(function () {
            debugger; $("#<%= txtchqdate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });

        $(function () {
            debugger; $("#<%= txttrnsdate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });
        </script>
    <style>
        .mgrinnone{
            margin-top: 0px !important;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <div class="container">
       
     <center>
    
                 <div style="overflow: hidden;">
                    <asp:Panel ID="pnlRprt" Width="100%" runat="server" Style="overflow: hidden;">
                        <center>
                       <div class="panel  ">
                
             <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_idpnlBdy','btnWfParam');return false;">
                                    <div class="row">
                                        <div class="col-xs-10" style="text-align: left">
                                            <asp:Label ID="lblTitle" runat="server" Text="Online Candidate Verification"
                                             style="font-size:19px" ></asp:Label>
                                        </div>
                                        <div class="col-xs-2">
                                            <span id="btnWfParam" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                                                color:  #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                  
                      <div id="idpnlBdy" runat="server" class="panel-body" style="display:block;">
                  <div id="divSrvcReqReport"  class="panel-body panel-collapse collapse in">
                           <div id="tblRpt" runat="server" class="row">
                      
                        <div>
                            <div class="col-md-3" style="text-align: left">

               
                            <asp:Label ID="lblAppNo" Text="Application No"  CssClass="control-label" runat="server"></asp:Label>
                            </div>
                 
                        <div class="col-md-3">

                            <asp:TextBox ID="lblAppNoValue" style="margin-bottom: 5px;"  Enabled ="false" CssClass="form-control"  runat="server" ></asp:TextBox>
                   </div>
                         <div class="col-md-3"  style="text-align: left">
                            <asp:Label ID="lblCndName"  CssClass="control-label"  Text="Candidate Name" runat="server"></asp:Label>
                     </div>
                 
                        <div class="col-md-3" >
                            <asp:TextBox ID="lblAdvNameValue" Enabled ="false"  style="margin-bottom: 5px;"  CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
            
                    </div>
                  
                  
            
                <div class="panel  ">
                    <div class="panel-heading subheader" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_divagndetails','Span1');return false;"
                                                    >
                                                    <div class="row" align="left">
                                                        <div class="col-sm-10">
                                                            <span class="glyphicon glyphicon-menu-hamburger" style="margin-right: 5px; color:  #034ea2;">
                                                            </span>
                                                            <asp:Label ID="lblCnddtls" runat="server" Text="Candidate Details" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <span id="Span1" class="glyphicon glyphicon-resize-full" style="float: right; padding: 1px 10px ! important;
                                                                font-size: 18px; color:  #034ea2;"></span>
                                                        </div>
                                                        <%-- <asp:Label ID="Label1" runat="server" CssClass="standardlabel" Font-Bold="True" Text=""></asp:Label>--%>
                                                    </div>
                                                </div>


       
          <div id="divagndetails" runat="server" class="panel-body" style="display: block">
                      <div class="row" align="left">
                  
                            <div class="col-md-3"  style="text-align: left">
            
                            <asp:Label ID="lblCndNo" Text="Candidate No"  CssClass="control-label" runat="server" ></asp:Label>
                             <span style="color: red">*</span>
                    </div>
                         <div class="col-md-3" >
                            <asp:TextBox ID="lblCndNoValue" style="margin-bottom: 5px;" Enabled ="false"   CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                         <div class="col-md-6"  style="text-align: left">
                            <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details" OnClick="lblCndView_Click" CssClass="control-label"></asp:LinkButton>
                           
                            </div>
                            </div>
        
                         <div class="row" align="left">

                          
                    <div class="col-md-3" style="text-align: left" >
                            <asp:Label ID="LblTokenno"  CssClass="control-label" Text="Token No" runat="server" ></asp:Label>
                             <span style="color: red">*</span>
                        </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="txttoken" style="margin-bottom: 5px;" Enabled ="false"   CssClass="form-control" runat="server" ></asp:TextBox>
                       </div>
                   
                    <div class="col-md-3" style="text-align: left" >
                            <asp:Label ID="lblMode"  CssClass="control-label" Text="Payment Mode" runat="server" ></asp:Label>
                             <span style="color: red">*</span>
                        </div>
                         <div class="col-md-3">
                            <asp:DropDownList ID="txtmode" style="margin-bottom: 5px;" OnSelectedIndexChanged="ddlMode_SelectedIndexChnged"
                            AutoPostBack="true"  CssClass="form-control" runat="server" >
                             <asp:ListItem Value="">Select</asp:ListItem>
                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                              <asp:ListItem Value="DD">Demand Draft(DD)</asp:ListItem>
                              </asp:DropDownList>
                       </div>
                       </div>
                         <div id="divMode" runat="server" visible="false" class="row" align="left">
                         <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lblchekno"  CssClass="control-label" Text="Cheque/DD No" runat="server" ></asp:Label>
                             <span style="color: red">*</span>
                        </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="txtchekno"  style="margin-bottom: 5px;"  CssClass="form-control" runat="server" Font-Bold="False"></asp:TextBox>
                        </div>
              
                        <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lblchqdate"  CssClass="control-label" Text="Cheque/DD Date" runat="server" ></asp:Label>
                             <span style="color: red">*</span>
                        </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="txtchqdate"  style="margin-bottom: 5px;"  runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                          </div>
                         <div class="row" align="left">
                         <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lbltrnsid" Text="Transaction ID" CssClass="control-label"  runat="server" ></asp:Label>
                             <span style="color: red">*</span>
                        </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="txttrnsid" style="margin-bottom: 5px;"  CssClass="form-control"  runat="server" ></asp:TextBox>
                       </div>
                     <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lbltrnsdate"  CssClass="control-label" Text="Transaction Date" runat="server" ></asp:Label>
                             <span style="color: red">*</span>
                        </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="txttrnsdate"  style="margin-bottom: 5px;" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                    
                 <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lblbankname"  CssClass="control-label" Text="Bank Name" runat="server" ></asp:Label>
                             <span style="color: red">*</span>
                        </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="txtbankname"  runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lblamount"  CssClass="control-label" Text="Amount" runat="server" ></asp:Label>
                             <span style="color: red">*</span>
                        </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="txtamount" Enabled ="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                </div>
            </div>
            </div>
          </div>
         
          </div>
   
      
        <br />
      
              
              
               
        
       

           <div ID="SeaCan" runat="server">

                                <div align="center" class="col-sm-12">
                                    <asp:LinkButton ID="BtnSearch" runat="server" CssClass="btn btn-sample" 
                                        OnClick="BtnSave_click">
                                 <span class="glyphicon glyphicon-floppy-disk" style="color: white;"> </span> Save
                                </asp:LinkButton>
                                    <asp:LinkButton ID="btncancel" runat="server" CssClass="btn btn-sample" 
                                    OnClientClick="doCancel();return false;" > <%-- --%>
                                 <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> Cancel
                                </asp:LinkButton>
                                </div>

                                 <div align="center" class="col-sm-12">
                                   <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" CssClass="control-label"></asp:Label>
                                 </div>
                            </div>
     
       </div>
       </div>
        </center>
                    </asp:Panel>
                </div>
       
    </center>
  
      </div>  
          <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" style='width:250px;height:230px;'>
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label1" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl3" runat="server"></asp:Label><br />
        
        </div>
        <div class="modal-footer mgrinnone" style="text-align: center">
          <button type="button" class="btn btn-sample" data-dismiss="modal" style='margin-bottom:-6px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>
   
    
    <%--For Displaying Information Pop-up End--%>
   <%-- <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                    BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
                    TargetControlID="hiddenField1" PopupControlID="Panel1">
                </ajaxToolkit:ModalPopupExtender>
                <asp:HiddenField ID="hiddenField1" runat="server" />--%>
  
  
   <%-- <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: Grey;">
        <center>
            <img src="../../../App_Themes/Isys/images/spinner.gif" />
            <br />
            <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
        </center>
    </asp:Panel>
    <table>
        <tr>
            <td>
                <asp:HiddenField ID="hdnCndNo" runat="server" />
            </td>
        </tr>
    </table>--%>
   
    
       
</asp:Content>



<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgtInfoEducation.aspx.cs"
    Inherits="Application_ISys_ChannelMgmt_AgtInfoEducation" MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
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
      <style type="text/css">
          
         .btn-subtab
        {
            color:#034ea2;
            background-color:#FFFFFF;
            border-color:#034ea2;
        }
       </style>
         <script language="javascript" type="text/javascript">

             $(function () {
                 debugger;

                 $("#<%= txtGradDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
              
             
             });

             function funValidate() {
                 var strContent = "ctl00_ContentPlaceHolder1_";
                 if (document.getElementById(strContent + "ddlAcadQual") != null) {

                     if (document.getElementById(strContent + "ddlAcadQual").selectedIndex == 0) {
                         alert("Please Select Highest Academic Qualification");
                         document.getElementById(strContent + "ddlAcadQual").focus();
                       
                         return false;
                     }
                 }

             }



        function popup() {
            $("#myModal").modal();
        }


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
               // objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
            }
        }
         </script>
    <asp:ScriptManager runat="server" ID="ScriptManager1">
    </asp:ScriptManager>
    <div>
        <table width="95%" style="border-collapse: collapse; background-image: url(Images\background.jpg);
            height: 18px;">
            <tr>
                <td>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
              <div id="demo1" class="row"  runat="server" style="text-align: left; margin-left: 20px;margin-bottom: 10px">
                    <asp:ImageButton ID="lnkPage1" runat="server" OnClick="lnkPage1_Click" CssClass="TextBox"  Visible="false"
                        BackColor="transparent" ImageUrl="~/theme/iflow/tabs/Agent2.png" />
                    <asp:ImageButton ID="lnkPage2" runat="server" OnClick="lnkPage2_Click" CssClass="TextBox"  Visible="false"
                        BackColor="Transparent" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/Education1.png" />
                    <asp:ImageButton ID="lnkPage3" runat="server" OnClick="lnkPage3_Click" CssClass="TextBox"  Visible="false" 
                        BackColor="Transparent" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/EmpHst2.png" />
                    <asp:ImageButton ID="lnkPage4" runat="server" OnClick="lnkPage4_Click" CssClass="TextBox"  Visible="false"
                        BackColor="Transparent" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/Disp2.png" />
                    <asp:ImageButton ID="lnkPage5" runat="server" OnClick="lnkPage5_Click" CssClass="TextBox"  Visible="false"
                        BackColor="Transparent" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/PaymentInfo2.png" />
                          <asp:LinkButton ID="lnkEmployee"  Text="Employee"  CssClass="btn btn-default"  OnClientClick="return addCssClassByClick('1')"  OnClick="lnkEmployee_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="lnkEducation"  Text="Education" CssClass="btn btn-default"  OnClick="lnkEducation_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="lnkEmpHist" Text="Employment History" CssClass="btn btn-default" OnClick="lnkEmpHist_Click"  OnClientClick="return addCssClassByClick('3')" runat="server"></asp:LinkButton>
                       
                       <asp:LinkButton ID="lnkDisp" Text="Disciplinary Info" CssClass="btn btn-default" OnClick="lnkDisp_Click"  OnClientClick="return addCssClassByClick('3')" runat="server"></asp:LinkButton>
                       <asp:LinkButton ID="lnkpaymnt" Text="Payment Info" CssClass="btn btn-default" OnClick="lnkpaymnt_Click"  OnClientClick="return addCssClassByClick('3')" runat="server"></asp:LinkButton>
                 
           </div>
                   <div class="panel" id="div1" runat="server">
                      <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgntinfo','btnAgntinfo');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblVw2AgntInfo" runat="server"  CssClass="control-label" Font-Size="19px"></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnAgntinfo" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                   <div id="divAgntinfo" runat="server" class="panel-body" style="display:block"> 
                    <div class="row" style="margin-bottom:5px;">
                     <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblVw2AgntCodeDisp" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                      </div>
                       <div class="col-md-3">
                                <asp:TextBox ID="lblVw2AgntCode" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                         </div>
                        <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblchnl" runat="server" Font-Bold="False" CssClass="control-label" Text="Hierarchy Name"></asp:Label>
                         </div>
                    <div class="col-md-3">
                                <asp:TextBox ID="lblchnlval" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                     </div>
                   </div>
                     <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblsubchnl" runat="server" Font-Bold="False" CssClass="control-label" Text="Sub Class"></asp:Label>
                      </div>
                           <div class="col-md-3">
                                <asp:TextBox ID="lblsubchnlval" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                          </div>
                       <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblVw2AgntTypeDisp" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                          </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="lblVw2AgntType" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                         </div>
                      </div>
                          <div class="row" style="margin-bottom:5px;">
                          <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblVw2AgntNameDisp" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                           </div>
                           <div class="col-md-3">
                                <asp:TextBox ID="lblVw2AgntName" CssClass="form-control"   Enabled="false"
 runat="server"></asp:TextBox>
                           </div>
                            <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblVw2AgntGenderDisp" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                           </div>
                               <div class="col-md-3">
                                <asp:TextBox ID="lblVw2AgntGender" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                          </div>
                        </div>
                        </div>
                        </div>
                         <div class="panel" id="div2" runat="server">
                             <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divEducatn','btnEducatn');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblEduBack" runat="server"  CssClass="control-label" Font-Size="19px"></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnEducatn" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                       <div id="divEducatn" runat="server" class="panel-body" style="display:block"> 
                           <div class="row" style="margin-bottom:5px;">
                           <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblHighAcadQual" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                           <div class="col-md-3">
                                <asp:DropDownList ID="ddlAcadQual" runat="server" CssClass="form-control" >
                                </asp:DropDownList>
                           </div>
                             <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblInstName" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                           </div>
                           <div class="col-md-3">
                                <asp:TextBox ID="txtInstName" runat="server" CssClass="form-control"  MaxLength="50" 
                                   ></asp:TextBox>
                          </div>
                     </div>
                             <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblGradDate" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                        </div>
                        <div class="col-md-3">
                                <asp:TextBox ID="txtGradDate" runat="server" CssClass="form-control" onchange="setDateFormat('txtDob')" 
                                onmousedown="$('#txtGradDate').datepicker({ changeMonth: true, changeYear: true });" />
                           </div>
                               <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblMajor" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                           </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtMajor" runat="server" CssClass="form-control"  MaxLength="50" 
                                  ></asp:TextBox>
                          </div>
                        </div>
                        </div>
                        </div>
                         <div class="panel" id="div3" runat="server">
                           <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divFamily','btnFamily');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblFamilyBack" runat="server"  CssClass="control-label" Font-Size="19px"></asp:Label>
                     <input
                                    id="hdnSpouseGivenName" runat="server" type="hidden" /><input id="hdnSpouseSurName"
                                        runat="server" type="hidden" />
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnFamily" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                   <div id="divFamily" runat="server" class="panel-body" style="display:block"> 
                      <div class="row" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblSpouseName" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                        </div>
                       <div class="col-md-3">
                                <asp:TextBox ID="txtSpouseName" runat="server" CssClass="form-control" MaxLength="30"
                                ></asp:TextBox>
                        </div>
                         <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblFamilyCnt" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                          </div>
                         <div class="col-md-3">
                                <asp:TextBox ID="txtFamilyCnt" runat="server" CssClass="form-control" MaxLength="3"></asp:TextBox>
                      </div>
                    </div>
                         <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblEmployerName" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                       </div>
                          <div class="col-md-3">
                                <asp:TextBox ID="txtEmployerName" runat="server" CssClass="form-control"
                                    MaxLength="30"></asp:TextBox>
                       </div>
                         <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblNoOfChild" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                        </div>
                           <div class="col-md-3">
                                <asp:TextBox ID="txtNoOfChild" runat="server" CssClass="form-control" MaxLength="2"></asp:TextBox>
                           </div>
                      </div>
                         <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblDesignation" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                   </div>
                        <div class="col-md-3">
                                <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control"
                                    MaxLength="50"></asp:TextBox>
                        </div>
                  </div>
                        </div>
                        </div>
                <div class="row">
        <div class="col-md-12" style="text-align:center">
                  <%--  <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        CssClass="standardbutton" onclick="btnUpdate_Click" />--%>
                            <asp:LinkButton ID="btnUpdate" runat="server"  CssClass="btn btn-sample" Text="Update"
                          OnClick="btnUpdate_Click" >
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Update
                                  </asp:LinkButton>
                  <%--  <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="standardbutton" CausesValidation="False" />--%>
                    <asp:LinkButton ID="btnCancel" runat="server"  CssClass="btn btn-sample" Text="Cancel" CausesValidation="False"
                         >
                                  <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                                  </asp:LinkButton>
           </div>
         </div>
        </table>
    </div>
<asp:Panel runat="server" ID="Panelpop" Width="850" display="none">
        <iframe runat="server" id="Iframepop" width="850" height="300px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label8" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="Mdlviewpopup" BehaviorID="mdlViewpop"
        DropShadow="true" TargetControlID="Label8" PopupControlID="Panelpop" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnlMdl" Width="500" Height="350" display="none">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="no" width="500" frameborder="0"
            display="none" style="height: 350px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
       <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
          <div class="modal-content" >
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label13" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl3" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-sample" data-dismiss="modal" style='margin-top:-6px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      </div>
  </div>
  
</asp:Content>

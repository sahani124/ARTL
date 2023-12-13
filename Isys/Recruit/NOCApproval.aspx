<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="NOCApproval.aspx.cs"
    Inherits="Application_INSC_Recruit_NOCApproval" Title="Untitled Page" %>

<%@ Register Src="../../../App_UserControl/Common/ctlDate.ascx" TagName="ctlDate"
    TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
        <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
   <%-- <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />--%>
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
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />--%>
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
    <script type="text/javascript">

        function popup() {
            debugger;
            $("#myModal").modal();
        }

        function ShowReqDtl12(divName, btnName) {
            debugger;
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
        //for main div
        function ShowReqDtl(divName, btnName) {
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

        function validreject() {
            debugger;
            alert('1');
            var strContent = "ctl00_ContentPlaceHolder1_";
            if ($("#" + strContent + "cbRejectFlag").checked == false) {
                alert("Please Select Reason for Reject");
                document.getElementById(strContent + "cbRejectFlag").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            else {
                if ($("#" + strContent + "txtReject").val() == "") {
                    alert("Please Enter Reason for Reject");
                    document.getElementById(strContent + "txtReject").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
        }
        function Cancel1(modalimg, modalimg1) {
            debugger;
            var modal = modalimg;
            var modal1 = modalimg1;
            modal.style.display = "none";
            modal1.style.display = "none";
        }

    </script>
    <style type="text/css">
        .disablepage {
            display: none;
        }

        .rbl input[type="radio"] {
            margin-left: 10px;
            margin-right: 1px;
        }

        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
        }

        .textalign th {
            padding-left: 42%;
        }
    </style>
    <style type="text/css">
        .modal-dialog {
            position: relative;
            display: table;
            overflow-y: auto;
            overflow-x: auto;
            width: auto;
            min-width: 50px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>

   
        <%--<div style="overflow: hidden;">--%>
          <%--  <div class="panel ">--%>
                <div id="tdPopUp" runat="server" visible="false" class="row">
                        <div class="col-sm-12" >
                            <asp:Label ID="lblMessage" runat="server"  Visible="false"  ForeColor="Green"  Width="310px"></asp:Label>
                             <asp:Label ID="lblSuccessMsg" runat="server"  Visible="false"  ForeColor="Green"  Width="310px"></asp:Label>
                        </div>
                    </div>
                <div class="stripPanelClass">
                       <ul class="nav nav-tabs" id="myTab" role="tablist">
                      <li class="nav-item" role="presentation">
                        <label class="nav-link Strip" id="divCRH" runat="server" data-bs-toggle="tab" type="label" role="tab" aria-controls="divCR" aria-selected="false" style="font-size: 12px!important;"><span id="span8" runat="server" class="badge bg-secondary numbercircle ">1</span>&nbsp CFR Raised</label>
                    </li>
                     <li class="nav-item" role="presentation">
<%--                        <button class="nav-link active Strip" id="divRDH" runat="server" data-bs-toggle="tab" type="button" role="tab" aria-controls="divRD" aria-selected="true"><span id="span7" runat="server" class="badge bg-secondary numbercircle">1</span>&nbsp Candidate Details </button>--%>
                        <label class="nav-link active Strip" id="divRDH" runat="server" data-bs-toggle="tab" type="label" role="tab" aria-controls="divRD" aria-selected="true" style="font-size: 12px!important;"><span id="span7" runat="server" class="badge bg-secondary numbercircle">2</span>&nbsp Candidate Details </label>
                    </li>
                    <li class="nav-item" role="presentation">
<%--                        <button class="nav-link Strip" id="divPAH" runat="server" data-bs-toggle="tab" type="button" role="tab" aria-controls="divPA" aria-selected="false"><span id="span10" runat="server" class="badge bg-secondary numbercircle ">2</span>&nbsp Confirmation</button>--%>
                        <label class="nav-link Strip" id="divPAH" runat="server" data-bs-toggle="tab" type="label" role="tab" aria-controls="divPA" aria-selected="false" style="font-size: 12px!important;"><span id="span10" runat="server" class="badge bg-secondary numbercircle ">3</span>&nbsp Confirmation</label>
                    </li>
                </ul>
            </div>

        <div class="tab-content" id="myTabContent">

    <%--Personal Details Start--%>
            <div class="tab-pane fade show active PanelInsideTab" id="divCR" role="tabpanel" aria-labelledby="divCRH">
                            
            </div>
    <%--Personal Details End--%>

 
    <%--Training & Exam Details Start--%>
            <div class="tab-pane fade PanelInsideTab" id="divRD" role="tabpanel" aria-labelledby="divRDH">3
        
  </div>
       <%--Training & Exam Details End--%>
            <div class="tab-pane fade PanelInsideTab" id="divPA" role="tabpanel" aria-labelledby="divPAH">4

 </div>
</div>

                        <div class="card PanelInsideTab" id="divPannel1" runat="server" style="margin-top: -10px;" >
                           <div class="row rowspacing" style="padding-left:20px;">  <%--padding-top:10px--%>
                   <%-- <div class="panel-heading subheader"  onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_tblRpt','Spandiv');return false;" style="">--%>
                         <div class="panelheadingAliginment" style="display:none"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_tblRpt','Spandiv');return false;">
                         <div class="row rowspacing">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblTitle1" runat="server" Text="" CssClass="control-label" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Spandiv" class="glyphicon glyphicon-chevron-up" style="float: right; color: #00cccc; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                          </div>
                         <div id="tblRpt" runat="server" class="row" style="display:block;">
                             <div id="divSearchDetails" class="panel-body" style="width:99%;display:none">
                                 <div class="row rowspacing">
                                 <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAppNo" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                                </div>
                                 <div class="col-sm-3" >
                                    <asp:TextBox ID="lblAppNoValue" Enabled="false" CssClass="form-control"  style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                                </div>
                                 <div class="col-sm-3" style="text-align: left" >
                                    <asp:Label ID="lblCndName" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                                </div>
                                 <div class="col-sm-3" >
                                    <asp:TextBox ID="lblAdvNameValue" Enabled="false" CssClass="form-control"  runat="server"></asp:TextBox>
                               </div>
                               </div>
                              </div>
                          <div id="Div4"  runat="server"  class="panel" visible="false">
                         <div class="panel-heading subheader"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divagndetails','Span1');return false;" style="">
                         <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblCnddtls" runat="server" Text="NOC Request" CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span1" class="glyphicon glyphicon-chevron-up" style="float: right; color: #00cccc; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                           </div>
                  
                 <%--   not required usa --%>
                        <div id="divIsSpecified" runat="server" style="display: none;">
                    <asp:UpdatePanel ID="Updatepanel114" runat="server">
                        <ContentTemplate>
                            <table class="tableIsys" style="width: 90%;">
                                <tr>
                                    <td class="formcontent" style="width: 20%;">
                                        <asp:Label ID="lblIsSPFlag" runat="server" Style="color: black"></asp:Label>
                                    </td>
                                    <td style="width: 30%;" class="formcontent">
                                        <asp:UpdatePanel ID="UpdIsSPFlag" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rbtIsSP" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                    Visible="true" TabIndex="25" Enabled="false">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td style="width: 20%;" class="formcontent">
                                    </td>
                                    <td style="width: 30%;" class="formcontent">
                                    </td>
                                </tr>
                                <tr id="tr_IsSPDtls" visible="false" runat="server">
                                    <td class="formcontent" style="width: 20%;">
                                        <asp:UpdatePanel ID="Updatepanel15" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblCACode" runat="server" Style="color: black"></asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent" style="width: 30%;">
                                        <asp:UpdatePanel ID="Updatepanel16" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtCACode" runat="server" CssClass="standardtextbox" MaxLength="20"
                                                    Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();"> 
                                                

                                                </asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender77" runat="server"
                                                    InvalidChars=",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtCACode" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent" style="width: 20%;">
                                        <asp:UpdatePanel ID="Updatepanel17" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblCAName" runat="server" Style="color: black"></asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent" style="width: 30%;">
                                        <asp:UpdatePanel ID="Updatepanel118" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtCAName" runat="server" CssClass="standardtextbox" MaxLength="20"
                                                    Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();">

                                                </asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender76" runat="server"
                                                    InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" FilterMode="InvalidChars"
                                                    TargetControlID="txtCAName" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                 <%--   not required usa --%>     
                                                 
                       <div runat="server" id="divagndetails" style="display: block" class="panel-body">
                          <div class="row rowspacing" >
                                       <div class="col-sm-4" style="text-align: left">
                                         </div>
                                      <div class="col-sm-4" style="text-align: left">
                                         </div>
                                      <div class="col-sm-4" style="text-align: left">
                                        <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details" OnClick="lblCndView_Click" class="control-label labelSize" visible="true"></asp:LinkButton>
                                           </div>  

                                             </div>
                         <div class="row rowspacing" >
<%--                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCndNo"  CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                           </div>--%>
<%--                          <div class="col-sm-3"  >
                                <asp:TextBox ID="lblCndNoValue" Enabled="false"  CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>--%>
                       <%--   <div class="col-sm-3" style="text-align: left">
                                <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details" OnClick="lblCndView_Click"></asp:LinkButton>
                          </div>--%>
<%--                            <div class="col-sm-3"  >
                            </div>--%>

                               <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblCndNo"  CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="lblCndNoValue" Enabled="false"  CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="Label11" CssClass="control-label" Text="Mobile No" runat="server" ></asp:Label>
                                <asp:TextBox ID="lblmobile"  Enabled="false" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
                         <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="Label12" runat="server" CssClass="control-label" Text="PAN No" Font-Bold="False" ></asp:Label>
                                <asp:TextBox ID="lblpanno" Enabled="false"  CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>

                          </div>
                      <%--  </tr>--%>
                        <div class="row rowspacing" >
                        <%--  <div class="col-sm-3" style="text-align: left" >
                                <asp:Label ID="Label11" CssClass="control-label" Text="Mobile No" runat="server" ></asp:Label>
                          </div>--%>
                         <%-- <div class="col-sm-3" >
                                <asp:TextBox ID="lblmobile"  Enabled="false" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>--%>
                          <%--<div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label12" runat="server" CssClass="control-label" Text="PAN No" Font-Bold="False" ></asp:Label>
                           </div>--%>
                      <%--    <div class="col-sm-3" >
                                <asp:TextBox ID="lblpanno" Enabled="false"  CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                          </div>--%>
<%--                          <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label13" runat="server" CssClass="control-label" Text="Agency Code" Font-Bold="False"></asp:Label>
                           </div>--%>
<%--                          <div class="col-sm-3" >
                                <asp:TextBox ID="lblagencycodeValue" Enabled="false" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>--%>
<%--                          <div class="col-sm-3" style="text-align: left" >
                                <asp:Label ID="lbldateissue" CssClass="control-label" runat="server" Text="Date of Issue of Appointment" Font-Bold="False"></asp:Label>
                             </div>--%>
<%--                          <div class="col-sm-3">
                                <asp:TextBox ID="lbldateissuevalue" Enabled="false" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>--%>
                               <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="Label13" runat="server" CssClass="control-label" Text="Agency Code" Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="lblagencycodeValue" Enabled="false" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lbldateissue" CssClass="control-label" runat="server" Text="Date of Issue of Appointment" Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="lbldateissuevalue" Enabled="false" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
                         <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lbldos" CssClass="control-label" runat="server" Text="Date of Submission" Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="lbldate" Enabled="false" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>

                            </div>
                          
                        <%--  usha 03.07.2015--%>
                          <div class="row rowspacing"  id="trdos" runat="server" >
<%--                            <div class="col-sm-3" style="text-align: left" >                            
                                <asp:Label ID="lbldos" CssClass="control-label" runat="server" Text="Date of Submission" Font-Bold="False"></asp:Label>
                              </div>--%>
<%--                          <div class="col-sm-3"  >
                                <asp:TextBox ID="lbldate" Enabled="false" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>--%>
                         <%-- <div class="col-sm-3" style="text-align: left" >
                                <asp:Label ID="lbldoa"  CssClass="control-label"  runat="server" Text="Date of acceptance of resignation" Font-Bold="False"></asp:Label>
                              </div>--%>
                       <%--   <div class="col-sm-3"  >
                                <asp:TextBox ID="lbldoar" Enabled="false" style="margin-bottom:5px;" CssClass="form-control" runat="server" Font-Bold="False"></asp:TextBox>
                         </div>--%>
                       <%-- </tr>--%>
                                <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lbldoa"  CssClass="control-label"  runat="server" Text="Date of acceptance of resignation" Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="lbldoar" Enabled="false" style="margin-bottom:5px;" CssClass="form-control" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
                         </div>
                        <%--    </table>--%>
                            </div>
                           
                    </div>
                       <table>
                        <tr style="display: none">
                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblBranch" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblBranchValue" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblSMName" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblSMNameValue" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; height: 16px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblReqStatus" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 16px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblReqStatusValue" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 16px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblSponsorDt" Text="Sponsor Date" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 16px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblSponsorDtValue" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; height: 38px; display: none" class="formcontent" align="left">
                                <span style="color: Red">
                                    <asp:Label ID="lblMobileNo" Text="Mobile No" runat="server" Style="color: Black"></asp:Label>*</span>
                            </td>
                            <td style="width: 30%; height: 38px; display: none" class="formcontent" align="left">
                                <asp:TextBox ID="txtmobilecode" runat="server" Text="91" CssClass="standardtextbox"
                                    Width="25px" Enabled="false" BackColor="#FFFFB2"></asp:TextBox>
                                <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" CssClass="standardtextbox"
                                    Width="155px" BackColor="#FFFFB2"></asp:TextBox><%-- onblur="form2();"--%>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                    FilterMode="InvalidChars" TargetControlID="txtMobileNo" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:Button ID="btnverifymobile" runat="server" Text="Verify" ValidationGroup="RecruitInfo"
                                    CssClass="standardbutton"></asp:Button>
                                <div id="divmob" class="Content" style="display: none">
                                    <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                    Loading...</div>
                                <br />
                                <asp:Label ID="lblmobileverify" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 38px; display: none" class="formcontent" align="left">
                                <span style="color: Red">
                                    <asp:Label ID="lblPAN" runat="server" Text="PAN No" Font-Bold="False" Style="color: Black"></asp:Label>*</span>
                            </td>
                            <td style="width: 30%; height: 38px; display: none" class="formcontent" align="left">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" CssClass="standardtextbox"
                                            onChange="javascript:this.value=this.value.toUpperCase();" BackColor="#FFFFB2"></asp:TextBox>
                                        <asp:Button ID="btnVerifyPAN" runat="server" Text="Verify" CssClass="standardbutton"
                                            ValidationGroup="RecruitInfo"></asp:Button>
                                        <div id="divPAN" class="Content" style="display: none">
                                            <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                            Loading...</div>
                                        <br />
                                        <asp:Label ID="lblPANMsg" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                        <asp:HiddenField ID="hdnPanDtls" runat="server"></asp:HiddenField>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                <span style="color: Red">
                                    <asp:Label ID="lblEmail" runat="server" Text="Email" Style="color: Black"></asp:Label>*</span>
                            </td>
                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:TextBox ID="txtEMail" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                    onblur="validateEmail1(this.value)"></asp:TextBox>
                                <asp:Button ID="btnverifyemail" runat="server" Text="Verify" ValidationGroup="RecruitInfo"
                                    CssClass="standardbutton"></asp:Button>
                                <div id="divEmail" class="Content" style="display: none">
                                    <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                    Loading...</div>
                                <br />
                                <asp:Label ID="lblEmailMsg" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblpandetail" runat="server" Text="Is Pan name different from registered name"
                                    Font-Bold="False"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:CheckBox ID="Chkpan" runat="server" />
                            </td>
                        </tr>
                        <tr id="trlicn" runat="server" visible="false">
                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblLicnno" runat="server" Text="License No" CssClass="standardlabel"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:TextBox ID="txtlicno" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                <asp:Label ID="lbllicnoval" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:Label ID="lblLicExpDt" runat="server" Text="LicenseExpDate" CssClass="standardlabel"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                <asp:TextBox ID="txtLicExpDt" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="center" style="display: none">
                            <td>
                                <asp:Label ID="LabelFees" runat="server" Visible="false" ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div id="Div3" class="panel card" runat="server"  style="padding-top:20px;margin-top:45px!important;display:none" >
                       <div class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divNOCdetails','Span2');return false;">
                               <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="reasonNOC" runat="server" Text="Reason for NOC" CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span2" class="glyphicon glyphicon-chevron-up" style="float: right; color: #00cccc; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                            </div>
                         <div id="divNOCdetails" runat="server" style="display:block"  class="panel-body">
                            <div class="row rowspacing" style="margin-bottom: 40px;" >
                             <div class="col-sm-4" style="text-align: left" >
                                <asp:Label ID="lblselect" runat="server" CssClass="control-label" Text="Type of Leaving Reason" Font-Bold="False"></asp:Label>

                                <asp:TextBox ID="lblsnlve" Enabled="false" CssClass="form-control" runat="server" ></asp:TextBox>
                          </div>
                                 <div class="col-sm-4" style="text-align: left" >
                                <asp:Label ID="lblreasontext" runat="server" CssClass="control-label" Text="Reason for leaving organization"
                                    Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="txtreasonleave" runat="server" Rows="4" TextMode="multiline" 
                                    CssClass="form-control"></asp:TextBox>
                </div>
                                </div>
                </div>
                </div>
                    <div id="tblResonInsurer" runat="server" visible="false" class="panel">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblremarkinsurer" runat="server" Text="Remark of Insurer" CssClass="control-label" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span3" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                             <div id="tblremarkinsurer" runat="server" visible="false" class="row" >                      
                                <div class="col-sm-6" style="text-align: left"   >
                                <asp:Label ID="lblremark" runat="server" Text="Remark of Insurer" Font-Bold="False"></asp:Label>
                          </div>
                            <div class="col-sm-6" >
                                <asp:TextBox ID="txtReInsurer" runat="server" Rows="4" TextMode="multiline" CssClass="form-control"
                                  ></asp:TextBox>
                            </div>
                      </div>
                     </div>
                     <br />
                    <div id="Div2"  runat="server" class="panel">
                     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                            <div id="trReject" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRejectCase','Span6');return false;" style="">
                                                  
                                 <div class="row">
                            <div class="col-sm-10" style="text-align: left;margin-left: -14px;">
                                <asp:Label ID="lblRejectDtl" runat="server" Text="Reason for Reject" CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>

                            </div>
                            <div class="col-sm-2">
                                <span id="Span6" class="glyphicon glyphicon-chevron-down" style="float: right; color:  #00cccc;; padding: 1px 10px ! important; font-size: 18px;margin-right: -16px;"></span>
                            </div>
                        </div>
                              </div>
                                      <div id="divRejectCase" runat="server" style="display:block;" class="panel-body">
                                      <div class="row">
                                      <div class="col-sm-6" style="text-align:left;">
                                            <asp:CheckBox ID="cbRejectFlag" runat="server" CssClass="standardcheckbox"  
                                                        AutoPostBack ="true" Enabled="true"
                                                        oncheckedchanged="cbRejectFlag_CheckedChanged"  TabIndex="20" Style="margin-left: 8px;"/>
                                                     <asp:Label ID="lblRejectFlag" CssClass="control-label" Font-Bold="true" runat="server" Text="Reject Case" ></asp:Label>
                                               </div>
                                      </div>
                                      <div class="row">
                               <div id="divRejectDetails" runat="server" visible="false" class="panel-body" >
                                        <div class="row"  >
                                <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblReject" runat="server" CssClass="control-label" Text="Reason for Reject" Font-Bold="False"></asp:Label>
                            </div>
                             <div class="col-sm-6"  >
                                <asp:TextBox ID="txtReject" CssClass="form-control" runat="server" Rows="4" TextMode="multiline" 
                                  ></asp:TextBox>
                                           </div>
                                           </div>
                                           </div>
                                          </div>
                                          </div> 
                                     
                                  </ContentTemplate>
                               <Triggers><asp:AsyncPostBackTrigger ControlID="cbRejectFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger></Triggers>
                            </asp:UpdatePanel>
                            </div>

                                     <br />
                                <br />
                                <br />

                    <div  id="tblconfirm" runat="server"  class="panel" visible="false">
                  <div  class="panelheadingAliginment" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_tblconfirm2','Span5');return false;" style="">
                      <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label6" runat="server" Text="Confirmation" CssClass="control-label HeaderColor" Font-Size="19px" Style="margin-left: -1px;"></asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:Label ID="lblNoteIc"  runat="server"  Text="[Note: CFR will be auto raised if option selected as Yes]"   ForeColor="Red"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span5" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc;; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                </div>
                  <div id="tblconfirm2" runat="server" class="panel-body">
                    <%--  <asp:UpdatePanel ID="upd" runat="server">
                      <ContentTemplate>--%>
                         <div id="trDgDetails" runat="server" class="row" >
                            <div class="col-sm-9" style="text-align: left" >
                       
                        <%--<table style="width: 90%" id="tblconfirm2" runat="server" class="formtable table-condensed">
                            <tr style="width: 90%" id="trDgDetails" runat="server">--%>
                              
                              <%--  <td style="height: 25px">--%>
                                    <asp:Label ID="lblHasAgent79" CssClass="control-label" Text="Whether any amount is outstanding OR due to accounts ?" runat="server"
                                       ></asp:Label>
                                    <span style="color: red">*</span>
                                    </div>
                             
                                <div class="col-sm-3"  >
                                    <asp:RadioButtonList ID="Confirm1" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                     CssClass="rbl"
                                        EnableViewState="true" CellPadding="2" CellSpacing="2"  OnSelectedIndexChanged="Confirm1_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                              </div>
                              <asp:Label ID="c1" CssClass="control-label"  runat="server" ></asp:Label>
                              </div>
                          <div id="tr1" runat="server"  class="row" >
                               <div class="col-sm-9" style="text-align: left" >
                                    <asp:Label ID="Label380" CssClass="control-label"  runat="server" 
                                       Text="Whether any Covernotes, Blank Forms, Commission 
                                    receivable, Cheque Bounce recoverable pending from 
                                    agent?">
                                        </asp:Label>
                                    <span style="color: red">*</span>
                              </div>
                                <div class="col-sm-3">
                                    <asp:RadioButtonList ID="Confirm2" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                     CssClass="rbl"
                                        EnableViewState="true" CellPadding="2" CellSpacing="2" OnSelectedIndexChanged="Confirm2_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                            </div>
                              <asp:Label ID="C2" runat="server" CssClass="control-label" ></asp:Label>
                            </div>
                            <%--<tr style="width: 100%" id="tr2" runat="server">--%>
                             <div id="tr2" runat="server" class="row" >
                               <div class="col-sm-9" style="text-align: left"  >
                                    <asp:Label ID="Label581" CssClass="control-label" Text="Return of appointment letter, ID card & POS keys, pending if any" runat="server" 
                                        ></asp:Label>
                                    <span style="color: red">*</span>
                               </div>
                                  <div class="col-sm-3"  >
                                    <asp:RadioButtonList ID="Confirm3" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                     CssClass="rbl"
                                        EnableViewState="true" CellPadding="2" CellSpacing="2"  OnSelectedIndexChanged="Confirm3_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                  <asp:Label ID="C3" runat="server" CssClass="control-label" ></asp:Label>
                        </div>
                </div>
                </div>
                    <div id="divCFRInbox" visible="false"  runat="server" class="panel card">

                 <div id="div5" runat="server"  class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_tblCFRInbox','Span4');return false;" style="">
                       <div id="tblCFRInboxCollapse" runat="server" visible="false" class="row">
                            <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblhead" runat="server" Text="Raised CFR's" CssClass="control-label HeaderColor" Font-Size="19px" Style="color: #00cccc;"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span4" class="glyphicon glyphicon-chevron-up" style="float: right; color: #00cccc; padding: 1px 10px ! important; font-size: 18px;margin-right: -28px"></span>
                            </div>
                        </div>
                               </div>
                                   </div>
        
                        
                    <div id="tblCFRInbox" class="panel-body"   runat="server" >  <%--style="overflow:auto;"--%>
                              <div id="trCfrInbox" visible="false" runat="server" class="row" >
                   
                                            <div class="col-sm-3" >
                                                <asp:Label ID="lblcfrraised" runat="server" Text="Raised CFR" CssClass="control-label"></asp:Label>
                                                </div>
                                                  <div class="col-sm-3" >
                                                <asp:Label ID="lblcfrraisedcount" runat="server" CssClass="control-label"></asp:Label>
                                                </div>
                                                  <div class="col-sm-3" >
                                                <asp:Label ID="lblresponded" runat="server" Text="Responded CFR" CssClass="control-label"></asp:Label>
                                                </div>
                                                  <div class="col-sm-3" >
                                                <asp:Label ID="lblcfrrespondedcount" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                        </div>
                  
                                <asp:GridView  ID="dgDetailsInbox" runat="server" CssClass="footable"
                                    AutoGenerateColumns="False" AllowPaging="True"
                                    OnRowCommand="dgDetailsInbox_RowCommand" OnPageIndexChanging="dgDetailsInbox_PageIndexChanging"
                                    PageSize="5" OnRowDataBound="dgDetailsInbox_RowDataBound">
                                    <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRow" />
                                        <HeaderStyle CssClass="gridview" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Wrap="false" ItemStyle-Width="6%">
                                            <ItemTemplate>
                                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                       <ContentTemplate>
                                                <asp:CheckBox ID="ChkAssigned" OnCheckedChanged="ChkAssigned_CheckedChanged" runat="server"
                                                    AutoPostBack="true" />
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="False" ></HeaderStyle>
                                            <ItemStyle Width="6%" CssClass="pad"></ItemStyle>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR Raised For">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcfr" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle />
                                            <ItemStyle HorizontalAlign="left" CssClass="pad" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="RemarkId" HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarkid" runat="server" Text='<%# Eval("RemarkID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle  />
                                            <ItemStyle HorizontalAlign="left" CssClass="pad" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                         <asp:TemplateField SortExpression="Remark" HeaderText="Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddnlRemark" runat="server"  Text='<%# Eval("AddnlRemark") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle  />
                                            <ItemStyle HorizontalAlign="left" CssClass="pad" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Responded" HeaderText="Responded">
                                            <ItemTemplate>
                                                <asp:Label ID="Responded" runat="server" Text='<%# Eval("Responded") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle />
                                            <ItemStyle HorizontalAlign="left" CssClass="pad" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Responded" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCFRRemarkID" runat="server" Text='<%# Eval("CFRRemarkID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle  />
                                            <ItemStyle HorizontalAlign="left" CssClass="pad" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRaisedFlag" runat="server" Text='<%# Eval("RaisedFlag") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle  />
                                            <ItemStyle HorizontalAlign="left" CssClass="pad" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCFRDocCode" runat="server" Text='<%# Eval("DocCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle/>
                                            <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate >
                                                <asp:Label ID="lblCFRFlagType" runat="server" Visible="false" Text='<%# Eval("CFRFlagType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle  />
                                            <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField >
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkReopen" Style="text-align: center;width: 10%;" runat="server" Text="ReOpen CFR"
                                                    CommandArgument='<%# Eval("RemarkId") %>' CommandName="ReopenCFR"></asp:LinkButton>  <%-- Visible="false"--%>
                                            </ItemTemplate>
                                            <HeaderStyle  />
                                            <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                       
                                    </Columns>
                                </asp:GridView>
                               
                        <br />
                         </div>

                    </div>
                              <br />
                                <br />
                                <br />

                    <div class="col-sm-12" style="margin-bottom: 1%;">
                        <div id="buttons" runat="server" class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnprevs" runat="server" CssClass="btn btn-clear" AutoPostback="false" TabIndex="10" style="width:125px" Visible="false" OnClick="btnprevs_Click">
                                 <span class="glyphicon glyphicon-arrow-left" style='color:#00cccc;'></span> PREVIOUS
                                </asp:LinkButton> 
                            <asp:LinkButton ID="btnprv" runat="server" CssClass="btn btn-clear" AutoPostback="false" TabIndex="10" style="width:125px" Visible="false" OnClick="btnprv_Click">
                                 <span class="glyphicon glyphicon-arrow-left" style='color:#00cccc;'></span> PREVIOUS
                                </asp:LinkButton> 
                                 <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-success"  
                                 Visible="True" Enabled="false" OnClientClick="StartProgressBar();" OnClick="btnSave_Click">
                                 <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Save
                                </asp:LinkButton>
                                       <asp:LinkButton ID="BtnApprove" runat="server" CssClass="btn btn-success"  
                                 Visible="True" Enabled="false" OnClientClick="StartProgressBar();" OnClick="BtnApprove_Click">
                                 <span class="glyphicon glyphicon-ok-circle" style="color:White"> </span> Approve
                                </asp:LinkButton>
                                      <asp:LinkButton ID="btnReject" runat="server" CssClass="btn btn-success"  
                                 Visible="True"  OnClientClick="return validreject();" OnClick="btnReject_Click">
                                 <span class=" glyphicon glyphicon-remove-circle" style="color:White"> </span> Reject
                                </asp:LinkButton>
                                     <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-danger" OnClientClick="doCancel()" TabIndex="43">
                                <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                                </asp:LinkButton>
                                     <asp:LinkButton ID="btnCancel1" runat="server" CssClass="btn btn-success"  Visible="false" OnClick="btnCancel1_Click" TabIndex="44">
                                <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btnCroprefresh" runat="server" CssClass="btn btn-primary"  Style="display: none;"
                                    ClientIDMode="Static" />
                                <asp:LinkButton ID="btnReOpenReFresh" runat="server" CssClass="btn btn-primary"   Style="display: none;"
                                    ClientIDMode="Static" />
                               <asp:LinkButton ID="Btnnext" runat="server" CssClass="btn btn-success" TabIndex="10" onclick="Btnnext_Click" style="width:90px;">
                               NEXT <span class="glyphicon glyphicon-arrow-right" style='color:White;'></span> 
                                </asp:LinkButton>
                               <asp:LinkButton ID="btnnext2" runat="server" CssClass="btn btn-success" TabIndex="10" style="width:90px;" Visible="false" OnClick="btnnext2_Click">
                               NEXT <span class="glyphicon glyphicon-arrow-right" style='color:White;'></span> 
                                </asp:LinkButton>

                                <div id="divloader" runat="server" style="display: none;">
                               
                                    <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                                    Loading...
                                </div>
                            </div>
                            </div>
                                <br />
                                <br />
                                <br />
                     <div id="tblButton" runat="server" class="col-sm-12" align="center">
                               <asp:LinkButton ID="lnkPrv" runat="server" CssClass="btn btn-clear" AutoPostback="false" TabIndex="10" style="width:125px" Visible="false">
                                 <span class="glyphicon glyphicon-arrow-left" style='color:#00cccc;'></span> PREVIOUS
                                </asp:LinkButton> 
                              <asp:LinkButton ID="Btnprev" runat="server" CssClass="btn btn-clear" AutoPostback="false" TabIndex="10" style="width:125px" Visible="false" OnClick="Btnprev_Click">
                                 <span class="glyphicon glyphicon-arrow-left" style='color:#00cccc;'></span> PREVIOUS
                                </asp:LinkButton> 
                                  <asp:LinkButton ID="Btnprevious" runat="server" CssClass="btn btn-clear" AutoPostback="false" TabIndex="10" style="width:125px;" Visible="false" OnClick="Btnprevious_Click">
                                 <span class="glyphicon glyphicon-arrow-left" style='color:#00cccc;'></span> PREVIOUS
                                </asp:LinkButton>   <%--OnClientClick="navbuttonclick(this)" --%>
                             <asp:LinkButton ID="btnRespond" runat="server" CssClass="btn btn-success" OnClick="btnRespond_Click" Visible="false" 
                              TabIndex="11">
                                 <span class="glyphicon glyphicon-share-alt BtnGlyphicon"> </span> Respond
                                </asp:LinkButton>
                               <asp:LinkButton ID="btnCloseCfr" runat="server" CssClass="btn btn-success"  OnClick="btnCloseCfr_Click" Visible="false"  TabIndex="11">
                                 <span class="glyphicon glyphicon-ban-circle BtnGlyphicon"> </span> Close CFR
                                </asp:LinkButton>
                                     <asp:LinkButton ID="btn_Approve" runat="server" CssClass="btn btn-success"   OnClientClick="StartProgressBar();"
                                 OnClick="btn_Approve_Click" Visible="false"  TabIndex="11">
                                 <span class="glyphicon glyphicon-ok-circle BtnGlyphicon"> </span> Approve
                                </asp:LinkButton>
                                   <asp:LinkButton ID="btnCancel" runat="server" Visible="false" CssClass="btn btn-clear" OnClick="btnCancel_Click" OnClientClick="doCancel()"
                                  TabIndex="11">
                                  <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color:#d32020"> </span> CANCEL
                                </asp:LinkButton>
                                     <asp:LinkButton ID="btncancel12" runat="server" CssClass="btn btn-clear"  OnClick="btncancel12_Click"
                                  Visible="false"  TabIndex="11">  <%--OnClick="btn_Approve_Click"  OnClientClick="doCancel()"--%>
                                  <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color:#d32020"> </span> CANCEL
                                </asp:LinkButton>
                                    <asp:LinkButton ID="btnClear1" runat="server"  OnClientClick="funcClear()"   CssClass="btn btn-clear"  OnClick="btnClear1_Click" style="border: 2px solid;border-radius: 5px;display:none;"
                                  TabIndex="43"> 
                                     <span class="glyphicon glyphicon-remove" style="color:#d32020" ></span> CANCEL
                                 </asp:LinkButton> 
                                  <asp:LinkButton ID="btnNxt1" runat="server" CssClass="btn btn-success" TabIndex="10" onclick="btnNxt1_Click" style="width:90px;">
                               NEXT <span class="glyphicon glyphicon-arrow-right" style='color:White;'></span> 
                                </asp:LinkButton>
                                    <asp:LinkButton ID="btnnext1" runat="server" CssClass="btn btn-success" TabIndex="10" style="width:90px;" Visible="false" OnClick="btnnext1_Click">
                               NEXT <span class="glyphicon glyphicon-arrow-right" style='color:White;'></span> 
                                </asp:LinkButton>
                    </div>

                    <br />
                </div>
                          </div> 
                        </div> 
            <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" >
        <div style="text-align: center;background-color:white;padding: 15px;min-height: 16.4286px;border-bottom: 1px solid rgb(229, 229, 229);"> <%-- class="modal-header" --%>
            <asp:Label ID="Label8" Text="INFORMATION" runat="server" Style="margin-left:9px;color: #00cccc; font-size: 19px;"></asp:Label>  <%--Font-Bold="false" --%>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lblus" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-success" data-dismiss="modal"  style='margin-top:-6px;margin-right: 94px;' />
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK
        </div>
      </div>
      
    </div>
  </div>
        <%--</div>--%>
        <asp:ListBox ID="LstImagepath" runat="server" Style="display: none"></asp:ListBox>
        <asp:ListBox ID="Listlabel" runat="server" Style="display: none"></asp:ListBox>
        <asp:ListBox ID="ListDoccode" runat="server" Style="display: none"></asp:ListBox>
        <asp:ListBox ID="ListID" runat="server" Style="display: none"></asp:ListBox>

<%--        <asp:Panel runat="server" ID="PnlReOpenCFR" Width="100%" display="none"> 
                <iframe runat="server" id="IframeReOpenCFR" frameborder="0" display="none" style="width:683px;
                    height: 350px"></iframe>
            </asp:Panel>--%>
<%--        <asp:Label runat="server" ID="lblReOpenCFR" Style="display: none" />--%>
<%--        <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopReOpenCFR" BehaviorID="MdlPopReOpenCFR"
            TargetControlID="lblReOpenCFR" PopupControlID="PnlReOpenCFR"  BackgroundCssClass="modalPopupBg" DropShadow="true" > 
        </ajaxToolkit:ModalPopupExtender>--%>

<div class="modal" id="myModalReOpenCFR" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;margin-top: -2px;" >
  <div class="modal-dialog" style="
    padding-top: 0px; margin-top:100px;
    width: 70%;">
    <div class="modal-content">
     
       

          <div class="row" style=" margin-top: 10px;">
                     <div class="col-sm-3" style="text-align:center;">
                       
                       <span class="glyphicon glyphicon-arrow-left" style="color:#00cccc"> </span>   <asp:Label ID="Label24" Text="ReOpen CFR" CssClass="HeaderColor" style="font-size:17px;" runat="server"></asp:Label>

                  </div>
                         <div class="col-sm-8" style="text-align:left;margin-left: -35px;">
                        
                          <asp:Label ID="Label25"  runat="server" Text=""  CssClass="HeaderColor" style="font-size:17px;"></asp:Label>

                  </div>
                         <div class="col-sm-1" style="margin-left: 25px;margin-top: -10px;">
                             <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="return Cancel1(myModalReOpenCFR,myModalImage);"  style="color:blue;font-size: 30px;text-decoration: none;" >
                                   &times;
                              </asp:LinkButton>

                               <%--<button type="button" class="btn"  onclick="return Cancel1(myModalRaise,myModalImage);">
                      <span   style="color:blue;font-size: 30px;"> &times;</span></button>--%>
                  </div>

                   </div>
        
     
        <div class="modal-body" >
          <iframe id="IframeReOpenCFR" src="" width="500" height="210" frameborder="0" allowtransparency="true"></iframe>  
      </div>
     
    </div>
    <!-- /.modal-content -->
  </div>
  <!-- /.modal-dialog -->
</div>

        <asp:HiddenField ID="hiddenField1" runat="server" />
        <script language="javascript" type="text/javascript">
                var path = "<%=Request.ApplicationPath.ToString()%>";
                var imgno = 1;
                function FuncReOpen(lblRemarkidValue, lblAddnlRemark) {
                    debugger;
                    //$find("MdlPopReOpenCFR").show();
                    document.getElementById('myModalReOpenCFR').style.display = 'block';
                    document.getElementById("myModalReOpenCFR").src = "../../../Application/ISys/Recruit/PopReOpenCFR.aspx?RemarkId=" + lblRemarkidValue + "&Remarks=" + lblAddnlRemark + "&mdlpopup=MdlPopReOpenCFR";

                }
                function CloseSub() {
                    window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
                    window.parent.document.getElementById("btnReFresh").click();
                }
                function doCancel() {
                    window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
                }
                function doCancels() {
                    window.close();
                }

                function Closewin() {

                    window.close();
                }
            </script>
    </center>
</asp:Content>

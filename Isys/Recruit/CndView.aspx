<%@ Page Title="Candidate view" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CndView.aspx.cs" Inherits="Application_ISys_Recruit_CndView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
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

    <script language="javascript" type="text/javascript">

        function Hidetab(status) {
            debugger;

            if (status == "10") {
                $('#ctl00_ContentPlaceHolder1_profiling').css({ display: "none" });
                $('#ctl00_ContentPlaceHolder1_Training').css({ display: "none" });
                $('#ctl00_ContentPlaceHolder1_Exam').css({ display: "none" });
                $('#ctl00_ContentPlaceHolder1_NOC').css({ display: "none" });
            }
            else if (status == "20") {

                $('#ctl00_ContentPlaceHolder1_Training').css({ display: "none" });
                $('#ctl00_ContentPlaceHolder1_Exam').css({ display: "none" });
                $('#ctl00_ContentPlaceHolder1_NOC').css({ display: "none" });
            }
            else if (status <= "170" && status >= "30") {
                $('#ctl00_ContentPlaceHolder1_NOC').css({ display: "none" });
            }




        }


        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        //   
        //    function ShowReqDtl(divId, btnId) {
        //        if (document.getElementById(divId).style.display == "block") {
        //            document.getElementById(divId).style.display = "none";
        //            
        //            document.getElementById(btnId).value = '+';
        //        }
        //        else {
        //            document.getElementById(divId).style.display = "block";
        //            
        //            document.getElementById(btnId).value = '-';
        //        }
        //    }


        debugger;
        //    function show() {
        //        var btncontrol = document.getElementById("ctl00_ContentPlaceHolder1_btnCancel");
        //        btncontrol.style.display = "block";
        //    }
        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-resize-small'
                }
                else {
                    objnewdiv.style.display = "block";
                    //objnewbtn.className = 'glyphicon glyphicon-resize-full'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }
        function doCancel() {

            parent.history.back();
            return false;

        }


        function funcShowPopup(strPopUpType) {
            debugger;

            if (strPopUpType == "statedemo") {
                debugger;
                if (document.getElementById('<%=ddlstate1.ClientID %>').value == "--Select--") {
                    alert("Please select State.");
                    document.getElementById('<%= ddlstate1.ClientID %>').focus();
                    return false;
                }
                else {
                    $find("mdlViewBID").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopAgtCnct.aspx?Code=" + document.getElementById('<%=ddlstate1.ClientID %>').value
         + "&field1=" + document.getElementById('<%=txtPermPostcode.ClientID %>').id + "&field2=" + document.getElementById('<%=txtPDistrict.ClientID %>').id
         + "&field3=" + document.getElementById('<%=txtPcity1.ClientID %>').id + "&field4=" + document.getElementById('<%=txtParea1.ClientID %>').id
         + "&mdlpopup=mdlViewBID";
                }
            }

            if (strPopUpType == "statedemo1") {
                debugger;
                if (document.getElementById('<%=ddlstatePA.ClientID %>').value == "--Select--") {
                    alert("Please select State.");
                    document.getElementById('<%= ddlstatePA.ClientID %>').focus();
                    return false;
                }
                else {
                    $find("mdlViewBID").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopAgtCnct.aspx?Code=" + document.getElementById('<%=ddlstatePA.ClientID %>').value
         + "&field1=" + document.getElementById('<%=txtPAPostcode.ClientID %>').id + "&field2=" + document.getElementById('<%=txtPADistrict.ClientID %>').id
         + "&field3=" + document.getElementById('<%=txtPAcity1.ClientID %>').id + "&field4=" + document.getElementById('<%=txtPAarea1.ClientID %>').id
         + "&mdlpopup=mdlViewBID";
                }
            }
        }




    </script>

    <style type="text/css">
        /*added by ajay 270420230 start*/
        .gridview th {
            padding: 10px;
            height: 40px;
            border-color: #53accd !important;
            /*text-align: center;*/
            font-family: VAG Rounded Std Light;
            font-size: 15px;
            white-space: nowrap;
            border-width: 1px;
            border-left: 0px;
            border-right: 0px;
        }
        /*added by ajay 270420230 end*/
        .clscenter{
            text-align:center !important;
        }
        .clsleft{
            text-align:left !important;
        }


        .nav-tabs > li.active > a,
        .nav-tabs > li.active > a:hover,
        .nav-tabs > li.active > a:focus {
            color: #ffffff;
            background-color: #034ea2;
        }

        .subheader {
            font-size: 16px !important;
        }

        .disablepage {
            display: none;
        }

        ul#menu {
            padding: 0;
            margin-right: 69%;
        }

            ul#menu li {
                display: inline;
            }



                ul#menu li a {
                    background-color: Silver;
                    color: black;
                    cursor: pointer;
                    padding: 10px 20px;
                    text-decoration: none;
                    border-radius: 4px 4px 0 0;
                }

                    ul#menu li a:active {
                        background: white;
                    }

                    ul#menu li a:hover {
                        background-color: red;
                    }
    </style>

    <asp:ScriptManager ID="SM1" runat="server">
    </asp:ScriptManager>
    <center>
        <table align="center" style="width: 90%;  border-collapse: collapse;">
            <tr align="center">
                <td>
                    <asp:Label ID="lblError2" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000" ></asp:Label>
                </td>
            </tr>
            <tr align="center" style="display:none;">
                <td align="left"  style="width: 100%">
                     <asp:ImageButton ID="lnkPage1" runat="server"  
                         CssClass="TextBox" BackColor="transparent" 
                         ImageUrl= "~/theme/iflow/tabs/Personal 2.png"   CausesValidation="False" 
                         TabIndex="1215"    onclick="lnkPage1_Click"/>
                     <asp:ImageButton ID="lnkPage2" runat="server" 
                         CssClass="TextBox" BackColor="Transparent"  
                         ImageUrl="~/theme/iflow/tabs/profiling2.png"  CausesValidation="False" 
                         TabIndex="1220"    onclick="lnkPage2_Click"/>
                  
                    <asp:ImageButton ID="LinkPage6" runat="server" ImageUrl="~/theme/iflow/tabs/Train 2.png" 
                         CssClass="TextBox" BackColor="Transparent"
                           CausesValidation="False" 
                         TabIndex="1240" onclick="LinkPage6_Click"  />
                     <asp:ImageButton ID="LinkPage7" runat="server"  
                         CssClass="TextBox" BackColor="Transparent"
                        ImageUrl="~/theme/iflow/tabs/Exam 2.png"   CausesValidation="False" 
                         TabIndex="1240" onclick="LinkPage7_Click"  />
                          <asp:ImageButton ID="LinkPage8" runat="server"  
                         CssClass="TextBox" BackColor="Transparent"
                        ImageUrl="~/theme/iflow/tabs/NOC2.png"   CausesValidation="False" 
                         TabIndex="1240"  onclick="LinkPage8_Click"  />
                         <%--OnClick="lnkPage2_Click"  OnClick="lnkPage3_Click" OnClick="LinkPage4_Click"  OnClick="LinkPage5_Click"  --%>

                </td>
            </tr>
        </table>
    </center>

    <center>
     <div id="divIRCC" runat="server" style="padding: 1%" role="tabpanel">
                           <asp:HiddenField ID="hdnStausValue" runat="server" />
                                    <ul class="nav nav-tabs" style="margin-bottom: 10px;margin-left: 2px;">
                                        <li  class="active"><a id="personal" runat="server" aria-controls="menu1"
                                            data-toggle="tab" href="#menu1"><b>Personal</b></a></li>
                                        <li><a id="profiling" visible="false" runat="server" aria-controls="menu2"
                                            data-toggle="tab" href="#menu2"><b>Profiling</b></a></li> 
                                        <li><a id="Training" runat="server" aria-controls="menu3"
                                            data-toggle="tab" href="#menu3"><b>Training</b></a></li>
                                        <li><a id="Exam" runat="server" aria-controls="menu4"
                                            data-toggle="tab" href="#menu4"><b>Exam</b></a></li>
                                        <li><a id="NOC" runat="server" aria-controls="menu5" visible="true"
                                            data-toggle="tab" href="#menu5"><b>NOC</b></a></li>
                                        <li><a id="Dispatch" runat="server" aria-controls="menu6" 
                                            data-toggle="tab" href="#menu6"><b>Dispatch Details</b></a></li>
                                      </ul>
    
    
 
 
      <div class="tab-content card">
       <div id="menu1" class="tab-pane fade in active" >
                                    <%--Personal Information Start--%>
                                     <div  style="margin-bottom:15px;" class="card PanelInsideTab">
                                          <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPersonal','btnPersonal');return false;">
                   
                                              <%--image on 31 july 2023--%>
                            <div class="row" runat="server" id="infodiv">
                                <%--<div class="col-sm-12" >--%>
                                    <div class="col-sm-6" style="text-align:right;">
                                    <img src="../../../image/Caution_th.jpeg" style="width:26px;height:20px;"/>

                                    </div>
                                     <div class="col-sm-6" style="text-align:left;margin-top:3px;margin-left:-12px">
                                    <asp:Label ID="lblcau" runat="server" Text="Conversion Case" CssClass="control-label" Style="color: black"></asp:Label>

                                    </div>
                                <%--</div>--%>
                            </div>
                                              <%--image on 31 july 2023--%>
                                              

                                              <div class="row">  
                     <div class="col-sm-10" style="text-align:left">   
                            <asp:Label ID="lblpfPersonal" runat="server"  CssClass="control-label" Font-Size="19px"></asp:Label>
                     </div>
                      <div class="col-sm-2">
                        <span id="btnPersonal" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                        <div id="divPersonal" runat="server" class="panel-body" style="display:block;" >
                                        <table class="tableIsys" style="width: 100%;">
                                            <tr id="tblrdb" runat="server" style="display:none;">
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblIsSPFlag" runat="server" Style="color: black"></asp:Label>
                                                </td>
                                                <td style="width:30%;" class="formcontent">
                                                    
                                                            <asp:RadioButtonList ID="rbtIsSP" runat="server" CssClass="radiobtn"  RepeatDirection="Horizontal" 
                                                               Visible="true">
                                                                <asp:ListItem Value="Y" >Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                               </asp:RadioButtonList>
                                                           
                                               </td>
                                               <td style="width:20%;" class="formcontent"></td>
                                                <td style="width:30%;" class="formcontent"></td>
                                                </tr>
                                             <tr id="tblIsSpecific" runat="server" style="display:none;">
                                                <td class="formcontent" style="width: 20%;">
                                                
                                                    <asp:Label ID="lblCACode" runat="server" Style="color: black"  ></asp:Label>
                                                   
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                     <asp:Label ID="lblCACodeDesc" runat="server" Style="color: black"  ></asp:Label>
                                                   
                                                </td>
                                                <td class="formcontent" style="width: 20%;">
                                                
                                                    <asp:Label ID="lblCAName" runat="server" Style="color: black"  ></asp:Label>
                                                    
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblCANameDesc" runat="server" Style="color: black"  ></asp:Label>
                                                </td>
                                                </tr>
                                        </table>
                                         <div >
                                               <div class="col-sm-10" >
                                       <div class="row rowspacing" >
                                               <div class="col-sm-4" style="text-align:left">
                                                    <asp:Label ID="lblpfcndid" runat="server" CssClass="control-label"   ></asp:Label>
                                                     <asp:TextBox ID="lblcndidDesc" runat="server" CssClass="form-control control-label"   Enabled="false"   ></asp:TextBox>
                                             </div>
                                               <div class="col-sm-4" style="text-align:left">
                                        
                                                    <asp:Label ID="lblcategory" runat="server" CssClass="control-label"   ></asp:Label>
                                                    <asp:UpdatePanel ID="UpdPanelCategory" runat="server">
                                                        <contenttemplate>
                                                         <asp:TextBox ID="lblcategoryDesc" runat="server" CssClass="form-control control-label " Enabled="false"   ></asp:TextBox>   
                                                        </contenttemplate> 
                                                    </asp:UpdatePanel> 
                                               </div>
                                           <div class="col-sm-4" style="text-align:left">
                                          
                                                     <asp:Label ID="lblpfappno" runat="server" CssClass="control-label"   ></asp:Label>
                                                      <asp:TextBox ID="lblpfappnoDesc" runat="server" CssClass="form-control control-label"   Enabled="false"   ></asp:TextBox>  
                                                    </div>
                                        </div>
                                               <div class="row rowspacing"  >
                                               <div class="col-sm-4" style="text-align:left">
                                                    <asp:Label ID="lblpfregdate" runat="server" CssClass="control-label"  ></asp:Label>
                                                  
                                                     <asp:TextBox ID="lblpfregdateDesc" runat="server" CssClass="form-control control-label "   Enabled="false"  ></asp:TextBox>
                                               </div>
                                                   <div class="col-sm-4" style="text-align:left">
                                              
                                                    <asp:Label ID="lblpfgivenName" runat="server"    ></asp:Label>
                                                   
                                                      
                                            
                                                    <asp:UpdatePanel ID="UpdPanelAgtType" runat="server">
                                                        <contenttemplate>
                                                        <asp:TextBox ID="lblpfgivenNameDesc" runat="server" CssClass="form-control control-label "   Enabled="false"   ></asp:TextBox>        
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                              </div>
                                                    <div class="col-sm-4" style="text-align:left">
                                                  
                                                    <asp:Label ID="lblpfSurName" runat="server" CssClass="control-label"   ></asp:Label>
                                                   
                                                    <asp:TextBox ID="lblpfSurNameDesc" runat="server" CssClass="form-control control-label "   Enabled="false"   ></asp:TextBox>
                                           </div>
                                           </div>
                                          
                                         <div class="row rowspacing" >
                                             <div class="col-sm-4" style="text-align:left">
                                                    <asp:Label ID="lblpffathername" runat="server" CssClass="control-label" style="color:Black; margin-bottom:5px;"></asp:Label>
                                                 
                                                    <asp:TextBox ID="lblpffathernameDesc" CssClass="form-control control-label "   Enabled="false"  runat="server"  ></asp:TextBox>
                                                </div>
                                           <div class="col-sm-4" style="text-align:left">
                                                   <asp:Label ID="lblpfGender" runat="server"  CssClass="control-label" ></asp:Label>
                                                    
                                                    <asp:TextBox ID="lblpfGenderDesc"  CssClass="form-control control-label "   Enabled="false" runat="server" ></asp:TextBox>
                                               </div>
                                             <div class="col-sm-4" style="text-align:left">
                                                   
                                                    <asp:Label ID="lblpfdob" runat="server" CssClass="control-label"  ></asp:Label>
                                                     <span>
                                                    <asp:TextBox ID="lblpfdobDesc" runat="server" CssClass="form-control control-label "   Enabled="false"  ></asp:TextBox>
                                           </div>
                                         </div>
                                        <div class="row rowspacing" >
                                                    <div class="col-sm-4" style="text-align:left">
                                          <asp:Label ID="lblCndUrn" runat="server" CssClass="control-label"  Font-Bold="False" ></asp:Label>
                                                <asp:Label ID="lblpfpob" Visible="false" CssClass="control-label" runat="server"  Font-Bold="False"  ></asp:Label>
                                            <asp:TextBox ID="lblCndUrnDesc" runat="server" CssClass="form-control control-label"   Enabled="false"  Font-Bold="False" ></asp:TextBox>
                                                    <asp:TextBox ID="lblpfpobDesc" Visible="false" CssClass="form-control control-label"   Enabled="false"  runat="server" Font-Bold="False"  ></asp:TextBox>
                                              </div>
                                                <div class="col-sm-4" style="text-align:left">
                                                
                                                    <asp:Label ID="lblpfmaritalstatus" runat="server" CssClass="control-label"  style="color:Black; margin-bottom:5px;"></asp:Label>
                                                  
                                                     <asp:TextBox ID="lblpfmaritalstatusDesc" CssClass="form-control control-label "   Enabled="false" runat="server"   ></asp:TextBox>
                                             </div>
                                          <div class="col-sm-4" style="text-align:left">
                                                    <asp:Label ID="lblpfNationality" runat="server" CssClass="control-label" style="color:Black; margin-bottom:5px;"></asp:Label>
                                                  
                                                   <asp:TextBox ID="lblpfNationalityDesc" CssClass="form-control control-label "   Enabled="false" runat="server"  ></asp:TextBox>
                                               </div>
                                           </div>
                                       <div class="row rowspacing" >
                                                 <div class="col-sm-4" style="text-align:left">
                                                    <asp:Label ID="lblpfpan" runat="server" Font-Bold="False" CssClass="control-label" style="color:Black; margin-bottom:5px;"></asp:Label>
                                                   
						                             <asp:TextBox ID="lblpfpanDesc" runat="server" CssClass="form-control control-label "   Enabled="false"  Font-Bold="False" > </asp:TextBox>
                                        </div>

                                         <div class="col-sm-4" style="text-align:left">
                                    <asp:Label ID="lblaadhr" runat="server" Text ="Relationship with agent"  CssClass="control-label"></asp:Label>
                                              
                                                             <asp:TextBox ID="txtaadhr"  Enabled ="false"  runat="server" CssClass="form-control control-label " MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"
                                                               style='width:98%;' ></asp:TextBox>&nbsp;
                                                                 
                                                        
                                                   
                                             </div>
                                           <div class="col-sm-4" style="text-align:left">
                                                
                                                    <asp:Label ID="lblCasteCat" runat="server"  CssClass="control-label" Text="Category" ></asp:Label>
                                                    
                                                    <asp:TextBox ID="lblCasteCatDesc" runat="server" CssClass="form-control control-label "   Enabled="false"  ></asp:TextBox>
                                           </div>
                                          </div>
                                            <div class="row" >
			                                 
                                                      <div class="col-sm-4" style="text-align:left">
                                            
                                                    <asp:Label ID="lblPrimProf" runat="server" CssClass="control-label"  Text="Current Occupation" ></asp:Label>
                                                    
                                                  <asp:TextBox ID="lblPrimProfDesc" CssClass="form-control control-label "   Enabled="false" runat="server"  ></asp:TextBox>
                                            </div>
                                                <div class="col-sm-4" style="text-align:left">
                                            
                                                    <asp:Label ID="Label10" runat="server" CssClass="control-label"  Text="Candidate Type" ></asp:Label>
                                                    
                                                  <asp:TextBox ID="txtcndtype" CssClass="form-control control-label "   Enabled="false" runat="server"  ></asp:TextBox>
                                            </div>
                                                <div class="col-sm-4" style="text-align:left">
                                            
                                                    <asp:Label ID="Label11" runat="server" CssClass="control-label"  Text="Anniversary Date" ></asp:Label>
                                                    
                                                  <asp:TextBox ID="TxtAnnivsrdte" CssClass="form-control control-label"   Enabled="false" runat="server"  ></asp:TextBox>
                                            </div>
			                             </div>

                                                     <%--  added by sanoj 21082023--%>
                                            <div class="row rowspacing" id="divWaiverType" runat="server" visible="false" >
			                             
                                             <div class="col-sm-4" style="text-align:left">
                                         
                                                  <asp:Label ID="lblWaiverType" runat="server" CssClass="control-label"  Text="Wavier Type" ></asp:Label>
                                           
                                                  <asp:TextBox ID="txtWaiverType" CssClass="form-control control-label"   Enabled="false" runat="server"  ></asp:TextBox>
                                            </div>
                                                <div class="col-sm-4" style="text-align:left">
                                            
                                                    
                                            </div>
                                                <div class="col-sm-4" style="text-align:left">
                                            
                                                    
                                            </div>
			                             </div>
                                                     <%--  added by sanoj 21082023--%>
                                      
                                </div>
                                               <div class="col-sm-2">
                                    <table border="0" cellpadding="0" cellspacing="0" class="tableIsys">
                                        <tr>
                                            <td>
                                            <asp:UpdatePanel ID="updgrdImage" runat="server">
                                            <ContentTemplate>
                                            <asp:Image ID="Img" runat="server" ImageUrl="~/theme/iflow/prof_pic_blank.jpg" Height="100px" />
                                         
                                             <asp:GridView ID="GridCndImage" runat="server" AllowSorting="True" CssClass="formtable" Style="border-bottom-color: black;"
                                                PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                                RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                                AllowPaging="True" Width="100%" Visible="false" >
                                                     <%--onrowdatabound="GridCndImage_RowDataBound"--%>
                                                <Columns>
                                                    
                                                    <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ID") %>'></asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:ImageField DataImageUrlField="ID" DataImageUrlFormatString="ImageCSharp.aspx?ImageID={0}"
                                                        HeaderText="Preview Image" ControlStyle-Height="100px" ControlStyle-Width="120px">                                                     </asp:ImageField>
                                                </Columns>
                                                 <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                                </PagerStyle>
                                                <HeaderStyle CssClass="test"></HeaderStyle>
                                                <AlternatingRowStyle CssClass="sublinkodd" BackColor="#78A8FA"></AlternatingRowStyle>
                                                </asp:GridView>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                     </div>
                                     
                                  </div>    
                                    </div>
                                     </div>
                                    <%--Personal Information End--%>
                             <%--       transfer details start--%>
                           
                                           <div id="tbltrnsDtls" runat="server" class="card PanelInsideTab" style='margin-top:15px;display:block;'>
                                   <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTrnsferDetails','btnTrnsferDetails');return false;">
                   <div class="row rowspacing">  
                     <div class="col-sm-10" style="text-align:left">   
                            <asp:Label ID="lblTransferDtl" runat="server" Text=" Transfer Details"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                          <asp:CheckBox  Visible="False"
                                                       ID="cbTrfrFlag" runat="server" AutoPostBack="true" CssClass="standardcheckbox" Enabled="False" 
                                                       TabIndex="19" />
                     </div>
                      <div class="col-sm-2">
                        <span id="btnTrnsferDetails" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                              
                                            <div id="divTrnsferDetails" runat="server" class="panel-body" style="display:none;" >
			                               <div class="row rowspacing" style="display:none" runat="server" id="tr2" >
			                                    <div class="col-sm-4" style="text-align:left;margin-left:13px;">
                                                
                                                    <asp:Label ID="lbloldLcnNo" runat="server" CssClass="control-label " Style="color: black" Text="License No"></asp:Label>
                                                     
                                                 
                                               </div><%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                                              <div class="col-sm-4">
                                               
                                                    <asp:Label ID="lbloldLcnNoDesc" runat="server" CssClass="control-label " Style="color: black" 
                                                        ></asp:Label>
                                                         
                                                    <span style="color: red"></span>
                                                    
                                           </div>
                                              <div class="col-sm-4" style="text-align:left;margin-left:13px;">
                                                
                                                    <asp:Label ID="lblOldLcnexpDate" runat="server" CssClass="control-label " Style="color: black"></asp:Label>
                                                   
                                                   
                                             </div>
                                               <div class="col-sm-3">
                                                   <asp:Label ID="lblOldLcnexpDateDesc" CssClass="control-label" runat="server" Style="color: black"/>
                                                  </div>
			                            </div>
			                               <div class="row rowspacing" style="display:none" runat="server" id="tr3">
			                                   <div class="col-sm-3" style="text-align:left;margin-left:13px;">
                                                
                                                    <asp:Label ID="lblPrevInsurerName" runat="server" CssClass="control-label" Style="color: black" Text="Insurer Name" ></asp:Label>
                                                   
                                            </div>
                                               <div class="col-sm-3">
                                                    <asp:Label ID="lblPrevInsurerNameDesc" CssClass="control-label" runat="server" Style="color: black"  />
                                                    </div> 
                                               <div class="col-sm-2" style="text-align:left;margin-left:13px;">
                                               
                                                    <asp:Label ID="lblNOCFlag" runat="server" CssClass="control-label" Style="color: black" Text="NOC Received" ></asp:Label>
                                                  
                                            </div>
                                              <div class="col-sm-3">
                                                <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal" 
                                                               CssClass="radiobtn" TabIndex="24" 
                                                               AutoPostBack="true" Enabled="False">
                                                <asp:ListItem Value="0" Text="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="1" Text="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                                        
                                                </div>
                                                 
			                            </div>
                                         <div class="row rowspacing" style="display:none" runat="server" id="trAckrow">
                                          
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-3">
                                                  <asp:Label ID="lblAckrcv" CssClass="control-label" runat="server" />
                                                  </div>
                                                <div class="col-sm-3">
                                                    <asp:Label ID="lblAckrcvDesc" CssClass="control-label" runat="server" ></asp:Label>
                                                        
                                             </div>
                                       </div>
                                            <%--added by amruta for transfer start on 11.6.15--%>
                                               <div class="row rowspacing" style="display:none" runat="server" id="trNoteTr">
                                      <div class="col-sm-3" style="text-align:left;margin-left:13px;">
                                                
                                                    <asp:Label ID="lblIC" runat="server" Style="" CssClass="control-label" Text="IC Date"></asp:Label>
                                              </div>
                                              <div class="col-sm-3">
                                                  <asp:Label ID="lblICdate" CssClass="control-label" runat="server" />
                                               </div>
                                       </div>
                                        <%--added by amruta for transfer end on 11.6.15--%>
                                           <%--</table>--%>
                                             <div  class="panel-body" style="overflow-x: scroll;padding:0px">
                                                                              <asp:GridView ID="gvTrnsfr" 
                                               AutoGenerateColumns="false" AutoGenerateDeleteButton="false" runat="server"
                                       CssClass="footable">
                                           <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                        <asp:TemplateField HeaderText="I-C Date">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                             </ItemTemplate>
                                            <ItemStyle CssClass="clscenter"  ></ItemStyle>
                                             </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Category">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                             </ItemTemplate>
                                              <ItemStyle CssClass="clsleft" />
                                              <HeaderStyle CssClass="clsleft" />
                                             </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Name of insurer">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label>
                                             </ItemTemplate>
                                               <ItemStyle CssClass="clsleft" />
                                               <HeaderStyle CssClass="clsleft" />
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Agency code number">
                                             <ItemTemplate>
                                            <asp:Label ID="lblAgencyCode" runat="server"  Text='<%# Bind("Agency_code_Number") %>'></asp:Label>
                                             </ItemTemplate>
                                                 <ItemStyle CssClass="clscenter" />
                                                 <HeaderStyle CssClass="clscenter" />
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date of appointment as agent">
                                            <ItemTemplate>
                                            <asp:Label ID="lblDateAppointment" runat="server"  Text='<%# Bind("Date_of_appointment_as_agent") %>'></asp:Label>
                                             </ItemTemplate>
                                                 <ItemStyle CssClass="clscenter" />
                                                 <HeaderStyle CssClass="clscenter" />
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date of cessation of agency">
                                             <ItemTemplate>
                                            <asp:Label ID="lblDateCessation" runat="server"  Text='<%# Bind("Date_of_cessation_of_agency") %>'></asp:Label>
                                             </ItemTemplate>
  <ItemStyle CssClass="clscenter" />
                                                 <HeaderStyle CssClass="clscenter" />
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Reason for cessation of agency">
                                              <ItemTemplate>
                                            <asp:Label ID="lblReasonCessation" runat="server"  Text='<%# Bind("Reason_for_cessation_of_agency") %>'></asp:Label>
                                             </ItemTemplate>
 <ItemStyle CssClass="clsleft" />
                                               <HeaderStyle CssClass="clsleft" />
                                            </asp:TemplateField>
                                             <%-- <asp:CommandField ShowDeleteButton="true"  DeleteText="Delete" />--%>
                                            <%--<asp:TemplateField>               
                                             <ItemTemplate>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<% #Eval("Agency_code_Number")%>'  CommandName="delete" />
                                             </ItemTemplate>
                
                                            </asp:TemplateField>--%>



                                           </Columns>
                                           
                                           </asp:GridView>
                                     </div>
                                     
                                           </div>
                                          
                                     </div>      
                                           <%--added by pranjali on 13-03-2014 for transfr deatils end--%>
                                             <%--       transfer details start--%>
                            
                                           <div id="tbltagDtls" runat="server" class="card PanelInsideTab" style="margin:0px;" visible="false" >
                                   <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTagDetails','btntagDtls');return false;">
                   <div class="row rowspacing">  
                     <div class="col-sm-10" style="text-align:left">   
                            <asp:Label ID="lblTag" runat="server" Text=" Tagged Details"   CssClass="control-label" Font-Size="19px"></asp:Label>
                          <asp:CheckBox  Visible="False"
                                                       ID="cbTagLcn" runat="server" AutoPostBack="true" CssClass="standardcheckbox" Enabled="False" 
                                                       TabIndex="19" />
                     </div>
                      <div class="col-sm-2">
                        <span id="btntagDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                              
                                            <div id="divTagDetails" runat="server" class="panel-body" style="display:none;" >
			                             
                                             <div  class="panel-body" style="overflow-x: scroll;padding:0px">
                                                                            <asp:GridView ID="grdTag" CssClass="footable"
                                                AutoGenerateColumns="false" AutoGenerateDeleteButton="false" runat="server">
                                               <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                                               
                                                <Columns>
                                                   
                                                    <asp:TemplateField HeaderText="Category">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name of Insurer">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Agency code number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAgencyCode" runat="server" Text='<%# Bind("Agency_code_Number") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="URN No.">
                                                     <ItemTemplate>
                                                            <asp:Label ID="lblURNNo" runat="server" Text='<%# Bind("URNNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                    </asp:TemplateField>
                                                 
                                                    <asp:TemplateField HeaderText="Date of appointment as agent">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDateAppointment" runat="server" Text='<%# Bind("Date_of_appointment_as_agent") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                  
                                                </Columns>
                                            </asp:GridView>
                                     </div>
                                     
                                           </div>
                                          
                                     </div>      
                                           <%--added by pranjali on 13-03-2014 for transfr deatils end--%>
                                           <%--added by pranjali on 13-03-2014 for composite deatils start--%>
                                             
                            <div id="tblcomposite"  runat="server" class="card PanelInsideTab">

                                      <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCompositeDetails','btnCompositeDetails');return false;">
                   <div class="row rowspacing">  
                     <div class="col-sm-10" style="text-align:left">  
                            <asp:Label ID="lblCompositeDtl" runat="server" Text="Composite Details"   CssClass="control-label" Font-Size="19px"></asp:Label>
                            <asp:Label ID="lblCompLcn" runat="server" Style="color: black;margin-left: 28px;" Text="Composite Case" ></asp:Label>
                            <asp:CheckBox 
                                                       ID="cbTccCompLcn" runat="server" AutoPostBack="true" CssClass="standardcheckbox" Enabled="False" 
                                                       TabIndex="20" />
                     </div>
                      <div class="col-sm-2">
                        <span id="btnCompositeDetails" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>

                                
                                     <div id="divCompositeDetails" runat="server" class="panel-body" style="display:none;" >
                               <div id="div1" runat="server" class="panel-body" style="display:none;" >
                                           <div class="row rowspacing" id="tr5" style="margin-left: -114px"  runat="server"> 
			                              <div class="col-sm-4">
                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lblCompLicNo" runat="server" Style="color: black" CssClass="control-label " Text="Life License No"></asp:Label>
                                                    
                                                    <asp:Label ID="lblCompLicNoDesc" runat="server" CssClass="control-label" Style="color: black" ></asp:Label>
                                           </div>
                                                  <div class="col-sm-3">
                                                 <%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lblComplicnseExpDt" runat="server" CssClass="control-label " Style="color: black"></asp:Label>
                                                     
                                                   <asp:Label ID="lblComplicnseExpDtDesc" runat="server" CssClass="control-label" Style="color: black"></asp:Label>
                                              </div>
                                                 <div class="col-sm-4">
                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lblCompInsurerName" runat="server" CssClass="control-label " Style="color: black" Text="Insurer Name" ></asp:Label>
                                                     
                                                   <asp:Label ID="lblCompInsurerNameDesc" runat="server" CssClass="control-label" Style="color: black"></asp:Label>
                                                   </div>  
			                           </div>

			                                 <div class="row rowspacing" id="tr6" style="margin-left: -114px;display:none"  runat="server"> 
			                                   

                                </div>
                                  </div>       
                                             <%--added by Nikhil on 09062015 start--%>
                                            <%--grid for composite start--%>
                     <div  class="panel-body" style="overflow-x: scroll;padding:0px">
                                       <asp:GridView ID="gvComposite"  
                                               AutoGenerateColumns="false" AutoGenerateDeleteButton="false" runat="server"
                                   CssClass="footable"    >

                                          <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />

                                        <Columns>
                                         <asp:TemplateField HeaderText="Category">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                             </ItemTemplate>
                                             </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Name_of_Insurer">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label>
                                             </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Agency_code_Number">
                                             <ItemTemplate>
                                            <asp:Label ID="lblAgencyCode" runat="server"  Text='<%# Bind("Agency_code_Number") %>'></asp:Label>
                                             </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date_of_appointment_as_agent">
                                            <ItemTemplate>
                                            <asp:Label ID="lblDateAppointment" runat="server"  Text='<%# Bind("Date_of_appointment_as_agent") %>'></asp:Label>
                                             </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date_of_cessation_of_agency">
                                             <ItemTemplate>
                                            <asp:Label ID="lblDateCessation" runat="server"  Text='<%# Bind("Date_of_cessation_of_agency") %>'></asp:Label>
                                             </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Reason_for_cessation_of_agency">
                                              <ItemTemplate>
                                            <asp:Label ID="lblReasonCessation" runat="server"  Text='<%# Bind("Reason_for_cessation_of_agency") %>'></asp:Label>
                                             </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="CndNo" Visible="false">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblCndNo" runat="server" Text='<%# Bind("CndNo") %>'></asp:Label>
                                             </ItemTemplate>
                                             </asp:TemplateField>


                                           </Columns>
                                           
                                           </asp:GridView>
                                     
                                        <%--added by Nikhil on 09062015 End--%>
                                         <%-- added by shreela on 7-Apr-14 start--%>
                                           
                                               <asp:CheckBox ID="chkCompAgnt" Visible="false" runat="server" CssClass="standardcheckbox"  Enabled="true" />
                                            
                                           <%-- added by shreela on 7-Apr-14 end--%>
                                   
                                       </div>
                                      </div>
                                         
                                       </div>
                                     <%--  <br />--%>

                                     <%--  added by usha--%>
                                     <div id="tblFeesWavier" runat="server"  class="card PanelInsideTab" style="margin-left:0px;margin-right:0px;display:none;">
          
               <div  class="panel-heading"   >       
              <%-- onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','ctl00_ContentPlaceHolder1_btnpersnl');return false;"   --%> 
                         <asp:UpdatePanel ID="UpdFeesWavier" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                          <div class="row rowspacing">
                    <div class="col-sm-12" style="text-align:left">
                 
                     <asp:Label ID="lblFeesTitle" runat="server" Text="Fees Wavier Details" CssClass="control-label" Font-Size="19px"></asp:Label>
                       <asp:CheckBox ID="ChkFeesWavier" Enabled ="false" runat="server" CssClass="standardCheckBox" AutoPostBack="true"  />
                    </div>
                    <%--<div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>--%>
                </div>
          
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            </div>
                                   <%--  ended by usha--%>
                              
                                        <%--added by pranjali on 13-03-2014 for composite deatils end--%>    
                                    <%--Nominee Details start--%>
                                    <div class="card PanelInsideTab" id="tblNomineeDetails" runat="server" >
                                     <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNomineeDetails','btnNomineeDetails');return false;">
                   <div class="row rowspacing">  
                     <div class="col-sm-10" style="text-align:left">  
                            <asp:Label ID="Label3" runat="server" Text="Nominee Details"   CssClass="control-label" Font-Size="19px"></asp:Label>
                           
                     </div>
                      <div class="col-sm-2">
                        <span id="btnNomineeDetails" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                    <div id="divNomineeDetails" runat="server" class="panel-body" style="display:block;">
                                       <div class="row rowspacing" style="text-align:left">
                                  <div class="col-sm-4" style="text-align:left">
                                                      <asp:Label ID="Label5" Text="Nominee Name" CssClass="control-label"  runat="server"></asp:Label>
                                                       <asp:TextBox ID="lblNomineeDesc" CssClass="form-control control-label"   Enabled="false"  runat="server"></asp:TextBox>
                                             </div>
                                              <div class="col-sm-4" style="text-align:left">
                                                   <asp:Label ID="Label7" Text="Relationship with agent" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>
                                                    <asp:TextBox ID="lblReltoAdvDesc"  CssClass="form-control control-label"   Enabled="false" runat="server"></asp:TextBox>
                                           </div>
                                             <div class="col-sm-4" style="text-align:left">
                                                    <asp:Label ID="Label6" CssClass="control-label"  Text="Age" runat="server"></asp:Label>
                                           
                                                    <asp:TextBox ID="lblAgeDesc" CssClass="form-control control-label"   Enabled="false"   runat="server"></asp:TextBox>
                                               </div>
                                        </div>
                                               <div class="row rowspacing" style="text-align:left;">
                                    <div class="col-sm-4">
                                        <asp:Label ID="lblNomneeEmail" CssClass="control-label labelSize" Text="Nominee Email" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtNomneeEmail" runat="server" CssClass="form-control control-label" onChange="javascript:this.value=this.value.toUpperCase();" Enabled="false"
                                            MaxLength="100" TabIndex="79"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:Label ID="lblNominMob" Text="Nominee Mobile No" CssClass="control-label labelSize" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtNominMob" runat="server" CssClass="form-control control-label" Enabled="false"
                                            MaxLength="10" TabIndex="80"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:Label ID="lblNomnPan" Text="Nominee Pan No" CssClass="control-label labelSize" runat="server"></asp:Label>
                                        <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtNomnPan" runat="server" CssClass="form-control control-label" MaxLength="10"  Enabled="false"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="81"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                              
                                    </div>
                                  
                                    </div>
                                    <%--Nominee Details end--%>
                                      
       

                                    <%--Recruit Information Start--%>
                                     <div class="card PanelInsideTab">
                                       <div id="tblRecruitDetails" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divRecruitInformation','btnRecruitInformation');return false;">
                   <div class="row">  
                     <div class="col-sm-10" style="text-align:left">   
                            <asp:Label ID="lblpfrecinfotitle" runat="server"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                           
                     </div>
                      <div class="col-sm-2">
                        <span id="btnRecruitInformation" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                    <div id="divRecruitInformation" runat="server" class="panel-body" style="display:block;">
                                      <div class="row" style="text-align:left">
                                                 <div class="col-sm-4" >
                                                         <asp:Label ID="lblSAPCode" runat="server" CssClass="control-label" style="color:Black;" Text="Employee Code"></asp:Label>
                                                  
                                                         <asp:TextBox ID="lblSAPCodeDesc" CssClass="form-control control-label"   Enabled="false" runat="server" style="color:Black;"></asp:TextBox>
                                                    </div>
                                          <div class="col-sm-4">
                                              <asp:Label ID="Label12" runat="server" CssClass="control-label" style="color:Black;" Text="Market Type"></asp:Label>
                                                  
                                                         <asp:TextBox ID="txtmarktype" CssClass="form-control control-label"   Enabled="false" runat="server" style="color:Black;"></asp:TextBox>
                                          </div>
                                         <%-- //pan validation start 07_08_2023 start--%>
                                          <div class="col-sm-4">
                                              <asp:Label ID="lbladdrptmgrcode" runat="server" CssClass="control-label" style="color:Black;" Text="Additional Reporting Manager"></asp:Label>
                                                  
                                                         <asp:TextBox ID="txtaddrptmgrcode" CssClass="form-control control-label"   Enabled="false" runat="server" style="color:Black;"></asp:TextBox>
                                          </div>
<%--//pan validation start 07_08_2023 end--%>
                                             </div>
                                                 <div class="row rowspacing" >
                                                    <div class="col-sm-4" style="text-align:left">
                                                   
                                                             <asp:Label ID="lblpfsalchannel" CssClass="control-label" runat="server" Font-Bold="False" style="color:Black;"></asp:Label>
                                                                
                                                           <asp:TextBox ID="lblpfsalchannelDesc" CssClass="form-control control-label "   Enabled="false"  runat="server" Font-Bold="False" ></asp:TextBox>
                                                   </div>
                                                    <div class="col-sm-4" style="text-align:left">
                                                    
                                                        <asp:Label ID="lblpfchasubclass" CssClass="control-label" runat="server" style="color:Black;"></asp:Label>
                                                        
                                                         <asp:TextBox ID="lblpfchasubclassDesc" CssClass="form-control control-label "   Enabled="false"  runat="server" ></asp:TextBox>
                                                </div>
                                                     <div class="col-sm-4" style="text-align:left">
                                                   
                                                         <asp:Label ID="lblpfagetype" runat="server" CssClass="control-label"  Font-Bold="False" style="color:Black;"></asp:Label>
                                                          
                                                         <asp:TextBox ID="lblpfagetypeDesc" runat="server"  CssClass="form-control control-label "   Enabled="false"  Font-Bold="False"></asp:TextBox>
                                                        </div>
                                                  </div>
                                               
                                                      <div class="row rowspacing" >
                                                          <div class="col-sm-4" style="text-align:left">
                                                            <asp:Label ID="lblpfsmname" runat="server" CssClass="control-label" style="color:Black;"></asp:Label>
                                                            
                                                         <asp:TextBox ID="lblpfsmnameDesc" CssClass="form-control control-label "   Enabled="false"  runat="server"></asp:TextBox>
                                                   </div>
                                                  <div class="col-sm-4" style="text-align:left">
                                                  
                                                        <asp:Label ID="lblpfimmleader" runat="server" CssClass="control-label" style="color:Black;"></asp:Label>
                                                           
                                                       <asp:TextBox ID="lblpfimmleaderDesc" CssClass="form-control control-label "   Enabled="false" runat="server" ></asp:TextBox>
                                                 </div>
                                                      <div class="col-sm-4" style="text-align:left">
                                                          <asp:Label ID="lblCandAgntType" CssClass="control-label"  runat="server"></asp:Label>
                                                           <asp:TextBox ID="lblCandAgntTypeDesc" CssClass="form-control control-label "   Enabled="false"  runat="server"></asp:TextBox>
                                                   </div>
                                               </div>

                                            </div>
                                    </div>
                                  
                                      <div class="card PanelInsideTab">
                                                <div id="tblReportinDTls" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divReporting','btnReporting');return false;">
                   <div class="row rowspacing">  
                     <div class="col-sm-10" style="text-align:left">   
                            <asp:Label ID="lblRptInfo" runat="server" Text="Reporting Details" CssClass="control-label" Font-Size="19px" ></asp:Label>
                           
                     </div>
                      <div class="col-sm-2">
                        <span id="btnReporting" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                    <div id="divReporting" runat="server" class="panel-body" style="display:block;">
                                              <div class="row rowspacing" style="text-align:left">
                                                      <div class="col-sm-4" >
                                                      
                                                          <asp:Label ID="lblpfberptcode" runat="server" CssClass="control-label" style="color:Black;" ></asp:Label>
                                                        
                                                           <asp:TextBox ID="lblpfberptcodeDesc" CssClass="form-control control-label "   Enabled="false"  runat="server"></asp:TextBox>
                                                     </div>

                                                  <div class="col-sm-4">
                                              <asp:Label ID="Label16" runat="server" CssClass="control-label" style="color:Black;" Text="Market Type"></asp:Label>
                                                  
                                                         <asp:TextBox ID="txtrpmarkt" CssClass="form-control control-label"   Enabled="false" runat="server" style="color:Black;"></asp:TextBox>
                                          </div>
                                             </div>
                                               <div class="row rowspacing" >
                                              <div class="col-sm-4" style="text-align:left">
                                                     
                                                             <asp:Label ID="lblpfsalchannelrpt" runat="server" CssClass="control-label" Font-Bold="False" style="color:Black;" ></asp:Label>
                                                           <asp:TextBox ID="lblpfsalchannelrptDesc" CssClass="form-control control-label "   Enabled="false" runat="server"  Font-Bold="False" ></asp:TextBox>
                                                     </div>
                                                    <div class="col-sm-4" style="text-align:left">
                                                  
                                                        <asp:Label ID="lblpfchasubclassrpt" runat="server" CssClass="control-label" style="color:Black;" ></asp:Label>
                                                         <asp:TextBox ID="lblpfchasubclassrptDesc" CssClass="form-control control-label "   Enabled="false"  runat="server" ></asp:TextBox>
                                                </div>
                                                   <div class="col-sm-4" style="text-align:left">
                                                  
                                                         <asp:Label ID="lblpfagetyperpt" runat="server" CssClass="control-label"  Font-Bold="False" style="color:Black;" ></asp:Label>
                                                         <asp:TextBox ID="lblpfagetyperptDesc" CssClass="form-control control-label "   Enabled="false" runat="server"   Font-Bold="False"></asp:TextBox>
                                                       </div>
                                                 </div>
                                                  
                                                  <div class="row rowspacing" >
                                                      <div class="col-sm-4" style="text-align:left">
                                                   
                                                        <asp:Label ID="lblpfimmleaderrpt" runat="server" CssClass="control-label" style="color:Black;" ></asp:Label>
                                                       <asp:TextBox ID="lblpfimmleaderrptDesc" CssClass="form-control control-label"   Enabled="false"  runat="server"></asp:TextBox>
                                                    </div>
                                                 <div class="col-sm-4" style="text-align:left">
                                              
                                                            <asp:Label ID="lblpfsmnamerpt" runat="server" CssClass="control-label" style="color:Black;" ></asp:Label>
                                                         <asp:TextBox ID="lblpfsmnamerptDesc" CssClass="form-control control-label"   Enabled="false"  runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="col-sm-4" style="text-align:left">
                                                          <asp:Label ID="lblCandAgntTyperpt" CssClass="control-label" runat="server"  Text="Agent Type"></asp:Label>
                                                     
                                                           <asp:TextBox ID="lblCandAgntTyperptDesc" CssClass="form-control control-label"   Enabled="false"  runat="server"></asp:TextBox>
                                                  </div>
                                                  </div>
                                                
                                            </div>
                                              
                                            </div>
                                            
                                   <%-- <table id="tblLicDtls" class="formtable" visible="false" style="width: 100%;" runat="server">
                                                 <tr>
                                                      <td  colspan="4" class="test">
                                                           <input runat="server" type="button" class="standardlink" value="-" id="btnLicenseDtls" style="width: 20px;"
                                                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divLicenseDtls', 'ctl00_ContentPlaceHolder1_btnLicenseDtls');" />
                                                           <asp:Label ID="lbllicdtls" Text="License Details" runat="server"></asp:Label>
                                                      </td>
                                                 </tr>
                                            </table>--%>
                                   <%-- <div id="divLicenseDtls" runat="server" style="display: none;">
                                               <table class="tableIsys" style="width: 100%;">
                                                 <tr>
                                                      <td nowrap="nowrap" align="left" class="formcontent" style="width: 20%;">
                                                      
                                                          <asp:Label ID="lblLicNo" runat="server" style="color:Black" Text="License No"></asp:Label> </td>
                                                      <td nowrap="nowrap" align="left" class="formcontent" style="width: 30%;">
                                                           <asp:Label ID="lblLicNoValue" runat="server"></asp:Label>
                                                       </td>
                                                      <td class="formcontent"  nowrap="nowrap" align="left" style="width: 20%;">
                                                          <asp:Label ID="lblLicExpDt" runat="server" style="color:Black" Text="License Exp. Date"></asp:Label>
                                                     </td>
                                                     <td class="formcontent"  nowrap="nowrap" style="width: 30%;">
                                                       <asp:Label ID="lblLicExpDtValue" runat="server" style="color:Black"></asp:Label>
                                                     </td>
                                                 </tr>
                                                 </table>
                                                 </div>--%>
                                   <div class="card PanelInsideTab">
                                              <div id="tblLicDtls" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divLicenseDtls','btnLicense');return false;">
                                               <div class="row rowspacing">  
                                                  <div class="col-sm-10" style="text-align:left">   
                                                      <asp:Label ID="lbllicdtls" runat="server" Text="License Details" CssClass="control-label" Font-Size="19px" ></asp:Label>
                           
                                                      </div>
                                                  <div class="col-sm-2">
                                                      <span id="btnLicense" class="glyphicon glyphicon-chevron-down" style="float: right;
                                                          padding: 1px 10px ! important; font-size: 18px;"></span>
                                                                  </div>
                                                                 </div>
                                     </div>
                                               <div id="divLicenseDtls" runat="server" class="panel-body" style="display:block;">
                                              <div class="row rowspacing" style="text-align:left">
                                                      <div class="col-sm-4" >
                                                          <asp:Label ID="lblLicNo" runat="server" CssClass="control-label" Text="License No" style="color:Black;" ></asp:Label>
                                                           <asp:TextBox ID="lblLicNoValue" CssClass="form-control control-label "   Enabled="false"  runat="server"></asp:TextBox>
                                                     </div>

                                                  <div class="col-sm-4">
                                                 <asp:Label ID="lblLicExpDt" runat="server" CssClass="control-label" style="color:Black;" Text="License Exp. Date"></asp:Label>
                                                <asp:TextBox ID="lblLicExpDtValue" CssClass="form-control control-label"   Enabled="false" runat="server" style="color:Black;"></asp:TextBox>
                                              </div>
                                             </div>

                                        </div>
                                    </div>

                                    <%--Recruit Information End--%>
                                    <%--Present Address Start--%>
                                     <div  id="tblPresentadd" runat="server" class="card PanelInsideTab">
                                        <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPresentAddress','btnPresentAddress');return false;">
                   <div class="row">  
                     <div class="col-sm-10" style="text-align:left">  
                            <asp:Label ID="lblpfpresentadd" runat="server" CssClass="control-label" Font-Size="19px" ></asp:Label>
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                 <contenttemplate>
                                                     <asp:CheckBox ID="chkEdit" Text="Address Edit" runat="server" Visible="false" CssClass="standardcheckbox"  
                                                    TabIndex = "76" oncheckedchanged="chkEdit_CheckedChanged" AutoPostBack="true" />
                                                   </contenttemplate>
                                                    </asp:UpdatePanel>
                     </div>
                      <div class="col-sm-2">
                        <span id="btnPresentAddress" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                                   <asp:UpdatePanel ID="UpdPanelShow" runat="server">
                                                 <contenttemplate>
                                                 <div id="divPresentAddress" runat="server" class="panel-body" style="display:block;">
                                        <div class="row" >
                                           <div class="col-sm-4" style="text-align:left">
                                           
                                                <asp:Label ID="lblpfaddresstype" CssClass="control-label" runat="server" style="color:Black;"></asp:Label>
                                               
                                                
                                                <asp:TextBox ID="lblpfaddresstypeDesc" CssClass="form-control control-label "   Enabled="false"  runat="server" ></asp:TextBox>
                                         </div>
                                  <div class="col-sm-4" style="text-align:left">
                                          
                                                 <asp:Label ID="lblpfStateP" runat="server" CssClass="control-label" style="color:Black;"></asp:Label>
                                                   
                                                    <asp:TextBox ID="c" CssClass="form-control control-label "   Enabled="false"  runat="server" ></asp:TextBox>
                                                </div>
                                            <div class="col-sm-4" style="text-align:left">
                                           
                                                <asp:Label ID="lblpfAddrP1" Text="Address Line 1" CssClass="control-label" runat="server" style="color:Black;"></asp:Label>
                                                 
                                                <asp:TextBox ID="lblpfAddrP1Desc" CssClass="form-control control-label "   Enabled="false"  runat="server" ></asp:TextBox>
                                            </div>
                                    </div>
                                     
                                        <div class="row rowspacing" >
                                              
                                           <div class="col-sm-4" style="text-align:left">
                                     
                                                <asp:Label ID="Label1"  runat="server"  Text="District" CssClass="control-label" style="color:Black;"></asp:Label>
                                                       
                                                <asp:TextBox ID="lbldistDesc" CssClass="form-control control-label "   Enabled="false"  runat="server"  ></asp:TextBox>
                                                </div>
                                             <div class="col-sm-4" style="text-align:left">
                                                <asp:Label ID="lblpfAddrP2" Text="Address Line 2"  CssClass="control-label" runat="server" ></asp:Label>
                                                
                                                
                                                <asp:TextBox ID="lblpfAddrP2Desc" CssClass="form-control control-label "  Enabled="false"  runat="server" ></asp:TextBox>
                                         </div>
                                        <div class="col-sm-4" style="text-align:left">
                                            
                                            <asp:Label ID="lblcity" runat="server" Text="City" CssClass="control-label" style="color:Black;"></asp:Label>
                                             
                                                <asp:TextBox ID="lblCityDesc" CssClass="form-control control-label "   Enabled="false"  runat="server" ></asp:TextBox>
                                            </div>
                                            </div>
                                              <div class="row rowspacing" >
                                         <div class="col-sm-4" style="text-align:left;display:none">
                                                <asp:Label ID="lblpfAddrP3" Text="Address Line 3" CssClass="control-label"  runat="server" ></asp:Label>
                                                
                                                <asp:TextBox ID="lblpfAddrP3Desc" CssClass="form-control control-label "  Enabled="false"  runat="server" ></asp:TextBox>
                                           </div>
                                          <div class="col-sm-4" style="text-align:left">
                                       
                                            <asp:Label ID="lblarea" runat="server" Text="Area" CssClass="control-label" style="color:Black;"></asp:Label>
                                                
                                                <asp:TextBox ID="lblareaDesc" CssClass="form-control control-label "  Enabled="false"  runat="server"></asp:TextBox>
                                              </div>
                                                  <div class="col-sm-4" style="text-align:left">
                                                <asp:Label ID="lblVillage" runat="server" CssClass="control-label"  Text="Village" ></asp:Label>
                                                <asp:TextBox ID="lblVillageDesc" CssClass="form-control control-label"  Enabled="false"  runat="server"></asp:TextBox>
                                           </div>
                                                   <div class="col-sm-4" style="text-align:left">
                                           
                                                <asp:Label ID="lblpfPinP" runat="server" CssClass="control-label" style="color:Black;"></asp:Label>
                                                  
                                                <asp:TextBox ID="lblpfPinPDesc" runat="server"  CssClass="form-control control-label "  Enabled="false" ></asp:TextBox>
                                           </div>
                                          
                                      </div>
                                       
                                            <div class="row rowspacing" >
                                         
                                                <div class="col-sm-4" style="text-align:left">
                                              
                                                <asp:Label ID="lblpfCountryP" runat="server" CssClass="control-label" style="color:Black;"></asp:Label>
                                                <asp:TextBox ID="lblpfCountryPDesc" CssClass="form-control control-label "  Enabled="false"  runat="server" ></asp:TextBox>
                                          </div>
                                </div>
                                   </div>
                                   </contenttemplate>
                                   <Triggers><asp:AsyncPostBackTrigger ControlID="chkEdit" EventName="CheckedChanged" /></Triggers>
                                   </asp:UpdatePanel>
                                   
                                   </div>
                                     
                                    <%--Present Address End--%>
                                    <asp:UpdatePanel ID="UpdPanelAddShow" runat="server">
                                                 <contenttemplate>
                                    <div id="divPermonantAddressEdit" runat="server" visible="false" >
                                      <table class="tableIsys" style="width: 100%;">
                                        <tr id="treditPA" runat="server">
                                            <td class="formcontent" > <%--style="width: 20%; text-align:left;"--%>
                                                &nbsp;<asp:Label ID="lbladdtype" Text="Address Type" runat="server"></asp:Label>&nbsp;
                                                
                                            </td>
                                            
                                            <td class="formcontent">
                                            <asp:Label ID="lbladdtypeDesc"  runat="server"></asp:Label>
                                            </td>
                                            <%--<td class="formcontent" nowrap="nowrap" style="width: 30%;"> </td>--%>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lblstatecodeedit" runat="server" ></asp:Label><span style="color: #ff0000">
                                                *</span>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                            <asp:DropDownList id="ddlstate1" runat="server" CssClass="standardmenu"  BackColor="#FFFFB2" 
                                                       Width="187px" TabIndex="84"></asp:DropDownList> 
                                            <asp:Button ID="btnstate1search" runat="server" CssClass="standardbutton" CausesValidation="False" 
                                                        Text="Search" TabIndex="85" />
                                                        </td>
                                            
                                        </tr>
                                        <tr id="treditPA1" runat="server">
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lblPAddline1" Text="Address Line 1" runat="server" ></asp:Label><span style="color: #ff0000">
                                                *</span>
                                            </td>
                                            <%--<td class="formcontent" nowrap="nowrap" style="width: 30%;">--%>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox  ID="txtPAddline1" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" runat="server" 
                                                    Font-Bold="False" MaxLength="30" TabIndex = "77"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender223" runat="server" InvalidChars=",#$@%^!*()&''%^~`"
                                                      FilterMode="InvalidChars" TargetControlID="txtPAddline1" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;"> 
                                             <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                <asp:Label ID="lblPDistrict"  runat="server"  style="color:Black"></asp:Label>*</span>
                                                <%--<span style="color: #ff0000">*</span>--%>
                                            </td>
                                                <td class="formcontent" style="width: 30%;">
                                                <asp:TextBox ID="txtPDistrict" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"  ReadOnly="false"  
                                                      Font-Bold="False" MaxLength="50" TabIndex="86"></asp:TextBox> <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                                <asp:Button  ID="btnPDistrict" runat="server" CssClass="standardbutton"  CausesValidation="False" 
                                                      Text="..." Enabled="false" Visible="false" TabIndex = "87"/>
                                                <asp:HiddenField ID="hdnpermDist" runat="server" />
                                                <asp:HiddenField ID="hdnpermPinFrom" runat="server" />
                                                <asp:HiddenField ID="hdnpermPinTo" runat="server" />
                                            </td>
	                                          
                                            
                                        </tr>
                                        <tr id="treditPA2" runat="server">
                                         <td class="formcontent" nowrap="nowrap" style="width: 20%; height: 24px;">
                                          <span style="color:Red">
                                                <asp:Label ID="lblPAdd2" runat="server" style="color:Black"></asp:Label>*</span>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%; height: 24px;">
	                                            <asp:TextBox ID="txtPAdd2" runat="server" CssClass="standardtextbox" 
                                                  BackColor="#FFFFB2"  MaxLength="30" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="78"></asp:TextBox>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                             <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                            <asp:Label ID="lblPcity" runat="server"  style="color:Black"></asp:Label>*</span>
                                           <%-- <span style="color: #ff0000">*</span>--%>
                                            </td>
                                            
                                                    <td class="formcontent" style="width: 30%;">
                                                <asp:TextBox ID="txtPcity1" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"  ReadOnly="false"  
                                                      Font-Bold="False" MaxLength="50" TabIndex="88"></asp:TextBox> <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                                
                                                </td>
                                            
                                        </tr>
                                        <tr id="treditPA3" runat="server">
                                           <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                            <span style="color:Red">
                                                <asp:Label ID="lblPAdd3" runat="server" style="color:Black"></asp:Label>*</span>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
	                                            <asp:TextBox ID="txtPAdd3" runat="server" CssClass="standardtextbox" 
                                                  BackColor="#FFFFB2"  MaxLength="30" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="79"></asp:TextBox>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                            <asp:Label ID="lblParea1" runat="server" ></asp:Label><span style="color: #ff0000">*</span>
                                            </td>
                                            
                                                    <td class="formcontent" style="width: 30%;">
                                                <asp:TextBox ID="txtParea1" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"  ReadOnly="false"  
                                                      Font-Bold="False" MaxLength="50" TabIndex="90"></asp:TextBox> <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                                
                                                </td>
                                        </tr>
                                        <tr id="treditPA4" runat="server">
                                             <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lblPVillage" runat="server"></asp:Label></td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:UpdatePanel ID="upnlPAVillage" runat="server">
                                                    <contenttemplate>
                                                        <asp:TextBox  ID="txtpermvillage" runat="server" CssClass="standardtextbox" 
                                                             onChange="javascript:this.value=this.value.toUpperCase();" Font-Bold="False"
                                                             MaxLength="30"  TabIndex="80"></asp:TextBox>
                                                             <%--ADDED BY PRANJALI ON 05-03-2014 for allowing only characters for village validation start--%>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_Village" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " 
                                                                TargetControlID="txtpermvillage"></ajaxToolkit:FilteredTextBoxExtender>
                                                            <%--ADDED BY PRANJALI ON 05-03-2014 for allowing only characters for village validation end--%>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" InvalidChars=",#$@%^!*()&''%^~`"
                                                              FilterMode="InvalidChars" TargetControlID="txtpermvillage" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%; height: 24px;">
                                             <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                <asp:Label ID="lblPpostcode" runat="server" style="color:Black" ></asp:Label>*</span>
                                                <%--<span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%; height: 24px;">
	                                            <asp:TextBox ID="txtPermPostcode" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                     MaxLength="10" TabIndex="92"></asp:TextBox>
                                            </td>
                                            
                                        </tr>
                                        <tr id="treditPA5" runat="server">
                                        
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                            
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                &nbsp;</td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                             <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                
                                              <asp:Label ID="lblPrmcountry" runat="server" style="color:Black"></asp:Label>
                                                  
                                                *</span>
                                               <%-- <span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtPermCountryCode" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                    MaxLength="3" onChange="javascript:this.value=this.value.toUpperCase();" 
                                                    Width="42px" TabIndex="93"></asp:TextBox>
                                                <asp:TextBox ID="txtPermCountryDesc" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                    Width="133px" Enabled="false" TabIndex="94" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                   </div>
                                   </contenttemplate>
                                   <Triggers><asp:AsyncPostBackTrigger ControlID="chkEdit" EventName="CheckedChanged" /></Triggers>
                                   </asp:UpdatePanel>
                               
                                         <div id="tblPerAdd" runat="server" class="card PanelInsideTab" style="display:none;">
                                       
                                                 <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPermanentAddress','btnPermanentAddress');return false;">
                   <div class="row">  
                     <div class="col-sm-10" style="text-align:left">   
                            <asp:Label ID="Label8" runat="server" Text="Permanent Address"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                 <contenttemplate>
                                                     <asp:CheckBox ID="chkPerEdit" Text="Permonant Address Edit" Visible="false" runat="server" CssClass="standardcheckbox"  
                                                    TabIndex = "76"  AutoPostBack="true" 
                                                         oncheckedchanged="chkPerEdit_CheckedChanged"  />
                                                   </contenttemplate>
                                                    </asp:UpdatePanel>
                     </div>
                      <div class="col-sm-2">
                        <span id="btnPermanentAddress" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                                   <asp:UpdatePanel ID="UpdPanelEditAddShow" runat="server">
                                      <contenttemplate>

                                  <div id="divPermanentAddress" runat="server" class="panel-body" style="display:block;">
                                    <div class="row" >
                                          <div class="col-sm-12" style="text-align:left">
                                                <asp:Label ID="lblpfPrmAddTitle" CssClass="control-label"  runat="server"></asp:Label>&nbsp;
                                                <asp:CheckBox ID="ChkPA" runat="server" CssClass="standardcheckbox"  TabIndex = "76" Enabled="False"/>
                                           </div>
                                        </div>
                                             <div id="trPermAdd1" runat="server" class="row rowspacing" >
                                                   <div class="col-sm-4" style="text-align:left;">
                                              <asp:Label ID="lblpfprmstatecode" CssClass="control-label"  runat="server" ></asp:Label>
                                         
                                                <span style="color: #ff0000">*</span
                                            <asp:TextBox ID="lblpfprmstatecodeDesc" runat="server" CssClass="form-control control-label"  Enabled="false" style="color:Black;"></asp:TextBox>
                                               
                                          </div>
                                     <div class="col-sm-4" style="text-align:left">
                                         
                                                <asp:Label ID="lblpfprmAdd1" runat="server" CssClass="control-label" Text="Address Line 1" style="color:Black;"></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                <asp:TextBox ID="lblpfprmAddDesc" CssClass="form-control control-label"  Enabled="false"  runat="server" ></asp:TextBox>
                                          </div>
                                       <div class="col-sm-4" style="text-align:left">
                                           
                                                <asp:Label ID="lblpermDistrict"  runat="server" CssClass="control-label" Text="District" style="color:Black;"></asp:Label>
                                                 <span style="color: #ff0000">*</span>
                                                <asp:TextBox ID="lblpermDistrictDesc" CssClass="form-control control-label"  Enabled="false"  runat="server" ></asp:TextBox>
                                           </div>
	                                     </div>
                                             <div id="trPermAdd4" runat="server" class="row rowspacing">
                                   <div class="col-sm-4" style="text-align:left">
                                                <asp:Label ID="Label26" CssClass="control-label"  Text="Address Line 2"  runat="server" ></asp:Label>
                                                <span style="color: #ff0000">*</span>
	                                            <asp:TextBox ID="lblPermAdd2" CssClass="form-control control-label"  Enabled="false" runat="server" ></asp:TextBox>
                                          </div>
                                            <div class="col-sm-4" style="text-align:left">
                                            <asp:Label ID="lblcity1" runat="server" Text="City" CssClass="control-label" style="color:Black;"></asp:Label>
                                            *</span>
                                                <asp:TextBox ID="lblcity1Desc" CssClass="form-control control-label"  Enabled="false" runat="server"  ></asp:TextBox>
                                              </div>
                                                 <div class="col-sm-4" style="text-align:left">
                                                <asp:Label ID="Label30"  Text="Address Line 3"  CssClass="control-label" runat="server" ></asp:Label> 
                                                <span style="color: #ff0000">*</span>
	                                            <asp:TextBox ID="Label30Desc"  CssClass="form-control control-label"  Enabled="false" runat="server" ></asp:TextBox>
                                          </div>
                                       </div>
                                          <div id="trPermAdd2" runat="server" class="row rowspacing" >
                                        
                                       <div class="col-sm-4" style="text-align:left">
                                           
                                            <asp:Label ID="lblarea1" runat="server" Text="Area" CssClass="control-label" style="color:Black;"></asp:Label>
                                             <span style="color: #ff0000">*</span>
                                                <asp:TextBox ID="lblarea1Desc" runat="server" CssClass="form-control control-label"  Enabled="false"  ></asp:TextBox>
                                              </div>
                                               <div class="col-sm-4" style="text-align:left">
                                                <asp:Label ID="lblpermVillage" CssClass="control-label" runat="server"  Text="Village" ></asp:Label>
                                                <asp:TextBox ID="lblpermVillageDesc" CssClass="form-control control-label"  Enabled="false"  runat="server"  ></asp:TextBox>
                                                </div>
                                               <div class="col-sm-4" style="text-align:left">
                                                <asp:Label ID="lblpfprmpostcode" runat="server" CssClass="control-label" style="color:Black;"></asp:Label>
                                                 <span style="color: #ff0000">*</span>
	                                            <asp:TextBox ID="lblpfprmpostcodeDesc" runat="server"  CssClass="form-control control-label"  Enabled="false" ></asp:TextBox>
                                           </div>
                                      </div>
                                         <div id="trPermAdd3" runat="server" class="row" >
                                       
                                                <div class="col-sm-4" style="text-align:left">
                                            <span style="color: #ff0000">
                                                <asp:Label ID="lblpfprmcountry" runat="server" CssClass="control-label" style="color:Black;"></asp:Label>
                                                *</span>
                                                <asp:TextBox ID="lblpfprmcountryDesc" CssClass="form-control control-label"  Enabled="false"  runat="server"></asp:TextBox>
                                         </div>
                                         </div>
                                   </div>
                                   </contenttemplate>
                                    </asp:UpdatePanel>
                                   
                                    </div>
                                       
                                    <asp:UpdatePanel ID="UpdPanelPermAddShow" runat="server">
                                       <contenttemplate>
                                    <div id="divPerAddressEdit" runat="server" visible="false"  style="display:none;" class="card PanelInsideTab">
                                      <table class="tableIsys" style="width: 100%;">
                                        <tr id="tr4" runat="server">
                                            <td class="formcontent" colspan="2" > <%--style="width: 20%; text-align:left;"--%>
                                                <%--&nbsp;<asp:Label ID="lbladdPAtype" Text="Address Type" runat="server"></asp:Label>&nbsp;--%>
                                              &nbsp;<asp:Label ID="lblpfPrmAddTitleEdit" runat="server"></asp:Label>&nbsp;
                                                <asp:CheckBox ID="ChkPAEdit" runat="server" CssClass="standardcheckbox" />  
                                            </td>
                                            
                                           
                                            <%--<td class="formcontent" nowrap="nowrap" style="width: 30%;"> </td>--%>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lblPAstatecodeedit" Text="State" runat="server" ></asp:Label><span style="color: #ff0000">
                                                *</span>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                            <asp:DropDownList id="ddlstatePA" runat="server" CssClass="standardmenu"  BackColor="#FFFFB2" 
                                                       Width="187px" TabIndex="84"></asp:DropDownList> 
                                            <asp:Button ID="btnPAstate1search" runat="server" CssClass="standardbutton" CausesValidation="False" 
                                                        Text="Search" TabIndex="85" />
                                                        </td>
                                            
                                        </tr>
                                        <tr id="tr7" runat="server">
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lblPAAddline1" Text="Address Line 1" runat="server" ></asp:Label><span style="color: #ff0000">
                                                *</span>
                                            </td>
                                            <%--<td class="formcontent" nowrap="nowrap" style="width: 30%;">--%>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox  ID="txtPAAddline1" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" runat="server" 
                                                    Font-Bold="False" MaxLength="30" TabIndex = "77"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" InvalidChars=",#$@%^!*()&''%^~`"
                                                      FilterMode="InvalidChars" TargetControlID="txtPAAddline1" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;"> 
                                             <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                <asp:Label ID="lblPADistrict" Text="District"  runat="server"  style="color:Black"></asp:Label>
                                                *</span>
                                                <%--<span style="color: #ff0000">*</span>--%>
                                            </td>
                                                <td class="formcontent" style="width: 30%;">
                                                <asp:TextBox ID="txtPADistrict" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"  ReadOnly="false"  
                                                      Font-Bold="False" MaxLength="50" TabIndex="86"></asp:TextBox> <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                                <asp:Button  ID="btnPADistrict" runat="server" CssClass="standardbutton"  CausesValidation="False" 
                                                      Text="..." Enabled="false"  TabIndex = "87"/>
                                                <asp:HiddenField ID="hdnDist" runat="server" />
                                                <asp:HiddenField ID="hdnPinFrom" runat="server" />
                                                <asp:HiddenField ID="hdnPinTo" runat="server" />
                                            </td>
	                                          
                                            
                                        </tr>
                                        <tr id="tr8" runat="server">
                                         <td class="formcontent" nowrap="nowrap" style="width: 20%; height: 24px;">
                                          <span style="color:Red">
                                                <asp:Label ID="lblPAAdd2" Text="Address Line 2" runat="server" style="color:Black"></asp:Label>
                                                *</span>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%; height: 24px;">
	                                            <asp:TextBox ID="txtPAAdd2" runat="server" CssClass="standardtextbox" 
                                                  BackColor="#FFFFB2"  MaxLength="30" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="78"></asp:TextBox>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                             <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                            <asp:Label ID="lblPAcity" Text="City" runat="server"  style="color:Black"></asp:Label>*</span>
                                           <%-- <span style="color: #ff0000">*</span>--%>
                                            </td>
                                            
                                                    <td class="formcontent" style="width: 30%;">
                                                <asp:TextBox ID="txtPAcity1" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"  ReadOnly="false"  
                                                      Font-Bold="False" MaxLength="50" TabIndex="88"></asp:TextBox> <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                                
                                                </td>
                                            
                                        </tr>
                                        <tr id="tr9" runat="server">
                                           <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                            <span style="color:Red">
                                                <asp:Label ID="lblPAAdd3" Text="Address Line 3" runat="server" style="color:Black"></asp:Label>*</span>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
	                                            <asp:TextBox ID="txtPAAdd3" runat="server" CssClass="standardtextbox" 
                                                  BackColor="#FFFFB2"  MaxLength="30" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="79"></asp:TextBox>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                            <asp:Label ID="lblPAarea1" Text="City" runat="server" ></asp:Label><span style="color: #ff0000">
                                            *</span>
                                            </td>
                                            
                                                    <td class="formcontent" style="width: 30%;">
                                                <asp:TextBox ID="txtPAarea1" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"  ReadOnly="false"  
                                                      Font-Bold="False" MaxLength="50" TabIndex="90"></asp:TextBox> <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                                
                                                </td>
                                        </tr>
                                        <tr id="tr10" runat="server">
                                             <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lblPAVillage" runat="server"   ></asp:Label></td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:UpdatePanel ID="upnlprmVillage" runat="server">
                                                    <contenttemplate>
                                                        <asp:TextBox  ID="txtPAvillage" runat="server" CssClass="standardtextbox" 
                                                             onChange="javascript:this.value=this.value.toUpperCase();" Font-Bold="False"
                                                             MaxLength="30"  TabIndex="80"></asp:TextBox>
                                                             <%--ADDED BY PRANJALI ON 05-03-2014 for allowing only characters for village validation start--%>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " 
                                                                TargetControlID="txtPAvillage"></ajaxToolkit:FilteredTextBoxExtender>
                                                            <%--ADDED BY PRANJALI ON 05-03-2014 for allowing only characters for village validation end--%>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" InvalidChars=",#$@%^!*()&''%^~`"
                                                              FilterMode="InvalidChars" TargetControlID="txtPAvillage" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%; height: 24px;">
                                             <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                <asp:Label ID="lblPApostcode" Text="Post Code" runat="server" style="color:Black" ></asp:Label>
                                                *</span>
                                                <%--<span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%; height: 24px;">
	                                            <asp:TextBox ID="txtPAPostcode" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                     MaxLength="10" TabIndex="92"></asp:TextBox>
                                            </td>
                                            
                                        </tr>
                                        <tr id="tr11" runat="server">
                                        
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                            
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                &nbsp;</td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                             <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                
                                              <asp:Label ID="lblPAcountry" Text="Country" runat="server" style="color:Black"></asp:Label>
                                                  
                                                *</span>
                                               <%-- <span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtPACounCode" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                    MaxLength="3" onChange="javascript:this.value=this.value.toUpperCase();" 
                                                    Width="42px" TabIndex="93"></asp:TextBox>
                                                <asp:TextBox ID="txtPACounCodeDesc" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                    Width="133px" Enabled="false" TabIndex="94" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                      
                                   </div>
                                   </contenttemplate>
                                   <Triggers><asp:AsyncPostBackTrigger ControlID="chkPerEdit" EventName="CheckedChanged" /></Triggers>
                                   </asp:UpdatePanel>
                                    
                                   <%--Permanent Address end--%>

                                   <%--Contact Information Start--%>

                                    <div class="card PanelInsideTab">
                                   
                                        <div id="tblContactInfo" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divContactInformation','btnContactInformation');return false;">
                   <div class="row">  
                     <div class="col-sm-10" style="text-align:left">    
                            <asp:Label ID="Label9" runat="server" Text="Contact Information" CssClass="control-label" Font-Size="19px" ></asp:Label>
                             
                     </div>
                      <div class="col-sm-2">
                        <span id="btnContactInformation" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                    <div id="divContactInformation" runat="server" class="panel-body" style="display:block;">
                                  <div class="row" >
                                            <div class="col-sm-4" style="text-align:left">
                                               <asp:Label  ID="lblpfconpreferred" runat="server" CssClass="control-label"  Text="Contact Preferred"></asp:Label>
                                          
                                                 <asp:TextBox  ID="lblpfconpreferredDesc" CssClass="form-control control-label"  Enabled="false"  runat="server" ></asp:TextBox>
                                          </div>
                                  </div>
                                           <div class="row rowspacing" >
                                           <div class="col-sm-4" style="text-align:left">
                                           
                                                <asp:Label ID="lblpfhometel" runat="server" CssClass="control-label" style="color:Black;"></asp:Label>
                                               

                                                <asp:TextBox ID="lblpfhometelDesc" CssClass="form-control control-label"  Enabled="false"  runat="server" ></asp:TextBox>
                                         </div>
                                             <div class="col-sm-4" style="text-align:left">
                                                <span><asp:Label ID="lblpfofftel" CssClass="control-label"  runat="server" ></asp:Label></span>
                                                <asp:TextBox ID="lblpfofftelDesc" CssClass="form-control control-label"  Enabled="false" runat="server"  ></asp:TextBox>
                                           </div>
                                               <div class="col-sm-4" style="text-align:left">
                                         
                                                <asp:Label ID="lblpfmobtel" runat="server" CssClass="control-label" Text="Mobile No. 1" style="color:Black;"></asp:Label>
                                                    
                         <div  class="input-group">

                             <span class="input-group-addon input-addon_extended">
                                            <asp:TextBox ID="lblMobCode" Text="91" CssClass="form-control control-label "  Enabled="false"  runat="server" width="62px"></asp:TextBox>&nbsp; <%-- Width="25%" --%>
                                            </span>   <asp:TextBox ID="lblpfmobtelDesc1" CssClass="form-control control-label "  Enabled="false"  runat="server" ></asp:TextBox>
                                          </div> 
                                             </div>
                                     </div>
                                    <div class="row rowspacing" >
                                             
                                            <div class="col-sm-4" style="text-align:left">
                                                <asp:Label ID="lblMobile2" CssClass="control-label"  runat="server" Text="Mobile No. 2"  ></asp:Label>
                             <div  class="input-group">
                             <span class="input-group-addon input-addon_extended">
                                            <asp:TextBox ID="lblmobcode1" CssClass="form-control control-label"  Enabled="false" Text="91"  runat="server" width="62px"></asp:TextBox>&nbsp;
                                             </span>    <asp:TextBox ID="lblpfmobtelDesc2" CssClass="form-control control-label"  Enabled="false"  runat="server"  ></asp:TextBox>  <%-- Width="25%" --%>
                                            </div>
                             </div>
                                        <div class="col-sm-4" style="text-align:left">
                                               
                                                    <asp:Label ID="lblpfemail" CssClass="control-label" runat="server" text="Email 1" style="color:Black;"></asp:Label>
                                                 
                                                <asp:TextBox ID="lblEmail1Desc" CssClass="form-control control-label "  Enabled="false"  runat="server"  ></asp:TextBox>
                                           </div>
                                          <div class="col-sm-4" style="text-align:left">
                                                <span>
                                                    <asp:Label ID="lblEmail2" CssClass="control-label"  runat="server" Text="Email 2" ></asp:Label>
                                                </span>
                                                <asp:TextBox ID="lblEmail2Desc" CssClass="form-control control-label"  Enabled="false"  runat="server"></asp:TextBox>
                                          </div>
                                       </div>
                                           
                                    </div>
                                       
                                    </div>
                                   

           <%--bank details start --%>
           <div  id="divpanel5" runat="server" visible="false" class="card PanelInsideTab">
                <div  style="margin-left: 0px; margin-right: 0px">
                    <div id="Div23" runat="server" class="panelheadingAliginment">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblbnkdtls" runat="server" CssClass="control-label HeaderColor" Text="Bank Details" Font-Size="19px"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div id="divbnkdtls" style="display: block;margin-top: -9px;" runat="server" class="panel-body panelContent">
                        <div class="row rowspacing" style="text-align:left">
                            <div class="col-sm-4">
                                <asp:Label ID="lblbnkhldname" runat="server" Style="color: black" CssClass="control-label labelSize" Text="Account Holder Name"></asp:Label>
                            </div>
                                <div class="col-sm-4">
                                <asp:Label ID="lblbnkacno" runat="server"  CssClass="control-label labelSize" Text="Account No"></asp:Label>


                            </div>
                                <div class="col-sm-4">
                                <asp:Label ID="lblifsccode" runat="server" CssClass="control-label labelSize" Text="Bank IFSC Code"></asp:Label>


                            </div>
                        </div>
                        <div class="row ">
                            <div class="col-sm-4" style="text-align: left">
                                    <asp:TextBox ID="txtbnkhldname" runat="server" CssClass="form-control " TabIndex="180" MaxLength="50" Enabled="false"></asp:TextBox>
                                   
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtbnkacno" runat="server" CssClass="form-control " Enabled="false" TabIndex="181" MaxLength="20" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            </div>
                            <div class="col-sm-4" style="text-align: left">
                                    <asp:TextBox ID="txtifsccode" runat="server"
                                        Style="text-transform: uppercase;" CssClass="form-control " TabIndex="185" MaxLength="11" Enabled="false"></asp:TextBox>
                                    
                                <span id="spanifsccode" runat="server" style="color: red; display: none;">Incorrect Bank IFSC Code
                                </span>
                            </div>
                        </div>
                        <div class="row rowspacing" style="text-align: left">
                            <div class="col-sm-4" >
                                <asp:Label ID="lblbrnchname" runat="server"  CssClass="control-label labelSize" Text="Branch Name"></asp:Label>
                                    <asp:TextBox ID="txtbrnchname" runat="server" CssClass="form-control " Enabled="false" TabIndex="183" MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            </div>
                            <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblactype" runat="server" CssClass="control-label labelSize" Text="Account Type"></asp:Label>
                                <asp:TextBox ID="ddlactype" runat="server" CssClass="form-control " TabIndex="183" MaxLength="50" Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblbnkname" runat="server" CssClass="control-label labelSize" Text="Bank Name"></asp:Label>
                                <asp:TextBox ID="txtbnkname" Enabled="false" runat="server" CssClass="form-control " TabIndex="182" MaxLength="100" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row rowspacing">
                            <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblmicrcode" runat="server" Style="color: black" CssClass="control-label labelSize" Text="MICR Code"></asp:Label>
                                <asp:TextBox ID="txtmicrcode" runat="server" CssClass="form-control" TabIndex="186" MaxLength="9" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           <%--bank details end --%>
            <%--   nominee bank details  start--%>
           <div id="nombnkdtls" runat="server" class="card PanelInsideTab" visible="false">
                            <div id="Div27" runat="server" class="panelheadingAliginment">
                                <div class="row rowspacing">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="Label51" runat="server" Text="Nominee Account Details" CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                             <div id="Nombankdtl" runat="server"  class="panel-body panelContent">
                                <div class="row " style="text-align: left">
                                    <div class="col-sm-4" >
                                <asp:Label ID="lblnmbnkhldname" runat="server" Text="Account Holder Name" CssClass="control-label labelSize"></asp:Label>
                                    <asp:TextBox ID="ddlnmbnkhldname" runat="server" CssClass="form-control" TabIndex="82" MaxLength="50"
                                         onChange="javascript:this.value=this.value.toUpperCase();" Enabled="false" ></asp:TextBox>
                                   
                                
                            </div>
                                    <div class="col-sm-4">
                                        <asp:Label ID="lblnmbnkacno" runat="server" Text="Account No" CssClass="control-label labelSize"></asp:Label>
                                        <asp:TextBox ID="txtnmbnkacno" runat="server" CssClass="form-control" TabIndex="83"  MaxLength="20" onChange="javascript:this.value=this.value.toUpperCase();" Enabled="false" ></asp:TextBox>
                                      
                                    </div>
                                     <div class="col-sm-4">
                                        <asp:Label ID="lblnmifscode" runat="server" Text="BANK IFSC Code" CssClass="control-label labelSize"></asp:Label>

                                        <asp:TextBox ID="ddlnmifscode" runat="server" CssClass="form-control" TabIndex="87" MaxLength="11" Enabled="false" ></asp:TextBox>
                                    </div>
                                    
                                  
                                </div>
                                  <div class="row rowspacing" style="text-align: left">
                                        <div class="col-sm-4">
                                        <asp:Label ID="lblnmddlactype" runat="server" Text="Account Type" CssClass="control-label labelSize"></asp:Label>
                                        </div>
                                      <div class="col-sm-4">
                                        <asp:Label ID="lblnmBrnchname" runat="server" Text="Branch Name" CssClass="control-label labelSize"></asp:Label>

                                        </div>
                                      <div class="col-sm-4">
                                    <asp:Label ID="lblnmBnkname" runat="server" Text="Bank Name" CssClass="control-label labelSize"></asp:Label>

                                        </div>
                                    </div>
                                <div class="row" style="text-align: left">
                                      <div class="col-sm-4" style="text-align: left">
                                           <asp:TextBox ID="ddlnmddlactype" runat="server" CssClass="form-control" TabIndex="86" Enabled="false" ></asp:TextBox>
                                       
                                    </div>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="ddlnmBrnchname" runat="server" CssClass="form-control" TabIndex="86" Enabled="false" ></asp:TextBox>
                                    </div>
                                      <div class="col-sm-4">
                                          <asp:TextBox ID="ddlnmBnkname" runat="server" CssClass="form-control" TabIndex="84" Enabled="false"   onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                        </div>
                                    </div>
                                <div class="row rowspacing" style="text-align: left">
                                   
                                    <div class="col-sm-4">
                                        <asp:Label ID="lblnmmicr" runat="server" Text="MICR Code" CssClass="control-label labelSize"></asp:Label>
                                        <asp:TextBox ID="txtnmmicr" runat="server" CssClass="form-control" TabIndex="88" MaxLength="9" Enabled="false" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                    </div>
           <%--nominee bank details end--%>

                                   <div class="card PanelInsideTab" id="tblProofofDocument"  runat="server" style='margin:0px;display:none;'>
                                   <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divProofofDocument','btnProofofDocument');return false;">
                   <div class="row rowspacing">  
                     <div class="col-sm-10" style="text-align:left">    
                            <asp:Label ID="lblpfprodoctitle" runat="server" Text="Contact Information"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                             
                     </div>
                      <div class="col-sm-2">
                        <span id="btnProofofDocument" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                    <div id="divProofofDocument" runat="server" class="panel-body" style="display:block;">
                                       <div class="row rowspacing" >
                                       <div class="col-sm-3" style="text-align:left">
                                       
                                              <asp:Label ID="lblBasicQual" CssClass="control-label" runat="server"  ></asp:Label>
                                                <span style="color: red">*</span>
                                              </div>
                                      <div class="col-sm-3">
                                              <asp:TextBox ID="lblBasicQualDesc" CssClass="form-control control-label"  Enabled="false" runat="server"  ></asp:TextBox>
                                       </div>
                                         <div class="col-sm-3" style="text-align:left">
                                        
                                                <asp:Label ID="lblBoardName" runat="server" CssClass="control-label"  ></asp:Label>
                                                 <span style="color: red">*</span>
                                           </div>
                                      <div class="col-sm-3">
                                                <asp:TextBox ID="lblBoardNameDesc" CssClass="form-control control-label"  Enabled="false" runat="server"  ></asp:TextBox>
                                       </div>
                                     </div>
                                            <div class="row rowspacing" >
                                        <div class="col-sm-3" style="text-align:left">
                                     
                                             <asp:Label ID="lblBasicRNo" CssClass="control-label" runat="server"  ></asp:Label>
                                                 <span style="color: red">*</span>
                                            </div>
                                        <div class="col-sm-3">
                                              <asp:TextBox ID="lblBasicRNoDesc" CssClass="form-control control-label"  Enabled="false" runat="server"  ></asp:TextBox>
                                         </div>
                                 <div class="col-sm-3" style="text-align:left">
                                        
                                                <asp:Label ID="lblYrPass" runat="server" CssClass="control-label"  ></asp:Label>
                                                 <span style="color: red">*</span>
                                              </div>
                                         <div class="col-sm-3">
                                                  <asp:TextBox ID="lblYrPassDesc" CssClass="form-control control-label"  Enabled="false" runat="server"  ></asp:TextBox>
                                       </div>
                                    </div>
                                    <div class="row rowspacing" >
                                      <div class="col-sm-3" style="text-align:left">
                                          
                                              <asp:Label ID="lblpfeduproof" runat="server" CssClass="control-label"  ></asp:Label>
                                              <span style="color: red">*</span><%--shreela--%></div>
                                     <div class="col-sm-3">
                                              <asp:TextBox ID="lblpfeduproofDesc" runat="server" CssClass="form-control control-label"  Enabled="false"  ></asp:TextBox>
                                       </div>
                                    <%--    add by meena 17_5_18--%>  <div class="col-sm-3" style="text-align:left;display:none;"">
                                              <asp:Label ID="LblProfQual" runat="server" CssClass="control-label"  ></asp:Label>
                                       
                                          </div>
                                             <div class="col-sm-3" style="display:none;">

                                                  <asp:TextBox ID="LblProfQualDesc" runat="server" CssClass="form-control control-label"  Enabled="false"  ></asp:TextBox>
                                             </div>
                                     </div>
                         <div class="row rowspacing" style="display:none;">
                                      <div class="col-sm-3" style="text-align:left">
                                          
                                              <asp:Label ID="LblInsQual" runat="server" CssClass="control-label"  Style="color: black"></asp:Label>
                                              </div>
                                     <div class="col-sm-3">
                                              <asp:TextBox ID="LblInsQualdesc" runat="server" CssClass="form-control control-label"  Enabled="false"  ></asp:TextBox>
                                       </div>
                                          <div class="col-sm-3">
                                              
                                          </div>
                                             <div class="col-sm-3">
                                                 
                                             </div>
                                     </div>
                                          <div class="row rowspacing" >
                                  <div class="col-sm-3" style="text-align:left;display:none"> <%--;display:none added by meena 16_4_18--%>  
                                          <span style="color: red">
                                               <asp:Label ID="lblPhotoSign" runat="server" CssClass="control-label"  Visible="true" style="color:Black"></asp:Label>
                                               *</span> <%--changed by kalayani on 20-12-2013 '4 Photos/Signature Recd' to 'Photos/Signature Recd'--%>
                                               </div>
                                             <div class="col-md-1" style="text-align:left;display:none"> <%--;display:none added by meena 16_4_18--%>  
                                               <asp:CheckBox ID="chkPhotoSign" runat="server"  Visible="true" Enabled="False" TabIndex="114" />
                                         </div>
                                          <div class="col-sm-3" style="text-align:center;display:none"> <%--;display:none added by meena 16_4_18--%>  
                                              <asp:Label ID="lblpfmarksheet" CssClass="control-label" runat="server" Style="color: black" ></asp:Label>
                                              </div>
                                               <div class="col-md-1" style="text-align:center;display:none"> <%--;display:none added by meena 16_4_18--%>  
                                              <asp:CheckBox ID="cbmarksheet" runat="server" CssClass="standardcheckbox" 
                                                   TabIndex="115" Enabled="False"/> 
                                              <%--<span style="color: red">*</span>--%>
                                        </div>
                                 <div class="col-sm-3" style="text-align:right;display:none"> <%--;display:none added by meena 16_4_18--%>  
                                                <asp:Label ID="lblpfcertificate" runat="server" CssClass="control-label" Style="color: black" ></asp:Label>
                                                <%--<span style="color: red">*</span>--%>
                                                </div>
                                                    <div class="col-md-1" style="text-align:right;display:none"> <%--;display:none added by meena 16_4_18--%>  
                                                 <asp:CheckBox ID="cbcertificate" runat="server" CssClass="standardcheckbox" 
                                                    TabIndex="116" Enabled="False"/>
                                    </div>
                               
                                 </div>
                                     <%--  Added by kalyani on 21-12-2013 for panchayat proof received start--%>
                                      <tr id="trPanchayat" runat="server" visible="false">
                                         <td class="formcontent" align="left" style="width:20%;">
                                         <span style="color: red">
                                              <asp:Label ID="lblPanachayat" runat="server"  style="color:Black" ></asp:Label>
                                              *</span> 
                                            
                                         </td>
                                         <td class="formcontent" style="width: 30%;">
                                              &nbsp;<asp:CheckBox ID="cbPanachayat" runat="server" BackColor="#FFFFB2"  TabIndex="117" Enabled="False"/>
                                         </td>
                                         <td class="formcontent" colspan="2"></td>
                                      </tr>
                                      <tr id="trNOCAck" runat="server" visible="false">
                                         <td class="formcontent" align="left" style="width:20%;">
                                              <asp:Label ID="lblNOCAck" runat="server"   ></asp:Label> 
                                            <%--  <span style="color: red">*</span>--%>
                                         </td>
                                         <td class="formcontent" style="width: 30%;">
                                              &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkNOCAck" runat="server" BackColor="#FFFFB2"  TabIndex="118" Enabled="False"/>
                                         </td>
                                         <td class="formcontent" colspan="2"></td>
                                      </tr>
                                     
			                          <tr id="trcfr" runat="server" visible="false">
                                        <td class="formcontent" align="left" style="width:20%;">
                                                <asp:Label ID="lblcfr" runat="server" Style="color: black" Text="CFR" ></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                                <asp:CheckBox ID="cbcfr" runat="server" CssClass="standardcheckbox" 
                                                    TabIndex="119" />
                                        </td>
			                            <td class="formcontent" style="width: 20%;">
				                                &nbsp;</td>
			                            <td class="formcontent" style="width: 30%;">
				                                &nbsp;</td>
			                          </tr>
			                          <tr style="display: none">
                                         <!-- Visible="false" added by ank on 08.08.2011 -->
			                            <td class="formcontent" style="width: 20%;">
                                             <asp:Label ID="lblpfphoto" runat="server" Visible="false" Style="color: black"></asp:Label>
                                         <!--<span style="color: red" >*</span>-->
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                              <asp:CheckBox ID="cbphoto" runat="server" 
                                                    CssClass="standardcheckbox" Visible="false" TabIndex="121" />
                                        </td>
                                        <td class="formcontent" align="left" style="width: 20%;">
                                                &nbsp;</td>
                                        <td class="formcontent" style="width: 30%;">
                                                &nbsp;&nbsp;
                                                <input type="hidden" runat="server" id="txtUnitCode"  name="txtUnitCode" visible="false"  />
                                                &nbsp;
                                        </td>
                                        
                                      </tr>
                                      <div class="row rowspacing">
                                <div class="col-md-12">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sample"
                                    Width="100" onclick="btnSave_Click"></asp:Button>
         
                                </div>
                                    </div>
                     </div>
                      
                     </div>
                        
                      <div  class="card PanelInsideTab" id="Table11" runat="server" style="margin-bottom:16px">
                          <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCndMvmt','btnCndMvmt');return false;">
                   <div class="row" id="cndmvmt" runat="server">  
                     <div class="col-sm-10" style="text-align:left">  
                            <asp:Label ID="lblCndmvmt" runat="server"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                             
                     </div>
                      <div class="col-sm-2">
                        <span id="btnCndMvmt" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                     
                                                
                                                 <div id="divCndMvmt" runat="server"  style="display: block;margin-top:10px">
      <div id="tblcndmvmt" runat="server" style="overflow-x: scroll;width:97%" >
           <%-- <asp:GridView Style="color: blue" ID="dgCndMvmt" runat="server" PagerStyle-HorizontalAlign="Center"
                            PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                            HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" 
                            Width="100%" onpageindexchanging="dgCndMvmt_PageIndexChanging" 
                onrowdatabound="dgCndMvmt_RowDataBound" PageSize="5" >--%>
                   <asp:GridView  AllowSorting="True" ID="dgCndMvmt" runat="server" CssClass="footable" Style="border-bottom-color: black;"
                                        AutoGenerateColumns="False"  CellPadding="1"  
                                        OnRowDataBound="dgCndMvmt_RowDataBound"  >
                                         <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                                       
                                      
                            <Columns>
                                <asp:TemplateField SortExpression="CreatedDt" HeaderText="Movement Date" ItemStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDt" runat="server" Text='<%# Eval("CreatedDt","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                               <ItemStyle CssClass="clscenter"  ></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="cndStatus" HeaderText="Status" ItemStyle-Width="3%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcndstat" runat="server" Text='<%# Eval("cndStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                <ItemStyle CssClass="clsleft" />
                                        <HeaderStyle CssClass="clsleft" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="CreatedBy" HeaderText="Movement By" ItemStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Eval("CreatedBy")%>'></asp:Label>
                                    </ItemTemplate>
                                   <ItemStyle CssClass="clscenter" />
                                        <HeaderStyle CssClass="clscenter" />
                                </asp:TemplateField>
                              <asp:TemplateField SortExpression="RemarkReject" HeaderText="Reason of Reject"  ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReaRej" runat="server"  Text='<%# Eval("ReasonRejection")%>'></asp:Label>
                                    </ItemTemplate>
                                  <ItemStyle CssClass="clsleft" />
                                        <HeaderStyle CssClass="clsleft" />
                                </asp:TemplateField>
                            </Columns>
                            
                       <%--     <HeaderStyle Height="10px" CssClass="portlet blue" ForeColor="White" HorizontalAlign="Center" />
                            <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black" Font-Size="12px"></PagerStyle>
                            <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="12px">
                            </RowStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>--%>
                        </asp:GridView>
                        
       </div>
       </div>
                                                 
                                              
                                             
                                               
            </div>
 
                </div>
                <%--added by Prathamesh for Profiling tab 16-6-15 start--%>
          
                <%--2-Profiling section start--%>
                 <div id="menu2" class="tab-pane fade" >
                   
                            <table class="formtable" style="width: 90%; display: none;">
                                <tr>
                                    <td class="test" colspan="4">
                                        <input runat="server" type="button" class="standardlink" value="-" id="btnView2"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divView2', 'ctl00_ContentPlaceHolder1_btnView2');" />
                                        <asp:Label ID="lblView2" Text="Profiling" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <%--<div id="divView2" runat="server" style="display: block; width: 90%;">--%>
                                <%--<table id="Table5" runat="server" class="tableIsys" style="width: 100%;">
                                    <tr>
                                        <td align="center">--%>
                                          <%--Personal Information start--%>
                                               <div class="panel" style="margin:0px;">
                                                   <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divQPersonal','btnQPersonal');return false;">           
                          <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblqfpersonalinformation" runat="server" CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnQPersonal" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                                                   <div id="divQPersonal" runat="server" class="panel-body" style="display:block;" >
                                         <div class="row rowspacing" >
                                                  <div class="col-sm-3" style="text-align:left">
                                                            <asp:Label ID="lblqfcndnotitle" runat="server" CssClass="control-label"></asp:Label>
                                                    </div>
                                                       <div class="col-sm-3">
                                                            <asp:TextBox ID="lblqcndno" CssClass="form-control control-label"   Enabled="false" runat="server"></asp:TextBox>
                                                      </div>
                                                      <div class="col-sm-3" visible="false"  style="text-align:left">
                                                            <asp:Label ID="lblqfcategorytitle" runat="server" CssClass="control-label"></asp:Label>
                                                      </div>
                                                                <div class="col-sm-3" visible="false">
                                                            <asp:TextBox ID="lblqfcategory" runat="server" visible="false" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>
                                                      </div>
                                               
                                               </div>
                                                   <div class="row rowspacing" >
                                                        <div class="col-sm-3" style="text-align:left">
                                                            <asp:Label ID="lblqfappnotitle" runat="server" CssClass="control-label"></asp:Label>
                                                       </div>
                                                           <div class="col-sm-3">
                                                            <asp:TextBox ID="lblqappno" runat="server" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>
                                                    </div>
                                                           <div class="col-sm-3" style="text-align:left">
                                                            <asp:Label ID="lblqfregdatetitle" runat="server" CssClass="control-label"></asp:Label>
                                                   </div>
                                                         <div class="col-sm-3">
                                                            <asp:TextBox ID="lblqregdate" runat="server" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>
                                                       </div>
                                                </div>

                                                    <%--comment by Prathamesh Name and surname--%>
                                            <div class="row rowspacing" >
                                                        <div class="col-sm-3" style="text-align:left">
                                                            <asp:Label ID="lblqfgivennametitle" CssClass="control-label" runat="server"></asp:Label>
                                                    </div>
                                                         <div class="col-sm-3">
                                                            <asp:TextBox ID="lblqgivenname" CssClass="form-control control-label"   Enabled="false" runat="server"></asp:TextBox>
                                                  </div>
                                                         <div class="col-sm-3" style="text-align:left">
                                                            <asp:Label ID="lblqfsurname" CssClass="control-label" runat="server"></asp:Label>
                                                     </div>
                                                           <div class="col-sm-3">
                                                            <asp:TextBox ID="lblqsurname" CssClass="form-control control-label"   Enabled="false" runat="server"></asp:TextBox>
                                                        </div>
                                                   </div>
                                                     <%--comment by Prathamesh Name and surname end--%>
                                                     
                                                    <%--Personal Information end--%>
                                             
                                            </div>
                                            </div>
                                               
                                            <table class="formtable" style="width: 100%; display: none;">
                                                <%--Languages known start--%>
                                                <tr>
                                                    <td class="test" colspan="4">
                                                        <asp:UpdatePanel ID="upnldivLanguage" runat="server">
                                                            <ContentTemplate>
                                                                <input runat="server" type="button" class="standardlink" value="+" id="btnLanguage"
                                                                    style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divLanguage', 'ctl00_ContentPlaceHolder1_btnLanguage');" />
                                                                <asp:Label ID="lblqfknolanguagestitle" runat="server"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>

                                                    <%--comment by Prathamesh 2/7/15--%>
                                                   <%-- <td class="formcontent"  align="left" style="width: 15%">
                                                    &nbsp;<asp:CheckBox ID="cbLifeIns" runat="server" CssClass="standardcheckbox" 
                                                            TabIndex="135" Enabled="False"/>
                                                     </td>
                                                    <td class="formcontent" align="left"  style="width: 18%">
                                                    &nbsp;<asp:CheckBox ID="cbGenIns" runat="server" CssClass="standardcheckbox" 
                                                            TabIndex="136" Enabled="False"/></td>
                                                    <td class="formcontent" align="left"  style="width: 15%">
                                                    &nbsp;<asp:CheckBox ID="cbCreCard" runat="server"  CssClass="standardcheckbox" 
                                                            TabIndex="137" Enabled="False"/></td>--%>
                                                </tr>
                                            </table>
                                            <div id="divLanguage" runat="server" style="display: none" width="100%;">
                                                <table class="tableIsys" style="width: 100%;">
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:Label ID="lblqflanguage1" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnlLanguage1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblqfread1" runat="server" Visible="false"></asp:Label>&nbsp;
                                                                    <asp:Label ID="lblqfwrite1" runat="server" Visible="false"></asp:Label>&nbsp;
                                                                    <asp:Label ID="lblqfspeak1" runat="server" Visible="false"></asp:Label>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddllanknow1" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:Label ID="lblqflanguage2" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnlLanguage2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblqfread2" runat="server" Visible="false"></asp:Label>&nbsp;
                                                                    <asp:Label ID="lblqfwrite2" runat="server" Visible="false"></asp:Label>&nbsp;
                                                                    <asp:Label ID="lblqfspeak2" runat="server" Visible="false"></asp:Label>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddllanknow3" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            <asp:Label ID="lblqflanguagesKnown1" runat="server"></asp:Label>
                                                        </td>

                                                        <%--comment by Pathamesh 17-6-15--%>
                                                        <td class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnllanknow1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddllanknow1" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                                                        Width="100px" OnSelectedIndexChanged="ddllanknow1_SelectedIndexChanged" TabIndex="500">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td id="tdlanknow1" runat="server" class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnllanknow1Chk" runat="server">
                                                                <ContentTemplate>
                                                                    &nbsp;&nbsp;<asp:CheckBox ID="cbpread" runat="server" CssClass="standardcheckbox"
                                                                        Visible="false" TabIndex="505" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:CheckBox ID="cbpwrite" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="510" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:CheckBox ID="cbpspeak" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="515" />
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddllanknow1" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:Label ID="lblqflanguagesKnown2" runat="server" Font-Bold="False" Width="117px"></asp:Label>
                                                        </td>

                                                        <%--comment by Pathamesh 17-6-15--%>
                                                        <td class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnllanknow3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddllanknow3" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                                                        Width="100px" OnSelectedIndexChanged="ddllanknow3_SelectedIndexChanged" TabIndex="540">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnllanknow3Chk" runat="server">
                                                                <ContentTemplate>
                                                                    &nbsp;&nbsp;<asp:CheckBox ID="cbpread3" runat="server" CssClass="standardcheckbox"
                                                                        Visible="false" TabIndex="545" />&nbsp; &nbsp;&nbsp;&nbsp;
                                                                    <asp:CheckBox ID="cbpwrite3" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="550" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:CheckBox ID="cbpspeak3" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="555" />
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddllanknow3" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            &nbsp;
                                                        </td>

                                                        <%--comment by Pathamesh 17-6-15--%>
                                                        <td class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnllanknow2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddllanknow2" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                                                        Width="100px" OnSelectedIndexChanged="ddllanknow2_SelectedIndexChanged" TabIndex="520">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnllanknow2Chk" runat="server">
                                                                <ContentTemplate>
                                                                    &nbsp;&nbsp;<asp:CheckBox ID="cbpread2" runat="server" CssClass="standardcheckbox"
                                                                        Visible="false" TabIndex="525" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:CheckBox ID="cbpwrite2" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="530" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:CheckBox ID="cbpspeak2" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="535" />
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddllanknow2" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            &nbsp;
                                                        </td>

                                                        <%--comment by Pathamesh 17-6-15--%>
                                                        <td class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnllanknow4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddllanknow4" runat="server" CssClass="standardmenu" Width="100px"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddllanknow4_SelectedIndexChanged"
                                                                        TabIndex="560">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnllanknow4Chk" runat="server">
                                                                <ContentTemplate>
                                                                    &nbsp;&nbsp;<asp:CheckBox ID="cbpread4" runat="server" CssClass="standardcheckbox"
                                                                        Visible="false" TabIndex="565" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:CheckBox ID="cbpwrite4" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="570" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:CheckBox ID="cbpspeak4" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="575" />
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddllanknow4" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <%--Languages known End--%>
                                                </table>
                                            </div>
                                            <table class="formtable" style="width: 100%; display: none;">
                                                <%--Address of Employer start--%>
                                                <tr>
                                                    <td class="test" colspan="4">
                                                        <input runat="server" type="button" class="standardlink" value="+" id="btnQOccupation"
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divOccupation', 'ctl00_ContentPlaceHolder1_btnQOccupation');" />
                                                        <asp:Label ID="lbqfloccqualification" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divOccupation" runat="server" style="display: none" width="100%;">
                                                <table class="tableIsys" style="width: 100%;">
                                                    <tr>
                                                        <td class="formcontent" style="width: 20%">
                                                            <asp:Label ID="lblqfHigestQul" runat="server"></asp:Label><span style="color: red">*</span>
                                                        </td>
                                                        <td class="formcontent" style="width: 26%" colspan="4">
                                                            <asp:UpdatePanel ID="upnlQualCode" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="cboQualCode" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                                                        BackColor="#FFFFB2" Width="310px" TabIndex="128">
                         
                         
                         
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <%--<uc4:ddlLookup runat="server" ID="cboQualCode" CssClass="standardmenu" 
                                                 RequiredField="false" LookupCode="NBEduQua" ValidationError="Mandatory!" 
                                                 TabIndex="580"></uc4:ddlLookup>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" style="width: 20%">
                                                            <asp:Label ID="lblqfinsqualification" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 501px" colspan="4">
                                                            <asp:TextBox CssClass="standardtextbox" ID="txtinsurancequalification" runat="server"
                                                                MaxLength="50" Width="300px" TabIndex="129"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <span style="color: red">
                                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                                <asp:Label ID="lblqfoccupation" runat="server" Style="color: Black"></asp:Label>*</span>
                                                            <%-- <span style="color: red">*</span>--%>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%" align="left">
                                                            <asp:TextBox ID="txtOccupationCode" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                                Width="50px" onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="4"
                                                                TabIndex="130"></asp:TextBox>
                                                            <asp:TextBox ID="txtOccupationDesc" runat="server" CssClass="standardtextbox" Enabled="false"
                                                                Width="120px" BackColor="#FFFFB2" onChange="javascript:this.value=this.value.toUpperCase();"
                                                                TabIndex="131"></asp:TextBox>
                                                            &nbsp;
                                                            <asp:Button ID="btnOccupation" runat="server" CssClass="standardbutton" Text="..."
                                                                BackColor="#FFFFB2" CausesValidation="False" Width="20px" TabIndex="132"></asp:Button>
                                                        </td>
                                                        <td class="formcontent" style="width: 20%">
                                                            <asp:Label ID="lblqfempaddress" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%">
                                                            <asp:TextBox ID="txtempaddress" runat="server" CssClass="standardtextbox" MaxLength="100"
                                                                Width="178px" TextMode="MultiLine" TabIndex="133"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <%--Address of Employer End--%>
                                                </table>
                                            </div>
                                            <table class="formtable" style="width: 100%; display: none;">
                                                <tr>
                                                    <td class="test" colspan="5">
                                                        <input runat="server" type="button" class="standardlink" value="+" id="btnFunProduct"
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divFunProduct', 'ctl00_ContentPlaceHolder1_btnFunProduct');" />
                                                        <asp:Label ID="lblqfdoyouhave" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divFunProduct" runat="server" style="display: none" width="100%;">
                                                <table class="tableIsys" style="width: 100%;">
                                                    <tr>
                                                        <td colspan="4">
                                                            <table class="tableIsys" style="width: 100%;">
                                                                <tr>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:Label ID="lblqffromreliance" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        &nbsp;<asp:CheckBox ID="cbMutFund" runat="server" CssClass="standardcheckbox" TabIndex="134" />
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        &nbsp;<asp:CheckBox ID="cbLifeIns" runat="server" CssClass="standardcheckbox" TabIndex="135" />
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 18%">
                                                                        &nbsp;<asp:CheckBox ID="cbGenIns" runat="server" CssClass="standardcheckbox" TabIndex="136" />
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        &nbsp;<asp:CheckBox ID="cbCreCard" runat="server" CssClass="standardcheckbox" TabIndex="137" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" style="width: 18%">
                                                            <asp:Label ID="lblqffromothers" runat="server" Width="176px"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" colspan="3">
                                                            <asp:TextBox ID="txtOtherProduct" runat="server" CssClass="standardtextbox" Width="200px"
                                                                MaxLength="20" TabIndex="138"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        <%--</td>
                                    </tr>
                                </table>--%>
                           <%-- </div>--%>
                            <%--pranjali removed--%>
                            <table class="formtable" style="width: 90%; display: none;">
                                <tr>
                                    <td style="background-color:#3399FF;color:Navy;" colspan="4">
                                        <input runat="server" type="button" class="standardlink" value="+" id="btnView3"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divView3', 'ctl00_ContentPlaceHolder1_btnView3');" />
                                        <asp:Label ID="Label131" Text="Employment" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div id="divView3" runat="server" style="display: none; width: 90%;">
                                <table id="Table4" runat="server" class="container" style="width: 100%">
                                    <tr>
                                        <td style="width: 791px" align="center">
                                            <%--Personal Information--%>
                                            <table class="formtable" width="90%" style="display: none;">
                                                <tr>
                                                    <td style="background-color:#3399FF;color:Navy;" colspan="4">
                                                        <input runat="server" type="button" class="standardlink" value="-" id="btnEPersonal"
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divEPersonal', 'ctl00_ContentPlaceHolder1_btnEPersonal');" />
                                                        <asp:Label ID="lblehtpersonalinformation" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divEPersonal" runat="server" style="display: none;">
                                                <table class="tableIsys" width="90%">
                                                    <%--Newly--%>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%;">
                                                            <asp:Label ID="lblehcndnotitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblecndno" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblehcategorytitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblehcategory" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%;">
                                                            <asp:Label ID="lblehappnotitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lbleappno" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblehregdatetitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lbleregdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblehgivennametitle" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblegivenname" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblehsurnametitle" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblesurname" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--Personal Information End--%>
                                            </div>
                                            <table class="formtable" style="width: 100%">
                                                <tr style="background-color: #0055A0">
                                                    <td colspan="4" align="left">
                                                        <input runat="server" type="button" visible="false" class="standardlink" value="+"
                                                            id="btnEmploymentHist" style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divEmploymentHist', 'ctl00_ContentPlaceHolder1_btnEmploymentHist');" />
                                                        <asp:Label ID="lblehEmpHistory" runat="server" Style="padding-left: 20px" ForeColor="White"
                                                           ></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divEmploymentHist" runat="server" style="display: block" width="100%;">
                                                <table class="tableIsys" width="100%">
                                                    <tr>
                                                        <td class="formcontent" colspan="4" align="left">
                                                            <asp:Label ID="lblehbeginning" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%--Working--%>
                                                    <tr>
                                                        <td align="left" class="formcontent" colspan="4">
                                                            <table class="tableIsys" width="100%">
                                                                <tr class="test">
                                                                    <td align="center" style="width: 100px;">
                                                                        <asp:Label ID="lblehfrom" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="width: 100px;">
                                                                        <asp:Label ID="lblehto" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="width: 94px;">
                                                                        <asp:Label ID="lblehname" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="width: 94px;">
                                                                        <asp:Label ID="lblehaddofemp" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="width: 94px;">
                                                                        <asp:Label ID="lbllehastposition" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="width: 94px;">
                                                                        <asp:Label ID="lblehannincome" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="width: 94px;">
                                                                        <asp:Label ID="lblehresforleave" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtfrom1" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="139" />--%>
                                                                        <asp:TextBox ID="txtfrom1" runat="server" CssClass="standardtextbox" Width="80" TabIndex="139" />
                                                                        <asp:Image ID="btnfrom1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimg1cal" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtfrom1"
                                                                            PopupButtonID="btnfrom1" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtfrom1" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR6" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom1" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtfrom1"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtto1" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="140"/>--%>
                                                                        <asp:TextBox ID="txtto1" runat="server" CssClass="standardtextbox" Width="80" TabIndex="140" />
                                                                        <asp:Image ID="btntxtto1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtto1" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtto1"
                                                                            PopupButtonID="btntxtto1" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtto1" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR7" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto1" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtto1"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName1" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="141"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender111" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName1">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtaddofemp1" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="142"></asp:TextBox>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtEmpLvl1" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="143"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender411" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl1">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtLastIncome1" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="144"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender911" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome1" FilterType="Custom">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtreasforleave1" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="145"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave1">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtfrom2" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="146"/>--%>
                                                                        <asp:TextBox ID="txtfrom2" runat="server" CssClass="standardtextbox" Width="80" TabIndex="146" />
                                                                        <asp:Image ID="imgtxtfrom2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtfrom2" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtfrom2"
                                                                            PopupButtonID="txtimgtxtfrom2" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtto1" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR8" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom2" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txtfrom2"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtto2" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="147"/>--%>
                                                                        <asp:TextBox ID="txtto2" runat="server" CssClass="standardtextbox" Width="80" TabIndex="147" />
                                                                        <asp:Image ID="imgtxtto2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtto2" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtto2"
                                                                            PopupButtonID="txtimgtxtfrom2" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtto2" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR9" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto2" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txtto2"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName2" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="148"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName2">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtaddofemp2" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="149"></asp:TextBox>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtEmpLvl2" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="150"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender43" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl2">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtLastIncome2" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="151"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender44" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome2" FilterType="Custom">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtreasforleave2" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="152"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave2">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtfrom3" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="153"/>--%>
                                                                        <asp:TextBox ID="txtfrom3" runat="server" CssClass="standardtextbox" Width="80" TabIndex="153" />
                                                                        <asp:Image ID="imgtxtfrom3" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtfrom3" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtfrom3"
                                                                            PopupButtonID="imgtxtfrom3" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtfrom3" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR10" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom3" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator10" runat="server" ControlToValidate="txtfrom3"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtto3" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="154"/>--%>
                                                                        <asp:TextBox ID="txtto3" runat="server" CssClass="standardtextbox" Width="80" TabIndex="154" />
                                                                        <asp:Image ID="imgtxtto3" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtto3" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtimgtxtto3"
                                                                            PopupButtonID="imgtxtto3" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtto3" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR11" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto3" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator11" runat="server" ControlToValidate="txtto3"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName3" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="155"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName3">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td align="left" class="formcontent">
                                                                        <asp:TextBox ID="txtaddofemp3" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="156"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" class="formcontent">
                                                                        <asp:TextBox ID="txtEmpLvl3" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="157"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl3">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td align="left" class="formcontent">
                                                                        <asp:TextBox ID="txtLastIncome3" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="158"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome3" FilterType="Custom">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td align="left" class="formcontent">
                                                                        <asp:TextBox ID="txtreasforleave3" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="159"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave3">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtfrom4" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="160"/>--%>
                                                                        <asp:TextBox ID="txtfrom4" runat="server" CssClass="standardtextbox" Width="80" TabIndex="160" />
                                                                        <asp:Image ID="imgtxtfrom4" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtfrom4" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtimgtxtfrom4"
                                                                            PopupButtonID="imgtxtfrom4" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtfrom4" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR12" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom4" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator12" runat="server" ControlToValidate="txtfrom4"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtto4" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="161"/>--%>
                                                                        <asp:TextBox ID="txtto4" runat="server" CssClass="standardtextbox" Width="80" TabIndex="161" />
                                                                        <asp:Image ID="imgtxtto4" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtto4" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txtimgtxtto4"
                                                                            PopupButtonID="imgtxtto4" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtto4" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR13" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto4" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator13" runat="server" ControlToValidate="txtto4"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName4" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="162"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName4">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtaddofemp4" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="163"></asp:TextBox>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtEmpLvl4" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="164"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender34" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl4">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtLastIncome4" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="165"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender36" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome4" FilterType="Custom">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtreasforleave4" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="166"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave4">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtfrom5" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="167"/>--%>
                                                                        <asp:TextBox ID="txtfrom5" runat="server" CssClass="standardtextbox" Width="80" TabIndex="167" />
                                                                        <asp:Image ID="imgtxtfrom5" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtfrom5" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txtimgtxtfrom5"
                                                                            PopupButtonID="imgtxtfrom5" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtfrom5" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR14" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom5" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator14" runat="server" ControlToValidate="txtfrom5"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtto5" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="168"/>--%>
                                                                        <asp:TextBox ID="txtto5" runat="server" CssClass="standardtextbox" Width="80" TabIndex="168" />
                                                                        <asp:Image ID="imgtxtto5" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtto5" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender151" runat="server" TargetControlID="txtimgtxtto5"
                                                                            PopupButtonID="imgtxtto5" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator151" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtfrom5" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR15" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto5" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator15" runat="server" ControlToValidate="txtfrom5"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName5" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="169"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender38" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName5">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtaddofemp5" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="170"></asp:TextBox>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtEmpLvl5" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="171"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl5">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtLastIncome5" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="172"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome5" FilterType="Custom">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtreasforleave5" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="173"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender37" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave5">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr id="Tr12" runat="server" visible="false">
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtfrom6" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="174"/>--%>
                                                                        <asp:TextBox ID="txtfrom6" runat="server" CssClass="standardtextbox" Width="80" TabIndex="174" />
                                                                        <asp:Image ID="imgtxtfrom6" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtfrom6" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender161" runat="server" TargetControlID="txtimgtxtfrom6"
                                                                            PopupButtonID="imgtxtfrom6" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator161" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtfrom6" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR161" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom6" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator1611" runat="server" ControlToValidate="txtfrom6"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtto6" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="175"/>--%>
                                                                        <asp:TextBox ID="txtto6" runat="server" CssClass="standardtextbox" Width="80" TabIndex="175" />
                                                                        <asp:Image ID="imgtxtto6" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtto6" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender171" runat="server" TargetControlID="txtimgtxtto6"
                                                                            PopupButtonID="imgtxtto6" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtto6" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR17" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto6" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                        <asp:RangeValidator ID="RangeValidator17" runat="server" ControlToValidate="txtto6"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName6" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="176"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender40" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName6">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtaddofemp6" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="177"></asp:TextBox>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtEmpLvl6" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="178"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender41" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl6">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtLastIncome6" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="179"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender45" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome6" FilterType="Custom">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtreasforleave6" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="180"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender42" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave6">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <table class="formtable" width="100%">
                                                <%--Sales/Marketing/Financial Services Experience -Start--%>
                                                <tr style="background-color: #0055A0">
                                                    <td align="left" colspan="4">
                                                        <input runat="server" type="button" visible="false" class="standardlink" value="-"
                                                            id="btnSalesExp" style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSalesExp', 'ctl00_ContentPlaceHolder1_btnSalesExp');" />
                                                        <asp:Label ID="lblehexperience" runat="server" Style="padding-left: 20px" ForeColor="White"
                                                           ></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divSalesExp" runat="server" style="display: block" width="100%;">
                                                <table class="tableIsys" width="100%">
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="6" style="width: 100%;">
                                                            <table>
                                                                <tr>
                                                                    <td class="formcontent" align="right" style="width: 90%;">
                                                                        <span style="color: Red;">
                                                                            <asp:Label ID="lblehhaveyou" runat="server" Font-Bold="False" Style=""></asp:Label>*</span>
                                                                    </td>
                                                                    <%--comment by Pathamesh 17-6-15--%>
                                                                    <td class="formcontent" align="left" style="width: 10%;">
                                                                        <asp:UpdatePanel ID="updrbotherexp" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:RadioButtonList ID="rbotherexp" runat="server" CssClass="radiobtn" BackColor="#FFFFB2"
                                                                                    RepeatDirection="Horizontal" TabIndex="181" AutoPostBack="true" OnSelectedIndexChanged="rbotherexp_SelectedIndexChanged">
                                                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="4">
                                                            <table class="tableIsys" width="100%">
                                                                <tr class="test">
                                                                    <td align="center" style="width: 160px;">
                                                                        <asp:Label ID="lblehcompanyname" runat="server" ForeColor="Navy"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="width: 160px;">
                                                                        <asp:Label ID="lblehcnfrom" runat="server" ForeColor="Navy"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="width: 90px;">
                                                                        <asp:Label ID="lblehcnto" runat="server" ForeColor="Navy"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="width: 90px;">
                                                                        <asp:Label ID="lblehcnjobnature" runat="server" ForeColor="Navy"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="width: 90px;">
                                                                        <asp:Label ID="lblehcnfield" runat="server" ForeColor="Navy"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordname1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordname1" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                                    TabIndex="182"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender46" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordname1">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:UpdatePanel ID="updtxtotherexpfrom1" runat="server">
                                                                            <ContentTemplate>
                                                                                <%--<uc7:ctlDate ID="txtotherexpfrom1" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="183"/>--%>
                                                                                <asp:TextBox ID="txtotherexpfrom1" runat="server" CssClass="standardtextbox" Width="80"
                                                                                    TabIndex="183" />
                                                                                <asp:Image ID="imgtxtotherexpfrom1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                                <asp:TextBox ID="txtimgtxtotherexpfrom1" runat="server" CssClass="standardtextbox"
                                                                                    Style="display: none"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender181" runat="server" TargetControlID="txtotherexpfrom1"
                                                                                    PopupButtonID="imgtxtotherexpfrom1" Format="dd/MM/yyyy" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator181" runat="server" SetFocusOnError="true"
                                                                                    ControlToValidate="txtotherexpfrom1" Enabled="false" ErrorMessage="Mandatory!"
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR181" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpfrom1" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                                <asp:RangeValidator ID="RangeValidator141" runat="server" ControlToValidate="txtotherexpfrom1"
                                                                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:UpdatePanel ID="updtxtotherexpTo1" runat="server">
                                                                            <ContentTemplate>
                                                                                <%--<uc7:ctlDate ID="txtotherexpTo1" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="184"/>--%>
                                                                                <asp:TextBox ID="txtotherexpTo1" runat="server" CssClass="standardtextbox" Width="80"
                                                                                    TabIndex="184" />
                                                                                <asp:Image ID="imgtxtotherexpTo1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                                <asp:TextBox ID="txtimgtxtotherexpTo1" runat="server" CssClass="standardtextbox"
                                                                                    Style="display: none"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txtotherexpTo1"
                                                                                    PopupButtonID="imgtxtotherexpTo1" Format="dd/MM/yyyy" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" SetFocusOnError="true"
                                                                                    ControlToValidate="txtotherexpTo1" Enabled="false" ErrorMessage="Mandatory!"
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR16" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpTo1" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                                <asp:RangeValidator ID="RangeValidator151" runat="server" ControlToValidate="txtotherexpTo1"
                                                                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordjobnature1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordjobnature1" runat="server" CssClass="standardtextbox"
                                                                                    MaxLength="30" TabIndex="185"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender47" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordjobnature1">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordfield1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordfield1" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                                    TabIndex="186"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender48" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordfield1">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:UpdatePanel ID="updemprecordname2" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordname2" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                                    TabIndex="187"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender49" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordname2">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:UpdatePanel ID="updtxtotherexpfrom2" runat="server">
                                                                            <ContentTemplate>
                                                                                <%--<uc7:ctlDate ID="txtotherexpfrom2" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="188"/>--%>
                                                                                <asp:TextBox ID="txtotherexpfrom2" runat="server" CssClass="standardtextbox" Width="80"
                                                                                    TabIndex="188" />
                                                                                <asp:Image ID="imgtxtotherexpfrom2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                                <asp:TextBox ID="txtimgtxtotherexpfrom2" runat="server" CssClass="standardtextbox"
                                                                                    Style="display: none"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender16" runat="server" TargetControlID="txtotherexpfrom2"
                                                                                    PopupButtonID="imgtxttxtotherexpfrom2" Format="dd/MM/yyyy" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" SetFocusOnError="true"
                                                                                    ControlToValidate="txtotherexpfrom2" Enabled="false" ErrorMessage="Mandatory!"
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR171" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpfrom2" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                                <asp:RangeValidator ID="RangeValidator161" runat="server" ControlToValidate="txtotherexpfrom2"
                                                                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:UpdatePanel ID="updtxtotherexpTo2" runat="server">
                                                                            <ContentTemplate>
                                                                                <%--<uc7:ctlDate ID="txtotherexpTo2" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="189"/>--%>
                                                                                <asp:TextBox ID="txtotherexpTo2" runat="server" CssClass="standardtextbox" Width="80"
                                                                                    TabIndex="189" />
                                                                                <asp:Image ID="imgtxtotherexpTo2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                                <asp:TextBox ID="txtimgtxtotherexpTo2" runat="server" CssClass="standardtextbox"
                                                                                    Style="display: none"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender17" runat="server" TargetControlID="txtotherexpTo2"
                                                                                    PopupButtonID="imgtxtotherexpTo2" Format="dd/MM/yyyy" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator171" runat="server" SetFocusOnError="true"
                                                                                    ControlToValidate="txtotherexpTo2" Enabled="false" ErrorMessage="Mandatory!"
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR18" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpTo2" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                                <asp:RangeValidator ID="RangeValidator171" runat="server" ControlToValidate="txtotherexpTo2"
                                                                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordjobnature2" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordjobnature2" runat="server" CssClass="standardtextbox"
                                                                                    MaxLength="30" TabIndex="190"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender50" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordjobnature2">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordfield2" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordfield2" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                                    TabIndex="191"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender51" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordfield2">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordname3" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordname3" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                                    TabIndex="192"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender52" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordname3">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:UpdatePanel ID="updtxtotherexpfrom3" runat="server">
                                                                            <ContentTemplate>
                                                                                <%--<uc7:ctlDate ID="txtotherexpfrom3" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="193"/>--%>
                                                                                <asp:TextBox ID="txtotherexpfrom3" runat="server" CssClass="standardtextbox" Width="80"
                                                                                    TabIndex="193" />
                                                                                <asp:Image ID="imgtxtotherexpfrom3" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                                <asp:TextBox ID="txtimgtxtotherexpfrom3" runat="server" CssClass="standardtextbox"
                                                                                    Style="display: none"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender18" runat="server" TargetControlID="txtotherexpfrom3"
                                                                                    PopupButtonID="imgtxtotherexpfrom3" Format="dd/MM/yyyy" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" SetFocusOnError="true"
                                                                                    ControlToValidate="txtotherexpfrom3" Enabled="false" ErrorMessage="Mandatory!"
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR19" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpfrom3" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                                <asp:RangeValidator ID="RangeValidator18" runat="server" ControlToValidate="txtotherexpfrom3"
                                                                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:UpdatePanel ID="updtxtotherexpTo3" runat="server">
                                                                            <ContentTemplate>
                                                                                <%-- <uc7:ctlDate ID="txtotherexpTo3" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="194"/>--%>
                                                                                <asp:TextBox ID="txtotherexpTo3" runat="server" CssClass="standardtextbox" Width="80"
                                                                                    TabIndex="194" />
                                                                                <asp:Image ID="imgtxtotherexpTo3" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                                <asp:TextBox ID="txtimgtxtotherexpTo3" runat="server" CssClass="standardtextbox"
                                                                                    Style="display: none"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender19" runat="server" TargetControlID="txtotherexpTo3"
                                                                                    PopupButtonID="imgtxtotherexpTo3" Format="dd/MM/yyyy" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" SetFocusOnError="true"
                                                                                    ControlToValidate="txtotherexpTo3" Enabled="false" ErrorMessage="Mandatory!"
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR20" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpTo3" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                                <asp:RangeValidator ID="RangeValidator19" runat="server" ControlToValidate="txtotherexpTo3"
                                                                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordjobnature3" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordjobnature3" runat="server" CssClass="standardtextbox"
                                                                                    MaxLength="30" TabIndex="195"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender53" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordjobnature3">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordfield3" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordfield3" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                                    TabIndex="196"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender54" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordfield3">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <table class="formtable" width="100%">
                                                <tr style="background-color: #0055A0">
                                                    <td align="left" colspan="4">
                                                        <input runat="server" type="button" visible="false" class="standardlink" value="-"
                                                            id="btnInsuranceAgency" style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divInsuranceAgency', 'ctl00_ContentPlaceHolder1_btnInsuranceAgency');" />
                                                        <asp:Label ID="lblehdetofinsagcy" Style="padding-left: 20px" ForeColor="White" runat="server"
                                                           ></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divInsuranceAgency" runat="server" style="display: none" width="100%;">
                                                <table class="tableIsys" width="100%">
                                                    <tr>
                                                        <td class="formcontent" colspan="4">
                                                            <table width="90%">
                                                                <tr>
                                                                    <td class="formcontent" align="left" style="width: 90%;">
                                                                        <span style="color: Red;">
                                                                            <asp:Label ID="lblehgerlifeinscompy" runat="server" Font-Bold="False" Style=""></asp:Label>*</span>
                                                                    </td>

                                                                    <%--comment by Pathamesh 17-6-15--%>
                                                                    <td class="formcontent" align="left" style="width: 10%;">
                                                                        <asp:UpdatePanel ID="UpdPanelrbagnex" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:RadioButtonList ID="rbinsagency" runat="server" CssClass="radiobtn" AutoPostBack="True"
                                                                                    BackColor="#FFFFB2" OnSelectedIndexChanged="rdagnexp_SelectedIndexChanged" RepeatDirection="Horizontal"
                                                                                    TabIndex="197">
                                                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" style="width: 20%">
                                                            <asp:Label ID="lblehnameofcomp" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:UpdatePanel ID="upinscompname" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtInsCompName" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                        Width="152px" TabIndex="198"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender55" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtInsCompName">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lblehlicno" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:UpdatePanel ID="upLcnNo" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLcnNo" runat="server" CssClass="standardtextbox" MaxLength="22"
                                                                        Width="152px" TabIndex="199"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender56" runat="server"
                                                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                        FilterMode="InvalidChars" TargetControlID="txtLcnNo" FilterType="Custom">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" style="width: 20%">
                                                            <asp:Label ID="lblehdateofissue" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:UpdatePanel ID="updateofissue" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<uc7:ctlDate ID="txtdateofissue" runat="server" CssClass="standardtextbox" 
                                                            TabIndex="200" />--%>
                                                                    <asp:TextBox ID="txtdateofissue" runat="server" CssClass="standardtextbox" Width="152"
                                                                        TabIndex="200" />
                                                                    <asp:Image ID="imgtxtdateofissue" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                    <asp:TextBox ID="txtimgtxtdateofissue" runat="server" CssClass="standardtextbox"
                                                                        Style="display: none"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender20" runat="server" TargetControlID="txtdateofissue"
                                                                        PopupButtonID="imgtxtdateofissue" Format="dd/MM/yyyy" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" SetFocusOnError="true"
                                                                        ControlToValidate="txtdateofissue" Enabled="false" ErrorMessage="Mandatory!"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR21" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtdateofissue" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                    <asp:RangeValidator ID="RangeValidator20" runat="server" ControlToValidate="txtdateofissue"
                                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lblehvaliddate" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:UpdatePanel ID="upvaliddate" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<uc7:ctlDate ID="txtvaliddate" runat="server" CssClass="standardtextbox" 
                                                             TabIndex="201" />--%>
                                                                    <asp:TextBox ID="txtvaliddate" runat="server" CssClass="standardtextbox" Width="152"
                                                                        TabIndex="201" />
                                                                    <asp:Image ID="imgtxtvaliddate" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                    <asp:TextBox ID="txtimgtxtvaliddate" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender21" runat="server" TargetControlID="txtvaliddate"
                                                                        PopupButtonID="imgtxtvaliddate" Format="dd/MM/yyyy" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" SetFocusOnError="true"
                                                                        ControlToValidate="txtvaliddate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR22" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtvaliddate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                    <asp:RangeValidator ID="RangeValidator21" runat="server" ControlToValidate="txtvaliddate"
                                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblehagencycode" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%;">
                                                            <asp:UpdatePanel ID="upagtcode" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtInsAgencyCode" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                        Width="152px" TabIndex="202"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender57" runat="server"
                                                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                        FilterMode="InvalidChars" TargetControlID="txtInsAgencyCode" FilterType="Custom">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%;">
                                                            <asp:Label ID="lblehterminationdate" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%;">
                                                            <asp:UpdatePanel ID="upterminatedate" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<uc7:ctlDate ID="txtterminatedate" runat="server" CssClass="standardtextbox" 
                                                             TabIndex="203" />--%>
                                                                    <asp:TextBox ID="txtterminatedate" runat="server" CssClass="standardtextbox" Width="152"
                                                                        TabIndex="203" />
                                                                    <asp:Image ID="imgtxtterminatedate" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                    <asp:TextBox ID="txtimgtxtterminatedate" runat="server" CssClass="standardtextbox"
                                                                        Style="display: none"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender22" runat="server" TargetControlID="txtterminatedate"
                                                                        PopupButtonID="imgtxtterminatedate" Format="dd/MM/yyyy" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" SetFocusOnError="true"
                                                                        ControlToValidate="txtterminatedate" Enabled="false" ErrorMessage="Mandatory!"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR23" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtterminatedate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                                    <asp:RangeValidator ID="RangeValidator22" runat="server" ControlToValidate="txtterminatedate"
                                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" style="width: 20%">
                                                            <asp:Label ID="lblehterreason" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <asp:UpdatePanel ID="upTermination" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtTerminationReason" runat="server" CssClass="standardtextbox"
                                                                        MaxLength="30" Width="152px" TabIndex="204"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender58" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtTerminationReason">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <%--Sales/Marketing/Financial Services Experience -End--%>
                                                    <%--Employee history End--%>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <table class="formtable" style="width: 90%; display: none;">
                                <tr>
                                    <td class="test" colspan="4">
                                        <input runat="server" type="button" class="standardlink" value="+" id="btnView4"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divView4', 'ctl00_ContentPlaceHolder1_btnView4');" />
                                        <asp:Label ID="Label141" Text="Disciplinary Information" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div id="divView4" runat="server" style="display: none; width: 90%;">
                                <table id="Table3" runat="server" class="container" style="width: 100%">
                                    <tr>
                                        <td style="width: 791px" align="center">
                                            <%--Personal Information--%>
                                            <table class="formtable" style="display: none">
                                                <tr>
                                                    <td class="test" colspan="4">
                                                        <input runat="server" type="button" class="standardlink" value="-" id="btnDPersonal"
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivDPersonal', 'ctl00_ContentPlaceHolder1_btnDPersonal');" />
                                                        <asp:Label ID="lblpersonalinformation" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="DivDPersonal" runat="server" style="display: none;">
                                                <table class="tableIsys">
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%;">
                                                            <asp:Label ID="lbldicndidtitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblpcndno" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lbldicategorytitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 501px;">
                                                            <asp:Label ID="lbldicategory" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lbldiappnotitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblpappno" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lbldiregdatetitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblpregdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lbldigivennametitle" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblpgivenname" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lbldisurnametitle" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblpSurname" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%--Personal Information End--%>
                                            <%--Disciplinary Information Start--%>
                                            <table class="formtable" style="display: none;">
                                                <tr>
                                                    <td class="test" align="left" colspan="4">
                                                        <input runat="server" type="button" class="standardlink" value="-" id="btnDisciplinaryInfo"
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divDisciplinaryInfo', 'ctl00_ContentPlaceHolder1_btnDisciplinaryInfo');" />
                                                        <asp:Label ID="lbldidisinformation" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divDisciplinaryInfo" runat="server" style="display: none;">
                                                <table class="tableIsys">
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <asp:Label ID="lbldihybconvicted" runat="server" Font-Bold="False"></asp:Label><span
                                                                style="color: #ff0000">*</span>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:RadioButtonList ID="rbQstn01" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                                BackColor="#FFFFB2" TabIndex="205">
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <span style="color: red">
                                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                                <asp:Label ID="lbldihybsubject" runat="server" Font-Bold="False" Style="color: Black"></asp:Label>*</span>
                                                            <%-- <span style="color: #ff0000">*</span>--%>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:RadioButtonList ID="rbQstn02" runat="server" CssClass="radiobtn" BackColor="#FFFFB2"
                                                                RepeatDirection="Horizontal" TabIndex="206">
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <span style="color: red">
                                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                                <asp:Label ID="lbldihybjudgement" runat="server" Font-Bold="False" Style="color: Black"></asp:Label>*</span>
                                                            <%-- <span style="color: #ff0000">*</span>--%>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:RadioButtonList ID="rbQstn03" runat="server" CssClass="radiobtn" BackColor="#FFFFB2"
                                                                RepeatDirection="Horizontal" TabIndex="207">
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <span style="color: red">
                                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                                <asp:Label ID="lbldihybinsolv" runat="server" Font-Bold="False" Style="color: Black"></asp:Label>*</span>
                                                            <%--<span style="color: #ff0000">*</span>--%>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:RadioButtonList ID="rbQstn04" runat="server" CssClass="radiobtn" BackColor="#FFFFB2"
                                                                RepeatDirection="Horizontal" TabIndex="208">
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <table class="formtable" style="display: none;">
                                                <tr>
                                                    <td class="test" align="left" colspan="4">
                                                        <input runat="server" type="button" class="standardlink" value="+" id="btnReferences"
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divReferences', 'ctl00_ContentPlaceHolder1_btnReferences');" />
                                                        <asp:Label ID="lbldireference" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divReferences" runat="server" style="display: block;">
                                                <table class="tableIsys">
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lblditrefname1" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef1Name" runat="server" CssClass="standardtextbox" MaxLength="60"
                                                                TabIndex="209"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender59" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtRef1Name">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiref1address" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef1Add1" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                                MaxLength="30" TabIndex="210"></asp:TextBox>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiRef1state" runat="server"></asp:Label><span style="color: #ff0000"></span>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtStateCodeR1" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                                Width="50px" MaxLength="3" TabIndex="213"></asp:TextBox>
                                                            <asp:TextBox ID="txtStateDescR1" runat="server" CssClass="standardtextbox" Enabled="False"
                                                                onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="214"></asp:TextBox>
                                                            <asp:Button ID="btnStateR1" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                                Text="..." TabIndex="215" />&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="Label41" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef1Add2" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                                MaxLength="30" TabIndex="211"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender60" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtRef1Add2">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiRef1Pincode" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef1Pin" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                                MaxLength="6" Width="163px" TabIndex="216"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender74" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtRef1Pin" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="Label43" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef1Add3" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                                MaxLength="30" TabIndex="212"></asp:TextBox>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiRef1country" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtCountryCodeR1" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                                Width="50px" MaxLength="3" TabIndex="217"></asp:TextBox>
                                                            <asp:TextBox ID="txtCountryDescR1" runat="server" CssClass="standardtextbox" Enabled="False"
                                                                onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="218"></asp:TextBox>
                                                            <asp:Button ID="btnCountryR1" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                                Text="..." TabIndex="219" />&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiRefname2" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef2Name" runat="server" CssClass="standardtextbox" MaxLength="60"
                                                                TabIndex="220"></asp:TextBox>&nbsp;
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender61" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtRef2Name">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiRef2Add" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef2Add1" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                                MaxLength="30" TabIndex="221"></asp:TextBox>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiRef2State" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtStateCodeR2" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                                Width="50px" MaxLength="3" TabIndex="224"></asp:TextBox>
                                                            <asp:TextBox ID="txtStateDescR2" runat="server" CssClass="standardtextbox" Enabled="False"
                                                                onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="225"></asp:TextBox>
                                                            <asp:Button ID="btnStateR2" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                                Text="..." TabIndex="226" />&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="Label62" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef2Add2" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                                MaxLength="30" TabIndex="222"></asp:TextBox>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiRef2Pincode" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef2Pin" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                                MaxLength="10" Width="163px" TabIndex="227"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender62" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtRef2Pin" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="Label63" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef2Add3" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                                MaxLength="30" TabIndex="223"></asp:TextBox>
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiRef2Country" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtCountryCodeR2" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                                Width="50px" MaxLength="3" TabIndex="228"></asp:TextBox>
                                                            <asp:TextBox ID="txtCountryDescR2" runat="server" CssClass="standardtextbox" Enabled="False"
                                                                onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="229"></asp:TextBox>
                                                            <asp:Button ID="btnCountryR2" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                                Text="..." TabIndex="230" />&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%--Disciplinary Information End--%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <table style="width: 90%; display: none;">
                                <tr>
                                    <td class="test" colspan="4">
                                        <input runat="server" type="button" class="standardlink" value="+" id="btnView5"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divView5', 'ctl00_ContentPlaceHolder1_btnView5');" />
                                        <asp:Label ID="Label15" Text="Business Plan" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div id="divView5" runat="server" style="display: none; width: 90%;">
                                <table id="Table2" runat="server" class="container" style="width: 100%">
                                    <tr>
                                        <td style="width: 791px" align="center">
                                            <table class="formtable" style="display: none">
                                                <tr>
                                                    <td class="test" colspan="4">
                                                        <input runat="server" type="button" class="standardlink" value="-" id="btnBPersonal"
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBPersonal', 'ctl00_ContentPlaceHolder1_btnBPersonal');" />
                                                        <asp:Label ID="lblbppersinftitle" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divBPersonal" runat="server" style="display: none;">
                                                <table class="tableIsys">
                                                    <%--Newly--%>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%;">
                                                            <asp:Label ID="lblbpcndnotitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblbcndno" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblbpcategorytitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 501px;">
                                                            <asp:Label ID="lblbpcategory" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lblbpappnotitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblbappno" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblbpregdatetitle" runat="server" Style="color: black"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblbregdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblbpgivennametitle" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblbgivenname" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblbpsurnametitle" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblbSurname" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%--Three years biz plan Start--%>
                                            <table class="formtable" style="display: none;">
                                                <tr>
                                                    <td class="test" colspan="4">
                                                        <input runat="server" type="button" class="standardlink" value="-" id="btnBusinessPlan"
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBusinessPlan', 'ctl00_ContentPlaceHolder1_btnBusinessPlan');" />
                                                        <asp:Label ID="lblbpEmpHistory1" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divBusinessPlan" runat="server" style="display: block;">
                                                <table class="tableIsys">
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lblbptyear" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lbltnooflives" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lbltsumassured" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:Label ID="lbltfirstyearpremium" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lblbpyear1" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:TextBox ID="txtbusinessplannooflives11" runat="server" CssClass="standardtextbox"
                                                                MaxLength="4" Style="text-align: right" TabIndex="231" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender63" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannooflives11" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:TextBox ID="txtbusinessplansumassured11" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="232" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender64" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplansumassured11" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:TextBox ID="txtbusinessplannfirstyearpremium11" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="233" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender65" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannfirstyearpremium11"
                                                                FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lblbpyear2" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:TextBox ID="txtbusinessplannooflives21" runat="server" CssClass="standardtextbox"
                                                                MaxLength="4" Style="text-align: right" TabIndex="234" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender66" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannooflives21" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:TextBox ID="txtbusinessplannsumassured21" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="235" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender67" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannsumassured21" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:TextBox ID="txtbusinessplannfirstyearpremium21" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="236" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender68" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannfirstyearpremium21"
                                                                FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lblbpyear3" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:TextBox ID="txtbusinessplannooflives31" runat="server" CssClass="standardtextbox"
                                                                MaxLength="4" Style="text-align: right" TabIndex="237" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender69" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannooflives31" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:TextBox ID="txtbusinessplannsumassured31" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="238" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender70" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannsumassured31" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:TextBox ID="txtbusinessplannfirstyearpremium31" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="239" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender71" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannfirstyearpremium31"
                                                                FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <span style="color: red">
                                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                                <asp:Label ID="lblbpwillingtowork" runat="server" Font-Bold="False" Style="color: Black"></asp:Label>*</span>
                                                            <%-- <span style="color: #ff0000">*</span>--%>
                                                        </td>
                                                        <%--<td align="left" class="formcontent">
                                             </td>--%>
                                                        <td align="left" class="formcontent">
                                                            <asp:RadioButtonList ID="rbtimework" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                                BackColor="#FFFFB2" TabIndex="240">
                                                                <asp:ListItem Value="0">Full Time</asp:ListItem>
                                                                <asp:ListItem Value="1">Part Time</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" colspan="4" style="height: 18px">
                                                            <asp:Label ID="lblbpanyotherinformation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" colspan="4">
                                                            <asp:TextBox ID="txtpastachievement" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                Width="773px" MaxLength="100" Rows="3" TabIndex="241"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender72" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtpastachievement">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <span style="color: red">
                                                                <asp:Label ID="lblbpareyourelated" runat="server" Style="color: black" Font-Bold="False"></asp:Label>*</span>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:RadioButtonList ID="rbrelatedemp" runat="server" CssClass="radiobtn" BackColor="#FFFFB2"
                                                                RepeatDirection="Horizontal" TabIndex="242">
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            <asp:Label ID="lblbpifyes" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <asp:TextBox ID="txtrelativeworkdesc" runat="server" CssClass="standardtextbox" Width="575px"
                                                                MaxLength="50" Height="31px" TabIndex="243"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender73" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtrelativeworkdesc">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%--Three years biz plan End--%>
                                            <%--added by Rachana on 17/05/2013 for Interview Details --%>
                                            <%--<table  id="tblint" runat="server" class="formtable2"> 
                                           <tr>
                                             <td class="test" colspan="4" >
                                                 &nbsp;<asp:Label ID="lblInt" runat="server" Text="Interview Details" CssClass="standardtextbox1"></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                               <td class="formcontent" nowrap="nowrap">
                                                   &nbsp;<asp:Label ID="lblCndNo" Text="Candidate No."  runat="server" ></asp:Label>
                                               </td>
                                               <td class="formcontent" width="100%" colspan="3">
                        
                                                    <asp:Label ID="lblCandidateid" runat="server" ></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    &nbsp;<asp:Label ID="lblCndName" Text="Candidate Name" runat="server" ></asp:Label>
                                                </td>
                                                <td class="formcontent" width="100%" colspan="3">
                        
                                                    <asp:Label ID="lblCandidateName" runat="server" ></asp:Label>     
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    &nbsp;<asp:Label ID="lblInterviewerName" Text="Interviewer Name" runat="server" ></asp:Label>
                                                </td>
                                                <td class="formcontent" >
                                                    <asp:TextBox CssClass="standardtextbox" ID="txtInterviewerName" runat="server" 
                                                        Width="209px"></asp:TextBox>
                         
                                                </td>
                                                <td class="formcontent" ><asp:Label ID="lblDate" Text="Date of Interview" runat="server" ></asp:Label>
                                                </td>
                                                 <td class="formcontent" >
                                                    <uc7:ctlDate ID="txtDTRegFrom" runat="server" CssClass="standardtextbox" 
                                                                RequiredField="false" RequiredValidationMessage="Mandatory!" Width="100" />
                     
                                                  </td>
                                             </tr>
                                             <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    &nbsp;<asp:Label ID="lblInterviewerComment" runat="server" ></asp:Label>
                                                </td>
                                                <td class="formcontent" width="100%"  colspan="3">
                                                    <asp:TextBox CssClass="standardtextbox" ID="txtInterviewerComment" 
                                                        runat="server" Height="115px" TextMode="MultiLine" Width="427px"></asp:TextBox>
                                                </td>
                                            </tr>
                                      </table>--%>
                                            <%--End Interview Details--%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="panel" style="margin:0px;">
                                <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div3','btndiv3');return false;">           
                          <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblBusiPln" runat="server" Text="Business Plan" CssClass="control-label" Font-Size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btndiv3" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                          <div id="div3" runat="server" class="panel-body" style="display:block;" >
                              <div class="row rowspacing" >
                                         <div class="col-sm-3" style="text-align:left">
                                       
                                                <asp:Label ID="lblagntype" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="Type of agent"></asp:Label>
                                                     <span style="color: Red;">*</span>
                                     </div>
                                        
                                        <div class="col-sm-3">
                                                      <asp:TextBox ID="lblAgntTypePF" runat="server" CssClass="form-control control-label"   Enabled="false" Style="color: black"  ></asp:TextBox>  
                                       </div>

                                        <%--comment by Pathamesh 17-6-15--%>
<%--                                           <div class="col-sm-3">--%>
                                                     <td>
                                            <asp:UpdatePanel runat="server" ID="updangtype">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlagntype" runat="server" CssClass="form-control" AutoPostBack="true"
                                                       TabIndex="6" OnSelectedIndexChanged="ddlagntype_SelectedIndexChanged" Visible="false">
                                                        <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                        
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            </td>
                                    <%-- </div>--%>
                                         <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="Others" runat="server" CssClass="control-label" Font-Bold="False" Text="From others please specify"></asp:Label>
                                     </div>
                                        
                                         <div class="col-sm-3">
                                            <asp:TextBox ID="lblOthersPF" runat="server" CssClass="form-control control-label"   Enabled="false" Style="color: black"  ></asp:TextBox>  
                                     </div>
                                       <%-- <div class="col-sm-3">--%>
                                       <td>
                                            <asp:UpdatePanel runat="server" ID="updOthers">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtOthers" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                                        MaxLength="30" Width="170px" TabIndex="8" Visible="false"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `0123456789" FilterMode="InvalidChars"
                                                        TargetControlID="txtOthers" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            </td>
                                       <%--</div>--%>
                                   </div>
                                <div class="row rowspacing" >
                                       <div class="col-sm-3" style="text-align:left">
                                          
                                                <asp:Label ID="Label4" runat="server" CssClass="control-label" Font-Bold="False" Text="Is he working with some other Group company"></asp:Label>
                                                  <span style="color: Red;">*</span>
                                </div>
                                      <%--  <td>
                                            <asp:Label ID="lblIsWrkngPF" runat="server"></asp:Label>
                                        </td>--%>
                                                <div class="col-sm-3">
                                                      <asp:TextBox ID="lblIsWrkngPF" runat="server" CssClass="form-control control-label"   Enabled="false"  ></asp:TextBox>  
                                       </div>

                                        <%--comment by Pathamesh 17-6-15--%>
                                       <td>
                                            <asp:UpdatePanel runat="server" ID="updIsWrkng">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlIsWrkng" runat="server" AutoPostBack="true" CssClass="form-control"
                                                        OnSelectedIndexChanged="ddlIsWrkng_SelectedIndexChanged" Width="170px" TabIndex="6" Visible="false">
                                                        <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Y"> </asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                     </td>
                                    <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblcompName" runat="server" Style="color: black" CssClass="control-label" Font-Bold="False"
                                                Text="If yes, company name"></asp:Label>
                                     </div>
                                          <div class="col-sm-3">
                                                      <asp:TextBox ID="lblcompNamePF" runat="server" CssClass="form-control control-label"   Enabled="false"  ></asp:TextBox>  
                                                   </div>
                                                           <td>
                                            <asp:UpdatePanel runat="server" ID="updcompName">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlcompName" runat="server" CssClass="form-control" Width="170px"
                                                        TabIndex="6" Visible="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                     </td>
                                 </div>
                                   <div class="row rowspacing" >
                                     <div class="col-sm-3" style="text-align:left">
                                        
                                                <asp:Label ID="lblNoOfYrsInsurance" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="No. of years in insurance"></asp:Label>
                                                    <span style="color: Red;">*</span>
                                      </div>
                                           <div class="col-sm-3">
                                                      <asp:TextBox ID="lblNoOfYrsInsurancePF" runat="server" CssClass="form-control control-label"   Enabled="false" ></asp:TextBox>  
                                       </div>
                                      <td>
                                            <asp:UpdatePanel runat="server" ID="updNoOfYrsIns">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNoOfYrsIns" runat="server" CssClass="form-control"
                                                        TabIndex="6" Visible="false">
                                                        <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                </td>
                                   <div class="col-sm-3" style="text-align:left">
                                           
                                                <asp:Label ID="lblNoOfYrs" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="No. of years with company"></asp:Label>
                                                 <span style="color: Red;">*</span>
                                   </div>
                              <div class="col-sm-3">
                                                      <asp:TextBox ID="lblNoOfYearsPF" runat="server" CssClass="form-control control-label"   Enabled="false" ></asp:TextBox>  
                                  </div>
                                        <td>
                                            <asp:UpdatePanel runat="server" ID="updNoOfYrs">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNoOfYrs" runat="server" CssClass="form-control"
                                                        TabIndex="6" Visible="false">
                                                        <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                               </td>
                                  </div>
                                 <div class="row rowspacing" >
                                       <div class="col-sm-3" style="text-align:left">
                                       
                                                <asp:Label ID="lblTypeOfVehicle" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="If Dealer, type of vehicle dealing in"></asp:Label>
                                                     <span style="color: Red;">*</span>
                                       </div>
                                            <div class="col-sm-3">
                                                      <asp:TextBox ID="lblTypeOfVehiclePF" runat="server" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>  
                                       </div>
                                         <td>
                                            <asp:UpdatePanel runat="server" ID="updTypeOfvehicle">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTypeOfVehicle" runat="server" CssClass="form-control"
                                                        TabIndex="6" Visible="false">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </td>
                                      <div class="col-sm-3" style="text-align:left">
                                      
                                                <asp:Label ID="lblVchlManf" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="If Dealer, vehicle manufacturer dealing with"></asp:Label>
                                                      <span style="color: Red;">*</span>
                                 </div>
                                         <div class="col-sm-3">
                                                      <asp:TextBox ID="lblVchlManfPF" runat="server" CssClass="form-control control-label"   Enabled="false" ></asp:TextBox>  
                                    </div>
                                     <td>
                                            <asp:UpdatePanel runat="server" ID="updVechManuf">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlVechManuf" runat="server" CssClass="form-control"
                                                        TabIndex="6" Visible="false">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                   </td>
                                    </div>
                                  <div class="row rowspacing" >
                                      <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblDlrCompName" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="Company  Name"></asp:Label>
                                                     <span style="color: Red;">*</span>
                                    </div>
                                           <div class="col-sm-3">
                                                 <asp:TextBox ID="lblDlrCompNamePF" runat="server" CssClass="form-control control-label"   Enabled="false" ></asp:TextBox>  
                                        </div>
                                          <td>
                                            <asp:UpdatePanel runat="server" ID="updDlrCompName">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtDlrCompName" runat="server" Enabled="false"  CssClass="form-control control-label"
                                                        onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="30" 
                                                        TabIndex="8"  Visible="false"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `0123456789" FilterMode="InvalidChars"
                                                        TargetControlID="txtDlrCompName" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </td>
                                            <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblDlrOth" runat="server" CssClass="control-label" Font-Bold="False" Text="From others please specify"></asp:Label>
                                   </div>
                                        <div class="col-sm-3">
                                                      <asp:TextBox ID="lblDlrOthPF" runat="server" CssClass="form-control control-label"   Enabled="false" ></asp:TextBox>  
                                          </div>
                                   <td>
                                            <asp:UpdatePanel runat="server" ID="updDlrOth">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtDlrOth" runat="server" Enabled="false" CssClass="form-control control-label"
                                                        onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="30" 
                                                        TabIndex="8" Visible="false"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `0123456789" FilterMode="InvalidChars"
                                                        TargetControlID="txtDlrOth" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                     </td>
                              </div>
                                    </div>
                                 </div>    
                                     
                            <div class="panel" style="margin:0px;"> 
                                    <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPotential','btnPotential');return false;">           
                          <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label13" runat="server" Text="Potential of agent"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnPotential" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                          <div id="divPotential" runat="server" class="panel-body" style="display:block;" >
                                     <div class="row rowspacing" >
                                         <div class="col-sm-3" style="text-align:left">
                                           
                                                <asp:Label ID="Label14" runat="server" CssClass="control-label" Font-Bold="False" Text="Avg. monthly volume in Lacs"></asp:Label>
                                                <span style="color: Red;">*</span>
                                      </div>
                                       
                                               <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updAvgMonthlyIncm">
                                                <ContentTemplate>
                                             <asp:TextBox ID="lblAvgVolInLacsPF" runat="server" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>  
                                            <asp:DropDownList ID="ddlAvgMonthlyIncm" runat="server" CssClass="form-control"
                                                        TabIndex="6" Visible="false" >
                                                        <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                    
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                     </div>
                                        <div class="col-sm-3" style="text-align:left">
                                       </div>
                                      <div class="col-sm-3">
                                     </div>
                                  </div>
                                     </div>
                                      </div>
                                         
                            <div class="panel" style="margin:0px;">
                              <div id="Div7" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCompetitor','btnCompetitor');return false;">           
                          <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label20" runat="server" Text="Competitor company working with"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnCompetitor" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                          <div id="divCompetitor" runat="server" class="panel-body" style="display:block;" >
                                 <div class="row rowspacing" >
                                        <div class="col-sm-3" style="text-align:left">
                                           
                                                <asp:Label ID="lblComp1Name" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="Company 1 name"></asp:Label>
                                                 <span style="color: Red;">*</span>
                                  </div>
                                        <%-- <td class="formcontent" style="width: 30%;">
                                                      <asp:Label ID="lblComp1NamePF" runat="server" Style="color: black"  ></asp:Label>  
                                         </td>--%>
                                           <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updComp1Name">
                                                <ContentTemplate>
                                             <asp:TextBox ID="lblComp1NamePF" runat="server" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>  
                                                    <asp:DropDownList ID="ddlComp1Name" runat="server" CssClass="form-control"
                                                        TabIndex="6" Visible="false">
                                                        <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                           <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblMnthVol1" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="Monthly volume in Lacs"></asp:Label>
                                                 <span style="color: Red;">*</span>
                                       </div>

                                         <%--<td class="formcontent" style="width: 30%;">
                                                      <asp:Label ID="lblMnthVol1PF" runat="server" Style="color: black"  ></asp:Label>  
                                          </td>--%>
                                            <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updMnthVol1">
                                                <ContentTemplate>
                                             <asp:TextBox ID="lblMnthVol1PF" runat="server" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>  
                                                    <asp:DropDownList ID="ddlMnthVol1" runat="server" CssClass="form-control"
                                                        TabIndex="6" Visible="false">
                                                        <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>
                                    </div>
                                   <div class="row rowspacing" >
                                    <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblComp2Name" runat="server" CssClass="control-label" Font-Bold="False"
                                                Text="Company 2 name"></asp:Label>
                                    </div>
                                         <%--<td class="formcontent" style="width: 30%;">
                                                      <asp:Label ID="lblComp2NamePF" runat="server" Style="color: black"  ></asp:Label>  
                                          </td>--%>
                                               <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updComp2Name">
                                                <ContentTemplate>
                                             <asp:TextBox ID="lblComp2NamePF" runat="server" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>  
                                                    <asp:DropDownList ID="ddlComp2Name" runat="server" CssClass="form-control"
                                                        TabIndex="6" Visible="false">
                                                        <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                     </div>
                                        <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblMnthVol2" runat="server" CssClass="control-label" Font-Bold="False"
                                                Text="Monthly volume in Lacs"></asp:Label>
                                     </div>
                                       <%--  <td class="formcontent" style="width: 30%;">
                                                      <asp:Label ID="lblMnthVol2PF" runat="server" Style="color: black"  ></asp:Label>  
                                         </td>--%>
                                           <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updMnthVol2">
                                                <ContentTemplate>
                                             <asp:TextBox ID="lblMnthVol2PF" runat="server" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>  
                                                    <asp:DropDownList ID="ddlMnthVol2" runat="server" CssClass="form-control"
                                                        TabIndex="6" Visible="false">
                                                        <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                       </div>
                                </div>
                                          </div>
                                          </div>
                                             
                            <div class="panel" style="margin:0px;">
                                            <div id="Div8" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBusiness','btnBusiness');return false;">           
                          <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label21" runat="server" Text="Business volume with Group Company"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnBusiness" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                          <div id="divBusiness" runat="server" class="panel-body" style="display:block;" >
                                      <div class="row rowspacing" >
                                        <div class="col-sm-3" style="text-align:left">
                                           
                                                <asp:Label ID="lblRGIMnthVol" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="Monthly volume in Lacs"></asp:Label>
                                                <span style="color: Red;">*</span>
                                    </div>
                                       <%--  <td class="formcontent" style="width: 30%;">
                                                      <asp:Label ID="lblRGIMnthVolPF" runat="server" Style="color: black"  ></asp:Label>  
                                         </td>--%>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updRGIMnthVol">
                                                <ContentTemplate>
                                                  &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                             <asp:TextBox ID="lblRGIMnthVolPF" runat="server" CssClass="form-control"   Enabled="false" Style=""></asp:TextBox>  
                                                    <asp:DropDownList ID="ddlRGIMnthVol" runat="server" CssClass="form-control"
                                                        TabIndex="6" Visible="false">
                                                        <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                         <div class="col-sm-3" style="text-align:left">
                                       </div>
                                         <div class="col-sm-3">
                                        </div>
                                 </div>
                                    </div>
                                            </div>
                                               
                            <div class="panel" style="margin:0px;">
                                 <div id="Div18" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divProduct','btnProduct');return false;"> 
                           <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblPrdMxAgn" runat="server" Text="Product mix of agent"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnProduct" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>     <%-- panel-body panel-collapse collapse in  --%>               <%--panel-heading subheader--%>
                </div>
                     <div id="divProduct" runat="server" class="panel-body" style="display:block;" >
                      <div id="div20">
                           <div class="panel"> 
                                  <div id="Div19" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divTotalbuisness','btnTotalbuisness');return false;"
                      style="background-color:#ffffff !important">   
                       <div class="row rowspacing">
                    <div class="col-sm-9" style="text-align:left">
                     <asp:Label ID="Label22" runat="server" Text="Total Business"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-3">
                        <span id="btnTotalbuisness" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>      
                    </div>        
                          </div>    
                        <div id="divTotalbuisness" runat="server" class="panel-body" style="display:block;" >
                                               <div class="row rowspacing" >
                                                 <div class="col-md-2" style="text-align:left">
                                                            <asp:Label ID="lblTotBsnMtr" runat="server" CssClass="control-label" Font-Bold="False"
                                                                Text="Motor (in percentage)"></asp:Label>
                                                              <span style="color: Red;">*</span>
                                                 </div>
                                                     
                                                     <%--<td class="formcontent" style="width: 30%;">
                                                      <asp:Label ID="lblTotBsnMtrPF" runat="server" Style="color: black"  ></asp:Label>  
                                                     </td>--%>
                                                     <div class="col-md-2">
                                                        <asp:UpdatePanel runat="server" ID="updTotBsnMtr">
                                                            <ContentTemplate>
                                                             <asp:TextBox ID="lblTotBsnMtrPF" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>  
                                                                <asp:DropDownList ID="ddlTotBsnMtr" runat="server" CssClass="form-control"
                                                                    TabIndex="6" Visible="false">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                 </div>
                                                 <div class="col-md-2" style="text-align:left">
                                                      
                                                            <asp:Label ID="lblTotBsnHlth" runat="server" CssClass="control-label" Font-Bold="False"
                                                                Text="Health (in percentage)"></asp:Label>
                                                              <span style="color: Red;">*</span>
                                                  </div>
                                                    <%-- <td class="formcontent" nowrap="nowrap" style="width: 10%; padding-top: 5px; padding-bottom: 5px;">
                                                       
                                                            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                            <ContentTemplate>
                                                              &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                                             <asp:Label ID="Label2" runat="server" Style=""></asp:Label>  
                                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="standardmenu" Width="170px"
                                                                    TabIndex="6" Visible="false">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>--%>
                                                     
                                                     <%--<td class="formcontent" style="width: 30%;">
                                                      <asp:Label ID="lblTotBsnHlthPF" runat="server" Style="color: black"  ></asp:Label>  
                                                     </td--%>
                                                   <%-- <caption>
                                                        &gt;
                                                        <tr>--%>
                                                                <div class="col-md-2">
                                                                <asp:UpdatePanel ID="updddlTotBsnHlth" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="lblTotBsnHlthPF" runat="server" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>
                                                                        <asp:DropDownList ID="ddlTotBsnHlth" runat="server" CssClass="form-control"
                                                                            TabIndex="6" Visible="false" >
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                                    <div class="col-md-2" style="text-align:left">
                                                               
                                                                <asp:Label ID="lblTotBsnComm" runat="server" Font-Bold="False" 
                                                                  CssClass="control-label" Text="Commercial line (in percentage)"></asp:Label>
                                                                 <span style="color: Red;">*</span>
                                                                </div>
                                                                 <div class="col-md-2">
                                                                 <asp:UpdatePanel ID="updddlTotBsnComm" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="lblTotBsnCommPF" runat="server" CssClass="form-control control-label"   Enabled="false" ></asp:TextBox>
                                                                        <asp:DropDownList ID="ddlTotBsnComm" runat="server" CssClass="form-control"
                                                                            TabIndex="6" Visible="false" >
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>

                                                            </td>
                                                            <%-- <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblTotBsnCommPF" runat="server" Style="color: black"></asp:Label>
                                                        </td>--%>
                                                           <%-- <td align="left" class="formcontent" 
                                                                style="width: 20%; padding-top: 5px; padding-bottom: 5px;">
                                                                <asp:UpdatePanel ID="updddlTotBsnComm" runat="server">
                                                                    <ContentTemplate>
                                                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                                                        <asp:Label ID="lblTotBsnCommPF" runat="server" Style=""></asp:Label>
                                                                        <asp:DropDownList ID="ddlTotBsnComm" runat="server" CssClass="standardmenu" 
                                                                            TabIndex="6" Visible="false" Width="170px">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>--%>
                                                       
                        </div>
                           </div>
                           </div>
                           </div>
                              
                                <div class="panel"> 
                                                     <div id="Div21" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divBuisnessRGI','btnBuisnessRGI');return false;"
                     style="background-color:#ffffff !important"> 
                       <div class="row rowspacing">
                    <div class="col-sm-9" style="text-align:left">
                     <asp:Label ID="Label23" runat="server" Text="Business with Group Company"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-3">
                        <span id="btnBuisnessRGI" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>      
                    </div>  
                    </div>
                                                    <%--<td  align="left" colspan="6" >
                        <asp:Label ID="lblBsnRGI" style="padding-left:20px" ForeColor="White" runat="server" Text="Business With RGI"  ></asp:Label>
                      </td>--%>
                        <div id="divBuisnessRGI" runat="server" class="panel-body" style="display:block;" >
                                 <div class="row rowspacing" >
                                          <div class="col-md-2" style="text-align:left">
                                                        
                                                            <asp:Label ID="lblRGIBsnMtr" runat="server" CssClass="control-label" Font-Bold="False"
                                                                Text="Motor (in percentage)"></asp:Label>
                                                            <span style="color: Red;">*</span>
                                           </div>
                                             <div class="col-md-2">
                                                      <asp:TextBox ID="lblRGIBsnMtrPF" runat="server" CssClass="form-control control-label"   Enabled="false" ></asp:TextBox>  
                                                                                                     
                                                        <asp:UpdatePanel runat="server" ID="updRGIBsnMtr">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlRGIBsnMtr" runat="server" CssClass="form-control"
                                                                    TabIndex="6" Visible="false">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                              </div>
                                             <div class="col-md-2" style="text-align:left">
                                                            <asp:Label ID="lblRGIBsnHlth" runat="server" CssClass="control-label" Font-Bold="False"
                                                                Text="Health (in percentage)"></asp:Label>
                                                            <span style="color: Red;">*</span>
                                                </div>
                                                      <div class="col-md-2">
                                                      <asp:TextBox ID="lblRGIBsnHlthPF" runat="server" CssClass="form-control control-label"   Enabled="false"></asp:TextBox>  
                                                    
                                                        <asp:UpdatePanel runat="server" ID="updddlRGIBsnHlth">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlRGIBsnHlth" runat="server" CssClass="form-control"
                                                                    TabIndex="6" Visible="false">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                </div>
                                                        <div class="col-md-2" style="text-align:left">
                                                     
                                                            <asp:Label ID="lblRGIBsnComm" runat="server" CssClass="control-label" Font-Bold="False"
                                                                Text="Commercial line (in percentage)"></asp:Label>
                                                               <span style="color: Red;">*</span>
                                                  </div>
                                                   <div class="col-md-2">
                                                      <asp:TextBox ID="lblRGIBsnCommPF" runat="server" CssClass="form-control control-label"   Enabled="false" ></asp:TextBox>  
                                                   
                                                        <asp:UpdatePanel runat="server" ID="updddlRGIBsnComm">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlRGIBsnComm" runat="server" CssClass="form-control"
                                                                    TabIndex="6" Visible="false">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                  </div>
                                                  </div>
                        </div>
                                </div>
                         </div>
                     </div>
                               </div>
                            
                            <%--pranjali removed--%>
                      
                        </div>
                    <%--2-Profiling section end--%>


                <%--added by Prathamesh for Profiling tab 16-6-15 end--%>
                    <%--Trainig and Exam Details start--%>
                     <div id="menu3" class="tab-pane fade" >
                   
                     <div id="tbltrainingdtls" runat="server" style="margin:0px;">
                     <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTrnDtls','btnTrn');return false;">           
                          <div class="row rowspacing" id="tblTraining" runat="server" visible="false">
                   <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblTrndetails" runat="server" Text="Training Details" CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnTrn" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                
                      <div id="divTrnDtls" runat="server" style="display:block;" >
                       <%--<table runat="server" id="TrnTbl" class="tableIsys" style="width: 100%; ">
                          
                         </table>--%><div class="card PanelInsideTab">
                          <div id="trntblper" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divtblper','btntblper');return false;"
                         style="background-color:#ffffff !important">           
                          <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblqfpersonalinformation1" runat="server" CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btntblper" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                         <div id="divtblper" runat="server" class="panel-body" style="display:block;">
                            <div class="row rowspacing"  >
                         <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblqfcndnotitle1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         
                         <asp:TextBox ID="lblcndidDesc1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                          <div class="col-sm-4" style="text-align:left">
                            <asp:Label ID="lblCndUrn2" runat="server" CssClass="control-label" Enabled="false" > 
                            </asp:Label>
                          
                         <asp:TextBox ID="lblCndUrnDesc1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                         <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblqfappnotitle1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                        
                         <asp:TextBox ID="lblpfappnoDesc1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                         </div>
                 
                  <div class="row rowspacing"  >
                       <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblqfregdatetitle1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="lblpfregdateDesc1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblqfgivennametitle1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="lblpfgivenNameDesc1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblqfsurname1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="lblpfSurNameDesc1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                  </div>
                        </div>
                        </div>
                        
                        <div class="card PanelInsideTab" style="margin-bottom:16px;">
                      <div id="trntbl" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divtrn','btntrn');return false;"
                         style="background-color:#ffffff !important">           
                          <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblTrndetails1" runat="server" CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btntrn" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                     <div id="divtrn" runat="server" class="panel-body" style="display:block;">
                          <div class="row rowspacing"  >
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblTrnMode1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         
                         <asp:TextBox ID="TrnMode1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblTrnLoc1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="TrnLocDesc1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                                <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblTrnInstitute1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="TrnInstitute2" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                  </div>
                  
                  <div class="row rowspacing"  >
                       <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblAccrdtn1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="AccrdNo1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblTrnstrtDate1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="TrnStartDate1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblTrnEndDate1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="TrnEndDate1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                  </div>
                  <div class="row rowspacing"  >
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblHrnTrn1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="HrsTrn1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                             
                  </div>
                     </div>
                     <div>
                   </div>
                   </div>
                  
                    </div>

                     </div>
                    </div>
                    <%--Trainig and Exam Details end--%>
                     <div id="menu4" class="tab-pane fade" >
                   
                      <div id="tblexm" runat="server" style="margin:0px;"> 
                       <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divExamDtls','btnExam');return false;">       
                       <div class="row rowspacing" id="tblExam" runat="server" visible="false">
                   <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblexmdetails" runat="server" Text="Exam Details" CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnExam" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                  </div>
                      <div id="divExamDtls" runat="server" style="display:block;" >
                        <div class="card PanelInsideTab">
                      <div  id="trntblper1" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div9','Span1');return false;"
                         style="background-color:#ffffff !important">           
                          <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblqfpersonalinformation2" runat="server" Text=" Personal Details" Font-Size="19px" CssClass="control-label" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                     <div id="div9" runat="server" class="panel-body" style="display:block;">
                           
                            
                            <div class="row rowspacing"  >
                         <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblqfcndnotitle2" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="lblcndidDesc2" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                          <div class="col-sm-4" style="text-align:left">
                            <asp:Label ID="lblCndUrn1" runat="server" Text="URN No." CssClass="control-label" Enabled="false" > 
                            </asp:Label>
                         
                         <asp:TextBox ID="lblCndUrnDesc2" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                         <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblqfappnotitle2" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="lblpfappnoDesc2" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                         </div>
                 
                  <div class="row rowspacing"  >
                      <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblqfregdatetitle2" runat="server" Text="Registration Date" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                        
                         <asp:TextBox ID="lblpfregdateDesc2" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblqfgivennametitle2" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="lblpfgivenNameDesc2" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblqfsurname2" runat="server" Text="Surname" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="lblpfSurNameDesc2" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                  </div>
                  
                            </div>             
                            </div>  
                           
                              <div class="card PanelInsideTab">
                      <div  id="exmtbl" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div11','Span2');return false;"style="background-color:#ffffff !important;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblexmdetails1" runat="server" Text=" Exam Details" Font-Size="19px"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="Span2" class="glyphicon glyphicon-chevron-down" style="float: right;padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                     <div id="div11" runat="server" class="panel-body" style="display:block;">
                                     
                           
                          <div class="row"  >
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblSystemDt1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="SystemExmDt1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblCreatDt1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="CreateDtim1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblpreffDt11" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="PreffExmDt11" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                  </div>
                  
                  <div class="row rowspacing"  >
                      <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblSAPCode1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="Agent_SAPCODE1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblpreffDt2" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="PreffExmDt2" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblExmLang1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="ExamLanguage1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                  </div>
                  <div class="row rowspacing"  >
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblExmStrtTime1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="ExmStartTime1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left" >
                          <asp:Label ID="lblExmVenue1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                 <asp:TextBox ID="TrnInstitute" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                       <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblExmResult1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="ExmResult1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                  </div>
                   
                  <div class="row rowspacing"  >
                       <div class="col-sm-4" style="text-align:left" >
                          <asp:Label ID="lblExmAssStat1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                 <asp:TextBox ID="ExmAssStatus1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblRemarks1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="Remarks" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left" >
                          <asp:Label ID="lblRollNo1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                 <asp:TextBox ID="RollNumber1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                  </div>
                    <div class="row rowspacing"  >
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblExmMark1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="ExmMarks1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left" >
                          <asp:Label ID="lblExmMode1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                        
                 <asp:TextBox ID="ExmMode1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                        <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblExmCenter1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="TrnInstitute1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                  </div>
                  
      <div class="row rowspacing"  >
          <div class="col-sm-4" style="text-align:left" >
                          <asp:Label ID="lblRecruiterName1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                 <asp:TextBox ID="RecruitAgtName1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                     <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblToken1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                         <asp:TextBox ID="FeesTokenNo1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                              <div class="col-sm-4" style="text-align:left" >
                          <asp:Label ID="lblFees1" runat="server" CssClass="control-label" Enabled="false" > 
                          </asp:Label>
                 <asp:TextBox ID="TotalFees1" runat="server" CssClass="form-control control-label"  Enabled="false"></asp:TextBox>
                         </div>
                  </div>
                     </div>
                        </div>
                      
                     </div>  
                      </div>
                    </div>        
                      <%--Exam details section end  --%>
                   
                   
                    <%--NOC View Start by Nikhil on 09.10.15--%>
                     <div id="menu5" class="tab-pane fade " >
                   <div class="panel" id="tbNOC" runat="server" visible="false" style="margin:0px;"> 
                    <div id="tbNOCDtls" runat="server"  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNOC','btnNC');return false;">       
                       <div class="row rowspacing" id="Div10" runat="server">
                   <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblNOCDtls" runat="server" Text="NOC Candidate Details" CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnNC" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                  </div>
                      <div id="divNOC" runat="server" class="panel-body" style="display:block;" >
                      <div class="row rowspacing"  id="trCnd" runat="server">
                      <div class="col-sm-3" style="text-align:left;"> 
                         <asp:Label ID="lblCndNo" runat="server" Text="Candidate No" CssClass="control-label"  ></asp:Label>
                                                 
                      </div>
                       <div class="col-sm-3">
                        <asp:TextBox ID="lblCndNoValue" runat="server" Enabled="false" CssClass="form-control control-label"  ></asp:TextBox>
                      </div>
                       <div class="col-sm-3" style="text-align:left;">
                           <asp:Label ID="lblCndName" runat="server" Text="Candidate Name" CssClass="control-label"  ></asp:Label>
                                                
                      </div>
                       <div class="col-sm-3">
                        <asp:TextBox ID="lblCndNameValue" runat="server" Enabled="false" CssClass="form-control control-label"></asp:TextBox>
                      </div>
                      </div>
                      <div class="row rowspacing"  id="trAgency" runat="server">
                       <div class="col-sm-3" style="text-align:left;">
                         <asp:Label ID="Label2" runat="server" Text="Agency Code" CssClass="control-label"  ></asp:Label>
                                                 
                      </div>
                       <div class="col-sm-3">
                        <asp:TextBox ID="lblagencycodeValue" runat="server" Enabled="false" CssClass="form-control control-label"  ></asp:TextBox>
                      </div>
                       <div class="col-sm-3" style="text-align:left;">
                           <asp:Label ID="lbldateissue" runat="server" Text="Date of Issue of Appointment" CssClass="control-label"  ></asp:Label>
                                                
                      </div>
                       <div class="col-sm-3">
                        <asp:TextBox ID="lbldateissuevalue" runat="server" Enabled="false" CssClass="form-control control-label"></asp:TextBox>
                      </div>
                      </div>
                        <div class="row rowspacing"  id="trdos" runat="server">
                         <div class="col-sm-3" style="text-align:left;">
                         <asp:Label ID="lbldos" runat="server" Text="Date of Submission" CssClass="control-label"  ></asp:Label>
                                                 
                      </div>
                       <div class="col-sm-3">
                        <asp:TextBox ID="lbldate" runat="server" Enabled="false" CssClass="form-control control-label"  ></asp:TextBox>
                      </div>
                       <div class="col-sm-3" style="text-align:left;">
                           <asp:Label ID="lbldoa" runat="server" Text="Date of acceptance of resignation" CssClass="control-label"  ></asp:Label>
                                                
                      </div>
                       <div class="col-sm-3">
                        <asp:TextBox ID="lbldoar" runat="server" Enabled="false" CssClass="form-control control-label"></asp:TextBox>
                      </div>
                      </div>
                       <div class="row rowspacing"  id="trreasontext" runat="server">
                         <div class="col-sm-3" style="text-align:left;">
                         <asp:Label ID="lblselect" runat="server" Text="Type of Reason for NOC"  CssClass="control-label"  ></asp:Label>
                                                 
                      </div>
                       <div class="col-sm-3">
                        <asp:TextBox ID="lblsnlve" runat="server"  Enabled="false" CssClass="form-control control-label"  ></asp:TextBox>
                      </div>
                       <div class="col-sm-3" style="text-align:left;">
                           <asp:Label ID="lblreasontext" runat="server" Text="Remark of Reason for NOC"  CssClass="control-label"  ></asp:Label>
                                                
                      </div>
                       <div class="col-sm-3">
                        <asp:TextBox ID="txtreasonleave" runat="server" Rows="4"  TextMode="multiline"  Enabled="false" CssClass="form-control control-label"></asp:TextBox>
                      </div>
                      </div>
                  
                       <div class="row rowspacing"  id="trInsurer" runat="server">
                         <div class="col-sm-3" style="text-align:left;">
                         <asp:Label ID="lblremark" runat="server" Text="Remark of Insurer" CssClass="control-label"  ></asp:Label>
                                                 
                      </div>
                       <div class="col-sm-3">
                        <asp:TextBox ID="txtReInsurer" runat="server" Rows="4" CssClass="form-control control-label"  ></asp:TextBox>
                      </div>
                       <div class="col-sm-3" style="text-align:left;">
                                                
                      </div>
                       <div class="col-sm-3">
                        
                      </div>
                      </div>
                      </div>
                          </div>
                 
              
                    </div>
                    <%--NOC View Ended by Nikhil on 09.10.15--%>

               <%--   added by sanoj 22062023 Dispatch details--%>
                <div id="menu6" class="tab-pane fade" >

                     <div id="tbldispatchdtls" runat="server" class="card PanelInsideTab" width="100%">
                          <div id="Div12" runat="server"  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divDispatch','btnDispatch');return false;">       
                       <div class="row rowspacing" id="Div13" runat="server">
                   <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label27" runat="server" Text="Dispatch Details" CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnDispatch" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                  </div>
                         <div id="divDispatch" runat="server" class="panel-body" style="display:block;" >
                              <div class="row rowspacing"  runat="server">
                                  <div class="col-sm-4" style="text-align:left;">
                            <asp:Label ID="lblRefNo" runat="server" Text="Reference No" CssClass="control-label" ></asp:Label>
                            <asp:Label ID="lblRefNoValue" CssClass="form-control control-label" Enabled="false" runat="server" ></asp:Label>
                                                 
                         </div>
                                  <div class="col-sm-4" style="text-align:left;">
                                       <asp:Label ID="lblRefName" runat="server" Text="Reference Name" CssClass="control-label"    ></asp:Label>
                                                
                                                   <asp:Label ID="lblRefNameValue" runat="server" CssClass="form-control control-label" Enabled="false"></asp:Label>          
                      </div>
                                  <div class="col-sm-4" style="text-align:left;">
                                       <asp:Label ID="lblCover" runat="server" Text="Cover Note" CssClass="control-label"   ></asp:Label>
                                                
                                                     <asp:Label ID="lblCoverValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                        
                      </div>
                             </div>

                              <div class="row rowspacing"  runat="server">
                           <div class="col-sm-4" style="text-align:left;">
                        <asp:Label ID="lblDocNo" runat="server" Text="Document No"  CssClass="control-label" ></asp:Label>
                                               
                                                   <asp:Label ID="lblDocNoValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                                                 
                         </div>
                           <div class="col-sm-4" style="text-align:left;">
                               <asp:Label ID="lblReqType" runat="server" Text="Request Type" CssClass="control-label"></asp:Label>
                                                
                                                     <asp:Label ID="lblReqTypeValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>                 
                      </div>
                           <div class="col-sm-4" style="text-align:left;">
                        <asp:Label ID="lblDocType" runat="server" Text="Type of Document" CssClass="control-label" ></asp:Label>
                                               
                                                   <asp:Label ID="lblDocTypeValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                      </div>
                      </div>
                              <div class="row rowspacing"  runat="server">
                           <div class="col-sm-4" style="text-align:left;">
                        <asp:Label ID="lblDispDate" runat="server" Text="Dispatch Date" CssClass="control-label"></asp:Label>
                                               
                                                     <asp:Label ID="lblDispDateValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                                                 
                         </div>
                           <div class="col-sm-4" style="text-align:left;">
                               <asp:Label ID="lblDispBy" runat="server" Text="Dispatch By" CssClass="control-label" ></asp:Label>
                                              
                                                   <asp:Label ID="lblDispByValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>                  
                      </div>
                           <div class="col-sm-4" style="text-align:left;">
                        <asp:Label ID="lblCourier" runat="server" Text="Courier AWB No" CssClass="control-label"></asp:Label>
                                              
                                                     <asp:Label ID="lblCourierValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                      </div>
                      </div>
                              <div class="row rowspacing"  runat="server">
                           <div class="col-sm-4" style="text-align:left;">
                         <asp:Label ID="lblDelivery" runat="server" Text="Delivery Status" CssClass="control-label" ></asp:Label>
                                              
                                                   <asp:Label ID="lblDeliveryValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                                                 
                         </div>
                           <div class="col-sm-4" style="text-align:left;">
                                   <asp:Label ID="lblReceivedBy" runat="server" Text="Received By" CssClass="control-label"></asp:Label>
                                               
                                                     <asp:Label ID="lblReceivedByValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>              
                      </div>
                           <div class="col-sm-4" style="text-align:left;">
                         <asp:Label ID="lblRTO" runat="server" Text="Delivery / RTO" CssClass="control-label" ></asp:Label>
                                                
                                                   <asp:Label ID="lblRTOValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                      </div>
                      </div>
                              <div class="row rowspacing"  runat="server">
                                   <div class="col-sm-4" style="text-align:left;">
                       
                                  <asp:Label ID="lblRTOReason" runat="server" Text="RTO Reason" CssClass="control-label"></asp:Label>
                                                
                                                     <asp:Label ID="lblRTOReasonValue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>               
                         </div>
                        
                                    <div class="col-sm-4" style="text-align:left;">
                        <asp:Label ID="lblUpdDate" runat="server" Text="Updated Date" CssClass="control-label"></asp:Label>
                                              
                                                     <asp:Label ID="lblUpdDatevalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                      </div>
                                    <div class="col-sm-4" style="text-align:left;">
                            <asp:Label ID="lblFileBarCode" runat="server" Text="File Bar Code No." CssClass="control-label" ></asp:Label>
                                                
                                                   <asp:Label ID="lblFileBarCodevalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                                                 
                         </div>
                      </div>
                              <div class="row rowspacing"  runat="server">
                         
                           <div class="col-sm-4" style="text-align:left;">
                                        <asp:Label ID="lblBoxbarCode" runat="server" Text="BoxBar Code" CssClass="control-label"></asp:Label>
                                             
                                                     <asp:Label ID="lblBoxbarCodevalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>            
                      </div>
                           <div class="col-sm-4" style="text-align:left;">
                         <asp:Label ID="lblArchivalDt" runat="server" Text="Archival Date" CssClass="control-label" ></asp:Label>
                                             
                                                   <asp:Label ID="lblArchivalDtvalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                      </div>
                                  <div class="col-sm-4" style="text-align:left;">
                       <asp:Label ID="lbldispatchMode" runat="server" Text="Dispatch Mode" CssClass="control-label"></asp:Label>
                                                
                                                     <asp:Label ID="lbldispatchModevalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                                                 
                         </div>
                      </div>

                              <div class="row rowspacing"  runat="server">
                           
                                  <div class="col-sm-4" style="text-align:left;">
                                   <asp:Label ID="lbldispatchDt" runat="server" Text="Dispatch Date" CssClass="control-label" ></asp:Label>
                                           
                                                   <asp:Label ID="lbldispatchDtvalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>               
                      </div>
                                  <div class="col-sm-4" style="text-align:left;">
                         <asp:Label ID="lblPolicyDisp" runat="server" Text="Policy Dispatched" CssClass="control-label"></asp:Label>
                                                
                                                     <asp:Label ID="lblPolicyDispvalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                      </div>
                                  <div class="col-sm-4" style="text-align:left;">
                        <asp:Label ID="lblInsAddr" runat="server" Text="Insured Address" CssClass="control-label" ></asp:Label>
                                              
                                                   <asp:Label ID="lblInsAddrvalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                                                 
                         </div>
                      </div>
                              <div class="row rowspacing"  runat="server">
                           
                           <div class="col-sm-4" style="text-align:left;">
                                   <asp:Label ID="lblCourierName" runat="server" Text="Courier Name" CssClass="control-label"></asp:Label>
                                                
                                                     <asp:Label ID="lblCourierNamevalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>              
                      </div>
                           <div class="col-sm-4" style="text-align:left;">
                        <asp:Label ID="lblremark1" runat="server" Text="Remark" CssClass="control-label" ></asp:Label>
                                              
                                                   <asp:Label ID="lblremarkvalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                      </div>
                           <div class="col-sm-4" style="text-align:left;">
                         <asp:Label ID="lblInsDt" runat="server" Text="Insert Date" CssClass="control-label"></asp:Label>
                                              
                                                     <asp:Label ID="lblInsDtvalue" runat="server" CssClass="form-control control-label" Enabled="false"  ></asp:Label>
                                                 
                         </div>
                      </div>
                           
                             
                             </div>

                         </div>


                     
                </div>
                   
               <%--   Ended by sanoj 22062023 Dispatch details--%>      
              <%-- </asp:MultiView>--%>
                </div>
             </div>                         
 
        
           
           <center>
          <%-- <div class="btn btn-xs btn-primary" style="width:130;"><i class="fa fa-times"></i>--%>
          
        
            <div class="col-sm-12" align="center" >
                        <asp:LinkButton ID="btnCancel" visible="false" runat="server" CssClass="btn btn-clear" CausesValidation="False" style='display:initial;'
                         Width="100px" OnClientClick="return doCancel();"     TabIndex="33">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> CANCEL 
                             </asp:LinkButton> 
                         
               </div>
              
                                    </center>
       
     

    

<asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
              <%--1-Personal section start--%>
              <asp:View ID="View1" runat="server">
              </asp:View>
               <asp:View ID="View2" runat="server">
               </asp:View>
                <asp:View ID="View6" runat="server">
                 </asp:View>
                  <asp:View ID="View7" runat="server">
                 </asp:View>
                  <asp:View ID="View8" runat="server">
                 </asp:View>
          </asp:MultiView>

 <input id="hdnID210" type="hidden" runat="server" />
       <input id="hdnID260" type="hidden" runat="server" />
       <input id="hdnID270" type="hidden" runat="server" />
       <input id="hdnID280" type="hidden" runat="server" />
       <input id="hdnID290" type="hidden" runat="server" />
       <input id="hdnID300" type="hidden" runat="server" />
       <input id="hdnID310" type="hidden" runat="server" />
       <input id="hdnID320" type="hidden" runat="server" />
       <input id="hdnID330" type="hidden" runat="server" />
       <input id="hdnID340" type="hidden" runat="server" />
       <input id="hdnID350" type="hidden" runat="server" />
       <input id="hdnID360" type="hidden" runat="server" />
       <input id="hdnID370" type="hidden" runat="server" />
       <input id="hdnID380" type="hidden" runat="server" />
       <input id="hdnID390" type="hidden" runat="server" />
       <input id="hdnID400" type="hidden" runat="server" />
       <input id="hdnID410" type="hidden" runat="server" />
       <input id="hdnID420" type="hidden" runat="server" />
       <input id="hdnID430" type="hidden" runat="server" />
       <input id="hdnID440" type="hidden" runat="server" />
       <input id="hdnID450" type="hidden" runat="server" />
       <input id="hdnID460" type="hidden" runat="server" />
       <input id="hdnID470" type="hidden" runat="server" />
       <input id="hdnID480" type="hidden" runat="server" />
       <input id="hdnID490" type="hidden" runat="server" />
       <input id="hdnID500" type="hidden" runat="server" />
       <input id="hdnID510" type="hidden" runat="server" />
       <input id="hdnID520" type="hidden" runat="server" />
       <input id="hdnID530" type="hidden" runat="server" />
       <input id="hdnID540" type="hidden" runat="server" />
       <input id="hdnID550" type="hidden" runat="server" />
       <input id="hdnID560" type="hidden" runat="server" />
       <input id="hdnID570" type="hidden" runat="server" />
       <input id="hdnID580" type="hidden" runat="server" />
       <input id="hdnID590" type="hidden" runat="server" />
       <input id="hdnID600" type="hidden" runat="server" />
       <input id="hdnID610" type="hidden" runat="server" />
       <input id="hdnID620" type="hidden" runat="server" />
                                
       <input id="hdnID630" type="hidden" runat="server" />
       <input id="hdnID640" type="hidden" runat="server" />
       <input id="hdnID650" type="hidden" runat="server" />
       <input id="hdnID660" type="hidden" runat="server" />
       <input id="hdnID670" type="hidden" runat="server" />
                                
       <input id="hdnIsDateValid" type="hidden" runat="server" />
       <input id="hdnDOB" type="hidden" runat="server" />
       <input id="hdnSave" type="hidden" runat="server" />
       <input id="hdnUpdate" type="hidden" runat="server" />
       <input id="hdnAppno" type="hidden" runat="server" />
       <input id="hdSmCode" type="hidden" runat="server" />
       <input id="hdnECCode" type="hidden" runat="server" />
       <input id="hdnBizSrc" type="hidden" runat="server" />
        <asp:HiddenField ID="hdnCndNo" runat="server" />                        
        <asp:HiddenField ID="hdnBtnDis" runat="server" />
             <table>
                  <tr>
                      <td>
                           <asp:UpdatePanel ID="updPnlHidden" runat="server">
                               <contenttemplate>
                                    <asp:HiddenField ID="hdnAgnCode" runat="server" />
                                    <asp:HiddenField ID="hdnPan" runat="server" />
                                    <asp:HiddenField ID="hdnAgentBrokerCode" runat="server" />
                                    <asp:HiddenField ID="hdnUrn" runat="server" />     
                                    <%-- //04...07/09/2012...Miti --%>           
                                    <asp:HiddenField ID="hdnpanedit" runat="server" />
                                     <%--//04...07/09/2012...Miti--%>
                                </contenttemplate>
                            </asp:UpdatePanel>
                       </td>
                   </tr>
             </table>
    </center>


    <%--Hidden field section start added by Prathamesh 17-6-15--end--%>



    <%--<asp:Panel runat="server" ID="pnlMdl" Width ="500" display = "none" >
        <iframe runat="server" id="ifrmMdlPopup" width="500" height="300px" frameborder="0"
            display="none"></iframe>
         
    </asp:Panel>--%>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--<asp:Panel ID="pnl" runat="server" class="modalpopupmesg" 
        BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" Width="323px" Height="155px">
       <table width="100%">
           <tr align="center">
                <td class="test" width="100%" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
           </tr>
       </table>
       <table>
            <tr>
                <td style="width: 391px">
                     <br />
                        <center>
                             <asp:Label ID="lbl" runat="server"></asp:Label><br />
                        </center>
                    <br />
                 </td>
            </tr>
       </table>
       <center>
        <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" 
               Width="81px" />
       </center>                       
    </asp:Panel>--%>
    <%--<ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100" >
    </ajaxToolkit:ModalPopupExtender>--%>
</asp:Content>


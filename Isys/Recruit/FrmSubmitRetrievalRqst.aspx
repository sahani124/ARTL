<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="FrmSubmitRetrievalRqst.aspx.cs" Inherits="Application_ISys_Recruit_FrmSubmitRetrievalRqst" %>

<%@ Register Src="../../../App_UserControl/Common/ctlDate.ascx" TagName="ctlDate"
    TagPrefix="uc7" %>
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

 <script type="text/javascript" src="../../../Scripts/common.js"></script>
 <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
 <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
 <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
 
 <script type="text/javascript">
     function popup() {
         $("#myModal").modal();
     }
     //function ShowReqDtlResize(divName, btnName) {
     //    debugger;
     //    try {
     //        var objnewdiv = document.getElementById(divName)
     //        var objnewbtn = document.getElementById(btnName);
     //        if (objnewdiv.style.display == "block") {
     //            objnewdiv.style.display = "none";
     //            objnewbtn.className = 'glyphicon glyphicon-resize-small'
     //        }
     //        else {
     //            objnewdiv.style.display = "block";
     //            objnewbtn.className = 'glyphicon glyphicon-resize-full'
     //        }
     //    }
     //    catch (err) {
     //        ShowError(err.description);
     //    }
     //}
     
     		        function ShowReqDtlResize(divName, btnName) {
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
                ////ShowError(err.description);
            }
        }

     
     		        function ShowReqDtl12(divName, btnName) {
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
                ////ShowError(err.description);
            }
        }
     //function ShowReqDtl12(divName, btnName) {
     //    //debugger;
     //    try {
     //        var objnewdiv = document.getElementById(divName)
     //        var objnewbtn = document.getElementById(btnName);
     //        if (objnewdiv.style.display == "block") {
     //            objnewdiv.style.display = "none";
     //            objnewbtn.className = 'glyphicon glyphicon-resize-small'
     //        }
     //        else {
     //            objnewdiv.style.display = "block";
     //            objnewbtn.className = 'glyphicon glyphicon-resize-full'

     //        }
     //    }
     //    catch (err) {
     //        ShowError(err.description);
     //    }
     //}
     //for main div
     //function ShowReqDtl1(divName, btnName) {
     //    debugger;
     //    try {
     //        var objnewdiv = document.getElementById(divName)
     //        var objnewbtn = document.getElementById(btnName);
     //        if (objnewdiv.style.display == "block") {
     //            objnewdiv.style.display = "none";
     //            objnewbtn.className = 'glyphicon glyphicon-collapse-up'
     //        }
     //        else {
     //            objnewdiv.style.display = "block";
     //            objnewbtn.className = 'glyphicon glyphicon-collapse-down'
     //        }
     //    }
     //    catch (err) {
     //        ShowError(err.description);
     //    }
     //}

     		        function ShowReqDtl1(divName, btnName) {
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
                ////ShowError(err.description);
            }
        }
     </script>
     <style type="text/css">  
     .nav-tabs > li.active > a,
        .nav-tabs > li.active > a:hover,
        .nav-tabs > li.active > a:focus{
            color: #555555;
            background-color: #dff0d8;  
        } 
          .modal-dialog{
    position: relative;
    display: table;
    overflow-y: auto;    
    overflow-x: auto;
    width: auto;
    min-width: 50px;   
}
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
         ul#menu {
    padding: 0;
       margin-right: 69%;
        }

ul#menu li {
    display: inline;
     
    
}



ul#menu li a {
    background-color:Silver;
    color: black;
    cursor:pointer;
    padding: 10px 20px;

    text-decoration: none;
    border-radius: 4px 4px 0 0;
}
ul#menu li a:active{background:white;}

ul#menu li a:hover {
    background-color: red;
}


        </style>
    <%--Added by rahana end--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <table style="width: 100%;display:none;">
            <tr>
                <td align="right" colspan="4">
                    <asp:ImageButton ID="Img2" runat="server" Visible="true" ForeColor="Red" OnClientClick="CloseSub()"
                        src="~/theme/iflow/Error.JPG" />
                </td>
            </tr>
        </table>
        <table id="tblheader" runat="server" style="width: 81%;display:none; border-collapse: collapse;">
            <tr align="center">
                <td>
                    <asp:Label ID="Label9" runat="server" ForeColor="#C04000"></asp:Label>
                </td>
            </tr>
            <tr align="center">
                <%--<td align="left"  style="width: 5%">
            </td>--%>
                <td align="left" style="width: 95%">
                    <asp:ImageButton ID="lnkPage1" runat="server" CssClass="TextBox" BackColor="transparent"
                        OnClick="lnkPage1_Click" ImageUrl="~/theme/iflow/tabs/Retrieval1.png" CausesValidation="False"
                        TabIndex="1215" />
                    <asp:ImageButton ID="lnkPage2" runat="server" CssClass="TextBox" BackColor="Transparent"
                        OnClick="lnkPage2_Click" ImageUrl="~/theme/iflow/tabs/profiling2.png" CausesValidation="False"
                        TabIndex="1220" />
                </td>
            </tr>
        </table>
        <div id="divIRCC" runat="server" style="padding: 1%" role="tabpanel">
            <ul class="nav nav-tabs">
                <li class="active"><a id="personal" runat="server" aria-controls="menu1" data-toggle="tab"
                    href="#menu1"><b>Retrieval</b></a></li>
                <li><a id="profiling" runat="server" aria-controls="menu2" data-toggle="tab" href="#menu2">
                    <b>Profiling</b></a></li>
            </ul>
            <div class="tab-content">
           
                <div id="menu1" class="tab-pane fade in active">
               <div class="panel panel-success" style="margin-left:0px;margin-right:0px">
                                 <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div5','btnpersnl');return false;">           
                          <div class="row">
                           <div class="col-sm-10" style="text-align:left">
                      <span class=""  ></span> Reterival Request
                    
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-collapse-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                          </div>
                          </div>
                            <div id="div5" style="display:block;" runat="server" class="panel-body">
                             <div class="row">
                                      <div class="col-sm-3" style="text-align:left;">
                                                <asp:Label ID="lblAppNo" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                               <div class="col-sm-3" >
                                       
                                                <asp:TextBox ID="lblAppNoValue" runat="server" Enabled="false"  CssClass="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-sm-3" style="text-align:left;">
                                                <asp:Label ID="lblCndName" runat="server"  CssClass="control-label"></asp:Label>
                                           </div>
                                               <div class="col-sm-3">
                                                <asp:TextBox ID="lblAdvNameValue" runat="server"  Enabled="false"  CssClass="form-control"></asp:TextBox>
                                           </div>
                                           </div>
                                            <div class="row">
                                                <div class="panel panel-success" >
                                                    <div id="Div6" runat="server" class="panel-heading subheader" 
                                                        onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_divagndetails','Span1');return false;">
                                                    
                                                        <div class="row">
                                                            <div class="col-sm-10" style="text-align: left">
                                                                <span ></span>  Personal Information
                                                               
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right;
                                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div runat="server" id="divagndetails" style="display: block;" class="panel-body">
                                                        <div class="row">
                                                        <div class="col-sm-10">
                                                        <div class="row" style=" margin-bottom: 5px;">
                                                        <div class="col-sm-2" style="text-align:left">
                                                            <asp:Label ID="lblCndNo" runat="server" CssClass="control-label"></asp:Label>
                                                          
                                                        </div>
                                                         <div class="col-sm-4">
                                                          <asp:TextBox ID="lblCndNoValue" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                        </div>
                                                            <div class="col-sm-6">
                                                                <asp:Label ID="lblAdvWaiver" Text="Advisor Waiver" Visible="false" runat="server"></asp:Label>
                                                                <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details" OnClick="lblCndView_Click"></asp:LinkButton>
                                                                <asp:CheckBox ID="chkAdvWaiver" runat="server" Visible="false" AutoPostBack="true"
                                                                    OnCheckedChanged="chkAdvWaiver_CheckedChanged" />
                                                                <asp:Button ID="btnAdvisorWaiver" runat="server" Visible="false" Text="Waiver Advisor"
                                                                    Width="100" CssClass="standardbutton" />
                                                                <asp:HiddenField ID="hdnAdvWaiver" runat="server" />
                                                                <asp:HiddenField ID="hdnCsccode" runat="server" />
                                                            </div>
                                                        
                                                        </div>
                                                            <div class="row" style=" margin-bottom: 5px;">
                                                                <div class="col-sm-2" style="text-align: left">
                                                                    <asp:Label ID="lblBranch" runat="server" CssClass="control-label"></asp:Label>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:TextBox ID="lblBranchValue" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-2" style="text-align: left">
                                                                    <asp:Label ID="lblSMName" runat="server" Text="Reporting Name" CssClass="control-label"></asp:Label>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:TextBox ID="lblSMNameValue" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                         <div class="row" style=" margin-bottom: 5px;">
                                                          <div class="col-sm-2" style="text-align:left">
                                                                    <asp:Label ID="lblPAN" runat="server" Text="PAN No" CssClass="control-label"></asp:Label>
                                                                         <span style="color: Red">*</span>
                                                        </div>
                                                         <div class="col-sm-4">
                                                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                     <ContentTemplate>
                                         <div  style="display:flex;">
                                             <asp:TextBox ID="txtPAN"  runat="server" CssClass="form-control" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"
                                               style='width:98%;'  TabIndex="1"></asp:TextBox>&nbsp;
                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" 
                                                 InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtPAN"
                                                 FilterType="Custom">
                                             </ajaxToolkit:FilteredTextBoxExtender>
                                           
                                                 <asp:LinkButton ID="btnVerifyPAN" runat="server" Text="Verify" CssClass="btn btn-primary"
                                                     OnClick="btnVerifyPAN_Click" OnClientClick="funpan();" TabIndex="4">
                                             <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify
                                                 </asp:LinkButton>
                                           </div> 
                                       
                                         <div id="divPAN" class="Content" style="display: none">
                                             <img src="../../../App_Themes/Isys/images/spinner.gif" />
                                             <asp:Label ID="Lblimg" runat="server"></asp:Label>
                                         </div>
                                         <asp:Label ID="lblPANMsg" runat="server" Font-Bold="False" CssClass="control-label"
                                             Font-Size="X-Small"></asp:Label>
                                               <asp:HiddenField ID="hdnPanDtls" runat="server"></asp:HiddenField>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                               
                                 <i class="fa fa-hand-o-right"></i>
            <a href="https://incometaxindiaefiling.gov.in/e-Filing/Services/KnowYourJurisdiction.html;jsessionid=Fl7hSy1QFps1MQr5XqXhX51h7rJp7Jyd1HLJnMxthzG1HLRhgPFl!905747125" target="_blank" style="font-size:13px"; tabindex="5">Income Tax PAN Verification Link</a> <%--14-01-2014--%>
        
                                                        </div>
                                                         <div class="col-sm-2" style="text-align:left">
                                                            <asp:Label ID="lblSponsorDt" Text="Sponsor Date" runat="server" CssClass="control-label"></asp:Label>
                                                          
                                                               
                                                        </div>
                                                         <div class="col-sm-4">
                                                          <asp:TextBox ID="lblSponsorDtValue" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                      
                                                        </div>
                                                        </div>
                                                          <div class="row" style=" margin-bottom: 5px;">
                                                                <div class="col-sm-2" style="text-align: left">
                                                               
                                                                    <asp:Label ID="lblMobileNo" Text="Mobile No" runat="server" CssClass="control-label"></asp:Label>
                                                                      <span style="color: Red">*</span>
                                                               
                                                                </div>
                                                                 <div class="col-sm-4">

                                            <asp:UpdatePanel ID="updMobile" runat="server">
                                                                    <ContentTemplate>
                                                                                                                                        <div style="display:flex;">
                                              <asp:TextBox ID="txtmobilecode" runat="server" Enabled="false" Text="91"  CssClass="form-control"  Width="27%"
                                                      ></asp:TextBox>
                                             <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" 
                                             Placeholder="Mobile No should be 10 digit."       MaxLength="10"  TabIndex="99" ></asp:TextBox>
                                                   <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                      FilterMode="InvalidChars" TargetControlID="txtMobileNo" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                <asp:LinkButton ID="btnverifymobile" runat="server" CssClass="btn btn-primary" 
                                                ValidationGroup="RecruitInfo"     OnClick="btnverifymobile_Click" OnClientClick="return form2();" TabIndex="4">
                                             <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify
                                                 </asp:LinkButton>
                                             
                                                                        <div id="divmob" class="Content" style="display: none">
                                                                            <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                                                            Loading...</div>
                                                                        <br />
                                                                        <asp:Label ID="lblmobileverify" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                                               
                                            </div>
                                             </ContentTemplate>
                                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-2" style="text-align: left">
                                                                 
                                                                        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="control-label"></asp:Label>
                                                                           <span style="color: Red">*</span>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:UpdatePanel ID="updMail" runat="server">
                                                                        <ContentTemplate>
                                                                        <div style="display:flex;">
                                                                            <asp:TextBox ID="txtEMail" runat="server" CssClass="form-control"
                                                                                onblur="validateEmail1(this.value)"></asp:TextBox><%--onblur="validateEmail1(this.value)"--%>
                                                                            <%-- added by shravana14jun2013--%>
                                                                            <asp:LinkButton ID="btnverifyemail" runat="server"  ValidationGroup="RecruitInfo" 
                                                                                CssClass="btn btn-primary" OnClick="btnverifyemail_Click" OnClientClick="return validateEmail1();">
                                                                            <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify
                                                 </asp:LinkButton>
                                                                              
                                                                            <div id="divEmail" class="Content" style="display: none">
                                                                                <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                                                                Loading...</div>
                                                                            <br />
                                                                            <asp:Label ID="lblEmailMsg" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                                                          </div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                               
                                                                </div>
                                                            <div class="row" style=" margin-bottom: 5px;">
                                                                <div class="col-sm-3" style="text-align: left">
                                                                   <asp:Label ID="lblReqStatus" runat="server" CssClass="control-label"></asp:Label>
                                                                </div>
                                                                 <div class="col-sm-3" >
                                                                    <asp:TextBox ID="lblReqStatusValue" runat="server" CssClass="form-control"
                                                                    Enabled="false"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-6" style="text-align:left">
                                                           <asp:Label ID="lblpandetail" runat="server" Text="Is Pan name different from registered name"
                                                                    CssClass="control-label"></asp:Label>
                                                          
                                                                <asp:CheckBox ID="Chkpan"  CssClass="checkbox" runat="server" />
                                                        </div>
                                                        </div>
                                                          </div>
                                                        <div class="col-sm-2" style="text-align:center" >
                                                        <div class="row">
                                                           <asp:UpdatePanel ID="updgrdImage" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Image ID="Img" runat="server" ImageUrl="~/theme/iflow/prof_pic_blank2.jpeg"
                                                                        Height="140px" Width="140px" />
                                                                    <asp:GridView ID="GridCndImage" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        Visible="false" ShowHeader="false">
                                                                        <%--onrowdatabound="GridCndImage_RowDataBound"--%>
                                                                        <Columns>
                                                                            <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton><asp:HiddenField
                                                                                        ID="hdnid" runat="server" Value='<%# Eval("ID") %>'></asp:HiddenField>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:ImageField DataImageUrlField="ID" DataImageUrlFormatString="ImageCSharp.aspx?ImageID={0}"
                                                                                HeaderText="Photo" ControlStyle-Height="140px" ControlStyle-Width="140px">
                                                                            </asp:ImageField>
                                                                        </Columns>
                                                                      
                                                                       
                                                                    </asp:GridView>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            </div>
                                                            <div class="row">
                                                             <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Image ID="ImgSign" runat="server" ImageUrl="~/theme/iflow/Signature.JPG" Height="40px"
                                                                        Width="140px" />
                                                                    <asp:GridView ID="GridCndSignImage" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        Visible="false" ShowHeader="false">
                                                                        <%--onrowdatabound="GridCndImage_RowDataBound"--%>
                                                                        <Columns>
                                                                            <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton><asp:HiddenField
                                                                                        ID="hdnid" runat="server" Value='<%# Eval("ID") %>'></asp:HiddenField>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:ImageField DataImageUrlField="ID" DataImageUrlFormatString="ImageCSharp.aspx?ImageID={0}"
                                                                                HeaderText="Signature" ControlStyle-Height="40px" ControlStyle-Width="140px">
                                                                            </asp:ImageField>
                                                                        </Columns>
                                                                       </asp:GridView>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                      
                                                    </div>
                                                </div>
                                            </div>
                                      
</div>
<div class="row">
 <div class="panel panel-success" >
                                                    <div id="tblPresentadd" runat="server" class="panel-heading subheader" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_div7','Span2');return false;"
                                                     >
                                                        <div class="row">
                                                            <div class="col-sm-10" style="text-align: left">
                                                                <span ></span>  Present Address
                                                               
                                                            </div>
                                                            
                                                            <div class="col-sm-2">
                                                                <span id="Span2" class="glyphicon glyphicon-chevron-down" style="float: right;
                                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div id="div7" runat="server" style="display: block;">
                                                     <div class="row" >
                             <div class="col-sm-12" style="text-align: left;margin:1%;">
                                                            <asp:UpdatePanel ID="UpdPanelEditAdd" runat="server">
                                            <ContentTemplate>
                                            <asp:Label ID="Label11" Text="Address Edit" Font-Bold="true" runat="server" CssClass="control-label"></asp:Label>
                                                <asp:CheckBox ID="chkEdit"  runat="server"
                                                    TabIndex="76" OnCheckedChanged="chkEdit_CheckedChanged" AutoPostBack="true" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        </div>
                                        </div>
                                                    <asp:UpdatePanel ID="UpdPanelShow" runat="server">
                                <ContentTemplate>
                                    <div id="divPresentAddress" runat="server" visible="true" style="display: block;margin:1%">
                            
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align:left;">
                                                       
                                                        <asp:Label ID="lblpfaddresstype" runat="server" CssClass="control-label"></asp:Label>
                                                         <span style="color: #ff0000">*</span>
                                                        </div>
                                                        <div class="col-sm-3" >
                                                          <asp:TextBox ID="lblpfaddresstypeDesc" runat="server" CssClass="form-control"
                                                          Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align:left;">
                                                          
                                                        <asp:Label ID="lblpfStateP" runat="server"  CssClass="control-label"></asp:Label>
                                                         <span style="color: #ff0000">*</span>
                                                        </div>
                                                        <div class="col-sm-3" >
                                                         <asp:TextBox ID="lblpfStatePDesc" runat="server" CssClass="form-control"
                                                          Enabled="false"></asp:TextBox>
                                                        </div>
                                                        </div>
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align:left;">
                                                           <asp:Label ID="lblpfAddrP1" runat="server" CssClass="control-label"></asp:Label>
                                                          <span style="color: #ff0000">*</span>
                                              
                                                  
                                                        </div>
                                                        <div class="col-sm-3" >
                                                          <asp:TextBox ID="lblpfAddrP1Desc" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                              
                                                
                                                        </div>
                                                        <div class="col-sm-3" style="text-align:left;">
                                                        
                                                   
                                                        <asp:Label ID="Label16" runat="server" Text="District" CssClass="control-label"></asp:Label>
                                                         <span style="color: #ff0000">*</span>
                                              
                                              
                                                        </div>
                                                        <div class="col-sm-3" >
                                                              <asp:TextBox ID="lbldistDesc"  Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                               
                                                        </div>
                                                        </div>
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align:left;">
                                                          <asp:Label ID="lblpfAddrP2" Text="Address Line 2" CssClass="control-label" runat="server"></asp:Label>
                                            
                                                        </div>
                                                        <div class="col-sm-3" >
                                                            <asp:TextBox ID="lblpfAddrP2Desc" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                                
                                                        </div>
                                                        <div class="col-sm-3" style="text-align:left;">
                                                          <asp:Label ID="lblcity" runat="server" Text="City"  CssClass="control-label"></asp:Label>
                                                         <span style="color: #ff0000"> *</span>
                                               </div>
                                                        <div class="col-sm-3" >
                                                          <asp:TextBox ID="lblCityDesc" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        </div>
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align:left;">
                                                          <asp:Label ID="lblpfAddrP3" CssClass="control-label" runat="server"></asp:Label>
                                             
                                                        </div>
                                                        <div class="col-sm-3" >
                                                         <asp:TextBox ID="lblpfAddrP3Desc" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                              
                                                        </div>
                                                        <div class="col-sm-3" style="text-align:left;">
                                                           <asp:Label ID="lblarea" runat="server" Text="Area" Style="color: Black"></asp:Label>
                                                      <span style="color: #ff0000">     *</span>
                                               
                                                        </div>
                                                        <div class="col-sm-3" >
                                                          <asp:TextBox ID="lblareaDesc" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                             
                                                        </div>
                                                        </div>
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align:left;">
                                                           <asp:Label ID="lblVillage" runat="server" Text="Village" CssClass="control-label"></asp:Label>
                                                      <span style="color: #ff0000">*</span>
                                               
                                                   
                                                      
                                                        </div>
                                                        <div class="col-sm-3" >
                                                         <asp:TextBox ID="lblVillageDesc" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                                  
                                                        </div>
                                                        <div class="col-sm-3" style="text-align:left;">
                                                          <asp:Label ID="lblpfPinP" runat="server" CssClass="control-label"></asp:Label>
                                                         <span style="color: #ff0000">*</span>
                                        
                                                        </div>
                                                        <div class="col-sm-3" >
                                                              <asp:TextBox ID="lblpfPinPDesc" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                              
                                                        </div>
                                                        </div>
                                                        <div class="row">
                                                        <div class="col-sm-3">
                                                        </div>
                                                        <div class="col-sm-3" >
                                                        </div>
                                                        <div class="col-sm-3" style="text-align:left;">
                                                          <asp:Label ID="lblpfCountryP" runat="server" CssClass="control-label"></asp:Label>
                                                         <span style="color: #ff0000">*</span>
                                               
                                                  
                                                        </div>
                                                        <div class="col-sm-3" >
                                                          <asp:TextBox ID="lblpfCountryPDesc" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                              
                                                        </div>
                                                        </div>
                                                         </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkEdit" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                             <asp:UpdatePanel ID="UpdPanelAddShow" runat="server">
                                                 <contenttemplate>
                                    <div id="divPermonantAddressEdit" runat="server" visible="false" style="display:block;margin:1%">
                                     
                                        <div id="treditPA" runat="server" class="row">
                                        <div class="col-sm-3" style="text-align:left;">
                                        <asp:Label ID="lbladdtype" Text="Address Type" CssClass="control-label" runat="server"></asp:Label>
                                        </div>
                                         <div class="col-sm-3" >
                                         <asp:TextBox ID="lbladdtypeDesc"  CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                        </div>
                                         <div class="col-sm-3" style="text-align:left;">
                                        <asp:Label ID="lblstatecodeedit" CssClass="control-label" runat="server"></asp:Label>
                                        <span style="color: #ff0000">*</span>
                                        </div>
                                         <div class="col-sm-3" >
                                           <div style="display:flex;">
                                            <asp:DropDownList id="ddlstate1" runat="server" CssClass="form-control"   
                                                     style='width:98%;'     TabIndex="84"></asp:DropDownList>
                                                   <%--     <span class="input-group-btn"> --%>
                                                        <asp:LinkButton ID="btnstate1search" runat="server" CssClass="btn btn-primary"
                                                             Text="Search" CausesValidation="False"
                               TabIndex="85"> 
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search   
                                 </asp:LinkButton>
                                 </div>
                                     
                                        </div>
                                        
                                        </div>
                                            <div id="treditPA1" runat="server" class="row">
                                            <div class="col-sm-3" style="text-align:left;">
                                             <asp:Label ID="lblPAddline1" CssClass="control-label" Text="Address Line 1" runat="server" ></asp:Label><span style="color: #ff0000">*</span>
                                            
                                            </div>
                                             <div class="col-sm-3" >
                                              <asp:TextBox  ID="txtPAddline1" CssClass="form-control"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" runat="server" 
                                                    Font-Bold="False" MaxLength="30" TabIndex = "77"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender223" runat="server" InvalidChars=",#$@%^!*()&''%^~`"
                                                      FilterMode="InvalidChars" TargetControlID="txtPAddline1" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                            
                                             </div>
                                              <div class="col-sm-3" style="text-align:left;">
                                               <asp:Label ID="lblPDistrict"  runat="server"  CssClass="control-label"></asp:Label>
                                                  <span style="color: red">*</span>
                                               
                                              
                                              
                                              </div>
                                               <div class="col-sm-3" >
                                                 <asp:TextBox ID="txtPDistrict" runat="server" CssClass="form-control"  ReadOnly="false"  
                                                 Enabled="false"     Font-Bold="False" MaxLength="50" TabIndex="86"></asp:TextBox> <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                                <asp:Button  ID="btnPDistrict" runat="server" CssClass="standardbutton"  CausesValidation="False" 
                                                      Text="..." Enabled="false" Visible="false" TabIndex = "87"/>
                                                <asp:HiddenField ID="hdnpermDist" runat="server" />
                                                <asp:HiddenField ID="hdnpermPinFrom" runat="server" />
                                                <asp:HiddenField ID="hdnpermPinTo" runat="server" />
                                       
                                             </div>
                                            </div>
                                           <div id="treditPA2" runat="server" class="row">
                                            <div class="col-sm-3" style="text-align:left;">
                                            <asp:Label ID="lblPAdd2" runat="server" CssClass="control-label"></asp:Label>
                                                <span style="color:Red">*</span>
                                          
                                            </div>
                                             <div class="col-sm-3" >
                                             
	                                            <asp:TextBox ID="txtPAdd2" runat="server" CssClass="form-control" 
                                                 MaxLength="30" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="78"></asp:TextBox>
                                                 <asp:HiddenField ID="updDist" runat="server" />
                                      
                                          
                                             </div>
                                              <div class="col-sm-3" style="text-align:left;">
                                                <asp:Label ID="lblPcity" runat="server"  CssClass="control-label"></asp:Label>
                                              <span style="color: red">*</span>
                                       
                                              </div>
                                               <div class="col-sm-3" >
                                               
                                                <asp:TextBox ID="txtPcity1" runat="server"  CssClass="form-control"   ReadOnly="false"  
                                                  Enabled="false"      Font-Bold="False" MaxLength="50" TabIndex="88"></asp:TextBox> <%--onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                                
                                                 <asp:HiddenField ID="hdnPermCity1" runat="server" />
                                             </div>
                                            </div>
                                             <div id="treditPA3" runat="server" class="row">
                                              <div class="col-sm-3" style="text-align:left;">
                                            
                                                <asp:Label ID="lblPAdd3" runat="server" CssClass="control-label"></asp:Label>
                                                   <span style="color:Red">*</span>
                                           
	                                                                              <asp:HiddenField ID="hdnpermArea1" runat="server" />
                                            </div>
                                             <div class="col-sm-3" >
                                                <asp:TextBox ID="txtPAdd3" runat="server" CssClass="form-control" 
                                                  MaxLength="30" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="79"></asp:TextBox>
                                           
                                                
                                             </div>
                                              <div class="col-sm-3" style="text-align:left;">
                                               <asp:Label ID="lblParea1" runat="server" CssClass="control-label"></asp:Label><span style="color: #ff0000">*</span>
                                           
                                              
                                              </div>
                                               <div class="col-sm-3" >
                                                 <asp:TextBox ID="txtParea1" runat="server" CssClass="form-control"  ReadOnly="false"  
                                                   Enabled="false"     Font-Bold="False" MaxLength="50" TabIndex="90"></asp:TextBox> <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                                            
                                             </div>
                                            </div>
                                             <div id="treditPA4" runat="server" class="row">
                                              <div class="col-sm-3" style="text-align:left;">
                                             <asp:Label ID="lblPVillage"  runat="server"  CssClass="control-label" ></asp:Label>
                                         
                                              
                                            </div>
                                             <div class="col-sm-3" >
                                               <asp:UpdatePanel ID="upnlPAVillage" runat="server">
                                                    <contenttemplate>
                                                        <asp:TextBox  ID="txtpermvillage" runat="server" CssClass="form-control" 
                                                             onChange="javascript:this.value=this.value.toUpperCase();" Font-Bold="False"
                                                             MaxLength="30"  TabIndex="80"></asp:TextBox>
                                                             <%--ADDED BY PRANJALI ON 05-03-2014 for allowing only characters for village validation start--%>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_Village" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " 
                                                                TargetControlID="txtpermvillage"></ajaxToolkit:FilteredTextBoxExtender>
                                                            <%--ADDED BY PRANJALI ON 05-03-2014 for allowing only characters for village validation end--%>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" InvalidChars=",#$@%^!*()&''%^~`"
                                                              FilterMode="InvalidChars" TargetControlID="txtpermvillage" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                             </div>
                                              <div class="col-sm-3" style="text-align:left;">
                                                <asp:Label ID="lblPpostcode" runat="server"   CssClass="control-label" ></asp:Label>
                                                  <span style="color: red">*</span>
                                          
	                                           
                                              </div>
                                               <div class="col-sm-3" >
                                                <asp:TextBox ID="txtPermPostcode" runat="server" CssClass="form-control"
                                                    Enabled="false"   MaxLength="10" TabIndex="92"></asp:TextBox>
                                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" InvalidChars=",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                      FilterMode="InvalidChars" TargetControlID="txtPermPostcode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                      <asp:HiddenField ID="hdnPermPin" runat="server" />
                                             </div>
                                            </div>
                                             <div id="treditPA5" runat="server" class="row">
                                              <div class="col-sm-3" style="text-align:left;">
                                               
                                           
                                            </div>
                                             <div class="col-sm-3" >
                                             
                                          
                                           <%--Added by shreela on 6/03/14 to remove space--%>
                                              
                                             </div>
                                              <div class="col-sm-3" style="text-align:left;">
                                                  <asp:Label ID="lblPrmcountry" runat="server" CssClass="control-label"></asp:Label>
                                                  
                                               <span style="color: red"> *</span>
                                            
                                              
                                              </div>
                                               <div class="col-sm-3" >
                                               <div style="display:flex;">
                                                 <asp:TextBox ID="txtPermCountryCode" runat="server" CssClass="form-control"
                                                Enabled="false"      MaxLength="3" onChange="javascript:this.value=this.value.toUpperCase();" 
                                                    Width="25%" TabIndex="93"></asp:TextBox>
                                                <asp:TextBox ID="txtPermCountryDesc" runat="server" CssClass="form-control"
                                                    Enabled="false" TabIndex="94" ></asp:TextBox>
                                                   
                                          </div>
                                             </div>
                                            </div>
                                          
                                       
                                           
                                                <asp:GridView ID="dgPaymentdtls" runat="server" AllowPaging="True"
                                                Visible="false" 
                                                    AutoGenerateColumns="False" CssClass="tableIsys" HorizontalAlign="Left" 
                                                    OnRowCommand="dgPaymentdtls_RowCommand" 
                                                    OnRowDataBound="dgPaymentdtls_RowDataBound" 
                                                    OnRowDeleting="dgPaymentdtls_RowDeleting" PagerStyle-Font-Underline="true" 
                                                    PagerStyle-ForeColor="blue" PagerStyle-HorizontalAlign="Center" 
                                                    RowStyle-CssClass="tableIsys" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Token No" ItemStyle-Width="8%" 
                                                            SortExpression="TokenNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTokenNo" runat="server" Font-Size="Smaller" 
                                                                    Text='<%# Eval("TokenNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Payment Mode" ItemStyle-Width="12%" 
                                                            SortExpression="PaymentMode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPymtMode" runat="server" Font-Size="Smaller" 
                                                                    Text='<%# Eval("PaymentMode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                                            <ItemStyle HorizontalAlign="left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Payment Date" ItemStyle-Width="12%" 
                                                            SortExpression="PaymentDate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPymtDt" runat="server" Font-Size="Smaller" 
                                                                    Text='<%# Eval("PaymentDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bank Name" ItemStyle-Width="10%" 
                                                            SortExpression="BankName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBankName" runat="server" Font-Size="Smaller" 
                                                                    Text='<%# Eval("BankName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                                            <ItemStyle HorizontalAlign="left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Instrument No" ItemStyle-Width="13%" 
                                                            SortExpression="InstrumentNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInstrumentNo" runat="server" Font-Size="Smaller" 
                                                                    Text='<%# Eval("InstrumentNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Instrument Date" ItemStyle-Width="15%" 
                                                            SortExpression="InstrumentDate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInstrumentDt" runat="server" Font-Size="Smaller" 
                                                                    Text='<%# Eval("InstrumentDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount" ItemStyle-Width="6%" 
                                                            SortExpression="Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPymtAmt" runat="server" Font-Size="Smaller" 
                                                                    Text='<%# Eval("Amount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Transaction No" ItemStyle-Width="12%" 
                                                            SortExpression="TrxNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTrxNo" runat="server" Font-Size="Smaller" 
                                                                    Text='<%# Eval("TrxNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Receipt Id" ItemStyle-Width="7%" 
                                                            SortExpression="ReceiptNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRcptId" runat="server" Font-Size="Smaller" 
                                                                    Text='<%# Eval("RcptNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="5%" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" 
                                                                    Enabled="false" Text="Delete" />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Underline="False" HorizontalAlign="Center" />
                                                            <ControlStyle Font-Underline="True" />
                                                            <FooterStyle Font-Underline="False" />
                                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="standardlink" HorizontalAlign="Center" />
                                                    <PagerStyle Font-Underline="True" ForeColor="Black" HorizontalAlign="Left" />
                                                    <RowStyle CssClass="sublinkodd" Font-Size="Small" ForeColor="Black" 
                                                        HorizontalAlign="Left" />
                                                    <AlternatingRowStyle CssClass="sublinkeven" />
                                                </asp:GridView>
                                     
                                     
                                             
                                       
                                    
                                                <asp:Button ID="btnAddressSave" runat="server" Text="Save" CssClass="standardbutton" style="display: none;"
                                    Width="100" onclick="btnAddressSave_Click"></asp:Button>
                                          
                                   </div>
                                   </contenttemplate>
                                   <Triggers><asp:AsyncPostBackTrigger ControlID="chkEdit" EventName="CheckedChanged" /></Triggers>
                                   </asp:UpdatePanel>
                                   </div>
                                                        </div>
                                                        </div>

<div class="row">
  <div class="panel panel-success" >
       
           <div id="tblupload" runat="server" class="panel-heading subheader" onclick="ShowReqDtlResize('ctl00_ContentPlaceHolder1_div9','btnpnlcfrdtls');return false;"
           style="background-color:#EDF1cc !important">   
    <%--       <div class="row" style="margin-bottom:5px;">
             <div class="col-md-12" style="text-align:center">
                    <asp:Label ID="lblNote" runat="server" CssClass="control-label" Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/GIF format"
                        ForeColor="red"></asp:Label>
             </div>
          </div>        --%>
                          <div class="row">
                    <div class="col-sm-3" style="text-align:left">
                      <span class="glyphicon glyphicon-chevron-down" ></span>
                     <asp:Label ID="lblCanddoc" runat="server" Text="Candidate Document Upload" CssClass="control-label" ></asp:Label>
                 
                    </div>
                        <div class="col-md-5"  style="text-align:center">
                          <asp:Label ID="txtcolr" runat="server" Height="12px" Width="20px" CssClass="form-control" BackColor="LightPink"></asp:Label>
                           <asp:Label ID="LinkButton1" runat="server" Text="Mandatory Documents" OnClick="lnkmandtry_click">
                    </asp:Label>&nbsp;&nbsp;&nbsp;
                        </div>
                    <div class="col-sm-4">
                        <span id="btnpnlcfrdtls" class="glyphicon glyphicon-resize-full" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>

          <div id="div9" runat="server"  class="panel-body"  style="width: 97%; display:block">
               <div class="row" style="margin-bottom:5px;">
             <div class="col-md-12" style="text-align:center">
                    <asp:Label ID="lblNote" runat="server" CssClass="control-label" Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/GIF format"
                        ForeColor="red"></asp:Label>
             </div>
          </div>      
        <ajaxToolkit:ModalPopupExtender ID="mdlcfrdtls" runat="server" BehaviorID="mdlcfrdtlsID"
            DropShadow="false" TargetControlID="buttonNull" PopupControlID="pnlcfrdtls" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Button ID="buttonNull" runat="server" Style="display: none" />
        <asp:Panel runat="server" ID="pnlcfrdtls" Style="display: block; width: 30%; height: 50%">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <ContentTemplate>
                      <div id="trdgDetails" runat="server" class="panel-body">
                               <%-- <asp:GridView ID="dgDetails1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                    Width="450px" RowStyle-CssClass="tableIsys" AllowSorting="True">--%>
                               <asp:GridView  AllowSorting="True" ID="dgDetails1" runat="server" CssClass="footable"
                                       AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                        >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRow" />
                                           <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                    <%--OnRowDataBound="dgDetails_RowDataBound"OnSorting="dgDetails_Sorting" --%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Seq No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblseqno" runat="server" Text='<%# Bind("SeqNo") %>' Visible="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandatory Documents">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManDoc" runat="server" Text='<%# Bind("ImgDesc01") %>' Visible="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    
                                </asp:GridView>
                     </div>
                    <div class="row" style="margin-bottom:5px;">
                           <div class="col-md-12" style="text-align:center">
                                <%--align="center">--%>
                                <%--<div class="btn btn-xs btn-primary" style="width: 90px;">
                                    <i class="fa fa-times"></i>--%>
                                <asp:Button ID="btnpopcancel" runat="server" CssClass="standardbutton" Text="Cancel" />
                                <%--</div>--%>
                          </div>
                      </div>
                    
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnpopcancel" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
       
        
        <div id="div1" runat="server" style="display: block; ">
               <div class="row" style="margin-bottom:5px; overflow:auto;">
              
                        <%--//pranjali start--%>
                        <asp:UpdatePanel ID="upddgView" runat="server">
                            <ContentTemplate>
                                <%--<asp:GridView ID="dgView" runat="server" AllowSorting="True" CssClass="tableIsys"
                                    PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="dgView_PageIndexChanging"
                                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys" OnRowCommand="dgView_RowCommand"
                                    OnRowDataBound="dgView_RowDataBound" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True" Width="100%" PageSize="15">--%>
                                       <asp:GridView  AllowSorting="True" ID="dgView" runat="server" CssClass="footable"
                                     OnRowCommand="dgView_RowCommand"
                                    OnRowDataBound="dgView_RowDataBound"
                                       AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                            >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRow" />
                                        <HeaderStyle CssClass="gridview th" />
                                   <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                    <Columns>
                                                            <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="175px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldocName" runat="server" Font-Size="11px" Text='<%#Bind("ImgDesc01") %>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Document Description" HeaderStyle-Width="310px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldocDescription" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                        Text='<%#Bind("ImgDesc02") %>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <%--added by pranjali on 03-03-2014 start--%>
                                                            <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                        Text='<%#Bind("MaxImgSize") %>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <%--added by pranjali on 03-03-2014 end--%>
                                                            <asp:TemplateField HeaderText="Upload Documents">
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                                                        <ContentTemplate>
                                                                            <asp:FileUpload ID="FileUpload" runat="server" Width="340px"></asp:FileUpload></ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="btn_Upload" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                                    <ContentTemplate>
                                                        <%--<asp:Button ID="btn_Upload" runat="server" CssClass="standardlabel" Text="Upload" Enabled="false" Visible="false" Width="80px"
                                                            OnClick="btn_Upload_Click" />--%>
                                                       <asp:LinkButton ID="btn_Upload" runat="server" CssClass="standardlabel" Text="Upload"
                                                                            Enabled="false" Visible="false" Width="80px" OnClick="btn_Upload_Click" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_Upload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_ReUpload" runat="server" CssClass="standardlabel" Text="ReUpload" Width="80px" 
                                            OnClick="btn_ReUpload_Click" />
                                        </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>

                                        </asp:TemplateField>
                                                            <%-- <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                    <ContentTemplate>
                                        <asp:Button ID="btn_ReUpload" runat="server" CssClass="standardbutton" Text="ReUpload" 
                                            OnClick="btn_ReUpload_Click" />
                                        </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>--%>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblimgsize" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("MaxImgSize") %>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblimgshrt" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                        Text='<%#Bind("ImgShortCode") %>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblimgwidth" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                        Text='<%#Bind("ImgWidth") %>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblimgheight" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                        Text='<%#Bind("ImgHeight") %>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblManDoc" runat="server" Text='<%#Bind("IsMandatory") %>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldoccode" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                        Text='<%#Bind("DocCode") %>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkPreview" runat="server" Text="Preview" CommandArgument='<%# Eval("DocCode") %>'
                                                                        CommandName="Preview" Font-Size="11px" Style="text-transform: capitalize;">
                                                                    </asp:LinkButton></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                </asp:GridView>
                              
                            </ContentTemplate>
                           
                        </asp:UpdatePanel>
                        <div class="row" style="text-align:center">
                         <asp:Label ID="Label8" runat="server" Text="NOTE: Declaration is mandatory if License Certificate and ID Card is unavailable."
                                                ForeColor="red"></asp:Label>
                        </div>
           
        </div>
        </div>
          </div>
          </div>
         
        
</div>
</div>
</div>
                            <div id="divSearchDetails" runat="server" style="display:none;">
                                <table style="width: 90%" class="tableIsys">
                                    <tbody>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="red"></asp:Label>
                                                <asp:Label ID="lblSuccessMsg" runat="server" Visible="false" ForeColor="red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="test" align="left" colspan="4">
                                                <asp:Label ID="lblTitle" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                       
                                        <%--Added by rachana on 29-07-2013 for toggle of agent details start--%>
                                    </tbody>
                                </table>
                                <table style="width: 90%" class="formtable table-condensed">
                                    <tr>
                                        <td class="test" colspan="4">
                                            <%--//added by pranjali for id on 11-04-2014--%>
                                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnUploadDtls"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divagndetails','ctl00_ContentPlaceHolder1_btnUploadDtls');" />
                                            <asp:Label ID="lblCnddtls" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <%--added from here--%>
                                <div id="divPersonal" runat="server" style="display: block;">
                                    <table class="tableIsys" style="width: 90%;">
                                        <tr style="height: 25px;">
                                            <td class="formcontent" style="vertical-align: text-top; width: 85%;">
                                                
                                                <div id="divIsSpecified" runat="server" style="display: block;">
                                                    <asp:UpdatePanel ID="Updatepanel14" runat="server">
                                                        <ContentTemplate>
                                                            <table class="tableIsys" style="width: 98%;">
                                                                <tr>
                                                                    <td class="formcontent" style="width: 20%;">
                                                                        <asp:Label ID="lblIsSPFlag" runat="server" Style="color: black"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 30%;" class="formcontent">
                                                                        <asp:UpdatePanel ID="UpdIsSPFlag" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:RadioButtonList ID="rbtIsSP" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                                                    Visible="true" TabIndex="25" Enabled="false">
                                                                                    <%--AutoPostBack="true" OnSelectedIndexChanged="rbtIsSP_SelectedIndexChanged"--%>
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
                                                                                    Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();"> </asp:TextBox>
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
                                                                        <asp:UpdatePanel ID="Updatepanel18" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtCAName" runat="server" CssClass="standardtextbox" MaxLength="20"
                                                                                    Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();"> </asp:TextBox>
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
                                                <div >
                                                    <%--Added by rachana on 29-07-2013 for toggle of agent details end--%>
                                                    <table runat="server" id="tbltest" style="width: 98%" class="tableIsys">
                                                        <tr>
                                                          
                                                        </tr>
                                                        <tr>
                                                            <%-- commented by pranjali on 27-12-2013--%>
                                                            <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchCode" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchCodeValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                                                            <%-- commented by pranjali on 27-12-2013--%>
                                                          
                                                        </tr>
                                                        <%--commented by pranjali on 27-12-2013--%>
                                                        <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSalesUnitCode" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSalesUnitCodeValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                                                        <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMName" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMNameValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                                                        <%--commented by pranjali on 27-12-2013--%>
                                                        <%--commented by pranjali on 27-12-2013--%>
                                                        <%--<tr>
                        <td style="height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnStartDate" runat="server" Text="Training Start Date" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 160px; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnStartDateValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnEndDate" runat="server" Text="Training End Date" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 210px; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnEndDateValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>--%>
                                                        <%--commented by pranjali on 27-12-2013--%>
                                                      
                                                        <%--  added by shreela 21032014--%>
                                                        <tr id="trlicn" runat="server" visible="false">
                                                            <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                                                <asp:Label ID="lblLicnno" runat="server" Text="License No" CssClass="standardlabel"></asp:Label>
                                                            </td>
                                                            <td style="width: 30%; height: 20px" class="formcontent" align="left">
                                                                <asp:TextBox ID="txtlicno" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                                                <asp:Label ID="lbllicnoval" runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                                                <asp:Label ID="lblLicExpDt" runat="server" Text="LicenseExpDate" CssClass="standardlabel"></asp:Label>
                                                            </td>
                                                            <td style="width: 30%; height: 20px" class="formcontent" align="left">
                                                                <asp:TextBox ID="txtLicExpDt" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <%--  added by shreela 21032014--%>
                                                        <%--added by rachana on 14032013 for fees Details start--%>
                                                        <%--added by rachana on 14032013 for fees Details end--%>
                                                        <!--ank end 12.01.2011-->
                                                        <%--</tbody>--%>
                                                        <tr align="center">
                                                            <td>
                                                                <asp:Label ID="LabelFees" runat="server" Visible="false" ForeColor="red"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                            <td class="formcontent" style="vertical-align: middle; width: 15%;">
                                                <%----add----%>
                                                <table border="0" cellpadding="0" cellspacing="0" class="tableIsys" style="width: 90%;">
                                                    <tr>
                                                        <%--<td>
                                                <div style="width:  100%; height: 100%; line-height: 136px; text-align: center;">
                                                    <asp:Label ID="Label16" Text="Photo" runat="server" />
                                                </div>
                                            </td>--%>
                                                        <td>
                                                         
                                                        </td>
                                                    </tr>
                                                    <tr style="clear: both;">
                                                        <%--<td>
                                            <div style="width: 100%; height: 100%; line-height: 38px; text-align: center;">
                                                <asp:Label ID="Label19" Text="Signature" runat="server" />
                                            </div>
                                         </td>--%>
                                                        <td>
                                                           
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <%--added from here--%>
                            </div>
                            
                            <%--Added by Rahul on 24-04-2015 for Present Address View & Edit start --%>
                            <table  class="formtable" style="width: 90%;display:none;" >
                                <tr>
                                    <td class="test" colspan="2" style="text-align: left; width: 60%;">
                                        <input runat="server" type="button" class="standardlink" value="-" id="btnPresentAddress"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPresentAddress','ctl00_ContentPlaceHolder1_btnPresentAddress');" />
                                        <asp:Label ID="lblpfpresentadd" runat="server" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td class="test" colspan="2" style="text-align: left; width: 40%;">
                                        
                                    </td>
                                </tr>
                            </table>
                                      
                           
                            <%--Added by Rahul on 24-04-2015 for Present Address View & Edit end --%>

                            <table id="tblIcmColl" runat="server" style="width: 90%" class="tableIsys">
                                <tr>
                                    <td align="left" class="test" colspan="4">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnICMDtls"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivICMDtls','ctl00_ContentPlaceHolder1_btnICMDtls');" />
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Payment Details"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div runat="server" id="DivICMDtls" style="display: none">
                                <table runat="server" id="tblICMDtls" class="tableIsys" style="width: 90%;">
                                    <tr id="FeesRow" runat="server" visible="true">
                                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                            <span id="spwebtoken" runat="server" style="color: Red">
                                                <asp:Label ID="lblWebTknReceived" Text="Fees Collected" runat="server" Style="color: Black"></asp:Label>*</span>
                                            <%--  added by shreela on 10/03/14--%>
                                            <%-- <span id="spwebtoken" runat="server" style="color: #ff0000">*</span>--%>
                                        </td>
                                        <td style="width: 30%; height: 20px" class="formcontent" align="left" nowrap="nowrap">
                                            <asp:UpdatePanel ID="updChkFees" runat="server">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="chkWebTknRecd" runat="server" OnCheckedChanged="chkWebTknRecd_CheckedChanged"
                                                        AutoPostBack="true" Enabled="false" Visible="false" />
                                                    <%--<asp:TextBox ID="txtFeesRcvd" runat="server" CssClass="standardtextbox" Width="130px" TabIndex="10" Visible="false"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FTEFees" runat="server" InvalidChars="/.\?<>{}[];:|=+_,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                   FilterMode="InvalidChars" TargetControlID="txtFeesRcvd" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                                    <asp:HiddenField ID="hdnVerifyFees" runat="server"></asp:HiddenField>
                                                    <%--<asp:Button ID="btnGetFeeDetails" runat="server" Text="Get Details" width="80px"
                                CssClass="standardbutton" onclick="btnGetFeeDetails_Click" ></asp:Button>--%>
                                                    <asp:LinkButton ID="lnkGetFees" runat="server" Text="Get Fees" OnClick="lnkGetFees_Click"
                                                        Enabled="false"></asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <%--<asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>--%>
                                            <%--</ContentTemplate>
                              <Triggers><asp:AsyncPostBackTrigger ControlID="chkWebTknRecd" EventName="CheckedChanged" /></Triggers>
                              </asp:UpdatePanel>--%>
                                        </td>
                                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                            <asp:Label ID="lbladvWaiverbtn" runat="server" Visible="false" Text="Upload Adv's Waiver Form"></asp:Label>
                                            <span id="spwaiver" runat="server" visible="false" style="color: #ff0000">*</span>
                                        </td>
                                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                                            <asp:Label ID="lblAdvWaiverUpl" runat="server" Visible="false"></asp:Label>
                                            <asp:FileUpload ID="AdvWaiverUpload" runat="server" Visible="false" Width="98%">
                                            </asp:FileUpload>
                                            <asp:CustomValidator ID="CVAdvWaiverValidator" runat="server" ControlToValidate="AdvWaiverUpload"
                                                OnServerValidate="CVAdvWaiverValidator_ServerValidate" SetFocusOnError="True"> </asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr id="trTokenwithFees" runat="server">
                                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                            <asp:Label ID="lblTknNo" runat="server" Text="Token No"></asp:Label>
                                        </td>
                                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                                            <asp:Label ID="lblTknNoValue" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                            <asp:Label ID="lblTotfees" runat="server" Text="Total Fees"></asp:Label>
                                        </td>
                                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                                            <asp:Label ID="lblTotfeesValue" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trTokenwithLatestFees" runat="server" style="display: none">
                                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                            <asp:Label ID="lblTknNoLst" runat="server" Text="Token No"></asp:Label>
                                        </td>
                                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                                            <asp:Label ID="lblTknNoLstDesc" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                            <asp:Label ID="lblTotfeesLst" runat="server" Text="Fees as on todays date"></asp:Label>
                                        </td>
                                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                                            <asp:Label ID="lblTotfeesLstDesc" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--New ICM Details Added by rachana on 30-04-2014 Start --%>
                            <table id="tblICMManual" runat="server" width="90%">
                                <tr>
                                    <td align="left" class="test" colspan="4">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnICM"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divICM','ctl00_ContentPlaceHolder1_btnICM');" />
                                        <asp:Label ID="lblNICMTitle" runat="server" Font-Bold="True" Text="Fees Details Edit"
                                            Width="860px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div runat="server" id="divICM" style="display: none">
                                <table runat="server" id="tblICMDetails" class="tableIsys" style="width: 90%;">
                                    <tr>
                                        <td class="formcontent" style="width: 20%; height: 24px;">
                                            <asp:Label ID="lblPymtMode" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 24px;">
                                            <asp:UpdatePanel ID="upldPayment" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDlPymtMode" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                                        Width="185px" OnSelectedIndexChanged="DDlPymtMode_SelectedIndexChanged" TabIndex="15">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblPymtAmt" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:UpdatePanel ID="updpayment" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtPymtAmt" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTEAmt" runat="server" InvalidChars="/\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                        FilterMode="InvalidChars" TargetControlID="txtPymtAmt" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formcontent" style="width: 20%; height: 24px;">
                                            <asp:UpdatePanel ID="updchqlbl" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblChequeNo" runat="server" Font-Bold="False"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 24px;">
                                            <asp:UpdatePanel ID="updchq" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtChequeNo" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTEChqNo" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                        FilterMode="InvalidChars" TargetControlID="txtChequeNo" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <asp:UpdatePanel ID="updchqdate" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblChequeDate" runat="server" Font-Bold="False"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:UpdatePanel ID="upddate" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtChequedate" runat="server" CssClass="standardtextbox" TabIndex="22" />
                                                    <asp:Image ID="btncal" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                    <asp:TextBox ID="txtcal" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtChequedate"
                                                        PopupButtonID="btncal" Format="dd/MM/yyyy" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                                                        ControlToValidate="txtChequedate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="COMPAREVALIDATOR1" runat="server" ErrorMessage="Invalid date!"
                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtChequedate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtChequedate"
                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formcontent" style="width: 20%; height: 24px;">
                                            <asp:Label ID="lblBankName" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 24px;">
                                            <asp:UpdatePanel ID="updbnkname" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtBankName" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTEBnkName" runat="server" FilterType="LowercaseLetters, UppercaseLetters,Custom"
                                                        ValidChars=" " TargetControlID="txtBankName">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="formcontent" style="width: 20%; height: 24px;">
                                            <asp:Label ID="lblEFT" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 24px;">
                                            <asp:UpdatePanel ID="upldeft" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="TextEFT" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTEEFT" runat="server" InvalidChars="/.\?<>{}[];:|=+_,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                        FilterMode="InvalidChars" TargetControlID="TextEFT" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formcontent2" colspan="4" style="width: 20%; height: 24px;">
                                            <asp:UpdatePanel ID="updAdd" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="BtnAdd" runat="server" Text="Add" CssClass="standardbutton" Width="114px"
                                                        OnClick="BtnAdd_Click"></asp:Button>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--New ICM Details Added by rachana on 30-04-2014 end --%>
                            <asp:UpdatePanel ID="updgridfees" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table id="TblFees" style="width: 90%" class="formtable table-condensed" runat="server"
                                        visible="false">
                                        <tr>
                                            <td colspan="4" align="left" class="test">
                                                <input runat="server" type="button" value="+" id="btnfees" style="width: 20px;" onclick="ShowReqDtlNew('ctl00_ContentPlaceHolder1_divFees','ctl00_ContentPlaceHolder1_btnfees');"
                                                    class="btn btn-xs btn-primary" />
                                                <asp:Label ID="lblFeesDtls" Text="Fees Collected Details" runat="server" Font-Bold="true"></asp:Label>
                                                <%--shreela 24032014--%>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="divFees" runat="server" style="display: none;">
                                        <table id="tblfeesdtl" style="width: 90%" class="tableIsys" runat="server">
                                            <tr id="trfeesDetails1" runat="server">
                                                <td style="height: 20px" class="formcontent">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <ajax:AsyncPostBackTrigger ControlID="lnkGetFees" EventName="Click" />
                                    <ajax:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="lnkGetFees" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <%--added by pranjali on 11-04-2014 start--%>
                            <asp:UpdatePanel ID="updtblEmsdtls" runat="server">
                                <ContentTemplate>
                                    <table id="tblEmsdtls" runat="server" style="width: 90%" class="formtable table-condensed">
                                        <tr>
                                            <td class="test" colspan="4">
                                                <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnExmDtls"
                                                    style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgnPhotoTrnExmDtl','ctl00_ContentPlaceHolder1_btnExmDtls');" />
                                                <asp:Label ID="lblExamTitle" runat="server" Font-Bold="True"></asp:Label>
                                                <%--Text="Exam Details"--%>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                            <div runat="server" id="divAgnPhotoTrnExmDtl" visible="true" style="display: block">
                                <asp:UpdatePanel ID="updexamdetailforqc" runat="server">
                                    <ContentTemplate>
                                        <table runat="server" id="tblexam" class="tableIsys" style="width: 90%;">
                                            <%--<tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblExamTitle" runat="server" Font-Bold="True" Text="Exam Details"></asp:Label>
                    </td>
                </tr>--%>
                                            <tr>
                                                <td class="formcontent" style="width: 20%; height: 24px;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblExam" runat="server" Style="color: black" Font-Bold="False"> </asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%; height: 24px;">
                                                    <asp:UpdatePanel ID="updExam" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlExam" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                                                Width="185px" BackColor="#FFFFB2">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblExmBody" runat="server" Style="color: black"></asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:UpdatePanel ID="UpdExmBody" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlExmBody" runat="server" CssClass="standardmenu" Width="185px"
                                                                BackColor="#FFFFB2">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" style="width: 20%; height: 24px;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblpreexamlng" runat="server" Font-Bold="False" Style="color: Black"></asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%; height: 24px;">
                                                    <asp:UpdatePanel ID="updPreExmLng" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu" Width="185px"
                                                                BackColor="#FFFFB2">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblCentre" runat="server" Style="color: black"></asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:UpdatePanel ID="updExmCentre" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlExmCentre" runat="server" CssClass="standardmenu" Width="185px"
                                                                BackColor="#FFFFB2" Visible="false">
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtExmCentre" runat="server" Enabled="false" CssClass="standardtextbox"
                                                                Visible="true" BackColor="#FFFFB2"></asp:TextBox>
                                                            <asp:Button ID="btnExmCentre" runat="server" CausesValidation="False" CssClass="standardbutton"
                                                                Text="Search" />
                                                            <input type="hidden" runat="server" id="hdnExmCentreCode" />
                                                            &nbsp;
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                                <table id="tblExmSchedule" runat="server" style="width: 90%" class="tableIsys" visible="false">
                                    <tr>
                                        <td class="test" align="left" colspan="2">
                                            <asp:Label ID="Label41" runat="server" Text="Exam Schedule" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td class="test" align="left" colspan="2">
                                            <asp:Label ID="Label5" Text="Preffered Exam Schedule" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                                            <asp:Label ID="lblNWExmdt" runat="server" Style="color: black"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 20px;">
                                            <asp:Label ID="lblNWExmdtValue" runat="server"></asp:Label>
                                            <asp:Label ID="lblNwExmfrmt" runat="server" Text="(dd/mm/yyyy)"></asp:Label>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                                            <asp:Label ID="lblExmdt1" Text="Preffered Exam Date 1" runat="server"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 20px;">
                                            <asp:Label ID="lblpref1value" runat="server"></asp:Label>
                                            <asp:Label ID="lblprefformat1" runat="server" Text="(dd/mm/yyyy)"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table runat="server" id="tblPrefExm" class="tableIsys" style="width: 90%;" visible="false">
                                    <tr>
                                        <td class="test" colspan="4" style="text-align: left;">
                                            <%--<asp:Label ID="Label5" Text="Preffered Exam Schedule" runat="server" Font-Bold="true"></asp:Label>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%; height: 38px" class="formcontent" align="left">
                                            <%--<asp:Label ID="lblExmdt1" Text="Preffered Exam Date 1" runat="server"></asp:Label>--%>
                                        </td>
                                        <td style="width: 30%; height: 38px" class="formcontent" align="left">
                                            <%-- <asp:Label ID="lblpref1value" runat="server"></asp:Label>
                        <asp:Label ID="lblprefformat1" runat="server" Text="(dd/mm/yyyy)"></asp:Label>--%>
                                        </td>
                                        <td style="width: 20%; height: 38px" class="formcontent" align="left">
                                            <asp:Label ID="lblExmdt2" runat="server" Text="Preffered Exam Date 2" Font-Bold="False"
                                                Visible="false"></asp:Label>
                                            <%--<span style="color: #ff0000">*</span> --%>
                                        </td>
                                        <td style="width: 30%; height: 38px" class="formcontent" align="left">
                                            <asp:Label ID="lblpref2value" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblprefformat2" runat="server" Text="(dd/mm/yyyy)" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%-- Old Exam Details start--%>
                            <table id="tbloldexm" runat="server" class="tableIsys" style="width: 90%;" visible="false">
                                <tr>
                                    <td class="test" colspan="4" style="text-align: left;">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnOldExmDtls"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivOldExmdtls','ctl00_ContentPlaceHolder1_BtnOldExmDtls');" />
                                        <asp:Label ID="lbloldexm" runat="server" Font-Bold="True" Text="Old Exam Details"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div id="DivOldExmdtls" runat="server" style="display: block;">
                                <table id="Table21" runat="server" class="tableIsys" style="width: 90%; display: none">
                                    <tr>
                                        <td class="formcontent" style="width: 20%; height: 24px;">
                                            <asp:Label ID="lblOExam" runat="server" Font-Bold="False" Text="Exam Mode"> </asp:Label>
                                            <span style="color: #ff0000">*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 24px;">
                                            <asp:TextBox ID="txtExm" runat="server" Enabled="false" CssClass="standardtextbox"
                                                BackColor="#FFFFB2"></asp:TextBox>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lbloldexmbody" runat="server" Style="color: black" Text="Examination Body"></asp:Label>
                                            <span style="color: #ff0000">*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:TextBox ID="txtBody" runat="server" Enabled="false" CssClass="standardtextbox"
                                                BackColor="#FFFFB2"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formcontent" style="width: 20%; height: 24px;">
                                            <span style="color: Red">
                                                <asp:Label ID="lbloldpref" runat="server" Font-Bold="False" Text="Preffered Exam Language"
                                                    Style="color: Black"></asp:Label>*</span>
                                            <%--<span style="color: #ff0000">*</span>--%>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 24px;">
                                            <asp:TextBox ID="txtLang" runat="server" Enabled="false" CssClass="standardtextbox"
                                                BackColor="#FFFFB2"></asp:TextBox>
                                            <%--   <asp:UpdatePanel ID="updPreExmLng" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu" DataTextField="ParamDesc1"
                                    DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="DSddlpreeamlng">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DSddlpreeamlng" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <span style="color: Red">
                                                <asp:Label ID="lbloldCentre" runat="server" Style="color: black" Text="Exam Centre"></asp:Label>*</span>
                                            <%--   <span style="color: #ff0000">*</span>--%>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="textoldexmcenter" runat="server" Enabled="false" CssClass="standardtextbox"
                                                        BackColor="#FFFFB2"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--Old Exam Details End --%>
                            <%--added by pranjali on 11-04-2014 end--%>
                            <%--added by pranjali on 28-04-2014--%>
                            <%--New Exam Details Start --%>
                            <table id="tblNExmTitle" runat="server" class="formtable table-condensed" style="width: 90%;"
                                visible="false">
                                <tr>
                                    <td class="test" colspan="4" style="text-align: left;">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnNwExm"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNewExmDtls','ctl00_ContentPlaceHolder1_btnNwExm');" />
                                        <asp:Label ID="lblNExamTitle" runat="server" Font-Bold="True" Text="New Exam Details"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div runat="server" id="divNewExmDtls" visible="true" style="display: block">
                                <table runat="server" id="tblNexam" class="tableIsys" style="width: 90%;" visible="false">
                                    <tr>
                                        <td class="formcontent" style="width: 20%; height: 24px;">
                                            <span style="color: #ff0000">
                                                <asp:Label ID="lblNExam" runat="server" Font-Bold="False" Style="color: black"> </asp:Label>*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 24px;">
                                            <asp:UpdatePanel ID="updNExam" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNExam" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                                        Width="185px" BackColor="#FFFFB2" OnSelectedIndexChanged="ddlNExam_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <span style="color: #ff0000">
                                                <asp:Label ID="lblNExmBody" runat="server" Style="color: black"></asp:Label>*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:UpdatePanel ID="UpdNExmBody" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNExmBody" runat="server" CssClass="standardmenu" Width="185px"
                                                        BackColor="#FFFFB2" OnSelectedIndexChanged="ddlNExmBody_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formcontent" style="width: 20%; height: 24px;">
                                            <span style="color: Red">
                                                <asp:Label ID="lblNpreexamlng" runat="server" Font-Bold="False" Style="color: Black"></asp:Label>*</span>
                                            <%--//removed text by pranjali on 25-04-2014--%>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 24px;">
                                            <asp:UpdatePanel ID="updNPreExmLng" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNpreeamlng" runat="server" CssClass="standardmenu" Width="185px"
                                                        BackColor="#FFFFB2" OnSelectedIndexChanged="ddlNpreeamlng_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <span style="color: Red">
                                                <asp:Label ID="lblNCentre" runat="server" Style="color: black"></asp:Label>*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNExmCenter" runat="server" CssClass="standardmenu" Visible="false"
                                                        BackColor="#FFFFB2" Width="185px">
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtNExmCenter" runat="server" Enabled="false" CssClass="standardtextbox"
                                                        Visible="true" BackColor="#FFFFB2"></asp:TextBox>
                                                    <asp:Button ID="btnNExmCenter" runat="server" CausesValidation="False" CssClass="standardbutton"
                                                        Text="Search" />
                                                    <input type="hidden" runat="server" id="hdnNExmCenter" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--New Exam Details end --%>
                            <%--added by pranjali on 28-04-2014--%>
                            <%--pranjali--%>
                            <table id="tbltrndtls" runat="server" class="tableIsys" style="width: 90%;" visible="false">
                                <tr>
                                    <td class="test" colspan="4" style="text-align: left;">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="BtnOldTrnDtls"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_Divoldtrndtls','ctl00_ContentPlaceHolder1_BtnOldTrnDtls');" />
                                        <asp:Label ID="Label3" Text="Old Training Details" runat="server" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div id="Divoldtrndtls" runat="server" style="display: none;">
                                <table id="tbltrndtlsall" runat="server" class="tableIsys" style="width: 90%;">
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                                            <asp:Label ID="lblTrnMode1" runat="server" Style="color: black" Text="Training Mode"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 20px;">
                                            <asp:Label ID="lblTrnModeValue" runat="server"></asp:Label>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                                            <asp:Label ID="lblTrnLoc1" runat="server" Style="color: black" Text="Training Location"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 20px;">
                                            <asp:Label ID="lblTrnLocValue" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                                            <asp:Label ID="lblTrnInst1" runat="server" Style="color: black" Text="Training Institute"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 20px;">
                                            <asp:Label ID="lblTrnInstituteValue" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                                            <asp:Label ID="lblAcc1" runat="server" Style="color: black" Text="Accrediation No."></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 20px;" colspan="3">
                                            <asp:Label ID="lblAccvalue1" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                                            <asp:Label ID="lblTrnHrs1" runat="server" Style="color: black" Text="Training Hours"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%; height: 20px;">
                                            <asp:Label ID="lblTrnHrsValue1" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td id="Td16" class="formcontent" runat="server" style="width: 20%">
                                        </td>
                                        <td id="Td17" class="formcontent" runat="server" style="width: 30%">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:UpdatePanel ID="updtrn" runat="server">
                                <ContentTemplate>
                                    <table visible="true" runat="server" id="tbltrn" class="tableIsys" style="width: 90%;">
                                        <tr>
                                            <td class="test" colspan="4" style="text-align: left;">
                                                <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="BtnTrnDtls"
                                                    style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_Divtrndtls','ctl00_ContentPlaceHolder1_BtnTrnDtls');" />
                                                <asp:Label ID="lblTrnDtl" Text="Training Details" runat="server" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="Divtrndtls" runat="server" style="display: block;">
                                        <table visible="true" runat="server" id="tbltrndtlss" class="tableIsys" style="width: 90%;">
                                            <tr>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="Label2" runat="server" Style="color: black" Text="Training Mode"></asp:Label>*</span>
                                                    <%-- <span style="color: #ff0000">*</span>--%>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:UpdatePanel ID="updTrnMode" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlTrnMode" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                                                Width="250px" BackColor="#FFFFB2" Enabled="true" OnSelectedIndexChanged="ddlTrnMode_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblTrnLoc" runat="server" Style="color: black" Text="Training Location"></asp:Label>*</span>
                                                    <%-- <span style="color: #ff0000">*</span>--%>
                                                </td>
                                                <td class="formcontent" style="width: 30%;" colspan="3">
                                                    <asp:UpdatePanel ID="updTrnLoc" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlTrnLoc" runat="server" CssClass="standardmenu" Visible="true"
                                                                AutoPostBack="true" Width="250px" BackColor="#FFFFB2" OnSelectedIndexChanged="ddlTrnLoc_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <input type="hidden" runat="server" id="hdnTrnLocation" name="hdnTrnLocation" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <%--Added by M.Valvi--%>
                                            </tr>
                                            <tr>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblTrnInstitute" runat="server" Style="color: black" Text="Training Institute"></asp:Label>*</span>
                                                    <%-- <span style="color: #ff0000">*</span>--%>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:UpdatePanel ID="updTrnInstitute" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlTrnInstitute" runat="server" CssClass="standardmenu" Visible="true"
                                                                Width="250px" BackColor="#FFFFB2" AutoPostBack="true" OnSelectedIndexChanged="ddlTrnInstitute_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <input type="hidden" runat="server" id="hdnTrnInstitute" name="hdnTrnInstitute" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblAccrdtn" runat="server" Style="color: black" Text="Accreditation Number"></asp:Label>
                                                </td>
                                                <td style="width: 30%;" class="formcontent" align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblAccrdtnValue" runat="server" MaxLength="50"></asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" class="formcontent" align="left">
                                                    <asp:Label ID="lblHrnTrn" runat="server" Font-Bold="False"></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td style="width: 30%" class="formcontent" align="left">
                                                    <asp:UpdatePanel ID="updTrnHrs" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlHrsTrn" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                                                BackColor="#FFFFB2" Width="250px">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                                    <%--<asp:Label ID="lblHrnTrn" runat="server" Font-Bold="False"></asp:Label>
                        <span style="color: #ff0000">*</span>--%>
                                                    <asp:Label ID="lblExmType" runat="server" Font-Bold="False" Visible="False"></asp:Label>
                                                </td>
                                                <td style="width: 30%; height: 20px" class="formcontent" align="left">
                                                    <%--<asp:DropDownList ID="ddlHrsTrn" runat="server" Width="120px">
                            <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                        </asp:DropDownList>--%>
                                                    <%--<asp:UpdatePanel ID="updExpTpe" runat="server" >
                            <ContentTemplate>--%>
                                                    <asp:DropDownList ID="ddlExmTpe" runat="server" Visible="False" Width="120px" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlExmTpe_SelectedIndexChanged">
                                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                        <asp:ListItem Text="New Advisor" Value="NADV"></asp:ListItem>
                                                        <asp:ListItem Text="Repeater" Value="REXM"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                            <div id="divPOI" runat="server" visible="false">
                                <table runat="server" id="tblPOI" class="tableIsys" style="width: 90%;">
                                    <tr>
                                        <td class="test" colspan="4" style="text-align: left;">
                                            <asp:Label ID="lblPOITitle" runat="server" Font-Bold="True" Text="Proof of Document"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblBasicQual" runat="server" Style="color: black" Text="Basic Qualification"></asp:Label>
                                            <span style="color: red">*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:UpdatePanel ID="UpdBasicQual" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlBasicQual" runat="server" CausesValidation="true" BackColor="#FFFFB2"
                                                        CssClass="standardmenu">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblBoardName" runat="server" Style="color: black" Text="Board Name"></asp:Label>
                                            <span style="color: red">*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:TextBox ID="txtBoardName" runat="server" BackColor="#FFFFB2" CssClass="standardtextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblBasicRNo" runat="server" Style="color: black" Text="Basic Qual. Roll No"></asp:Label>
                                            <span style="color: red">*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:TextBox ID="txtBasicRNo" runat="server" BackColor="#FFFFB2" CssClass="standardtextbox"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="REVBasicRNo" runat="server" ControlToValidate="txtBasicRNo"
                                                ErrorMessage="Basic Roll No. should be Numeric.!!" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblYrPass" runat="server" Style="color: black" Text="Year of Passing"></asp:Label>
                                            <span style="color: red">*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:TextBox CssClass="standardtextbox" runat="server" ID="txtYrPass" Width="90px"
                                                BackColor="#FFFFB2" />
                                            <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                            <asp:TextBox CssClass="standardtextbox" ID="txtDtValidate" Style="display: none"
                                                runat="server" Width="80px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtYrPass"
                                                PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />
                                            <asp:RequiredFieldValidator ID="RFV" runat="server" SetFocusOnError="true" ControlToValidate="txtYrPass"
                                                Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                            <asp:CompareValidator ID="CV" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                                Type="Date" ControlToValidate="txtYrPass" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                            <asp:RangeValidator ID="RGV" runat="server" ControlToValidate="txtYrPass" Display="Dynamic"
                                                ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                Type="Date"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblpfeduproof" runat="server" Style="color: black" Text="Qualification"></asp:Label>
                                            <span style="color: red">*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%;" colspan="3">
                                            <asp:UpdatePanel ID="Upeducationproof" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddleducationproof" runat="server" CssClass="standardmenu" DataTextField="ParamDesc"
                                                        DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="dseducationproof"
                                                        BackColor="#FFFFB2">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="dseducationproof" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                                    </asp:SqlDataSource>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="formcontent" style="width: 20%;">
                                        </td>
                                        <td class="formcontent" style="width: 501px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblCasteCat" runat="server" Style="color: black" Text="Category"></asp:Label><span
                                                style="color: #ff0000">*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:DropDownList ID="ddlCasteCat" runat="server" CssClass="standardmenu" BackColor="#FFFFB2">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblPrimProf" runat="server" Style="color: black" Text="Primary Profession"></asp:Label>
                                            <span style="color: #ff0000">*</span>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:TextBox ID="txtPrimProf" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--<div id="divAdvDtl" runat="server">
            <table  class="formtable" style="width: 90%;">
                 <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblAdvDtl" runat="server" Font-Bold="True" Text="Candidate Image Details"></asp:Label>
                    </td>
                 </tr>
                 <tr>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label4" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="updAnPhoto" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblPhotoPath" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="AgnPhotoUpload" runat="server" Width="98%"></asp:FileUpload>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="AgnPhotoUpload"
                                    OnServerValidate="CustomValidator1_ServerValidate" SetFocusOnError="True">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label6" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="updAgnSign" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblSignPath" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="AgnSignUpload" runat="server" Width="99%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVSignature" runat="server" ControlToValidate="AgnSignUpload"
                                    OnServerValidate="CVSignature_ServerValidate" SetFocusOnError="True">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                 </tr>
                 
                 <tr>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="Label7"  runat="server"></asp:Label><span
                                    style="color: #ff0000">*</span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    
                    <td style="height: 20px" class="formcontent" align="left" colspan="3">
                       <table style="width:100%;">
                          <tr>
                             <td class="formcontent" style="width:40%;" align="left"> 
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                   <asp:Label ID="lblPANPath" runat="server" Visible="false"></asp:Label>
                                   <asp:FileUpload ID="PANUpload" runat="server" Width="99%" EnableViewState="true">
                                   </asp:FileUpload>
                                   <asp:CustomValidator ID="CVPANValidator" runat="server" ControlToValidate="PANUpload"
                                    OnServerValidate="CVPANValidator_ServerValidate" SetFocusOnError="True">
                                   </asp:CustomValidator>
                               </ContentTemplate>
                               </asp:UpdatePanel>
                            </td>
                    
                        <td style="width: 15%; height: 20px" class="formcontent" align="left">
                            <asp:UpdatePanel ID="upnllblNocDoc" runat="server" Visible="false">
                            <ContentTemplate>
                                <asp:Label ID="Label8" runat="server"></asp:Label><span
                                    style="color: #ff0000">*</span>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            </td>
                            <td id="tdNocDoc" runat="server" class="formcontent" style="width:30%;visibility:hidden" align="left"> 
                                <asp:UpdatePanel ID="upnlNocDoc" runat="server" >
                                <ContentTemplate>
                                 <asp:Label ID="lblNoc" runat="server" Visible="false"></asp:Label>
                                   <asp:FileUpload ID="NocDocUpload" runat="server" Width="139%" 
                                        EnableViewState="true">
                                   </asp:FileUpload>
                                    <asp:CustomValidator ID="CVDocUpload" runat="server" ControlToValidate="NocDocUpload"
                                   SetFocusOnError="True" onservervalidate="CVDocUpload_ServerValidate">
                                </asp:CustomValidator>
                               </ContentTemplate>
                               </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                         <td class="formcontent" style="width:25%;" align="left"> </td>
                         <td class="formcontent" style="width:25%;" align="left" >
                               <asp:LinkButton ID="lnkArf" runat="server" Visible = "true"  Text="ARF Form Pg1"
                                 onclick="Click_Arf"   ></asp:LinkButton>
                            </td>
                            <td class="formcontent" style="width:25%;" align="left">
                               <asp:LinkButton ID="lnkArfForm" runat="server" Text="ARF Form Pg2" Visible = "true"></asp:LinkButton>
                            </td>
                            <td class="formcontent" style="width:25%;" align="left">
                               <asp:LinkButton ID="lnkeducation" runat="server" Visible = "true" Text="Education Proof" 
                                 onclick="Click_Educationproof"  ></asp:LinkButton>
                            </td>
                            </tr>
                       </table>
                    </td>  
                </tr>
                
                <tr>
                   <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndArf1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblArf1" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndArf1" runat="server" Width="98%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVArf1" runat="server" ControlToValidate="CndArf1"
                                     SetFocusOnError="True" onservervalidate="CVArf1_ServerValidate">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label10" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndArf2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblArf2" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndArf2" runat="server" Width="99%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVArf2" runat="server" ControlToValidate="AgnSignUpload"
                                     SetFocusOnError="True" onservervalidate="CVArf2_ServerValidate">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                   <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label11" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndEduProof1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblEdu1" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndEduProof1" runat="server" Width="98%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVEduProof1" runat="server" ControlToValidate="CndEduProof1"
                                     SetFocusOnError="True" onservervalidate="CVEduProof1_ServerValidate" >
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label12" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndEduProof2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblEdu2" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndEduProof2" runat="server" Width="99%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVEduProof2" runat="server" ControlToValidate="CndEduProof2"
                                     SetFocusOnError="True" onservervalidate="CVEduProof2_ServerValidate" >
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                 
            </table>
       </div>--%>
                            <%--//pranjali--%>
                            <%--Added by rachana on 14022014 for Transfer Case Details start--%>
                            <%--<table id="tblcol" style="width: 90%" class="formtable" runat="server">
            <tr>
                <td colspan="4" align="left" class="test">
                    <input runat="server" type="button" class="standardlink" value="-" id="btntransCollapse"
                        style="width: 20px;" onclick="ShowReqDtlNew('ctl00_ContentPlaceHolder1_divtransfer','ctl00_ContentPlaceHolder1_btntransCollapse');" />
                    <asp:Label ID="lblheadtrans" runat="server" Text="Transfer/Composite Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>--%>
                            <%--<div runat="server" id="divtransfer" style="display: none;">
            <table id="TblTransfer" runat="server" style="width: 90%" class="formtable">
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblTrfrFlag" runat="server" Style="color: black" Text="Transfer Case">
                        </asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox" AutoPostBack="false"
                            OnCheckedChanged="cbTrfrFlag_CheckedChanged" TabIndex="19" />
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblCompLcn" runat="server" Style="color: black" Text="Composite License">
                        </asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox" Enabled="true"
                            AutoPostBack="false" TabIndex="20" OnCheckedChanged="cbTccCompLcn_CheckedChanged" />
                    </td>
                </tr>
                <tr id="trTCCase" runat="server">
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lbloldLcnNo" runat="server" Style="color: black" Text="Life License No">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtOldTccLcnNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                            TabIndex="21">
                        </asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                            InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo"
                            FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lblOldLcnexpDate" runat="server" Style="color: black" Text="Old License Exp.Date">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                            TabIndex="22" />
                        <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <asp:TextBox ID="txtOldLicense" runat="server" CssClass="standardtextbox" Style="display: none">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CldrExtendrOldLicense" runat="server" TargetControlID="txtDate"
                            PopupButtonID="btnoldlicense" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RFVOldLicense" runat="server" SetFocusOnError="true"
                            ControlToValidate="txtDate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic">
                        </asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="COMPAREVALIDATOROldLicense" runat="server" ErrorMessage="Invalid date!"
                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtDate" Display="Dynamic">
                        </asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RVOldLicense" runat="server" ControlToValidate="txtDate"
                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                            MinimumValue="1900-01-01" Type="Date">
                        </asp:RangeValidator>
                    </td>
                </tr>
                <tr id="trTCCase1" runat="server">
                    <td align="left" class="formcontent" style="width: 20%;">
                     <span style="color:Red">
                        <asp:Label ID="lblPrevInsurerName" runat="server" Style="color: black" Text="Prev Insurer Name">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtTccPrevInsurerName" runat="server" CssClass="standardtextbox"
                            BackColor="#FFFFB2" TabIndex="23">
                        </asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                            InvalidChars=",#$@%^!*()&''%^~`1234567890" FilterMode="InvalidChars" TargetControlID="txtTccPrevInsurerName"
                            FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lblNOCFlag" runat="server" Style="color: black" Text="NOC Received"></asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbNOCFlag" runat="server" CssClass="standardcheckbox" BackColor="#FFFFB2"
                            AutoPostBack="false" Visible="false" />
                        <asp:UpdatePanel ID="upnlRbtNoc" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal" CssClass="radiobtn"
                                    TabIndex="24" AutoPostBack="true" OnSelectedIndexChanged="RbtNoc_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Y" Selected="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="1" Text="N">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="trAckRcv" runat="server" style="height: 10%">
                    <td style="width: 20%;" class="formcontent">
                    </td>
                    <td style="width: 30%;" class="formcontent">
                    </td>
                    <td style="width: 20%;" class="formcontent">
                        <asp:UpdatePanel ID="upnllblAckrcv" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblAckrcv" runat="server" Visible="false" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 30%;" class="formcontent">
                        <asp:UpdatePanel ID="upnlRbAckRev" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="RbAckRev" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                    Visible="false" TabIndex="25">
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="trNOCAck" runat="server" visible="false">
                    <td class="formcontent" align="left" style="width: 20%;">
                        <asp:Label ID="lblNOCAck" runat="server" Text="NOC/Acknowledgement"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkNOCAck" runat="server" BackColor="#FFFFB2"
                            TabIndex="118" />
                    </td>
                    <td class="formcontent" colspan="2">
                    </td>
                </tr>
            </table>
        </div>--%>
                            <%--added by pranjali on 13-03-2014 for transfr deatils start--%>
                            <table id="trnsfrtitle" class="tableIsys table-condensed" runat="server" style="width: 90%;">
                                <tr>
                                    <td colspan="4" class="test">
                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
                                                <%--<input runat="server" type="button" class="standardlink" value="+" id="btnTransferDetails" style="width: 20px;"
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTrnsferDetails','ctl00_ContentPlaceHolder1_btnTransferDetails');" />--%>
                                                <asp:Label ID="lblTransferDtl" Text="Transfer Details" runat="server" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                <asp:Label ID="lblTrfrFlag" runat="server" Style="color: black" Text="Transfer Case"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp
                                                <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox" AutoPostBack="true"
                                                    OnCheckedChanged="cbTrfrFlag_CheckedChanged" TabIndex="19" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <div id="divTrnsferDetails" runat="server" visible="false" style="display: block;">
                                        <table class="tableIsys" style="width: 90%;">
                                            <%--<tr>
			                                    <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblTrfrFlag" runat="server" Style="color: black" Text="Transfer Case" ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox"  
                                                        AutoPostBack ="false"
                                                        oncheckedchanged="cbTrfrFlag_CheckedChanged"  TabIndex="19"  />   
                                                </td>
                                                <td align="left" class="formcontent" style="width:20%;"></td>
                                                <td class="formcontent" style="width: 30%;"></td>
			                               </tr>--%>
                                            <tr id="trTCCase" runat="server">
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: red">
                                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                                        <asp:Label ID="lbloldLcnNo" runat="server" Style="color: black" Text="License No"></asp:Label>*</span>
                                                    <%--  <span style="color: #ff0000">*</span>--%>
                                                </td>
                                                <%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox ID="txtOldTccLcnNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        TabIndex="21"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                        InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo"
                                                        FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: red">
                                                        <asp:Label ID="lblOldLcnexpDate" runat="server" Style="color: black"></asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="standardtextbox" TabIndex="22"
                                                        BackColor="#FFFFB2" />
                                                    <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                    <asp:TextBox ID="txtOldLicense" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CldrExtendrOldLicense" runat="server" TargetControlID="txtDate"
                                                        PopupButtonID="btnoldlicense" Format="dd/MM/yyyy" />
                                                    <asp:RequiredFieldValidator ID="RFVOldLicense" runat="server" SetFocusOnError="true"
                                                        ControlToValidate="txtDate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="COMPAREVALIDATOROldLicense" runat="server" ErrorMessage="Invalid date!"
                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtDate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RVOldLicense" runat="server" ControlToValidate="txtDate"
                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                    <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                                                </td>
                                            </tr>
                                            <tr id="trTCCase1" runat="server">
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: red">
                                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                                        <asp:Label ID="lblPrevInsurerName" runat="server" Style="color: black" Text="Insurer Name"></asp:Label>*</span>
                                                    <%-- <span style="color: #ff0000">*</span>--%>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <%--<asp:TextBox id="txtTccPrevInsurerName" runat="server" 
                                                        CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="23" Visible="false" ></asp:TextBox>--%>
                                                    <asp:DropDownList ID="ddlTrnsfrInsurName" runat="server" CssClass="standardmenu"
                                                        BackColor="#FFFFB2" Width="270px" TabIndex="65">
                                                    </asp:DropDownList>
                                                    <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtTccPrevInsurerName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblNOCFlag" runat="server" Style="color: black" Text="NOC Received"></asp:Label>*</span>
                                                    <%--  <span style="color: #ff0000">*</span>--%>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <%--// 01...06/09/2012...Miti--%>
                                                    <asp:CheckBox ID="cbNOCFlag" runat="server" CssClass="standardcheckbox" BackColor="#FFFFB2"
                                                        AutoPostBack="false" Visible="false" />
                                                    <%----%>
                                                    <asp:UpdatePanel ID="upnlRbtNoc" runat="server">
                                                        <ContentTemplate>
                                                            <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal" CssClass="radiobtn"
                                                                TabIndex="24" AutoPostBack="true" OnSelectedIndexChanged="RbtNoc_SelectedIndexChanged">
                                                                <%--<asp:ListItem Value="0" Text="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="1" Text="N">No</asp:ListItem>--%>
                                                                <%--//added by pranjali on 26-03-2014 start--%>
                                                                <asp:ListItem Value="Y" Text="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N" Text="N">No</asp:ListItem>
                                                                <%--//added by pranjali on 26-03-2014 end--%>
                                                            </asp:RadioButtonList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <%--// 01...06/09/2012...Miti--%>
                                            </tr>
                                            <tr id="trAckRcv" runat="server" style="height: 10%">
                                                <%--<td style="width:20%;" class="formcontent">
                                                <span style="color: red">
                                                <asp:Label ID="lblcndURNNo" Text="Candidate URN No." runat="server" Style="color: black"></asp:Label>*</span>
                                                </td>
                                                <td style="width:30%;" class="formcontent">
                                                <asp:TextBox id="txtCndURNNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                                </td>--%>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblissudate" runat="server" Text="License Issue Date" Style="color: black"></asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox ID="txtissudate" runat="server" CssClass="standardtextbox" TabIndex="22"
                                                        BackColor="#FFFFB2" />
                                                    <asp:Image ID="btnissu" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtissudate"
                                                        PopupButtonID="btnissu" Format="dd/MM/yyyy" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true"
                                                        ControlToValidate="txtissudate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="COMPAREVALIDATOR5" runat="server" ErrorMessage="Invalid date!"
                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtissudate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtissudate"
                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                    <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                                                </td>
                                                <td style="width: 20%;" class="formcontent">
                                                    <asp:UpdatePanel ID="upnllblAckrcv" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblAckrcv" runat="server" Visible="false" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td style="width: 30%;" class="formcontent">
                                                    <asp:UpdatePanel ID="upnlRbAckRev" runat="server">
                                                        <ContentTemplate>
                                                            <asp:RadioButtonList ID="RbAckRev" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                                Visible="false" TabIndex="25">
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                            <%--added by pranjali on 13-03-2014 for transfr deatils end--%>
                            <%--added by pranjali on 13-03-2014 for composite deatils start--%>
                            <table id="CompositeTitle" runat="server" class="tableIsys table-condensed" style="width: 90%;">
                                <tr>
                                    <td colspan="4" class="test">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <%--<input runat="server" type="button" class="standardlink" value="+" id="btnCompositeDetails" style="width: 20px;"
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCompositeDetails','ctl00_ContentPlaceHolder1_btnCompositeDetails');" />--%>
                                                <asp:Label ID="lblCompositeDtl" Text="Composite Details" runat="server" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                <asp:Label ID="lblCompLcn" runat="server" Style="color: black" Text="Composite Case"></asp:Label>&nbsp
                                                <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox" Enabled="true"
                                                    AutoPostBack="true" TabIndex="20" OnCheckedChanged="cbTccCompLcn_CheckedChanged" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <%--<td class="test">
                                               <asp:CheckBox ID="chkCompAgnt" runat="server" CssClass="standardcheckbox"  Enabled="true" TabIndex="21"  />
                                               </td>--%>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <div id="divCompositeDetails" runat="server" visible="false" style="display: block;">
                                        <table class="tableIsys" style="width: 90%;">
                                            <%--<tr>                                            
                                                <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblCompLcn" runat="server" Style="color: black" Text="Composite License" ></asp:Label></td>
                                                <td class="formcontent" style="width: 30%;">
                                                     <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox"  Enabled="true" AutoPostBack ="false"
                                                         TabIndex="20" oncheckedchanged="cbTccCompLcn_CheckedChanged" />
                                                </td>
                                                <td align="left" class="formcontent" style="width:20%;"></td>
                                                <td class="formcontent" style="width: 30%;"></td>
			                               </tr>--%>
                                            <tr id="tr2" runat="server">
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: red">
                                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                                        <asp:Label ID="lblCompLicNo" runat="server" Style="color: black" Text="License No"></asp:Label>*</span>
                                                </td>
                                                <%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox ID="txtCompLicNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        TabIndex="21"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server"
                                                        InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtCompLicNo"
                                                        FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: red">
                                                        <asp:Label ID="lblComplicnseExpDt" runat="server" Style="color: black"></asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox ID="txtCompLicExpDt" runat="server" CssClass="standardtextbox" TabIndex="22" />
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCompLicExpDt"
                                                        PopupButtonID="Image1" Format="dd/MM/yyyy" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                                        ControlToValidate="txtCompLicExpDt" Enabled="false" ErrorMessage="Mandatory!"
                                                        Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="COMPAREVALIDATOR2" runat="server" ErrorMessage="Invalid date!"
                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtCompLicExpDt" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCompLicExpDt"
                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                    <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                                                </td>
                                            </tr>
                                            <tr id="tr3" runat="server">
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: red">
                                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                                        <asp:Label ID="lblCompInsurerName" runat="server" Style="color: black" Text="Insurer Name"></asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <%--<asp:TextBox id="txtCompInsurerName" runat="server" 
                                                        CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="23" ></asp:TextBox>--%>
                                                    <asp:DropDownList ID="ddlCompInsurerName" runat="server" CssClass="standardmenu"
                                                        BackColor="#FFFFB2" Width="270px" TabIndex="65">
                                                    </asp:DropDownList>
                                                    <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtCompInsurerName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                </td>
                                            </tr>
                                            <%--added by pranjali on 28-03-2014--%>
                                            <%--shree--%>
                                            <%--shree07--%>
                                            <%--<tr id="trrenwl" runat="server" visible="false">
                                                     <td id="Td12" align="left" runat="server" class="formcontent" style="width:20%;">
                                                     <span style="color:Red">
                                                     <asp:Label ID="lblinsrentype" runat="server" style="color:Black"></asp:Label>*</span>
                                                     </td>
                                                     <td id="Td13" runat="server" class="formcontent" >
                                                     <asp:DropDownList ID="ddlinsrentype" runat="server" CssClass="standardmenu"  BackColor="#FFFFB2" 
                                                     Width="210px" AutoPostBack="true" OnSelectedIndexChanged="ddlinsrentype_SelectedIndexChanged"></asp:DropDownList>
                                                     </td>
                                                     <td id="Td14" runat="server" class="formcontent" style="width:20%;">
                                                     <span style="color:Red">
                                                     <asp:Label ID="lbllyftrngcmpltd" runat="server" style="color:Black"></asp:Label>*</span>
                                                     </td>
                                                     <td id="Td15" runat="server" class="formcontent">
                                                     <asp:DropDownList ID="ddllyftrngcmpltd" runat="server" CssClass="standardmenu"  BackColor="#FFFFB2" 
                                                     Width="210px" Enabled="false" ></asp:DropDownList>
                                                     </td>
                                          </tr>--%>
                                            <%--shree--%>
                                        </table>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cbTccCompLcn" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                            <table id="trIsPriorAgt" class="tableIsys" runat="server" style="height: 5%; width: 90%;">
                                <tr>
                                    <td align="left" colspan="4" class="test">
                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chkCompAgnt" runat="server" CssClass="standardcheckbox" Enabled="true"
                                                    TabIndex="21" OnCheckedChanged="chkCompAgnt_CheckedChanged" AutoPostBack="true" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <%--added by pranjali on 28-03-2014--%>
                            <%--added by pranjali on 13-03-2014 for composite deatils end--%>
                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                <ContentTemplate>
                                    <table id="tblCndURN" runat="server" style="width: 90%;" visible="false">
                                        <tr>
                                            <td class="test" colspan="4" style="text-align: left;">
                                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                    <ContentTemplate>
                                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="BtnCndTrnsDtls"
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCndTrnsDtls','ctl00_ContentPlaceHolder1_BtnCndTrnsDtls');" />
                                                        <asp:Label ID="lbltitleURN" runat="server" Font-Bold="True" Text="Candidate URN No."></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="divCndTrnsDtls" runat="server" style="display: none;">
                                        <table id="tblCndURNDtl" runat="server" style="width: 90%; display: block">
                                            <tr>
                                                <td align="left" class="formcontent">
                                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                        <ContentTemplate>
                                                            <span style="color: red">
                                                                <asp:Label ID="lblcndURNNo" Text="Candidate URN No." runat="server" Style="color: black"></asp:Label>*</span>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                            <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtCndURNNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                                            <asp:Label ID="lblcndURNVal" runat="server" Style="color: Black" Visible="false"></asp:Label>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                            <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblTrnsfrReqNo" Text="IRDA Transfer Request No." runat="server" Style="color: black"></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox ID="TxtTrnsfrReqNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%-- added by shreela on 18-04-2014 for Renewal Details start--%>
                            <table id="tblRenewalCollapse" style="width: 90%" class="formtable table-condensed"
                                runat="server" visible="false">
                                <tr>
                                    <td colspan="4" align="left" class="test">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnRenew"
                                            style="width: 20px;" onclick="ShowReqDtlRenew('ctl00_ContentPlaceHolder1_divRenewal','ctl00_ContentPlaceHolder1_btnRenew');" />
                                        <asp:Label ID="lblRenew" runat="server" Text="Renewal Details" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="updrenewal" runat="server">
                                <ContentTemplate>
                                    <div id="divRenewal" runat="server" visible="false" style="display: none">
                                        <table id="tblRenewal" style="width: 90%" class="tableIsys" runat="server">
                                            <tr>
                                                <td align="left" colspan="4" class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblCndType" runat="server" Style="color: Black"></asp:Label>
                                                </td>
                                                <td id="Td1" runat="server" class="formcontent" style="width: 30%;">
                                                    <asp:Label ID="lblCndVal" runat="server"></asp:Label>
                                                </td>
                                                <td id="Td2" runat="server" class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblCount" runat="server" Style="color: Black"></asp:Label>
                                                </td>
                                                <td id="Td3" runat="server" class="formcontent" style="width: 30%;">
                                                    <asp:Label ID="lblCountVal" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="Comp" runat="server" style="display: none;">
                                                <td id="Td4" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblRenewType" runat="server" Style="color: Black"></asp:Label>*</span>
                                                </td>
                                                <td id="Td5" runat="server" class="formcontent">
                                                    <asp:DropDownList ID="ddlRenewType" runat="server" CssClass="standardmenu" BackColor="#FFFFB2"
                                                        Width="210px" AutoPostBack="true" OnSelectedIndexChanged="ddlRenewType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td id="Td6" runat="server" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lbllyfTraining" runat="server" Style="color: Black"></asp:Label>*</span>
                                                </td>
                                                <td id="Td7" runat="server" class="formcontent">
                                                    <asp:DropDownList ID="ddllyfTraining" runat="server" CssClass="standardmenu" BackColor="#FFFFB2"
                                                        Width="210px" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <%--Added by kalyani to fetch Renewal record on QC module start--%>
                                            <tr id="trCompQC" runat="server" visible="false">
                                                <td id="Td8" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblQCRenewType" runat="server" Style="color: Black"></asp:Label></span>
                                                </td>
                                                <td id="Td9" runat="server" class="formcontent">
                                                    <asp:Label ID="lbltxtQCRenewType" runat="server" Style="color: Black"></asp:Label>
                                                </td>
                                                <td id="Td10" runat="server" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblQClyfTraining" runat="server" Style="color: Black"></asp:Label></span>
                                                </td>
                                                <td id="Td11" runat="server" class="formcontent">
                                                    <asp:Label ID="lbltxtQClyfTraining" runat="server" Style="color: Black"></asp:Label>
                                                </td>
                                            </tr>
                                            <%--Added by kalyani to fetch Renewal record on QC module end--%>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%-- added by shreela on 18-04-2014 for Renewal Details end--%>
                            <%--added by pranjali on 05-01-2015 start for repeater case--%>
                            <table id="TblRptrTitle" style="width: 90%" class="formtable table-condensed" runat="server"
                                visible="false">
                                <tr>
                                    <td colspan="4" align="left" class="test">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnRptr"
                                            style="width: 20px;" onclick="ShowReqDtlRenew('ctl00_ContentPlaceHolder1_divRptr','ctl00_ContentPlaceHolder1_btnRptr');" />
                                        <asp:Label ID="TblRptrDtls" runat="server" Text="Repeater Details" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                <ContentTemplate>
                                    <div id="divRptr" runat="server" style="display: none">
                                        <table id="tblRptr" style="width: 90%" class="tableIsys" runat="server">
                                            <tr>
                                                <td align="left" colspan="4" class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblRptrCndTyp" Text="Candidate Type" runat="server" Style="color: Black"></asp:Label>
                                                </td>
                                                <td id="Td12" runat="server" class="formcontent" style="width: 30%;">
                                                    <asp:Label ID="lblRptrCndTypVal" runat="server"></asp:Label>
                                                </td>
                                                <td id="Td13" runat="server" class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblRptrCount" Text="ReExam Count" runat="server" Style="color: Black"></asp:Label>
                                                </td>
                                                <td id="Td15" runat="server" class="formcontent" style="width: 30%;">
                                                    <asp:Label ID="lblRptrCountVal" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr4" runat="server">
                                                <td id="Td22" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="lblRptrTyp" Text="ReExam Type" runat="server" Style="color: Black"></asp:Label></span>
                                                </td>
                                                <td id="Td23" runat="server" class="formcontent">
                                                    <asp:Label ID="lblRptrTypVal" runat="server" Style="color: Black"></asp:Label>
                                                </td>
                                                <td id="Td24" runat="server" class="formcontent" style="width: 20%;">
                                                    <span style="color: Red">
                                                        <asp:Label ID="Label17" runat="server" Style="color: Black"></asp:Label></span>
                                                </td>
                                                <td id="Td25" runat="server" class="formcontent">
                                                    <asp:Label ID="Label18" runat="server" Style="color: Black"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%--added by pranjali on 05-01-2015 end for repeater case--%>
                            <%--added by shreela for old license details start--%>
                            <table id="tbloldlic" runat="server" style="width: 90%" class="tableIsys" visible="false">
                                <%-- <tr>
            <td align="center" colspan="4">
                    <asp:Label ID="Label6" runat="server" Text="NOTE: License will be updated once license details are uploaded from Lic User" ForeColor="red"></asp:Label>
            </td>
        </tr>--%>
                                <tr>
                                    <td id="tdoldlic" class="test" runat="server" colspan="4">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnOldLicDtls"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divoldlic','ctl00_ContentPlaceHolder1_BtnOldLicDtls');" />
                                        <asp:Label ID="lbloldlic" runat="server" Text="Old License Details" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div id="divoldlic" runat="server" style="display: none" visible="false">
                                <table id="tbloldlicdtls" runat="server" class="tableIsys" style="width: 90%">
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 20%">
                                            <asp:Label ID="lbloldlicno" Text="License No" runat="server"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%">
                                            <asp:Label ID="lbloldlicnoval" runat="server"></asp:Label>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%">
                                            <asp:Label ID="lbloldexpdate" Text="Old LicenseExpDate" runat="server"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%">
                                            <asp:Label ID="lbloldexpdateval" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formcontent" style="width: 20%">
                                            <asp:Label ID="lbloldlicissu" Text="Old License Issue Date" runat="server"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%">
                                            <asp:Label ID="lbloldlicissuval" runat="server"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 20%">
                                        </td>
                                        <td class="formcontent" style="width: 30%">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--added by shreela for old license details end--%>
                            <%--added by shreela for new license details start--%>
                            <table id="tblnewlic" runat="server" style="width: 90%" class="tableIsys" visible="false">
                                <tr>
                                    <td id="tdnewlic" class="test" runat="server" colspan="4">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnNewLicDtls"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divnewlic','ctl00_ContentPlaceHolder1_BtnNewLicDtls');" />
                                        <asp:Label ID="lblnewlic" runat="server" Text="New License Details" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div id="divnewlic" runat="server" style="display: none" visible="false">
                                <table id="tblnewlicdtls" runat="server" class="tableIsys" style="width: 90%">
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 20%">
                                            <asp:Label ID="lblnewlicno" Text="License No" runat="server"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%">
                                            <asp:Label ID="lblnewlicnoval" runat="server"></asp:Label>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%">
                                            <asp:Label ID="lblnewexpdate" Text="LicenseExpDate" runat="server"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%">
                                            <asp:TextBox ID="txtnewexpdate" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtnewexpdate"
                                                PopupButtonID="btnCalendar" Format="dd/MM/yyyy" Enabled="false" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true"
                                                ControlToValidate="txtnewexpdate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Invalid date!"
                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtnewexpdate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtnewexpdate"
                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                            <%--  <asp:Label ID="Label8" runat="server"></asp:Label>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formcontent" style="width: 20%">
                                            <asp:Label ID="lblnewlicissu" Text="License Issue Date" runat="server"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="width: 30%">
                                            <asp:TextBox ID="txtnewlicissu" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                            <asp:Image ID="btnCalenderissu" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtnewlicissu"
                                                PopupButtonID="btnCalenderissu" Format="dd/MM/yyyy" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                                                ControlToValidate="txtnewlicissu" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                            <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Invalid date!"
                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtnewlicissu" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtnewlicissu"
                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                        </td>
                                        <td class="formcontent" style="width: 20%">
                                        </td>
                                        <td class="formcontent" style="width: 30%">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--added by shreela for new license details end--%>
                            <%--Added by rachana on 14022014 for Transfer Case Details end--%>
                            <%--Added by Pranjali on 13-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 Start--%>
                            <table id="TblFeesWaiver" class="tableIsys" runat="server" style="height: 5%; width: 90%;">
                                <tr>
                                    <td align="left" colspan="4" class="test">
                                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chkFeesWaivr" Text="Fees Waiver" runat="server" CssClass="standardcheckbox"
                                                    Enabled="false" TabIndex="21" OnCheckedChanged="chkFeesWaivr_CheckedChanged"
                                                    AutoPostBack="true" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                <ContentTemplate>
                                    <div id="divRmrk" runat="server" style="display: none;">
                                        <table class="tableIsys" style="width: 90%;">
                                            <tr id="trRmrk" runat="server">
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: red">
                                                        <asp:Label ID="lblSMRmrks" runat="server" Style="color: black" Text="Remarks"></asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" colspan="3">
                                                    <asp:TextBox ID="txtRemrk" runat="server" Rows="3" TextMode="multiline" CssClass="standardtextbox"
                                                        Width="850px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkFeesWaivr" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                            <table id="tblFeewaivrdtls" class="tableIsys" visible="false" runat="server" style="height: 5%;
                                width: 90%;">
                                <tr>
                                    <td>
                                        <asp:GridView Style="color: blue" ID="gridFeeWaivr" runat="server" PagerStyle-HorizontalAlign="Center"
                                            PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                                            HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Approval Name" ItemStyle-Width="30%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAppName" runat="server" Text='<%# Eval("LegalName") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle CssClass="test" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle CssClass="test" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="30%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblremarks" runat="server" Text='<%# Eval("remarks") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle CssClass="test" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" ItemStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbldecisionflag" runat="server" Text='<%# Eval("decisionflag") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle CssClass="test" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                                            <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black"></PagerStyle>
                                            <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="Small">
                                            </RowStyle>
                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <%--Added by Pranjali on 13-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 End--%>
                            <%--Added by rachana on 13022014 to show inbox cfr details start--%>
                            <table id="tblCFRInboxCollapse" style="width: 90%" class="formtable table-condensed"
                                runat="server">
                                <tr>
                                    <td colspan="4" align="left" class="test">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnBasicCollapse"
                                            style="width: 20px;" onclick="ShowReqDtlNew('ctl00_ContentPlaceHolder1_divCFRInbox','ctl00_ContentPlaceHolder1_btnBasicCollapse');" />
                                        <asp:Label ID="lblhead" runat="server" Text="Raised CFR's" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div id="divCFRInbox" runat="server" style="display: block">
                                <table id="tblCFRInbox" style="width: 90%" class="tableIsys" runat="server">
                                    <tr>
                                        <td align="left" class="test" colspan="4" style="width: 30">
                                            <asp:Label ID="lblcfrraised" runat="server" Text="Raised CFR" CssClass="standardlink "></asp:Label>&nbsp;
                                            <asp:Label ID="lblcfrraisedcount" runat="server" CssClass="standardlink "></asp:Label>&nbsp;
                                            <asp:Label ID="lblresponded" runat="server" Text="Responded CFR" CssClass="standardlink "></asp:Label>
                                            <asp:Label ID="lblcfrrespondedcount" runat="server" CssClass="standardlink "></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView Style="color: blue" ID="dgDetailsInbox" runat="server" PagerStyle-HorizontalAlign="Center"
                                                PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                                                HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%"
                                                OnRowCommand="dgDetailsInbox_RowCommand" OnPageIndexChanging="dgDetailsInbox_PageIndexChanging"
                                                PageSize="5" OnRowDataBound="dgDetailsInbox_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Wrap="false" ItemStyle-Width="6%">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkAssigned" runat="server" /></ItemTemplate>
                                                        <HeaderStyle Wrap="False" CssClass="test"></HeaderStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField SortExpression="CFR Remark" HeaderText="CFR Remarks">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRRemarks") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR Raised For">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcfr" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField SortExpression="RemarkId" HeaderText="" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRemarkid" runat="server" Text='<%# Eval("RemarkId") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField SortExpression="Responded" HeaderText="Responded">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Responded" runat="server" Text='<%# Eval("Responded") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Responded" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCFRRemarkID" runat="server" Text='<%# Eval("CFRRemarkID") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRaisedFlag" runat="server" Text='<%# Eval("RaisedFlag") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCFRDocCode" runat="server" Text='<%# Eval("DocCode") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCFRFlagType" runat="server" Text='<%# Eval("CFRFlagType") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkReopen" Style="text-align: center;" runat="server" Text="ReOpen CFR"
                                                                CommandArgument='<%# Eval("RemarkId") %>' CommandName="ReopenCFR" Visible="false"></asp:LinkButton></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAddnlRemark" runat="server" Text='<%# Eval("AddnlRemark") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                                                <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black"></PagerStyle>
                                                <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="Small">
                                                </RowStyle>
                                                <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="Td14" runat="server" align="left" class="test" visible="false" colspan="4">
                                            <asp:Label ID="lblTitleRemarks" Visible="false" runat="server" Text="Remarks" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView Style="color: blue" ID="GridRemarks" runat="server" PagerStyle-HorizontalAlign="Center"
                                                PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                                                HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%"
                                                OnPageIndexChanging="GridRemarks_PageIndexChanging" PageSize="5">
                                                <Columns>
                                                    <asp:TemplateField SortExpression="Date" HeaderText="Date" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField SortExpression="CFRRemark" HeaderText="Remarks" ItemStyle-Width="70%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRRemark") %>'></asp:Label></ItemTemplate>
                                                        <HeaderStyle CssClass="test" />
                                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                                                <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black"></PagerStyle>
                                                <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="Small">
                                                </RowStyle>
                                                <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="trRespond" runat="server" visible="false">
                                        <td align="center">
                                            <%--<div class="btn btn-xs btn-primary" style="width: 110px;">
                            <i class="fa fa-comment"></i>--%>
                                            <asp:Button ID="btnRespond" runat="server" Text="Respond" CssClass="standardbutton"
                                                Width="84px" OnClick="btnRespond_Click" Visible="false"></asp:Button>
                                            <%--</div>--%>
                                            <%--<div class="btn btn-xs btn-primary" style="width: 110px;">
                            <i class="fa fa-comment"></i>--%>
                                            <asp:Button ID="btnCloseCfr" runat="server" Text="Close CFR" CssClass="standardbutton"
                                                Width="114px" OnClick="btnCloseCfr_Click"></asp:Button>
                                            <%--</div>--%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--Added by rachana on 13022014 to show inbox cfr details end--%>
                           
                            <table class="formtable table-condensed" id="Table1" runat="server" style="width: 90%;">
                                <tr id="tr_DocumentReuploadTitle" runat="server" visible="false">
                                    <%--pranjali--%>
                                    <td class="test" colspan="3" style="text-align: left;">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" visible="false"
                                            id="Button11" style="width: 20px;" onclick="funShowReqDtl('ctl00_ContentPlaceHolder1_divReUploadFiles','ctl00_ContentPlaceHolder1_BtnReUpload');" />
                                        <%--<asp:Label ID="lblcndupload" runat="server" Font-Bold="True" Text=""></asp:Label>--%>
                                        <asp:Label ID="lblcndupload" runat="server" Font-Bold="True"></asp:Label>
                                        <%--  Candidate Document Re-Upload--%>
                                    </td>
                                </tr>
                            </table>
                            <div id="div2" runat="server" style="display: block;">
                                <table class="tableIsys" align="center" style="width: 90%;">
                                    <tr id="tr_reupload" runat="server" visible="false">
                                        <td>
                                            <%--//pranjali start--%>
                                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CssClass="tableIsys"
                                                OnPageIndexChanging="GridView1_PageIndexChanging" PagerStyle-HorizontalAlign="Center"
                                                PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                                                OnRowDataBound="GridView1_RowDataBound" HorizontalAlign="Left" AutoGenerateColumns="False"
                                                AllowPaging="True" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="210px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldocName" runat="server" Text='<%#Bind("DocType") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Upload By" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUpldBy" runat="server" Text='<%#Bind("UploadedBy") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Uploaded Dt" HeaderStyle-Width="90px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUpdDtTm" runat="server" Text='<%#Bind("UploadedDate") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFileName" runat="server" Text='<%#Bind("ServerFileName") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <%--added by pranjali on 03-03-2014 start--%>
                                                    <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                Text='<%#Bind("MaxImgSize") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <%--added by pranjali on 03-03-2014 end--%>
                                                    <asp:TemplateField HeaderText="Reupload Documents" HeaderStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <asp:FileUpload ID="FileReUpload" runat="server" Width="340px" Filebytes='<%# Bind("UserFileName") %>'>
                                                            </asp:FileUpload></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_ReUpload" runat="server" CssClass="standardbutton" Text="ReUpload"
                                            OnClick="btn_ReUpload_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>--%>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblimgsize1" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("maximgsize") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblimgshrt1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                Text='<%#Bind("ImgShortCode") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblimgwidth1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                Text='<%#Bind("ImgWidth") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblimgheight1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                Text='<%#Bind("ImgHeight") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldoccode1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                Text='<%#Bind("DocCode") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="sublinkodd"></RowStyle>
                                                <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                                </PagerStyle>
                                                <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                                <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--pranjali end--%>
                            <%--Added by rachana on 29-07-2013 for addition of panel showing documents start--%>
                            <div id="divnavigate" runat="server">
                                <table id="tblphoto" runat="server" style="width: 90%;">
                                    <tr>
                                        <td class="formcontent" colspan="2">
                                            <%--<div class="btn btn-xs btn-primary" style="width: 110px;" id="divCrop" runat="server" visible="false">
                            <i class="fa fa-crop"></i>--%>
                                            <asp:Button ID="Btncrop" TabIndex="43" runat="server" Text="CROP" CssClass="standardbutton"
                                                OnClick="Btncrop_Click" Width="80" Visible="false"></asp:Button>
                                            <%--</div>--%>
                                            <%--<div class="btn btn-xs btn-primary" style="width: 110px;" id="divCFR" runat="server" visible="false">
                            <i class="fa fa-crop"></i>--%>
                                            <asp:Button ID="BtnCFR" TabIndex="43" OnClick="btnCFR_Click" runat="server" Text="Raise CFR"
                                                CssClass="standardbutton" Width="80px" Visible="false"></asp:Button><%--</div>--%>
                                            <%--OnClientClick="fungetcropimage();"--%>
                                        </td>
                                        <%--Added by pranjali on 25-022014 for displaying cfr raised start--%>
                                        <td align="left" class="style2" colspan="2">
                                            <asp:Label ID="lblcfrrais1" runat="server" Text="Raised CFR:" CssClass="standardlink "></asp:Label>&nbsp;
                                            <asp:Label ID="lblcfrrais1count" runat="server" CssClass="standardlink" Style="color: Red;"></asp:Label><br />
                                        </td>
                                        <%--</tr>
                <tr>--%>
                                        <td align="left" class="formcontent" colspan="2">
                                            <asp:Label ID="lblrespond" runat="server" Text="Responded CFR:" CssClass="standardlink"></asp:Label>&nbsp;
                                            <asp:Label ID="lblcfrrespondcount" runat="server" CssClass="standardlink" ></asp:Label><br />
                                        </td>
                                        <%--</tr>
        <tr>--%>
                                        <td align="left" class="formcontent" colspan="2">
                                            <asp:Label ID="lblclosed" runat="server" Text="Closed CFR:" CssClass="standardlink"></asp:Label>&nbsp;
                                            <asp:Label ID="lblcfrclosed" runat="server" CssClass="standardlink" Style="color: Green;"></asp:Label><br />
                                        </td>
                                        <%--Added by pranjali on 25-022014 for displaying cfr raised end--%>
                                        <td class="formcontent3">
                                            <asp:UpdatePanel runat="server" ID="upnlPrev">
                                                <ContentTemplate>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <%--<div class="btn btn-xs btn-primary" style="width: 110;">
                                    <i class="fa fa-chevron-circle-left"></i>--%>
                                                    <asp:Button ID="btnprev" runat="server" Text="Prev" CssClass="standardbutton" OnClick="btnprev_Click"
                                                        Width="80"></asp:Button><%--</div>--%>
                                                    &nbsp;&nbsp;
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="formcontent">
                                            <asp:UpdatePanel runat="server" ID="upnlNext">
                                                <ContentTemplate>
                                                    <%--<div class="btn btn-xs btn-primary" style="width: 110;">
                                    <i class="fa fa-crop"></i>--%>
                                                    <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="standardbutton" OnClick="btnnext_Click"
                                                        Width="80"></asp:Button>
                                                    <%--<i class="fa fa-chevron-right"></i>
                                </div>--%>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--Added by rachana on 29-07-2013 for addition of panel showing documents end--%>
                            <%--added by shravana 14jun2013--%>
                            <%--Added by rachana on 07-08-2013 start--%>
                     
                </div>
                    <div id="menu2" class="tab-pane fade">
                                 <%-- <div class="panel panel-success" style="margin-left:0px;margin-right:0px">
                          <div class="row">
                                    <div class="col-sm-3">
                                        <input runat="server" type="button" class="standardlink" value="-" id="btnView2"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divView2','ctl00_ContentPlaceHolder1_btnView2');" />
                                        <asp:Label ID="lblView2" Text="Profiling" runat="server"  CssClass="control-label" Font-Bold="true"></asp:Label>
                               </div>
                             
                            </div>
                          </div>--%>
                             <div class="panel panel-success" style="margin-left:0px;margin-right:0px">
                                         
                                                <%--Personal Information start--%>
                                                 <div id="Div12" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divQPersonal','btnQPersonal');return false;">  
                                              <div class="row">
                                             <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-chevron-down" ></span>
                     <asp:Label ID="lblqfpersonalinformation" runat="server"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnQPersonal" class="glyphicon glyphicon-collapse-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>     
                                                  
                                             </div>
                                                </div>
                                 
                                            <div id="divQPersonal" runat="server" style="display: block" class="panel-body" width="100%;">
                                         
                                                   <div class="row" >
                                                       <div class="col-sm-3" style="text-align:left">
                                                            <asp:Label ID="lblqfcndnotitle" runat="server" CssClass="control-label" ></asp:Label>
                                                    </div>
                                                       <div class="col-sm-3" style="text-align:left">
                                                            <asp:TextBox  Enabled="False" CssClass="form-control" ID="lblqcndno" runat="server" ></asp:TextBox>
                                                   </div>
                                                       <div class="col-sm-3" style="text-align:left" visible="false">
                                                            <asp:Label ID="lblqfcategorytitle" Visible="false" runat="server"  CssClass="control-label"></asp:Label>
                                                      </div>
                                                       <div class="col-sm-3" style="text-align:left"  visible="false">
                                                            <asp:TextBox  Enabled="False" Visible="false" CssClass="form-control" ID="lblqfcategory" runat="server" ></asp:TextBox>
                                                   </div>
                                                 </div>
                                                  <div class="row" >
                                                         <div class="col-sm-3" style="text-align:left">
                                                            <asp:Label ID="lblqfappnotitle" runat="server"  CssClass="control-label"></asp:Label>
                                                       </div>
                                                  <div class="col-sm-3" style="text-align:left">
                                                            <asp:TextBox  Enabled="False" CssClass="form-control" ID="lblqappno" runat="server"></asp:TextBox>
                                                       </div>
                                                        <div class="col-sm-3" style="text-align:left">
                                                            <asp:Label ID="lblqfregdatetitle" runat="server"  CssClass="control-label"></asp:Label>
                                                   </div>
                                                        <div class="col-sm-3" style="text-align:left">
                                                            <asp:TextBox  Enabled="False" CssClass="form-control" ID="lblqregdate" runat="server" ></asp:TextBox>
                                                      </div>
                                       </div>

                                                    <%--comment by Prathamesh Name and surname--%>

                                               <div class="row" >
                                                        <div class="col-sm-3" style="text-align:left">
                                                            <asp:Label ID="lblqfgivennametitle"  CssClass="control-label" runat="server"></asp:Label>
                                                 </div>
                                                       <div class="col-sm-3" style="text-align:left">
                                                            <asp:TextBox  Enabled="False" CssClass="form-control" ID="lblqgivenname" runat="server" ></asp:Textbox>
                                                        </div>
                                                           <div class="col-sm-3" style="text-align:left">
                                                            <asp:Label ID="lblqfsurname"  CssClass="control-label" runat="server"></asp:Label>
                                                     </div>
                                                         <div class="col-sm-3" style="text-align:left">
                                                            <asp:TextBox  Enabled="False" CssClass="form-control" ID="lblqsurname" runat="server" ></asp:TextBox>
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
                                                                    style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divLanguage','btnLanguage');" />
                                                                <asp:Label ID="lblqfknolanguagestitle" runat="server" Font-Bold="true"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                 </td> 
                                                </tr>
                                            </table>
                                            <div id="divLanguage" runat="server" style="display: none" width="100%;">
                                                <table class="tableIsys" style="width: 100%;">
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            
                                                 </td>  
                                                        <td class="formcontent" align="left">
                                                            <asp:Label ID="lblqflanguage1" runat="server"></asp:Label>
                                                  </td> 
                                                        <td class="formcontent" align="left">
                                                            <asp:UpdatePanel ID="upnlLanguage1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblqfread1" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblqfwrite1" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblqfspeak1" runat="server" Visible="false"></asp:Label>
                                                                </ContentTemplate>
                                                                <Triggers><asp:AsyncPostBackTrigger ControlID="ddllanknow1" EventName="SelectedIndexChanged" /></Triggers>
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
                                                                    <asp:Label ID="lblqfread2" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblqfwrite2" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblqfspeak2" runat="server" Visible="false"></asp:Label>
                                                                </ContentTemplate>
                                                                <Triggers><asp:AsyncPostBackTrigger ControlID="ddllanknow3" EventName="SelectedIndexChanged" /></Triggers>
                                                            </asp:UpdatePanel>
                                                    </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            <asp:Label ID="lblqflanguagesKnown1" runat="server"></asp:Label>
                                               </td>
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
                                                                    <asp:CheckBox ID="cbpread" runat="server" CssClass="standardcheckbox"
                                                                        Visible="false" TabIndex="505" />
                                                                    <asp:CheckBox ID="cbpwrite" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="510" />
                                                                    <asp:CheckBox ID="cbpspeak" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="515" />
                                                                </ContentTemplate>
                                                                <Triggers><asp:AsyncPostBackTrigger ControlID="ddllanknow1" EventName="SelectedIndexChanged" /></Triggers>
                                                            </asp:UpdatePanel>
                                                        </td> 
                                                        <td class="formcontent" align="left">
                                                            <asp:Label ID="lblqflanguagesKnown2" runat="server" Font-Bold="False" Width="117px"></asp:Label>
                                                          </td>   
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
                                                                    <asp:CheckBox ID="cbpread3" runat="server" CssClass="standardcheckbox"
                                                                        Visible="false" TabIndex="545" /> 
                                                                    <asp:CheckBox ID="cbpwrite3" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="550" />
                                                                    <asp:CheckBox ID="cbpspeak3" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="555" />
                                                                </ContentTemplate>
                                                                <Triggers><asp:AsyncPostBackTrigger ControlID="ddllanknow3" EventName="SelectedIndexChanged" /></Triggers>
                                                            </asp:UpdatePanel>
                                                      </td>   
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            
                                                        </td>
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
                                                                    <asp:CheckBox ID="cbpread2" runat="server" CssClass="standardcheckbox"
                                                                        Visible="false" TabIndex="525" />
                                                                    <asp:CheckBox ID="cbpwrite2" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="530" />
                                                                    <asp:CheckBox ID="cbpspeak2" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="535" />
                                                                </ContentTemplate>
                                                                <Triggers><asp:AsyncPostBackTrigger ControlID="ddllanknow2" EventName="SelectedIndexChanged" /></Triggers>
                                                            </asp:UpdatePanel>
                                                    </td>
                                                        <td class="formcontent" align="left">
                                                            
                                                          </td> 
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
                                                                    <asp:CheckBox ID="cbpread4" runat="server" CssClass="standardcheckbox"
                                                                        Visible="false" TabIndex="565" />
                                                                    <asp:CheckBox ID="cbpwrite4" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="570" />
                                                                    <asp:CheckBox ID="cbpspeak4" runat="server" CssClass="standardcheckbox" Visible="false"
                                                                        TabIndex="575" />
                                                                </ContentTemplate>
                                                                <Triggers><asp:AsyncPostBackTrigger ControlID="ddllanknow4" EventName="SelectedIndexChanged" /></Triggers>
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
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divOccupation','ctl00_ContentPlaceHolder1_btnQOccupation');" />
                                                        <asp:Label ID="lbqfloccqualification" runat="server" Font-Bold="true"></asp:Label>
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
                                                                         Width="310px" TabIndex="128">
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
                                                                <asp:Label ID="lblqfoccupation" runat="server" CssClass="control-label"></asp:Label>*</span>
                                                            <%-- <span style="color: red">*</span>--%>
                                                      </td>
                                                        <td class="formcontent" style="width: 30%" align="left">
                                                            <asp:TextBox ID="txtOccupationCode" runat="server" CssClass="standardtextbox" 
                                                                Width="50px" onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="4"
                                                                TabIndex="130"></asp:TextBox>
                                                            <asp:TextBox ID="txtOccupationDesc" runat="server" CssClass="standardtextbox" Enabled="false"
                                                                Width="120px"  onChange="javascript:this.value=this.value.toUpperCase();"
                                                                TabIndex="131"></asp:TextBox>
                                                            
                                                            <asp:Button ID="btnOccupation" runat="server" CssClass="standardbutton" Text="..."
                                                                 CausesValidation="False" Width="20px" TabIndex="132"></asp:Button>
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
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divFunProduct','ctl00_ContentPlaceHolder1_btnFunProduct');" />
                                                        <asp:Label ID="lblqfdoyouhave" runat="server" Font-Bold="true"></asp:Label>
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
                                                                        <asp:CheckBox ID="cbMutFund" runat="server" CssClass="standardcheckbox" TabIndex="134" />
                                                                 </td>  
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:CheckBox ID="cbLifeIns" runat="server" CssClass="standardcheckbox" TabIndex="135" />
                                                              </td>
                                                                    <td class="formcontent" align="left" style="width: 18%">
                                                                        <asp:CheckBox ID="cbGenIns" runat="server" CssClass="standardcheckbox" TabIndex="136" />
                                                                    </td> 
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:CheckBox ID="cbCreCard" runat="server" CssClass="standardcheckbox" TabIndex="137" />
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
                                       
                         
                            <%--pranjali removed--%>
                   <%--      <div class="panel panel-success" style="margin-left:0px;margin-right:0px">--%>
                       <%--        <div id="Div13" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divView3','ctl00_ContentPlaceHolder1_btnView3');return false;">     
                                         <div class="row">
                                           <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-chevron-down" style="margin-right:5px; margin-left:-90%;"></span>
                     <asp:Label ID="Label131" runat="server" Text="Employment" Font-Bold="True" CssClass="control-label" ></asp:Label>
                 
                    </div>
                                             <div class="col-sm-2">
                        <span id="btnView3" class="glyphicon glyphicon-collapse-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>      
                                   
                           </div>
                           </div>--%>
                    
                            <div id="divView3" runat="server" style="display: none; width: 90%;">
                                <table id="Table4" runat="server" class="container" style="width: 100%">
                                    <tr>
                                        <td style="width: 791px" align="center">
                                            <%--Personal Information--%>
                                            <table class="formtable" width="90%" style="display: none;">
                                                <tr>
                                                    <td style="background-color:#3399FF;color:Navy;" colspan="4">
                                                        <input runat="server" type="button" class="standardlink" value="-" id="btnEPersonal"
                                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divEPersonal','ctl00_ContentPlaceHolder1_btnEPersonal');" />
                                                        <asp:Label ID="lblehtpersonalinformation" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                                </tr>
                                            </table>
                                            <div id="divEPersonal" runat="server" style="display: none;">
                                                <table class="tableIsys" width="90%">
                                                    <%--Newly--%>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%;">
                                                            <asp:Label ID="lblehcndnotitle" runat="server" CssClass="control-label"></asp:Label>
                                                        </td> 
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblecndno" runat="server"></asp:Label>
                                                       </td>
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblehcategorytitle" runat="server" CssClass="control-label"></asp:Label>
                                                         </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblehcategory" runat="server" CssClass="control-label"></asp:Label>
                                                        </td> 
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%;">
                                                            <asp:Label ID="lblehappnotitle" runat="server" CssClass="control-label"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lbleappno" runat="server"></asp:Label>
                                                         </td> 
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblehregdatetitle" runat="server" CssClass="control-label"></asp:Label>
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
                                                            id="btnEmploymentHist" style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divEmploymentHist','ctl00_ContentPlaceHolder1_btnEmploymentHist');" />
                                                        <asp:Label ID="lblehEmpHistory" runat="server" Style="padding-left: 20px" ForeColor="White"
                                                            Font-Bold="true"></asp:Label>
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
                                                                        <asp:Label ID="lblehfrom" runat="server" Font-Bold="true"></asp:Label>
                                                               </td> 
                                                                    <td align="center" style="width: 100px;">
                                                                        <asp:Label ID="lblehto" runat="server" Font-Bold="true"></asp:Label>
                                                                  </td>   
                                                                    <td align="center" style="width: 94px;">
                                                                        <asp:Label ID="lblehname" runat="server" Font-Bold="true"></asp:Label>
                                                                 </td>   
                                                                    <td align="center" style="width: 94px;">
                                                                        <asp:Label ID="lblehaddofemp" runat="server" Font-Bold="true"></asp:Label>
                                                              </td>   
                                                                    <td align="center" style="width: 94px;">
                                                                        <asp:Label ID="lbllehastposition" runat="server" Font-Bold="true"></asp:Label>
                                                                   </td>    
                                                                    <td align="center" style="width: 94px;">
                                                                        <asp:Label ID="lblehannincome" runat="server" Font-Bold="true"></asp:Label>
                                                                  </td>  
                                                                    <td align="center" style="width: 94px;">
                                                                        <asp:Label ID="lblehresforleave" runat="server" Font-Bold="true"></asp:Label>
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
                                                                            ControlToValidate="txtfrom1" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR6" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom1" Display="Dynamic"></asp:CompareValidator>
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
                                                                            ControlToValidate="txtto1" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR7" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto1" Display="Dynamic"></asp:CompareValidator>
                                                                        <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtto1"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName1" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="141"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender111" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName1"></ajaxToolkit:FilteredTextBoxExtender>
                                                                 </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtaddofemp1" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="142"></asp:TextBox>
                                                                   </td>  
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtEmpLvl1" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="143"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender411" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl1"></ajaxToolkit:FilteredTextBoxExtender>
                                                                   </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtLastIncome1" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="144"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender911" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome1" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                                    </td> 
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtreasforleave1" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="145"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave1"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                            ControlToValidate="txtto1" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR8" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom2" Display="Dynamic"></asp:CompareValidator>
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
                                                                            ControlToValidate="txtto2" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR9" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto2" Display="Dynamic"></asp:CompareValidator>
                                                                        <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txtto2"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                   </td>    
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName2" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="148"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName2"></ajaxToolkit:FilteredTextBoxExtender>
                                                                   </td>  
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtaddofemp2" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="149"></asp:TextBox>
                                                                   </td>  
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtEmpLvl2" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="150"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender43" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl2"></ajaxToolkit:FilteredTextBoxExtender>
                                                                 </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtLastIncome2" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="151"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender44" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome2" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                                 </td> 
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtreasforleave2" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="152"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave2"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                            ControlToValidate="txtfrom3" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR10" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom3" Display="Dynamic"></asp:CompareValidator>
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
                                                                            ControlToValidate="txtto3" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR11" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto3" Display="Dynamic"></asp:CompareValidator>
                                                                        <asp:RangeValidator ID="RangeValidator11" runat="server" ControlToValidate="txtto3"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td> 
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName3" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="155"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName3"></ajaxToolkit:FilteredTextBoxExtender>
                                                                      </td>   
                                                                    <td align="left" class="formcontent">
                                                                        <asp:TextBox ID="txtaddofemp3" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="156"></asp:TextBox>
                                                                </td>   
                                                                    <td align="left" class="formcontent">
                                                                        <asp:TextBox ID="txtEmpLvl3" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="157"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl3"></ajaxToolkit:FilteredTextBoxExtender>
                                                                 </td> 
                                                                    <td align="left" class="formcontent">
                                                                        <asp:TextBox ID="txtLastIncome3" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="158"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome3" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                                </td> 
                                                                    <td align="left" class="formcontent">
                                                                        <asp:TextBox ID="txtreasforleave3" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="159"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave3"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                            ControlToValidate="txtfrom4" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR12" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom4" Display="Dynamic"></asp:CompareValidator>
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
                                                                            ControlToValidate="txtto4" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR13" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto4" Display="Dynamic"></asp:CompareValidator>
                                                                        <asp:RangeValidator ID="RangeValidator13" runat="server" ControlToValidate="txtto4"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                  </td>  
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName4" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="162"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName4"></ajaxToolkit:FilteredTextBoxExtender>
                                                                </td>  
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtaddofemp4" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="163"></asp:TextBox>
                                                                 </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtEmpLvl4" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="164"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender34" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl4"></ajaxToolkit:FilteredTextBoxExtender>
                                                                  </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtLastIncome4" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="165"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender36" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome4" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                                </td>  
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtreasforleave4" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="166"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave4"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                            ControlToValidate="txtfrom5" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR14" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom5" Display="Dynamic"></asp:CompareValidator>
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
                                                                            ControlToValidate="txtfrom5" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR15" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto5" Display="Dynamic"></asp:CompareValidator>
                                                                        <asp:RangeValidator ID="RangeValidator15" runat="server" ControlToValidate="txtfrom5"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                    </td>  
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName5" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="169"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender38" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName5"></ajaxToolkit:FilteredTextBoxExtender>
                                                                </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtaddofemp5" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="170"></asp:TextBox>
                                                                    </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtEmpLvl5" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="171"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl5"></ajaxToolkit:FilteredTextBoxExtender>
                                                                  </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtLastIncome5" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="172"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome5" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                                </td> 
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtreasforleave5" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="173"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender37" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave5"></ajaxToolkit:FilteredTextBoxExtender>
                                                                </td> 
                                                                </tr>
                                                                <tr id="Tr5" runat="server" visible="false">
                                                                    <td class="formcontent" align="left">
                                                                        <%--<uc7:ctlDate ID="txtfrom6" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="174"/>--%>
                                                                        <asp:TextBox ID="txtfrom6" runat="server" CssClass="standardtextbox" Width="80" TabIndex="174" />
                                                                        <asp:Image ID="imgtxtfrom6" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                        <asp:TextBox ID="txtimgtxtfrom6" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender161" runat="server" TargetControlID="txtimgtxtfrom6"
                                                                            PopupButtonID="imgtxtfrom6" Format="dd/MM/yyyy" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator161" runat="server" SetFocusOnError="true"
                                                                            ControlToValidate="txtfrom6" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR161" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom6" Display="Dynamic"></asp:CompareValidator>
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
                                                                            ControlToValidate="txtto6" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="COMPAREVALIDATOR17" runat="server" ErrorMessage="Invalid date!"
                                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto6" Display="Dynamic"></asp:CompareValidator>
                                                                        <asp:RangeValidator ID="RangeValidator17" runat="server" ControlToValidate="txtto6"
                                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                 </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtPrevEmpName6" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                            Style="width: 94%;" TabIndex="176"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender40" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName6"></ajaxToolkit:FilteredTextBoxExtender>
   </td> 
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtaddofemp6" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                            Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="177"></asp:TextBox>
                                                                    </td>   
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtEmpLvl6" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                            MaxLength="50" TabIndex="178"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender41" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl6"></ajaxToolkit:FilteredTextBoxExtender>
                                                                     </td>  
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtLastIncome6" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                            Style="width: 95%;" TabIndex="179"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender45" runat="server"
                                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                            FilterMode="InvalidChars" TargetControlID="txtLastIncome6" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                                 </td> 
                                                                    <td class="formcontent" align="left">
                                                                        <asp:TextBox ID="txtreasforleave6" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                            Style="width: 95%;" TabIndex="180"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender42" runat="server"
                                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave6"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                            id="btnSalesExp" style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSalesExp','ctl00_ContentPlaceHolder1_btnSalesExp');" />
                                                        <asp:Label ID="lblehexperience" runat="server" Style="padding-left: 20px" ForeColor="White"
                                                            Font-Bold="true"></asp:Label>
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
                                                                            <asp:Label ID="lblehhaveyou" runat="server" Font-Bold="False" Style="color: Black;"></asp:Label>*</span>
                                                                   </td>  
                                                                    <td class="formcontent" align="left" style="width: 10%;">
                                                                        <asp:UpdatePanel ID="updrbotherexp" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:RadioButtonList ID="rbotherexp" runat="server" CssClass="radiobtn" 
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
                                                                        <asp:Label ID="lblehcompanyname" runat="server" ForeColor="Navy" Font-Bold="true"></asp:Label>
                                                                   </td>  
                                                                    <td align="center" style="width: 160px;">
                                                                        <asp:Label ID="lblehcnfrom" runat="server" ForeColor="Navy" Font-Bold="true"></asp:Label>
                                                                   </td>   
                                                                    <td align="center" style="width: 90px;">
                                                                        <asp:Label ID="lblehcnto" runat="server" ForeColor="Navy" Font-Bold="true"></asp:Label>
                                                                  </td>   
                                                                    <td align="center" style="width: 90px;">
                                                                        <asp:Label ID="lblehcnjobnature" runat="server" ForeColor="Navy" Font-Bold="true"></asp:Label>
                                                                   </td> 
                                                                    <td align="center" style="width: 90px;">
                                                                        <asp:Label ID="lblehcnfield" runat="server" ForeColor="Navy" Font-Bold="true"></asp:Label>
                                                                  </td> 
                                                                </tr>
                                                                <tr>
                                                                    <td class="formcontent" align="left" style="width: 20%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordname1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordname1" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                                    TabIndex="182"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender46" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordname1"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR181" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpfrom1" Display="Dynamic"></asp:CompareValidator>
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
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR16" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpTo1" Display="Dynamic"></asp:CompareValidator>
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
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordjobnature1"></ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                 </td>   
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordfield1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordfield1" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                                    TabIndex="186"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender48" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordfield1"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordname2"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR171" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpfrom2" Display="Dynamic"></asp:CompareValidator>
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
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR18" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpTo2" Display="Dynamic"></asp:CompareValidator>
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
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordjobnature2"></ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                   </td>  
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordfield2" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordfield2" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                                    TabIndex="191"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender51" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordfield2"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordname3"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR19" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpfrom3" Display="Dynamic"></asp:CompareValidator>
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
                                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                <asp:CompareValidator ID="COMPAREVALIDATOR20" runat="server" ErrorMessage="Invalid date!"
                                                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpTo3" Display="Dynamic"></asp:CompareValidator>
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
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordjobnature3"></ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                            </td>   
                                                                    <td class="formcontent" align="left" style="width: 15%">
                                                                        <asp:UpdatePanel ID="updtxtemprecordfield3" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtemprecordfield3" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                                    TabIndex="196"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender54" runat="server"
                                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordfield3"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                            id="btnInsuranceAgency" style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divInsuranceAgency','ctl00_ContentPlaceHolder1_btnInsuranceAgency');" />
                                                        <asp:Label ID="lblehdetofinsagcy" Style="padding-left: 20px" ForeColor="White" runat="server"
                                                            Font-Bold="true"></asp:Label>
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
                                                                            <asp:Label ID="lblehgerlifeinscompy" runat="server" Font-Bold="False" Style="color: Black;"></asp:Label>*</span>
                                                               </td>   
                                                                    <td class="formcontent" align="left" style="width: 10%;">
                                                                        <asp:UpdatePanel ID="UpdPanelrbagnex" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:RadioButtonList ID="rbinsagency" runat="server" CssClass="radiobtn" AutoPostBack="True"
                                                                                     OnSelectedIndexChanged="rdagnexp_SelectedIndexChanged" RepeatDirection="Horizontal"
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
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtInsCompName"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                        FilterMode="InvalidChars" TargetControlID="txtLcnNo" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR21" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtdateofissue" Display="Dynamic"></asp:CompareValidator>
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
                                                                        ControlToValidate="txtvaliddate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR22" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtvaliddate" Display="Dynamic"></asp:CompareValidator>
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
                                                                        FilterMode="InvalidChars" TargetControlID="txtInsAgencyCode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR23" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtterminatedate" Display="Dynamic"></asp:CompareValidator>
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
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtTerminationReason"></ajaxToolkit:FilteredTextBoxExtender>
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
                                            style="width: 20px;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divView4','ctl00_ContentPlaceHolder1_btnView4');" />
                                        <asp:Label ID="Label141" Text="Disciplinary Information" runat="server" Font-Bold="true"></asp:Label>
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
                                                            style="width: 20px;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_DivDPersonal','ctl00_ContentPlaceHolder1_btnDPersonal');" />
                                                        <asp:Label ID="lblpersonalinformation" runat="server" Font-Bold="true"></asp:Label>
                                                </td> 
                                                </tr>
                                            </table>
                                            <div id="DivDPersonal" runat="server" style="display: none;">
                                                <table class="tableIsys">
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%;">
                                                            <asp:Label ID="lbldicndidtitle" runat="server" CssClass="control-label"></asp:Label>
                                                     </td>  
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblpcndno" runat="server"></asp:Label>
                                                       </td> 
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lbldicategorytitle" runat="server" CssClass="control-label"></asp:Label>
                                                      </td>  
                                                        <td class="formcontent" style="width: 501px;">
                                                            <asp:Label ID="lbldicategory" runat="server" CssClass="control-label"></asp:Label>
                                                        </td> 
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lbldiappnotitle" runat="server" CssClass="control-label"></asp:Label>
                                                     </td>   
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblpappno" runat="server"></asp:Label>
                                                       </td>   
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lbldiregdatetitle" runat="server" CssClass="control-label"></asp:Label>
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
                                                            style="width: 20px;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divDisciplinaryInfo','ctl00_ContentPlaceHolder1_btnDisciplinaryInfo');" />
                                                        <asp:Label ID="lbldidisinformation" runat="server" Font-Bold="true"></asp:Label>
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
                                                                 TabIndex="205">
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       </td>    
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <span style="color: red">
                                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                                <asp:Label ID="lbldihybsubject" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>*</span>
                                                            <%-- <span style="color: #ff0000">*</span>--%>
                                                    </td>   
                                                        <td class="formcontent" align="left">
                                                            <asp:RadioButtonList ID="rbQstn02" runat="server" CssClass="radiobtn" 
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
                                                                <asp:Label ID="lbldihybjudgement" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>*</span>
                                                            <%-- <span style="color: #ff0000">*</span>--%>
                                                     </td>  
                                                        <td class="formcontent" align="left">
                                                            <asp:RadioButtonList ID="rbQstn03" runat="server" CssClass="radiobtn" 
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
                                                                <asp:Label ID="lbldihybinsolv" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>*</span>
                                                            <%--<span style="color: #ff0000">*</span>--%>
                                                      </td> 
                                                        <td class="formcontent" align="left">
                                                            <asp:RadioButtonList ID="rbQstn04" runat="server" CssClass="radiobtn" 
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
                                                            style="width: 20px;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divReferences','ctl00_ContentPlaceHolder1_btnReferences');" />
                                                        <asp:Label ID="lbldireference" runat="server" Font-Bold="true"></asp:Label>
                                                  </td> 
                                                </tr>
                                            </table>
                                            <div id="divReferences" runat="server" style="display: block;">
                                                <table class="tableIsys">
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lblditrefname1" runat="server"></asp:Label>
                                                       </td>    
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef1Name" runat="server" CssClass="standardtextbox" MaxLength="60"
                                                                TabIndex="209"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender59" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtRef1Name"></ajaxToolkit:FilteredTextBoxExtender>
                                                      </td>   
                                                        <td class="formcontent" nowrap="nowrap" colspan="2">
                                                 </td>  
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiref1address" runat="server"></asp:Label>
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
                                                                Text="..." TabIndex="215" />
                                                       </td>    
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="Label4" runat="server"></asp:Label>
                                                       </td> 
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef1Add2" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                                MaxLength="30" TabIndex="211"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender60" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtRef1Add2"></ajaxToolkit:FilteredTextBoxExtender>
                                                       </td>   
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiRef1Pincode" runat="server"></asp:Label>
                                                       </td>   
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef1Pin" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                                MaxLength="6" Width="163px" TabIndex="216"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender74" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtRef1Pin" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                            <asp:Label ID="lbldiRef1country" runat="server"></asp:Label>
                                                      </td>  
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtCountryCodeR1" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                                Width="50px" MaxLength="3" TabIndex="217"></asp:TextBox>
                                                            <asp:TextBox ID="txtCountryDescR1" runat="server" CssClass="standardtextbox" Enabled="False"
                                                                onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="218"></asp:TextBox>
                                                            <asp:Button ID="btnCountryR1" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                                Text="..." TabIndex="219" />
                                                      </td>   
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                            <asp:Label ID="lbldiRefname2" runat="server"></asp:Label>
                                                       </td>   
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtRef2Name" runat="server" CssClass="standardtextbox" MaxLength="60"
                                                                TabIndex="220"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender61" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtRef2Name"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                            <asp:Label ID="lbldiRef2State" runat="server"></asp:Label>
                                                       </td>   
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtStateCodeR2" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                                Width="50px" MaxLength="3" TabIndex="224"></asp:TextBox>
                                                            <asp:TextBox ID="txtStateDescR2" runat="server" CssClass="standardtextbox" Enabled="False"
                                                                onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="225"></asp:TextBox>
                                                            <asp:Button ID="btnStateR2" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                                Text="..." TabIndex="226" />
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
                                                                FilterMode="InvalidChars" TargetControlID="txtRef2Pin" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                            <asp:Label ID="lbldiRef2Country" runat="server"></asp:Label>
                                                      </td>    
                                                        <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                            <asp:TextBox ID="txtCountryCodeR2" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                                Width="50px" MaxLength="3" TabIndex="228"></asp:TextBox>
                                                            <asp:TextBox ID="txtCountryDescR2" runat="server" CssClass="standardtextbox" Enabled="False"
                                                                onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="229"></asp:TextBox>
                                                            <asp:Button ID="btnCountryR2" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                                Text="..." TabIndex="230" />
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
                                            style="width: 20px;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divView5','ctl00_ContentPlaceHolder1_btnView5');" />
                                        <asp:Label ID="Label15" Text="Business Plan" runat="server" Font-Bold="true"></asp:Label>
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
                                                            style="width: 20px;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divBPersonal','ctl00_ContentPlaceHolder1_btnBPersonal');" />
                                                        <asp:Label ID="lblbppersinftitle" runat="server" Font-Bold="true"></asp:Label>
                                                 </td>  
                                                </tr>
                                            </table>
                                            <div id="divBPersonal" runat="server" style="display: none;">
                                                <table class="tableIsys">
                                                    <%--Newly--%>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%;">
                                                            <asp:Label ID="lblbpcndnotitle" runat="server" CssClass="control-label"></asp:Label>
                                                      </td>  
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblbcndno" runat="server"></asp:Label>
                                                       </td> 
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblbpcategorytitle" runat="server" CssClass="control-label"></asp:Label>
                                                      </td> 
                                                        <td class="formcontent" style="width: 501px;">
                                                            <asp:Label ID="lblbpcategory" runat="server" CssClass="control-label"></asp:Label>
                                                 </td>   
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:Label ID="lblbpappnotitle" runat="server" CssClass="control-label"></asp:Label>
   </td>    
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:Label ID="lblbappno" runat="server"></asp:Label>
                                                      </td>    
                                                        <td class="formcontent" style="width: 20%;">
                                                            <asp:Label ID="lblbpregdatetitle" runat="server" CssClass="control-label"></asp:Label>
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
                                                            style="width: 20px;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divBusinessPlan','ctl00_ContentPlaceHolder1_btnBusinessPlan');" />
                                                        <asp:Label ID="lblbpEmpHistory1" runat="server" Font-Bold="true"></asp:Label>
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
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannooflives11" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                       </td>   
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:TextBox ID="txtbusinessplansumassured11" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="232" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender64" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplansumassured11" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>   
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:TextBox ID="txtbusinessplannfirstyearpremium11" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="233" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender65" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannfirstyearpremium11"
                                                                FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannooflives21" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                     </td>   
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:TextBox ID="txtbusinessplannsumassured21" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="235" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender67" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannsumassured21" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>   
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:TextBox ID="txtbusinessplannfirstyearpremium21" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="236" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender68" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannfirstyearpremium21"
                                                                FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
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
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannooflives31" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>  
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:TextBox ID="txtbusinessplannsumassured31" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="238" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender70" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannsumassured31" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                             </td>  
                                                        <td class="formcontent" align="left" style="width: 30%">
                                                            <asp:TextBox ID="txtbusinessplannfirstyearpremium31" runat="server" CssClass="standardtextbox"
                                                                MaxLength="9" Style="text-align: right" TabIndex="239" Width="50%"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender71" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtbusinessplannfirstyearpremium31"
                                                                FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                       </td>    
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <span style="color: red">
                                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                                <asp:Label ID="lblbpwillingtowork" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>*</span>
                                                            <%-- <span style="color: #ff0000">*</span>--%>
                                                     </td> 
                                                        <%--<td align="left" class="formcontent">
                                           </div>   --%>
                                                        <td align="left" class="formcontent">
                                                            <asp:RadioButtonList ID="rbtimework" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                                 TabIndex="240">
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
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtpastachievement"></ajaxToolkit:FilteredTextBoxExtender>
                                                   </td>  
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" colspan="3">
                                                            <span style="color: red">
                                                                <asp:Label ID="lblbpareyourelated" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>*</span>
                                                   </td>   
                                                        <td class="formcontent" align="left">
                                                            <asp:RadioButtonList ID="rbrelatedemp" runat="server" CssClass="radiobtn" 
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
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtrelativeworkdesc"></ajaxToolkit:FilteredTextBoxExtender>
                                                       </td>  
                                                    </tr>
                                                </table>
                                            </div>
                                            <%--Three years biz plan End--%>
                                            <%--added by Rachana on 17/05/2013 for Interview Details --%>
                                            <%--<table  id="tblint" runat="server" class="formtable2"> 
                                           <tr>
                                             <td class="test" colspan="4" >
                                                 <asp:Label ID="lblInt" runat="server" Text="Interview Details" CssClass="standardtextbox1"></asp:Label>
                                           </div>   
                                         </tr>
                                         <tr>
                                               <td class="formcontent" nowrap="nowrap">
                                                   <asp:Label ID="lblCndNo" Text="Candidate No."  runat="server" ></asp:Label>
                                             </div>   
                                               <td class="formcontent" width="100%" colspan="3">
                        
                                                    <asp:Label ID="lblCandidateid" runat="server" ></asp:Label>
                                              </div>   
                                           </tr>
                                           <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    <asp:Label ID="lblCndName" Text="Candidate Name" runat="server" ></asp:Label>
                                              </div>   
                                                <td class="formcontent" width="100%" colspan="3">
                        
                                                    <asp:Label ID="lblCandidateName" runat="server" ></asp:Label>     
                                               </div>   
                                            </tr>
                                            <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    <asp:Label ID="lblInterviewerName" Text="Interviewer Name" runat="server" ></asp:Label>
                                              </div>   
                                                <td class="formcontent" >
                                                    <asp:TextBox CssClass="standardtextbox" ID="txtInterviewerName" runat="server" 
                                                        Width="209px"></asp:TextBox>
                         
                                              </div>   
                                                <td class="formcontent" ><asp:Label ID="lblDate" Text="Date of Interview" runat="server" ></asp:Label>
                                              </div>   
                                                 <td class="formcontent" >
                                                    <uc7:ctlDate ID="txtDTRegFrom" runat="server" CssClass="standardtextbox" 
                                                                RequiredField="false" RequiredValidationMessage="Mandatory!" Width="100" />
                     
                                                </div>   
                                             </tr>
                                             <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    <asp:Label ID="lblInterviewerComment" runat="server" ></asp:Label>
                                              </div>   
                                                <td class="formcontent" width="100%"  colspan="3">
                                                    <asp:TextBox CssClass="standardtextbox" ID="txtInterviewerComment" 
                                                        runat="server" Height="115px" TextMode="MultiLine" Width="427px"></asp:TextBox>
                                              </div>   
                                            </tr>
                                      </table>--%>
                                            <%--End Interview Details--%>
                                        </td> 
                                    </tr>
                                </table>
                            </div>
                            <%-- </div>--%>

                        <%--    profiling -------start--------------%>
                        <div class="panel panel-success" style="margin-left:0px;margin-right:0px">
                        <div id="Div14" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div3','btndiv3');return false;">   
                             <div class="row">
                              <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-chevron-down"  ></span>
                     <asp:Label ID="lblBusiPln" runat="server" Text="Business Plan" CssClass="control-label" ></asp:Label>
                 
                    </div>
                                    <div class="col-sm-2">
                        <span id="btndiv3" class="glyphicon glyphicon-collapse-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                             </div>
                             </div>
                            <div id="div3" runat="server" style="display:block;" class="panel-body">
                                    <div class="row">
                                     <div class="col-sm-3" style="text-align:left">
                                               
                                                <asp:Label ID="lblagntype" runat="server" CssClass="control-label" 
                                                    Font-Bold="False" Text="Type of agent"></asp:Label>
                                                 <span style="color: Red;">*</span>
                                 </div> 
                                         <div class="col-sm-3">
                                                <asp:UpdatePanel ID="updangtype" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlagntype" runat="server" AutoPostBack="true" 
                         CssClass="form-control"     OnSelectedIndexChanged="ddlagntype_SelectedIndexChanged" TabIndex="6" 
                                                            >
                                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                          </div>   
                                         <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="Others" runat="server" CssClass="control-label" 
                                                    Font-Bold="False" Text="From others please specify"></asp:Label>
                                          </div>   
                                         <div class="col-sm-3">
                                                <asp:UpdatePanel ID="updOthers" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtOthers" runat="server" CssClass="form-control"
                                                            Enabled="false" MaxLength="30" 
                                                            onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="8" 
                                                           ></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                                                            runat="server" FilterMode="InvalidChars" FilterType="Custom" 
                                                            InvalidChars="/.\?&lt;&gt;{}[];:|=+_-,#$@%^!*()&amp;''%^~ `0123456789" 
                                                            TargetControlID="txtOthers">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                          </div>   
                                    </div>
                                  <div class="row">
                                         <div class="col-sm-3" style="text-align:left">
                                          
                                                <asp:Label ID="Label10" runat="server" CssClass="control-label" Font-Bold="False" Text="Is he working with some other RCAP company"></asp:Label>
                                                  <span style="color: Red;">*</span>
                                      </div>   
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updIsWrkng">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlIsWrkng" runat="server" AutoPostBack="true" CssClass="form-control"
                                                        OnSelectedIndexChanged="ddlIsWrkng_SelectedIndexChanged"  TabIndex="6">
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Y"> </asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                       <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblcompName" runat="server" CssClass="control-label" Font-Bold="False"
                                                Text="If yes, company name"></asp:Label>
                                      </div>   
                                         <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updcompName">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlcompName" runat="server" CssClass="form-control" 
                                                        TabIndex="6" Enabled="false">
                                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                    </div>   
                                  <div class="row">
                                        <div class="col-sm-3" style="text-align:left">
                                            
                                                <asp:Label ID="lblNoOfYrsInsurance" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="No. of years in insurance"></asp:Label>
                                                <span style="color: Red;">*</span>
                                      </div>   
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updNoOfYrsIns">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNoOfYrsIns" runat="server" CssClass="form-control" 
                                                        TabIndex="6">
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                     <div class="col-sm-3" style="text-align:left">
                                           
                                                <asp:Label ID="lblNoOfYrs" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="No. of years with reliance"></asp:Label>
                                                 <span style="color: Red;">*</span>
                                      </div>   
                                       <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updNoOfYrs">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNoOfYrs" runat="server" CssClass="form-control" 
                                                        TabIndex="6">
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                   </div>
                                  <div class="row">
                                       <div class="col-sm-3" style="text-align:left">
                                          
                                                <asp:Label ID="lblTypeOfVehicle" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="If Dealer, type of vehicle dealing in"></asp:Label>
                                                  <span style="color: Red;">*</span>
                                      </div>   
                                       <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updTypeOfvehicle">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTypeOfVehicle" runat="server" CssClass="form-control" 
                                                        TabIndex="6">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                                <div class="col-sm-3" style="text-align:left">
                                         
                                                <asp:Label ID="lblVchlManf" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="If Dealer, vehicle manufacturer dealing with"></asp:Label>
                                                   <span style="color: Red;">*</span>
                                      </div>   
                                     <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updVechManuf">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlVechManuf" runat="server" CssClass="form-control" 
                                                        TabIndex="6">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                    </div>   
                                  <div class="row">
                                         <div class="col-sm-3" style="text-align:left">
                                       
                                                <asp:Label ID="lblDlrCompName" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="Company  Name"></asp:Label>
                                                     <span style="color: Red;">*</span>
                                      </div>   
                                            <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updDlrCompName">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtDlrCompName" runat="server" Enabled="false" CssClass="form-control"
                                                        onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="30" 
                                                        TabIndex="8"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `0123456789" FilterMode="InvalidChars"
                                                        TargetControlID="txtDlrCompName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                           <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblDlrOth" runat="server" CssClass="control-label" Font-Bold="False" Text="From others please specify"></asp:Label>
                                      </div>   
                                           <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updDlrOth">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtDlrOth" runat="server" Enabled="false" CssClass="form-control"
                                                        onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="30" 
                                                        TabIndex="8"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `0123456789" FilterMode="InvalidChars"
                                                        TargetControlID="txtDlrOth" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                    </div> 
                                   </div>
                                      </div>      
                        <div class="panel panel-success" style="margin-left:0px;margin-right:0px">
                                          <div id="Div15" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divpotentail','btnpotential');return false;">  
                                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-chevron-down"  ></span>
                     <asp:Label ID="Label13" runat="server" Text="Potential of agent"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnpotential" class="glyphicon glyphicon-collapse-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>  
                                                </div> 
                                            <div id="divpotentail" runat="server" style="display:block;" class="panel-body"> 
                                      <div class="row">
                                       <div class="col-sm-3" style="text-align:left">
                                          
                                                <asp:Label ID="Label14" runat="server" CssClass="control-label" Font-Bold="False" Text="Avg. monthly volume in Lacs"></asp:Label>
                                                  <span style="color: Red;">*</span>
                                      </div>   
                                       <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updAvgMonthlyIncm">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlAvgMonthlyIncm" runat="server" CssClass="form-control" 
                                                        TabIndex="6" >
                                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                         <div class="col-sm-3">
                                         </div>
                                            <div class="col-sm-3">
                                            </div>
                                      </div>   
                                     </div>  
                                    </div>  
                        <div class="panel panel-success" style="margin-left:0px;margin-right:0px">
                                        <div id="Div16" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divCompetitor','btnCompetitor');return false;">  
                                           <div class="row">
                                                 <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-chevron-down"  ></span>
                     <asp:Label ID="Label20" runat="server"   Text="Competitor company working with" CssClass="control-label" ></asp:Label>
                 
                    </div>
                                                 <div class="col-sm-2">
                        <span id="btnCompetitor" class="glyphicon glyphicon-collapse-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                                          </div>
                                                </div>  
                                       <div id="divCompetitor" style="display:block;" runat="server" class="panel-body"> 
                                                <div class="row">
                                        <div class="col-sm-3" style="text-align:left">
                                         
                                                <asp:Label ID="lblComp1Name" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="Company 1 name"></asp:Label>
                                                   <span style="color: Red;">*</span>
                                      </div>   
                                       <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updComp1Name">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlComp1Name" runat="server" CssClass="form-control" 
                                                        TabIndex="6" >
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                <div class="col-sm-3" style="text-align:left">
                                           
                                                <asp:Label ID="lblMnthVol1" runat="server" CssClass="control-label"
                                                    Text="Monthly volume in Lacs" ></asp:Label>
                                                 <span style="color: Red;">*</span>
                                      </div>   
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updMnthVol1">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlMnthVol1" runat="server" CssClass="form-control"
                                                        TabIndex="6" >
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                    </div>   
                                  <div class="row">
                                      <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblComp2Name" runat="server" CssClass="control-label" Font-Bold="False"
                                                Text="Company 2 name"></asp:Label>
                                      </div>   
                                      <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updComp2Name">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlComp2Name" runat="server" CssClass="form-control" 
                                                        TabIndex="6" >
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                      <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblMnthVol2" runat="server" CssClass="control-label"
                                                Text="Monthly volume in Lacs"></asp:Label>
                                      </div>   
                                      <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updMnthVol2">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlMnthVol2" runat="server" CssClass="form-control" 
                                                        TabIndex="6" >
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>   
                                    </div>   
                                           </div>  
                                                </div>       
                        <div class="panel panel-success" style="margin-left:0px;margin-right:0px">         
                             <div id="Div17" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRGI','btnRGI');return false;">  
                           <div class="row">
                              <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-chevron-down"  ></span>
                     <asp:Label ID="Label21" runat="server" Text="Business volume with RGI"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                              <div class="col-sm-2">
                        <span id="btnRGI" class="glyphicon glyphicon-collapse-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                           </div>
                     </div>   
                             <div id="divRGI" runat="server" style="display:block;" class="panel-body">
                                    <div class="row">
                                    <div class="col-sm-3" style="text-align:left">
                                         
                                                <asp:Label ID="lblRGIMnthVol" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Text="Monthly volume in Lacs"></asp:Label>
                                                   <span style="color: Red;">*</span>
                                      </div>   
                                <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updRGIMnthVol">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlRGIMnthVol" runat="server" CssClass="form-control" 
                                                        TabIndex="6" >
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>  
                                        <div class="col-sm-3">
                                      </div>
                                        <div class="col-sm-3">
                                        </div>
                                    </div>   
                                       </div>   
                        </div>   
                        <div class="panel panel-success" style="margin-left:0px;margin-right:0px"> 
                         <div id="Div18" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divProduct','btnProduct');return false;"> 
                           <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-chevron-down" ></span>
                     <asp:Label ID="lblPrdMxAgn" runat="server" Text="Product mix of agent"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnProduct" class="glyphicon glyphicon-collapse-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>     <%-- panel-body panel-collapse collapse in  --%>               <%--panel-heading subheader--%>
                </div>
                     <div id="divProduct" style="display:block;" runat="server" class="panel-body">
          
                   <div id="div20">
                       <div class="panel panel-success" style="margin-left:0px;margin-right:0px"> 
                     <div id="Div19" runat="server" class="panel-heading subheader" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_divTotalbuisness','btnTotalbuisness');return false;"
                      style="background-color:#EDF1cc !important">   
                       <div class="row">
                    <div class="col-sm-9" style="text-align:left">
                      <span class="glyphicon glyphicon-chevron-down" ></span>
                     <asp:Label ID="Label22" runat="server" Text="Total Business"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-3">
                        <span id="btnTotalbuisness" class="glyphicon glyphicon-resize-full" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>      
                    </div>        
                          </div>                      
                     <div id="divTotalbuisness" style="display:block;" runat="server" class="panel-body">
                                                    <div class="row">
                                                         <div class="col-sm-2" style="text-align:left">
                                                       
                                                            <asp:Label ID="lblTotBsnMtr" runat="server" CssClass="control-label" 
                                                                Font-Bold="False" Text="Motor (in percentage)"></asp:Label>
                                                                 <span style="color: Red;">*</span>
                                                      </div>   
                                                         <div class="col-sm-2">
                                                            <asp:UpdatePanel ID="updTotBsnMtr" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlTotBsnMtr" runat="server" CssClass="form-control"
                                                                        TabIndex="6" >
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                      </div>   
                                                         <div class="col-sm-2" style="text-align:left">
                                                        
                                                            <asp:Label ID="lblTotBsnHlth" runat="server" CssClass="control-label" 
                                                                Font-Bold="False" Text="Health (in percentage)"></asp:Label>
                                                                <span style="color: Red;">*</span>
                                                      </div>   
                                                         <div class="col-sm-2">
                                                            <asp:UpdatePanel ID="updddlTotBsnHlth" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlTotBsnHlth" runat="server" CssClass="form-control" 
                                                                        TabIndex="6" >
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                      </div>   
                                                         <div class="col-sm-2" style="text-align:left">
                                                            
                                                            <asp:Label ID="lblTotBsnComm" runat="server" CssClass="control-label" 
                                                                Font-Bold="False" Text="Commercial line (in percentage)"></asp:Label>
                                                            <span style="color: Red;">*</span>
                                                      </div>   
                                                         <div class="col-sm-2">
                                                            <asp:UpdatePanel ID="updddlTotBsnComm" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlTotBsnComm" runat="server" CssClass="form-control"
                                                                        TabIndex="6" >
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                      </div>   
                                                    </div>
                      </div>
                      </div>
                          <div class="panel panel-success" style="margin-left:0px;margin-right:0px"> 
                     <div id="Div21" runat="server" class="panel-heading subheader" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_divBuisnessRGI','btnBuisnessRGI');return false;"
                     style="background-color:#EDF1cc !important"> 
                       <div class="row">
                    <div class="col-sm-9" style="text-align:left">
                      <span class="glyphicon glyphicon-chevron-down" ></span>
                     <asp:Label ID="Label23" runat="server" Text="Business with RGI"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-3">
                        <span id="btnBuisnessRGI" class="glyphicon glyphicon-resize-full" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>      
                    </div>  
                    </div> 
                     <div id="divBuisnessRGI" style="display:block;" runat="server" class="panel-body">
                                                    <div class="row">
                                                        <div class="col-sm-2" style="text-align:left">
                                                           
                                                            <asp:Label ID="lblRGIBsnMtr" runat="server" CssClass="control-label" 
                                                                Font-Bold="False" Text="Motor (in percentage)"></asp:Label>
                                                             <span style="color: Red;">*</span>
                                                      </div>   
                                                         <div class="col-sm-2">
                                                            <asp:UpdatePanel ID="updRGIBsnMtr" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlRGIBsnMtr" runat="server" CssClass="form-control"
                                                                        TabIndex="6" >
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                      </div>   
                                                       <div class="col-sm-2" style="text-align:left">
                                                            <asp:Label ID="lblRGIBsnHlth" runat="server" CssClass="control-label" 
                                                                Font-Bold="False" Text="Health (in percentage)"></asp:Label>
                                                              <span style="color: Red;">*</span>
                                                      </div>   
                                                      <div class="col-sm-2">
                                                            <asp:UpdatePanel ID="updddlRGIBsnHlth" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlRGIBsnHlth" runat="server" CssClass="form-control" 
                                                                        TabIndex="6" >
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                      </div>   
                                                       <div class="col-sm-2" style="text-align:left">
                                                       
                                                            <asp:Label ID="lblRGIBsnComm" runat="server" CssClass="control-label" 
                                                                Font-Bold="False" Text="Commercial line (in percentage)"></asp:Label>
                                                                 <span style="color: Red;">*</span>
                                                      </div>   
                                                          <div class="col-sm-2">
                                                            <asp:UpdatePanel ID="updddlRGIBsnComm" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlRGIBsnComm" runat="server" CssClass="form-control" 
                                                                        TabIndex="6" >
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
                             
                                    <div id="divButtons" runat="server">
             <div class="col-sm-12" align="center">
                             <asp:LinkButton ID="btnSubmit"
                             OnClientClick="return Validation();" OnClick="btnSubmit_Click" 
                                            CssClass="btn btn-primary" runat="server">
                                 <span class=" glyphicon glyphicon-saved"  style="color:White"> </span> Submit
                                 </asp:LinkButton>
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" CssClass="standardbutton"
                                Width="80px" Visible="false" OnClientClick="StartProgressBar();"></asp:Button>
                            <asp:Button ID="BtnApprove" OnClick="btnApprove_Click" runat="server" Text="Approve"
                                CssClass="standardbutton" Width="80px" Visible="false" OnClientClick="StartProgressBar();">
                            </asp:Button>
                            <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="standardbutton"
                                Visible="false" Width="114" OnClick="btnReject_Click" OnClientClick="StartProgressBar();" />
                             <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-danger"
                                            runat="server">
                                <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                                        </asp:LinkButton>
                            <%--  Added by shreela on 14/07/2014 for renewals--%>
                            <asp:Button ID="btnCancel" runat="server" CssClass="standardbutton" Style="display: none;" Width="114px"
                                Text="Cancel" OnClick="btnCancel_Click" Visible="false" OnClientClick="CloseSub()" /><%--modify by amruta on 14/05/2015 for removing cancel button--%>
                            <asp:Button ID="btnCroprefresh" runat="server" CssClass="standardbutton" Style="display: none;"
                                ClientIDMode="Static" OnClick="btnCroprefresh_Click" /><%--added by shreela on 05/08/2014 fro cropping--%>
                            <asp:Button ID="btnReOpenReFresh" runat="server" CssClass="standardbutton" Style="display: none;"
                                ClientIDMode="Static" OnClick="btnReOpenReFresh_Click" />
                           <%-- <div id="divloader" runat="server" style="display: none;">
                                &nbsp;&nbsp;
                                <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                                Loading...
                            </div>--%>
                       </div>
            <table>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdnBranchCode" runat="server" />
                        <asp:HiddenField ID="hdnflag" runat="server" />
                        <asp:HiddenField ID="hdnDocCode" runat="server" />
                        <%--//Added by rachana on 02-01-2014 for confirmation of approval--%>
                        <asp:HiddenField ID="hdnDoctype" runat="server" />
                        <asp:HiddenField ID="hdnprevcount" runat="server" />
                        <asp:HiddenField ID="hdnCandTypeRen" runat="server" />
                        <asp:HiddenField ID="hdnInsRenType" runat="server" />
                        <asp:HiddenField ID="hdncompinsren" runat="server" />
                        <%--shree--%>
                        <asp:HiddenField ID="hdnrenwlflag" runat="server" />
                        <%--shree--%>
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnStartDate" runat="server" />
                        <asp:HiddenField ID="hdnRenwlCnt" runat="server" />
                        <asp:HiddenField ID="hdnRenwl" runat="server" />
                    </td>
                    <td>
                        <input type="hidden" runat="server" id="hdnUserId" />
                        <input id="hdnIsDateValid" type="hidden" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnBizSrc" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnTrnLoc" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnTrnInst" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAgnPhoto" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAgnSign" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnTccID" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAppNo" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnCndNo" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnSDate" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnStateCode" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAgnCode" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnbtnVerify" runat="server" />
                        <asp:HiddenField ID="hdnbtnemailVerify" runat="server" />
                        <asp:HiddenField ID="hdnMobileVerify" runat="server" />
                    </td>
                    <!-- Added by ank 12.01.2011-->
                    <td>
                        <asp:HiddenField ID="hdnWebTkn" runat="server" />
                    </td>
                    <!-- Added by Darshik 01.02.2013-->
                    <td>
                        <asp:HiddenField ID="hdnWebTknCon" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnEntryDate" runat="server" />
                    </td>
                    <asp:UpdatePanel ID="updPnlHidden" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hdnPan" runat="server" />
                            <asp:HiddenField ID="hdnEmail" runat="server" />
                            <asp:HiddenField ID="hdnMobile" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <td>
                        <asp:HiddenField ID="hdnCanid" runat="server" />
                        <asp:HiddenField ID="hdnpath" runat="server" />
                        <asp:Button Text="btnok" ID="btnopen" OnClick="btnopen_Click" runat="server" Visible="false" />
                    </td>
                </tr>
            </table>
        </div>
            </div>
              <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
  

      <div class="modal-content" >
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="lbl" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lblSub" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button"  class="btn btn-primary"  data-dismiss="modal">
             <span class="glyphicon glyphicon-ok  BtnGlyphicon"> </span> OK

             </button>
         
        </div>
      </div>

      
      
    </div>
  </div>
        </div>
        <table style="width: 90%;display:none;" class="container">
            <tr align="center">
                <td>
                    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                      <asp:View ID="View1" runat="server">
                           </asp:View>
                        <asp:View ID="View2" runat="server">
                          
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
        <%--<asp:Panel ID="Panelphoto1"   runat="server" BorderColor="ActiveBorder" BorderStyle="Solid" BorderWidth="2px"  Width="89%" Height="500px" 
           ScrollBars="Vertical" class="modalpopupmesg" HorizontalAlign="Left" style="display:none"> 
          <center>
              <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height:5%;">
                 <tr>
                     <td >
                         <asp:Label ID="Label3" runat="server"   CssClass = "standardlink "/>
                         
                     </td>
                 </tr>
             </table>
          </center>
          <table style="width: 99%; height: 18px">
             <tr class="modalpanelleft">
               <td>
                  <asp:Image ID="Imageall" runat="server"/>
               </td>
            </tr>
         </table>   
      </asp:Panel>--%>
        <asp:Panel ID="Panelphoto2" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
            BorderWidth="2px" Width="89%" Visible="true" class="modalpopupmesg" ScrollBars="Vertical">
            <asp:UpdatePanel runat="server" ID="upnlHeader">
                <ContentTemplate>
                    <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height: 5%;">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblpanelheader" runat="server" CssClass="standardlink " />
                                <asp:HiddenField ID="hdnDocId" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <table class="modalpanel" style="display: none">
                        <tr>
                            <td>
                                <asp:Image ID="imgCrop" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <%----%>
                    <div id="divgrid" runat="server" style="width: 100%; height: 100%; overflow: hidden">
                        <table style="border-collapse: separate; left: 0in; position: relative; top: 0px;
                            width: 100%;" class="tableIsys">
                            <tr>
                                <td>
                                    <asp:GridView ID="GridImage" runat="server" AllowSorting="True" CssClass="tableIsys"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                        RowStyle-CssClass="tableIsys" HorizontalAlign="Left" AutoGenerateColumns="False"
                                        AllowPaging="True" Width="100%" Height="242px" OnPageIndexChanging="GridImage_PageIndexChanging"
                                        OnRowDataBound="GridImage_RowDataBound">
                                        <Columns>
                                            <%--<asp:TemplateField SortExpression="DocType" HeaderText="Image Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblCndNo" runat="server" Text='<%# Eval("DocType") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton>
                                                    <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ID") %>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ImageField DataImageUrlField="ID" DataImageUrlFormatString="ImageCSharp.aspx?ImageID={0}"
                                                HeaderText="Preview Image">
                                                <%--ItemStyle-Height="100%" ItemStyle-Width="100%"--%>
                                            </asp:ImageField>
                                        </Columns>
                                        <RowStyle CssClass="sublinkeven" BackColor="#78A8FA"></RowStyle>
                                        <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                        </PagerStyle>
                                        <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                        <AlternatingRowStyle CssClass="sublinkodd" BackColor="#78A8FA"></AlternatingRowStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <iframe id="FrmImg" runat="server" visible="false" width="100%" height="500px"></iframe>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnnext" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
     
        <%--<div>
         <table style="width: 90%">
             <tbody>
                    <tr>
                        <td style="height: 20px" align="left" colspan="4">
                            <asp:Label ID="lblNotes" runat="server" Visible="true" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>--%>
    </center>

    <%-- //Ibrahim--%>
  <asp:Panel runat="server" ID="pnlMdl" Width ="500" display = "none" >
        <iframe runat="server" id="ifrmMdlPopup" width="610px" height="300px" frameborder="0"
            display="none"></iframe>
         <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg"
        X="260" Y="100" >
                    </ajaxToolkit:ModalPopupExtender>
       <asp:HiddenField ID="hiddenField1" runat="server" />
    
    <%--Loader popup end--%>
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
    <input id="Hidden1" type="hidden" runat="server" />
    <input id="hdnDOB" type="hidden" runat="server" />
    <input id="hdnSave" type="hidden" runat="server" />
    <input id="hdnUpdate" type="hidden" runat="server" />
    <input id="Hidden2" type="hidden" runat="server" />
    <input id="hdSmCode" type="hidden" runat="server" />
    <input id="hdnECCode" type="hidden" runat="server" />
    <input id="Hidden3" type="hidden" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="hdnBtnDis" runat="server" />
    <script language="javascript" type="text/javascript">
        var path = "<%=Request.ApplicationPath.ToString()%>";
        var imgno = 1;

        function Validation() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////
            var StateCode = (document.getElementById("<%=hdnStateCode.ClientID %>").value);

            if (StateCode == "ME" || StateCode == "SI") {
            }
            else {
                if (document.getElementById("<%=txtPAN.ClientID%>").value == "") {
                    alert("Please Enter PAN No");
                    document.getElementById("<%=txtPAN.ClientID%>").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById("<%=txtPAN.ClientID%>").value != "") {
                if (CheckPANFormat(document.getElementById("<%=txtPAN.ClientID%>").value) == 0) {
                    alert("Please Enter Valid PAN No");
                    document.getElementById("<%=txtPAN.ClientID%>").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

            }



            //Added by Nikhil on 21.5.15
            if (document.getElementById("<%=chkEdit.ClientID %>").checked) {
                //Validation for Present Address -1
                if (SpaceTrim(document.getElementById(strContent + "txtPAddline1").value) == "") {
                    alert(document.getElementById(strContent + "hdnID370").value + "Please Enter Address Line 1");
                    document.getElementById(strContent + "txtPAddline1").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //Validation for Present Address -2
                if (SpaceTrim(document.getElementById(strContent + "txtPAdd2").value) == "") {
                    alert(document.getElementById(strContent + "hdnID370").value + "Please Enter Address Line 2");
                    document.getElementById(strContent + "txtPAdd2").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //Validation for Present Address -3
                if (SpaceTrim(document.getElementById(strContent + "txtPAdd3").value) == "") {
                    alert(document.getElementById(strContent + "hdnID370").value + "Please Enter Address Line 3");
                    document.getElementById(strContent + "txtPAdd3").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //Nikhil District start
                if (SpaceTrim(document.getElementById(strContent + "txtPDistrict").value) == "") {
                    alert("Plese enter district");
                    document.getElementById(strContent + "txtPDistrict").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById(strContent + "txtPDistrict").value) == "") {
                    alert("Plese select district");
                    document.getElementById(strContent + "txtPDistrict").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //Nikhil city start 
                if (SpaceTrim(document.getElementById(strContent + "txtPcity1").value) == "") {
                    alert("Please enter City");
                    document.getElementById(strContent + "txtPcity1").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //Nikhil end

                //Nikhil area start 
                if (SpaceTrim(document.getElementById(strContent + "txtParea1").value) == "") {
                    alert("Please enter Area");
                    document.getElementById(strContent + "txtParea1").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //Validation for State 
                if (document.getElementById('<%=ddlstate1.ClientID %>').value == "" || document.getElementById('<%=ddlstate1.ClientID %>').value == "Select") {
                    alert("Please select the state");
                    document.getElementById(strContent + "ddlstate1").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }


                //            //Validation for PAN No format.
                //            if (SpaceTrim(document.getElementById(strContent + "txtCurrentID").value) != "") {
                //                if (CheckPANFormat(SpaceTrim(document.getElementById(strContent + "txtCurrentID").value)) == 0) {
                //                    alert(document.getElementById(strContent + "hdnID580").value);
                //                    document.getElementById(strContent + "txtCurrentID").focus();
                //                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                //                    return false;
                //                }
                //            }


                //Validation for Present Address PinCode
                if (SpaceTrim(document.getElementById(strContent + "txtPermPostcode").value) == "") {
                    alert(document.getElementById(strContent + "hdnID390").value);
                    document.getElementById(strContent + "txtPermPostcode").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                else {
                    var Pin = document.getElementById(strContent + "txtPermPostcode").value;
                    var PinFrom = SpaceTrim(document.getElementById(strContent + "hdnPermPinFrom").value);
                    var PinTo = SpaceTrim(document.getElementById(strContent + "hdnPermPinTo").value);

                    if (PinFrom <= Pin && PinTo >= Pin) {
                    }
                    else {
                        if (PinFrom.length != 0) {
                            alert("Pincode range should be between " + PinFrom + " to " + PinTo);
                            document.getElementById(strContent + "txtPermPostcode").focus();
                            // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }
                }

                //Validation for Present Address Country Code
                if (SpaceTrim(document.getElementById(strContent + "txtCountryCodeP").value) == "") {
                    alert(document.getElementById(strContent + "hdnID400").value + " Code");
                    document.getElementById(strContent + "txtCountryCodeP").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById(strContent + "txtCountryCodeP").value) != null) {
                    if (SpaceTrim(document.getElementById(strContent + "txtCountryDescP").value) == "") {
                        alert(document.getElementById(strContent + "hdnID600").value);
                        document.getElementById(strContent + "txtCountryCodeP").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }
            
            }
            else if (SpaceTrim(document.getElementById(strContent + "lblpfaddresstypeDesc").value) == "" ||
            SpaceTrim(document.getElementById(strContent + "lblpfAddrP1Desc").value) == "" ||
            SpaceTrim(document.getElementById(strContent + "lblpfAddrP2Desc").value) == "" ||
            SpaceTrim(document.getElementById(strContent + "lblpfAddrP3Desc").value) == "" ||
            SpaceTrim(document.getElementById(strContent + "lblpfStatePDesc").value) == "" ||
            SpaceTrim(document.getElementById(strContent + "lbldistDesc").value) == "" ||
            SpaceTrim(document.getElementById(strContent + "lblCityDesc").value) == "" ||
            SpaceTrim(document.getElementById(strContent + "lblareaDesc").value) == "" ||
            SpaceTrim(document.getElementById(strContent + "lblpfPinPDesc").value) == "" ||
            SpaceTrim(document.getElementById(strContent + "lblpfCountryPDesc").value) == "") {
                alert("Please Edit The Address Because Address is not Correct.");
                document.getElementById(strContent + "chkEdit").focus();
                return false;
            }
           
            //Ended by Nikhil

            if (document.getElementById(strContent + "ddlagntype").selectedIndex == 0) {

                alert("Please Select Agent Type");
                document.getElementById(strContent + "ddlagntype").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            //Validation IsWorking
            //if (document.getElementById(strContent + "ddlIsWrkng") != null) {
            if (document.getElementById(strContent + "ddlIsWrkng").selectedIndex == 0) {
                alert("Please select Is he Working With Some other Reliance Capital Company");
                document.getElementById(strContent + "ddlIsWrkng").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}


            //Validation IsWorking then specify CompName
            if (document.getElementById(strContent + "ddlIsWrkng").selectedIndex == 1) {

                if (document.getElementById(strContent + "ddlcompName").selectedIndex == 0) {
                    alert("Please specify Company Name");
                    document.getElementById(strContent + "ddlcompName").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation No. of YEARS In Insurance
            //if (document.getElementById(strContent + "ddlNoOfYrsIns") != null) {
            if (document.getElementById(strContent + "ddlNoOfYrsIns").selectedIndex == 0) {
                alert("Please select No. of Years In Insurance");
                document.getElementById(strContent + "ddlNoOfYrsIns").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}


            //Validation No. of YEARS In Reliance
            if (document.getElementById(strContent + "ddlNoOfYrs").selectedIndex == 0) {
                alert("Please select No. of Years with Reliance");
                document.getElementById(strContent + "ddlNoOfYrs").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            //Validation for agenType
            if (document.getElementById(strContent + "ddlagntype").selectedIndex == 5) {

                if (SpaceTrim(document.getElementById(strContent + "txtOthers").value) == "") {
                    alert("Please fill From Others please Specify");
                    document.getElementById(strContent + "txtOthers").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation VEHICLE MANUFACTURER DEALING WITH
            if (document.getElementById(strContent + "ddlagntype").selectedIndex == 2) {

                if (document.getElementById(strContent + "ddlTypeOfVehicle").selectedIndex == 0) {
                    alert("Please select Type of Vehicle Dealing in");
                    document.getElementById(strContent + "ddlTypeOfVehicle").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (document.getElementById(strContent + "ddlVechManuf").selectedIndex == 0) {
                    alert("Please select VEHICLE MANUFACTURER DEALING WITH");
                    document.getElementById(strContent + "ddlVechManuf").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (document.getElementById(strContent + "txtDlrCompName").value == "") {
                    alert("Please Enter Company Name");
                    document.getElementById(strContent + "txtDlrCompName").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

            }


            //Validation Potential of Agent
            //if (document.getElementById(strContent + "ddlAvgMonthlyIncm") != null) {
            if (document.getElementById(strContent + "ddlAvgMonthlyIncm").selectedIndex == 0) {
                alert("Please select Potential of agent");
                document.getElementById(strContent + "ddlAvgMonthlyIncm").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}


            //Validation COMPETITOR COMPANY Name 1
            //if (document.getElementById(strContent + "ddlComp1Name") != null) {
            if (document.getElementById(strContent + "ddlComp1Name").selectedIndex == 0) {
                alert("Please select COMPETITOR COMPANY Name 1");
                document.getElementById(strContent + "ddlComp1Name").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}


            //Validation COMPETITOR COMPANY Monthly Volume
            //if (document.getElementById(strContent + "ddlMnthVol1") != null) {
            if (document.getElementById(strContent + "ddlMnthVol1").selectedIndex == 0) {
                alert("Please select COMPETITOR COMPANY Monthly Volume 1");
                document.getElementById(strContent + "ddlMnthVol1").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}

            //Validation  Business Volume with RGI
            //if (document.getElementById(strContent + "ddlRGIMnthVol") != null) {
            if (document.getElementById(strContent + "ddlRGIMnthVol").selectedIndex == 0) {
                alert("Please select Business Volume With RGI");
                document.getElementById(strContent + "ddlRGIMnthVol").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            // }

            //Validation Total Business for Motor
            //if (document.getElementById(strContent + "ddlTotBsnMtr") != null) {
            debugger;
            if (document.getElementById(strContent + "ddlTotBsnMtr").selectedIndex == 0) {
                alert("Please select Total Business for Motor");
                document.getElementById(strContent + "ddlTotBsnMtr").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}

            //Validation Total Business for Health
            //if (document.getElementById(strContent + "ddlTotBsnHlth") != null) {

            if (document.getElementById(strContent + "ddlTotBsnHlth").selectedIndex == 0) {
                alert("Please select Total Business for Health");
                document.getElementById(strContent + "ddlTotBsnHlth").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}

            //Validation  COMERCIAL LINE
            //if (document.getElementById(strContent + "ddlTotBsnComm") != null) {
            if (document.getElementById(strContent + "ddlTotBsnComm").selectedIndex == 0) {
                alert("Please select Total Business for COMERCIAL LINE");
                document.getElementById(strContent + "ddlTotBsnComm").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}

            //Validation Business for Motor with RGI
            //if (document.getElementById(strContent + "ddlRGIBsnMtr") != null) {
            if (document.getElementById(strContent + "ddlRGIBsnMtr").selectedIndex == 0) {
                alert("Please select Business for Motor with RGI");
                document.getElementById(strContent + "ddlRGIBsnMtr").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}

            //Validation Business for Motor with RGI
            //if (document.getElementById(strContent + "ddlRGIBsnHlth") != null) {
            if (document.getElementById(strContent + "ddlRGIBsnHlth").selectedIndex == 0) {
                alert("Please select Business for Health with RGI");
                document.getElementById(strContent + "ddlRGIBsnHlth").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}

            //Validation Business COMERCIAL LINE with RGI
            //if (document.getElementById(strContent + "ddlRGIBsnComm") != null) {
            if (document.getElementById(strContent + "ddlRGIBsnComm").selectedIndex == 0) {
                alert("Please select Business for COMMERCIAL LINE with RGI");
                document.getElementById(strContent + "ddlRGIBsnComm").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
         
        }



        //added by pranjali on 04-03-2014 start
        function funvalidateApprove() {

            var strContent = "ctl00_ContentPlaceHolder1_";
            debugger;


            //added by pranjali on 11-04-2014 start
            if (document.getElementById('<%=ddlExam.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExam.ClientID %>').value == "Select") || (document.getElementById('<%=ddlExam.ClientID %>').value == "")) {
                    alert("Exam Mode is Mandatory.");
                    document.getElementById('<%= ddlExam.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlExmBody.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExmBody.ClientID %>').value == "Select") || (document.getElementById('<%=ddlExmBody.ClientID %>').value == "")) {
                    alert("Exam Body is Mandatory.");
                    document.getElementById('<%= ddlExmBody.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlpreeamlng.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "Select") || (document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "")) {
                    alert("Exam language is Mandatory.");
                    document.getElementById('<%= ddlpreeamlng.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (document.getElementById('<%=txtExmCentre.ClientID %>') != null) {
                if ((document.getElementById('<%=txtExmCentre.ClientID%>').value == "Select") || (document.getElementById('<%=txtExmCentre.ClientID%>').value == "")) {
                    alert("Exam Centre is Mandatory.");
                    document.getElementById('<%=txtExmCentre.ClientID%>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //            if (document.getElementById('<%=ddlExmCentre.ClientID %>') != null) {
            //                if ((document.getElementById('<%=ddlExmCentre.ClientID %>').value == "Select") || (document.getElementById('<%=ddlExmCentre.ClientID %>').value == "")) {
            //                    alert("Exam Centre is Mandatory.");
            //                    document.getElementById('<%= ddlExmCentre.ClientID %>').focus();
            //                    return false;
            //                }
            //            }

            //added by pranjali on 11-04-2014 end
            if (document.getElementById("ctl00_ContentPlaceHolder1_cbTrfrFlag") != null) {
                if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked != true) {
                    //debugger;
                    if (document.getElementById('<%=ddlTrnMode.ClientID %>') != null) {
                        if ((document.getElementById('<%= ddlTrnMode.ClientID %>').value == "Select") || (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "")) {
                            alert("Please Select Training Mode");
                            document.getElementById('<%= ddlTrnMode.ClientID  %>').focus();
                           // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById('<%=ddlTrnLoc.ClientID %>') != null) {
                        if ((document.getElementById("<%=ddlTrnLoc.ClientID%>").value == "Select") || (document.getElementById('<%=ddlTrnLoc.ClientID %>').value == "")) {
                            alert("Please Enter the Training Location");
                            document.getElementById("<%=ddlTrnLoc.ClientID%>").focus();
                           // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }
                    if (document.getElementById('<%=ddlTrnInstitute.ClientID %>') != null) {
                        if ((document.getElementById('<%=ddlTrnInstitute.ClientID %>').value == "Select") || (document.getElementById('<%=ddlTrnInstitute.ClientID %>').value == "")) {
                            alert("Please Select Training Institute");
                            document.getElementById("<%=ddlTrnInstitute.ClientID%>").focus();
                           // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById('<%=ddlHrsTrn.ClientID %>') != null) {
                        if ((document.getElementById('<%= ddlHrsTrn.ClientID %>').value == "Select") || (document.getElementById('<%=ddlHrsTrn.ClientID %>').value == "")) {
                            alert("Please Select Training Hrs");
                            document.getElementById('<%= ddlHrsTrn.ClientID  %>').focus();
                           // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }
                }
            }

            //shree
            if (document.getElementById("<%=hdnrenwlflag.ClientID %>").value == "Y") {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                    if (document.getElementById('<%=txtCompLicNo.ClientID %>').Value == "") {
                        alert("Please Enter Life LicenseNo.");
                        document.getElementById("<%=txtCompLicNo.ClientID %>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (document.getElementById('<%=txtCompLicExpDt.ClientID %>').Value == "") {
                        alert("Please Enter License Exp.Date");
                        document.getElementById("<%=txtCompLicExpDt.ClientID %>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (document.getElementById('<%=ddlCompInsurerName.ClientID %>') != null) {
                        if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "Select") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                            alert("Please Select Insurer Name");
                            document.getElementById("<%=ddlCompInsurerName.ClientID%>").focus();
                           // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }


                }
                //shree07
                //added by shreela on18042014 for renewals validation
                if (document.getElementById('<%=hdnCandTypeRen.ClientID %>').value == "Composite") {
                    if ((document.getElementById('<%=ddlRenewType.ClientID %>').value == "-Select-") || (document.getElementById('<%=ddlRenewType.ClientID %>').value == "")) {
                        alert("Insurer Type is Mandatory.");
                        document.getElementById('<%= ddlRenewType.ClientID %>').focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    if (document.getElementById('<%=hdnInsRenType.ClientID %>').value == "L") {
                        if (document.getElementById('<%=ddllyfTraining.ClientID %>') != null) {
                            if ((document.getElementById('<%=ddllyfTraining.ClientID %>').value == "-Select-") || (document.getElementById('<%=ddllyfTraining.ClientID %>').value == "")) {
                                alert("Life Training Completed is Mandatory.");
                                document.getElementById('<%= ddllyfTraining.ClientID %>').focus();
                               // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                                return false;
                            }
                        } //shree
                    }
                }
            }
            //shree
            //Validate Transfer Case
            debugger;
            if (document.getElementById("<%=cbTrfrFlag.ClientID %>") != null) {
                if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked == true) {
                    if (document.getElementById(strContent + "txtOldTccLcnNo").value != null) {
                        if (document.getElementById(strContent + "txtOldTccLcnNo").value == "") {
                            alert("License Number for Transfer is Mandatory");
                            document.getElementById(strContent + "txtOldTccLcnNo").focus();
                           // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById(strContent + "txtDate").value == "")//txtOldTccLcnExpDate_txtDate
                    {
                        alert("License Expiry Date for Transfer is Mandatory");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtDate").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }


                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "Select") || (document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "")) {
                        alert("Insurer Name for Transfer is Mandatory.");
                        document.getElementById('<%= ddlTrnsfrInsurName.ClientID %>').focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                    if (document.getElementById(strContent + "txtCndURNNo").value == "") {
                        alert("Candidate URN No. is Mandatory.");
                        document.getElementById(strContent + "txtCndURNNo").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (document.getElementById(strContent + "txtissudate").value == "") {
                        alert("License Issue Date for Transfer is Mandatory.");
                        document.getElementById(strContent + "txtissudate").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }
            }

            //added by pranjali on 13-03-2014 for composite start
            debugger;
            if (document.getElementById("<%=cbTccCompLcn.ClientID %>") != null) {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                    if (document.getElementById(strContent + "txtCompLicNo").value == "") {
                        alert("License Number for Composite is Mandatory");
                        document.getElementById(strContent + "txtCompLicNo").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }


                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "Select") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                        alert("Insurer Name for Composite is Mandatory.");
                        document.getElementById('<%= ddlCompInsurerName.ClientID %>').focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                }
            }

            //added by pranjali on 13-03-2014 for composite end

        }
        //added by pranjali on 04-03-2014 end
        function ValidationPAN() {

            var varPAN = document.getElementById('<%= txtPAN.ClientID %>').value;
            document.getElementById('<%= lblPANMsg.ClientID %>').style.display = 'none';

            if (varPAN.length == 0) {
                alert('Please Enter PAN No.');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }
            if (varPAN.length < 10) {
                alert('PAN No. must have minimum 10 characters.');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }

            if (varPAN.length != 10) {
                alert('PAN No. should be 10 characters.');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }

            document.getElementById('divPAN').style.display = 'block'

        }
        function CheckPANFormat(strPANNo) {
            var result = true;
            var pan = strPANNo.split(",");
            var Char;

            var pan2 = pan[0]
            if (pan2 != "") {
                if (pan2.length == 10) {
                    for (j = 0; j < pan2.length && result == true; j++) {
                        Char = pan2.substring(j, j + 1);

                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 9) {
                            if (!isAlphabet(Char)) {
                                return 0;
                            }
                            if (j == 3) {
                                if (pan2.substring(j, j + 1) != 'P')
                                    return 0;
                            }
                        }
                        if (j == 5 || j == 6 || j == 7 || j == 8) {
                            if (!IsNumeric(Char)) {
                                return 0;
                            }
                        }
                    }
                }
                else {
                    return 0;
                }
            }
            return 1;
        }

        function funOpenPopWinExmCentre(strPageName, strExmCentreName, strtxtExmCentreName, strhdnExmCCode) {
            if (document.getElementById('<%=ddlExam.ClientID %>').value == "Select") {
                alert("Please Select Exam Mode");
                return false;
            }
            else {
                if (document.getElementById('<%=ddlExam.ClientID %>').value == "1") {
                    alert("To Select Exam Center within 85 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                }
                else if (document.getElementById('<%=ddlExam.ClientID %>').value == "2") {
                    alert("To Select Exam Center within 100 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                }
                showPopWin(strPageName + "?txtExmCentreName=" + document.getElementById(strExmCentreName).value +
            "&strtxtExmCentreName=" + strtxtExmCentreName +
            "&strhdnExmCCode=" + strhdnExmCCode + "&ExmMode=" + document.getElementById('<%=ddlExam.ClientID %>').value + "&SalesUnitCode=" + "&BizSrc=" + document.getElementById('<%=hdnBizSrc.ClientID %>').value + "&ExmBody=" + document.getElementById('<%=ddlExmBody.ClientID %>').value, 750, 350, null);

            }
        }


        function funOpenPopWinTrnInstitute(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "Select") {
                alert("Please Select Training Mode");
                return false;
            }
            else {
                showPopWin(strPageName + "?txtTrnInstName=" + document.getElementById(strTrnInstitute).value +
            "&strtxtTrnInstitute=" + strtxtTrnInstitute +
            "&strhdnTrnInstitute=" + strhdnTrnInstitute + "&Page=TrnInst&TrnMode=" + document.getElementById('<%=ddlTrnMode.ClientID%>').value, 750, 350, null);
            }
        }

        function funOpenPopWinTrnLocation(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "Select") {
                alert("Please Select Training Mode");
                return false;
            }
            else {
                showPopWin(strPageName + "?txtTrnInstName=" + document.getElementById(strTrnInstitute).value +
            "&strtxtTrnInstitute=" + strtxtTrnInstitute +
            "&strhdnTrnInstitute=" + strhdnTrnInstitute + "&Page=TrnLoc&TrnMode=" + document.getElementById('<%=ddlTrnMode.ClientID%>').value + "&TrnInst=" + document.getElementById('<%=hdnTrnInstitute.ClientID%>').value, 750, 350, null);
            }
        }

        function funcopencrop1() {
            debugger;
            $find("MdlPopRaiseCrop").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCrop").src = "../../../Application/ISys/Recruit/CropImage.aspx?CndNo=" +
                 document.getElementById('<%=hdnCndNo.ClientID%>').value + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerText + "&mdlpopup=MdlPopRaiseCrop";

        } //added by shreela on 08/05/2014 for croping

        function FuncReOpen(lblRemarkidValue, lblAddnlRemark) {
            debugger;
            //$find("MdlPopReOpenCFR").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeReOpenCFR").src = "../../../Application/ISys/Recruit/PopReOpenCFR.aspx?RemarkId=" + lblRemarkidValue + "&Remarks=" + lblAddnlRemark + "&mdlpopup=MdlPopReOpenCFR";
        }

        function funcShowPopup(strPopUpType) // To populate popup of exam centre
        {
            if (strPopUpType == "RaiseCFR") {
                debugger;
                if (document.getElementById('<%=TxtTrnsfrReqNo.ClientID %>') != null) {
                    $find("MdlPopRaiseCFR").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopRaiseCFR.aspx?CndNo=" +
                 document.getElementById('<%=hdnCndNo.ClientID%>').value + "&UserId=" + document.getElementById('<%=hdnUserId.ClientID%>').value + "&args1=" +
                 document.getElementById('<%=BtnApprove.ClientID%>').id + "&args2=" + document.getElementById('<%=BtnCFR.ClientID%>').id + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerHTML + "&args4=" +
                 document.getElementById('<%=hdnDocId.ClientID%>').value + "&args5=" +
                 document.getElementById('<%=hdnDocCode.ClientID%>').value + "&raised=" +
                 document.getElementById('<%=lblcfrrais1count.ClientID%>').id + "&responded=" +
                 document.getElementById('<%=lblcfrrespondcount.ClientID%>').id + "&closed=" +
                 document.getElementById('<%=lblcfrclosed.ClientID%>').id + "&TransfrReqNo=" + document.getElementById('<%=TxtTrnsfrReqNo.ClientID%>').value + "&FlagCode=Trnsfr" + "&mdlpopup=MdlPopRaiseCFR";
                }
                else {
                    $find("MdlPopRaiseCFR").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopRaiseCFR.aspx?CndNo=" +
                 document.getElementById('<%=hdnCndNo.ClientID%>').value + "&UserId=" + document.getElementById('<%=hdnUserId.ClientID%>').value + "&args1=" +
                 document.getElementById('<%=BtnApprove.ClientID%>').id + "&args2=" + document.getElementById('<%=BtnCFR.ClientID%>').id + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerHTML + "&args4=" +
                 document.getElementById('<%=hdnDocId.ClientID%>').value + "&args5=" +
                 document.getElementById('<%=hdnDocCode.ClientID%>').value + "&raised=" +
                 document.getElementById('<%=lblcfrrais1count.ClientID%>').id + "&responded=" +
                 document.getElementById('<%=lblcfrrespondcount.ClientID%>').id + "&closed=" +
                 document.getElementById('<%=lblcfrclosed.ClientID%>').id + "&FlagCode=Others" + "&mdlpopup=MdlPopRaiseCFR";
                }
            }
            if (strPopUpType == "ExmCentre") {
                debugger;
                $find("mdlViewBIDExm").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeExm").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?ExmCentre=" +
                 document.getElementById('<%=txtExmCentre.ClientID%>').value + "&field1=" + document.getElementById('<%=txtExmCentre.ClientID %>').id +
                 "&field2=" + document.getElementById('<%=hdnExmCentreCode.ClientID %>').id +
                 "&mdlpopup=mdlViewBIDExm";
            }

            if (strPopUpType == "occup") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopOccupation.aspx?Code=" + document.getElementById('<%=txtOccupationCode.ClientID %>').value
        + "&Desc=" + document.getElementById('<%=txtOccupationDesc.ClientID %>').value + "&field1="
        + document.getElementById('<%=txtOccupationCode.ClientID %>').id + "&field2=" + document.getElementById('<%=txtOccupationDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "state1") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopState.aspx?Code=" + document.getElementById('<%=txtStateCodeR1.ClientID %>').value
        + "&Desc=" + document.getElementById('<%=txtStateDescR1.ClientID %>').value + "&field1="
        + document.getElementById('<%=txtStateCodeR1.ClientID %>').id + "&field2=" + document.getElementById('<%=txtStateDescR1.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "state2") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopState.aspx?Code=" + document.getElementById('<%=txtStateCodeR2.ClientID %>').value
        + "&Desc=" + document.getElementById('<%=txtStateDescR2.ClientID %>').value + "&field1="
        + document.getElementById('<%=txtStateCodeR2.ClientID %>').id + "&field2=" + document.getElementById('<%=txtStateDescR2.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "NExmCentre") {
                debugger;
                $find("mdlViewBIDExm").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeExm").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?ExmCentre=" +
                 document.getElementById('<%=txtNExmCenter.ClientID%>').value + "&field1=" + document.getElementById('<%=txtNExmCenter.ClientID %>').id +
                 "&field2=" + document.getElementById('<%=hdnNExmCenter.ClientID %>').id +
                 "&mdlpopup=mdlViewBIDExm";
            }
            if (strPopUpType == "ExamCentre") {
                if (document.getElementById('<%=ddlExam.ClientID %>').value == "Select") {
                    alert("Please Select Exam Mode");
                    return false;
                }
                else {
                    if (document.getElementById('<%=ddlExam.ClientID %>').value == "1") {
                        alert("To Select Exam Center within 85 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                    }
                    else if (document.getElementById('<%=ddlExam.ClientID %>').value == "2") {
                        alert("To Select Exam Center within 100 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                    }
                    $find("mdlViewBID").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?txtExmCentreName=" +
                    document.getElementById('<%=txtExmCentre.ClientID %>').value + "&strtxtExmCentreName=" + document.getElementById('<%=txtExmCentre.ClientID %>').id +
                    "&strhdnExmCCode=" + document.getElementById('<%=hdnExmCentreCode.ClientID %>').id + "&ExmMode=" + document.getElementById('<%=ddlExam.ClientID %>').value +
                     "&BizSrc=" + document.getElementById('<%=hdnBizSrc.ClientID %>').value +
                    "&ExmBody=" + document.getElementById('<%=ddlExmBody.ClientID %>').value + "&mdlpopup=mdlViewBID";

                }
            }
        }

        function funOpenPopWinTrnLocation(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "Select") {
                alert("Please Select Training Mode");
                return false;
            }
            else {
                showPopWin(strPageName + "?txtTrnInstName=" + document.getElementById(strTrnInstitute).value +
            "&strtxtTrnInstitute=" + strtxtTrnInstitute +
            "&strhdnTrnInstitute=" + strhdnTrnInstitute + "&Page=TrnLoc&TrnMode=" + document.getElementById('<%=ddlTrnMode.ClientID%>').value + "&TrnInst=" + document.getElementById('<%=hdnTrnInstitute.ClientID%>').value, 750, 350, null);
            }
        }
        function PopWaiver(CscCode) {

            showPopWin("../../../Application/Common/PopWaiverAdvisor.aspx?Code=" + CscCode
                    , 500, 100, null);
        }


        //added by pranjali on 11-04-2014 start
        function ShowReqDtl(divId, btnId) {

            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+'
                //document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }
        //added by pranjali on 11-04-2014 end
        function ShowReqDtlNew(divId, btnId) {
            alert('akshay');
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                //document.getElementById(divId).value = '+'
                document.getElementById(btnId).value = '+';
            }
            else {
                alert('akshay2');
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }
        //        function funShowReqDtl(divId, btnId) {

        //            if (document.getElementById(divId).style.display == "block") {
        //                document.getElementById(divId).style.display = "none";
        //                //document.getElementById(divId).value = '+'
        //                document.getElementById("ctl00_ContentPlaceHolder1_BtnUpload").value = '+';
        //            }
        //            else {
        //                document.getElementById(divId).style.display = "block";
        //                //document.getElementById(btnId).value = '-'
        //                document.getElementById("ctl00_ContentPlaceHolder1_BtnUpload").value = '-';
        //            }
        //        }

        //        function funChkOpnCfr(count) {


        //            if (count > 0) {
        //                var confirmed = confirm('CFR is still open. Do you want to approve?');
        //                if (confirmed == true) {

        //                    document.getElementById("ctl00_ContentPlaceHolder1_hdnflag").value = 1;
        //                    return true;
        //                }
        //            }
        //            else if (count == 0) {
        //                var confirmed = confirm('CFR not raised yet/CFR closed. Do you want to approve?');
        //                if (confirmed == true) {

        //                    document.getElementById("ctl00_ContentPlaceHolder1_hdnflag").value = 1;
        //                    return true;
        //                }
        //            }
        //            else {

        //                document.getElementById("ctl00_ContentPlaceHolder1_hdnflag").value = 0;
        //                return true;
        //            }
        //        }
        //}

        //Added by rachana on 02-01-2014 for confirmation of approval end
        function Closewin() {

            window.close();
        }



        //Added for transfer case start

        function RecursiveEnabled(control) {
            var children = control.childNodes;
            try { control.removeAttribute('disabled') }
            catch (ex) { }
            for (var j = 0; j < children.length; j++) {
                RecursiveEnabled(children[j]);
            }
        }

        //Added for transfer case end
        function PopupModal() {
            //debugger;
            var modal = $find('mdlcfrdtlsID');

            if (modal) {
                if (modal.show) {
                    modal.show();
                }
                else {
                    alert("nope!");
                }
            }
            else {
                throw modal;
            }
        }

        //added by shreela on 12/03/14 for validation on mobile no and email start
        function form2() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            // debugger;
            if ((document.getElementById(strContent + "txtMobileNo").value) == "") {
                alert("Mobile No is mandatory.");
                document.getElementById(strContent + "txtMobileNo").focus();
                return false;
            }
            else {
                //                var Mobile = (document.getElementById('<%= txtMobileNo.ClientID %>').value);
                //                if ((Mobile.substr(0, 1)) != "0") {
                //                    alert("Mobile Number should start with 0");
                //                    document.getElementById(strContent + "txtMobileNo").focus();
                //                    return false;
                //                }
                var Mobile = (document.getElementById('<%= txtMobileNo.ClientID %>').value);
                if (Mobile.length != 10) {
                    alert("Mobile No should be 10 digit.");
                    document.getElementById(strContent + "txtMobileNo").focus();
                    return false;
                }

            }
            return true;
        }

        function validateEmail1() {

            //debugger;
            var Email = (document.getElementById('<%= txtEMail.ClientID %>').value);
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!Email.match(reEmail)) {
                alert("Invalid email address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEMail").focus();
                return false;
            }

            return true;

        }
        //added by shreela on 12/03/14 for validation on mobile no and email end


        //Added by shreela on 8/04/2014 for Renewal start
        function validateRenewal() {
            debugger;
            if (document.getElementById('<%=ddlRenewType.ClientID%>').value == "-Select-") {
                alert("Insurer Type is Mandatory");
                document.getElementById('<%=ddlRenewType.ClientID%>').focus();
                return true;
            }
            else if (document.getElementById('<%=ddllyfTraining.ClientID%>').value == "-Select-") {
                alert("Please select Life Training");
                document.getElementById('<%=ddllyfTraining.ClientID%>').focus();
                return true;
            }
        }
        function ShowReqDtlRenew(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                //document.getElementById(divId).value = '+'
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }
        function AlertMsgs(msgs) {
            alert(msgs);
        }

        //Added by shreela on 8/04/2014 for Renewal end

        //changing color of fees at 2nd Qc
        function btnClick() {
            debugger;
            var x = document.getElementById("tbltest").getElementsByTagName("FeesRow");
            // var y = document.getElementById("tblICMDtls").getElementsByTagName("trTokenwithFees");
            x.style.backgroundColor = "yellow";
            //y.style.backgroundColor = "red";
        }

        //Added by rachana for showinfg loader image on approve,save,submit, reject button start
        function StartProgressBar() {

            var myExtender = $find('ProgressBarModalPopupExtender');
            myExtender.show();

            return true;
        }

        //Added by rachana for showinfg loader image on approve,save,submit, reject button end
        function SpaceTrim(InString) {
            var LoopCtrl = true;
            while (LoopCtrl) {
                if (InString.indexOf("  ") != -1) {
                    Temp = InString.substring(0, InString.indexOf("  "));
                    InString = Temp + InString.substring(InString.indexOf("  ") + 1, InString.length);
                }
                else
                    LoopCtrl = false;
            }
            if (InString.substring(0, 1) == " ")
                InString = InString.substring(1, InString.length);
            if (InString.substring(InString.length - 1) == " ")
                InString = InString.substring(0, InString.length - 1);
            return (InString);
        }
        function FrmToDateValidation(args1, argsID1, args2, argsID2) {
            var Splitargs1 = args1.split("/");
            var Splitargs2 = args2.split("/");
            var BeginMonth = eval(Splitargs1[1]);
            var BeginYear = eval(Splitargs1[2]);
            var EndMonth = eval(Splitargs2[1]);
            var EndYear = eval(Splitargs2[2]);
            var BeginDate = new Date(BeginYear, BeginMonth - 1, 1);
            var EndDate = new Date(EndYear, EndMonth - 1, 1);
            var BeginDate1 = args1;
            var EndDate1 = args2;
            if (BeginMonth != '' && BeginYear != '') {
                if (!validDate(BeginDate1, 'dd/mm/yyyy', 1, 2)) {
                    alert(document.getElementById("<%=hdnID440.ClientID%>").value);
                    document.getElementById(argsID1).focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return 1;
                }
            }

            if (EndMonth != '' && EndYear != '') {
                if (!validDate(EndDate1, 'dd/mm/yyyy', 1, 2)) {
                    alert(document.getElementById("<%=hdnID440.ClientID%>").value);
                    document.getElementById(argsID2).focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return 1;
                }
            }

            return 0;
        }
        function DateValidation(args1, argsID) {
            var Splitargs1 = args1.split("/");
            var BeginMonth = eval(Splitargs1[1]);
            var BeginYear = eval(Splitargs1[2]);
            var RegDate = new Date(args1); //BeginYear,BeginMonth-1,1);
            var BeginDate1 = args1;
            var TodayDate = new Date();

            if (BeginMonth != '' && BeginYear != '') {
                if (!validDate(BeginDate1, 'dd/mm/yyyy', 1, 2)) {
                    alert(document.getElementById("<%=hdnID440.ClientID%>").value);
                    document.getElementById(argsID).focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return 1;
                }
            }
            return 0;
        }
        //Added by rachana for showinfg loader image on approve,save,submit, reject button end
        function funValidateForm2() {
            debugger;
            //Commented by Rahul on 20-04-2015 for change request from client start
            //            if (document.getElementById("ctl00_ContentPlaceHolder1_cboQualCode") != null) {
            //                if (document.getElementById("ctl00_ContentPlaceHolder1_cboQualCode").selectedIndex == 0) {
            //                    alert("Please select Highest Qualification.");
            //                    document.getElementById("ctl00_ContentPlaceHolder1_cboQualCode").focus();
            //                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //                    return false;
            //                }
            //            }
            //            //Validation for Permanent Address State Code
            //            if (SpaceTrim(document.getElementById("<%=txtOccupationCode.ClientID%>").value) == "") {
            //                alert("Please select Occupation.");
            //                document.getElementById("<%=txtOccupationCode.ClientID%>").focus();
            //               // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //                return false;
            //            }

            //            if (SpaceTrim(document.getElementById("<%=txtOccupationCode.ClientID%>").value) != null) {
            //                if (SpaceTrim(document.getElementById("<%=txtOccupationDesc.ClientID%>").value) == "") {
            //                    alert("Please select Occupation.");
            //                    document.getElementById("<%=txtOccupationCode.ClientID%>").focus();
            //                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //                    return false;
            //                }
            //            }
            //Commented by Rahul on 20-04-2015 for change request from client end
            if (SpaceTrim(document.getElementById("<%=txtPrevEmpName1.ClientID%>").value) != "") {
                if (SpaceTrim(document.getElementById('<%=txtfrom1.ClientID %>').value) == "") {
                    alert("Please Enter Employment History From:");
                    document.getElementById('<%=txtfrom1.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById('<%=txtto1.ClientID %>').value) == "") {
                    alert("Please Enter Employment History To:");
                    document.getElementById('<%=txtto1.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp1").value) == "") {
                    alert("Please Enter Address of Employer.");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp1").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }


                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl1").value) == "") {
                    alert("Please Enter Last Position Held");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl1").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome1").value) == "") {
                    alert("Please Enter Annual Income");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome1").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave1").value) == "") {
                    alert("Please Enter Reason Of Leaving");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave1").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //document.getElementById('<%=txtto1.ClientID %>').value

                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom1_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto1_txtDate").value != null )
                if (document.getElementById('<%=txtfrom1.ClientID %>').value != null && document.getElementById('<%=txtfrom1.ClientID %>').value != null) {
                    if (FrmToDateValidation(document.getElementById('<%=txtfrom1.ClientID %>').value, "document.getElementById('<%=txtfrom1.ClientID %>')", document.getElementById('<%=txtfrom1.ClientID %>').value, "document.getElementById('<%=txtfrom1.ClientID %>')") == 1)
                        return false;
                }

                if (SpaceTrim(document.getElementById("<%=txtLastIncome1.ClientID%>").value) != "") {
                    if (!IsNumeric(document.getElementById("<%=txtLastIncome1.ClientID%>").value)) {
                        alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 1");
                        document.getElementById("<%=txtLastIncome1.ClientID%>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }


            } // End if EH-1


            //Validation for Employment History -2 
            if (SpaceTrim(document.getElementById("<%=txtPrevEmpName2.ClientID%>").value) != "") {
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom2_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtfrom2.ClientID %>').value) == "") {
                    alert("Please Enter Employment History From:");
                    document.getElementById('<%=txtfrom2.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById('<%=txtto2.ClientID %>').value) == "") {
                    alert("Please Enter Employment History To:");
                    document.getElementById('<%=txtto2.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp2").value) == "") {
                    alert("Please Enter Address of Employer.");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp2").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }


                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl2").value) == "") {
                    alert("Please Enter Last Position Held");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl2").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome2").value) == "") {
                    alert("Please Enter Annual Income");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome2").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave2").value) == "") {
                    alert("Please Enter Reason Of Leaving");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave2").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom2_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto2_txtDate").value != null )
                if (document.getElementById('<%=txtfrom2.ClientID %>').value != null && document.getElementById('<%=txtto2.ClientID %>').value != null) {
                    if (FrmToDateValidation(document.getElementById('<%=txtfrom2.ClientID %>').value, "document.getElementById('<%=txtfrom2.ClientID %>').value", document.getElementById('<%=txtto2.ClientID %>').value, "document.getElementById('<%=txtto2.ClientID %>')") == 1)
                        return false;
                }

                if (SpaceTrim(document.getElementById("<%=txtLastIncome2.ClientID%>").value) != "") {
                    if (!IsNumeric(document.getElementById("<%=txtLastIncome2.ClientID%>").value)) {
                        alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 2");
                        document.getElementById("<%=txtLastIncome2.ClientID%>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }

            } // End if EH-2


            //Validation for Employment History - 3 
            if (SpaceTrim(document.getElementById("<%=txtPrevEmpName3.ClientID%>").value) != "") {
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom3_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtfrom3.ClientID%>').value) == "") {
                    alert("Please Enter Employment History From:");
                    document.getElementById('<%=txtfrom3.ClientID%>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById('<%=txtto3.ClientID%>').value) == "") {
                    alert("Please Enter Employment History To:");
                    document.getElementById('<%=txtto3.ClientID%>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp3").value) == "") {
                    alert("Please Enter Address of Employer.");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp3").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }


                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl3").value) == "") {
                    alert("Please Enter Last Position Held");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl3").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome3").value) == "") {
                    alert("Please Enter Annual Income");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome3").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave3").value) == "") {
                    alert("Please Enter Reason Of Leaving");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave3").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom3_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto3_txtDate").value != null )
                if (document.getElementById('<%=txtfrom3.ClientID%>').value != null && document.getElementById('<%=txtto3.ClientID%>').value != null) {
                    //if (FrmToDateValidation(document.getElementById("<%= txtfrom3.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtfrom3_txtDate",document.getElementById("<%= txtto3.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtto3_txtDate") == 1)
                    if (FrmToDateValidation(document.getElementById('<%=txtfrom3.ClientID%>').value, "document.getElementById('<%=txtfrom3.ClientID%>')", document.getElementById('<%=txtto3.ClientID%>').value, "document.getElementById('<%=txtto3.ClientID%>')") == 1)
                        return false;
                }

                if (SpaceTrim(document.getElementById("<%=txtLastIncome3.ClientID%>").value) != "") {
                    if (!IsNumeric(document.getElementById("<%=txtLastIncome3.ClientID%>").value)) {
                        alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 3");
                        document.getElementById("<%=txtLastIncome3.ClientID%>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }

            } // End if EH-3

            //Validation for Employment History - 4 
            if (SpaceTrim(document.getElementById("<%=txtPrevEmpName4.ClientID%>").value) != "") {
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom4_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtfrom4.ClientID %>').value) == "") {
                    alert("Please Enter Employment History From:");
                    document.getElementById('<%=txtfrom4.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById('<%=txtto4.ClientID %>').value) == "") {
                    alert("Please Enter Employment History To:");
                    document.getElementById('<%=txtto4.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp4").value) == "") {
                    alert("Please Enter Address of Employer.");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp4").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }


                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl4").value) == "") {
                    alert("Please Enter Last Position Held");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl4").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome4").value) == "") {
                    alert("Please Enter Annual Income");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome4").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave4").value) == "") {
                    alert("Please Enter Reason Of Leaving");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave4").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom4_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto4_txtDate").value != null )
                if (document.getElementById('<%=txtfrom4.ClientID %>').value != null && document.getElementById('<%=txtto4.ClientID %>').value != null) {
                    //if (FrmToDateValidation(document.getElementById("<%= txtfrom4.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtfrom4_txtDate",document.getElementById("<%= txtto4.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtto4_txtDate") == 1)
                    if (FrmToDateValidation(document.getElementById('<%=txtfrom4.ClientID %>').value, "document.getElementById('<%=txtfrom4.ClientID %>')", document.getElementById('<%=txtto4.ClientID %>').value, "document.getElementById('<%=txtto4.ClientID %>')") == 1)
                        return false;
                }

                if (SpaceTrim(document.getElementById("<%=txtLastIncome4.ClientID%>").value) != "") {
                    if (!IsNumeric(document.getElementById("<%=txtLastIncome4.ClientID%>").value)) {
                        alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 4");
                        document.getElementById("<%=txtLastIncome4.ClientID%>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }

            } // End if EH-4

            //Validation for Employment History - 5 
            if (SpaceTrim(document.getElementById("<%=txtPrevEmpName5.ClientID%>").value) != "") {
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom5_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtfrom5.ClientID %>').value) == "") {
                    alert("Please Enter Employment History From:");
                    document.getElementById('<%=txtfrom5.ClientID %>').value.focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById('<%=txtto5.ClientID %>').value) == "") {
                    alert("Please Enter Employment History To:");
                    document.getElementById('<%=txtto5.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp5").value) == "") {
                    alert("Please Enter Address of Employer.");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp5").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }


                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl5").value) == "") {
                    alert("Please Enter Last Position Held");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl5").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome5").value) == "") {
                    alert("Please Enter Annual Income");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome5").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave5").value) == "") {
                    alert("Please Enter Reason Of Leaving");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave5").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                // if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom5_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto5_txtDate").value != null )
                if (document.getElementById('<%=txtfrom5.ClientID %>').value != null && document.getElementById('<%=txtto5.ClientID %>').value != null) {
                    //if (FrmToDateValidation(document.getElementById("<%= txtfrom5.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtfrom5_txtDate",document.getElementById("<%= txtto5.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtto5_txtDate") == 1)
                    if (FrmToDateValidation(document.getElementById('<%=txtfrom5.ClientID %>').value, "document.getElementById('<%=txtfrom5.ClientID %>')", document.getElementById('<%=txtto5.ClientID %>').value, "document.getElementById('<%=txtto5.ClientID %>')") == 1)
                        return false;
                }

                if (SpaceTrim(document.getElementById("<%=txtLastIncome5.ClientID%>").value) != "") {
                    if (!IsNumeric(document.getElementById("<%=txtLastIncome5.ClientID%>").value)) {
                        alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 5");
                        document.getElementById("<%=txtLastIncome5.ClientID%>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }

            } // End if EH-5
            if (document.getElementById("<%=txtfrom1.ClientID%>").value != "" || document.getElementById("<%=txtto1.ClientID%>").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp1").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl1").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome1").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave1").value != "") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName1").value) == "") {
                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 1");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName1").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for Employment History Name 2 if(document.getElementById('<%=txtfrom2.ClientID %>').value != null && document.getElementById('<%=txtto2.ClientID %>').value != null )
            if (document.getElementById('<%=txtfrom2.ClientID %>').value != "" || document.getElementById('<%=txtto2.ClientID %>').value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp2").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl2").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome2").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave2").value != "") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName2").value) == "") {
                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 2");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName2").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for Employment History Name 3
            if (document.getElementById('<%=txtfrom3.ClientID %>').value != "" || document.getElementById('<%=txtto3.ClientID %>').value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp3").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl3").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome3").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave3").value != "") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName3").value) == "") {
                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 3");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName3").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for Employment History Name 4
            if (document.getElementById('<%=txtfrom4.ClientID %>').value != "" || document.getElementById('<%=txtto4.ClientID %>').value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp4").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl4").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome4").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave4").value != "") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName4").value) == "") {
                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 4");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName4").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for Employment History Name 5
            if (document.getElementById('<%=txtfrom5.ClientID %>').value != "" || document.getElementById('<%=txtto5.ClientID %>').value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp5").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl5").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome5").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave5").value != "") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName5").value) == "") {
                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 5");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName5").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if ((eval(document.getElementById("ctl00_ContentPlaceHolder1_rbotherexp_0").checked) == false) && (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbotherexp_1").checked) == false)) {
                alert(document.getElementById("<%=hdnID380.ClientID%>").value);
                document.getElementById("ctl00_ContentPlaceHolder1_rbotherexp_0").focus();
               // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbotherexp_0").checked) == true) {
                if (SpaceTrim(document.getElementById("<%=txtemprecordname1.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID420.ClientID%>").value);
                    document.getElementById("<%=txtemprecordname1.ClientID%>").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for Other Exp - 1
            if (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbotherexp_0").checked) == true) {
                if (SpaceTrim(document.getElementById("<%=txtemprecordname1.ClientID%>").value) != "") {
                    if (SpaceTrim(document.getElementById('<%=txtotherexpfrom1.ClientID %>').value) == "") {
                        alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 1");
                        document.getElementById('<%=txtotherexpfrom1.ClientID %>').focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (SpaceTrim(document.getElementById('<%=txtotherexpTo1.ClientID %>').value) == "") {
                        alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 1");
                        document.getElementById('<%=txtotherexpTo1.ClientID %>').focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (SpaceTrim(document.getElementById("<%= txtemprecordjobnature1.ClientID %>").value) == "") {
                        alert('Please enter job nature.');
                        document.getElementById("<%= txtemprecordjobnature1.ClientID %>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    if (SpaceTrim(document.getElementById("<%=txtemprecordfield1.ClientID%>").value) == "") {
                        alert('Please enter field details.');
                        document.getElementById("<%=txtemprecordfield1.ClientID %>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    //if (document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom1_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo1_txtDate").value != null) 
                    if (document.getElementById('<%=txtotherexpfrom1.ClientID %>').value != null && document.getElementById('<%=txtotherexpTo1.ClientID %>').value != null) {
                        //  if (FrmToDateValidation(document.getElementById("<%= txtotherexpfrom1.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpfrom1_txtDate", document.getElementById("<%= txtotherexpTo1.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpTo1_txtDate") == 1)
                        if (FrmToDateValidation(document.getElementById('<%=txtotherexpfrom1.ClientID %>').value, "document.getElementById('<%=txtotherexpfrom1.ClientID %>')", document.getElementById('<%=txtotherexpTo1.ClientID %>').value, "document.getElementById('<%=txtotherexpTo1.ClientID %>')") == 1)
                            return false;
                    }


                } // End if Other Exp-1

                //Validation for Other Exp - 2
                if (SpaceTrim(document.getElementById("<%=txtemprecordname2.ClientID%>").value) != "") {

                    //if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom2_txtDate").value) == "") {
                    if (SpaceTrim(document.getElementById('<%=txtotherexpfrom2.ClientID %>').value) == "") {
                        alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 2");
                        document.getElementById('<%=txtotherexpfrom2.ClientID %>').focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (SpaceTrim(document.getElementById('<%=txtotherexpTo2.ClientID %>').value) == "") {
                        alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 2");
                        document.getElementById('<%=txtotherexpTo2.ClientID %>').focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    //validation for job nature and record field
                    if (SpaceTrim(document.getElementById("<%=txtemprecordjobnature2.ClientID%>").value) == "") {
                        alert('Please enter job nature.');
                        document.getElementById("<%=txtemprecordjobnature2.ClientID%>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    if (SpaceTrim(document.getElementById("<%=txtemprecordfield2.ClientID%>").value) == "") {
                        alert('Please enter field details.');
                        document.getElementById("<%=txtemprecordfield2.ClientID%>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    //if (document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom2_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo2_txtDate").value != null) 
                    if (document.getElementById('<%=txtotherexpfrom2.ClientID %>').value != null && document.getElementById('<%=txtotherexpTo2.ClientID %>').value != null) {
                        //if (FrmToDateValidation(document.getElementById("<%= txtotherexpfrom2.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpfrom2_txtDate", document.getElementById("<%= txtotherexpTo2.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpTo2_txtDate") == 1)
                        if (FrmToDateValidation(document.getElementById('<%=txtotherexpfrom2.ClientID %>').value, "document.getElementById('<%=txtotherexpfrom2.ClientID %>')", document.getElementById('<%=txtotherexpTo2.ClientID %>').value, "document.getElementById('<%=txtotherexpTo2.ClientID %>')") == 1)
                            return false;
                    }
                } // End if Other Exp-2


                //Validation for Other Exp - 3
                if (SpaceTrim(document.getElementById("<%=txtemprecordname3.ClientID%>").value) != "") {

                    //if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom3_txtDate").value) == "") {
                    if (SpaceTrim(document.getElementById('<%=txtotherexpfrom3.ClientID %>').value) == "") {
                        alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 3");
                        document.getElementById('<%=txtotherexpfrom3.ClientID %>').focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (SpaceTrim(document.getElementById('<%=txtotherexpTo3.ClientID %>').value) == "") {
                        alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 3");
                        document.getElementById('<%=txtotherexpTo3.ClientID %>').focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (SpaceTrim(document.getElementById("<%=txtemprecordjobnature3.ClientID%>").value) == "") {
                        alert('Please enter job nature.');
                        document.getElementById("<%=txtemprecordjobnature3.ClientID%>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    if (SpaceTrim(document.getElementById("<%=txtemprecordfield3.ClientID%>").value) == "") {
                        alert('Please enter job field details.');
                        document.getElementById("<%=txtemprecordfield3.ClientID%>").focus();
                       // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (document.getElementById('<%=txtotherexpfrom3.ClientID %>').value != null && document.getElementById('<%=txtotherexpTo3.ClientID %>').value != null) {
                        //    if (FrmToDateValidation(document.getElementById("<%= txtotherexpfrom3.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpfrom3_txtDate", document.getElementById("<%= txtotherexpTo3.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpTo3_txtDate") == 1)
                        if (FrmToDateValidation(document.getElementById('<%=txtotherexpfrom3.ClientID %>').value, "document.getElementById('<%=txtotherexpfrom3.ClientID %>')", document.getElementById('<%=txtotherexpTo3.ClientID %>').value, "document.getElementById('<%=txtotherexpTo3.ClientID %>')") == 1)
                            return false;
                    }

                } // End if Other Exp-3
            }

            //Validation for Details of Insurance Agency
            if (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbinsagency_0").checked) == true) {
                if (SpaceTrim(document.getElementById("<%=txtInsCompName.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID420.ClientID%>").value);
                    document.getElementById("<%=txtInsCompName.ClientID%>").focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtdateofissue_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtdateofissue.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID320.ClientID%>").value);
                    document.getElementById('<%=txtdateofissue.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById('<%=txtvaliddate.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID330.ClientID%>").value);
                    document.getElementById('<%=txtvaliddate.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById('<%=txtterminatedate.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID340.ClientID%>").value);
                    document.getElementById('<%=txtterminatedate.ClientID %>').focus();
                   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            } // End if Insurance Agency

            if (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbinsagency_0").checked) == true) {
                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtdateofissue_txtDate").value != null)
                if (document.getElementById('<%=txtdateofissue.ClientID %>').value != null) {

                    //if (DateValidation(document.getElementById("<%= txtdateofissue.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtdateofissue_txtDate") == 1)
                    if (DateValidation(document.getElementById('<%=txtdateofissue.ClientID %>').value, "document.getElementById('<%=txtdateofissue.ClientID %>')") == 1)
                        return false;
                }
                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtvaliddate_txtDate").value != null)
                if (document.getElementById('<%=txtvaliddate.ClientID %>').value != null) {
                    //if (DateValidation(document.getElementById("<%= txtvaliddate.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtvaliddate_txtDate") == 1)
                    if (DateValidation(document.getElementById('<%=txtvaliddate.ClientID %>').value, "document.getElementById('<%=txtvaliddate.ClientID %>')") == 1)
                        return false;
                }
                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtterminatedate_txtDate").value != null)
                if (document.getElementById('<%=txtterminatedate.ClientID %>').value != null) {
                    //if (DateValidation(document.getElementById("<%=txtterminatedate.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtterminatedate_txtDate") == 1)
                    if (DateValidation(document.getElementById('<%=txtterminatedate.ClientID %>').value, "document.getElementById('<%=txtterminatedate.ClientID %>')") == 1)
                        return false;
                }
            }
        }

        //Added by Rahul on 27-04-2015 for Address update start
       
        function funcShowPopup(strPopUpType) {
            debugger;

            if (strPopUpType == "statedemo") 
            {
                debugger;
                if (document.getElementById('<%=ddlstate1.ClientID %>').value == "Select") 
                {
                    alert("Please select State.");
                    document.getElementById('<%= ddlstate1.ClientID %>').focus();
                    return false;
                }
                else
                 {
                    $find("mdlViewBID").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopAgtCnct.aspx?Code=" + document.getElementById('<%=ddlstate1.ClientID %>').value
         + "&field1=" + document.getElementById('<%=txtPermPostcode.ClientID %>').id + "&field2=" + document.getElementById('<%=txtPDistrict.ClientID %>').id
         + "&field3=" + document.getElementById('<%=txtPcity1.ClientID %>').id + "&field4=" + document.getElementById('<%=txtParea1.ClientID %>').id
         + "&field11=" + document.getElementById('<%=hdnPermPin.ClientID %>').id + "&field21=" + document.getElementById('<%=hdnpermDist.ClientID %>').id
         + "&field31=" + document.getElementById('<%=hdnPermCity1.ClientID %>').id + "&field41=" + document.getElementById('<%=hdnpermArea1.ClientID %>').id
         
         + "&mdlpopup=mdlViewBID";
                }
            }

        }
      
        //Added by Rahul on 27-04-2015 for Address update end
    </script>
</asp:Content>

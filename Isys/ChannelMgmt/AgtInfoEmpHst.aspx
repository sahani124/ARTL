<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgtInfoEmpHst.aspx.cs" Inherits="Application_ISys_ChannelMgmt_AgtInfoEmpHst"
    MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" /><link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
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
             function popup() {
                 $("#myModal").modal();
             }


             function ShowReqDtl(divName, btnName) {
                 //debugger;
                 var objnewdiv = document.getElementById(divName);
                 var objnewbtn = document.getElementById(btnName);

                 if (objnewdiv.style.display == "block") {
                     objnewdiv.style.display = "none";
                     //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                 }
                 else {
                     objnewdiv.style.display = "block";
                    // objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
                 }
             }


             function ShowReqDtl1(divName, btnName) {
                 //debugger;
                 var objnewdiv = document.getElementById(divName);
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
         </script>
    <asp:ScriptManager runat="server" ID="ScriptManager1">
    </asp:ScriptManager>
    <div>
       <%-- <table width="95%" style="border-collapse: collapse; background-image: url(Images\background.jpg);
            height: 18px;">--%>
            <tr>
                <td>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <div id="demo1" class="row"  runat="server" style="text-align: left; margin-left: 20px">
                    <asp:ImageButton ID="lnkPage1" runat="server" OnClick="lnkPage1_Click" CssClass="TextBox" Visible="false"
                        BackColor="transparent" ImageUrl="~/theme/iflow/tabs/Agent2.png" />
                    <asp:ImageButton ID="lnkPage2" runat="server" OnClick="lnkPage2_Click" CssClass="TextBox" Visible="false"
                        BackColor="Transparent" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/Education2.png" />
                    <asp:ImageButton ID="lnkPage3" runat="server" OnClick="lnkPage3_Click" CssClass="TextBox" Visible="false"
                        BackColor="Transparent" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/EmpHst1.png" />
                    <asp:ImageButton ID="lnkPage4" runat="server" OnClick="lnkPage4_Click" CssClass="TextBox" Visible="false"
                        BackColor="Transparent" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/Disp2.png" />
                    <asp:ImageButton ID="lnkPage5" runat="server" OnClick="lnkPage5_Click" CssClass="TextBox" Visible="false"
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
                     <asp:Label ID="lblVw3AgntInfo" runat="server"  CssClass="control-label" Font-Size="19px"></asp:Label>
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
                                <asp:Label ID="lblVw3AgntCodeDisp" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                        </div>
                         <div class="col-md-3">
                                <asp:TextBox ID="lblVw3AgntCode" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                    </div>
                       <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblchnl" runat="server" CssClass="control-label" Font-Bold="False" Text="Hierarchy Name"></asp:Label>
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
                                <asp:Label ID="lblsubchnlval" CssClass="form-control"   Enabled="false" runat="server"></asp:Label>
                      </div>
                         <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblVw3AgntTypeDisp" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                        </div>
                         <div class="col-md-3">
                                <asp:Label ID="lblVw3AgntType" CssClass="form-control"   Enabled="false" runat="server"></asp:Label>
                     </div>
                    </div>
                 <div class="row" style="margin-bottom:5px;">
                    <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblVw3AgntNameDisp" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                 </div>
                     <div class="col-md-3">
                                <asp:Label ID="lblVw3AgntName" CssClass="form-control"   Enabled="false" runat="server"></asp:Label>
                       </div>
                       <div class="col-md-3" style="text-align:left">
                                <asp:Label ID="lblVw3AgntGenderDisp" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                         </div>
                        <div class="col-md-3">
                                <asp:Label ID="lblVw3AgntGender" CssClass="form-control"   Enabled="false" runat="server"></asp:Label>
                       </div>
                  </div>
                        </div>
                        </div>
           <div class="panel" >
                            <div id="Div9" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divEmpHist','btnEmpHist');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblEmpHistory" runat="server"  CssClass="control-label" Font-Size="19px"></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnEmpHist" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                    <div id="divEmpHist" runat="server" class="panel-body" style="display:block"> 
                           <div class="panel"  runat="server">
                                 <div id="div2" runat="server" class="panel-heading subheader"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divEmp1','btnEmp1');return false;"
                    style="background-color:White !important">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                    <asp:Label Text="Employer1" runat="server"  
                                 ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnEmp1" class="glyphicon glyphicon-resize-full" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>
                 <div id="divEmp1" runat="server" class="panel-body" style="display:block"> 
                        <div class="row" style="margin-bottom:5px;">
                        <div class="col-md-3" style="text-align:left">
                                    <span style="color: #ff0000">
                                        <asp:Label ID="lblPrevEmp1" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label></span>
                           </div>
                         <div class="col-md-3">
                                    <asp:TextBox ID="txtPrevEmpName1" runat="server" CssClass="form-control" 
                                        MaxLength="50"></asp:TextBox>
                         </div>
                                     <div class="col-md-6" style="text-align:left">
                                        <span style="color: #ff0000">
                                    <asp:Label ID="lblForInsSlsBack1" runat="server" Font-Bold="False"></asp:Label></span>
                              </div>
                          </div>
                       <div class="row" style="margin-bottom:5px;">
                             <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblDurOfService1" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                           </div>
                                <div class="col-md-3" style="display: flex">
                                    <asp:Label ID="lblVw3From1" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label><span style="padding-left: 3px;"></span><%--Added:Parag--%><asp:DropDownList
                                        ID="ddlVw3FromMnth1" runat="server" CssClass="form-control"  >
                                    </asp:DropDownList>
                                    /<asp:TextBox ID="txtVw3FromYear1" runat="server" CssClass="form-control"  
                                        MaxLength="4"></asp:TextBox>
                             </div>
                               <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblAgntLvlAchieve1" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                          </div>
                                   <div class="col-md-3">
                                    <asp:DropDownList ID="ddlAgntLvlAchieve1" runat="server" CssClass="form-control"  >
                                    </asp:DropDownList>
                              </div>
                    </div>
                           <div class="row" style="margin-bottom:5px;">
                              <div class="col-md-3" style="text-align:left">
                              </div>
                                <div class="col-md-3" style="display: flex">
                                    <asp:Label ID="lblVw3To1" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label><span style="padding-left: 12px;"></span><%--Added:Parag--%>
                                    <asp:DropDownList ID="ddlVw3ToMnth1" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    /<asp:TextBox ID="txtVw3ToYear1" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                                </div>
                                <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblEmpStatus1" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                            </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlEmpStatus1" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                         </div>
                         <div class="row" style="margin-bottom:5px;">
                            <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblWorkIndustry1" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                              </div>
                           <div class="col-md-3">
                                    <asp:DropDownList ID="ddlWorkIndustry1" runat="server" CssClass="form-control"  >
                                    </asp:DropDownList>
                            </div>
                              <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblPrevAgntCode1" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                              </div>
                              <div class="col-md-3">
                                    <asp:TextBox ID="txtPrevAgntCode1" runat="server" CssClass="form-control"   MaxLength="10"
                                       ></asp:TextBox>
                        </div>
                         </div>
                                <div class="row" style="margin-bottom:5px;">
                              <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblEmpLvl1" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                             </div>
                               <div class="col-md-3">
                                    <asp:DropDownList ID="ddlEmpLvl1" runat="server" CssClass="form-control" >
                                    </asp:DropDownList>
                              </div>
                              <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblQualID1" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                              </div>
                               <div class="col-md-3">
                                    <asp:TextBox ID="txtQualID1" runat="server" CssClass="form-control"  MaxLength="10" ></asp:TextBox>
                              </div>
                          </div>
                             <div class="row" style="margin-bottom:5px;">
                               <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblLastIncome1" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                               </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtLastIncome1" runat="server" CssClass="form-control" MaxLength="8"
                                      ></asp:TextBox>
                               </div>
                                     <div class="col-md-3">
                                     </div>
                                           <div class="col-md-3">
                                           </div>
                           </div>
                            </div>
                            </div>
                              <div class="panel" id="div3" runat="server">
                                    <div id="div6" runat="server" class="panel-heading subheader"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divEmp2','btnEmp2');return false;"
                    style="background-color:White !important">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                    <asp:Label Text="Employer2" runat="server"  
                                 ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnEmp2" class="glyphicon glyphicon-resize-full" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>
                     <div id="divEmp2" runat="server" class="panel-body" style="display:block"> 
                          <div class="row" style="margin-bottom:5px;">
                             <div class="col-md-3" style="text-align:left">
                                    <span style="color: #ff0000">
                                        <asp:Label ID="lblPrevEmp2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label></span>
                               </div>
                               <div class="col-md-3">
                                    <asp:TextBox ID="txtPrevEmpName2" runat="server" CssClass="form-control" 
                                        MaxLength="50"></asp:TextBox>
                               </div>
                               <div class="col-md-6" style="text-align:left">
                                 <span style="color: #ff0000">
                                    <asp:Label ID="lblForInsSlsBack2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label></span>
                                </div>
                          </div>
                                 <div class="row" style="margin-bottom:5px;">
                              <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblDurOfService2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                              </div>
                             <div class="col-md-3" style="display: flex">
                                    <asp:Label ID="lblVw3From2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label><span style="padding-left: 3px;"></span><%--Added:Parag--%>
                                    <asp:DropDownList ID="ddlVw3FromMnth2" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    /<asp:TextBox ID="txtVw3FromYear2" runat="server" CssClass="form-control"
                                        MaxLength="4"></asp:TextBox>
                                </div>
                              <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblAgntLvlAchieve2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                            </div>
                                  <div class="col-md-3">
                                    <asp:DropDownList ID="ddlAgntLvlAchieve2" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                             </div>
                       </div>
                         <div class="row" style="margin-bottom:5px;">
                             <div class="col-md-3" style="text-align:left">
                             </div>
                              <div class="col-md-3" style="display: flex">
                                    <asp:Label ID="lblVw3To2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label><span style="padding-left: 12px;"></span><%--Added:Parag--%>
                                    <asp:DropDownList ID="ddlVw3ToMnth2" runat="server" CssClass="form-control"  >
                                    </asp:DropDownList>
                                    /<asp:TextBox ID="txtVw3ToYear2" runat="server" CssClass="form-control"   MaxLength="4"></asp:TextBox>
                               </div>
                              <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblEmpStatus2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                             </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlEmpStatus2" runat="server" CssClass="form-control"  >
                                    </asp:DropDownList>
                                </div>
                           </div>
                          <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblWorkIndustry2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                            </div>
                         <div class="col-md-3">
                                    <asp:DropDownList ID="ddlWorkIndustry2" runat="server" CssClass="form-control" >
                                    </asp:DropDownList>
                          </div>
                                 <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblPrevAgntCode2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                               </div>
                          <div class="col-md-3">
                                    <asp:TextBox ID="txtPrevAgntCode2" runat="server" CssClass="form-control"  MaxLength="10"
                                       ></asp:TextBox>
                            </div>
                         </div>
                         <div class="row" style="margin-bottom:5px;">
                          <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblEmpLvl2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                           </div>
                           <div class="col-md-3">
                                    <asp:DropDownList ID="ddlEmpLvl2" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                          </div>
                          <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblQualID2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                           </div>
                         <div class="col-md-3">
                                    <asp:TextBox ID="txtQualID2" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                        </div>
                          </div>
                         <div class="row" style="margin-bottom:5px;">
                      <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblLastIncome2" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                       </div>
                              <div class="col-md-3">
                                    <asp:TextBox ID="txtLastIncome2" runat="server" CssClass="form-control"  MaxLength="8"
                                        ></asp:TextBox>
                            </div>
                               <div class="col-md-3">
                               </div>
                                  <div class="col-md-3">
                                  </div>
                           </div>
                            </div>
                            </div>
                              <div class="panel" id="div5" runat="server">
                                <div id="div7" runat="server" class="panel-heading subheader"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divEmp3','btnEmp3');return false;"
                    style="background-color:White !important">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                    <asp:Label ID="Label1" Text="Employer3" runat="server"  
                                 ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnEmp3" class="glyphicon glyphicon-resize-full" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>
                   <div id="divEmp3" runat="server" class="panel-body" style="display:block"> 
                              <div class="row" style="margin-bottom:5px;">
                              <div class="col-md-3" style="text-align:left">
                                    <span style="color: #ff0000">
                                        <asp:Label ID="lblPrevEmp3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label></span>
                             </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtPrevEmpName3" runat="server" CssClass="form-control"
                                        MaxLength="50"></asp:TextBox>
                               </div>
                                 <div class="col-md-6" style="text-align:left">
                                   <span style="color: #ff0000">
                                    <asp:Label ID="lblForInsSlsBack3" runat="server" Font-Bold="False"></asp:Label></span>
                             </div>
                        </div>
                               <div class="row" style="margin-bottom:5px;">
                              <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblDurOfService3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                               </div>
                              <div class="col-md-3" style="display: flex">
                                    <asp:Label ID="lblVw3From3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label><span style="padding-left: 3px;"></span><%--Added:Parag--%>
                                    <asp:DropDownList ID="ddlVw3FromMnth3" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    /<asp:TextBox ID="txtVw3FromYear3" runat="server" CssClass="form-control"
                                        MaxLength="4"></asp:TextBox>
                             </div>
                             <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblAgntLvlAchieve3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                          </div>
                              <div class="col-md-3">
                                    <asp:DropDownList ID="ddlAgntLvlAchieve3" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                         </div>
                         </div>
                          <div class="row" style="margin-bottom:5px;">
                                 <div class="col-md-3">
                                 </div>
                              <div class="col-md-3" style="display: flex">
                                    <asp:Label ID="lblVw3To3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label><span style="padding-left: 12px;"></span><%--Added:Parag--%>
                                    <asp:DropDownList ID="ddlVw3ToMnth3" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    /<asp:TextBox ID="txtVw3ToYear3" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                            </div>
                             <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblEmpStatus3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                               </div>
                             <div class="col-md-3">
                                    <asp:DropDownList ID="ddlEmpStatus3" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                           </div>
                            </div>
                        <div class="row" style="margin-bottom:5px;">
                             <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblWorkIndustry3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                           </div>
                              <div class="col-md-3">
                                    <asp:DropDownList ID="ddlWorkIndustry3" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                              </div>
                              <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblPrevAgntCode3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                              </div>
                            <div class="col-md-3">
                                    <asp:TextBox ID="txtPrevAgntCode3" runat="server" CssClass="form-control" MaxLength="10"
                                        ></asp:TextBox>
                             </div>
                           </div>
                         <div class="row" style="margin-bottom:5px;">
                           <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblEmpLvl3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                             </div>
                          <div class="col-md-3">
                                    <asp:DropDownList ID="ddlEmpLvl3" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                           </div>
                             <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblQualID3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                           </div>
                             <div class="col-md-3">
                                    <asp:TextBox ID="txtQualID3" runat="server" CssClass="form-control" MaxLength="10" ></asp:TextBox>
                             </div>
                          </div>
                            <div class="row" style="margin-bottom:5px;">
                             <div class="col-md-3" style="text-align:left">
                                    <asp:Label ID="lblLastIncome3" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                            </div>
                             <div class="col-md-3">
                                    <asp:TextBox ID="txtLastIncome3" runat="server" CssClass="form-control" MaxLength="8"
                                        ></asp:TextBox>
                             </div>
                              <div class="col-md-3">
                              </div>
                               <div class="col-md-3">
                               </div>
                          </div>
                            </div>
                        </div>
                        </div>
                    </div>
               
            <div class="row">
                <div class="col-md-12" style="text-align:center">
                 <%--   <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="standardbutton"
                        OnClick="btnUpdate_Click" />--%>
                          <asp:LinkButton ID="btnUpdate" runat="server"  CssClass="btn btn-sample" Text="Update"
                          OnClick="btnUpdate_Click" >
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Update
                                  </asp:LinkButton>
                 <%--   <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="standardbutton"
                        CausesValidation="False" />--%>
                        <asp:LinkButton ID="btnCancel" runat="server"  CssClass="btn btn-sample" Text="Cancel" CausesValidation="False"
                         >
                                  <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                                  </asp:LinkButton>
                </div>
           </div>
       <%-- </table>--%>
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

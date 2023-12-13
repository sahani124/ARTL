
<%@ Page Language="C#"  MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="ClientCreation.aspx.cs" Inherits="Application_Isys_Recruit_ClientCreation" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
   

    <script type="text/javascript">

        function doCancel() {
          
            window.location = "ClientAgentSearch.aspx?ID=CC";
        }

        function popup() {
            debugger;
           // alert("hi");
            $("#myModal").modal();
        }

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

    </script>
    <div class="panel panel-success">
                <div id="Div2" runat="server" class="panel-heading"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnpersnl');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="lblpfPersonal" Text="Personal Client New" runat="server" CssClass="control-label" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                <div id="divSearch" runat="server" style="display:block;" class="panel-body">
              
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblcstemrid" runat="server" Text ="Customer ID" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                           
                               
                                         <div  style="display:flex;">
                                             <asp:TextBox ID="txtcstmrid"  Enabled ="false" runat="server" CssClass="form-control" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"
                                               style='width:98%;'  TabIndex="1"></asp:TextBox>&nbsp;
                                            
                                           
                                                  <asp:Label ID="Label2" runat="server" Text ="Active" Font-Bold="false" CssClass="control-label"
                                             Font-Size="medium"></asp:Label>
                                           </div> 
                                       
                                       
                                       
                                   
                               
                                 <i class="fa fa-hand-o-right"></i>
          
                             </div>

                       
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblClientcode" runat="server" Text="Client Code" CssClass="control-label"></asp:Label>
                            <span style="color: red">*</span>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtClientcode" runat="server" CssClass="form-control" 
                                Enabled="False" MaxLength="20" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblpfGivenName" runat="server" Text ="Given Name" CssClass="control-label"></asp:Label>
                            <span style="color: #ff0000;">*</span>
                        </div>
                        <div class="col-sm-3">

                            <div  style="display:flex;">
                             
                                    <asp:DropDownList ID="cboTitle" Enabled ="false" runat="server" CssClass="form-control" DataTextField="ParamDesc"
                                       DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="dscbotitle" 
                                  width="30%" 
                                        TabIndex="7">
                                    </asp:DropDownList>
                             
                              
                              
                                <asp:TextBox ID="txtpfGivenName" Enabled ="false" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                  MaxLength="30" TabIndex="8" onblur="CheckSpaces();"></asp:TextBox>
                               
                            </div>
                             <asp:SqlDataSource ID="dscbotitle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                                         </asp:SqlDataSource>
                                                         
                            <asp:HiddenField ID="hdnGenderTitle1" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdnGenderTitle2" runat="server"></asp:HiddenField>
                        </div>
                    <div class="col-sm-3" style="text-align: left">
                      
                            <asp:Label ID="lblpfSurname" runat="server" Text ="Surname" CssClass="control-label"></asp:Label> <span style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtpfSurname" Enabled ="false" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                            CssClass="form-control" MaxLength="30" TabIndex="9"></asp:TextBox>
                       
                    </div>
                </div>
                 <%--   amruta end--%>
                        
                <div class="row">


                 <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblpfDOB" Text ="Date Of Birth" runat="server" CssClass="control-label"></asp:Label>
                        <span><font color="red">*</font> </span>
                    </div>
                    <div class="col-sm-3">
                      
                    
                        <asp:TextBox CssClass="form-control" onmousedown="$('#txtDob').datepicker({ changeMonth: true, changeYear: true });"
                            onchange="setDateFormat('txtDob')" Enabled ="false" runat="server" ID="txtDOB" MaxLength="15"
                            TabIndex="12" />
                         
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblpfFatherName" runat="server" Text="Father Name" CssClass="control-label"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtFatherName" Enabled ="false" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                             MaxLength="60" TabIndex="10" onblur="AllowSpace();return false;"></asp:TextBox>
                       
                    </div>
                   
                </div>
               
                  <div class="row">
                           <div class="col-sm-3" style="text-align:left">

                                    <asp:Label ID="lblpan" runat="server" Text ="Pan"  CssClass="control-label"></asp:Label>
                                                                    <span style="color: red">*</span>
                        </div>
                           <div class="col-sm-3">
                           
                                
                                         <div  style="display:flex;">
                                             <asp:TextBox ID="txtpan" Enabled ="false"   runat="server" CssClass="form-control" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"
                                               style='width:98%;'  TabIndex="1"></asp:TextBox>&nbsp;
                                            
                                           
                                                  </div> 
                                       
                                      
                                    
                                 </div>
                                        
                           <div class="col-sm-3" style="text-align:left">
                               
                                    <asp:Label ID="lblRule" runat="server"  Text ="Client Create Rule"  CssClass="control-label"></asp:Label>
                                    
                        </div>
                           <div class="col-sm-3" >
                                <asp:DropDownList ID="ddlRule" Enabled ="false" runat="server" CssClass="form-control" >
                                    
                                </asp:DropDownList>
                      </div>
                   </div>
                  <div class="row">
                   
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblpfGender" CssClass="control-label" Text ="Gender" runat="server"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="cboGender" Enabled ="false" CssClass="form-control" runat="server" 
                            TabIndex="13">
                        </asp:DropDownList>
                    </div>

                    
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Lblspind" text="Special Indicator" CssClass="control-label" runat="server"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="ddllspind" CssClass="form-control" runat="server" 
                            TabIndex="13">  
                             <asp:ListItem  Value ="Select"  Enabled="false"> </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="row">
                   
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblalternetid" CssClass="control-label" Text="Alternate ID Type" runat="server"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="ddlternetid" CssClass="form-control" runat="server" 
                            TabIndex="13">
                               
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMarital" text="Marital Status" CssClass="control-label" runat="server"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="ddlmaritalstatusDesc" Enabled="false" CssClass="form-control" runat="server" 
                            TabIndex="13">  
                            
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="row">
                   
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label1" CssClass="control-label" Text="Alternate ID No" runat="server"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>
                     
                    <div class="col-sm-3">
                    <div style="display:flex;">
                        <asp:TextBox ID="txtAltIdNo" runat="server" CssClass="form-control" />
                         <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                    Enabled="false" TabIndex="15" Text="Find"> </asp:LinkButton></div>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="LblSoe" text="SOE" CssClass="control-label" runat="server"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="ddlSOE" CssClass="form-control" runat="server" 
                            TabIndex="13">  
                             <asp:ListItem  Text ="Select" Value=""  Enabled="false"> </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                
                <div class="row">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblpfNationality" CssClass="control-label" Text ="Nationality" runat="server"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                         <div  style="display:flex;">
                             <asp:TextBox ID="txtNationalCode" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                            width="25%" Enabled="False"   MaxLength="3" TabIndex="14"></asp:TextBox>
                            <asp:TextBox ID="txtNationalDesc" runat="server" CssClass="form-control" Enabled="False"
                                onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="15"></asp:TextBox>
                           
                                <asp:LinkButton ID="btnNational" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                    Enabled="false" TabIndex="15" Text="..."> <%--  <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> ...--%></asp:LinkButton>
                     
                    </div>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCatagry" Text="Category" CssClass="control-label" 
                            runat="server"></asp:Label><span style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="ddlCat" Enabled ="false" runat="server" CssClass="form-control" 
                            TabIndex="16">
                        </asp:DropDownList>
                    </div>
                </div>
                
                 <div class="row">
                   
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblhightsqual" CssClass="control-label" Text="Highest Qualification" runat="server"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>
                     
                    <div class="col-sm-3">
                  
                       <asp:DropDownList ID="ddlHighQual" Enabled ="false" CssClass="form-control" runat="server" 
                            TabIndex="13">  
                            <%-- <asp:ListItem  Text ="Select" Value=""  Enabled="false"> </asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label6" text="Correspondence address" CssClass="control-label" runat="server"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox runat="server" id="txtCorrAddr" CssClass="form-control"/>
                    </div>
              
                   </div>
                    <div class="row">
                   
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblisndate" CssClass="control-label" Text="Inception date" runat="server"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>
                     
                    <div class="col-sm-3">
                      <asp:TextBox  ID="txtDTRegFrom" runat="server" CssClass="form-control" MaxLength="15" style="margin-bottom:5px;" TabIndex="6"/>
                    </div>
                   
                    
                </div>
    
     


                  <%--Present Address Start--%>
                 
                                    
                              <div class="panel panel-success" >
                              <div id="Div8" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPresentAddress','btnPresentAddress');return false;">  
                                     <div class="row">
                                      <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="lblpfpresentadd" runat="server" Text ="Residential Address(1)"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                                      <div class="col-sm-2">
                        <span id="btnPresentAddress" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                                        </div>
                                        </div>
                              
                                   <div id="divPresentAddress" style="display:block;" runat="server" class="panel-body">
                                        <div class="row">
                                          <div class="col-sm-3" style="text-align:left">
                                            
                                                <asp:Label ID="lblpfAddrP1" runat="server" Text ="Address" style="color:Black"></asp:Label>
                                                 <span style="color: red">*</span>
                                                 </div>
                                          
                                            <div class="col-sm-3">
                                                <asp:TextBox  ID="txtAddrP1" CssClass="form-control" 
                                                    onChange="javascript:this.value=this.value.toUpperCase();"  runat="server" 
                                                    Font-Bold="False" MaxLength="100" TabIndex = "58"></asp:TextBox>
                                                
                                            
                                         </div>
                                           <div class="col-sm-3" style="text-align:left">
                                                 <asp:Label ID="lblpfStateP" runat="server" Text ="State" CssClass="control-label"></asp:Label><span style="color: #ff0000">
                                                 *</span>
                                           </div>
                                            <div class="col-sm-3">
                                
                             <div style="display:flex;">
                                 <asp:DropDownList id="ddlState" runat="server" CssClass="form-control" style='width:98%;'  
                                                        TabIndex="65"></asp:DropDownList> 
                              
                                      <asp:LinkButton ID="btnstatesearch" runat="server" CssClass="btn btn-primary" TabIndex="6"> <span class="glyphicon glyphicon-search BtnGlyphicon"></span>Search </asp:LinkButton>
                            
                             </div>
                             <div id="Div13" class="Content" style="display: none">
                                 <img src="../../../App_Themes/Isys/images/spinner.gif" /></img>Loading...</div>
                            
                             <asp:Label ID="Label17" runat="server" CssClass="control-label" Font-Bold="False"
                                 Font-Size="X-Small"></asp:Label>
                       
                 </div>
                                           
                                   </div>
                                        <div class="row">
                                           
                                       
                                         <div class="col-sm-3" style="text-align:left">
                                            
                                               
                                             </div>
                                             <div class="col-sm-3">
                                                <asp:TextBox ID="txtDistric" runat="server" CssClass="form-control"   
                                                      Font-Bold="False" MaxLength="50" TabIndex="67"></asp:TextBox> 
                                              </div>
                                           

                                    
                                      <div class="col-sm-3" style="text-align:left">
                                           
                                                <asp:Label ID="lblpfPinP" runat="server" Text="Pin Code" CssClass="control-label"></asp:Label>
                                                 <span style="color: red">*</span>
                                              
                                         </div>
                                       <div class="col-sm-3">
                                                <asp:TextBox  ID="txtPinP" runat="server" CssClass="form-control"  Enabled="false"
                                                    Font-Bold="False" MaxLength="6" TabIndex = "72"></asp:TextBox>
                                               
                                       </div>
                                       
                                     </div>
                                        <div class="row">
                                        <div class="col-sm-3" style="text-align:left">
                                                    </div>
                                              <div class="col-sm-3">
                                                     <asp:TextBox ID="txtStateCodeP" runat="server" CssClass="form-control" 
                                                       ></asp:TextBox>
                                                    
                                              </div>
                                               <div class="col-sm-3" style="text-align:left">
                                               
                                                <asp:Label ID="lblpfCountryP" runat="server" text ="Country" CssClass="control-label" ></asp:Label>
                                                 <span style="color: red">*</span>
                                                </div>
                                                  <div class="col-sm-3">
                                                  <div style="display:flex;">
                                            
                                 <asp:TextBox ID="txtCountryCodeP" runat="server" CssClass="form-control" 
                                                 Enabled="false"  width="25%"  onChange="javascript:this.value=this.value.toUpperCase();" 
                                                    MaxLength="3"  TabIndex = "73" ></asp:TextBox>
                                                <asp:TextBox ID="txtCountryDescP" runat="server" 
                                                    CssClass="form-control"   Enabled="False" TabIndex = "74" ></asp:TextBox>
                                             
                                              
                                                
                                                <asp:Button ID="btnCountryP" runat="server" CssClass="standardbutton"  
                                                    CausesValidation="False" Text="..." 
                                                    Enabled = "true"  TabIndex = "75"/>
                                                      </div>
                                                    
                                   </div>
                                      </div>
                                   </div>
                                   </div>
                                  
                                  
                                    <%--Present Address End--%>


                                       <%--Business Address  Start--%>
                                     
                              <div class="panel panel-success" >
                              <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div3','Span1');return false;">  
                                     <div class="row">
                                      <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="Label8" runat="server" Text ="Business Address (1)"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                                      <div class="col-sm-2">
                        <span id="Span1" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                                        </div>
                                        </div>
                              
                                   <div id="div3" style="display:block;" runat="server" class="panel-body">
                                        <div class="row">
                                          <div class="col-sm-3" style="text-align:left">
                                            
                                                <asp:Label ID="lbladrsB" runat="server" Text ="Address" style="color:Black"></asp:Label>
                                                <%-- <span style="color: red">*</span>--%>
                                                 </div>
                                          
                                            <div class="col-sm-3">
                                                <asp:TextBox  ID="txtadrsB" CssClass="form-control" 
                                                    onChange="javascript:this.value=this.value.toUpperCase();"  runat="server" 
                                                    Font-Bold="False" MaxLength="100" TabIndex = "58"></asp:TextBox>
                                               <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" InvalidChars="&quot;',#$@%^!*()&''%^~`"
                                                      FilterMode="InvalidChars" TargetControlID="txtAddrP1" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                            
                                         </div>
                                           <div class="col-sm-3" style="text-align:left">
                                                 <asp:Label ID="lbladrsB2" runat="server" Text ="State" CssClass="control-label"></asp:Label><span style="color: #ff0000">
                                                 *</span>
                                           </div>
                                            <div class="col-sm-3">
                                    
                             <div style="display:flex;">
                                 <asp:DropDownList id="DropDownList4" runat="server" CssClass="form-control" style='width:98%;'  
                                                        TabIndex="65"></asp:DropDownList> 
                              
                                      <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-primary" TabIndex="6"> <span class="glyphicon glyphicon-search BtnGlyphicon"></span>Search </asp:LinkButton>
                            
                             </div>
                             <div id="Div4" class="Content" style="display: none">
                                 <img src="../../../App_Themes/Isys/images/spinner.gif" /></img>Loading...</div>
                            
                             <asp:Label ID="Label11" runat="server" CssClass="control-label" Font-Bold="False"
                                 Font-Size="X-Small"></asp:Label>
                        
                 </div>
                                           
                                   </div>
                                        <div class="row">
                                           
                                       
                                         <div class="col-sm-3" style="text-align:left">
                                            
                                               
                                             </div>
                                             <div class="col-sm-3">
                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"   
                                                      Font-Bold="False" MaxLength="50" TabIndex="67"></asp:TextBox> 
                                              </div>
                                           

                                    
                                      <div class="col-sm-3" style="text-align:left">
                                           
                                                <asp:Label ID="lblpinbs" runat="server" Text="Pin Code" CssClass="control-label"></asp:Label>
                                                 <span style="color: red">*</span>
                                              
                                         </div>
                                       <div class="col-sm-3">
                                                <asp:TextBox  ID="TextBox3" runat="server" CssClass="form-control"  Enabled="false"
                                                    Font-Bold="False" MaxLength="6" TabIndex = "72"></asp:TextBox>
                                               <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" InvalidChars=",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                      FilterMode="InvalidChars" TargetControlID="txtPinP" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                      <asp:HiddenField ID="HiddenField1" runat="server" />--%>
                                       </div>
                                       
                                     </div>
                                        <div class="row">
                                        <div class="col-sm-3" style="text-align:left">
                                                    </div>
                                              <div class="col-sm-3">
                                                     <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" 
                                                       ></asp:TextBox>
                                                    
                                              </div>
                                               <div class="col-sm-3" style="text-align:left">
                                               
                                                <asp:Label ID="lblcntrybs" runat="server" Text="Country" CssClass="control-label" ></asp:Label>
                                                 <span style="color: red">*</span>
                                                </div>
                                                  <div class="col-sm-3">
                                                  <div style="display:flex;">
                                            
                                 <asp:TextBox ID="TextBox5" Text ="IND" runat="server" CssClass="form-control" 
                                                 Enabled="false"  width="25%"  onChange="javascript:this.value=this.value.toUpperCase();" 
                                                    MaxLength="3"  TabIndex = "73" ></asp:TextBox>
                                                <asp:TextBox ID="TextBox6" runat="server"  Text="INDIA"
                                                    CssClass="form-control"   Enabled="False" TabIndex = "74" ></asp:TextBox>
                                             
                                              
                                                
                                                <asp:Button ID="Button1" runat="server" CssClass="standardbutton"  
                                                    CausesValidation="False" Text="..." 
                                                    Enabled = "true"  TabIndex = "75"/>
                                                      </div>
                                                    
                                   </div>
                                      </div>
                                   </div>
                                   </div>
                               
                                    <%--Business Address End--%>




                                      <%--Permanent  Address  Start--%>
                                      
                                    
                              <div class="panel panel-success" >
                              <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div6','Span2');return false;">  
                                     <div class="row">
                                      <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="Label14" runat="server" Text ="Permanent Address Same As Present Address"  CssClass="control-label" ></asp:Label>
                      <asp:CheckBox ID="ChkPA" runat="server" CssClass="standardcheckbox"  TabIndex = "76" /> 
                      <span style="color: red">*</span>
                 
                    </div>
                                      <div class="col-sm-2">
                        <span id="Span2" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                                        </div>
                                        </div>
                              
                                   <div id="div6" style="display:block;" runat="server" class="panel-body">
                                        <div class="row">
                                          <div class="col-sm-3" style="text-align:left">
                                            
                                                <asp:Label ID="lblper" runat="server" Text ="Address" style="color:Black"></asp:Label>
                                                 <span style="color: red">*</span>
                                                 </div>
                                          
                                            <div class="col-sm-3">
                                                <asp:TextBox  ID="txtper" CssClass="form-control" 
                                                    onChange="javascript:this.value=this.value.toUpperCase();"  runat="server" 
                                                    Font-Bold="False" MaxLength="100" TabIndex = "58"></asp:TextBox>
                                               <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" InvalidChars="&quot;',#$@%^!*()&''%^~`"
                                                      FilterMode="InvalidChars" TargetControlID="txtAddrP1" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                            
                                         </div>
                                           <div class="col-sm-3" style="text-align:left">
                                                 <asp:Label ID="lblstateper" runat="server" Text="State" CssClass="control-label"></asp:Label><span style="color: #ff0000">
                                                 *</span>
                                           </div>
                                            <div class="col-sm-3">
                                   
                             <div style="display:flex;">
                                 <asp:DropDownList id="ddlstateper" runat="server" CssClass="form-control" style='width:98%;'  
                                                        TabIndex="65"></asp:DropDownList> 
                              
                                      <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-primary" TabIndex="6"> <span class="glyphicon glyphicon-search BtnGlyphicon"></span>Search </asp:LinkButton>
                            
                             </div>
                             <div id="Div7" class="Content" style="display: none">
                                 <img src="../../../App_Themes/Isys/images/spinner.gif" /></img>Loading...</div>
                            
                             <asp:Label ID="Label18" runat="server" CssClass="control-label" Font-Bold="False"
                                 Font-Size="X-Small"></asp:Label>
                       
                 </div>
                                           
                                   </div>
                                        <div class="row">
                                           
                                       
                                         <div class="col-sm-3" style="text-align:left">
                                            
                                               
                                             </div>
                                             <div class="col-sm-3">
                                                <asp:TextBox ID="txtaddrper2" runat="server" CssClass="form-control"   
                                                      Font-Bold="False" MaxLength="50" TabIndex="67"></asp:TextBox> 
                                              </div>
                                           

                                    
                                      <div class="col-sm-3" style="text-align:left">
                                           
                                                <asp:Label ID="lblpinper" runat="server" Text="Pin Code" CssClass="control-label"></asp:Label>
                                                 <span style="color: red">*</span>
                                              
                                         </div>
                                       <div class="col-sm-3">
                                                <asp:TextBox  ID="txtpinper" runat="server" CssClass="form-control"  Enabled="false"
                                                    Font-Bold="False" MaxLength="6" TabIndex = "72"></asp:TextBox>
                                              <%--  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" InvalidChars=",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                      FilterMode="InvalidChars" TargetControlID="txtPinP" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                      <asp:HiddenField ID="HiddenField2" runat="server" />--%>
                                       </div>
                                       
                                     </div>
                                        <div class="row">
                                        <div class="col-sm-3" style="text-align:left">
                                                    </div>
                                              <div class="col-sm-3">
                                                     <asp:TextBox ID="txtdist2" runat="server" CssClass="form-control" 
                                                       ></asp:TextBox>
                                                    
                                              </div>
                                               <div class="col-sm-3" style="text-align:left">
                                               
                                                <asp:Label ID="lblpercuntry" Text="Country" runat="server" CssClass="control-label" ></asp:Label>
                                                 <span style="color: red">*</span>
                                                </div>
                                                  <div class="col-sm-3">
                                                  <div style="display:flex;">
                                            
                                 <asp:TextBox ID="txtcountryper" runat="server" CssClass="form-control" 
                                                 Enabled="false"  width="25%"  onChange="javascript:this.value=this.value.toUpperCase();" 
                                                    MaxLength="3"  TabIndex = "73" ></asp:TextBox>
                                                <asp:TextBox ID="txtcntryper" runat="server" 
                                                    CssClass="form-control"   Enabled="False" TabIndex = "74" ></asp:TextBox>
                                             
                                              
                                                
                                                <asp:Button ID="Button2" runat="server" CssClass="standardbutton"  
                                                    CausesValidation="False" Text="..." 
                                                    Enabled = "true"  TabIndex = "75"/>
                                                      </div>
                                                    
                                   </div>
                                      </div>
                                   </div>
                                   </div>
                                   
                                  
                                    <%--Permanent  Address End--%>



                                        <%--contact details--%>
                                         
          <div class="panel panel-success">
          <div id="Div9" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divContactInformation','btnContactInformation');return false;">           
                   <div class="row">
                    <div class="col-sm-3" style="text-align:left">
                          <span class="glyphicon glyphicon-menu-hamburger" style="color:Orange;"></span> Contact Preferred
                          </div>
                           <div class="col-sm-2" style="text-align:left">
                         
                           <asp:DropDownList id="ddlDstbnMethod" runat="server" Enabled="false"  CssClass="form-control" AutoPostBack="true"  >
                           <%-- <asp:ListItem  Text ="Select" > </asp:ListItem>--%>
                           </asp:DropDownList>
                           </div>
                                 <div class="col-sm-3" style="text-align:left">
                                                       
                       <span class="glyphicon glyphicon-menu-hamburger" style="color:Orange;"></span> Privacy
                       </div>
                        <div class="col-sm-2" style="text-align:left">
                         
                           <asp:DropDownList id="ddlprivacy" runat="server" Enabled ="false"   CssClass="form-control" AutoPostBack="true"  TabIndex="17" >
                                    <%--  <asp:ListItem  Text ="Select" > </asp:ListItem>--%>
                                                               </asp:DropDownList>    
                                                               </div>
                                                         
                  
                     <div class="col-sm-2">
                        <span id="btnContactInformation" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
               </div>
          <div id="divContactInformation" style="display:block;" runat="server" class="panel-body">
         
                     
                                        <div class="row">
                                          <div class="col-sm-3" style="text-align:left">
                                             <%--Added by shreela on 6/03/14 to remove space--%>
                                                <asp:Label ID="lblpfhometel" runat="server" Text="Home Tel No" CssClass="control-label" ></asp:Label>
                                                <span style="color: red">*</span>
                                               <%-- <span style="color: #ff0000">*</span>--%>
                                       </div>
                                          <div class="col-sm-3" >
                                                <asp:TextBox  ID="txthometel" runat="server"
                                                  placeholder="Should not start with 0 and should be 10 digit."    CssClass="form-control" MaxLength="10" 
                                                    TabIndex = "18" ></asp:TextBox>
                                                    <asp:Label ID="LblhomeNote" runat="server" visible="false" Text="(Tel No:Should not start with 0 and should be 10 digit.)" CssClass="control-label" ForeColor="Red"></asp:Label>
                                                     </div>
                                          <div class="col-sm-3" style="text-align:left">
                                                <span><asp:Label ID="lblpfofftel" runat="server" text="Office Tel" CssClass="control-label"></asp:Label></span>
                                     </div>
                                          <div class="col-sm-3">
                                                <asp:TextBox ID="txtWorkTel" runat="server" CssClass="form-control"
                                                    MaxLength="11" TabIndex="19" ></asp:TextBox>
                                                 </div>
                                         </div>
              <div class="row">
                  <div class="col-sm-3" style="text-align: left">
                      <%--Added by shreela on 6/03/14 to remove space--%>
                      <asp:Label ID="lblpfdidtel" runat="server" Text="DID Tel No" CssClass="control-label"></asp:Label>
                      
                      
                  </div>
                  <div class="col-sm-3">
                     
                           <asp:TextBox ID="didtel" Enabled="false"  runat="server" Text="91" CssClass="form-control" 
                          ></asp:TextBox>
                            
                      </div>
                    
                     
             
                  <div class="col-sm-3" style="text-align: left">
                      <asp:Label ID="lblMobile2" runat="server" Text="Mobile No" CssClass="control-label">
                      </asp:Label> <span style="color: red">*</span>
                  </div>
                  <div class="col-sm-3">
                     
                        
                          <asp:TextBox ID="txtMobile2" runat="server" CssClass="form-control" 
                              MaxLength="10" TabIndex="21"></asp:TextBox>
                        
                     
                  </div>
              </div>
                                       <div class="row">
                                           <div class="col-sm-3" style="text-align:left">
                                         
                                                    <asp:Label ID="lblpfemail" runat="server" Text="Email" CssClass="control-label"></asp:Label>
                                                      <span style="color: red">*</span>
                                         </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" MaxLength="50" TabIndex="22" ></asp:TextBox>&nbsp;
                                          </div>
                                            <div class="col-sm-3" style="text-align:left">
                                                <span>
                                                    <asp:Label ID="lblEmail2" runat="server" Text="Direct Mail" CssClass="control-label"></asp:Label>
                                                </span>
                                      </div>
                                           <div class="col-sm-3">
                                            <div style="display:flex;">
                                                <asp:TextBox ID="txtEmail2" runat="server" CssClass="form-control" Width ="25%"
                                                    MaxLength="50" TabIndex="23" ></asp:TextBox>&nbsp;
                                                    </div>
                                            </div>
                                  </div>
                                   <div class="row">
                                           <div class="col-sm-3" style="text-align:left">
                                         
                                                    <asp:Label ID="lblpager" runat="server" Text="Pager" CssClass="control-label"></asp:Label>
                                                     
                                         </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="Txtpager" runat="server" CssClass="form-control"  TabIndex="22" ></asp:TextBox>&nbsp;
                                          </div>
                                            <div class="col-sm-3" style="text-align:left">
                                                <span>
                                                    <asp:Label ID="lblfax" runat="server" Text="Fax" CssClass="control-label"></asp:Label>
                                                </span>
                                      </div>
                                           <div class="col-sm-3">
                                           
                                                <asp:TextBox ID="txtfax" runat="server" CssClass="form-control" 
                                                    MaxLength="50" TabIndex="23" ></asp:TextBox>&nbsp;
                                                  
                                            </div>
                                  </div>
                                   
                                    </div>
             </div>
              <%--Contact details end--%>

           <%--  Personal details --%>
           <div class="panel panel-success" >
                              <div id="Div10" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div11','Span3');return false;">  
                                     <div class="row">
                                      <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="Label3" runat="server" Text ="Personal Details"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                                      <div class="col-sm-2">
                        <span id="Span3" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                                        </div>
                                        </div>
                              
                                   <div id="div11" style="display:block;" runat="server" class="panel-body">
                                        <div class="row">
                                          <div class="col-sm-3" style="text-align:left">
                                            
                                                <asp:Label ID="lblhight" runat="server" Text ="Height (cm)" style="color:Black"></asp:Label>
                                                
                                                 </div>
                                          
                                            <div class="col-sm-3">
                                                <asp:TextBox  ID="txthight" CssClass="form-control" runat="server" > </asp:TextBox>
                                             
                                            
                                         </div>
                                           <div class="col-sm-3" style="text-align:left">
                                                 <asp:Label ID="lblweight" runat="server" Text ="State" CssClass="control-label"></asp:Label>
                                           </div>
                                            <div class="col-sm-3">
                                    
                                       <asp:TextBox  ID="txtweight" CssClass="form-control" runat="server" > </asp:TextBox>
                        
                                         </div>
                                           
                                   </div>
                                        <div class="row">
                                           
                                       
                                         <div class="col-sm-3" style="text-align:left">
                                             <asp:Label ID="lbloccupation" runat="server" Text ="Occupation" CssClass="control-label"></asp:Label>
                                               <span style="color: red">*</span> 
                                             </div>
                                             <div class="col-sm-3">
                                                 <div style="display:flex;">
                                            
                                 <asp:TextBox ID="txtoccupation"  runat="server" CssClass="form-control" 
                                                 Enabled="false"  width="25%"  onChange="javascript:this.value=this.value.toUpperCase();" 
                                                    MaxLength="3"  TabIndex = "73" ></asp:TextBox>
                                                <asp:TextBox ID="txtoccupation1" runat="server" 
                                                    CssClass="form-control"   Enabled="False" TabIndex = "74" ></asp:TextBox>
                                             
                                              
                                                
                                                <asp:Button ID="Button4" runat="server" CssClass="standardbutton"  
                                                    CausesValidation="False" Text="..." 
                                                    Enabled = "true"  TabIndex = "75"/>
                                                      </div>
                                              </div>
                                           

                                    
                                      <div class="col-sm-3" style="text-align:left">
                                           
                                                <asp:Label ID="lblIncome" runat="server" Text="Anual Income" CssClass="control-label"></asp:Label>
                                                
                                              
                                         </div>
                                       <div class="col-sm-3">
                                                <asp:TextBox  ID="txtIncome" runat="server" CssClass="form-control"  Enabled="false"
                                                    Font-Bold="False"  TabIndex = "72"></asp:TextBox>
                                              
                                       </div>
                                       
                                     </div>
                                        <div class="row">
                                       
                                            
                                               <div class="col-sm-3" style="text-align:left">
                                               
                                                <asp:Label ID="lblpreffered" runat="server" Text="Preferred Client" CssClass="control-label" ></asp:Label>
                                              
                                                </div>
                                                  <div class="col-sm-3">
                                                  <div style="Display:flex;")
                                                     <asp:TextBox ID="txtpreffered" runat="server" CssClass="form-control" 
                                                       ></asp:TextBox>
                                                       </div>
                                                    
                                              </div>
                                                 
                                      </div>
                                   </div>
                                   </div>
        <%--   end personal details--%>
            
               <div class="row" style="margin-top:12px;">
                    <div class="col-sm-12" align="center">
       
                         <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-primary" CausesValidation="false"
                                OnClick="btnUpdate_Click" TabIndex="244" >
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"> </span> Update
                        </asp:LinkButton>  
               
                 <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-danger" CausesValidation="False"
                               OnClientClick="doCancel();return false;" >
                             <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> Cancel 
                             </asp:LinkButton> 
                   <div id="divloader" runat="server" style="display:none;">
                                 <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                    </div>
                    </div>
                    </div> 
             </div>               
       </div>
              <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" style='width:400px;height:238px;'>
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label4" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl3" runat="server"></asp:Label><br />
        
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-primary" data-dismiss="modal" style='margin-top:-6px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>
   

    </asp:Content>
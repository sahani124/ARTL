<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/iFrame.master" CodeFile="PopCntstMst.aspx.cs"
    Inherits="Application_ISys_Saim_PopCntstMst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
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
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>



    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }


        function funPopUpCycle(cmpcode, accycle, cyctype, yrtyp, effdatefrom, effdateto, rulesetcode, cntstcode, BUSI_YEAR) {

            debugger;
            window.open("Date_Cycle_Defination.aspx?cmpcode=" + cmpcode + "&accyc=" + accycle
                + "&cyctype=" + cyctype + "&yrtyp=" + yrtyp + "&effdatefrom=" + effdatefrom + "&effdateto=" + effdateto + "&rulesetcode=" + rulesetcode + "&cntstcode=" + cntstcode + "&BUSI_YEAR=" + BUSI_YEAR, "PopUpCycle", "toolbar=yes,scrollbars=yes,resizable=yes,top=40,left=70,bottom=80,width=1200,height=600", true);

        }
        //function funPopUpCycle(cmpcode, accycle, cyctype, yrtyp, effdatefrom, effdateto, rulesetcode, cntstcode, BUSI_YEAR) {





        function doCancel() {

            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            window.parent.document.getElementById("btnKPI").click();
        }

        function funPopupDataSynchHybrid(cmpcode, cnstCode, RuleSet, CatgCode) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlPopBIDHybrid").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "PopBulkCatgUpd.aspx?CmpCode=" + cmpcode + "&cnstCode=" + cnstCode + "&RuleSet="
                + RuleSet + "&CatgCode=" + CatgCode
                + "&mdlpopup=mdlPopBIDHybrid";
        }
        function ShowReqDtl1(divName, btnName) {
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

    </script>
    <style type="text/css">
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space:nowrap;
        }
        .new_text_new
        {
            color: #066de7;
        }
        .divBorder
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
        }*/
        .disablepage {
            display: none;
        }
    </style>
    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="div1" runat="server" style="width: 97%;" class="panel">
                    <div id="divqualhdrcollapse" runat="server" class="panel-heading" style="width: 96%;"
                        onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divqual','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblhdr" Text="Select Master" Style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 26/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <div id="divqual" class="panel-body" runat="server">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label1" Text="Compensation Code" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCompCodeVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label2" Text="Contestant Code" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCntstCdVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                            </div>
                        </div>
                        <div id="divrul" runat="server" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label Text="Rule Set Key" runat="server" CssClass="control-label"/>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlRuleSetKy" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" 
                                            onselectedindexchanged="ddlRuleSetKy_SelectedIndexChanged">
                                        </asp:DropDownList>
                                         <asp:HiddenField ID="hdnIsValid" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label Text="Rule Set Key Description" runat="server" CssClass="control-label"/>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRulSetDsc" runat="server" CssClass="select2-container form-control" /></ContentTemplate>
                                </asp:UpdatePanel>  
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblrlSetKy" Text="Rule Set Key" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtRuleSetKey" runat="server" CssClass="select2-container form-control"
                                    placeholder="Rule Set Key" Enabled="false" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRuleSetKeyDesc" Text="Rule Set Key Description" runat="server"
                                    CssClass="control-label" />
                                <asp:Label ID="lblRuleSetKeyDesc_s" Text="*" runat="server" Style="color: Red" />
                            </div>

                          <%--  added by ajay sawant--%>


                              
                                       

                            <div class="col-sm-3" style="display:flex;">
                                <asp:TextBox ID="txtRuleSetKeyDsc" runat="server" CssClass="select2-container form-control"
                                    placeholder="Rule Set Key" />
                                    <asp:LinkButton ID="lnkrwddsc" runat="server" CssClass="btn btn-sample">
                                    <span style="color: White;"></span> ...
                                </asp:LinkButton>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars=" ,&,_,<,=,>/"
                                    FilterMode="ValidChars" TargetControlID="txtRuleSetKeyDsc">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
                          <div class="row"  runat="server" id="divKPILinkage" Visible="false"  style="margin-bottom: 5px;">

                                <div class="col-sm-3" style="text-align: left">
                                             <asp:Label ID="lblKPIlinkage" Text="KPI Linkage" runat="server"
                                                             CssClass="control-label" />
                                </div>

                               <div class="col-sm-3" >
                                            <asp:DropDownList runat="server" ID="ddlKPILinkage" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%"  >
                                    
    
                                
                                 </asp:DropDownList>
                                </div>
                            </div>

                         <%--Added by prity on 23 aug 2018--%>
                            <div class="row"  id="divParent" style="margin-bottom: 5px;" visible="false" runat="server">
                            <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="LblPcmpcode" Text="Parent Compensation Code" runat="server" CssClass="control-label" />
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlPcmpCode" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" 
                                     onselectedindexchanged="ddlPcmpCode_SelectedIndexChanged"  ViewStateMode="Enabled" EnableViewState="true">
                                    
                                    
                                 </asp:DropDownList>
                                </div>
                            
                            
                               <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="LblPcntcode" Text="Parent Contestant Code" runat="server"   CssClass ="control-label" />
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                
                                      <asp:DropDownList runat="server" ID="ddlPCntCode" 
                                            CssClass="form-control" Width="100%"  onselectedindexchanged="ddlPcntCode_SelectedIndexChanged" AutoPostBack="true" >
                                    
    
                                
                                 </asp:DropDownList>
                  
                             
                                </div>
                                        </div>
                              <%--Ended by prity on 23 aug 2018--%> 
                         <div class="row"  id="divRuleMethod" style="margin-bottom: 5px;" visible="false" runat="server">
                             <%--Added by prity--%>
                            
                               <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="lblParent" Text="Parent Rule Set Key" runat="server"   CssClass ="control-label" />
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlParentRule" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%"  OnSelectedIndexChanged="ddlParentRule_SelectedIndexChanged" >
                                    
    
                                
                                 </asp:DropDownList>
                             
                                </div>
                                       
                              <%--Ended by prity--%> 
                              <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="lblRuleMethod" Text="Rule Method" runat="server" CssClass="control-label" />
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlRuleMethod" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" OnSelectedIndexChanged="ddlRuleMethod_SelectedIndexChanged" >
                                    
                                    
                                 </asp:DropDownList>
                                </div>
                             </div>
                         <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row" id="divparentkpi" runat="server" visible="false">
                              <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="lblKPI_Code" Text="Parent KPI Code" runat="server" CssClass="control-label" />
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlKPI_Code" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" >
                                
                                 </asp:DropDownList>
                             
                                </div>
                                             <div class="col-sm-6" style="text-align: left"></div>
                              </div>
                                         </ContentTemplate>
                            </asp:UpdatePanel>
                                    
                            <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                              
                                
                                        <div class="row" style="margin-bottom: 5px;" runat="server" id="divAccumulation" visible="false">
                                            
                                            
                                             <div class="col-sm-3" style="text-align: left">
                                <asp:Label Text="Accrual Cycle" runat="server" CssClass="control-label" />
                                <asp:Label ID="Accrual_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAccrCyc" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="7"   Enabled="true">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                                            
                                            
                                            
                                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAccCyc" Text="Accumulation Cycle" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblAccCyc_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAccCyc" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="4" Enabled="true"  OnSelectedIndexChanged="ddlAccCyc_SelectedIndexChanged" 
 >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                         
                            
                        </div>



                           <div class="row" style="margin-bottom: 5px;" runat="server" id="divReward" visible="false">
                                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRewardComputation" Text="Reward Computation Cycle" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label8" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlRewardComputation" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="4" Enabled="false"   >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                         
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRwdRlsCyc" Text="Rewards Release Cycle" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblRwdRlsCyc_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlRwdRlsCyc" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="8"  Enabled="false">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        

                               <div class="row" id="divMemCycleData" runat="server" visible="false">
                                <div class="col-sm-3" style="text-align: left">
                                     <asp:Label ID="lblMEM_ACH_ACC_CYCLE" Text="Member Achievement Accumulation Cycle" runat="server" CssClass="control-label" />
                                     <asp:Label ID="spnMEM_ACH_ACC_CYCLE" Text="*" runat="server" ForeColor="red" Visible="false"/>
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlMEM_ACH_ACC_CYCLE" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" >
                                    <asp:ListItem Value="">--SELECT--</asp:ListItem>
                                    <asp:ListItem Value="M">Monthly</asp:ListItem>
                                    <asp:ListItem Value="Q">Quarterly</asp:ListItem>
                                    <asp:ListItem Value="H">Half-Yearly</asp:ListItem>
                                    <asp:ListItem Value="A">Annually</asp:ListItem>
                                 </asp:DropDownList>
                            
                                </div>
                                         
                                   <div class="col-sm-3" style="text-align: left">
                                     <asp:Label ID="lblMEM_RWD_CMP_CYCLE" Text="Member Reward Computation Cycle" runat="server" CssClass="control-label" />
                                       <asp:Label ID="spnMEM_RWD_CMP_CYCLE" Text="*" runat="server" ForeColor="red" Visible="false"/>
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlMEM_RWD_CMP_CYCLE" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" >
                                <asp:ListItem Value="">--SELECT--</asp:ListItem>
                                     <asp:ListItem Value="N">None</asp:ListItem>
                                    <asp:ListItem Value="M">Monthly</asp:ListItem>
                                    <asp:ListItem Value="Q">Quarterly</asp:ListItem>
                                    <asp:ListItem Value="H">Half-Yearly</asp:ListItem>
                                     <asp:ListItem Value="A">Annually</asp:ListItem>
                                 </asp:DropDownList>
                             
                                </div>
                                   
                              
                              </div>
                               <div class="row" runat="server" >
                                   <div id="divMemCycleData2"  runat="server" visible="false">
                                <div class="col-sm-3" style="text-align: left">
                                     <asp:Label ID="lblMEM_RWD_REL_CYCLE" Text="Member Reward Release Cycle" runat="server" CssClass="control-label" />
                                      <asp:Label ID="spnMEM_RWD_REL_CYCLE" Text="*" runat="server" ForeColor="red" Visible="false" />
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlMEM_RWD_REL_CYCLE" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" >
                                            <asp:ListItem Value="">--SELECT--</asp:ListItem>
                                     <asp:ListItem Value="N">None</asp:ListItem>
                                    <asp:ListItem Value="M">Monthly</asp:ListItem>
                                    <asp:ListItem Value="Q">Quarterly</asp:ListItem>
                                    <asp:ListItem Value="H">Half-Yearly</asp:ListItem>
                                      <asp:ListItem Value="A">Annually</asp:ListItem>
                                 </asp:DropDownList>
                             
                                </div>
                                         </div>
                                   <div id="DivAchtable" runat="server" style="display:none;">
                            <%--Added by prity on 23 aug 2018--%>
                                    <div class="col-sm-3" style="text-align: left" >
                                     <asp:Label ID="lblAch" Text="Achievement Table" runat="server" CssClass="control-label" />
                                    
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlAch" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" >
                                           
                                 </asp:DropDownList>
                             </div>
                             

                                </div>

                                   </div>
                                  
                                  <div id="divRuleType" class="row" runat="server" visible="false">
                                      <%--  <div class="col-sm-3" style="text-align: left" >
                                     <asp:Label ID="lblRulTyp" Text="Rule Class" runat="server" CssClass="control-label" />
                                    
                                     </div>--%>

                                   <%--     <div class="col-sm-3" style="text-align: left">
                                        <asp:DropDownList runat="server" ID="ddlRuleType"  AutoPostBack="true" 
                                            CssClass="form-control" Width="100%"  onselectedindexchanged="ddlOperator_SelectedIndexChanged">
                                           
                                        </asp:DropDownList>
                                    </div>--%>

                                        <div class="col-sm-3" style="text-align: left" >
                                     <asp:Label ID="Label7" Text="Target Category Rule Class" runat="server" CssClass="control-label" /> 
                                              <asp:Label ID="Label11" Text="*" runat="server" ForeColor="red" Visible="true" />
                                    
                                     </div>

                                        <div class="col-sm-3" style="text-align: left">
                                        <asp:DropDownList runat="server" ID="ddlRuleType"  AutoPostBack="true" 
                                            CssClass="form-control" Width="100%"  onselectedindexchanged="ddlOperator_SelectedIndexChanged">
                                           
                                        </asp:DropDownList>
                                    </div>


                                        <div class="col-sm-3" style="text-align: left" >
                                     <asp:Label ID="Label9" Text="Reward Rule Class" runat="server" CssClass="control-label" />
                                    <asp:Label ID="Label12" Text="*" runat="server" ForeColor="red" Visible="true" />
                                     </div>

                                        <div class="col-sm-3" style="text-align: left">
                                        <asp:DropDownList runat="server" ID="ddlRuleClass"  AutoPostBack="true" 
                                            CssClass="form-control" Width="100%"  >
                                           
                                        </asp:DropDownList>
                                    </div>






                                       <div class="col-sm-3" style="text-align: left" >
                                     <asp:Label ID="lblRulCmpx" Text="Rule Complexity" runat="server" CssClass="control-label"  Visible="false"/>
                                    
                                     </div>

                                        <div class="col-sm-3" style="text-align: left">
                                        <asp:DropDownList runat="server" ID="ddlRulComplexity"  AutoPostBack="true" OnSelectedIndexChanged="ddlRulComplexity_SelectedIndexChanged" 
                                            CssClass="form-control" Width="100%"   Visible="false">
                                           
                                        </asp:DropDownList>
                                    </div>


                                      </div>
                                        
                                        <div class="row" runat="server" id="MoCycle"  visible="false">


                                             <div class="col-sm-3" style="text-align: left" >
                                     <asp:Label ID="Label13" Text="Starting  rule from M0  cycle?" runat="server" CssClass="control-label" />
                                  
                                     </div>
                                              <div class="col-sm-3"   style="text-align: left" >
                                       <asp:RadioButtonList ID="cycleM0" runat="server" CssClass="radio-list" AutoPostBack="true"
                                    RepeatDirection="Horizontal" OnSelectedIndexChanged="cycleM0_SelectedIndexChanged">
                                        
                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>  

                                    <asp:ListItem Text="No"   Value="N"  ></asp:ListItem>

                                    </asp:RadioButtonList>
                                       </div>



                                      
                                       <div class="col-sm-3" style="text-align: left" >
                                     <asp:Label ID="Label14" Text="M0 is separate cycle?" runat="server" Visible="false" CssClass="control-label" />
                                  
                                     </div>

                                        <div class="col-sm-3"  style="text-align: left" >
                                       <asp:RadioButtonList ID="rdoseparate" Visible="false" runat="server" CssClass="radio-list" AutoPostBack="true"
                                    RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoseparate_SelectedIndexChanged" >
                                        
                                    <asp:ListItem Text="Yes" Value="Y" ></asp:ListItem>  

                                    <asp:ListItem Text="No" Value="N" ></asp:ListItem>

                                    </asp:RadioButtonList>
                                       </div>
                                             <div class="col-sm-6" style="text-align: left" >
                                              
                                                 </div>
                                            
                                             <div class="col-sm-6" style="text-align: left" >
                                                  <asp:Label ID="lblnote"  runat="server" Text="NOTE:"  Visible="false" Font-Bold="true" ForeColor="red"></asp:Label>
                                                     <asp:Label ID="Label15" Text="Achievement of M0 cycle will be added to M1 cycle" ForeColor="red"  runat="server" CssClass="control-label" Visible="false" />
                    

                                                 </div>



                                            </div>


                                        
                                   <div id="divOperator" class="row" runat="server" visible="false">
                            

                                    <div class="col-sm-3" style="text-align: left" >
                                     <asp:Label ID="lblOperator" Text="Operator" runat="server" CssClass="control-label" />
                                    
                                     </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:DropDownList runat="server" ID="ddlOperator" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%"  onselectedindexchanged="ddlOperator_SelectedIndexChanged">
                                           
                                        </asp:DropDownList>
                                    </div>
                                    

                                     </div>
                                 
                             
                              
                            
                           


                            

                           <div class="row" style="margin-bottom: 5px;" id="divCat1" runat="server" visible="false">
                                <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label3" Text="Accumulation Year" runat="server" CssClass="control-label" />
                                 </div>
                               <div class="col-sm-3">
                              <%--  <asp:RadioButtonList ID="rblIsparent" runat="server" CssClass="radio-list" AutoPostBack="true"
                                    RepeatDirection="Horizontal" OnSelectedIndexChanged="rblIsparent_SelectedIndexChanged">
                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>

                                </asp:RadioButtonList>--%>

                                   <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" 
                                            >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                                <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label4" Text="Member Cycle" runat="server"
                                    CssClass="control-label" />
                              <%--  <asp:Label ID="Label5" Text="*" runat="server" Style="color: Red" />--%>
                            </div>

                                <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlParentCategory" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" 
                                            >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>



                            </div>


                         <div class="row" style="margin-bottom: 5px;" id="divCat2" runat="server" visible="false">

                              <div class="col-sm-3" style="text-align: left">
                                  <asp:Label ID="Label5" Text="Category Code 2" runat="server"
                                    CssClass="control-label" />
                                  </div>

                              <div class="col-sm-3" >

                                  <asp:TextBox ID="txtCat2" runat="server" CssClass="select2-container form-control"
                                    placeholder="Cate2" Enabled="false" />
                                  </div>
                             </div>

                         <div class="row" style="margin-bottom: 5px;" id="divScore" runat="server" visible="false">

                              <div class="col-sm-3" style="text-align: left">
                                  <asp:Label ID="lblScorefrom" Text="Score From" runat="server"
                                    CssClass="control-label" />
                                  </div>

                              <div class="col-sm-3" >

                                  <asp:TextBox ID="txtScorefrom" runat="server" CssClass="select2-container form-control"
                                    placeholder="Weighted Score from" Enabled="true" />
                                  </div>
                             <div class="col-sm-3" style="text-align: left">
                                  <asp:Label ID="lblScoreTo" Text="Score To" runat="server"
                                    CssClass="control-label" />
                                  </div>

                              <div class="col-sm-3" >

                                  <asp:TextBox ID="txtScoreTo" runat="server" CssClass="select2-container form-control"
                                    placeholder="Weighted Score to" Enabled="true" />
                                  </div>
                             </div>

                       

                                          </ContentTemplate>
        </asp:UpdatePanel>
                               </div>

                   <%-- permutation and combination Start--%>
                    <div id="divPCHeading" runat="server"  visible="false" class="panel-heading" style="width: 96%;"
                        onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divPrmtCmbns','myImg4');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblPC" Text="Permutation-Combination" Style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg4" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 26/4/2018--%>
                            </div>
                        </div>
                    </div>
                
                   

                      <div id="divPC" class="panel-body" runat="server" visible="false">  
                          <div class="row" id="divIOPC" runat="server">
                            <div class="col-sm-3" style="text-align: left">
                                  <asp:Label ID="lblInput" Text="Possible Combination" runat="server"
                                    CssClass="control-label" />
                                  </div>

                              <div class="col-sm-3" >

                                  <asp:TextBox ID="txtInput1" runat="server" CssClass="select2-container form-control"
                                    placeholder="Input Value" Enabled="true" />
                                  </div>
                             <div class="col-sm-3" style="text-align: left">
                                  <asp:Label ID="lblInput2" Text="Output" runat="server"
                                    CssClass="control-label" />
                                  </div>

                              <div class="col-sm-3" >

                                  <asp:TextBox ID="txtInput2" runat="server" CssClass="select2-container form-control"
                                    placeholder="Input Value" Enabled="true" />
                                  </div>


                               <div class="col-sm-12" align="center">
                                 
                                <asp:LinkButton ID="lnkAddPC" runat="server" CssClass="btn btn-sample" onclick="lnkAddPC_Click"  Visible="false">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add 
                                </asp:LinkButton>
                               
                            </div>
                             </div>
                         
                              
                            
                        </div>

                     <div id="divPrmtCmbn" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                            padding: 10px;" class="table-scrollable" visible="false">
                         <asp:UpdatePanel ID="UpdPnlPC" runat="server">
                             <%-- <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lnkAddPC" EventName="click" />
                             </Triggers>--%>
                                <ContentTemplate>

                       <asp:GridView ID="gvPrmtCmbn" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable"  DataKeyNames="RULE_SET_KEY">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                        
                                             <Columns>

                                               <asp:TemplateField HeaderText="Rule Set" SortExpression="COMBINATION">
                                               <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRuleSet" runat="server" Text='<%# Bind("RULE_SET_KEY")%>'></asp:Label>
                                                         <asp:HiddenField ID="hdnCMPNSTN_CODE_PC" runat="server" Value='<%# Bind("CMPNSTN_CODE")%>' />
                                                        <asp:HiddenField ID="hdnCNTSTNT_CODE_PC" runat="server" Value='<%# Bind("CNTSTNT_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                               
                                            <asp:TemplateField HeaderText="Combination" >
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCombination_PC" runat="server" Text='<%# Bind("PSBL_COMBINATION")%>'></asp:Label>
                                                    <%-- <asp:HiddenField ID="hdnINPUT_VALUE_PC" runat="server" Value='<%# Bind("INPUT_VALUE")%>' />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Output Value">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOUTPUT_VALUE_PC" runat="server" Text='<%# Bind("OUTPUT_VALUE")%>' />
                                                  
                                                    </ItemTemplate>
                                            </asp:TemplateField>

                                                 </columns>
                           </asp:GridView>
                                    </ContentTemplate>
                             
                             </asp:UpdatePanel>
                        
                        <br>
                      
                         </div>

                  <%--   desgin task gridview--%>
                    <div id="divDsgnTskHdng" runat="server"  visible="false" class="panel-heading" style="width: 96%;"
                        onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divqual','myImg3');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblDesign" Text="Design Task" Style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg3" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 26/4/2018--%>
                            </div>
                        </div>
                    </div>

                    <div id="divDsgnTsk" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                            padding: 10px;" class="table-scrollable" visible="false">
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                       <asp:GridView ID="gvDsgnTsk" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" OnRowDataBound="gvDsgnTsk_RowDataBound"  DataKeyNames="CmpstnCode">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                        
                                             <Columns>

                                                   <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                 <ItemTemplate>  
                                                            <asp:CheckBox ID="chkOne" runat="server" />  
                                                       </ItemTemplate> 
                                            </asp:TemplateField>

                                               
                                            <asp:TemplateField HeaderText="Compensation Code" SortExpression="CmpstnCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkCompCode" runat="server" Text='<%# Bind("CmpstnCode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contestant Code" SortExpression="CntstCode">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCntstCode" runat="server" Text='<%# Bind("CntstCode")%>' />
                                                    <asp:HiddenField ID="lblCntstCode11" runat="server" Value='<%# Bind("CntstCode")%>' />
                                                    
                                                           
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rule Set Code" SortExpression="RuleSetCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetCode" runat="server" Text='<%# Bind("RuleSetCode")%>' />
                                                     <asp:HiddenField ID="hdnACCRUAL_ACC_CYCLE" runat="server" Value='<%# Bind("ACCRUAL_ACC_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnRWD_CMP_CYCLE" runat="server" Value='<%# Bind("RWD_CMP_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnRWRD_REL_CYCLE" runat="server" Value='<%# Bind("RWRD_REL_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnACC_CYCLE" runat="server" Value='<%# Bind("ACC_CYCLE")%>' />
                                                     

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                                  <asp:TemplateField HeaderText="Rule Set Code" SortExpression="RulSetCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRulSetCode" runat="server" Text='<%# Bind("RulSetCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                                  <asp:TemplateField HeaderText="Rule Set Description" SortExpression="RuleSetDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetDesc" runat="server" Text='<%# Bind("RuleSetDesc")%>' />
                                                      <asp:HiddenField ID="hdnPARENT_CMPNSTN_CODE" runat="server" Value='<%# Bind("PARENT_CMPNSTN_CODE")%>' />
                                                    <asp:HiddenField ID="hdnPARENT_CNTST_CODE" runat="server" Value='<%# Bind("PARENT_CNTST_CODE")%>' />
                                                   
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--Added by Prity--%>
                                            <asp:TemplateField HeaderText="Parent Rule Set Code" SortExpression="PARENT_RULESECODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPRulSetCode" runat="server" Text='<%# Bind("PARENT_RULESECODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                                  <asp:TemplateField HeaderText="Parent Rule Set Description" SortExpression="PARENT_RULESETDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPRuleSetDesc" runat="server" Text='<%# Bind("PARENT_RULESETDesc")%>' />
                                                     <asp:HiddenField ID="hdnPARENT_KPICODE" runat="server" Value='<%# Bind("PARENT_KPICODE")%>' />
                                                </ItemTemplate>
                                             </asp:TemplateField>

                                            <%--ended by prity--%>
                                            <asp:TemplateField HeaderText="Rule Method" SortExpression="RULE_METHOD">
                                                <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("rule_desc")%>' />
                                                    <asp:HiddenField ID="hdnRuleMethod" runat="server" Value='<%# Bind("RULE_METHOD")%>' />
                                                    <asp:HiddenField ID="hdnMEM_ACH_ACC_CYCLE" runat="server" Value='<%# Bind("MEM_ACH_ACC_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnMEM_RWD_CMP_CYCLE" runat="server" Value='<%# Bind("MEM_RWD_CMP_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnMEM_RWD_REL_CYCLE" runat="server" Value='<%# Bind("MEM_RWD_REL_CYCLE")%>' />
                                                     <asp:HiddenField ID="hdnAchTbl" runat="server" Value='<%# Bind("PTR_TBL")%>' />
                                                    
                                                    <asp:HiddenField ID="hdnOperator" runat="server" Value='<%# Bind("OPERATOR")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category Code" SortExpression="CategoryCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategoryCode" runat="server" Text='<%# Bind("CategoryCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category Description" SortExpression="CategoryDesc">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategoryDesc" runat="server" Text='<%# Bind("CategoryDesc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reward Code" SortExpression="RWRDCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRWRDCode" runat="server" Text='<%# Bind("RWRDCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reward Description" SortExpression="RWRDDesc">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRWRDDesc" runat="server" Text='<%# Bind("RWRDDesc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date" SortExpression="CreatedDt">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreatedDt" runat="server" Text='<%# Bind("CreatedDt")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Weighted Score From" SortExpression="WScore_From">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWScoreFrom" runat="server" Text='<%# Bind("WScore_From")%>' />
                                                    <asp:HiddenField ID="hdnWScoreFrom" runat="server" Value='<%# Bind("WScore_From")%>' />
                                                    <asp:HiddenField ID="hdnRULE_CODE" runat="server" Value='<%# Bind("RuleCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Weighted Score To" SortExpression="RULE_METHOD">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWScoreTo" runat="server" Text='<%# Bind("WScore_To")%>' />
                                                    <asp:HiddenField ID="hdnWScoreTo" runat="server" Value='<%# Bind("WScore_To")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                          
                                            <asp:TemplateField HeaderText="Source Table">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                   
                                            <%--<asp:Label ID="lblAch" Text="Source Table" runat="server" CssClass="control-label" />--%>
                                    
                                               <asp:DropDownList runat="server" ID="ddlAchGv" AutoPostBack="true" 
                                                CssClass="form-control" Width="100%" >
                                           
                                                 </asp:DropDownList>
                           
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Source Value">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                   
                                           <asp:TextBox ID="txtVal" runat="server" CssClass="select2-container form-control"
                                    placeholder="Input Value" Enabled="true" />
                           
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                        
                           </asp:GridView>
                         <div class="row" style="margin-bottom: 5px;">
                            
                        </div>

                                    </ContentTemplate>
                             </asp:UpdatePanel>
                 
                        
                     <div class="row">
                     

                    </div>
                    
                    </div>

                   


                   <%-- end design task grid--%>

                        <div class="row" style="width: 100%;">
                            <div class="col-sm-12" align="center">
                                 <asp:LinkButton ID="lnkAddMP" runat="server" CssClass="btn btn-sample" onclick="lnkAddMP_Click"  Visible="false">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Mapping 
                                </asp:LinkButton>
                                 
                                <asp:LinkButton ID="btncycle" runat="server" CssClass="btn btn-sample" onclick="btncycle_Click"  Visible="false">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Cycle
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample" OnClick="btnSave_Click">
                                    <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-sample" onclick="btnAdd_Click"  Visible="false">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add 
                                </asp:LinkButton>
                                    
                                 <asp:LinkButton ID="btnBlkCatgUpd" runat="server" CssClass="btn btn-sample" onclick="btnBlkCatgUpd_Click"  Visible="false">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Bulk Upload
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCncl" runat="server" CssClass="btn btn-sample" OnClientClick="doCancel();return false;">
                                    <span class="glyphicon glyphicon-remove" style="color: White;"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                       

                  <%--  Audit grid--%>
                        <div id="divAuditTrail" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow-x:scroll;
                            padding: 10px;" class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvAddMst" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" DataKeyNames="CmpstnCode">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Compensation Code" SortExpression="CmpstnCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkCompCode" runat="server" Text='<%# Bind("CmpstnCode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>    <%--1--%>
                                            <asp:TemplateField HeaderText="Contestant Code" SortExpression="CntstCode">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCntstCode" runat="server" Text='<%# Bind("CntstCode")%>' />
                                                    <asp:HiddenField ID="lblCntstCode11" runat="server" Value='<%# Bind("CntstCode")%>' />
                                                    
                                                           
                                                </ItemTemplate>
                                            </asp:TemplateField>       <%--2--%>
                                            <asp:TemplateField HeaderText="Rule Set Code" SortExpression="RuleSetCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetCode" runat="server" Text='<%# Bind("RuleSetCode")%>' />
                                                     <asp:HiddenField ID="hdnACCRUAL_ACC_CYCLE" runat="server" Value='<%# Bind("ACCRUAL_ACC_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnRWD_CMP_CYCLE" runat="server" Value='<%# Bind("RWD_CMP_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnRWRD_REL_CYCLE" runat="server" Value='<%# Bind("RWRD_REL_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnACC_CYCLE" runat="server" Value='<%# Bind("ACC_CYCLE")%>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>     <%-- 3--%>
                                            <asp:TemplateField HeaderText="Rule Set Code" SortExpression="RulSetCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRulSetCode" runat="server" Text='<%# Bind("RulSetCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>       <%-- 4--%>
                                            <asp:TemplateField HeaderText="Rule Set Description" SortExpression="RuleSetDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetDesc" runat="server" Text='<%# Bind("RuleSetDesc")%>' />
                                                     <asp:HiddenField ID="hdnPARENT_CMPNSTN_CODE" runat="server" Value='<%# Bind("PARENT_CMPNSTN_CODE")%>' />
                                                    <asp:HiddenField ID="hdnPARENT_CNTST_CODE" runat="server" Value='<%# Bind("PARENT_CNTST_CODE")%>' />
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>         <%--  5--%>

                                            <%--Added by Prity--%>
                                            <asp:TemplateField HeaderText="Parent Rule Set Code" SortExpression="PARENT_RULESECODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPRulSetCode" runat="server" Text='<%# Bind("PARENT_RULESECODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>      <%-- 6--%>
                                            <asp:TemplateField HeaderText="Parent Rule Set Description" SortExpression="PARENT_RULESETDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPRuleSetDesc" runat="server" Text='<%# Bind("PARENT_RULESETDesc")%>' />
                                                     <asp:HiddenField ID="hdnPARENT_KPICODE" runat="server" Value='<%# Bind("PARENT_KPICODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>        <%-- 7--%>
                                            <%--ended by prity--%>
                                            <asp:TemplateField HeaderText="Rule Method" SortExpression="RULE_METHOD">
                                                <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleMethod" runat="server" Text='<%# Bind("rule_desc")%>' />
                                                    <asp:HiddenField ID="hdnRuleMethod" runat="server" Value='<%# Bind("RULE_METHOD")%>' />
                                                    <asp:HiddenField ID="hdnMEM_ACH_ACC_CYCLE" runat="server" Value='<%# Bind("MEM_ACH_ACC_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnMEM_RWD_CMP_CYCLE" runat="server" Value='<%# Bind("MEM_RWD_CMP_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnMEM_RWD_REL_CYCLE" runat="server" Value='<%# Bind("MEM_RWD_REL_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnAchTbl" runat="server" Value='<%# Bind("PTR_TBL")%>' />
                                                    <asp:HiddenField ID="hdnOperator" runat="server" Value='<%# Bind("OPERATOR")%>' />
                                                  <%--   <asp:HiddenField ID="hdnRUL_CLASS" runat="server" Value='<%# Bind("TRG_CATG_RUL_CLASS")%>' />--%>

                                                </ItemTemplate>
                                            </asp:TemplateField>         <%--8--%>

                                                 <asp:TemplateField HeaderText="Target Rule Class" SortExpression="TRG_CATG_RUL_CLASS">
                                                <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                <ItemTemplate>
                                               <%--      <asp:Label ID="lblTRG_CATG_RUL_CLASS" runat="server" Text='<%# Bind("TRG_CATG_RUL_CLASS_DESC")%>' />--%>
                                                      <asp:HiddenField ID="hdnTRG_CATG_RUL_CLASS" runat="server" Value='<%# Bind("TRG_CATG_RUL_CLASS")%>' />
                                            
                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>   <%-- 9--%>

                                              <asp:TemplateField HeaderText="Reward Rule Class" SortExpression="RWD_RUL_CLASS">
                                                <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                <ItemTemplate>

                                                    <%--<asp:Label ID="lblRWD_RUL_CLASS" runat="server" Text='<%# Bind("RWD_RUL_CLASS_DESC")%>' />        --%>   
                                                     <asp:HiddenField ID="hdnRWD_RUL_CLASS" runat="server" Value='<%# Bind("RWD_RUL_CLASS")%>' />

                                                    <asp:HiddenField ID="hdnIS_STR_RUL_FRM_FLAG" runat="server" Value='<%# Bind("IS_STR_RUL_FRM_FLAG")%>' />
                                                     <asp:HiddenField ID="hdnIS_STR_RUL_FRM" runat="server" Value='<%# Bind("IS_STR_RUL_FRM")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>    <%--10--%>
                                            <asp:TemplateField HeaderText="Category Code" SortExpression="CategoryCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategoryCode" runat="server" Text='<%# Bind("CategoryCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>        <%--11--%>
                                            <asp:TemplateField HeaderText="Category Description" SortExpression="CategoryDesc">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategoryDesc" runat="server" Text='<%# Bind("CategoryDesc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>          <%-- 12--%>
                                            <asp:TemplateField HeaderText="Reward Code" SortExpression="RWRDCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRWRDCode" runat="server" Text='<%# Bind("RWRDCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>        <%--13--%>
                                            <asp:TemplateField HeaderText="Reward Description" SortExpression="RWRDDesc">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRWRDDesc" runat="server" Text='<%# Bind("RWRDDesc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>         <%-- 14--%>
                                            <asp:TemplateField HeaderText="Date" SortExpression="CreatedDt">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreatedDt" runat="server" Text='<%# Bind("CreatedDt")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>       <%-- 15--%>

                                              <asp:TemplateField HeaderText="Weighted Score From" SortExpression="WScore_From">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWScoreFrom" runat="server" Text='<%# Bind("WScore_From")%>' />
                                                    <asp:HiddenField ID="hdnWScoreFrom" runat="server" Value='<%# Bind("WScore_From")%>' />
                                                    <asp:HiddenField ID="hdnRULE_CODE" runat="server" Value='<%# Bind("RuleCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>      <%-- 16--%>

                                             <asp:TemplateField HeaderText="Weighted Score To" SortExpression="RULE_METHOD">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWScoreTo" runat="server" Text='<%# Bind("WScore_To")%>' />
                                                    <asp:HiddenField ID="hdnWScoreTo" runat="server" Value='<%# Bind("WScore_To")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>         <%--  17--%>

                                            <asp:TemplateField HeaderText="Member Cycle" SortExpression="RULE_METHOD">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleCode" runat="server" Text='<%# Bind("RuleCode")%>' />
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>              <%--18--%>

                                              <asp:TemplateField HeaderText="Linkage KPI" SortExpression="LNKD_DRVD_KPI_CODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLNKD_DRVD_KPI_DESC" runat="server" Text='<%# Bind("LNKD_DRVD_KPI_DESC")%>' />
                                                    <asp:HiddenField ID="hdnLNKD_DRVD_KPI_CODE" runat="server" Value='<%# Bind("LNKD_DRVD_KPI_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>             <%-- 19--%>

                                            <asp:TemplateField HeaderText="Rule Complexity" SortExpression="RUL_SET_CMPLXTY">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRUL_SET_CMPLXTY_DESC" runat="server" Text='<%# Bind("RUL_SET_CMPLXTY_DESC")%>' />
                                                    <asp:HiddenField ID="hdnRUL_SET_CMPLXTY" runat="server" Value='<%# Bind("RUL_SET_CMPLXTY")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>                <%--20--%>

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>                 <%--  21--%>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" OnClick="lnkDelete_Click"
                                                        OnClientClick="return confirm('Are you sure you want delete'); return true;"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>                <%--  22--%>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                        <br />
                        <div id="div11" visible="true" runat="server" class="pagination">
                            <center>
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
                            </center>
                        </div>
                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        
                        
                </div>

                 <%--<asp:Panel runat="server" Height="550px" Width="1000px" ID="pnlMdl" display="none"
        Style="text-align: center;">
        <iframe runat="server" id="ifrmMdlPopup" width="100%" frameborder="0" display="none"
            style="height: 200%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="ModalPopupPanel">
    </ajaxToolkit:ModalPopupExtender>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>



    <asp:Panel runat="server" Height="483px" Width="863px" ID="Panel1" display="none" Style="text-align: center; padding: 5px; left: -22px; top: -4px;"
        CssClass="panel panel-success">
        <iframe runat="server" id="Iframe1" scrolling="yes" width="80%" frameborder="0"
            display="none" style="height: 80%;"></iframe>


    </asp:Panel>
    <asp:Label runat="server" ID="Label10" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlPopBIDHybrid"
        DropShadow="false" TargetControlID="Label10" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg" X="-4" Y="0">
    </ajaxToolkit:ModalPopupExtender>


</asp:Content>

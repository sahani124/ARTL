<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/iFrame.master" CodeFile="PopVarSU.aspx.cs"
    Inherits="Application_ISys_Saim_PopVarSU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <%--  <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
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


        function doCancel() {

            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            window.parent.document.getElementById("btnKPI").click();
        }

        function ShowReqDtl1(divName, btnName) {
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    //  objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

    </script>
    <style type="text/css">
        .CenterAlign {
            text-align: center !important;
        }

        .LeftAlign {
            text-align: left !important;
        }

        .RightAlign {
            text-align: right !important;
        }


        . /*gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space:nowrap;
        }*/
        .new_text_new {
            color: #066de7;
        }

        .divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }

        .disablepage {
            display: none;
        }
    </style>
    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode ="Conditional" >
            <ContentTemplate>
                <asp:HiddenField ID="hdnCount" runat="server" />
                <asp:HiddenField ID="hdnCycle" runat="server" />
                <asp:HiddenField ID="hdnYrTyp" runat="server" />
                <asp:HiddenField ID="hdnBusiCode" runat="server" />
                <asp:HiddenField ID="hdnCycTyp" runat="server" />
                <asp:HiddenField ID="HiddenField6" runat="server" />
                   <asp:HiddenField ID="hdnVEREFFFROM" runat="server" />
                      <asp:HiddenField ID="hdnVEREFFTO" runat="server" />
                         <asp:HiddenField ID="hdnVERSION" runat="server" />

            <div style="height:400px;overflow:auto;width:97%;">
                <div id="div1" runat="server" style="" class="panel">
                    <div id="divqualhdrcollapse" runat="server" class="panel-heading" style="width: 96%;"
                        onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divqual','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblhdr" Text="Variable Commission Rate Setup"  runat="server" />
                            </div>
                            <div class="col-sm-2">
                                 <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 3/5/2018--%>
                            </div>
                        </div>
                    </div>
                    <div id="divqual" class="panel-body" style="display:none;" runat="server">

                     <div id="divrul" runat="server"></div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label1" Text="Business Type" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label13" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCompCodeVal" runat="server" CssClass="form-control-static new_text_new" style="display:none"></asp:Label>
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server"  >
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="DDlBusinessType" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" 
                                            onselectedindexchanged="ddlRuleSetKy_SelectedIndexChanged">

                                              <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="NEW BUSINESS" Value="N"></asp:ListItem>
                                    <asp:ListItem Text="RENEWAL BUSINESS" Value="RE"></asp:ListItem>
                                    <asp:ListItem Text="TOP UP BUSINESS" Value="RO"></asp:ListItem>
                                        </asp:DropDownList>
                                       <asp:HiddenField ID="hdnBusType" runat="server"/>
                                       <asp:HiddenField ID="hdnRWD_RUL_CODE_p" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label2" Text="Product Category (LOB)" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label14" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCntstCdVal" runat="server" CssClass="form-control-static new_text_new" style="display:none"></asp:Label>

                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList  ID="ddlPrdClsCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    OnSelectedIndexChanged="ddlPrdClsCode_SelectedIndexChanged">
                                        </asp:DropDownList>
                                       
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                         <div id="Div5"  runat="server" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label11" Text="Product Code" runat="server" CssClass="control-label"/>
                                <asp:Label ID="Label16" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlProduct" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" 
                                            onselectedindexchanged="ddlRuleSetKy_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                              <%--  <asp:Label ID="Label12" Text="Product Name" runat="server" CssClass="control-label"/>
                                <asp:Label ID="Label17" Text="*" runat="server" Style="color: Red;" />--%>
                                 <asp:Label ID="Label9" Text="Plan Code" runat="server" CssClass="control-label"/>
                            </div>
                            <div class="col-sm-3">
                                <%--<asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextProductName" runat="server" CssClass="select2-container form-control" /></ContentTemplate>
                                </asp:UpdatePanel>  --%>
                                 <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextPlanCode" runat="server" Text="ALL" Enabled="false" CssClass="select2-container form-control" /></ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                       
                        <div  runat="server" class="row" style="margin-bottom: 5px;">


                        <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label12" Text="Frequency" runat="server" CssClass="control-label"/>
                                <asp:Label ID="Label18" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                 

                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList  ID="ddlfreguency" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="4" OnSelectedIndexChanged="ddlfreguency_SelectedIndexChanged">
                                        </asp:DropDownList>

                                        <asp:DropDownList  ID="ddlRuleSetKy" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="4" OnSelectedIndexChanged="ddlfreguency_SelectedIndexChanged" style="display:none;">
                                        </asp:DropDownList>
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>


                              <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label7" Text="Pay Mode" runat="server" CssClass="control-label"/>
                                <asp:Label ID="Label24" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlPayMode"  runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                   >

                                    <asp:ListItem Text="CASH" Value="CASH">
                                    </asp:ListItem>
                                    <asp:ListItem Text="CHEQUE" Value="CHEQUE">
                                    </asp:ListItem>
                                    <asp:ListItem Text="ECS" Value="ECS">
                                    </asp:ListItem>
                                    <asp:ListItem Text="NEFT" Value="NEFT">
                                    </asp:ListItem>
                                    <asp:ListItem Text="ALL" Value="ALL" Selected="True" >
                                    </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                           
                            
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblrlSetKy" Text="Rule Set Key" runat="server" CssClass="control-label" style="display:none;" />
                                  <asp:Label ID="Label3" Text="Policy Term From" runat="server" CssClass="control-label" />
                                  <asp:Label ID="Label19" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtRuleSetKey" runat="server" CssClass="select2-container form-control"
                                    placeholder="Rule Set Key" Style="display:none;" />

                                     <asp:TextBox ID="TxtPolTermFrom" runat="server" style="text-align:right;"  Text="1" CssClass="select2-container form-control"
                                    placeholder="Policy Term From"  />
                            </div>
                            <div class="col-sm-3" style="text-align: left">


                                <asp:Label ID="lblRuleSetKeyDesc" Text="Policy Term To" runat="server"
                                    CssClass="control-label"  style="display:none;"/>
                                    <asp:Label ID="Label10" Text="Policy Term To" runat="server"
                                    CssClass="control-label"  />
                                <asp:Label ID="lblRuleSetKeyDesc_s" Text="*" runat="server" Style="color: Red;display:none;" />
                                <asp:Label ID="Label20" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3" style="display:flex;">
                                <asp:TextBox ID="txtRuleSetKeyDsc" Style="display:none;" runat="server" CssClass="select2-container form-control"
                                    placeholder="Rule Set Key" />
                                    <asp:LinkButton ID="lnkrwddsc" runat="server" Style="display:none;" CssClass="btn btn-primary">
                                    <span style="color: White;"></span> ...
                                </asp:LinkButton>
                                <asp:TextBox ID="TxtPolTermTo" runat="server"  Text="1" style="text-align:right;" CssClass="select2-container form-control"
                                    placeholder="Policy Term To"  />


                                    <asp:TextBox ID="txtRulSetDsc" runat="server" CssClass="select2-container form-control"
                                    placeholder="Policy Term To"  style="display:none;" />

                                    


                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars=" ,&,_,<,=,>/"
                                    FilterMode="ValidChars" TargetControlID="txtRuleSetKeyDsc">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>

                        <div id="Div2"  runat="server" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label4" Text="Premium From" runat="server" CssClass="control-label"/>
                                <asp:Label ID="Label21" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                       <%-- <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" 
                                            onselectedindexchanged="ddlRuleSetKy_SelectedIndexChanged">
                                        </asp:DropDownList>--%>

                                        <asp:TextBox ID="TxtPremiumFrom" runat="server"  Text="0.00" style="text-align:right;" CssClass="select2-container form-control"
                                    placeholder="Premium From"  />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label5" Text="Premium To" runat="server" CssClass="control-label"/>
                                <asp:Label ID="Label22" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TxtPremiumTo" style="text-align:right;" runat="server" CssClass="select2-container form-control" 
                                            Text="9999999.00" placeholder="Premium To" /></ContentTemplate>
                                </asp:UpdatePanel>  
                            </div>
                        </div>



                         <div id="Div7"  runat="server" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label17" Text="Renewal Year From" runat="server" CssClass="control-label"/>
                                <asp:Label ID="Label26" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                    <ContentTemplate>
                                       <%-- <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" 
                                            onselectedindexchanged="ddlRuleSetKy_SelectedIndexChanged">
                                        </asp:DropDownList>--%>

                                        <asp:TextBox ID="TextBox1" runat="server"  Text="0.00" style="text-align:right;" 
                                            CssClass="select2-container form-control"
                                    placeholder="Renewal Year From"  />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label27" Text="Renewal Year To" runat="server" CssClass="control-label"/>
                                <asp:Label ID="Label28" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextBox2" style="text-align:right;" runat="server" CssClass="select2-container form-control" 
                                            Text="1" placeholder="Renewal Year To" /></ContentTemplate>
                                </asp:UpdatePanel>  
                            </div>
                        </div>


                        <div id="Div3"  runat="server" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label6" Text="Premium Type" runat="server" CssClass="control-label"/>
                                <asp:Label ID="Label23" Text="*" runat="server" Style="color: Red;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server"  Enabled="false" ID="ddlPremiumType" AutoPostBack="true" CssClass="select2-container form-control">
                                         <asp:ListItem Text="ALL" Value="ALL" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="COLLECTED PREMIUM" Value="CP">
                                    </asp:ListItem>
                                                                                   
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblType" Text="Unit Type" runat="server" CssClass="control-label col-md" />
                                        <asp:Label ID="lblType_" Text="*" runat="server" ForeColor="red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                    CellSpacing="10" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdnType" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                          
                        </div>

                       

                                                   
                        <div class="row" style="margin-bottom: 5px;">


                         <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblKPICode" Text="KPI Code" runat="server" CssClass="control-label col-md" />
                                        <asp:Label ID="lblKPICode_" runat="server" ForeColor="red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlKPICode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                    Enabled="false">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdnKPICode_p" runat="server" />
                                            </ContentTemplate>
                                           
                                        </asp:UpdatePanel>
                                    </div>
                            <div class="col-sm-3" style="text-align: left">
                     <%--           <asp:Label ID="lblValue" Text="Value" runat="server" CssClass="control-label col-md"  st/>
                                <asp:Label ID="lblValue_" Text="*" runat="server" ForeColor="red" />--%>

                                <asp:Label ID="Label8" Text="Value" runat="server" CssClass="control-label"/>
                                <asp:Label ID="Label25" Text="*" runat="server" Style="color: Red;text-align:right;" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtValue" runat="server" CssClass="select2-container form-control" style="display:none"
                                    placeholder="Value" MaxLength="12" /> <%--onkeypress="return isNumberKey(event,this);"--%>

                                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TxtCommissionRate" runat="server" CssClass="select2-container form-control" OnTextChanged="TxtCommissionRate_TextChanged" placeholder="Value" AutoPostBack="true" /></ContentTemplate>
                                </asp:UpdatePanel>  

                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterType="Numbers,Custom" FilterMode="ValidChars" ValidChars=".,-" TargetControlID="txtValue">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:LinkButton ID="lnkSetFrml" Text="Set Formula" runat="server" Visible="false"
                                    OnClick="lnkSetFrml_Click" />
                            </div>


                            <div class="col-sm-3" style="text-align: left">
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblRate" Text="Rate" runat="server" CssClass="control-label col-md"
                                            Visible="false" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRate" runat="server" CssClass="select2-container form-control"
                                            placeholder="Rate" Visible="false" /></ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>


                        <div id="Div4"  runat="server" class="row" style="margin-bottom: 5px;">
                           
                            <div class="col-sm-3" >
                               <%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="select2-container form-control"  /></ContentTemplate>
                                </asp:UpdatePanel> --%> 
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                 <asp:CheckBox ID="chkCyc" runat="server" AutoPostBack="true" />
                                <asp:Label ID="lbl12" Text="Apply to all Cycles" runat="server" />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        


                        <div class="row" style="width: 100%;">
                            <div class="col-sm-12" align="center">
                             <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample" OnClick="btnSave_Click">
                                    <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sample" OnClick="btnUpdate_Click" Visible="false">
                                    <span class="glyphicon glyphicon-floppy-disk" style="color: White;" ></span> Update
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCncl" runat="server" CssClass="btn btn-sample" OnClientClick="doCancel();return false;">
                                    <span class="glyphicon glyphicon-remove" style="color: White;"></span> Cancel
                                </asp:LinkButton>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                         

                        <%-- </div>--%>
                      

                    </div>



                </div>


                <div  style="" class="panel">
                
                
                     <div id="div6" runat="server" class="panel-heading" style="width: 96%;"
                        onclick="ShowReqDtl1('divqual2','Span1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label15" Text="Variable Commission Rate Details" runat="server"  />
                            </div>
                            <div class="col-sm-2">
                                <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 3/5/2018--%>
                            </div>
                        </div>
                    </div>


                    <div  id="divqual2"  class="">
                    
                      <div id="divAuditTrail" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                            padding: 10px;" class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel14" runat="server" RenderMode="Inline"  UpdateMode ="Conditional" >
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                 </Triggers>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                 </Triggers>
                                <ContentTemplate>
                                   
                                    <asp:GridView ID="gvAddMst" AutoGenerateColumns="false" runat="server"  Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" >
                                        <RowStyle CssClass="GridViewRow"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label24" Text="No variable commission rate details" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                    <Columns>
                                                                               

                                             <asp:TemplateField HeaderText="Business Type" SortExpression="BusType">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBusType" runat="server" Text='<%# Bind("BusType")%>' />
                                                    <asp:HiddenField ID="lblBusType1" runat="server" Value='<%# Bind("BusTypeCode")%>' />
                                                    <asp:HiddenField ID="hdnRWD_RUL_CODE" runat="server" Value='<%# Bind("RWD_RUL_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Product Code" SortExpression="ProdCode">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProdCode" runat="server" Text='<%# Bind("ProdCodeDesc")%>' />
                                                    <asp:HiddenField ID="lblProdCode11" runat="server" Value='<%# Bind("ProdCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            
                                             <asp:TemplateField HeaderText="Plan Code" SortExpression="PlanCode">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlanCode" runat="server" Text='<%# Bind("PlanCode")%>' />
                                                    <asp:HiddenField ID="lblPlanCode11" runat="server" Value='<%# Bind("PlanCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Product Category" SortExpression="ProdCategory">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProdCategory" runat="server" Text='<%# Bind("ProdCategoryDesc")%>' />
                                                    <asp:HiddenField ID="lblProdCategory11" runat="server" Value='<%# Bind("ProdCategory")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Frequency" SortExpression="Frequency">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFrequency" runat="server" Text='<%# Bind("FrequencyDesc")%>' />
                                                    <asp:HiddenField ID="lblFrequency11" runat="server" Value='<%# Bind("Frequency")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Policy Term From" SortExpression="PolicyTermFrom">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle CssClass="CenterAlign" Width="20px" />
                                                <ItemTemplate >
                                                    <asp:Label ID="lblPolicyTermFrom" runat="server" Text='<%# Bind("PolicyTermFrom")%>' />
                                                    <asp:HiddenField ID="lblPolicyTermFrom11" runat="server" Value='<%# Bind("PolicyTermFrom")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Policy Term To" SortExpression="PolicyTermTo">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle CssClass="CenterAlign"  Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPolicyTermTo" runat="server" Text='<%# Bind("PolicyTermTo")%>' />
                                                    <asp:HiddenField ID="lblPolicyTermTo11" runat="server" Value='<%# Bind("PolicyTermTo")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Premium Term From" SortExpression="PremiumFrom">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle  CssClass="RightAlign"  Width="20px" />
                                                <ItemTemplate >
                                                    <asp:Label ID="lblPremiumFrom" runat="server" Text='<%# Bind("PremiumFrom")%>' />
                                                    <asp:HiddenField ID="lblPremiumFrom11" runat="server" Value='<%# Bind("PremiumFrom")%>' />
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Premium To" SortExpression="PremiumTo">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle  CssClass="RightAlign" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPremiumTo" runat="server" Text='<%# Bind("PremiumTo")%>' />
                                                    <asp:HiddenField ID="lblPremiumTo11" runat="server" Value='<%# Bind("PremiumTo")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Premium Type" SortExpression="PremiumType">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPremiumType" runat="server" Text='<%# Bind("PremiumType")%>' />
                                                    <asp:HiddenField ID="lblPremiumType11" runat="server" Value='<%# Bind("PremiumType")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Commission Rate" SortExpression="CommRate">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle CssClass="RightAlign" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCommRate" runat="server" Text='<%# Bind("CommRate")%>' />
                                                    <asp:HiddenField ID="lblCommRate11" runat="server" Value='<%# Bind("CommRate")%>' />
                                                     <asp:HiddenField ID="hdnTYPE" runat="server" Value='<%# Bind("TYPE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Pay Mode" SortExpression="PayMode">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPayMode" runat="server" Text='<%# Bind("PayMode")%>' />
                                                    <asp:HiddenField ID="lblPayMode11" runat="server" Value='<%# Bind("PayMode")%>' />
                                                    <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("BASED_ON_KPI")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" OnClick="lnkDelete_Click"
                                                        OnClientClick="return confirm('Are you sure you want delete'); return true;"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                               
                            </asp:UpdatePanel>
                        </div>
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
                
                </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>

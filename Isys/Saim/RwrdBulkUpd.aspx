<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="RwrdBulkUpd.aspx.cs" Inherits="Application_Isys_Saim_RwrdBulkUpd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
     <script type="text/javascript" src="../../../Scripts/jquery.min.js"></script>
    <script type="text/javascript">

        $("[src*=btnexp]").live("click", function () {
            debugger;
            $(this).closest("tr").after("<tr><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../images/btncol.png");

        });
        $("[src*=btncol]").live("click", function () {
            debugger;
            $(this).attr("src", "../../../images/btnexp.png");
            $(this).closest("tr").next().remove();
        });
        function minmax(value, min, max) {
            //if (parseInt(value) < min || isNaN(parseInt(value)))
            if (parseInt(value) > max) {
                alert("Please enter an integer  between  1 and 6");
                return false;
            }
            else {
                return true;
            }
        }

        function chckddl(min, max) {
            //if (parseInt(value) < min || isNaN(parseInt(value)))
            if (parseInt(min) > max) {
                alert("From should be smaller");
                return false;
            }
            else {
                return true;
            }
        }

        function validateGenerate() {
            debugger;

            var ddlRuleSetCode = $('#<%=ddlRuleSetCode.ClientID %>');
            var ddlRwdDesc = $('#<%=ddlRwdDesc.ClientID %>');
            var ddlType = $('#<%=ddlType.ClientID %>');
            var ddlKPICode = $('#<%=ddlKPICode.ClientID %>');

            if (ddlRuleSetCode.val().toLowerCase() == "") {
                alert("Please select Rule Set Code!");
                return false;
            };
           
            if (ddlRwdDesc.val().toLowerCase() == "") {
                alert("Please select Reward Description!");
                return false;
            }
            if (ddlType.val().toLowerCase() == "") {
                alert("Please select Unit Type!");
                return false;
            }
            if (ddlType.val().toLowerCase() != "") {
                if (ddlType.val().toLowerCase() == "1003" || ddlType.val().toLowerCase() == "1004" || ddlType.val().toLowerCase() == "1005")
                {
                    if (ddlKPICode.val().toLowerCase() == "") {
                        alert("Please select KPI Code!");
                        return false;
                    };
                }
            }
           
            return true;
        }

        function validate() {
            debugger;

            var ddlRuleSetCode = $('#<%=ddlRuleSetCode.ClientID %>');
            var ddlFrom = $('#<%=ddlFrom.ClientID %>');
            var ddlTo = $('#<%=ddlTo.ClientID %>');
            var DropDownList1 = $('#<%=DropDownList1.ClientID %>');
            var DropDownList2 = $('#<%=DropDownList2.ClientID %>');

            if (ddlRuleSetCode.val().toLowerCase() == "") {
                alert("Please select Rule Set Code!");
                return false;
            };
            //if (ddlFrom.val().toLowerCase() == "") {
            //    alert("Please select Member Month From!");
            //    return false;
            //}
            //if (ddlTo.val().toLowerCase() == "") {
            //    alert("Please select Member Month To!");
            //    return false;
            //}
            //if (DropDownList1.val().toLowerCase() == "") {
            //    alert("Please select Cycle From!");
            //    return false;
            //}
            //if (DropDownList2.val().toLowerCase() == "") {
            //    alert("Please select Cycle To!");
            //    return false;
            //}
            return true;
        }


        function funPopupDataSynchHybrid(cmpcode, cnstCode) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlPopBIDHybrid").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "PopBulkCatgUpd.aspx?CmpCode=" + cmpcode + "&cnstCode=" + cnstCode + "&btchUpload=" + upd1 + "&mdlpopup=mdlPopBIDHybrid";
        }

        function getUrlParameter(name) {
            name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
            var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
            var results = regex.exec(location.search);
            return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
        };


        function fnCallPOP() {
            debugger;
            var ddlRuleSetCode = $('#<%=ddlRuleSetCode.ClientID %>');
            if (ddlRuleSetCode.val().toLowerCase() == "") {
                alert("Please select Rule Set Code!");
                return false;
            };
            var cmpCode = getUrlParameter('CmpCode');
            var cntCode = getUrlParameter('CntstCode');
            var ruleSet = ddlRuleSetCode.val().toLowerCase();
            var strContent = "ctl00_ContentPlaceHolder1_";
            
            $find("mdlPopBIDHybrid").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = ("RwrdBulkFileUpload.aspx?CmpCode=" + cmpCode + "&cnstCode=" + cntCode + "&btchUpload=" + "upd1" + "&RuleSetKey=" + ruleSet + "&mdlpopup=mdlPopBIDHybrid");
            // document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "PopBulkCatgUpd.aspx";
            return false;
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <center>
        <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel">
            <div id="Div6" runat="server" class="panel-heading" >
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
<%--                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;commennted by ajay sawant 25/4/2018--%>
                        <asp:Label ID="lblhdr" Text="" Font-Size="19px" runat="server" />
                    </div>
                    <div class="col-sm-2">
                             <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>

                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" style="width: 96%;" class="panel-body">

               <div class="row" style="margin-bottom: 5px; display:none">
                    <div class="col-sm-3" style="text-align: left;font-weight:bold;">
                        <asp:Label ID="Label4" Text="Rule Set" runat="server" CssClass="control-label" />
                    </div>
                </div>
               <div class="row" style="margin-bottom: 5px;">
                 <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label5" Text="Rule Set Code" runat="server" CssClass="control-label" />
                    </div>
                  <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlRuleSetCode" runat="server" AutoPostBack="true"  CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
               </div>

               <div class="row" style="margin-bottom: 5px;display:none;">
                    <div class="col-sm-3" style="text-align: left;font-weight:bold;">
                        <asp:Label ID="lblSlabs" Text="SLABS" runat="server" CssClass="control-label" />
                    </div>
                </div>
               <div class="row" style="margin-bottom: 5px;display:none;">
                 <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblcount" Text="Count" runat="server" CssClass="control-label" />
                    </div>
                 <div class="col-sm-3" style="display:none;">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtcount" runat="server" MaxLength="1" CssClass="form-control" TabIndex="1"
                                  placeholder="Count" />
                                <asp:RangeValidator ID="Value2RangeValidator" ControlToValidate="txtcount"  
             Type="Integer" MinimumValue="1" MaximumValue="6" Display="Dynamic"  
             ErrorMessage="Please enter an integer  between  1 and 6.<br />"
                                    runat="server"/>  
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
               </div>

               <%-- <div style="display:none;">--%>
               <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left;font-weight:bold; display:none">
                        <asp:Label ID="Label6" Text="Reward details" runat="server" CssClass="control-label" />
                    </div>
                </div>
               <div class="row" style="margin-bottom: 5px;">
                  <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblRwdType" runat="server" Text="Reward Type" CssClass="control-label col-md" />
                                        <asp:Label ID="lblRwdType_" Text="*" runat="server" ForeColor="red" />
                                    </div>
                  <div class="col-sm-3">
                  <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                     <ContentTemplate>
                                                <asp:DropDownList ID="ddlRwdType"   onchange="FunddlRwdTypeChange()" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                  </asp:UpdatePanel>
               </div>
                  <div class="col-sm-3" style="text-align: left;display:none;">
                                <asp:Label ID="lblDependKPIrewardFlag" runat="server" Text="Depend on" CssClass="control-label col-md" />
                                    </div>
                  <div class="col-sm-3" style="display:none;">
                               <asp:DropDownList ID="ddlDependKPIRewardFlag" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDependKPIRewardFlag_SelectedIndexChanged" CssClass="select2-container form-control"
                                            Visible="true" >
                                    <asp:ListItem Value="">--SELECT--</asp:ListItem>
                                    <asp:ListItem Value="N">None</asp:ListItem>
                                    <asp:ListItem Value="A">Achievements</asp:ListItem>
   
                                   
                                                </asp:DropDownList>
                                    </div>
               </div>
                <br />
               <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRwdDesc1" runat="server" Text="Reward Description" CssClass="control-label col-md" />
                                <asp:Label ID="lblRwdDesc1_" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRwdDesc1" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" OnTextChanged="txtRwdDesc1_TextChanged" />
                                        <asp:DropDownList ID="ddlRwdDesc" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            Visible="false" OnSelectedIndexChanged="ddlRwdDesc_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left;display:none;">
                                <asp:Label ID="lblRwdCode" runat="server" Text="Reward Code" CssClass="control-label col-md" />
                            </div>
                            <div class="col-sm-3" style="display:none;">
                                <asp:TextBox ID="txtRwdCode" runat="server" CssClass="select2-container form-control" />
                            </div>
                           
                        </div>
                <br />

              <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblType" Text="Unit Type" runat="server" CssClass="control-label col-md" />
                                        <asp:Label ID="lblType_" Text="*" runat="server" ForeColor="red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                    CellSpacing="10" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblKPICode" Text="KPI Code" runat="server" CssClass="control-label col-md" />
                                        <asp:Label ID="lblKPICode_" runat="server" ForeColor="red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlKPICode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                    Enabled="false"  >
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
               
             
               <div class="row" style="margin-bottom: 5px;display:none;">
                    <div class="col-sm-3" style="text-align: left;font-weight:bold;">
                        <asp:Label ID="lblMemMonth" Text="Member Month" runat="server" CssClass="control-label" />
                    </div>
                </div>
               <div class="row" style="margin-bottom: 5px;display:none;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblFrom" Text="From" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlFrom" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="To" Text="To" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlTo" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
             
               

               <div class="row" style="margin-bottom: 5px;display:none">
                    <div class="col-sm-3" style="text-align: left;font-weight:bold;">
                        <asp:Label ID="Label1" Text="Cycles" runat="server" CssClass="control-label" />
                    </div>
                </div>
               <div class="row" style="margin-bottom: 5px;display:none">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label2" Text="From" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label3" Text="To" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                  <%--  </div>--%>

               <div id="tblrwdtrg" runat="server" class="row" style="margin-top: 12px;">
                                    <div class="col-sm-12" align="center">
                                     
                                        <%--//Added By DAKSH 21012019--%>
                                        <asp:LinkButton ID="lnlSearchbyRuleSet"  runat="server" OnClick="lnlSearchbyRuleSet_Click" OnClientClick="javascript : return validate();"   CssClass="btn btn-sample" Visible="false" >
                                         <span class="glyphicon glyphicon-search BtnGlyphicon" style="color: White;"></span> Search
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="BtnAdd" OnClick="BtnAdd_Click"  runat="server"  OnClientClick="javascript : return validateGenerate();"  CssClass="btn btn-sample" Visible="true" >
                                         <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                        </asp:LinkButton>


                                        
                                    
                                    </div>
                                </div>

                <div id="div9" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow:auto"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" 
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable"   >
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            
                                            <asp:TemplateField HeaderText="Rule Set Code" SortExpression="RuleSetCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetCode1" runat="server" Text='<%# Bind("RuleSetCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reward Type" SortExpression="RwrdType">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetDesc1" runat="server" Text='<%# Bind("RwrdType")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reward Description" SortExpression="RewardDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleMethod1" runat="server" Text='<%# Bind("RewardDesc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--Added by Prity--%>
                                            <asp:TemplateField HeaderText="Unit Type" SortExpression="UnitType">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPARENT_CMPNSTN_CODE1" runat="server" Text='<%# Bind("UnitType")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="KPI Description" SortExpression="KPIDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPARENT_CNTST_CODE1" runat="server" Text='<%# Bind("KPIDesc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                          
                                            
                                            </Columns>
                                          </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                                  
                                  </div>

                <div class="col-sm-12" align="center">
                                        <div id="div3" runat="server" style="text-align: left;padding-left: 40%;display:none;">
                                <asp:CheckBox ID="CheckBox1" Checked="false"  runat="server"  CssClass="checkbox"/>
                                <asp:Label Text="Same Categories Code For all Cycles" CssClass="control-label" runat="server" style="padding-left: 5px;" />
                            </div>
                                         <asp:LinkButton ID="BtnGenerate" Visible="false" OnClick="BtnGenerate_Click"  runat="server"  CssClass="btn btn-sample" ><%--OnClick="lnkAddRuleMst_Click"--%>
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Generate
                                        </asp:LinkButton>
                                        </div>

                <div id="div11" runat="server">
                                <h3 class="form-section" style="text-align: left;">
                                        <img id="ImageKPITrgs1" src="../../../images/Key_Performance_Indicator_targets.png" style="border-width:0px;width: 35px;margin-top: 6px;margin-bottom:10px;height: 35px;"/>

                                    Key Performance Indicator Rewards</h3>
                <div id="div10" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow:auto"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Width="100%" 
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable"   >
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            
                                            <asp:TemplateField HeaderText="Rule Set Code" SortExpression="RULE_SET_KEY">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetCode1" runat="server" Text='<%# Bind("RULE_SET_KEY")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Cycle Description" SortExpression="CycleDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetCode1" runat="server" Text='<%# Bind("CycleDesc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Category Description" SortExpression="CatDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetCode1" runat="server" Text='<%# Bind("CatDesc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reward Type Description" SortExpression="RewardTypeDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleMethod1" runat="server" Text='<%# Bind("RewardTypeDesc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--Added by Prity--%>
                                            <asp:TemplateField HeaderText="Reward Description" SortExpression="RWRD_DESC01">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPARENT_CMPNSTN_CODE1" runat="server" Text='<%# Bind("RWRD_DESC01")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Unit Type Description" SortExpression="RewardDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPARENT_CNTST_CODE1" runat="server" Text='<%# Bind("RewardDesc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                          
                                            
                                            </Columns>
                                          </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                                  
                 </div>
                <div id="div8" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevrwdrul" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="true" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevrwdrul_Click" />
                                                            <asp:TextBox runat="server" ID="txtPageRwdRul" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnextrwdrul" Text=">" CssClass="form-submit-button" runat="server"
                                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                                Enabled="true" OnClick="btnnextrwdrul_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                    </div>

                <div id="Div13" runat="server" class="row" style="margin-top: 12px;">
                                    <div class="col-sm-12" align="center">
                                     
                                        <asp:LinkButton ID="BtnDownloadExcel" OnClick="BtnDownloadExcel_Click" runat="server" OnClientClick="javascript : return validateGenerate();" CssClass="btn btn-sample" >
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span>Download
                                        </asp:LinkButton>
                                        <button id="btnUPLOADpop" type="button" class="btn btn-sample" onclick="javascript: return fnCallPOP();">
                                            <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Bulk Upload
                                        </button>
                                          <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="btn btn-sample" CausesValidation="False"
                                     OnClick="btn_Cancel_Click" TabIndex="33">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color:white"> </span> Cancel
                                 </asp:LinkButton>

                                       
                                    
                                    </div>
                                </div>

               <div id="divchkRwd" runat="server" style="display:none; text-align: left; padding-left: 42px;" >
                                <asp:CheckBox ID="chkRwd" runat="server" CssClass="checkbox" />
                                <asp:Label Text="Please check for setting rewards rule" runat="server" style="padding-left: 5px;"/>
                            </div>
               <div id="divRwd" runat="server" style="width:96%;display:none;" class="panel-body">
                    <div id="divKPI" runat="server" >
                               <h3 class="form-section" style="text-align: left;">
                               <img id="ImageKPI" src="../../../images/Key_Performance_Rule_Icon.png" style="border-width:0px;width: 35px;margin-top: 6px;margin-bottom:10px;height: 35px;"/>
                                   
                                    Key Performance Indicators</h3>
                                <div id="div4" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow:auto"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvAddMst" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" DataKeyNames="RuleSetCode"  OnRowDataBound="gvAddMst_RowDataBound" >
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField>
                                                    <ItemTemplate>
                                                <img alt="" id="img2"  style="cursor: pointer" src="../../../images/btnexp.png" />
                                                <div id="divChild" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                    class="table-scrollable,divBorder1">
                                                    <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="dgReward" runat="server" CssClass="footable" AllowSorting="True"
                                                OnSorting="dgReward_Sorting" AllowPaging="true" AutoGenerateColumns="false"   OnRowDataBound="dgReward_RowDataBound" >
                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />                                                               
                                                                 <EmptyDataTemplate>
                                            <asp:Label ID="Label15" Text="No KPI have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>


                                                    <Columns>
                                                        
                                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnKpiOrg" Value='<%# Bind("KPI_ORIGIN")%>' runat="server">

                                                            </asp:HiddenField>
                                                             <asp:HiddenField ID="hdnRuleCode" Value='<%# Bind("RULE_CODE")%>' runat="server"/>
                                                            <asp:HiddenField ID="hdnRuleSetKy" Value='<%# Bind("RULE_SET_KEY")%>' runat="server"/>
                                                            <asp:HiddenField ID="hdnCatg" Value='<%# Bind("CATEGORY")%>' runat="server"></asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KPI Description" SortExpression="KPI_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPIDesc" runat="server" Text='<%# Bind("KPI_DESC")%>' />
                                                            <asp:HiddenField ID="hdnKPIDesc" runat="server" Value='<%# Bind("KPI_DESC")%>' />
                                                            <asp:HiddenField ID="hdnParentRuleSetKPI" runat="server" Value='<%# Bind("PARENT_RULE_SET_KPI")%>' />
                                                             <asp:HiddenField ID="hdnCmpFlag" runat="server" Value='<%# Bind("CMPTTN_FLAG")%>' />
                                                             <asp:HiddenField ID="hdnIsCummulative" runat="server" Value='<%# Bind("IS_CUMULATIVE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Accumulation Mode" SortExpression="ACC_MODE_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAccMode" runat="server" Text='<%# Bind("ACC_MODE_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnAccMode" runat="server" Value='<%# Bind("ACC_MODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ver Eff Frm" SortExpression="VER_FRM">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVerFrm" runat="server" Text='<%# Bind("VER_FRM")%>'></asp:Label>
                                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Bind("VER_FRM")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ver Eff To" SortExpression="VER_TO">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVerTo" runat="server" Text='<%# Bind("VER_TO")%>'></asp:Label>
                                                            <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Bind("VER_TO")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Carry Forward Rule" SortExpression="CARRY_FWD">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCRYFWD" runat="server" Text='<%# Bind("CARRY_FWD")%>' />
                                                            <asp:HiddenField ID="hdnCRYFWD" runat="server" Value='<%# Bind("CARRY_FWD")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reward Computation Rule" SortExpression="RWD_CMP_RULE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRwdCmpRul" runat="server" Text='<%# Bind("RWD_CMP_RULE")%>' />
                                                            <asp:HiddenField ID="hdnRwdCmpRul" runat="server" Value='<%# Bind("RWD_CMP_RULE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="UNIT_TYPE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnitType" runat="server" Text='<%# Bind("UNIT_TYPEDsc")%>' />
                                                            <asp:HiddenField ID="hdnUnitType" runat="server" Value='<%# Bind("UNIT_TYPE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Max Limit" SortExpression="MAX_LIMIT">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMaxLmt" runat="server" Text='<%# Bind("MAX_LIMIT")%>' />
                                                            <asp:HiddenField ID="hdnMaxLmt" runat="server" Value='<%# Bind("MAX_LIMIT")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                </Columns>
                                                 
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                    </div>

                                                         </ItemTemplate>  
                                                          
                                                      </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rule Set Code" SortExpression="RuleSetCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetCode" runat="server" Text='<%# Bind("RuleSetCode")%>' />
<%--                                                     <asp:HiddenField ID="hdnRulCode" runat="server" Value='<%# Bind("RULE_CODE")%>' />--%>
                                                     <asp:HiddenField ID="hdnACCRUAL_ACC_CYCLE" runat="server" Value='<%# Bind("ACCRUAL_ACC_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnRWD_CMP_CYCLE" runat="server" Value='<%# Bind("RWD_CMP_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnRWRD_REL_CYCLE" runat="server" Value='<%# Bind("RWRD_REL_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnACC_CYCLE" runat="server" Value='<%# Bind("ACC_CYCLE")%>' />

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
                                            <asp:TemplateField HeaderText="Rule Method" SortExpression="RULE_METHOD">
                                                <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleMethod" runat="server" Text='<%# Bind("RuleMethod")%>' />
                                                    <asp:HiddenField ID="hdnRuleMethod" runat="server" Value='<%# Bind("RULE_METHOD")%>' />
                                                    <asp:HiddenField ID="hdnMEM_ACH_ACC_CYCLE" runat="server" Value='<%# Bind("MEM_ACH_ACC_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnMEM_RWD_CMP_CYCLE" runat="server" Value='<%# Bind("MEM_RWD_CMP_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnMEM_RWD_REL_CYCLE" runat="server" Value='<%# Bind("MEM_RWD_REL_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnAchTbl" runat="server" Value='<%# Bind("PTR_TBL")%>' />
                                                    <asp:HiddenField ID="hdnOperator" runat="server" Value='<%# Bind("OPERATOR")%>' />
                                                   <%--  <asp:HiddenField ID="hdnRUL_CLASS" runat="server" Value='<%# Bind("RUL_CLASS")%>' />--%>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--Added by Prity--%>
                                            <asp:TemplateField HeaderText="Parent Compensation Desc" SortExpression="PARENT_CMPNSTN_CODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPARENT_CMPNSTN_CODE" runat="server" Text='<%# Bind("PARENT_CMPNSTN_DESC")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Parent contestant Code" SortExpression="PARENT_CNTST_CODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPARENT_CNTST_CODE" runat="server" Text='<%# Bind("PARENT_CNTST_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Parent Rule Set Code" SortExpression="PARENT_RULESECODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPARENT_RULESECODE" runat="server" Text='<%# Bind("PARENT_RULESECODE")%>' />
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
                                            <asp:TemplateField HeaderText=" Target Rule Class" SortExpression="TRG_CATG_RUL_CLASS">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTRG_CATG_RUL_CLASS_DESC" runat="server" Text='<%# Bind("TRG_CATG_RUL_CLASS_DESC")%>' />
                                                 <asp:HiddenField ID="hdnTRG_CATG_RUL_CLASS" runat="server" Value='<%# Bind("TRG_CATG_RUL_CLASS")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reward  Rule Class" SortExpression="RWD_RUL_CLASS">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRWD_RUL_CLASS_DESC" runat="server" Text='<%# Bind("RWD_RUL_CLASS_DESC")%>' />
                                                    <asp:HiddenField ID="hdnRWD_RUL_CLASS" runat="server" Value='<%# Bind("RWD_RUL_CLASS")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rule Complexity" SortExpression="RUL_SET_CMPLXTY">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRUL_SET_CMPLXTY_DESC" runat="server" Text='<%# Bind("RUL_SET_CMPLXTY_DESC")%>' />
                                                    <asp:HiddenField ID="hdnRUL_SET_CMPLXTY" runat="server" Value='<%# Bind("RUL_SET_CMPLXTY")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                                 </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                                  
                                  </div>
                                <div id="divPageRwd" visible="true" runat="server" class="pagination" style="padding:10px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space:nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevrwd" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;"  />
                                                            <asp:TextBox runat="server" ID="txtPageRwd" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnextrwd" Text=">" CssClass="form-submit-button" runat="server"
                                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float:left; margin: 0; height: 30px;" Width="40px"
                                                                Enabled="false" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>

                                <div style="text-align: left;">
                                    <asp:LinkButton ID="lnkKeyDfn" Text="Rule Set Key Definition" runat="server" Visible="false" />
                                </div>
                              

                                <div id="tblrwd" runat="server" class="row" style="margin-top: 12px;display:none;">
                                    <div class="col-sm-12" align="center">
                                        <asp:LinkButton ID="btnAddIndctrMst" runat="server" CssClass="btn btn-primary custom" Enabled="true"
                                            Visible="False">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Master
                                        </asp:LinkButton>
                                           <asp:LinkButton ID="lnkAddRuleMst" runat="server"  CssClass="btn btn-sample" ><%--OnClick="lnkAddRuleMst_Click"--%>
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span>Add Rule Set 
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnAddRwd" runat="server" CssClass="btn btn-sample" >
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add KPI
                                        </asp:LinkButton>

                                         <%--Added by Prathamesh on 27_02_2018 start--%>
                                          <asp:LinkButton ID="btnDwdFormat" runat="server" CssClass="btn btn-sample" Visible="false" Enabled="true">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Download Format
                                        </asp:LinkButton>
                                         <%--Added by Prathamesh on 27_02_2018 end--%>
                                        <asp:LinkButton ID="btnBlkKPIRwd" Visible="false" runat="server" CssClass="btn btn-sample" Enabled="true">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Bulk Add KPI
                                        </asp:LinkButton>

                                       

                                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="False">
                                                <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnSaveRwd" runat="server" CssClass="btn btn-sample" Visible="false"
                                            Enabled="true">
                                                    <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span> Save
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnindctrcmnt" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="false">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Add Comments
                                        </asp:LinkButton>
                                        
                                      <%-- <asp:Label ID="lbllbrktrwd" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkindctrcmnt" Text="+" runat="server" />
                                        <asp:Label ID="lblrbrktrwd" Text="]" runat="server" CssClass="control-label" />--%>
                                     <asp:LinkButton ID="lnkindctrcmnt"  CssClass="btn btn-sample"  runat="server" >
                                      <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Comments
                                     </asp:LinkButton>
                                         <asp:LinkButton ID="lnkVwCmtRwd"  CssClass="btn btn-sample" Text="View Comments" runat="server" >
                                             <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> View Comments
                                         </asp:LinkButton>
                                     <%--<asp:Label ID="Label15" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkVwCmtRwd" Text="..." runat="server" />
                                        <asp:Label ID="Label16" Text="]" runat="server" CssClass="control-label" />--%>
                                    </div>
                                </div>
                                </div>

                    <div id="divKPIT" runat="server">
                                <h3 class="form-section" style="text-align: left;">
                                        <img id="ImageKPITrgs" src="../../../images/Key_Performance_Indicator_targets.png" style="border-width:0px;width: 35px;margin-top: 6px;margin-bottom:10px;height: 35px;"/>

                                    Key Performance Indicator Targets</h3>
                                <div id="div20" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow:auto"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgTrg" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" DataKeyNames="rulesetCode" OnRowDataBound="dgTrg_RowDataBound">   <%--OnRowDataBound="dgTrg_RowDataBound"--%>
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                                 <EmptyDataTemplate>
                                            <asp:Label ID="Label15" Text="No Rule have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                        
                                                <Columns>

                                           <asp:TemplateField>
                                                    <ItemTemplate>
                                <img alt="" id="img2"  style="cursor: pointer" src="../../../images/btnexp.png" />
                                <div id="div5" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                    class="table-scrollable,divBorder1">

                                   
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgRwdTrg" runat="server" CssClass="footable" AllowSorting="True"  
                                                AllowPaging="True" AutoGenerateColumns="false" 
                                                OnSorting="dgRwdTrg_Sorting"  PageSize="10"   OnPageIndexChanging="dgRwdTrg_PageIndexChanging"  >
                                                
                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <%--<PagerStyle CssClass="disablepage" />--%>
                                                <HeaderStyle CssClass="gridview th" />
                                                <EmptyDataTemplate>
                                            <asp:Label ID="Label15" Text="No Target have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="RS Key" SortExpression="RULE_SET_KEY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                            <asp:HiddenField ID="hdnBusiCode" runat="server" Value='<%# Bind("BUSI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnCode" runat="server" Value='<%# Bind("CODE")%>' />
                                                            <asp:HiddenField ID="HiddenRulecode" runat="server" Value='<%# Bind("RULE_CODE")%>' />
                                                            <asp:HiddenField ID="HiddenCycleCode" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                                            <asp:HiddenField ID="HiddenKpiCode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnKpiOrg" Value='<%# Bind("KPI_ORIGIN")%>' runat="server">
                                                            </asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category" SortExpression="CATEGORY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatgCode" runat="server" Text='<%# Bind("CATEGORY")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatgCode" runat="server" Value='<%# Bind("CATEGORY")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cycle" SortExpression="CYCLE">
                                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCycle" runat="server" Text='<%# Bind("CYCLE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category Description" SortExpression="CATG_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatDsc" runat="server" Text='<%# Bind("CATG_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatDsc" runat="server" Value='<%# Bind("CATG_DESC")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnCatg" runat="server" Value='<%# Bind("CATG")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Target From" SortExpression="TRG_FRM">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTrgFrm" runat="server" Text='<%# Bind("TRG_FRM")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTrgFrm" runat="server" Value='<%# Bind("TRG_FRM")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Target To" SortExpression="TRG_TO">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTrgTo" runat="server" Text='<%# Bind("TRG_TO")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTrgTo" runat="server" Value='<%# Bind("TRG_TO")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Eff From" SortExpression="EFFDT_FROM">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEffFrom" runat="server" Text='<%# Bind("EFFDT_FROM")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnEffFrom" runat="server" Value='<%# Bind("EFFDT_FROM")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Eff To" SortExpression="EFFDT_TO">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEffTo" runat="server" Text='<%# Bind("EFFDT_TO")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnEffTo" runat="server" Value='<%# Bind("EFFDT_TO")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Catg Set" SortExpression="CATSET">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCATSET" runat="server" Text='<%# Bind("CATSET")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCATSET" runat="server" Value='<%# Bind("CATSET")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="P Excl" SortExpression="P_EXCL">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblP_EXCL" runat="server" Text='<%# Bind("P_EXCL_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnP_EXCL" runat="server" Value='<%# Bind("P_EXCL")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="S Excl" SortExpression="S_EXCL">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblS_EXCL" runat="server" Text='<%# Bind("S_EXCL_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnS_EXCL" runat="server" Value='<%# Bind("S_EXCL")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sort" SortExpression="SORT">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSORT" runat="server" Text='<%# Bind("SORT")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnSORT" runat="server" Value='<%# Bind("SORT")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Member Code" SortExpression="MEM_CODE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMEM_CODE" runat="server" Text='<%# Bind("MEM_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnMEM_CODE" runat="server" Value='<%# Bind("MEM_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                   <%-- <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditRwdTrg" runat="server" Text="Edit" OnClick="lnkEditRwdTrg_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelRwdTrg" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                                OnClick="lnkDelRwdTrg_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkKPITrgtSetRule" runat="server" Text="Set Rule" OnClick="lnkKPITrgtSetRule_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <%--<Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddRwdTrg" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnSaveRwdTrg" EventName="Click" />
                                        </Triggers>--%>
                                    </asp:UpdatePanel>
                                </div>


                                                        </ItemTemplate>
                                           </asp:TemplateField>

                                                    
                                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="rulesetCode">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lnkRule_SET_KEY" runat="server" Text='<%# Bind("rulesetCode")%>'></asp:Label>
                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Rule Set Description" SortExpression="RuleSetDesc">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRuleSetDesc" runat="server" Text='<%# Bind("RuleSetDesc")%>'></asp:Label>
                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Cycle" SortExpression="CYCLE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCycle" runat="server" Text='<%# Bind("Cycle_Desc")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Eff From" SortExpression="EFF_FROM">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEffFrom" runat="server" Text='<%# Bind("EFF_FROM")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnEffFrom" runat="server" Value='<%# Bind("EFF_FROM")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Eff To" SortExpression="EFF_TO">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEffTo" runat="server" Text='<%# Bind("EFF_TO")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnEffTo" runat="server" Value='<%# Bind("EFF_TO")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <%-- <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkQtrgSetRule" runat="server" Text="Set Rule" OnClick="lnkQtrgSetRule_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>


                                                    </Columns>


                                             </asp:GridView>
                                             </ContentTemplate>

                                     </asp:UpdatePanel>
                                         </div>
                                <div id="divRwdPgTrg" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevrwdtrg" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevrwdtrg_Click" />
                                                            <asp:TextBox runat="server" ID="txtpgrwdtrg" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnextrwdtrg" Text=">" CssClass="form-submit-button" runat="server"
                                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                                Enabled="false" OnClick="btnnextrwdtrg_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                 
                               

                                <%--<div id="Div2" runat="server" class="row"  style="margin-top: 12px;display:none;">
                                    <div class="col-sm-12" align="center">
                                     
                                        <asp:LinkButton ID="BtnDownloadExcel" OnClick="BtnDownloadExcel_Click" runat="server" CssClass="btn btn-sample" >
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span>Download
                                        </asp:LinkButton>
                                        <button id="btnUPLOADpop" type="button" class="btn btn-sample" onclick="javascript: return fnCallPOP();">
                                            <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Bulk Upload
                                        </button>

                                    
                                    </div>
                                </div>--%>
                                </div>

                    <div id="divKPIRR" runat="server">
                                <h3 class="form-section" style="text-align: left;">
                                        <img id="ImageReward2" src="../../../images/Reward_Rule_Icon.png" style="border-width:0px;width: 35px;margin-top: 0px;margin-bottom: 5px;height: 35px;"/> 
                                            
                                    Key Performance Indicator Reward Rules</h3>
                                <div id="div7" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow:auto;"
                                    class="table-scrollable">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgRwdRul" runat="server" CssClass="footable" AllowSorting="True" PageSize="10"
                                                OnSorting="dgRwdRul_Sorting" AllowPaging="true" AutoGenerateColumns="false" OnRowDataBound="dgRwdRul_RowDataBound">
                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                  <%--  1--%>
                                                    <asp:TemplateField>
                                            <ItemTemplate>
                                                <img alt="" id="img2"  style="cursor: pointer" src="../../../images/btnexp.png" />
                                                <div id="divChild" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                    class="table-scrollable,divBorder1">
                                                    <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="dgCntst" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                PageSize="10" AllowSorting="False" AllowPaging="true" CssClass="footable"
                                                                 >
                                                              
                                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                <PagerStyle CssClass="disablepage" />
                                                                <HeaderStyle CssClass="gridview th" />
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                                        runat="server" />
                                                                </EmptyDataTemplate>
                                                                <Columns>

                                                                
                                             <asp:TemplateField HeaderText="Buisiness Type" SortExpression="BusType">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBusType" runat="server" Text='<%# Bind("BusType")%>' />
                                                    <asp:HiddenField ID="lblBusType11" runat="server" Value='<%# Bind("BusType")%>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Product Code" SortExpression="ProdCode">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProdCode" runat="server" Text='<%# Bind("ProdCode")%>' />
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
                                                    <asp:Label ID="lblProdCategory" runat="server" Text='<%# Bind("ProdCategory")%>' />
                                                    <asp:HiddenField ID="lblProdCategory11" runat="server" Value='<%# Bind("ProdCategory")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Frequency" SortExpression="Frequency">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFrequency" runat="server" Text='<%# Bind("Frequency")%>' />
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
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Pay Mode" SortExpression="PayMode">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPayMode" runat="server" Text='<%# Bind("PayMode")%>' />
                                                    <asp:HiddenField ID="lblPayMode11" runat="server" Value='<%# Bind("PayMode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                     <%--  2--%>
                                                    <asp:TemplateField HeaderText="Reward Code" SortExpression="RWD_RUL_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRwdRulCode" runat="server" Text='<%# Bind("RWD_RUL_CODE")%>'></asp:Label>
                                                            <%--<asp:Label ID="lblRwdCode" runat="server" Text='<%# Bind("REWARD_CODE")%>'></asp:Label>--%>
                                                            <asp:HiddenField ID="hdnRwdCode" runat="server" Value='<%# Bind("REWARD_CODE")%>' />
                                                            <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                             <asp:HiddenField ID="hdnActSts" runat="server" Value='<%# Bind("ACTV_STATUS")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  3--%>
                                                    <asp:TemplateField HeaderText="Cycle" SortExpression="CYCLE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCYCLE" runat="server" Text='<%# Eval("CYCLE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCYCLE1" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                            <asp:HiddenField ID="hdnCycCd" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <%--  4--%>
                                                    <asp:TemplateField HeaderText="Category Code" SortExpression="CATG_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatgCd" runat="server" Text='<%# Bind("CATG_CODE")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <%--  5--%>
                                                    <asp:TemplateField HeaderText="Category Classification" SortExpression="CATEGORY">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatgCode" runat="server" Text='<%# Bind("CATEGORY")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatgCode" runat="server" Value='<%# Bind("CATG_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  6--%>
                                                    <asp:TemplateField HeaderText="RS Key" SortExpression="RULE_SET_KEY_DESC">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  7--%>
                                                    <asp:TemplateField HeaderText="Reward Type" SortExpression="REWARD_TYPE_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="Label6" runat="server" Text='<%# Bind("REWARD_TYPE_DESC")%>'></asp:Label>--%>
                                                            <asp:Label ID="lblCatDsc" runat="server" Text='<%# Bind("REWARD_TYPE_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatDsc" runat="server" Value='<%# Bind("REWARD_TYPE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  8--%>
                                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="TYPE_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("TYPE_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("TYPE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  9--%>
                                                    <asp:TemplateField HeaderText="Based On KPI" SortExpression="KPI_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="Label6" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>--%>
                                                            <asp:Label ID="lblBsdKpi" runat="server" Text='<%# Eval("KPI_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnBsdKpi" runat="server" Value='<%# Eval("KPI_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  10--%>
                                                    <asp:TemplateField HeaderText="Value" SortExpression="VALUE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblValue" runat="server" Text='<%# Eval("VALUE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnValue" runat="server" Value='<%# Bind("VALUE")%>' />
                                                            <asp:HiddenField ID="hdnRate" runat="server" Value='<%# Bind("RATE")%>' />
                                                            <%--<asp:LinkButton ID="lnkValue" Text="..." runat="server" Visible="false" OnClick="lnkValue_Click" />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  11--%>
                                                    <asp:TemplateField HeaderText="Reward Desc" SortExpression="RWD_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRwdDesc" runat="server" Text='<%# Bind("RWD_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRwdDesc" runat="server" Value='<%# Bind("RWD_DESC")%>' />
                                                            <asp:HiddenField ID="hdnRwdDesc1" runat="server" Value='<%# Bind("RWRD_DESC02")%>' />
                                                            <asp:HiddenField ID="hdnRwdDesc2" runat="server" Value='<%# Bind("RWRD_DESC03")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  12--%>
                                                    <asp:TemplateField HeaderText="Breakup Rule" SortExpression="BRK_RULE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBrkRul" runat="server" Text='<%# Eval("BRK_RULE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnBrkRul" runat="server" Value='<%# Bind("BRK_RULE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  13--%>
                                                    <asp:TemplateField HeaderText="Rate" SortExpression="RATE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRATE" runat="server" Text='<%# Eval("RATE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRATE1" runat="server" Value='<%# Bind("RATE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  14--%>

                                                    <asp:TemplateField HeaderText="Member Code" SortExpression="MEMBERCODE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMEMBERCODE" runat="server" Text='<%# Eval("MEMBERCODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnMEMBERCODE" runat="server" Value='<%# Bind("MEMBERCODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                     <%--  15--%>
                                                     <asp:TemplateField HeaderText="Target From" SortExpression="TRGT_FROM">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTRGT_FROM" runat="server" Text='<%# Eval("TRGT_FROM")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTRGT_FROM" runat="server" Value='<%# Bind("TRGT_FROM")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                     <%--  16--%>
                                                    <asp:TemplateField HeaderText="Target To" SortExpression="TRGT_TO">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTRGT_TO" runat="server" Text='<%# Eval("TRGT_TO")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTRGT_TO" runat="server" Value='<%# Bind("TRGT_TO")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                     <%--  17--%>
                                                   <%-- added by arjun dated on 06/09/2018 for the UAT bug 2052--%>
                                                     <asp:TemplateField HeaderText="Reason for Edit Rate" SortExpression="ParamDesc1">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="LBLParamDesc1RED" runat="server" Text='<%# Bind("ParamDesc1")%>' />
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                 <%--   ended by arjun--%>
                                                          <%--  18--%>                                             
                                                  <%--  <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditRwdRul" runat="server" Text="Edit" OnClick="lnkEditRwdRul_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--  19--%>
                                                  <%--  <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelRwdRul" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                                OnClick="lnkDelRwdRul_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <%--<Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddRwdRul" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnSaveRwdRul" EventName="Click" />
                                             <asp:AsyncPostBackTrigger ControlID="LNKRWD" EventName="Click" />
                                        </Triggers>--%>
                                    </asp:UpdatePanel>
                                </div>
                                
                                <div id="Div1" runat="server" class="row" style="margin-top: 12px;">
                                    <div id="div12" runat="server" style="display: none; text-align: left;padding-left: 42px;">
                                <asp:CheckBox ID="chkQual" Checked="false"  runat="server" CssClass="checkbox"/>
                                <asp:Label Text="Please check for setting qualification rule" CssClass="control-label" runat="server" style="padding-left: 5px;" />
                            </div>
                                 
                                        </div>
                                </div>
                </div>
                
            </div>
        </div>



        <asp:Panel runat="server" Height="483px" Width="863px" ID="Panel1" display="none" Style="text-align: center; padding: 5px;left:-22px;top:-4px;"
        CssClass="panel panel-success">
        <iframe runat="server" id="Iframe1" scrolling="yes" width="80%" frameborder="0"
            display="none" style="height: 80%; "></iframe>


    </asp:Panel>
         <asp:Label runat="server" ID="Label10" Style="display: none" />
         <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlPopBIDHybrid"
        DropShadow="false" TargetControlID="Label10" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg"  X="-4" Y="0">
    </ajaxToolkit:ModalPopupExtender>
     
         </center>
    <asp:HiddenField ID="hdnBatchId" runat="server" />
    <input id="hdnAgentCode" type="hidden" value="" runat="server" />
<%--    Added by usha  on 24.01.2020--%>
      <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <%--<asp:HiddenField ID="hdnAccCyc" runat="server" />
            <asp:HiddenField ID="hdnSetTrgRul" runat="server" />
            <asp:HiddenField ID="hdnTrgFrm" runat="server" />
            <asp:HiddenField ID="hdnTrgTo" runat="server" />
            <asp:HiddenField ID="hdnBusiYear" runat="server" />--%>
            <asp:HiddenField ID="hdnbusicode" runat="server" />
           <%-- <asp:HiddenField ID="hdnCount" runat="server" />
            <asp:HiddenField ID="hdnyrtyp" runat="server" />
            <asp:HiddenField ID="hdnTrgCnt" runat="server" />
            <asp:HiddenField ID="hdnTrgCnt1" runat="server" />
            <asp:HiddenField ID="hdnSortNo" runat="server" />
            <asp:HiddenField ID="hdntxtfrm" runat="server" />
             <asp:HiddenField ID="hdnYrType" runat="server" />
             <asp:HiddenField ID="StrFinyear" runat="server" />--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


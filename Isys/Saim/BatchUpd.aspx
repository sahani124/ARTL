<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="BatchUpd.aspx.cs" Inherits="Application_Isys_Saim_BatchUpd" %>

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
                alert("Cycle from should be smaller then cycle to");
                return false;
            }
            else {
                return true;
            }
        }

        function chckddl1(min, max) {
            //if (parseInt(value) < min || isNaN(parseInt(value)))
            if (parseInt(min) > max) {
                alert("Month from should be smaller then month to");
                return false;
            }
            else {
                return true;
            }
        }

        function validateGenerate() {
            debugger;

            var ddlRuleSetCode = $('#<%=ddlRuleSetCode.ClientID %>');
            var txtcount = $('#<%=txtcount.ClientID %>');
            var ddlFrom = $('#<%=ddlFrom.ClientID %>');
            var ddlTo = $('#<%=ddlTo.ClientID %>');
            var DropDownList1 = $('#<%=DropDownList1.ClientID %>');
            var DropDownList2 = $('#<%=DropDownList2.ClientID %>');
             var StrFinyear = $('#<%=StrFinyear.ClientID %>').val();

            if (ddlRuleSetCode.val().toLowerCase() == "") {
                alert("Please select rule set code");
                return false;
            };
            if (txtcount.val() == "") {
                alert('Please enter the count');
                return false;
            }
            if (txtcount.val() != "") {
                if (!minmax(txtcount.val(), 1, 99999)) {
                    return false;
                }

            }
            if (StrFinyear == "10000010" && StrFinyear != null) {
                if (ddlFrom.val().toLowerCase() == "") {
                    alert("Please select Member Month From!");
                    return false;
                }
                if (ddlTo.val().toLowerCase() == "") {
                    alert("Please select Member Month To!");
                    return false;
                }
            }
            //if (ddlFrom.val().toLowerCase() == "") {
            //    alert("Please select member month from");
            //    return false;
            //}
            //if (ddlTo.val().toLowerCase() == "") {
            //    alert("Please select member month to");
            //    return false;
            //}

            if (ddlFrom.val().toLowerCase() != "" && ddlTo.val().toLowerCase() != "") {
                var From = ddlFrom.val().toLowerCase();
                var To = ddlTo.val().toLowerCase();
                From = From.substring(1);
                To = To.substring(1);
                if (!chckddl1(From, To)) {
                    return false;
                }

            }
            if (DropDownList1.val().toLowerCase() == "") {
                alert("Please select cycle from");
                return false;
            }
            if (DropDownList2.val().toLowerCase() == "") {
                alert("Please select cycle to");
                return false;
            }

            if (DropDownList1.val().toLowerCase() != "" && DropDownList2.val().toLowerCase() != "") {
                if (!chckddl(DropDownList1.val().toLowerCase(), DropDownList2.val().toLowerCase())) {
                    return false;
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
                alert("Please select rule set code");
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
                alert("Please select rule set code");
                return false;
            };
            var cmpCode = getUrlParameter('CmpCode');
            var cntCode = getUrlParameter('CntstCode');
            var ruleSet = ddlRuleSetCode.val().toLowerCase();
            var strContent = "ctl00_ContentPlaceHolder1_";
            
            $find("mdlPopBIDHybrid").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = ("FrmARFUpload.aspx?CmpCode=" + cmpCode + "&cnstCode=" + cntCode + "&btchUpload=" + "upd1" + "&RuleSetKey=" + ruleSet + "&mdlpopup=mdlPopBIDHybrid");
            // document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "PopBulkCatgUpd.aspx";
            return false;
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <center>
        <div id="divcmphdrcollapse" runat="server" style="width: 97%;"  class="panel">
            <div id="Div6" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;" runat="server" class="panel-heading" >
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
<%--                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;commennted by ajay sawant 25/4/2018--%>
                        <asp:Label ID="lblhdr" Text="Target Bulk Upload" Font-Size="19px" runat="server" />
                    </div>
                    <div class="col-sm-2">
                             <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>

                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" style="width: 96%;" class="panel-body">

               <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left;font-weight:bold; display:none">
                        <asp:Label ID="Label4" Text="Rule Set" runat="server" CssClass="control-label" />
                    </div>
                </div>
               <div class="row" style="margin-bottom: 5px;">
                 <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label5" Text="Rule Set Code" runat="server" CssClass="control-label" />
                       <asp:Label ID="Label51" Text="*" runat="server" ForeColor="red" />
                    </div>
                  <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlRuleSetCode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRuleSetCode_SelectedIndexChanged"  CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
               </div>

               <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left;font-weight:bold;">
                        <asp:Label ID="lblSlabs" Text="SLABS" runat="server" CssClass="control-label" />
                    </div>
                </div>
               <div class="row" style="margin-bottom: 5px;">
                 <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblcount" Text="Count" runat="server" CssClass="control-label" />
                      <asp:Label ID="Label6" Text="*" runat="server" ForeColor="red" />
                    </div>
                 <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                              <%--  <asp:TextBox ID="txtcount" runat="server" MaxLength="1" CssClass="form-control" TabIndex="1"
                                  placeholder="Count" />--%>


                                 <asp:TextBox ID="txtcount" runat="server" MaxLength="5" CssClass="form-control" TabIndex="1"
                                  placeholder="Count" />
                                <asp:RangeValidator ID="Value2RangeValidator" ControlToValidate="txtcount"  
             Type="Integer" MinimumValue="1" MaximumValue="99999" Display="Dynamic"  
             ErrorMessage="Please enter an integer  between  1 and 99999.<br />"
                                    runat="server"/>  
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
               </div>
                 <div id ="memberMonths" runat="server" style="display:none;">
               <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left;font-weight:bold;">
                        <asp:Label ID="lblMemMonth" Text="Member Month" runat="server" CssClass="control-label" />
                    </div>
                </div>
               <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblFrom" Text="From" runat="server" CssClass="control-label" />
                         <asp:Label ID="Label7" Text="*" runat="server" ForeColor="red" />
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
                         <asp:Label ID="Label8" Text="*" runat="server" ForeColor="red" />
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
                     </div>


               <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left;font-weight:bold;">
                        <asp:Label ID="Label1" Text="Cycles" runat="server" CssClass="control-label" />
                    </div>
                </div>
               <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label2" Text="From" runat="server" CssClass="control-label" />
                         <asp:Label ID="Label9" Text="*" runat="server" ForeColor="red" />
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
                         <asp:Label ID="Label11" Text="*" runat="server" ForeColor="red" />
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

               <div id="tblrwdtrg" runat="server" class="row" style="margin-top: 12px;">
                                    <div class="col-sm-12" align="center">
                                     
                                        <%--//Added By DAKSH 21012019--%>
                                        <asp:LinkButton ID="lnlSearchbyRuleSet"  runat="server" OnClick="lnlSearchbyRuleSet_Click" OnClientClick="javascript : return validateGenerate();"   CssClass="btn btn-sample" Visible="true" >
                                         <span class="glyphicon glyphicon-search BtnGlyphicon" style="color: White;"></span> Search
                                        </asp:LinkButton>
                                    
                                    </div>
                                </div>

                <div id="divchkRwd" runat="server" style="display:none; text-align: left; padding-left: 42px;" >
                                <asp:CheckBox ID="chkRwd" runat="server" CssClass="checkbox" />
                                <asp:Label Text="Please check for setting rewards rule" runat="server" style="padding-left: 5px;"/>
                            </div>
                <div id="divRwd" runat="server" style="width: 96%;" class="panel-body">
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

<%--                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditRwd" runat="server" Text="Edit" OnClick="LnkEditRwrd_Click" ></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" OnClick="lnkDelete_Click"
                                                        OnClientClick="return confirm('Are you sure you want delete'); return true;"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkKPISetRule" runat="server" Text="Set Rule" OnClick="lnkKPISetRule_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action ">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkTrgView" runat="server" Text="View Target" OnClick="lnkTrgView_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

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

                                            <%--<asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                  <%--  <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>--%>
                                              <%--  </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" OnClick="lnkDelete_Click"
                                                        OnClientClick="return confirm('Are you sure you want delete'); return true;"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            </Columns>
                                                 </asp:GridView>
                                                       </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                  
                                  </div>


                                <div id="divPageRwd" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
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
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
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
                                <div id="Div1" runat="server" class="row" style="margin-top: 12px;">
                                    <div id="div12" runat="server" style="display: none; text-align: left;padding-left: 42px;">
                                <asp:CheckBox ID="chkQual" Checked="false"  runat="server" CssClass="checkbox"/>
                                <asp:Label Text="Please check for setting qualification rule" CssClass="control-label" runat="server" style="padding-left: 5px;" />
                            </div>
                                    <div class="col-sm-12" align="center">
                                        <div id="div3" runat="server" style="text-align: left;padding-left: 40%;">
                                <asp:CheckBox ID="CheckBox1" Checked="false"  runat="server"  CssClass="checkbox"/>
                                <asp:Label Text="Same Categories For all Cycles" CssClass="control-label" runat="server" style="padding-left: 5px;" />
                            </div>
                                         <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click"  runat="server" OnClientClick="javascript : return validateGenerate();"  CssClass="btn btn-sample" ><%--OnClick="lnkAddRuleMst_Click"--%>
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Generate
                                        </asp:LinkButton>
                                        </div>
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
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon " style="color: White;"></span> Download Format
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
                                <div id="div5" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow:auto "
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgRwdTrg" runat="server" CssClass="footable" AllowSorting="True"
                                                AllowPaging="true" AutoGenerateColumns="false" OnRowDataBound="dgRwdTrg_RowDataBound"
                                                OnSorting="dgRwdTrg_Sorting"  PageSize="10">
                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="RS Key" SortExpression="RULE_SET_KEY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY")%>'></asp:Label>
                                                            
                                             
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category" SortExpression="CATEGORY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatgCode" runat="server" Text='<%# Bind("CATG_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatgCode" runat="server" Value='<%# Bind("CATG_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cycle" SortExpression="CYCLE">
                                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCycle" runat="server" Text='<%# Bind("CYCLE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Category Description" SortExpression="CATG_DESC01">
                                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatDesc" runat="server" Text='<%# Bind("CATG_DESC01")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatDESC" runat="server" Value='<%# Bind("CATG_DESC01")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                

                                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_CODE")%>'></asp:Label>
                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
	
                                                    <asp:TemplateField HeaderText="Target From" SortExpression="TRG_FRM">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTrgFrm" runat="server" Text='<%# Bind("KPI_TRGT_FROM")%>'></asp:Label>
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Target To" SortExpression="TRG_TO">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTrgTo" runat="server" Text='<%# Bind("KPI_TRGT_TO")%>'></asp:Label>
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Eff From" SortExpression="EFFDT_FROM">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEffFrom" runat="server" Text='<%# Bind("EFF_FROM")%>'></asp:Label>
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Eff To" SortExpression="EFFDT_TO">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEffTo" runat="server" Text='<%# Bind("EFF_TO")%>'></asp:Label>
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Catg Set" SortExpression="CATSET">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCATSET" runat="server" Text='<%# Bind("CAT_SET")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCATSET" runat="server" Value='<%# Bind("CAT_SET")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="P Excl" SortExpression="P_EXCL">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblP_EXCL" runat="server" Text='<%# Bind("P_EXCL")%>'></asp:Label>
                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="S Excl" SortExpression="S_EXCL">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblS_EXCL" runat="server" Text='<%# Bind("S_EXCL")%>'></asp:Label>
                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sort" SortExpression="SORT">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSORT" runat="server" Text='<%# Bind("SORT")%>'></asp:Label>
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

<%--
                                                    <asp:TemplateField HeaderText="Member Code" SortExpression="MEM_CODE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMEM_CODE" runat="server" Text='<%# Bind("MEMBER_CODE")%>'></asp:Label>
                                                            
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
                                <div id="Div2" runat="server" class="row" style="margin-top: 12px;">
                                    <div class="col-sm-12" align="center">
                                     
                                        <asp:LinkButton ID="BtnDownloadExcel" Visible="TRUE" OnClick="BtnDownloadExcel_Click" OnClientClick="javascript : return validateGenerate();" runat="server" CssClass="btn btn-sample" >
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Download
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
                                </div>
                </div>
                
            </div>
        </div>
            <asp:Panel runat="server" Height="365px" Width="863px" ID="Panel1" display="none" Style="text-align: center;top:59px !important; padding: 5px;left:-22px;"
        CssClass="panel panel-success">
        <iframe runat="server" id="Iframe1" scrolling="yes" width="80%" frameborder="0"
            display="none" style="height: 100%; "></iframe>


    </asp:Panel>
         <asp:Label runat="server" ID="Label10" Style="display: none" />
         <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlPopBIDHybrid"
        DropShadow="false" TargetControlID="Label10" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg"  X="-4" Y="0">
    </ajaxToolkit:ModalPopupExtender>
     
         </center>
    <asp:HiddenField ID="hdnBatchId" runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnAccCyc" runat="server" />
            <asp:HiddenField ID="hdnSetTrgRul" runat="server" />
            <asp:HiddenField ID="hdnTrgFrm" runat="server" />
            <asp:HiddenField ID="hdnTrgTo" runat="server" />
            <asp:HiddenField ID="hdnBusiYear" runat="server" />
            <asp:HiddenField ID="hdnbusicode" runat="server" />
            <asp:HiddenField ID="hdnCount" runat="server" />
            <asp:HiddenField ID="hdnyrtyp" runat="server" />
            <asp:HiddenField ID="hdnTrgCnt" runat="server" />
            <asp:HiddenField ID="hdnTrgCnt1" runat="server" />
            <asp:HiddenField ID="hdnSortNo" runat="server" />
            <asp:HiddenField ID="hdntxtfrm" runat="server" />
             <asp:HiddenField ID="hdnYrType" runat="server" />
             <asp:HiddenField ID="StrFinyear" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



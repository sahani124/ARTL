<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="ExcptPyout.aspx.cs" Inherits="Application_ISys_Saim_ExcptPyout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
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
    <style type="text/css">
        /*.ajax__calendar
        {
            z-index: 100px;
        }
        .form-submit-button
        {
            box-shadow: none !important;
        }
        .disablepage
        {
            display: none;
        }
        .divBorder
        {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }
        
        .transbox
        {
            width: 400px;
            height: 180px;
            margin: 30px 50px;
            background-color: #ffffff;
            border: 1px solid black;
            opacity: 0.6;
            filter: alpha(opacity=60); /* For IE8 and earlier 
            z-index: inherit;
        }
        
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        
        .btn-tab
        {
            color: #3c763d;
            background-color: #dff0d8;
            border-color: #d6e9c6;
        }
        
        .nav-tabs > li.active > a, .nav-tabs > li.active > a:hover, .nav-tabs > li.active > a:focus
        {
            color: #555555;
            background-color: #dff0d8;
        }
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
        }*/
        
        ul#menu li a:active
        {
            background: white;
        }
        
        
        
        .disablepage
        {
            display: none;
        }
        ul#menu
        {
            padding: 0;
            margin-right: 69%;
        }
        
        ul#menu li
        {
            display: inline;
        }
        
        ul#menu li a
        {
            background-color: Silver;
            color: black;
            cursor: pointer;
            padding: 10px 20px;
            text-decoration: none;
            border-radius: 4px 4px 0 0;
        }
        ul#menu li a:active
        {
            background: white;
        }
        
        ul#menu li a:hover
        {
            background-color: red;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("th").click(function () {
                var columnIndex = $(this).index();
                var tdArray = $(this).closest("table").find("tr td:nth-child(" + (columnIndex + 1) + ")");
                tdArray.sort(function (p, n) {
                    var pData = $(p).text();
                    var nData = $(n).text();
                    return pData < nData ? -1 : 1;
                });
                tdArray.each(function () {
                    var row = $(this).parent();
                    $("#dgReward").append(row);
                });
            });
        })
    </script>
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
            //            ////alert(img);
            //            //$(document.getElementById(strContent + divId)).slideToggle();
            //                        var imgids = ["#myImg", "#Img1"];
            //                        var divids = ["divcmphdr", "divkpisrch"];
            //                        var index;
            //                        var idx;
            //                        //////loop for imgids
            //                        for (index = 0; index < imgids.length; index++) {
            //                            if ($(imgids[index]).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
            //                                $(imgids[index]).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            //                            }
            //                            else {
            //                                $(imgids[index]).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            //                            }
            //                        }
            //                        //////loop for divids
            //                        for (idx = 0; idx < divids.length; idx++) {
            //                            $(document.getElementById(strContent + divids[idx])).slideToggle();
            //                        }
        }


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

        function TotalAMT(id) {


            var chnID = id;

            id=  id.replace("chkprnMEM", "lblTotComm")
           // ctl00_ContentPlaceHolder1_dgCmp_ctl02_chkprnMEM

          //  ctl00_ContentPlaceHolder1_dgCmp_ctl02_lblTotComm
            //ctl00_ContentPlaceHolder1_txtTotComm

            if (document.getElementById(chnID).checked == true) {

               document.getElementById("ctl00_ContentPlaceHolder1_txtTotComm").value =
                   parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_txtTotComm").value) +
               parseFloat(document.getElementById(id).innerText)
            }
            else {


               if (document.getElementById("ctl00_ContentPlaceHolder1_txtTotComm").value != "0.00") {
                    document.getElementById("ctl00_ContentPlaceHolder1_txtTotComm").value =
                        parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_txtTotComm").value) -
                    parseFloat(document.getElementById(id).innerText)
                }
            }
         //   alert(id)
        }

        function TotalCommission(id, name) {
            debugger;

            var ParentGridID = id

            var childGrid = id.replace("chkOnerrr", "lblCommission")

            var TotalLen = id.indexOf("dgReward");

            ParentGridID = id.substring(0, TotalLen)

            ParentGridID = ParentGridID +'lblTotComm'
           // alert(ParentGridID);


            if (document.getElementsByName(name)[1].checked == true) {


                document.getElementById(ParentGridID).innerText = parseFloat(document.getElementById(ParentGridID).innerText) +
                    parseFloat(document.getElementById(childGrid).innerText)
            }
            else {

                document.getElementById(ParentGridID).innerText = parseFloat(document.getElementById(ParentGridID).innerText) -
                    parseFloat(document.getElementById(childGrid).innerText)
            }
            //tl00_ContentPlaceHolder1_dgCmp_ctl02_

            //ctl00_ContentPlaceHolder1_dgCmp_ctl02_dgReward_ctl02_chkOne
            //ctl00_ContentPlaceHolder1_dgCmp_ctl02_dgReward_ctl02_lblPremium




        }


        function funcall() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
        }

        function callsearch() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
        }

        function funPopUpRwdRul() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwRwdRulBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "ConvRangeSelection.aspx?mdlpopup=mdlVwRwdRulBID";
        }
        function ClosePopup() {
            $find("mdlVwRwdRulBID").Hide();
        }
        function GetDataFromChild(data) {
            debugger;
            $('#<% =hdnMemCode.ClientID %>').attr('value', data);
        }
    </script>
    <script type="text/javascript" src="../../../Scripts/jquery.min.js"></script>
    <script type="text/javascript">
        debugger;
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
    </script>

    <style type="text/css">
        .radio-group label
        {
            overflow: hidden;
        }
        
        .radio-group input
        {
            /* This is on purpose for accessibility. Using display: hidden is evil. This makes things keyboard friendly right out tha box! */
            height: 1px;
            width: 1px;
            position: absolute;
            top: -20px;
        }
        
        .radio-group .not-active
        {
            color: #3276b1;
            background-color: #fff;
        }
    </style>
  
    <%--    <script type="text/javascript">
           $(document).ready(function () {
               debugger;
               $.ajax({
                   type: "POST",
                   // url: "http://localhost:50230/Application/Isys/Saim/BatchJobDtls.aspx/GetDashBoardDtls",
                   url: "Application/Isys/Saim/BatchJobDtls.aspx/GetDashBoardDtls",
                   data: "{}",
                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   success: function (data) {
                       debugger;
                       successBindata(data)
                   },
                   failure: function (result) {
                       debugger;
                       var r = jQuery.parseJSON(result.responseText);
                       alert("Message: " + r.Message);
                       alert("StackTrace: " + r.StackTrace);
                       alert("ExceptionType: " + r.ExceptionType);
                       alert(response.d);
                   }
               });
           });

           function successBindata(data) {
               var BatchDtls = JSON.parse(data.d);
               debugger;
               document.getElementById('SpnAgency').innerHTML = BatchDtls.BatchJobCount[0].AgencyCount;
               document.getElementById('SpanHealth').innerHTML = BatchDtls.BatchJobCount[0].HealthCount;
               document.getElementById('SpanDirect').innerHTML = BatchDtls.BatchJobCount[0].DirectCount;
           }
    </script>--%>
   
 <center>
        <center>                              
                <div id="divAudit" runat="server" style="width: 97%;" class="panel">
                    <div id="div15" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divAuditTrail','Img8');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                 <img id="ImageCon" src="../../../images/Contestant_Details_Icon.png" style="border-width:0px !important;width: 35px;margin-top: 0px;margin-bottom:10px;height: 35px;"/>     
                             
                                <asp:Label ID="Label9" Text="EXCEPTION COMMISSION PAYOUT RELEASE" Style="font-size:19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                 <span id="Img8" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 5px 11px ! important; font-size: 18px;"></span><%--added by ajay sawant 26/4/2018--%>
                            </div>
                        </div>
                    </div>
                        <div id="divAuditTrail" runat="server" style="width: 96%;" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblChnl" Text="Channel" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                          
                                        <asp:DropDownList ID="ddlChnl" runat="server" CssClass="select2-container form-control"
                                            OnSelectedIndexChanged="ddlChnl_SelectedIndexChanged" AutoPostBack="true" TabIndex="1" Height="35px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblSubChnl" Text="Sub Channel" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSubChnl" runat="server" CssClass="select2-container form-control"
                                            OnSelectedIndexChanged="ddlSubChnl_SelectedIndexChanged" AutoPostBack="true" TabIndex="1" Height="35px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblMemTyp" Text="Member Type" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMemTyp" runat="server" CssClass="select2-container form-control"
                                           OnSelectedIndexChanged="ddlMemTyp_SelectedIndexChanged" AutoPostBack="true" TabIndex="1" Height="35px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCommRul" Text="Commission Rule" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCommRul" runat="server" CssClass="select2-container form-control"
                                           OnSelectedIndexChanged="ddlCommRul_SelectedIndexChanged" AutoPostBack="true" TabIndex="1" Height="35px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblProdCod" Text="Product Code" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlProdCod" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" TabIndex="1" Height="35px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                             <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCommCyc" Text="Commission Cycle" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCommCyc" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" TabIndex="1" Height="35px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left;display:none">
                                <asp:Label ID="lblSupCod" Text="Supervisor Code" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3" style="display:none">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSupCod" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" TabIndex="1" Height="35px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAgentCod" Text="Agent Code" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
<%--                                        <asp:DropDownList ID="ddlAgentCod" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" TabIndex="1" Height="35px">
                                        </asp:DropDownList>--%>
                                        <asp:ListBox ID="ddlAgentCod" runat="server" Visible="false" CssClass="select2-container form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlAgentCod_SelectedIndexChanged" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <button type="button" class="btn btn-sample" id="btnConvCD" style="width:85px !important" data-val-code="CD" onclick="funPopUpRwdRul()" data-val-desc="Created Date"> SELECT </button>
                                         <asp:HiddenField ID="hdnMemCode" runat="server"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left;display:none">
                                <asp:Label ID="lblPolicies" Text="Policies" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3" style="display:none">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
<%--                                        <asp:DropDownList ID="ddlPolicies" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" TabIndex="1" Height="35px">
                                        </asp:DropDownList>--%>
                                        <asp:ListBox ID="ddlPolicies" runat="server" CssClass="select2-container form-control" AutoPostBack="true"
                                        SelectionMode="Multiple">
                                        </asp:ListBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                           
                        </div>
                    <div class="row"  style="margin-top: 12px;margin-bottom:6px">
                    <div class="col-sm-12"    align="center">
                        <asp:UpdatePanel runat="server" ID="divnnn" style="margin-top:-68px">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnSearch" style="width:85px" runat="server" CssClass="btn btn-sample" OnClientClick="return ToggleDiv('col')" OnClick="btnSearch_Click">
                                        <span class="glyphicon glyphicon-search" style="color: White;"></span> SEARCH
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnClear"  style="background-color:#FFF;color:#f04e5e; width:85px !important" runat="server" CssClass="btn btn-sample" OnClick="btnClear_Click">
                                        <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: #f04e5e;"></span> CLEAR
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    </div> 

                            <div id="testgrid">
                                 <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                        <ContentTemplate>

                                   <asp:GridView ID="dgCmp" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="10" AllowSorting="True" AllowPaging="true"
                                    CssClass="footable" OnRowDataBound="gvAddMst_RowDataBound" DataKeyNames="MEM_CODE">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>

                                         <asp:TemplateField>
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkprnMEM" runat="server" onclick="TotalAMT(this.id)"/> 
                                                        
                                               <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                                                                            
                                               <div id="divChild" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                    class="table-scrollable,divBorder1">
                                                   

                                                             <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="dgReward" runat="server" CssClass="footable" AllowSorting="True"
                                                                AllowPaging="true" AutoGenerateColumns="false" DataKeyNames="POLICY_NO" OnRowDataBound="dgReward_RowDataBound">
                                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                <PagerStyle CssClass="disablepage" />
                                                                <HeaderStyle CssClass="gridview th" />                                                               
                                                                 <EmptyDataTemplate>
                                                                    <asp:Label ID="Label15" Text="No KPI have been defined" ForeColor="Red" CssClass="control-label" runat="server" />
                                                                </EmptyDataTemplate>
                                                    <Columns>
                                         <asp:TemplateField HeaderText="Action">  
                                                               <HeaderTemplate>
                                                               
                                                                </HeaderTemplate>
                                                     <ItemTemplate>  
                                                            <asp:CheckBox ID="chkOnerrr" runat="server" checked="true" onclick="TotalCommission(this.id,this.name)"  value="true"/>  
                                                       </ItemTemplate>  
                                                     </asp:TemplateField>
                                                        
                                                    <asp:TemplateField HeaderText="Policy Number" SortExpression="POLICY_NO">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPolNum" runat="server" Text='<%# Bind("POLICY_NO")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnPolNum" runat="server" Value='<%# Bind("POLICY_NO")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Product Description" SortExpression="PRODUCT_NAME">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProDesc" runat="server" Text='<%# Bind("PRODUCT_NAME")%>' />
                                                            <asp:HiddenField ID="hdnProDesc" runat="server" Value='<%# Bind("PRODUCT_NAME")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Premium Mode" SortExpression="PREM_MODE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPPT" runat="server" Text='<%# Bind("PREM_MODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnPPT" runat="server" Value='<%# Bind("PREM_MODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Premium" SortExpression="PREM_AMT">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPremium" runat="server" Text='<%# Bind("PREM_AMT")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnPremium" runat="server" Value='<%# Bind("PREM_AMT")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rate" SortExpression="RATE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRate" runat="server" Text='<%# Bind("RATE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRate" runat="server" Value='<%# Bind("RATE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Commission" SortExpression="RWRD_AMT">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCommission" runat="server" Text='<%# Bind("RWRD_AMT")%>' />
                                                            <asp:HiddenField ID="hdnCommission" runat="server" Value='<%# Bind("RWRD_AMT")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                                 
                                                                </asp:GridView>
                                                               </ContentTemplate>
                           
                                                            </asp:UpdatePanel>
                                                          
                                                    </div>

                                                         </ItemTemplate>  
                                                          
                                                      </asp:TemplateField>
                                                    

                                      <asp:TemplateField HeaderText="Member Code" SortExpression="MEM_CODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMEM_CODE2" runat="server" Text='<%# Bind("MEM_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Member Name" SortExpression="LegalName">
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMemName2" runat="server" Text='<%# Bind("LegalName")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cycle Description" SortExpression="BUSI_DESC">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCycDesc" runat="server" Text='<%# Bind("BUSI_DESC")%>' />
                                                    <asp:Label ID="lblCycCode" Visible="false" runat="server" Text='<%# Bind("BUSI_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>                                                   
                                                      <asp:TemplateField HeaderText="Total Commission" SortExpression="SUMPREM">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotComm" runat="server" Text='<%# Bind("SUMPREM")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Pay Date" SortExpression="END_DATE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPayDt" runat="server" Text='<%# Bind("END_DATE")%>' />
                                                    <asp:Label ID="lblRuleSetKey" Visible="false" runat="server" Text='<%# Bind("RULE_SET_KEY")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                                                 </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                                                            </asp:UpdatePanel>

                            </div>
                                <div id="div4" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow:auto;"
                                  >
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvAddMst" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true"  DataKeyNames="MEM_CODE" >
                                        <RowStyle ></RowStyle>
                                        <PagerStyle />
                                        <HeaderStyle />
                                        <Columns>
                                            <asp:TemplateField>
                                                    <ItemTemplate>
                                               

                                                         </ItemTemplate>  
                                                          
                                                      </asp:TemplateField>
                                                    


                                            <asp:TemplateField HeaderText="Member Code" SortExpression="MEM_CODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkall" runat="server" OnCheckedChanged="chkLeftAll_CheckedChanged" 
                                                        AutoPostBack="true"  />
                                                    <asp:Label ID="lblMEM_CODE" runat="server" Text='<%# Bind("MEM_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         
                                            <asp:TemplateField HeaderText="Member Name" SortExpression="LegalName">
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMemName" runat="server" Text='<%# Bind("LegalName")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
<%--                                            <asp:TemplateField HeaderText="Supervisor Name" SortExpression="SuperName">
                                                <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleMethod" runat="server" Text='<%# Bind("SuperName")%>' />
                                                    <asp:HiddenField ID="hdnRuleMethod" runat="server" Value='<%# Bind("SuperName")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>                                           --%>
                                            <asp:TemplateField HeaderText="Cycle Description" SortExpression="BUSI_DESC">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCycDesc" runat="server" Text='<%# Bind("BUSI_DESC")%>' />
                                                    <asp:Label ID="lblCycCode" Visible="false" runat="server" Text='<%# Bind("BUSI_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>                                                   
                                                      <asp:TemplateField HeaderText="Total Commission" SortExpression="SUMPREM">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotComm" runat="server" Text='<%# Bind("SUMPREM")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Pay Date" SortExpression="END_DATE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPayDt" runat="server" Text='<%# Bind("END_DATE")%>' />
                                                    <asp:Label ID="lblRuleSetKey" Visible="false" runat="server" Text='<%# Bind("RULE_SET_KEY")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                                 </asp:GridView>
                                                       </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                                                            </asp:UpdatePanel>
                            <div id="div8" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                <center>
                                    <table>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="Button1" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                            Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="Button1_Click" /><%--OnClick="btnprevious_Click"--%>
                                                        <asp:TextBox runat="server" ID="TextBox1" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="Button2" Text=">" CssClass="form-submit-button" runat="server" Enabled="false" Style="border-style: solid;
                                                            border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                            float: left; margin: 0; height: 30px;" Width="40px" OnClick="Button2_Click" /><%--OnClick="btnnext_Click"--%>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>

                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPayOutRefNo" Text="Payout Ref No." runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                <asp:TextBox ID="txtPayOutRefNo" runat="server" CssClass="form-control" TabIndex="1" Text="10001"
                                   />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblTotComm" Text="Total Commission" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label ID="Label3" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                <asp:TextBox ID="txtTotComm" runat="server" CssClass="form-control" TabIndex="2" Text="0.00"
                                   />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRemark" Text="Remark" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-9">
                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRemarkv" runat="server" CssClass="form-control" TabIndex="24"
                                            TextMode="MultiLine" Columns="20" ClientIDMode="Static" Rows="6" MaxLength="100"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                    <div class="row" style="margin-top: 12px;margin-bottom:6px">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnSave" width="85px" runat="server" CssClass="btn btn-sample" OnClientClick="return ToggleDiv('col')" OnClick="btnSearch_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> SAVE
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel"   style="background-color:#FFF;color:#f04e5e; width:85px !important" runat="server" CssClass="btn btn-sample" OnClick="btnClear_Click">
                                        <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: #f04e5e;"></span> CANCEL
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    </div> 
                                                  
                                  </div>
                        </div>
                    
                </div>
                <br />
            </center>
    </center>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" Height="510px" Width="1000px" ID="pnlRwdRul" display="none"
                Style="text-align: center; top: 20%" CssClass="panel panel-success">
                <iframe runat="server" id="ifrmRwdRul" scrolling="yes" width="100%" frameborder="0"
                    display="none" style="height: 100%;"></iframe>
            </asp:Panel>
            <asp:Label runat="server" ID="Label5" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVwRwdRul" BehaviorID="mdlVwRwdRulBID"
                DropShadow="false" TargetControlID="Label5" PopupControlID="pnlRwdRul" BackgroundCssClass="modalPopupBg">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

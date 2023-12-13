
<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="CompAccSrch.aspx.cs" Inherits="Application_Isys_Saim_CompAccSrch" %>

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

        .panel
        {margin-bottom:20px;background-color:#fff;border:1px solid transparent;border-radius:4px;-webkit-box-shadow:0 0 0 rgba(0,0,0,0)!important;
         box-shadow:0 1px 1px rgba(0,0,0,.05)}

        .ccsalignCenter{
            text-align:center !important;

        }
        .cssalingleft{
        text-align:left !important;


        }

         .cssalingright{
        text-align:right !important;


        }

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
                    $("#dgCntst").append(row);
                });
            });
        })
    </script>
    <script type="text/javascript">

           function Enable() {
            document.getElementById('ctl00_ContentPlaceHolder1_divkpisrch').style.display = "none";
            document.getElementById('ctl00_ContentPlaceHolder1_Loading_gif').style.display = "block";
        }

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

        function funcall() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
        }

        function callsearch() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
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
        <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel">
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <span style="margin-left:6px">
                                    <img id="imgCodeIcon1" src="../../../KMI%20Styles/assets/css/Images/compensation_icon.png"/></span>
<%--                        <span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>&nbsp;commennted by ajay sawant 25/4/2018--%>
                        <asp:Label ID="lblhdr" Text="JOURNAL VOUCHER SEARCH CRITERIA" style="margin-left: 8px;font-size:19px;" runat="server" />
                    </div>                          
                    <div class="col-sm-2">
                             <span id="myImg" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>

                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" style="width: 96%;" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompCode" Text="Member Name" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                               <%-- <asp:TextBox ID="txtMemName" runat="server" CssClass="form-control" TabIndex="1"
                                    MaxLength="8" placeholder="Member Name" />--%>
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FTXCompCd" runat="server" FilterType="Numbers"
                                    TargetControlID="txtMemName">
                                </ajaxToolkit:FilteredTextBoxExtender>--%>

                                  <asp:TextBox ID="txtMemName" runat="server" CssClass="form-control" TabIndex="1"
                                    placeholder="Member Name" MaxLength="8" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTXCompCd" runat="server"
                                    FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars=" "
                                    FilterMode="ValidChars" TargetControlID="txtMemName">
                                </ajaxToolkit:FilteredTextBoxExtender>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompDesc1" Text="Jv No." runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                              <%--  <asp:TextBox ID="txtJVNo" runat="server" CssClass="form-control" TabIndex="2"
                                    placeholder="JV No." MaxLength="40" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars=" "
                                    FilterMode="ValidChars" TargetControlID="txtJVNo">
                                </ajaxToolkit:FilteredTextBoxExtender>--%>


                                   <asp:TextBox ID="txtJVNo" runat="server" CssClass="form-control" TabIndex="2"
                                    MaxLength="40" placeholder="JV No." />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                    TargetControlID="txtJVNo">
                                </ajaxToolkit:FilteredTextBoxExtender>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompTyp" Text="Member Type" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlMemType" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompStat" Text="Tran Status" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" OnClick="btnSearch_Click" OnClientClick="Enable()">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> SEARCH
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnClear" runat="server" style="background-color:#FFF;color:#f04e5e; width:105px !important" CssClass="btn btn-sample"  OnClick="btnClear_Click">
                                    <span style="color:#f04e5e" class="glyphicon glyphicon-remove BtnGlyphicon"></span> CLEAR
                                </asp:LinkButton>
                               <%-- <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" OnClick="btnCancel_Click"
                                    Visible="false">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                </asp:LinkButton>--%>
                              <%--  <asp:LinkButton ID="btnAddNew" runat="server" CssClass="btn btn-sample" OnClick="btnAddNew_Click">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Add New
                                </asp:LinkButton>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
       
        <%--Start By bhau--%>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <div id="divChanlWiseCompenDsn" runat="server" style="width: 97%;" class="panel" visible="false">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divResultDtls','ImgResultDtls');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">

                                <%--<span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>&nbsp;--%><%-- added and commented by ajay sawant 25/4/2018--%>
                                <asp:Label ID="lblchnldesgin" Text="Channel Wise Compensations in Design" Style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <span id="ImgResultDtls" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divResultDtls" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <%--<div class="panel-body" style="margin-top: -1%; margin-right: 2%; margin-left: 2%;">--%>
                                    <div style="margin-right: 0%; margin-left: 11px;" id="dvNewReg">
                                        <div class="row" style="color: White;">
                                            <div class="col-sm-4" style="text-align: center; width: 31%; padding: 20px; margin: 1% 1% 1% 1%;
                                                box-shadow: 0 5px 5px #ACACAC; border-radius: 5px; background-color: #58caf0;"> <%--#5bc0de--%>
                                               <%-- <span id="SpnAgency" style="font-size: 200%; font-weight: bold" runat="server">0</span>--%>
                                                 <asp:Label runat="server" ID="SpnAgency" Text="0" style="font-size: large; font-weight: bold;"></asp:Label>
                                                <br />
                                                <span id="Span2" style="font-size: small; font-weight: bold;">AGENCY </span>
                                            </div>
                                            <div class="col-sm-4" style="margin: 1% 1% 1% 1%; text-align: center; width: 31%;
                                                padding: 20px; box-shadow: 0 5px 5px #ACACAC; border-radius: 5px; background-color: #aaf058;"> <%--#5cb85c--%>
                                               <%-- <span id="SpanHealth" style="font-size: 200%; font-weight: bold" runat="server">0</span>--%>
                                                  <asp:Label runat="server" ID="SpanHealth" Text="0" style="font-size: large; font-weight: bold;"></asp:Label>
                                                <br />
                                                <span id="Span3" style="font-size: small; font-weight: bold;">HEALTH</span>
                                            </div>
                                            <div class="col-sm-4" style="margin: 1% 1% 1% 1%; width: 31%; text-align: center;
                                                padding: 20px; box-shadow: 0 5px 5px #ACACAC; border-radius: 5px; background-color: #f2b852;"> <%--#f0ad4e--%>
                                               <%-- <span id="SpanDirect" style="font-size: 200%; font-weight: bold" runat="server">0</span>--%>
                                                  <asp:Label runat="server" ID="SpanDirect" Text="0" style="font-size: large; font-weight: bold;"></asp:Label>
                                                <br />
                                                <span id="Span4" style="font-size: small; font-weight: bold;">DIRECT</span>
                                            </div>
                                        </div>
                                    </div>
                                <%--</div>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--End by bhau--%>

        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="divcmpsrchhdrcollapse" runat="server" style="width: 97%;" class="panel ">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpisrch','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <div class="col-sm-6">
                                    <span style="margin-left:6px">
                                    <img id="imgCodeIconnew" src="../../../KMI%20Styles/assets/css/Images/compensation_icon.png"/></span>
                                <asp:Label ID="lblCmpSrch" Text="JOURNAL VOUCHER SEARCH RESULTS" style="margin-left:15px;font-size:19px;" runat="server" />
                                </div>
                                <div class="col-sm-6">
                                            <img id="Loading_gif" style="display:none;  margin-top:5px;margin-right:100px" runat="server" 
                                    src="../Recruit/assets/img/animated_gif_loader.gif" />
                                </div>
                               <%-- <span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>&nbsp;--%><%--commented by ajay sawant 25/4/2018--%>
                                 
                            </div>


                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate>
                                        <%--<img id="Img2" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 10px;"
                                            alt="" onclick="callsearch();"  />--%>
                                        <span id="Img1" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divkpisrch" runat="server" style="width: 96%; padding: 10px; overflow-x:scroll;">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgCmp" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="10" AllowSorting="True" OnSorting="dgCmp_Sorting" AllowPaging="true"
                                    CssClass="footable" OnRowDataBound="dgCmp_RowDataBound"  >
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                   <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                <div id="divChild" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                    class="table-scrollable,divBorder1">
                                                    <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                        <ContentTemplate>

                                                          <%--Childgrid--%>

                                                            <asp:GridView ID="dgCntst" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="dgCntst_RowDataBound"
                                                                AllowSorting="False" AllowPaging="false" CssClass="footable" >
                                                                <%--CssClass="dataTable details"--%>
                                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                <PagerStyle CssClass="disablepage" />
                                                                <HeaderStyle CssClass="gridview th" />
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                                        runat="server" />
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Product Name" SortExpression="Product" ItemStyle-HorizontalAlign="Center" >
                                                                      
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemStyle CssClass="cssalingright" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblProdName" runat="server" Text='<%# Bind("Product")%>'></asp:Label>
                                                                            <asp:HiddenField ID="hdnCnstCode" runat="server" Value='<%# Bind("Product")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Posting Key" SortExpression="Posting_Key">
                                                                        <%--Added New--%>
                                                                        <ItemStyle CssClass="cssalingright" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPostKey" runat="server" Text='<%# Bind("Posting_Key")%>'></asp:Label>
                                                                            <%--<asp:HiddenField ID="hdncmpcode" runat="server" Value='<%# Bind("CMPNSTN_CODEVAL")%>' />--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="GL Code" SortExpression="GLCode" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <%--Added New--%>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle CssClass="cssalingright" />                                       
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGlCode" runat="server" Text='<%# Bind("GLCode")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Gross Comm." SortExpression="Gross_Commission">
                                                                        <ItemStyle CssClass="cssalingright" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCmpDesc" runat="server" Text='<%# Bind("Gross_Commission")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                 

                                                                    <asp:TemplateField HeaderText="Function area" SortExpression="Function_area" >
                                                                        <ItemStyle CssClass="cssalingright" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("Function_area")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField> 
                                                                </Columns>
                                                            </asp:GridView>

                                                          <%--Childgrid--%>


                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField HeaderText="JV No" SortExpression="[JV No]" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>          
                                                <asp:Label ID="lnkCmpCode"  Text='<%# Bind("[JV No]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="JV Date" SortExpression="[JV Date]" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>                                           
                                                <asp:Label ID="lblJVDate"  Text='<%# Bind("[JV Date]")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="ccsalignCenter" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Member Name" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemName" Text='<%# Bind("[Member Name]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Member Code" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemCode" Text='<%# Bind("[Member Code]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSapCode" Text='<%# Bind("[SAP Code]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Gross Comm" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrossComm" Text='<%# Bind("[Gross Comm]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Channel" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChannel" Text='<%# Bind("[Channel]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Trans Type" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTransType" Text='<%# Bind("[Trans Type]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Member Type" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemType" Text='<%# Bind("[Member Type]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Narration" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNarr" Text='<%# Bind("[Narration]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                     

                                        <asp:TemplateField HeaderText="Location Name" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocatName" Text='<%# Bind("[Location Name]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cost Center" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostcent" Text='<%# Bind("[Cost Center]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="GST State Code Comp" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGstStComp" Text='<%# Bind("[GST State CODE comp]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                           <asp:TemplateField HeaderText="GST State Code Mem" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGSTStCome" Text='<%# Bind("[GST State Code Mem]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="GST Tax Code" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGstTCd" Text='<%# Bind("[GST Tax Code]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="GST Regn No" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGstrefno" Text='<%# Bind("[GST Reg No]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="HSN SSC Code" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHsnCode" Text='<%# Bind("[HSN SSC CODE]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingright" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Tran Status" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTStatus" Text='<%# Bind("[Trans Status]") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="cssalingleft" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>

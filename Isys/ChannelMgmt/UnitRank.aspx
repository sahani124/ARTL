<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnitRank.aspx.cs" Inherits="INSCL.UnitRank"
    MasterPageFile="~/iFrame.master" %>

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
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
   <%-- <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>--%>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"  type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
   <%-- <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
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
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>--%>




    <style type="text/css">
        .modal-dialog {
            position: relative;
            display: table;
            overflow-y: auto;
            overflow-x: auto;
            width: auto;
            min-width: 50px;
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

    <style>
        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
    </style>

    <style type="text/css">
        .dataTable {
            width: 100% !important;
            clear: both;
            margin-top: 5px;
            border: none;
        }

        .dataTables_filter label {
            line-height: 32px;
        }

        .dataTable .row-details {
            margin-top: 3px;
            display: inline-block;
            cursor: pointer;
            width: 14px;
            height: 14px;
        }

            .dataTable .row-details.row-details-close {
                background: url("../img/datatable-row-openclose.png") no-repeat 0 0;
            }

            .dataTable .row-details.row-details-open {
                background: url("../img/datatable-row-openclose.png") no-repeat 0 -23px;
            }

        .dataTable .details {
            background-color: #eee;
        }

            .dataTable .details td,
            .dataTable .details th {
                padding: 4px;
                background: none;
                border: 0;
            }

            .dataTable .details tr:hover td,
            .dataTable .details tr:hover th {
                background: none;
            }

            .dataTable .details tr:nth-child(odd) td,
            .dataTable .details tr:nth-child(odd) th {
                background-color: #eee;
            }

            .dataTable .details tr:nth-child(even) td,
            .dataTable .details tr:nth-child(even) th {
                background-color: #eee;
            }

        .dataTable > thead > tr > th.sorting,
        .dataTable > thead > tr > th.sorting_asc,
        .dataTable > thead > tr > th.sorting_desc {
            padding-right: 18px;
        }

        .dataTable .table-checkbox {
            width: 8px !important;
        }

        @media (max-width: 768px) {
            .dataTables_wrapper .dataTables_length .form-control,
            .dataTables_wrapper .dataTables_filter .form-control {
                display: inline-block;
            }

            .dataTables_wrapper .dataTables_info {
                top: 17px;
            }

            .dataTables_wrapper .dataTables_paginate {
                margin-top: -15px;
            }
        }

        @media (max-width: 480px) {
            .dataTables_wrapper .dataTables_filter .form-control {
                width: 175px !important;
            }

            .dataTables_wrapper .dataTables_paginate {
                float: left;
                margin-top: 20px;
            }
        }

        .dataTables_processing {
            position: fixed;
            top: 50%;
            left: 50%;
            min-width: 125px;
            margin-left: 0;
            padding: 7px;
            text-align: center;
            color: #333;
            font-size: 13px;
            border: 1px solid #ddd;
            background-color: #eee;
            vertical-align: middle;
            -webkit-box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
            -moz-box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
            box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
        }

            .dataTables_processing span {
                line-height: 15px;
                vertical-align: middle;
            }

        .dataTables_empty {
            text-align: center;
        }

        .ajax__calendar {
            z-index: 100px;
        }

        .form-submit-button {
            box-shadow: none !important;
        }

        .disablepage {
            display: none;
        }

        .divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .transbox {
            width: 400px;
            height: 180px;
            margin: 30px 50px;
            background-color: #ffffff;
            border: 1px solid black;
            opacity: 0.6;
            filter: alpha(opacity=60); /* For IE8 and earlier */
            z-index: inherit;
        }

        .ChildGrid td {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }

        .ChildGrid th {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }
    </style>

    <script type="text/javascript">

        $(function () {
            debugger;

            $("[id*=txtEff]").datepicker({ minDate: '01/04/2021', maxDate: '31/03/2022', dateFormat: 'dd/mm/yy' });
            $("[id*=txtCseDt]").datepicker({ maxDate: '31/03/2022', minDate: '-0d', dateFormat: 'dd/mm/yy' });
        });



    </script>



    <script type="text/javascript">

        function popup() {
            $("#myModal").modal();
        }

        function popupHist() {
            debugger
            $("#myModal1").modal();
        }

          function AppliacbleToDate() {
            debugger;
              $("[id*=txtEff]").datepicker({ minDate: '01/04/2021', maxDate: '31/03/2022', dateFormat: 'dd/mm/yy' });
          }
        
         function Appliacble() {
            debugger;
              $("[id*=txtCseDt]").datepicker({ maxDate: '31/03/2022', minDate: '-0d', dateFormat: 'dd/mm/yy' });
         }

        function ShowReqDtl1(divName, btnName) {
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

        function doValidateName(src, args) {
            var result = true;
            var sString = args.Value;

            sString = document.getElementById("ctl00_ContentPlaceHolder1_txtUnitRank").value;

            var iChars = "!@$^*-_+={}[]()|\:;?><,'~ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            for (var i = 0; i < sString.length; i++) {
                if (iChars.indexOf(sString.charAt(i)) != -1) {
                    result = false;
                }
            }

            args.IsValid = result;
        }

        function done() {

            window.location.href = "SearchUnitRank.aspx";
            return false;
        }

        function validate() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strContent + "txtUnitRank") != null) {
                if (document.getElementById(strContent + "txtUnitRank").value == "") {
                    alert("Please Enter Unit Rank");
                    document.getElementById(strContent + "txtUnitRank").focus();
                    return false;
                }
            }


            if (document.getElementById(strContent + "txtDesc1") != null) {
                if (document.getElementById(strContent + "txtDesc1").value == "") {
                    alert("Please Enter Unit Rank Description 1");
                    document.getElementById(strContent + "txtDesc1").focus();
                    return false;
                }
            }


            if (document.getElementById(strContent + "txtRnkHdrDesc1") != null) {
                if (document.getElementById(strContent + "txtRnkHdrDesc1").value == "") {
                    alert("Please Enter Header Description 1");
                    document.getElementById(strContent + "txtRnkHdrDesc1").focus();
                    return false;
                }
            }


            if (document.getElementById(strContent + "txtEff") != null) {
                if (document.getElementById(strContent + "txtEff").value == "") {
                    alert("Please select Effective Date");
                    document.getElementById(strContent + "txtEff").focus();
                    return false;
                }
            }
        }

        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";

            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(document.getElementById(strContent + divId)).slideUp();
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(document.getElementById(strContent + divId)).slideDown();
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }

        //Popup Of History Page Function. 
        function funPopUp() {
            debugger;
            var value = document.getElementById('<%= hdnBizsrc.ClientID%>').value;
            var Header = "Version History Of Unit Rank";
            var Flag = "UnitRank";
            $find("mdlViewBIDLOB").show()
            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "PopupCompanyHistory.aspx?&Code=" + value + "&mdlpopup=mdlViewBIDLOB" + "&Header=" + Header + "&Flag=" + Flag;
        }

        function HeaderDesc1(id) {
            debugger;
            var strText = document.getElementById(id).value;
            var count = 0;
            if (strText.length > 0) {
                for (var i = 0; i < strText.length; i++) {
                    if (strText.charAt(i) == " ") {
                        count++;
                    }
                }
                if (count > 1) {
                    alert("More than 1 spaces are not allowed in Header Desc 1 ");
                    document.getElementById(id).value = "";
                    document.getElementById(id).focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }
            }
        }

        function HeaderDesc2(id) {
            debugger;
            var strText = document.getElementById(id).value;
            var count = 0;
            if (strText.length > 0) {
                for (var i = 0; i < strText.length; i++) {
                    if (strText.charAt(i) == " ") {
                        count++;
                    }
                }
                if (count > 1) {
                    alert("More than 1 spaces are not allowed in Header Desc 2 ");
                    document.getElementById(id).value = "";
                    document.getElementById(id).focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }
            }
        }

        function HeaderDesc3(id) {
            debugger;
            var strText = document.getElementById(id).value;
            var count = 0;
            if (strText.length > 0) {
                for (var i = 0; i < strText.length; i++) {
                    if (strText.charAt(i) == " ") {
                        count++;
                    }
                }
                if (count > 1) {
                    alert("More than 1 spaces are not allowed in Header Desc 3 ");
                    document.getElementById(id).value = "";
                    document.getElementById(id).focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
        }

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .ajax__calendar {
            position: static;
        }

        .pagelink span {
            font-weight: bold;
        }

        .test {
            color: Navy;
            background-color: #3399ff;
        }
    </style>
    <center>

     <asp:UpdatePanel ID="up_UnitR" runat="server">
            <ContentTemplate>
             <div class="panel" id="divModification" runat="server" style="margin-left: 2%; margin-right: 2%;">
                    <div id="Div18" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divmodifybody','btndivmodify');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
         <asp:Label ID="Label21" runat="server" Text="Correction or changes in Unit Rank Setup"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="btndivmodify" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>         
           </div>
                   <div id="divmodifybody" runat="server" class="panel-body" style="display:block">
               <div class="row" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left;margin-top: 10px;">
                        <asp:Label ID="lblModMode" runat="server" Text="Mod Mode" CssClass="control-label" /> 
                        <span style="color: #ff0000"> *</span>
                        </div>
                         <div class="col-md-3" style="text-align:left"  >
                        <div class="btn-group"  role="group" style="margin-left: -162px;">
                        <asp:RadioButtonList  ID="rbCorrection" runat="server"  CellPadding="2" CellSpacing="2"  RepeatDirection="Horizontal"  AutoPostBack="true" OnSelectedIndexChanged="rbCorrection_OnSelectedIndexChanged" >
                        <asp:ListItem Text="&nbspCorrection" Selected="True"  value="CR"  class="btn btn-default"  />
                        <asp:ListItem Text="&nbspChanges&nbsp"  value="CH"  class="btn btn-default" style="margin-left: 0px;"  />
                     </asp:RadioButtonList>
                    </div>
                       </div>
                        <div class="col-md-3">
                     </div>
                      <div class="col-md-3">
                     </div>
                  </div>
                </div>
            </div>
             <div class="card PanelInsideTab" id="div1" runat="server" style="margin-left: 2%; margin-right: 2%;">
                <div id="divUnitRnkhdr" runat="server" class="panelheadingAliginment"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divUnitRnkhdrcollapse','btnpersnl');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                       <asp:Label ID="lblChannelUnitRank"  runat="server" CssClass="control-label HeaderColor"  Font-Size="19px" />
                 
                    </div>
                    <div class="col-sm-2">
                     
                        <span id="btnpersnl" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                <div id="divUnitRnkhdrcollapse" style="display:block;" runat="server" class="panel-body" >
                                
                       <div class="row" style="margin-bottom:5px;">
                                <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="lblChannel" runat="server"  CssClass="control-label"></asp:Label>
                                    <span style="color: #ff0000"> *</span>
                                   
                                   </div>

                                <div class="col-sm-3">
                          <asp:TextBox ID="lblSalesChannel" runat="server" Enabled="false" Visible="false"  CssClass="form-control"></asp:TextBox>
                         
                            <asp:DropDownList ID="ddlSalesChannel" runat="server" Visible="False" CssClass="form-control" MaxLength="50">
                               
                            </asp:DropDownList>
                                    
                            <asp:RequiredFieldValidator ID="rfvBizSrc" runat="server" ControlToValidate="ddlSalesChannel"
                               Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                       
                        <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblRank" runat="server"  CssClass="control-label"></asp:Label>&nbsp;
                            <span style="color: #ff0000"> *</span>
                           </div>
                            
                            
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="new" runat="server">
                                    <ContentTemplate>

                             <asp:TextBox ID="txtUnitRank" runat="server"  Visible="false" CssClass="form-control" MaxLength="3" AutoPostBack="true" 
                               onChange="javascript:this.value=this.value.toUpperCase();" OnTextChanged="txtUnitRank_TextChanged"></asp:TextBox>
                                      <asp:TextBox ID="lblUnitRank" runat="server"  Visible="false"  CssClass="form-control"></asp:TextBox>
                                        

                            <asp:RequiredFieldValidator ID="rfvUnitRank" runat="server" ControlToValidate="txtUnitRank"
                               SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvUnitRank" runat="server" ControlToValidate="txtUnitRank"
                                ErrorMessage="Invalid Unit Rank!" ClientValidationFunction="doValidateName" Display="Dynamic"></asp:CustomValidator>
                            <ajaxToolkit:FilteredTextBoxExtender ID="txtUnitTypeFTX" runat="server" ValidChars="."
                                TargetControlID="txtUnitRank" FilterType="Custom, Numbers">
                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ContentTemplate>
                                </asp:UpdatePanel>

                       </div>
                       
                       
                       </div>
                              <div class="row" style="margin-bottom:5px;">
                             <div class="col-sm-3" style="text-align:left">
                          
                             <asp:Label ID="lblDesc1" runat="server" CssClass="control-label"></asp:Label>&nbsp;
                            <span style="font-size: 10pt; color: #ff0000"> *</span>
                            </div>

                            <div class="col-sm-3" >
                            <asp:TextBox ID="txtDesc1" runat="server" CssClass="form-control"  MaxLength="50" 
                          onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUnitDesc1" runat="server" ControlToValidate="txtDesc1"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                        
                        <div class="col-sm-3" style="text-align:left">
                           <asp:Label ID="lblHdrDesc01" runat="server"   CssClass="control-label"></asp:Label>&nbsp;
                           <span style="font-size: 10pt; color: #ff0000"> *</span>
                       </div>

                        <div class="col-sm-3">
                              <asp:TextBox ID="txtRnkHdrDesc1" runat="server" CssClass="form-control" onblur="HeaderDesc1(this.id);return false;" 
                                 MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>

                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" ValidChars=" "  TargetControlID="txtRnkHdrDesc1" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            
                            <asp:RequiredFieldValidator ID="rfvRankHdrDesc" runat="server" ControlToValidate="txtRnkHdrDesc1"
                               Display="Dynamic"></asp:RequiredFieldValidator>
                              
                     </div>
                      
                </div>
                       <div class="row" style="margin-bottom:5px;">
                  <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblDesc2" runat="server"   CssClass="control-label"></asp:Label>
                 </div>

                   <div class="col-sm-3">
                            <asp:TextBox ID="txtDesc2" runat="server" CssClass="form-control"  MaxLength="50"
                                onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                ValidChars=",-.()/& " TargetControlID="txtDesc2" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                            </ajaxToolkit:FilteredTextBoxExtender>
                       
                   </div>

                        <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblAllowSales" runat="server" CssClass="control-label"></asp:Label>
                     </div>

                     <div class="col-sm-3">
                             <asp:TextBox ID="txtRnkHdrDesc2" runat="server" CssClass="form-control" MaxLength="50"  onblur="HeaderDesc2(this.id);return false;"
                                onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars=" " 
                                TargetControlID="txtRnkHdrDesc2" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                            </ajaxToolkit:FilteredTextBoxExtender>
                       </div>     
                   </div>
                          <div class="row" style="margin-bottom:5px;">
                   <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblDesc3" runat="server"  CssClass="control-label"></asp:Label>
                     </div>
                             
                     <div class="col-sm-3">
                             <asp:TextBox ID="txtDesc3" runat="server" CssClass="form-control"
                                MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" 
                                ValidChars=",-.()/& " TargetControlID="txtDesc3" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            
                            </div>
                       
                       <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblAllowServices" runat="server" CssClass="control-label"></asp:Label>
                          </div> 

                           <div class="col-sm-3" >
                            <asp:TextBox ID="txtRnkHdrDesc3" runat="server" CssClass="form-control" onblur="HeaderDesc3(this.id);return false;"
                          MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"  runat="server" ValidChars=" " 
                                TargetControlID="txtRnkHdrDesc3" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers"> 
                            </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
                    </div>
                   </div> 
            </ContentTemplate>
            </asp:UpdatePanel>

     <%--<br />--%>
     <%--others div--%>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
             <div class="card PanelInsideTab" id="div3" runat="server"  style="margin-left: 2%; margin-right: 2%;">
                  <div id="divOtherDetails" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divOthers','btncallmap');return false;">
             <div class="row">
                 <div class="col-sm-10" style="text-align: left">
                  
                      <asp:Label ID="lblODtls" Text="Hierarchy Setup" runat="server" CssClass="control-label HeaderColor"  Font-Size="19px" />
                 </div>
                 <div class="col-sm-2">
                     <span id="btncallmap" class="glyphicon glyphicon-chevron-down" style="float: right;
                         color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                 </div>
             </div>
         </div>
                  <div id="divOthers" style="display:block;" runat="server" class="panel-body">
                    <div class="row" style="margin-bottom:5px;">
                    <div class="col-sm-3" style="text-align: left">
                         <asp:Label ID="lblPer" runat="server"  CssClass="control-label"></asp:Label>
                      </div>
                      
                        <div class="col-sm-3">
                       <asp:TextBox ID="txtPer" runat="server" visible="false" CssClass="form-control"  MaxLength="50" />
                                <asp:DropDownList ID="ddlFinancialYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                            </div>


                        <div class="col-sm-3" style="text-align: left">
                          <asp:Label ID="lblVer" runat="server"  CssClass="control-label"></asp:Label>   
                     </div>
                           

                           <div class="col-sm-3">
                            <asp:TextBox ID="txtVer" runat="server"   CssClass="form-control" MaxLength="50" />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" FilterType="Custom, Numbers"
                                runat="server" ValidChars="." TargetControlID="txtVer">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>

                        <div class="row" style="margin-bottom:5px;"> 
                    <div class="col-sm-3" style="text-align: left">
                               <asp:Label ID="lblEff" runat="server"  CssClass="control-label"></asp:Label>&nbsp;
                                 <span style="font-size: 10pt; color: #ff0000"> *</span>
                                 </div>
                     <div class="col-md-3">
<%--                                              <asp:TextBox ID="txtEff" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control"   onmousedown="AppliacbleToDate()" onmouseup="AppliacbleToDate()"/>--%>
                          <asp:TextBox ID="txtEff" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control"   onmousedown="Appliacble()" onmouseup="Appliacble()"/>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" FilterType="Custom, Numbers" runat="server" ValidChars="/" TargetControlID="txtEff">
                        </ajaxToolkit:FilteredTextBoxExtender>
                   </div>
                                           
                    <div class="col-sm-3" style="text-align: left">
                           <asp:Label ID="lblCsedt" runat="server" Height="22px" Width="150px" CssClass="control-label"></asp:Label> 
                      </div> 
                    <div class="col-sm-3">

                         <asp:TextBox ID="txtCseDt" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control"   onmousedown="AppliacbleToDate()" onmouseup="AppliacbleToDate()"/>
                                </div>
                            </div>
                       <div class="row" style="margin-bottom:5px;"> 
                          <div class="col-md-3" style="text-align:left">
                          <asp:Label ID="lblChnStatus" Text="Status " runat="server" CssClass="control-label" /> 
                           <span style="color: #ff0000"> *</span>
                     </div>
                        <div class="col-sm-3">
                        <asp:DropDownList Enabled="false" id="ddllStatus" style="margin-right: -3px;" CssClass="form-control"  runat="server">
                       <asp:ListItem   Value="Draft">Draft</asp:ListItem>
                     <asp:ListItem Selected="True" Value="Final">Final</asp:ListItem>

                        </asp:DropDownList>
                        </div>
                     
                        </div>
           </div>
                     
                 </div>
                   </ContentTemplate>
    </asp:UpdatePanel>

     <div id="div2" runat="server" style="width: 95%;">
       <div class="row" style="margin-top:12px;">
                    <div class="col-sm-12" align="center">
                                        

                         <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sample" Text="Update" CausesValidation="false"
                          OnClientClick="return validate();"      OnClick="btnUpdate_Click">
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span> UPDATE
                        </asp:LinkButton> 

                         <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample" Text="Update" CausesValidation="false"
                          OnClientClick="return validate();"      OnClick="btnSave_Click">
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span> SAVE
                        </asp:LinkButton> 
               
                       
                 <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" style="background-color:#FFF;color:#f04e5e; width:85px !important" CausesValidation="False" Text="CANCEL" 
                               OnClick="btnCancel_Click"> <%--onClientclick="javascript:window.history.go(-1);return false;"--%>
                             <span style="color:#f04e5e" class="glyphicon glyphicon-remove BtnGlyphicon"></span> CANCEL
                             </asp:LinkButton>
                            
                                            <asp:LinkButton ID="btnshowHist" runat="server" CssClass="btn btn-sample" 
                              CausesValidation="false" TabIndex="15" OnClientClick="funPopUp();return false;">  
                                  <span class="glyphicon glyphicon-dashboard" style="color:White"> </span> VIEW HISTORY
                                </asp:LinkButton>
                             
                             </div> 
                                   
                                   </div>
                </div>
        
  </center>
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color: #034ea2;">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true" ForeColor="white"></asp:Label>

                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server" CssClass="control-label"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-sample" data-dismiss="modal" style='margin-top: -6px;'>
                        <span class="glyphicon glyphicon-ok"></span>OK

                    </button>

                </div>
            </div>

        </div>
    </div>
    <center>
    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="500px" Height="250px" DefaultButton="btnok">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <center>
        <table>
            <tr>
                <td style="width: 391px">
                    <br />
                    <center>
                        <asp:Label ID="lblpopup" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        </center>
          <center>  <asp:Button ID="btnok" runat="server" Text="OK" OnClick="btOK_Click"   CssClass="btn blue" OnClientClick="javascript:done();"
               Width="80px"  Enabled="false"/></center>
    </asp:Panel>
    </center>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>

    <div class="modal fade" id="myModal1" role="dialog">
        <div class="modal-dialog modal-sm" style="width: 1270px; padding: 49px">
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; text-align: initial; background-color: #dff0d8;">
                    <asp:Label ID="lblchnlVer" Text="Version history of unit rank setup" runat="server" Font-Bold="true" Style="font-size: initial"></asp:Label>
                </div>
                <div class="panel" id="div19" runat="server" style="margin-left: 2%; margin-right: 2%;">
                    <div id="Div20" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divmodifybody','btndivmodify1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label23" runat="server" Text="Search Result" CssClass="control-label" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                            </div>
                        </div>
                    </div>
                    <div id="div21" runat="server" class="panel-body" style="display: block">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="Label24" runat="server" Text="Modification Mode" CssClass="control-label" />
                            </div>
                            <div class="col-md-3" style="text-align: left">
                                <asp:RadioButtonList ID="rdMode" runat="server" CellPadding="2" CellSpacing="2"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Text="&nbspCorrection&nbsp" Value="CR">  </asp:ListItem>
                                    <asp:ListItem Text="&nbspChanges&nbsp" Value="CH"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="lblFinyer" Text="Financial year" CssClass="control-label" runat="server" />
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlFinYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                            </div>
                        </div>
                    </div>
                </div>
                <div id="div22" runat="server" style="width: 98%;">
                    <div class="row">
                        <div class="col-md-12" style="text-align: center">
                            <%--<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sample"
                                CausesValidation="false" OnClick="btnSearch_Click" TabIndex="14"> 
                                  <span class="glyphicon glyphicon-search BtnGlyphicon" style="color:White"> </span> Search </asp:LinkButton>--%>
                            <button type="button" class="btn btn-sample" data-dismiss="modal">
                                <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span>&nbspCancel
                            </button>
                        </div>
                    </div>
                </div>

                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup1" runat="server"></asp:Label>
                    <div id="divsrch" runat="server" class="panel-body" style="display: block; overflow: auto">
                        <asp:GridView AllowSorting="True" ID="gvhistory" runat="server" CssClass="footable"
                            AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                            <FooterStyle CssClass="GridViewFooter" />
                            <RowStyle CssClass="GridViewRowNew" />
                            <HeaderStyle CssClass="gridview" />
                            <PagerStyle CssClass="disablepage" />
                            <SelectedRowStyle CssClass="GridViewSelectedRow" />
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Channel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("BizSrc") %>'
                                            CommandArgument='<%# Eval("BizSrc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Rank">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRank") %>'
                                            CommandArgument='<%# Eval("UnitRank") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="UnitRank Desc 01">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankDesc01") %>'
                                            CommandArgument='<%# Eval("UnitRankDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="UnitRank Desc 02">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankDesc02") %>'
                                            CommandArgument='<%# Eval("UnitRankDesc02") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="UnitRank Desc 03">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankDesc03") %>'
                                            CommandArgument='<%# Eval("UnitRankDesc03") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Rank Hdr01">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankHdr01") %>'
                                            CommandArgument='<%# Eval("UnitRankHdr01") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Rank Hdr02">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankHdr02") %>'
                                            CommandArgument='<%# Eval("UnitRankHdr02") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Rank Hdr03">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankHdr03") %>'
                                            CommandArgument='<%# Eval("UnitRankHdr03") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Period">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period") %>'
                                            CommandArgument='<%# Eval("Period") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Version">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Version") %>'
                                            CommandArgument='<%# Eval("Version") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Eff. Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("EffDate") %>'
                                            CommandArgument='<%# Eval("EffDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Cease Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CeaseDate") %>'
                                            CommandArgument='<%# Eval("CeaseDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created by">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateBy") %>'
                                            CommandArgument='<%# Eval("CreateBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateDtim") %>'
                                            CommandArgument='<%# Eval("CreateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Updated Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateDtim") %>'
                                            CommandArgument='<%# Eval("UpdateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mod. Mode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ModMode") %>'
                                            CommandArgument='<%# Eval("ModMode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Status") %>'
                                            CommandArgument='<%# Eval("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="modal-footer" id="DivButton" visible="false" runat="server" style="text-align: center">
                    <button type="button" visible="false" runat="server" class="btn btn-sample" data-dismiss="modal" style='margin-top: -93px; border-radius: 15px;'>
                        <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span>&nbspCancel
                    </button>
                </div>


            </div>
        </div>
    </div>

    <%--Modal popup Setup Div  --%>
    <asp:Panel runat="server" ID="PnlPopupLOB" Width="1000px" Height="550px" display="none" top="52" left="529px">
        <iframe runat="server" id="IframeLOB" width="100%" frameborder="0" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopExtndrLOB" BehaviorID="mdlViewBIDLOB"
        DropShadow="false" TargetControlID="lblpopup" PopupControlID="PnlPopupLOB" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hdnBizsrc" runat="server" />

    <script type="text/javascript">
        hideRadioSymbol();

        function hideRadioSymbol() {
            debugger;
            var rads = new Array();
            rads = document.getElementsByName('ctl00$ContentPlaceHolder1$rbCorrection'); //Whatever ID u have given to ur radiolist.
            for (var i = 0; i < rads.length; i++)
                document.getElementById(rads.item(i).id).style.display = 'none'; //hide
        }

        function Chk(Flag) {
            debugger;
            if (Flag == 1) {


                document.getElementById("ctl00_ContentPlaceHolder1_rbCorrection_0").style.display = 'none'; //hide
                document.getElementById("ctl00_ContentPlaceHolder1_rbCorrection_1").style.display = 'none'; //hide
            }
            //Enable Controls
            else if (Flag == 2) {

                document.getElementById("ctl00_ContentPlaceHolder1_rbCorrection_0").style.display = 'none'; //hide
                document.getElementById("ctl00_ContentPlaceHolder1_rbCorrection_1").style.display = 'none'; //hide 
            }
            //Disable Controls
            else if (Flag == 0) {

                document.getElementById("ctl00_ContentPlaceHolder1_rbCorrection_0").style.display = 'none'; //hide
                document.getElementById("ctl00_ContentPlaceHolder1_rbCorrection_1").style.display = 'none'; //hide
            }
        }
    </script>

<%--    <script type='text/javascript'>
        $(function () {
            $("[id*=txtEff]").attr("readonly", true);
            $("[id*=txtEff]").attr.backgroundcolor = "white";
            $("[id*=txtCseDt]").attr("readonly", true);
            $("[id*=txtCseDt]").attr.backgroundcolor = "white";

           
        })
    </script>--%>




</asp:Content>

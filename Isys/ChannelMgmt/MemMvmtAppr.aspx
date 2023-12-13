<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MemMvmtAppr.aspx.cs" Inherits="Application_ISys_ChannelMgmt_MemMvmtAppr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
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
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
  
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    
  

 <script type="text/javascript" src="../../../Scripts/common.js"></script>
 <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
 <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
 <script type="text/javascript" src="../../../Scripts/formatting.js"></script>   
    <script src="../../../KMI Styles/Bootstrap/css/jquery-1.10.2.min.js" type="text/javascript"></script>
    
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>

    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
<%--    <script type="text/javascript" src="../../../Scripts/CalendarControl.js"></script>--%>
    
    
    
  
   <style type="text/css">
         .btn-tab
        {
            color:#3c763d;
            background-color:#dff0d8;
            border-color:#d6e9c6;
        }
            
             .nav-tabs > li.active > a,
        .nav-tabs > li.active > a:hover,
        .nav-tabs > li.active > a:focus{
            color: #555555;
            background-color: #dff0d8;  
        } 
        
        ul#menu li a:active{background:white;}
            
            
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
 


    <style type="text/css">
        .ajax__calendar
        {
            position:static;
        }
        .pagelink span
        {
            font-weight: bold;
        }
        /*Added: Parag @ 25032014*/
        
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        
         .disablepage
        {
            display: none;
        }
    </style>
    <script language="javascript" type="text/javascript">
       
       
       

      function addCssClassByClick(flag) {
            debugger;
          //  abtnclearlert("Enter");
            if (flag == 1) {

                alert("Hello");
                $("#ctl00_ContentPlaceHolder1_Employee").addClass("btn-tab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Agent").removeClass("btn-tab")


            }

            else if (flag == 2) {
              //  alert("Hello11");
                $("#ctl00_ContentPlaceHolder1_Employee").removeClass("btn-tab")
                $("#ctl00_ContentPlaceHolder1_Agent").addClass("btn-tab btn btn-default")


            }



        }


        var path = "<%=Request.ApplicationPath.ToString()%>";

        function ShowReqDtl1(divName, btnName) {
        
            debugger;
            try {
                
                var objnewdiv = document.getElementById(divName)
                
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
            catch (err) {
                ShowError(err.description);
            }
        }

        function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
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

        function funValidate() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            var sAgtType = document.getElementById('<%= ddlAgntType.ClientID %>').value;

            if (document.getElementById(strContent + "ddlSlsChnnl") != null) {
                if (document.getElementById(strContent + "ddlSlsChnnl").disabled == false) {
                    if (document.getElementById(strContent + "ddlSlsChnnl").selectedIndex == 0) {
                        alert('Please Select Sales Channel');
                        document.getElementById(strContent + "ddlSlsChnnl").focus();
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "ddlChnCls") != null) {
                if (document.getElementById(strContent + "ddlChnCls").disabled == false) {
                    if (document.getElementById(strContent + "ddlChnCls").selectedIndex == 0) {
                        alert('Please Select Channel Sub Class');
                        document.getElementById(strContent + "ddlChnCls").focus();
                        return false;
                    }
                }
            }

            if (document.getElementById(strContent + "ddlAgntType") != null) {
                if (document.getElementById(strContent + "ddlAgntType").selectedIndex == 0) {
                    alert('Please Select Agent Type');
                    document.getElementById(strContent + "ddlAgntType").focus();
                    return false;
                }
            }

            if ((sAgtType.value == 'All' || sAgtType.value == 'HO' || sAgtType.value == 'ZM' || sAgtType.value == 'RM' || sAgtType.value == 'CM' || sAgtType.value == 'BM') && (sChekCDA.checked == true)) {
                alert("CDA linkage is allowed for franchise manager only.");
                return false;
            }

        }

//        function ShowReqDtl(divId, btnId, img) {
//            var strContent = "ctl00_ContentPlaceHolder1_";
//            $(document.getElementById(strContent + divId)).slideToggle();
//            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
//                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
//            }
//            else {
//                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
//            }
//        }

        function CheckAgtTypeForCDA() {
            var sAgtType = document.getElementById('<%= ddlAgntType.ClientID %>').value;

            if (sChekCDA.checked == true) {
                if (sAgtType.value == 'All' || sAgtType.value == 'HO' || sAgtType.value == 'ZM' || sAgtType.value == 'RM' || sAgtType.value == 'CM' || sAgtType.value == 'BM') {
                    alert('CDA linkage is allowed for franchise manager only.');
                    sChekCDA.checked = false;
                    return false;
                }
            }
        }


        //Added by Vijendra on 13-03-2014 to validate textboxes start
        function fncInputNumericValuesOnly() {
            if (!(event.keyCode == 48 || event.keyCode == 49 || event.keyCode == 50 || event.keyCode == 51 || event.keyCode == 52 || event.keyCode == 53 || event.keyCode == 54 || event.keyCode == 55 || event.keyCode == 56 || event.keyCode == 57)) {
                event.returnValue = false;
            }
        }
        //Added by Vijendra on 13-03-2014 to validate textboxes End





        //Added by Kalyani on 11-12-2013 for collapsable functionality start
        function ShowReqDtls(divId, btnId) {
            //debugger;
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
        //Added by Kalyani on 11-12-2013 for collapsable functionality end
        //Added by swapnesh on 16/12/2013 for collapsable functionality start
        function ShowReqDtlonSearch(divId, btnId) {
            //debugger;
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(divId).value = '+'
                //document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "none";
                //document.getElementById(btnId).value = '-'
                //document.getElementById(btnId).value = '-';
            }
        }
        //Added by swapnesh on 16/12/2013 for collapsable functionality end
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        
        
       
                    <table style="border-collapse: collapse; left: -0.03in; text-align: left; position: relative;
                        background-image: url(Images\background.jpg); height: 18px;" width="100%">
                        <tr align="left">
                            <td align="left">
                                <asp:ImageButton ID="lnkTab1" runat="server" Visible="false" CssClass="TextBox" BackColor="transparent" style=" margin-left:64px"
                                    ImageUrl="~/theme/iflow/tabs/Employee1.png" onclick="lnkTab1_Click" />
                                <asp:ImageButton ID="lnkTab2" runat="server" Visible="false" CssClass="TextBox" BackColor="Transparent"
                                    ImageUrl="~/theme/iflow/tabs/Agent2.png" onclick="lnkTab2_Click" />
                          
                          </td>
                        </tr>
                         </table> 
                   
                        
                        
                         <div id="demo1"  style="margin-right:1038px;" runat="server">
                            <asp:LinkButton ID="Employee"  Text="Employee" CssClass="btn-tab btn btn-default"  OnClientClick="return addCssClassByClick('1')"  OnClick="Employee_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="Agent" Text="Agent" CssClass=" btn btn-default"    OnClientClick="return addCssClassByClick('2')" OnClick="Agent_Click" runat="server"></asp:LinkButton>
                          <%--  <asp:LinkButton ID="Other" Text="Other" CssClass="btn btn-default" Visible="false"  OnClientClick="return addCssClassByClick('3')" OnClick="Other_Click"  runat="server"></asp:LinkButton>--%>
                        </div>

                        
                       <%-- <tr id="trHead" runat="server" visible="false">
                            <td align="left" class="formtablehdr" >
                                <asp:Label ID="lblSourceName" Visible="false" runat="server"></asp:Label>
                          </div>
                        </tr>--%>

                        <%-- <div id="div2" runat="server" class="panel panel-success" style="margin-top:15px;display:block;">
                               <div id="div4" runat="server" class="panel-heading"  onclick="ShowReqDtl1('demo','Span4');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                  <asp:Label ID="lblSourceName" Visible="true" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="Span4" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                            </div>    
                  
                     <div id="demo"  runat="server" class="panel panel-body">--%>


                  <%--   <div ID="div1" runat="server" class="divBorder1" style="width: 90%;">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td>
                                <i class="fa fa-list"></i>
                                
                                &nbsp;<asp:Label ID="lblbas" Text="Basic Search" runat="server" Font-Bold="false" 
                                   ></asp:Label>
                          </div>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img1" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divAgtBasicSearch','Img1','#Img1');" />
                          </div>
                        </tr>
                    </table>--%>
                   
                       <div id="divsearch1" runat="server" class="panel panel-success" style="display:block;">
                               <div id="divsrchHdr" runat="server" class="panel-heading"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgtBasicSearch','Span2');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
              <asp:Label ID="lblbas" Text="Basic Search" runat="server" Font-Bold="false" 
                                   ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="Span2" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                            </div>    

                  
                    <div id="divAgtBasicSearch" runat="server" class="panel-body">
                        <div class="row" style="margin-bottom:5px;">
                                   <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgntCode" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                              </div>
                                  <div class="col-sm-3">
                                    <asp:TextBox ID="txtAgntCode" runat="server" CssClass="form-control"
                                       onkeypress="fncInputNumericValuesOnly('txtQty')"></asp:TextBox>
                              </div>
                                   <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgntName" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                              </div>
                                  <div class="col-sm-3">
                                    <asp:TextBox ID="txtAgntName" runat="server"  CssClass="form-control" ></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                                InvalidChars=",#$@%^!*()&''%^~`0123456789<>=?./|\{}[]:+;-" FilterMode="InvalidChars" TargetControlID="txtAgntName"
                                                FilterType="Custom">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                              </div>
                            </div>
                             <div class="row" style="margin-bottom:5px;">
                                   <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblRptType" runat="server" CssClass="control-label" Text="Reporting Type"></asp:Label>
                              </div>
                                  <div class="col-sm-3">
                                    <asp:UpdatePanel ID="updRptType" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlRptTyp" runat="server" AutoPostBack="true" CssClass="form-control"
                                               onselectedindexchanged="ddlRptTyp_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--<asp:RadioButtonList ID="rdbRptTyp" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                        <asp:ListItem Value="1" Text="Administrative"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Functional"></asp:ListItem>
                                    </asp:RadioButtonList>--%>
                              </div>
                                   <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblImmLeaderCode" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                              </div>
                                  <div class="col-sm-3">
                                    <asp:UpdatePanel ID="updMgrCode" runat="server">
                                    <ContentTemplate>
                                    <asp:TextBox ID="txtImmLeaderCode" runat="server" 
                                       CssClass="form-control" Enabled="false"  onkeypress="fncInputNumericValuesOnly('txtQty')"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlRptTyp" EventName="selectedindexchanged" />
                                    </Triggers> 
                                    </asp:UpdatePanel>
                              </div>
                           </div>
                            <div class="row" style="margin-bottom:5px;">
                                   <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblSapCode" runat="server" CssClass="control-label"></asp:Label>
                              </div>
                                  <div class="col-sm-3">
                                    <asp:TextBox ID="txtSapCode" runat="server" CssClass="form-control"
                                     onkeypress="fncInputNumericValuesOnly('txtQty')"></asp:TextBox>
                              </div>
                                   <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblShwRecords" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>
                              </div>
                                  <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass="form-control"
                                        >
                                    </asp:DropDownList>
                              </div>
                          </div>
                           <div class="row" style="margin-bottom:5px;">
                                   <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblMomentType" runat="server" CssClass="control-label" Text="Movement Type"></asp:Label>
                              </div>
                                  <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlMomentType" runat="server" CssClass="form-control"
                                     >
                                    </asp:DropDownList>
                              </div>
                              </div>
                            
                    </div>
                    
                     </div>
                    
                     <br />



                     <%-- <div ID="div2" runat="server" class="divBorder1" style="width: 90%;">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td>
                                <i class="fa fa-list"></i>
                                
                                &nbsp;<asp:Label ID="lbladvsrch" Text="Advance Search" runat="server" Font-Bold="false" 
                                   ></asp:Label>
                          </div>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img2" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divAgtAdvSearch','Img2','#Img2');" />
                          </div>
                        </tr>
                    </table>--%>

                     <div class="panel panel-success" >
                <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgtAdvSearch','Span1');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                            <asp:Label ID="Label3" Text="Advance Search" Font-Bold="false" runat="server" />
                        </div>
                        <div class="col-sm-2">
                            <span id="Span1" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>


                    <div id="divAgtAdvSearch" class="panel-body" runat="server" style="display: block;">
                        <div class="row" style="margin-bottom:5px;">
                                  <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblchnltype" runat="server" Text="Hierarchy Type" CssClass="control-label"    style=" padding: 8px;"></asp:Label>
                              </div>
                                  <div class="col-sm-3">
                                    <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged"
                                              CellPadding="2" CellSpacing="2" RepeatDirection="Horizontal"  TabIndex="8">
                                                <asp:ListItem Value="0" Text="&nbspCompany&nbsp&nbsp&nbsp&nbsp" Selected="False"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="&nbspChannel"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                              </div>
                                  <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblSlsChnnl" runat="server" Font-Bold="False" CssClass="control-label" ></asp:Label>
                                  </div>
                                  <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                    <asp:DropDownList ID="ddlSlsChnnl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSlsChnnl_SelectedIndexChanged"
                                        CssClass="form-control" >
                                    </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                              </div>
                           </div>
                            <div class="row" style="margin-bottom:5px;">
                                  <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblChnCls" runat="server" CssClass="control-label" style=" padding: 8px;"></asp:Label>
                                  </div>
                                  <div class="col-sm-3">
                                    <asp:UpdatePanel ID="updddlSlsChnl" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlChnCls" runat="server" AutoPostBack="true" 
                                                CssClass="form-control"  
                                                OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlSlsChnnl" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                              </div>
                                  <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgntType" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                              </div>
                                  <div class="col-sm-3">
                                <asp:UpdatePanel ID="upnlAgnType" runat="server">
                                        <ContentTemplate>
                                    <asp:DropDownList ID="ddlAgntType" runat="server" AutoPostBack="True" CssClass="form-control"
                                        >
                                    </asp:DropDownList>
                                    </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlChnCls" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                              </div>
                          </div>
                    </div>
                    </div>
                    <br />
                    
                    
                    
                    
                   

                        <div class="row" style="margin-top: 12px;">
                <div class="col-sm-12" align="center">
                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" CausesValidation="true"
                        Text="SEARCH" OnClick="btnSearch_Click" OnClientClick="javascript:validate();"
                        TabIndex="43">
                         <span class="glyphicon glyphicon-search" style='color: White;'></span> Search
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-primary" CausesValidation="False"
                         OnClick="btnClear_Click" TabIndex="43">
                              <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear
                    </asp:LinkButton>
                </div>
            </div>

     
              
            
        <br />
        
        
        
        
       
                  <div class="col-sm-12" style="text-align: center">
                    <asp:Label ID="lblMessage" runat="server"  CssClass="control-label" Visible="false" style='text-align:center;'  ForeColor="Red"></asp:Label>
              </div>
           
        
        <%--<table width="90%" cellspacing="0">--%>
            <%--<tr id="trDetails" runat="server" visible="false">
                  <div class="col-sm-3" style="text-align: left">
                <asp:Label ID="lblAgtSrchRes" runat="server"  CssClass="control-label" Text="Member Search Results"  Font-Bold="false"></asp:Label>
                    <span style="padding-left:70%;"></span>
                    <asp:Label ID="lblPageInfo" Font-Bold="false"  CssClass="control-label" runat="server"></asp:Label>
              </div>
            </tr>--%>

             <%--    <div id="div3" runat="server" style="width: 90%;" class="divBorder1">
            <table class="formtablehdr" style="width: 100%;">
                <tr id="trDetails" visible="false" style="height: 30px;">
                    <td>
                        <i class="fa fa-list"></i>
                        <asp:Label ID="lblAgtSrchRes" Text="Member Search Results" runat="server" />
                      
                  </div>
                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                         <img id="Img3" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divcmphdr','Img3','#Img3');" />
                  </div>
                </tr>
            </table>--%>
        

         <div id="demo11" runat="server" class="panel panel-success" style="margin-top: 15px;display:none;">
                <div id="div3" runat="server" class="panel-heading"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmphdr','Span3');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                            <asp:Label ID="Label4" Text="Advance Search" runat="server" />
                        </div>
                        <div class="col-sm-2">
                            <span id="Span3" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>



             <div id="divcmphdr" runat="server" style="width:100%;padding: 10px;" class="panel-body table-scrollable">
         
                    <asp:GridView ID="dgDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        AllowSorting="True" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                        onpageindexchanging="dgDetails_PageIndexChanging" 
                        onsorting="dgDetails_Sorting" onrowdatabound="dgDetails_RowDataBound">
                       <RowStyle CssClass="GridViewRow"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                        
                        <Columns>
                            <asp:ImageField DataImageUrlField="MemCode" DataImageUrlFormatString="ImageGrid.aspx?ImageID={0}" HeaderText="Photo" 
                                        ControlStyle-Height="40px" ControlStyle-Width="40px">
                                </asp:ImageField>

                            <asp:BoundField DataField="MemCode" SortExpression="MemCode" HeaderText="Member Code">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="InsMemCode" SortExpression="InsMemCode" HeaderText="Ins Ref Code">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center"/>
                            </asp:BoundField>
                             <asp:TemplateField HeaderText="Emp Code" SortExpression="EMPCode">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Visible="true" Text='<%# Bind("EMPCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Agent Name" DataField="LegalName" SortExpression="LegalName">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <%--<asp:BoundField HeaderText="Manager Code" DataField="MgrCode" SortExpression="MgrCode">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                            </asp:BoundField>--%>
                            <asp:BoundField HeaderText="Unit Code" DataField="UnitDsc" SortExpression="UnitDsc" />
                            <asp:BoundField HeaderText="Unit Desc" DataField="UnitDesc" SortExpression="UnitDesc" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="Channel" DataField="BizSrc" SortExpression="BizSrc" />
                            <asp:BoundField HeaderText="Sub Class" DataField="ChnCls" SortExpression="ChnCls" />
                            <asp:BoundField DataField="MemType" HeaderText="Member Type" SortExpression="MemType" />
                            <asp:BoundField DataField="MovementType" HeaderText="MovementType" SortExpression="MovementType" ItemStyle-HorizontalAlign="Left"/>

                            <asp:TemplateField HeaderText="Proceed" SortExpression="Proceed">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkProceed" runat="server" Visible="true" Text="Proceed"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblmvmtcode" runat="server" Text='<%# Bind("MvmtCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                        </Columns>


                       
                    </asp:GridView>
           
        
           
          
            <div id="divPage" visible="true" runat="server" class="pagination">
                        <center>
                            <table>
                                <tr>
                                    <td style="white-space: nowrap;">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                  </div>

                                      </div>
                              
                     </div>  
                    
                    
                    
                    
                    
                   
       <%-- </table>--%>
        <asp:HiddenField ID="hdnAgentRole" runat="server" />
    </center>
    <%--<script type="text/javascript">

        function funcShowPopup(strPopUpType) {
            if (strPopUpType == "unitcode") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/INSC/ChannelMgmt/GetunitCodePopUp.aspx?Code=" + document.getElementById('<%=txtUnitCode.ClientID %>').value + "&Desc=" + document.getElementById('<%=txtUnitCode.ClientID %>').id + "&field1="
        + document.getElementById('<%=txtUnitCode.ClientID %>').id + "&field2=" + document.getElementById('<%=txtUnitCode.ClientID %>').id + "&field3= 1" + "&mdlpopup=mdlViewBID";
            }

        }

        function funcShowPopupBAS(Agtcode) {

            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/INSC/ChannelMgmt/PopVendorlist.aspx?AgentCode=" + Agtcode + "&mdlpopup=mdlViewBID";


        }
        //Added by Rachana on 14/05/2013 for replacing js funOpenPopWinForUntCode with funcShowPopup 
    </script>--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="500" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="500" height="300px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="Panel1" Width="700" display="none">
        <iframe runat="server" id="Iframe1" width="700" height="700px" frameborder="0" display="none">
        </iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label2" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlView"
        DropShadow="true" TargetControlID="Label2" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>
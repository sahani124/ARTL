<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="UnitHierarchy.aspx.cs" Inherits="Application_INSC_ChannelMgmt_BranchUnitHierarchy" %>

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
    <%-- <script src="assets/KMI%20Styles/Bootstrap/datepicker/datetimepicker.js" type="text/javascript"></script>
    <script src="assets/jqueryCalendar/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>--%>
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
    <%-- <link href="../../../assets/KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
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
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
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
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>




    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>





    <style type="text/css">
        .hidden-field {
            display: none;
        }

        .map-responsive {
            overflow: hidden;
            padding-bottom: 56.25%;
            position: relative;
            height: 0;
        }

        #map-canvas {
            width: 100%;
            height: 100%;
            height: calc(100% - 0px);
        }



        /*.gridview th
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
        }*/
    </style>

    <script language="javascript" type="text/javascript">
        var path = "<%=Request.ApplicationPath.ToString()%>";

        function StartProgressBar() {

            var myExtender = $find('ProgressBarModalPopupExtender');
            myExtender.show();
            //document.getElementById("btnSubmit").click();
            return true;
        }

        function funValidate() {
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strContent + "ddlSalesChannel").selectedIndex == 0) {

                alert('Please Select Hierarchy Name');
                document.getElementById(strContent + "ddlSalesChannel").focus();

                return false;
            }

            if (document.getElementById(strContent + "ddlUnitLevel").selectedIndex == 0 && document.getElementById(strContent + "ddlReportingUnitType").selectedIndex == 0) {

                alert('Please Select Unit Type or Reporting Unit Type');


                return false;
            }


        }

        function popup() {

            $("#myMapModal").modal();
            $('#btnVwUnitType').click(function () {
                $('#myMapModal').modal({ show: true })
            }); var map;
            var myCenter = new google.maps.LatLng(53, -1.33);
            var marker = new google.maps.Marker({
                position: myCenter
            });

            function initialize() {
                var mapProp = {
                    center: myCenter,
                    zoom: 14,
                    draggable: false,
                    scrollwheel: false,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };

                map = new google.maps.Map(document.getElementById("map-canvas"), mapProp);
                marker.setMap(map);

                google.maps.event.addListener(marker, 'click', function () {

                    infowindow.setContent(contentString);
                    infowindow.open(map, marker);

                });
            };
            google.maps.event.addDomListener(window, 'load', initialize);

            google.maps.event.addDomListener(window, "resize", resizingMap());

            $('#myMapModal').on('show.bs.modal', function () {
                //Must wait until the render of the modal appear, thats why we use the resizeMap and NOT resizingMap!! ;-)
                resizeMap();
            })

            function resizeMap() {
                if (typeof map == "undefined") return;
                setTimeout(function () { resizingMap(); }, 400);
            }

            function resizingMap() {
                if (typeof map == "undefined") return;
                var center = map.getCenter();
                google.maps.event.trigger(map, "resize");
                map.setCenter(center);
            }
        }

        function ShowReqDtl1(divName, btnName) {
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
                    //objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
                }
            }
            catch (err) {
                ShowError(err.description);
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





    </script>



    <meta charset="utf-8">


    <style type="text/css" rel="StyleSheet">
        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }

        .gm-style .gm-style-iw DIV {
            /*Overridden to clear of all style attributes*/
        }

        .MapDiv {
            height: auto;
            font-family: Verdana;
            font-size: 9px;
            line-height: 11px;
            padding-bottom: 2px;
        }

        #pnlGeoMap {
            z-index: 9997;
        }

        #Pnl_Downlines {
            z-index: 9998;
        }

        .ajax__calendar {
            position: static;
        }
    </style>


    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBdC_JgCDjPFZ0iIZw1DWxTljdXOCt8-Vc&v=3&sensor=true" type="text/javascript"></script>
    <script src="../../../assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/json2.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Global Variable
        var marker;
        var lat = new Array();
        var lng = new Array();
        var popMsg = new Array();
        var index;
        var lookuplat = [];
        var lookuplng = [];
        var infoWindow;
        //------------------------------------------------------------------------------------------------------------------
        function PutMarkers(argLat, argLan, argpopMsg, indexer) {
            var i;
            if (infoWindow) { infoWindow.close(); }
            if (argLat.length > 0 || argLan.length > 0 || argpopMsg.length > 0) {
                popMsg = jsonParse(argpopMsg);
                lat = JSON.parse(argLat);
                lng = JSON.parse(argLan);
                index = indexer;
            }
            setTimeout(function () {
                map = new google.maps.Map(document.getElementById('map-canvas'), {
                    zoom: 4,
                    center: new google.maps.LatLng(21.153675, 79.072347),
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                });
                infoWindow = new google.maps.InfoWindow({ maxWidth: 425 });;

                if (marker) { marker.setMap(null); }
                for (i = 0; i < index; i++) {
                    lookuplat.push(lat[i]); lookuplng.push(lng[i]);

                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(lat[i], lng[i]),
                        map: map
                    });
                    google.maps.event.addListener(marker, 'click', (function (marker, i) {
                        return function () {

                            infoWindow.setContent(popMsg[i]);
                            infoWindow.open(map, marker);
                        }
                    })(marker, i));
                }
                map.setCenter(new google.maps.LatLng(21.153675, 79.072347));
            }, 2000);
        }
        //------------------------------------------------------------------------------------------------------------------
        function SelectMarker(arg1, arg2, arg3) {
            if (infoWindow) { infoWindow.close(); }
            map.setCenter(new google.maps.LatLng(JSON.parse(arg1), JSON.parse(arg2)));
            infoWindow.setContent(arg3);
            infoWindow.setPosition(new google.maps.LatLng(JSON.parse(arg1), JSON.parse(arg2)));
            infoWindow.open(map);
        }
        //------------------------------------------------------------------------------------------------------------------
        function PutMarker(UnitLegalName, Lat, Lan, Address, PostalAddress) {
            setTimeout(function () {
                map = new google.maps.Map(document.getElementById('map-canvas'), {
                    zoom: 10,
                    center: new google.maps.LatLng(19.075097, 72.875648),
                    mapTypeId: google.maps.MapTypeId.HYBRID
                });
                var lat = Lat; var lng = Lan; var address = Address; var postaladdress = PostalAddress; var unitlegalname = UnitLegalName;
                if (marker) { marker.setMap(null); }
                var LatLng = new google.maps.LatLng(lat, lng);
                var msg = "<div class='MapDiv'><strong>Unit   :" + unitlegalname.toString() + "</strong></br>" + address.toString() + "</br>" + postaladdress.toString() + "</div>";
                marker = new google.maps.Marker({
                    position: LatLng,
                    map: map
                });
                infoWindow = new google.maps.InfoWindow({ maxWidth: 425 });;

                google.maps.event.addListener(marker, 'click', function () {
                    if (infoWindow) { infoWindow.close(); }
                    infoWindow.open(map, marker);
                    infoWindow.setContent(msg);
                });
                map.setCenter(LatLng);
            }, 2000);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------
        function openPopUnitDownlines(arg1) {
            var qs1 = document.getElementById('<%=ddlSalesChannel.ClientID%>').value.substring(0, 2);
            var qs3 = document.getElementById('<%=ddlChnnlSubClass.ClientID%>').value.substring(0, 4);
            var qs2;

            if (arg1 == 1) {
                qs2 = document.getElementById('<%=ddlReportingUnitType.ClientID%>').options[document.getElementById('<%=ddlReportingUnitType.ClientID%>').selectedIndex].text;
                qs2 = qs2.substring(0, 2);
            }
            else if (arg1 == 2) {
                qs2 = document.getElementById('<%=ddlUnitLevel.ClientID%>').options[document.getElementById('<%=ddlUnitLevel.ClientID%>').selectedIndex].text;
                    qs2 = qs2.substring(0, 2);
                }

            $find("mdlDownlines").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframepop").src = "PopUnitDownlines.aspx?Bizsrc=" + qs1 + "&UnitType=" + qs2 + "&Chncls=" + qs3;
        }

        //-----------------------------------------------------------------------------------------------------------------------
    </script>
    <script type="text/javascript">
        function hideTd() {
            //            jQuery("#td_Grid").hide();
            //            jQuery("#td_Map").resize(function () { jQuery("#td_Map").css("width", "800px").css("height", "445px").css("position", "absolute"); });
            //            jQuery("#map-canvas").resize(function () { jQuery("#map-canvas").css("width", "795px").css("height", "445px").css("vertical-align", "top").css("float", "left"); });
        }

        function showTd() {
            //            jQuery("#td_Grid").show();
            //            jQuery("#td_Map").resize(function () { jQuery("#td_Map").css("width", "619px").css("height", "445px").css("position", "absolute"); });
            //            jQuery("#map-canvas").resize(function () { jQuery("#map-canvas").css("width", "612px").css("height", "445px").css("vertical-align", "top").css("float", "left"); });
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <br />
       <%-- <asp:UpdatePanel ID="up_UnitM" runat="server">
            <ContentTemplate>--%>


                          <%--  <div id="divcmphdrcollapse" runat="server" style="width: 98%;" class="divBorder1">
            <table class="formtablehdr" style="width: 100%;">
                <tr style="height: 30px;">
                    <td style="padding-left: 5px;">
                        <i class="fa fa-list"></i>
                        <asp:Label ID="lblUnitMaintanance"  runat="server" Style="padding-left: 5px;" />
                    </td>
                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                         <img id="myImg" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('divcmphdr','myImg','#myImg');" />
                    </td>
                </tr>
            </table>--%>
        <div class="container">
             <div class="panel ">
                <div id="divcmphdrcollapse" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','btnpersnl');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <asp:Label ID="lblUnitMaintanance"  runat="server" Font-Size="19px" />
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>
           
               
                
                
                <div id="divcmphdr" style="display:block;" runat="server" class="panel-body">
                
                               <%-- <tr>
                                    <td class="test formHeader" colspan="4" align="left">
                                        <asp:Label ID="lblUnitMaintanance" runat="server" CssClass="caption" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>--%>
                                <div class="col-sm-3" style="text-align:left">
                                        <span style="color: #ff0000">
                                            <asp:Label ID="lblSalesChannel" CssClass="control-label"  runat="server" Style="color: Black"></asp:Label>
                                            *</span>
                                   </div>

                                   <div class="col-sm-3" style="text-align:left">
                                        <asp:UpdatePanel runat="server" ID="upnlSalesChannel">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSalesChannel" runat="server"  CssClass="form-control"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvSlsChnnl" runat="server" ControlToValidate="ddlSalesChannel"
                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        </div>

                                         <div class="col-sm-3" style="text-align:left">
                                        <span style="color: #ff0000">
                                            <asp:Label ID="lblChnnlSubClass" runat="server"  CssClass="control-label"  Style="color: Black"></asp:Label>
                                            *</span>
                                            </div>

                                   <div class="col-sm-3">
                                        <asp:UpdatePanel runat="server" ID="upnlChnnlSubClass">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlChnnlSubClass"  runat="server"  CssClass="form-control"
                                                    OnSelectedIndexChanged="ddlChnnlSubClass_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvChnnlSubClass" runat="server" ControlToValidate="ddlChnnlSubClass"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged">
                                                </asp:AsyncPostBackTrigger>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        </div>
                                   
                                    <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="lblUnitLevel" CssClass="control-label" runat="server"></asp:Label>
                                            <span style="color: #ff0000">*</span> 
                                        </div>
                                  
                                   <div class="col-sm-3">
                                        <asp:UpdatePanel runat="server" ID="upnlChnCls">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUnitLevel"  runat="server"  CssClass="form-control"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlUnitLevel_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <%--Modifcation by Parag @13022014--%>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged">
                                                </asp:AsyncPostBackTrigger>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    
                                    <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="lblUnitCode"  CssClass="control-label"  runat="server"></asp:Label>
                                        </div>
                                   
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtUnitCode" runat="server"  CssClass="form-control"
                                            MaxLength="10"></asp:TextBox>
                                            </div>
                                   
                                </div>
                                 </div>
                                 <br />
                                
        </div>                        
                                
                                
                      <div class="container">       

               <div class="panel ">
                <div id="div1" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div2','Span1');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     
                       <asp:Label ID="lblReportingUnit"  runat="server" Font-Size="19px"  />
                 
                    </div>
                    <div class="col-sm-2">
                    
                        <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div> 
                                
                                <div id="div2" style="display:block;" runat="server" class="panel-body">
               <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="lblReportingUnitType" CssClass="control-label" runat="server"></asp:Label>
                                         <span style="color: #ff0000">*</span>
                                        </div>
                                   
                                   <div class="col-sm-3">
                                        <asp:UpdatePanel runat="server" ID="upnlReprtngUnt">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlReportingUnitType" runat="server"  CssClass="select2-container form-control" 
                                              AutoPostBack="True" OnSelectedIndexChanged="ddlReportingUnitType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <%--Modifcation: Parag @13022014--%>
                                            </ContentTemplate>
                                            <Triggers>
                                                <ajax:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                  </div>
                                  <div class="col-sm-3" style="text-align:left">
                                      
                                        <asp:Label ID="lblReportingUnitCode"  CssClass="control-label" runat="server"></asp:Label>
                                         
                                   </div>
                                   <div class="col-sm-3">
                                        <asp:TextBox ID="txtReportingUnitCode" runat="server"  
                                             CssClass="form-control"  MaxLength="10"></asp:TextBox>
                                  </div>
                               
                                </div> 
                                
                                </div>
                     </div>         

                  <div class="row" style="margin-top:12px;">
                    <div class="col-sm-12" align="center">
       
                         <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" CausesValidation="false"
                                 Text="SEARCH"  OnClick="btnSearch_Click"   OnClientClick="return funValidate();" >
                         <span class="glyphicon glyphicon-search" style='color:White;'></span> Search
                        </asp:LinkButton>  
               
                 <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample" CausesValidation="False"
                               OnClick="btnClear_Click">
                              <span class="glyphicon glyphicon-erase BtnGlyphicon"> </span> Clear
                             </asp:LinkButton> 

                             </div>

                             </div>

 <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="False" ForeColor="Red"></asp:Label>
                      </div>
                 <br />
        <div class="container">
                       <div  id="demo" style="display:none;" runat="server" class="panel ">
                <div id="div3" runat="server" style="display:none;" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div_UnitContact','Span2');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      
                       <asp:Label ID="lblTitleUnitMaintanance" runat="server" Text="Unit Hierarchy Search Results"
                                Font-Size="19px"   ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                    
                        <span id="Span2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>

                
                
                 <div id="div_UnitContact"  style="display:none; margin-top:10px; width:97%" runat="server">
                
                   
                            <asp:RadioButtonList ID="rdbUnit" runat="server" CssClass="radiobtnHidden" RepeatDirection="Horizontal"
                                OnSelectedIndexChanged="rdbUnit_SelectedIndexChanged" AutoPostBack="True" Height="11px"
                                Visible="false" Enabled="false">
                            </asp:RadioButtonList>
                        
                   
                           <%-- <asp:UpdatePanel ID="updPnl_DgDetails" runat="server">
                                <ContentTemplate>--%>
                                    <asp:GridView ID="dgDetails" runat="server" AutoGenerateColumns="false" 
                                        OnRowCommand="dgDetails_RowCommand" DataKeyNames="UnitCode" OnRowDataBound="dgDetails_RowDataBound"
                                        AllowPaging="true" OnRowDeleting="dgDetails_RowDeleting" 
                                         PageSize="10"
                                    OnSorting="dgDetails_Sorting"
                                        AllowSorting="True" CssClass="footable">

                                         <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />

                            <Columns>
                                            <asp:BoundField HeaderText="Insurer Code" DataField="CmsUnitCode" SortExpression="CmsUnitCode">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField ShowHeader="true" HeaderText="Unit Code" SortExpression="UnitCode">
                                                <ItemTemplate>
                                                    <asp:LinkButton OnClick="lnkUnitCode_Click" ID="lnkUnitCode" Text='<%# Bind("UnitCode") %>'
                                                        runat="server"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Justify" />
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField ShowHeader="true" Visible="false" HeaderText="BizSrc">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBizSrc" Text='<%# Bind("Bizsrc") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                           
                                            <asp:BoundField HeaderText="Unit Description" DataField="LegalName" SortExpression="LegalName">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Reporting Unit" DataField="RptUnitName" SortExpression="RptUnitName">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Unit Manager" DataField="UnitMgrName" SortExpression="UnitMgrName">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Unit Type" DataField="UnitType" SortExpression="UnitType">
                                                <ItemStyle Font-Bold="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                          
                                            <asp:BoundField HeaderText="Insurer Rpt Code" DataField="RptCmsUnitCode" SortExpression="RptCmsUnitCode">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Unit Code" DataField="UnitCode" SortExpression="UnitCode">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                           
                                            <asp:TemplateField ShowHeader="True" HeaderText="Delete">
                                                <ItemTemplate>
                                                    <div style="width: 100%;">
                                                        <i class="fa fa-trash-o"></i>
                                                        <asp:LinkButton ID="DeleteBtn" ForeColor="Red" Text="Delete" CommandName="Delete"
                                                            runat="server" />
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                          
                                            <%--<asp:TemplateField ShowHeader="true" HeaderText="View on Map">
                                                <ItemTemplate>
                                                    <div style="width: 100%;">
                                                        <i class="fa fa-map-marker"></i>
                                                        <asp:LinkButton ID="ViewBtn" Text="View" runat="server" OnClick="ViewBtn_OnClick" />
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                         --%>
                                        </Columns>

                               <%--<Columns>
                                            <asp:BoundField HeaderText="Insurer Code" DataField="CmsUnitCode" SortExpression="CmsUnitCode">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField ShowHeader="true" HeaderText="Unit Code" SortExpression="UnitCode">
                                                <ItemTemplate>
                                                    <asp:LinkButton OnClick="lnkUnitCode_Click" ID="lnkUnitCode" Text='<%# Bind("UnitCode") %>'
                                                     Enabled="false"   runat="server"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Justify" />
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField ShowHeader="true" Visible="false" HeaderText="BizSrc">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBizSrc" Text='<%# Bind("Bizsrc") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                      
                                            <asp:BoundField HeaderText="Unit Description" DataField="LegalName" SortExpression="LegalName">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Reporting Unit" DataField="RptUnitName" SortExpression="RptUnitName">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Unit Manager" DataField="UnitMgrName" SortExpression="UnitMgrName">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Unit Type" DataField="UnitType" SortExpression="UnitType">
                                                <ItemStyle Font-Bold="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                          
                                            <asp:BoundField HeaderText="Insurer Rpt Code" DataField="RptCmsUnitCode" SortExpression="RptCmsUnitCode">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                         
                                            
                                    
                                            <asp:TemplateField ShowHeader="True" HeaderText="Action">
                                                <ItemTemplate>
                                                    <div style="width: 100%;">
                                                        <i class="fa fa-trash-o"></i>
                                                        <asp:LinkButton ID="DeleteBtn" Visible="false"  Text="Delete" CommandName="Delete"
                                                            runat="server" />
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField ShowHeader="true" HeaderText="View on Map">
                                                <ItemTemplate>
                                                    <div style="width: 100%;">
                                                        <i class="fa fa-map-marker"></i>
                                                        <asp:LinkButton ID="ViewBtn" Text="View" runat="server" OnClick="ViewBtn_OnClick" />
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                          
                                        </Columns>--%>
                                      
                                    </asp:GridView>
                                

                <div id="divPage" visible="true" runat="server" class="pagination">
                        <center>
                            <table>
                                <tr>
                                    <td style="white-space: nowrap;">
                                       <%-- <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>--%>
                                                <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtPage" Style="width: 44px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                           <%-- </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                    
                    
                      </div>
                   
                </div>
            </div>
                 <%-- <div class="row" style="margin-top:12px;">
                    <div class="col-sm-12" align="center">
                                    <asp:LinkButton ID="btnVwUnitType" CssClass="btn btn-sample" Visible="false"   Text="View All On Map" runat="server" OnClick="btnVwUnitType_Click">
                                    <span class="glyphicon glyphicon-modal-window" style='color:White;'></span> View All On Map
                                    </asp:LinkButton>
                              
                            </div>
                            </div>--%>
              
           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </center>
    <%--Parag 13022014 For Runtime Lable update--%>
    <%--   <asp:UpdatePanel ID="updPnl_Message" runat="server" UpdateMode="Always">
        <ContentTemplate>--%>
    <%--Parag 13022014 For Runtime Lable update--%>
    <%--Added by Pranjali on 28-05-2013 for modal popup start--%>
    <asp:Panel ID="pnl" runat="server" Style="display: none;"
        Width="400px">
        <table width="100%" style="background-color:white; padding:10px">
            <tr align="center" style="background-color: #034ea2">
                <center>
                        <td width="100%" class="formHeader" colspan="1" style="padding:10px">
                            <asp:Label ID="lblModalTitle" runat="server" style="color:white;font-size:16px" /><%--Parag @ 13022014 - To make the hardcoded Text as lable--%>
                        </td>
                        </center>
            </tr>
            <tr>
                <td>
                    <br />
                    <center>
                                <asp:Label ID="Lbl1" runat="server" Font-Bold="true" style="font-size:17px"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl2" runat="server" style="font-size:17px;padding: 10px;"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl3" runat="server" Font-Size="Smaller"></asp:Label>
                                <br />
                            </center>
                </td>
            </tr>
            <tr>
                <td>
                    <center>
                        <asp:Button ID="btnok" runat="server" Text="OK" Width="81px" style="margin:10px" CssClass="btn btn-sample" />
                    </center>
                </td>
            </tr>
        </table>
<%--        <table style="background-color: white">
            <tr>
                <td>
                    <br />
                    <center>
                                <asp:Label ID="Lbl1" runat="server" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl2" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl3" runat="server" Font-Size="Smaller"></asp:Label>
                                <br />
                            </center>
                </td>
            </tr>
            <tr>
                <td>
                    <center>
                        <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="81px" CssClass="btn btn-sample" />
                    </center>
                </td>
            </tr>
        </table>--%>
        
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl1"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--Added by Pranjali on 28-05-2013 for modal popup end--%>
    <%--Parag 10022014 For Runtime Lable update--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--Parag End--%>
    <%--Parag 13022014 For GeoMap--%>
    <%--Parag 13022014 For Runtime Lable update--%>
    <%--Added by Pranjali on 28-05-2013 for modal popup start--%>


    <%-- <asp:Panel ID="pnlGeoMap" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="550px" Height="444">--%>




    <%-- <div class="test formHeader" style="height: 30px; width: 100%;" align="center">
            <asp:Label ID="lblTitleGeoMap" runat="server" Text="Geographical Location" />
        </div>--%>





    <%-- <div id="div4" runat="server" style="width: 110%;" class="divBorder1">
             <table class="formtablehdr" style="width: 100%;">
                <tr style="height: 30px;">
                    <td style="padding-left: 5px;">
                        <i class="fa fa-search"></i>
                        <asp:Label ID="lblTitleGeoMap"  runat="server" Text="Geographical Location" Style="padding-left: 5px;" />
                        <span style="padding-left: 555px;"></span>
                                                

                    </td>
                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                  
                        <img id="Img3" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('div5','Img3','#Img3');" />
                    </td>
                </tr>
            </table>--%>






    <%-- </div>--%>


    <%-- </asp:Panel>--%>





    <div class="modal fade" id="myMapModal">
        <div class="modal-dialog">
            <div class="modal-content" style='padding-top: 15px;'>
                <div class="container">
                    <div class="panel ">

                        <div class="modal-header panel-heading" style='padding: 2px;'>
                            <div id="div4" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div_UnitDtl1','Span3');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblTitleGeoMap" runat="server" Font-Size="19px" Text="Geographical Location" />

                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span3" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div id="div_UnitDtl1" style="display: block;" runat="server">

                            <div class="modal-body">
                                <div class="container">
                                    <div class="row">

                                        <div id="div5" runat="server" style="width: 100%;" class="img-responsive">




                                            <div id="map-canvas" class="map-responsive img-responsive" style="width: 414px; height: 445px;">
                                            </div>

                                            <asp:GridView ID="GrdVw_Locations" runat="server" AutoGenerateColumns="false" HorizontalAlign="Left"
                                                CssClass="footable"
                                                AllowPaging="True" RowStyle-CssClass="formtable"
                                                PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="GrdVw_Locations_PageIndexChanging"
                                                OnSorting="GrdVw_Locations_Sorting" AllowSorting="True" PageSize="25" Visible="true"
                                                Style="margin-bottom: 0px; vertical-align: top;">
                                                <RowStyle CssClass="GridViewRowNew "></RowStyle>
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />

                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLat" Text='<%# Bind("Latitude") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLan" Text='<%# Bind("Longitude") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Names">
                                                        <ItemTemplate>
                                                            <i class="fa fa-map-marker"></i>&nbsp;&nbsp;
                                            <asp:LinkButton OnClick="lnkLegalName_Click" ID="lnkLegalName" Text='<%# Bind("UnitLegalName") %>'
                                                runat="server"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Justify" />
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>


                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="margin-left: 159px">
                                                    <asp:LinkButton ID="btnClose" runat="server" Text="CLOSE" Width="80px"
                                                        CssClass="btn btn-sample">
                         <span class="glyphicon glyphicon-ban-circle" style='color:White;'></span> Close
                                                    </asp:LinkButton>
                                                </div>
                                            </div>


                                        </div>

                                    </div>
                                </div>
                            </div>

                            <%--<div class="modal-footer">   
            </div>--%>
                        </div>



                    </div>
                </div>

            </div>
        </div>
    </div>













    <%--  <ajaxToolkit:ModalPopupExtender ID="mdlPopupGeoMap" runat="server" TargetControlID="lblTitleGeoMap"
        BehaviorID="mdlPopupGeoMap" BackgroundCssClass="modalPopupBg" PopupControlID="pnlGeoMap"
        DropShadow="true" OkControlID="btnClose">
    </ajaxToolkit:ModalPopupExtender>--%>
    <%--Added by Pranjali on 28-05-2013 for modal popup end--%>
    <%--Parag 13022014 For Runtime Lable update--%>
    <asp:Panel runat="server" ID="Pnl_Downlines" Width="550px" Height="444px" BorderColor="ActiveBorder"
        BorderStyle="Solid" BorderWidth="2px" class="modalpopupmesg">
        <iframe runat="server" id="Iframepop" width="550px" height="95%" frameborder="0"
            display="none"></iframe>
        <center>
            <asp:Button Text="CLOSE" CssClass="standardbutton" Width="80px" runat="server" ID="btnClosePopUp" />
        </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlDownlines" runat="server" TargetControlID="Iframepop"
        BehaviorID="mdlDownlines" BackgroundCssClass="modalPopupBg" PopupControlID="Pnl_Downlines"
        OkControlID="btnClosePopUp">
    </ajaxToolkit:ModalPopupExtender>
    <%--Parag End--%>
</asp:Content>

<%@ Page Language="C#" StylesheetTheme="Admin" AutoEventWireup="true" CodeFile="Charts.aspx.cs"
    Inherits="Charts" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE6" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="expires" content="-1" />
    <link rel="Stylesheet" href="Styles/bootstrap.css" />
    <link rel="Stylesheet" href="../../Styles/main.css" />
    <link rel="Stylesheet" href="Styles/bootstrap.min.css" />
    <link rel="Stylesheet" href="Styles/style_metronic.css" />
    <link rel="Stylesheet" href="Styles/style-metronic.css" />
    <link rel="Stylesheet" href="Styles/font-awesome.css" />
    <link rel="Stylesheet" href="Styles/font-awesome.min.css" />
    <script language="javascript" type="text/javascript">

        function ShowPopup() {
            var PageUrl = 'AddNewPopUp.aspx';
            window.open(PageUrl, '', 'width=600,height=200,location=no,menubar=no,resize=no,scrollbars=no,status=no,toolbar=no,left=300,top=100');
        }
    </script>
    
    <!-- IMPORTANT! fullcalendar depends on jquery-ui-1.10.3.custom.min.js for drag & drop support -->
<script src="Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
<script src="Scripts/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
<!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
<script src="Scripts/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
<script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.slimscroll.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.cokie.min.js" type="text/javascript"></script>
<!-- END CORE PLUGINS -->
<!-- BEGIN PAGE LEVEL PLUGINS -->
<script src="Scripts/moment.min.js" type="text/javascript"></script>
<script src="Scripts/daterangepicker.js" type="text/javascript"></script>
<script src="Scripts/jquery.gritter.js" type="text/javascript"></script>
<!-- IMPORTANT! fullcalendar depends on jquery-ui-1.10.3.custom.min.js for drag & drop support -->
<script src="Scripts/fullcalendar.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.easy-pie-chart.js" type="text/javascript"></script>
<script src="Scripts/jquery.sparkline.min.js" type="text/javascript"></script>
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="Scripts/app.js" type="text/javascript"></script>
<script src="Scripts/index.js" type="text/javascript"></script>
<script src="Scripts/tasks.js" type="text/javascript"></script>
<!-- END PAGE LEVEL SCRIPTS -->

<script type="text/javascript">
    jQuery(document).ready(function () {
       // debugger;
        App.init(); // initlayout and core plugins
        Index.init();
        //Index.initJQVMAP(); // init index page's custom scripts
        Index.initCalendar(); // init index page's custom scripts
        Index.initCharts(); // init index page's custom scripts
        Index.initChat();
        Index.initMiniCharts();
        Index.initDashboardDaterange();
        Index.initIntro();
        Tasks.initDashboardWidget();
    });
</script>
<!-- END PAGE LEVEL PLUGINS -->
    <script language="javascript" type="text/javascript">
        function ShowReqDtl(divId, btnId) {
            //debugger;
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                document.getElementById(btnId).value = '-';
            }
        }
       
    </script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDyndZZALAfd5c1vfGGK_VbWTPuuhCJq9Q&v=3&sensor=true"></script>
    <script type="text/javascript" language="javascript">
        function initialize() {
            //debugger;
            //Generate Google Maps v3 Map Object
            var map = new google.maps.Map(document.getElementById('map-canvas'), {
                center: new google.maps.LatLng(19.072501451715087, 72.87083387374878),
                zoom: 7,
                mapTypeId: google.maps.MapTypeId.HYBRID
            });

            this.inner = function (city) {//debugger;
                //Set Variables
                var strCity = city;
                var LatLng;
                var msg;
                var Type;
                var image;
                var shape;

                switch (strCity) {
                    case "Head Office":
                        LatLng = new google.maps.LatLng(18.936495, 72.834387); msg = "<div class='infoWindow'><h4>Head Quarters: AlJamea tus Saifiyah</h4>Badri Mahal,211/213 D.N.Road, 1st Flr,Fort, Mumbai 400001.<br>Maharashtra.<hr width='220px'><strong>Contact Person :</strong>Mr Malik -ul Ashter<br><strong>Mob : </strong>091 9819837452 / 91 22 43515231</div>"; /*<br/><b>Mr. Ali Asger</b><br/><b>Mr. Amman Talib</b></div>";*/Type = "HO"; break;
                    case "Karachi Jamea":
                        LatLng = new google.maps.LatLng(24.894534, 67.029548); msg = "<div class='infoWindow'><h4>Jamea : Karachi</h4></div>"; /*<br>Unit No 405, 4th Floor,<br>3rd EYE ONE,<br>Opp Havmor Restaurant, Panchvati,<br>C G Road,<br>Ahemdabad - 380006.<br>Gujarat.<br><b>Tel : </b>079 - 30481311<br><b>Fax : </b>079 - 30481312<hr width='220px'><b>Contact Person</b><br>Purvish Patel<br><b>Mob : </b>7926853127 , 9920117770</div>";*/Type = "J"; break;
                    case "Marol Jamea":
                        LatLng = new google.maps.LatLng(19.117516, 72.883938); msg = "<div class='infoWindow'><h4>Jamea : Marol</h4></div>"; /*<br>19-A,<br> Nyay Marg ( Hasting Road ,<br> Ashok Nagar,<br> Allahabad-211001 .<br>Uttar Pradesh.<br><b>Tel :0532-2420798 </b> <br><b>Fax : </b> <hr width='220px'><b>Contact Person</b><br>Mr. Amit Jaiswal<br><b>Mob : </b>9918300852</div>"; */Type = "J"; break;
                    case "Nairobi Jamea":
                        LatLng = new google.maps.LatLng(-1.292844, 36.819992); msg = "<div class='infoWindow'><h4>Jamea : Nairobi</h4></div>"; /*<br>4-5, First Floor, Kush Marg,<br>Station Road, <Br/>Alwar- 301001.<br> Rajasthan. <br><b>Tel : 0144-2700750/2700931</b> <br><b>Fax : </b> <hr width='220px'> <b>Contact Person</b><br>Mr Rohit Singh <br><b>Mob : </b>09214333405 </div>";*/Type = "J"; break;
                    case "Surat Jamea":
                        LatLng = new google.maps.LatLng(21.195185, 72.832575); msg = "<div class='infoWindow'><h4>Jamea : Surat</h4>Mahad al-Zahra - Aljamea-tus-Saifiyah,Deori Mubarak, Zampa Bazaar,Surat. Gujrat.<br><b>Tel : 0261 3011209</b></div>"; Type = "J"; break;
                }
                
                //Calculate a position which places mapcenter above the marker
                function map_recenter(latlng, offsetx, offsety) {
                    var point1 = map.getProjection().fromLatLngToPoint(
                    (latlng instanceof google.maps.LatLng) ? latlng : map.getCenter());
                    var point2 = new google.maps.Point(
                    ((typeof (offsetx) == 'number' ? offsetx : 0) / Math.pow(2, map.getZoom())) || 0,
                    ((typeof (offsety) == 'number' ? offsety : 0) / Math.pow(2, map.getZoom())) || 0
                    );
                    map.setCenter(map.getProjection().fromPointToLatLng(new google.maps.Point(
                    point1.x - point2.x,
                    point1.y + point2.y
                                    )));
                }

                //Generate Marker
                var marker = new google.maps.Marker({
                    position: LatLng,
                    map: map
                });

                //Generate Marker Information Window
                var infoWindow = new google.maps.InfoWindow();

                //Listen to the Click event provided for Marker
                google.maps.event.addListener(marker, 'click', function () {
                    infoWindow.open(map, marker);
                    infoWindow.setContent(msg);
                });

                //Auto Navigate to Marker
                map_recenter(LatLng, 0, -80);

                //Trigger a Marker Click event
                google.maps.event.trigger(marker, 'click');
            }
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
    <style type="text/css">
        /*#WebPartTitle_gwpPanel2, #WebPartTitle_gwpPanel3,*/
        #WebPartTitle_gwpPanel4
        {
            font-weight: bold;
            font-size: 8pt;
            font-family: Verdana,Tahoma,Arial;
            padding-left: 5px;
            padding-bottom: 6px;
            padding-top: 6px; /*background-image:url('../../image/tab-bg3.jpg');*/ /*background-image:url('../../image/news6.JPG');*/ /*background-image:url('../../image/webhdr1.JPG');*/
            background-image: url('../../image/Webhdr2.JPG');
            background-color: #4B8EF9;
            color: white;
        }
        .webpartlabel
        {
            font-weight: bold;
            font-size: 9pt;
            font-family: Arial;
        }
        
        #WebPartTitle_gwpPanel2
        {
            font-weight: bold;
            font-size: 8pt;
            font-family: Verdana,Tahoma,Arial;
            padding-left: 5px;
            padding-bottom: 6px;
            padding-top: 6px; /*background-image:url('../../image/tab-bg3.jpg');*/ /*background-image:url('../../image/Alert7.JPG');*/ /*background-image:url('../../image/Alerthdr1.JPG');*/
            color: white;
        }
        
        #WebPartTitle_gwpPanel3
        {
            font-weight: bold;
            font-size: 8pt;
            font-family: Verdana,Tahoma,Arial;
            padding-left: 5px;
            padding-bottom: 6px;
            padding-top: 6px; /*background-image:url('../../image/tab-bg3.jpg');*/ /*background-image:url('../../image/Announce.JPG');*/ /*background-image:url('../../image/Webhdr3.JPG');*/
            color: white;
        }
        
        .gmapCanvasDiv
        {
            width: 500px;
            height: 230px;
        }
        .locationHeader
        {
            font-family: Verdana;
            font-size: small;
            color: Maroon;
        }
        .infoWindow
        {
            height: auto;
            width: 100%;
            font-family: Arial;
            font-size: smaller;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server" Height="300px">
        
				<div class="col-md-12">
					<!-- BEGIN PAGE TITLE & BREADCRUMB-->
					<h3 class="page-title">
					Dashboard <small>statistics and more</small>
					</h3>
                    <table class="page-breadcrumb breadcrumb" width="100%">
                    <tr>
                        <td style="width: 110px;height:30px;">
                            <asp:Label runat="server" ID="lblTitle" CssClass="HeaderInfo" Text="Hierarchy Name" ></asp:Label>
                        </td>
                        <td style="width: 240px;">
                            <asp:UpdatePanel ID="updslsChnl" runat="server" >
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSlsChannel" runat="server" AutoPostBack="True" CssClass="standardmenu"
                                        Width="140px" OnSelectedIndexChanged="ddlSlsChannel_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="width: 320px;">
                        </td>
                        <td align="right" style="font-family: Arial; padding-left: 10px;">
                            <asp:Label ID="lbldate" runat="server" CssClass="HeaderInfo"  Text="Date:   "  Font-Bold="true" ></asp:Label> 
                                <span class="HeaderDetail" ><%= string.Format("{0:dd/MM/yyyy   hh:mm:ss}",System.DateTime.Now)%></span>
                            &nbsp;&nbsp;
                                <span class="HeaderDetail"><%= DateTime.Now.DayOfWeek.ToString()  %></span>
                        </td>
                    </tr>
                </table>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
        <div id="divimg" class="col-md-12">
            <table width="100%">
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel ID="updCount" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 25%;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" style="height: 150px; width: 230px;
                                                background-repeat: no-repeat;">
                                                <div class="dashboard-stat blue" style="margin-left: 0px; padding-left: 0px;">
                                                    <div class="visual">
                                                        <i class="fa fa-comments"></i>
                                                    </div>
                                                    <div class="details">
                                                        <div class="number">
                                                            <asp:Label ID="lblEmpCnt" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="desc">
                                                            Employee Count
                                                        </div>
                                                    </div>
                                                    <a class="more" href="#">View more <i class="m-icon-swapright m-icon-white"></i>
                                                    </a>
                                                </div>
                                            </div>
                                        </td>
                                        <td style="width: 25%;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" style="height: 150px; width: 230px;
                                                background-repeat: no-repeat;">
                                                <div class="dashboard-stat green">
                                                    <div class="visual">
                                                        <i class="fa fa-shopping-cart"></i>
                                                    </div>
                                                    <div class="details">
                                                        <div class="number">
                                                            <asp:Label ID="lblAgntCnt" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="desc">
                                                            Agent Count
                                                        </div>
                                                    </div>
                                                    <a class="more" href="#">View more <i class="m-icon-swapright m-icon-white"></i>
                                                    </a>
                                                </div>
                                            </div>
                                        </td>
                                        <td style="width: 25%;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" style="height: 150px; width: 230px;
                                                background-repeat: no-repeat;">
                                                <div class="dashboard-stat purple">
                                                    <div class="visual">
                                                        <i class="fa fa-globe"></i>
                                                    </div>
                                                    <div class="details">
                                                        <div class="number">
                                                            <asp:Label ID="lblVenCnt" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="desc">
                                                            Vendor Count
                                                        </div>
                                                    </div>
                                                    <a class="more" href="#">View more <i class="m-icon-swapright m-icon-white"></i>
                                                    </a>
                                                </div>
                                            </div>
                                        </td>
                                        <td style="width: 25%;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" style="height: 150px; width: 230px;
                                                background-repeat: no-repeat;">
                                                <div class="dashboard-stat yellow">
                                                    <div class="visual">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                    </div>
                                                    <div class="details">
                                                        <div class="number">
                                                            <asp:Label ID="lblUntCnt" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="desc">
                                                            Unit Count
                                                        </div>
                                                    </div>
                                                    <a class="more" href="#">View more <i class="m-icon-swapright m-icon-white"></i>
                                                    </a>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlSlsChannel" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="portlet box blue" style="width:480px; margin-left:10px;margin-top:10px;">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-cogs"></i>My Alerts
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a><a href="#portlet-config" data-toggle="modal"
                                        class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;"
                                            class="remove"></a>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="scroller" style="height: 260px;" data-always-visible="1" data-rail-visible="0">
                                    <%--<asp:GridView ID="gvAlert" runat="server" Width="100%" class="table table-bordered table-striped"
                                        AutoGenerateColumns="False" AllowPaging="True" Height="250px" PageSize="5" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Alert Date" HeaderStyle-HorizontalAlign="Center" SortExpression="Alert Date"
                                                ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="Gvitem">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDt" runat="server" Text='<%# Bind("AlertDate") %>' ForeColor="Black"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Alerts" HeaderStyle-HorizontalAlign="Center" SortExpression="Description"
                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="Gvitem">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblDes" Text='<%# Bind("Description") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center" SortExpression="Status"
                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="Gvitem">
                                                <ItemTemplate>
                                                    <asp:Label Text="lblStatus" runat="server" ID="lblStatus" />
                                                    <asp:Image ImageUrl="" runat="server" ID="imgStatus" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Center" />
                                        <FooterStyle BackColor="#B6C60E" />
                                    </asp:GridView>--%>
                                    <table style="Width:100%;" class="table table-bordered table-striped">
                                        <tr>
                                            <td style="text-align:center;">
                                                Alert Date
                                            </td>
                                            <td style="text-align:center;">
                                                Alerts
                                            </td>
                                            <td style="text-align:center;">
                                                Status
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:center;">
                                                21/04/2014
                                            </td>
                                            <td style="text-align:left;">
                                                Movements : Member Transfer requested
                                            </td>
                                            <td style="text-align:center;">
                                                18
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:center;">
                                                22/04/2014
                                            </td>
                                            <td style="text-align:left;">
                                                Movements : Member Transfer approved
                                            </td>
                                            <td style="text-align:center;">
                                                10
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:center;">
                                                23/04/2014
                                            </td>
                                            <td style="text-align:left;">
                                                Movements : Members Terminated
                                            </td>
                                            <td style="text-align:center;">
                                                8
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:center;">
                                                24/04/2014
                                            </td>
                                            <td style="text-align:left;">
                                                Movements : Members Prmotion requested
                                            </td>
                                            <td style="text-align:center;">
                                                8
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:center;">
                                                25/04/2014
                                            </td>
                                            <td style="text-align:left;">
                                                Movements : Members Prmotion approved
                                            </td>
                                            <td style="text-align:center;">
                                                8
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="scroller-footer">
                                    <div style="text-align:center;">
                                        <asp:LinkButton ID="lnkAddNew" runat="server" ForeColor="blue" Font-Names="Verdana"
                                            Font-Size="Smaller" OnClientClick="javascript:ShowPopup();return false;">Add New Alert</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="portlet box green" style="width:480px; padding-left:5px;margin-left:10px;margin-top:10px;">
                        <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-cogs"></i>News 
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a><a href="#portlet-config" data-toggle="modal"
                                        class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;"
                                            class="remove"></a>
                                </div>
                            </div>
                            <div class="portlet-body">
                            <div class="scroller" style="height: 260px;" data-always-visible="1" data-rail-visible="0">
                                    <table border="0" cellspacing="0" cellpadding="0" width="300px" style="margin-left: -20px;
                                        margin-right: 26px; height: 50px;">
                                        <tr>
                                            <td align="left" style="width: 400px;">
                                                <div style="height: 175px; width: 300px; padding-left: 5px; margin-left: 19px;" align="justify">
                                                    <marquee scrollamount="1" id="place" onmouseover="javascript:stop()" onmouseout="javascript:start();"
                                                        scrolldelay="5" behavior="scroll" direction="up" height="200px" width="350px"
                                                        style="position: relative; vertical-align: bottom; padding-right: 2px; margin-right: 5px;"
                                                        class="ul_newsFeed">
                                                    <ul style="padding-right:13px;">
                                                        <li style="margin-left:-28px; text-align:justify;font-family:Arial;">
                                                            <a  href="#">
                                                                <b><asp:Label ID="lblDate1News" runat="server" Text="Section 1.10.32" CssClass="webpartlabel"></asp:Label></b>
                                                            </a><br/>
                                                                <asp:Label ID="lblDesc1News" runat="server" Text="Sed ut perspiciatis unde omnis iste natus error sit" CssClass="webpartlabel"></asp:Label><br/>
                                                            <div style="padding:7px 0px 7px 50px; width:50px; height:1px;"></div>
                                                        </li>
                                                        <li style="margin-left:-28px; text-align:justify;font-family:Arial;">
                                                            <a  href="#"><b>
                                                                <asp:Label ID="lblDate2News" runat="server" Text="1914 translation by H. Rackham" CssClass="webpartlabel"></asp:Label></b>
                                                            </a><br/>
                                                            <asp:Label ID="lblDesc2News" runat="server" Text="But I must explain to you how all this mistaken idea of denouncing" CssClass="webpartlabel"></asp:Label><br/>
                                                            <div style="padding:7px 0px 7px 50px; width:50px; height:1px;"></div>
                                                        </li>
                                                        <li style="margin-left:-28px; text-align:justify;font-family:Arial;">
                                                            <a  href="#">
                                                                <b><asp:Label ID="lblDate3News" runat="server" Text="Section 1.10.33" CssClass="webpartlabel"></asp:Label></b>
                                                            </a><br/>
                                                            <asp:Label ID="lblDesc3News" runat="server" Text="At vero eos et accusamus et iusto odio dignissimos ducimus" CssClass="webpartlabel"></asp:Label><br/>
                                                            <div style="padding:7px 0px 7px 50px; width:50px; height:1px;"></div>
                                                        </li>
                                                    </ul>
                                                </marquee>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="scroller-footer">
                                    <div style="text-align:center;height:12px;">
                                    </div>
                                </div>
                        </div>
                        </div>
                    </td>
                </tr>
                    <tr>
                        <td>
                        <div class="portlet box yellow" style="width:480px; padding-left:5px;margin-left:10px;margin-top:10px;">
                            <div class="portlet-title">
							<div class="caption">
								<i class="fa fa-reorder"></i>Bar Chart
							</div>
							<div class="tools">
								<a href="javascript:;" class="collapse">
								</a>
								<a href="#portlet-config" data-toggle="modal" class="config">
								</a>
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
						</div>
                        <div class="portlet-body">
                            <div class="scroller" style="height: 230px;width:500px;" data-always-visible="1" data-rail-visible="0">
                                <asp:Chart ID="AsatezaAdmission" Height="230px" runat="server" Width="500px" Palette="SeaGreen">
                                    <Legends>
                                        <asp:Legend Name="Legend" Title="Asateza" BackColor="#FAFAFA">
                                        </asp:Legend>
                                    </Legends>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BackImageTransparentColor="ActiveBorder">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                    <Titles>
                                        <asp:Title Font="Microsoft Sans Serif, 10pt" ForeColor="DodgerBlue" Name="Title"
                                            Text="Asateza Admission Charts ">
                                        </asp:Title>
                                    </Titles>
                                </asp:Chart>
                            </div>
                            </div>
					</div>
                        </td>
                        <td>
                        <div class="portlet box purple" style="width:480px; padding-left:5px;margin-left:10px;margin-top:10px;">
                            <div class="portlet-title">
							<div class="caption">
								<i class="fa fa-reorder"></i>Bar Chart
							</div>
							<div class="tools">
								<a href="javascript:;" class="collapse">
								</a>
								<a href="#portlet-config" data-toggle="modal" class="config">
								</a>
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
						</div>
                        <div class="portlet-body">
                            <div class="scroller" style="height: 230px;width:500px;" data-always-visible="1" data-rail-visible="0">
                                <asp:Chart ID="TalabatAdmission" Height="230px" runat="server" Width="500px" Palette="Pastel">
                                    <Legends>
                                        <asp:Legend Name="Legend1" Title="Talabat" BackColor="White" TextWrapThreshold="50">
                                        </asp:Legend>
                                    </Legends>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                    <Titles>
                                        <asp:Title Font="Microsoft Sans Serif, 10pt" ForeColor="DodgerBlue" Name="Title1"
                                            Text="Talabat Admission Charts ">
                                        </asp:Title>
                                    </Titles>
                                </asp:Chart>
                            </div>
                            </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <%--<td colspan="2">
					<div class="portlet box red calendar" style="width:480px; padding-left:5px;margin-left:10px;margin-top:10px;">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-calendar"></i>Calendar
							</div>
						</div>
						<div class="portlet-body light-grey" style="height:400px;">
							<div id="calendar" style="height:100%;">
							</div>
						</div>
					</div>
					
                        </td>--%>
                        <td colspan="2" style="vertical-align:top;text-align:center;" align="center" >
                        <div class="portlet solid yellow" style="width:700px; padding-left:5px;margin-left:10px;margin-top:10px;">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-reorder"></i>Markers
							</div>
							<div class="tools">
								<a href="javascript:;" class="collapse">
								</a>
								<a href="#portlet-config" data-toggle="modal" class="config">
								</a>
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
						</div>
						<div class="portlet-body">
                            <div class="scroller" style="height: 350px;width:500px;" data-always-visible="1" data-rail-visible="0">
                                <div id="map-canvas" style="width: 100%;height: 300px;" >
                                </div>
                                <span class="locationHeader">Jamea Location</span>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:LinkButton Text="Badri Mahal - H.O" runat="server" ID="LinkButton1" CssClass="lblimg1"
                                                OnClientClick="javascript:(new initialize()).inner('Head Office');return false;" />|
                                        </td>
                                        <td>
                                            <asp:LinkButton Text="Karachi Jamea" runat="server" ID="LinkButton2" CssClass="lblimg1"
                                                OnClientClick="javascript:(new initialize()).inner('Karachi Jamea');return false;" />|
                                        </td>
                                        <td>
                                            <asp:LinkButton Text="Marol Jamea" runat="server" ID="LinkButton3" CssClass="lblimg1"
                                                OnClientClick="javascript:(new initialize()).inner('Marol Jamea');return false;" />|
                                        </td>
                                        <td>
                                            <asp:LinkButton Text="Nairobi Jamea" runat="server" ID="LinkButton4" CssClass="lblimg1"
                                                OnClientClick="javascript:(new initialize()).inner('Nairobi Jamea');return false;" />|
                                        </td>
                                        <td>
                                            <asp:LinkButton Text="Surat Jamea" runat="server" ID="LinkButton5" CssClass="lblimg1"
                                                OnClientClick="javascript:(new initialize()).inner('Surat Jamea');return false;" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            </div>
					</div>
                        </td>
                    </tr>
                </table>
        
            </div>
    </asp:Panel>
    </form>
</body>
</html>

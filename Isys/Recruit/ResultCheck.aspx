<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="ResultCheck.aspx.cs" Inherits="Application_Isys_Recruit_ResultCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <script src="../../../assets/scripts/jquery-1.10.2.min.js"></script>
    <script src="../../../assets/scripts/jquery.min.js"></script>
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
    <meta http-equiv="X-UA-Compatible" content="IE=11"/>
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
  <%--  <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />--%>
  <%--  <meta http-equiv="X-UA-Compatible" content="IE=edge" />--%>
<%--    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />--%>
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
    <script language="javascript" type="text/javascript">  
        
       //setTimeout("location.reload(true);", 1000);     
        $(document).ready(function () {
            debugger;
            //var x = document.getElementById("ctl00_ContentPlaceHolder1_BtnSubmitCaptcha");
            //if (window.getComputedStyle(x).display === "none") {
            //    setTimeout("location.reload(true);", 5000);
            //}
            //else {
            //    setTimeout("location.reload(true);", 15000);
            //}
            var Panno = getUrlParameter("Panno");
            var Sid = getUrlParameter("SId");
            //var path = "Images/Screenshot.png";
            //var a = imageExists(path);
            //if (a == true) {
            //    setTimeout("location.reload(true);", 15000);
            //}
            //else {
            //    setTimeout("location.reload(true);", 5000);
            //}
            //var userGuid = RefSts(Panno, Sid);
            //if (userGuid == "Enter Captcha" || userGuid == "Re-Enter Captcha") {
            //    setTimeout(RefSts(Panno, Sid), 15000);
            //}
            //else {
            //    setTimeout(RefSts(Panno, Sid), 5000);
            //}
            var userGuid = RefSts(Panno, Sid);
            //userGuid.success(function (_data) {
            //    alert(_data.d);
            //});
            userGuid.success(function (_data) {
                var status = _data.d;
                if (status == "Enter Captcha" || status == "Re-Enter Captcha") {
                    setTimeout("location.reload(true);", 15000);
                }
                else {
                    setTimeout("location.reload(true);", 5000);
                }
            });
           //RefSts(Panno, Sid);
        });
        //function Initialize() {
        //    debugger;
        //    var Panno = getUrlParameter("Panno");
        //    var Sid = getUrlParameter("SId");
        //    var path = "Images/Screenshot.png";
        //    var a = imageExists(path);
        //    if (a == true) {
        //        setTimeout("location.reload(true);", 15000);
        //    }
        //    else {
        //        setTimeout("location.reload(true);", 5000);
        //    }
        //    RefSts(Panno, Sid);
        //};
        function getUrlParameter(name) {
            name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
            var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
            var results = regex.exec(location.search);
            return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
        };        
        function RefSts(Panno, Sid) {
            debugger;
            var obj = {}
            var object = {}
            var dataObj = [];
            //var ActNo = getQueryVal('uid', window.location);
            object["panno"] = Panno;
            object["sid"] = Sid;

            dataObj.push(object);
            sendObj = {
                data: (dataObj)
            }

            //$.ajax({
            return $.ajax({
                type: "POST",
                url: "ResultCheck.aspx/CheckPanSts",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (_data) {
                    debugger;                   
                    var userGuid = _data.d;
                    //var path = "D:\\Sarthak\\PAN verification\\PAN verification\\Images\\" + Panno +".png";
                    //var path = "Images/Screenshot.png;
                    var path = "Images/Screenshot.png?time=" + Date.now();
                    document.getElementById('ctl00_ContentPlaceHolder1_Data').innerHTML = userGuid;
                    //var a = imageExists(path); 
                    //document.getElementById("CaptchaImg").innerHTML = path;
                    //if (a == true)
                    //{
                    //    debugger;
                    //   // setTimeout("location.reload(true);", 1000);
                    //    document.getElementById('CaptchaImg').setAttribute('style', 'display:block');
                    //    document.getElementById('CaptchaImg').setAttribute('src', path);
                    //    document.getElementById('ctl00_ContentPlaceHolder1_txtCaptcha').setAttribute('style', 'display:block');
                    //    document.getElementById('ctl00_ContentPlaceHolder1_BtnSubmitCaptcha').setAttribute('style', 'display:block');
                    //    document.getElementById('ctl00_ContentPlaceHolder1_BtnClear').setAttribute('style', 'display:block');
                    //    //setTimeout("location.reload(true);", 15000);
                    //}
                    if (userGuid == "Enter Captcha" || userGuid == "Re-Enter Captcha") {
                        debugger;
                        // setTimeout("location.reload(true);", 1000);
                        document.getElementById('CaptchaImg').setAttribute('style', 'display:block');
                        document.getElementById('CaptchaImg').setAttribute('src', path);
                        document.getElementById('ctl00_ContentPlaceHolder1_txtCaptcha').setAttribute('style', 'display:block');
                        document.getElementById('ctl00_ContentPlaceHolder1_BtnSubmitCaptcha').setAttribute('style', 'display:block');
                        document.getElementById('ctl00_ContentPlaceHolder1_BtnClear').setAttribute('style', 'display:block');
                        //setTimeout("location.reload(true);", 15000);
                    }
                    if (userGuid == "Matching Record Found in Database" || userGuid == "No Data Found in POS System")
                    {
<%--                        window.parent.$find('<%=Request.QueryString["pnlRwdRulDemo"].ToString()%>').hide();--%>
                        doCancel(userGuid);

                    }
                    //return userGuid;
                },
                failure: function (response) {
                    alert("Something went wrong.");
                }
            });
            //return userGuid;
        }
        function imageExists(image_url) {

            var http = new XMLHttpRequest();

            http.open('HEAD', image_url, false);
            http.send();

            return http.status != 404;

        }
        function doCancel(Status) {
            setInterval(function () {
                var status = Status;
                window.parent.CallParent(status);
            }, 3000);
        }
        
     </script>
    <style>
        .dataCenter {
            margin-top: 75px;
            margin-left: 54px;
        }
    </style>

    <div class="dataCenter" style="margin-left:269px">
        <center><img src="../../../assets/img/input-spinner.gif" style="margin-right:228px"/><br /></center>
        <asp:Label ID="Data" runat="server" ForeColor="Blue"></asp:Label><br />
        <%--<asp:Image ID="CaptchaImg" runat="server" /><br />--%>
        <img id="CaptchaImg" style="display:none; margin-left: 4px;" src=""/><br />
        
        <div class="row">
            <div class="col-xs-3" style="margin-left: 4px;">
                <asp:TextBox ID="txtCaptcha" Style="display: none;" CssClass="form-control" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="row" style="margin-right:70%; margin-left:0.40%">
            <div style="float: left">
                <asp:Button ID="BtnSubmitCaptcha" Style="display: none;" runat="server" Text="Submit" CssClass="btn btn-verify" OnClick="BtnSubmitCaptcha_Click" />
            </div>
            <div style="float: right">
                <asp:Button ID="BtnClear" Style="display: none;" runat="server" Text="Clear" CssClass="btn btn-verify" OnClick="BtnClear_Click" /><br />
            </div>
          <%--<div class="col-md-4">
            </div>--%>
        </div>
        <div class="row" style="text-align:center; margin-right:207px">
            Processing...<br />
            <img src="../../../assets/img/Fading_squares.gif" />
            <br />
        </div>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="Integration.aspx.cs" Inherits="Application_Isys_Recruit_Integration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <script src="../../../assets/scripts/jquery-1.10.2.min.js"></script>
    <script src="../../../assets/scripts/jquery.min.js"></script>
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
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
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">

        function Openwindow(URL) {
            debugger;
            window.open(URL,'', 'width=900,height=550,toolbar=no,scrollbars=Yes,resizable=No,left=180,top=150,location=0;');
        }
        function LdWait(delay) {
            //debugger;
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'block';
            setTimeout("RemoveLoading12()", delay);
        }
        function RemoveLoading12() {
            //debugger;
            //hide loading status...
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'none';

        }

        function Conpopup(id) {
            debugger;
            document.getElementById("<%=hdnPopmsg.ClientID%>").value = id;
            if (id=="btnYes") {
                txt = "Yes";
                Hidepopup();
            document.getElementById('ctl00_ContentPlaceHolder1_lnkPrcdWthInt').click()
            }
            else
            {
                txt = "No";
				Hidepopup();
				//document.getElementById('ctl00_ContentPlaceHolder1_lnkPrcdWthInt').click()
				var Pan = '<%= ViewState["Pan"] %>'
				var Sid = '<%= ViewState["sid"] %>'
				var Userid = '<%= Session["UserID"] %>'
				RefSts(Pan, Sid, Userid);
            }
            
        }

        function popup() {
            debugger;
            $("#myModal").show();
        }
        function Hidepopup() {
			debugger;
			$("#myModal").hide();
		}
    </script>

    <%--added by sanoj for NSDL--%>
    <script language="javascript" type="text/javascript">
         function Datedob() {
            var start = new Date();
            start.setFullYear(start.getFullYear() - 70);
            var end = new Date();
            end.setFullYear(end.getFullYear() - 18);
            $("#<%= txtDOB.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                minDate: start,
                maxDate: end,
                yearRange: start.getFullYear() + ':' + end.getFullYear()
            });
             document.getElementById('ctl00_ContentPlaceHolder1_divLoaderCERSAI').style.display = 'none';


        }

        
        function openLoader(){
            document.getElementById('ctl00_ContentPlaceHolder1_divLoaderCERSAI').style.display = 'block';
        }
        function RefSts(Panno, Sid, UserId) {
            debugger;
            var obj = {}
            var object = {}
			var dataObj = [];
			//async = false;
            //var ActNo = getQueryVal('uid', window.location);
            object["panno"] = Panno;
            object["sid"] = Sid;
            object["UserId"] = UserId;

            dataObj.push(object);
            sendObj = {
                data: (dataObj)
            }
            //console.info(performance.navigation.type);
            //if (performance.navigation.type == performance.navigation.TYPE_RELOAD) {
            //    //alert("This page is reloaded");
            //    window.open("../../../index.aspx", "_self");
            //}

            //$.ajax({
            return $.ajax({
                type: "POST",
                url: "Integration.aspx/CheckPanSts",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (_data) {
                    debugger;

                    //document.getElementById('iLoading').style.display = 'block';

                    var j = JSON.parse(_data.d);
                    //var userGuid = _data.d;
                    //var path = "D:\\Sarthak\\PAN verification\\PAN verification\\Images\\" + Panno +".png";
                    //var path = "Images/Screenshot.png;
                    //var path = "Images/Screenshot.png?time=" + Date.now();
                    //var path = "../../../ExternalImages/Screenshot.png?time=" + Date.now();
                    //var path = "../../../ExternalImages/NSDL/" + Panno + ".png?time=" + Date.now();
                    //document.getElementById('ctl00_ContentPlaceHolder1_Data').innerHTML = userGuid;
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
                    //if (userGuid == "Enter Captcha" || userGuid == "Re-Enter Captcha") {
                    /* if (j["status"] == "PAN Number based search initiated" || j["status"] == "PAN Number based search in progress")*/
                    if (j["Data"] == "4" || j["Data"] == "5")
                    {
                        debugger;
                        // setTimeout("location.reload(true);", 1000);
                        document.getElementById('divCmpnyNme').style.display = 'block';
                        document.getElementById('divcaptchaimg').style.display = 'none';//by ajay08052023
                        //document.getElementById('ctl00_ContentPlaceHolder1_popuphidden').style.display = 'block';
                        //document.getElementById('CaptchaImg').setAttribute('style', 'display:block');
                        //while (true) {
                        //    var n = imageExists(path);
                        //    if (n == true) {
                        //        break;
                        //    }
                        //}
                        //document.getElementById('ctl00_ContentPlaceHolder1_popuphidden').setAttribute('style', 'display:block');
                        document.getElementById('CaptchaImg').setAttribute('src', "data:image/png;base64," + j["image"]);
                        //document.getElementById('ctl00_ContentPlaceHolder1_txtCaptcha').setAttribute('style', 'display:block');
                        //document.getElementById('ctl00_ContentPlaceHolder1_BtnSubmitCaptcha').setAttribute('style', 'display:block');
                        //document.getElementById('ctl00_ContentPlaceHolder1_BtnClear').setAttribute('style', 'display:block');
                        //setTimeout(RefSts(Panno, Sid), 15000);
                        //document.getElementById('divPAN').style.display = 'none';
                       // document.getElementById('divCaptchatxt').style.display = 'inherit';
                        document.getElementById('divPAN').style.display = 'none';

                        document.getElementById('ctl00_ContentPlaceHolder1_divloader').style.display = 'none';
                        console.log("ok");
                    }
                   
                    else {
                        debugger;
                        document.getElementById('divCmpnyNme').style.display = 'none';
                        document.getElementById('divPAN').style.display = 'none';
                        document.getElementById('divcaptchaimg').style.display = 'none';
                        //document.getElementById('divCaptchatxt').style.display = 'none';
                        document.getElementById('divShowResult').style.display = 'none';
                    }
                  /*  if (j["status"] == "Matching Record Found in Database" || j["status"] == "No Data Found in POS System")*/
                    if (j["Data"] == "6" || j["Data"] == "7")
                    //if (userGuid != 
                    {
                        //alert('ajay ');
                        debugger;
						//myTimeout = setTimeout(RefSts(Panno, Sid, UserId), 15000);
						//clearTimeout(myTimeout);
                        document.getElementById('divCmpnyNme').style.display = 'block';
                        document.getElementById('divcaptchaimg').style.display = 'none';
                        //document.getElementById('divCaptchatxt').style.display = 'none';
                        document.getElementById('ctl00_ContentPlaceHolder1_divCaptchatxt1').style.display = 'none';
                        document.getElementById('divPAN').style.display = 'inherit';
						document.getElementById('divShowResult').style.display = 'block';
						 document.getElementById('ctl00_ContentPlaceHolder1_divloader').style.display = 'none';
                        //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = userGuid;
                        //alert('Hiii');
                        var Message = j["Result"];
                        //alert(Message);
                        //console.log(Message);
                        //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
                        document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText =Message; 

						if (document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText != null) {
                            document.getElementById('ctl00_ContentPlaceHolder1_LinkButton1').setAttribute('style', 'text-align: center;display: block;padding-top: 2px;margin-left: -22px;');

							document.getElementById('ctl00_ContentPlaceHolder1_LinkButton1').style.display = 'block';
							if (j["status"] == "Matching record found") {
								document.getElementById('ctl00_ContentPlaceHolder1_btnNsdl').setAttribute('style', 'margin-top: -4px;display: block;text-align: right;padding: 6px;')
								document.getElementById('ctl00_ContentPlaceHolder1_btnNsdl').style.display = 'block';
							}
							else {
								document.getElementById('ctl00_ContentPlaceHolder1_ShowResult').setAttribute('style', 'color: Green;font-size: 10px;padding-left: 37px;')
							}

                        }
                    }
                    //else if (j["status"] == "Invalid PAN") {
                    //    debugger;
                    //    document.getElementById('ctl00_ContentPlaceHolder1_divloader').style.display = 'none';

                    //    document.getElementById('divCmpnyNme').style.display = 'block';
                    //    document.getElementById('divcaptchaimg').style.display = 'none';
                    //    document.getElementById('divCaptchatxt').style.display = 'none';
                    //    document.getElementById('divPAN').style.display = 'inherit';
                    //    document.getElementById('divShowResult').style.display = 'block';
                    //    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = userGuid;
                    //    var Message = 'Invalid PAN '
                    //    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
                    //    document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = Message;

                    //}
                    //else {
                    //    setTimeout(RefSts(Panno, Sid, UserId), 15000);
                    //}
                    //return userGuid;sss
                },
                failure: function (response) {
                    alert("Something went wrong.");
                }
            }),
            //return userGuid;
            $.ajax({
                type: "POST",
                url: "Integration.aspx/CheckPanStsIIB",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (_data1) {
                    debugger;

					if (Object.keys(_data1.d).length != 0) {
						var k = JSON.parse(_data1.d);


						// if (j["status"] == "PAN Number based search initiated" || j["status"] == "PAN Number based search in progress")
						if (k["Data"] == "4" || k["Data"] == "5") {
							debugger;
							// setTimeout("location.reload(true);", 1000);
							document.getElementById('divCmpnyNme').style.display = 'block';
							document.getElementById('divcaptchaimgIIB').style.display = 'block';

							document.getElementById('CaptchaImgIIB').setAttribute('src', "data:image/png;base64," + k["image"]);

							document.getElementById('divCaptchatxtIIB').style.display = 'inherit';
							document.getElementById('divPAN').style.display = 'none';

							document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIIB').style.display = 'none';
							console.log("ok");
						}

						else {

							document.getElementById('divCmpnyNme').style.display = 'none';
							document.getElementById('divPAN').style.display = 'none';
							document.getElementById('divcaptchaimgIIB').style.display = 'none';
							document.getElementById('divCaptchatxtIIB').style.display = 'none';
							document.getElementById('divShowResultIIB').style.display = 'none';
						}
						//if (j["status"] == "Matching Record Found in Database" || j["status"] == "No Data Found in POS System")
						if (k["Data"] == "6" || k["Data"] == "7")
						//if (userGuid != "")
						{

							//   myTimeout = setTimeout(RefStsIIB(Panno, Sid, UserId), 15000);
							//clearTimeout(myTimeout);
							document.getElementById('divCmpnyNme').style.display = 'block';
							document.getElementById('divcaptchaimgIIB').style.display = 'none';
							document.getElementById('divCaptchatxtIIB').style.display = 'none';
							document.getElementById('divPAN').style.display = 'inherit';
							document.getElementById('divShowResultIIB').style.display = 'block';
							document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIIB').style.display = 'none';
							var Message = k["Result"];

							//document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
							document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIIB").innerText = Message;

							if (document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIIB").innerText != null) {
								let imageIIB = document.getElementById("ctl00_ContentPlaceHolder1_ImgIIB").src;
								if (imageIIB.includes("Black")) {
									document.getElementById("ctl00_ContentPlaceHolder1_ImgIIB").setAttribute('src','../../../image/IibClor.jpg');
								}
								document.getElementById('ctl00_ContentPlaceHolder1_LinkButton2').setAttribute('style', 'text-align: center;display: block;padding-top: 2px;margin-left: -22px;');

								document.getElementById('ctl00_ContentPlaceHolder1_LinkButton2').style.display = 'block';
								if (k["status"] == "No record found") {
									document.getElementById('ctl00_ContentPlaceHolder1_btnNextIIB').setAttribute('style', 'margin-top: -4px;display: block;text-align: right;padding: 6px;')
									document.getElementById('ctl00_ContentPlaceHolder1_btnNextIIB').style.display = 'block';
								}

							}

						}
						//else if (j["status"] == "Invalid PAN") {
						//    debugger;
						//    document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIIB').style.display = 'none';

						//    document.getElementById('divCmpnyNme').style.display = 'block';
						//    document.getElementById('divcaptchaimgIIB').style.display = 'none';
						//    document.getElementById('divCaptchatxtIIB').style.display = 'none';
						//    document.getElementById('divPAN').style.display = 'inherit';
						//    document.getElementById('divShowResultIIB').style.display = 'block';
						//    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = userGuid;
						//    var Message = j["Result"];
						//    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
						//    document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIIB").innerText = Message;

						//}
						//else {
						//    setTimeout(RefSts(Panno, Sid, UserId), 15000);
						//}
						//return userGuid;sss
					}
                },
                failure: function (response) {
                    alert("Something went wrong.");
                }
			}),
            $.ajax({
                type: "POST",
                url: "Integration.aspx/CheckPanStsIRDA",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (_data2) {
                    debugger;

					if (Object.keys(_data2.d).length != 0) {

						var l = JSON.parse(_data2.d);


						//if (j["status"] == "PAN Number based search initiated" || j["status"] == "PAN Number based search in progress")
						if (l["Data"] == "4" || l["Data"] == "5") {
							debugger;
							// setTimeout("location.reload(true);", 1000);
							document.getElementById('divCmpnyNme').style.display = 'block';
							document.getElementById('divcaptchaimgIRDA').style.display = 'block';

							document.getElementById('CaptchaImgIRDA').setAttribute('src', "data:image/png;base64," + l["image"]);

							document.getElementById('divCaptchatxtIRDA').style.display = 'inherit';
							document.getElementById('divPAN').style.display = 'none';

							document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIRDA').style.display = 'none';
							console.log("ok");
						}

						else {

							document.getElementById('divCmpnyNme').style.display = 'none';
							document.getElementById('divPAN').style.display = 'none';
							document.getElementById('divcaptchaimgIRDA').style.display = 'none';
							document.getElementById('divCaptchatxtIRDA').style.display = 'none';
							document.getElementById('divShowResultIRDA').style.display = 'none';
						}
						//if (j["status"] == "Matching Record Found in Database" || j["status"] == "No Data Found in POS System")
						if (l["Data"] == "6" && l["Result"] != "" || l["Data"] == "7" && l["Result"] != "")
						//if (userGuid != "")
						{

							//   myTimeout = setTimeout(RefStsIRDA(Panno, Sid, UserId), 15000);
							//clearTimeout(myTimeout);
							document.getElementById('divCmpnyNme').style.display = 'block';
							document.getElementById('divcaptchaimgIRDA').style.display = 'none';
							document.getElementById('divCaptchatxtIRDA').style.display = 'none';
							document.getElementById('divPAN').style.display = 'inherit';
							document.getElementById('divShowResultIRDA').style.display = 'block';
							document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIRDA').style.display = 'none';

							var Message = l["Result"];
							//document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
							document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIRDA").innerText = Message;
							if (document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIRDA").innerText != null) {
								let imageIRDA = document.getElementById("ctl00_ContentPlaceHolder1_ImgIRDA").src;
								if (imageIRDA.includes("Black")) {
									document.getElementById("ctl00_ContentPlaceHolder1_ImgIRDA").setAttribute('src', '../../../image/IrdaiClor.jpg');
									//while (true) {
									//	let imageIRDAColor = document.getElementById("ctl00_ContentPlaceHolder1_ImgIRDA").src;
									//	if (imageIRDAColor.includes("Clor")) {
									//		break;
									//	}
									//}									
									//document.getElementById('ctl00_ContentPlaceHolder1_btnNextIRDA').click();
								}
								document.getElementById('ctl00_ContentPlaceHolder1_LinkButton3').setAttribute('style', 'text-align: center;display: block;padding-top: 2px;margin-left: -22px;');

								document.getElementById('ctl00_ContentPlaceHolder1_LinkButton3').style.display = 'block';
								if (l["status"] != "Candidate registered with another General insurance company.") {
									document.getElementById('ctl00_ContentPlaceHolder1_btnNextIRDA').setAttribute('style', 'margin-top: -4px;display: block;text-align: right;padding: 6px;')
									document.getElementById('ctl00_ContentPlaceHolder1_btnNextIRDA').style.display = 'block';
								}

							}
							else {
								setTimeout(RefSts(Panno, Sid, UserId), 15000);
							}

						}
						//else if (j["status"] == "Invalid PAN") {
						//    debugger;
						//    document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIRDA').style.display = 'none';

						//    document.getElementById('divCmpnyNme').style.display = 'block';
						//    document.getElementById('divcaptchaimgIRDA').style.display = 'none';
						//    document.getElementById('divCaptchatxtIRDA').style.display = 'none';
						//    document.getElementById('divPAN').style.display = 'inherit';
						//    document.getElementById('divShowResultIRDA').style.display = 'block';
						//    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = userGuid;
						//    var Message = j["Result"];
						//    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
						//    document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIRDA").innerText = Message;

						//}
						//else if (j["status"] == "No Records Found") {
						//    debugger;
						//    document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIRDA').style.display = 'none';

						//    document.getElementById('divCmpnyNme').style.display = 'block';
						//    document.getElementById('divcaptchaimgIRDA').style.display = 'none';
						//    document.getElementById('divCaptchatxtIRDA').style.display = 'none';
						//    document.getElementById('divPAN').style.display = 'inherit';
						//    document.getElementById('divShowResultIRDA').style.display = 'block';
						//    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = userGuid;
						//    var Message = j["Result"];
						//    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
						//    document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIRDA").innerText = Message;

						//}
						else {
							setTimeout(RefSts(Panno, Sid, UserId), 15000);
						}
						//return userGuid;sss
					}
						else {
							setTimeout(RefSts(Panno, Sid, UserId), 15000);
						}
                },
                failure: function (response) {
                    alert("Something went wrong.");
                }
            });
        }
        function imageExists(image_url) {

            var http = new XMLHttpRequest();

            http.open('HEAD', image_url, false);
            http.send();

            return http.status != 404;
        }
      /*  For IIb*/
        function RefStsIIB(Panno, Sid, UserId) {
			debugger;
            var obj = {}
            var object = {}
            var dataObj = [];
            //var ActNo = getQueryVal('uid', window.location);
            object["panno"] = Panno;
            object["sid"] = Sid;
            object["UserId"] = UserId;
            RefSts(Panno, Sid, UserId);

            dataObj.push(object);
            sendObj = {
                data: (dataObj)
            }
            //console.info(performance.navigation.type);
            //if (performance.navigation.type == performance.navigation.TYPE_RELOAD) {
            //    //alert("This page is reloaded");
            //    window.open("../../../index.aspx", "_self");
            //}

            //$.ajax({
            return $.ajax({
                type: "POST",
                url: "Integration.aspx/CheckPanStsIIB",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (_data) {
                    debugger;

                    

                    var j = JSON.parse(_data.d);
                    
                    
                   // if (j["status"] == "PAN Number based search initiated" || j["status"] == "PAN Number based search in progress")
                        if (j["Data"] == "4" || j["Data"] == "5")
                    {
                        debugger;
                        // setTimeout("location.reload(true);", 1000);
                        document.getElementById('divCmpnyNme').style.display = 'block';
                        document.getElementById('divcaptchaimgIIB').style.display = 'block';
                      
                        document.getElementById('CaptchaImgIIB').setAttribute('src', "data:image/png;base64," + j["image"]);
                      
                        document.getElementById('divCaptchatxtIIB').style.display = 'inherit';
                        document.getElementById('divPAN').style.display = 'none';

                        document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIIB').style.display = 'none';
                        console.log("ok");
                    }

                    else {
                       
                        document.getElementById('divCmpnyNme').style.display = 'none';
                        document.getElementById('divPAN').style.display = 'none';
                        document.getElementById('divcaptchaimgIIB').style.display = 'none';
                        document.getElementById('divCaptchatxtIIB').style.display = 'none';
                        document.getElementById('divShowResultIIB').style.display = 'none';
                    }
                    //if (j["status"] == "Matching Record Found in Database" || j["status"] == "No Data Found in POS System")
                    if (j["Data"] == "6" || j["Data"] == "7")
                    //if (userGuid != "")
                    {
                        
					    myTimeout = setTimeout(RefStsIIB(Panno, Sid, UserId), 15000);
						clearTimeout(myTimeout);
                        document.getElementById('divCmpnyNme').style.display = 'block';
                        document.getElementById('divcaptchaimgIIB').style.display = 'none';
                        document.getElementById('divCaptchatxtIIB').style.display = 'none';
                        document.getElementById('divPAN').style.display = 'inherit';
                        document.getElementById('divShowResultIIB').style.display = 'block';
                       document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIIB').style.display = 'none';
                        var Message = j["Result"];
                       
                        //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
                        document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIIB").innerText = Message;

                        if (document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIIB").innerText != null) {
                            document.getElementById('ctl00_ContentPlaceHolder1_LinkButton2').setAttribute('style', 'text-align: center;display: block;padding-top: 2px;margin-left: -22px;');

                            document.getElementById('ctl00_ContentPlaceHolder1_LinkButton2').style.display = 'block';
                            document.getElementById('ctl00_ContentPlaceHolder1_btnNextIIB').setAttribute('style', 'margin-top: -4px;display: block;text-align: right;padding: 6px;')
                            document.getElementById('ctl00_ContentPlaceHolder1_btnNextIIB').style.display = 'block';

                        }
                        
                    }
                    //else if (j["status"] == "Invalid PAN") {
                    //    debugger;
                    //    document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIIB').style.display = 'none';

                    //    document.getElementById('divCmpnyNme').style.display = 'block';
                    //    document.getElementById('divcaptchaimgIIB').style.display = 'none';
                    //    document.getElementById('divCaptchatxtIIB').style.display = 'none';
                    //    document.getElementById('divPAN').style.display = 'inherit';
                    //    document.getElementById('divShowResultIIB').style.display = 'block';
                    //    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = userGuid;
                    //    var Message = j["Result"];
                    //    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
                    //    document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIIB").innerText = Message;

                    //}
                    else {
                        setTimeout(RefStsIIB(Panno, Sid, UserId), 15000);
                    }
                    //return userGuid;sss
                },
                failure: function (response) {
                    alert("Something went wrong.");
                }
            });
            //return userGuid;
        }
        /*end for iib*/

        //for irda
        function RefStsIRDA(Panno, Sid, UserId) {
            debugger;
            var obj = {}
            var object = {}
            var dataObj = [];
            //var ActNo = getQueryVal('uid', window.location);
            object["panno"] = Panno;
            object["sid"] = Sid;
            object["UserId"] = UserId;
            RefSts(Panno, Sid, UserId);
            RefStsIIB(Panno, Sid, UserId);

            dataObj.push(object);
            sendObj = {
                data: (dataObj)
            }
            //console.info(performance.navigation.type);
            //if (performance.navigation.type == performance.navigation.TYPE_RELOAD) {
            //    //alert("This page is reloaded");
            //    window.open("../../../index.aspx", "_self");
            //}

            //$.ajax({
            return $.ajax({
                type: "POST",
                url: "Integration.aspx/CheckPanStsIRDA",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (_data) {
                    debugger;



                    var j = JSON.parse(_data.d);


                    //if (j["status"] == "PAN Number based search initiated" || j["status"] == "PAN Number based search in progress")
                        if (j["Data"] == "4" || j["Data"] == "5")
                    {
                        debugger;
                        // setTimeout("location.reload(true);", 1000);
                        document.getElementById('divCmpnyNme').style.display = 'block';
                        document.getElementById('divcaptchaimgIRDA').style.display = 'block';

                        document.getElementById('CaptchaImgIRDA').setAttribute('src', "data:image/png;base64," + j["image"]);

                        document.getElementById('divCaptchatxtIRDA').style.display = 'inherit';
                        document.getElementById('divPAN').style.display = 'none';

                        document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIRDA').style.display = 'none';
                        console.log("ok");
                    }

                    else {

                        document.getElementById('divCmpnyNme').style.display = 'none';
                        document.getElementById('divPAN').style.display = 'none';
                        document.getElementById('divcaptchaimgIRDA').style.display = 'none';
                        document.getElementById('divCaptchatxtIRDA').style.display = 'none';
                        document.getElementById('divShowResultIRDA').style.display = 'none';
                    }
                    //if (j["status"] == "Matching Record Found in Database" || j["status"] == "No Data Found in POS System")
                        if (j["Data"] == "6" || j["Data"] == "7")
                    //if (userGuid != "")
                    {
                        
					    myTimeout = setTimeout(RefStsIRDA(Panno, Sid, UserId), 15000);
						clearTimeout(myTimeout);
                        document.getElementById('divCmpnyNme').style.display = 'block';
                        document.getElementById('divcaptchaimgIRDA').style.display = 'none';
                        document.getElementById('divCaptchatxtIRDA').style.display = 'none';
                        document.getElementById('divPAN').style.display = 'inherit';
                        document.getElementById('divShowResultIRDA').style.display = 'block';
						document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIRDA').style.display = 'none';

                        var Message = j["Result"];
                        //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
                            document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIRDA").innerText = Message;
                            if (document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIRDA").innerText != null)
                            {
                                document.getElementById('ctl00_ContentPlaceHolder1_LinkButton3').setAttribute('style', 'text-align: center;display: block;padding-top: 2px;margin-left: -22px;');

                                document.getElementById('ctl00_ContentPlaceHolder1_LinkButton3').style.display = 'block';
                                document.getElementById('ctl00_ContentPlaceHolder1_btnNextIRDA').setAttribute('style', 'margin-top: -4px;display: block;text-align: right;padding: 6px;')
                                document.getElementById('ctl00_ContentPlaceHolder1_btnNextIRDA').style.display = 'block';

                            }
                        
                    }
                    //else if (j["status"] == "Invalid PAN") {
                    //    debugger;
                    //    document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIRDA').style.display = 'none';

                    //    document.getElementById('divCmpnyNme').style.display = 'block';
                    //    document.getElementById('divcaptchaimgIRDA').style.display = 'none';
                    //    document.getElementById('divCaptchatxtIRDA').style.display = 'none';
                    //    document.getElementById('divPAN').style.display = 'inherit';
                    //    document.getElementById('divShowResultIRDA').style.display = 'block';
                    //    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = userGuid;
                    //    var Message = j["Result"];
                    //    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
                    //    document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIRDA").innerText = Message;

                    //}
                    //else if (j["status"] == "No Records Found") {
                    //    debugger;
                    //    document.getElementById('ctl00_ContentPlaceHolder1_divLoaderIRDA').style.display = 'none';

                    //    document.getElementById('divCmpnyNme').style.display = 'block';
                    //    document.getElementById('divcaptchaimgIRDA').style.display = 'none';
                    //    document.getElementById('divCaptchatxtIRDA').style.display = 'none';
                    //    document.getElementById('divPAN').style.display = 'inherit';
                    //    document.getElementById('divShowResultIRDA').style.display = 'block';
                    //    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = userGuid;
                    //    var Message = j["Result"];
                    //    //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
                    //    document.getElementById("ctl00_ContentPlaceHolder1_ShowResultIRDA").innerText = Message;

                    //}
                    else {
                            setTimeout(RefStsIRDA(Panno, Sid, UserId), 15000);
                    }
                    //return userGuid;sss
                },
                failure: function (response) {
                    alert("Something went wrong.");
                }
            });
            //return userGuid;
        }
       /* end for irda*/
    </script>
	<style>
     .ww {
  word-wrap: break-word;
}
		@media screen and (max-width: 720px) {
			/*#div2{
				width:80% !important;
			}*/
            #divPannel1{
                margin-left:16px !important;
            }
            #ImgCmpnyNme{
                width:50vw !important;
                padding-left:0px!important;
            }
			#divPAN{
				/*padding-left:49px !important;**/
                padding-left:15vw !important;
				padding-top:10px !important;
                padding-right:15vw !important;
			}
			#divPAN1{
				width:77vw !important;
                height:35.9px !important
			}
            input[type="text"] {
                padding-top:15px;
            }
			#txtpan{
				width:215px !important;
			}
			/*#divPAN2{
				width:14px !important;
			}*/
			#divCaptchatxt{
				/*padding-left:25px !important;*/
                padding-left:18vw !important;
			}
			#divCaptchatxt1{
				width:219px !important;
			}
			#txtCaptcha{
                width:215px !important;
				/*padding-left:215px !important;*/
			}
			#divCaptchatxt2{
				width:29px !important;
			}
            #img1{
				width:29vw !important;
			}
		}
	</style>
    <%--ended by sanoj for NSDL--%>

    <style>
        textarea:focus, input:focus{
    outline: solid 1px #ccdcee !important;

}
       /*//added by ajay for ckyc start*/
       input[type="text"]:focus{
    border:1px solid white !important;
}
       .formcontrol {
    border-radius: 7px !important;
    height: 34px !important;
    display: block;
    width: 100%;
    padding: 0.375rem 0.75rem;
    font-size: 1rem;
    font-weight: 400;
    line-height: 1.5;
    color: #212529;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid #ced4da;
    -webkit-appearance: none;
    -moz-appearance: none;
    appearance: none;
    border-radius: 0.25rem;
    transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
    }
       div.ui-datepicker{
 font-size:10px;
 left: 890.859px !important;
}
       /*//added by ajay for ckyc end*/
        .glyphicon{
            color:white;
        }
        p{
            text-align:justify;
            text-justify:inter-word;
        }
    </style>


    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
        <div class="panel panel-success PanelInsideTab" style="margin-top: 0px;">
                       <div class="row">
                         <div class="col-sm-10" style="padding-left:30px">                   
                             <asp:Label ID="Label37" Text="Automated PAN based verification" runat="server" CssClass="control-label HeaderColor" />                           
                         </div>                 
                       </div>
                       <div class="row rowspacing" style="padding-left:30px;margin-left: 125px;">

                           <div class="row" id="divNSDL" style="width: 18%; height: 228px; float: left; background-color: #fcfcfc; margin: 15px; border: solid 1px #ccdcee; padding: 10px">
                            <div class="dvHeader">
                                 <div class="row">
                                     <asp:Label ID="lblNsdl1" runat="server" style="text-align: center;font-size: 10px;margin-bottom: 4px;" Text="NSDL PAN check"></asp:Label>
                                 </div>
                                 <asp:UpdatePanel ID="UpdatePanel2" runat="server" style="text-align: center;">
                                    <ContentTemplate>
                                        <img src="../../../image/NsdlClor.jpg" class="auto-style3" style="margin-left: -4px;width: 122px;height: 101px;"/><br />
                                       
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                 <div id="divloader" runat="server" style="display:none;text-align:center">
                               <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
									 <br />
							   <asp:Label ID="Label3" runat="server" style="text-align: center;font-size: 10px;margin-bottom: 4px;" Text="Successfully connected to server"></asp:Label>
                                        </div>

                                <%--added by sanoj for captcha--%>
                               
		            <div class="row rowspacing" id="divcaptchaimg" style="display:none"> <%--style="display:none"--%>
						<div class="col-sm-12" style="text-align: center;">
							<%--<img id="CaptchaImg" src=""/><br />--%> 
							<img id="CaptchaImg" style="width:89px"; src="../../../ExternalImages/Screenshot.png"/><br /> 
						</div>
					</div>
                                <%--<img src="../../../images/CollapsAndExpandSMall2.png" />--%>
                    
                                 <div class="row rowspacing" runat="server" id="divCaptchatxt" > <%-- style="display:none"--%>
					<%--<div class="row rowspacing" id="divCaptchatxt" style="display:inherit">--%>
                       
<%--					<div class="row rowspacing" id="divCaptchatxt" style="display:none;padding-left:404px;">--%>
<div id="divMobno" runat="server" class="col-sm-12" style="margin-left: 11px;display:flex">
    <asp:TextBox ID="txtmobno" CssClass="form-control"  style="font-size: 11px;height: 25px !important;width: 59% !important;" placeholder="Mobile No." runat="server"></asp:TextBox> &nbsp;
    <asp:LinkButton ID="btnotp" runat="server" BorderColor="White" OnClick="btnotp_Click" CssClass="btn btn-clear" style="padding: 0px;width: 28px;height: 24px;border-color:  #ced4da !important;"> 
                             <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon" style="color:#00cccc;font-size:16px;width:18px;height:20px"> </span></asp:LinkButton>
</div>
                                     <br />
						<div id="divCaptchatxt1" runat="server" class="col-sm-12" style="margin-left: 11px;display:flex;display:none">
                            
							<asp:TextBox ID="txtCaptcha" MaxLength="6" CssClass="form-control" style="font-size: 11px;height: 25px !important;width: 59% !important;" placeholder="Enter OTP" runat="server"></asp:TextBox> &nbsp;
                              <asp:LinkButton ID="BtnSubmitCaptcha" runat="server" BorderColor="White" OnClick="BtnSubmitCaptcha_Click" CssClass="btn btn-clear" style="padding: 0px;width: 28px;height: 24px;border-color:  #ced4da !important;"> 
                             <span class="glyphicon glyphicon-ok" style="color:#00cccc;font-size:16px;width:18px;height:20px"> </span>
                          </asp:LinkButton> 
						</div>
						<div id="divCaptchatxt2" class="col-sm-1" style="text-align: left">
                        
<%--                          <asp:LinkButton ID="BtnClear" runat="server" BorderColor="White" CssClass="btn btn-clear" style="float:none" OnClick="BtnClear_Click">
                              <span class="glyphicon glyphicon-remove" style="color:#00cccc"></span>
                          </asp:LinkButton> --%>
						</div>
                        <div class="col-sm-3" style="text-align: center">
                            </div>
					</div>
                                  <%--endded by sanoj for captcha--%>
					
                            </div>
                            <br />
                            <div style="text-align: center;display:none">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label4" runat="server" Text="Verification Link" Style="font-size: 14px;text-align:center" CssClass="control-label" />
                                        <br />
                                        <a href="https://www.itrex.in/USN/SelfDeactivatePAN.aspx">Click here</a>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div style="text-align: center;margin-top:33px;">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnPrcd" Enabled="false" Visible="false" runat="server" CssClass="btn btn-success">
                                            PROCEED <span class="glyphicon glyphicon-arrow-right"> </span>
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                           
                        </div>
                          
                           <div class="row" id="divIIB1" style="width: 18%; height: 228px; float: left; background-color: #fcfcfc; margin: 15px; border: solid 1px #ccdcee; padding: 10px">
                            <div class="dvHeader">
                                 <div class="row">
                                     <asp:Label ID="lblIib1" runat="server" style="text-align: center;font-size: 10px;margin-bottom: 4px;" Text="IIB PAN check"></asp:Label>
                                 </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="text-align: center;">
                                    <ContentTemplate>
                                        <img id="ImgIIB" runat="server" src="../../../image/IibBlack.jpg" class="auto-style7" style="margin-left: -4px;width: 122px;height: 101px;" /><br />
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div id="divLoaderIIB" runat="server" style="display:none;text-align:center">
                               <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" />
									<br />
							  <asp:Label ID="Label5" runat="server" style="text-align: center;font-size: 10px;margin-bottom: 4px;" Text="Successfully connected to server"></asp:Label>
                                        </div>

                                 <div class="row rowspacing" id="divcaptchaimgIIB" style="display:none">
						<div class="col-sm-12" style="text-align: center">
							<%--<img id="CaptchaImg" src=""/><br />--%> 
							<img id="CaptchaImgIIB" style="width:89px"; src="../../../ExternalImages/Screenshot.png"/><br /> 
						</div>
					</div>
                    
                                 <div class="row rowspacing" id="divCaptchatxtIIB" style="display:none">
					<%--<div class="row rowspacing" id="divCaptchatxt" style="display:inherit">--%>
                       
<%--					<div class="row rowspacing" id="divCaptchatxt" style="display:none;padding-left:404px;">--%>
						<div id="divCaptchatxt1IIB" class="col-sm-12" style="margin-left:14px;display:flex">
							<asp:TextBox ID="txtIIB" CssClass="form-control" style="font-size: 11px;width:59%;height:25px !important" placeholder="Captcha" runat="server"></asp:TextBox> &nbsp;
                              <asp:LinkButton ID="BtnSubmitCaptchaIIB" runat="server" BorderColor="White" OnClick="BtnSubmitCaptchaIIB_Click" CssClass="btn btn-clear" style="padding: 0px;width: 28px;height: 24px;">
                             <span class="glyphicon glyphicon-ok" style="color:#00cccc"> </span>
                          </asp:LinkButton> 
						</div>
						<div id="divCaptchatxt2IIB" class="col-sm-1" style="text-align: left">
                        
<%--                          <asp:LinkButton ID="BtnClear" runat="server" BorderColor="White" CssClass="btn btn-clear" style="float:none" OnClick="BtnClear_Click">
                              <span class="glyphicon glyphicon-remove" style="color:#00cccc"></span>
                          </asp:LinkButton> --%>
						</div>
                        <div class="col-sm-3" style="text-align: center">
                            </div>
					</div>

                            </div>
                            <br />
                            <br />
                            <br />
                            <div style="text-align: center">
                                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label1" runat="server" Visible="false" Text="Verification Link" Style="font-size: 14px;text-align:center" CssClass="control-label" />
                                        <br />
                                        <asp:LinkButton ID="lnkbtnIIB" runat="server" Visible="false" OnClick="lnkbtnIIB_Click" Text="Click here">
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <br />
                            <div style="text-align: center;margin-top:1px">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="ChkBxIIB" runat="server" Visible="false" Text="VERIFY" Font-Bold="true" Enabled="false"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                           <div class="row" id="divIRDAI" style="width: 18%; height: 228px; float: left; background-color: #fcfcfc; margin: 15px; border: solid 1px #ccdcee; padding: 10px">
                            <div class="dvHeader">
                                 <div class="row">
                                     <asp:Label ID="lblIrdai1" runat="server" style="text-align: center;font-size: 10px;margin-bottom: 4px;" Text="IRDAI PAN check"></asp:Label>
                                 </div>
                                <asp:UpdatePanel ID="UpdatePanel33" runat="server" style="text-align: center;">
                                    <ContentTemplate>
                                        <img id="ImgIRDA" runat="server"  src="../../../image/IrdaiBlack.jpg" class="auto-style5" style="margin-left: -4px;width: 122px;height: 101px;" /><br />
                                    
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div id="divLoaderIRDA" runat="server" style="display:none;text-align:center">
                               <img id="Img3" alt="" src="~/images/spinner.gif" runat="server" />
									<br />
							   <asp:Label ID="Label6" runat="server" style="text-align: center;font-size: 10px;margin-bottom: 4px;" Text="Successfully connected to server"></asp:Label>
                                        </div>
                                 <div class="row rowspacing" id="divcaptchaimgIRDA"  style="display:none;">
						<div class="col-sm-12" style="text-align: center">
							<%--<img id="CaptchaImg" src=""/><br />--%> 
							<img id="CaptchaImgIRDA" style="width:89px"; src="../../../ExternalImages/Screenshot.png"/><br /> 
						</div>
					</div>
                    
                                 <div class="row rowspacing" id="divCaptchatxtIRDA" style="display:none"><%----%>
					<%--<div class="row rowspacing" id="divCaptchatxt" style="display:inherit">--%>
                       
<%--					<div class="row rowspacing" id="divCaptchatxt" style="display:none;padding-left:404px;">--%>
						<div id="divCaptchatxt1IRDA" class="col-sm-12" style="display: flex; margin-left: 11px;display:flex;">
							<asp:TextBox ID="txtIRDA" CssClass="form-control" style="font-size: 11px; height: 25px !important; width: 59% !important;" placeholder="Enter the Captcha" runat="server"></asp:TextBox> &nbsp;
                              <asp:LinkButton ID="BtnSubmitCaptchaIRDA" runat="server" OnClick="BtnSubmitCaptchaIRDA_Click" CssClass="btn btn-clear" style="padding: 0px; width: 28px; height: 24px; border-color: #ced4da !important;">
                             <span class="glyphicon glyphicon-ok" style="color:#00cccc"> </span>
                          </asp:LinkButton> 
						</div>
						<div id="divCaptchatxt2IRDA" class="col-sm-1" style="text-align: left">
                        
<%--                          <asp:LinkButton ID="BtnClear" runat="server" BorderColor="White" CssClass="btn btn-clear" style="float:none" OnClick="BtnClear_Click">
                              <span class="glyphicon glyphicon-remove" style="color:#00cccc"></span>
                          </asp:LinkButton> --%>
						</div>
                        <div class="col-sm-3" style="text-align: center">
                            </div>
					</div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div style="text-align: center">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label2" runat="server" Visible="false" Text="Verification Link" Style="font-size: 14px;text-align:center" CssClass="control-label" />
                                        <br />
                                        <asp:LinkButton ID="lnkbtnIRDA" runat="server" Visible="false" OnClick="lnkbtnIRDA_Click" Text="Click here">
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <div style="text-align: center">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="ChkBxIRDA" Visible="false" runat="server" Text="VERIFY" Font-Bold="true" Enabled="false"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                       
                           <div class="row" id="divCERSAI" style="width: 18%; height: 228px; float: left; background-color: #fcfcfc; margin: 15px; border: solid 1px #ccdcee; padding: 10px">
                            <div class="auto-style4">
                                 <div class="row">
                                     <asp:Label ID="lblCersai1" runat="server" style="text-align: center;font-size: 10px;margin-bottom: 4px;" Text="CKYC search"></asp:Label>
                                 </div>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" style="text-align: center;">
                                    <ContentTemplate>
                                        <img id="ImgCERSAI" runat="server" src="../../../image/CersaiBlack.jpg" class="auto-style6" style="margin-left: -4px;width: 122px;height: 101px;"/><br />
                                       
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div id="divLoaderCERSAI" runat="server" style="display:none;text-align:center">
                               <img id="Img4" alt="" src="~/images/spinner.gif" runat="server" />
                                        </div>
                            </div>
                            <%--<br />
                            <div style="text-align: center;display:none">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label3" runat="server" Text="Verification Link" Style="font-size: 14px;text-align:center" CssClass="control-label" />
                                        <br />
                                        <a href="https://www.itrex.in/USN/SelfDeactivatePAN.aspx">Click here</a>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <br />
                            <br />--%>
                           <%-- <div style="text-align: center;margin-top:39px;">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnPrcd1" Enabled="false" Visible="false" runat="server" CssClass="btn btn-success">
                                            PROCEED <span class="glyphicon glyphicon-arrow-right"> </span>
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>--%>

                                <div style="text-align: center;">
                                 
                                <div class="col-sm-12" style="text-align: center;display:flex">
                                         <asp:TextBox CssClass="formcontrol" onmousedown="Datedob();" Visible="false" style="font-size: 12px; margin-left:13px;height:28px !important;" placeholder="dd/mm/yyyy" Width="100px" tabindex="-1" 
                                runat="server" ID="txtDOB" MaxLength="14" ReadOnly="false" 
                                />&nbsp;&nbsp;
                                        
                                    </div>
                            </div>
                        </div>
                    </div>

                           <%--  added by for message--%>
                            <div class="row rowspacing" style="padding-left:30px;margin-left: 125px;">
                       <div class="row" id="divNSDLLable" style="width: 18%;height: 90px;margin-top: -31px;float: left;background-color: #FCFCEB;border: solid 1px #ccdcee;margin-left: 15px;">
                          <div class="col-sm-2" style="text-align: center;margin-top: 19px;display:none;">
                               <asp:LinkButton ID="LinkButton1" runat="server" BorderColor="White" style="text-align: center;display:none; padding-top: 18px;padding-left: -10px;margin-left: -22px;">
                                 <span class="glyphicon glyphicon-arrow-left" style="color:#00cccc"> </span>
                                </asp:LinkButton>
                            </div>
                           <div id="divShowResult" class="col-sm-10" style="text-align: center;display:flex;line-height: 12px;padding:15px" >
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server" style="text-align: center;">
                                    <ContentTemplate>
                        <p>  <asp:Label ID="ShowResult" runat="server" style="color:Green;font-size: 10px;" Text=""></asp:Label><br /></p>
                              </ContentTemplate></asp:UpdatePanel>
						</div>
                                
                           <div class="col-sm-2" style="text-align: right;margin-top: 29px;">
                               <asp:LinkButton ID="btnNsdl" runat="server" BorderColor="White" OnClick="btnNsdl_Click"  style="margin-top: 2px;display:none;text-align: right;padding: 6px;">
                                 <span class="glyphicon glyphicon-arrow-right" style="color:#00cccc"> </span>
                                </asp:LinkButton> 

                            </div>
                           </div>
                       <div class="row" id="divIIBLabel" style="width: 18%;height: 90px;margin-top: -31px;float: left;background-color: #FCFCEB;border: solid 1px #ccdcee;margin-left: 42px;">
                              
                            <div class="col-sm-2" style="text-align: center;margin-top: 29px;">
                               <asp:LinkButton ID="LinkButton2" runat="server" BorderColor="White" style="text-align: center;display:none;padding-top: 18px;padding-left: -10px;margin-left: -22px;">
                                 <span class="glyphicon glyphicon-arrow-left" style="color:#00cccc"> </span>
                                </asp:LinkButton>
                            </div>
                           <div id="divShowResultIIB" class="col-sm-8 ww" style="text-align: center;display:flex;line-height: 12px;">
                           <p style="padding-top:23px"> <asp:Label ID="ShowResultIIB" runat="server" style="color:Green;font-size: 10px;" Text=""></asp:Label><br /></p>
                              
						</div>
                                
                           <div class="col-sm-2" style="text-align: right;margin-top: 29px;">
                               <asp:LinkButton ID="btnNextIIB" runat="server" BorderColor="White" OnClick="btnNextIIB_Click" style="margin-top: 2px;display:none;text-align: right;padding: 6px;">
                                 <span class="glyphicon glyphicon-arrow-right" style="color:#00cccc"> </span>
                                </asp:LinkButton> 
                            </div>
                              <%--<div id="divShowResultIIB" class="col-sm-12" style="text-align: center;display:flex">
                            <asp:Label ID="ShowResultIIB" runat="server" style="color:Green;font-size: 10px;" Text=""></asp:Label><br />
                              <asp:LinkButton ID="btnNextIIB" runat="server" BorderColor="White" OnClick="btnNextIIB_Click" CssClass="btn btn-clear" style="padding: 5px;width: 41px;height: 34px;">
                             <span class="glyphicon glyphicon-arrow-right" style="color:#00cccc"> </span>
                          </asp:LinkButton> 
						</div>--%>
                           </div>
                       <div class="row" id="divIRDA" style="width: 18%;height: 90px;margin-top: -31px;float: left;background-color: #FCFCEB;border: solid 1px #ccdcee;margin-left: 42px;">
                             <%--   <div id="divShowResultIRDA" class="col-sm-12" style="text-align: center;display:flex">
                            <asp:Label ID="ShowResultIRDA" runat="server" style="color:Green;font-size: 10px;" Text=""></asp:Label><br />
                              <asp:LinkButton ID="btnNextIRDA" runat="server" BorderColor="White" OnClick="btnNextIRDA_Click" CssClass="btn btn-clear" style="padding: 5px;width: 41px;height: 34px;">
                             <span class="glyphicon glyphicon-arrow-right" style="color:#00cccc"> </span>
                          </asp:LinkButton> 
						</div>--%>
                            <div class="col-sm-2" style="text-align: center;margin-top: 29px;">
                               <asp:LinkButton ID="LinkButton3" runat="server" BorderColor="White" style="display:none;text-align: center;padding-top: 18px;padding-left: -10px;margin-left: -22px;">
                                 <span class="glyphicon glyphicon-arrow-left" style="color:#00cccc"> </span>
                                </asp:LinkButton>
                            </div>
                           <div id="divShowResultIRDA" class="col-sm-8" style="text-align: center; display: flex; line-height: 12px; padding: 15px;padding-top:21px">
                          <p> <asp:Label ID="ShowResultIRDA" runat="server" style="color:Green;font-size: 10px;" Text=""></asp:Label><br /></p> 
						</div>
                                
                           <div class="col-sm-2" style="text-align: right;margin-top: 29px;">
                               <asp:LinkButton ID="btnNextIRDA" runat="server" BorderColor="White" OnClientClick="openLoader();" OnClick="btnNextIRDA_Click" style="margin-top: 2px;text-align: right;padding: 6px;display:none;">
                                 <span class="glyphicon glyphicon-arrow-right" style="color:#00cccc;"> </span>
                                </asp:LinkButton> 
                            </div>
                           </div>
                       <div class="row" id="divCKYC" style="width: 18%;height: 90px;margin-top: -31px;float: left;background-color: #FCFCEB;border: solid 1px #ccdcee;margin-left: 42px;text-align:center;display:flex">
                                <%--<asp:Label id="ptxt" runat="server"  Text="CKYC record found.Please enter DOB.<br />" style="text-align:center;font-size:9px;color:green;width:90%; margin-top:10px" Visible="false"></asp:Label>
                                       
                           <asp:LinkButton ID="btnPrcd1" runat="server"  BorderColor="White" OnClick="btnPrcd1_Click" style="margin-top: 8px;border-color: white;width: 14px;height: 28px;padding: 0px;color: grey !important;" Visible="false">
                                             <span class="glyphicon glyphicon-arrow-right" style="color:#00cccc;font-size:12px"> </span>
                                        </asp:LinkButton>--%>

                            <div class="col-sm-2" style="text-align: center;margin-top: 33px;">
                               <asp:LinkButton ID="LinkButton4" Visible="false" runat="server" BorderColor="White" style="text-align: center;padding-top: 18px;padding-left: -10px;margin-left: -22px;">
                                 <span class="glyphicon glyphicon-arrow-left" style="color:#00cccc"> </span>
                                </asp:LinkButton>
                            </div>
                           <div  class="col-sm-8" style="text-align: center;display:flex;line-height: 12px;padding-top:24px">
                          <p> <asp:Label ID="ptxt" runat="server" Text="CKYC record found.Please enter DOB.<br />"  style="text-align:center;font-size:10px;color:green;width:90%; margin-top:10px" Visible="false" ></asp:Label><br /></p> 
						</div>
                                
                           <div class="col-sm-2" style="text-align: right;margin-top: 33px;">
                               <asp:LinkButton ID="btnPrcd1" Visible="false" runat="server" BorderColor="White" OnClick="btnPrcd1_Click" style="margin-top: 2px;text-align: right;padding: 6px;">
                                 <span class="glyphicon glyphicon-arrow-right" style="color:#00cccc"> </span>
                                </asp:LinkButton> 
                            </div>
                           </div>
                 </div>
                             <%--  ended by for message--%>

                        <br />
                        <div class="row">
                            <div class="col-sm-1">
                                </div>
                             <div class="col-sm-5">
                                   <asp:LinkButton ID="btnPrevHome" runat="server" Text="PREVIOUS" CssClass="btn btn-success" OnClick="btnPrevHome_Click" style="margin-left:70px">
               <span class="glyphicon glyphicon-arrow-left BtnGlyphicon"> </span>  PREVIOUS 
           </asp:LinkButton>
                                 </div>
                            <div class="col-sm-3">
                                </div>
                            <div class="col-sm-3">  
                                
                                <asp:LinkButton ID="lnkPrcdWthInt" runat="server" OnClick="lnkPrcdWthInt_Click" CssClass="btn btn-clear" style="margin-left:-59px">
                                   CONTINUE
                                    <span class="glyphicon glyphicon-arrow-right" style="color:#00cccc" > </span>
                                </asp:LinkButton> 
                            </div>
                        </div>
                       <br /> 
                       <br /> 
                      
                       <div class="row" style="padding-left:30px;margin-left:118px">
                         <div class="col-sm-10" style="text-align: left">                   
                             <img src="../../../image/download_prev_ui.png" class="auto-style8" />
                             Please note: The PAN details of the candidate can be verified from the above regulatory databases to avoid any kind of verification or
                             identification issues later. The CKYC Registry database can also help to fetch the latest personal details of the candidate to speeden 
                             up the onboarding process.
                         </div>                 
                       </div>
            </div>

    <%--    added by sanoj for NSDL--%>
                    <div id="iLoading" runat="server" class="Content" style="position:absolute;top:50%;left:50%;margin:-50px 0px 0px -50px;z-index:9999;display:none">
            <img id="img1" src="../../../assets/img/loading-spinner-blue.gif" alt="LOADING" /> 
            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Loading...
        </div>
                    <div class="card" id="divPannel1" runat="server" style="width:100%;margin-left:0px;height:600px;display:none;">
					<%--<div class="card" id="divPannel1" runat="server" style="width:93%;margin-left:45px;height:600px">--%>
<%--                    <div id="div2" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRwd','Img3');return false;" style="width:96%;padding-top:10px">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                
                                <asp:Label ID="Label3" Text="PAN Search" CssClass="control-label HeaderColor" runat="server" />
                            </div>
                            <div class="col-sm-2">
                            </div>
                        </div>
                    </div>--%>
					<div class="row rowspacing" id="divCmpnyNme" style="padding-top:104px" >
						<div class="col-sm-12" style="text-align: center">
							<img id="ImgCmpnyNme" src="../../../image/KMIlogo.png" /><br /> 
						</div>
					</div>
					<%--<div class="row rowspacing" id="divPAN" style="display:inherit;padding-left:404px;padding-top:178px" >--%>
<%--					<div class="row rowspacing" id="divPAN" style="display:inherit;padding-left:404px;padding-top:20px" >
						<div id="divPAN1" class="col-sm-6" style="text-align: center">
						 <asp:TextBox ID="txtpan" CssClass="form-control" style="margin-bottom:5px;" placeholder="Enter PAN Number" runat="server" Font-Bold="False"></asp:TextBox>
						</div>
						<div class="col-sm-2" id="divPAN2" style="text-align: left">
                          <asp:LinkButton ID="btnVerifyPAN" runat="server" BorderColor="White" OnClick="btnVerifyPAN_Click" CssClass="btn btn-clear">
                             <span class="glyphicon glyphicon-search" style="color:#00cccc"> </span>
                          </asp:LinkButton> 
						</div>
					</div>--%>
					<div class="row rowspacing" id="divPAN" style="display:inherit;padding-top:30px" >
                        <div class="col-sm-3" style="text-align: center">
                            </div>
						<div id="divPAN1" class="col-sm-6" style="text-align: right;display:flex;border-bottom:1px solid;border-radius:7px;padding-left:0px;height:35.9px">
						 <asp:TextBox ID="txtpan" CssClass="form-control" style="margin-bottom:5px;border:0px" placeholder="Enter PAN Number" runat="server" Font-Bold="False"></asp:TextBox>
                          <asp:LinkButton ID="btnVerifyPAN" runat="server" BorderColor="White" OnClick="btnVerifyPAN_Click" CssClass="btn btn-clear">
                             <span class="glyphicon glyphicon-search" style="color:#00cccc"> </span>
                          </asp:LinkButton> 
						</div>
                        <div class="col-sm-3" style="text-align: center">
                            </div>
					</div>
					
				</div>


    <div class="modal fade" id="myModal" role="dialog" style="opacity:1.0">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content" style='width: 305px; height: 175px;margin-top:16pc'>
                <div id="divmdlbdy" class="modal-body" style="text-align: center">
                    <div class="row">
                        <div class="col-sm-12">
                              <asp:Label ID="Label7" Text="Do you want to skip integration process" runat="server"  Style="margin-left: 7px; color: black; font-size: 16px; margin-top: 20px;"></asp:Label>
                        </div>
                    </div>
                        <div class="row" >
                            <div class="col-sm-12" style="text-align:center;padding:38px">
 <button type="button" id="btnYes" class="btn btn-success" value="Yes" onclick="Conpopup('btnYes');">
                        <span  style="color: white" ></span>Yes
                    </button>
                    <button type="button" id="btnNo" value="No" class="btn btn-success" onclick="Conpopup('btnNo');">
                        <span  style="color: white" ></span>No
                    </button>
                        </div>
                        </div>
                   
                </div>
            </div>

        </div>
    </div>


       <asp:HiddenField ID="hdnCndCode" runat="server" />
       <asp:HiddenField ID="hdnPan" runat="server" />
       <asp:HiddenField ID="hdnPanValue" runat="server" />
       <asp:HiddenField ID="hdnUrn" runat="server" />
       <asp:HiddenField ID="hdnAgentBrokerCode" runat="server" />
       <asp:HiddenField ID="hdnEmpCode" runat="server" />
    <asp:HiddenField ID="hdnPopmsg" runat="server" />
    <%--    endded by sanoj for NSDL--%>
    <script>
        //function showbtn() {
        //    getid = document.getElementById("ctl00_ContentPlaceHolder1_BtnSubmitCaptcha");
        //    if (getid.length >= 6) {
        //    getid.style.setAttribute("style", "padding: 0px; width: 28px; height: 24px; border - color:  #ced4da !important");

        //    }
        //}
    </script>
</asp:Content>
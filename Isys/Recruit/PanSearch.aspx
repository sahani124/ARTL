<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PanSearch.aspx.cs" Inherits="Application_Isys_Recruit_PanSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    
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
    
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
    
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="IE=11" />
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
	<link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
   

        function ShowReqDtl(divName, btnName) {
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
                url: "PanSearch.aspx/CheckPanSts",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (_data) {
					debugger;         
					var j = JSON.parse(_data.d);
                    //var userGuid = _data.d;
                    //var path = "D:\\Sarthak\\PAN verification\\PAN verification\\Images\\" + Panno +".png";
                    //var path = "Images/Screenshot.png;
                    //var path = "Images/Screenshot.png?time=" + Date.now();
                    var path = "../../../ExternalImages/Screenshot.png?time=" + Date.now();
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
					if (j["status"] == "PAN Number based search initiated" || j["status"] == "PAN Number based search in progress") {
                        debugger;
                        // setTimeout("location.reload(true);", 1000);
						document.getElementById('divcaptchaimg').style.display = 'block';
						//document.getElementById('ctl00_ContentPlaceHolder1_popuphidden').style.display = 'block';
                        //document.getElementById('CaptchaImg').setAttribute('style', 'display:block');
                        while (true) {
                            var n = imageExists(path);
                            if (n == true) {
                                break;
                            }
                        }
                        //document.getElementById('ctl00_ContentPlaceHolder1_popuphidden').setAttribute('style', 'display:block');
                        document.getElementById('CaptchaImg').setAttribute('src', path);
                        //document.getElementById('ctl00_ContentPlaceHolder1_txtCaptcha').setAttribute('style', 'display:block');
                        //document.getElementById('ctl00_ContentPlaceHolder1_BtnSubmitCaptcha').setAttribute('style', 'display:block');
                        //document.getElementById('ctl00_ContentPlaceHolder1_BtnClear').setAttribute('style', 'display:block');
                        //setTimeout(RefSts(Panno, Sid), 15000);
                        //document.getElementById('divPAN').style.display = 'none';
						document.getElementById('divCaptchatxt').style.display = 'inherit';
						document.getElementById('divPAN').style.display = 'none';
                    }
                    else
                    {
                        //document.getElementById('ctl00_ContentPlaceHolder1_popuphidden').style.display = 'none';
      //                  document.getElementById('CaptchaImg').setAttribute('style', 'display:none');
      //                  document.getElementById('CaptchaImg').setAttribute('src', '');
      //                  document.getElementById('ctl00_ContentPlaceHolder1_txtCaptcha').setAttribute('style', 'display:none');
      //                  document.getElementById('ctl00_ContentPlaceHolder1_BtnSubmitCaptcha').setAttribute('style', 'display:none');
      //                  document.getElementById('ctl00_ContentPlaceHolder1_BtnClear').setAttribute('style', 'display:none');
						//document.getElementById('divPAN').style.display = 'block';
						document.getElementById('divcaptchaimg').style.display = 'none';
						document.getElementById('divCaptchatxt').style.display = 'none';
						document.getElementById('divPAN').style.display = 'inherit';
                    }
					if (j["status"] == "Matching Record Found in Database" || j["status"] == "No Data Found in POS System")
					//if (userGuid != "")
					{
						//alert(j["Data"]);
<%--                        window.parent.$find('<%=Request.QueryString["pnlRwdRulDemo"].ToString()%>').hide();--%>
                        //doCancel(userGuid);
                        //document.getElementById('ctl00_ContentPlaceHolder1_Data').innerHTML = userGuid;
                        //document.getElementById('lblhidden').style.display = 'block';
                        //document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = userGuid;
						//document.getElementById('divPAN').style.display = 'none';
						document.getElementById('divPAN').style.display = 'inherit';
						document.getElementById('divShowResult').style.display = 'block';
						//document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = userGuid;
						document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = j["Data"];
                        //if(userGuid == "Matching Record Found in Database"){
                        //    document.getElementById('pngright').style.display = 'block';
                        //}
                        //else if (userGuid == "No Data Found in POS System") {
                        //    document.getElementById('pngwrong').style.display = 'block';
                        //}
                    }
                    else {
                        setTimeout(RefSts(Panno,Sid), 15000);
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
    </script>
					<div class="card" id="divPannel1" runat="server" style="width:93%;margin-left:45px;height:600px">
                    <div id="div2" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRwd','Img3');return false;" style="width:96%;padding-top:10px">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                
                                <asp:Label ID="Label3" Text="PAN Search" CssClass="control-label HeaderColor" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <%-- <span id="Img3" class="glyphicon glyphicon-collapse-down" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>--%>
<%--                                  <span class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>&nbsp;--%>
                            </div>
                        </div>
                    </div>

					<%--<div class="row rowspacing" id="divPAN" style="display:inherit;padding-left:404px;padding-top:178px" >--%>
					<div class="row rowspacing" id="divPAN" style="display:inherit;padding-left:404px;padding-top:178px" >
						<div class="col-sm-6" style="text-align: center">
						 <asp:TextBox ID="txtpan" CssClass="form-control" style="margin-bottom:5px;" placeholder="Enter PAN Number" runat="server" Font-Bold="False"></asp:TextBox>
						</div>
						<div class="col-sm-2" style="text-align: left">
                          <asp:LinkButton ID="btnVerifyPAN" runat="server" BorderColor="White" OnClick="btnVerifyPAN_Click" CssClass="btn btn-clear">
                             <span class="glyphicon glyphicon-search" style="color:#00cccc"> </span>
                          </asp:LinkButton> 
						</div>
					</div>

<%--					<div class="row rowspacing" id="divcaptchaimg" style="display:block" >--%>
					<div class="row rowspacing" id="divcaptchaimg" style="display:none" >
						<div class="col-sm-12" style="text-align: center">
							<img id="CaptchaImg" src=""/><br /> 
						</div>
					</div>

<%--					<div class="row rowspacing" id="divCaptchatxt" style="display:inherit;padding-left:404px;">--%>
					<div class="row rowspacing" id="divCaptchatxt" style="display:none;padding-left:404px;">
						<div class="col-sm-6" style="text-align: center">
							<asp:TextBox ID="txtCaptcha" CssClass="form-control" placeholder="Please Enter the Captcha" runat="server"></asp:TextBox>
						</div>
						<div class="col-sm-3" style="text-align: left">
                          <asp:LinkButton ID="BtnSubmitCaptcha" runat="server" BorderColor="White" OnClick="BtnSubmitCaptcha_Click" CssClass="btn btn-clear">
                             <span class="glyphicon glyphicon-ok" style="color:#00cccc"> </span>
                          </asp:LinkButton> 
                          <asp:LinkButton ID="BtnClear" runat="server" BorderColor="White" CssClass="btn btn-clear" style="float:none" OnClick="BtnClear_Click">
                              <span class="glyphicon glyphicon-remove" style="color:#00cccc"></span>
                          </asp:LinkButton> 
						</div>
					</div>

<%--					<div class="row rowspacing" id="divShowResult"  style="display:block">--%>
					<div class="row rowspacing" id="divShowResult"  style="display:none">
					    <div class="col-sm-12" style="text-align:center">
                            <asp:Label ID="ShowResult" runat="server" Text="ANJX XXXARI"></asp:Label><br />
                        </div>
					</div>
				</div>

       <asp:HiddenField ID="hdnCndCode" runat="server" />
       <asp:HiddenField ID="hdnPan" runat="server" />
       <asp:HiddenField ID="hdnPanValue" runat="server" />
       <asp:HiddenField ID="hdnUrn" runat="server" />
       <asp:HiddenField ID="hdnAgentBrokerCode" runat="server" />
       <asp:HiddenField ID="hdnEmpCode" runat="server" />
       <%--<asp:HiddenField ID="hdnPanINT" runat="server" />--%>
</asp:Content>
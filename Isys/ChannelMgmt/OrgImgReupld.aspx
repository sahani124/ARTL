<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrgImgReupld.aspx.cs" Inherits="Application_Isys_ChannelMgmt_OrgImgReupld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <script src="../../../CropScript/js/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../CropScript/js/jquery.Jcrop.min.js" type="text/javascript"></script>
    <link href="../../../CropScript/jquery.Jcrop.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
			$(document).ready(function () {
            // Bind the change event of the FileUpload control
            $("#FileUpload1").change(function () {
                readURL(this);
            });

            // Function to display the selected image
            function readURL(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        // Set the source of the image
						$('#img3').attr('src', e.target.result);
						$('#<%= hdnImageData.ClientID %>').val(e.target.result);
                    }
                    // Read the file as a data URL
                    reader.readAsDataURL(input.files[0]);
                }
            }
        });
        var doccode;
        var arg03, Transfr;
        var ZinSize, ZoutSize;
        var MstWidth, MstHeight;
        var ImgWidth, ImgHeight, Size, flag;
        var counter;


        function zoomIn() {
            debugger;
            var max_height, max_width;

   //         var imageheight = $('#ctl00_contentplaceholder1_img3').height();
			//var imagewidth = $('#ctl00_contentplaceholder1_img3').width();
            var imageheight = $('#img3').height();
            var imagewidth = $('#img3').width();

            zinsize = imageheight * imagewidth / 1024;

            var size = zoutsize / 1024;
            if (zinsize <= size) {
    //            $('#ctl00_contentplaceholder1_img3').css({
    //                height: '+=' + imageheight * 0.1,
    //                width: '+=' + imagewidth * 0.1
				//});
                $('#img3').css({
                    height: '+=' + imageheight * 0.1,
                    width: '+=' + imagewidth * 0.1
                });
    //            $("#ctl00_contentplaceholder1_hdnht").val($('#ctl00_contentplaceholder1_img3').height());
				//$("#ctl00_contentplaceholder1_hdnwt").val($('#ctl00_contentplaceholder1_img3').width());
                $("#ctl00_contentplaceholder1_hdnht").val($('#img3').height());
                $("#ctl00_contentplaceholder1_hdnwt").val($('#img3').width());
                $('#ctl00_contentplaceholder1_btnsaveimage').attr("disabled", false);
            }
<%--			var imageElement = document.getElementById('img3');
			// Create a canvas element
			var canvas = document.createElement('canvas');

			// Set the canvas dimensions to match the image
			canvas.width = imageElement.width;
			canvas.height = imageElement.height;

			// Draw the image onto the canvas
			var context = canvas.getContext('2d');
			context.drawImage(imageElement, 0, 0, imageElement.width, imageElement.height);

			// Get the base64-encoded string from the canvas
			var base64String = canvas.toDataURL('image/jpeg'); // You can specify the desired image format
			$('#<%= hdnImageData.ClientID %>').val(base64String);--%>
        }

        function zoomOut() {
            debugger;

   //         var imageheight = $('#ctl00_contentplaceholder1_img3').height();
			//var imagewidth = $('#ctl00_contentplaceholder1_img3').width();
            var imageheight = $('#img3').height();
            var imagewidth = $('#img3').width();
            zinsize = imageheight * imagewidth / 1024;

			//var size = size;
			var size = 10;
            if (zinsize >= size) {
				//$('#ctl00_contentplaceholder1_img3').css({
				$('#img3').css({
                    height: '-=' + imageheight * 0.1,
                    width: '-=' + imagewidth * 0.1
                });
    //            $("#ctl00_contentplaceholder1_hdnht").val($('#ctl00_contentplaceholder1_img3').height());
				//$("#ctl00_contentplaceholder1_hdnwt").val($('#ctl00_contentplaceholder1_img3').width());
                $("#ctl00_contentplaceholder1_hdnht").val($('#img3').height());
                $("#ctl00_contentplaceholder1_hdnwt").val($('#img3').width());
                $('#ctl00_contentplaceholder1_btnsaveimage').attr("disabled", false);
            }

        }

        function rotateImage() {
            debugger;
            var options;
			//var box = $('#ctl00_contentplaceholder1_img3');
            var box = $('#img3');
            counter += 90;
            $('#ctl00_contentplaceholder1_hdnrotatevalue').val(counter);
            $('#ctl00_contentplaceholder1_btnsaveimage').attr("disabled", false);
            $('#img3').css('transform', 'rotate(' + counter + 'deg)')
			//$('#img3').css('margin-top', '14%')

<%--			var imageElement = document.getElementById('img3');
			// Create a canvas element
			var canvas = document.createElement('canvas');
			var context = canvas.getContext('2d');

			// Set the canvas dimensions to match the image
			canvas.width = imageElement.width;
			canvas.height = imageElement.height;

			// Rotate the image (45 degrees in this example, adjust as needed)
			context.translate(canvas.width / 2, canvas.height / 2);
			context.rotate((Math.PI / 180) * counter);
			context.drawImage(imageElement, -canvas.width / 2, -canvas.height / 2);

			context.setTransform(1, 0, 0, 1, 0, 0);

			// Convert the canvas content to a data URL
			var rotatedImageDataUrl = canvas.toDataURL('image/jpeg');

			// Optional: Display the rotated image
			var rotatedImageElement = document.createElement('img');
			rotatedImageElement.src = rotatedImageDataUrl;
			document.body.appendChild(rotatedImageElement);

			// Optional: Save the rotated image data URL to a hidden field or send it to the server
			//document.getElementById('hdnImageData').value = rotatedImageDataUrl;
			$('#<%= hdnImageData.ClientID %>').val(rotatedImageDataUrl);--%>
        }

        function showimage(imgid, imgcode, height, width, zinsize1, zoutsize1, mstwidth1, mstheight1, flag, doctype, popdesc) {
            debugger;
            $('#ctl00_contentplaceholder1_hdnrotatevalue').val("0");
            $("#ctl00_contentplaceholder1_hdnht").val(height);
            $("#ctl00_contentplaceholder1_hdnwt").val(width);
            counter = 0;
            flag = 1;
            mstwidth = mstwidth1;
            mstheight = mstheight1;
            zinsize = zinsize1;
            zoutsize = zoutsize1;
            size = ((zoutsize1 / 1024) * 20) / 100;
            imgwidth = width;
            imgheight = height;
            var cndno = document.getElementById('txtAgntCode').value; <%--//document.getelementbyid('<%=hdncndno.clientid%>').value;--%>
            var modal = document.getElementById('myModalImage');/* //document.getElementById('mymodalimage');*/
            var imgsrc = "";
            imgsrc = "fpimagecsharp.aspx?imageid=" + imgid + "&Flag=" + "Hierarchy";   
            //var img = document.getelementbyid('myimg');
            var modalimg = document.getElementById("img3");
            //var img = document.getelementbyid("ctl00_contentplaceholder1_pdfimage1");
            //img.style.display = 'none'; //added  by sanoj 04022023
            $("#ctl00_contentplaceholder1_hdnid").val(imgid);
            doccode = imgcode;
            modal.style.display = "block";
            modalimg.src = imgsrc;
            modalimg.alt = this.alt;
            modalimg.width = width;
            modalimg.height = height;
           // $("#img3").removeattr("style");
            //var mybookid = doctype
            //$("#ctl00_contentplaceholder1_lbldocdesc").text(mybookid);
            //$("#ctl00_contentplaceholder1_hdnimgid").val(mybookid);
            //if (popdesc == "cfr") {
            //    document.getelementbyid("buttoncropimage").style.display = "none";

            //    document.getelementbyid("rasisecfr").style.display = "none";
            //    document.getelementbyid("btnapp").style.display = "none";

            //    document.getelementbyid("img-op").style.display = "none";
            //    document.getelementbyid("btnsaveimage").style.display = "none";
            //}
            //if (mybookid == "photo" || mybookid == "signature") {
            //}
            //else {
            //    $("#buttoncropimage").hide();
            //}
            //if (flag == 2) {
            //    $('#ctl00_contentplaceholder1_btnapp').attr("disabled", true);
            //}
            //else {
            //    $('#ctl00_contentplaceholder1_btnapp').attr("disabled", false);
            //}
            //arg03 = mybookid;
            //document.getelementbyid("ctl00_contentplaceholder1_lbldoctype").value = doctype;
            //document.getelementbyid("ctl00_contentplaceholder1_label19").innerhtml = doctype;
            //var span = document.getelementsbyclassname("close")[0];
            //var span1 = document.getelementsbyclassname("btn btn-default")[0];
        }
        window.addEventListener('load', function () {
             var MemCode = document.getElementById('txtAgntCode').value;
                debugger;
                showimage(MemCode, '1', '138', '103', '14214', '51200', '142', '192', '1', 'Photo', 'cfr')
            //var Flagval = GetQueryStringValue(window.location, 'Flag');
            //if (Flagval == 'Heirarchy') {
            //    var elements = document.getElementsByClassName('card');
            //    for (var i = 0; i < elements.length; i++) {
            //        elements[i].style.marginTop = '200px';
            //    }
               
            //}
        });

        function GetQueryStringValue(url, param) {
            debugger;
            param = param.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regVal = new RegExp("[\\?&]" + param + "=([^&#]*)"),
                results = regVal.exec(url);
            return results === null ? null : decodeURIComponent((results[1]).replace(/\+/g, " "));
        }

        function doUpload() {
            alert("Photo Uploaded Successfully");
            var Flagval = GetQueryStringValue(window.location, 'Flag');
            if (Flagval == 'Heirarchy') {
                doCancel2();
            }
            else {
                window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
			}
			window.opener.location.reload();
        }
  //      function doCancel2() {
  //          debugger;
  //          var parentDivPopup = window.parent.document.getElementById('divPopup');
  //          if (parentDivPopup) {
  //              GetBytes(document.getElementById('txtAgntCode').value);
  //              parentDivPopup.style.display = 'none';
  //          }
		//}
        function doCancel2() {
            debugger;
            //var parentDivPopup = window.parent.document.getElementById('divPopup');
            //if (parentDivPopup) {
            //    GetBytes(document.getElementById('txtAgntCode').value);
            //    parentDivPopup.style.display = 'none';
            //}
			var Memcode = GetQueryStringValue(window.location, 'Field1');
			localStorage.setItem('Memcode', Memcode);
			var btn = window.parent.document.getElementById("btnClosePopup");
			btn.click()
		}
<%--		function blurButtonClick() {
			// Your existing logic (if any) goes here
			// ...

			// Trigger the postback for the server-side button click event
			__doPostBack('<%= btnSave.UniqueID %>', '');
			return false; // Return false to prevent the default button click behavior
		}--%>
        function funcopencrop1() {
            debugger;
            document.getElementById('ctl00_ContentPlaceHolder1_lblImageCrop').innerHTML = 'Crop Image'; //added by sanoj 21-03-2023
            var modal = document.getElementById('myModalCrop');
            var modaliframe = document.getElementById("iframe1");
<%--            var cndno = document.getElementById('<%=hdnCndNo.ClientID%>').value;
            var userid = document.getElementById('<%=hdnUserId.ClientID%>').value;--%>
<%--            modaliframe.src = "../../../Application/ISys/Recruit/CropImage.aspx?Flag=QC&CndNo=" + document.getElementById('<%=hdnCndNo.ClientID%>').value + "&args3=" + document.getElementById('<%=hdnImgId.ClientID%>').value + "&mdlpopup=MdlPopRaiseCrop";--%>
            var span = document.getElementsByClassName("close")[0];

            span.onclick = function () {
                //  debugger;
                modal.style.display = "none";

            }
            var pouId = document.getElementById("myModalImage");//added by sanoj 06032023
            pouId.style.display = 'none';
            modal.style.display = "block";
            $('#myModalCrop').modal();

		}
        function funcopencrop1old(MemCode) {
            debugger;
            document.getElementById('lblImageCrop').innerHTML = 'Crop Image'; //added by sanoj 21-03-2023
            var modal = document.getElementById('myModalCrop');
            var modaliframe = document.getElementById("iframe1");
<%--            var cndno = document.getElementById('<%=hdnCndNo.ClientID%>').value;
            var userid = document.getElementById('<%=hdnUserId.ClientID%>').value;--%>
<%--            modaliframe.src = "../../../Application/ISys/Recruit/CropImage.aspx?Flag=QC&CndNo=" + document.getElementById('<%=hdnCndNo.ClientID%>').value + "&args3=" + document.getElementById('<%=hdnImgId.ClientID%>').value + "&mdlpopup=MdlPopRaiseCrop";--%>
			modaliframe.src = "CropImage.aspx?Memcode=" + MemCode + "&mdlpopup=MdlPopRaiseCrop";
			var span = document.getElementsByClassName("close")[0];

            span.onclick = function () {
                //  debugger;
                modal.style.display = "none";

            }
            var pouId = document.getElementById("myModalImage");//added by sanoj 06032023
            pouId.style.display = 'none';
            modal.style.display = "block";
            $('#myModalCrop').modal();

		}
		
		function funcopencrop1(MemCode) {
			debugger;
			// Set the window features (adjust as needed)
			var features = "width=500,height=400,toolbar=no,location=no,status=no,menubar=no";

			// Construct the URL with parameters
			var url = "CropImage.aspx?Memcode=" + MemCode + "&mdlpopup=MdlPopRaiseCrop";

			// Open a new window
			var newWindow = window.open(url, "CropImageWindow", features);

			// Optionally, focus the new window
			if (newWindow) {
				newWindow.focus();
			}
		}
        function funccrop1() {
            debugger;
			$('#img3').Jcrop({
                onSelect: updateCoords,
                onChange: updateCoords
            });

		}
		function updateCoords(c) {
			debugger;
            $('#hfX').val(c.x);
            $('#hfY').val(c.y);
            $('#hfHeight').val(c.h);
            $('#hfWidth').val(c.w);
        }
    function triggerFileUpload() {
        document.getElementById('FileUpload1').click();
    }

	function OpenCamera() {
		debugger;
		const video = document.getElementById('video');
		const Img = document.getElementById('img3');
		video.style.display = "block";
		video.style.marginLeft = "138px";
		Img.style.display = "none";
		const BtnVid = document.getElementById('btnVid');
		if (BtnVid.innerText == "\nCLICK" || BtnVid.innerHTML == "<span class='glyphicon glyphicon-camera' style='color: #00cccc; height: 14px; font-size: 16px !important;'></span><br />CLICK</span>") {
			BtnVid.innerHTML="<span class='glyphicon glyphicon-camera' style='color: #00cccc; height: 14px; font-size: 16px !important;'></span><br />CAPTURE</span>";
			navigator.mediaDevices.getUserMedia({ video: true })
				.then(function (stream) {
					video.srcObject = stream;
				})
				.catch(function (error) {
					console.log("Error accessing camera: ", error);
				});
		}
		else {
			const canvas = document.getElementById('canvas');
			BtnVid.innerHTML = "<span class='glyphicon glyphicon-camera' style='color: #00cccc; height: 14px; font-size: 16px !important;'></span><br />CLICK</span>";
			const context = canvas.getContext('2d');
		    context.drawImage(video, 0, 0, canvas.width, canvas.height);
		    
		    // You can convert the canvas data to an image or send it to a server
		    // For simplicity, we'll just log the data URL in this example
		    const imageDataURL = canvas.toDataURL('image/png');
		    //console.log('Captured photo:', imageDataURL);
			$('#<%= hdnImageData.ClientID %>').val(imageDataURL);
			video.style.display = "none";
			Img.style.display = "block";
			Img.style.marginLeft = "125px";
			document.getElementById("img3").src = imageDataURL;
		}
	}

    </script>
	<style>
		.jcrop-holder{
			width: 103px;
			height: 138px;
			position: relative;
			background-color: black;
			margin-left: 128px;
		}
		.close {
			float: right;
			font-size: 21px;
			font-weight: 700;
			line-height: 1;
			color: #000;
			text-shadow: 0 1px 0 #fff;
			filter: alpha(opacity=20);
			opacity: .2;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptMgr" runat="server" />
            <div class="card" style="margin-top: 220px;height:60vw;width:98vw;box-shadow: 10px 10px 10px rgba(0, 0, 0, 0.3);">
				<button type="button" id="btnClosePopup" class="close" data-dismiss="modal" aria-hidden="true" onclick="doCancel2()" style="border:0px;width: 4px;margin-left: 392px;">&times</button>
                <div class="row" id="Div1" runat="server" style="display: none;">
                    <div class="col-sm-3" >
                                                <asp:TextBox ID="txtAgntCode" runat="server" CssClass="form-control" Width="270px"></asp:TextBox>
                    </div>
                    </div>
<%--                <div class="row" id="rowDocupld" runat="server" >--%>
<%--                    <div class="col-sm-3" style="text-align:left">
                        <asp:LinkButton ID="btnUpload" runat="server" CssClass="btn btn-sample"
                            Text="Upload Photo" OnClick="btnUpload_Click">
                         <span class="glyphicon glyphicon-upload" style='color:White;'></span> Upload Photo
                        </asp:LinkButton>
                    </div>--%>
<%--                </div>
            <br />
                <br />--%>
              <div id="myModalImage" class="modal" style="margin-top: 235px;width:95%;padding-left:10px">

            <div class="modal-content" style="border:none">

                <div class="modal-title">
                    <asp:HiddenField ID="hdnImgId" runat="server" />
                    <asp:HiddenField ID="hdnId" runat="server" />

                </div>
                <div class="row" style="margin-top: 10px;display:none">
                    <div class="col-sm-3" style="text-align: center;">

                        <asp:Label ID="lblDocType" Text="Document Name:" CssClass="HeaderColor" Style="font-size: 17px;" runat="server"></asp:Label>

                    </div>
                    <div class="col-sm-8" style="text-align: left;">

                        <asp:Label ID="lblDocDesc" runat="server" Text="" CssClass="HeaderColor" Style="font-size: 17px; margin-left: -36px;"></asp:Label>

                    </div>
                    <%--<div class="col-sm-1" style="margin-top: -10px;">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return Cancel(myModalImage);" Style="color: blue; font-size: 30px; text-decoration: none;">
                                   &times;
                        </asp:LinkButton>



                    </div>--%>

                </div>

                <div class="modal-body">
                   <%-- <center>--%>
                        <div id="img-preview" style="text-align:center;">
                          
                               <%--<asp:Image id="img3" runat="server"   class="image-box" style="cursor: move;" />--%>
							<asp:Image id="img3" runat="server" />
							<video id="video" width="103" height="138" style="display:none" autoplay></video>
							<canvas id="canvas" width="103" height="138" style="display:none;"></canvas>
                             <%--<iframe id="PDFImage1" runat="server" width="100%" height="350px"></iframe>--%>
                        </div>
                        <%--<div class="img-op">--%>
                        
                        <%-- <asp:HiddenField ID="HiddenField3" runat="server" />
                        <asp:HiddenField ID="HiddenField4" runat="server" />
                        <asp:HiddenField ID="HiddenField5" runat="server" />--%>

                    <%--</div>--%>
                   
  
                  <%--</center>--%>
                </div>





                <div class="footer" style="text-align: center; margin-bottom: 3px;">

                    <asp:UpdatePanel ID="updbuttons" runat="server">
                        <ContentTemplate>
                            <div class="row" style="width:101vw;">
                                <div id="divImgBtn" style="width:105vw;">
                                    <span id="btnVid" class="btn" onclick="return  OpenCamera();" style="font-size: 10px;">
                                        <span class="glyphicon glyphicon-camera" style="color: #00cccc; height: 14px; font-size: 16px !important;"></span>
                                        <br />
                                        CLICK</span>
									<span class="btn" style="font-size: 10px;">
															<span class="glyphicon glyphicon-cloud-upload" onclick="triggerFileUpload()" style="color: #00cccc; height: 14px; font-size: 16px !important;"></span>
															<br />
															UPLOAD
																<input type="file" id="FileUpload1" style="display: none;" />
									</span>

                                    <span class="btn" onclick="return  zoomIn();" style="font-size: 10px;">
                                        <span class="glyphicon glyphicon-zoom-in" style="color: #00cccc; height: 14px; font-size: 16px !important;"></span>
                                        <br />
                                        ZOOM<br />IN</span>

                                    <span class="btn" onclick="return  zoomOut();" style="font-size: 10px;">
                                        <span class="glyphicon glyphicon-zoom-out" style="color: #00cccc; height: 14px; font-size: 16px !important;"></span>
                                        <br />
                                        ZOOM<br />OUT</span>

                                    <span class="btn" onclick="return  rotateImage();" style="font-size: 10px;">
                                        <span class="glyphicon glyphicon-repeat" style="color: #00cccc; height: 14px; font-size: 16px !important;"></span>
                                        <br />
                                        ROTATE</span>

                                   <%-- <asp:LinkButton ID="btnSaveImage" runat="server" Style="font-size: 10px;" Text="Save Image" CssClass="btn" OnClick="btnSaveImage_Click">
                        <span class="glyphicon glyphicon-floppy-disk" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> SAVE 
                                    </asp:LinkButton>--%>

                                    <button class="btn" id="ButtonCROPImage" onclick="return funccrop1();" style="font-size: 10px;">
                                        <span class="glyphicon glyphicon-edit" style="color: #00cccc; height: 14px; font-size: 16px !important;"></span>
                                        <br />
                                        CROP</button>
<%--                                    <button class="btn" id="ButtonCROPImage" runat="server" onserverclick="BtnCrop_ServerClick" style="font-size: 10px;">
                                        <span class="glyphicon glyphicon-edit" style="color: #00cccc; height: 14px; font-size: 16px !important;"></span>
                                        <br />
                                        CROP</button>--%>


<%--                                    <button class="btn" id="btnBlur" onclick="return funcopenBlur();" style="font-size: 10px;">
                                        <span class="glyphicon glyphicon-adjust" style="color: #00cccc; height: 14px; font-size: 16px !important;"></span>
                                        <br />
                                        BLUR
                                    </button>--%>
                                    <button class="btn" id="btnSave" runat="server" onserverclick="btnSave_ServerClick" style="font-size: 10px;">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color: #00cccc; height: 14px; font-size: 16px !important;"></span>
                                        <br />
                                        SAVE
                                    </button>

                                    <button type="button" class="btn btn-danger btnBorderRadius" style="display: none;" onclick="return Cancel(myModalImage);">
                                        <span class="glyphicon glyphicon-remove" style="color: White"></span>CANCEL</button>
                                </div>

<%--                                <div id="divPdfBtn">
                                 
                                </div>--%>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

        </div>
      </div>
<div class="modal" id="myModalCrop" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:60px;" >
  <div class="modal-dialog" style="
    padding-top: 0px;
    width: 70%;">
    <div class="modal-content">
      
        <button type="button"  style="display:none;" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
       
      <div class="row" style=" margin-top: 10px;">
                         <div class="col-sm-2" style="text-align:center;padding: 1px;margin-left: 11px;">
                      <asp:Label ID="lblImageCrop"  runat="server" Text="Crop Image"  CssClass="HeaderColor" style="font-size:17px;"></asp:Label>  

                  </div>
                         <div class="col-sm-9" style="text-align:center;padding: 1px;margin-left: 10px;">
                     

                  </div>
                         <div class="col-sm-1" style="text-align:center;padding: 1px;margin-left: -26px;margin-top: -12px;">
                         <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="return Cancel1(myModalCrop,myModalImage);"  style="color:blue;font-size: 30px;text-decoration: none;" >
                                   &times;
                              </asp:LinkButton>--%>

                              <button type="button" class="btn"  onclick="return Cancel1(myModalCrop,myModalImage);">
                      <span   style="color:blue;font-size: 30px;"> &times;</span></button>
                  </div>
        </div>
                   

      <div class="modal-body" >
          <iframe id="iframe1" src="" width="475" height="320" frameborder="0" allowtransparency="true"></iframe>  
      </div>
      
      </div>
    </div>
    <!-- /.modal-content -->
  </div>
         <asp:HiddenField ID="hdnRotateValue" runat="server" />
            <asp:HiddenField ID="hdnCndNo" runat="server" />
            <asp:HiddenField ID="ZoutSize" runat="server" />
            <asp:HiddenField ID="ZinSize" runat="server" />
            <asp:HiddenField ID="hdnimg" runat="server" />
			<asp:HiddenField ID="hdnImageData" runat="server" />
    <asp:HiddenField ID="hfX" runat="server" />
    <asp:HiddenField ID="hfY" runat="server" />
    <asp:HiddenField ID="hfHeight" runat="server" />
    <asp:HiddenField ID="hfWidth" runat="server" />
    <asp:HiddenField id="HiddenField1" runat="server" />
    </form>
</body>
</html>

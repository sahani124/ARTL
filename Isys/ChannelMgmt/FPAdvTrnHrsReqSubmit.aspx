<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FPAdvTrnHrsReqSubmit.aspx.cs"
    Inherits="Application_ISys_ChannelMgmt_FranchiesEnrollment_FPAdvTrnHrsReqSubmit" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <%--<link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />--%>
   <%-- <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
     <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
   
     <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
     <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />

    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>--%>
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
    <%--Added by rahana end--%>
    <script language="javascript" type="text/javascript">

        //////////// added by Daksh start  ////////////////
        var doccode;
        var arg03, Transfr;
        var ZinSize, ZoutSize;
        var MstWidth, MstHeight;
        var ImgWidth, ImgHeight, Size, flag;
        var counter;

        function RaiseCFR() {
            debugger;
            var Transfr;
            var modal = document.getElementById('myModalRaise'); 
            var modalImage = document.getElementById('myModalImage');
            var modalPDFImage = document.getElementById('PDFImgModal');

            

            var modaliframe = document.getElementById("iframeCFR");
            var cndno = document.getElementById('<%=hdnCndNo.ClientID%>').value;
            var userid = document.getElementById('<%=hdnUserId.ClientID%>').value;
            var args1 = "ctl00_ContentPlaceHolder1_BtnApprove"; //document.getElementById('<%=BtnApprove.ClientID%>').id;
            var args3 = arg03;

            var args5 = doccode;
            var args4 = doccode;
            var args2 = "ctl00_ContentPlaceHolder1_BtnCFR";
            var raised = document.getElementById('<%=hdnraise.ClientID%>').id;
            var responded = document.getElementById('<%=hdnrespond.ClientID%>').id;
            var closed = document.getElementById('<%=hdnclose.ClientID%>').id;
            var TransfrReqNo = Transfr;
            var ID = document.getElementById('<%=hdnId.ClientID%>').value;
            var IDCFR = document.getElementById('<%=hdnCFR.ClientID%>').value;
            var ModuleID = document.getElementById('<%=hdnModuleId.ClientID%>').value;//Added by usha
            

            //if (IDCFR == "Y") {
            //    ID = "Others";
            //}
            //             if (eval(document.getElementById("ctl00_ContentPlaceHolder1_chkOtherCFR").checked) == true) {
            //                 IDCFR == "Y"
            //                 ID = "Others";
            //             }
            // Get the image and insert it inside the modal - use its "alt" text as a caption
            if (TransfrReqNo != null) {

                modaliframe.src = "../../../Application/ISys/ChannelMgmt/FPPopRaiseCFR.aspx?MemCode=" + cndno + "&ModuleID=" + ModuleID + "&UserId=" + userid + "&args1=" + args1 + "&args2=" + args2 + "&args3=" + args3 + "&args4=" + args4 + "&args5=" + args5 + "&raised=" + raised + "&responded=" + responded + "&closed=" + closed + "&TransfrReqNo=" + Transfr + "&FlagCode=Trnsfr&ID=" + ID + "&mdlpopup=MdlPopRaiseCFR";

            }
            else {
                modaliframe.src = "../../../Application/ISys/ChannelMgmt/FPPopRaiseCFR.aspx?MemCode=" + cndno + "&ModuleID=" + ModuleID + "&UserId=" + userid + "&args1=" + args1 + "&args2=" + args2 + "&args3=" + args3 + "&args4=" + args4 + "&args5=" + args5 + "&raised=" + raised + "&responded=" + responded + "&closed=" + closed + "&FlagCode=Others&ID=" + ID + "&mdlpopup=MdlPopRaiseCFR";


            }
            modalImage.style.display = 'none';
            modalPDFImage.style.display = 'none';
            modal.style.display = 'block';
           
        }

        function validatiion() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strContent + "ddlnmbnkhldname").value == null || document.getElementById(strContent+"ddlnmbnkhldname").value == "") {
                alert("Please Enter Account Holder Name");
                document.getElementById(strContent + "ddlnmbnkhldname").focus();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtnmbnkacno").value) == null || SpaceTrim(document.getElementById(strContent + "txtnmbnkacno").value) == "") {
                alert("Please Enter Bank Account No");
                document.getElementById(strContent + "txtnmbnkacno").focus();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "ddlnmifscode").value) == null || SpaceTrim(document.getElementById(strContent + "ddlnmifscode").value) == "") {
                alert("Please Enter Bank IFSC code");
                return false;
            }
            else {
                debugger;
                var ifsc = document.getElementById(strContent +"ddlnmifscode").value;
                var reg = /[A-Za-z]{4}[0]{1}[A-Za-z0-9]{6}$/;
                if (!ifsc.match(reg)) {
                    alert("Please Enter Correct Bank IFSC code");
                    return false;
                }
            }
            if (document.getElementById(strContent + "ddlnmddlactype").selectedIndex == 0 || document.getElementById(strContent + "ddlnmddlactype").selectedIndex == null) {
                alert("Please select Account type");
                document.getElementById(strContent + "ddlnmddlactype").focus();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "ddlnmBrnchname").value) == "" || SpaceTrim(document.getElementById(strContent + "ddlnmBrnchname").value) == null) {
                alert("Please Enter Branch Name");
                document.getElementById(strContent + "ddlnmBrnchname").focus();
                return false;
            }
            if (document.getElementById(strContent + "ddlnmBnkname").value == null || document.getElementById(strContent + "ddlnmBnkname").value == "") {
                alert("Please Enter Bank Name");
                document.getElementById(strContent + "ddlnmBnkname").focus();
                return false;
            }
            if (document.getElementById(strContent + "txtnmmicr").value != "") {
                if (document.getElementById(strContent + "txtnmmicr").value.length != 9) {
                    alert("MICR Code Should be 9 Digit.");
                    document.getElementById(strContent + "txtnmmicr").focus();
                    return false;
                }
            }
        }

        function Cancel(modalimg) {
            debugger;
            var modal = modalimg;
            var span = document.getElementsByClassName("close")[0];

            modal.style.display = "none";


        }

        function zoomIn() {
            // debugger;
            var max_height, max_width;

            var imageHeight = $('#ctl00_ContentPlaceHolder1_img3').height();
            var imageWidth = $('#ctl00_ContentPlaceHolder1_img3').width();

            ZinSize = imageHeight * imageWidth / 1024;

            var size = ZoutSize / 1024;
            if (ZinSize <= size) {
                $('#ctl00_ContentPlaceHolder1_img3').css({
                    height: '+=' + imageHeight * 0.1,
                    width: '+=' + imageWidth * 0.1
                });
                $("#ctl00_ContentPlaceHolder1_hdnHt").val($('#ctl00_ContentPlaceHolder1_img3').height());
                $("#ctl00_ContentPlaceHolder1_hdnWt").val($('#ctl00_ContentPlaceHolder1_img3').width());
                $('#ctl00_ContentPlaceHolder1_btnSaveImage').attr("disabled", false);
            }


        }

        function zoomOut() {
            //  debugger;

            var imageHeight = $('#ctl00_ContentPlaceHolder1_img3').height();
            var imageWidth = $('#ctl00_ContentPlaceHolder1_img3').width();
            ZinSize = imageHeight * imageWidth / 1024;

            var size = Size;
            if (ZinSize >= size) {
                $('#ctl00_ContentPlaceHolder1_img3').css({
                    height: '-=' + imageHeight * 0.1,
                    width: '-=' + imageWidth * 0.1
                });
                $("#ctl00_ContentPlaceHolder1_hdnHt").val($('#ctl00_ContentPlaceHolder1_img3').height());
                $("#ctl00_ContentPlaceHolder1_hdnWt").val($('#ctl00_ContentPlaceHolder1_img3').width());
                $('#ctl00_ContentPlaceHolder1_btnSaveImage').attr("disabled", false);
            }

        }



        function rotateImage() {
            //  debugger;
            var options;




            var box = $('#ctl00_ContentPlaceHolder1_img3');
            // box.toggleClass('box-rotate');
            counter += 90;
            $('#ctl00_ContentPlaceHolder1_hdnRotateValue').val(counter);
            $('#ctl00_ContentPlaceHolder1_btnSaveImage').attr("disabled", false);
            $('#ctl00_ContentPlaceHolder1_img3').css('transform', 'rotate(' + counter + 'deg)')
            $('#ctl00_ContentPlaceHolder1_img3').css('margin-top', '14%')



        }


        function showimage(ImgId, ImgCode, Height, Width, ZinSize1, ZoutSize1, MstWidth1, MstHeight1, Flag, Doctype, PopDesc) {
            debugger;
//            var a = document.getElementById('#ctl00_ContentPlaceHolder1_hdnRotateValue')
           $('#ctl00_ContentPlaceHolder1_hdnRotateValue').val("0");
//            var b = $('#ctl00_ContentPlaceHolder1_hdnRotateValue');
//            var c = b.val("0");
            $("#ctl00_ContentPlaceHolder1_hdnHt").val(Height);
            $("#ctl00_ContentPlaceHolder1_hdnWt").val(Width);
            $('#ctl00_ContentPlaceHolder1_btnSaveImage').attr("disabled", true);
            counter = 0;
            flag = 1;
            MstWidth = MstWidth1;
            MstHeight = MstHeight1;
            ZinSize = ZinSize1;
            ZoutSize = ZoutSize1;
            Size = ((ZoutSize1 / 1024) * 20) / 100;
            ImgWidth = Width;
            ImgHeight = Height;
            var cndno = document.getElementById('<%=hdnCndNo.ClientID%>').value;
            var modal = document.getElementById('myModalImage');
            var ImgSrc = "";
            ImgSrc = "FPImageCSharp.aspx?ImageID=" + ImgId;
            // Get the image and insert it inside the modal - use its "alt" text as a caption
            var img = document.getElementById('myImg');
            var modalImg = document.getElementById("ctl00_ContentPlaceHolder1_img3");
            // $("#ctl00_ContentPlaceHolder1_img3").imageBox();
            var img = document.getElementById("ctl00_ContentPlaceHolder1_PDFImage1");
            img.style.display = 'none'; //added  by sanoj 04022023
            $("#ctl00_ContentPlaceHolder1_hdnId").val(ImgId);
            doccode = ImgCode;
            modal.style.display = "block";
            modalImg.src = ImgSrc;
            modalImg.alt = this.alt;
            modalImg.width = Width;
            modalImg.height = Height;
            $("#ctl00_ContentPlaceHolder1_img3").removeAttr("style");
            //var myBookId = $("#" + ImgCode).data('original-title');
            var myBookId = Doctype
            $("#ctl00_ContentPlaceHolder1_lblDocDesc").text(myBookId);
            //$("#ctl00_ContentPlaceHolder1_lblDocType").text(Doctype);
            $("#ctl00_ContentPlaceHolder1_hdnImgId").val(myBookId);
            //Added by Daksh of CFR Document 
            if (PopDesc == "CFR") {
                document.getElementById("ButtonCROPImage").style.display = "none";

                document.getElementById("rasiseCFR").style.display = "none";
                document.getElementById("btnApp").style.display = "none";

                document.getElementById("img-op").style.display = "none";
                document.getElementById("btnSaveImage").style.display = "none";
            }
            if (myBookId == "Photo" || myBookId == "Signature") {
                //$("#ButtonCROPImage").show();
            }
            else {
                $("#ButtonCROPImage").hide();
            }
            if (Flag == 2) {
                $('#ctl00_ContentPlaceHolder1_btnApp').attr("disabled", true);
            }
            else {
                $('#ctl00_ContentPlaceHolder1_btnApp').attr("disabled", false);
            }
            arg03 = myBookId;
          

            document.getElementById("ctl00_ContentPlaceHolder1_lblDocType").value = Doctype;
            document.getElementById("ctl00_ContentPlaceHolder1_Label19").innerHTML = Doctype;
            
            //var captionText = $("#"+ImgId).attr("data-title");
            //document.getElementById("lblDocDesc").value() = captionText;
            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];
            var span1 = document.getElementsByClassName("btn btn-default")[0];



        }



        function showPDF(PDFId, ImgCode, Height, Width, ZinSize1, ZoutSize1, MstWidth1, MstHeight1, Flag, Doctype, PopDesc) {
            debugger;

            counter = 0;
            flag = 1;
            MstWidth = MstWidth1;
            MstHeight = MstHeight1;
            ZinSize = ZinSize1;
            ZoutSize = ZoutSize1;
            Size = ((ZoutSize1 / 1024) * 20) / 100;
            ImgWidth = Width;
            ImgHeight = Height;

            var cndno = document.getElementById('<%=hdnCndNo.ClientID%>').value;
            var modal = document.getElementById('PDFImgModal');
            var ImgSrc = "";
            ImgSrc = "FPPDFCSharp.aspx?PDFID=" + PDFId;


            var img = document.getElementById('myImg');
            var modalImg = document.getElementById("ctl00_ContentPlaceHolder1_PDFImage");
            $("#ctl00_ContentPlaceHolder1_hdnId").val(PDFId);

            doccode = ImgCode;
            modal.style.display = "block";
            modalImg.src = ImgSrc;
            modalImg.alt = this.alt;
            
            $("#ctl00_ContentPlaceHolder1_PDFImage").removeAttr("style");
            var myBookId = Doctype
            $("#ctl00_ContentPlaceHolder1_lblPDFDocDesc").text(myBookId);
            $("#ctl00_ContentPlaceHolder1_hdnPDFImgId").val(myBookId);

            //Added by Daksh of CFR Document 
            if (PopDesc == "CFR") {
                document.getElementById("btnPDFCFR").style.display = "none";
                document.getElementById("lnkbtnPDFApprv").style.display = "none";
                document.getElementById("pdf-op").style.display = "none";
            }
            //if (myBookId == "Photo" || myBookId == "Signature") {
            //    $("#ButtonCROPImage").show();
            //}
            //else {
            //    $("#ButtonCROPImage").hide();
            //}
            document.getElementById("ctl00_ContentPlaceHolder1_Label19").innerHTML = Doctype;//added by sanoj for document name on cfr
            if (Flag == 2) {
                $('#ctl00_ContentPlaceHolder1_lnkbtnPDFApprv').attr("disabled", true);
            }
            else {
                $('#ctl00_ContentPlaceHolder1_lnkbtnPDFApprv').attr("disabled", false);
            }
            arg03 = myBookId;
            $("#ctl00_ContentPlaceHolder1_lblPDFDocName").val(Doctype);
            var span = document.getElementsByClassName("close")[0];
            var span1 = document.getElementsByClassName("btn btn-default")[0];

            // When the user clicks on <span> (x), close the modal
            //span.onclick = function () {
            //    modal.style.display = "none";
            //    var clickButton = document.getElementById("ctl00_ContentPlaceHolder1_PageReLoad");
            //    clickButton.click();
            //    return true;
            //}
            //span1.onclick = function () {
            //    modal.style.display = "none";
            //    var clickButton = document.getElementById("ctl00_ContentPlaceHolder1_PageReLoad");
            //    clickButton.click();
            //    return true;
            //}

        }

        var strContent = "ctl00_ContentPlaceHolder1_";
        //form1.onload = function () {
        //    zoom(1)
        //}

        /// added by Daksh end   ////////////////
        function zoom(zm) {
            var button = document.getElementById('<%=btnRotateSave.ClientID %>');
            button.disabled = true;
            img = document.getElementById(strContent + "imgbnd");
            wid = img.width
            ht = img.height
            img.style.width = (wid * zm) + "px"
            img.style.height = (ht * zm) + "px"

            if ((img.style.width >= '322.2' + 'px')) {
                document.getElementById("btnp").disabled = true;
            }
            else {
                if (document.getElementById("btnp").disabled = true) {
                    document.getElementById("btnp").disabled = false;
                }
            }

            if ((img.style.width <= '108' + 'px')) {
                document.getElementById("btnm").disabled = true;
            }
            else {
                if (document.getElementById("btnm").disabled = true) {
                    document.getElementById("btnm").disabled = false;
                }
                else { document.getElementById("btnm").disabled = true; }
            }
            var btnZoom = document.getElementById(strContent + "btnm");

        }


        //added by sanoj 1042023
        function msgpopup(value) {
            debugger;
            document.getElementById('ctl00_ContentPlaceHolder1_Label15').innerHTML = value ;

            var modal = document.getElementById('msgModalPopup');
            modal.style.display = "block";
            //$("#myModal").modal();
        }
        //ended by sanoj 1042023
         //added by sanoj 18042023
        function popup() {
            debugger;
            var modal = document.getElementById('msgModalPopup1');
            modal.style.display = "block";
            //$("#myModal").modal();
        }
        function Cancel(modalimg) {
            debugger;
            var modal = modalimg;
            modal.style.display = "none";


        }
         //endded by sanoj 18042023
    </script>
    <%--    added by amruta 29/7/16 for rotation of image start--%>
    <script language="javascript" type="text/javascript">
        var degrees = 0;
        function brnrotatep1() {
            debugger;
            var button = document.getElementById('<%=btnRotateSave.ClientID %>');
            button.disabled = false;
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (degrees == 0) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image");
                degrees += 90;
                document.getElementById(strContent + "hdnRotateValue").value = degrees;
                //  alert(degrees);
                return degrees;
            }

            else if (degrees == 90) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image180");
                degrees += 90;
                document.getElementById(strContent + "hdnRotateValue").value = degrees;
                // alert(degrees);
                return degrees;
            }

            else if (degrees == 180) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image270");
                degrees += 90;
                document.getElementById(strContent + "hdnRotateValue").value = degrees;
                // alert(degrees);
                return degrees;
            }

            else if (degrees == 270) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image360");
                degrees += 90;
                document.getElementById(strContent + "hdnRotateValue").value = degrees;
                //alert(degrees);
                return degrees;

            }

            else if (degrees == 360) {

                degrees = 0;
                document.getElementById(strContent + "hdnRotateValue").value = degrees;
                //alert(degrees);
                return degrees;
            }
        }

    </script>
    <script language="javascript" type="text/javascript">
        var degrees = 0;
        function brnrotatem() {
            debugger;
            var button = document.getElementById('<%=btnRotateSave.ClientID %>');
            button.disabled = false;
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (degrees == 0) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated360");
                degrees = 360;
                document.getElementById(strContent + "hdnRotateValue").value = degrees;
                // alert(degrees);
                return degrees;
            }

            else if (degrees == 360) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated270");
                degrees = 270;
                document.getElementById(strContent + "hdnRotateValue").value = degrees;
                // alert(degrees);
                return degrees;
            }

            else if (degrees == 270) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated180");
                degrees = 180;
                document.getElementById(strContent + "hdnRotateValue").value = degrees;
                // alert(degrees);
                return degrees;
            }

            else if (degrees == 180) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated");
                degrees = 90;
                document.getElementById(strContent + "hdnRotateValue").value = degrees;
                // alert(degrees);
                return degrees;
            }

            else if (degrees == 90) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated360");
                degrees = 0;
                document.getElementById(strContent + "hdnRotateValue").value = degrees;
                //  alert(degrees);
                return degrees;
            }
            //            else if (degrees == 90) {
            //                img.setAttribute("class", "rotated-imag");
            //                degrees = 90;
            //                return degrees;
            //            }
        }

    </script>
    <style type="text/css">
        .badge {
            display: inline-block;
            padding: .35em .65em;
            font-size: .75em;
            font-weight: 700;
            line-height: 1;
            color: #fff;
            text-align: center;
            white-space: nowrap;
            vertical-align: baseline;
            border-radius: .25rem;
            background-color: dimgrey;
        }

       /* added by sanoj 30032023*/
         #img-preview {
            height: 255px;
            width: auto;
            overflow: auto;
            text-align: center;
        }
          .clscenter{
           text-align:center!important;
           }
           .clsLeft{
           text-align:left !important;
           padding-left:0px !important;
           }
           .clsright{
               text-align:right !important;
           }
 /* ended by sanoj 30032023*/
        #tblphoto {
            FONT-FAMILY: Verdana, Tahoma, Arial;
            font-size: 12px;
            background-color: #FAFAFA;
            text-align: center!important;
        }

        .row {
            border: none!important;
        }

        .rotated-image {
            -webkit-transform: rotate(90deg);
            transform: rotate(90deg);
        }

        .rotated-image180 {
            -webkit-transform: rotate(180deg);
            transform: rotate(180deg);
        }

        .rotated-image270 {
            -webkit-transform: rotate(270deg);
            transform: rotate(270deg);
        }

        .rotated-image360 {
            -webkit-transform: rotate(360deg);
            transform: rotate(360deg);
        }






        .rotated {
            -webkit-transform: rotate(90deg);
            transform: rotate(90deg);
        }

        .rotated180 {
            -webkit-transform: rotate(180deg);
            transform: rotate(180deg);
        }

        .rotated270 {
            -webkit-transform: rotate(270deg);
            transform: rotate(270deg);
        }

        .rotated360 {
            -webkit-transform: rotate(360deg);
            transform: rotate(360deg);
        }

        .rotated-image0 {
            -webkit-transform: rotate(0deg);
            transform: rotate(0deg);
        }

        .new_text_new {
            color: #066de7;
        }

        .divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }

        .disablepage {
            display: none;
        }

        .box {
            background-color: #efefef;
            padding-left: 5px;
        }
    </style>

    <%--added by ajay 09062023--%>
    <style>
         .modal-content {
            margin: auto;
            display: block;
            width: 100%; /*Meena*/
            max-width: 700px;
        }
    </style>
    <%--    added by amruta 29/7/16 for rotation of image end--%>
    <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">--%>
    <asp:ScriptManager ID="sm50HrsSearch1" runat="server">
    </asp:ScriptManager>
    <center>
        <div class="card PanelInsideTab">
            <asp:Panel ID="Panelphoto2" runat="server" >
            <asp:UpdatePanel runat="server" ID="upnlHeader">
                <ContentTemplate>
                    <div>
                        <div id="tblDocuments" class="row">
                            <div class="col-sm-12" style="text-align: left">
                                <asp:Label ID="lblDocuments" Text="Uploaded Documents" runat="server" CssClass="control-label HeaderColor"></asp:Label>
                            </div>
                        </div>

                        <div id="divDOCPanel" runat="server">
                            <div id="divnavigate" runat="server">
                                <div id="tblphoto" runat="server" class="tblLabelContent" style="width: 100%; text-align: center!important;">
                                    <div class="row rowspacing" style="text-align:center;font-size: 14px;">
                                        <div class="col-sm-1" style="display: none;">
                                             <asp:Button ID="Btncrop" TabIndex="43" Style="display: none;" runat="server" Text="CROP" CssClass="standardbutton"
                                            OnClick="Btncrop_Click" Width="80" Visible="false"></asp:Button>
                                        </div>
                                        <div class="col-sm-2">
                                             <asp:Label ID="Label20" runat="server" Text="Document Status" ></asp:Label>&nbsp;
                     
                                        </div>
                                        <div class="col-sm-2">
                                             <asp:Label ID="lblcfrrais1" runat="server" Text="Raised CFR:" Style="color: Red;"></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrrais1count" runat="server" CssClass="badge" ></asp:Label><br />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Label ID="lblrespond" runat="server" Text="Responded CFR:" Style="color:mediumpurple"></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrrespondcount" runat="server" CssClass="badge"></asp:Label><br />
                                    </div>
                                         <div class="col-sm-2">
                                             <asp:Label ID="lblclosed" runat="server" Text="Closed CFR:" Style="color: blue;"></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrclosed" runat="server" CssClass="badge" ></asp:Label><br />
                                    </div>
                                         <div class="col-sm-3">
                                             <asp:Label ID="Label14" runat="server" Text="Approved Document:" Style="color: Green;"></asp:Label>&nbsp;
                        <asp:Label ID="approvedoc" runat="server" CssClass="badge" ></asp:Label><br />
                                    </div>
                                        </div>

                                    
                                </div>
                            </div>

                            <div id="divPhoto" runat="server" style="width: 100%; height: 100%; overflow: hidden">
                        </div>
                        </div>
                    </div>


                    <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height: 5%;">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblpanelheader" Style="display: none;" runat="server" CssClass="standardlink " />
                                <asp:HiddenField ID="hdnDocId" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <table class="modalpanel" style="display: none">
                        <tr>
                            <td>
                                <asp:Image ID="imgCrop" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <table class="formtable" style="width: 100%; display:none" runat="server" >
                        <tr>
                            <td class="test" colspan="4" style="text-align: left;">
                                
                            </td>
                        </tr>
                    </table>
                    <div >
                        <div>
                            <table >
                                <tr>
                                    <td class="formcontent"  colspan="2">
                                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;" id="divCrop" runat="server" visible="false">
                            <i class="fa fa-crop"></i>--%>
                                       
                                        <%--</div>--%>
                                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;" id="divCFR" runat="server" visible="false">
                            <i class="fa fa-crop"></i>--%>
                                        <%-- <asp:Button ID="BtnCFR" TabIndex="43" OnClick="btnCFR_Click" runat="server" Text="Raise CFR"
                            CssClass="standardbutton" Width="80px" Visible="false"></asp:Button>--%><%--</div>--%>
                                        <%--OnClientClick="fungetcropimage();"--%>
                                    </td>
                                    <%--Added by pranjali on 25-022014 for displaying cfr raised start--%>
                                    <td align="left" class="formcontent" colspan="2">
                                       
                                    </td>

                                    <td align="left" class="formcontent" colspan="2">
                                        
                                    </td>

                                    <td align="left" class="formcontent" colspan="2">
                                        
                                    </td>

                                    <td align="left" class="formcontent" colspan="2">
                                        
                                    </td>
                                    <%--Added by pranjali on 25-022014 for displaying cfr raised end--%>
                                </tr>
                            </table>
                        </div>
                        
                    </div>
                    <div id="divgrid" runat="server" style="width: 100%; height: 100%; display: none; overflow: hidden">
                        <table style="border-collapse: separate; left: 0in; position: relative; top: 0px; width: 100%;"
                            class="tableIsys">
                            <tr>
                                <td>
                                    <asp:GridView ID="GridImage" runat="server" AllowSorting="True" CssClass="tableIsys"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                        RowStyle-CssClass="tableIsys" HorizontalAlign="Left" AutoGenerateColumns="False"
                                        AllowPaging="True" Width="100%" Height="242px" OnPageIndexChanging="GridImage_PageIndexChanging"
                                        OnRowDataBound="GridImage_RowDataBound">
                                        <Columns>
                                            <%--<asp:TemplateField SortExpression="DocType" HeaderText="Image Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblCndNo" runat="server" Text='<%# Eval("DocType") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton>
                                                    <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ID") %>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ImageField DataImageUrlField="ID" DataImageUrlFormatString="FPImageCSharp.aspx?ImageID={0}"
                                                HeaderText="Preview Image">
                                                <%--ItemStyle-Height="100%" ItemStyle-Width="100%"--%>
                                            </asp:ImageField>
                                        </Columns>
                                        <RowStyle CssClass="sublinkeven" BackColor="#78A8FA"></RowStyle>
                                        <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True"></PagerStyle>
                                        <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                        <AlternatingRowStyle CssClass="sublinkodd" BackColor="#78A8FA"></AlternatingRowStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <iframe id="FrmImg" runat="server" visible="false" width="100%" height="500px"></iframe>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <%-- <asp:AsyncPostBackTrigger ControlID="btnnext" EventName="Click"></asp:AsyncPostBackTrigger>--%>
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
            
         <div id="divmain" runat="server">
             <div  id="divPannel1" runat="server">
                     <div class="row rowspacing">
                                 <div class="col-sm-10" style="text-align:left">
                              <asp:Label ID="lblCnddtls" runat="server" CssClass="control-label" style="font-size:19px;color:#00cccc"></asp:Label>&nbsp&nbsp&nbsp&nbsp
                                        <asp:Label ID="lblhead" runat="server" Text="Raised CFR's" CssClass="control-label" style="color:#9c9c9a;font-size:19px"></asp:Label>&nbsp&nbsp&nbsp&nbsp
                                     <asp:Label ID="lbldocupld" runat="server" Text="Documents Details" CssClass="control-label" style="color:#9c9c9a;font-size:19px" Visible="false"></asp:Label>
                                 </div>
                      <div class="col-sm-2" style="text-align:left">
                        <asp:LinkButton ID="lblCndView" runat="server" Text="View Details" OnClick="lblCndView_Click"></asp:LinkButton>
                           </div>
                             </div>
                     <div id="Tremcode" runat="server">
                    <div class="row spacebetnrow" id="trmsg" runat="server">
                            <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="red"></asp:Label>
                            <asp:Label ID="lblSuccessMsg" runat="server" Visible="false" ForeColor="red"></asp:Label>
                       
             </div>
                    
                         <div class="row spacebetnrow" style="text-align:left">
                              <div class="col-sm-12">
                                   <asp:Label ID="lblTitle" runat="server" CssClass="control-label HeaderColor"></asp:Label>
                              </div>
                         </div>

                             <div class="row rowspacing" style="text-align:left;display:none">
                                 <div class="col-sm-4">
                                      <%--<asp:Label ID="lblFrenchName" Text="Franchisee Code" runat="server" CssClass="control-label"></asp:Label>--%>
                      
                           
                        
                           
                                 </div>
                                 <div class="col-sm-4">
                                      <asp:Label ID="lblCndName" runat="server"  CssClass="control-label"></asp:Label>
                           
                       
                            
                                 </div>
                             </div>
                         <div class="row rowspacing" style="text-align:left;display:none" >
                             <div class="col-sm-4">
                                  <asp:Label ID="lblFrenchiseeCode" runat="server" CssClass="control-label"></asp:Label>
                             </div>
                             <div class="col-sm-4">
                                
                             </div>
                             </div>
                            

                             <div class="row rowspacing" style="text-align:left">
                                 <div class="col-sm-4">
                                        <asp:Label ID="lblFrechiseeName" Text="Franchisee Name" runat="server" CssClass="control-label"></asp:Label>
                        
                        
                           
                                 </div>
                                  <div class="col-sm-4">
                                       
                                       <asp:Label ID="lblSMName" runat="server" CssClass="control-label"></asp:Label>
                        
                           
                             </div>
                                 <div class="col-sm-4">
                                     <asp:Label ID="lblMemCode" runat="server" Text="Member Code" CssClass="control-label"></asp:Label>
                                     
                                 </div>
                                 </div>
                         <div class="row " style="text-align:left">
                             <div class="col-sm-4">
                                    <%--<asp:Label ID="lblAdvNameValue" runat="server" CssClass="control-label"></asp:Label>--%>
                                 <asp:TextBox ID="lblAdvNameValue" runat="server" Enabled="false" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                       ></asp:TextBox><br />
                       
 </div>
                             <div class="col-sm-4">
                                  <%--<asp:Label ID="lblSMNameValue" runat="server" CssClass="control-label"></asp:Label>--%>
                                  <asp:TextBox ID="lblSMNameValue" runat="server" Enabled="false" CssClass="form-control"  onChange="javascript:this.value=this.value.toUpperCase();"
                                       ></asp:TextBox><br />
                             </div>
                             <div class="col-sm-4">
                                  <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                <ContentTemplate>
                                  
                                    <asp:TextBox ID="txtMemberCode" runat="server" Enabled="false" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                        MaxLength="30"  TabIndex="6"  onblur="CheckSpaces();return false;"></asp:TextBox><br />
                                    

                                </ContentTemplate>
                            </asp:UpdatePanel>
                             </div>
                         </div>
                          <div class="row " style="text-align:left">
                              <div class="col-sm-4">
                                  <asp:Label ID="lblFrnchcode" runat="server" Text="Franchisee Code" CssClass="control-label"></asp:Label>
                              </div>
                               <div class="col-sm-4">
                                   <asp:Label ID="lblMobileNo" Text="Mobile No " runat="server" CssClass="control-label"></asp:Label>
                              </div>
                               <div class="col-sm-4">
                                   <asp:Label ID="lblPAN" runat="server" Text="PAN No " Font-Bold="False" CssClass="control-label"></asp:Label>
                              </div>
                          </div>
                           <div class="row " >
                                 <div class="col-sm-4" >
                                      <asp:TextBox ID="txtFrenchCode" runat="server" Enabled="false" CssClass="form-control" 
                                onChange="javascript:this.value=this.value.toUpperCase();"
                                MaxLength="30" TabIndex="7"></asp:TextBox>&nbsp;
                              </div>
                               <div class="col-sm-1">
                                    <asp:TextBox ID="txtmobilecode" runat="server" Text="91" CssClass="form-control" style="margin-right: 30px;width: 59%;"
                                Enabled="false" ></asp:TextBox>
                               </div>
                               <div class="col-sm-3">
                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" Enabled="false" CssClass="form-control"  style="width: 115%;margin-left: -47px;"
                                ></asp:TextBox><%-- onblur="form2();"--%>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                FilterMode="InvalidChars" TargetControlID="txtMobileNo" FilterType="Custom">
                            </ajaxToolkit:FilteredTextBoxExtender>
                              </div>
                               <div class="col-sm-4">
                                   <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" Enabled="false" CssClass="form-control"
                                        onChange="javascript:this.value=this.value.toUpperCase();" ></asp:TextBox>
                                   
                                    <br />
                                    <asp:Label ID="lblPANMsg" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                    <asp:HiddenField ID="hdnPanDtls" runat="server"></asp:HiddenField>
                                    <%--Added by pranjali on 14-03-2014--%>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                              </div>
                          </div>

                          <div class="row " style="text-align:left;">
                              <div class="col-sm-4">
                                  <asp:Label ID="lblBranch" runat="server" CssClass="control-label"></asp:Label>
                                  </div>
                              <div class="col-sm-4">
                                  <asp:Label ID="lblEmail" runat="server" Text="Email " CssClass="control-label"></asp:Label>
                                  

                              </div>
                              <div class="col-sm-4">
                                   <asp:Label ID="lblSponsorDt" Text="Sponsor Date" runat="server" CssClass="control-label"></asp:Label>
                       
                           
                              </div>
                          </div>
                         <div class="row " style="text-align:left;">
                              <div class="col-sm-4">
                                   <%--<asp:Label ID="lblBranchValue" runat="server" CssClass="control-label"></asp:Label>--%>
                                  <asp:TextBox ID="lblBranchValue" runat="server" CssClass="form-control" Enabled="false" 
                                ></asp:TextBox>
                                  </div>
                             <div class="col-sm-4">
                                  <asp:TextBox ID="txtEMail" runat="server" CssClass="form-control" Enabled="false" 
                                onblur="validateEmail1(this.value)"></asp:TextBox><%--onblur="validateEmail1(this.value)"--%>
                            <asp:Label ID="lblEmailMsg" runat="server" CssClass="control-label" Font-Size="X-Small"></asp:Label>
                             </div>
                              <div class="col-sm-4">
                                   <%--<asp:Label ID="lblSponsorDtValue" runat="server" CssClass="control-label"></asp:Label>--%>
                                  <asp:TextBox ID="lblSponsorDtValue" runat="server" CssClass="form-control" Enabled="false" 
                                ></asp:TextBox>
                             </div>
                         </div>
                         </div>
                         </div>
              </div>
           <%-- Added by sanoj forHNIN bank details  05062023--%>
                   <div id="memberBnkDtls" runat="server" visible="false" >
                            <div id="Div27" runat="server">
                                <div class="row rowspacing">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="Label51" runat="server" Text="Member Account Details" CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                             <div id="Nombankdtl" runat="server" style="text-align:left;margin-top:10px;">
                                <div class="row ">
                                    <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblnmbnkhldname" runat="server" Text="Account Holder Name" CssClass="control-label labelSize"></asp:Label>
                                    <asp:TextBox ID="ddlnmbnkhldname" runat="server" CssClass="form-control mandatory" TabIndex="82" MaxLength="50"
                                     onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender96" runat="server"
                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" "
                                        TargetControlID="ddlnmbnkhldname">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                                    <div class="col-sm-4">
                                        <asp:Label ID="lblnmbnkacno" runat="server" Text="Account No" CssClass="control-label labelSize"></asp:Label>
                                        <asp:TextBox ID="txtnmbnkacno" runat="server" CssClass="form-control mandatory" TabIndex="83"  MaxLength="20" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender88" runat="server"
                                    FilterType="Custom,Numbers"
                                    TargetControlID="txtnmbnkacno">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                     <div class="col-sm-4">
                                        <asp:Label ID="lblnmifscode" runat="server" Text="BANK IFSC Code" CssClass="control-label labelSize"></asp:Label>
                                        <asp:TextBox ID="ddlnmifscode" runat="server" CssClass="form-control mandatory" TabIndex="87" MaxLength="11" onblur="NomieeIfsc();"></asp:TextBox>
                                    </div>
                                      <div class="col-sm-1" style=" text-align: right; display:none;">
                                                <asp:LinkButton ID="btnifsc2" runat="server" CssClass="btn btn-success" Width="100%" Height="89%" TabIndex="113" OnClick="btnifsc2_Click"
                                                    >
                                     <span class="glyphicon glyphicon-search" style='color:White;'></span>  
                                                </asp:LinkButton>
                                            </div>
                                  
                                </div>
                                  <div class="row rowspacing">
                                        <div class="col-sm-4">
                                        <asp:Label ID="lblnmddlactype" runat="server" Text="Account Type" CssClass="control-label labelSize"></asp:Label>
                                        </div>
                                      <div class="col-sm-4">
                                        <asp:Label ID="lblnmBrnchname" runat="server" Text="Branch Name" CssClass="control-label labelSize"></asp:Label>

                                        </div>
                                      <div class="col-sm-4">
                                    <asp:Label ID="lblnmBnkname" runat="server" Text="Bank Name" CssClass="control-label labelSize"></asp:Label>

                                        </div>
                                    </div>
                                <div class="row">
                                      <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlnmddlactype" runat="server" CssClass="form-control form-select mandatory" Style="width: 100%" TabIndex="85" >
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Saving" Value="Saving"></asp:ListItem>
                                            <asp:ListItem Text="Current" Value="Current"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="ddlnmBrnchname" runat="server" CssClass="form-control mandatory" TabIndex="86" ></asp:TextBox>
                                    </div>
                                      <div class="col-sm-4">
                                          <asp:TextBox ID="ddlnmBnkname" runat="server" CssClass="form-control mandatory" TabIndex="84"  onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                        </div>
                                    </div>
                                <div class="row rowspacing">
                                   
                                    <div class="col-sm-4">
                                        <asp:Label ID="lblnmmicr" runat="server" Text="MICR Code" CssClass="control-label labelSize"></asp:Label>
                                        <asp:TextBox ID="txtnmmicr" runat="server" CssClass="form-control " TabIndex="88" MaxLength="9" ></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender95" runat="server"
                                            FilterType="Custom,Numbers"
                                            TargetControlID="txtnmmicr">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                </div>
                            </div>
                    </div>
            <%-- Endde by sanoj 05062023--%>

        <div class="row rowspacing" style="display:none;">
            <div class="col-sm-12" style="text-align:right">
                <asp:ImageButton ID="Img2" runat="server" Visible="true" ForeColor="Red" OnClientClick="CloseSub()" ImageUrl="~/theme/iflow/Error.JPG" />
            </div>
        </div>
        <table style="width: 100%">
            <tr>
                <td align="right" colspan="4">
                    <%-- <asp:ImageButton ID="Img2" runat="server" Visible="true" ForeColor="Red" OnClientClick="CloseSub()" src="~/theme/iflow/Error.JPG"/>--%>
                    

                </td>
            </tr>
        </table>
        <div id="divSearchDetails" runat="server" style="display:none">

            <table style="width: 90%" class="tableIsys">
                <tbody>
                  
                    <tr>
                        <td class="test" align="left" colspan="4">
                           
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                           

                        </td>
                    </tr>
                    <%--Added by rachana on 29-07-2013 for toggle of agent details start--%>
                </tbody>
            </table>
            <table style="width: 90%" class="formtable table-condensed">
                <tr>
                    <td class="test" colspan="4">
                        <%--//added by pranjali for id on 11-04-2014--%>
                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnUploadDtls"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divagndetails', 'ctl00_ContentPlaceHolder1_btnUploadDtls');" />
                        
                    </td>
                </tr>
            </table>
            <div id="divIsSpecified" runat="server" style="display: block;">
                <asp:UpdatePanel ID="Updatepanel114" runat="server">
                    <ContentTemplate>
                        <table class="tableIsys" style="width: 90%;">
                            <tr>
                                <td class="formcontent" style="width: 20%;">
                                    <asp:Label ID="lblIsSPFlag" runat="server" CssClass="control-label"></asp:Label>
                                </td>
                                <td style="width: 30%;" class="formcontent">
                                    <asp:UpdatePanel ID="UpdIsSPFlag" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rbtIsSP" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                Visible="true" TabIndex="25" Enabled="false">
                                                <%--AutoPostBack="true" OnSelectedIndexChanged="rbtIsSP_SelectedIndexChanged"--%>
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width: 20%;" class="formcontent"></td>
                                <td style="width: 30%;" class="formcontent"></td>
                            </tr>
                            <tr id="tr_IsSPDtls" visible="false" runat="server">
                                <td class="formcontent" style="width: 20%;">
                                    <asp:UpdatePanel ID="Updatepanel15" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblCACode" runat="server" CssClass="control-label"></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="width: 30%;">
                                    <asp:UpdatePanel ID="Updatepanel16" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCACode" runat="server" CssClass="form-control" MaxLength="20"
                                                Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();"> 
                                            </asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender77" runat="server"
                                                InvalidChars=",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                FilterMode="InvalidChars" TargetControlID="txtCACode" FilterType="Custom">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="width: 20%;">
                                    <asp:UpdatePanel ID="Updatepanel17" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblCAName" runat="server" CssClass="control-label"></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="width: 30%;">
                                    <asp:UpdatePanel ID="Updatepanel118" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCAName" runat="server" CssClass="form-control" MaxLength="20"
                                                Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();">
                                          
                                            </asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender76" runat="server"
                                                InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" FilterMode="InvalidChars"
                                                TargetControlID="txtCAName" FilterType="Custom">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div runat="server" id="divagndetails" style="display: none">
                <%--Added by rachana on 29-07-2013 for toggle of agent details end--%>
                <table runat="server" id="tbltest" style="width: 90%" class="tableIsys">
                    <tr  >
                        <td style="width: 20%; height: 20px"  class="formcontent" align="left">
                            <asp:Label ID="lblCndNo" runat="server" Visible="false" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblCndNoValue"  Visible="false" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left" colspan="2">
                            <asp:Label ID="lblAdvWaiver" Text="Advisor Waiver" Visible="false" runat="server"></asp:Label>
                           <%-- <asp:LinkButton ID="lblCndView" runat="server" Text="View Details" OnClick="lblCndView_Click"></asp:LinkButton>--%>
                            <asp:CheckBox ID="chkAdvWaiver" runat="server" Visible="false" AutoPostBack="true"
                                OnCheckedChanged="chkAdvWaiver_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAdvisorWaiver" runat="server" Visible="false" Text="Waiver Advisor"
                                Width="100" CssClass="standardbutton" />
                            <asp:HiddenField ID="hdnAdvWaiver" runat="server" />
                            <asp:HiddenField ID="hdnCsccode" runat="server" />
                        </td>
                    </tr>

                    <tr id='trMob' runat="server" visible="false">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">

                            <asp:Label ID="Label11" Text="Mobile No" runat="server" CssClass="control-label"></asp:Label>

                        </td>

                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblmobile" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">

                            <asp:Label ID="Label12" runat="server" Text="PAN No" Font-Bold="False" CssClass="control-label"></asp:Label>

                        </td>

                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblpanno" runat="server" Font-Bold="False"></asp:Label>
                        </td>

                    </tr>
                    <tr id='trAgency' runat="server" visible="false">

                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="Label13" runat="server" Text="Agency Code" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblagencycodeValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lbldateissue" runat="server" Text="Date of Issue of Appointment" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lbldateissuevalue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>


                    <%--  usha 03.07.2015--%>
                    <tr id="trdos" runat="server" visible="false">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">

                            <asp:Label ID="lbldos" runat="server" Text="Date of Submission" Font-Bold="False"></asp:Label>

                        </td>
                        <td class="formcontent" style="width: 20%;">
                            <asp:Label ID="lbldate" runat="server" Font-Bold="False"></asp:Label>
                        </td>

                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lbldoa" runat="server" Text="Date of acceptance of resignation" Font-Bold="False"></asp:Label>

                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lbldoar" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trBranch" runat="server">
                        <%-- commented by pranjali on 27-12-2013--%>
                        <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchCode" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchCodeValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                        <%-- commented by pranjali on 27-12-2013--%>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                          
                        </td>
                    </tr>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSalesUnitCode" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSalesUnitCodeValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                    <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMName" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMNameValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--<tr>
                        <td style="height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnStartDate" runat="server" Text="Training Start Date" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 160px; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnStartDateValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnEndDate" runat="server" Text="Training End Date" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 210px; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnEndDateValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <tr id="trRequest" runat="server">
                       
                       <%-- <td style="width: 20%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblSponsorDt" Text="Sponsor Date" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblSponsorDtValue" runat="server" Font-Bold="True"></asp:Label>
                        </td>--%>
                    </tr>
                   <%-- Added by sanoj 27-12-2021--%>

                    <tr id="tr11" runat="server">
                        <td class="formcontent" style="width: 20%;">
                            <span style="color: red">
                                
                                *</span>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                           
                        </td>
                        <td class="formcontent" style="width: 20%;">
                            <span>
                                </span>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                           
                                                   
                           
                        </td>
                    </tr>
                    <%-- Added by sanoj 27-12-2021--%>




                    <tr id="trGivenName" runat="server">
                        <td class="formcontent" style="width: 20%;">
                            <span style="color: red">
                                <asp:Label ID="lblpfgivenName" runat="server" Text="Given Name" CssClass="control-label"></asp:Label>
                                *</span>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:UpdatePanel ID="UpdPanelAgtType" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="cboTitle" runat="server" CssClass="standardmenu" 
                                        Enabled="false" Width="65px" TabIndex="5"></asp:TextBox>
                                    <asp:TextBox ID="txtGivenName" runat="server" CssClass="form-control" Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();"
                                        MaxLength="30" Width="162px" TabIndex="6"  onblur="CheckSpaces();return false;"></asp:TextBox><br />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_GivenName" runat="server"
                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtGivenName" ValidChars=" " FilterMode="ValidChars">
                                    </ajaxToolkit:FilteredTextBoxExtender>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="formcontent" style="width: 20%;">
                            <span>
                                <asp:Label ID="lblpfSurName" runat="server" Text="Surname" CssClass="control-label"></asp:Label></span>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:TextBox ID="txtname" runat="server" CssClass="form-control" Enabled="false" 
                                onChange="javascript:this.value=this.value.toUpperCase();"
                                MaxLength="30" TabIndex="7"></asp:TextBox>&nbsp;
                                                    <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtname" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom"
                                TargetControlID="txtname">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr id="trFatherName" visible="false" runat="server">
                        <td class="formcontent" style="width: 20%;">
                            <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblpffathername" runat="server" Text="Father name" CssClass="control-label"></asp:Label>
                                *</span>
                            <%--<span style="color: #ff0000">*</span>--%>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:TextBox ID="txtFathername" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                MaxLength="60" TabIndex="8" Width="230px"  onblur="AllowSpace();return false;"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_FatherName" runat="server"
                                InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" ValidChars=" " FilterMode="ValidChars"
                                TargetControlID="txtFathername" FilterType="LowercaseLetters, UppercaseLetters,Custom">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <%-- <asp:TextBox id="txtFathername"  runat="server" CssClass="form-control"  
                                                        onChange="javascript:this.value=this.value.toUpperCase();"  MaxLength="60" 
                                                        TabIndex="8" onblur="AllowSpace();return false;" ></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_FatherName" runat="server"
                                                        InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" ValidChars=" " FilterMode="InvalidChars"
                                                        TargetControlID="txtFathername" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                        </td>
                        <td class="formcontent" style="width: 20%;">
                            <%-- <span style="color: red">--%><%--Added by shreela on 6/03/14 to remove space--%>
                            <asp:Label ID="lblpfGender" runat="server" Text="Gender" CssClass="control-label"></asp:Label>
                            <%-- *</span>--%>
                            <%-- <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:TextBox ID="cboGender" runat="server" CssClass="standardmenu" 
                                Enabled="false" Width="182px" TabIndex="9"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trMobile" runat="server">
                        <td style="width: 20%; height: 38px" class="formcontent" align="left">
                            <span style="color: Red">
                                *</span>
                            <%--  added by shreela on 10/03/14--%>
                            <%--  <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td style="width: 30%; height: 38px" class="formcontent" align="left">
                          
                            <%-- added by shravana 14jun2013--%>
                           
                          
                            <asp:Label ID="lblmobileverify" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                            <%--Added by rachana on 14-08-2013 to verify email end--%>
                            <%-- added by shravana 14jun2013--%>
                        </td>
                        <td style="width: 20%; height: 38px" class="formcontent" align="left">
                            <span style="color: Red">
                                *</span>
                            <%--  added by shreela on 10/03/14--%>
                            <%--  <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td style="width: 30%; height: 38px" class="formcontent" align="left">
                            
                        </td>
                    </tr>

                    <tr id="trEmail" runat="server">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <span style="color: Red">
                                *</span>
                            <%--  added by shreela on 10/03/14--%>
                            <%-- <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            
                            <%--Added by rachana on 14-08-2013 to verify email end--%>
                            <%-- added by shravana14jun2013--%>
                        </td>
                        <%--ank strt 12.01.2011--%>
                        <%--   lblpandetail disply none by sanoj--%>
                        <td style="display:none; width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblpandetail" runat="server" Text="Is Pan name different from registered name"
                                Font-Bold="False"></asp:Label>
                        </td>

                         <td style="width: 20%; height: 16px" class="formcontent" align="left">
                            
                        </td>

                        
                    </tr>

                    <%-- added by usha CR 17 for Aadhaar  no on 08.08.017 --%>


                    <tr id="TrAadhar" visible="false" runat="server">

                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <span style="color: Red">
                                <asp:Label ID="LblAadharId" runat="server" CssClass="control-label"></asp:Label>*</span>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:TextBox ID="TxtAadharId" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>

                        </td>
                        <td runat="server" class="formcontent" style="width: 20%;">
                            <asp:Label ID="LblAadharVerfy" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>
                        </td>
                        <td align="left" runat="server" class="formcontent" style="width: 20%;">
                            <asp:TextBox ID="TxtAadharVerfy" Enabled="false" runat="server" CssClass="form-control"  Width="182px">
                            </asp:TextBox>
                        </td>
                    </tr>




                    <%--  added by shreela 21032014--%>
                    <tr id="trlicn" runat="server" visible="false">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblLicnno" runat="server" Text="License No" CssClass="standardlabel"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:TextBox ID="txtlicno" runat="server" CssClass="form-control" ></asp:TextBox>
                            <asp:Label ID="lbllicnoval" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblLicExpDt" runat="server" Text="LicenseExpDate" CssClass="standardlabel"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:TextBox ID="txtLicExpDt" runat="server" CssClass="form-control" ></asp:TextBox>
                        </td>
                    </tr>
                      <%--Added by usha on 01.06.2021 --%>  
                                                 <tr ID="TrRptMgr" runat="server" visible="false">
                                          <td nowrap="nowrap" align="left" class="formcontent" style="width: 20%">
                                           <asp:Label ID="LblRptMgrCode" Text="Additional Reporting Manager" runat="server"></asp:Label>
                                              </td>
                                               <td nowrap="nowrap" align="left" class="formcontent" style="width: 20%">
                                              <asp:Label ID="lblRptMgr" runat="server"></asp:Label>
                                              </td>
                                                <%--Added by usha on 01.06.2021 --%>  
                                                    <td class="formcontent" id="Td18"   runat="server" style="width: 20%;"> 
                                                 <asp:Label ID="LblAnnivrsryDt"  text ="Anniversary Date" runat="server" Font-Bold="False"  CssClass="control-label"></asp:Label>
                                                    </td>
                         <td style="width: 20%; height: 20px" class="formcontent" align="left">
                             <asp:Label ID="LblAnnivrsry"   runat="server" Enabled ="false" ></asp:Label>
                         </td>
                                                 </tr>  
                    <%--  added by shreela 21032014--%>
                    <%--added by rachana on 14032013 for fees Details start--%>
                    <%--added by rachana on 14032013 for fees Details end--%>
                    <!--ank end 12.01.2011-->
                    <%--</tbody>--%>
                    <tr align="center" style="display: none">
                        <td>
                            <asp:Label ID="LabelFees" runat="server" Visible="false" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <%--  added cr 17  by usha for aadhar   on 08.08.017--%>
                <table class="formtable" style="width: 90%;">

                    <tr id="TrAdhrQcCnfrm" visible="false" runat="server">
                        <td class="formcontent">
                            <span style="color: Red">
                                <asp:Label ID="LblAdhrQcCnfrm" runat="server" Text="Confirm manual verification of aadhar details :" CssClass="control-label"></asp:Label>*</span>
                        </td>
                        <td class="formcontent">
                            <asp:RadioButtonList ID="QCConfirmAadhar" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px">
                                <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True" Text="No"></asp:ListItem>
                            </asp:RadioButtonList>

                        </td>
                        <td class="formcontent"></td>

                    </tr>
                    <%--  ended by usha--%>
                </table>
            </div>
        </div>
        <table id="tblIcmColl" visible="false" runat="server" style="width: 90%" class="tableIsys">
            <tr>
                <td align="left" class="test" colspan="4">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnICMDtls"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivICMDtls', 'ctl00_ContentPlaceHolder1_btnICMDtls');" />
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Payment Details"></asp:Label>
                </td>
            </tr>
        </table>
        <div runat="server" id="DivICMDtls" style="display: none">
            <table runat="server" id="tblICMDtls" class="tableIsys" style="width: 90%;">
                <tr id="FeesRow" runat="server" visible="true">
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <span id="spwebtoken" runat="server" style="color: Red">
                            <asp:Label ID="lblWebTknReceived" Text="Fees Collected" runat="server" CssClass="control-label"></asp:Label>*</span>
                        <%--  added by shreela on 10/03/14--%>
                        <%-- <span id="spwebtoken" runat="server" style="color: #ff0000">*</span>--%>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left" nowrap="nowrap">
                        <asp:UpdatePanel ID="updChkFees" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chkWebTknRecd" runat="server" OnCheckedChanged="chkWebTknRecd_CheckedChanged"
                                    AutoPostBack="true" Enabled="false" Visible="false" />
                                <%--<asp:TextBox ID="txtFeesRcvd" runat="server" CssClass="form-control" Width="130px" TabIndex="10" Visible="false"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FTEFees" runat="server" InvalidChars="/.\?<>{}[];:|=+_,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                   FilterMode="InvalidChars" TargetControlID="txtFeesRcvd" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                <asp:HiddenField ID="hdnVerifyFees" runat="server"></asp:HiddenField>
                                <%--<asp:Button ID="btnGetFeeDetails" runat="server" Text="Get Details" width="80px"
                                CssClass="standardbutton" onclick="btnGetFeeDetails_Click" ></asp:Button>--%>
                                <asp:LinkButton ID="lnkGetFees" runat="server" Text="Get Fees" OnClick="lnkGetFees_Click" Enabled="false"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--<asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>--%>
                        <%--</ContentTemplate>
                              <Triggers><asp:AsyncPostBackTrigger ControlID="chkWebTknRecd" EventName="CheckedChanged" /></Triggers>
                              </asp:UpdatePanel>--%>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lbladvWaiverbtn" runat="server" Visible="false" Text="Upload Adv's Waiver Form"></asp:Label>
                        <span id="spwaiver" runat="server" visible="false" style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblAdvWaiverUpl" runat="server" Visible="false"></asp:Label>
                        <asp:FileUpload ID="AdvWaiverUpload" runat="server" Visible="false" Width="98%"></asp:FileUpload>
                        <asp:CustomValidator ID="CVAdvWaiverValidator" runat="server" ControlToValidate="AdvWaiverUpload"
                            OnServerValidate="CVAdvWaiverValidator_ServerValidate" SetFocusOnError="True"> </asp:CustomValidator>
                    </td>
                </tr>
                <tr id="trTokenwithFees" runat="server">
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblTknNo" runat="server" Text="Token No"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblTknNoValue" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblTotfees" runat="server" Text="Total Fees"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblTotfeesValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trTokenwithLatestFees" runat="server" style="display: none">
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblTknNoLst" runat="server" Text="Token No"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblTknNoLstDesc" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblTotfeesLst" runat="server" Text="Fees as on todays date"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblTotfeesLstDesc" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <%--New ICM Details Added by rachana on 30-04-2014 Start --%>
     <%--   Commented by sanoj 28-12-2021--%>
        <table id="tblICMManual" runat="server" width="90%" style="display:none">
            <tr>
                <td align="left" class="test" colspan="4">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnICM"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divICM', 'ctl00_ContentPlaceHolder1_btnICM');" />
                    <asp:Label ID="lblNICMTitle" runat="server" Font-Bold="True" Text="Fees Details Edit"
                        Width="860px"></asp:Label>
                </td>
            </tr>
        </table>
        <div runat="server" id="divICM" style="display: none">
            <table runat="server" id="tblICMDetails" class="tableIsys" style="width: 90%;">
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:Label ID="lblPymtMode" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="upldPayment" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DDlPymtMode" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                    Width="185px" OnSelectedIndexChanged="DDlPymtMode_SelectedIndexChanged" TabIndex="15">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblPymtAmt" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="updpayment" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPymtAmt" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEAmt" runat="server" InvalidChars="/\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                    FilterMode="InvalidChars" TargetControlID="txtPymtAmt" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:UpdatePanel ID="updchqlbl" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblChequeNo" runat="server" Font-Bold="False"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updchq" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtChequeNo" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEChqNo" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                    FilterMode="InvalidChars" TargetControlID="txtChequeNo" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:UpdatePanel ID="updchqdate" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblChequeDate" runat="server" Font-Bold="False"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="upddate" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtChequedate" runat="server" CssClass="form-control" TabIndex="22" />
                                <asp:Image ID="btncal" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox ID="txtcal" runat="server" CssClass="form-control" Style="display: none"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtChequedate"
                                    PopupButtonID="btncal" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                                    ControlToValidate="txtChequedate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:CompareValidator ID="COMPAREVALIDATOR1" runat="server" ErrorMessage="Invalid date!"
                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtChequedate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtChequedate"
                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:Label ID="lblBankName" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updbnkname" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEBnkName" runat="server" FilterType="LowercaseLetters, UppercaseLetters,Custom"
                                    ValidChars=" " TargetControlID="txtBankName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:Label ID="lblEFT" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="upldeft" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TextEFT" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEEFT" runat="server" InvalidChars="/.\?<>{}[];:|=+_,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                    FilterMode="InvalidChars" TargetControlID="TextEFT" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent2" colspan="4" style="width: 20%; height: 24px;">
                        <asp:UpdatePanel ID="updAdd" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="BtnAdd" runat="server" Text="Add" CssClass="standardbutton" Width="114px"
                                    OnClick="BtnAdd_Click"></asp:Button>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <%--New ICM Details Added by rachana on 30-04-2014 end --%>
        <asp:UpdatePanel ID="updgridfees" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table id="TblFees" style="width: 90%" class="formtable table-condensed" runat="server"
                    visible="false">
                    <tr>
                        <td colspan="4" align="left" class="test">
                            <input runat="server" type="button" value="+" id="btnfees" style="width: 20px;" onclick="ShowReqDtlNew('ctl00_ContentPlaceHolder1_divFees', 'ctl00_ContentPlaceHolder1_btnfees');"
                                class="btn btn-xs btn-primary" />
                            <asp:Label ID="lblFeesDtls" Text="Fees Collected Details" runat="server" Font-Bold="true"></asp:Label>
                            <%--shreela 24032014--%>
                        </td>
                    </tr>
                </table>
                <div id="divFees" runat="server" style="display: none;">
                    <table id="tblfeesdtl" style="width: 90%" class="tableIsys" runat="server">
                        <tr id="trfeesDetails1" runat="server">
                            <td style="height: 20px" class="formcontent">
                                <asp:GridView ID="dgPaymentdtls" runat="server" PagerStyle-HorizontalAlign="Center"
                                    CssClass="tableIsys" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                    RowStyle-CssClass="tableIsys" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True" Width="100%" OnRowDataBound="dgPaymentdtls_RowDataBound" OnRowCommand="dgPaymentdtls_RowCommand"
                                    OnRowDeleting="dgPaymentdtls_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField SortExpression="TokenNo" HeaderText="Token No" ItemStyle-Width="8%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTokenNo" runat="server" Text='<%# Eval("TokenNo") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="PaymentMode" HeaderText="Payment Mode" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPymtMode" runat="server" Text='<%# Eval("PaymentMode") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="PaymentDate" HeaderText="Payment Date" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPymtDt" runat="server" Text='<%# Eval("PaymentDate","{0:dd/MM/yyyy}") %>'
                                                    Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="BankName" HeaderText="Bank Name" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("BankName") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="InstrumentNo" HeaderText="Instrument No" ItemStyle-Width="13%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInstrumentNo" runat="server" Text='<%# Eval("InstrumentNo") %>'
                                                    Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="InstrumentDate" HeaderText="Instrument Date" ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInstrumentDt" runat="server" Text='<%# Eval("InstrumentDate","{0:dd/MM/yyyy}") %>'
                                                    Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Amount" HeaderText="Amount" ItemStyle-Width="6%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPymtAmt" runat="server" Text='<%# Eval("Amount") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="TrxNo" HeaderText="Transaction No" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTrxNo" runat="server" Text='<%# Eval("TrxNo") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ReceiptNo" HeaderText="Receipt Id" ItemStyle-Width="7%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRcptId" runat="server" Text='<%# Eval("RcptNo") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="DeleteBtn" Text="Delete" CommandName="Delete" runat="server" Enabled="false" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                            <ControlStyle Font-Underline="True" />
                                            <FooterStyle Font-Underline="False" />
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="standardlink" HorizontalAlign="Center" />
                                    <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black"></PagerStyle>
                                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="Small"></RowStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <%--<ajax:AsyncPostBackTrigger ControlID="btnGetFeeDetails" EventName="Click" />--%>
                <ajax:AsyncPostBackTrigger ControlID="lnkGetFees" EventName="Click" />
                <ajax:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

<div id="div3" runat="server">
                     <div id="tblCFRInboxCollapse" style="display:none; width: 90%" class="formtable table-condensed panelheadingAliginment"
            runat="server"></div>

            <div id="divCFRInbox" runat="server" style="display: none" class="panel-body panelContent">
                <div id="tblCFRInbox" runat="server">
                    <div class="row" style=" width:95%">
                        <div class="col-sm-6" style="margin-bottom: 12px;margin-left: -181px;">
                            <asp:Label ID="lblcfrraised" runat="server" Text="Raised CFR" CssClass="control-label labelSize " >

                        </asp:Label>&nbsp;&nbsp;
                        <asp:Label ID="lblcfrraisedcount" runat="server" CssClass="badge" ></asp:Label>&nbsp;&nbsp;

                         <asp:Label ID="lblresponded" runat="server" Text="Responded CFR" CssClass="control-label labelSize ">

                         </asp:Label>&nbsp;&nbsp;
                           <asp:Label ID="lblcfrrespondedcount" runat="server" CssClass="badge" ></asp:Label>
                         </div>
                         
                        <div class="col-sm-3" style="text-align:left">
                         </div>
                        <div class="col-sm-3" style="text-align:left">
                         </div>
                        </div>

                      <asp:GridView  ID="dgDetailsInbox" runat="server"  AutoGenerateColumns="False" AllowPaging="True"
                            Width="100%" OnRowCommand="dgDetailsInbox_RowCommand" CssClass="footable"
                            OnPageIndexChanging="dgDetailsInbox_PageIndexChanging" PageSize="5"
                            OnRowDataBound="dgDetailsInbox_RowDataBound">
                           <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                       <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderStyle-Wrap="false" ItemStyle-Width="6%">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkAssigned" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="CFR Remark" HeaderText="CFR Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRRemarks") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle CssClass="clsLeft"/>
                                      <HeaderStyle CssClass="clsLeft" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR Raised For">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcfr" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle CssClass="clsLeft"/>
                                    <HeaderStyle CssClass="clsLeft" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="RemarkId" HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarkid" runat="server" Text='<%# Eval("RemarkId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="Responded" HeaderText="Responded">
                                    <ItemTemplate>
                                        <asp:Label ID="Responded" runat="server" Text='<%# Eval("Responded") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle CssClass="clsLeft"/>
                                    <HeaderStyle CssClass="clsLeft" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Responded" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCFRRemarkID" runat="server" Text='<%# Eval("CFRRemarkID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRaisedFlag" runat="server" Text='<%# Eval("RaisedFlag") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCFRDocCode" runat="server" Text='<%# Eval("DocCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCFRFlagType" runat="server" Text='<%# Eval("CFRFlagType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkReopen" Style="text-align: center;" runat="server" Text="ReOpen CFR" CommandArgument='<%# Eval("RemarkId") %>'
                                            CommandName="ReopenCFR" Visible="false"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddnlRemark" runat="server" Text='<%# Eval("AddnlRemark") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>
                

                <div class="row rowspacing" style="text-align:left;font-size: 19px;color:#00cccc;">
                     <asp:Label ID="lblTitleRemarks" Visible="false" runat="server" Text="Remarks" Font-Bold="true"></asp:Label>
                </div>

                 <asp:GridView  ID="GridRemarks" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%"
                            OnPageIndexChanging="GridRemarks_PageIndexChanging" PageSize="5" CssClass="footable">
                     <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                       <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField SortExpression="Date" HeaderText="Date" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                    
                                   <ItemStyle CssClass="clscenter"/>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="CFRRemark" HeaderText="Remarks" ItemStyle-Width="70%">
                                    <ItemTemplate>
                                        <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRRemark") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle CssClass="clscenter"/>
                                </asp:TemplateField>
                            </Columns>
                              
                        </asp:GridView>
            </div>
                         </div>
        </div>


        <%--Fees Wavier Added by amrurta on 24-07-2015 start --%>
        <asp:UpdatePanel ID="UpdFeesWavier" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table id="tblFeesWavier" style="width: 90%" class="formtable table-condensed" runat="server"
                    visible="false">
                    <tr>
                        <%--<td class="test" style="width: 5%">
                         <asp:CheckBox ID="ChkFeesWavier" runat="server" />
                       </td>--%>
                        <td class="test">
                            <asp:CheckBox ID="ChkFeesWavier" runat="server" AutoPostBack="true" OnCheckedChanged="ChkFeesWavier_CheckedChanged" />
                            <%--<input runat="server" type="button" value="+" id="btnFeesWavier" style="width: 20px;" onclick="ShowReqDtlNew('ctl00_ContentPlaceHolder1_divFeesWavier','ctl00_ContentPlaceHolder1_btnFeesWavier');"
                                class="btn btn-xs btn-primary" />--%>
                            <asp:Label ID="lblFeesTitle" Text="Fees Wavier Details" runat="server" Font-Bold="true"></asp:Label>

                        </td>
                    </tr>
                </table>


            </ContentTemplate>
        </asp:UpdatePanel>
        <%--Fees Wavier Added by amrurta on 24-07-2015 end --%>
        <%--added by pranjali on 11-04-2014 start--%>
         <%--   tblEmsdtls disply none payment section by sanoj--%>
        <asp:UpdatePanel ID="updtblEmsdtls" runat="server">
            <ContentTemplate>
                <table id="tblEmsdtls" runat="server" style="display:none; width: 90%" class="formtable table-condensed">
                    <tr>
                        <td class="test" colspan="4">
                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnExmDtls"
                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgnPhotoTrnExmDtl', 'ctl00_ContentPlaceHolder1_btnExmDtls');" />
                            <asp:Label ID="lblExamTitle" runat="server" Font-Bold="True"></asp:Label>
                            <%--Text="Exam Details"--%>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
           <%--   divAgnPhotoTrnExmDtl disply none payment section by sanoj--%>
        <div runat="server" id="divAgnPhotoTrnExmDtl" visible="true" style="display:none">
            <asp:UpdatePanel ID="updexamdetailforqc" runat="server">
                <ContentTemplate>
                    <table runat="server" id="tblexam" class="tableIsys" style="width: 90%;">
                        <%--   <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblExamTitle" runat="server" Font-Bold="True" Text="Exam Details"></asp:Label>
                    </td>
                </tr>--%>
                        <%--    added by amruta on 16.6.15 start--%>
                        <tr id="trCndExm3" runat="server">
                            <td id="tdExmmode1" runat="server" class="formcontent" style="width: 20%; height: 24px;">
                                <span style="color: Red">
                                    <asp:Label ID="lblExam" runat="server" CssClass="control-label" Font-Bold="False"> </asp:Label>
                                    *</span>
                            </td>
                            <td id="tdExmmode2" runat="server" class="formcontent" style="width: 30%; height: 24px;">
                                <asp:UpdatePanel ID="updExam" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExam" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Width="185px" >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td id="tdExmCode1" runat="server" align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblExmCode" Text="Exam Code " runat="server" CssClass="control-label"> </asp:Label>*</span>
                            </td>
                            <td id="tdExmCode2" runat="server" class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="updExam1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExamCode" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Width="185px" >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td id="tdExmBody1" runat="server" align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblExmBody" runat="server" CssClass="control-label"></asp:Label>
                                    *</span>
                            </td>
                            <td id="tdExmBody2" runat="server" class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="UpdExmBody" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExmBody" runat="server" CssClass="standardmenu" Width="185px"
                                            >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>

                        </tr>
                        <%--   added by amruta on 16.6.15 end--%>
                        <%-- added by amruta on 15.6.15 for exam details start--%>
                        <tr id="trCndExm" runat="server">
                            <td class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblCanNo" runat="server" CssClass="control-label" Text="Candidate Number "></asp:Label>
                                <span style="color: red">*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtCanNo" runat="server"  CssClass="form-control"></asp:TextBox>
                                <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCanNo"
                            ErrorMessage="Candidate Number should be Numeric.!!" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                            </td>
                            <td class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblCanMark" runat="server" CssClass="control-label" Text="Candidate Marks "></asp:Label>
                                <span style="color: red">*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtCanMark" runat="server"  CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCanMark"
                                    ErrorMessage="Candidate Marks should be Numeric.!!" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <%-- <tr id="trCndExm4" runat="server">
                            <td class="formcontent" style="width: 20%; height: 24px;">
                                <span style="color: Red">
                                    <asp:Label ID="lblpreexamlng" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%; height: 24px;">
                                <asp:UpdatePanel ID="updPreExmLng" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu" Width="185px"
                                            >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
<%--                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblCentre" runat="server" CssClass="control-label"></asp:Label>*</span>
                            </td>--%>
                        <%--    <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="updExmCentre" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExmCentre" runat="server" CssClass="standardmenu" Width="185px"
                                             Visible="false">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtExmCentre" runat="server" Enabled="false" CssClass="form-control"
                                            Visible="true" ></asp:TextBox>
                                        <asp:Button ID="btnExmCentre" runat="server" CausesValidation="False" CssClass="standardbutton"
                                            Text="Search" />
                                        <input type="hidden" runat="server" id="hdnExmCentreCode" />
                                        &nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>--%>
                        </tr>
                        <caption>
                            --%&gt;
                            <tr id="trCndExm2" runat="server">
                                <td id="tdPreExm" runat="server" class="formcontent" style="width: 20%; height: 24px;"><span style="color: Red">
                                    <asp:Label ID="lblpreexamlng" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                                    *</span> </td>
                                <td id="tdPreExmlng" runat="server" class="formcontent" style="width: 30%; height: 24px;">
                                    <asp:UpdatePanel ID="updPreExmLng" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu" Width="185px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td id="tdExmCenter1" runat="server" align="left" class="formcontent" style="width: 20%;"><span style="color: Red">
                                    <asp:Label ID="lblCentre" runat="server" CssClass="control-label"></asp:Label>
                                    *</span> </td>
                                <td id="tdExmCenter2" runat="server" class="formcontent" style="width: 30%;">
                                    <asp:UpdatePanel ID="updExmCentre" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlExmCentre" runat="server" AutoPostBack="True" CssClass="standardmenu" Visible="false" Width="185px">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtExmCentre" runat="server" AutoPostBack="True" CssClass="form-control" Enabled="false" Visible="true"></asp:TextBox>
                                            <asp:Button ID="btnExmCentre" runat="server" CausesValidation="False" CssClass="standardbutton" Text="Search" />
                                            <input type="hidden" runat="server" id="hdnExmCentreCode" />
                                            &nbsp;
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td id="tdExmDt1" runat="server" align="left" class="formcontent" style="width: 20%;"><span style="color: red">
                                    <asp:Label ID="lblDtPass" runat="server" CssClass="control-label" Text="Date of Passing"></asp:Label>
                                    *</span> </td>
                                <td id="tdExmDt2" runat="server" class="formcontent" style="width: 30%;">
                                    <asp:TextBox ID="txtDateOfPass" runat="server" CssClass="form-control" TabIndex="10"></asp:TextBox>
                                    <asp:Image ID="btnCalendarDtPass" runat="server" Height="16px" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy" PopupButtonID="btnCalendarDtPass" TargetControlID="txtDateOfPass">
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RFVYrPass1" runat="server" ControlToValidate="txtYrPass" Display="Dynamic" Enabled="false" ErrorMessage="Mandatory!" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    &nbsp;
                                    <asp:CompareValidator ID="CompareValidator61" runat="server" ControlToValidate="txtYrPass" Display="Dynamic" ErrorMessage="Invalid date!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                    &nbsp;
                                    <asp:RangeValidator ID="RangeValidatorYrPass1" runat="server" ControlToValidate="txtYrPass" Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                </td>
                            </tr>
                        </caption>

                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
            <table id="tblExmSchedule" runat="server" style="width: 90%" class="tableIsys"
                visible="false">
                <tr>
                    <td class="test" align="left" colspan="2">
                        <asp:Label ID="Label4" runat="server" Text="Exam Schedule" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="test" align="left" colspan="2">
                        <asp:Label ID="Label5" Text="Preffered Exam Schedule" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblNWExmdt" runat="server" CssClass="control-label"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblNWExmdtValue" runat="server"></asp:Label>
                        <asp:Label ID="lblNwExmfrmt" runat="server" Text="(dd/mm/yyyy)"></asp:Label>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblExmdt1" Text="Preffered Exam Date 1" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblpref1value" runat="server"></asp:Label>
                        <asp:Label ID="lblprefformat1" runat="server" Text="(dd/mm/yyyy)"></asp:Label>
                    </td>
                </tr>
            </table>
            <table runat="server" id="tblPrefExm" class="tableIsys" style="width: 90%;"
                visible="false">
                <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <%--<asp:Label ID="Label5" Text="Preffered Exam Schedule" runat="server" Font-Bold="true"></asp:Label>--%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%; height: 38px" class="formcontent" align="left">
                        <%--<asp:Label ID="lblExmdt1" Text="Preffered Exam Date 1" runat="server"></asp:Label>--%>
                    </td>
                    <td style="width: 30%; height: 38px" class="formcontent" align="left">
                        <%-- <asp:Label ID="lblpref1value" runat="server"></asp:Label>
                        <asp:Label ID="lblprefformat1" runat="server" Text="(dd/mm/yyyy)"></asp:Label>--%>
                    </td>
                    <td style="width: 20%; height: 38px" class="formcontent" align="left">
                        <asp:Label ID="lblExmdt2" runat="server" Text="Preffered Exam Date 2" Font-Bold="False"
                            Visible="false"></asp:Label>
                        <%--<span style="color: #ff0000">*</span> --%>
                    </td>
                    <td style="width: 30%; height: 38px" class="formcontent" align="left">
                        <asp:Label ID="lblpref2value" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblprefformat2" runat="server" Text="(dd/mm/yyyy)" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <%-- Old Exam Details start--%>
        <table id="tbloldexm" runat="server" class="tableIsys" style="width: 90%;"
            visible="false">
            <tr>
                <td class="test" colspan="4" style="text-align: left;">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnOldExmDtls"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivOldExmdtls', 'ctl00_ContentPlaceHolder1_BtnOldExmDtls');" />
                    <asp:Label ID="lbloldexm" runat="server" Font-Bold="True" Text="Old Exam Details"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="DivOldExmdtls" runat="server" style="display: block;">
            <table id="Table2" runat="server" class="tableIsys" style="width: 90%; display: none">
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:Label ID="lblOExam" runat="server" Font-Bold="False" Text="Exam Mode"> </asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:TextBox ID="txtExm" runat="server" Enabled="false" CssClass="form-control"
                            ></asp:TextBox>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lbloldexmbody" runat="server" CssClass="control-label" Text="Examination Body"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtBody" runat="server" Enabled="false" CssClass="form-control"
                            ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <span style="color: Red">
                            <asp:Label ID="lbloldpref" runat="server" Font-Bold="False" Text="Preffered Exam Language"
                                CssClass="control-label"></asp:Label>*</span>
                        <%--<span style="color: #ff0000">*</span>--%>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:TextBox ID="txtLang" runat="server" Enabled="false" CssClass="form-control"
                            ></asp:TextBox>
                        <%--   <asp:UpdatePanel ID="updPreExmLng" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu" DataTextField="ParamDesc1"
                                    DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="DSddlpreeamlng">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DSddlpreeamlng" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <span style="color: Red">
                            <asp:Label ID="lbloldCentre" runat="server" CssClass="control-label" Text="Exam Centre"></asp:Label>*</span>
                        <%--   <span style="color: #ff0000">*</span>--%>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="textoldexmcenter" runat="server" Enabled="false" CssClass="form-control"
                                    ></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <%--Old Exam Details End --%>
        <%--added by pranjali on 11-04-2014 end--%>
        <%--added by pranjali on 28-04-2014--%>
        <%--New Exam Details Start --%>
        <table style="width: 90%" id="tblCategory" runat="server" class="formtable table-condensed" visible="false">
            <tr>
                <td class="test" colspan="4">

                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btncat"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCat', 'ctl00_ContentPlaceHolder1_btncat');" />
                    <asp:Label ID="lblcat" runat="server" Text="Category of Appointment " Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trCatbind" runat="server" style="width: 90%" class="tableIsys" visible="false">
                <td id="tdcatappbind" runat="server" class="formcontent" nowrap="nowrap" style="width: 20%;">
                    <asp:Label ID="lblCatAppointment" runat="server" CssClass="control-label" Font-Bold="True" Text="Category of Appointment"></asp:Label>
                </td>
                <td id="td19" runat="server" class="formcontent" nowrap="nowrap" style="width: 25%;">
                    <asp:Label ID="lblCatAppBind" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                </td>
                <td id="tdcatbind" runat="server" class="formcontent" nowrap="nowrap" style="width: 20%;">
                    <asp:Label ID="lblcatbind" runat="server" CssClass="control-label" Font-Bold="True" Text="Category"></asp:Label>
                </td>
                <td id="tdcategorybind" runat="server" class="formcontent" nowrap="nowrap" style="width: 25%;">
                    <asp:Label ID="lblcategorybind" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                </td>
            </tr>

            <tr id="trNameInsurance" runat="server" style="width: 90%" class="tableIsys" visible="false">
                <td style="width: 20%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblNameIns" runat="server" Text="Name of insurance" Font-Bold="True"></asp:Label>
                    <%--<span style="color: red">*</span>--%>
 
                </td>
                <td class="formcontent" style="width: 25%;">
                    <asp:Label ID="lblNameBind" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 20%; height: 20px" class="formcontent" align="left"></td>
                <td class="formcontent" style="width: 25%;"></td>

            </tr>
        </table>
        <div id="divCat" runat="server" visible="false">

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <table runat="server" id="tblcat" style="width: 90%" class="tableIsys" visible="false">
                        <tr id="trCatApp" runat="server">
                            <td id="tdCatApp" runat="server" class="formcontent" nowrap="nowrap" style="width: 20%;">
                                <span style="color: Red;">
                                    <asp:Label ID="lblCatApp" runat="server" CssClass="control-label" Font-Bold="False" Text="Category of Appointment"></asp:Label>
                                    *</span>
                            </td>
                            <td id="tdddlCatApp" runat="server" class="formcontent">
                                <asp:UpdatePanel ID="updcatapp" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlcatapp" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Width="170px" TabIndex="6" OnSelectedIndexChanged="ddlcatapp_SelectedIndexChanged"
                                            >
                                            <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td id="tdCat" runat="server" class="formcontent" style="width: 20%;">
                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Visible="false" Font-Bold="False" Text="Category"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td id="tdddlCat" runat="server" class="formcontent">
                                <asp:UpdatePanel ID="updOthers" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="ddlcat" Visible="false" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Enabled="false" Width="170px" Text="Non-Life" TabIndex="6">
                                                       
                                                        
                                        </asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr id="trLife" runat="server">
                            <td colspan="4">
                                <%--<input runat="server" type="button" class="standardlink" value="+" id="btnTransferDetails" style="width: 20px;"
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTrnsferDetails','ctl00_ContentPlaceHolder1_btnTransferDetails');" />--%>
                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="cbLife" runat="server" CssClass="standardcheckbox" AutoPostBack="true"
                                            OnCheckedChanged="cbLife_CheckedChanged" TabIndex="19" />

                                        <asp:Label ID="lblLife" runat="server" CssClass="control-label" Text="Life (For composite Case)"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr id="trIns" runat="server" visible="false">
                            <td id="tdIns" runat="server" class="formcontent" nowrap="nowrap" style="width: 20%;">
                                <span style="color: Red;">
                                    <asp:Label ID="Label8" runat="server" CssClass="control-label" Font-Bold="False" Text="Name of Insurance"></asp:Label>
                                    *</span>
                            </td>
                            <td id="tdddlIns" runat="server" class="formcontent">
                                <asp:DropDownList ID="ddlIns" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                    Width="170px" TabIndex="6" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"
                                    >
                                    <asp:ListItem Text="--Select--" Value="0"> </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td id="tdother" runat="server" class="formcontent" nowrap="nowrap" style="width: 20%;">
                                <asp:Label ID="Label9" runat="server" CssClass="control-label" Font-Bold="False" Text="From others please specify"></asp:Label>
                            </td>
                            <td id="tdtxtother" runat="server" class="formcontent">
                                <asp:TextBox ID="txtOther" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                    MaxLength="30" Width="170px" TabIndex="8"  Enabled="false"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`0123456789" FilterMode="InvalidChars"
                                    TargetControlID="txtOther" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr id="trHealth" runat="server">
                            <td colspan="4">
                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                    <ContentTemplate>
                                        <%--<input runat="server" type="button" class="standardlink" value="+" id="btnTransferDetails" style="width: 20px;"
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTrnsferDetails','ctl00_ContentPlaceHolder1_btnTransferDetails');" />--%>
                                        <asp:CheckBox ID="cbHealth" runat="server" CssClass="standardcheckbox" AutoPostBack="true"
                                            OnCheckedChanged="cbHealth_CheckedChanged" TabIndex="19" />

                                        <asp:Label ID="lblHealth" runat="server" CssClass="control-label" Text="Health (For composite Case)"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr id="trHealthIns" runat="server" visible="false">
                            <td id="tdInsHlth" runat="server" class="formcontent" nowrap="nowrap" style="width: 20%;">
                                <span style="color: Red;">
                                    <asp:Label ID="lblInsHlth" runat="server" CssClass="control-label" Font-Bold="False"
                                        Text="Name of Insurance"></asp:Label>
                                    *</span>
                            </td>
                            <td id="tdInsname" runat="server" class="formcontent">
                                <asp:DropDownList ID="ddlInsname" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                    Width="170px" TabIndex="6" OnSelectedIndexChanged="ddlInsname_SelectedIndexChanged"
                                    >
                                    <asp:ListItem Text="--Select--" Value="0"> </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td id="tdOtherH" runat="server" class="formcontent" nowrap="nowrap" style="width: 20%;">
                                <asp:Label ID="lblOtherH" runat="server" CssClass="control-label" Font-Bold="False" Text="From others please specify"></asp:Label>
                            </td>
                            <td id="tdOtherHealth" runat="server" class="formcontent">
                                <asp:TextBox ID="txtOtherH" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                    MaxLength="30" Width="170px" TabIndex="8"  Enabled="false"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`0123456789" FilterMode="InvalidChars"
                                    TargetControlID="txtOtherH" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>

                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>


        </div>

        <table style="width: 90%" id="tblreasonNOC1" runat="server" class="formtable table-condensed" visible="false">
            <tr>
                <td class="test">

                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnReasonLeave"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNOCdetails', 'ctl00_ContentPlaceHolder1_btnUploadDtls');" />
                    <asp:Label ID="reasonNOC" runat="server" Text="Reason for NOC" Font-Bold="true"></asp:Label>
                </td>
            </tr>

        </table>
        <div id="divNOCdetails" runat="server" style="display: block">

            <table runat="server" id="tblreasonnoc" style="width: 90%" class="tableIsys" visible="false">
                <tr id="trreasontext" runat="server">
                    <td style="width: 25%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblselect" runat="server" Text="Type of Reason for NOC" Font-Bold="True"></asp:Label>
                        <%--<span style="color: red">*</span>--%>
 
                    </td>
                    <td class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblsnlve" runat="server" Font-Bold="False"></asp:Label>
                    </td>

                </tr>
                <tr>

                    <td id="tdreasontext" runat="server" style="width: 20%; height: 20px" class="formcontent" align="left">

                        <asp:Label ID="lblreasontext" runat="server" Text="Remark of Reason for NOC" Font-Bold="True"></asp:Label>
                        <%--<span style="color: red">*</span>--%>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:TextBox ID="txtreasonleave" runat="server" Rows="4" TextMode="multiline"  Enabled="false" CssClass="form-control" Width="100%"></asp:TextBox>
                    </td>


                </tr>

            </table>
        </div>
        <table style="width: 90%" id="tblResonInsurer" runat="server" class="formtable table-condensed" visible="false">

            <tr>
                <td class="test" colspan="4">

                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="Button20"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divInsurer', 'ctl00_ContentPlaceHolder1_btnUploadDtls');" />
                    <asp:Label ID="lblremarkinsurer" runat="server" Text="Remark of Insurer" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>

        <div runat="server" id="divInsurer" style="display: block">
            <%--Added by rachana on 29-07-2013 for toggle of agent details end--%>
            <table runat="server" id="tblremarkinsurer" style="width: 90%" class="tableIsys" visible="false">
                <tr>
                    <td style="width: 45%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblremark" runat="server" Text="Remark of Insurer" Font-Bold="True"></asp:Label>

                    </td>

                    <td style="width: 100%; height: 20px" class="formcontent" align="left">
                        <asp:TextBox ID="txtReInsurer" runat="server" Rows="4" Enabled="false" TextMode="multiline" CssClass="form-control" Width="100%"></asp:TextBox>
                    </td>
                </tr>
            </table>


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table id="trReject" runat="server" style="width: 90%" class="tableIsys" visible="false">
                        <tr>
                            <td colspan="4" class="test" style="height: 38px">

                                <%--<input runat="server" type="button" class="standardlink" value="+" id="btnRejectReason" style="width: 20px;"
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divreject','ctl00_ContentPlaceHolder1_btnRejectReason');" />--%>
                                <asp:Label ID="lblRejectDtl" Text="Reason for Reject" runat="server" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                    <asp:Label ID="lblRejectFlag" runat="server" CssClass="control-label" Text="Reject Case"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp
                                                    
                                                    <asp:CheckBox ID="cbRejectFlag" runat="server" CssClass="standardcheckbox"
                                                        AutoPostBack="true" Enabled="true"
                                                        OnCheckedChanged="cbRejectFlag_CheckedChanged" TabIndex="20" Style='margin-left: 1px' />

                            </td>
                        </tr>



                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>


            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
                    <div id="divRejectDetails" runat="server" visible="false">
                        <table style="width: 90%" class="tableIsys">


                            <tr style="margin-top: 10px;margin-left:-4px">
                                <td style="width: 45%; height: 20px" class="formcontent" align="left">

                                    <asp:Label ID="lblReject" runat="server" Text="Reason for Reject" Font-Bold="True"></asp:Label>
                                    <span style="color: Red">*</span>
                                </td>
                                <td style="width: 100%; height: 20px" class="formcontent" align="left">
                                    <asp:TextBox ID="txtReject" runat="server" Rows="4" TextMode="multiline" CssClass="form-control"
                                        Width="100%" ></asp:TextBox>
                                </td>
                            </tr>


                        </table>

                    </div>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cbRejectFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>

            <%--
                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>--%>
            <%-- comemded by usha--%>
        </div>
        <table id="tblNExmTitle" runat="server" class="formtable table-condensed" style="width: 90%;"
            visible="false">
            <tr>
                <td class="test" colspan="4" style="text-align: left;">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnNwExm"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNewExmDtls', 'ctl00_ContentPlaceHolder1_btnNwExm');" />
                    <asp:Label ID="lblNExamTitle" runat="server" Font-Bold="True" Text="New Exam Details"></asp:Label>
                </td>
            </tr>
        </table>
        <div runat="server" id="divNewExmDtls" visible="true" style="display: none">
            <table runat="server" id="tblNexam" class="tableIsys" style="width: 90%;"
                visible="false">
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <span style="color: #ff0000">
                            <asp:Label ID="lblNExam" runat="server" Font-Bold="False" CssClass="control-label"> </asp:Label>*</span>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updNExam" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNExam" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                    Width="185px"  OnSelectedIndexChanged="ddlNExam_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <span style="color: #ff0000">
                            <asp:Label ID="lblNExmBody" runat="server" CssClass="control-label"></asp:Label>*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdNExmBody" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNExmBody" runat="server" CssClass="standardmenu" Width="185px"
                                     OnSelectedIndexChanged="ddlNExmBody_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <span style="color: Red">
                            <asp:Label ID="lblNpreexamlng" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>*</span>
                        <%--//removed text by pranjali on 25-04-2014--%>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updNPreExmLng" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNpreeamlng" runat="server" CssClass="standardmenu" Width="185px"
                                     OnSelectedIndexChanged="ddlNpreeamlng_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <span style="color: Red">
                            <asp:Label ID="lblNCentre" runat="server" CssClass="control-label"></asp:Label>*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNExmCenter" runat="server" CssClass="standardmenu" Visible="false"
                                     Width="185px">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtNExmCenter" runat="server" Enabled="false" CssClass="form-control"
                                    Visible="true" ></asp:TextBox>
                                <asp:Button ID="btnNExmCenter" runat="server" CausesValidation="False" CssClass="standardbutton"
                                    Text="Search" />
                                <input type="hidden" runat="server" id="hdnNExmCenter" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <%--New Exam Details end --%>
        <%--added by pranjali on 28-04-2014--%>
        <%--pranjali--%>
        <table id="tbltrndtls" runat="server" class="tableIsys" style="width: 90%;"
            visible="false">
            <tr>
                <td class="test" colspan="4" style="text-align: left;">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="BtnOldTrnDtls"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_Divoldtrndtls', 'ctl00_ContentPlaceHolder1_BtnOldTrnDtls');" />
                    <asp:Label ID="Label3" Text="Old Training Details" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="Divoldtrndtls" runat="server" style="display: none;">
            <table id="tbltrndtlsall" runat="server" class="tableIsys" style="width: 90%;">
                <tr>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblTrnMode1" runat="server" CssClass="control-label" Text="Training Mode"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblTrnModeValue" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblTrnLoc1" runat="server" CssClass="control-label" Text="Training Location"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblTrnLocValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblTrnInst1" runat="server" CssClass="control-label" Text="Training Institute"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblTrnInstituteValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblAcc1" runat="server" CssClass="control-label" Text="Accrediation No."></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;" colspan="3">
                        <asp:Label ID="lblAccvalue1" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblTrnHrs1" runat="server" CssClass="control-label" Text="Training Hours"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblTrnHrsValue1" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td id="Td16" class="formcontent" runat="server" style="width: 20%"></td>
                    <td id="Td17" class="formcontent" runat="server" style="width: 30%"></td>
                </tr>
            </table>
        </div>
        <asp:UpdatePanel ID="updtrn" runat="server" Visible=false>
            <ContentTemplate>

                <table visible="true" runat="server" id="tbltrn" class="tableIsys"
                    style="width: 90%;">
                    <tr>
                        <td class="test" colspan="4" style="text-align: left;">
                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="BtnTrnDtls"
                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_Divtrndtls', 'ctl00_ContentPlaceHolder1_BtnTrnDtls');" />
                            <asp:Label ID="lblTrnDtl" Text="Training Details" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div id="Divtrndtls" runat="server" style="display: block;">
                    <table visible="true" runat="server" id="tbltrndtlss" class="tableIsys"
                        style="width: 90%;">
                        <tr>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Training Mode "></asp:Label>*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="updTrnMode" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTrnMode" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Width="250px"  Enabled="true" OnSelectedIndexChanged="ddlTrnMode_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblTrnLoc" runat="server" CssClass="control-label" Text="Training Location"></asp:Label>*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%;" colspan="3">
                                <asp:UpdatePanel ID="updTrnLoc" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTrnLoc" runat="server" CssClass="standardmenu" Visible="true"
                                            AutoPostBack="true" Width="250px"  OnSelectedIndexChanged="ddlTrnLoc_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <input type="hidden" runat="server" id="hdnTrnLocation" name="hdnTrnLocation" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <%--Added by M.Valvi--%>
                        </tr>
                        <tr>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblTrnInstitute" runat="server" CssClass="control-label" Text="Training Institute"></asp:Label>*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="updTrnInstitute" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTrnInstitute" runat="server" CssClass="standardmenu" Visible="true"
                                            Width="250px"  AutoPostBack="true" OnSelectedIndexChanged="ddlTrnInstitute_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <input type="hidden" runat="server" id="hdnTrnInstitute" name="hdnTrnInstitute" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblAccrdtn" runat="server" CssClass="control-label" Text="Accreditation Number"></asp:Label>
                            </td>
                            <td style="width: 30%;" class="formcontent" align="left">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblAccrdtnValue" runat="server" MaxLength="50"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" class="formcontent" align="left">
                                <asp:Label ID="lblHrnTrn" runat="server" Font-Bold="False"></asp:Label>
                                <span style="color: #ff0000">*</span>
                            </td>
                            <td style="width: 30%" class="formcontent" align="left">
                                <asp:UpdatePanel ID="updTrnHrs" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlHrsTrn" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                             Width="250px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                <%--<asp:Label ID="lblHrnTrn" runat="server" Font-Bold="False"></asp:Label>
                        <span style="color: #ff0000">*</span>--%>
                                <asp:Label ID="lblExmType" runat="server" Font-Bold="False" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 20px" class="formcontent" align="left">
                                <%--<asp:DropDownList ID="ddlHrsTrn" runat="server" Width="120px">
                            <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                        </asp:DropDownList>--%>
                                <%--<asp:UpdatePanel ID="updExpTpe" runat="server" >
                            <ContentTemplate>--%>
                                <asp:DropDownList ID="ddlExmTpe" runat="server" Visible="False" Width="120px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlExmTpe_SelectedIndexChanged">
                                    <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                    <asp:ListItem Text="New Advisor" Value="NADV"></asp:ListItem>
                                    <asp:ListItem Text="Repeater" Value="REXM"></asp:ListItem>
                                </asp:DropDownList>
                                <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>

        <%--Bank Details start 08/06/2017--%>

        <table class="formtable" style="width: 90%;" visible="false" runat="server" id="tblbnkdtls">
            <tr>
                <td class="test" colspan="4" style="text-align: left;">
                    <input runat="server" type="button" class="standardlink" value="-" id="btnbnkdtls" style="width: 20px;"
                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divbnkdtls', 'ctl00_ContentPlaceHolder1_divbnkdtls');" />
                    <asp:Label ID="lblbnkdtls" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>

        <div id="divbnkdtls" runat="server" style="display: block;" visible="false">
            <table class="tableIsys" style="width: 90%;">
                <tr id="tr7" runat="server">
                    <%--visible="false"--%>

                    <td align="left" class="formcontent" style="width: 20%; height: 26px;">
                        <asp:Label ID="lblbnkhldname" runat="server" CssClass="control-label"></asp:Label><span style="color: #ff0000">*</span>
                    </td>

                    <td class="formcontent" style="width: 30%; height: 26px;">
                        <span style="color: #ff0000">
                            <asp:TextBox ID="txtbnkhldname" runat="server" CssClass="standardmenu" Width="187px" TabIndex="107" MaxLength="50" onblur="AllowSpacebnkname(this);return false;" onChange="javascript:this.value=this.value.toUpperCase();" ></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender75" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" "
                                TargetControlID="txtbnkhldname">
                            </ajaxToolkit:FilteredTextBoxExtender>

                        </span>
                    </td>

                    <td class="formcontent" style="height: 20px;">
                        <asp:Label ID="lblbnkacno" runat="server" CssClass="control-label"></asp:Label>
                        <span style="color: #ff0000">*</span>

                    </td>

                    <td class="formcontent" style="width: 30%; height: 26px;">

                        <asp:TextBox ID="txtbnkacno" runat="server" CssClass="standardmenu" Width="187px" TabIndex="107" MaxLength="20" ></asp:TextBox>

                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender85" runat="server"
                            FilterType="Numbers,LowercaseLetters, UppercaseLetters,Custom"
                            TargetControlID="txtbnkacno">
                        </ajaxToolkit:FilteredTextBoxExtender>

                    </td>
                </tr>


                <tr id="tr8" runat="server">
                    <%--visible="false"--%>
                    <td align="left" class="formcontent" style="width: 20%; height: 26px;">
                        <asp:Label ID="lblbnkname" runat="server" CssClass="control-label"></asp:Label><span style="color: #ff0000">*</span>
                    </td>

                    <td class="formcontent" style="width: 30%; height: 26px;">
                        <span style="color: #ff0000">
                            <asp:TextBox ID="txtbnkname" runat="server" CssClass="standardmenu" Width="187px" TabIndex="107" MaxLength="100"  onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>

                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender83" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" "
                                TargetControlID="txtbnkname">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </span>
                    </td>

                    <td class="formcontent" style="height: 20px;">
                        <asp:Label ID="lblbrnchname" runat="server" CssClass="control-label"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>

                    <td class="formcontent" style="width: 30%; height: 26px;">
                        <span style="color: #ff0000">
                            <asp:TextBox ID="txtbrnchname" runat="server" CssClass="standardmenu" Width="187px" TabIndex="107" MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();" ></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender84" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers" ValidChars=" "
                                TargetControlID="txtbrnchname">
                            </ajaxToolkit:FilteredTextBoxExtender>

                        </span>
                    </td>
                </tr>


                <tr id="tr9" runat="server">
                    <%--visible="false"--%>
                    <td align="left" class="formcontent" style="width: 20%; height: 26px;">
                        <asp:Label ID="lblactype" runat="server" CssClass="control-label"></asp:Label><span style="color: #ff0000">*</span>
                    </td>

                    <td class="formcontent" style="width: 30%; height: 26px;">
                        <span style="color: #ff0000">
                            <asp:DropDownList ID="ddlactype" runat="server" CssClass="standardmenu" Width="187px" TabIndex="107" >
                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Saving" Value="Saving"></asp:ListItem>
                                <asp:ListItem Text="Current" Value="Current"></asp:ListItem>
                            </asp:DropDownList>
                        </span>
                    </td>

                    <td class="formcontent" style="height: 20px;">
                        <asp:Label ID="lblifsccode" runat="server" CssClass="control-label"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>

                    <td class="formcontent" style="width: 30%; height: 26px;">
                        <span style="color: #ff0000">
                            <asp:TextBox ID="txtifsccode" runat="server" CssClass="standardmenu" Width="187px" TabIndex="107" MaxLength="20" ></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender87" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers"
                                TargetControlID="txtifsccode">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </span>
                    </td>
                </tr>

                <tr id="tr10" runat="server">
                    <%--visible="false"--%>
                    <td align="left" class="formcontent" style="width: 20%; height: 26px;">
                        <asp:Label ID="lblmicrcode" runat="server" CssClass="control-label"></asp:Label><span style="color: #ff0000">*</span>
                    </td>

                    <td class="formcontent" style="width: 30%; height: 26px;">
                        <span style="color: #ff0000">
                            <asp:TextBox ID="txtmicrcode" runat="server" CssClass="standardmenu" Width="187px" TabIndex="107" MaxLength="20" ></asp:TextBox>

                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender86" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers"
                                TargetControlID="txtmicrcode">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </span>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 26px;"></td>
                    <td class="formcontent" style="width: 30%; height: 26px;"></td>
                </tr>

            </table>
        </div>
        <%--End Bank Details start 08/06/2017--%>

        <div id="divPOI" runat="server" visible="false">
            <table runat="server" id="tblPOI" class="tableIsys" style="width: 90%;">
                <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblPOITitle" runat="server" Font-Bold="True" Text="Proof of Document"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblBasicQual" runat="server" CssClass="control-label" Text="Basic Qualification"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdBasicQual" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlBasicQual" runat="server" CausesValidation="true" 
                                    CssClass="standardmenu">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblBoardName" runat="server" CssClass="control-label" Text="Board Name"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtBoardName" runat="server"  CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblBasicRNo" runat="server" CssClass="control-label" Text="Basic Qual. Roll No"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtBasicRNo" runat="server"  CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVBasicRNo" runat="server" ControlToValidate="txtBasicRNo"
                            ErrorMessage="Basic Roll No. should be Numeric.!!" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblYrPass" runat="server" CssClass="control-label" Text="Year of Passing"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtYrPass" Width="90px"
                             />
                        <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <asp:TextBox CssClass="form-control" ID="txtDtValidate" Style="display: none"
                            runat="server" Width="80px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtYrPass"
                            PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RFV" runat="server" SetFocusOnError="true" ControlToValidate="txtYrPass"
                            Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="CV" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                            Type="Date" ControlToValidate="txtYrPass" Display="Dynamic"></asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RGV" runat="server" ControlToValidate="txtYrPass" Display="Dynamic"
                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                            Type="Date"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblpfeduproof" runat="server" CssClass="control-label" Text="Qualification"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;" colspan="3">
                        <asp:UpdatePanel ID="Upeducationproof" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddleducationproof" runat="server" CssClass="standardmenu" DataTextField="ParamDesc"
                                    DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="dseducationproof"
                                    >
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="dseducationproof" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 20%;"></td>
                    <td class="formcontent" style="width: 501px;"></td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblCasteCat" runat="server" CssClass="control-label" Text="Category"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:DropDownList ID="ddlCasteCat" runat="server" CssClass="standardmenu" >
                        </asp:DropDownList>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblPrimProf" runat="server" CssClass="control-label" Text="Primary Profession"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtPrimProf" runat="server" CssClass="form-control" ></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <%--<div id="divAdvDtl" runat="server">
            <table  class="formtable" style="width: 90%;">
                 <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblAdvDtl" runat="server" Font-Bold="True" Text="Candidate Image Details"></asp:Label>
                    </td>
                 </tr>
                 <tr>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label4" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="updAnPhoto" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblPhotoPath" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="AgnPhotoUpload" runat="server" Width="98%"></asp:FileUpload>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="AgnPhotoUpload"
                                    OnServerValidate="CustomValidator1_ServerValidate" SetFocusOnError="True">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label6" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="updAgnSign" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblSignPath" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="AgnSignUpload" runat="server" Width="99%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVSignature" runat="server" ControlToValidate="AgnSignUpload"
                                    OnServerValidate="CVSignature_ServerValidate" SetFocusOnError="True">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                 </tr>
                 
                 <tr>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="Label7"  runat="server"></asp:Label><span
                                    style="color: #ff0000">*</span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    
                    <td style="height: 20px" class="formcontent" align="left" colspan="3">
                       <table style="width:100%;">
                          <tr>
                             <td class="formcontent" style="width:40%;" align="left"> 
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                   <asp:Label ID="lblPANPath" runat="server" Visible="false"></asp:Label>
                                   <asp:FileUpload ID="PANUpload" runat="server" Width="99%" EnableViewState="true">
                                   </asp:FileUpload>
                                   <asp:CustomValidator ID="CVPANValidator" runat="server" ControlToValidate="PANUpload"
                                    OnServerValidate="CVPANValidator_ServerValidate" SetFocusOnError="True">
                                   </asp:CustomValidator>
                               </ContentTemplate>
                               </asp:UpdatePanel>
                            </td>
                    
                        <td style="width: 15%; height: 20px" class="formcontent" align="left">
                            <asp:UpdatePanel ID="upnllblNocDoc" runat="server" Visible="false">
                            <ContentTemplate>
                                <asp:Label ID="Label8" runat="server"></asp:Label><span
                                    style="color: #ff0000">*</span>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            </td>
                            <td id="tdNocDoc" runat="server" class="formcontent" style="width:30%;visibility:hidden" align="left"> 
                                <asp:UpdatePanel ID="upnlNocDoc" runat="server" >
                                <ContentTemplate>
                                 <asp:Label ID="lblNoc" runat="server" Visible="false"></asp:Label>
                                   <asp:FileUpload ID="NocDocUpload" runat="server" Width="139%" 
                                        EnableViewState="true">
                                   </asp:FileUpload>
                                    <asp:CustomValidator ID="CVDocUpload" runat="server" ControlToValidate="NocDocUpload"
                                   SetFocusOnError="True" onservervalidate="CVDocUpload_ServerValidate">
                                </asp:CustomValidator>
                               </ContentTemplate>
                               </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                         <td class="formcontent" style="width:25%;" align="left"> </td>
                         <td class="formcontent" style="width:25%;" align="left" >
                               <asp:LinkButton ID="lnkArf" runat="server" Visible = "true"  Text="ARF Form Pg1"
                                 onclick="Click_Arf"   ></asp:LinkButton>
                            </td>
                            <td class="formcontent" style="width:25%;" align="left">
                               <asp:LinkButton ID="lnkArfForm" runat="server" Text="ARF Form Pg2" Visible = "true"></asp:LinkButton>
                            </td>
                            <td class="formcontent" style="width:25%;" align="left">
                               <asp:LinkButton ID="lnkeducation" runat="server" Visible = "true" Text="Education Proof" 
                                 onclick="Click_Educationproof"  ></asp:LinkButton>
                            </td>
                            </tr>
                       </table>
                    </td>  
                </tr>
                
                <tr>
                   <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndArf1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblArf1" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndArf1" runat="server" Width="98%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVArf1" runat="server" ControlToValidate="CndArf1"
                                     SetFocusOnError="True" onservervalidate="CVArf1_ServerValidate">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label10" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndArf2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblArf2" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndArf2" runat="server" Width="99%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVArf2" runat="server" ControlToValidate="AgnSignUpload"
                                     SetFocusOnError="True" onservervalidate="CVArf2_ServerValidate">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                   <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label11" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndEduProof1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblEdu1" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndEduProof1" runat="server" Width="98%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVEduProof1" runat="server" ControlToValidate="CndEduProof1"
                                     SetFocusOnError="True" onservervalidate="CVEduProof1_ServerValidate" >
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label12" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndEduProof2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblEdu2" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndEduProof2" runat="server" Width="99%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVEduProof2" runat="server" ControlToValidate="CndEduProof2"
                                     SetFocusOnError="True" onservervalidate="CVEduProof2_ServerValidate" >
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                 
            </table>
       </div>--%>
        <%--//pranjali--%>
        <%--Added by rachana on 14022014 for Transfer Case Details start--%>
        <%--<table id="tblcol" style="width: 90%" class="formtable" runat="server">
            <tr>
                <td colspan="4" align="left" class="test">
                    <input runat="server" type="button" class="standardlink" value="-" id="btntransCollapse"
                        style="width: 20px;" onclick="ShowReqDtlNew('ctl00_ContentPlaceHolder1_divtransfer','ctl00_ContentPlaceHolder1_btntransCollapse');" />
                    <asp:Label ID="lblheadtrans" runat="server" Text="Transfer/Composite Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>--%>
        <%--<div runat="server" id="divtransfer" style="display: none;">
            <table id="TblTransfer" runat="server" style="width: 90%" class="formtable">
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblTrfrFlag" runat="server" CssClass="control-label" Text="Transfer Case">
                        </asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox" AutoPostBack="false"
                            OnCheckedChanged="cbTrfrFlag_CheckedChanged" TabIndex="19" />
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblCompLcn" runat="server" CssClass="control-label" Text="Composite License">
                        </asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox" Enabled="true"
                            AutoPostBack="false" TabIndex="20" OnCheckedChanged="cbTccCompLcn_CheckedChanged" />
                    </td>
                </tr>
                <tr id="trTCCase" runat="server">
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lbloldLcnNo" runat="server" CssClass="control-label" Text="Life License No">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtOldTccLcnNo" runat="server" CssClass="form-control" 
                            TabIndex="21">
                        </asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                            InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo"
                            FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lblOldLcnexpDate" runat="server" CssClass="control-label" Text="Old License Exp.Date">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" 
                            TabIndex="22" />
                        <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <asp:TextBox ID="txtOldLicense" runat="server" CssClass="form-control" Style="display: none">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CldrExtendrOldLicense" runat="server" TargetControlID="txtDate"
                            PopupButtonID="btnoldlicense" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RFVOldLicense" runat="server" SetFocusOnError="true"
                            ControlToValidate="txtDate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic">
                        </asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="COMPAREVALIDATOROldLicense" runat="server" ErrorMessage="Invalid date!"
                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtDate" Display="Dynamic">
                        </asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RVOldLicense" runat="server" ControlToValidate="txtDate"
                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                            MinimumValue="1900-01-01" Type="Date">
                        </asp:RangeValidator>
                    </td>
                </tr>
                <tr id="trTCCase1" runat="server">
                    <td align="left" class="formcontent" style="width: 20%;">
                     <span style="color:Red">
                        <asp:Label ID="lblPrevInsurerName" runat="server" CssClass="control-label" Text="Prev Insurer Name">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtTccPrevInsurerName" runat="server" CssClass="form-control"
                             TabIndex="23">
                        </asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                            InvalidChars=",#$@%^!*()&''%^~`1234567890" FilterMode="InvalidChars" TargetControlID="txtTccPrevInsurerName"
                            FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lblNOCFlag" runat="server" CssClass="control-label" Text="NOC Received"></asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbNOCFlag" runat="server" CssClass="standardcheckbox" 
                            AutoPostBack="false" Visible="false" />
                        <asp:UpdatePanel ID="upnlRbtNoc" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal" CssClass="radiobtn"
                                    TabIndex="24" AutoPostBack="true" OnSelectedIndexChanged="RbtNoc_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Y" Selected="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="1" Text="N">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="trAckRcv" runat="server" style="height: 10%">
                    <td style="width: 20%;" class="formcontent">
                    </td>
                    <td style="width: 30%;" class="formcontent">
                    </td>
                    <td style="width: 20%;" class="formcontent">
                        <asp:UpdatePanel ID="upnllblAckrcv" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblAckrcv" runat="server" Visible="false" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 30%;" class="formcontent">
                        <asp:UpdatePanel ID="upnlRbAckRev" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="RbAckRev" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                    Visible="false" TabIndex="25">
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="trNOCAck" runat="server" visible="false">
                    <td class="formcontent" align="left" style="width: 20%;">
                        <asp:Label ID="lblNOCAck" runat="server" Text="NOC/Acknowledgement"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkNOCAck" runat="server" 
                            TabIndex="118" />
                    </td>
                    <td class="formcontent" colspan="2">
                    </td>
                </tr>
            </table>
        </div>--%>
        <%--added by pranjali on 13-03-2014 for transfr deatils start--%>
        <table id="trnsfrtitle" visible="false" runat="server" class="tableIsys table-condensed" style="width: 90%;">
            <tr id="trtran" runat="server">
                <td colspan="4" class="test">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <%--<input runat="server" type="button" class="standardlink" value="+" id="btnTransferDetails" style="width: 20px;"
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTrnsferDetails','ctl00_ContentPlaceHolder1_btnTransferDetails');" />--%>
                            <asp:Label ID="lblTransferDtl" Text="Transfer Details" runat="server" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="lblTrfrFlag" runat="server" CssClass="control-label" Text="Transfer Case"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox" AutoPostBack="true"
                                OnCheckedChanged="cbTrfrFlag_CheckedChanged" TabIndex="19" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <%--     added by amruta for transfer start on 11.6.15--%>
            <tr id="trNoteTr" class="formcontent" runat="server">
                <td class="formcontent" style="width: 20%;">
                    <span style="color: red">
                        <asp:Label ID="lblIC" CssClass="control-label" Text="I-C Date" runat="server"></asp:Label>*</span>
                </td>
                <td class="formcontent" style="width: 20%;">
                    <asp:TextBox ID="txtIC" runat="server" CssClass="form-control" 
                        TabIndex="10"></asp:TextBox>
                    <asp:Image ID="btnCalendarIC" runat="server"
                        ImageUrl="~/App_UserControl/Common/calendar.bmp" Height="16px" />

                    <ajaxToolkit:CalendarExtender ID="CalendarExtender28" runat="server" TargetControlID="txtIC"
                        PopupButtonID="btnCalendarIC" Format="dd/MM/yyyy">
                    </ajaxToolkit:CalendarExtender>


                </td>
                <td id="tdNoteIc" class="formcontent" runat="server" style="width: 20%;">
                    <asp:Label ID="lblNoteIc" runat="server" Text="Please provide last insurer I-C Date" ForeColor="Red"></asp:Label>
                </td>
                <td class="formcontent" style="width: 20%;"></td>
                <td class="formcontent" style="width: 20%;"></td>
            </tr>
            <%--     added by amruta for transfer end on 11.6.15--%--%>
        </table>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="divTrnsferDetails" runat="server" visible="false" style="width: 90%; height: 100%; overflow: hidden">
                    <table class="tableIsys" style="width: 100%;">
                        <tr id="trTCCase" style="display: none;" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                    <asp:Label ID="lbloldLcnNo" runat="server" CssClass="control-label" Text="License No"></asp:Label>*</span>
                                <%--  <span style="color: #ff0000">*</span>--%>
                            </td>
                            <%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="updlcnVer1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtOldTccLcnNo" runat="server" CssClass="form-control"  TabIndex="21" AutoPostBack="true"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lbllcnerr2" Font-Size="X-Small" Visible="false" ForeColor="Green" runat="server" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                            FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <%--<span style="color: red">--%>
                                <asp:Label ID="lblOldLcnexpDate" runat="server" CssClass="control-label"></asp:Label><%--*</span>--%>
                                                   
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control"  TabIndex="22" />
                                <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox ID="txtOldLicense" runat="server" CssClass="form-control" Style="display: none"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CldrExtendrOldLicense" runat="server" TargetControlID="txtDate" PopupButtonID="btnoldlicense" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RFVOldLicense" runat="server" SetFocusOnError="true" ControlToValidate="txtDate" Enabled="false"
                                    ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="COMPAREVALIDATOROldLicense" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck" Type="Date"
                                                        ControlToValidate="txtDate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RVOldLicense" runat="server" ControlToValidate="txtDate" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                
                            </td>
                        </tr>
                        <tr id="trTCCase1" style="display: none;" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                    <asp:Label ID="lblPrevInsurerName" runat="server" CssClass="control-label" Text="Insurer Name"></asp:Label>*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <%--<asp:TextBox id="txtTccPrevInsurerName" runat="server" 
                                                        CssClass="form-control"  TabIndex="23" Visible="false" ></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlTrnsfrInsurName" runat="server" CssClass="standardmenu" 
                                    Width="270px" TabIndex="65">
                                </asp:DropDownList>
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtTccPrevInsurerName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">

                                <asp:Label ID="lblLicIssueDt" runat="server" CssClass="control-label" Text="License Issue Date"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="Updatepanel134" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtLicIssueDt" runat="server" CssClass="form-control"  TabIndex="21"></asp:TextBox>
                                        <asp:Image ID="btnLicIssue" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Style="display: none"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender23" runat="server" TargetControlID="txtLicIssueDt" PopupButtonID="btnLicIssue" Format="dd/MM/yyyy" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" SetFocusOnError="true" ControlToValidate="txtLicIssueDt" Enabled="false"
                                            ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="COMPAREVALIDATOR24" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck" Type="Date"
                                                        ControlToValidate="txtLicIssueDt" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator23" runat="server" ControlToValidate="txtLicIssueDt" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <%--// 01...06/09/2012...Miti--%>
                        </tr>

                        <tr id="tr6" style="display: none;" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblNOCFlag" runat="server" CssClass="control-label" Text="NOC Received"></asp:Label>*</span>
                                <%--  <span style="color: #ff0000">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <%--// 01...06/09/2012...Miti--%>
                                <asp:CheckBox ID="cbNOCFlag" runat="server" CssClass="standardcheckbox"  AutoPostBack="false" Visible="false" />
                                <%----%>
                                <asp:UpdatePanel ID="upnlRbtNoc" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal"
                                            CssClass="radiobtn" TabIndex="24"
                                            AutoPostBack="true" OnSelectedIndexChanged="RbtNoc_SelectedIndexChanged">
                                            <asp:ListItem Value="Y" Text="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N" Text="N">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;"></td>
                            <td class="formcontent" style="width: 30%;"></td>
                        </tr>
                        <tr id="trAckRcv" style="display: none;" runat="server">
                            <td style="width: 20%;" class="formcontent">
                                <asp:UpdatePanel ID="upnllblAckrcv" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblAckrcv" runat="server" Visible="false" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 30%;" class="formcontent">
                                <asp:UpdatePanel ID="upnlRbAckRev" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="RbAckRev" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                            Visible="false" TabIndex="25">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtissudate" runat="server" CssClass="form-control" TabIndex="22"  />
                                <asp:Image ID="btnissu" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Style="display: none"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtissudate"
                                    PopupButtonID="btnissu" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true"
                                    ControlToValidate="txtissudate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:CompareValidator ID="COMPAREVALIDATOR5" runat="server" ErrorMessage="Invalid date!"
                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtissudate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtissudate"
                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                 
                            </td>


                            <td style="width: 20%;" class="formcontent"></td>
                            <td style="width: 30%;" class="formcontent"></td>

                        </tr>
                        <%-- added by amruta on 11.6.15--%>
                        <tr id="trTrnsfr1" class="formcontent" runat="server">
                            <td>
                                <span style="color: red">
                                    <asp:Label ID="lblCatTrnsfr" CssClass="control-label" Text="Category" runat="server"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 20%;">
                                <asp:UpdatePanel ID="UpdatePanel119" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCaTrnsfr" runat="server" CssClass="standardmenu"
                                             Width="187px" TabIndex="12">
                                            <asp:ListItem Value="" Text="---select---"></asp:ListItem>

                                        </asp:DropDownList>


                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" style="width: 20%;"></td>
                            <td class="formcontent" style="width: 20%;"></td>
                            <td class="formcontent" style="width: 20%;"></td>
                        </tr>
                        <tr id="trTrnsfr2" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblInsurerTrnsfr" CssClass="control-label" Text="Name of Insurer" runat="server"></asp:Label>*</span>
                            </td>

                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel137">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlNameInTrnsfr" runat="server" CssClass="standardmenu"  Width="187px"
                                            TabIndex="6">
                                            <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblAgencyCodeTrnsfr" CssClass="control-label" Text="Agency code number" runat="server"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtAgencyCodeTrnsfr" runat="server" CssClass="form-control" 
                                    onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="60" TabIndex="9"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender80" runat="server"
                                    InvalidChars="a^z1234567890 " ValidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~" FilterMode="InvalidChars"
                                    TargetControlID="txtAgencyCodeTrnsfr" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>


                            </td>
                            <td class="formcontent" style="width: 30%;"></td>
                        </tr>
                        <tr id="trTrnsfr3" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblDateOfAppointmentTrnsfr" CssClass="control-label" Text="Date of appointment as agent" runat="server"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtDateOfAppointmentTrnsfr" runat="server" CssClass="form-control" 
                                    TabIndex="10"></asp:TextBox>
                                <asp:Image ID="btnCalendarTr" runat="server"
                                    ImageUrl="~/App_UserControl/Common/calendar.bmp" Height="16px" />

                                <ajaxToolkit:CalendarExtender ID="CalendarExtender26" runat="server" TargetControlID="txtDateOfAppointmentTrnsfr"
                                    PopupButtonID="btnCalendarTr" Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>

                            </td>
                            <td class="formcontent" style="width: 30%;"></td>
                            <td class="formcontent" style="width: 30%;"></td>
                        </tr>

                        <tr id="trTrnsfr4" class="formcontent" runat="server">
                            <td class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblStsTrnsfr" CssClass="control-label" Text="Status" runat="server"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 20%;">
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlStsTrnsfr" runat="server" CssClass="standardmenu"
                                             Width="187px" TabIndex="11">
                                            <asp:ListItem Value="0" Text="---select---"></asp:ListItem>
                                            <%--         <asp:ListItem Value="1" Text="Inforce"></asp:ListItem>--%>
                                            <asp:ListItem Value="2" Text="Cessation"></asp:ListItem>
                                        </asp:DropDownList>


                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" style="width: 20%;"></td>
                            <td class="formcontent" style="width: 20%;"></td>
                        </tr>

                        <tr id="trTrnsfr5" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblDateOfCessationTrnsfr" CssClass="control-label" Text="Date of cessation of agency" runat="server"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtDateOfCessationTrnsfr" runat="server" CssClass="form-control"
                                    TabIndex="12"></asp:TextBox>
                                <asp:Image ID="btnCalendartr2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />

                                <ajaxToolkit:CalendarExtender ID="CalendarExtender27" runat="server" TargetControlID="txtDateOfCessationTrnsfr"
                                    PopupButtonID="btnCalendartr2" Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>

                            </td>

                            <td align="left" class="formcontent" style="width: 20%;">

                                <asp:Label ID="lblReasonForCessationTrnsfr" CssClass="control-label" Text="Reason for cessation of agency" runat="server"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtReasonForCessationTrnsfr" runat="server" CssClass="form-control"
                                    TabIndex="13"></asp:TextBox>
                            </td>
                            <td class="formcontent" style="width: 30%;"></td>
                            <td class="formcontent" style="width: 30%;"></td>
                        </tr>
                    </table>
                    <table>

                        <tr>
                            <td class="formcontent" style="width: 30%; text-align: center">
                                <asp:Button ID="btnAddTrnsfr" runat="server" Text="Add" OnClick="btnAddTrnsfr_Click" OnClientClick="return funIc();" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvTrnsfr" OnRowDeleting="gvTrnsfr_RowDeleting"
                                    AutoGenerateColumns="false" AutoGenerateDeleteButton="false" runat="server"
                                    BackColor="White" Style="width: 100%;"
                                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">


                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="I-C Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name_of_Insurer">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agency_code_Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAgencyCode" runat="server" Text='<%# Bind("Agency_code_Number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date_of_appointment">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateAppointment" runat="server" Text='<%# Bind("Date_of_appointment_as_Agent") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date_of_cessation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateCessation" runat="server" Text='<%# Bind("Date_of_cessation_of_Agency") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reason_for_cessation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReasonCessation" runat="server" Text='<%# Bind("Reason_for_cessation_of_Agency") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:CommandField ShowDeleteButton="true"  DeleteText="Delete" />--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<% #Eval("Agency_code_Number")%>' CommandName="delete" />
                                            </ItemTemplate>

                                        </asp:TemplateField>



                                    </Columns>

                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        <%--added by pranjali on 13-03-2014 for transfr deatils end--%>
        <%--added by pranjali on 13-03-2014 for composite deatils start--%>
        <table id="CompositeTitle" runat="server" visible="false" class="tableIsys table-condensed" style="width: 90%;">
            <tr id="chkcom" runat="server">
                <td colspan="4" class="test">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <%--<input runat="server" type="button" class="standardlink" value="+" id="btnCompositeDetails" style="width: 20px;"
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCompositeDetails','ctl00_ContentPlaceHolder1_btnCompositeDetails');" />--%>
                            <asp:Label ID="lblCompositeDtl" Text="Composite Details" runat="server" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="lblCompLcn" runat="server" CssClass="control-label" Text="Composite Case"></asp:Label>&nbsp
                            <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox" Enabled="true"
                                AutoPostBack="true" TabIndex="20" OnCheckedChanged="cbTccCompLcn_CheckedChanged" />

                            <%--     added by Nikhil for composite start--%>
                            <tr id="tr5" class="formcontent" runat="server">
                                <td>
                                    <asp:Label ID="lblHasAgent" Text="Has the agent taken an acknowledgement on form I-B from the life Insurance Company  (Y/N)" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="radioComposite" AutoPostBack="true" runat="server"
                                        RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="radioComposite_SelectedIndexChanged" Enabled="True">
                                        <asp:ListItem Value="0" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td></td>
                            </tr>
                            <%--     added by Nikhil for composite end--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <%--<td class="test">
                                               <asp:CheckBox ID="chkCompAgnt" runat="server" CssClass="standardcheckbox"  Enabled="true" TabIndex="21"  />
                                               </td>--%>
            </tr>
        </table>
        <asp:UpdatePanel ID="Updcompdtls" runat="server" Visible="false">
            <ContentTemplate>
                <div id="divCompositeDetails" runat="server" visible="false" style="display: none;">
                    <table id="tblcomp" runat="server" class="tableIsys" style="width: 90%;">

                        <tr id="tr2" style="display: none" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                    <asp:Label ID="lblCompLicNo" runat="server" CssClass="control-label" Text="Life License No"></asp:Label>*</span>
                            </td>
                            <%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="updlcnver2" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCompLicNo" runat="server" CssClass="form-control"  TabIndex="21" OnTextChanged="txtCompLicNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lbllcnerr" Font-Size="X-Small" Visible="false" ForeColor="Green" runat="server" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                            FilterMode="InvalidChars" TargetControlID="txtCompLicNo" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblComplicnseExpDt" runat="server" CssClass="control-label"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtCompLicExpDt" runat="server" CssClass="form-control"  TabIndex="22" />
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Style="display: none"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCompLicExpDt" PopupButtonID="Image1" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" ControlToValidate="txtCompLicExpDt" Enabled="false"
                                    ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="COMPAREVALIDATOR2" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck" Type="Date"
                                                        ControlToValidate="txtCompLicExpDt" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCompLicExpDt" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                
                            </td>
                        </tr>
                        <tr id="tr3" style="display: none" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                    <asp:Label ID="lblCompInsurerName" runat="server" CssClass="control-label" Text="Insurer Name"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <%--<asp:TextBox id="txtCompInsurerName" runat="server" 
                                                        CssClass="form-control"  TabIndex="23" ></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlCompInsurerName" runat="server" CssClass="standardmenu" 
                                    Width="270px" TabIndex="65">
                                </asp:DropDownList>
                                <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtCompInsurerName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;"></td>
                            <td class="formcontent" style="width: 30%;"></td>

                        </tr>
                        <%--composite addition added by amruta--%>
                        <tr id="Tr1" class="formcontent" runat="server">
                            <td>
                                <span style="color: red">
                                    <asp:Label ID="lblCatComp" CssClass="control-label" Text="Category" runat="server"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 20%;">
                                <asp:UpdatePanel ID="UpdatePanel151" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCatComp" runat="server" CssClass="standardmenu"
                                             Width="187px" TabIndex="12">
                                            <asp:ListItem Value="" Text="---select---"></asp:ListItem>
                                            <%-- <asp:ListItem Value="Life" Text="Life"></asp:ListItem>
                                                                  <asp:ListItem Value="Health" Text="Health"></asp:ListItem>--%>
                                        </asp:DropDownList>


                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" style="width: 20%;"></td>
                            <td class="formcontent" style="width: 20%;"></td>
                            <td class="formcontent" style="width: 20%;"></td>
                        </tr>
                        <tr id="trInsurer" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblInsurer" CssClass="control-label" Text="Name of Insurer" runat="server"></asp:Label>*</span>
                            </td>
                            <%--added by amruta--%>
                            <td class="formcontent" style="width: 20%;">
                                <asp:UpdatePanel runat="server" ID="updNameIns">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlNameIns" runat="server" CssClass="standardmenu"  Width="170px"
                                            TabIndex="6">
                                            <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblAgencyCode" CssClass="control-label" Text="Agency code number" runat="server"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtAgencyCode" runat="server" CssClass="form-control" 
                                    onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="60" TabIndex="9"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender81" runat="server"
                                    InvalidChars="a^z1234567890 " ValidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~" FilterMode="InvalidChars"
                                    TargetControlID="txtAgencyCode" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>


                            </td>
                            <td class="formcontent" style="width: 30%;"></td>
                        </tr>

                        <tr id="trAppointment" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblDateOfAppointment" CssClass="control-label" Text="Date of appointment as agent" runat="server"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtDateOfAppointment" runat="server" CssClass="form-control" 
                                    TabIndex="10"></asp:TextBox>
                                <asp:Image ID="btnCalendar1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <%--<asp:TextBox ID="txtDtValidate1" runat="server" CssClass="form-control" Style="display: none"
                                                            Width="80px"></asp:TextBox>--%>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender24" runat="server" TargetControlID="txtDateOfAppointment"
                                    PopupButtonID="btnCalendar1" Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" SetFocusOnError="true" ControlToValidate="txtDateOfAppointment"
                                                            Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="CompareValidator25" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                                            Type="Date" ControlToValidate="txtDateOfAppointment" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator24" runat="server" ControlToValidate="txtDateOfAppointment" Display="Dynamic"
                                                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                            Type="Date"></asp:RangeValidator>  --%>
                            </td>
                            <td class="formcontent" style="width: 30%;"></td>
                            <td class="formcontent" style="width: 30%;"></td>
                        </tr>
                        <tr id="trSts" class="formcontent" runat="server">
                            <td class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblSts" CssClass="control-label" Text="Status" runat="server"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 20%;">
                                <asp:UpdatePanel ID="UpdatePanel116" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSts" runat="server" CssClass="standardmenu"
                                             Width="187px" TabIndex="11">
                                            <asp:ListItem Value="0" Text="---select---"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Inforce"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Cessation"></asp:ListItem>
                                        </asp:DropDownList>


                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" style="width: 20%;"></td>
                            <td class="formcontent" style="width: 20%;"></td>
                        </tr>

                        <tr id="trCessation" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblDateOfCessation" CssClass="control-label" Text="Date of cessation of agency" runat="server"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtDateOfCessation" runat="server" CssClass="form-control"
                                    TabIndex="12"></asp:TextBox>
                                <asp:Image ID="btnCalendar2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <%--  <asp:TextBox ID="txtDtValidate2" runat="server" CssClass="form-control" Style="display: none"
                                                            Width="80px"></asp:TextBox>--%>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender25" runat="server" TargetControlID="txtDateOfCessation"
                                    PopupButtonID="btnCalendar2" Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" SetFocusOnError="true" ControlToValidate="txtDateOfCessation"
                                                            Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="CompareValidator26" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                                            Type="Date" ControlToValidate="txtDateOfCessation" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator25" runat="server" ControlToValidate="txtDateOfCessation" Display="Dynamic"
                                                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                            Type="Date"></asp:RangeValidator>--%>  
                            </td>

                            <td align="left" class="formcontent" style="width: 20%;">

                                <asp:Label ID="lblReasonForCessation" CssClass="control-label" Text="Reason for cessation of agency" runat="server"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtReasonForCessation" runat="server" CssClass="form-control"
                                    TabIndex="13"></asp:TextBox>
                            </td>
                            <td class="formcontent" style="width: 30%;"></td>
                            <td class="formcontent" style="width: 30%;"></td>
                        </tr>

                    </table>
                    <tr>
                        <td class="formcontent" style="width: 30%; text-align: center">
                            <asp:Button ID="btnAddComposite" runat="server" Text="Add"
                                OnClick="btnAddComposite_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" style="width: 30%; text-align: center">
                            <asp:GridView ID="gvComposite" OnRowDeleting="gvComposite_RowDeleting" AutoGenerateColumns="false" AutoGenerateDeleteButton="false" runat="server"
                                BackColor="White" Style="width: 90%"
                                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="3">

                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />

                                <Columns>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name_of_Insurer">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Agency_code_Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgencyCode" runat="server" Text='<%# Bind("Agency_code_Number") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date_of_appointment">

                                        <ItemTemplate>
                                            <asp:Label ID="lblDateAppointment" runat="server" Text='<%# Bind("Date_of_appointment_as_agent") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date_of_cessation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateCessation" runat="server" Text='<%# Bind("Date_of_cessation_of_agency") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reason_for_cessation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReasonCessation" runat="server" Text='<%# Bind("Reason_for_cessation_of_agency") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:CommandField ShowDeleteButton="true"  DeleteText="Delete" />--%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<% #Eval("Agency_code_Number")%>' CommandName="delete" />
                                        </ItemTemplate>

                                    </asp:TemplateField>



                                </Columns>

                            </asp:GridView>
                        </td>
                    </tr>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cbTccCompLcn" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        <table id="trIsPriorAgt" class="tableIsys" runat="server" style="height: 5%; width: 90%; display: none">
            <tr>
                <td align="left" colspan="4" class="test">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <asp:CheckBox ID="chkCompAgnt" runat="server" CssClass="standardcheckbox" Enabled="true"
                                TabIndex="21" OnCheckedChanged="chkCompAgnt_CheckedChanged" AutoPostBack="true" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <%--added by pranjali on 28-03-2014--%>
        <%--added by pranjali on 13-03-2014 for composite deatils end--%>
        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
                <table id="tblCndURN" runat="server" style="width: 90%;" visible="false">
                    <tr>
                        <td class="test" colspan="4" style="text-align: left;">
                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                <ContentTemplate>
                                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="BtnCndTrnsDtls"
                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCndTrnsDtls', 'ctl00_ContentPlaceHolder1_BtnCndTrnsDtls');" />
                                    <asp:Label ID="lbltitleURN" runat="server" Font-Bold="True" Text="Candidate URN No."></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <div id="divCndTrnsDtls" runat="server">
                    <table id="tblCndURNDtl" runat="server" style="width: 90%; display: block">
                        <tr>
                            <td id="tdCndURNNo" align="left" runat="server" class="formcontent">
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <%--<span style="color: red">*</span>--%>
                                            <asp:Label ID="lblcndURNNo" Text="Candidate URN No." runat="server" CssClass="control-label"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                        <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="UpdatePanel171" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCndURNNo" runat="server" CssClass="form-control" ></asp:TextBox>
                                        <asp:Label ID="lblcndURNVal" runat="server" CssClass="control-label" Visible="false"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                        <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%; display: none;">
                                <asp:Label ID="lblTrnsfrReqNo" Text="IRDA Transfer Request No." runat="server" CssClass="control-label"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%; display: none;">
                                <asp:TextBox ID="TxtTrnsfrReqNo" runat="server" CssClass="form-control" ></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- added by shreela on 18-04-2014 for Renewal Details start--%>
        <table id="tblRenewalCollapse" style="width: 90%" class="formtable table-condensed"
            runat="server" visible="false">
            <tr>
                <td colspan="4" align="left" class="test">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnRenew"
                        style="width: 20px;" onclick="ShowReqDtlRenew('ctl00_ContentPlaceHolder1_divRenewal', 'ctl00_ContentPlaceHolder1_btnRenew');" />
                    <asp:Label ID="lblRenew" runat="server" Text="Renewal Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="updrenewal" runat="server">
            <ContentTemplate>
                <div id="divRenewal" runat="server" visible="false" style="display: none">
                    <table id="tblRenewal" style="width: 90%" class="tableIsys" runat="server">
                        <tr>
                            <td align="left" colspan="4" class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblCndType" runat="server" CssClass="control-label"></asp:Label>
                            </td>
                            <td id="Td1" runat="server" class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblCndVal" runat="server"></asp:Label>
                            </td>
                            <td id="Td2" runat="server" class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblCount" runat="server" CssClass="control-label"></asp:Label>
                            </td>
                            <td id="Td3" runat="server" class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblCountVal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="Comp" runat="server" style="display: none;">
                            <td id="Td4" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblRenewType" runat="server" CssClass="control-label"></asp:Label>*</span>
                            </td>
                            <td id="Td5" runat="server" class="formcontent">
                                <asp:DropDownList ID="ddlRenewType" runat="server" CssClass="standardmenu" 
                                    Width="210px" AutoPostBack="true" OnSelectedIndexChanged="ddlRenewType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td id="Td6" runat="server" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lbllyfTraining" runat="server" CssClass="control-label"></asp:Label>*</span>
                            </td>
                            <td id="Td7" runat="server" class="formcontent">
                                <asp:DropDownList ID="ddllyfTraining" runat="server" CssClass="standardmenu" 
                                    Width="210px" Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <%--Added by kalyani to fetch Renewal record on QC module start--%>
                        <tr id="trCompQC" runat="server" visible="false">
                            <td id="Td8" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblQCRenewType" runat="server" CssClass="control-label"></asp:Label></span>
                            </td>
                            <td id="Td9" runat="server" class="formcontent">
                                <asp:Label ID="lbltxtQCRenewType" runat="server" CssClass="control-label"></asp:Label>
                            </td>
                            <td id="Td10" runat="server" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblQClyfTraining" runat="server" CssClass="control-label"></asp:Label></span>
                            </td>
                            <td id="Td11" runat="server" class="formcontent">
                                <asp:Label ID="lbltxtQClyfTraining" runat="server" CssClass="control-label"></asp:Label>
                            </td>
                        </tr>
                        <%--Added by kalyani to fetch Renewal record on QC module end--%>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- added by shreela on 18-04-2014 for Renewal Details end--%>
        <%--added by pranjali on 05-01-2015 start for repeater case--%>
        <table id="TblRptrTitle" style="width: 90%" class="formtable table-condensed"
            runat="server" visible="false">
            <tr>
                <td colspan="4" align="left" class="test">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnRptr"
                        style="width: 20px;" onclick="ShowReqDtlRenew('ctl00_ContentPlaceHolder1_divRptr', 'ctl00_ContentPlaceHolder1_btnRptr');" />
                    <asp:Label ID="TblRptrDtls" runat="server" Text="Repeater Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
            <ContentTemplate>
                <div id="divRptr" runat="server" style="display: none">
                    <table id="tblRptr" style="width: 90%" class="tableIsys" runat="server">
                        <tr>
                            <td align="left" colspan="4" class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblRptrCndTyp" Text="Candidate Type" runat="server" CssClass="control-label"></asp:Label>
                            </td>
                            <td id="Td12" runat="server" class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblRptrCndTypVal" runat="server"></asp:Label>
                            </td>
                            <td id="Td13" runat="server" class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblRptrCount" Text="ReExam Count" runat="server" CssClass="control-label"></asp:Label>
                            </td>
                            <td id="Td15" runat="server" class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblRptrCountVal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="tr4" runat="server">
                            <td id="Td22" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblRptrTyp" Text="ReExam Type" runat="server" CssClass="control-label"></asp:Label></span>
                            </td>
                            <td id="Td23" runat="server" class="formcontent">
                                <asp:Label ID="lblRptrTypVal" runat="server" CssClass="control-label"></asp:Label>
                            </td>
                            <td id="Td24" runat="server" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="Label17" runat="server" CssClass="control-label"></asp:Label></span>
                            </td>
                            <td id="Td25" runat="server" class="formcontent">
                                <asp:Label ID="Label18" runat="server" CssClass="control-label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--added by pranjali on 05-01-2015 end for repeater case--%>
        <%--added by shreela for old license details start--%>
        <table id="tbloldlic" runat="server" style="width: 90%" class="tableIsys"
            visible="false">
            <%-- <tr>
            <td align="center" colspan="4">
                    <asp:Label ID="Label6" runat="server" Text="NOTE: License will be updated once license details are uploaded from Lic User" ForeColor="red"></asp:Label>
            </td>
        </tr>--%>
            <tr>
                <td id="tdoldlic" class="test" runat="server" colspan="4">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnOldLicDtls"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divoldlic', 'ctl00_ContentPlaceHolder1_BtnOldLicDtls');" />
                    <asp:Label ID="lbloldlic" runat="server" Text="Old License Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divoldlic" runat="server" style="display: none" visible="false">
            <table id="tbloldlicdtls" runat="server" class="tableIsys" style="width: 90%">
                <tr>
                    <td align="left" class="formcontent" style="width: 20%">
                        <asp:Label ID="lbloldlicno" Text="License No" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:Label ID="lbloldlicnoval" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%">
                        <asp:Label ID="lbloldexpdate" Text="Old LicenseExpDate" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:Label ID="lbloldexpdateval" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%">
                        <asp:Label ID="lbloldlicissu" Text="Old License Issue Date" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:Label ID="lbloldlicissuval" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 20%"></td>
                    <td class="formcontent" style="width: 30%"></td>
                </tr>
            </table>
        </div>
        <%--added by shreela for old license details end--%>
        <%--added by shreela for new license details start--%>
        <table id="tblnewlic" runat="server" style="width: 90%" class="tableIsys"
            visible="false">
            <tr>
                <td id="tdnewlic" class="test" runat="server" colspan="4">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnNewLicDtls"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divnewlic', 'ctl00_ContentPlaceHolder1_BtnNewLicDtls');" />
                    <asp:Label ID="lblnewlic" runat="server" Text="New License Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divnewlic" runat="server" style="display: none" visible="false">
            <table id="tblnewlicdtls" runat="server" class="tableIsys" style="width: 90%">
                <tr>
                    <td align="left" class="formcontent" style="width: 20%">
                        <asp:Label ID="lblnewlicno" Text="License No" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:Label ID="lblnewlicnoval" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%">
                        <asp:Label ID="lblnewexpdate" Text="LicenseExpDate" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:TextBox ID="txtnewexpdate" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtnewexpdate"
                            PopupButtonID="btnCalendar" Format="dd/MM/yyyy" Enabled="false" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true"
                            ControlToValidate="txtnewexpdate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Invalid date!"
                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtnewexpdate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtnewexpdate"
                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                        <%--  <asp:Label ID="Label8" runat="server"></asp:Label>--%>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%">
                        <asp:Label ID="lblnewlicissu" Text="License Issue Date" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:TextBox ID="txtnewlicissu" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Image ID="btnCalenderissu" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtnewlicissu"
                            PopupButtonID="btnCalenderissu" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                            ControlToValidate="txtnewlicissu" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Invalid date!"
                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtnewlicissu" Display="Dynamic"></asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtnewlicissu"
                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                    </td>
                    <td class="formcontent" style="width: 20%"></td>
                    <td class="formcontent" style="width: 30%"></td>
                </tr>
            </table>
        </div>
        <%--added by shreela for new license details end--%>
        <%--Added by rachana on 14022014 for Transfer Case Details end--%>
        <%--Added by rachana on 13022014 to show inbox cfr details start--%>
        <%--   tblCFRInboxCollapse disply none payment section by sanoj--%>

        
      
        <div style="display:none;">
            <table  style="width: 90%" class="tableIsys" runat="server">
                <tr>
                    <td align="left" class="test" colspan="4" style="width: 30">
                        
                    </td>
                </tr>
                <tr>
                    <td>
                      
                    </td>
                </tr>
                <tr>
                    <td id="Td14" runat="server" align="left" class="test" visible="false" colspan="4">
                       
                    </td>
                </tr>
                <tr>
                    <td>
                       
                    </td>
                </tr>
                <tr id="trRespond" runat="server" visible="false">
                    <td align="center">
                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;">
                            <i class="fa fa-comment"></i>--%>
                      
                        <%--</div>--%>
                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;">
                            <i class="fa fa-comment"></i>--%>
                       <%-- <asp:Button ID="btnCloseCfr" runat="server" Text="Close CFR" CssClass="standardbutton"
                            Width="114px" OnClick="btnCloseCfr_Click"></asp:Button>--%>
                        <%--</div>--%>
                    </td>
                </tr>
            </table>
        </div>
        <%--Added by rachana on 13022014 to show inbox cfr details end--%>
        <div id="tblupload" runat="server" class="rowspacing">
                <div class="row rowspacing">
                          <div class="col-sm-12">
                              <asp:Label ID="lblNote" runat="server" Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/PNG/PDF format"
                        ForeColor="red"></asp:Label>
                          </div>
                      </div>
             <div class="row rowspacing">
                          <div class="col-sm-12">
                               <asp:Label ID="lblNote1" runat="server" Text="To activate the check box of Agree to Application Terms and Conditions View T&C please upload signature"
                                                ForeColor="red"></asp:Label>
                          </div>
                      </div>
             <div class="row  rowspacing">
                          <div class="col-sm-6" style="text-align:left;">
                        <asp:Label ID="lblCanddoc" runat="server" Text="Document Upload" CssClass="control-label HeaderColor"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              </div>
                 <div class="col-sm-6" style="text-align:left;">

                 
                   <%-- <asp:Label ID="txtcolr" runat="server" CssClass="control-label" Width="20px" Height="12px" BackColor="LightPink"></asp:Label>
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Mandatory Documents" OnClick="lnkmandtry_click">
                    </asp:LinkButton>&nbsp;&nbsp;&nbsp;--%>
                         </div>     
                          </div>
         
 

            
            
        </div>
      
        <ajaxToolkit:ModalPopupExtender ID="mdlcfrdtls" runat="server" BehaviorID="mdlcfrdtlsID"
            DropShadow="false" TargetControlID="buttonNull" PopupControlID="pnlcfrdtls" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Button ID="buttonNull" runat="server" Style="display: none" />
        <asp:Panel runat="server" ID="pnlcfrdtls" Style="display: block; width: 30%; height: 50%">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <table class="tableIsys" align="center" style="width: 40%;">
                        <tr id="trdgDetails" runat="server">
                            <td class="formcontent" colspan="3" style="height: 40px">
                                <asp:GridView ID="dgDetails1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                    Width="450px" RowStyle-CssClass="tableIsys" AllowSorting="True">
                                    <%--OnRowDataBound="dgDetails_RowDataBound"OnSorting="dgDetails_Sorting" --%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Seq No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblseqno" runat="server" Text='<%# Bind("SeqNo") %>' Visible="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandatory Documents">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManDoc" runat="server" Text='<%# Bind("ImgDesc01") %>' Visible="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle Font-Names="verdana" />
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Center"></RowStyle>
                                    <HeaderStyle CssClass="portlet blue" Font-Bold="true" ForeColor="White" />
                                    <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <%--align="center">--%>
                                <%--<div class="btn btn-xs btn-primary" style="width: 90px;">
                                    <i class="fa fa-times"></i>--%>
                                <asp:Button ID="btnpopcancel" runat="server" CssClass="standardbutton" Text="Cancel" />
                                <%--</div>--%>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnpopcancel" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
        <div id="div1" runat="server" style="display: block;">
               <asp:UpdatePanel ID="upddgView" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgView" runat="server" AllowSorting="True" CssClass="footable"
                                    OnPageIndexChanging="dgView_PageIndexChanging"
                                     OnRowCommand="dgView_RowCommand"
                                    OnRowDataBound="dgView_RowDataBound"  AutoGenerateColumns="False"
                                    AllowPaging="True" Width="100%" PageSize="15">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Document Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldocName" runat="server" Font-Size="11px" Text='<%#Bind("ImgDesc01") %>'></asp:Label>
                                                <asp:Label ID="MandocName" runat="server" Font-Size="13px" Text="*" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="clsLeft" />
                                            <HeaderStyle CssClass="clsLeft" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Document Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldocDescription" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgDesc02") %>'></asp:Label>
                                            </ItemTemplate>
                                             <ItemStyle CssClass="clsLeft" />
                                            <HeaderStyle CssClass="clsLeft" />
                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Max. Size(kb)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                            </ItemTemplate>
                                             <ItemStyle CssClass="clscenter" />
                                            <HeaderStyle CssClass="clscenter" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Upload Documents">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                                    <ContentTemplate>
                                                        <asp:FileUpload ID="FileUpload" runat="server" ></asp:FileUpload>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_Upload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                             <ItemStyle CssClass="clscenter" />
                                            <HeaderStyle CssClass="clscenter" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btn_Upload" runat="server" CssClass="btn btn-success" Text="Upload" Enabled="false" Visible="false" Width="80px"
                                                            OnClick="btn_Upload_Click" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_Upload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btn_ReUpload" runat="server" CssClass="btn btn-success" Text="ReUpload"
                                                            OnClick="btn_ReUpload_Click" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                             <ItemStyle CssClass="clscenter" />
                                            <HeaderStyle CssClass="clsright" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgsize" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgshrt" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgwidth" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgheight" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManDoc" runat="server" Text='<%#Bind("IsMandatory") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldoccode" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("DocCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPreview" runat="server" Text="Preview" CommandArgument='<%# Eval("DocCode") %>' CommandName="Preview" 
                                                     Style="text-transform: capitalize;">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                           <ItemStyle CssClass="pad" HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>
                                    </Columns>
                                   <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="checkedchanged" />
                            </Triggers>
                        </asp:UpdatePanel>
        </div>
        <table class="formtable table-condensed" visible="false" id="Table1" runat="server" style="width: 90%;">
            <tr id="tr_DocumentReuploadTitle" runat="server" visible="false">
                <%--pranjali--%>
                <td class="test" colspan="3" style="text-align: left;">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" visible="false"
                        id="Button11" style="width: 20px;" onclick="funShowReqDtl('ctl00_ContentPlaceHolder1_divReUploadFiles', 'ctl00_ContentPlaceHolder1_BtnReUpload');" />
                    <%--<asp:Label ID="lblcndupload" runat="server" Font-Bold="True" Text=""></asp:Label>--%>
                    <asp:Label ID="lblcndupload" runat="server" Font-Bold="True"></asp:Label>
                    <%--  Candidate Document Re-Upload--%>
                </td>
            </tr>
        </table>
        <div id="div2" runat="server" style="display: none;">
            <table class="tableIsys" align="center" style="width: 90%;">
                <tr id="tr_reupload" runat="server" visible="false">
                    <td>
                        <%--//pranjali start--%>
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CssClass="tableIsys"
                            OnPageIndexChanging="GridView1_PageIndexChanging" PagerStyle-HorizontalAlign="Center"
                            PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                            OnRowDataBound="GridView1_RowDataBound" HorizontalAlign="Left" AutoGenerateColumns="False"
                            AllowPaging="True" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="210px">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldocName" runat="server" Text='<%#Bind("DocType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upload By" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpldBy" runat="server" Text='<%#Bind("UploadedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Uploaded Dt" HeaderStyle-Width="90px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdDtTm" runat="server" Text='<%#Bind("UploadedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFileName" runat="server" Text='<%#Bind("ServerFileName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <%--added by pranjali on 03-03-2014 start--%>
                                <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <%--added by pranjali on 03-03-2014 end--%>
                                <asp:TemplateField HeaderText="Reupload Documents" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:FileUpload ID="FileReUpload" runat="server" Width="340px" Filebytes='<%# Bind("UserFileName") %>'></asp:FileUpload>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_ReUpload" runat="server" CssClass="standardbutton" Text="ReUpload"
                                            OnClick="btn_ReUpload_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgsize1" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("maximgsize") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgshrt1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgwidth1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgheight1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldoccode1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("DocCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="sublinkodd"></RowStyle>
                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True"></PagerStyle>
                            <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
       
         <div width="100%"  id="TblTandC" visible="false" runat="server" >
                                    <div class="row rowspacing">
                         
                               <div class="col-sm-6">
                                    <asp:CheckBox ID="chkgst" Enabled="false" runat="server"/>
                                 <asp:Label ID="lblgst" runat="server" Text="GST Not Applicable" ></asp:Label>
                          </div>
                          <div class="col-sm-4" style="text-align:left">
                                     <asp:LinkButton ID="btngst"   runat="server" OnClick="btngst_Click" >View non-GST Declaration</asp:LinkButton>            
                              </div>                    
                                                   
                                                   
                      </div>
                      <div class="row rowspacing">
                          <div class="col-sm-6" style="margin-left: 77px;">
                               <asp:CheckBox ID="chkagree" Enabled="false"  runat="server"/>
                              <asp:Label ID="lblagree" runat="server" Text="Agree to Application Terms and Conditions" CssClass="control-label"></asp:Label>
                               </div>
                         <div class="col-sm-4" style="text-align:left">
                                                
                                                   
                                                     <asp:LinkButton ID="btnView"   runat="server" OnClick="btnView_Click" >View T&C</asp:LinkButton>
                            </div>
                           </div>
                                   </div>
         <%-- Added by usha for  Terms and condition on 01/06/2022--%>

        <div id="divButtons" runat="server" class="row rowspacing">
            <div class="col-sm-12 rowspacing" style="align-items:center">

                                  <asp:LinkButton  ID="btnnextDetails" runat="server" Visible="false" Text="" CssClass="btn btn-success " OnClick="btnnextDetails_Click" >   <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS</asp:LinkButton>
                <asp:LinkButton  ID="btnprevdoc" runat="server" Visible="false" Text="" CssClass="btn btn-success " OnClick="btnprevdoc_Click" >   <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS</asp:LinkButton>
                 
                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="SUBMIT"
                               CssClass="btn btn-success" Width="80px" OnClientClick="StartProgressBar();"></asp:Button>
                                
                  <asp:Button ID="btnRespond" runat="server" Text="RESPOND" CssClass="btn btn-success" 
                            Width="84px" OnClick="btnRespond_Click" Visible="false"></asp:Button>
                  <%--  Added by usha  on 24_04_2023--%>
                  <asp:Button ID="btnCloseCfr" runat="server" Text="CLOSE CFR" CssClass="btn btn-success"
                            Width="114px" OnClick="btnCloseCfr_Click" Visible="false"></asp:Button>

                <asp:Button ID="btnedit" runat="server" Style="display: none;" Text="Edit Image" OnClick="btnedit_Click"
                                Visible="false" CssClass="standardbutton" Width="80px"></asp:Button>

                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="SAVE" CssClass="standardbutton"
                                Width="80px" Visible="false" OnClientClick="StartProgressBar();"></asp:Button>

                            <asp:Button ID="BtnApprove" OnClick="btnApprove_Click" runat="server" Text="APPROVE"
                                CssClass="btn btn-success"  Visible="false" OnClientClick="StartProgressBar();"></asp:Button>

                            <asp:Button ID="btnReject" runat="server" Text="REJECT" CssClass="btn btn-success"
                                Visible="false" Width="80px" OnClick="btnReject_Click" OnClientClick="StartProgressBar();" />
                 <asp:Button ID="btnClear" TabIndex="43" OnClientClick="doCancel()"
                                runat="server" Text="CANCEL"
                                CssClass="btn btn-clear" Width="80px" OnClick="btnClear_Click"></asp:Button>
                         

                            <%--  Added by shreela on 14/07/2014 for renewals--%>

                        <asp:LinkButton  ID="btnCancel" runat="server" Text="" CssClass="btn btn-clear" OnClick="btnCancel_Click" >   <span class="glyphicon glyphicon-remove" style="color:#f04e5e"> </span> CANCEL</asp:LinkButton> 

                                   <asp:LinkButton  ID="btnnectcfr" runat="server" Text="" CssClass="btn btn-success " OnClick="btnnectcfr_Click" >  NEXT <span   class="glyphicon glyphicon-arrow-right BtnGlyphicon" ></span> </asp:LinkButton> 
                <asp:LinkButton  ID="btnnextdoc" runat="server" Text="" CssClass="btn btn-success " OnClick="btnnextdoc_Click" Visible="false">  NEXT <span   class="glyphicon glyphicon-arrow-right BtnGlyphicon" ></span> </asp:LinkButton> 


                            <asp:Button ID="btnCroprefresh" runat="server" CssClass="standardbutton" Style="display: none;"
                                ClientIDMode="Static" OnClick="btnCroprefresh_Click" /><%--added by shreela on 05/08/2014 fro cropping--%>
                            <asp:Button ID="btnReOpenReFresh" runat="server" CssClass="standardbutton" Style="display: none;"
                                ClientIDMode="Static" OnClick="btnReOpenReFresh_Click" />
                            <div id="divloader" runat="server" style="display: none;">
                                &nbsp;&nbsp;
                                <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                                Loading...
                            </div>
            </div>
        </div>
        <div  >
            <table>
                <tbody>
                    <tr>
                        <td style="height: 20px; padding-right: 10px;" align="center" colspan="2">

                           
                        </td>
                        <td style="height: 20px" align="center" colspan="2">
                            
                        </td>
                    </tr>
                </tbody>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdnBranchCode" runat="server" />
                        <asp:HiddenField ID="hdnflag" runat="server" />
                        <asp:HiddenField ID="hdnDocCode" runat="server" />
                        <%--//Added by rachana on 02-01-2014 for confirmation of approval--%>
                        <asp:HiddenField ID="hdnDoctype" runat="server" />
                        <asp:HiddenField ID="hdnprevcount" runat="server" />
                        <asp:HiddenField ID="hdnCandTypeRen" runat="server" />
                        <asp:HiddenField ID="hdnInsRenType" runat="server" />
                        <asp:HiddenField ID="hdncompinsren" runat="server" />
                        <%--shree--%>
                        <asp:HiddenField ID="hdnrenwlflag" runat="server" />
                        <%--shree--%>
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnStartDate" runat="server" />
                        <asp:HiddenField ID="hdnRenwlCnt" runat="server" />
                        <asp:HiddenField ID="hdnRenwl" runat="server" />
                    </td>
                    <td>
                        <input type="hidden" runat="server" id="hdnUserId" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnBizSrc" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnTrnLoc" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnTrnInst" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAgnPhoto" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAgnSign" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnTccID" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAppNo" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnCndNo" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnSDate" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnStateCode" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAgnCode" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnbtnVerify" runat="server" />
                        <asp:HiddenField ID="hdnbtnemailVerify" runat="server" />
                        <asp:HiddenField ID="hdnMobileVerify" runat="server" />
                        <asp:HiddenField ID="hdnEmpCode" runat="server" />
                         <asp:HiddenField ID="hdnModuleId" runat="server" />
                    </td>
                    <!-- Added by ank 12.01.2011-->
                    <td>
                        <asp:HiddenField ID="hdnWebTkn" runat="server" />
                    </td>
                    <!-- Added by Darshik 01.02.2013-->
                    <td>
                        <asp:HiddenField ID="hdnWebTknCon" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnEntryDate" runat="server" />
                    </td>
                    <asp:UpdatePanel ID="updPnlHidden" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hdnPan" runat="server" />
                            <asp:HiddenField ID="hdnEmail" runat="server" />
                            <asp:HiddenField ID="hdnMobile" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <td>
                        <asp:HiddenField ID="hdnCanid" runat="server" />
                        <asp:HiddenField ID="hdnpath" runat="server" />

                        <asp:Button Text="btnok" ID="btnopen" OnClick="btnopen_Click" runat="server" Visible="false" />
                    </td>
                </tr>
            </table>
        </div>
        <%--<div>
         <table style="width: 90%">
             <tbody>
                    <tr>
                        <td style="height: 20px" align="left" colspan="4">
                            <asp:Label ID="lblNotes" runat="server" Visible="true" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>--%>
        </div>
    </center>

    <asp:Panel ID="Panel2" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="75%" Height="100%" Style="display: none;">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px;">
                    <b>
                        <asp:Label runat="server" ID="lbltitle1" Text=""></asp:Label></b>
                </td>
            </tr>
        </table>
        <center>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <div id="divimage" runat="server" style="position: fixed; z-index: 3000; padding-left: 250px">
                        <center>
                            <asp:Image ID="imgbnd" runat="server" Height="250px" Width="250px" Style="position: fixed; z-index: 3000;" /><%--Height="200px" Width="250px"--%>
                        </center>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
        <center>
            <div style="position: fixed; z-index: 3000; text-align: center; padding-top: 350px; padding-left: 265px;">
                <asp:Label ID="Label10" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="-" onclick="zoom(0.9)" id="btnm" name="btnm" />&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="+" onclick="zoom(1.1)" id="btnp" name="btnp" />&nbsp;&nbsp;&nbsp;&nbsp;
     <%--           <input type="button"  id="btnrp1" name="btnrp" onclick="brnrotatep()"/>--%>
                <%--<input type="button"   id="btnrp"  name="btnp" img src="../../../theme/iflow/aa.png" onclick="brnrotatep()" height="22px" width="22px" />--%>
                <%--  <asp:Button id="btnrp" runat="server" name="btnp" img src="../../../theme/iflow/aa.png"  OnClientClick="brnrotatep(); return false;" height="22px" width="22px" />--%>
                <img src="../../../../theme/iflow/aa.png" height="22px" width="22px" id="btnrp" name="btnrp" onclick="brnrotatem()" />
                <%--    added by amruta 29/7/16 for rotation of image start--%>
                <asp:HiddenField ID="hdnRotateValue" runat="server" />
                <%--    added by amruta 29/7/16 for rotation of image end--%>
         &nbsp;&nbsp;&nbsp;&nbsp;

                
                <img src="../../../../theme/iflow/bb.png" height="22px" width="22px" id="btnrm" name="btnrm" onclick="brnrotatep1()" />

                <%--value="Rotate-"--%>
                <div style="padding-top: 10px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;    
                   <asp:Button ID="Button3" runat="server" Text="Cancel" Width="100px" Height="25px" CssClass="standardbutton" />
                    &nbsp;&nbsp;&nbsp;&nbsp;  
                  <%-- <asp:FileUpload id="FileUpload1"  runat="server">
                  </asp:FileUpload>--%>
                    <%--    added by amruta 29/7/16 for rotation of image start--%>
                    <asp:Button ID="btnRotateSave" runat="server" Text="Save" Width="100px" OnClick="lblRotate_Click" Height="25px" CssClass="standardbutton" />&nbsp;&nbsp;&nbsp;&nbsp;
              <%--    added by amruta 29/7/16 for rotation of image end--%>
                </div>
            </div>
        </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopupzoom" runat="server" TargetControlID="Label10"
        BehaviorID="mdlpopupzoom" BackgroundCssClass="modalPopupBg" PopupControlID="Panel2"
        OkControlID="btnok">
    </ajaxToolkit:ModalPopupExtender>
    <%--miti..for Raise CFR...Start--%>
    <asp:Panel runat="server" ID="PnlRaiseCFR" Width="700" display="none">
        <iframe runat="server" id="IframeRaiseCFR" width="700" height="450px" frameborder="0"
            display="none" style="background-color: White;"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="Label1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseCFR" BehaviorID="MdlPopRaiseCFR"
        DropShadow="true" TargetControlID="Label1" PopupControlID="PnlRaiseCFR" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--miti..for Raise CFR...end--%>
    <%-- //Ibrahim--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="400" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="400" height="300px" frameborder="0"
            display="none"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--issue popup 23.06.2022 start--%>
    <asp:Panel ID="pnl" runat="server" style="background-color: white;border-width: 0px;height: 232px;width: 405px;position: relative;z-index: 2;left:490px;">
        <table width="100%">
            <tr align="center">
                <td width="100%" colspan="1" style="height: 32px;color:#034ea2;font-size:19px">INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <center>
            <br />
            <asp:Label ID="lblpopup" runat="server"></asp:Label>
            <br />
            <span style="color: red">
                <asp:Label ID="Lblagentmsz" Visible="false" runat="server" Text="NOTE : <br/> This application will not flow to your reporting manager for approval unless agent profiling is completed in ARTL.<br/> Go to agent profiling tab under candidate sponsorship menu <br/> and complete agent profiling through web app."></asp:Label>
            </span>
        </center>
        <br />
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" Width="81px" OnClientClick="Closewin()" />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--issue popup 23.06.2022 end--%>
    <%--added by shreela on 14/07/2014--%><%--added by ajay 23.06.2022--%>

     <%--   added by sanoj --%>
   <div class="modal" id="msgModalPopup1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;" >
  <div class="modal-dialog" style="padding-top: 45px; width: 70%; margin-left: 35%;">
    <div class="modal-content" style=" width: 333px;">
        
<%--      <h3 style="padding-left: 33%;color: #00cccc;font-size: 19px;margin-top: 16px;">INFORMATION</h3>--%>
          <asp:Label ID="LblInfo" Text="INFORMATION" runat="server" Style="padding-left: 33%;color: #00cccc;font-size: 19px;margin-top: 16px;"></asp:Label>  <%--Font-Bold="false" --%>

        <div class="modal-body" style="text-align: center">
          
           <asp:Label ID="lblSub" runat="server" style=" font-size: 15px;"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align:center">
          <button type="button" class="btn btn-success" data-dismiss="modal" onclick="return Cancel(msgModalPopup1);" style="margin-right: 110px;border-radius: 6px;">
             <span class="glyphicon glyphicon-ok" style='color: White;'> </span> OK</button>
         
       
      </div>
        
        
     
    </div>

  </div>

</div>
      <%--    endded by sanoj 18042023--%>

    <asp:Panel ID="pnlSub" runat="server" BorderColor="ActiveBorder"
         class="modalpopupmesg" Width="321px" Height="266px">
        <table width="100%">
            <tr align="center">
                <td width="100%"  colspan="1" style="height: 32px">INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <center>
            <br />
           <%-- <asp:Label ID="lblSub" runat="server"></asp:Label> --%></center>
        <br />
        <center>
            <asp:Button ID="btnokSub" class="btn btn-success" runat="server" Text="OK" Width="81px" OnClientClick="CloseSub()" />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopupSub" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopupSub" BackgroundCssClass="modalPopupBg" PopupControlID="pnlSub"
        DropShadow="true" OkControlID="btnokSub" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--added by shreela on 14/07/2014--%>


    <%--added by shreela on 14/07/2014--%>
    <asp:Panel ID="pnlsave" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="321px" Height="266px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <center>
            <br />
            <asp:Label ID="lblsave" runat="server"></asp:Label></center>
        <br />
        <center>
            <asp:Button ID="btnoksave" runat="server" Text="OK" Width="81px" OnClientClick="funcClear()" />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopupSave" runat="server" TargetControlID="lblsave"
        BehaviorID="mdlpopupSave" BackgroundCssClass="modalPopupBg" PopupControlID="pnlsave"
        DropShadow="true" OkControlID="btnokSub" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--added by shreela on 14/07/2014--%>
    <asp:Panel ID="PanelPhoto" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="520px" Height="380px">
        <%--340px,350px--%>
        <center>
            <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height: 5%;">
                <tr>
                    <td>
                        <asp:Label ID="lblAdvisor" runat="server" Text="" CssClass="standardlink " />
                    </td>
                </tr>
            </table>
        </center>
        <table>
            <asp:Image ID="Image_Photo" runat="server" Width="520px" Height="340px" />
            <%--330,287--%>
        </table>
        <%-- added by shravana--%>
        <table width="100%">
            <tr align="center">
                <td bgcolor="gray" colspan="1" style="height: 32px" width="100%">
                    <asp:Button ID="Button1" runat="server" Text="OK" CssClass="btn-xs default" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup_photo" runat="server" TargetControlID="Image_Photo"
        BehaviorID="mdlpopup_photo" BackgroundCssClass="modalPopupBg" PopupControlID="PanelPhoto"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--//End Ibrahim--%>
    <asp:ListBox ID="LstImagepath" runat="server" Style="display: none"></asp:ListBox>
    <asp:ListBox ID="Listlabel" runat="server" Style="display: none"></asp:ListBox>
    <%--Addd by rachana on 1-07-2013 to fill all image path with listbox to fetch in JS function--%>
    <asp:ListBox ID="ListDoccode" runat="server" Style="display: none"></asp:ListBox>
    <%--Addd by rachana on 29-07-2013 to fill all image path with listbox to fetch in JS function--%>
    <asp:ListBox ID="ListID" runat="server" Style="display: none"></asp:ListBox>
    <%--panel for cnd view--%>
    <asp:Panel runat="server" ID="pnlMdlCnd" Width="760px" display="none">
        <iframe runat="server" id="Iframe1Cnd" width="790px" height="600px" frameborder="0"
            display="none"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1Cnd" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlViewCnd" BehaviorID="mdlViewBIDCnd"
        DropShadow="true" TargetControlID="lbl1Cnd" PopupControlID="pnlMdlCnd" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlMdlRen" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="280px" Height="180px" Visible="false">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">INFORMATION
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px;">
                    <br />
                    <center>
                        <asp:Label ID="lblRen" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="Button2" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn-xs default" /></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlViewRen" BehaviorID="mdlViewBIDRen"
        DropShadow="true" TargetControlID="lblRen" PopupControlID="pnlMdlRen" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
     <%--popup modified by ajay 21042023 start--%>
    <asp:Panel ID="pnlMdl1" runat="server"  style="background-color: white; border-color: activeborder; border-width: 2px; height: 230px; width: 280px; position: fixed; z-index: 100001; left: 500px; top: 100px;">
        <table width="100%">
            <tr align="center">
                <td width="100%" colspan="1" style="height: 32px; color: #034ea2; font-size: 22px;">INFORMATION
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px;">
                    <br />
                    <center>
                        <asp:Label ID="lblcfrrespnd" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btnCFROk" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn btn-success" /></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlCFRRespond" BehaviorID="mdlViewBIDRespnd"
        DropShadow="false" TargetControlID="lblcfrrespnd" PopupControlID="pnlMdl1" BackgroundCssClass="modalPopupBg" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--popup modified by ajay 21042023 end--%>
    <%--<asp:Panel ID="pnlMdl1" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="280px" Height="230px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">INFORMATION
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px;">
                    <br />
                    <center>
                        <asp:Label ID="lblcfrrespnd" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btnCFROk" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn btn-success" /></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlCFRRespond" BehaviorID="mdlViewBIDRespnd"
        DropShadow="true" TargetControlID="lblcfrrespnd" PopupControlID="pnlMdl1" BackgroundCssClass="modalPopupBg" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>--%>
    <asp:Panel runat="server" ID="PnlExm" Width="450" Height="320" display="none">
        <iframe runat="server" id="IframeExm" scrolling="no" width="100%" frameborder="0"
            display="none" style="height: 100%; background-color: White;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label6" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlViewBIDExm"
        DropShadow="true" TargetControlID="Label6" PopupControlID="PnlExm" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <%--Shreela  for Crop...Start--%>
    <asp:Panel runat="server" ID="PnlRaiseCrop" Width="1000px" display="none">
        <iframe runat="server" id="IframeRaiseCrop" frameborder="0" display="none" style="width: 1000px; padding: 10%; height: 500px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblCrop" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseCrop" BehaviorID="MdlPopRaiseCrop" DropShadow="false"
        TargetControlID="lblCrop" PopupControlID="PnlRaiseCrop" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Shreela  for Crop...End--%>

    <%--ReOpen  CFR...START--%>
    <asp:Panel runat="server" ID="PnlReOpenCFR" style="width: 600px;position: relative;z-index: 2;left: 5Px;" display="none">
        <iframe runat="server" id="IframeReOpenCFR" frameborder="0" display="none" style="width: 600px; height: 300px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblReOpenCFR" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopReOpenCFR" BehaviorID="MdlPopReOpenCFR" DropShadow="true"
        TargetControlID="lblReOpenCFR" PopupControlID="PnlReOpenCFR" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--ReOpen  CFR...END--%>

    <%--Loader popup start--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />
    <asp:HiddenField ID="ZoutSize" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="ZinSize" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: Grey;">

        <center>
            <img src="../../../App_Themes/Isys/images/spinner.gif" />
            <br />
            <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
        </center>
    </asp:Panel>

    <%--<div id="myModalImage" class="modal" style="padding-top: 10px">

        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" onclick="return Cancel(myModalImage);">&times;</button>
                    
                <div class="modal-title" style="margin-right:410px">
                    <asp:HiddenField ID="hdnImgId" runat="server" />
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <span style="font-weight: bold;">
                        <asp:Label ID="lblDocType" Text="Document Name : " CssClass="control-label" runat="server"></asp:Label></span>
                    <asp:Label ID="lblDocDesc" runat="server" Text="" CssClass="control-label"></asp:Label>
                </div>
            </div>
            <div class="modal-body">
                <center>
                    <div id="img-preview" style="overflow: auto">

                        <asp:Image ID="img3" runat="server" class="image-box" Style="cursor: move; margin-top: -7%;" />
                    </div>
                    <div class="img-op" id="img-op" style="padding-top: 2%;">

                        <asp:HiddenField ID="HiddenField3" runat="server" />
                        <asp:HiddenField ID="HiddenField4" runat="server" />
                        <asp:HiddenField ID="HiddenField5" runat="server" />

                        <span class="btn btn-primary zoom-in btnBorderRadius" onclick="return  zoomIn();">
                            <span class="glyphicon glyphicon-zoom-in" style="color: white; height: 14px"></span>Zoom In</span>
                        <span class="btn btn-primary zoom-out btnBorderRadius" onclick="return  zoomOut();">
                            <span class="glyphicon glyphicon-zoom-out" style="color: white; height: 14px"></span>Zoom Out</span>
                        <span class="btn btn-primary rotate btnBorderRadius" onclick="return  rotateImage();">
                            <span class="glyphicon glyphicon-repeat" style="color: white; height: 14px"></span>Rotate</span>
                    </div>

                    <div class="img-op" style="padding: 2px">
                    </div>
                    <asp:LinkButton ID="btnSaveImage" ClientIDMode="Static" runat="server" OnClick="btnSaveImage_Click" Text="Save Image"
                        CssClass="btn btn-primary btnBorderRadius" Style="font-size: 14px!important; background-color: rebeccapurple;">
                        <span class="  glyphicon glyphicon-floppy-disk" style="color:white;height:14px"></span> Save Image
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnApp" runat="server" ClientIDMode="Static" Text="Approve Image" CssClass="btn btn-success btnBorderRadius" OnClick="btnApp_click">
                                     <span class="glyphicon glyphicon-ok-circle" style="color:white;height:14px"></span> Approve Image
                    </asp:LinkButton>


                </center>
            </div>

            <div class="modal-footer" style="margin-right: 410px;">

                <asp:UpdatePanel ID="updbuttons" runat="server">
                    <ContentTemplate>
                        <button class="btn btn-sample btnBorderRadius" id="ButtonCROPImage" onclick="return funcopencrop1();" style="font-size: 14px!important;">
                            <span class="glyphicon glyphicon-edit" style="color: white; height: 14px"></span>Crop Image</button>
                        <button class="btn btn-warning btnBorderRadius" id="rasiseCFR" onclick="return RaiseCFR();">
                            <span class="glyphicon glyphicon-arrow-up" style="color: white; height: 14px"></span>CFR Raise</button>
                        <asp:Button ID="BtnCFR" TabIndex="43" Style="display: none;" OnClick="btnCFR_Click" runat="server" Text="Raise CFR"
                            CssClass="standardbutton" Width="80px"></asp:Button>

                        <button type="button" class="btn btn-danger btnBorderRadius" onclick="return Cancel(myModalImage);">
                            <span class="glyphicon glyphicon-remove" style="color: White"></span>Cancel</button>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>--%>

    <%--added by sanoj 30032023--%>
     <div id="myModalImage" class="modal" style="padding-top:10px"  >
 
        <div class="modal-content">

                <div class="modal-title">
                 <asp:HiddenField ID="hdnImgId" runat="server" />
                   <asp:HiddenField ID="hdnId" runat="server" />

                   </div>
                <div class="row" style=" margin-top: 10px;">
                     <div class="col-sm-3" style="text-align:center;">
                       
                                         <asp:Label ID="lblDocType" Text="Document Name:" CssClass="HeaderColor" style="font-size:17px;" runat="server"></asp:Label>

                  </div>
                         <div class="col-sm-8" style="text-align:left;">
                        
                                             <asp:Label ID="lblDocDesc"  runat="server" Text=""  CssClass="HeaderColor" style="font-size:17px;margin-left: -36px;"></asp:Label>

                  </div>
                         <div class="col-sm-1" style="margin-top: -10px;">
                          <%--<button type="button" class="btn"  onclick="return Cancel(myModalImage);" style="color:blue;font-size: 30px;">
                        &times; </button>--%>
                              <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return Cancel(myModalImage);"  style="color:blue;font-size: 30px;text-decoration: none;" >
                                   &times;
                              </asp:LinkButton>



                  </div>

                   </div>
          
            <div  class="modal-body">
                <center>
                        <div id="img-preview">
                          
                               <asp:Image id="img3" runat="server"   class="image-box" style="cursor: move;margin-top: -7%;" />

                             <iframe id="PDFImage1" runat="server" width="100%" height="350px"></iframe>
                        </div>
                        <div class="img-op">
                        
                         <asp:HiddenField ID="HiddenField3" runat="server" />
                        <asp:HiddenField ID="HiddenField4" runat="server" />
                        <asp:HiddenField ID="HiddenField5" runat="server" />

                    </div>
                   
  
                  </center>  
                 </div>

                   
                     
             
        
            <div class="footer" style="text-align: center;margin-bottom: 14px;">
             
                <asp:UpdatePanel ID="updbuttons" runat="server">
                    <ContentTemplate>
                     <div class="row" >
                    <div id="divImgBtn">
                        
                      
                              <span class="btn" onclick="return  zoomIn();" style="font-size: 10px;" >
                               <span class="glyphicon glyphicon-zoom-in" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> ZOOM IN</span>
                 
                                 <span class="btn" onclick="return  zoomOut();" style="font-size: 10px;" >
                                    <span class="glyphicon glyphicon-zoom-out" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> ZOOM OUT</span>
                 
                            <span class="btn" onclick="return  rotateImage();" style="font-size: 10px;" >
                                    <span class="glyphicon glyphicon-repeat" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> ROTATE</span>
                 
                      <asp:LinkButton ID="btnSaveImage" runat="server" style="font-size: 10px;" Text="Save Image" CssClass="btn" OnClick="btnSaveImage_Click" >
                        <span class="glyphicon glyphicon-floppy-disk" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> SAVE 
                              </asp:LinkButton>
                 
                         <button class="btn" id="ButtonCROPImage"  onclick="return funcopencrop1();" style="font-size: 10px;display: none;"  >
                         <span class="glyphicon glyphicon-edit" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> CROP</button>

                
                      <button class="btn" id="btnBlur"  onclick="return funcopenBlur();" style="font-size: 10px;display: none;" >
                         <span class="glyphicon glyphicon-adjust" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> BLUR </button>
                  
                       <button class="btn"  id="rasiseCFR" onclick="return RaiseCFR();" style="font-size: 10px;" >
                       <span class="glyphicon glyphicon-arrow-up" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> CFR RAISE</button>
                
                           
                        <asp:LinkButton ID="btnApp" runat="server" Text="Approve Image" CssClass="btn" style="font-size: 10px;" OnClick="btnApp_click" >
                                     <span class="glyphicon glyphicon-ok-circle" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> APPROVE 
                              </asp:LinkButton>
			       <button type="button" class="btn btn-danger btnBorderRadius" style="display: none;"  onclick="return Cancel(myModalImage);">
                            <span class="glyphicon glyphicon-remove" style="color: White"></span>CANCEL</button>

                         <asp:Button ID="BtnCFR" TabIndex="43" Style="display: none;" OnClick="btnCFR_Click" runat="server" Text="Raise CFR"
                            CssClass="standardbutton" Width="80px"></asp:Button>
                  
                  
                    </div>

                    <div id="divPdfBtn">
                        <asp:LinkButton ID="LinkButton2" ClientIDMode="Static" runat="server" OnClick="btnSavePDF_Click" Text="Save Image"
                        CssClass="btn" Style="display: none; font-size: 10px;">
                        <span class="  glyphicon glyphicon-floppy-disk" style="color:#00cccc;height:14px"></span> SAVE IMAGE
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" runat="server" ClientIDMode="Static" Visible="false" Text="Approve Image" CssClass="btn" OnClick="lnkbtnPDFApprv_click" Style="font-size: 10px;">
                                     <span class="glyphicon glyphicon-ok-circle" style="color:#00cccc;height:14px;font-size: 16px !important;"></span> <br></br> APPROVE 
                    </asp:LinkButton>
				<%--	<button class="btn" id="btnPDFCFR" onclick="return RaiseCFR();" style="font-size: 10px;">
                            <span class="glyphicon glyphicon-arrow-up" style="color: #00cccc; height: 14px;font-size: 16px !important;"></span>  </br>CFR RAISE</button>--%>
                      </div>

                 </div>

                
              
                     </ContentTemplate>
                   </asp:UpdatePanel>
            </div>
             </div>
       
</div>
  
    

    <div class="modal" id="msgModalPopup" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;" >
  <div class="modal-dialog" style="padding-top: 53px;width: 70%;">
    <div class="modal-content" style=" width: 329px;margin-left: 79px;">
      
      <h3 style="margin-top: 23px;color:blue;font-size:18px;text-align: center;">INFORMATION</h3>
         
        <div class="modal-body" style="text-align: center">
          
          <asp:Label ID="Label15" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align:center">
          <button type="button" class="btn btn-success" data-dismiss="modal" onclick="return Cancel(msgModalPopup);" style="margin-right: 110px;border-radius: 6px;">
             <span class="glyphicon glyphicon-ok" style='color: White;'> </span> OK</button>
         
       
      </div>
       
     
    </div>

  </div>

</div>
      <%--endded by sanoj 30032023--%>

    <div id="PDFImgModal" class="modal" style="padding-top: 10px">

        <div class="modal-content">
            <div class="">
                <%--<button type="button" class="close" onclick="return Cancel(PDFImgModal);">
                    &times;</button>--%>
                <div class="modal-title">
                    <asp:HiddenField ID="hdnPDFImgID" runat="server" />
                    <asp:HiddenField ID="hdnPDFID" runat="server" />
                   
                       
                   
                </div>
                 <div class="row" style=" margin-top: 10px;margin-bottom: -30px;" >
                     <div class="col-sm-3" style="text-align:center;">
                       
                                         <asp:Label ID="lblPDFDocName" Text="Document Name : " CssClass="HeaderColor" runat="server" style="font-size:17px;"></asp:Label>

                  </div>
                         <div class="col-sm-8" style="text-align:left;margin-left: -32px;">
                        
                                             <asp:Label ID="lblPDFDocDesc" runat="server" Text="" CssClass="HeaderColor" style="font-size:17px;"></asp:Label>

                  </div>
                         <div class="col-sm-1" style="margin-left: 25px;margin-top: -16px;">
                          <button type="button" class="btn"  onclick="return Cancel(PDFImgModal);" style="color:blue;font-size: 30px;">
                        &times; </button>



                  </div>

                   </div>


            </div>
            <div class="modal-body">
                <center>
                    <div id="PDFImgPreview" style="overflow: auto">
                         <iframe id="PDFImage" runat="server" width="100%" height="350px"></iframe>
                    </div>
                    <div class="img-op" id="pdf-op" style="padding-top: 2%;">
                        <asp:HiddenField ID="HiddenField8" runat="server" />
                        <asp:HiddenField ID="HiddenField9" runat="server" />
                        <asp:HiddenField ID="HiddenField10" runat="server" />
                    </div>

                    <div class="img-op" style="padding: 2px">
                    </div>
                    <asp:LinkButton ID="btnSavePDF" ClientIDMode="Static" runat="server" OnClick="btnSavePDF_Click" Text="Save Image"
                        CssClass="btn btn-primary btnBorderRadius" Style="display: none; font-size: 14px!important; background-color: rebeccapurple;">
                        <span class="  glyphicon glyphicon-floppy-disk" style="color:white;height:14px"></span> Save Image
                    </asp:LinkButton>
                   
                </center>
            </div>
            <div class="footer" style="text-align: center;margin-bottom: 25px;">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <div class="row"> 
                        <div id="divPdfBtn1">
                       
                        <asp:LinkButton ID="LinkButton4" ClientIDMode="Static" runat="server" OnClick="btnSavePDF_Click" Text="Save Image"
                        CssClass="btn" Style="display: none; font-size: 10px;">
                        <span class="  glyphicon glyphicon-floppy-disk" style="color:#00cccc;height:14px"></span> SAVE IMAGE
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnPDFApprv" runat="server" ClientIDMode="Static" Text="Approve Image" CssClass="btn" OnClick="lnkbtnPDFApprv_click" Style="font-size: 10px;">
                                     <span class="glyphicon glyphicon-ok-circle" style="color:#00cccc;height:14px;font-size: 16px !important;"></span> <br></br> APPROVE 
                    </asp:LinkButton>
					<button class="btn" id="btnPDFCFR" onclick="return RaiseCFR();" style="font-size: 10px;">
                            <span class="glyphicon glyphicon-arrow-up" style="color: #00cccc; height: 14px;font-size: 16px !important;"></span>  
                            <br>  </br>CFR RAISE</button>
                      </div>

               
                            </div>



                        <asp:Button ID="Button6" TabIndex="43" Style="display: none;" OnClick="btnCFR_Click" runat="server" Text="Raise CFR"
                            CssClass="standardbutton" Width="80px"></asp:Button>

                       

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div class="modal" id="myModalRaise" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 10px;">
        <div class="modal-dialog" style="padding-top: 0px; width: 90%;">
            <div class="modal-content" style="margin-left: -69px; width: 142%;">
                <div class="">
                     <div class="row" style=" margin-top: 10px;">
                     <div class="col-sm-3" style="text-align:center;">
                       
                                         <asp:Label ID="Label16" Text="Raise CFR For:" CssClass="HeaderColor" style="font-size:17px;" runat="server"></asp:Label>

                  </div>
                                <div class="col-sm-8" style="text-align:left;margin-left: -35px;">
                        
                                             <asp:Label ID="Label19"  runat="server" Text=""  CssClass="HeaderColor" style="font-size:17px;margin-left: -16px;"></asp:Label>

                  </div>
                         <div class="col-sm-1" style="margin-left: 25px;margin-top: -16px;">
                              <asp:LinkButton ID="lnkRaise" TabIndex="43" style="color:blue;font-size: 30px;"
                        runat="server"
                        CssClass="btn"> &times;
                                  
                    </asp:LinkButton>
                          <%--<button type="button" class="btn"  onclick="return Cancel(myModalRaise);" style="color:blue;font-size: 30px;">
                        &times; </button>--%>



                  </div>

                   </div>
                    <%--<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Raise CFR</h4>--%>
                </div>
                <div class="modal-body">
                    <iframe id="iframeCFR" src="" width="675" height="300" frameborder="0" allowtransparency="true"></iframe>
                </div>
                <div class="modal-footer">

                   

                </div>
            </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
   
<%--added by sanoj 01042023--%>
    <div class="modal" id="myModalCrop" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;" >
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
                       

                              <button type="button" class="btn"  onclick="return Cancel(myModalCrop);">
                      <span   style="color:blue;font-size: 30px;"> &times;</span></button>
                  </div>
        </div>
                   

      <div class="modal-body" >
          <iframe id="iframe1" src="" width="675" height="320" frameborder="0" allowtransparency="true"></iframe> 
          
      </div>
      
      </div>
    </div>
    <!-- /.modal-content -->
  </div>
 <%--   <div class="modal" id="myModalCrop" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 10px; width: 100%">
        <div class="modal-dialog" style="padding-top: 0px; width: 70%;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="H1">Crop Image</h4>
                </div>
                <div class="modal-body">
                    <iframe id="iframe1" src="" width="675" height="300" frameborder="0" allowtransparency="true" style="width: 100%"></iframe>
                </div>
                <div class="modal-footer">

                    <asp:LinkButton ID="lnkModalCrop" TabIndex="43"
                        runat="server"
                        CssClass="btn btn-danger btnBorderRadius">
                                    <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                    </asp:LinkButton>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>--%>
  <%--  added by sanoj 13062023 for reopen--%>
      <div class="modal" id="myModalReopen" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;" >
  <div class="modal-dialog" style="
    padding-top: 0px;
    width: 70%; margin-top: 50px;">
    <div class="modal-content" style="width: 141% !important;margin-left: -72px;margin-top:5px;">
      <div class="modal-body" >
          <iframe id="IframeReOpenCFR1" src="" width="675" height="250" frameborder="0" allowtransparency="true"></iframe> 
          
      </div>
      
      </div>
    </div>
          </div>
    <!-- /.modal-content -->
 <%--  Endded by sanoj 13062023 for reopen--%>


    <%--added by sanoj 01042023--%>
    <asp:HiddenField ID="hdnraise" runat="server" />
    <asp:HiddenField ID="hdnrespond" runat="server" />
    <asp:HiddenField ID="hdnclose" runat="server" />
    <asp:HiddenField ID="hdnCFR" runat="server" />
    <asp:HiddenField ID="hdnHt" runat="server" />
    <asp:HiddenField ID="hdnWt" runat="server" />
    <asp:HiddenField ID="hndcndtype" runat="server" />
    <asp:HiddenField ID="hdnDocName" runat="server" />
    <%--Loader popup end--%>
    <script language="javascript" type="text/javascript">
        var path = "<%=Request.ApplicationPath.ToString()%>";
        var imgno = 1;
        //Added by nikhil
        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
        //ended  by nikhil
        function SpaceTrim(InString) {
            var LoopCtrl = true;
            while (LoopCtrl) {
                if (InString.indexOf("  ") != -1) {
                    Temp = InString.substring(0, InString.indexOf("  "));
                    InString = Temp + InString.substring(InString.indexOf("  ") + 1, InString.length);
                }
                else
                    LoopCtrl = false;
            }
            if (InString.substring(0, 1) == " ")
                InString = InString.substring(1, InString.length);
            if (InString.substring(InString.length - 1) == " ")
                InString = InString.substring(0, InString.length - 1);
            return (InString);
        }

        //added by Nikhil Pathari  on 10-09-2015 for grid in composite endss
        function CheckSpaces() {
            //debugger;


            var strContent = "ctl00_ContentPlaceHolder1_";
            if (SpaceTrim(document.getElementById(strContent + "txtGivenName").value) == "") {
                alert("Please Enter Given Name");
                document.getElementById(strContent + "txtGivenName").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            var GivenName = document.getElementById('<%= txtGivenName.ClientID %>').value;
            if (GivenName.length < 3) {
                alert("GivenName should be atleast of three Characters");
                document.getElementById('<%= txtGivenName.ClientID %>').focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            var strText = document.getElementById(strContent + "txtGivenName").value;
            strText = SpaceTrim(strText);
            document.getElementById(strContent + "txtGivenName").value = strText;
            var count = 0;

            if (strText.length > 0) {
                for (var i = 0; i < strText.length; i++) {
                    if (strText.charAt(i) == " ") {
                        count++;
                    }
                }
                if (count > 2) {
                    alert("More than 2 spaces are not allowed in Given Name");
                    document.getElementById(strContent + "txtGivenName").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }



            }

        }
        //Ended by Nikhil Pathari on 10-09-2015 for Given Name Space validation end

        //Added by Nikhil Pathari on 10-09-2015 for father Name Space validation start

        function AllowSpace() {
            //debugger;


            var strContent = "ctl00_ContentPlaceHolder1_";

            if (SpaceTrim(document.getElementById('<%= txtFathername.ClientID %>').value) == "") {
                alert("Please Enter Father/Spouse Name");
                document.getElementById('<%= txtFathername.ClientID %>').focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            var lenFather = document.getElementById('<%= txtFathername.ClientID %>').value;
            if (lenFather.length < 3) {
                alert("Father/Spouse Name should be atleast of three Characters");
                document.getElementById('<%= txtFathername.ClientID %>').focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            var strText = document.getElementById(strContent + "txtFathername").value;
            strText = SpaceTrim(strText);
            document.getElementById(strContent + "txtFathername").value = strText;
            var count = 0;

            if (strText.length > 0) {
                for (var i = 0; i < strText.length; i++) {
                    if (strText.charAt(i) == " ") {
                        count++;
                    }
                }
                if (count > 1) {
                    alert("More than 1 spaces are not allowed in Father Name");
                    document.getElementById(strContent + "txtFathername").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }

                //ProgressBarModalPopupExtender.Hide();

            }

        }






        //Ended by Nikhil Pathari on 10-09-2015 for Father Name Space validation end
        function Validation() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////
            var StateCode = (document.getElementById("<%=hdnStateCode.ClientID %>").value);

            if (StateCode == "ME" || StateCode == "SI") {
            }
            else {
                if (document.getElementById("<%=txtPAN.ClientID%>").value == "") {
                    alert("Please Enter PAN No");
                    document.getElementById("<%=txtPAN.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
//            if (document.getElementById("<%=txtPAN.ClientID%>").value != "") {
//                if (CheckPANFormat(document.getElementById("<%=txtPAN.ClientID%>").value) == 0) {
//                    alert("Please Enter Valid PAN No");
//                    document.getElementById("<%=txtPAN.ClientID%>").focus();
//                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
//                    return false;
//                }

//            }
            if ((document.getElementById(strContent + "txtMobileNo").value) == "") {
                alert("Please Enter Mobile No");
                document.getElementById(strContent + "txtMobileNo").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            var Mobile = (document.getElementById('<%= txtMobileNo.ClientID %>').value);
            if (Mobile.length != 10) {
                alert("Mobile No should be 10 digit");
                document.getElementById(strContent + "txtMobileNo").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if ((document.getElementById(strContent + "txtEMail").value) == "") {
                alert("Please Enter Email");
                document.getElementById(strContent + "txtEMail").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //Validate Transfer Case
            debugger;
            if (document.getElementById("<%=cbTrfrFlag.ClientID %>") != null) {
                if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked == "") {
                    if (document.getElementById(strContent + "txtOldTccLcnNo").value != null) {
                        if (document.getElementById(strContent + "txtOldTccLcnNo").value == "") {
                            alert("License Number for Transfer is Mandatory");
                            document.getElementById(strContent + "txtOldTccLcnNo").focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById(strContent + "txtDate").value == "")//txtOldTccLcnExpDate_txtDate
                    {
                        alert("License Expiry Date for Transfer is Mandatory");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtDate").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    if (document.getElementById(strContent + "txtissudate").value == "") {
                        alert("License Issue Date for Transfer is Mandatory.");
                        document.getElementById(strContent + "txtissudate").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    //			        
                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "")) {
                        alert("Insurer Name for Transfer is Mandatory.");
                        document.getElementById('<%= ddlTrnsfrInsurName.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                    //                    if (document.getElementById(strContent + "txtCndURNNo").value == "") {
                    //                        alert("Candidate URN No. is Mandatory.");
                    //                        document.getElementById(strContent + "txtCndURNNo").focus();
                    //                        var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    //                        return false;
                    //                    }
                }
            }

            //added by pranjali on 13-03-2014 for composite start
            debugger;
            if (document.getElementById("<%=cbTccCompLcn.ClientID %>") != null) {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                    if (document.getElementById(strContent + "txtCompLicNo").value == "") {
                        alert("License Number for Composite is Mandatory");
                        document.getElementById(strContent + "txtCompLicNo").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }


                    if (document.getElementById(strContent + "txtCompLicExpDt").value == "")//txtOldTccLcnExpDate_txtDate
                    {
                        alert("License Expiry Date for Composite is Mandatory");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtCompLicExpDt").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    //			        
                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                        alert("Insurer Name for Composite is Mandatory.");
                        document.getElementById('<%= ddlCompInsurerName.ClientID %>').focus();
                                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                                            return false;
                                        }
                    //added by pranjali on 13-03-2014 end
                                    }
                                }

            //added by pranjali on 13-03-2014 for composite end
            //added by pranjali on 11-04-2014 start
                                if (document.getElementById('<%=ddlExam.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExam.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExam.ClientID %>').value == "")) {
                    alert("Please Select Exam Mode");
                    document.getElementById('<%= ddlExam.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlExmBody.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExmBody.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmBody.ClientID %>').value == "")) {
                                        alert("Please Select Examination Body");
                                        document.getElementById('<%= ddlExmBody.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlpreeamlng.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "")) {
                    alert("Please Select Prefered Exam Language");
                    document.getElementById('<%= ddlpreeamlng.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=txtExmCentre.ClientID %>') != null) {
                if ((document.getElementById('<%=txtExmCentre.ClientID%>').value == "--Select--") || (document.getElementById('<%=txtExmCentre.ClientID%>').value == "")) {
                    alert("Please Select Exam Centre");
                    document.getElementById('<%=txtExmCentre.ClientID%>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //            if (document.getElementById('<%=ddlExmCentre.ClientID %>') != null) {
            //                if ((document.getElementById('<%=ddlExmCentre.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmCentre.ClientID %>').value == "")) {
            //                    alert("Exam Centre is Mandatory.");
            //                    document.getElementById('<%= ddlExmCentre.ClientID %>').focus();
            //                    return false;
            //                }
            //            }

            //added by pranjali on 11-04-2014 end

            //added by pranjali on 28-04-2014 start
            if (document.getElementById('<%=ddlNExam.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlNExam.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlNExam.ClientID %>').value == "")) {
                    alert("Please Select Exam Mode");
                    document.getElementById('<%= ddlNExam.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlNExmBody.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlNExmBody.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlNExmBody.ClientID %>').value == "")) {
                    alert("Please Select Examination Body");
                    document.getElementById('<%= ddlNExmBody.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlNpreeamlng.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlNpreeamlng.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlNpreeamlng.ClientID %>').value == "")) {
                    alert("Please Select Prefered Exam Language");
                    document.getElementById('<%= ddlNpreeamlng.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=txtNExmCenter.ClientID %>') != null) {
                if ((document.getElementById('<%=txtNExmCenter.ClientID %>').value == "--Select--") || (document.getElementById('<%=txtNExmCenter.ClientID %>').value == "")) {
                    alert("Please Select Exam Centre");
                    document.getElementById('<%= txtNExmCenter.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //            if (document.getElementById('<%=ddlNExmCenter.ClientID %>') != null) {
            //                if ((document.getElementById('<%=ddlNExmCenter.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlNExmCenter.ClientID %>').value == "")) {
            //                    alert("Exam Centre is Mandatory.");
            //                    document.getElementById('<%= ddlNExmCenter.ClientID %>').focus();
            //                    return false;
            //                }
            //            }

            //added by pranjali on 28-04-2014 end







            //Added by rachana for fees validation




            //shree07
            //                //added by shreela on18042014 for renewals validation
            //                if (document.getElementById('<%=hdnCandTypeRen.ClientID %>').value == "C") {
            //                    if ((document.getElementById('<%=ddlRenewType.ClientID %>').value == "---Select---") || (document.getElementById('<%=ddlRenewType.ClientID %>').value == "")) {
            //                        alert("Insurer Type is Mandatory.");
            //                        document.getElementById('<%= ddlRenewType.ClientID %>').focus();
            //                        return false;
            //                    }
            //                    if (document.getElementById('<%=hdnInsRenType.ClientID %>').value == "L") {
            //                        if ((document.getElementById('<%=ddllyfTraining.ClientID %>').value == "---Select---") || (document.getElementById('<%=ddllyfTraining.ClientID %>').value == "")) {
            //                            alert("Life Training Completed is Mandatory.");
            //                            document.getElementById('<%= ddllyfTraining.ClientID %>').focus();
            //                            return false;
            //                        }
            //                    } //shree
            //                }

        }


        //added by pranjali on 04-03-2014 start
        function funvalidateApprove() {
            //added by rachana on 1/04/2014 for Trn Type validation start
            var strContent = "ctl00_ContentPlaceHolder1_";
            debugger;

            //added by rachana on 1/04/2014 for Trn Type validation end
            //added by pranjali on 11-04-2014 start
            if (document.getElementById('<%=ddlExam.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExam.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExam.ClientID %>').value == "")) {
                    alert("Please Select Exam Mode");
                    document.getElementById('<%= ddlExam.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlExmBody.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExmBody.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmBody.ClientID %>').value == "")) {
                    alert("Please Select Examination Body");
                    document.getElementById('<%= ddlExmBody.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlpreeamlng.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "")) {
                    alert("Please Select Prefered Exam Language");
                    document.getElementById('<%= ddlpreeamlng.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (document.getElementById('<%=txtExmCentre.ClientID %>') != null) {
                if ((document.getElementById('<%=txtExmCentre.ClientID%>').value == "--Select--") || (document.getElementById('<%=txtExmCentre.ClientID%>').value == "")) {
                    alert("Please Select Exam Centre");
                    document.getElementById('<%=txtExmCentre.ClientID%>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //            if (document.getElementById('<%=ddlExmCentre.ClientID %>') != null) {
            //                if ((document.getElementById('<%=ddlExmCentre.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmCentre.ClientID %>').value == "")) {
            //                    alert("Exam Centre is Mandatory.");
            //                    document.getElementById('<%= ddlExmCentre.ClientID %>').focus();
            //                    return false;
            //                }
            //            }

            //added by pranjali on 11-04-2014 end
            if (document.getElementById("ctl00_ContentPlaceHolder1_cbTrfrFlag") != null) {
                if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked != true) {
                    debugger;
                    if (document.getElementById('<%=ddlTrnMode.ClientID %>') != null) {
                        if ((document.getElementById('<%= ddlTrnMode.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "")) {
                            alert("Please Select the Training Mode");
                            document.getElementById('<%= ddlTrnMode.ClientID  %>').focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById('<%=ddlTrnLoc.ClientID %>') != null) {
                        if ((document.getElementById("<%=ddlTrnLoc.ClientID%>").value == "--Select--") || (document.getElementById('<%=ddlTrnLoc.ClientID %>').value == "")) {
                            alert("Please Select the Training Location");
                            document.getElementById("<%=ddlTrnLoc.ClientID%>").focus();
                           var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                           return false;
                       }
                   }
                   if (document.getElementById('<%=ddlTrnInstitute.ClientID %>') != null) {
                        if ((document.getElementById('<%=ddlTrnInstitute.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlTrnInstitute.ClientID %>').value == "")) {
                       alert("Please Select Training Institute");
                       document.getElementById("<%=ddlTrnInstitute.ClientID%>").focus();
                       var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                       return false;
                   }
               }

                    //                   if (document.getElementById('<%=ddlHrsTrn.ClientID %>') != null) {
                    //            if ((document.getElementById('<%= ddlHrsTrn.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlHrsTrn.ClientID %>').value == "")) {
                    //                 alert("Please Select Training Hours");
                    //                  document.getElementById('<%= ddlHrsTrn.ClientID  %>').focus();
                    //               var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    //                 return false;
                    //              }
                    //         }

                }
            }

            //shree
            if (document.getElementById("<%=hdnrenwlflag.ClientID %>").value == "Y") {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                    if (document.getElementById('<%=txtCompLicNo.ClientID %>').Value == "") {
                        alert("Please Enter Life LicenseNo.");
                        document.getElementById("<%=txtCompLicNo.ClientID %>").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (document.getElementById('<%=txtCompLicExpDt.ClientID %>').Value == "") {
                        alert("Please Enter License Exp.Date");
                        document.getElementById("<%=txtCompLicExpDt.ClientID %>").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (document.getElementById('<%=ddlCompInsurerName.ClientID %>') != null) {
                        if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                            alert("Please Select Insurer Name");
                            document.getElementById("<%=ddlCompInsurerName.ClientID%>").focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }


                }
                //shree07
                //added by shreela on18042014 for renewals validation
                if (document.getElementById('<%=hdnCandTypeRen.ClientID %>').value == "Composite") {
                    if ((document.getElementById('<%=ddlRenewType.ClientID %>').value == "---Select---") || (document.getElementById('<%=ddlRenewType.ClientID %>').value == "")) {
                        alert("Insurer Type is Mandatory.");
                        document.getElementById('<%= ddlRenewType.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    if (document.getElementById('<%=hdnInsRenType.ClientID %>').value == "L") {
                        if (document.getElementById('<%=ddllyfTraining.ClientID %>') != null) {
                            if ((document.getElementById('<%=ddllyfTraining.ClientID %>').value == "---Select---") || (document.getElementById('<%=ddllyfTraining.ClientID %>').value == "")) {
                                alert("Life Training Completed is Mandatory.");
                                document.getElementById('<%= ddllyfTraining.ClientID %>').focus();
                                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                                return false;
                            }
                        } //shree
                    }
                }
            }
            //shree
            //Validate Transfer Case
            debugger;
            if (document.getElementById("<%=cbTrfrFlag.ClientID %>") != null) {
                if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked == "") {
                    if (document.getElementById(strContent + "txtOldTccLcnNo").value != null) {
                        if (document.getElementById(strContent + "txtOldTccLcnNo").value == "") {
                            alert("License Number for Transfer is Mandatory");
                            document.getElementById(strContent + "txtOldTccLcnNo").focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById(strContent + "txtDate").value == "")//txtOldTccLcnExpDate_txtDate
                    {
                        alert("License Expiry Date for Transfer is Mandatory");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtDate").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }


                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "")) {
                        alert("Insurer Name for Transfer is Mandatory.");
                        document.getElementById('<%= ddlTrnsfrInsurName.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                    //                    if (document.getElementById(strContent + "txtCndURNNo").value == "") {
                    //                        alert("Candidate URN No. is Mandatory.");
                    //                        document.getElementById(strContent + "txtCndURNNo").focus();
                    //                        var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    //                        return false;
                    //                    }

                    if (document.getElementById(strContent + "txtissudate").value == "") {
                        alert("License Issue Date for Transfer is Mandatory.");
                        document.getElementById(strContent + "txtissudate").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }
            }

            //added by pranjali on 13-03-2014 for composite start
            debugger;
            if (document.getElementById("<%=cbTccCompLcn.ClientID %>") != null) {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                    if (document.getElementById(strContent + "txtCompLicNo").value == "") {
                        alert("License Number for Composite is Mandatory");
                        document.getElementById(strContent + "txtCompLicNo").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }


                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                        alert("Insurer Name for Composite is Mandatory.");
                        document.getElementById('<%= ddlCompInsurerName.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                }
            }

            //added by pranjali on 13-03-2014 for composite end

        }
        //added by pranjali on 04-03-2014 end
        function ValidationPAN() {

            var varPAN = document.getElementById('<%= txtPAN.ClientID %>').value;
            document.getElementById('<%= lblPANMsg.ClientID %>').style.display = 'none';

            if (varPAN.length == 0) {
                alert('Please Enter PAN No.');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }
            if (varPAN.length < 10) {
                alert('PAN No. must have minimum 10 characters');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }

            if (varPAN.length != 10) {
                alert('PAN No. should be 10 characters.');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }

            document.getElementById('divPAN').style.display = 'block'

        }
        function CheckPANFormat(strPANNo) {
            var result = true;
            var pan = strPANNo.split(",");
            var Char;

            var pan2 = pan[0]
            if (pan2 != "") {
                if (pan2.length == 10) {
                    for (j = 0; j < pan2.length && result == true; j++) {
                        Char = pan2.substring(j, j + 1);

                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 9) {
                            if (!isAlphabet(Char)) {
                                return 0;
                            }
                            if (j == 3) {
                                if (pan2.substring(j, j + 1) != 'P')
                                    return 0;
                            }
                        }
                        if (j == 5 || j == 6 || j == 7 || j == 8) {
                            if (!IsNumeric(Char)) {
                                return 0;
                            }
                        }
                    }
                }
                else {
                    return 0;
                }
            }
            return 1;
        }

        function funOpenPopWinExmCentre(strPageName, strExmCentreName, strtxtExmCentreName, strhdnExmCCode) {
            if (document.getElementById('<%=ddlExam.ClientID %>').value == "--Select--") {
                alert("Please Select Exam Mode");
                return false;
            }
            else {
                if (document.getElementById('<%=ddlExam.ClientID %>').value == "1") {
                    alert("To Select Exam Center within 85 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                }
                else if (document.getElementById('<%=ddlExam.ClientID %>').value == "2") {
                    alert("To Select Exam Center within 100 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                }
                showPopWin(strPageName + "?txtExmCentreName=" + document.getElementById(strExmCentreName).value +
            "&strtxtExmCentreName=" + strtxtExmCentreName +
            "&strhdnExmCCode=" + strhdnExmCCode + "&ExmMode=" + document.getElementById('<%=ddlExam.ClientID %>').value + "&SalesUnitCode=" + "&BizSrc="
            + document.getElementById('<%=hdnBizSrc.ClientID %>').value + "&ExmBody=" + document.getElementById('<%=ddlExmBody.ClientID %>').value, 750, 350, null);

            }
        }


        function funOpenPopWinTrnInstitute(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "--Select--") {
                alert("Please Select Training Mode");
                return false;
            }
            else {
                showPopWin(strPageName + "?txtTrnInstName=" + document.getElementById(strTrnInstitute).value +
            "&strtxtTrnInstitute=" + strtxtTrnInstitute +
            "&strhdnTrnInstitute=" + strhdnTrnInstitute + "&Page=TrnInst&TrnMode=" + document.getElementById('<%=ddlTrnMode.ClientID%>').value, 750, 350, null);
            }
        }

        function funOpenPopWinTrnLocation(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "--Select--") {
                alert("Please Select Training Mode");
                return false;
            }
            else {
                showPopWin(strPageName + "?txtTrnInstName=" + document.getElementById(strTrnInstitute).value +
            "&strtxtTrnInstitute=" + strtxtTrnInstitute +
            "&strhdnTrnInstitute=" + strhdnTrnInstitute + "&Page=TrnLoc&TrnMode=" + document.getElementById('<%=ddlTrnMode.ClientID%>').value + "&TrnInst="
            + document.getElementById('<%=hdnTrnInstitute.ClientID%>').value, 750, 350, null);
            }
        }

        //        function funcopencrop1() {
        //            debugger;
        //            $find("MdlPopRaiseCrop").show();
        //            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCrop").src = "../../../Application/ISys/Recruit/CropImage.aspx?CndNo=" +
        //                 document.getElementById('<%=hdnCndNo.ClientID%>').value + "&args3=" +
        //                 document.getElementById('<%=lblpanelheader.ClientID%>').innerText + "&mdlpopup=MdlPopRaiseCrop"
        //                 + "&DocName=" + $('#<%=lblDocDesc.ClientID%>').text();


        //        } //added byusha on 25/08/2016 for croping


        function funcopencrop1() {
            debugger;
            document.getElementById('ctl00_ContentPlaceHolder1_lblImageCrop').innerHTML = 'Crop Image'; //added by sanoj 21-03-2023
            var modal = document.getElementById('myModalCrop');
            var modaliframe = document.getElementById("iframe1");
            var cndno = document.getElementById('<%=hdnCndNo.ClientID%>').value;
            var userid = document.getElementById('<%=hdnUserId.ClientID%>').value;
            modaliframe.src = "../../../Application/ISys/ChannelMgmt/FPCropImage.aspx?Flag=QC&MemCode=" + document.getElementById('<%=hdnCndNo.ClientID%>').value + "&args3="
             + document.getElementById('<%=hdnImgId.ClientID%>').value + "&mdlpopup=MdlPopRaiseCrop" + "&DocName=" + $('#<%=lblDocDesc.ClientID%>').text();
            var span = document.getElementsByClassName("close")[0];

            span.onclick = function () {
                //  debugger;
                modal.style.display = "none";

            }
            modal.style.display = "block";
           // $('#myModalCrop').modal();

        }

        function FuncReOpen(lblRemarkidValue, lblAddnlRemark, ModuleID) {
            debugger;
            var modal = document.getElementById('myModalReopen');
            modal.style.display = "block";
            
            //$find("MdlPopReOpenCFR").show();
            document.getElementById("IframeReOpenCFR1").src = "../../../Application/ISys/ChannelMgmt/FPPopReOpenCFR.aspx?RemarkId=" + lblRemarkidValue + "&Remarks=" + lblAddnlRemark + "&ModuleID=" + ModuleID + "&mdlpopup=MdlPopReOpenCFR";
        }

        function funcShowPopup(strPopUpType) // To populate popup of exam centre
        {
            if (strPopUpType == "RaiseCFR") {
                debugger;
                if (document.getElementById('<%=TxtTrnsfrReqNo.ClientID %>') != null) {
                    $find("MdlPopRaiseCFR").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/ChannelMgmt/FPPopRaiseCFR.aspx?MemCode=" + document.getElementById('<%=hdnCndNo.ClientID%>').value
                     + "&UserId=" + document.getElementById('<%=hdnUserId.ClientID%>').value
                     + "&ModuleID=" + document.getElementById('<%=hdnModuleId.ClientID%>').value 
                     + "&args1=" +document.getElementById('<%=BtnApprove.ClientID%>').id + "&args2=" + document.getElementById('<%=BtnCFR.ClientID%>').id + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerHTML + "&args4=" +
                 document.getElementById('<%=hdnDocId.ClientID%>').value + "&args5=" +
                 document.getElementById('<%=hdnDocCode.ClientID%>').value + "&raised=" +
                 document.getElementById('<%=lblcfrrais1count.ClientID%>').id + "&responded=" +
                 document.getElementById('<%=lblcfrrespondcount.ClientID%>').id + "&closed=" +
                 document.getElementById('<%=lblcfrclosed.ClientID%>').id + "&TransfrReqNo=" +
                 document.getElementById('<%=TxtTrnsfrReqNo.ClientID%>').value + "&FlagCode=Trnsfr" + "&mdlpopup=MdlPopRaiseCFR";
                }
                else {
                    $find("MdlPopRaiseCFR").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/ChannelMgmt/FPPopRaiseCFR.aspx?MemCode=" +
                 document.getElementById('<%=hdnCndNo.ClientID%>').value
                  + "&UserId=" + document.getElementById('<%=hdnUserId.ClientID%>').value
                   + "&ModuleID=" + document.getElementById('<%=hdnModuleId.ClientID%>').value 
                  + "&args1=" +
                 document.getElementById('<%=BtnApprove.ClientID%>').id + "&args2=" + document.getElementById('<%=BtnCFR.ClientID%>').id + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerHTML + "&args4=" +
                 document.getElementById('<%=hdnDocId.ClientID%>').value + "&args5=" +
                 document.getElementById('<%=hdnDocCode.ClientID%>').value + "&raised=" +
                 document.getElementById('<%=lblcfrrais1count.ClientID%>').id + "&responded=" +
                 document.getElementById('<%=lblcfrrespondcount.ClientID%>').id + "&closed=" +
                 document.getElementById('<%=lblcfrclosed.ClientID%>').id +  "&FlagCode=Others" + "&mdlpopup=MdlPopRaiseCFR";
                }
            }
            if (strPopUpType == "ExmCentre") {
                debugger;
                $find("mdlViewBIDExm").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeExm").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?ExmCentre=" +
                 document.getElementById('<%=txtExmCentre.ClientID%>').value + "&field1=" + document.getElementById('<%=txtExmCentre.ClientID %>').id +
                 "&field2=" + document.getElementById('<%=hdnExmCentreCode.ClientID %>').id +
                 "&mdlpopup=mdlViewBIDExm";
            }

            if (strPopUpType == "NExmCentre") {
                debugger;
                $find("mdlViewBIDExm").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeExm").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?ExmCentre=" +
                 document.getElementById('<%=txtNExmCenter.ClientID%>').value + "&field1=" + document.getElementById('<%=txtNExmCenter.ClientID %>').id +
                 "&field2=" + document.getElementById('<%=hdnNExmCenter.ClientID %>').id +
                 "&mdlpopup=mdlViewBIDExm";
            }
            if (strPopUpType == "ExamCentre") {
                if (document.getElementById('<%=ddlExam.ClientID %>').value == "--Select--") {
                    alert("Please Select Exam Mode");
                    return false;
                }
                else {
                    if (document.getElementById('<%=ddlExam.ClientID %>').value == "1") {
                        alert("To Select Exam Center within 85 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                    }
                    else if (document.getElementById('<%=ddlExam.ClientID %>').value == "2") {
                        alert("To Select Exam Center within 100 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                    }
                    $find("mdlViewBID").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?txtExmCentreName=" +
                    document.getElementById('<%=txtExmCentre.ClientID %>').value + "&strtxtExmCentreName=" + document.getElementById('<%=txtExmCentre.ClientID %>').id +
                    "&strhdnExmCCode=" + document.getElementById('<%=hdnExmCentreCode.ClientID %>').id + "&ExmMode=" + document.getElementById('<%=ddlExam.ClientID %>').value +
                     "&BizSrc=" + document.getElementById('<%=hdnBizSrc.ClientID %>').value +
                    "&ExmBody=" + document.getElementById('<%=ddlExmBody.ClientID %>').value + "&mdlpopup=mdlViewBID";

                }
            }
        }

        function funOpenPopWinTrnLocation(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "--Select--") {
                alert("Please Select Training Mode");
                return false;
            }
            else {
                showPopWin(strPageName + "?txtTrnInstName=" + document.getElementById(strTrnInstitute).value +
            "&strtxtTrnInstitute=" + strtxtTrnInstitute +
            "&strhdnTrnInstitute=" + strhdnTrnInstitute + "&Page=TrnLoc&TrnMode=" + document.getElementById('<%=ddlTrnMode.ClientID%>').value + "&TrnInst=" + document.getElementById('<%=hdnTrnInstitute.ClientID%>').value, 750, 350, null);
            }
        }
        function PopWaiver(CscCode) {

            showPopWin("../../../Application/Common/PopWaiverAdvisor.aspx?Code=" + CscCode
                    , 500, 100, null);
        }


        //added by pranjali on 11-04-2014 start
        function ShowReqDtl(divId, btnId) {

            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+'
                //document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }
        //added by pranjali on 11-04-2014 end
        function ShowReqDtlNew(divId, btnId) {
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
        //        function funShowReqDtl(divId, btnId) {

        //            if (document.getElementById(divId).style.display == "block") {
        //                document.getElementById(divId).style.display = "none";
        //                //document.getElementById(divId).value = '+'
        //                document.getElementById("ctl00_ContentPlaceHolder1_BtnUpload").value = '+';
        //            }
        //            else {
        //                document.getElementById(divId).style.display = "block";
        //                //document.getElementById(btnId).value = '-'
        //                document.getElementById("ctl00_ContentPlaceHolder1_BtnUpload").value = '-';
        //            }
        //        }

        //        function funChkOpnCfr(count) {


        //            if (count > 0) {
        //                var confirmed = confirm('CFR is still open. Do you want to approve?');
        //                if (confirmed == true) {

        //                    document.getElementById("ctl00_ContentPlaceHolder1_hdnflag").value = 1;
        //                    return true;
        //                }
        //            }
        //            else if (count == 0) {
        //                var confirmed = confirm('CFR not raised yet/CFR closed. Do you want to approve?');
        //                if (confirmed == true) {

        //                    document.getElementById("ctl00_ContentPlaceHolder1_hdnflag").value = 1;
        //                    return true;
        //                }
        //            }
        //            else {

        //                document.getElementById("ctl00_ContentPlaceHolder1_hdnflag").value = 0;
        //                return true;
        //            }
        //        }
        //}

        //Added by rachana on 02-01-2014 for confirmation of approval end
        function Closewin() {

            window.close();
        }

        //Added by shreela on 11-07-2014 start
        function CloseSub() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            window.parent.document.getElementById("btnReFresh").click();
        }

        function OpenPOP() {
            debugger;
            //window.opener.document.getElementById("ctl00_ContentPlaceHolder1_btnReFresh");
            window.parent.document.getElementById("btnReFresh").click();
        }
        //Added by shreela on 11-07-2014 end

        function funcClear() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

        //Added for transfer case start

        function RecursiveEnabled(control) {
            var children = control.childNodes;
            try { control.removeAttribute('disabled') }
            catch (ex) { }
            for (var j = 0; j < children.length; j++) {
                RecursiveEnabled(children[j]);
            }
        }

        //Added for transfer case end
        function PopupModal() {
            //debugger;
            var modal = $find('mdlcfrdtlsID');

            if (modal) {
                if (modal.show) {
                    modal.show();
                }
                else {
                    alert("nope!");
                }
            }
            else {
                throw modal;
            }
        }

        //added by shreela on 12/03/14 for validation on mobile no and email start
        function form2() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            // debugger;
            if ((document.getElementById(strContent + "txtMobileNo").value) == "") {
                alert("Mobile No is mandatory.");
                document.getElementById(strContent + "txtMobileNo").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            else {
                //                var Mobile = (document.getElementById('<%= txtMobileNo.ClientID %>').value);
                //                if ((Mobile.substr(0, 1)) != "0") {
                //                    alert("Mobile Number should start with 0");
                //                    document.getElementById(strContent + "txtMobileNo").focus();
                //                    return false;
                //                }
                var Mobile = (document.getElementById('<%= txtMobileNo.ClientID %>').value);
                if (Mobile.length != 10) {
                    alert("Mobile No should be 10 digit.");
                    document.getElementById(strContent + "txtMobileNo").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

            }
            return true;
        }

        function validateEmail1() {

            //debugger;
            var Email = (document.getElementById('<%= txtEMail.ClientID %>').value);
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!Email.match(reEmail)) {
                alert("Invalid Email Address");
                document.getElementById("<%=txtEMail.ClientID%>").focus();

                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            return true;

        }
        //added by shreela on 12/03/14 for validation on mobile no and email end


        //Added by shreela on 8/04/2014 for Renewal start
        function validateRenewal() {
            debugger;
            if (document.getElementById('<%=ddlRenewType.ClientID%>').value == "---Select---") {
                alert("Insurer Type is Mandatory");
                document.getElementById('<%=ddlRenewType.ClientID%>').focus();
                return true;
            }
            else if (document.getElementById('<%=ddllyfTraining.ClientID%>').value == "---Select---") {
                alert("Please select Life Training");
                document.getElementById('<%=ddllyfTraining.ClientID%>').focus();
                return true;
            }
    }
    function ShowReqDtlRenew(divId, btnId) {
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
    function AlertMsgs(msgs) {
        alert(msgs);
    }

    //Added by shreela on 8/04/2014 for Renewal end

    //changing color of fees at 2nd Qc
    function btnClick() {
        debugger;
        var x = document.getElementById("tbltest").getElementsByTagName("FeesRow");
        // var y = document.getElementById("tblICMDtls").getElementsByTagName("trTokenwithFees");
        x.style.backgroundColor = "yellow";
        //y.style.backgroundColor = "red";
    }
    //added by Nikhil Pathari  on 10-09-2015 
    function CheckSpaces() {
        //debugger;


        var strContent = "ctl00_ContentPlaceHolder1_";
        if (SpaceTrim(document.getElementById(strContent + "txtGivenName").value) == "") {
            alert("Please Enter Given Name");
            document.getElementById(strContent + "txtGivenName").focus();
            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            return false;
        }


        var GivenName = document.getElementById('<%= txtGivenName.ClientID %>').value;
        if (GivenName.length < 3) {
            alert("GivenName should be atleast of three Characters");
            document.getElementById('<%= txtGivenName.ClientID %>').focus();
            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            return false;
        }
        var strText = document.getElementById(strContent + "txtGivenName").value;
        strText = SpaceTrim(strText);
        document.getElementById(strContent + "txtGivenName").value = strText;
        var count = 0;

        if (strText.length > 0) {
            for (var i = 0; i < strText.length; i++) {
                if (strText.charAt(i) == " ") {
                    count++;
                }
            }
            if (count > 2) {
                alert("More than 2 spaces are not allowed in Given Name");
                document.getElementById(strContent + "txtGivenName").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;

            }



        }

    }
    //Ended by Nikhil Pathari on 10-09-2015 for Given Name Space validation end

    //Added by Nikhil Pathari on 10-09-2015 for father Name Space validation start

    function AllowSpace() {
        //debugger;


        var strContent = "ctl00_ContentPlaceHolder1_";

        if (SpaceTrim(document.getElementById('<%= txtFathername.ClientID %>').value) == "") {
            alert("Please Enter Father/Spouse Name");
            document.getElementById('<%= txtFathername.ClientID %>').focus();
            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            return false;
        }


        var lenFather = document.getElementById('<%= txtFathername.ClientID %>').value;
        if (lenFather.length < 3) {
            alert("Father/Spouse Name should be atleast of three Characters");
            document.getElementById('<%= txtFathername.ClientID %>').focus();
            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            return false;
        }
        var strText = document.getElementById(strContent + "txtFathername").value;
        strText = SpaceTrim(strText);
        document.getElementById(strContent + "txtFathername").value = strText;
        var count = 0;

        if (strText.length > 0) {
            for (var i = 0; i < strText.length; i++) {
                if (strText.charAt(i) == " ") {
                    count++;
                }
            }
            if (count > 1) {
                alert("More than 1 spaces are not allowed in Father Name");
                document.getElementById(strContent + "txtFathername").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;

            }

            //ProgressBarModalPopupExtender.Hide();

        }

    }






    //Ended by Nikhil Pathari on 10-09-2015 for Father Name Space validation end

    //Added by rachana for showinfg loader image on approve,save,submit, reject button start
    function StartProgressBar() {

        var myExtender = $find('ProgressBarModalPopupExtender');
        myExtender.show();

        return true;
    }

    //Added by rachana for showinfg loader image on approve,save,submit, reject button end
    </script>
</asp:Content>

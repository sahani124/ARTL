<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="AdvTrnHrsReqSubmit.aspx.cs" Inherits="Application_INSC_Recruit_AdvTrnHrsReqSubmit" Title="Untitled Page" %>

<%@ Register Src="../../../App_UserControl/Common/ctlDate.ascx" TagName="ctlDate"
    TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
       <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    --%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <%-- <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
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
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>


    <script type="text/javascript" src="/../../../Script/JQuery/jquery.min.js"></script>
    <script type="text/javascript" src="../../../KMI%20Styles/Bootstrap/js/jquery.imagebox.js"></script>--%>

    <%--  strat by sanoj 23112022--%>

    <link href="../../../kmi%20styles/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

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

    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <%--<script type="text/javascript" src="../../../Scripts/subModal.js"></script>--%>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>


    <script type="text/javascript" src="/../../../Script/JQuery/jquery.min.js"></script>
    <script type="text/javascript" src="../../../KMI%20Styles/Bootstrap/js/jquery.imagebox.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style>
        .panel {
            margin-top: 10px;
        }
    </style>
    <style type="text/css">
        .clscenter {
            text-align: center !important;
        }

        .left-space {
            margin-left: 9px !important;
        }

        .imgheight {
            display: block;
            max-width: 100%;
            height: 50px;
        }

        .textalign th {
            padding-left: 42%;
        }

        .modal-dialog {
            position: relative;
            display: table;
            overflow-y: auto;
            overflow-x: auto;
            width: auto;
            min-width: 50px;
        }

        .modal-header {
            min-height: 16.42857143px;
            padding: 15px;
            border-bottom: 1px solid #e5e5e5;
            background-color: #034ea2 !important;
            color: #ffffff;
        }

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
    </style>

    <script type="text/javascript">

        /*added by sanoj 23032023*/
        function showUrnDiv() {
            debugger;
            var chkPassport = document.getElementById("ctl00_ContentPlaceHolder1_cbTrfrFlag");
            var dvPassport = document.getElementById("ctl00_ContentPlaceHolder1_UrnNo");

            if (chkPassport.checked) {
                dvPassport.setAttribute('style', 'text-align: left;margin-top: 17px;display: block;');
            }
            else {
                dvPassport.style.display = 'none';
            }
       

        }

        /*Ended by sanoj 23032023*/
        function healthdiv() {
            debugger;
                if (document.getElementById('ctl00_ContentPlaceHolder1_cbHealth').checked == true) {
                    var divhealth = document.getElementById('ctl00_ContentPlaceHolder1_trHealthIns');
                    divhealth.style.display = "block";
                }
             else {
                var divhealth = document.getElementById('ctl00_ContentPlaceHolder1_trHealthIns');
                divhealth.style.display = "none";
            }
             
        }

        function lifediv() {
            debugger;
            if (document.getElementById('ctl00_ContentPlaceHolder1_cbLife').checked == true) {
                var divlife = document.getElementById('ctl00_ContentPlaceHolder1_trIns');
                divlife.style.display = "block";
            }
            else {
                var divlife = document.getElementById('ctl00_ContentPlaceHolder1_trIns');
                divlife.style.display = "none";
            }
        }

        
        // __doPostBack('lnkAddTag', 'OnClick');
        function pageLoad() {
            // added by pratik for calender 19/3/2018
            $("#<%= txtDateOfAppointmentTrnsfr.ClientID  %>").datepicker({
             dateFormat: 'dd/mm/yy', changeMonth: true,
             changeYear: true
         });  // Will run at every postback/AsyncPostback

         $("#<%= txtIC.ClientID  %>").datepicker({
             dateFormat: 'dd/mm/yy', changeMonth: true,
             changeYear: true
         });

         $("#<%= txtDateOfCessationTrnsfr.ClientID  %>").datepicker({
             dateFormat: 'dd/mm/yy', changeMonth: true,
             changeYear: true
         });
         $("#<%= txtTagApp.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true
            });
            // __doPostBack('lnkAddTag', 'OnClick');
        }


        function DoPost() {
            __doPostBack('ddlTrnLoc', '');

        }

        function Dopostback() {
            __doPostBack('lnkAddTag', 'OnClick');
        }


        $(function () {
            //  debugger;
            pageLoad();
        });


        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();

        });

    </script>
    <style type="text/css">
        .image td {
            padding-left: 20% !important;
        }
    </style>
    <style type="text/css">
        #myImg {
            border-radius: 5px;
            cursor: pointer;
            transition: 0.3s;
        }

            #myImg:hover {
                opacity: 0.7;
            }

        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.2); /* Black w/ opacity */
        }

        /* Modal Content (image) */
        .modal-content {
            margin: auto;
            display: block;
            width: 100%; /*Meena*/
            max-width: 700px;
        }

        /* Caption of Modal Image */
        #caption {
            margin: auto;
            display: block;
            width: 80%;
            max-width: 700px;
            text-align: center;
            color: #ccc;
            padding: 10px 0;
            height: 150px;
        }

        /* Add Animation */
        .modal-content, #caption {
            -webkit-animation-name: zoom;
            -webkit-animation-duration: 0.6s;
            animation-name: zoom;
            animation-duration: 0.6s;
        }

        @-webkit-keyframes zoom {
            from {
                -webkit-transform: scale(0);
            }

            to {
                -webkit-transform: scale(1);
            }
        }

        @keyframes zoom {
            from {
                transform: scale(0);
            }

            to {
                transform: scale(1);
            }
        }

        /* The Close Button */
        .close {
            position: absolute;
            top: 15px;
            right: 35px;
            color: #f1f1f1;
            font-size: 40px;
            font-weight: bold;
            transition: 0.3s;
        }

            .close:hover,
            .close:focus {
                color: #bbb;
                text-decoration: none;
                cursor: pointer;
            }

        /* 100% Image Width on Smaller Screens */
        @media only screen and (max-width: 700px) {
            .modal-content {
                width: 100%;
            }
        }
    </style>
    <style type="text/css">
        #img-preview {
            height: 255px;
            width: auto;
            overflow: auto;
            text-align: center;
        }

        .img-op {
            margin-top: 5px;
            text-align: center;
        }

        .modal .modal-content .btn {
            border-radius: 0;
        }

        .img-op .bt {
            margin: 5px;
            width: 100px;
        }

        .modal-footer .btn-default {
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
        }

        .modal-backdrop {
            position: inherit;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: 1040;
            background-color: #000;
        }

            .modal-backdrop.fade {
                filter: alpha(opacity=0);
                opacity: 0;
            }

            .modal-backdrop.in {
                filter: alpha(opacity=50);
                opacity: .5;
            }
    </style>
    <script type="text/javascript">

        var doccode;
        var arg03, Transfr;
        var ZinSize, ZoutSize;
        var MstWidth, MstHeight;
        var ImgWidth, ImgHeight, Size, flag;
        var counter;
        function Cancel(modalimg) {
            debugger;
            var modal = modalimg;
            modal.style.display = "none";


        }
        function Cancel1(modalimg, modalimg1) {
            debugger;
            var modal = modalimg;
            var modal1 = modalimg1;
            modal.style.display = "none";
            modal1.style.display = "none";


        }
        function funcopencrop1() {
            debugger;
            document.getElementById('ctl00_ContentPlaceHolder1_lblImageCrop').innerHTML = 'Crop Image'; //added by sanoj 21-03-2023
            var modal = document.getElementById('myModalCrop');
            var modaliframe = document.getElementById("iframe1");
            var cndno = document.getElementById('<%=hdnCndNo.ClientID%>').value;
            var userid = document.getElementById('<%=hdnUserId.ClientID%>').value;
            modaliframe.src = "../../../Application/ISys/Recruit/CropImage.aspx?Flag=QC&CndNo=" + document.getElementById('<%=hdnCndNo.ClientID%>').value + "&args3=" + document.getElementById('<%=hdnImgId.ClientID%>').value + "&mdlpopup=MdlPopRaiseCrop";
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

        function funcopenBlur() {
            debugger;
            document.getElementById('ctl00_ContentPlaceHolder1_lblImageCrop').innerHTML = 'Image Blur'; //added by sanoj 21-03-2023
            var modal = document.getElementById('myModalCrop');
            var modaliframe = document.getElementById("iframe1");
            var cndno = document.getElementById('<%=hdnCndNo.ClientID%>').value;
             var userid = document.getElementById('<%=hdnUserId.ClientID%>').value;
             modaliframe.src = "../../../Application/ISys/Recruit/BlurImage.aspx?Flag=QC&CndNo=" + document.getElementById('<%=hdnCndNo.ClientID%>').value + "&args3=" + document.getElementById('<%=hdnImgId.ClientID%>').value + "&mdlpopup=MdlPopRaiseCrop";
            var span = document.getElementsByClassName("close")[0];

            span.onclick = function () {
                //  debugger;
                modal.style.display = "none";

            }
            var pouId = document.getElementById("myModalImage");//added by sanoj 06032023
            pouId.style.display = 'none';
            modal.style.display = 'block'; //added by sanoj 06032023
            

        }
        // Get the modal
        function showimage(ImgId, ImgCode, Height, Width, ZinSize1, ZoutSize1, MstWidth1, MstHeight1, Flag, Doctype) {
            debugger;
            document.getElementById('divPdfBtn').style.display = 'none'; //added b y sanoj 06032023
            document.getElementById('divImgBtn').style.display = 'block'; //added b y sanoj 06032023

            $('#ctl00_ContentPlaceHolder1_hdnRotateValue').val("0");
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
            ImgSrc = "ImageCSharp.aspx?ImageID=" + ImgId;
            // Get the image and insert it inside the modal - use its "alt" text as a caption
            var img = document.getElementById("ctl00_ContentPlaceHolder1_PDFImage1");
            img.style.display = 'none'; //added  by sanoj 04022023
            var modalImg = document.getElementById("ctl00_ContentPlaceHolder1_img3");
            // $("#ctl00_ContentPlaceHolder1_img3").imageBox();
            $("#ctl00_ContentPlaceHolder1_hdnId").val(ImgId);


            doccode = ImgCode;
            modal.style.display = "block";
            modalImg.src = ImgSrc;
            modalImg.alt = this.alt;
            modalImg.width = Width;
            modalImg.height = Height;
            $("#ctl00_ContentPlaceHolder1_img3").removeAttr("style");
            var myBookId = $("#" + ImgCode).data('original-title');
            // $("#ctl00_ContentPlaceHolder1_lblDocDesc").text(myBookId);
            document.getElementById("ctl00_ContentPlaceHolder1_lblDocDesc").innerHTML = Doctype //added bysanoj 25112022
            document.getElementById("ctl00_ContentPlaceHolder1_lblForcfr").innerHTML = Doctype //added bysanoj 25112022
          
            $("#ctl00_ContentPlaceHolder1_hdnImgId").val(Doctype);
            // document.getElementById("ctl00_ContentPlaceHolder1_lblDocDesc").innerHTML = Doctype; //added bysanoj 25112022
            if (Doctype == "Photo" || Doctype == "Signature") {
                $("#btnCrop").show();
            }
            else {
                $("#btnCrop").hide();
            }
            if (Flag == 2) {
                $('#ctl00_ContentPlaceHolder1_btnApp').attr("disabled", true);
            }
            else {
                $('#ctl00_ContentPlaceHolder1_btnApp').attr("disabled", false);
            }
            arg03 = Doctype;


            //  document.getElementById("lblDocType").value=Doctype; 
            //var captionText = $("#"+ImgId).attr("data-title");
            //document.getElementById("lblDocDesc").value() = captionText;
            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];
            var span1 = document.getElementsByClassName("btn btn-default")[0];


            // When the user clicks on <span> (x), close the modal
            span.onclick = function () {
                //  debugger;
                modal.style.display = "none";
                var clickButton = document.getElementById("ctl00_ContentPlaceHolder1_PageReLoad");
                clickButton.click();
                return true;
            }
            span1.onclick = function () {
                // debugger;
                modal.style.display = "none";
                var clickButton = document.getElementById("ctl00_ContentPlaceHolder1_PageReLoad");
                clickButton.click();
                return true;
            }

        }
        //PDF

        function showPDF(PDFId, ImgCode, Height, Width, ZinSize1, ZoutSize1, MstWidth1, MstHeight1, Flag, Doctype, PopDesc) {
            debugger;
            document.getElementById('divPdfBtn').style.display = 'block'; //added b y sanoj 06032023
            document.getElementById('divImgBtn').style.display = 'none'; //added b y sanoj 06032023
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
            var modal = document.getElementById('myModalImage'); //    PDFImgModal
              var ImgSrc = "";
              ImgSrc = "PDFCSharp.aspx?PDFID=" + PDFId;


            var img = document.getElementById('ctl00_ContentPlaceHolder1_img3');
            img.style.display = 'none';
            var modalImg = document.getElementById("ctl00_ContentPlaceHolder1_PDFImage1");//    PDFImage img3
              $("#ctl00_ContentPlaceHolder1_hdnId").val(PDFId);
              modalImg.style.display = "block";//added by sanoj  04032023
              doccode = ImgCode;
              modal.style.display = "block";
              modalImg.src = ImgSrc;
              modalImg.alt = this.alt;

            $("#ctl00_ContentPlaceHolder1_PDFImage").removeAttr("style");
            var myBookId = Doctype
          
            $("#ctl00_ContentPlaceHolder1_lblForcfr").text(myBookId); //added bysanoj 25112022
            $("#ctl00_ContentPlaceHolder1_lblDocDesc").text(myBookId);  //lblPDFDocDesc
              $("#ctl00_ContentPlaceHolder1_hdnPDFImgId").val(myBookId);

            //Added by Daksh of CFR Document 
            if (PopDesc == "CFR") {
                //document.getElementById("btnPDFCFR").style.display = "none";
                //document.getElementById("lnkbtnPDFApprv").style.display = "none";
                //document.getElementById("pdf-op").style.display = "none";commented by sanoj 27032023
            }


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

        function openpopup() {
            debugger;
            var modal = document.getElementById('myModalRaise123');
            modal.style.display = "block";
            $('#myModalRaise123').modal();

            return false;
        }
        function RaiseCFR() {
            debugger;

            var modal = document.getElementById('myModalRaise');
            var modaliframe = document.getElementById("iframeCFR");
            var cndno = document.getElementById('<%=hdnCndNo.ClientID%>').value;
            var userid = document.getElementById('<%=hdnUserId.ClientID%>').value;
            var args1 = '';// document.getElementById('<%=BtnApprove.ClientID%>').id comented by sanoj 20032023
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
            if (eval(document.getElementById("ctl00_ContentPlaceHolder1_chkOtherCFR").checked) == true) {
                IDCFR == "Y"
                ID = "Others";
            }
            // Get the image and insert it inside the modal - use its "alt" text as a caption
            if (TransfrReqNo != null) {

                modaliframe.src = "../../../Application/ISys/Recruit/PopRaiseCFR.aspx?CndNo=" + cndno + "&ModuleID=" + ModuleID + "&UserId=" + userid + "&args1=" + args1 + "&args2=" + args2 + "&args3=" + args3 + "&args4=" + args4 + "&args5=" + args5 + "&raised=" + raised + "&responded=" + responded + "&closed=" + closed + "&TransfrReqNo=" + Transfr + "&FlagCode=Trnsfr&ID=" + ID + "&mdlpopup=MdlPopRaiseCFR";

            }
            else {
                modaliframe.src = "../../../Application/ISys/Recruit/PopRaiseCFR.aspx?CndNo=" + cndno + "&ModuleID=" + ModuleID + "&UserId=" + userid + "&args1=" + args1 + "&args2=" + args2 + "&args3=" + args3 + "&args4=" + args4 + "&args5=" + args5 + "&raised=" + raised + "&responded=" + responded + "&closed=" + closed + "&FlagCode=Others&ID=" + ID + "&mdlpopup=MdlPopRaiseCFR";


            }


            // $("#ctl00_ContentPlaceHolder1_img3").imageBox();

            //  modal.style.display = "block";
            //modal.style.padding-top = "0px"

            var pouId = document.getElementById("myModalImage");//added by sanoj 06032023
            pouId.style.display = 'none';


            var span = document.getElementsByClassName("close")[0];

            span.onclick = function () {
                //   debugger;
                modal.style.display = "none";

            }
            modal.style.display = "block";
            $('#myModalRaise').modal();
        }
        function funcAlert() {
            alert('Document approved successfully.')
            document.getElementById('myModalImage').style.display='none';
        }
        function AppDoc() {
            //   debugger;
            alert('hello')
            var clickButton = document.getElementById("App");
            clickButton.click();
            return true;

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
            $('#ctl00_ContentPlaceHolder1_img3').css('margin-top', '5%')




        }


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

        }

    </script>
    <style type="text/css">
        #tblphoto {
            FONT-FAMILY: Verdana, Tahoma, Arial;
            font-size: 12px;
            background-color: #FAFAFA;
            text-align: center !important;
        }

        .row {
            border: none !important;
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
    <%--    added by amruta 29/7/16 for rotation of image end--%>
    <%--Added by rahana end--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
<table style="width: 100%">
        <tr>
                        <td align="right" colspan="4">
                            <asp:ImageButton ID="Img2" runat="server" Visible="false" ForeColor="Red" OnClientClick="CloseSub()" src="~/theme/iflow/Error.JPG"/>
                            
                        </td>
                    </tr>
                    </table>
      
            <table style="width: 90%" class="tableIsys">
                <tbody>
                    <tr id="trmsg" runat="server">
                        <td align="center" colspan="4">
                            <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="red"></asp:Label>
                            <asp:Label ID="lblSuccessMsg" runat="server" Visible="false" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                       </tbody>
            </table>
          
              <div class="card PanelInsideTab">
                <div id="Div3" runat="server" class="HeaderColor" style="margin-left:25px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearchDetails','btndivSearchDetails');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblTitle" runat="server" CssClass="HeaderColor" style="font-size:22px;"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btndivSearchDetails" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                     <div id="divSearchDetails" runat="server" class="panel-body" style="display:block">
                     <div class="row rowspacing" style=" margin-top: 2px; margin-left: 44px; ">
                      
                          <div class="col-sm-4">
                         </div>
                   </div>
                  
                    <%--Added by rachana on 29-07-2013 for toggle of agent details start--%>
                        <asp:updatepanel runat="server">
                        <contenttemplate>
         <div id="divImageBind" runat="server" visible="false" class="card PanelInsideTab_body" style="margin-top: -8px;">
                <div id="div10" runat="server" class="HeaderColor" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPhoto','btnImage');return false;"
               >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left;" >

                            <asp:Label ID="Label6" CssClass="HeaderColor" Text=" Uploaded Documents"  runat="server" Font-Size="19px"> </asp:Label>
                   
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnImage" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                      <br/>
                            <div class="row"  style=" margin-bottom: 10px; ">
                                <div class="row" style=" margin-bottom: 10px; ">
                            <div style="padding-left: 2%;" class="col-sm-2">
                            <font color="blue" ><b> Document Status: </b></font>
                              </div>
                               <div class="col-sm-2">
                              <font color="Red"> Raised CFR</font> <span id="raise" runat="server"  class="badge">0</span></div>
                                <div class="col-sm-3">
                               <font color="dark#034ea2"> Responded CFR</font> <span id="respond" runat="server" class="badge">0</span></div>
                               <div class="col-sm-2">
                                <font color="blue" style="margin-left: -25px;"> Closed CFR </font> <span id="close" runat="server" class="badge">0</span></div>
                                <div class="col-sm-3" >
                                <font color="green"> Approved Document</font> <span id="approvedoc" runat="server" class="badge">0</span></div>
                                    </div>
                           <asp:HiddenField ID="hdnraise" runat="server"/>
                             <asp:HiddenField ID="hdnrespond" runat="server"/>
                               <asp:HiddenField ID="hdnclose" runat="server"/>
                                <div id="divPhoto" runat="server" class="panel-body" style="display:block;width:95%">
           
                    </div>
                            </div>
                    
                     
           <div class="row">
            <div class="col-sm-6" style="padding-left: 2%;text-align:left;display:none;">
                                            <asp:CheckBox ID="chkOtherCFR" runat="server" CssClass="standardcheckbox"  
                                                        Enabled="true" AutoPostBack="true" onclick="return RaiseCFR();"
                                                         /> <%-- OnCheckedChanged="cbOtherCFR_CheckedChanged"--%> 
                                                     <asp:Label ID="lblOther" CssClass="control-label labelSize "  runat="server" Text="Other CFR Details" ></asp:Label>
                                     
                                                 
                                      </div>
           </div>
           </div>

                        </contenttemplate>
                 </asp:updatepanel>
                    <div>
                         <div id="DivPanel1" runat="server" class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divagndetails1','btnUploadDtls');return false;"  >           
                          <div class="row">
                              <div class="col-sm-10" style="text-align:left;margin-top: 20px;">
                              <asp:Label ID="lblCnddtls" CssClass="control-label labelSize HeaderColor" runat="server" style="font-size:19px;border-bottom: inset;border-bottom-color: #00cccc;"></asp:Label>
                               <asp:Label ID="LblCfr" CssClass="control-label labelSize " style="color:#9c9c9a;margin-left:7px;"  Visible="false" Text ="CFR's Details"  runat="server" font-size="19px"></asp:Label>
                               <asp:Label ID="lblNoc" CssClass="control-label labelSize " style="color:#9c9c9a;margin-left:7px;"  Visible="false" Text ="NOC Details"  runat="server" font-size="19px"></asp:Label>

                                  <asp:Label ID="LblPmnt" CssClass="control-label labelSize " style="color:#9c9c9a;margin-left:7px;" Text ="Payment Details"  runat="server" font-size="19px"></asp:Label>
                               <asp:Label ID="LblExm" CssClass="control-label labelSize " style="color:#9c9c9a;margin-left:7px;" text="Exam/Training"   runat="server" font-size="19px"></asp:Label>
                               <asp:Label ID="LblTrnfr" CssClass="control-label labelSize " style="color:#9c9c9a;margin-left:7px;" Visible="false" text="Transfer/Composite"  runat="server" font-size="19px"></asp:Label>
                 
                              </div>
                              <div class="col-sm-2">
                              
                               </div>
                             </div>
                        </div>
              
                          <div id="divIsSpecified" runat="server" style="display: block;">
                <asp:UpdatePanel ID="Updatepanel114" runat="server">
                    <ContentTemplate>
                        <table class="tableIsys" style="width: 90%;">
                            <tr>
                                <td class="formcontent" style="width: 20%;">
                                    <asp:Label ID="lblIsSPFlag" runat="server" ></asp:Label>
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
                                <td style="width: 20%;" class="formcontent">
                                </td>
                                <td style="width: 30%;" class="formcontent">
                                </td>
                            </tr>
                            <tr id="tr_IsSPDtls" visible="false" runat="server">
                                <td class="formcontent" style="width: 20%;">
                                    <asp:UpdatePanel ID="Updatepanel15" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblCACode" runat="server" ></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="width: 30%;">
                                    <asp:UpdatePanel ID="Updatepanel16" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCACode" runat="server" CssClass="standardtextbox" MaxLength="20"
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
                                            <asp:Label ID="lblCAName" runat="server" ></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="width: 30%;">
                                    <asp:UpdatePanel ID="Updatepanel118" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCAName" runat="server" CssClass="standardtextbox" MaxLength="20"
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


                          <div id="divagndetails" runat="server" class="card PanelInsideTab_body" style="display:block">
                <%--Added by rachana on 29-07-2013 for toggle of agent details end--%>

<%--start added by sanoj 03092022--%>
                               <div class="row rowspacing" >
                                   <div class="col-sm-4" style="text-align:left">
                                       </div>
                                    <div class="col-sm-4" style="text-align:left">
                                       </div>
                                    <div class="col-sm-4" style="text-align:left">
                                          <asp:LinkButton ID="lblCndView" runat="server" CssClass="control-label labelSize" Text="View Candidate Details" OnClick="lblCndView_Click"></asp:LinkButton>
                                       </div>
                                   </div>
                         <div class="row rowspacing" >
                             
                        <div class="col-sm-4" style="text-align:left">
                            <asp:Label ID="lblCndNo" runat="server" CssClass="control-label labelSize"></asp:Label>

                              <asp:TextBox ID="lblCndNoValue" runat="server" CssClass="form-control" MaxLength="20"
                                                Enabled="false" > 
                                            </asp:TextBox>
                      </div>
                              <div class="col-sm-4" style="text-align:left;">
                            <asp:Label ID="lblAppNo" runat="server" CssClass="control-label labelSize " ></asp:Label>

                            <asp:TextBox ID="lblAppNoValue" runat="server" CssClass="form-control" MaxLength="20"
                                                Enabled="false" > 
                                            </asp:TextBox>
                      </div>

                       <div class="col-sm-4" style="text-align:left;">
                      

                              <asp:Label ID="lblBranch" runat="server"   CssClass="control-label labelSize"></asp:Label>
                               <asp:TextBox ID="lblBranchValue" runat="server" CssClass="form-control" MaxLength="20"
                                                Enabled="false" > 
                                            </asp:TextBox>
                       </div>
                    
              </div>

                         <div id="divSpon" class="row rowspacing" runat="server" >
                             <div class="col-sm-4" style="text-align:left">
                            <asp:Label ID="lblSponsorDt" Text="Sponsor Date" CssClass="control-label labelSize" runat="server" ></asp:Label>

                              <asp:TextBox ID="lblSponsorDtValue" runat="server" CssClass="form-control" MaxLength="20"
                                                Enabled="false" > 
                                            </asp:TextBox>
                      </div>
                                    
                                   <div class="col-sm-4" style="text-align:left">
                                        <asp:Label ID="lblReqStatus" CssClass="control-label labelSize" runat="server" ></asp:Label>
                                        <asp:TextBox ID="lblReqStatusValue" runat="server" CssClass="form-control" MaxLength="20"
                                                Enabled="false" > 
                                            </asp:TextBox>
                                    </div>
                                   <div class="col-sm-4" style="text-align:left">

                                        <asp:Label ID="lblpfGender" runat="server" CssClass="control-label labelSize" Text="Gender" ></asp:Label>
                                              
                                                    <asp:Textbox id="cboGender" runat="server" CssClass="form-control"  
                                                     Enabled="false"  TabIndex="9"></asp:Textbox> 
                                       <%-- <asp:Label ID="lblaadhr" runat="server" Text ="Aadhaar No"  CssClass="control-label labelSize"></asp:Label>
                                       <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                     <ContentTemplate>
                       
                                             <asp:TextBox ID="txtaadhr"  Enabled ="false"  runat="server" CssClass="form-control" MaxLength="16" 
                                              TabIndex="1"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender82" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWYZabcdefghijklmnopqrstuvwxyz "
                                                  FilterMode="InvalidChars" TargetControlID="txtaadhr" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                     
                                     </ContentTemplate>
                                 </asp:UpdatePanel>--%>
                                    </div>

                              </div>

                         <div class="row rowspacing" >
            
                            <%-- <div class="col-sm-1">
                                        <asp:Label ID="lblPrefix" runat="server" Text="Pre.Fix" CssClass="control-label labelSize"></asp:Label>
                                      
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                               <asp:Textbox ID="cboTitle" runat="server" CssClass="form-control"
                                  Enabled="false"   TabIndex="5">   
                                </asp:Textbox>
                                            </span>
                                            </div>
                                         </div>--%>

                 <div class="col-sm-4" style="text-align: left">
                      <asp:Label ID="lblpfgivenName" runat="server" CssClass="control-label labelSize" Text="Given Name" ></asp:Label> 
                                                   
                                            <asp:TextBox ID="txtGivenName" runat="server" Enabled="false" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                    aria-label="Text input with dropdown button" MaxLength="30" TabIndex="6" ></asp:TextBox><br />  
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_GivenName" runat="server"
                                                             FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtGivenName" ValidChars=" " FilterMode="ValidChars">
                    </ajaxToolkit:FilteredTextBoxExtender>

                                            
                                        </div>


                 <div class="col-sm-4" style="text-align: left">

                                           <span>
                                                    <asp:Label ID="lblpfSurName" runat="server" CssClass="control-label labelSize" Text="Surname" ></asp:Label></span>
                                               
                                                    <asp:TextBox id="txtname"  runat="server" CssClass="form-control "  Enabled="false"
                                                        onChange="javascript:this.value=this.value.toUpperCase();" 
                                                        MaxLength="30" TabIndex="7"></asp:TextBox>
                                                   
                                                          <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom"  
                                                            TargetControlID="txtname"></ajaxToolkit:FilteredTextBoxExtender>
                      
                  </div>
               
                 <div class="col-sm-4" style="text-align: left">

                      <asp:Label ID="lblpffathername" runat="server" CssClass="control-label labelSize" Text="Father name" ></asp:Label>
                                                   
                                                    
                                                                  
                                                    <asp:TextBox ID="txtFathername" runat="server" Enabled="false" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                        MaxLength="60" TabIndex="8"  onblur="AllowSpace();return false;"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_FatherName" runat="server"
                        InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" ValidChars=" " FilterMode="ValidChars"
                        TargetControlID="txtFathername" FilterType="LowercaseLetters, UppercaseLetters,Custom"></ajaxToolkit:FilteredTextBoxExtender>
                      
                  </div>
                      </div>

                         <div class="row" style="margin-top: -10px;" >
                 <div class="col-sm-4" style="text-align: left">
                         <asp:Label ID="lblEmail" runat="server" Text="Email " CssClass="control-label labelSize" ></asp:Label>
                                
                           
                                         <asp:TextBox ID="txtEMail" runat="server" TabIndex="6" Enabled="false" CssClass="form-control" ></asp:TextBox>  <%--onblur="validateEmail1(this.value)--%>
                                        
                                    
                                             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                 <ContentTemplate>
                                                     <asp:LinkButton ID="btnverifyemail" runat="server" Text="Verify" CssClass="btn btn-verify"
                                                     ValidationGroup="RecruitInfo"  Visible="false" TabIndex="7"  OnClick="btnverifyemail_Click" OnClientClick="return validateEmail1();">
                                             <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify
                                                     </asp:LinkButton>
                                               
                                                     <asp:Label ID="lblEmailMsg" runat="server"  CssClass="control-label labelSize "
                                                        Visible="false" Font-Size="X-Small"></asp:Label>
                                                 </ContentTemplate>
                                             </asp:UpdatePanel>
                  </div>
                 <div class="col-sm-4" style="text-align: left">
                      
                        <asp:Label ID="lblMobileNo" CssClass="control-label labelSize" Text="Mobile No " runat="server" ></asp:Label>
                               
                            <%--  added by shreela on 10/03/14--%>
                            <%--  <span style="color: #ff0000">*</span>--%>
                     
                       <%--  <div  class="row">--%>
                              <%--<div class="col-sm-2" style="text-align: left;">
                             <span class="input-group-addon">
                            <asp:TextBox ID="txtmobcode" runat="server" Enabled="false" Text="91"  style=" width: 50px; " CssClass="form-control"
                                                      ></asp:TextBox>      
                                 </span>
                                  </div>--%>
                            <%--  <div class="col-sm-4" style="text-align: left">--%>
                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" Enabled="false" CssClass="form-control" TabIndex="3"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                FilterMode="InvalidChars" TargetControlID="txtMobileNo" FilterType="Custom">
                            </ajaxToolkit:FilteredTextBoxExtender>
                           <%-- <span class="input-group-btn">
                                <asp:LinkButton ID="btnverifymobile" runat="server" CausesValidation="False" CssClass="btn btn-verify" TabIndex="4"
                                    OnClick="btnverifymobile_Click" OnClientClick="return form2();" Visible="false" Text="Verify">
                                
                                   
                        <span class="glyphicon glyphicon-search BtnGlyphicon"> </span>Verify
                                </asp:LinkButton>
                                <div id="divmob" class="Content" style="display: none">
                                <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                Loading...</div>
                            <br />
                            <asp:Label ID="lblmobileverify" runat="server"  Font-Size="X-Small"></asp:Label>
                            </span>
                        </div>--%>
                             
                         <%--  </div>--%>
                  </div>
                             
                 <div class="col-sm-4" style="text-align: left">
                      

                       <asp:Label ID="lblPAN" runat="server" Text="PAN No " CssClass="control-label labelSize"  ></asp:Label>
                                 
                           
                         <%--<div  class="input-group">--%>
                                         <asp:TextBox TabIndex="4" ID="txtPAN" runat="server" CssClass="form-control " MaxLength="10" Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();">
                                         </asp:TextBox>
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                             InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtPAN"
                                             FilterType="Custom">
                                         </ajaxToolkit:FilteredTextBoxExtender>
                                          
                                                     
                                       <span class="input-group-btn input-addon_extended">
                                                     <asp:LinkButton TabIndex="5" ID="btnVerifyPAN" runat="server" Visible="false" Text="Verify" CssClass="btn btn-verify"
                                                         OnClick="btnVerifyPAN_Click" style="margin-left:2%" >
                                             <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify
                                                     </asp:LinkButton>
                                                     </span>
                                                    
                                                <%-- </ContentTemplate>
                                             </asp:UpdatePanel>--%>
                                         <%--    </div>--%>
                                              <div id="divPAN" class="Content" style="display: none">
                                                         <img src="../../../App_Themes/Isys/images/spinner.gif" />
                                                         <asp:Label ID="Label19" runat="server"></asp:Label>
                                                     </div>
                                                     <br />
                                                     <asp:Label ID="lblPANMsg" runat="server"  CssClass="control-label labelSize "
                                                         Font-Size="X-Small"></asp:Label>
                                                           <asp:HiddenField ID="hdnPanDtls" runat="server"></asp:HiddenField>
                            </div>
                  </div>

                         <div id="Divrecruit" runat ="server" class="row" style="margin-top: -10px;">
                             <div class="col-sm-4" style="text-align:left">
                                         <asp:Label ID="lblSMName" runat="server" CssClass="control-label labelSize" ></asp:Label>
                                          <asp:TextBox ID="lblSMNameValue" runat="server" CssClass="form-control" MaxLength="20"
                                                Enabled="false" > 
                                            </asp:TextBox>
                                    </div>
                               

                               <div class="col-sm-4" style="text-align: left">
                       <asp:Label ID="LblRptMgrCode" runat="server" Text="Additional Reporting Manager " CssClass="control-label labelSize" ></asp:Label>
                    <asp:TextBox ID="txtRptMgrCode" runat="server" CssClass="form-control" MaxLength="20"
                                                Enabled="false" > 
                                            </asp:TextBox>

                  </div>
                              <div class="col-sm-4" style="text-align: left">

                      <asp:Label ID="LblAnnivrsryDt" runat="server" Text="Anniversary Date " CssClass="control-label labelSize" ></asp:Label>
                       <asp:TextBox ID="txtAnnivrsryDt" runat="server" CssClass="form-control" MaxLength="20"
                                                Enabled="false" > 
                                            </asp:TextBox>
                  </div>  
                          
                          
                        </div>


                                <div id="DivCantype" runat="server" class="row">
                  <div class="col-sm-4" style="text-align: left">


                           <div class="row rowspacing">
                      <div  id="Div4"  runat="server" class="col-sm-12" >         
                         <asp:Label ID="lblCompsite" runat="server" CssClass="control-label labelSize" Text="Composite Case" ></asp:Label>

                        
                        

                           <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox"  Enabled="True" AutoPostBack ="false"
                                                         TabIndex="21" oncheckedchanged="cbTccCompLcn_CheckedChanged" GroupName="a"  />
                                                 
                                                   
                    </div>           
                 </div>
                    
                      
                  </div>
                 <div class="col-sm-4" style="text-align: left">

                       <div class="row rowspacing">
                  

            
                       <div  id="trTrnTitle"  runat="server" class="col-sm-12" >
                                     
                            <asp:Label ID="Label14" runat="server" CssClass="control-label labelSize"  Text="Transfer Case" ></asp:Label>
                         <%--                 <asp:RadioButton GroupName="a" ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox"  
                                                        AutoPostBack ="true" OnCheckedChanged="" TabIndex="20"/>--%>

                            <asp:CheckBox ID="cbTrfrFlag"  runat="server" CssClass="standardCheckBox"  AutoPostBack="true"  onchange="showUrnDiv();"  TabIndex="8"/>   <%--OnCheckedChanged="cbTrfrFlag_CheckedChanged1"--%>
                                                   
                                        </div>            
                                                    
                                      </div>
                           
                  </div>
                 <div class="col-sm-4" id="UrnNo" runat="server" visible="true" style="text-align: left;margin-top: 17px;">

                       <%-- <span style="color: red">
                                        <asp:Label ID="Label10" Text="Candidate URN No." runat="server" CssClass="control-label labelSize " ></asp:Label>*</span>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>--%>

                                  
                                        <asp:Label ID="lblcndURNNo" Text="Candidate URN No." runat="server" CssClass="control-label labelSize " >
                                           <%--<span style="color: red"> *</span>--%>
                                             </asp:Label>
                    <asp:TextBox ID="txtCndURNNo" runat="server" MaxLength="16" CssClass="form-control mandatory"></asp:TextBox>
                 </div>
                                    </div>

           
 

 <%--End added by sanoj 03092022--%>
               
                       <div id='trMob' runat="server" visible="false" class="row" >
                        <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="Label11" Text="Mobile No" runat="server" CssClass="control-label labelSize "></asp:Label>
                      </div>
                       <div class="col-sm-3" >
                            <asp:TextBox  ID="lblmobile" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                      </div>
                        <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="Label12" runat="server" Text="PAN No"  CssClass="control-label labelSize "></asp:Label>
                      </div>
                       <div class="col-sm-3" >
                            <asp:TextBox  ID="lblpanno" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>
                      </div>
                      </div>  


                                <div class="row rowspacing" id='trAgency' runat="server" visible="false">

                               <div class="col-sm-4" style="text-align: left">
                       <%-- <div id='trAgency' runat="server" visible="false" class="row" >--%>
                       <%-- <div class="col-sm-3" style="text-align:left">--%>
                           <asp:Label ID="Label13" Text="Agency Code" runat="server" CssClass="control-label labelSize "></asp:Label>
                         <asp:TextBox  ID="lblagencycodeValue" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                      </div>
                       <div class="col-sm-4" style="text-align: left">
                            <asp:Label  ID="lbldateissue" runat="server" Text="Date of Issue of Appointment"  CssClass="control-label labelSize "></asp:Label>
                     <%-- </div>
                       <div class="col-sm-3" >--%>
                            <asp:TextBox  ID="lbldateissuevalue" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>
                      </div>
                         <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lbldos" Text="Date of Submission" runat="server" CssClass="control-label labelSize "></asp:Label>
                               <asp:TextBox  ID="lbldate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                             </div>
                      </div>       
                  
                        
                      <div id='trdos' runat="server" visible="false" class="row" >
                        <%--<div class="col-sm-3" style="text-align:left">
                          
                      </div>
                       <div class="col-sm-3" >
                          
                      </div>--%>
                        <div class="col-sm-4" style="text-align:left">
                            <asp:Label  ID="lbldoa" runat="server" Text="Date of Acceptance of Resignation"  CssClass="control-label labelSize "></asp:Label>
                      <%--</div>
                       <div class="col-sm-3" >--%>
                            <asp:TextBox  ID="lbldoar" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>
                      </div>
                      </div> 
                     
                    <%--  usha 03.07.2015--%>
             
                         <div class="row" id="trBranch" runat="server" >
                 
                        <%-- commented by pranjali on 27-12-2013--%>
                        <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchCode" runat="server" ></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchCodeValue" runat="server" ></asp:Label>
                        </td>--%>
                        <%-- commented by pranjali on 27-12-2013--%>
                      <%--<div class="col-sm-3" style="text-align:left">
                           
                       </div>
              <div class="col-sm-3">
          
                      </div>
                     <div class="col-sm-3" style="text-align:left">
                           
                       </div>
                        <div class="col-sm-3">
                      
                       </div>--%>
                  </div>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSalesUnitCode" runat="server" ></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSalesUnitCodeValue" runat="server" ></asp:Label>
                        </td>--%>
                    <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMName" runat="server" ></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMNameValue" runat="server" ></asp:Label>
                        </td>--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--<tr>
                        <td style="height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnStartDate" runat="server" Text="Training Start Date" ></asp:Label>
                        </td>
                        <td style="width: 160px; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnStartDateValue" runat="server" ></asp:Label>
                        </td>
                        <td style="height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnEndDate" runat="server" Text="Training End Date" ></asp:Label>
                        </td>
                        <td style="width: 210px; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnEndDateValue" runat="server" ></asp:Label>
                        </td>
                    </tr>--%>
                    <%--commented by pranjali on 27-12-2013--%>
                            <div class="row" id="trRequest" runat="server" >
                 <div class="col-sm-3" style="text-align:left">
                           
                       </div>
                        <div class="col-sm-3">
                       
                      </div>
                     <div class="col-sm-3" style="text-align:left">

                                   

                                                                   
                        </div>
                             <div class="col-sm-3">
                           
                                 
                               
                                
                             </div>   
                 </div>
                           <div class="row" id="trGivenName" runat="server" >
                                              <div class="col-sm-3" style="text-align:left">
                                                    
                                                  
                                               </div>
                                                   <div class="col-sm-3">
                            
                         <div  class="input-group">
                             <span class="input-group-addon input-addon_extended">
                              
                                
                              </span>
                                
                               
                            </div>
                           
                        </div>
                                          
                                                 <div class="col-sm-3" style="text-align:left">
                                                   
                                               </div>
                            </div>
                               <div class="row" id="trFatherName" runat="server" >
                                      <div class="col-sm-3" style="text-align:left">
                                                  <%--Added by shreela on 6/03/14 to remove space--%>
                                                   
                                               
                                              </div>
                                                           <div class="col-sm-3" style="text-align:left">
                                                <%-- <span style="color: red">--%><%--Added by shreela on 6/03/14 to remove space--%>
                                                    
                                             </div>
                                         </div>
                        <div class="row" id="trMobile" runat="server" >
                    <div class="col-sm-3" style="text-align:left">
                           
                             
                    </div>
                     <div class="col-sm-3" style="text-align:left">
                           
                              
                      <%--  <div class="col-md-2">
                          
                                    <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" CssClass="form-control"
                                        onChange="javascript:this.value=this.value.toUpperCase();"
                                       ></asp:TextBox>
                                       </div>--%>
                                   <%--      <div class="col-md-1">
                                           <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnVerifyPAN" runat="server" Text="Verify" CssClass="btn btn-primary"
                                        OnClick="btnVerifyPAN_Click" ValidationGroup="RecruitInfo" ></asp:Button>
                                    <div id="divPAN" class="Content" style="display: none">
                                        <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                        Loading...</div>
                                    <br />
                                    <asp:Label ID="lblPANMsg" runat="server"  Font-Size="X-Small"></asp:Label>
                                    <asp:HiddenField ID="hdnPanDtls" runat="server"></asp:HiddenField>
                                
                                </ContentTemplate>
                            </asp:UpdatePanel>
                       </div>--%>
                  </div>
                       <div class="row" id="trEmail" runat="server" >
                    <div class="col-sm-3" style="text-align:left">
                            
                             
                                       <%--  </span>--%>
                                     
                               <%--  </div>--%>
</div>
                  
                        <%--ank strt 12.01.2011--%>
                 <div class="col-sm-3" style="text-align:left">
                          
                        </div>
                  </div >
                    <div class="row" runat="server" >
                       <div class="col-md-6" style="text-align:left">
                           
                      </div>
                    </div>
                    <%--  added by shreela 21032014--%>
                    <tr id="trlicn" runat="server" visible="false">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblLicnno" runat="server" Text="License No" CssClass="standardlabel"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:TextBox ID="txtlicno" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                             <asp:Label ID="lbllicnoval" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblLicExpDt" runat="server" Text="LicenseExpDate" CssClass="standardlabel"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:TextBox ID="txtLicExpDt" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
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
             
            </div>

                        <div   class="row">

                               <div class="col-sm-4" id="DivPan" runat="server" style="text-align: left">
                        <asp:Label ID="lblpandetail" runat="server" CssClass="control-label labelSize" Text="Is Pan name different from registered name"
                                ></asp:Label>
                      
                            <asp:CheckBox ID="Chkpan" runat="server" TabIndex="8"/>
                  </div>
                               <div class="col-sm-4" style="text-align: left">
                       <asp:Label ID="lblAdvWaiver" Text="Advisor Waiver" Visible="false" runat="server"></asp:Label>
                          
                            <asp:CheckBox ID="chkAdvWaiver" runat="server" Visible="false" AutoPostBack="true"
                                OnCheckedChanged="chkAdvWaiver_CheckedChanged" TabIndex="9" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAdvisorWaiver" runat="server" Visible="false" Text="Waiver Advisor"
                                Width="100" CssClass="standardbutton" />
                            <asp:HiddenField ID="hdnAdvWaiver" runat="server" />
                            <asp:HiddenField ID="hdnCsccode" runat="server" />
                  </div>
                    
                               <div class="col-sm-4" style="text-align: left">  </div>

            </div>
                    </div>

                           <%--   <added by sanoj 30092022--%>
                          <asp:UpdatePanel ID="Updatepanel4" runat="server">
                    <ContentTemplate>
                           <div id="divPayment" runat="server" class="card PanelInsideTab_body" Visible="false" >


                                <div class="row rowspacing" style="margin-left: 25px;">
                                           <div class="col-sm-4" style="text-align: left">
                                               <asp:Label ID="lblTknNo" runat="server" Text="Token No" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="lblTknNoValue" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                             
                                           </div>
                                          <div class="col-sm-4" style="text-align: left">
                                               <asp:Label ID="lblTotfees" runat="server" Text="Total Fees" CssClass="control-label labelSize "></asp:Label>
                                                <asp:TextBox ID="lblTotfeesValue" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                     
                                           </div>
                                          <div class="col-sm-4" style="text-align: left">
                      
                                         </div>

                                 </div>

                                <div class="row rowspacing" style="margin-left: 26px;">
                                   <div class="col-sm-8" style="text-align: left">
                                        <asp:Label ID="lblFeesDtls" Text="Fees Collected Details" runat="server" CssClass="HeaderColor " font-size="19px" ></asp:Label>
                                   </div>
                                  <div class="col-sm-4" style="text-align: left">
                                       
                                   </div>
                                 

                             </div>


                                  <div class="panel" id="TblFees"  visible="true" runat="server">
        
             <div    class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divFees','btnfees');return false;" > 
                     
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                    <%-- <asp:Label ID="lblFeesDtls" Text="Fees Collected Details" runat="server" CssClass="control-label labelSize " font-size="19px" ></asp:Label>--%>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnfees" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
         
                        </div>
                         <asp:UpdatePanel ID="updgridfees" runat="server" UpdateMode="Conditional">
            <ContentTemplate> 
                <div id="divFees" runat="server" class="card PanelInsideTab_body" style="display: block;margin-bottom:15px;">
                               <%-- <asp:GridView ID="dgPaymentdtls" runat="server" PagerStyle-HorizontalAlign="Center"
                                    CssClass="tableIsys" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                    RowStyle-CssClass="tableIsys" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True" Width="100%" OnRowDataBound="dgPaymentdtls_RowDataBound" OnRowCommand="dgPaymentdtls_RowCommand"
                                    OnRowDeleting="dgPaymentdtls_RowDeleting">--%>
                                     <asp:GridView  AllowSorting="True" ID="dgPaymentdtls" runat="server" CssClass="footable" Style="border-bottom-color: black;"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   OnRowDeleting="dgPaymentdtls_RowDeleting"
                                        OnRowDataBound="dgPaymentdtls_RowDataBound"  OnRowCommand="dgPaymentdtls_RowCommand" >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <%--<AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>--%>
                                    <Columns>
                                        <asp:TemplateField SortExpression="TokenNo" HeaderText="Token No" ItemStyle-Width="8%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTokenNo" runat="server" Text='<%# Eval("TokenNo") %>' ></asp:Label>
                                            </ItemTemplate>
                                           <%-- <HeaderStyle CssClass="test" Font-Size="Smaller" />--%>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="PaymentMode" HeaderText="Payment Mode" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPymtMode" runat="server" Text='<%# Eval("PaymentMode") %>' ></asp:Label>
                                            </ItemTemplate>
                                           <%-- <HeaderStyle CssClass="test" Font-Size="Smaller" />--%>
                                           <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="PaymentDate" HeaderText="Payment Date" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPymtDt" runat="server" Text='<%# Eval("PaymentDate","{0:dd/MM/yyyy}") %>'
                                                   ></asp:Label>
                                            </ItemTemplate>
                                       <%--     <HeaderStyle CssClass="test" Font-Size="Smaller" />--%>
                                             <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="BankName" HeaderText="Bank Name" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("BankName") %>' ></asp:Label>
                                            </ItemTemplate>
                                      <%--      <HeaderStyle CssClass="test" Font-Size="Smaller" />--%>
                                             <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField SortExpression="InstrumentNo" Visible="false" HeaderText="Instrument No" ItemStyle-Width="13%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInstrumentNo" runat="server" Text='<%# Eval("InstrumentNo") %>'
                                                   ></asp:Label>
                                            </ItemTemplate>
                                          <%--  <HeaderStyle CssClass="test" Font-Size="Smaller"/>--%>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"   ></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="InstrumentDate"  Visible="false" HeaderText="Instrument Date" ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInstrumentDt" runat="server" Text='<%# Eval("InstrumentDate","{0:dd/MM/yyyy}") %>'
                                                    Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <%--<HeaderStyle CssClass="test" Font-Size="Smaller"/>--%>
                                           <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Amount" HeaderText="Amount" ItemStyle-Width="6%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPymtAmt" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <%--<HeaderStyle CssClass="test" Font-Size="Smaller"/>--%>
                                              <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="TrxNo" HeaderText="Transaction No" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTrxNo" runat="server" Text='<%# Eval("RcptNo") %>' ></asp:Label>
                                            </ItemTemplate>
                                           <%-- <HeaderStyle CssClass="test" Font-Size="Smaller"/>--%>
                                             <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ReceiptNo" Visible="false" HeaderText="Receipt Id" ItemStyle-Width="7%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRcptId" runat="server" Text='<%# Eval("RcptNo") %>' ></asp:Label>
                                            </ItemTemplate>
                                          <%--  <HeaderStyle CssClass="test" Font-Size="Smaller" />--%>
                                              <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="5%" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="DeleteBtn" Text="Delete" CommandName="Delete" runat="server" Enabled="false"  />
                                            </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                           <%-- <ControlStyle Font-Underline="True" />
                                            <FooterStyle Font-Underline="False" />
                                            <HeaderStyle CssClass="test" Font-Size="Smaller"/>--%>
                                        </asp:TemplateField>
                                    </Columns>
                                   <%-- <HeaderStyle CssClass="standardlink" HorizontalAlign="Center" />
                                    <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black"></PagerStyle>
                                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="Small">
                                    </RowStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>--%>
                                </asp:GridView>
                                
                </div>
          </ContentTemplate>
            <Triggers>
                <%--<ajax:AsyncPostBackTrigger ControlID="btnGetFeeDetails" EventName="Click" />--%>
                <ajax:AsyncPostBackTrigger  ControlID="lnkGetFees" EventName="Click" />
                <ajax:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click" />
            </Triggers>
       
            </asp:UpdatePanel>
        </div>

                           <div class="row rowspacing" style="margin-left: 26px;">
                              <div class="col-sm-12" style="text-align: left">
                                    <asp:UpdatePanel ID="UpdFeesWavier" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                          
                    <div class="col-sm-12" style="text-align:left; display:flex;">
                 
                     <asp:Label ID="lblFeesTitle" runat="server" Text="Fees Wavier Details" CssClass="HeaderColor"  Font-Size="19px"></asp:Label>
                       <asp:CheckBox ID="ChkFeesWavier" runat="server" style="margin-left: 8px;margin-top: 7px;" CssClass="standardCheckBox" AutoPostBack="true" OnCheckedChanged="ChkFeesWavier_CheckedChanged" />
                    </div>
                    <%--<div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-collapse-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>--%>
             
          
            </ContentTemplate>
            </asp:UpdatePanel>

                             </div>

                           </div>

                               

                               </div>
                           <div id="divExam" runat="server" class="card PanelInsideTab_body" Visible="false" >

                               <div id="divExm" runat="server">
       
                                 <div class="row rowspacing">
                                <div class="col-sm-4" style="text-align: left;margin-left: 19px;">
                                             <asp:Label ID="lblExamTitle" runat="server" CssClass="HeaderColor" font-size="19px"></asp:Label>
                                
                                </div>
                                </div>

                                 <div class="row rowspacing left-space">
                                     <div class="col-sm-4" style="text-align: left">
                                     
                                    <asp:Label ID="lblExam" runat="server"  CssClass="control-label labelSize "> </asp:Label> 
                                    
                                   
                                           <asp:UpdatePanel ID="updExam" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExam" runat="server" CssClass="form-control form-select mandatory" AutoPostBack="true" Enabled="false"
                                        TabIndex="8">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                </div>
                                     <div class="col-sm-4" style="text-align: left">
                                          <asp:Label ID="lblExmBody" runat="server" CssClass="control-label labelSize " ></asp:Label> 
                                    
                                         <asp:UpdatePanel ID="UpdExmBody" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExmBody" TabIndex="10" runat="server" CssClass="form-control form-select mandatory" enabled="false">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                     
                                </div>
                                     <div class="col-sm-4" style="text-align: left">
                                      <asp:Label ID="lblpreexamlng" runat="server"  CssClass="control-label labelSize " ></asp:Label> 
                                      
                                          <asp:UpdatePanel ID="updPreExmLng" runat="server">
                                    <ContentTemplate>
                                        <%--<asp:DropDownList ID="ddlpreeamlng" runat="server" Enabled="false" TabIndex="13" CssClass="form-control form-select mandatory">
                                        </asp:DropDownList>commented by ajay yadav 11-03-2023--%>
                                        <asp:DropDownList ID="ddlpreeamlng" runat="server"  CssClass="form-control form-select mandatory" DataTextField="ParamDesc1" Enabled="false"
                                    DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="DSddlpreeamlng">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DSddlpreeamlng" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                </div>
                              
                               
                         </div>
                                 <div class="row rowspacing left-space">
                                   <div class="col-sm-4" style="text-align: left">
                                       <asp:Label ID="lblCentre" CssClass="control-label labelSize " runat="server" ></asp:Label> 
                                 
                                         <div  class="input-group">

                                         <asp:TextBox ID="txtExmCentre" runat="server" CssClass="form-control mandatory" Enabled="false" TabIndex="14"  Visible="true"  AutoPostBack="True"></asp:TextBox>
                                        
                                             
                                     <asp:DropDownList ID="ddlExmCentre" runat="server" CssClass="form-control" Visible="false" TabIndex="14" AutoPostBack="True">
                                        </asp:DropDownList>
                                                    <span class="input-group-btn">
                                                          <asp:LinkButton ID="btnExmCentre" runat="server" CausesValidation="False" Visible="false" TabIndex="15" CssClass="btn btn-success " 
                                          Text="Search" style="margin-left: 6px;height: 34px;border-radius: 6px;">
                                             <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search
                                                     </asp:LinkButton>
                                                        </span>
                                            
                                       <input type="hidden" runat="server" id="hdnExmCentreCode" />
                                 </div>
                                   </div>
                                  <div class="col-sm-4" style="text-align: left">
                                       
                                   </div>
                                  <div class="col-sm-4" style="text-align: left">
                                       
                                   </div>

                             </div>
                               
                                   </div>

                               <div class="row rowspacing">
                                <div class="col-sm-4" style="text-align: left;margin-left: 17px;">
                                              <asp:Label ID="lblTrnDtl" runat="server" Text="Training Details" CssClass="HeaderColor" font-size="19px"></asp:Label>
                                
                                </div>
                                </div>

                                <div class="row rowspacing left-space">
                                   <div class="col-sm-4" style="text-align: left">
                                       <asp:Label ID="Label2" runat="server" CssClass="control-label labelSize "  Text="Training Mode "></asp:Label>
                                  

                                        <asp:UpdatePanel ID="updTrnMode" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTrnMode" runat="server" CssClass="form-control form-select mandatory" AutoPostBack="true"
                                            Enabled="true" OnSelectedIndexChanged="ddlTrnMode_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                   </div>
                                  <div class="col-sm-4" style="text-align: left">
                                        <asp:Label ID="lblTrnLoc" runat="server"  CssClass="control-label labelSize " Text="Training Location"></asp:Label>
                                 
                                       <asp:UpdatePanel ID="updTrnLoc" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTrnLoc" runat="server" CssClass="form-control form-select mandatory" Visible="true" onchange = "DoPost()"
                                            AutoPostBack="true"  OnSelectedIndexChanged="ddlTrnLoc_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <input type="hidden" runat="server" id="hdnTrnLocation" name="hdnTrnLocation" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                   </div>
                                  <div class="col-sm-4" style="text-align: left">
                                       <asp:Label ID="lblTrnInstitute" runat="server"  CssClass="control-label labelSize " Text="Training Institute"></asp:Label>
                                     
                                         <asp:UpdatePanel ID="updTrnInstitute" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTrnInstitute" runat="server" CssClass="form-control form-select mandatory" Visible="true" AutoPostBack="true" OnSelectedIndexChanged="ddlTrnInstitute_SelectedIndexChanged"
                                             >  <%--AutoPostBack="true"  OnSelectedIndexChanged="ddlTrnInstitute_SelectedIndexChanged" --%>
                                        </asp:DropDownList>
                                        <input type="hidden" runat="server" id="hdnTrnInstitute" name="hdnTrnInstitute" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                   </div>

                                </div>

                                  <div class="row rowspacing left-space">
                                   <div class="col-sm-4" style="text-align: left">
                                        <asp:Label ID="lblAccrdtn" runat="server"  CssClass="control-label labelSize " Text="Accreditation Number"></asp:Label> 

                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:textBox ID="lblAccrdtnValue" runat="server" CssClass="form-control mandatory" MaxLength="50"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                   </div>
                                  <div class="col-sm-4" style="text-align: left">
                                       <asp:Label ID="lblHrnTrn" runat="server" CssClass="control-label labelSize " ></asp:Label>
                              
                         
                                <asp:UpdatePanel ID="updTrnHrs" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlHrsTrn" runat="server" AutoPostBack="true" CssClass="form-control form-select mandatory">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                   </div>
                                  <div class="col-sm-4" style="text-align: left">
                                       
                                   </div>

                                </div>

                            
                               </div>
                           <div id="divTransfer" runat="server" class="card PanelInsideTab_body" Visible="false" >

                            divPanel4
                               </div>

                           </ContentTemplate>
                </asp:UpdatePanel>
                     <%--   <added by sanoj 30092022--%>

<%--here payament details 06092022 --%>
        <div class="panel" id="tblIcmColl" runat="server" style="display:none;">
                 <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivICMDtls','btnICMDtls');return false;"
                >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label7" runat="server" CssClass="control-label labelSize " Text="Payment Details" font-size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnICMDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                        <div id="DivICMDtls" runat="server" class="panel-body" style="display: none">
                        <div class="row" id="FeesRow" runat="server" style="display: none" >
                         <div class="col-sm-3" style="text-align:left">
                            
                                <asp:Label ID="lblWebTknReceived" Text="Fees Collected" runat="server" CssClass="control-label labelSize "  Visible="false"></asp:Label>
                                <span id="spwebtoken" runat="server" style="color: Red">*</span>
                          
                      </div>
                         <div class="col-sm-3">
                            <asp:UpdatePanel ID="updChkFees" runat="server">
                                <ContentTemplate>
                                    <asp:CheckBox ID="chkWebTknRecd" runat="server" OnCheckedChanged="chkWebTknRecd_CheckedChanged"
                                        AutoPostBack="true" Enabled="false" Visible="false"/>
                                    
                                    <asp:HiddenField ID="hdnVerifyFees" runat="server"></asp:HiddenField>
                             
                                    <asp:LinkButton ID="lnkGetFees" runat="server" Text="Get Fees" OnClick="lnkGetFees_Click" Enabled="false" Visible="false"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                         
                      </div>
                     <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lbladvWaiverbtn" runat="server" CssClass="control-label labelSize " Visible="false" Text="Upload Adv's Waiver Form"></asp:Label>
                            <span id="spwaiver" runat="server" visible="false" style="color: #ff0000">*</span>
                      </div>
                       <div class="col-sm-3">
                            <asp:Label ID="lblAdvWaiverUpl" runat="server" Visible="false"></asp:Label>
                            <asp:FileUpload ID="AdvWaiverUpload" runat="server" Visible="false" Width="98%">
                            </asp:FileUpload>
                            <asp:CustomValidator ID="CVAdvWaiverValidator" runat="server" ControlToValidate="AdvWaiverUpload"
                                OnServerValidate="CVAdvWaiverValidator_ServerValidate" SetFocusOnError="True"> </asp:CustomValidator>
                       </div>
                 </div>
                        <div class="row" id="trTokenwithFees" runat="server" >
                      <div class="col-sm-3" style="text-align:left">
                           <%-- <asp:Label ID="lblTknNo" runat="server" Text="Token No" CssClass="control-label labelSize "></asp:Label>--%>
                    </div>
                        <div class="col-sm-3">
                           <%-- <asp:Label ID="lblTknNoValue" runat="server" CssClass="control-label labelSize "></asp:Label>--%>
                        </div>
                       <div class="col-sm-3" style="text-align:left">
                           <%-- <asp:Label ID="lblTotfees" runat="server" Text="Total Fees" CssClass="control-label labelSize "></asp:Label>--%>
                       </div>
                         <div class="col-sm-3">
                           <%-- <asp:Label ID="lblTotfeesValue" runat="server" CssClass="control-label labelSize "></asp:Label>--%>
                       </div>
                  </div>
                        <div class="row" id="trTokenwithLatestFees" runat="server" visible="false">
                       <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblTknNoLst" CssClass="control-label labelSize " runat="server" Text="Token No"></asp:Label>
                     </div>
                       <div class="col-sm-3">
                            <asp:Label ID="lblTknNoLstDesc" CssClass="control-label labelSize " runat="server"></asp:Label>
                      </div>
                      <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblTotfeesLst" runat="server" CssClass="control-label labelSize " Text="Fees as on todays date"></asp:Label>
                     </div>
                       <div class="col-sm-3">
                            <asp:Label ID="lblTotfeesLstDesc" CssClass="control-label labelSize " runat="server"></asp:Label>
                       </div>
             
             </div>
     
        </div>
        </div>
        <%--New ICM Details Added by rachana on 30-04-2014 Start --%>
        <table id="tblICMManual" runat="server" width="90%">
            <tr>
                <td align="left" class="test" colspan="4">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnICM"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divICM', 'ctl00_ContentPlaceHolder1_btnICM');" />
                    <asp:Label ID="lblNICMTitle" runat="server"  Text="Fees Details Edit"
                        Width="860px"></asp:Label>
                </td>
            </tr>
        </table>
        <div runat="server" id="divICM" style="display: none">
            <table runat="server" id="tblICMDetails" class="tableIsys" style="width: 90%;">
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:Label ID="lblPymtMode" runat="server" ></asp:Label>
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
                        <asp:Label ID="lblPymtAmt" runat="server" ></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="updpayment" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPymtAmt" runat="server" CssClass="standardtextbox"></asp:TextBox>
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
                                <asp:Label ID="lblChequeNo" runat="server" ></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updchq" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtChequeNo" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEChqNo" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                    FilterMode="InvalidChars" TargetControlID="txtChequeNo" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:UpdatePanel ID="updchqdate" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblChequeDate" runat="server" ></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="upddate" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtChequedate" runat="server" CssClass="standardtextbox" TabIndex="22" />
                                <asp:Image ID="btncal" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox ID="txtcal" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
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
                        <asp:Label ID="lblBankName" runat="server" ></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updbnkname" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtBankName" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEBnkName" runat="server" FilterType="LowercaseLetters, UppercaseLetters,Custom"
                                    ValidChars=" " TargetControlID="txtBankName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:Label ID="lblEFT" runat="server" ></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="upldeft" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TextEFT" runat="server" CssClass="standardtextbox"></asp:TextBox>
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
        



         <%--Fees Wavier Added by amrurta on 24-07-2015 start --%>
          <div id="tblFeesWavier" runat="server" visible="false" style="display:none;" class="panel"> <%--style="display:none;" Added by Ajay on 19 Apr 2018 for testing bug--%>
          
               <div  class="panel-heading subheader"  >       
              <%-- onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','ctl00_ContentPlaceHolder1_btnpersnl');return false;"   --%> 
                    
            </div>
            </div>
          <%--Fees Wavier Added by amrurta on 24-07-2015 end --%>
        <%--added by pranjali on 11-04-2014 start--%>
         <div id="tblEmsdtls" runat="server" style="display:none;" class="panel">
      
              <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgnPhotoTrnExmDtl','btnExmDtls');return false;" >           
                            <asp:UpdatePanel ID="updtblEmsdtls" runat="server">
            <ContentTemplate>
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                        
          
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnExmDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        </div>
              <div id="divAgnPhotoTrnExmDtl"  runat="server" class="panel-body" style="display:block">
            <asp:UpdatePanel ID="updexamdetailforqc" runat="server">
                <ContentTemplate>
                <div id="tblexam" runat="server">
                     <%--   <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblExamTitle" runat="server"  Text="Exam Details"></asp:Label>
                    </td>
                </tr>--%>
            <%--    added by amruta on 16.6.15 start--%>
               <div class="row" id="trCndExm3" runat="server" >
                <div class="col-sm-3" id="tdExmmode1" runat="server" style="text-align:left">
                           
                       </div>
                       <div class="col-sm-3" id="tdExmmode2" runat="server">
                         
                             
                    </div>
                    <div class="col-sm-3" id="tdExmCode1" runat="server" style="text-align:left">
                             
                                    <asp:Label ID="lblExmCode" Text="Exam Code " runat="server" CssClass="control-label labelSize " > </asp:Label>
                                       <span style="color: Red">*</span>
                         </div>
                          <div class="col-sm-3" id="tdExmCode2" runat="server" >
                                <asp:UpdatePanel ID="updExam1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList TabIndex="9" ID="ddlExamCode" runat="server" CssClass="form-control" AutoPostBack="true"
                                        >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                         </div>
                           <div class="col-sm-3" id="tdExmBody1" runat="server" style="text-align:left">
                           
                               
                                   
                        </div>
                         <div class="col-sm-3" id="tdExmBody2" runat="server">
                                
                            </div>
                      </div>
                         <%--   added by amruta on 16.6.15 end--%>
                          <%-- added by amruta on 15.6.15 for exam details start--%>
                             <div class="row" id="trCndExm" runat="server" >
                      <div class="col-sm-3" style="text-align:left">
                      <asp:Label ID="lblCanNo" runat="server"  CssClass="control-label labelSize " Text="Candidate Number "></asp:Label>
                        <span style="color: red">*</span>
                  </div>
                  <div class="col-sm-3">
                        <asp:TextBox ID="txtCanNo" runat="server" CssClass="form-control" TabIndex="11"></asp:TextBox>
                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCanNo"
                            ErrorMessage="Candidate Number should be Numeric.!!" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                 </div>
                       <div class="col-sm-3" style="text-align:left">
                        <asp:Label ID="lblCanMark" runat="server"  CssClass="control-label labelSize " Text="Candidate Marks "></asp:Label>
                        <span style="color: red">*</span>
                  </div>
                          <div class="col-sm-3">
                        <asp:TextBox ID="txtCanMark" runat="server" CssClass="form-control" TabIndex="12"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCanMark"
                            ErrorMessage="Candidate Marks should be Numeric.!!" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                   </div>
                     </div>
                       <%-- <tr id="trCndExm4" runat="server">
                            <td class="formcontent" style="width: 20%; height: 24px;">
                                <span style="color: Red">
                                    <asp:Label ID="lblpreexamlng" runat="server"  ></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%; height: 24px;">
                                <asp:UpdatePanel ID="updPreExmLng" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu" Width="185px"
                                            BackColor="#FFFFB2">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                          <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblCentre" runat="server" ></asp:Label>*</span>
                            </td>--%>
                        <%--    <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="updExmCentre" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExmCentre" runat="server" CssClass="standardmenu" Width="185px"
                                            BackColor="#FFFFB2" Visible="false">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtExmCentre" runat="server" Enabled="false" CssClass="standardtextbox"
                                            Visible="true" BackColor="#FFFFB2"></asp:TextBox>
                                        <asp:Button ID="btnExmCentre" runat="server" CausesValidation="False" CssClass="standardbutton"
                                            Text="Search" />
                                        <input type="hidden" runat="server" id="hdnExmCentreCode" />
                                        &nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>--%>
                         <div class="row" id="trCndExm2" runat="server" >
                          <div class="col-sm-3" id="tdPreExm"  runat="server" style="text-align:left">
                      
                             
                                   
                     </div>
                          <div class="col-sm-3" id="tdPreExmlng"  runat="server">
                               
                        </div>
                         <div class="col-sm-3" id="tdExmCenter1" runat="server" style="text-align:left">
                               
                                    
                           </div>
                           <div class="col-sm-3"  id="tdExmCenter2" runat="server">
                                   
                       
                                 
</div>
                          <%--  <div class="col-md-2" id="tdExmCenter2" runat="server" >
                                <asp:UpdatePanel ID="updExmCentre" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExmCentre" runat="server" CssClass="form-control" Visible="false" AutoPostBack="True">
                                        </asp:DropDownList>
                                        
                                                <asp:TextBox ID="txtExmCentre" runat="server" Enabled="false" CssClass="form-control"
                                                    Visible="true"  AutoPostBack="True"></asp:TextBox>
                                                    
                                  </ContentTemplate>
                                </asp:UpdatePanel>
                                </div>
                                                     <div class="col-md-1">
                                        <asp:Button ID="btnExmCentre" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                            Text="Search" />
                                                  <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> 
                           
                                        <input type="hidden" runat="server" id="hdnExmCentreCode" />
                                        &nbsp;
                          </div>--%>
                           <div class="col-sm-3" id="tdExmDt1" runat="server" style="text-align:left">
                                 
                                  <asp:Label ID="lblDtPass"  CssClass="control-label labelSize " Text="Date of Passing" runat="server"></asp:Label>
                                   <span style="color: red">*</span>
                               </div>
                                <div class="col-sm-3" id="tdExmDt2" runat="server">
                             
                                  <asp:TextBox ID="txtDateOfPass" runat="server" CssClass="form-control" 
                                   TabIndex="16"></asp:TextBox>
                                  <asp:Image ID="btnCalendarDtPass" runat="server" 
                                   ImageUrl="~/App_UserControl/Common/calendar.bmp" Height="16px" />
                                                    
                                  <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtDateOfPass"
                                   PopupButtonID="btnCalendarDtPass" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                   <asp:RequiredFieldValidator ID="RFVYrPass1" runat="server" SetFocusOnError="true" ControlToValidate="txtYrPass"
                                                            Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="CompareValidator61" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                                            Type="Date" ControlToValidate="txtYrPass" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidatorYrPass1" runat="server" ControlToValidate="txtYrPass" Display="Dynamic"
                                                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                            Type="Date"></asp:RangeValidator>
                                                 
                            </div>
                   </div>
                     <%-- Added by usha for Preferred date on 21.02.2018--%>

                   <div class="row" id ="Prefdate3" runat="server"  visible="false">
                            <div class="col-sm-3" style="text-align: left" >

                   
                        <asp:Label ID="LblPrefDate3" runat="server"  CssClass="control-label labelSize "  text="Preferred Date 3"  ></asp:Label>
                          <asp:Label ID="lblPrefDate3frmt" runat="server" Text="(dd/mm/yyyy)" CssClass="control-label labelSize "></asp:Label>
</div>
                    <div class="col-sm-3" style="text-align: left" >
                       <%--<asp:Label ID="lblPrefDate3Value" runat="server" CssClass="control-label labelSize "></asp:Label>--%> <%--coomented by amit--%>
                        <asp:TextBox ID="txtPrefDate3Value" runat="server" CssClass="form-control" onmousedown="$(this).datepicker({ maxDate: '+ 25', minDate: '1' ,changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });" ></asp:TextBox>
                      <%--  added by amit--%>
                     </div>
                    <div class="col-sm-3" style="text-align: left" >
                        
                     </div>
                    <div class="col-sm-3" style="text-align: left" >
                       
                    </div>
                    </div>
                     <%-- ended  by usha for Preferred date on 21.02.2018--%>
                   </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
            <div id="tblExmSchedule" runat="server"  visible="false" >
             <div runat="server" class="panel-heading subheader"    >   
                       <div class="row">
                    <div class="col-sm-6" style="text-align:left">
                    
                     <asp:Label ID="Label4" runat="server" Text="Exam Schedule"  CssClass="control-label labelSize " ></asp:Label>
                 
                    </div>
                                      <div class="col-sm-6" style="text-align:left">
                        <asp:Label ID="Label5" runat="server" Text="Preferred Exam Schedule"  CssClass="control-label labelSize " ></asp:Label>
                    </div>      
                    </div>        
                          </div>
             <div id="div5" runat="server" class="panel-body">
               <div class="row" >
                   <div class="col-sm-3" style="text-align:left">
                        <asp:Label ID="lblNWExmdt" runat="server" CssClass="control-label labelSize " ></asp:Label>
                    </div>
                   <div class="col-sm-3">
                        <asp:Label ID="lblNWExmdtValue" CssClass="control-label labelSize " runat="server"></asp:Label>
                        <asp:Label ID="lblNwExmfrmt" runat="server" CssClass="control-label labelSize " Text="(dd/mm/yyyy)"></asp:Label>
                 </div>
                     <div class="col-sm-3" style="text-align:left">
                        <asp:Label ID="lblExmdt1" Text="Preferred Exam Date 1" CssClass="control-label labelSize " runat="server"></asp:Label>
                   </div>
                     <div class="col-sm-3">
                        <asp:Label ID="lblpref1value" CssClass="control-label labelSize " runat="server"></asp:Label>
                        <asp:Label ID="lblprefformat1" CssClass="control-label labelSize " runat="server" Text="(dd/mm/yyyy)"></asp:Label>
                    </div>
               </div>
         </div>
         </div>
            <table runat="server" id="tblPrefExm" class="tableIsys" style="width: 90%;"
                visible="false">
                <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <%--<asp:Label ID="Label5" Text="Preffered Exam Schedule" runat="server" ></asp:Label>--%>
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
                        <asp:Label ID="lblExmdt2" runat="server" Text="Preferred Exam Date 2" 
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
        </div>
        <%-- Old Exam Details start--%>
        <div class="panel" id="tbloldexm" runat="server" visible="false" >
             <div  visible="false" class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivOldExmdtls','BtnOldExmDtls');return false;" >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lbloldexm" runat="server" Text="Old Exam Details" CssClass="control-label labelSize " font-size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="BtnOldExmDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
          <div id="DivOldExmdtls" runat="server" class="panel-body" style="display: block;">
           <div class="row" style=" display:none">
               <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblOExam" runat="server"  CssClass="control-label labelSize " Text="Exam Mode"> </asp:Label>
                    <span style="color: #ff0000">*</span>
                </div>
               <div class="col-sm-3">
                    <asp:TextBox ID="txtExm" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
              </div>
               <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lbloldexmbody" runat="server"  CssClass="control-label labelSize " Text="Examination Body"></asp:Label>
                    <span style="color: #ff0000">*</span>
            </div>
               <div class="col-sm-3">
                    <asp:TextBox ID="txtBody" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
                  <div class="row" style=" display:none">
             <div class="col-sm-3" style="text-align:left">
                    <span style="color: Red">
                        <asp:Label ID="lbloldpref" runat="server"  Text="Preferred Exam Language"
                            ></asp:Label>*</span>
                    <%--<span style="color: #ff0000">*</span>--%>
              </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtLang" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    <%--   <asp:UpdatePanel ID="updPreExmLng" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu" DataTextField="ParamDesc1"
                                    DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="DSddlpreeamlng">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DSddlpreeamlng" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
               </div>
               <div class="col-sm-3" style="text-align:left">
                    <span style="color: Red">
                        <asp:Label ID="lbloldCentre" runat="server"  Text="Exam Centre"></asp:Label>*</span>
                    <%--   <span style="color: #ff0000">*</span>--%>
              </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="textoldexmcenter" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
          </div>
        </div>
        </div>
        <%--Old Exam Details End --%>
        <%--added by pranjali on 11-04-2014 end--%>
        <%--added by pranjali on 28-04-2014--%>
        <%--New Exam Details Start --%>
               <div class="card PanelInsideTab_body" id="tblreasonNOC1" runat="server" visible="false">
                 <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNOCdetails','btnReasonLeave');return false;" >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="reasonNOC" runat="server" text="Reason for NOC" CssClass="control-label labelSize " font-size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnReasonLeave" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                 <div id="divNOCdetails" runat="server"   style="display: block"> 
                 <div runat="server" id="tblreasonnoc" visible="false">
                      <div class="row rowspacing" id="trreasontext" runat="server" style="margin-bottom:5px">
                        <div class="col-md-4" style="text-align:left">
                            <asp:Label ID="lblselect" runat="server" Text="Type of Reason for NOC" CssClass="control-label labelSize " ></asp:Label>
                     
                            <asp:TextBox ID="lblsnlve" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                           </div>
                  
                          <div class="col-md-4" id="tdreasontext" runat="server" style="text-align:left">
                            <asp:Label ID="lblreasontext" runat="server" CssClass="control-label labelSize " Text="Remark of Reason for NOC" ></asp:Label>
                            
                         <asp:TextBox ID="txtreasonleave" runat="server" Rows="4"  TextMode="multiline"  Enabled="false" CssClass="form-control"></asp:TextBox>
                        
                       </div>
                  </div>
                  </div>
    </div>
   
          <div class="card PanelInsideTab_body" id="tblCategory" runat="server" visible="false">
             <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div6','btncat');return false;" >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblcat" runat="server" text="Category of Appointment " CssClass="control-label labelSize " font-size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btncat" class="glyphicon glyphicon-chevron-down"  runat="server" style="float: right;
                           padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                           <div id="div6" runat="server" class="panel-body" style="display:block">
                    <div class="row rowspacing" id="trCatbind" runat="server"  visible="false">
                    <div class="col-sm-3" id="tdcatappbind" runat="server" style="text-align:left">
                                    <asp:Label ID="lblCatAppointment" runat="server"   CssClass="control-label labelSize " Text="Category of Appointment"></asp:Label>
                              <%-- </div>
                                <div class="col-sm-3" id="td19" runat="server">--%>
                                    <asp:TextBox  ID="lblCatAppBind" runat="server" CssClass="form-control" Enabled="False" ></asp:TextBox>
                                </div>
                                <div class="col-sm-3" id="tdcatbind" runat="server" style="text-align:left">
                                    <asp:Label ID="lblcatbind" runat="server"  CssClass="control-label labelSize "  Text="Category"></asp:Label>
                            <%-- </div>
                              <div class="col-sm-3" id="tdcategorybind" runat="server">--%>
                                 <asp:TextBox  ID="lblcategorybind" runat="server" CssClass="form-control" Enabled="False" ></asp:TextBox>
                                   
                             </div>
                       <%-- this div removed by ajay 06032023--%>
                        <%-- <div class="row rowspacing" id="trNameInsurance" runat="server" visible="false">  --%>   
                       <div class="col-sm-3" id="trNameInsurance" visible="false"  runat="server" style="text-align:left">
                            <asp:Label ID="lblNameIns" runat="server" CssClass="control-label labelSize " Text="Name of insurance" ></asp:Label>
                            <%--<span style="color: red">*</span>--%>
 
                       <%-- </div>
                          <div class="col-sm-3">--%>
                            <asp:TextBox ID="lblNameBind" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                         </div>
                          </div> <%--this div added by ajay 06032023--%>
                      <%--</div>--%>
         <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                                           <div id="divCat" runat="server"  visible="false">

                
                    <div  runat="server" id="tblcat">
                      <div class="row" id="trCatApp" runat="server" >
                        <div class="col-sm-3" id="tdCatApp" runat="server" style="text-align:left">
                                
                                        <asp:Label ID="lblCatApp" runat="server"  CssClass="control-label labelSize "  Text="Category of Appointment"></asp:Label>
                                            <span style="color: Red;">*</span>
                         </div>
                          <div class="col-sm-3" id="tdddlCatApp" runat="server">
                                    <asp:UpdatePanel ID="updcatapp" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlcatapp" runat="server" CssClass="form-control" AutoPostBack="true"
                                                 TabIndex="6" OnSelectedIndexChanged="ddlcatapp_SelectedIndexChanged"
                                               >
                                                <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                         </div>
                          <div class="col-sm-3" id="tdCat" runat="server" style="text-align:left">
                                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Visible="false" CssClass="control-label labelSize "  Text="Category"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                               </div>
                                <div class="col-sm-3" id="tdddlCat" runat="server">
                                    <asp:UpdatePanel ID="updOthers" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="ddlcat" Visible="false" runat="server" CssClass="form-control" AutoPostBack="true"
                                                Enabled="false" Text="Non-Life" TabIndex="6">
                                                       
                                                        
                                            </asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                              </div>
                            </div>
                              
                       <div id="trLife" runat="server" class="row rowspacing">
                    <div class="col-sm-12" style="text-align:left">
                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                    <asp:CheckBox ID="cbLife" runat="server" CssClass="standardcheckbox" AutoPostBack="true" onclick="lifediv();"
                                                OnCheckedChanged="cbLife_CheckedChanged" TabIndex="19" />
                     <asp:Label ID="lblLife" runat="server" Text="Life (For composite Case)"  CssClass="control-label labelSize " ></asp:Label>
                 </ContentTemplate>
                                    </asp:UpdatePanel>
                    </div>
                
                    </div>        
                         
                            <div  id="trIns" runat="server" style="display:none">
                                <div class="row rowspacing">

                             
                             <div class="col-sm-4" id="tdIns" runat="server" style="text-align:left">
                                  
                                        <asp:Label ID="Label8" runat="server"  CssClass="control-label labelSize "  Text="Name of Insurance"></asp:Label>
                                          
                                    <asp:DropDownList ID="ddlIns" runat="server" CssClass="form-control mandatory" AutoPostBack="true"
                                         TabIndex="6" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" >
                                        <asp:ListItem Text="Select" Value="0"> </asp:ListItem>
                                    </asp:DropDownList>
                            </div>
                                  <div class="col-sm-4" id="tdother" runat="server" style="text-align:left">
                                    <asp:Label ID="Label9" CssClass="control-label labelSize " runat="server"   Text="From others please specify"></asp:Label>
                            <%--</div>
                             <div class="col-sm-3" id="tdtxtother" runat="server">--%>
                                    <asp:TextBox ID="txtOther" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                        MaxLength="30"  TabIndex="8"  Enabled="false"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`0123456789" FilterMode="InvalidChars"
                                        TargetControlID="txtOther" FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                             </div>
                         </div>
                          </div>
                       <div id="trHealth" runat="server" class="row">
                    <div class="col-sm-12" style="text-align:left">
                     <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                        <ContentTemplate>
                    <asp:CheckBox ID="cbHealth" runat="server" CssClass="standardcheckbox" AutoPostBack="true" onclick="healthdiv();"
                                                OnCheckedChanged="cbHealth_CheckedChanged" TabIndex="19" />
                                            
                     <asp:Label ID="lblHealth" runat="server" Text="Health (For composite Case)"  CssClass="control-label labelSize " ></asp:Label>
                 </ContentTemplate>
                                    </asp:UpdatePanel>
                    </div>
                
                    </div>        
                         
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div id="trHealthIns" runat="server" style="display:none">
                                    <div class="row rowspacing">

                                   <div class="col-sm-4" style="text-align:left" runat="server" id="collblInsHlth">
                                        <asp:Label ID="lblInsHlth" runat="server"  CssClass="control-label labelSize" 
                                            Text="Name of Insurance"></asp:Label>
                                    <asp:DropDownList ID="ddlInsname" runat="server" CssClass="form-control mandatory" AutoPostBack="true"
                                       TabIndex="6" OnSelectedIndexChanged="ddlInsname_SelectedIndexChanged" >
                                        <asp:ListItem Text="Select" Value="0"> </asp:ListItem>
                                    </asp:DropDownList>
                        </div>
                         <div class="col-sm-4" style="text-align:left" runat="server" id="collblOtherH">
                                    <asp:Label ID="lblOtherH" runat="server"  CssClass="control-label labelSize "  Text="From others please specify"></asp:Label>
                                    <asp:TextBox ID="txtOtherH" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                        MaxLength="30"  TabIndex="8"  Enabled="false"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`0123456789" FilterMode="InvalidChars"
                                        TargetControlID="txtOtherH" FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                              </div>  
                                    </div>
                                
                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                         
                          </div> 

                       
                   
              
                         
            </div>
             </ContentTemplate>
                </asp:UpdatePanel>
                           </div>
           </div> 
        
                 


          <div class="card PanelInsideTab_body" id="tblResonInsurer" runat="server" visible="false">
      <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divInsurer','btnremark');return false;" >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblremarkinsurer" runat="server" text="Remark of Insurer" CssClass="control-label labelSize " font-size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnremark" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                         <div id="divInsurer" runat="server"   style="display: block">
                <%--Added by rachana on 29-07-2013 for toggle of agent details end--%>
                <div runat="server" id="tblremarkinsurer" visible="false" >
                <div class="row">
                      <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblremark" runat="server" Text="Remark of Insurer" CssClass="control-label labelSize " ></asp:Label>
                           </div>
                         <div class="col-md-6">
                         <asp:TextBox ID="txtReInsurer" runat="server" Rows="4" Enabled="false" TextMode="multiline"  CssClass="form-control"></asp:TextBox>
                      </div>
                       </div>
                 </div>
               </div>         
                 </div> 
           </div>
                    <div id="trReject" visible="false" runat="server" class="card PanelInsideTab_body">  
                       <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divRejectDetails','btnreject');return false;" >           
                           
                                    
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                       <asp:Label ID="lblRejectDtl" Text=" Reason for Reject" runat="server" CssClass="control-label labelSize " font-size="19px"></asp:Label>
                      
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnreject" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                 
                        </div>             
                         <div id="div7" runat="server"  style="display:block" class="card PanelInsideTab_body">
                           <div class="row" style="text-align:left;margin:1px">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                        <ContentTemplate>
                                                      
                                       <asp:Label ID="lblRejectFlag" runat="server"  Text="Reject Case" ></asp:Label>
                                                    
                       <asp:CheckBox ID="cbRejectFlag" runat="server" CssClass="standardcheckbox"  
                                                        AutoPostBack ="true" Enabled="true"
                                                        oncheckedchanged="cbRejectFlag_CheckedChanged"  TabIndex="20" style='margin-left:1px'/>
                  </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    </div>
                                                      <div class="row" style="text-align:left">
                                     <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                        <ContentTemplate>
                                       <div id="divRejectDetails" runat="server" visible="false" style="display:block" class="panel-body">
                             <div class="row" >
                              <div class="col-md-6" style="text-align:left">
                                <asp:Label ID="lblReject" runat="server" Text="Reason for Reject" CssClass="control-label labelSize " ></asp:Label>
                                <span style="color: Red"> *</span>
                          </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtReject" runat="server" Rows="4" TextMode="multiline" CssClass="form-control"></asp:TextBox>
                           </div>
                    </div>
                                           </div>
                                           </ContentTemplate>
                                           <Triggers><asp:AsyncPostBackTrigger ControlID="cbRejectFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger></Triggers>
                            </asp:UpdatePanel> 
                              </div>       
                  </div>
                 </div>
                       
                        <div id="tblNExmTitle" visible="false" runat="server" class="panel">
                        <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNewExmDtls','btnNwExm');return false;" >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblNExamTitle" Text="New Exam Details" runat="server" CssClass="control-label labelSize " font-size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnNwExm" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
     <div id="divNewExmDtls" runat="server" class="card PanelInsideTab_body" style="display:block">
     <div runat="server" id="tblNexam" visible="true">
            <div class="row" >
                  <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblNExam" runat="server" CssClass="control-label labelSize "  > </asp:Label>
                             <span style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">

                        <asp:UpdatePanel ID="updNExam" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNExam" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlNExam_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                   </div>
                <div class="col-sm-3" style="text-align:left">
                        <span style="color: #ff0000">
                            <asp:Label ID="lblNExmBody" CssClass="control-label labelSize " runat="server" ></asp:Label>*</span>
                  </div>
                   <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdNExmBody" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNExmBody" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlNExmBody_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                   </div>
               </div>
                <div class="row" >
                   <div class="col-sm-3" style="text-align:left">
                        <span style="color: Red">
                            <asp:Label ID="lblNpreexamlng" runat="server"  CssClass="control-label labelSize " ></asp:Label>*</span>
                        <%--//removed text by pranjali on 25-04-2014--%>
                </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="updNPreExmLng" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNpreeamlng" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlNpreeamlng_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                  </div>
                   <div class="col-sm-3" style="text-align:left">
                        <span style="color: Red">
                            <asp:Label ID="lblNCentre" runat="server" CssClass="control-label labelSize " ></asp:Label>*</span>
                   </div>
                   <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNExmCenter" runat="server" CssClass="standardmenu" Visible="false"
                                    BackColor="#FFFFB2" Width="185px">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtNExmCenter" runat="server" Enabled="false" CssClass="form-control"
                                    Visible="true" ></asp:TextBox>
                                <asp:Button ID="btnNExmCenter" runat="server" CausesValidation="False" CssClass="standardbutton"
                                    Text="Search" />
                                <input type="hidden" runat="server" id="hdnNExmCenter" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                   </div>
              </div>
            </div>
        </div>
        </div>
        <%--New Exam Details end --%>
        <%--added by pranjali on 28-04-2014--%>
        <%--pranjali--%>
        <div class="panel" id="tbltrndtls"  visible="false" runat="server">
          <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_Divoldtrndtls','BtnOldTrnDtls');return false;"
          >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label3" runat="server" Text="Old Training Details" CssClass="control-label labelSize " font-size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="BtnOldTrnDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
   
            <div id="Divoldtrndtls" runat="server" class="panel-body" style="display: none;">
            <div id="tbltrndtlsall" runat="server">
        <div class="row" >
           <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblTrnMode1" runat="server" CssClass="control-label labelSize "  Text="Training Mode"></asp:Label>
              </div>
                 <div class="col-sm-3"  style="text-align:left">
                    <asp:Label ID="lblTrnModeValue" CssClass="control-label labelSize " runat="server"></asp:Label>
               </div>
               <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblTrnLoc1" runat="server"  CssClass="control-label labelSize " Text="Training Location"></asp:Label>
             </div>
                <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblTrnLocValue" CssClass="control-label labelSize " runat="server" ></asp:Label>
              </div>
            </div>
               <div class="row" >
              <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblTrnInst1" runat="server" CssClass="control-label labelSize "  Text="Training Institute"></asp:Label>
             </div>
                 <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblTrnInstituteValue" runat="server" ></asp:Label>
                </div>
            <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblAcc1" runat="server"  CssClass="control-label labelSize " Text="Accrediation No."></asp:Label>
              </div>
               <div class="col-sm-3" style="text-align:left">
                    <asp:TextBox ID="lblAccvalue1" CssClass="form-control" runat="server" Enabled="false" ></asp:TextBox>
                </div>
         </div>
          <div class="row" >
              <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblTrnHrs1" runat="server" CssClass="control-label labelSize "  Text="Training Hours"></asp:Label>
               
                  </div>
                
              <div class="col-sm-3" style="text-align:left" >
                    <asp:Label ID="lblTrnHrsValue1" runat="server" CssClass="control-label labelSize "  ></asp:Label>
               </div>
              <div class="col-sm-3" style="text-align:left"></div>
              <div class="col-sm-3" style="text-align:left"></div>
         
      </div>
        </div>
        </div>
            </div>
         <div class="panel" id="tbltrn" style="display:none" runat="server">
        <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_Divtrndtls','BtnTrnDtls');return false;"
        >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                    
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="BtnTrnDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                         <asp:UpdatePanel ID="updtrn" runat="server">
            <ContentTemplate>
                 <div id="Divtrndtls" runat="server" class="panel-body" style="display: block;">
                 <div runat="server" id="tbltrndtlss" visible="true">
                       <div class="row" >
                           <div class="col-sm-3" style="text-align:left">
                                
                                    
                                <%-- <span style="color: #ff0000">*</span>--%>
                         </div>
                            <div class="col-sm-3">
                               
                         </div>
                           <div class="col-sm-3" style="text-align:left">
                               
                                   
                                <%-- <span style="color: #ff0000">*</span>--%>
                          </div>
                             <div class="col-sm-3">
                               
                        </div>
                            <%--Added by M.Valvi--%>
                   </div>
                        <div class="row" >
                            <div class="col-sm-3" style="text-align:left">
                             
                                    
                                <%-- <span style="color: #ff0000">*</span>--%>
                         </div>
                         <div class="col-sm-3">
                             
                           </div>
                            <div class="col-sm-3" style="text-align:left">
                              
                          </div>
                          <div class="col-sm-3">
                               
                           </div>
                    </div>
                        <div class="row" >
                           <div class="col-sm-3" style="text-align:left">
                                
                          </div>
                           <div class="col-sm-3" style="text-align:left">
                                <%--<asp:Label ID="lblHrnTrn" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>--%>
                                <asp:Label ID="lblExmType" runat="server"  CssClass="control-label labelSize " Visible="False"></asp:Label>
                          </div>
                           <div class="col-sm-3">
                                <%--<asp:DropDownList ID="ddlHrsTrn" runat="server" Width="120px">
                            <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                        </asp:DropDownList>--%>
                                <%--<asp:UpdatePanel ID="updExpTpe" runat="server" >
                            <ContentTemplate>--%>
                                <asp:DropDownList ID="ddlExmTpe" runat="server" Visible="False" CssClass="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlExmTpe_SelectedIndexChanged">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="New Advisor" Value="NADV"></asp:ListItem>
                                    <asp:ListItem Text="Repeater" Value="REXM"></asp:ListItem>
                                </asp:DropDownList>
                                <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                          </div>
                        </div>
                </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        </div>
        <div id="divPOI" runat="server" visible="false">
            <table runat="server" id="tblPOI" class="tableIsys" style="width: 90%;">
                <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblPOITitle" runat="server"  Text="Proof of Document"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblBasicQual" runat="server"  Text="Basic Qualification"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdBasicQual" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlBasicQual" runat="server" CausesValidation="true" BackColor="#FFFFB2"
                                    CssClass="standardmenu">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblBoardName" runat="server"  Text="Board Name"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtBoardName" runat="server" BackColor="#FFFFB2" CssClass="standardtextbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblBasicRNo" runat="server"  Text="Basic Qual. Roll No"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtBasicRNo" runat="server" BackColor="#FFFFB2" CssClass="standardtextbox"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVBasicRNo" runat="server" ControlToValidate="txtBasicRNo"
                            ErrorMessage="Basic Roll No. should be Numeric.!!" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblYrPass" runat="server"  Text="Year of Passing"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox CssClass="standardtextbox" runat="server" ID="txtYrPass" Width="90px"
                            BackColor="#FFFFB2" />
                        <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <asp:TextBox CssClass="standardtextbox" ID="txtDtValidate" Style="display: none"
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
                        <asp:Label ID="lblpfeduproof" runat="server"  Text="Qualification"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;" colspan="3">
                        <asp:UpdatePanel ID="Upeducationproof" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddleducationproof" runat="server" CssClass="standardmenu" DataTextField="ParamDesc"
                                    DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="dseducationproof"
                                    BackColor="#FFFFB2">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="dseducationproof" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 20%;">
                    </td>
                    <td class="formcontent" style="width: 501px;">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblCasteCat" runat="server"  Text="Category"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:DropDownList ID="ddlCasteCat" runat="server" CssClass="standardmenu" BackColor="#FFFFB2">
                        </asp:DropDownList>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblPrimProf" runat="server"  Text="Primary Profession"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtPrimProf" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <%--<div id="divAdvDtl" runat="server">
            <table  class="formtable" style="width: 90%;">
                 <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblAdvDtl" runat="server"  Text="Candidate Image Details"></asp:Label>
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
                    <asp:Label ID="lblheadtrans" runat="server" Text="Transfer/Composite Details" ></asp:Label>
                </td>
            </tr>
        </table>--%>
        <%--<div runat="server" id="divtransfer" style="display: none;">
            <table id="TblTransfer" runat="server" style="width: 90%" class="formtable">
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblTrfrFlag" runat="server"  Text="Transfer Case">
                        </asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox" AutoPostBack="false"
                            OnCheckedChanged="cbTrfrFlag_CheckedChanged" TabIndex="19" />
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblCompLcn" runat="server"  Text="Composite License">
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
                        <asp:Label ID="lbloldLcnNo" runat="server"  Text="Life License No">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtOldTccLcnNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                            TabIndex="21">
                        </asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                            InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo"
                            FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lblOldLcnexpDate" runat="server"  Text="Old License Exp.Date">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                            TabIndex="22" />
                        <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <asp:TextBox ID="txtOldLicense" runat="server" CssClass="standardtextbox" Style="display: none">
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
                        <asp:Label ID="lblPrevInsurerName" runat="server"  Text="Prev Insurer Name">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtTccPrevInsurerName" runat="server" CssClass="standardtextbox"
                            BackColor="#FFFFB2" TabIndex="23">
                        </asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                            InvalidChars=",#$@%^!*()&''%^~`1234567890" FilterMode="InvalidChars" TargetControlID="txtTccPrevInsurerName"
                            FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lblNOCFlag" runat="server"  Text="NOC Received"></asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbNOCFlag" runat="server" CssClass="standardcheckbox" BackColor="#FFFFB2"
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
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkNOCAck" runat="server" BackColor="#FFFFB2"
                            TabIndex="118" />
                    </td>
                    <td class="formcontent" colspan="2">
                    </td>
                </tr>
            </table>
        </div>--%>
        <%--added by pranjali on 13-03-2014 for transfr deatils start--%>

          <div class="panel" id="divCand" style="display:none;" runat="server">
              <div id="Div12" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTrComp','btnTrComp');return false;"
           >  
                                        <div class="row">
                                         <div class="col-sm-10" style="text-align:left;">

                                             <span style="font-size:19px">Candidate Type</span>
                                             
                  
                
                    </div>
                                         <div class="col-sm-2">
                        <span id="btnTrComp" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                                               
                                        </div>
                                    </div>
                                       <div id="divTrComp" style="display:block;" runat="server" class="card PanelInsideTab_body">

                                       <div class="row">
                                       <div  id="trFreshTitle"  runat="server" class="col-sm-4" style="text-align:center">
                                      <asp:Label ID="lblfreshDtl" Visible="false" Text="Fresh Details" runat="server" ></asp:Label>
                                   
                                 <%--     <asp:CheckBox ID="cbFrshFlag" runat="server" CssClass="standardcheckbox"  
                                                        AutoPostBack ="true" Enabled="false" Name="a"
                                                        TabIndex="20"/>--%>
                                            <asp:RadioButton GroupName="a" ID="cbFrshFlag" runat="server" CssClass="standardcheckbox"  Enabled="false" 
                                                        AutoPostBack ="true" TabIndex="20"/>
                                                       
                                                    <asp:Label ID="lblfrshFlag" runat="server"   Text="Fresh" ></asp:Label>
                                                    
                                                    
                                      </div>
                                     

                                         <div  id="trTagTitle"  runat="server" class="col-sm-4" style="text-align:center">
                                      <asp:Label ID="Label21" Visible="false" Text="Transfer Details" runat="server" ></asp:Label>
                                      <%--<asp:CheckBox ID="cbTagFlag" runat="server" CssClass="standardcheckbox"  
                                                        AutoPostBack ="true" Name="a"
                                                        oncheckedchanged="cbTagFlag_CheckedChanged"  TabIndex="20"/>--%>
                                             <asp:RadioButton  ID="cbTagFlag" runat="server" CssClass="standardcheckbox"  
                                                        AutoPostBack ="true" GroupName="a"
                                                        oncheckedchanged="cbTagFlag_CheckedChanged"  TabIndex="20"/>
                                                    <asp:Label ID="Label22" runat="server"   Text="Tagged" ></asp:Label>
                                                    
                                                    
                                      </div>
                                       <div id="trCompTitle"  runat="server" class="col-sm-3" style="text-align:center;display:none;">  <%--Added display:none by Meena--%>
                                           
                                                    <asp:Label ID="Label15" Visible="false" Text="Composite Details" runat="server" ></asp:Label>
                                                      <%-- <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox"  Enabled="True" AutoPostBack ="true"
                                                         TabIndex="21" oncheckedchanged="cbTccCompLcn_CheckedChanged"  />--%>
                                          
                                                 
                                                 
                                                       
                                      </div>
                                    </div>
        </div>
            
               </div>
                                         <div class="row">
       <%-- <asp:updatepanel runat="server">
    <contenttemplate>--%>
        <div class="panel" id="trnsfrtitle" runat="server" visible="false" style="margin-left: 14px; margin-right: 12px;">
          <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTrnsferDetails','btnTrnsfr');return false;"
          >           
                          <div class="row" id="trtran" runat="server">
                    <div class="col-sm-10" style="text-align:left">
                         <asp:Label ID="lblTransferDtl" runat="server" CssClass="control-label labelSize " text="Transfer Details" Font-Size="19px" ></asp:Label>
                       <%--<asp:Label ID="lblTransferDtl" Text="Transfer Details" runat="server"  font-size="19px"></asp:Label>--%>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <%--<asp:Label ID="lblTrfrFlag" runat="server"  Text="Transfer Case" font-size="19px"></asp:Label>--%>&nbsp&nbsp&nbsp&nbsp&nbsp
                   <%--         <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox" AutoPostBack="true"
                                OnCheckedChanged="cbTrfrFlag_CheckedChanged" TabIndex="19" />--%>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnTrnsfr" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
        <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>--%>
             <div id="divTrnsferDetails" style="display:none;" runat="server" class="card PanelInsideTab_body">
                                       
             <%--     added by amruta for transfer start on 11.6.15--%>
             <div class="row"  id="trNoteTr" runat="server">
                                        <div class="col-sm-3" style="text-align:left">
                                        
                                           <asp:Label ID="lblIC"  Text="I-C Date" CssClass="control-label labelSize " runat="server"></asp:Label>
                                             <span style="color: red">*</span>          
                                        </div>
                                       <div class="col-sm-3">
                                          <%-- <asp:TextBox ID="txtIC" runat="server" CssClass="form-control"
                                            TabIndex="10"></asp:TextBox>--%>
                                                <asp:TextBox CssClass="form-control" 
                     runat="server" ID="txtIC" MaxLength="15"
                            TabIndex="10" /> 

                                            <%--<asp:Image ID="btnCalendarIC" runat="server" 
                                                  ImageUrl="~/App_UserControl/Common/calendar.bmp" Height="16px" />
                                                    
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender28" runat="server" TargetControlID="txtIC"
                                                            PopupButtonID="btnCalendarIC" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>--%>
                                             </div>
                                            <div class="col-md-6" id="tdNoteIc" runat="server" style="text-align:left">
                                           <%--<asp:Label ID="lblNoteIc"  runat="server" Text="Please provide last insurer I-C Date" CssClass="control-label labelSize " ForeColor="Red"></asp:Label>--%>
                                         </div>
                                          
                                     </div>
                                        <%--     added by amruta for transfer end on 11.6.15--%--%> 
			                               <tr id="trTCCase"  style="display:none;" runat="server"  >
			                                    <td align="left" class="formcontent" style="width:20%; display:none;">
                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lbloldLcnNo" runat="server" Style="color: black; display:none;" Text="License No"></asp:Label>
                                                  <%--  <span style="color: #ff0000">*</span>--%>
                                                </td><%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                                                <td class="formcontent" style="width: 30%;  display:none;">
                                                <asp:UpdatePanel ID="updlcnVer1" runat="server" style="display:none;" >
                                                        <ContentTemplate>
                                                    <asp:TextBox id="txtOldTccLcnNo" runat="server"  style="display:none;"  CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="21"  AutoPostBack="true"></asp:TextBox>
                                                    <br /><asp:Label ID="lbllcnerr2" Font-Size="X-Small" Visible="false" ForeColor="Green" runat="server"/>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                                          FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="formcontent" style="width:20%; display:none;">
                                                 <%--<span style="color: red">--%>
                                                    <asp:Label ID="lblOldLcnexpDate" runat="server" Style="color: black ; display:none;"></asp:Label><%--*</span>--%>
                                                   
                                                </td>
                                                <td class="formcontent" style="width: 30%;  display:none;">
                                                   <asp:TextBox  ID="txtDate" runat="server" CssClass="standardtextbox" style=" display:none;"  BackColor="#FFFFB2"  TabIndex="22"/>
                                                    <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" style="display:none;" /> 
                                                    <asp:TextBox ID="txtOldLicense" runat="server" CssClass="standardtextbox"  style="display: none" ></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CldrExtendrOldLicense" runat="server" TargetControlID="txtDate" PopupButtonID="btnoldlicense" Format="dd/MM/yyyy"  />
                                                    <asp:RequiredFieldValidator ID="RFVOldLicense" runat="server" SetFocusOnError="true"  ControlToValidate="txtDate"  Enabled="false"
                                                    ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <ASP:COMPAREVALIDATOR id="COMPAREVALIDATOROldLicense" runat="server" errormessage="Invalid date!" operator="DataTypeCheck" type="Date" 
                                                    controltovalidate="txtDate" Display="Dynamic" ></ASP:COMPAREVALIDATOR>&nbsp;
                                                    <asp:RangeValidator ID="RVOldLicense" runat="server" ControlToValidate="txtDate" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                                   <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                                                </td>
			                               </tr>
			                               <tr id="trTCCase1" style="display:none;" runat="server" >
			                                    <td align="left" class="formcontent" style="width:20%; display:none;">
                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lblPrevInsurerName" runat="server" Style="color: black; display:none;" Text="Insurer Name" ></asp:Label>
                                                   <%-- <span style="color: #ff0000">*</span>--%>
                                                </td>
                                                <td class="formcontent" style="width: 30%; display:none;">
                                                    <%--<asp:TextBox id="txtTccPrevInsurerName" runat="server" 
                                                        CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="23" Visible="false" ></asp:TextBox>--%>
                                                        <asp:DropDownList id="ddlTrnsfrInsurName" runat="server"  style="display:none;" CssClass="standardmenu"  BackColor="#FFFFB2" 
                                                       Width="270px" TabIndex="65" ></asp:DropDownList>
                                                    <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtTccPrevInsurerName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                                </td>  
                                                <td align="left" class="formcontent" style="width:20%; display:none;">
                                                
                                                    <asp:Label ID="lblLicIssueDt" runat="server" Style="color: black; display:none;" Text="License Issue Date" ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%; display:none;">
                                                   <asp:updatepanel ID="Updatepanel134" runat="server" style="display:none;">
                                                         <ContentTemplate>
                                                           <asp:TextBox id="txtLicIssueDt" runat="server" CssClass="standardtextbox"  style="display:none;" BackColor="#FFFFB2" TabIndex="21"></asp:TextBox> 
                                                        <asp:Image ID="btnLicIssue" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" style="display:none;" /> 
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="standardtextbox"  style="display: none" ></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender23" runat="server" TargetControlID="txtLicIssueDt" PopupButtonID="btnLicIssue" Format="dd/MM/yyyy"  />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" SetFocusOnError="true"  ControlToValidate="txtLicIssueDt"  Enabled="false"
                                                    ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <ASP:COMPAREVALIDATOR id="COMPAREVALIDATOR24" runat="server" errormessage="Invalid date!" operator="DataTypeCheck" type="Date" 
                                                    controltovalidate="txtLicIssueDt" Display="Dynamic" ></ASP:COMPAREVALIDATOR>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator23" runat="server" ControlToValidate="txtLicIssueDt" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                                        </ContentTemplate>                                        
                                                     </asp:updatepanel>
                                                </td> 
                                                 <%--// 01...06/09/2012...Miti--%>
			                               </tr>
                                           
                                           <tr id="tr6" style="display:none;" runat="server">
			                                     <td align="left" class="formcontent" style="width:20%; display:none;">
                                              
                                                    <asp:Label ID="lblNOCFlag" runat="server" Style="color: black; display:none;" Text="NOC Received" ></asp:Label>
                                                  <%--  <span style="color: #ff0000">*</span>--%>
                                                </td>
                                                <td class="formcontent" style="width: 30%; display:none;">
                                                <%--// 01...06/09/2012...Miti--%>
                                                     <asp:CheckBox ID="cbNOCFlag" runat="server" style=" display:none;" CssClass="standardcheckbox" BackColor="#FFFFB2" AutoPostBack="false" Visible = "false" 
                                                          /> <%----%>
                                                     <asp:updatepanel ID="upnlRbtNoc" runat="server" style=" display:none;">
                                                         <ContentTemplate>
                                                            <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal" 
                                                               CssClass="radiobtn" TabIndex="24" style=" display:none;"
                                                               AutoPostBack="true" OnSelectedIndexChanged="RbtNoc_SelectedIndexChanged">
                                                            <asp:ListItem Value="Y" Text="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N" Text="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </ContentTemplate>                                        
                                                     </asp:updatepanel>
                                                </td>
                                                <td align="left" class="formcontent" style="width:20%; display:none;">
                                                </td>
                                                <td class="formcontent" style="width: 30%; display:none;">
                                                </td>
			                               </tr>
                                           <tr id="trAckRcv" style="display:none;" runat="server">
                                           <td  class="formcontent" style="display:none;">
                                                    <asp:updatepanel ID="upnllblAckrcv" runat="server"  style="display:none;">
                                                         <ContentTemplate>
                                                             <asp:Label ID="lblAckrcv" runat="server"  style="display:none;" Visible="false"/>
                                                         </ContentTemplate>
                                                         <Triggers><asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" /></Triggers>
                                                     </asp:updatepanel>
                                                </td>
                                                <td  style="display:none;" class="formcontent">
                                                    <asp:updatepanel ID="upnlRbAckRev" runat="server"  style="display:none;">
                                                       <ContentTemplate>
                                                            <asp:RadioButtonList ID="RbAckRev" runat="server" CssClass="radiobtn"  style="display:none;"  RepeatDirection="Horizontal" 
                                                               Visible="false" TabIndex="25">
                                                                <asp:ListItem Value="Y" >Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </ContentTemplate>
                                                        <Triggers><asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" /></Triggers>
                                                    </asp:updatepanel>
                                               </td>
                                                   <td class="formcontent" style="display:none;">
                                <asp:TextBox ID="txtissudate" runat="server" CssClass="standardtextbox"  style="display:none;" TabIndex="22" BackColor="#FFFFB2" />
                                <asp:Image ID="btnissu" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp"  style="display:none;" />
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtissudate"
                                    PopupButtonID="btnissu" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true"
                                    ControlToValidate="txtissudate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:CompareValidator ID="COMPAREVALIDATOR5" runat="server" ErrorMessage="Invalid date!"
                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtissudate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtissudate"
                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                            </td>

                           
                                                <td  class="formcontent" style="display:none;"></td>
                                                <td  class="formcontent" style="display:none;"></td>
                                                
                                           </tr>
                                            <%-- added by amruta on 11.6.15--%>
                                              <div class="row"  id="trTrnsfr1" runat="server">
                                         <div class="col-sm-3" style="text-align:left">
                                           
                                           <asp:Label ID="lblCatTrnsfr"  CssClass="control-label labelSize " Text="Category" runat="server"></asp:Label>
                                            <span style="color: red">*</span>
                                        </div>
                                             <div class="col-sm-3">
                                         <%--   <asp:UpdatePanel ID="UpdatePanel119" runat="server">
                                                        <contenttemplate>--%>
                                                            <asp:DropDownList id="ddlCaTrnsfr" runat="server" CssClass="form-control" TabIndex="12"  AutoPostBack="true"   OnSelectedIndexChanged="ddlCaTrns_OnSelectedIndexChanged">
                                                                  <asp:ListItem Value="" Text="select"></asp:ListItem>
                                                              
                                                                </asp:DropDownList>  <%--</contenttemplate> 
                                                           
                                                               
                                                      
                                                    </asp:UpdatePanel> --%>
                                        </div>
                                               <div class="col-sm-3">
                                               </div>
                                                   <div class="col-sm-3">
                                                   </div>
                                         </div>
                                          <div class="row"  id="trTrnsfr2" runat="server">
                                         <div class="col-sm-3" style="text-align:left">
                                               
                                           <asp:Label ID="lblInsurerTrnsfr"  CssClass="control-label labelSize " Text="Name of Insurer" runat="server"></asp:Label>
                                             <span style="color: red">*</span>
                                          </div>
                                           <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel137">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNameInTrnsfr" runat="server"  CssClass="form-control"   
   
                                                        TabIndex="6">
                                                       <%-- <asp:ListItem Text="Select" Value=""> </asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                  <%-- <Triggers>
                                                                 <asp:AsyncPostbackTrigger ControlID="ddlCaTrnsfr" EventName="SelectedIndexChanged" />
                                                              </Triggers>--%>
                                            </asp:UpdatePanel>
                                      </div>
                                         <div class="col-sm-3" style="text-align:left">
                                           
                                           <asp:Label ID="lblAgencyCodeTrnsfr"  CssClass="control-label labelSize " Text="Agency code number" runat="server"></asp:Label>
                                           <span style="color: red">*</span>
                                        </div>
                                     <div class="col-sm-3">
                                           <asp:TextBox ID="txtAgencyCodeTrnsfr" runat="server" CssClass="form-control" 
                                            onChange="javascript:this.value=this.value.toUpperCase();"  MaxLength="60" TabIndex="9"></asp:TextBox>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender80" runat="server"
                                                        InvalidChars="a^z1234567890 " ValidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~" FilterMode="InvalidChars"
                                                        TargetControlID="txtAgencyCodeTrnsfr" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                               </div>
                                       </div>
                                        <div class="row"  id="trTrnsfr3" runat="server">
                                          <div class="col-sm-3" style="text-align:left">
                                          
                                           <asp:Label ID="lblDateOfAppointmentTrnsfr"  CssClass="control-label labelSize " Text="Date of appointment as agent" runat="server"></asp:Label>
                                            <span style="color: red">*</span>
                                        </div>
                                            <div class="col-sm-3">
                                         <%--  <asp:TextBox ID="txtDateOfAppointmentTrnsfr" runat="server" CssClass="form-control"
                                            TabIndex="10"></asp:TextBox>--%>

                                                 <asp:TextBox CssClass="form-control" 
                     runat="server" ID="txtDateOfAppointmentTrnsfr" MaxLength="15"
                            TabIndex="10" /> 



                                            <%--<asp:Image ID="btnCalendarTr" runat="server" 
                                                  ImageUrl="~/App_UserControl/Common/calendar.bmp" Height="16px" />
                                                    
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender26" runat="server" TargetControlID="txtDateOfAppointmentTrnsfr"
                                                            PopupButtonID="btnCalendarTr" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>--%>
                                        </div>
                                            <div class="col-sm-3">
                                         </div>
                                            <div class="col-sm-3">
                                         </div>
                                       </div>
                                        <div class="row"  id="trTrnsfr4" runat="server">
                                         <div class="col-sm-3" style="text-align:left">
                                            
                                           <asp:Label ID="lblStsTrnsfr"  Text="Status" CssClass="control-label labelSize " runat="server"></asp:Label>
                                           <span style="color: red">*</span>
                                          </div>
                                         <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="ddlStsTrnsfr" runat="server" CssClass="form-control" TabIndex="11" >
                                                                  <asp:ListItem Value="0" Text="select"></asp:ListItem>
                                                        <%--         <asp:ListItem Value="1" Text="Inforce"></asp:ListItem>--%>
                                                                  <asp:ListItem Value="2" Text="Cessation"></asp:ListItem>
                                                                </asp:DropDownList>
                                                              
                                                               
                                                        </contenttemplate> 
                                                    </asp:UpdatePanel> 
                                           </div>
                                        <div class="col-sm-3">
                                        </div>
                                        <div class="col-sm-3">
                                     </div>
                                         </div>
                                             <div class="row"  id="trTrnsfr5" runat="server">
                                          <div class="col-sm-3" style="text-align:left">

                                           
                                           <asp:Label ID="lblDateOfCessationTrnsfr"  CssClass="control-label labelSize " Text="Date of cessation of agency" runat="server"></asp:Label>
                                         </div>
                                         <div class="col-sm-3">
                                          <%-- <asp:TextBox ID="txtDateOfCessationTrnsfr" runat="server" CssClass="form-control"
                                            TabIndex="12"></asp:TextBox>--%>

                                              <asp:TextBox CssClass="form-control" 
                     runat="server" ID="txtDateOfCessationTrnsfr" MaxLength="15"
                            TabIndex="12" /> 


                                           <%-- <asp:Image ID="btnCalendartr2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender27" runat="server" TargetControlID="txtDateOfCessationTrnsfr"
                                                            PopupButtonID="btnCalendartr2" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>--%>
                                          </div>
                                           <div class="col-sm-3" style="text-align:left">
                                           <asp:Label ID="lblReasonForCessationTrnsfr"  CssClass="control-label labelSize " Text="Reason for cessation of agency" runat="server"></asp:Label>
                                         </div>
                                         <div class="col-sm-3">
                                           <asp:TextBox ID="txtReasonForCessationTrnsfr" runat="server" CssClass="form-control" 
                                                    TabIndex="13" onchange="javascript:this.value=this.value.toUpperCase();" ></asp:TextBox>
                                        </div>
                                           </div>

                 <div class="row" style="text-align:center">
                                         <asp:LinkButton ID="btnAddTrnsfr" runat="server" CssClass="btn btn-sample" 
                                      onclick="btnAddTrnsfr_Click" OnClientClick="return funIc();"
                                          TabIndex="59">
                               <span class="glyphicon glyphicon-plus BtnGlyphicon"> </span> Add
                                       </asp:LinkButton>
                                        </div>
                                     <%--   <div class="row" >
                                         <div class="col-md-12" style="text-align:center">
                                               <asp:Button ID="btnAddTrnsfr" runat="server" Text="Add" onclick="btnAddTrnsfr_Click" OnClientClick="return funIc();" 
                                                />
                                         </div>
                                     </div>--%>
                                   <div class="row" >
                              <%--         <asp:GridView ID="gvTrnsfr" OnRowDeleting="gvTrnsfr_RowDeleting" 
                                               AutoGenerateColumns="false" AutoGenerateDeleteButton="false" runat="server"
                                        BackColor="White" style="width: 100%;"
                                               BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                                

                                           <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                           <HeaderStyle BackColor="#003399"  ForeColor="#CCCCFF" />
                                           <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                           <RowStyle BackColor="White" ForeColor="#003399" />
                                           <SelectedRowStyle BackColor="#009999"  ForeColor="#CCFF99" />
                                           <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                           <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                           <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                           <SortedDescendingHeaderStyle BackColor="#002876" />--%>
                                           <asp:GridView  AllowSorting="True" ID="gvTrnsfr" runat="server" CssClass="footable"
                                      OnRowDeleting="gvTrnsfr_RowDeleting"   AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1" >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewAlternateRow" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>

                                        <Columns>
                                        <asp:TemplateField HeaderText="I-C Date">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                             </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Category">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                             </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Name of Insurer">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label>
                                             </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Agency code number">
                                             <ItemTemplate>
                                            <asp:Label ID="lblAgencyCode" runat="server"  Text='<%# Bind("Agency_code_Number") %>'></asp:Label>
                                             </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date of appointment as agent">
                                            <ItemTemplate>
                                            <asp:Label ID="lblDateAppointment" runat="server"  Text='<%# Bind("Date_of_appointment_as_Agent") %>'></asp:Label>
                                             </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date of cessation of agency">
                                             <ItemTemplate>
                                            <asp:Label ID="lblDateCessation" runat="server"  Text='<%# Bind("Date_of_cessation_of_Agency") %>'></asp:Label>
                                             </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Reason for cessation of agency">
                                              <ItemTemplate>
                                            <asp:Label ID="lblReasonCessation" runat="server"  Text='<%# Bind("Reason_for_cessation_of_Agency") %>'></asp:Label>
                                             </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                            </asp:TemplateField>
                                             <%-- <asp:CommandField ShowDeleteButton="true"  DeleteText="Delete" />--%>
                                            <asp:TemplateField>               
                                             <ItemTemplate>
                                                 <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("Agency_code_Number") %>'
                                                CommandName="delete"></asp:LinkButton>
                                               <%-- <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<% #Eval("Agency_code_Number")%>'  CommandName="delete" />--%>
                                             </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                            </asp:TemplateField>



                                           </Columns>
                                           
                                           </asp:GridView>
                                     </div>
                                           </div>
           <%-- </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>--%>
        </div>
                         
                        <%-- </contenttemplate>
</asp:updatepanel>--%>


        </div>
        <%--added by pranjali on 13-03-2014 for transfr deatils end--%>
        <%--added by pranjali on 13-03-2014 for composite deatils start--%>
                 <%--tag agent statrt--%>
                          <div class="row">
                                    <div id="divTagged" runat="server" visible="false" class="panel" style="margin-left: 14px; margin-right: 17px;">
                                     <div id="divTagDtls" runat="server" class="panel-heading subHeader"  
                                     onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTag','btnTag');return false;">  
                                        <div class="row">
                                         <div class="col-sm-10" style="text-align:left">
                    <%--  <span style="font-size:19px"></span> Tagged Details--%>
                                              <asp:Label ID="Label23" runat="server" CssClass="control-label labelSize " text="Tagged Details" Font-Size="19px"></asp:Label>
                     
                    
                 
                    </div>
                                         <div class="col-sm-2">
                        <span id="btnTag"  class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                                               
                                        </div>
                                    </div>
                                    <div id="divTag" style="display:block;" runat="server" class="panel-body">
                                   
                                    <div id="divCatIns"  runat="server" class="row">
                                    <div class="col-sm-3" style="text-align:left">
                                    <span style="color: red"  >
                                           <asp:Label ID="lblTagCat"  CssClass="control-label labelSize " Text="Category" runat="server"></asp:Label>
                                           *</span>
                                    </div>
                                    <div class="col-sm-3">
                                      <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="ddlTagCat" runat="server" CssClass="form-control" 
                                                          OnSelectedIndexChanged="ddlTagcat_SelectedIndexChanged" AutoPostBack="True"    TabIndex="52" >
                                                                  <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                              
                                                                </asp:DropDownList>
                                                              
                                                               
                                                        </contenttemplate> 
                                                    </asp:UpdatePanel> 
                                    </div>
                                     <div class="col-sm-3"  style="text-align:left">
                                        <span style="color: red">
                                           <asp:Label ID="lblTagIns"  CssClass="control-label labelSize " Text="Name of Insurer" runat="server"></asp:Label>
                                           *</span>
                                       </div>
                                       <div class="col-sm-3">
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel31">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTagIns" runat="server" CssClass="form-control"
                                                        TabIndex="53">
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                       </div>
                                     </div>
                                       <div  id="divAgnURN" runat="server" class="row">
                                      
                                       <div class="col-sm-3"  style="text-align:left">
                                        <span style="color: red">
                                           <asp:Label ID="lblTagAgn"  CssClass="control-label labelSize " Text="Agency code number" runat="server"></asp:Label>
                                           *</span>
                                           
                                         
                                       </div>
                                       <div class="col-sm-3">
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel32">
                                                <ContentTemplate>
                                         <asp:TextBox ID="txtTagAgn" runat="server" CssClass="form-control" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                            onChange="javascript:this.value=this.value.toUpperCase();"  MaxLength="20" TabIndex="55"></asp:TextBox>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender83" runat="server"
                                                        TargetControlID="txtTagAgn" FilterType="Numbers, UppercaseLetters, LowercaseLetters"></ajaxToolkit:FilteredTextBoxExtender>
                                             </ContentTemplate>
                                            </asp:UpdatePanel>
                                       </div>
                                        <div class="col-sm-3"  style="text-align:left">
                                        <span style="color: red">
                                           <asp:Label ID="lblTagURN"  CssClass="control-label labelSize " Text="URN No." runat="server"></asp:Label>
                                           *</span>
                                           
                                         
                                       </div>
                                       <div class="col-sm-3" >
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel36">
                                                <ContentTemplate>
                                         <asp:TextBox ID="txtTagURN" runat="server" CssClass="form-control" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                            onChange="javascript:this.value=this.value.toUpperCase();"  MaxLength="20" TabIndex="56"></asp:TextBox>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender84" runat="server"
                                                        TargetControlID="txtTagURN" FilterType="Numbers, UppercaseLetters, LowercaseLetters"></ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                       </div>
                                       </div>
                                        <div  id="divAppStatus" runat="server" class="row">
                                        <div class="col-sm-3"  style="text-align:left">
                                         <span style="color: red">
                                           <asp:Label ID="lblTagApp"  CssClass="control-label labelSize " Text="Date of appointment as agent" runat="server"></asp:Label>
                                           *</span>
                                         
                                           
                                        </div>
                                        <div class="col-sm-3">
                                     <%--   <asp:TextBox ID="txtTagApp" runat="server" CssClass="form-control" 
                                           TabIndex="57"></asp:TextBox>--%>

                                              <asp:TextBox CssClass="form-control" 
                     runat="server" ID="txtTagApp" MaxLength="15"
                            TabIndex="57" /> 
                                           <%-- <asp:Image ID="Image3" runat="server" 
                                              Visible="false"    ImageUrl="~/App_UserControl/Common/calendar.bmp" Height="16px" />--%>
                                                    
                                                  
                                        </div>
                                          <div class="col-sm-3"  style="text-align:left">
                                        <span style="color: red">
                                           <asp:Label ID="lblTagStatus"  CssClass="control-label labelSize " Text="Status" runat="server"></asp:Label>
                                           *</span>
                                        </div>
                                        <div class="col-sm-3">
                                         <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="ddlTagStatus" runat="server" CssClass="form-control" 
                                                             TabIndex="58" >
                                                               
                                                                 <asp:ListItem Value="A" Text="Active" Selected="True"></asp:ListItem>
                                                                  <asp:ListItem Value="I" Text="In Active"></asp:ListItem>
                                                                </asp:DropDownList>
                                                              
                                                               
                                                        </contenttemplate> 
                                                    </asp:UpdatePanel> 
                                        </div>
                                       </div>
                                     
                                   
                                           <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                                        <ContentTemplate>
                                        <div class="row" style="text-align:center">
                                         <asp:LinkButton ID="lnkAddTag" runat="server" CssClass="btn btn-sample" 
                                       onclick="btnAddTag_Click" 
                                          TabIndex="59">
                               <span class="glyphicon glyphicon-plus BtnGlyphicon"> </span> Add
                                       </asp:LinkButton>
                                        </div>
                                        <div class="row">
                                        <br/>
                                         <div class="col-sm-12" style="overflow-x: scroll;">
                                        
                      
                                            <asp:GridView ID="grdTag" OnRowDeleting="grdTag_RowDeleting" CssClass="footable"
                                                TabIndex="60"  AutoGenerateColumns="false" AutoGenerateDeleteButton="false" runat="server">
                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                                               
                                                <Columns>
                                                   
                                                    <asp:TemplateField HeaderText="Category">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name_of_insurer">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Agency_code_number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAgencyCode" runat="server" Text='<%# Bind("Agency_code_Number") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="URN No.">
                                                     <ItemTemplate>
                                                            <asp:Label ID="lblURNNo" runat="server" Text='<%# Bind("URNNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                    </asp:TemplateField>
                                                 
                                                    <asp:TemplateField HeaderText="Date_of_appointment_as_agent">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDateAppointment" runat="server" Text='<%# Bind("Date_of_appointment_as_agent") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                             <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("Agency_code_Number") %>'
                                                CommandName="delete"></asp:LinkButton>
                                                            <%--<asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<% #Eval("Agency_code_Number")%>'
                                                                CommandName="delete" />--%></ItemTemplate>
                                                       
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <br/>
                                             <div id="divCatFlag"  runat="server" visible="false"  class="row">
                                           <div class="col-sm-3">
                                               <span style="color: red">
                                                   <asp:Label ID="lblCatFlag"  CssClass="control-label labelSize " Text="Which type of Category do you want to consider for URN No.?"
                                                       runat="server"></asp:Label>
                                                   *</span>
                                           </div>
                                           <div class="col-sm-3">
                                               <asp:DropDownList ID="ddlCatFlag" runat="server" CssClass="form-control" TabIndex="61">
                                               </asp:DropDownList>
                                           </div>
                                            </div>
                                        </div>
                                        </div>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                       
                                         
                                          <input id="hdnTag" type="hidden" runat="server"/> 
                                          
                                    </div> 
                                    </div>
                                    </div>




          <div class="row">
          <div class="panel" id="CompositeTitle" runat="server" visible="false" style="margin-left: 14px; margin-right: 17px;display:none">
             <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCompositeDetails','btnComp');return false;"
            >           
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                          <div class="row" id="chkcom" runat="server">
                           
                    <div class="col-sm-10" style="text-align:left">
                       <asp:Label ID="lblCompositeDtl" Text="Composite Details" runat="server"  Font-Size="19px"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                         <%--   <asp:Label ID="lblCompLcn" runat="server"  Text="Composite Case"></asp:Label>&nbsp--%>
                         <%--   <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox" Enabled="true"
                                AutoPostBack="true" TabIndex="20" OnCheckedChanged="cbTccCompLcn_CheckedChanged" />--%>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnComp" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                   
                </div>
                  </ContentTemplate>
                    </asp:UpdatePanel>
                        </div>
        
                <asp:UpdatePanel ID="Updcompdtls" runat="server">
            <ContentTemplate>
             <div id="divCompositeDetails" runat="server" class="card PanelInsideTab_body" visible="false" style="display:none;">
             <div id="tblcomp" runat="server" >
             <div class="row"  id="tr5" runat="server">
                        <div class="col-md-6" style="text-align:left">
                                          <asp:Label ID="lblHasAgent" CssClass="control-label labelSize " Text="Has the agent taken an acknowledgement on form I-B from the life Insurance Company  (Y/N)" runat="server"></asp:Label>
                          </div>
                          <div class="col-md-6">
                                         <asp:RadioButtonList ID="radioComposite"  AutoPostBack="true" runat="server" 
                                                 RepeatDirection="Horizontal" 
                                                 onselectedindexchanged="radioComposite_SelectedIndexChanged" Enabled="True">
                                                 <asp:ListItem Value="0" Text="Yes"></asp:ListItem>
                                                 <asp:ListItem Value="1" Text="No"></asp:ListItem>
                                                 </asp:RadioButtonList>
                        </div>
               </div>
			                               <tr id="tr2" style="display:none" runat="server"  >
			                                    <td align="left" class="formcontent" style="width:20%;">
                                                 <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lblCompLicNo" runat="server"  Text="Life License No"></asp:Label>*</span>
                                                </td><%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                                                <td class="formcontent" style="width: 30%;">
                                                <asp:UpdatePanel ID="updlcnver2" runat="server">
                                                        <ContentTemplate>
                                                    <asp:TextBox id="txtCompLicNo"  runat="server" CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="21" OnTextChanged="txtCompLicNo_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                                   <br /> <asp:Label ID="lbllcnerr" Font-Size="X-Small" Visible="false" ForeColor="Green" runat="server"/>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                                          FilterMode="InvalidChars" TargetControlID="txtCompLicNo" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="formcontent" style="width:20%;">
                                                 <span style="color: red">
                                                    <asp:Label ID="lblComplicnseExpDt" runat="server" ></asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                   <asp:TextBox  ID="txtCompLicExpDt" runat="server" CssClass="standardtextbox"  BackColor="#FFFFB2"  TabIndex="22"/>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" /> 
                                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="standardtextbox"  style="display: none" ></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCompLicExpDt" PopupButtonID="Image1" Format="dd/MM/yyyy"/>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"  ControlToValidate="txtCompLicExpDt"  Enabled="false"
                                                    ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator id="COMPAREVALIDATOR2" runat="server" errormessage="Invalid date!" operator="DataTypeCheck" type="Date" 
                                                    controltovalidate="txtCompLicExpDt" Display="Dynamic" ></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCompLicExpDt" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                                   <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                                                </td>
			                               </tr>
			                               <tr id="tr3" style="display:none" runat="server" >
			                                    <td align="left" class="formcontent" style="width:20%;">
                                                 <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lblCompInsurerName" runat="server"  Text="Insurer Name" ></asp:Label>*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <%--<asp:TextBox id="txtCompInsurerName" runat="server" 
                                                        CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="23" ></asp:TextBox>--%>
                                                        <asp:DropDownList id="ddlCompInsurerName" runat="server" CssClass="standardmenu"  BackColor="#FFFFB2" 
                                                       Width="270px" TabIndex="65"></asp:DropDownList>
                                                   <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtCompInsurerName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                                </td>  
                                                <td align="left" class="formcontent" style="width:20%;">
                                                
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                
                                                </td>
                                           
			                               </tr>
                                           <%--composite addition added by amruta--%>
                                           <div class="row"  id="Tr1"  runat="server">
                                         <div class="col-sm-3" style="text-align:left">
                                           
                                           <asp:Label ID="lblCatComp"  CssClass="control-label labelSize " Text="Category" runat="server"></asp:Label>
                                            <span style="color: red">*</span>
                                          </div>
                                             <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel151" runat="server">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="ddlCatComp" runat="server" CssClass="form-control" TabIndex="12" >
                                                                  <asp:ListItem Value="" Text="select"></asp:ListItem>
                                                                <%-- <asp:ListItem Value="Life" Text="Life"></asp:ListItem>
                                                                  <asp:ListItem Value="Health" Text="Health"></asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                              
                                                               
                                                        </contenttemplate> 
                                                    </asp:UpdatePanel> 
                                     </div>
                                             
                                          
                                           </div>
                                            <div class="row"  id="trInsurer"  runat="server">
                                       <div class="col-sm-3" style="text-align:left">
                                              
                                           <asp:Label ID="lblInsurer"  Text="Name of Insurer" CssClass="control-label labelSize " runat="server"></asp:Label>
                                              <span style="color: red">*</span>
                                        </div>
                                           <%--added by amruta--%>
                                          <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="updNameIns">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNameIns" runat="server" CssClass="form-control"
                                                        TabIndex="6">
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      </div>
                                      <div class="col-sm-3" style="text-align:left">
                                       
                                           <asp:Label ID="lblAgencyCode"  Text="Agency code number" CssClass="control-label labelSize " runat="server"></asp:Label>
                                               <span style="color: red">*</span>
                                        </div>
                                      <div class="col-sm-3">
                                           <asp:TextBox ID="txtAgencyCode" runat="server" CssClass="form-control"
                                            onChange="javascript:this.value=this.value.toUpperCase();"  MaxLength="60" TabIndex="9"></asp:TextBox>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender81" runat="server"
                                                        InvalidChars="a^z1234567890 " ValidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~" FilterMode="InvalidChars"
                                                        TargetControlID="txtAgencyCode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                          </div>
                                       </div>
                                         <div class="row"  id="trAppointment"  runat="server">
                                       <div class="col-sm-3" style="text-align:left">

                                           
                                           <asp:Label ID="lblDateOfAppointment"  CssClass="control-label labelSize " Text="Date of appointment as agent" runat="server"></asp:Label>
                                           <span style="color: red">*</span>
                                         </div>
                                      <div class="col-sm-3">
                                           <asp:TextBox ID="txtDateOfAppointment" runat="server" CssClass="form-control" 
                                            TabIndex="10"></asp:TextBox>
                                            <asp:Image ID="btnCalendar1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                    <%--<asp:TextBox ID="txtDtValidate1" runat="server" CssClass="standardtextbox" Style="display: none"
                                                            Width="80px"></asp:TextBox>--%>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender24" runat="server" TargetControlID="txtDateOfAppointment"
                                                            PopupButtonID="btnCalendar1" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" SetFocusOnError="true" ControlToValidate="txtDateOfAppointment"
                                                            Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="CompareValidator25" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                                            Type="Date" ControlToValidate="txtDateOfAppointment" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator24" runat="server" ControlToValidate="txtDateOfAppointment" Display="Dynamic"
                                                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                            Type="Date"></asp:RangeValidator>  --%>
                                         </div>
                                           <div class="col-sm-3">
                                         </div>
                                            <div class="col-sm-3">
                                         </div>
                                     </div>
                                                 <div class="row"  id="trSts"  runat="server">
                                         <div class="col-sm-3" style="text-align:left">

                                           
                                           <asp:Label ID="lblSts"  Text="Status" CssClass="control-label labelSize " runat="server"></asp:Label>
                                            <span style="color: red">*</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel116" runat="server">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="ddlSts" runat="server" CssClass="form-control" TabIndex="11" >
                                                                  <asp:ListItem Value="0" Text="select"></asp:ListItem>
                                                                 <asp:ListItem Value="1" Text="Inforce"></asp:ListItem>
                                                                  <asp:ListItem Value="2" Text="Cessation"></asp:ListItem>
                                                                </asp:DropDownList>
                                                              
                                                               
                                                        </contenttemplate> 
                                                    </asp:UpdatePanel> 
                                         </div>
                                          <div class="col-sm-3">
                                          </div>
                                             <div class="col-sm-3">
                                             </div>
                                         </div>
                                              <div class="row"  id="trCessation"  runat="server">
                                          <div class="col-sm-3" style="text-align:left">
                                           <asp:Label ID="lblDateOfCessation"  CssClass="control-label labelSize " Text="Date of cessation of agency" runat="server"></asp:Label>
                                          </div>
                                            <div class="col-sm-3">
                                           <asp:TextBox ID="txtDateOfCessation" runat="server" CssClass="form-control" 
                                            TabIndex="12"></asp:TextBox>
                                            <asp:Image ID="btnCalendar2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                  <%--  <asp:TextBox ID="txtDtValidate2" runat="server" CssClass="standardtextbox" Style="display: none"
                                                            Width="80px"></asp:TextBox>--%>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender25" runat="server" TargetControlID="txtDateOfCessation"
                                                            PopupButtonID="btnCalendar2" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                 <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" SetFocusOnError="true" ControlToValidate="txtDateOfCessation"
                                                            Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="CompareValidator26" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                                            Type="Date" ControlToValidate="txtDateOfCessation" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator25" runat="server" ControlToValidate="txtDateOfCessation" Display="Dynamic"
                                                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                            Type="Date"></asp:RangeValidator>--%>  
                                          </div>
                                           <div class="col-sm-3" style="text-align:left">

                                           <asp:Label ID="lblReasonForCessation"  CssClass="control-label labelSize " Text="Reason for cessation of agency" runat="server"></asp:Label>
                                          </div>
                                     <div class="col-sm-3">
                                           <asp:TextBox ID="txtReasonForCessation" runat="server" CssClass="form-control"
                                                    TabIndex="13"></asp:TextBox>
                                       </div>
                                         </div>
                                    <div class="row" >
                                         <div class="col-md-12" style="text-align:center">
                                               <asp:Button ID="btnAddComposite" runat="server" Text="Add" 
                                                onclick="btnAddComposite_Click" />
                                       </div>
                                    </div>
                                     <div class="row" >

                                   <%--    <asp:GridView ID="gvComposite" OnRowDeleting="gvComposite_RowDeleting" AutoGenerateColumns="false" AutoGenerateDeleteButton="false" runat="server"
                                        BackColor="White" style="width: 90%"
                                               BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >

                                           <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                           <HeaderStyle BackColor="#003399"   ForeColor="#CCCCFF" />
                                           <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                           <RowStyle BackColor="White" ForeColor="#003399" />
                                           <SelectedRowStyle BackColor="#009999"  ForeColor="#CCFF99" />
                                           <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                           <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                           <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                           <SortedDescendingHeaderStyle BackColor="#002876" />--%>
                                           <asp:GridView  AllowSorting="True" ID="gvComposite" runat="server" CssClass="footable"
                                      OnRowDeleting="gvComposite_RowDeleting"   AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1" >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>

                                        <Columns>
                                          <asp:TemplateField HeaderText="Category">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                             </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Name_of_Insurer">               
                                             <ItemTemplate>
                                            <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label>
                                             </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField  HeaderText="Agency_code_Number">
                                             <ItemTemplate>
                                            <asp:Label ID="lblAgencyCode" runat="server"  Text='<%# Bind("Agency_code_Number") %>'></asp:Label>
                                             </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date_of_appointment">
                                           
                                            <ItemTemplate>
                                            <asp:Label ID="lblDateAppointment" runat="server"  Text='<%# Bind("Date_of_appointment_as_agent") %>'></asp:Label>
                                             </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date_of_cessation">
                                             <ItemTemplate>
                                            <asp:Label ID="lblDateCessation" runat="server"  Text='<%# Bind("Date_of_cessation_of_agency") %>'></asp:Label>
                                             </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Reason_for_cessation">
                                              <ItemTemplate>
                                            <asp:Label ID="lblReasonCessation" runat="server"  Text='<%# Bind("Reason_for_cessation_of_agency") %>'></asp:Label>
                                             </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                            </asp:TemplateField>
                                             <%-- <asp:CommandField ShowDeleteButton="true"  DeleteText="Delete" />--%>
                                            <asp:TemplateField>               
                                             <ItemTemplate>
                                                  <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("Agency_code_Number") %>'
                                                CommandName="delete"></asp:LinkButton>
                                                <%--<asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<% #Eval("Agency_code_Number")%>'  CommandName="delete" />--%>
                                             </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                            </asp:TemplateField>



                                           </Columns>
                                           
                                           </asp:GridView>
                                    </div>
                                       </div>
                                       </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cbTccCompLcn" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
         
        <table id="trIsPriorAgt" class="tableIsys" runat="server" style="height: 5%;
            width: 90%; display:none">
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
        <div class="panel" id="tblCndURN" runat="server" visible="false" style="display:none" >
            <div class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCndTrnsDtls','BtnCndTrnsDtls');return false;"
            >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lbltitleURN" runat="server" CssClass="control-label labelSize " Text="Candidate URN No." Font-Size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="BtnCndTrnsDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
                      <div id="divCndTrnsDtls" runat="server" class="panel-body" style="display:none">
                      <div id="tblCndURNDtl" runat="server" style="display:block" >
                   <div class="row" >
                   <div class="col-sm-3" style="text-align:left" id="tdCndURNNo" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                <ContentTemplate>
                                   <%-- <span style="color: red">
                                        <asp:Label ID="lblcndURNNo" Text="Candidate URN No." runat="server" CssClass="control-label labelSize " ></asp:Label>*</span> --%> <%--commented by sanoj 04092022 --%>                          </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                     </div>
                    <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel171" runat="server">
                                <ContentTemplate>
                                   <%-- <asp:TextBox ID="txtCndURNNo" runat="server" CssClass="form-control"></asp:TextBox> --%><%--comented by sanoj 04092022--%>
                                    <asp:Label ID="lblcndURNVal" runat="server" CssClass="control-label labelSize " style="color:Black" visible="false"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                      </div>
                   <div class="col-sm-3" style="text-align:left">

                        <asp:Label ID="lblTrnsfrReqNo" Text="IRDA Transfer Request No." Visible="false" runat="server" CssClass="control-label labelSize " ></asp:Label>
                    </div>
                   <div class="col-sm-3">
                        <asp:TextBox ID="TxtTrnsfrReqNo" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                    </div>
                 </div>
             </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <%-- added by shreela on 18-04-2014 for Renewal Details start--%>
         <div class="panel" id="tblRenewalCollapse" runat="server" visible="false">
         <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divRenewal','btnRenew');return false;"
      >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblRenew" runat="server" Text="Renewal Details" CssClass="control-label labelSize " font-size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnRenew" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
        <asp:UpdatePanel ID="updrenewal" runat="server">
            <ContentTemplate>
                     <div id="divRenewal" runat="server" class="panel-body" visible="false" style="display:none">
                     <div id="tblRenewal" runat="server">
                     <div class="row" >
                         <div class="col-sm-3" style="text-align:left">
                                <asp:Label ID="lblCndType" runat="server" CssClass="control-label labelSize " ></asp:Label>
                          </div>
                           <div class="col-sm-3" id="Td1" runat="server">
                                <asp:Label ID="lblCndVal" CssClass="control-label labelSize " runat="server"></asp:Label>
                         </div>
                         <div class="col-sm-3" id="Td2" runat="server" style="text-align:left">
                                <asp:Label ID="lblCount" runat="server" CssClass="control-label labelSize " ></asp:Label>
                         </div>
                         <div class="col-sm-3" id="Td3" runat="server" style="text-align:left">
                                <asp:Label ID="lblCountVal" CssClass="control-label labelSize " runat="server"></asp:Label>
                         </div>
                      </div>
                      <div class="row"  id="Comp" runat="server">
                      <div class="col-sm-3" id="Td4" runat="server" style="text-align:left">
                               
                                    <asp:Label ID="lblRenewType" runat="server" CssClass="control-label labelSize " ></asp:Label>
                                     <span style="color: Red">*</span>
                      </div>
                       <div class="col-sm-3" id="Td5" runat="server">
                                <asp:DropDownList ID="ddlRenewType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRenewType_SelectedIndexChanged">
                                </asp:DropDownList>
                         </div>
                         <div class="col-sm-3" id="Td6" runat="server" style="text-align:left">
                               
                                    <asp:Label ID="lbllyfTraining" runat="server" CssClass="control-label labelSize " ></asp:Label>
                                     <span style="color: Red">*</span>
                         </div>
                         <div class="col-sm-3" id="Td7" runat="server" style="text-align:left">
                                <asp:DropDownList ID="ddllyfTraining" runat="server" CssClass="form-control" Enabled="false">
                                </asp:DropDownList>
                          </div>
                      </div>
                        <%--Added by kalyani to fetch Renewal record on QC module start--%>
                         <div class="row"  id="trCompQC" runat="server">
                         <div class="col-sm-3" id="Td8" runat="server"  style="text-align:left">
                         <asp:Label ID="lblQCRenewType" runat="server" ></asp:Label>
                                     <span style="color: Red"></span>
                         </div>
                          <div class="col-sm-3" id="Td9" runat="server">
                                <asp:Label ID="lbltxtQCRenewType" runat="server" CssClass="control-label labelSize " ></asp:Label>
                       </div>
                       <div class="col-sm-3" id="Td10" runat="server" style="text-align:left">
                               
                                    <asp:Label ID="lblQClyfTraining" CssClass="control-label labelSize " runat="server" ></asp:Label>
                                        <span style="color: Red"></span>
                        </div>
                          <div class="col-sm-3" id="Td11" runat="server">
                                <asp:Label ID="lbltxtQClyfTraining" runat="server" CssClass="control-label labelSize " ></asp:Label>
                          </div>
                     </div>
                        <%--Added by kalyani to fetch Renewal record on QC module end--%>
                   </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <%-- added by shreela on 18-04-2014 for Renewal Details end--%>
	<%--added by pranjali on 05-01-2015 start for repeater case--%>
     <div class="panel" id="TblRptrTitle" runat="server" visible="false">
     <div  class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divRptr','btnRptr');return false;" >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="TblRptrDtls" runat="server" Text="Repeater Details" CssClass="control-label labelSize " font-size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnRptr" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
            <ContentTemplate>
             <div id="divRptr" runat="server" class="panel-body" style="display:none">
             <div id="tblRptr" runat="server">
              <div class="row" >
                         <div class="col-sm-3" style="text-align:left">
                                <asp:Label ID="lblRptrCndTyp" Text="Candidate Type" runat="server" CssClass="control-label labelSize " ></asp:Label>
                         </div>
                         <div class="col-sm-3" id="Td12" runat="server" style="text-align:left">
                                <asp:Label ID="lblRptrCndTypVal" CssClass="control-label labelSize " runat="server"></asp:Label>
                         </div>
                         <div class="col-sm-3" style="text-align:left">

                                <asp:Label ID="lblRptrCount" Text="ReExam Count" runat="server" CssClass="control-label labelSize " ></asp:Label>
                         </div>
                          <div class="col-sm-3" id="Td15" runat="server" style="text-align:left">
                                <asp:Label ID="lblRptrCountVal" CssClass="control-label labelSize " runat="server"></asp:Label>
                          </div>
                  </div>
                     <div class="row" id="tr4" runat="server" >
                     <div class="col-sm-3" id="Td22" runat="server" style="text-align:left">
                               
                                    <asp:Label ID="lblRptrTyp" Text="ReExam Type" CssClass="control-label labelSize " runat="server" ></asp:Label>
                                     <span style="color: Red"></span>
                       </div>
                         <div class="col-sm-3" id="Td23" runat="server" style="text-align:left">
                                <asp:Label ID="lblRptrTypVal" runat="server" CssClass="control-label labelSize " ></asp:Label>
                          </div>
                          <div class="col-sm-3" id="Td24" runat="server" style="text-align:left">
                             
                                    <asp:Label ID="Label17" runat="server" ></asp:Label>
                                       <span style="color: Red"></span>
                       </div>
                        <div class="col-sm-3" d="Td25" runat="server" style="text-align:left">
                                <asp:Label ID="Label18" runat="server" CssClass="control-label labelSize " ></asp:Label>
                        </div>
                     </div>
              </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
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
                    <asp:Label ID="lbloldlic" runat="server" Text="Old License Details" ></asp:Label>
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
                    <td class="formcontent" style="width: 20%">
                    </td>
                    <td class="formcontent" style="width: 30%">
                    </td>
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
                    <asp:Label ID="lblnewlic" runat="server" Text="New License Details" ></asp:Label>
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
                        <asp:TextBox ID="txtnewexpdate" runat="server" CssClass="standardtextbox"></asp:TextBox>
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
                        <asp:TextBox ID="txtnewlicissu" runat="server" CssClass="standardtextbox"></asp:TextBox>
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
                    <td class="formcontent" style="width: 20%">
                    </td>
                    <td class="formcontent" style="width: 30%">
                    </td>
                </tr>
            </table>
        </div>
        <%--added by shreela for new license details end--%>
        <%--Added by rachana on 14022014 for Transfer Case Details end--%>
        <%--Added by rachana on 13022014 to show inbox cfr details start--%>
         <div class="panel-body" id="tblCFRInboxCollapse" style="display:none" runat="server">
          <div  class="panel-heading subheader">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblhead" runat="server" Text="Raised CFR's" CssClass="control-label labelSize " font-size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnBasicCollapse" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
          <div id="divCFRInbox" runat="server" class="card PanelInsideTab_body" style="display:block">
                          <div  id="tblCFRInbox" runat="server">
                           
                  <div class="row" style=" width:95%">
                    <div class="col-sm-6" style="text-align:left">
                        <asp:Label ID="lblcfrraised" runat="server" Text="Raised CFR" CssClass="control-label labelSize " ></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrraisedcount" runat="server" CssClass="badge" ></asp:Label> &nbsp;&nbsp;
                        <asp:Label ID="lblresponded" runat="server" Text="Responded CFR" CssClass="control-label labelSize "></asp:Label>&nbsp;
                          <asp:Label ID="lblcfrrespondedcount" runat="server" CssClass="badge" ></asp:Label>
                     </div>
                     <div class="col-sm-3" style="text-align:left">
                        
                      </div>
                      <div class="col-sm-3" style="text-align:left">
                        
                      </div>
                      
                 
           </div>
                  <div class="row" style="  width:95%; overflow:auto;">
                       
                           <asp:GridView  AllowSorting="True" ID="dgDetailsInbox" runat="server" CssClass="footable"
                                   OnRowCommand="dgDetailsInbox_RowCommand"
                                       AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                           OnRowDataBound="dgDetailsInbox_RowDataBound"  >
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
                               <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="CFR Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRRemarks") %>'></asp:Label>
                                    </ItemTemplate>
                              <ItemStyle CssClass="clscenter"/>
                                    <ItemStyle HorizontalAlign="left" ></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="CFR Raised For">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcfr" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                                    </ItemTemplate>
                                  <ItemStyle CssClass="clscenter"/>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="RemarkId" HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarkid" runat="server" Text='<%# Eval("RemarkId") %>'></asp:Label>
                                    </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Responded">
                                    <ItemTemplate>
                                        <asp:Label ID="Responded" runat="server" Text='<%# Eval("Responded") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="clscenter"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Responded" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCFRRemarkID" runat="server" Text='<%# Eval("CFRRemarkID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRaisedFlag" runat="server" Text='<%# Eval("RaisedFlag") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCFRDocCode" runat="server" Text='<%# Eval("DocCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCFRFlagType" runat="server" Text='<%# Eval("CFRFlagType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                </asp:TemplateField>
				           <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkReopen" style="text-align:center;" runat="server" Text="ReOpen CFR" CommandArgument='<%# Eval("RemarkId") %>'
                                         CommandName="ReopenCFR"></asp:LinkButton><%--Link to LinkReopen -Meena--%>
                                    </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                </asp:TemplateField>
				<asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddnlRemark" runat="server" Text='<%# Eval("AddnlRemark") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                   </div>
                                
                              <hr/>
                              
                <div class="row" style="width:95%;margin-top: 32px;">
               <div class="col-md-12" id="Td14" runat="server" style="text-align:left">
                <asp:Label ID="lblTitleRemarks" Visible="false" CssClass="control-label" runat="server" Text="Remarks" style="color: #00cccc; font-size: 17px; font-weight: bolder;"></asp:Label>
             </div>
             </div>
                <div class="row card" style="width:95%; overflow:auto;">
                 
            
                               <asp:GridView  AllowSorting="True" ID="GridRemarks" runat="server" CssClass="footable"
                                       AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                           OnRowDataBound="dgDetailsInbox_RowDataBound"  >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                       <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>
                            <Columns>
                            <asp:TemplateField  HeaderText="Date" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                   <ItemStyle CssClass="clscenter"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="70%">
                                    <ItemTemplate>
                                        <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRRemark") %>'></asp:Label>
                                    </ItemTemplate>
                                   <ItemStyle CssClass="clscenter"/>
                                </asp:TemplateField>
                                
                                </Columns>
                                
                        </asp:GridView>
                    </div>
                      <div class="row" id="trRespond" visible="false" runat="server" style="  width:95%">
          <div class="col-md-12" style="text-align:center; margin-top: 5px;"  >
                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;">
                            <i class="fa fa-comment"></i>--%>
                        <%--<asp:Button ID="btnRespond" runat="server" Text="Respond" CssClass="standardbutton"
                            Width="84px" OnClick="btnRespond_Click" Visible="false"></asp:Button>--%>
                             <asp:LinkButton ID="btnRespond" runat="server" Text="Respond"  CssClass="btn btn-success" 
                                 CausesValidation="false" OnClick="btnRespond_Click" Visible="false" TabIndex="32">
                                         <span class="glyphicon glyphicon-share-alt" style="color:White"> </span> Respond
                                    </asp:LinkButton>
                        <%--</div>--%>
                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;">
                            <i class="fa fa-comment"></i>--%>
                      <%--  <asp:Button ID="btnCloseCfr" runat="server" Text="Close CFR" CssClass="standardbutton"
                            Width="114px" OnClick="btnCloseCfr_Click"></asp:Button>--%>
                             <asp:LinkButton ID="btnCloseCfr" runat="server" Text="Close CFR"  CssClass="btn btn-success" 
                                    CausesValidation="false" OnClick="btnCloseCfr_Click">
                                         <span class="glyphicon glyphicon-ban-circle" style="color:White"> </span> Close CFR
                                    </asp:LinkButton>
                        <%--</div>--%>
                  </div>
              </div>
                           
            </div>
        </div>
        </div>
        <%--Added by rachana on 13022014 to show inbox cfr details end--%>
              <div id="divi"  runat="server" class="panel" style="display:none">
           
       <%--  <div class="row" >
             <div class="col-md-12" style="text-align:center">
                    <asp:Label ID="lblNote" runat="server" CssClass="control-label labelSize " Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/GIF format"
                        ForeColor="red"></asp:Label>
             </div>
          </div>--%>
       
           <div id="tblupload" runat="server" class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div9','btnpnlcfrdtls');return false;"
       >   
    <%--       <div class="row" >
             <div class="col-md-12" style="text-align:center">
                    <asp:Label ID="lblNote" runat="server" CssClass="control-label labelSize " Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/GIF format"
                        ForeColor="red"></asp:Label>
             </div>
          </div>        --%>
                          <div class="row">
                    <div class="col-sm-3" style="text-align:left">
                     <asp:Label ID="lblCanddoc" runat="server" Text="Candidate Document Upload" CssClass="control-label labelSize " Font-Size="19px"> </asp:Label>
                 
                    </div>
                        <div class="col-md-5"  style="text-align:center">
                          <asp:Label ID="txtcolr" runat="server" Height="12px" Width="20px" CssClass="form-control" BackColor="LightPink" Visible="false"></asp:Label>
                           <asp:Label ID="LinkButton1" runat="server" Text="Mandatory Documents" Visible="false" OnClick="lnkmandtry_click">
                    </asp:Label>&nbsp;&nbsp;&nbsp;
                        </div>
                    <div class="col-sm-4">
                        <span id="btnpnlcfrdtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>

          <div id="div9" runat="server"  class="panel-body"  style="width: 97%; display:block">
               <div class="row" >
             <div class="col-md-12" style="text-align:center">
                    <asp:Label ID="lblNote" runat="server" CssClass="control-label labelSize " Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/GIF format"
                        ForeColor="red"></asp:Label>
             </div>
          </div>      
        <ajaxToolkit:ModalPopupExtender ID="mdlcfrdtls" runat="server" BehaviorID="mdlcfrdtlsID"
            DropShadow="false" TargetControlID="buttonNull" PopupControlID="pnlcfrdtls" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Button ID="buttonNull" runat="server" Style="display: none" />
        <asp:Panel runat="server" ID="pnlcfrdtls" Style="display: block; width: 30%; height: 50%">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <ContentTemplate>
                      <div id="trdgDetails" runat="server" class="panel-body">
                               <%-- <asp:GridView ID="dgDetails1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                    Width="450px" RowStyle-CssClass="tableIsys" AllowSorting="True">--%>
                               <asp:GridView  AllowSorting="True" ID="dgDetails1" runat="server" CssClass="footable"
                                       AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                        >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                           <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>
                                    <%--OnRowDataBound="dgDetails_RowDataBound"OnSorting="dgDetails_Sorting" --%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Seq No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblseqno" runat="server" Text='<%# Bind("SeqNo") %>' Visible="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandatory Documents">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManDoc" runat="server" Text='<%# Bind("ImgDesc01") %>' Visible="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    
                                </asp:GridView>
                     </div>
                    <div class="row" >
                           <div class="col-md-12" style="text-align:center">
                                <%--align="center">--%>
                                <%--<div class="btn btn-xs btn-primary" style="width: 90px;">
                                    <i class="fa fa-times"></i>--%>
                                <asp:Button ID="btnpopcancel" runat="server" CssClass="standardbutton" Text="Cancel" />
                                <%--</div>--%>
                          </div>
                      </div>
                    
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnpopcancel" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
       
        
        <div id="div1" runat="server" style="display: block; ">
               <div class="row" style=" overflow:auto;">
              
                        <%--//pranjali start--%>
                       <%-- <asp:UpdatePanel ID="upddgView" runat="server">
                            <ContentTemplate>--%>
                                <%--<asp:GridView ID="dgView" runat="server" AllowSorting="True" CssClass="tableIsys"
                                    PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="dgView_PageIndexChanging"
                                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys" OnRowCommand="dgView_RowCommand"
                                    OnRowDataBound="dgView_RowDataBound" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True" Width="100%" PageSize="15">--%>
                                       <asp:GridView  AllowSorting="True" ID="dgView" runat="server" Style="width: 100%;" CssClass="footable"
                                     OnRowCommand="dgView_RowCommand"
                                    OnRowDataBound="dgView_RowDataBound"
                                       AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                            >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                        <HeaderStyle CssClass="gridview th" />
                                   <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                       <%-- <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>--%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Document Name"    HeaderStyle-Width="160px"><%--by Meena 06/12/17--%>
                                            <ItemTemplate>
                                                <asp:Label style="color: #ff0000" ID="lblMandate" runat="server" Font-Size="14px" Visible="false">*  &nbsp;</asp:Label>
                                                <asp:Label ID="lbldocName" runat="server" Font-Size="11px" Text='<%#Bind("ImgDesc01") %>'></asp:Label>
                                                <%--<span style="color: #ff0000">*</span>--%>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Document Description" HeaderStyle-Width="160"> <%--by Meena 06/12/17--%>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldocDescription" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgDesc02") %>'></asp:Label>
                                            </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                        <%--added by pranjali on 03-03-2014 start--%>
                                        <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                            </ItemTemplate>
                                       <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                        <%--added by pranjali on 03-03-2014 end--%>
                                        <asp:TemplateField HeaderText="Upload Documents" HeaderStyle-Width="110px">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                                    <ContentTemplate>
                                                        <asp:FileUpload ID="FileUpload" runat="server" Width="160px"></asp:FileUpload> <%--chnge 340 to 180 by meena  07/12/17--%>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_Upload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                                    <ContentTemplate>
                                                        <%--<asp:Button ID="btn_Upload" runat="server" CssClass="standardlabel" Text="Upload" Enabled="false" Visible="false" Width="80px"
                                                            OnClick="btn_Upload_Click" />--%>
                                                       <asp:LinkButton ID="btn_Upload" runat="server" CssClass="standardlabel" Text="Upload"
                                                                            Enabled="false" Visible="false" Width="70px" OnClick="btn_Upload_Click" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_Upload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_ReUpload" runat="server" CssClass="standardlabel" Text="ReUpload" Width="80px" 
                                            OnClick="btn_ReUpload_Click" />
                                        </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                    <ContentTemplate>
                                        <asp:Button ID="btn_ReUpload" runat="server" CssClass="standardbutton" Text="ReUpload" 
                                            OnClick="btn_ReUpload_Click" />
                                        </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>--%>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgsize" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                            </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgshrt" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgwidth" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgheight" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManDoc" runat="server" Text='<%#Bind("IsMandatory") %>'></asp:Label>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldoccode" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("DocCode") %>'></asp:Label>
                                            </ItemTemplate>
                                       <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
					<asp:TemplateField HeaderText="" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPreview" runat="server" Text="Preview" CommandArgument='<%# Eval("DocCode") %>' CommandName="Preview" 
                                                Font-Size="11px" Style="text-transform: capitalize;">
                                                    </asp:LinkButton>
                                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>

                                        </asp:TemplateField>
                                    </Columns>
                                   
                                </asp:GridView>
                                <br />
                                  <center>
                                              <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                                    <asp:TextBox runat="server" ID="txtPage1" Text="1" Style="width: 35px; border-style: solid;
                                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                                    <asp:Button ID="btnnext2" Text=">" Enabled="true" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                        </center>
                           <%-- </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="checkedchanged" />
                            </Triggers>
                        </asp:UpdatePanel>--%>
           
        </div>
        </div>
          </div>
         
         </div>
        <table class="formtable table-condensed" id="Table1" runat="server" style="width: 90%;">
            <tr id="tr_DocumentReuploadTitle" runat="server" visible="false">
                <%--pranjali--%>
                <td class="test" colspan="3" style="text-align: left;">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" visible="false"
                        id="Button11" style="width: 20px;" onclick="funShowReqDtl('ctl00_ContentPlaceHolder1_divReUploadFiles', 'ctl00_ContentPlaceHolder1_BtnReUpload');" />
                    <%--<asp:Label ID="lblcndupload" runat="server"  Text=""></asp:Label>--%>
                    <asp:Label ID="lblcndupload" runat="server" ></asp:Label>
                    <%--  Candidate Document Re-Upload--%>
                </td>
            </tr>
        </table>
        <div id="div2" runat="server" style="display: block;">
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
                                <asp:TemplateField HeaderText="Reupload Documents" HeaderStyle-Width="160px"> <%--chnge 340 to 180 by meena  07/12/17--%>
                                    <ItemTemplate>
                                        <asp:FileUpload ID="FileReUpload" runat="server" Width="150px" Filebytes='<%# Bind("UserFileName") %>'>
                                        </asp:FileUpload>
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
                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                            </PagerStyle>
                            <HeaderStyle CssClass="portlet blue" ForeColor="White" ></HeaderStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <%--pranjali end--%>
        <%--Added by rachana on 29-07-2013 for addition of panel showing documents start--%>
      
        <div id="divnavigate" runat="server" class="row" style=" margin-left:6%; margin-right:6%; display:block">
            <div id="tblphoto" style="display:none;" class="row" runat="server" >
                
                  <div class="col-md-2">
                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;" id="divCrop" runat="server" visible="false">
                            <i class="fa fa-crop"></i>--%>
                            <asp:LinkButton ID="Btncrop" runat="server"  CssClass="btn btn-sample" Text="CROP"  Visible ="false"
                                    CausesValidation="false" OnClick="Btncrop_Click" TabIndex="43"></asp:LinkButton>
                   <%--     <asp:Button ID="Btncrop" TabIndex="43" runat="server" Text="CROP" CssClass="standardbutton"
                            OnClick="Btncrop_Click" Width="80" Visible="false"></asp:Button>--%>
                        <%--</div>--%>
                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;" id="divCFR" runat="server" visible="false">
                            <i class="fa fa-crop"></i>--%>
                             <asp:LinkButton ID="BtnCFR" runat="server"  CssClass="btn btn-sample" Text="Raise CFR"
                                    CausesValidation="false" OnClick="btnCFR_Click" TabIndex="43">
                                        <span class="glyphicon glyphicon-arrow-up" style="color:White"> </span> Raise CFR
                                        </asp:LinkButton>
                     <%--   <asp:Button ID="BtnCFR" TabIndex="43" OnClick="btnCFR_Click" runat="server" Text="Raise CFR"
                            CssClass="standardbutton" Width="80px" Visible="false"></asp:Button>--%><%--</div>--%>
                        <%--OnClientClick="fungetcropimage();"--%>
                    </div>
                    <%--Added by pranjali on 25-022014 for displaying cfr raised start--%>
               <div class="col-md-2">
                        <asp:Label ID="lblcfrrais1" runat="server" Text="Raised CFR:" CssClass="control-label labelSize "></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrrais1count" runat="server" CssClass="control-label labelSize " Style="color: Red;"></asp:Label><br />
                </div>
                   
                   <div class="col-md-2">
                        <asp:Label ID="lblrespond" runat="server" Text="Responded CFR:" CssClass="control-label labelSize "></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrrespondcount" runat="server" CssClass="control-label labelSize " Style="color: #034ea2;"></asp:Label><br />
                  </div>
                   
                    <div class="col-md-2">
                        <asp:Label ID="lblclosed" runat="server" Text="Closed CFR:" CssClass="control-label labelSize "></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrclosed" runat="server" CssClass="control-label labelSize " Style="color: Green;"></asp:Label><br />
                   </div>
                    <%--Added by pranjali on 25-022014 for displaying cfr raised end--%>
                   <div class="col-md-2">
                        <asp:UpdatePanel runat="server" ID="upnlPrev">
                            <ContentTemplate>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <%--<div class="btn btn-xs btn-primary" style="width: 110;">
                                    <i class="fa fa-chevron-circle-left"></i>--%>
                                    <asp:LinkButton ID="btnprev" runat="server"  CssClass="btn btn-sample" Text="Prev"
                                  Visible="false"  CausesValidation="false" >
                                    <span class="glyphicon glyphicon-step-backward" style="color:White"> </span> Prev
                                    </asp:LinkButton>
                              <%--  <asp:Button ID="btnprev" runat="server" Text="Prev" CssClass="standardbutton" OnClick="btnprev_Click"
                                    Width="80"></asp:Button>--%><%--</div>--%>
                                &nbsp;&nbsp;
                            </ContentTemplate>
                        </asp:UpdatePanel>
                  </div>
                        <div class="col-md-2">
                        <asp:UpdatePanel runat="server" ID="upnlNext">
                            <ContentTemplate>
                                <%--<div class="btn btn-xs btn-sample" style="width: 110;">
                                    <i class="fa fa-crop"></i>--%>
                                     <asp:LinkButton ID="btnnext" runat="server"  CssClass="btn btn-sample" Text="Next"
                                Visible="false"      CausesValidation="false" >
                                         <span class="glyphicon glyphicon-step-forward" style="color:White"> </span> Next
                                         </asp:LinkButton>
                            <%--    <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="standardbutton" OnClick="btnnext_Click"
                                    Width="80"></asp:Button>--%>
                                <%--<i class="fa fa-chevron-right"></i>
                                </div>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                   </div>
            
            </div>
        </div>
        <%--Added by rachana on 29-07-2013 for addition of panel showing documents end--%>
        <%--added by shravana 14jun2013--%>
        <%--Added by rachana on 07-08-2013 start--%>
        <%--<asp:Panel ID="Panelphoto1"   runat="server" BorderColor="ActiveBorder" BorderStyle="Solid" BorderWidth="2px"  Width="89%" Height="500px" 
           ScrollBars="Vertical" class="modalpopupmesg" HorizontalAlign="Left" style="display:none"> 
          <center>
              <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height:5%;">
                 <tr>
                     <td >
                         <asp:Label ID="Label3" runat="server"   CssClass = "standardlink "/>
                         
                     </td>
                 </tr>
             </table>
          </center>
          <table style="width: 99%; height: 18px">
             <tr class="modalpanelleft">
               <td>
                  <asp:Image ID="Imageall" runat="server"/>
               </td>
            </tr>
         </table>   
      </asp:Panel>--%>
        <asp:Panel ID="Panelphoto2" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
            BorderWidth="2px" Width="89%" Visible="false" ScrollBars="Vertical" >
           <%--  <asp:Panel ID="Panelphoto2" runat="server" Style="display: none;">--%>
            <center>
            <asp:UpdatePanel runat="server" ID="upnlHeader">
                <ContentTemplate>
                 <div class="panel">
          <%--  <div class="panel #rcorners2" id="divAlert" runat="server" style="width:90%;
                display: block; border: 2px; border-radius: 15px; background-color: white; border: solid;
                border-color: blue; border-width: 2px;" cellpadding="0" cellspacing="0">--%>
                       <div id="Div8" runat="server" style="width:98%;!important" class="panel-heading" >
                        <div class="row" >
                            <div class="col-md-10" style="text-align:center">
                                <asp:Label ID="lblpanelheader" runat="server" CssClass="control-label labelSize " />
                                <asp:HiddenField ID="hdnDocId" runat="server" />
                         </div>
                       </div>
                   </div>
                    <div class="modalpanel" style="display: none">
                       <div class="row" >
                           
                                <asp:Image ID="imgCrop" runat="server" />
                         
                        </div>
                    </div>
                    <%----%>
                       <div id="divgrid" runat="server" class="panel-body" style="overflow: auto">
<%--                    <div id="divgrid" runat="server" style="width: 100%; height: 100%; overflow: hidden">--%>

                           
                              
                                   <%-- <asp:GridView ID="GridImage" runat="server" AllowSorting="True" CssClass="tableIsys"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                        RowStyle-CssClass="tableIsys" HorizontalAlign="Left" AutoGenerateColumns="False"
                                        AllowPaging="True" Width="100%" Height="242px" OnPageIndexChanging="GridImage_PageIndexChanging"
                                        OnRowDataBound="GridImage_RowDataBound">--%>
                                         <asp:GridView ID="GridImage" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                        AllowPaging="True"  OnPageIndexChanging="GridImage_PageIndexChanging" OnRowDataBound="GridImage_RowDataBound" CssClass="footable image"><%--CssClass="footable"--%>
                                          <HeaderStyle CssClass="textalign"/>
                                        
                                          
                                        <Columns>
                                            <%--<asp:TemplateField SortExpression="DocType" HeaderText="Image Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblCndNo" runat="server" Text='<%# Eval("DocType") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false" >
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblCndNo1"  runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton>
                                                    <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ID") %>'></asp:HiddenField>

                                                    
                                                </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Center" ></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:ImageField DataImageUrlField="ID" DataImageUrlFormatString="ImageCSharp.aspx?ImageID={0}"
                                              HeaderText="Preview Image" >
                                             
                                            </asp:ImageField>

                                        </Columns>
                                       <%-- <RowStyle CssClass="sublinkeven" BackColor="#78A8FA"></RowStyle>
                                        <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                        </PagerStyle>
                                        <HeaderStyle CssClass="portlet blue" ForeColor="White" ></HeaderStyle>
                                        <AlternatingRowStyle CssClass="sublinkodd" BackColor="#78A8FA"></AlternatingRowStyle>--%>
                                    </asp:GridView>
                             
                          
                           <div class="row" align="left">
                                      <div class="col-sm-3" style="margin-bottom: 5px;">
                                    <iframe id="FrmImg" runat="server" visible="false" ></iframe>
                               </div>
                           </div>
                     </div>
                    </div>
                  
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnnext" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
            </center>
        </asp:Panel>
        
        <div class="row" style="margin-top:12px;" id="divButtons" runat="server">
           
                      <div class="col-sm-12" align="center">
                        <%--  start added by sanoj 30092022--%>
                           <%--visible 1--%>
<%--          <asp:LinkButton  ID="btnPrev1" runat="server" Text="" CssClass="btn btn-success " Visible="false" Enabled="false" OnClick="btnPrev1_Click" > <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS  </asp:LinkButton> --%>
<%--            <asp:Button ID="" runat="server" Text="NEXT" CssClass="btn btn-success  " OnClientClick="return  RqrdValidation();" OnClick="btnNextdiv1_Click" Visible="true" />--%>
            <%--visible 1--%>
                           <asp:LinkButton  ID="btnCfrPrew" runat="server" Visible="false" Text="" CssClass="btn btn-success " OnClick="btnCfrPrew_Click" >   <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS</asp:LinkButton> 


            <%--visible 2--%>
           <%-- <asp:Button ID="" runat="server" Text="" CssClass="btn btn-success  " Visible="false"  OnClick=""/>--%>
            <asp:LinkButton  ID="btnPaymntPrew" runat="server" Visible="false" Text="" CssClass="btn btn-success " OnClick="btnPaymntPrew_Click" >   <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS</asp:LinkButton> 

                          
            <%-- <asp:Button ID="" runat="server" Text="NEXT" CssClass="btn btn-success  " OnClick="" Visible="false" />  --%>
                          


              <%--<asp:Button ID="" runat="server" Text="PREVIOUS" CssClass="btn btn-success  " Visible="false"  OnClick="btnExamPrew_Click"/>--%>

               <asp:LinkButton  ID="btnExamPrew" runat="server" Visible="false" Text="" CssClass="btn btn-success " OnClick="btnExamPrew_Click" >   <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS</asp:LinkButton> 


             <asp:LinkButton ID="btnExamtNxt" runat="server" Text="NEXT" CssClass="btn btn-success " Enabled="false" OnClick="btnExamtNxt_Click" Visible="false" />  

             <asp:LinkButton ID="btnTrnsfrPrew" runat="server" Text="PREVIOUS" CssClass="btn btn-success  " Visible="false"  OnClick="btnTrnsfrPrew_Click"/>
                          <%--visible 2--%>
                          <%--NOC--%>
             <asp:LinkButton ID="btnNOCNxt" runat="server" Text="NEXT" CssClass="btn btn-success " Enabled="false" OnClick="btnNOCNxt_Click" Visible="false" />  

             <asp:LinkButton ID="btnNOCPrew" runat="server"   CssClass="btn btn-success  " Visible="false"  OnClick="btnNOCPrew_Click"> <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS </asp:LinkButton> 
             

                             <%--  end added by sanoj 30092022--%>

                              <asp:LinkButton ID="btnSubmit" runat="server"  
                              OnClientClick="return Validation();"
                              CssClass="btn btn-success" 
                              CausesValidation="false" OnClick="btnSubmit_Click" TabIndex="32" >
                                  <span class="glyphicon glyphicon-saved" style="color:White"> </span> Submit
                     <%--  <span   class="glyphicon glyphicon-floppy-disk BtnGlyphicon" ></span> --%>
                                </asp:LinkButton>
                           <%-- <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit"
                                CssClass="standardbutton" Width="80px" OnClientClick="StartProgressBar();"></asp:Button>--%>

                         
                              <asp:LinkButton ID="btnSave" runat="server"  CssClass="btn btn-success " Visible="false"
                                 CausesValidation="false" OnClick="btnSave_Click" >
                                 <span   class="glyphicon glyphicon-floppy-disk BtnGlyphicon" ></span> SAVE
                                 </asp:LinkButton>
                              <asp:LinkButton ID="BtnApprove" runat="server"  CssClass="btn btn-success " Visible="false" Enabled="true"
                              CausesValidation="false" OnClick="btnApprove_Click" > <%-- OnClientClick="return funvalidateApprove();"--%>
                                  <span class="glyphicon glyphicon-ok-circle" style="color:White"> </span> APPROVE
                                  </asp:LinkButton>
                        
                              <asp:LinkButton ID="btnReject" runat="server" Visible="false"  CssClass="btn btn-success "
                              CausesValidation="false" OnClick="btnReject_Click" > 
                                   <span class="glyphicon glyphicon-remove-circle" style="color:White"> </span> REJECT
                                   </asp:LinkButton>
                       
                                                                
                              <asp:LinkButton ID="btnClear" TabIndex="43" runat="server"  CssClass="btn btn-clear " onclick="btnClear_Click">
                                    <span class="glyphicon glyphicon-remove" style="color:White"> </span> CANCEL
                                      </asp:LinkButton>
                                   <%--  Added by shreela on 14/07/2014 for renewals--%>
                               <%--    <asp:Button ID="btnCancel" runat="server" CssClass="standardbutton" Width="90px" Text="Cancel" Visible="false" OnClientClick="CloseSub()" />--%>
                              <asp:LinkButton ID="btnCancel" TabIndex="43" onclick="btnClear_Click"
                                runat="server"  Visible="false"
                                CssClass="btn btn-clear " >
                                    <span class="glyphicon glyphicon-remove" style="color:#f04e5e"> </span> CANCEL
                                    </asp:LinkButton>
                                  <asp:LinkButton  ID="btnNextdiv1" runat="server" Text="" CssClass="btn btn-success " OnClick="btnNextdiv1_Click" >  NEXT <span   class="glyphicon glyphicon-arrow-right BtnGlyphicon" ></span> </asp:LinkButton> 
                                  <asp:LinkButton  ID="btnPaymntNxt" runat="server" Text="" CssClass="btn btn-success " Visible="false"  OnClick="btnPaymntNxt_Click" >  NEXT <span   class="glyphicon glyphicon-arrow-right BtnGlyphicon" ></span> </asp:LinkButton> 

                                  <asp:LinkButton  ID="btnCfrNxt" runat="server"  CssClass="btn btn-success " Visible="false"  OnClick="btnCfrNxt_Click" >  NEXT <span   class="glyphicon glyphicon-arrow-right BtnGlyphicon" ></span> </asp:LinkButton> 




                              <asp:Button ID="btnCroprefresh" runat="server" CssClass="standardbutton"   style="display:none;"
                                    ClientIDMode="Static" onclick="btnCroprefresh_Click"  /><%--added by shreela on 05/08/2014 fro cropping--%>
				                   <asp:Button ID="btnReOpenReFresh" runat="server" CssClass="standardbutton"   style="display:none;"
                                    ClientIDMode="Static" onclick="btnReOpenReFresh_Click"  />
                            <div id="divloader" runat="server" style="display:none;">
                                &nbsp;&nbsp; <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                                </div>
                     
         </div>
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
                         <asp:HiddenField ID="hdnAgtType" runat="server" />
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

                       <asp:Button Text="btnok" ID="btnopen" OnClick="btnopen_Click" runat="server" Visible="false"/>
                      
                    </td>
                </tr>
            </table>
        </div>
        </div>
         </div>
<%--added by sanoj 07102022--%>
                     <div class="modal fade" id="myModal1234" role="dialog" style="padding-top:10px">
        <div class="modal-dialog modal-lg" style="width: 400px">
            <h1> ok</h1>
             </div>
  </div>
<%--added by sanoj 07102022--%>
                   <div class="modal fade" id="myModal" role="dialog" style="padding-top:10px">
        <div class="modal-dialog modal-lg" style="width: 400px">
    
      <!-- Modal content-->
     
      
    </div>
  </div>
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
                         <div class="col-sm-8" style="text-align:left;margin-left: -35px;">
                        
                                             <asp:Label ID="lblDocDesc"  runat="server" Text=""  CssClass="HeaderColor" style="font-size:17px;"></asp:Label>

                  </div>
                         <div class="col-sm-1" style="margin-left: 25px;margin-top: -16px;">
                          <button type="button" class="btn"  onclick="return Cancel(myModalImage);" style="color:blue;font-size: 30px;">
                        &times; </button>
                  </div>

                   </div>
          
            <div  class="modal-body">
                        <div id="img-preview">
                          
                               <asp:Image id="img3" runat="server"   class="image-box" style="cursor: move;margin-top: 14%;" />

                             <iframe id="PDFImage1" runat="server" width="100%" height="350px"></iframe>
                        </div>
                        <div class="img-op">
                        
                          <asp:HiddenField ID="ZoutSize" runat="server" />
                            <asp:HiddenField ID="hdnRotateValue" runat="server" />
                           <asp:HiddenField ID="ZinSize" runat="server" />
                            
                           <%--<span class="btn btn-success btnBorderRadius" onclick="return  zoomIn();">
                               <span class="glyphicon glyphicon-zoom-in" style="color:white;height:14px"></span> Zoom In</span>
                                <span class="btn btn-success btnBorderRadius" onclick="return  zoomOut();">
                                    <span class="glyphicon glyphicon-zoom-out" style="color:white;height:14px"></span> Zoom Out</span>
                                <span class="btn btn-success btnBorderRadius" onclick="return  rotateImage();">
                                    <span class="glyphicon glyphicon-repeat" style="color:white;height:14px"></span> Rotate</span>--%>
                    </div>
                   
                 

              


                 
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
                 
                      <asp:LinkButton ID="btnSaveImage" runat="server" style="font-size: 10px;" Text="Save Image" CssClass="btn" OnClick="SaveButn" Enabled="false" >
                        <span class="glyphicon glyphicon-floppy-disk" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> SAVE 
                              </asp:LinkButton>
                 
                         <button class="btn" id="btnCrop"  onclick="return funcopencrop1();" style="font-size: 10px;"  >
                         <span class="glyphicon glyphicon-edit" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> CROP</button>

                
                      <button class="btn" id="btnBlur"  onclick="return funcopenBlur();" style="font-size: 10px;" >
                         <span class="glyphicon glyphicon-adjust" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> BLUR </button>
                  
                       <button class="btn"  onclick="return RaiseCFR();" style="font-size: 10px;" >
                       <span class="glyphicon glyphicon-arrow-up" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> CFR Raise</button>
                
                           
                        <asp:LinkButton ID="btnApp" runat="server" Text="Approve Image" CssClass="btn" style="font-size: 10px;" OnClick="App" >
                                     <span class="glyphicon glyphicon-ok-circle" style="color:#00cccc;height:14px;font-size: 16px !important;"></span><br /> APPROVE 
                              </asp:LinkButton>
                  
                  
                    </div>

                    <div id="divPdfBtn">
                        <asp:LinkButton ID="btnSavePDF" ClientIDMode="Static" runat="server" OnClick="btnSavePDF_Click" Text="Save Image"
                        CssClass="btn" Style="display: none; font-size: 10px;">
                        <span class="  glyphicon glyphicon-floppy-disk" style="color:#00cccc;height:14px"></span> Save Image
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnPDFApprv" runat="server" ClientIDMode="Static" Text="Approve Image" CssClass="btn" OnClick="lnkbtnPDFApprv_click" Style="font-size: 10px;">
                                     <span class="glyphicon glyphicon-ok-circle" style="color:#00cccc;height:14px;font-size: 16px !important;"></span> </br> APPROVE 
                    </asp:LinkButton>
					<button class="btn" id="btnPDFCFR" onclick="return RaiseCFR();" style="font-size: 10px;">
                            <span class="glyphicon glyphicon-arrow-up" style="color: #00cccc; height: 14px;font-size: 16px !important;"></span>  </br>CFR RAISE</button>
                      </div>

                 </div>

                
              
                     </ContentTemplate>
                   </asp:UpdatePanel>
            </div>
             </div>
       
</div>

               <%--   added by sanoj --%>
<div class="modal" id="msgModalPopup" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;" >
  <div class="modal-dialog" style="padding-top: 0px; width: 70%;">
    <div class="modal-content" style=" width: 333px;">
         <%--<div class="modal-header">--%>
      <h3 style="margin-top: 23px;color:blue;font-size:18px;">INFORMATION</h3>
           <%--  </div>--%>
      <%--  <button type="button" data-dismiss="modal" onclick="return Cancel(msgModalPopup);"  aria-hidden="true" style=" color: blue; border: none; background-color: white; margin-left: 458px; font-size: 19px; ">&times;</button>--%>
       
     
      <%--<div class="modal-body" >--%>
        <div class="modal-body" style="text-align: center">
          
          <asp:Label ID="lblpopup" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align:center">
          <button type="button" class="btn btn-success" data-dismiss="modal" onclick="return Cancel(msgModalPopup);" style="margin-right: 110px;border-radius: 6px;">
             <span class="glyphicon glyphicon-ok" style='color: White;'> </span> OK</button>
         
       
      </div>
        
         <%-- <iframe id="iframeCFR123" src="" width="675" height="300" frameborder="0" allowtransparency="true"></iframe>  --%>
      <%--</div>--%>
     
    </div>

  </div>

</div>

                  <%--  Added by usha  for PDF--%>
                    <div id="PDFImgModal" class="modal" style="padding-top: 10px">

        <div class="modal-content">
            <div class="modal-header">
               
                <div class="modal-title">
                    <asp:HiddenField ID="hdnPDFImgID" runat="server" />
                    <asp:HiddenField ID="hdnPDFID" runat="server" />
                    <span style="font-weight: bold;">
                        <asp:Label ID="lblPDFDocName" Text="Document Name : " CssClass="HeaderColor" runat="server" style=" margin-left: 233px;font-size:17px;"></asp:Label></span>
                    <asp:Label ID="lblPDFDocDesc" runat="server" Text="" CssClass="control-label" style="font-size:17px;"></asp:Label>
                </div>
            </div>
            <div class="modal-body">
                <center>
                    <div id="PDFImgPreview" style="overflow: auto">
                        <%--<asp:Image ID="PDFImage" runat="server" class="image-box" Style="cursor: move; margin-top: -7%;" />--%>
                         <iframe id="PDFImage" runat="server" width="100%" height="350px"></iframe>
                    </div>
                    <div class="img-op" id="pdf-op" style="padding-top: 2%;">
                        <asp:HiddenField ID="HiddenField8" runat="server" />
                        <asp:HiddenField ID="HiddenField9" runat="server" />
                        <asp:HiddenField ID="HiddenField10" runat="server" />
                    </div>

                    <div class="img-op" style="padding: 2px">
                    </div>
                    <%--  ClientIDMode="Static" Added by Daksh--%>
                    <%--<asp:LinkButton ID="btnSavePDF" ClientIDMode="Static" runat="server" OnClick="btnSavePDF_Click" Text="Save Image"
                        CssClass="btn btn-primary btnBorderRadius" Style="display: none; font-size: 14px!important; background-color: rebeccapurple;">
                        <span class="  glyphicon glyphicon-floppy-disk" style="color:white;height:14px"></span> Save Image
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnPDFApprv" runat="server" ClientIDMode="Static" Text="Approve Image" CssClass="btn btn-success btnBorderRadius" OnClick="lnkbtnPDFApprv_click">
                                     <span class="glyphicon glyphicon-ok-circle" style="color:white;height:14px"></span> Approve Image
                    </asp:LinkButton>--%>
                </center>
            </div>
            <div class="modal-footer" style="text-align: center;">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <%--<button class="btn btn-warning btnBorderRadius" id="btnPDFCFR" onclick="return RaiseCFR();">
                            <span class="glyphicon glyphicon-arrow-up" style="color: white; height: 14px"></span>CFR Raise</button>--%>

                        <asp:Button ID="Button6" TabIndex="43" Style="display: none;" OnClick="btnCFR_Click" runat="server" Text="Raise CFR"
                            CssClass="standardbutton" Width="80px"></asp:Button>

                        <button type="button" class="btn btn-danger btnBorderRadius" onclick="return Cancel(PDFImgModal);">
                            <span class="glyphicon glyphicon-remove" style="color: White"></span>Cancel</button>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

                      <%--   added by sanoj --%>


<div class="modal" id="myModalRaise" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;margin-top: -2px;" >
  <div class="modal-dialog" style="
    padding-top: 0px;
    width: 70%;">
    <div class="modal-content">
     
       

          <div class="row" style=" margin-top: 10px;">
                     <div class="col-sm-3" style="text-align:center;">
                       
                       <span class="glyphicon glyphicon-arrow-left" style="color:#00cccc"> </span>   <asp:Label ID="lblcfrfor" Text="Raise CFR for:" CssClass="HeaderColor" style="font-size:17px;" runat="server"></asp:Label>

                  </div>
                         <div class="col-sm-8" style="text-align:left;margin-left: -35px;">
                        
                          <asp:Label ID="lblForcfr"  runat="server" Text=""  CssClass="HeaderColor" style="font-size:17px;"></asp:Label>

                  </div>
                         <div class="col-sm-1" style="margin-left: 25px;margin-top: -10px;">
                             <asp:LinkButton ID="lnkRaise" runat="server" OnClientClick="return Cancel1(myModalRaise,myModalImage);"  style="color:blue;font-size: 30px;text-decoration: none;" >
                                   &times;
                              </asp:LinkButton>

                               <%--<button type="button" class="btn"  onclick="return Cancel1(myModalRaise,myModalImage);">
                      <span   style="color:blue;font-size: 30px;"> &times;</span></button>--%>
                  </div>

                   </div>
        
     
        <div class="modal-body" >
          <iframe id="iframeCFR" src="" width="675" height="310" frameborder="0" allowtransparency="true"></iframe>  
      </div>
     
    </div>
    <!-- /.modal-content -->
  </div>
  <!-- /.modal-dialog -->
</div>
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
                         <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="return Cancel1(myModalCrop,myModalImage);"  style="color:blue;font-size: 30px;text-decoration: none;" >
                                   &times;
                              </asp:LinkButton>--%>

                              <button type="button" class="btn"  onclick="return Cancel1(myModalCrop,myModalImage);">
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
  <!-- /.modal-dialog -->
</div>
            <div class="modal fade" id="myModalReOpen" role="dialog" style="padding-top:10px">
    <div class="modal-dialog" style="margin-top: -53px;"><%--meena--%>
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header" style="background-color:#dff0d8;">
            <asp:Label ID="Label20" Text="ReOpen CFR" runat="server"  Font-Size="19px"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
           <div class="row" >
                    <div class="col-sm-3" style="text-align:left">

                        <asp:Label ID="lblDescrptn" runat="server" Text="Enter Description:" CssClass="control-label labelSize " ></asp:Label>
                  </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtDescValue" runat="server" Rows="4"  TextMode="multiline"  CssClass="form-control"  style="padding:5px;" ></asp:TextBox><%--added by ajay sawant 19/4/2018--%>
                  </div>
                  <asp:HiddenField ID="hdnReOpen" runat="server" />
             </div>
        
        </div>
        <div class="modal-footer" style="text-align: center">
          <asp:LinkButton ID="BtnSubmitReOpen" runat="server"  CssClass="btn btn-sample" Text="Submit"
                                    CausesValidation="false" OnClick="BtnSubmitReOpen_Click"  style='display:initial;'  ><%--added by ajay sawant 19/4/2018--%>
                                       <span class="glyphicon glyphicon-saved BtnGlyphicon"> </span> Submit
                                    </asp:LinkButton>
        
              <asp:LinkButton ID="lnkReopen" runat="server" Text="Cancel" CssClass="btn btn-sample"    OnClick="Cancel"  style='display:initial;'>
                             <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> Cancel </asp:LinkButton>
                      

          
        </div>
      </div>
      
    </div>
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
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
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
                      <img src="../../../theme/iflow/aa.png" height="22px" width="22px" id="btnrp" name="btnrp" onclick="brnrotatem()" />
                 <asp:HiddenField ID="HiddenField2" runat="server" />
          &nbsp;&nbsp;&nbsp;&nbsp;

                
                <img src="../../../theme/iflow/bb.png" height="22px" width="22px" id="btnrm" name="btnrm" onclick="brnrotatep1()" />

                <%--value="Rotate-"--%>
                <div style="padding-top: 10px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;    
                   <asp:Button ID="Button3" runat="server" Text="Cancel" Width="100px" Height="25px" CssClass="standardbutton" />
                    &nbsp;&nbsp;&nbsp;&nbsp;  
                  
                    <asp:Button ID="btnRotateSave" runat="server" Text="Save" Width="100px" OnClick="lblRotate_Click" Height="25px" CssClass="standardbutton" />&nbsp;&nbsp;&nbsp;&nbsp;
                 </div>
            </div>
        </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopupzoom" runat="server" TargetControlID="Label10"
        BehaviorID="mdlpopupzoom" BackgroundCssClass="modalPopupBg" PopupControlID="Panel2"
        OkControlID="btnok">
    </ajaxToolkit:ModalPopupExtender>
    <%--miti..for Raise CFR...Start--%>
    <%--<asp:Panel runat="server" ID="PnlRaiseCFR" Width="700" display="none">
        <iframe runat="server" id="IframeRaiseCFR" width="700" height="450px" frameborder="0"
            display="none"></iframe>--%>
    <asp:Panel runat="server" ID="PnlRaiseCFR" Width="500" Height="428" display="none" top="52" left="529px">
        <iframe runat="server" id="IframeRaiseCFR" width="610px" height="539px" frameborder="0" style="margin-top: -30px;"
            display="none"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="Label1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseCFR" BehaviorID="MdlPopRaiseCFR"
        TargetControlID="Label1" PopupControlID="PnlRaiseCFR" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--miti..for Raise CFR...end--%>
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

    <%--<asp:Panel runat="server" ID="PnlExm" Width="100%" Height="90%" display="none">
        <iframe runat="server" id="IframeExm" scrolling="no" width="50%" frameborder="0"
            display="none" style="height: 50%; background-color: White;"></iframe>
    </asp:Panel>--%>
    <%--   <asp:Label runat="server" ID="Label6" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlViewBIDExm"
        DropShadow="true" TargetControlID="Label6" PopupControlID="PnlExm" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>--%>




    <%--ReOpen  CFR...START--%>
      
    <div class="modal" id="myModalReOpenCFR" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;margin-top: -2px;" >
  <div class="modal-dialog" style="
    padding-top: 0px; margin-top:100px;
    width: 70%;">
    <div class="modal-content">
     
       

          <div class="row" style=" margin-top: 10px;">
                     <div class="col-sm-3" style="text-align:center;">
                       
                       <span class="glyphicon glyphicon-arrow-left" style="color:#00cccc"> </span>   <asp:Label ID="Label24" Text="ReOpen CFR" CssClass="HeaderColor" style="font-size:17px;" runat="server"></asp:Label>

                  </div>
                         <div class="col-sm-8" style="text-align:left;margin-left: -35px;">
                        
                          <asp:Label ID="Label25"  runat="server" Text=""  CssClass="HeaderColor" style="font-size:17px;"></asp:Label>

                  </div>
                         <div class="col-sm-1" style="margin-left: 25px;margin-top: -10px;">
                             <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="return Cancel1(myModalRaise,myModalImage);"  style="color:blue;font-size: 30px;text-decoration: none;" >
                                   &times;
                              </asp:LinkButton>

                               <%--<button type="button" class="btn"  onclick="return Cancel1(myModalRaise,myModalImage);">
                      <span   style="color:blue;font-size: 30px;"> &times;</span></button>--%>
                  </div>

                   </div>
        
     
        <div class="modal-body" >
          <iframe id="IframeReOpenCFR" src="" width="500" height="210" frameborder="0" allowtransparency="true"></iframe>  
      </div>
     
    </div>
    <!-- /.modal-content -->
  </div>
  <!-- /.modal-dialog -->
</div>

    
    <%--ReOpen  CFR...end --%>

    <%--Loader popup start--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: Grey;">

        <center>
                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                        <br />
                        <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                    </center>
    </asp:Panel>
    <%--Loader popup end--%>
    <script language="javascript" type="text/javascript">
        function popup() {
            debugger;
            var modal = document.getElementById('msgModalPopup');
            modal.style.display = "block";
            //$("#myModal").modal();
        }


        function popupReOpen(hdnReOpenCFR, ModuleID) {
            //  debugger;
            // $("#hdnReOpen").val() = hdnReOpenCFR;
            $("#myModalReOpen").modal();
        }

        function ShowReqDtl(divName, btnName) {
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

        //function ShowReqDtl(divName, btnName) {
        //    //debugger;
        //    var objnewdiv = document.getElementById(divName);
        //    var objnewbtn = document.getElementById(btnName);

        //    if (objnewdiv.style.display == "block") {
        //        objnewdiv.style.display = "none";
        //        //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
        //    }
        //    else {
        //        objnewdiv.style.display = "block";
        //        //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
        //    }
        //}
        //function ShowReqDtl(divName, btnName) {
        //  //  debugger;
        //    try {
        //        var objnewdiv = document.getElementById(divName)
        //        var objnewbtn = document.getElementById(btnName);
        //        if (objnewdiv.style.display == "block") {
        //            objnewdiv.style.display = "none";
        //            objnewbtn.className = 'glyphicon glyphicon-chevron-down'
        //        }
        //        else {
        //            objnewdiv.style.display = "block";
        //            objnewbtn.className = 'glyphicon glyphicon-chevron-down'
        //        }
        //    }
        //    catch (err) {
        //        ShowError(err.description);
        //    }
        //}
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

        //added validation  by sanoj 09102022   
        function RqrdValidation() {
            debugger;

            var strContent = "ctl00_ContentPlaceHolder1_";
            if (SpaceTrim(document.getElementById(strContent + "txtGivenName").value) == "") {
                alert("Please Enter Given Name");
                document.getElementById(strContent + "txtGivenName").focus();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtFathername").value) == "") {
                alert("Please Enter Father Name");
                document.getElementById(strContent + "txtFathername").focus();
                return false;
            }
            if ((document.getElementById(strContent + "txtMobileNo").value) == "") {
                alert("Mobile No is mandatory.");
                document.getElementById(strContent + "txtMobileNo").focus();
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
                    return false;
                }

            }
            if ((document.getElementById(strContent + "txtEMail").value) == "") {
                alert("Please Enter Email");
                document.getElementById(strContent + "txtEMail").focus();
                return false;
            }
            validateEmail1();
        }
        //Ended validation  by sanoj 09102022


        //Ended by Nikhil Pathari on 10-09-2015 for Father Name Space validation end
        function Validation() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////
            var StateCode = (document.getElementById("<%=hdnStateCode.ClientID %>").value);

            if (StateCode == "ME" || StateCode == "SI") {
            }
            else {
                if (document.getElementById("<%=txtPAN.ClientID%>").value == "") {
                    alert("Please Enter PAN No");
                    document.getElementById("<%=txtPAN.ClientID%>").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            if (SpaceTrim(document.getElementById("<%=txtPAN.ClientID%>").value) != "") {
                if (CheckPANFormat(document.getElementById("<%=txtPAN.ClientID%>").value) == 0) {
                    alert("Please Enter Valid PAN No");
                    document.getElementById("<%=txtPAN.ClientID%>").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }

            }
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
            //  debugger;
            if (document.getElementById("<%=cbTrfrFlag.ClientID %>") != null) {
                if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked == "") {
                    if (document.getElementById(strContent + "txtOldTccLcnNo").value != null) {
                        if (document.getElementById(strContent + "txtOldTccLcnNo").value == "") {
                            alert("License Number for Transfer is Mandatory");
                            document.getElementById(strContent + "txtOldTccLcnNo").focus();
                            // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById(strContent + "txtDate").value == "")//txtOldTccLcnExpDate_txtDate
                    {
                        alert("License Expiry Date for Transfer is Mandatory");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtDate").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                    if (document.getElementById(strContent + "txtissudate").value == "") {
                        alert("License Issue Date for Transfer is Mandatory.");
                        document.getElementById(strContent + "txtissudate").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }

                    //			        
                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "Select") || (document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "")) {
                        alert("Insurer Name for Transfer is Mandatory.");
                        document.getElementById('<%= ddlTrnsfrInsurName.ClientID %>').focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                    if (document.getElementById(strContent + "txtCndURNNo").value == "") {
                        alert("Candidate URN No. is Mandatory.");
                        document.getElementById(strContent + "txtCndURNNo").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                }
            }

            //added by pranjali on 13-03-2014 for composite start
            //  debugger;
            if (document.getElementById("<%=cbTccCompLcn.ClientID %>") != null) {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                    if (document.getElementById(strContent + "txtCompLicNo").value == "") {
                        alert("License Number for Composite is Mandatory");
                        document.getElementById(strContent + "txtCompLicNo").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }


                    if (document.getElementById(strContent + "txtCompLicExpDt").value == "")//txtOldTccLcnExpDate_txtDate
                    {
                        alert("License Expiry Date for Composite is Mandatory");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtCompLicExpDt").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }

                    //			        
                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "Select") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                        alert("Insurer Name for Composite is Mandatory.");
                        document.getElementById('<%= ddlCompInsurerName.ClientID %>').focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                }
            }

            //added by pranjali on 13-03-2014 for composite end
            //added by pranjali on 11-04-2014 start
            if (document.getElementById('<%=ddlExam.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExam.ClientID %>').value == "Select") || (document.getElementById('<%=ddlExam.ClientID %>').value == "")) {
                    alert("Please Select Exam Mode");
                    document.getElementById('<%= ddlExam.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlExmBody.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExmBody.ClientID %>').value == "Select") || (document.getElementById('<%=ddlExmBody.ClientID %>').value == "")) {
                                        alert("Please Select Examination Body");
                                        document.getElementById('<%= ddlExmBody.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlpreeamlng.ClientID %>') != null) {
               <%-- if ((document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "Select") || (document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "")) {
                                        alert("Please Select Preferred Exam Language");
                                        document.getElementById('<%= ddlpreeamlng.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }--%>
            }
            if (document.getElementById('<%=txtExmCentre.ClientID %>') != null) {
                <%--if ((document.getElementById('<%=txtExmCentre.ClientID%>').value == "Select") || (document.getElementById('<%=txtExmCentre.ClientID%>').value == "")) {
                    alert("Please Select Exam Centre");
                    document.getElementById('<%=txtExmCentre.ClientID%>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }--%>
            }

            //            if (document.getElementById('<%=ddlExmCentre.ClientID %>') != null) {
            //                if ((document.getElementById('<%=ddlExmCentre.ClientID %>').value == "Select") || (document.getElementById('<%=ddlExmCentre.ClientID %>').value == "")) {
            //                    alert("Exam Centre is Mandatory.");
            //                    document.getElementById('<%= ddlExmCentre.ClientID %>').focus();
            //                    return false;
            //                }
            //            }

            //added by pranjali on 11-04-2014 end

            //added by pranjali on 28-04-2014 start
            if (document.getElementById('<%=ddlNExam.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlNExam.ClientID %>').value == "Select") || (document.getElementById('<%=ddlNExam.ClientID %>').value == "")) {
                    alert("Please Select Exam Mode");
                    document.getElementById('<%= ddlNExam.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlNExmBody.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlNExmBody.ClientID %>').value == "Select") || (document.getElementById('<%=ddlNExmBody.ClientID %>').value == "")) {
                    alert("Please Select Examination Body");
                    document.getElementById('<%= ddlNExmBody.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            <%--if (document.getElementById('<%=ddlNpreeamlng.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlNpreeamlng.ClientID %>').value == "Select") || (document.getElementById('<%=ddlNpreeamlng.ClientID %>').value == "")) {
                    alert("Please Select Preferred Exam Language");
                    document.getElementById('<%= ddlNpreeamlng.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=txtNExmCenter.ClientID %>') != null) {
                if ((document.getElementById('<%=txtNExmCenter.ClientID %>').value == "Select") || (document.getElementById('<%=txtNExmCenter.ClientID %>').value == "")) {
                    alert("Please Select Exam Centre");
                    document.getElementById('<%= txtNExmCenter.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }--%>

            //            if (document.getElementById('<%=ddlNExmCenter.ClientID %>') != null) {
            //                if ((document.getElementById('<%=ddlNExmCenter.ClientID %>').value == "Select") || (document.getElementById('<%=ddlNExmCenter.ClientID %>').value == "")) {
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
            //                    if ((document.getElementById('<%=ddlRenewType.ClientID %>').value == "Select") || (document.getElementById('<%=ddlRenewType.ClientID %>').value == "")) {
            //                        alert("Insurer Type is Mandatory.");
            //                        document.getElementById('<%= ddlRenewType.ClientID %>').focus();
            //                        return false;
            //                    }
            //                    if (document.getElementById('<%=hdnInsRenType.ClientID %>').value == "L") {
            //                        if ((document.getElementById('<%=ddllyfTraining.ClientID %>').value == "Select") || (document.getElementById('<%=ddllyfTraining.ClientID %>').value == "")) {
            //                            alert("Life Training Completed is Mandatory.");
            //                            document.getElementById('<%= ddllyfTraining.ClientID %>').focus();
            //                            return false;
            //                        }
            //                    } //shree
            //                }

        }


        //added by pranjali on 04-03-2014 start
        function funvalidateApprove() {
            debugger;
            //added by rachana on 1/04/2014 for Trn Type validation start
            var strContent = "ctl00_ContentPlaceHolder1_";
            //  debugger;

            //added by rachana on 1/04/2014 for Trn Type validation end
            //added by pranjali on 11-04-2014 start
            if (document.getElementById('<%=ddlExam.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExam.ClientID %>').value == "Select") || (document.getElementById('<%=ddlExam.ClientID %>').value == "")) {
                    alert("Please Select Exam Mode");
                    document.getElementById('<%= ddlExam.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlExmBody.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExmBody.ClientID %>').value == "Select") || (document.getElementById('<%=ddlExmBody.ClientID %>').value == "")) {
                    alert("Please Select Examination Body");
                    document.getElementById('<%= ddlExmBody.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            <%--if (document.getElementById('<%=ddlpreeamlng.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "Select") || (document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "")) {
                    alert("Please Select Preferred Exam Language");
                    document.getElementById('<%= ddlpreeamlng.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            if (document.getElementById('<%=txtExmCentre.ClientID %>') != null) {
                if ((document.getElementById('<%=txtExmCentre.ClientID%>').value == "Select") || (document.getElementById('<%=txtExmCentre.ClientID%>').value == "")) {
                    alert("Please Select Exam Centre");
                    document.getElementById('<%=txtExmCentre.ClientID%>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }--%>

            //            if (document.getElementById('<%=ddlExmCentre.ClientID %>') != null) {
            //                if ((document.getElementById('<%=ddlExmCentre.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmCentre.ClientID %>').value == "")) {
            //                    alert("Exam Centre is Mandatory.");
            //                    document.getElementById('<%= ddlExmCentre.ClientID %>').focus();
            //                    return false;
            //                }
            //            }

            //added by pranjali on 11-04-2014 end
            //  if (document.getElementById("ctl00_ContentPlaceHolder1_cbTrfrFlag") != null) {
            //if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked != true) {
            //debugger;
            if (document.getElementById('<%=ddlTrnMode.ClientID %>') != null) {
                if ((document.getElementById('<%= ddlTrnMode.ClientID %>').value == "Select") || (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "")) {
                    alert("Please Select Training Mode");
                    document.getElementById('<%= ddlTrnMode.ClientID  %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            if (document.getElementById('<%=ddlTrnLoc.ClientID %>') != null) {
                if ((document.getElementById("<%=ddlTrnLoc.ClientID%>").value == "Select") || (document.getElementById('<%=ddlTrnLoc.ClientID %>').value == "")) {
                    alert("Please Enter the Training Location");
                    document.getElementById("<%=ddlTrnLoc.ClientID%>").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlTrnInstitute.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlTrnInstitute.ClientID %>').value == "Select") || (document.getElementById('<%=ddlTrnInstitute.ClientID %>').value == "")) {
                    alert("Please Select Training Institute");
                    document.getElementById("<%=ddlTrnInstitute.ClientID%>").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            if (document.getElementById('<%=ddlHrsTrn.ClientID %>') != null) {
                if ((document.getElementById('<%= ddlHrsTrn.ClientID %>').value == "Select") || (document.getElementById('<%=ddlHrsTrn.ClientID %>').value == "")) {
                    alert("Please Select Training Hrs");
                    document.getElementById('<%= ddlHrsTrn.ClientID  %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            //  }
            //   }

            //shree
            if (document.getElementById("<%=hdnrenwlflag.ClientID %>").value == "Y") {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                            if (document.getElementById('<%=txtCompLicNo.ClientID %>').Value == "") {
                        alert("Please Enter Life LicenseNo.");
                        document.getElementById("<%=txtCompLicNo.ClientID %>").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }

                    if (document.getElementById('<%=txtCompLicExpDt.ClientID %>').Value == "") {
                        alert("Please Enter License Exp.Date");
                        document.getElementById("<%=txtCompLicExpDt.ClientID %>").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }

                    if (document.getElementById('<%=ddlCompInsurerName.ClientID %>') != null) {
                        if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "Select") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                            alert("Please Select Insurer Name");
                            document.getElementById("<%=ddlCompInsurerName.ClientID%>").focus();
                                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                                    return false;
                                }
                            }


                        }
                        //shree07
                        //added by shreela on18042014 for renewals validation
                        if (document.getElementById('<%=hdnCandTypeRen.ClientID %>').value == "Composite") {
                            if ((document.getElementById('<%=ddlRenewType.ClientID %>').value == "Select") || (document.getElementById('<%=ddlRenewType.ClientID %>').value == "")) {
                        alert("Insurer Type is Mandatory.");
                        document.getElementById('<%= ddlRenewType.ClientID %>').focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                    if (document.getElementById('<%=hdnInsRenType.ClientID %>').value == "L") {
                        if (document.getElementById('<%=ddllyfTraining.ClientID %>') != null) {
                            if ((document.getElementById('<%=ddllyfTraining.ClientID %>').value == "Select") || (document.getElementById('<%=ddllyfTraining.ClientID %>').value == "")) {
                                alert("Life Training Completed is Mandatory.");
                                document.getElementById('<%= ddllyfTraining.ClientID %>').focus();
                                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
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
                            // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById(strContent + "txtDate").value == "")//txtOldTccLcnExpDate_txtDate
                    {
                        alert("License Expiry Date for Transfer is Mandatory");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtDate").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }


                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "Select") || (document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "")) {
                        alert("Insurer Name for Transfer is Mandatory.");
                        document.getElementById('<%= ddlTrnsfrInsurName.ClientID %>').focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                    if (document.getElementById(strContent + "txtCndURNNo").value == "") {
                        alert("Candidate URN No. is Mandatory.");
                        document.getElementById(strContent + "txtCndURNNo").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }

                    if (document.getElementById(strContent + "txtissudate").value == "") {
                        alert("License Issue Date for Transfer is Mandatory.");
                        document.getElementById(strContent + "txtissudate").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
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
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }


                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "Select") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                        alert("Insurer Name for Composite is Mandatory.");
                        document.getElementById('<%= ddlCompInsurerName.ClientID %>').focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
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
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = ''; //PAN  Validation added by pratik 15/2/18
                document.getElementById('<%=hdnPan.ClientID%>').value = '0'; //PAN  Validation added by pratik 15/2/18
                alert('Please Enter PAN No.');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }
            if (varPAN.length < 10) {
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = ''; //PAN  Validation added by pratik 15/2/18
                document.getElementById('<%=hdnPan.ClientID%>').value = '0'; //PAN  Validation added by pratik 15/2/18
                alert('PAN No. must have minimum 10 characters');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }

            if (varPAN.length != 10) {
                alert('PAN No. should be 10 characters.');
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = ''; //PAN  Validation added by pratik 15/2/18
                document.getElementById('<%=hdnPan.ClientID%>').value = '0'; //PAN  Validation added by pratik 15/2/18
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }
            document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = ''; //PAN  Validation added by pratik 15/2/18
            document.getElementById('<%=hdnPan.ClientID%>').value = '0'; //PAN  Validation added by pratik 15/2/18
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

                                if (pan2.substring(j, j + 1) != 'P') {
                                    return 0;
                                }
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
            if (document.getElementById('<%=ddlExam.ClientID %>').value == "Select") {
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
                    "&strhdnExmCCode=" + strhdnExmCCode + "&ExmMode=" + document.getElementById('<%=ddlExam.ClientID %>').value + "&SalesUnitCode=" + "&BizSrc=" + document.getElementById('<%=hdnBizSrc.ClientID %>').value + "&ExmBody=" + document.getElementById('<%=ddlExmBody.ClientID %>').value, 750, 350, null);

            }
        }


        function funOpenPopWinTrnInstitute(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "Select") {
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
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "Select") {
                alert("Please Select Training Mode");
                return false;
            }
            else {
                showPopWin(strPageName + "?txtTrnInstName=" + document.getElementById(strTrnInstitute).value +
                    "&strtxtTrnInstitute=" + strtxtTrnInstitute +
                    "&strhdnTrnInstitute=" + strhdnTrnInstitute + "&Page=TrnLoc&TrnMode=" + document.getElementById('<%=ddlTrnMode.ClientID%>').value + "&TrnInst=" + document.getElementById('<%=hdnTrnInstitute.ClientID%>').value, 750, 350, null);
            }
        }


        function FuncReOpen(lblRemarkidValue, lblAddnlRemark) {
            debugger;
            var ModuleID = document.getElementById('<%=hdnModuleId.ClientID%>').value;//Added by sanoj 17032023
            document.getElementById('myModalReOpenCFR').style.display = 'block';
            //$find("myModalReOpenCFR").show();
            document.getElementById("IframeReOpenCFR").src = "../../../Application/ISys/Recruit/PopReOpenCFR.aspx?RemarkId=" + lblRemarkidValue + "&Remarks=" + lblAddnlRemark + "&ModuleID=" + ModuleID + "&mdlpopup=myModalReOpenCFR";
        }

        function funcShowPopup(strPopUpType) // To populate popup of exam centre
        {
            if (strPopUpType == "RaiseCFR") {
                debugger;
                if (document.getElementById('<%=TxtTrnsfrReqNo.ClientID %>') != null) {
                    $find("MdlPopRaiseCFR").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopRaiseCFR.aspx?CndNo=" +
                        document.getElementById('<%=hdnCndNo.ClientID%>').value + "&UserId=" + document.getElementById('<%=hdnUserId.ClientID%>').value + "&args1=" +
                        document.getElementById('<%=BtnApprove.ClientID%>').id + "&args2=" + document.getElementById('<%=BtnCFR.ClientID%>').id + "&args3=" +
                        document.getElementById('<%=lblpanelheader.ClientID%>').innerHTML + "&args4=" +
                        document.getElementById('<%=hdnDocId.ClientID%>').value + "&args5=" +
                        document.getElementById('<%=hdnDocCode.ClientID%>').value + "&raised=" +
                        document.getElementById('<%=lblcfrrais1count.ClientID%>').id + "&responded=" +
                        document.getElementById('<%=lblcfrrespondcount.ClientID%>').id + "&closed=" +
                        document.getElementById('<%=lblcfrclosed.ClientID%>').id + "&TransfrReqNo=" + document.getElementById('<%=TxtTrnsfrReqNo.ClientID%>').value + "&FlagCode=Trnsfr" + "&mdlpopup=MdlPopRaiseCFR";
                }
                else {
                    $find("MdlPopRaiseCFR").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopRaiseCFR.aspx?CndNo=" +
                        document.getElementById('<%=hdnCndNo.ClientID%>').value + "&UserId=" + document.getElementById('<%=hdnUserId.ClientID%>').value + "&args1=" +
                        document.getElementById('<%=BtnApprove.ClientID%>').id + "&args2=" + document.getElementById('<%=BtnCFR.ClientID%>').id + "&args3=" +
                        document.getElementById('<%=lblpanelheader.ClientID%>').innerHTML + "&args4=" +
                        document.getElementById('<%=hdnDocId.ClientID%>').value + "&args5=" +
                        document.getElementById('<%=hdnDocCode.ClientID%>').value + "&raised=" +
                        document.getElementById('<%=lblcfrrais1count.ClientID%>').id + "&responded=" +
                        document.getElementById('<%=lblcfrrespondcount.ClientID%>').id + "&closed=" +
                        document.getElementById('<%=lblcfrclosed.ClientID%>').id + "&FlagCode=Others" + "&mdlpopup=MdlPopRaiseCFR";
                }
            }
            if (strPopUpType == "ExmCentre") {
                debugger;
                // $("#ctl00_ContentPlaceHolder1_PnlExm").style.visibility == "visible";
                $find("MdlPopRaiseCFR").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?ExmCentre=" +
                    document.getElementById('<%=txtExmCentre.ClientID%>').value + "&field1=" + document.getElementById('<%=txtExmCentre.ClientID %>').id +
                    "&field2=" + document.getElementById('<%=hdnExmCentreCode.ClientID %>').id +
                    "&mdlpopup=MdlPopRaiseCFR";
            }

            if (strPopUpType == "NExmCentre") {
                debugger;
                $find("MdlPopRaiseCFR").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?ExmCentre=" +
                    document.getElementById('<%=txtNExmCenter.ClientID%>').value + "&field1=" + document.getElementById('<%=txtNExmCenter.ClientID %>').id +
                    "&field2=" + document.getElementById('<%=hdnNExmCenter.ClientID %>').id +
                    "&mdlpopup=MdlPopRaiseCFR";
            }
            if (strPopUpType == "ExamCentre") {
                // alert("1");
                if (document.getElementById('<%=ddlExam.ClientID %>') != null) {
                    if ((document.getElementById('<%=ddlExam.ClientID %>').value == "Select") || (document.getElementById('<%=ddlExam.ClientID %>').value == "")) {
                        alert("Please Select Exam Mode");
                        document.getElementById('<%= ddlExam.ClientID %>').focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                }
                if (document.getElementById('<%=ddlExmBody.ClientID %>') != null) {
                    if ((document.getElementById('<%=ddlExmBody.ClientID %>').value == "Select") || (document.getElementById('<%=ddlExmBody.ClientID %>').value == "")) {
                        alert("Please Select Examination Body");
                        document.getElementById('<%= ddlExmBody.ClientID %>').focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                }
                if (document.getElementById('<%=ddlpreeamlng.ClientID %>') != null) {
                    if ((document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "Select") || (document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "")) {
                        alert("Please Select Preferred Exam Language");
                        document.getElementById('<%= ddlpreeamlng.ClientID %>').focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                }


                if (document.getElementById('<%=ddlExam.ClientID %>').value == "1") {
                    alert("To Select Exam Center within 85 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                }
                else if (document.getElementById('<%=ddlExam.ClientID %>').value == "2") {
                    alert("To Select Exam Center within 100 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                }
                $find("MdlPopRaiseCFR").show();

                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?ExmCentre=" +
                    document.getElementById('<%=txtExmCentre.ClientID%>').value + "&field1=" + document.getElementById('<%=txtExmCentre.ClientID %>').id +
                    "&field2=" + document.getElementById('<%=hdnExmCentreCode.ClientID %>').id +
                    "&mdlpopup=MdlPopRaiseCFR";


            }
        }

        function funOpenPopWinTrnLocation(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "Select") {
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
        //        function ShowReqDtl(divId, btnId) {

        //            if (document.getElementById(divId).style.display == "block") {
        //                document.getElementById(divId).style.display = "none";
        //                document.getElementById(btnId).value = '+'
        //                //document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
        //            }
        //            else {
        //                document.getElementById(divId).style.display = "block";
        //                //document.getElementById(btnId).value = '-'
        //                document.getElementById(btnId).value = '-';
        //            }
        //        }
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
            debugger;
            parent.history.back();
            return false;
            //            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            //            window.parent.document.getElementById("btnReFresh").click();
            //  Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=50hrs&Status=NW&Code=Spon");
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
            if (document.getElementById('<%=ddlRenewType.ClientID%>').value == "Select") {
                alert("Insurer Type is Mandatory");
                document.getElementById('<%=ddlRenewType.ClientID%>').focus();
                return true;
            }
            else if (document.getElementById('<%=ddllyfTraining.ClientID%>').value == "Select") {
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
            alert("Please Enter Father Name");
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
    <asp:HiddenField ID="hdnCFR" runat="server" />
    <asp:HiddenField ID="hdnHt" runat="server" />
    <asp:HiddenField ID="hdnWt" runat="server" />
</asp:Content>

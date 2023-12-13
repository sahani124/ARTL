<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OVCommStupSch.aspx.cs" Inherits="form_layouts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->

<!-- Mirrored from www.keenthemes.com/preview/metronic_admin/form_layouts.html by HTTrack Website Copier/3.x [XR&CO'2010], Fri, 13 Dec 2013 18:30:46 GMT -->
<!-- Added by HTTrack --><meta http-equiv="content-type" content="text/html;charset=UTF-8" /><!-- /Added by HTTrack -->
<head>
<meta charset="utf-8"/>
<title>KMT</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<meta content="" name="description"/>
<meta content="" name="author"/>
<meta name="MobileOptimized" content="320">
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL STYLES -->
<link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2_metro.css"/>
<!-- END PAGE LEVEL SCRIPTS -->
<!-- BEGIN THEME STYLES -->
<link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/style.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/plugins.css" rel="stylesheet" type="text/css"/>
<%--<link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color"/>--%>
<link href="assets/css/custom.css" rel="stylesheet" type="text/css"/>
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="favicon.ico"/>
<script type ="text/jscript" >

  function Clear() {

        test.innerHTML = "";

        document.getElementById("DivComp").style.visibility = "hidden"
    }


    function openNewPage(obj) {

        debugger;

        //  alert(obj);

        var strobj = obj.substring(6, obj.length);

        var strTdId = "td2";

        var strhdn8 = "hdn8";

        strhdn8 = strhdn8.concat(strobj)



        strTdId = strTdId.concat(strobj)

        //   alert(strTdId);

        var strtdtext = document.getElementById(strTdId).innerText;

        var strhdcycletext = document.getElementById(strhdn8).value;



        window.open("../Saim/SaimBreakUpPage.aspx?&MemberID=" + strtdtext + "&cycle=" + strhdcycletext + "", 'DCTM',
'width=550,height=400,toolbar=no,scrollbars=yes,location=no,resizable=yes,left=150,top=150')

    }

    function viewtable(obj) {
        debugger;

        var strlenght = obj.length;
        var strLast = obj.substring(3, strlenght);
        // alert(strLast);

        //        var strTrValue = "tridhide"

        //        strTrValue = strTrValue.concat(strLast)

        //        var strtdid = "td9";

        //       // alert(strLast);

        //       strtdid = strtdid.concat(strLast);

        var strbindTd = "td"
        strbindTd = strbindTd.concat(strLast);

        // alert(strbindTd);

        var strimg = "img";
        strimg = strimg.concat(strLast);
        //var strTdtext = document.getElementById(strtdid).innerHTML;





        //var x = document.getElementById(obj).value;


        var ImagUr = document.getElementById(strimg).src;

        //alert(ImagUr);
        //  alert(obj);

        if (ImagUr == "..Saim/assets/img/PlusImages.png") {
            //document.getElementById(obj).value = "-";



            document.getElementById(obj).src = "..Saim/assets/img/MinusImages.png";

            var StrMailID = document.getElementById(obj).value


            document.getElementById(strbindTd).style.display = "block";
            document.getElementById(strbindTd).colSpan = "9";
        }

        else {
            // document.getElementById(obj).value = "+";
            document.getElementById(obj).src = "../Saim/assets/img/PlusImages.png";
            document.getElementById(strbindTd).style.display = "none";
            document.getElementById(strbindTd).colSpan = "9";
        }





    }

    function openNewPageonAmount(obj) {

        var strlenght = obj.length;
        var strLast = obj.substring(11, strlenght);

        // alert(strLast);

        var strHdn = "hdnchild9";
        strHdn = strHdn.concat(strLast);


        var strhdn2 = "hdnchild92"
        strhdn2 = strhdn2.concat(strLast);

        var strhdn3 = "hdnchild93"
        strhdn3 = strhdn3.concat(strLast);


        var strtdtext = document.getElementById(strhdn2).value;

        // alert(strtdtext);

        var strhdnText = document.getElementById(strHdn).value

        var strhdn3text = document.getElementById(strhdn3).value

        //  alert(document.getElementById("hdnchild900").value);

        window.open("../Saim/SaimBreakUpPageAmountWise.aspx?&MemberID=" + strtdtext + "&flag=" + strhdnText + "&Cycle=" + strhdn3text + "", 'DCTM',
'width=550,height=400,toolbar=no,scrollbars=yes,location=no,resizable=yes,left=150,top=150')
    }

</script>
</head>
<!-- END HEAD -->
<!-- BEGIN BODY --> 
<body class="page-header-fixed">

<!-- END HEADER -->

<!-- BEGIN CONTAINER -->

	<!-- BEGIN SIDEBAR -->
	
	<!-- END SIDEBAR -->
	<!-- BEGIN CONTENT -->
	<!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
    <form runat  ="server" >
    <div style="margin-left:20px;margin-right:20px;margin-top:20px;margin-bottom:20px;background-color:White;">
			<div class="modal fade" id="portlet-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">
							<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
							<h4 class="modal-title">Modal title</h4>
						</div>
						<div class="modal-body">
							 Widget settings form goes here
						</div>
						<div class="modal-footer">
							<button type="button" class="btn blue">Save changes</button>
							<button type="button" class="btn default" data-dismiss="modal">Close</button>
						</div>
					</div>
					<!-- /.modal-content -->
				</div>
				<!-- /.modal-dialog -->
			</div>
			<!-- /.modal -->
			<!-- BEGIN PAGE CONTENT-->
			<div class="row">
				<div class="col-md-12">
					<div class="tab-pane " id="tab_2">
								<div class="portlet box green">
									<div class="portlet-title">
										<div class="caption">
											<i class="fa fa-search"></i>Compensation results Search
										</div>
										<div class="tools">
											<a href="javascript:;" class="collapse"></a>
											<a href="javascript:;" class="remove"></a>
										</div>
									</div>
									<div class="portlet-body form">
										<!-- BEGIN FORM-->
										<form action="#" class="form-horizontal">
											<div class="form-body">
												
												<div class="row">
													<div class="col-md-6">
														<div class="form-group">
															<label class="control-label col-md-5">Compensation Code</label>
															<div class="col-md-7">
																<input type="text" class="form-control" placeholder="Compensation Code">
                                                                
    
                                                                
                                                                </div>
														</div>
													</div>
													<!--/span-->
													<div class="col-md-6">
														<div class="form-group">
															<label class="control-label col-md-5">Compensation Description</label>
															<div class="col-md-7">
																<%--<input type="text" class="form-control" placeholder="Compensation Description">--%>
                                                                <select class="form-control" id="ddlctype" runat="server"  placeholder="Compensation Type">

                                                                    <option value="0">SELECT</option>
                                                                    <option value="1">Advisor Bonus Commission</option>
                                                                    <option value="2">CDA Override Commission</option>
                                                                </select>
                                                                
                                                                
                                                                
                                                                </div>
														</div>
													</div>
													<!--/span-->
												</div>
                                                
                                                <div class="row">
													<div class="col-md-6">
														<div class="form-group">
															<label class="control-label col-md-5">Compensation Cycle </label>
															<div class="col-md-7">
															<!--	<input type="text" class="form-control" placeholder="Compensation Type">
                                                                -->
                                                                
                                                                
<select class="form-control" runat="server" id="ddlMonth" onchange="Clear();" placeholder="Compensation Type">

<option value="0">SELECT</option>

<option value="1">APRIL 2014</option>
<option value="2">MAY 2014</option>
<option value="3">JUNE 2014</option>
<option value="4">JULY 2014</option>
<option value="5">AUGUST 2014</option>
<option value="6">SEPTEMBER 2014</option>
<option value="7">OCTOBER 2014</option>
<option value="8">NOVEMBER 2014</option>
<option value="9">DECEMBER 2014</option>
<option value="10">JANUARY 2015</option>
<option value="11">FEBRUARY 2015</option>
<option value="12">MARCH 2015</option>

</select>
                                                </div>
														</div>
													</div>
													<!--/span-->
													<div class="col-md-6">
														<div class="form-group">
															<label class="control-label col-md-5">Override Comm Type</label>
															<div class="col-md-7">
															<!--	<input type="text" class="form-control" placeholder="Status">-->
                                                                <select class="form-control">
                                                                    <option value="0">SELECT</option>
                                                                    <option value="1">DIRECT OVERRIDE COMMISSION</option>
                                                                    <option value="2">INDIRECT OVERRIDE COMMISSION</option>
                                                                    <option value="2">DIRECT & INDIRECT</option>
                                                                </select>         
                                                                </div>
														</div>
													</div>
											</div>
											<div class="form-actions fluid">
												<div class="row">
													<div align="center">
														<div>
															<asp:Button  ID="Button1" runat="server"  onclick="Button1_Click" Text="Search" 
                                                                CssClass="btn default" />
															<button type="button" class="btn default">Clear</button>
															<button type="button" class="btn default">Cancel</button>
														</div>
													</div>
													<div class="col-md-6">
													</div>
												</div>
											</div>
										</form>
										<!-- END FORM-->
									</div>
								</div>
							</div>
				</div>
                <div class="row" id='DivComp' visible="false" runat="server">
				<div class="col-md-12">
					<!-- BEGIN EXAMPLE TABLE PORTLET-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-search"></i>Contestant Search Results
						  </div>
							<div class="tools">
                                <a href="javascript:;" class="collapse"></a>
								<a href="javascript:;" class="reload"></a>
								<a href="javascript:;" class="remove"></a>
							</div>
						</div>
						<div class="portlet-body">

                           <div class="portlet-body" id ="test" runat="server">
                            
                            
                            </div>
						<%--	<table width="100%" cellpadding="0" cellspacing="0" class="table table-striped table-bordered table-hover" id="sample_1">
							<thead>
							<tr >
								<th>Member Code</th>
								<th>Short Code</th>
								<th>Member Name</th>
								<th>Member Type</th>
								<th>Cycle</th>
								<th>Effective From</th>
								<th>Effective To</th>
                                <th>Break-up</th>
							</tr>
							</thead>
							<tbody>
							<tr>
								<td>50000150</td>
								<td>F0156</td>
								<td>Ajay Sharma</td>
								<td align="center">Elite CDA</td>
								<td align="center">Nov-14</td>
								<td align="center">01/11/2014</td>
								<td align="center">30/11/2014</td>
                                <td align="center"><a>View Details</a></td>
							</tr>
                            <tr>
								<td>50000180</td>
								<td>F0186</td>
								<td>Birendra Bhadra</td>
								<td align="center">Rookie CDA</td>
								<td align="center">Nov-14</td>
								<td align="center">01/11/2014</td>
								<td align="center">30/11/2014</td>
                                <td align="center"><a>View Details</a></td>
							</tr>
	
							</tbody>
							</table>--%>
						</div>
					</div>
					<!-- END EXAMPLE TABLE PORTLET-->
				</div>
			</div>
			</div>
	<!-- END CONTENT -->

<!-- END CONTAINER -->
<!-- BEGIN FOOTER -->
<div class="footer">
	<div class="footer-inner">
		 2013 &copy; Metronic by keenthemes.
	</div>
	<div class="footer-tools">
		<span class="go-top">
			<i class="fa fa-angle-up"></i>
		</span>
	</div>
</div>
</div>
</form>
<!-- END FOOTER -->
<!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
<!-- BEGIN CORE PLUGINS -->
<!--[if lt IE 9]>
<script src="assets/plugins/respond.min.js"></script>
<script src="assets/plugins/excanvas.min.js"></script> 
<![endif]-->
<script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
<script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
<!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
<script src="assets/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
<script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="assets/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
<script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
<script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
<script src="assets/plugins/jquery.cokie.min.js" type="text/javascript"></script>
<script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
<!-- END CORE PLUGINS -->
<!-- BEGIN PAGE LEVEL PLUGINS -->
<script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="assets/scripts/app.js"></script>
<script src="assets/scripts/form-samples.js"></script>
<!-- END PAGE LEVEL SCRIPTS -->
<!-- BEGIN PAGE LEVEL PLUGINS -->
<script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="assets/plugins/data-tables/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="assets/plugins/data-tables/DT_bootstrap.js"></script>
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="assets/scripts/app.js"></script>
<script src="assets/scripts/table-advanced.js"></script>
<script>
    jQuery(document).ready(function () {
        App.init();
        TableAdvanced.init();
    });
</script>

<!-- END JAVASCRIPTS -->
<script type="text/javascript">    var _gaq = _gaq || []; _gaq.push(['_setAccount', 'UA-37564768-1']); _gaq.push(['_setDomainName', 'keenthemes.com']); _gaq.push(['_setAllowLinker', true]); _gaq.push(['_trackPageview']); (function () { var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true; ga.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'stats.g.doubleclick.net/dc.js'; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s); })();</script></body>
<!-- END BODY -->

<!-- Mirrored from www.keenthemes.com/preview/metronic_admin/form_layouts.html by HTTrack Website Copier/3.x [XR&CO'2010], Fri, 13 Dec 2013 18:30:47 GMT -->
<!-- Added by HTTrack --><meta http-equiv="content-type" content="text/html;charset=UTF-8" /><!-- /Added by HTTrack -->
</html>
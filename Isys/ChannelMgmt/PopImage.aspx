<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopImage.aspx.cs" Inherits="PopImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

      <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
   <%-- <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />--%>
<%--<link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" />
<link href="../../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />
<script src="../../../Scripts/JQuery/jquery-1.10.2.min.js"></script>
<script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js"></script>
<script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/bootstrap.min.js"></script>
<link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />--%>


 <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js"
        type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css"
        rel="stylesheet" type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
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
<script language="javascript" type="text/javascript">
   
    function doCancel() {
        window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        //var image = document.getElementById('<%=hdnimg.ClientID%>').value;
        //img = image;
    }
    function doCancel2() {
        debugger;
         var parentDivPopup = window.parent.document.getElementById('divPopup');
        if (parentDivPopup) {
                GetBytes(document.getElementById('txtAgntCode').value);
                parentDivPopup.style.display = 'none';
            }
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
    window.addEventListener('load', function () {
        var Flagval = GetQueryStringValue(window.location, 'Flag');
        if (Flagval == 'Heirarchy') {
            var elements = document.getElementsByClassName('panel');

            for (var i = 0; i < elements.length; i++) {
                elements[i].style.marginTop = '200px';
            }
        }
        else {
             var elements = document.getElementsByClassName('panel');

            for (var i = 0; i < elements.length; i++) {
                elements[i].style.marginTop = '15px';
            }
        }
    
    });

    function GetBytes(Memcode) {
                    var object = {}
                    var dataObj = [];
                    object["Memcode"] = Memcode;
                    dataObj.push(object);
                    sendObj = {
                        data: (dataObj)
                    }
                    //debugger;
                    $.ajax({
                        type: "POST",
                        url: "PopImage.aspx/GetBytes",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(sendObj),
                        dataType: "json",
                        success: function (_data2) {
                            debugger;
                            bytesUrl = _data2.d;
                            var getELEMENT =window.parent.document.getElementById(Memcode); //document.getElementById(Memcode);
                            //debugger;
                            if (bytesUrl != null || bytesUrl != '') {
                                getELEMENT.setAttribute('href', bytesUrl);
                            }
                        },
                        failure: function (response) {
                            debugger;
                            alert("Something went wrong.");
                        }
                    });
        }

    function GetQueryStringValue(url, param) {            debugger;    param = param.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");    var regVal = new RegExp("[\\?&]" + param + "=([^&#]*)"),    results = regVal.exec(url);    return results === null ? null : decodeURIComponent((results[1]).replace(/\+/g, " "));}
</script>
<head runat="server">
    <title></title>
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptMgr" runat="server" />

        <div class="panel card" >
                <div id="divimg" runat="server" class="panel-heading"  onclick="ShowReqDtl1('Div2','btnpersnl');return false;">           
                          <div class="row">
                    <div class="col-xs-10" style="text-align:left" >
                        <span style="color: #034ea2; font-size:19px">Image Upload</span>
                    </div>
                    <div class="col-xs-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>    


                 <div id="Div2" runat="server" style="display: block;" class="panel-body">
           
                      <div class="col-xs-3" style="text-align:left; margin-bottom: 5px">
                    <asp:Label ID="lvlVw1AgntCode" CssClass="control-label" runat="server" ></asp:Label>
                            </div>
                      <div class="col-sm-3" style="margin-bottom:5px;">
                           
                    <asp:TextBox ID="txtAgntCode" runat="server" CssClass="form-control" Width="270px"></asp:TextBox>
                            </div>
                    <div class="col-xs-3" style="text-align:left; margin-bottom: 5px">
                        
                    <asp:Label ID="lblImageFile" runat="server" CssClass="control-label"  Text="Image File"></asp:Label>
                            </div>
                          <div class="col-sm-3" style="margin-bottom:5px;">
                          
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" Width="270px"/>
                              <br/>
                    <asp:Label ID="lblimgsize" runat="server" Text="Maximum Size 200KB" style="margin-left:155px" ForeColor="Red"></asp:Label>
                          </div>
                                
                            
                   
                    <div class="row" style="margin-top:12px;">
                    <div class="col-sm-12" align="center">


                         <asp:LinkButton ID="btnUpload" runat="server" CssClass="btn btn-sample" 
                                 Text="Upload Photo"  OnClick="btnUpload_Click"  >
                         <span class="glyphicon glyphicon-upload" style='color:White;'></span> Upload Photo
                        </asp:LinkButton>  
               
                       <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" 
                               OnClick="btnCancel_Click">
                              <span class="glyphicon glyphicon-remove"> </span> Cancel
                             </asp:LinkButton> 
                         <asp:Label ID="lblmessage" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>

                             </div>

                             </div>

                    </div>

            
        

            </div>
                   
        <asp:HiddenField ID="hdnimg" runat="server" />
    </form>
</body>
</html>

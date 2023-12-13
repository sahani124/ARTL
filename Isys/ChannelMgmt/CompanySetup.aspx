<%--Creator:		< Rajkapoor Yadav> 
Create date:        <15th Sep 2021>
Description:	    <This page is created for seting up a company in the Hierarchy system, originally this page was part of channel setup.>
Reviewed by:        Abhay & Arjun Aroskar 
--%>



<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanySetup.aspx.cs" Inherits="INSCL.CompanySetup"
    MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />

    <link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
   <%-- <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
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

    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script lang="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script lang="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
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
    
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script lang="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script lang="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>--%>

    <script>
        function closePopUp() {
            document.getElementById('myModal').style.display = 'none';

        }
        function yourAjaxFunction() {
    var gststatecode = document.getElementById("ctl00_ContentPlaceHolder1_txtgststcode").value;

    $.ajax({
        type: "POST",
        url: "CompanySetup.aspx/GetData",
        data: JSON.stringify({ gststatecode: gststatecode }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            debugger;
            // Handle the response from the server here
            console.log(response.d); // Assuming the response is in JSON format
            if (response.d == '1') {
                alert('Please enter valid state code.');
                document.getElementById("ctl00_ContentPlaceHolder1_txtgststcode").value = '';
                return false;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_txtgstpan").focus();
                return false;
            }
        },
        error: function (xhr, status, error) {
            // Handle the error if the AJAX call fails
            console.log(error);
        }
    });
}

        function loadGst() {
             debugger;

             //Loader('DivSubChnl','DivSubChnl1');
             var gststatecode = document.getElementById("ctl00_ContentPlaceHolder1_txtgststcode").value;
             if (gststatecode.length == '2') {
                 yourAjaxFunction();
             }
            //Loader('DivSubChnl','DivSubChnl1');
        }

        function gstpankey() {
            gstpan = document.getElementById("ctl00_ContentPlaceHolder1_txtgstpan").value.toUpperCase();
            if (gstpan.length == '10') {
                debugger;
                if (CheckPANFormat(gstpan) == 0) {
                    alert("Please enter valid PAN format.");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtgstpan").value = '';
                    return false;
                } else {
                    document.getElementById("ctl00_ContentPlaceHolder1_txtgstothr").focus();
                }
            }
        }

        function Othrdkey() {
            debugger;
        var othrval = document.getElementById("ctl00_ContentPlaceHolder1_txtgstothr").value.toUpperCase();
        //if (othrval.length == "2") {
                var result = true;
            var pan = othrval.split(",");
            var Char;
            var pan2 = pan[0];
            for (j = 0; j < pan2.length && result == true; j++) {
                Char = pan2.substring(j, j + 1);
                if (j == '0') {
                    if (!isAlphaNumeric(Char)) {
                        alert('Please enter a number (0-9) or a letter (A-Z) at a first digit.');
                        document.getElementById("ctl00_ContentPlaceHolder1_txtgstothr").value = '';
                        return false;
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_txtgstothr").focus();
                }
                if (j == "1") {
                    if (Char != 'Z') {
                        alert('Please enter Z at second digit.');
                        document.getElementById("ctl00_ContentPlaceHolder1_txtgstothr").value = '';
                        return false;
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_txtgstothr").focus();
                }
                if (j == "2") {
                    if (!IsNumeric(Char)) {
                        alert('Please enter  a number (0-9) at last digit.');
                        document.getElementById("ctl00_ContentPlaceHolder1_txtgstothr").value = '';
                        return false;
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_txtRegCin").focus();
                }
            }
            
        }

            function isAlphaNumeric(char) {
          // Regular expression to match alphanumeric characters
          var alphanumericRegex = /^[0-9a-zA-Z]+$/;

          // Test if the character matches the regular expression
          return alphanumericRegex.test(char);
        }


    </script>


    <script type="text/javascript">

        //function LdWait(delay) {
        //    debugger;
        //    document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'block';
        //    setTimeout("RemoveLoading12()", delay);
        //    //$find("mdlViewBIDLOB").show();
        //    funPopUp();
        //}

        //function RemoveLoading12() {
        //    document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'none';
        //}

        function funPopUp() {
            debugger;
            var start = document.getElementById("ctl00_ContentPlaceHolder1_lblChannel");
            var value = start.textContent;
            //$find("mdlViewBIDLOB").show()
            //document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "PopupCompanyHistory.aspx?&Code=" + value + "&mdlpopup=mdlViewBIDLOB";

            //var value = document.getElementById('<%= lblChannel.ClientID%>').value;
            var Header = "Version History Of Company";
            var Flag = "COMPANY";
            $find("mdlViewBIDLOB").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "PopupCompanyHistory.aspx?&Code=" + value + "&mdlpopup=mdlViewBIDLOB" + "&Header=" + Header + "&Flag=" + Flag;
        }

        function funcShowPopupLOB() {
            debugger;
            $find("mdlViewBIDLOB").show();
            var prdcode = document.getElementById('<%= hdnprdcode.ClientID%>').value;
            var ProdcodeEdit = document.getElementById('<%= hdnProdcodeEdit.ClientID%>').value;
            var Chntype = document.getElementById('<%= hdnChntype.ClientID%>').value;
            if (document.getElementById('ctl00_ContentPlaceHolder1_lblChannel') != null) {
                var Bizsrc = document.getElementById('ctl00_ContentPlaceHolder1_lblChannel').innerText;
            }
            else { var Bizsrc = ""; }
            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "../../../Application/ISys/ChannelMgmt/LOBDtls.aspx?mdlpopup=" + 'MdlPopExtndrLOB' + "&hdnprodcode=" + prdcode + "&Flag=" + ProdcodeEdit + "&Bizsrc=" + Bizsrc + "&ChnType=" + Chntype;
        }

        function funcShowPopupCease(lnk) {
            debugger;
            var row = lnk.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            var Prodcode = row.cells[0].innerText;
            var prodName = row.cells[1].innerText;
            var Effdate = row.cells[2].innerText;
            var Mdlpnlcease = "Mdlpnlcease";
            $find("mdlViewBIDCease").show();
            //  document.getElementById("ctl00_ContentPlaceHolder1_Ifrmcease").src = "../../../Application/ISys/ChannelMgmt/CeaseDtls.aspx?&mdlpopup=Mdlpnlcease";
            document.getElementById("ctl00_ContentPlaceHolder1_Ifrmcease").src = "../../../Application/ISys/ChannelMgmt/CeaseDtls.aspx?mdlpopup=" + 'Mdlpnlcease' + "&Productcode=" + Prodcode + "&ProductName= " + prodName + "&Effectivedate=" + Effdate;
            return false;
        }


        function showPopup() {
            var some_html = '<div style="font-size:10.0pt;font-family:Calibri,sans-serif;color:black;"><p>The maximum score for each pair of questions is 3,total for question A and question B is 3, for example</p><ul><li>If A is very characteristic of you and B is very uncharacteristic, write ‘3’ next to A and ‘0’ next to B. </li><li>If B is very characteristic of you and A is very uncharacteristic, write ‘3’ next to B and ‘0’ next to A. </li><li>If A is somewhat characteristic of you and B is less characteristic, write ‘2’ next to A and ‘1’ next to B. </li><li>If B is somewhat characteristic of you and A is less characteristic, write ‘2’ next to B and ‘1’ next to A </li></ul></div>';
            bootbox.alert(some_html);
            return false;
        }
        //added by babita 
        function Adddiv(Name,flag,ab) {
            debugger;
            var arr = Name.split(",");
            var abc = ab.split(",")
			if (document.getElementById("ctl00_ContentPlaceHolder1_addtablename").style.display == 'none') {
				document.getElementById("ctl00_ContentPlaceHolder1_addtablename").style.display = 'block';
			}
			if (flag == "S") {
				//divisvisible('');
                var html;
                for (var i = 0; i < arr.length; i++) {
                    //html = "<div class='divspecial'>" + Name;
                    for (var j =0 ; j <= i; j++) {
                        if (abc[j]== "Y") {
                            html = "<div  class='divspecial' style='background-color: #90EE90'>" + arr[i] + "</div>";
                        }
                        else {
                            html = "<div class='divspecial'>" + arr[i];
                        }

                    }
                    //html += "<asp:LinkButton ID='lnk" + ID +  "OnClick='deletediv("+ ID +");'>";
                    //html += "<a onclick='deletediv(" + ID + "," + KPI_CODE + ")'; id='lnk" + ID + "'>";
                    //html += "<span class='glyphicon glyphicon-remove' style='color:black'></span>";
                    //html += "</asp:LinkButton>";
                    //html += "</a>";
                    html += "</div>";
                    //document.getElementById("ctl00_ContentPlaceHolder1_Div38").innerHTML += "<div Id='div"+ID+"' class='divspecial'>" + Name + "</div>";

                    document.getElementById("ctl00_ContentPlaceHolder1_addtablename").innerHTML += html;
                }
			}
			else {
				var myArray = JSON.parse(Name);
				for (var i = 0; i < myArray.length; i++) {
					var obj = myArray[i];
					//console.log("Name: " + obj.name + ", Age: " + obj.age);
					var html;
					html = "<div Id='div" + obj.OBJ_ID + "' class='divspecial'>" + obj.TBL_NAME;
					//html += "<asp:LinkButton ID='lnk" + ID +  "OnClick='deletediv("+ ID +");'>";
					if (obj.Flag == "0") {
						//html += "<a onclick='deletediv(" + obj.OBJ_ID + "," + KPI_CODE + ")'; id='lnk" + ID + "'>";
						html += "<span class='glyphicon glyphicon-remove' style='color:black'></span>";
						//html += "</asp:LinkButton>";
						html += "</a>";
					}
					html += "</div>";
					//document.getElementById("ctl00_ContentPlaceHolder1_Div38").innerHTML += "<div Id='div"+ID+"' class='divspecial'>" + Name + "</div>";

					document.getElementById("ctl00_ContentPlaceHolder1_addtablename").innerHTML += html;
				}
				//document.getElementById("ctl00_ContentPlaceHolder1_Div38").innerHTML += myArray;
			}
		}
        //ended by babita

    </script>


    <script lang="javascript" type="text/javascript">
        function popup() {
            debugger;
            document.getElementById("myModal").style.display = 'block';
            //$("#myModal").modal();
        }

        function popuptest() {
            debugger
            $("#exampleModal").modal();
            return false;
        }

        function popupHist() {
            debugger
            $("#myModal1").modal();
        }

        $(function () {
            debugger;

            //$("#<%= txtEffDate.ClientID  %>").datepicker({ minDate: '0', dateFormat: 'dd/mm/yy' }); //changed by sanoj 23052023 minDate: 0
            $("#<%= txtEffDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' }); //changed by pallavi on 11072023 
            $("#<%= txtCseDt.ClientID  %>").datepicker({ maxDate: '31/03/2024', minDate: '-0d', dateFormat: 'dd/mm/yy' });  //changed by sanoj 23052023 maxDate: '31/03/2024'
            $("#<%= txtCseDt1.ClientID  %>").datepicker({ maxDate: '31/03/2022', minDate: '-0d', dateFormat: 'dd/mm/yy' });
            //$("#<%= txtIncorporation.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtIncorporation.ClientID  %>").datepicker({ minDate: '01/04/2021', maxDate: '-0d', dateFormat: 'dd/mm/yy' });
        });

        //function ShowReqDtl(divName, btnName) {
        //    //debugger;
        //    var objnewdiv = document.getElementById(divName);
        //    var objnewbtn = document.getElementById(btnName);

        //    if (objnewdiv.style.display == "block") {
        //        objnewdiv.style.display = "none";
        //    }
        //    else {
        //        objnewdiv.style.display = "block";
        //    }
        //}

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

        function doValidateName(src, args) {
            var result = true;
            var sString = args.Value;
            sString = document.getElementById("ctl00_ContentPlaceHolder1_txtChannel").value;

            var iChars = "#%!@&$^*_+={}[]|\:;?><,.'~";

            for (var i = 0; i < sString.length; i++) {
                if (iChars.indexOf(sString.charAt(i)) != -1) {
                    result = false;
                }
            }

            args.IsValid = result;
        }

        function isInteger1(src, args) {
            var str = document.getElementById("ctl00_ContentPlaceHolder1_txtChannel").getAttribute("value");
            var result = true;
            for (i = 0; i <= 99; i++) {
                if (i == str) {
                    result = false;
                }
                args.IsValid = result;
            }
        }

        function isNumber(evt) {
            var textBox = document.getElementById("myTextBox");
            var textLength = textBox.value.length
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                if (textLength > 2)
                    return false;
            }
            return true;
        }
        function isInteger(src, args) {
            //var str = document.getElementById("ctl00_ContentPlaceHolder1_txtSortorder").getAttribute("value"); Added by swapnesh on 15/5/2013 to remove getAttribute function
            var str = document.getElementById("ctl00_ContentPlaceHolder1_txtSortorder").value;
            var result = true;
            if (str.charAt(0) == "-" || str.charAt(0) == "+")
                i = 1;
            else
                i = 0;
            for (; i < str.length; i++) {
                ch = str.charAt(i);
                if (ch < "0" || ch > "9") {
                    result = false;
                }
                args.IsValid = result;
            }
        }

        function isIntegerNumbers(src, args) {
            var result = false;
            var str = document.getElementById("ctl00_ContentPlaceHolder1_txtSortorder").value;
            if (str >= 0 && str <= 120) {
                result = true;
            }
            else {
                result = false;
            }
            args.IsValid = result;
        }

        function queryString(key) {
            strFunctionName = "queryString";
            var page = new PageQuery(window.location.search);
            return unescape(page.getValue(key));
        }

        function PageQuery(q) {
            strFunctionName = "PageQuery";
            if (q.length > 1)
                this.q = q.substring(1, q.length);
            else
                this.q = null;
            this.keyValuePairs = new Array();
            if (q) {
                for (var i = 0; i < this.q.split("&").length; i++) {
                    this.keyValuePairs[i] = this.q.split("&")[i];
                }
            }

            this.getKeyValuePairs = function () { return this.keyValuePairs; }

            this.getValue = function (s) {
                for (var j = 0; j < this.keyValuePairs.length; j++) {
                    if (this.keyValuePairs[j].split("=")[0] == s)
                        return this.keyValuePairs[j].split("=")[1];
                }
                return false;
            }
            this.getParameters = function () {
                var a = new Array(this.getLength());
                for (var j = 0; j < this.keyValuePairs.length; j++) {
                    a[j] = this.keyValuePairs[j].split("=")[0];
                }
                return a;
            }
            this.getLength = function () { return this.keyValuePairs.length; }
        }

        function done() {
            var chnTyp = queryString("ChnTyp");
            if (chnTyp == 'C') {
                window.location.href = "ChannelMas.aspx";
            }
            else if (chnTyp == 'O') {
                window.location.href = "CompanyMaster.aspx";
            }
            return false;
        }

        function cancel(flag, chnTyp) {

            if (flag == 'V') {
                if (window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>') != null) {
                    window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
                }
            }
            else if (chnTyp == 'C') {
                window.location.href = "ChannelMas.aspx";
            }
            else if (chnTyp == 'O') {
                window.location.href = "CompanyMaster.aspx";
            }
        }

        function validate() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + "txtChannel") != null) {
                if (document.getElementById(strContent + "txtChannel").value == "") {
                    alert("Please Enter Company Code");
                    document.getElementById(strContent + "txtChannel").focus();
                    //var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtDesc1").value == "") {
                alert("Please Enter Company Description 1");
                document.getElementById(strContent + "txtDesc1").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //if (document.getElementById(strContent + "txtSortorder").value == "") {
            //    alert("Please Enter Sort Order");
            //    document.getElementById(strContent + "txtSortorder").focus();
            //    return false;
            //}

            if (document.getElementById(strContent + "txtEffDate") != null) {
                if (document.getElementById(strContent + "txtEffDate").value == "") {
                    alert("Please Enter Effective Date");
                    document.getElementById(strContent + "txtEffDate").focus();
                    return false;
                }
            }

        }

    </script>

    <%--added by babita--%>
    <style>
        
        .divspecial {
  background-color: #FFCCCB;
  border: none;
  color: black;
  padding: 10px 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  margin: 4px 2px;
  /*cursor: pointer;*/
  border-radius: 16px;
}

         
    </style>

    <%--Ended by babita--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <center>
        <table width="70%">
            <tr>
                <td align="center">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text=" " Width="286px" Visible="false" Font-Bold="False"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
    <center>
                    <div class="card PanelInsideTab_body" id="divModification" runat="server">
                  <div id="Div18" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divmodifybody','btndivmodify');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
         <asp:Label ID="lblCompany" runat="server" Text="CORRECTION OR CHANGES IN COMPANY SETUP"   CssClass="control-label HeaderColor"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="btndivmodify" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>         
           </div>
               <div id="divmodifybody" runat="server" class="panel-body panelContent" style="display:block">
               <div class="row rowspacing" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left;margin-top: 10px;">
                        <asp:Label ID="lblModMode" runat="server" Text="Mod Mode" CssClass="control-label" /> 
                        <span style="color: #ff0000"> *</span>
                        </div>
                         <div class="col-md-3" style="text-align:left"  >
                        <div class="btn-group"  role="group" style="margin-left: -162px;">
                        <asp:RadioButtonList  ID="rbCorrection" runat="server"  CellPadding="2" CellSpacing="2"  RepeatDirection="Horizontal"  AutoPostBack="true" 
                     OnSelectedIndexChanged="rbCorrection_OnSelectedIndexChanged">
                        <asp:ListItem Text="&nbspCorrection&nbsp" selected="True" value="CR"  class="btn btn-default"  />
                        <asp:ListItem Text="&nbspChanges&nbsp"  value="CH"  class="btn btn-default" style="margin-left: 0px;"  />
                     </asp:RadioButtonList>
                    </div>
                       </div>
                        <div class="col-md-3">
                     </div>
                      <div class="col-md-3">
                     </div>
                  </div>
                </div>
            </div>

            <div class="panel-body panelContent" id="divcmphdrcollapse" runat="server" style="margin-left: 2%; margin-right: 2%;">

                <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmphdr','btndivcmphdr');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblslsHead" runat="server" Text="COMPANY SETUP"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="btndivcmphdr" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>         
           </div>
                <div id="divcmphdr" runat="server" class="panel-body panelContent" style="display:block"> 
                   <div class="row" style="margin-bottom:5px;">
               <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblSaleschannel" runat="server" CssClass="control-label" /> 
                                        <span style="color: #ff0000"> *</span>
                     </div>
              <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblChannel" runat="server" Visible="False" CssClass="control-label"></asp:Label>
                                                <ajax:UpdatePanel runat="server">
                                  <ContentTemplate>
                                        <asp:TextBox ID="txtChannel" runat="server" Visible="False" OnTextChanged="txtChannel_TextChanged" AutoPostBack="true" CssClass="form-control" TabIndex="1"
                                             MaxLength="2" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                    
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtChannelFTX" runat="server" TargetControlID="txtChannel"
                                            FilterType="Custom, LowercaseLetters, UppercaseLetters">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                              </ajax:UpdatePanel>
                    </div>
                     <div class="col-md-3">
                     </div>
                      <div class="col-md-3">
                     </div>
                  </div>
                   <div class="row" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblDesc1" runat="server" CssClass="control-label"></asp:Label><span
                                            style="color: #ff0000"> *</span>
                       </div>
                        <div class="col-md-3">
                                        <asp:TextBox ID="txtDesc1" runat="server" CssClass="form-control"  TabIndex="2"
                                            MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            ValidChars=" " FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers"
                                            TargetControlID="txtDesc1">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                       </div>
                       <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblDesc2" runat="server" Height="22px" CssClass="control-label"></asp:Label>
                       </div>
                      <div class="col-md-3">
                                        <asp:TextBox ID="txtDesc2" runat="server" CssClass="form-control" MaxLength="50" TabIndex="3"
                                            onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            ValidChars=" " FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers"
                                            TargetControlID="txtDesc2">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                      </div>
                     </div>
                   <div class="row" style="margin-bottom:5px;">
                           <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblDesc3" runat="server"  CssClass="control-label"></asp:Label>
                           </div>
                      <div class="col-md-3">
                                        <asp:TextBox ID="txtDesc3" runat="server" CssClass="form-control" MaxLength="50" TabIndex="3"
                                            onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            ValidChars=" " FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers"
                                            TargetControlID="txtDesc3">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                            <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblSortorder" CssClass="control-label" runat="server" />
                                        <%--<span style="color: #ff0000"> *</span>--%>
                             </div>
                          <div class="col-md-3">
                              <ajax:UpdatePanel runat="server">
                                  <ContentTemplate>
                                     <%--  <asp:TextBox ID="txtSortorder" runat="server" CssClass="form-control" OnTextChanged="txtSortorder_TextChanged" AutoPostBack="true" MaxLength="2" TabIndex="4"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtSortorder" runat="server" CssClass="form-control" AutoPostBack="true" MaxLength="2" TabIndex="4"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtSortorderFTX"  runat="server" ValidChars="01234567890"
                                            TargetControlID="txtSortorder" FilterType="Custom,Numbers">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                  </ContentTemplate>
                              </ajax:UpdatePanel>
                                       
                          </div>
                      </div>
                       <div class="row" style="margin-bottom:5px;">
                     <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblParanetChn" Text="Parent Organization" CssClass="control-label" runat="server" />
                         </div>
                       <div class="col-md-3">
                                <asp:DropDownList ID="ddlParentChnl" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                        </div>
                     </div>
            </div>
        </div>
         <div class="card PanelInsideTab_body" id="div5" runat="server" style="display:none;margin-left: 2%; margin-right: 2%;">
            <div id="Div9" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div6','Span1');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label5" runat="server" Text="Company Setup"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                         <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>         
           </div>   
            <div id="div6" runat="server" class="panel-body" style="display:block">
                <div class="row" style="margin-bottom: 10px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label2" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-9" style="text-align: center">
                          <asp:Label ID="Label1" runat="server" CssClass="control-label" ForeColor="Blue" ></asp:Label>
                    </div>
                   </div> 
                
                <div class="row" style="margin-top: 10px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label4" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                      <div class="col-sm-9" style="text-align:center">
                        <asp:Label ID="lblDesc" runat="server" CssClass="control-label" ForeColor="Blue" ></asp:Label>
                    </div>
                    </div>
                    <div class="row" style="margin-top: 10px;">
                    <div class="col-sm-3" style="text-align: left;">
                        <asp:Label ID="Label6" runat="server" Height="22px" CssClass="control-label"></asp:Label>
                     </div>
                     <div class="col-sm-9" style="text-align: center">
                     <asp:Label ID="lblDesc22" runat="server" CssClass="control-label" ForeColor="Blue" ></asp:Label>
                    </div>
                   </div>
                <div class="row" style="margin-bottom: 3px;">
                    <div class="col-sm-3" style="text-align: left; margin-top:5px;">
                        <asp:Label ID="Label8" runat="server" Height="22px" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-sm-9" style="text-align: center; margin-top:5px;">
                        <asp:Label ID="lblDesc33" runat="server" CssClass="control-label" ForeColor="Blue"></asp:Label>
                    </div>
                 </div>
                 <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left;">
                        <asp:Label ID="Label10" CssClass="control-label" runat="server" />
                    </div>
                    <div class="col-sm-9" style="text-align: center;">
                        <asp:Label ID="lblSortorder1" runat="server" CssClass="control-label" ForeColor="Blue"></asp:Label>
                    </div>
                   </div>
                </div>
            </div>
          <div class="card PanelInsideTab_body" id="div13" runat="server" style="display:none;margin-left: 2%; margin-right: 2%;">
              <div id="Div14" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div15','Span3');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label7" runat="server" Text="ADDITIONAL DETAILS" CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="Span3" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 
        </div>

          <div id="div15" runat="server" class="panel-body" style="display:block"> 
           <div class="row">
               <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="Label9" CssClass="control-label" Text="Company Name" runat="server" /> 
                 </div>
                 <div class="col-sm-9" style="text-align:center">
                                        <asp:Label ID="CompanyNamePop" runat="server" CssClass="control-label" 
                                            ForeColor="Blue" />                                                                                 
                    </div>
           </div>
                     <div class="row">
                                      <div class="col-sm-3" style="text-align:left;margin-top:10px;">
                                        <asp:Label ID="Label14" CssClass="control-label" Text="Insurer Type" runat="server" />
                                        
                                        </div>
                          <div class="col-sm-9" style="text-align:center;margin-top:10px;"> 
                                        <asp:Label ID="DropDownListPop" runat="server" CssClass="control-label" 
                                            ForeColor="Blue" />                                      
                     </div>

            </div>                           
             <div class="row" style="margin-top:10px;">
                 <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="Label16" CssClass="control-label" Text="Year of incorporation" runat="server" />
                    </div>
                    <div class="col-sm-9" style="text-align:center">
                                       <asp:Label ID="YrOfIncPop" runat="server" CssClass="control-label" ForeColor="Blue"/>                                     
                    </div>
              </div>
              <div class="row" style="margin-top:10px;">
                     <div class="col-sm-3" style="text-align:left;">
                                        <asp:Label ID="Label18" CssClass="control-label" Text="IRDAI License Number" runat="server" />
                     </div>
                     <div class="col-sm-9" style="text-align:center;">
                                        <asp:Label ID="IrdaLcnPop" runat="server" CssClass="control-label" ForeColor="Blue"/>                                  
                    </div>
             </div>
                <div class="row" style="margin-bottom:5px;margin-top:10px;">
                  <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="Label20" CssClass="control-label" Text="Registered Office Address" runat="server" />
                  </div>
                  <div class="col-sm-9" style="text-align:center">
                                        <asp:Label ID="RegAddrPop" runat="server" CssClass="control-label" ForeColor="Blue"/>                                      
                    </div>
                </div>
          </div>
          </div>
<%--           <br/>--%>
           <div class="card PanelInsideTab_body" id="div11" runat="server" style="margin-left: 2%; margin-right: 2%;">
              <div id="Div12" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAddDtls','btnAddsrch');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblAddDtls" runat="server" Text="COMPANY DETAILS"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="btnAddsrch" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 
        </div>

          <div id="divAddDtls" runat="server" class="panel-body" style="display:block"> 
           <div class="row" style="margin-bottom:5px;">
               <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblcomp" CssClass="control-label" Text="Company Name" runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtComp" runat="server" CssClass="form-control"  TabIndex="5"/>
                    </div>
               <div  class="col-sm-3"  style="text-align:left"  >
                                                    <asp:Label ID="lblinsurance"  Text ="Insurer Type" runat="server" CssClass="control-label"></asp:Label> 
                                                </div>
               <div class="col-sm-3">
                                        <asp:DropDownList id="ddlinsurance" runat="server" CssClass="form-control"  TabIndex="6"></asp:DropDownList>
                                         </div>
           </div>
             <div class="row" style="margin-bottom:5px;">
                 <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="Label11" CssClass="control-label" Text="Date of Incorporation" runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtIncorporation" runat="server" CssClass="form-control" TabIndex="7" style="background-color:white !important"/>
                                       
                    </div>
                     <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lbllcn" CssClass="control-label" Text="IRDAI License Number" runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtIrdaLcn" runat="server" CssClass="form-control" TabIndex="8" />
                    </div>
             </div>

              <div class="row" id="hideonChnl" runat="server" > 
                    <div class="col-md-3" style="text-align:left">
                          <asp:Label ID="Label22" text="Business Year: " runat="server" CssClass="control-label" /> 
                  </div>
                    <div class="col-md-3" >
                    <asp:RadioButtonList ID="rdoBusiYr" runat="server" CellPadding="2" CellSpacing="2"
                                    RepeatDirection="Horizontal" >
                                    <asp:ListItem Text="&nbspApril to March&nbsp&nbsp&nbsp&nbsp" Value="0">  </asp:ListItem>
                                    <asp:ListItem Text="&nbspJanuary to December&nbsp&nbsp" Value="1"></asp:ListItem>
                                </asp:RadioButtonList>
                   </div>
                   <div class="col-md-3">  
                          <asp:Label ID="lblnew" Text="Freeze Business Date:" runat="server" CssClass="control-label" style="margin-left: -152px;"/>
                           </div>
                        <div class="col-md-1">  

                        <asp:CheckBox ID="CheckBox1"  style="margin-left: -407px;margin-top: 2px;"     runat="server" Text="" /> 

                        </div>

                    <div class="col-md-2">   
                     <asp:TextBox ID="txtCseDt1"  style="width: 283px;margin-left: -104px;background-color:white !important" runat="server" Enabled="true" CssClass="form-control" TabIndex="13"  />  
                  </div>
                  </div>
                <div class="row" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblPhoneNo" CssClass="control-label" Text="Phone No." runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control" TabIndex="8" />
                    </div>

                
                  <div class="col-md-3" style="text-align:left;">
                                        <asp:Label ID="Label26" CssClass="control-label" Text="Upload Logo" runat="server" />
                    </div>
               <div class="col-md-3" >
                   <div class="row">
                   <div class="col-md-12" style="text-align:left;">
                                        <asp:Image ID="Img" runat="server" ImageUrl="~/theme/iflow/prof_pic_blank.jpg" Height="30px" />
                       </div>
                      <%-- <br />
                       <br />--%>
                    </div>

                    <div class="row">
                   <div class="col-md-8">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                       </div>
                                        <%--<asp:LinkButton ID="btnUpload" runat="server" class="btn btn-sample onhover" OnClick="btnUpload_Click">--%>
                   <div class="col-md-4" style="margin-top:-5px">
                                        <asp:LinkButton ID="btnUpload" runat="server" class="btn btn-success" OnClick="UploadButton_Click">
                                            <span class="glyphicon glyphicon-upload" style="color: White;"></span> Upload
                                        </asp:LinkButton>
                       <%--</div>--%>
                       </div>
                   </div>
                   </div>

                </div>
              <%--Added by ajay 03 November 2023 START--%>
               <div class="row" style="margin-bottom:5px;">
                  <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblEmailID" CssClass="control-label" Text="Email ID" runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control" TabIndex="8" />
                    </div>
                   <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblCCN" CssClass="control-label" Text="Customer Care No." runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtCCN" runat="server" CssClass="form-control" TabIndex="8" />
                    </div>
                   </div>
               <div class="row" style="margin-bottom:5px;">
                     <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblOffc" CssClass="control-label" Text="Registered Office Address" runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtRegAddr" runat="server" Height="100px" CssClass="form-control"  TextMode="MultiLine" TabIndex="9" />
                    </div>
                   <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblWebsite" CssClass="control-label" Text="Website" runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control" TabIndex="8" />
                    </div>
                   </div>
              <div class="row" style="margin-bottom:5px;">
                     <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblCorpOfc" CssClass="control-label" Text="Corporate Office Address" runat="server" />
                    </div>
               <div class="col-md-3">
                                        <asp:TextBox ID="txtCorpOfcAddr" runat="server" Height="100px" CssClass="form-control"  TextMode="MultiLine" TabIndex="9" />
                    </div>
                 
                   </div>
                <%--Added by ajay 03 November 2023 END--%>
          </div>
           </div>
       <%--     <br />--%>

        <%--Registartion detail start 13 july 2023--%>
        <div class="card PanelInsideTab_body" id="PnldivRegDtls" runat="server" style="margin-left: 2%; margin-right: 2%;">
             <div id="divHdrRegDtls" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBdyRegDtls','btnRegDtls');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblhdrRegDtls" runat="server" Text="REGISTRATION DETAILS"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="btnRegDtls" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 
        </div>
           <div id="divBdyRegDtls" runat="server" class="panel-body" style="display:block"> 
                <div class="row" style="margin-bottom:5px;">
                    <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblRegPan" CssClass="control-label" Text="PAN No." runat="server" />
                    </div>
                    <div class="col-md-3">
                                        <asp:TextBox ID="txtRegPan" runat="server" CssClass="form-control"  TabIndex="5" onblur="PanValid();" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"/>
                    </div>
                     <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblRegGstin" CssClass="control-label" Text="GSTIN No." runat="server" />
                    </div>
                    <div class="col-md-3" style="display:flex">
                                        <asp:TextBox ID="txtRegGstin" runat="server" CssClass="form-control"  TabIndex="5" MaxLength="15" onblur="validateGST()" style="display:none;" onChange="javascript:this.value=this.value.toUpperCase();"/>
                     <asp:TextBox ID="txtgststcode" runat="server" CssClass="form-control" Width="45px" MaxLength="2" onkeyup="loadGst();" TabIndex="201" placeholder="99"></asp:TextBox>

                                                   <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                            FilterType="Numbers,Custom"  
                                                            TargetControlID="txtgststcode"></ajaxToolkit:FilteredTextBoxExtender> 
                                                  <asp:TextBox ID="txtgstpan" runat="server" CssClass="form-control" style="width:145px;margin-left: 5px;" MaxLength="10" TabIndex="202" onkeyup="gstpankey();" onChange="javascript:this.value=this.value.toUpperCase();"  placeholder="AAAAA9999A"></asp:TextBox>
                                                 <asp:TextBox ID="txtgstothr" runat="server" CssClass="form-control" style="width: 70px;margin-left: 5px;" MaxLength="3" TabIndex="203" onkeyup="Othrdkey();" onChange="javascript:this.value=this.value.toUpperCase();" placeholder="9Z9"></asp:TextBox>
                </div>
                    </div>
                 <div class="row" style="margin-bottom:5px;">
                    <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblRegCin" CssClass="control-label" Text="CIN No." runat="server" />
                    </div>
                    <div class="col-md-3">
                                        <asp:TextBox ID="txtRegCin" runat="server" CssClass="form-control"  TabIndex="5" onblur="validateCIN();" MaxLength="21" onChange="javascript:this.value=this.value.toUpperCase();"/>
                    </div>
                     <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblLeiid" CssClass="control-label" Text="LEI No." runat="server" />
                    </div>
                    <div class="col-md-3">
                                        <asp:TextBox ID="txtLeiid" runat="server" CssClass="form-control"  TabIndex="5" MaxLength="20" onblur="leifo()"/>
                    </div>
                </div>
             <div class="row" style="margin-bottom:5px;">
                    <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblCkycId" CssClass="control-label" Text="CKYC No." runat="server" />
                    </div>
                    <div class="col-md-3">
                                        <asp:TextBox ID="txtCkycId" runat="server" CssClass="form-control"  TabIndex="5" MaxLength="14" onblur="ckycchk()"/>
                    </div>
                 </div>
               </div>
        </div>
        <%--Registartion detail end 13 july 2023--%>

         <%--added by babita on 24 may 2023--%>
        <div class="card PanelInsideTab_body" id="divchD" runat="server" style="margin-left: 2%; margin-right: 2%;">
              <div id="divchde" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divchanneldet','spanchdet');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label21" runat="server" Text="CHANNEL DETAILS" CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="spanchdet" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 
        </div> 

             <div id="divchanneldet" runat="server" class="panel-body" style="display:block"> 
                 <div style="margin-bottom:5px;">
               <%--<div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="Label26" CssClass="control-label" Text="Channel Details" runat="server" />
                    </div>
                      <div class="col-sm-3">
                                        <asp:DropDownList id="ddlchanneldet" runat="server" CssClass="form-control"  TabIndex="6"></asp:DropDownList>
                                         </div>--%>
           </div>

                 <div id="addtablename" runat="server" style="display:none" class="row">
				 <br />
                     </div>
                 </div>
            </div>
        
        <%--ended by babita--%>
      <%--  <br />--%>
            <div class="card PanelInsideTab_body" id="div1" runat="server" style="margin-left: 2%; margin-right: 2%;">
                <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divkpisrch','btndivkpisrch');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblhdr" runat="server"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="btndivkpisrch" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 

        </div>
          <div id="divkpisrch" runat="server" class="panel-body" style="display:block"> 
             <div class="row" style="margin-bottom:5px;">
                     <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblPer" CssClass="control-label" runat="server" />
                    </div>
                     <div class="col-md-3">
                                <asp:DropDownList ID="ddlFinancialYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />

                                        <asp:TextBox ID="txtFinYr" Visible="false" runat="server" CssClass="form-control" TabIndex="10" style="margin-left:2px" MaxLength="10"/>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" FilterType="Custom, Numbers"
                                            runat="server" ValidChars="-" TargetControlID="txtFinYr">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                      </div>
                    <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblVer" CssClass="control-label" runat="server" />
                    </div>
                  <div class="col-md-3">
                                        <asp:TextBox ID="txtVer" runat="server" CssClass="form-control" TabIndex="11" style="margin-left:-6px"/>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" FilterType="Custom, Numbers"
                                            runat="server" ValidChars="." TargetControlID="txtVer">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
              </div>
                <div class="row" style="margin-bottom:5px;">
                 <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblEffDate" runat="server" CssClass="control-label" />
                                        <span style="color: #ff0000"> *</span>
                </div>
                   <div class="col-md-3">
                                        <asp:TextBox ID="txtEffDate" runat="server" CssClass="form-control" TabIndex="12" style="margin-left:2px;background-color:white !important"/>
                                       
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" FilterType="Custom, Numbers"
                                            runat="server" ValidChars="/" TargetControlID="txtEffDate">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                   </div>
                <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblCseDt" runat="server" CssClass="control-label" />
                 </div>
                <div class="col-md-3">
                                        <asp:TextBox ID="txtCseDt" runat="server" CssClass="form-control" TabIndex="13" style="margin-left:-6px;background-color:white !important" Enabled="true"/>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" FilterType="Custom, Numbers"
                                            runat="server" ValidChars="/" TargetControlID="txtCseDt">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                  </div>
                 </div>
               <div class="row" style="margin-bottom:5px;">
                          <div class="col-md-3" style="text-align:left">
                          <asp:Label ID="lblChnStatus" Text="Status " runat="server" CssClass="control-label" /> 
                           <span style="color: #ff0000"> *</span>
                     </div>
                        <div class="col-sm-3">
                        <asp:DropDownList Enabled="false" id="ddllStatus" style="margin-right: -3px;" CssClass="form-control"  runat="server">
                        <asp:ListItem   Value="Draft">Draft</asp:ListItem>
                             <asp:ListItem Selected="True" Value="Final">Final</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                     </div>
            </div>
        </div>
         <br />
        <div id="div7" runat="server" class="card PanelInsideTab_body" style="display:none;margin-left: 2%; margin-right: 2%;">
            <div id="Div10" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div8','Span2');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label12" runat="server"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="Span2" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div> 
                  </div>
            <div id="div8" runat="server" class="panel-body" style="display:block">
                 <div class="row" style="margin-bottom:10px;">
                                   <div class="col-sm-3" style="text-align:left;">
                                        <asp:Label ID="Label13" CssClass="control-label" runat="server" />
                                   </div>
                                   <div class="col-sm-9" style="text-align:center">
                                    <asp:Label ID="lblFinYr" runat="server" CssClass="control-label" ForeColor="Blue"></asp:Label>
                                    </div>
                 </div>
                              <div class="row" style="margin-bottom:10px;">
                                   <div class="col-sm-3" style="text-align:left;">
                                        <asp:Label ID="Label15" CssClass="control-label" runat="server" />
                                   </div>                                  
                                   <div class="col-sm-9" style="text-align:center">
                                     <asp:Label ID="lblVer1" runat="server"  CssClass="control-label" ForeColor="Blue"></asp:Label>
                                   </div>
                              </div>
                                   <div class="row" style="margin-bottom:10px;">
                                      <div class="col-sm-3" style="text-align:left;">
                                        <asp:Label ID="Label17" runat="server" CssClass="control-label" />
                                        </div>
                                     <div class="col-sm-9" style="text-align:center;">
                                     <asp:Label ID="lblEffDate1" runat="server" CssClass="control-label" ForeColor="Blue"></asp:Label>
                                    </div>
                                    </div>
                                    <div class="row" style="margin-bottom:10px;">
                                       <div class="col-sm-3" style="text-align:left;">
                                        <asp:Label ID="Label19" runat="server" CssClass="control-label" />
                                       </div>    
                                       <div class="col-sm-9" style="text-align:center">                          
                                    <asp:Label ID="lblCseDt1" runat="server"  CssClass="control-label" ForeColor="Blue"></asp:Label>
                                   </div>
                       </div>
        </div>
        </div>
     <%--   <br />--%>
        <div id="div2" runat="server" style="width: 98%;">
         <div class="row">
                <div class="col-md-12" style="text-align: center">
                    <asp:HiddenField ID="hdndivclr" runat="server" />
                        <input id="hidFlag" runat="server" type="hidden" />&nbsp;
                             <asp:LinkButton ID="btnUpdate" runat="server"  CssClass="btn btn-sample" 
                              CausesValidation="false" OnClick="btnUpdate_Click" TabIndex="14" OnClientClick="return validate();" >
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> UPDATE
                                </asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="btnSave" OnClick="btnSave_Click" OnClientClick="return validate();"  runat="server"  CssClass="btn btn-success" 
                              CausesValidation="false"   TabIndex="14"   >
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> SAVE
                                </asp:LinkButton>&nbsp;
                        
                               <asp:LinkButton ID="Cancel" runat="server" style="background-color:#FFF;color:#f04e5e; width:85px !important" CssClass="btn btn-clear" 
                              CausesValidation="false" OnClick="Cancel_Click" TabIndex="15" >
                                  <span class="glyphicon glyphicon-remove" style="color:#f04e5e"> </span> CANCEL
                                </asp:LinkButton>
                    
                      <asp:LinkButton ID="btnshowHist" runat="server" CssClass="btn btn-sample" 
                        CausesValidation="false" TabIndex="15" OnClientClick="funPopUp();return false;">
                        <span class="glyphicon glyphicon-dashboard" style="color:White"> </span> VIEW HISTORY
                        </asp:LinkButton>
                  
               </div>
              </div>
        </div>
    </center>
    <!-- Modal -->
    <div id="ModalviewHis" runat="server">
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" style="margin-top: auto; width: 96%; height: 49%;" role="document">
                <div class="modal-content">
                    <div class="modal-header" style="padding: 6px !important;">
                        <div class="modal-header" style="text-align: center; text-align: initial; background-color: #dff0d8;">
                            <%--<asp:Label ID="lblchnlVer" Text="Version history of channels" runat="server" Font-Bold="true" Style="font-size: initial"></asp:Label>--%>
                            <asp:Label ID="lblComVer" Text="Version history of Company" runat="server" Font-Bold="true" Style="font-size: initial"></asp:Label>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-12" style="text-align: left; margin-left: 19px;">
                                <asp:Label ID="Label25" runat="server" Text="Search Result" CssClass="control-label" Font-Size="19px"></asp:Label>
                            </div>
                        </div>
                        <div id="div24" runat="server" class="panel-body" style="display: block">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="Label24" runat="server" Text="Modification Mode" CssClass="control-label" />
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:RadioButtonList ID="rdMode" runat="server" CellPadding="2" CellSpacing="2"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Text="&nbspCorrection&nbsp" Value="CR">  </asp:ListItem>
                                        <asp:ListItem Text="&nbspChanges&nbsp" Value="CH"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblFinyer" Text="Financial year" CssClass="control-label" runat="server" />
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlFinYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12" style="text-align: center">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sample" Visible="true"
                                        CausesValidation="false" TabIndex="14"> <%--OnClick="btnSearch_Click"--%> <%-- OnClick="btnSearch_Click"--%>
                                  <span class="glyphicon glyphicon-search BtnGlyphicon" style="color:White"> </span> Search </asp:LinkButton>
                                    <button type="button" class="btn btn-sample" data-dismiss="modal">
                                        <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span>&nbspCancel
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div id="div23" runat="server" class="panel-body" style="display: block; overflow: auto">
                            <asp:GridView AllowSorting="True" ID="GridView1" runat="server" CssClass="footable"
                                AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                                <FooterStyle CssClass="GridViewFooter" />
                                <RowStyle CssClass="GridViewRowNew" />
                                <HeaderStyle CssClass="gridview" />
                                <PagerStyle CssClass="disablepage" />
                                <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Channel">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("BizSrc") %>'
                                                CommandArgument='<%# Eval("BizSrc") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Channel Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChannelType") %>'
                                                CommandArgument='<%# Eval("ChannelType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Channel Desc 01">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChannelDesc01") %>'
                                                CommandArgument='<%# Eval("ChannelDesc01") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Channel Desc 02">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChannelDesc02") %>'
                                                CommandArgument='<%# Eval("ChannelDesc02") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Channel Desc 03">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChannelDesc03") %>'
                                                CommandArgument='<%# Eval("ChannelDesc03") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="SortOrder">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("SortOrder") %>'
                                                CommandArgument='<%# Eval("SortOrder") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Period">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period") %>'
                                                CommandArgument='<%# Eval("Period") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Version">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Version") %>'
                                                CommandArgument='<%# Eval("Version") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Eff. Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("EffDate") %>'
                                                CommandArgument='<%# Eval("EffDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Cease Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CeaseDate") %>'
                                                CommandArgument='<%# Eval("CeaseDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Create by">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateBy") %>'
                                                CommandArgument='<%# Eval("CreateBy") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateDtim") %>'
                                                CommandArgument='<%# Eval("CreateDtim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Updated by">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateBy") %>'
                                                CommandArgument='<%# Eval("UpdateBy") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Updated Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateDtim") %>'
                                                CommandArgument='<%# Eval("UpdateDtim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Insurance type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Insurance_Type") %>'
                                                CommandArgument='<%# Eval("Insurance_Type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Company name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CompName") %>'
                                                CommandArgument='<%# Eval("CompName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Year of incorporation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("YrIncorporation") %>'
                                                CommandArgument='<%# Eval("YrIncorporation") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Company name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CompName") %>'
                                                CommandArgument='<%# Eval("CompName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="License number">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("LcnNo") %>'
                                                CommandArgument='<%# Eval("LcnNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Office Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("OffcAddr") %>'
                                                CommandArgument='<%# Eval("OffcAddr") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mod. Mode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ModMode") %>'
                                                CommandArgument='<%# Eval("ModMode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Parent Channel Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Parnt_ChnlID") %>'
                                                CommandArgument='<%# Eval("Parnt_ChnlID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Business year">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("BusYrFlg") %>'
                                                CommandArgument='<%# Eval("BusYrFlg") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Freeze Business year">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("FrzBsnssFlg") %>'
                                                CommandArgument='<%# Eval("FrzBsnssFlg") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-sample" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="exampleModalTest" role="dialog">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; text-align: initial; background-color: #dff0d8;">
                </div>
                <div class="panel" id="div19" runat="server">
                    <div id="Div20" runat="server" class="panel-heading">
                        <div class="row">
                            <div class="col-sm-10">
                                <asp:Label ID="Label23" runat="server" Text="Search Result" CssClass="control-label" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                            </div>
                        </div>
                    </div>
                    <div id="div21" runat="server" class="panel-body" style="display: block">
                    </div>
                </div>
                <div id="div22" runat="server">
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup1" runat="server"></asp:Label>
                    <div id="divsrch" runat="server" class="panel-body" style="display: block; overflow: auto">
                    </div>
                </div>
                <div class="modal-footer" id="DivButton" runat="server" style="text-align: center">
                    <button type="button" visible="false" runat="server" class="btn btn-sample" data-dismiss="modal">
                        <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span>&nbspCancel
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color: #00cccc !important;">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" style="margin-left: 84px;color: blue;font-size: 17px;"></asp:Label>
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="closePopUp();" style='margin-top: -6px; margin-right: 113px;'>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK

                    </button>

                </div>
            </div>
        </div>
    </div>

    <asp:Panel runat="server" ID="pnlMdl" Width="400" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="400" height="300px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:UpdatePanel runat="server" ID="upd7">
        <ContentTemplate>
            <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="200px">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" class="test" colspan="1" style="height: 32px">INFORMATION
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 391px">
                            <br />
                            <center>
                                <asp:Label ID="lbl3" runat="server"></asp:Label></center>
                            <br />
                            <center>
                                <asp:Label ID="lbl4" runat="server"></asp:Label><br />
                            </center>
                            <br />
                            <center>
                                <asp:Label ID="lbl5" runat="server"></asp:Label></center>
                            <br />
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="16" Width="80px" OnClientClick="javascript:done();"
                        CssClass="standardbutton" />
                </center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnok" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:Panel runat="server" ID="PnlPopupLOB" Width="1000px" Height="550px" display="none" top="52" left="529px">

        <iframe runat="server" id="IframeLOB" width="100%" frameborder="0" style="height: 100%;"></iframe>

    </asp:Panel>
    <asp:Label runat="server" ID="lblpopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopExtndrLOB" BehaviorID="mdlViewBIDLOB"
        DropShadow="false" TargetControlID="lblpopup" PopupControlID="PnlPopupLOB" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>


    <asp:Panel runat="server" ID="pnlcease" Width="500" Height="428" display="none" top="52" left="529px">
        <iframe runat="server" id="Ifrmcease" width="610px" height="539px" frameborder="0" style="margin-top: -45px;"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblcease" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="Mdlpnlcease" BehaviorID="mdlViewBIDCease" DropShadow="false" TargetControlID="lblcease" PopupControlID="pnlcease" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>



    <asp:HiddenField ID="hdnprodctcode" runat="server" />
    <asp:HiddenField ID="hdnprodctNmae" runat="server" />
    <asp:HiddenField ID="hdn1" runat="server" />
    <asp:HiddenField ID="hdn2" runat="server" />
    <asp:HiddenField ID="hdn3" runat="server" />
    <asp:HiddenField ID="hdnprdcode" runat="server" />
    <asp:HiddenField ID="hdnProdcodeEdit" runat="server" />
    <asp:HiddenField ID="hdnChntype" runat="server" />
    <asp:HiddenField ID="hdnEffdate" runat="server" />


    <script type="text/javascript">
        $(function () {
            $("[id*=CheckBox1]").click(function () {
                if ($(this).is(":checked")) {
                    $("[id*=txtCseDt1]").removeAttr("disabled");
                    //$("[id*=txtCseDt1]").focus();
                } else {
                    $("[id*=txtCseDt1]").attr("disabled", "disabled");
                }
            });
        });
    </script>
    <script type="text/javascript">
        hideRadioSymbol();
        function hideRadioSymbol() {
            debugger;
            var rads = new Array();
            rads = document.getElementsByName('ctl00$ContentPlaceHolder1$rbCorrection'); //Whatever ID u have given to ur radiolist.
            for (var i = 0; i < rads.length; i++)
                document.getElementById(rads.item(i).id).style.display = 'none'; //hide
        }
    </script>
    <script type='text/javascript'>
        $(function () {
            $("[id*=txtEffDate]").attr("readonly", true);
            $("[id*=txtEffDate]").attr.backgroundColor = "white";
            $("[id*=txtCseDt1]").attr("readonly", true);
            $("[id*=txtCseDt1]").attr.backgroundColor = "white";
            $("[id*=txtCseDt]").attr("readonly", true);
            $("[id*=txtCseDt]").attr.backgroundColor = "white";
            $("[id*=txtIncorporation]").attr("readonly", true);
            $("[id*=txtIncorporation]").attr.backgroundColor = "white";

        })
    </script>
    <script>

        function PanValid() {
            debugger;
            var varPAN = document.getElementById("ctl00_ContentPlaceHolder1_txtRegPan").value;
            //if (varPAN.length == 0) {
            //    alert('Please Enter Pan No.');
            //    return false;
            //}
            //if (varPAN.length < 10) {
            //    alert('PAN No. must have minimum 10 characters.');
            //    return false;
            //}

            //if (varPAN.length != 10) {
            //    alert('PAN No. should be 10 characters.');
            //    return false;
            //}


            //Validation for PAN No format.
            if (SpaceTrim(document.getElementById('<%= txtRegPan.ClientID %>').value) != "") {
                if (CheckPANFormat(SpaceTrim(document.getElementById('<%= txtRegPan.ClientID %>').value)) == 0) {
                    alert('Invalid Pan Format');
                    return false;
                }
            }
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
                                if (pan2.substring(j, j + 1) != 'P' && pan2.substring(j, j + 1) != 'C' && pan2.substring(j, j + 1) != 'F' && pan2.substring(j, j + 1) != 'H') {
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
        function IsNumeric(sText) {
            var ValidChars = "0123456789";
            var IsNumber = true;
            var Char;

            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }

            return IsNumber;
        }

         function isAlphabet(strText) {
            var inputStr = strText
            for (var intCounter = 0; intCounter < inputStr.length; intCounter++) {
                var oneChar = inputStr.substring(intCounter, intCounter + 1)

                if (oneChar.toUpperCase() < "A" || oneChar.toUpperCase() > "Z") {
                    return false

                }
            }
            return true
        }

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

                //CIN Validation by ajay

        function validateCIN() {
            debugger;
            cin = document.getElementById('ctl00_ContentPlaceHolder1_txtRegCin').value;
                // Remove any white spaces from the CIN
                cin = cin.replace(/\s/g, '');

                // Check if the CIN is exactly 21 characters long
            if (cin.length !== 21) {
                alert('Please enter valid CIN no.');
                return false;
                }

                // Check if the first 21 characters are alphanumeric
            if (!/^[a-zA-Z0-9]+$/.test(cin)) {
                 alert('Please check if the first 21 characters are alphanumeric.');
                return false;
                }

            if (!/^[LUNA]/.test(cin)) {
              alert('Please enter valid company code.');
                        return false;
            }


            if (!/^[A-Z]{2}/.test(cin)) {
                  var stateCode = cin.substring(6, 8);
                  var stateCodeRegex = /^[A-Z]{2}$/;
  
                  if (stateCodeRegex.test(stateCode)) {
                    // State code is valid
                    // Your code logic here
                  } else {
                      alert('Please enter valid state code.');
                        return false;
                  }
            }

            var yearString = cin.substring(8, 12);
            var yearRegex = /^\d{4}$/;

            if (yearRegex.test(yearString)) {
            } else {
              alert('Please enter valid incorporation year.');
                        return false;
            }
                return true;
        }


        function validateGST() {
            debugger;
                    gst = document.getElementById('ctl00_ContentPlaceHolder1_txtRegGstin').value;
          // Check if the GST is a string
          //  if (typeof gst !== 'string') {
          //      alert('Please enter GSTIN no.');
          //  return false;
          //}

          // Remove any white spaces from the GST
          gst = gst.replace(/\s/g, '');

          // Check if the GST is exactly 15 characters long
            if (gst.length !== 15) {
              alert('Please enter Valid GSTIN no.');
            return false;
          }

          // Check if the first two characters are alphanumeric
            if (!/^[a-zA-Z0-9]+$/.test(gst.substr(0, 15))) {
             alert('Please enter Valid GSTIN no.');
            return false;
          }

          // All checks passed, the GST is valid
            if (gst != '' && document.getElementById("ctl00_ContentPlaceHolder1_txtRegPan").value != '') {
                checkPANandGSTIN(gst, document.getElementById("ctl00_ContentPlaceHolder1_txtRegPan").value);
            }
          return true;
        }

        function checkPANandGSTIN(gst, pan) {
          // Remove any white spaces from the GST and PAN
              gst = gst.replace(/\s/g, '');
              pan = pan.replace(/\s/g, '');

              // Convert both GST and PAN to uppercase for case-insensitive comparison
              gst = gst.toUpperCase();
            pan = pan.toUpperCase();


            //const gstNumber = "00AZKPY6016F5553";
            //const searchString = "AZKPY6016F";
            const startingPosition = 2; // Specify the starting position here (0-based index)
            const endingPosition = 11; // Specify the ending position here (0-based index)

            const extractedSubstring = gst.substring(startingPosition, endingPosition + 1);

            if (extractedSubstring.includes(pan)) {
              console.log("The specified portion of the GST number includes the search string.");
            } else {
                console.log("The specified portion of the GST number does not include the search string.");
               alert('The PAN provided is not matched in the GSTIN included.');
            }



            // const startingPosition = 2; // Specify the starting position here (0-based index)
            //const endingPosition = 12; // Specify the ending position here (0-based index)

            //const extractedSubstring = gst.substring(pan, endingPosition + 1);

            //if (extractedSubstring.includes(pan)) {
            ////if (gst.substring(3,12).includes(pan)) {
            //  console.log("The GST number includes the search string.");
            //} else {
            //  console.log("The GST number does not include the search string.");
            //}


              // Check if GST includes PAN
              //if (gst.includes(pan)) {
              //  return true;
              //} else {
              //    alert('The PAN provided is not matched in the GSTIN included.');
              //  return false;
              //}
        }
        function leifo() {
                     leino = document.getElementById('ctl00_ContentPlaceHolder1_txtLeiid').value;
          // Check if the LEI is a string
          //  if (typeof leino !== 'string') {
          //      alert('Please enter LEI no.');
          //  return false;
          //}

          // Remove any white spaces from the GST
          leino = leino.replace(/\s/g, '');

            // Check if the lei is exactly 15 characters long
            if (leino != '') {

            if (leino.length !== 20) {
              alert('Please enter valid LEI no.');
            return false;
            }
          }
        }
        function ckycchk() {
            ckycid = document.getElementById('ctl00_ContentPlaceHolder1_txtCkycId').value;
          // Check if the LEI is a string
          //  if (typeof ckycid !== 'string') {
          //      alert('Please enter CKYC no.');
          //  return false;
          //}

          // Remove any white spaces from the GST
          ckycid = ckycid.replace(/\s/g, '');

          // Check if the lei is exactly 15 characters long
            if (ckycid != '') {

            if (ckycid.length !== 14) {
              alert('Please enter valid CKYC no.');
            return false;
                }
            }

        }

    </script>
</asp:Content>


//Added by Mangesh for AR120081
//<script type="text/javascript">

var ControllJsXslVer = 3.0;

function StopProgressBar() {
    $find('ProgressBarModalPopupExtender').hide();
}
function StartProgressBar() {
    ////debugger;
    var myExtender = $find('ProgressBarModalPopupExtender');
    myExtender.show();
}
//Added by Ashish Pedgulwar
function openWinPPHC() {
    //////debugger;//http://bpm.reliancegeneral.co.in/sbm/bpmportal/MotorReport.jsp //http://bpm.reliancegeneral.co.in:18793/sbm/bpmportal/MotorReport.jsp
    var PPHCURL = "http://bpm.reliancegeneral.co.in/sbm/bpmportal/MotorReport.jsp";
    window.open(PPHCURL, 'newpopup', 'width=600px,height=450px,left=30,top=30,scollbars=yes,resizable=yes');
}
function openWinHKIT() {
    //////debugger;
    var HKITURL = "https://hkit.reliancegeneral.co.in/";
    window.open(HKITURL, 'newpopup', 'width=600px,height=450px,left=30,top=30,scrollbars=yes,resizable=yes');
}
function openWinCCAvenue() {
    //////debugger;
    var HKITURL = "https://dashboard.ccavenue.com/jsp/merchant/merchantLogin.jsp";
    window.open(HKITURL, 'newpopup', 'width=600px,height=450px,left=30,top=30,scrollbars=yes,resizable=yes');
}
function openWinRSA() {
    //debugger;
    var HKITURL = "http://hkit.reliancegeneral.co.in:8087/";
    window.open(HKITURL, 'newpopup', 'width=600px,height=450px,left=30,top=30,scrollbars=yes,resizable=yes');
}
//Added by Ashish Pedgulwar

//Added by Shubham for All Panel
function ShowHideForAll(divName, btnName) {
    debugger;
    try {
        var objnewdiv = document.getElementById(divName)
        var objnewbtn = document.getElementById(btnName);
        if (objnewdiv.style.display == "block") {
            objnewdiv.style.display = "none";
            objnewbtn.className = 'glyphicon glyphicon-plus icon'
        }
        else {
            objnewdiv.style.display = "block";
            objnewbtn.className = 'glyphicon glyphicon-minus icon'
        }
    }
    catch (err) {
        ShowError(err.description);
    }
}

var IsCommonRequestFlag = -1;
var CurrDate = "<%Response.Write(GetLADate());%>"
var path = "<%=Request.ApplicationPath.ToString()%>";
var UserId = "super";
var strPloicyNo;
//Added by Sujit
//Purpose-To Load Xml 
//function _ProvideXml(Path)
//{
//    XMLDocLoadXml= new ActiveXObject("Msxml2.DOMDocument.3.0");      
//    XMLDocLoadXml.async = false;
//    XMLDocLoadXml.load(Path);
//    return XMLDocLoadXml;

//}
//Added by Ramesh

function _ProvideXml(Path) {
    //debugger;
    //    XMLDocLoadXml= new ActiveXObject("Msxml2.DOMDocument.3.0");      
    //    XMLDocLoadXml.async = false;
    //    XMLDocLoadXml.load(Path);
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", Path, false);
    xhttp.send();

    //Added by Mangesh For Cross Browswe On 08 Apr 2019
    if (window.ActiveXObject) {
        XMLDocLoadXml = new ActiveXObject("Msxml2.DOMDocument.3.0");   //Microsoft.XMLDOM replaced by Msxml2.DOMDocument.3.0 by akash for CB
        XMLDocLoadXml.async = false;
        XMLDocLoadXml.loadXML(xhttp.responseText);
    }
    else if (Object.hasOwnProperty.call(window, "ActiveXObject") && !window.ActiveXObject) {
        XMLDocLoadXml = new ActiveXObject("Msxml2.DOMDocument.3.0");   //Microsoft.XMLDOM replaced by Msxml2.DOMDocument.3.0 by akash for CB
        XMLDocLoadXml.async = false;
        XMLDocLoadXml.loadXML(xhttp.responseText);
    }
    else {
        parser = new DOMParser();
        XMLDocLoadXml = parser.parseFromString(xhttp.responseText, "text/xml");
    }
    //Ended by Mangesh For Cross Browswe On 08 Apr 2019

    xhttp = null;
    return XMLDocLoadXml;
}




//Added by Sujit
//Purpose-To Check for Error in Xml
function CheckError(XMLDocLoadXml) {
    ////////debugger;
    if (XMLDocLoadXml.childNodes[0].nodeName == "SystemError") {
        if (XMLDocLoadXml.getElementsByTagName("SystemError/Flag")[0].text == "1") {
            window.location = path + "/ErrorSession.aspx";
        }
        alert("Error description: " + XMLDocLoadXml.getElementsByTagName("SystemError/ErrorMessage")[0].text);
        return false;
    }
    else {
        return true;
    }
}


function ShowError(strDescription) {
    strErrtxt = "There was an error on this page.\n\n";
    strErrtxt += "Error description: " + strDescription + "\n\n";
    strErrtxt += "Click OK to continue.\n\n";
    alert(strErrtxt);
}


function LoadWorkArea(SrvcCallTypeCode, CallSubTypeCode, SrvcReqTypeCode, LobCode, ReqChannel, MstrWAEDI_ADD_STTIC) {
    debugger;
    try {
        //alert("LoadWorkArea is called");
        if (queryString("MstrEDI_ADD_STTIC") == '2') {
            MstrWAEDI_ADD_STTIC = '2';
        }

        var XMLDocChgName1 = _ProvideXml("WAloader.aspx?SrvcGrpCode=" + queryString("MstrModuleCode")
                                               + "&SrvcCallTypeCode=" + SrvcCallTypeCode + "&CallSubTypeCode=" + CallSubTypeCode
                                               + "&MstrWAEDI_ADD_STTIC=" + MstrWAEDI_ADD_STTIC
                                               + "&SrvcReqTypeCode=" + SrvcReqTypeCode
                                               + "&LobCode=" + LobCode
                                               + "&ReqChannel=" + ReqChannel
                                               + "&CS=" + "CF");
        //alert("WAloader.aspx is called");
        if (XMLDocChgName1.getElementsByTagName("ErrorFlag")[0].childNodes[0].nodeValue == "1" && queryString("MstrModuleCode") != "1002") { //Modify by shubham 03/09/19
            alert(XMLDocChgName1.getElementsByTagName("MainPage/SystemError")[0].childNodes[0].nodeValue);
        }
        else {
            if (CheckError(XMLDocChgName1) == true) {
                debugger;
                //XMLNodeList = XMLDocChgName1.childNodes[1];
                //alert("Before For loop");
                XMLNodeList = XMLDocChgName1.getElementsByTagName("MainPage")[0];
                for (var nList = 0; nList < (XMLNodeList.childNodes.length - 1) ; nList++) { //Modify by shubham 
                    //alert("Inside For loop"+XMLNodeList.childNodes.length);
                    DivXMLNodeList = XMLNodeList.childNodes[nList].childNodes;
                    TabName = XMLNodeList.childNodes[nList].nodeName
                    Load_Define_Tab(DivXMLNodeList, TabName);
                } //alert("After For loop");
                document.getElementById("MstrWrokAreaTab").style.display = "block";
                document.getElementById("WAResolutionDiv").style.display = "none";

                if (queryString("MstrEDI_ADD_STTIC") == "0") {
                    document.getElementById("btnEdit").style.display = "none";
                }
            }
        }
    }
    catch (err) {
        ShowError(err.description);
    }
}

function GetRequestStrucType(SrvcCllrTypeCode, SrvcTypeCode, SrvcReqDtlCode) {
    XMLChkBodyLoad = new ActiveXObject("Msxml2.DOMDocument.3.0");
    XMLChkBodyLoad.async = false;
    XMLChkBodyLoad.load("LoadCommonData.aspx?MstrModuleCode=" + queryString("MstrModuleCode")
            + "&MstrEDI_ADD_STTIC=" + queryString("MstrEDI_ADD_STTIC")
            + "&SrvcCllrTypeCode=" + SrvcCllrTypeCode + "&SrvcTypeCode=" + SrvcTypeCode
            + "&MstrWAEDI_ADD_STTIC=" + queryString("MstrEDI_ADD_STTIC")
            + "&SrvcReqDtlCode=" + SrvcReqDtlCode + "&Flag=1");

    if (XMLChkBodyLoad.parseError.errorCode != 0) {
        alert("DOM Not Loaded");
    }
    else {
        IsCommonRequestFlag = XMLChkBodyLoad.getElementsByTagName("MaterWASetUp/Count")[0].text
    }
}





//</script>

//<script language="javascript" type="text/javascript">
//<!--

//var strFunctionName;
//onerror=handleErr;
//var txt="";
//function handleErr(msg,url,l)
//{
//        txt="There was an error on this page.\n\n";
//        txt+="Error: " + msg + "\n";
//        txt+="URL: " + url + "\n";
//        txt+="Line: " + l + "\n\n";
//        txt+="FuntionName: " + strFunctionName + "\n\n";
//        txt+="Click OK to continue.\n\n";
//        alert(txt);
//        return true;
//}

//Purpose : It is used to pop up SearchClient Page.
function SearchClient() {
    showPopWin("SearchClient.aspx", 970, 500, null);
}

//Added by kalpak for popup on checklist button
//////debugger;
var y1 = 20;   // change the # on the left to adjuct the Y co-ordinate
(document.getElementById) ? dom = true : dom = false;

function hideIt() {
    if (dom) { document.getElementById("layer1").style.visibility = 'hidden'; }
}

function showIt() {
    if (dom) { document.getElementById("layer1").style.visibility = 'visible'; }
}

function placeIt() {
    if (dom && !document.all) {
        document.getElementById("layer1").style.top = window.pageYOffset + (window.innerHeight - (window.innerHeight - y1))
            + "px";
    }
    if (document.all) { document.all["layer1"].style.top = document.documentElement.scrollTop + (document.documentElement.clientHeight - (document.documentElement.clientHeight - y1)) + "px"; }
    window.setTimeout("placeIt()", 10);
}

//end

//COMMENTED BY KALYANI-HANDE ON 05 MAY 2019 FOR ENRICHED CRM START
//added by kalpak methode onclick of button checklist
//function Checklist() {////////debugger;
//    var OutString;

//    var XMLDocFS = new ActiveXObject("Msxml2.DOMDocument.3.0");
//    XMLDocFS.async = false;
//    if (queryString("MstrEDI_ADD_STTIC") == '0') {
//        XMLDocFS.load("LoadDataClient.aspx?&Flag=20&SrvcCallTypeCode=" + document.getElementById("ddlCallType").value + "&SrvcCallSubTypeCode=" + document.getElementById("ddlCallSubType").value + "&SrvcReqTypeCode=" + document.getElementById("ddlSrvcReq").value + "&LOBCode=" + document.getElementById("ddlLob").value + "&PolicyNo=" + queryString("PolicyNo") + "&CS=CF");  //AR-45
//    }
//    else {
//        XMLDocFS.load("LoadDataClient.aspx?&Flag=20&SrvcCallTypeCode=" + document.getElementById("hdnSrvcCallTypeCode").value + "&SrvcCallSubTypeCode=" + document.getElementById("hdnSrvcCallSubTypeCode").value + "&SrvcReqTypeCode=" + document.getElementById("hdnSeviceRequest").value + "&LOBCode=" + document.getElementById("hdnLOBCode").value + "&PolicyNo=" + queryString("PolicyNo") + "&CS=CF");  //AR-45
//    }
//    if (XMLDocFS.parseError.errorCode != 0) {
//        alert("DOM Not Loaded");
//    }
//    else {
//        var XmlforExtFS = XMLDocFS.getElementsByTagName("CHKLIST/SRVCHKLST");
//        OutString = "<table id='tblGrid' cellpadding='2' cellspacing='2'>";
//        //opening For-1
//        //change by kalyani for AR-41 start
//        if (XmlforExtFS.length > 0) {
//            for (var i = 0; i < XmlforExtFS.length; i++) {
//                var XMLExtFs = XmlforExtFS[i];
//                OutString += "<tr><td class='formtitleChkLst' align='center' style='width:20px;'><span class='standardlabel' id='lblChkDesc'>*</span></td>";
//                OutString += "<td class='formtitleChkLst' align='left' style='width:200px;'><span class='standardlabel' id='lblChkDesc'>" + XMLExtFs.childNodes[0].text + "</span></td><tr>";
//            }
//        }
//        else {

//            OutString += "<tr><td class='formtitleChkLst' align='center' style='width:200px;'><span class='standardlabel' id='lblChkDesc'>No Data Available</span></td></tr>";
//        }
//        //change by kalyani for AR-41 end
//        OutString += "</table>";
//        document.getElementById("bindChkDesc").innerHTML = OutString;
//    }
//    placeIt();
//    showIt();

//}
var Browser = "";
function Checklist() {
    //debugger;
    var OutStringDocument;
    var OutStringInstruction;
    var OutStringAdditional;

    if (document.getElementById("hdnPolicyNo").value != "") {
        var XMLDocFS = null;

        if (queryString("MstrEDI_ADD_STTIC") == '0') {
            XMLDocFS = _ProvideXml("LoadDataClient.aspx?&Flag=61&SrvcCallTypeCode=" + document.getElementById("ddlCallType").value + "&SrvcCallSubTypeCode=" + document.getElementById("ddlCallSubType").value + "&SrvcReqTypeCode=" + document.getElementById("ddlSrvcReq").value + "&LOBCode=" + document.getElementById("ddlLob").value + "&PolicyNo=" + document.getElementById("hdnPolicyNo").value + "&SrvcReqDtlCode=" + "&CS=CF");  //AR-45
        }
        else {
            XMLDocFS = _ProvideXml("LoadDataClient.aspx?&Flag=61&SrvcCallTypeCode=" + document.getElementById("hdnSrvcCallTypeCode").value + "&SrvcCallSubTypeCode=" + document.getElementById("hdnSrvcCallSubTypeCode").value + "&SrvcReqTypeCode=" + document.getElementById("hdnSeviceRequest").value + "&LOBCode=" + document.getElementById("hdnLOBCode").value + "&PolicyNo=" + document.getElementById("hdnPolicyNo").value + "&SrvcReqDtlCode=" + document.getElementById("hdnSrvcReqDtlCode").value + "&CS=CF");  //AR-45
        }

        //Added By Mangesh For Enrich CRM Cross Browser On 21 Jun 2019

        if (window.ActiveXObject) {
            Browser = "IE";
        }
        else if (Object.hasOwnProperty.call(window, "ActiveXObject") && !window.ActiveXObject) {
            Browser = "IE";
        }
        else {
            Browser = "Chrome";
        }

        if (Browser == "IE") {
            if (XMLDocFS.parseError.errorCode != 0) {
                alert("DOM Not Loaded");
            }
            else {

                //OutString = "<table id='tblGrid' cellpadding='2' cellspacing='2'>";

                ////change by kalyani for AR-41 start
                //if (XmlforExtFS.childNodes.length > 0) {
                //    //opening For-1
                //    for (var i = 0; i < XmlforExtFS.childNodes.length; i++) {
                //        var XMLExtFs = XmlforExtFS.childNodes[i];
                //        OutString += "<tr><td class='formtitleChkLst' align='center' style='width:20px;'><span class='standardlabel' id='lblChkDesc'>*</span></td>";
                //        OutString += "<td class='formtitleChkLst' align='left' style='width:200px;'><span class='standardlabel' id='lblChkDesc'>" + XMLExtFs.childNodes[0].childNodes[0].nodeValue + "</span></td><tr>";
                //    }
                //}
                //else {
                //    //var XMLExtFs = XmlforExtFS[i];
                //    OutString += "<tr><td class='formtitleChkLst' align='center' style='width:200px;'><span class='standardlabel' id='lblChkDesc'>No Data Available</span></td></tr>";
                //}

                //OutString += "</table>";
                var XmlforExtFS = XMLDocFS.getElementsByTagName("CHKLIST/SRVCHKLST");
                totalCount = XmlforExtFS.length;
                if (totalCount > 0) {
                    document.getElementById("checkList").style.display = "block";
                    OutStringDocument = "<div class='row p-0'><ul class='unordered-list list-disc'>";
                    OutStringInstruction = "<div class='row p-0'><ul class='unordered-list list-disc'>";
                    OutStringAdditional = "<div class='row p-0'><ul class='unordered-list list-disc'>";
                    for (var i = 0; i < totalCount; i++) {
                        var XMLECHKLISTxtFs = XmlforExtFS[i];
                        if (XMLECHKLISTxtFs.childNodes[1].text == "Required") {
                            OutStringDocument += "<li class='u-list-item' style='border: 1px solid white !important'>";
                            OutStringDocument += XMLECHKLISTxtFs.childNodes[0].text;
                            OutStringDocument += "</li>";
                        }
                        else if (XMLECHKLISTxtFs.childNodes[1].text == "Not Required") {
                            OutStringInstruction += "<li class='u-list-item' style='border: 1px solid white !important'>";
                            OutStringInstruction += XMLECHKLISTxtFs.childNodes[0].text;
                            OutStringInstruction += "</li>";
                        }
                        else if (XMLECHKLISTxtFs.childNodes[1].text == "Additional") {
                            document.getElementById("Additional").style.display = "block";
                            OutStringAdditional += "<li class='u-list-item' style='border: 1px solid white !important'>";
                            OutStringAdditional += XMLECHKLISTxtFs.childNodes[0].text;
                            OutStringAdditional += "</li>";
                        }
                    }
                    OutStringDocument += "</div>";
                    OutStringInstruction += "</div>";
                    OutStringAdditional += "</div>";
                    document.getElementById("DivDocument").innerHTML = OutStringDocument;
                    document.getElementById("DivInstruction").innerHTML = OutStringInstruction;
                    document.getElementById("DivAdditional").innerHTML = OutStringAdditional;
                }
                else {
                    document.getElementById("checkList").style.display = "none";
                }

                placeIt();
                showIt();
            }
        }
        else {
            if (XMLDocFS.documentElement.nodeName == "parsererror") {
                alert("DOM Not Loaded");
            }
            else {
                var XmlforExtFS = XMLDocFS.getElementsByTagName("SRVCHKLST");
                totalCount = XmlforExtFS.length;
                if (totalCount > 0) {
                    document.getElementById("checkList").style.display = "block";
                    OutStringDocument = "<div class='row p-0'><ul class='unordered-list list-disc'>";
                    OutStringInstruction = "<div class='row p-0'><ul class='unordered-list list-disc'>";
                    OutStringAdditional = "<div class='row p-0'><ul class='unordered-list list-disc'>";
                    for (var i = 0; i < totalCount; i++) {
                        var XMLECHKLISTxtFs = XmlforExtFS[i];
                        if (XMLECHKLISTxtFs.childNodes[1].textContent == "Required") {
                            OutStringDocument += "<li class='u-list-item' style='border: 1px solid white !important'>";
                            OutStringDocument += XMLECHKLISTxtFs.childNodes[0].textContent;
                            OutStringDocument += "</li>";
                        }
                        else if (XMLECHKLISTxtFs.childNodes[1].textContent == "Not Required") {
                            OutStringInstruction += "<li class='u-list-item' style='border: 1px solid white !important'>";
                            OutStringInstruction += XMLECHKLISTxtFs.childNodes[0].textContent;
                            OutStringInstruction += "</li>";
                        }
                        else if (XMLECHKLISTxtFs.childNodes[1].textContent == "Additional") {
                            document.getElementById("Additional").style.display = "block";
                            OutStringAdditional += "<li class='u-list-item' style='border: 1px solid white !important'>";
                            OutStringAdditional += XMLECHKLISTxtFs.childNodes[0].textContent;
                            OutStringAdditional += "</li>";
                        }
                    }
                    OutStringDocument += "</div>";
                    OutStringInstruction += "</div>";
                    OutStringAdditional += "</div>";
                    document.getElementById("DivDocument").innerHTML = OutStringDocument;
                    document.getElementById("DivInstruction").innerHTML = OutStringInstruction;
                    document.getElementById("DivAdditional").innerHTML = OutStringAdditional;
                }
                else {
                    document.getElementById("checkList").style.display = "none";
                }

                placeIt();
                showIt();
            }
        }
        //Ened By Mangesh For Enrich CRM Cross Browser On 21 Jun 2019
    }
    else {
        document.getElementById("MstrSrvcTypeTab").style.display = "block";
    }
}




function PolicyEditChecklist(SrvcMapCode) {
    //debugger
    var OutStringDocument;
    var OutStringInstruction;

    //modified by kalpak for cross browser working
    var XMLDocFS = null;

    if (queryString("MstrEDI_ADD_STTIC") == '0') {
        XMLDocFS = _ProvideXml("LoadDataClient.aspx?&Flag=60&SrvcMapCode=" + SrvcMapCode + "&LOBCode=" + document.getElementById("hdnLOB").value + "&PolicyNo=" + document.getElementById("hdnPolicyNo").value + "&CS=CF");  //AR-45
    }
    else {
        XMLDocFS = _ProvideXml("LoadDataClient.aspx?&Flag=60&SrvcMapCode=" + SrvcMapCode + "&LOBCode=" + document.getElementById("hdnLOB").value + "&PolicyNo=" + document.getElementById("hdnPolicyNo").value + "&CS=CF");  //AR-45
    }

    if (XMLDocFS.parseError.errorCode != 0) {
        alert("DOM Not Loaded");
    }
    else {

        //OutString = "<table id='tblGrid' cellpadding='2' cellspacing='2'>";

        ////change by kalyani for AR-41 start
        //if (XmlforExtFS.childNodes.length > 0) {
        //    //opening For-1
        //    for (var i = 0; i < XmlforExtFS.childNodes.length; i++) {
        //        var XMLExtFs = XmlforExtFS.childNodes[i];
        //        OutString += "<tr><td class='formtitleChkLst' align='center' style='width:20px;'><span class='standardlabel' id='lblChkDesc'>*</span></td>";
        //        OutString += "<td class='formtitleChkLst' align='left' style='width:200px;'><span class='standardlabel' id='lblChkDesc'>" + XMLExtFs.childNodes[0].childNodes[0].nodeValue + "</span></td><tr>";
        //    }
        //}
        //else {
        //    //var XMLExtFs = XmlforExtFS[i];
        //    OutString += "<tr><td class='formtitleChkLst' align='center' style='width:200px;'><span class='standardlabel' id='lblChkDesc'>No Data Available</span></td></tr>";
        //}

        //OutString += "</table>";
        var XmlforExtFS = XMLDocFS.getElementsByTagName("CHKLIST/SRVCHKLST");
        totalCount = XmlforExtFS.length;
        if (totalCount > 0) {
            document.getElementById("checkList").style.display = "block";
            OutStringDocument = "<div class='row p-0'><ul class='unordered-list list-disc'>";
            OutStringInstruction = "<div class='row p-0'><ul class='unordered-list list-disc'>";


            for (var i = 0; i < totalCount; i++) {

                var XMLECHKLISTxtFs = XmlforExtFS[i];
                if (XMLECHKLISTxtFs.childNodes[1].text == "Required") {
                    OutStringDocument += "<li class='u-list-item' style='border: 3px solid white !important'>";
                    OutStringDocument += XMLECHKLISTxtFs.childNodes[0].text;
                    OutStringDocument += "</li>";
                }
                else if (XMLECHKLISTxtFs.childNodes[1].text == "Not Required") {
                    OutStringInstruction += "<li class='u-list-item' style='border: 3px solid white !important'>";
                    OutStringInstruction += XMLECHKLISTxtFs.childNodes[0].text;
                    OutStringInstruction += "</li>";
                }
            }
            OutStringDocument += "</div>";
            OutStringInstruction += "</div>";
            document.getElementById("DivDocument").innerHTML = OutStringDocument;
            document.getElementById("DivInstruction").innerHTML = OutStringInstruction;
        }
        else {
            document.getElementById("checkList").style.display = "none";
        }

        placeIt();
        showIt();
    }
}
//COMMENTED BY KALYANI-HANDE ON 05 MAY 2019 FOR ENRICHED CRM END




function closeDialog(divContainer, divOverlay) {
    $(divOverlay).hide()
    $(divContainer).hide()
    $(divContainer).html('')
}

function ClosePopupCheckList() {
    $('#ModalCheckList').modal('hide');
}
//end

//Purpose : It is used to popup Searchdept or Brn Page
function SearchDeptBrn() {
    showPopWin("SearchDeptBrn.aspx", 500, 350, null);
}




//Created By : Akleem
//Created on : 27 Mar 2012
//Purpose : To Search the Policy data for RGIC
function SendPolicyNo(SrNo) {
    _ProvideXml(SrNo);
}

function doSelect(args1, args2, args3, args4, args5, args6, reloadvalue) {
    window.location.reload("MainPage.aspx?MstrModuleCode=" + queryString("MstrModuleCode") + "&MstrEDI_ADD_STTIC=0&CltCode=" + args1 + "&RecId=" + args2 + "&PolicyNo=" + args3 + "&ProdCode=" + args4 + "&MsgId=" + args5 + "&parentMsgId=" + args6 + "&Flag=1&IsSearchPage=");

}

function lnkSelect(args1, args2, args3, args4, args5, args6, args7, args8, reloadvalue) {
    ////////debugger;
    window.location.reload("MainPage.aspx?MstrModuleCode=" + args1 + "&MstrEDI_ADD_STTIC=2&CltCode=" + args2 + "&SrvcReqHrdCode=" + args3 + "&SrvcReqDtlCode=" + args4 + "&SrvcReqTranNo=" + args6 + "&PolicyNo=" + args5 + "&Flag=" + args7 + "&RecId=" + args8);
}

function lnkSelect1(args1, args2, args3, args4, args5, args6, args7, args8, reloadvalue, isRecmplntFlag, args9, Status) {
    ////////debugger;
    if (isRecmplntFlag == "true") {
        window.location.reload("MainPage.aspx?MstrModuleCode=" + args1 + "&MstrEDI_ADD_STTIC=9&CltCode=" + args2 + "&SrvcReqHrdCode=" + args3 + "&SrvcReqDtlCode=" + args4 + "&SrvcReqTranNo=" + args6 + "&PolicyNo=" + args5 + "&Flag=" + args7 + "&RecId=" + args8 + "&CaseFlag=" + args9 + "&isRecmplntFlag=" + isRecmplntFlag);
    }
    else {
        if (Status == "7" || Status == "3") {
            window.location.reload("MainPage.aspx?MstrModuleCode=" + args1 + "&MstrEDI_ADD_STTIC=2&CltCode=" + args2 + "&SrvcReqHrdCode=" + args3 + "&SrvcReqDtlCode=" + args4 + "&SrvcReqTranNo=" + args6 + "&PolicyNo=" + args5 + "&Flag=" + args7 + "&RecId=" + args8 + "&CaseFlag=" + "8" + "&isRecmplntFlag=" + isRecmplntFlag);
        }
        else {
            window.location.reload("MainPage.aspx?MstrModuleCode=" + args1 + "&MstrEDI_ADD_STTIC=9&CltCode=" + args2 + "&SrvcReqHrdCode=" + args3 + "&SrvcReqDtlCode=" + args4 + "&SrvcReqTranNo=" + args6 + "&PolicyNo=" + args5 + "&Flag=" + args7 + "&RecId=" + args8 + "&CaseFlag=" + args9 + "&isRecmplntFlag=" + isRecmplntFlag);
        }
    }
}

function Reload(args1, args2, reloadvalue) {
    //debugger;
    window.location.reload("MainPage.aspx?MstrModuleCode=" + queryString("MstrModuleCode") + "&MstrEDI_ADD_STTIC=0&RecID=" + args1 + "&CltCode=" + args2);
}
function callFromParent() {
    //debugger;
    alert("Call from Parent Page");
    window_onload();
}

function window_onload() {
    //debugger;

    var Browser = GetBrowser();

    strFunctionName = "Window_Onload"
    if (queryString("MstrModuleCode")) {
        //Commented by Mangesh On 17 May 2019
        //XMLDocChgName = new ActiveXObject("Msxml2.DOMDocument.3.0");
        //XMLDocChgName.async = false;

        //XMLDocChgName.load("MainPageLoader.aspx?MstrModuleCode=" + queryString("MstrModuleCode") + "&MstrEDI_ADD_STTIC=" + queryString("MstrEDI_ADD_STTIC"));
        //Commented by Mangesh On 17 May 2019

        //Added by Mangesh For Cross Browswe On 17 May 2019
        var Browser = "";
        if (window.ActiveXObject) {
            XMLDocChgName = new ActiveXObject("Msxml2.DOMDocument.3.0");
            XMLDocChgName.async = false;

            XMLDocChgName.load("MainPageLoader.aspx?MstrModuleCode=" + queryString("MstrModuleCode") + "&MstrEDI_ADD_STTIC=" + queryString("MstrEDI_ADD_STTIC") + "&APPID=" + queryString("APPID") + "&PageID=" + queryString("PageID"));
            Browser = "IE";
            document.getElementById("hdnIsActivexObject").value = "Y";

        }
        else if (Object.hasOwnProperty.call(window, "ActiveXObject") && !window.ActiveXObject) {
            XMLDocChgName = new ActiveXObject("Msxml2.DOMDocument.3.0");
            XMLDocChgName.async = false;
            XMLDocChgName.load("MainPageLoader.aspx?MstrModuleCode=" + queryString("MstrModuleCode") + "&MstrEDI_ADD_STTIC=" + queryString("MstrEDI_ADD_STTIC") + "&APPID=" + queryString("APPID") + "&PageID=" + queryString("PageID"));
            Browser = "IE";
            document.getElementById("hdnIsActivexObject").value = "Y";

        }
        else {
            var URL = "MainPageLoader.aspx?MstrModuleCode=" + queryString("MstrModuleCode") + "&MstrEDI_ADD_STTIC=" + queryString("MstrEDI_ADD_STTIC") + "&APPID=" + queryString("APPID") + "&PageID=" + queryString("PageID");

            var iserror = false;
            var parseresult = "";
            jQuery.ajax({
                url: URL,
                method: "GET",
                contentType: "Application/xml",
                success: function (result) {
                    parseresult = result;
                },
                error: function (result) {
                    iserror = true;
                },
                async: false
            });

            //parser = new XMLParser();
            parser = new DOMParser();
            XMLDocChgName = parser.parseFromString(parseresult, "text/xml");
            Browser = "Chrome";
            document.getElementById("hdnIsActivexObject").value = "N";
        }
        //Ended by Mangesh For Cross Browswe On 17 May 2019
        //////debugger;
        if (Browser == "IE") {
            if (XMLDocChgName.parseError.errorCode != 0) {
                alert("DOM Not Loaded");
            }
            else {
                //alert(XMLDocChgName.xml )

                //Search Tab
                //XMLNodeList = XMLDocChgName.getElementsByTagName("MainPage/MstrSearchTab/iFileMasterSetUp")
                //Load_Define_Tab(XMLNodeList, "MstrSearchTab");

                XMLNodeList = XMLDocChgName.getElementsByTagName("MainPage/Section");
                var TotSec = XMLNodeList[0].childNodes.length
                var InternalSection = ' ';
                for (i = 0; i < TotSec; i++) {
                    InternalSection = InternalSection + '<div id="' + XMLNodeList[0].childNodes[i].text + '"></div>'
                }
                document.getElementById("PageContent").innerHTML = InternalSection;
                for (j = 1; j <= TotSec; j++) {
                    var Tagnam1 = "MainPage/Section" + j + "/iFileMasterSetUp";
                    XMLNodeList = XMLDocChgName.getElementsByTagName(Tagnam1)
                    Load_Define_Tab(XMLNodeList, j);
                }


            }
        }
        else {
            if (iserror) {
                alert("DOM Not Loaded");
            }
            else {

                XMLNodeList = XMLDocChgName.getElementsByTagName("Section")[0];
                var TotSec = XMLNodeList.childElementCount
                var InternalSection = ' ';
                for (i = 0; i < TotSec; i++) {
                    InternalSection = InternalSection + '<div id="' + XMLNodeList.childNodes[i].textContent + '"></div>'
                }
                document.getElementById("PageContent").innerHTML = InternalSection;
                for (j = 1; j <= TotSec; j++) {
                    var Tagnam1 = "Section" + j
                    XMLNodeList = XMLDocChgName.getElementsByTagName(Tagnam1)[0]
                    Load_Define_TabChrome(XMLNodeList, j);
                }

            }
        }
    }

    if (queryString("MstrEDI_ADD_STTIC") == "0") {
        //*********************************************************************************************************************************************//
        //Modified By       : Vinita Dhake
        //Modified On       : 04 Apr 2012
        //Purpose           : Used to set the display of MainPage
        //*********************************************************************************************************************************************//
        // Set_Tab_Display();
        //End Vinita
        //document.getElementById("MstrWrokAreaTab").style.display="none";
        //document.getElementById("MstrAudtTrialTab").style.display="none";
        //document.getElementById("hdnPolicy").value=queryString("PolicyNo");
        //try {
        //    if ((document.getElementById("hdnPolicy").value == "") && ((queryString("PolicyNo") != "") && (queryString("PolicyNo") != "false"))) {
        //        document.getElementById("hdnPolicyNo").value = queryString("PolicyNo");
        //    }
        //    document.getElementById("hdnSrvcGrpCode").value = queryString("MstrModuleCode");
        //    document.getElementById("hdnIsUnidentifiedClient").value = queryString("isUnidentifyClient");
        //}
        //catch (exp) {
        //    console.error(exp.message);
        //}

    }

    //                
    //               document.getElementById("MstrWrokAreaTab").style.display="block"; 




    //for loading Default screen for work area
    //         if (queryString("SrvcReqHrdCode")!="false")
    //        {
    //                LoadWorkArea('','','',1);
    //        } 



    //       for (intsrpt=0;intsrpt < document.scripts.length;intsrpt++)
    //       {
    //                
    //                if (document.scripts[intsrpt].src.indexOf('Script/')!=-1)
    //               {
    //                         
    //                        if (document.scripts[intsrpt].src!='')
    //                        {
    //                                if ( document.scripts[intsrpt].readyState =='loading')
    //                                {
    //                                       
    //                                        document.scripts[intsrpt].onreadystatechange=function()
    //                                        {
    //                                                loadscripts()
    //                                        }   
    //                                }
    //                        }
    //                }
    //       }

    //document.getElementById[].onreadystatechange
    //Added BY Pratik
    Wait(1000);

}
//alert("Js Function Called"); window.onload = window_onload();
function Wait(delay) {

    window.setTimeout("loadingDone()", delay);
}

//Added BY Pratik
function GetBrowser() {
    var Browser = "";
    if (window.ActiveXObject) {
        Browser = "IE";
    }
    else if (Object.hasOwnProperty.call(window, "ActiveXObject") && !window.ActiveXObject) {
        Browser = "IE";
    }
    else {
        Browser = "Chrome";
    }
    return Browser
}


function loadingDone() {
    try {
        //PssWindow_Load();

        LoadData();
        onElementHeightChange(document.body, DefineHeight);
        DefineHeight();
    } catch (ex) {
        console.error(ex.message)
    }
    //try {
    //    //Added by Mangesh For Cross Browser On 19 Jun 2019
    //    if (window.ActiveXObject) {
    //        PssWindow_Load();
    //        onElementHeightChange(document.body, DefineHeight);
    //        DefineHeight();
    //    }
    //    else if (Object.hasOwnProperty.call(window, "ActiveXObject") && !window.ActiveXObject) {
    //        PssWindow_Load();
    //        onElementHeightChange(document.body, DefineHeight);
    //        DefineHeight();
    //    }
    //    else {
    //        debugger;
    //        isScriptNeed = true
    //        var scriptloaded = $.getScript('Script/CBFRM/SrvcType/SrvcTypeCreationLoad.js', function () {
    //            debugger;
    //            PssWindow_Load();
    //            onElementHeightChange(document.body, DefineHeight);
    //            DefineHeight();
    //        });
    //    }
    //    //Ended by Mangesh For Cross Browser On 19 Jun 2019
    //}
    //catch (ex) {
    //    console.error(ex.message)
    //}
}
//Added for Iframe Auto Resize

function DefineHeight() {
    if (window.parent.setIframeHeight)
        window.parent.setIframeHeight((document.body.offsetHeight + 100) + 'px');
}
function onElementHeightChange(elm, callback) {
    //debugger;
    var lastHeight = elm.clientHeight, newHeight;
    (function run() {
        newHeight = elm.clientHeight;
        if (lastHeight != newHeight)
            callback();
        lastHeight = newHeight;

        if (elm.onElementHeightChangeTimer)
            clearTimeout(elm.onElementHeightChangeTimer);

        elm.onElementHeightChangeTimer = setTimeout(run, 200);
    })();
}
//Ended
//*********************************************************************************************************************************************//
//Created By        : 
//Created On        : 04 Apr 2012
//Modified By       : 
//Modified On       : 
//Purpose           : Used to set the display of MainPage
//Input Parameter   : Mst_STTIC_Code
//Output Parameter  : 
//*********************************************************************************************************************************************//
function Set_Tab_Display() {
    //////debugger;
    document.getElementById("MstrCustTab").style.display = "none";
    document.getElementById("MstrPolicyTab").style.display = "none";
    document.getElementById("MstrRequesterTab").style.display = "none";
    document.getElementById("MstrSrvcTypeTab").style.display = "none";
    document.getElementById("MstrWrokAreaTab").style.display = "none";
    document.getElementById("MstrFileUploadTab").style.display = "none";
    document.getElementById("MstrRoutingTab").style.display = "none";
    document.getElementById("MstrAudtTrialTab").style.display = "none";
    document.getElementById("MstrHistoryTab").style.display = "none";
    document.getElementById("MstrSMSTab").style.display = "none";



    if (queryString("Flag") == "1") {
        document.getElementById("MstrCustTab").style.display = "block";
        document.getElementById("MstrPolicyTab").style.display = "block";
        document.getElementById("MstrRequesterTab").style.display = "block";
        document.getElementById("MstrSrvcTypeTab").style.display = "block";
        if (queryString("MstrModuleCode") != "1003") {
            if (queryString("ProdCode") != "") {
                FillDropDown("ddlProduct", "LoadDataClient.aspx?Flag=18&ProdCode=" + queryString("ProdCode") + "&CS=" + "CF", 1, 0);
                document.getElementById("ddlProduct").selectedIndex = 1;
            }
        }
    }
}

//*********************************************************************************************************************************************//
//Created By        : 
//Created On        : 04 Apr 2012
//Modified By       : 
//Modified On       : 
//Purpose           : Used to set the display of MainPage
//Input Parameter   : Mst_STTIC_Code
//Output Parameter  : 
//*********************************************************************************************************************************************//
function ReSet_Tab_Display() {
    document.getElementById("MstrWrokAreaTab").style.display = "block";
    document.getElementById("MstrFileUploadTab").style.display = "block";
    document.getElementById("MstrRoutingTab").style.display = "block";
    document.getElementById("MstrAudtTrialTab").style.display = "block";
    document.getElementById("MstrHistoryTab").style.display = "block";
    document.getElementById("MstrSMSTab").style.display = "block";

}

//End Vinita

function Load_Define_Tab(XMLNodeList, DivTab) {
    debugger;
    //Added BY pratik
    var Browser = GetBrowser();
    if (XMLNodeList.length > 0) {
        var strTabName = "", strXMLName = "", strXSLName = "", strASPXName = "", striParameter = "";
        //alert("Before for loop" + DivTab);
        for (i = 0 ; i < XMLNodeList.length; i++) {
            // alert(XMLNodeList[i].haschildNodes)
            XMLNodeListTab = XMLNodeList[i]
            XMLNodeListiFileNames = XMLNodeListTab.childNodes[0]
            //XMLNodeListTab.childNodes[0]
            //XMLDocChgName
            //XMLDocChgName.documentElement.lenght

            if (XMLNodeListiFileNames.hasChildNodes() == true) {

                if (Browser == "Chrome") {
                    strFilename = XMLNodeListiFileNames.childNodes[0].textContent;

                }
                else {
                    strFilename = XMLNodeListiFileNames.childNodes[0].text;


                }
                if (XMLNodeListiFileNames.childNodes.length > 1) {
                    XMLNodeListiParameter = XMLNodeListiFileNames.childNodes[1]
                    striParameter = ""
                    for (iPara = 0 ; iPara < XMLNodeListiParameter.childNodes.length; iPara++) {
                        var striPara;
                        if (Browser == "Chrome") {
                            striPara = XMLNodeListiParameter.childNodes[iPara].textContent;
                        }
                        else {
                            striPara = XMLNodeListiParameter.childNodes[iPara].text;

                        }
                        if (striParameter == "") {
                            striParameter = "?" + striPara
                            if (striPara.indexOf("=") == -1)
                                striParameter = striParameter + "=" + queryString(striPara)
                        }
                        else {
                            striParameter = striParameter + "&" + striPara
                            if (striPara.indexOf("=") == -1)
                                striParameter = striParameter + "=" + queryString(striPara)
                        }
                        //alert(XMLNodeListiParameter.childNodes[iPara].text)
                    }
                }
            }
            if (Browser == "Chrome") {
                if (XMLNodeListTab.childNodes[0].textContent != "0") {
                    //strFileType = XMLNodeListTab.childNodes[0].lastElementChild.textContent;
                    strFileType = XMLNodeListTab.childNodes[1].textContent;
                }
            }
            else {
                strFileType = XMLNodeListTab.childNodes[1].text;
            }

            if (strFileType == 'xml' || strFileType == 'xsl' || strFileType == 'aspx') {

                if (strFileType == 'xml')
                    strXMLName = strFilename + striParameter;

                if (strFileType == 'xsl')
                    strXSLName = strFilename + striParameter;

                if (strFileType == 'aspx')
                    strASPXName = strFilename + striParameter;
            }
            else {
                if (strFileType == "js")
                    Load_JS_CSSfile("Script/" + strFilename, strFileType);
                else
                    Load_JS_CSSfile("StyleSheet/" + strFilename, strFileType);
            }
        }
        if (strASPXName != "") {
            //alert("Load_ASPX_File("+ strASPXName +"," + DivTab+")") 
            Load_ASPX_File(strASPXName, DivTab);
        }
        else {
            //alert ("Load_XML_XSLT_TO_Div("+ DivTab +","+strXMLName+",xsl/"+strXSLName+")")
            //                       if (strXSLName.indexOf('xsl')==-1)
            //                                Load_XML_XSLT_TO_Div(DivTab,strXMLName,"xsl/"+strXSLName);
            //                        else
            //Load_XML_XSLT_TO_Div(DivTab, strXMLName, "xsl/" + strXSLName);//Commented by AshishP
            Load_XML_XSLT_TO_Div(DivTab, strXMLName, strXSLName);

        }
    }
}

//Added by Mangesh For Cross Browser On 13 Jun 2019
function Load_Define_TabChrome(XMLNodeList, DivTab) {
    if (XMLNodeList != null) {
        if (XMLNodeList.childNodes.length > 0) {
            var strTabName = "", strXMLName = "", strXSLName = "", strASPXName = "", striParameter = "";

            for (i = 0; i < XMLNodeList.childNodes.length; i++) {
                // alert(XMLNodeList[i].haschildNodes)
                XMLNodeListTab = XMLNodeList.childNodes[i]
                XMLNodeListiFileNames = XMLNodeListTab.childNodes[0]

                if (XMLNodeListiFileNames.hasChildNodes() == true) {

                    //modified by kalpak for cross browser working
                    strFilename = XMLNodeListiFileNames.childNodes[0].childNodes[0].nodeValue;
                    //end modified by kalpak for cross browser working

                    if (XMLNodeListiFileNames.childNodes.length > 1) {
                        XMLNodeListiParameter = XMLNodeListiFileNames.childNodes[1]
                        striParameter = ""
                        for (iPara = 0; iPara < XMLNodeListiParameter.childNodes.length; iPara++) {

                            //modified by kalpak for cross browser working
                            var striPara = '';
                            striPara = XMLNodeListiParameter.childNodes[iPara].childNodes[0].nodeValue;
                            //end modified by kalpak for cross browser working

                            if (striParameter == "") {
                                striParameter = "?" + striPara
                                if (striPara.indexOf("=") == -1)
                                    striParameter = striParameter + "=" + queryString(striPara)
                            }
                            else {
                                striParameter = striParameter + "&" + striPara
                                if (striPara.indexOf("=") == -1)
                                    striParameter = striParameter + "=" + queryString(striPara)
                            }
                            //alert(XMLNodeListiParameter.childNodes[iPara].text)
                        }
                    }
                }

                //modified by kalpak for cross browser working
                strFileType = XMLNodeListTab.childNodes[1].childNodes[0].nodeValue;
                //end modified by kalpak for cross browser working

                if (strFileType == 'xml' || strFileType == 'xsl' || strFileType == 'aspx') {

                    if (strFileType == 'xml')
                        strXMLName = strFilename + striParameter;

                    if (strFileType == 'xsl')
                        strXSLName = strFilename + striParameter;

                    if (strFileType == 'aspx')
                        strASPXName = strFilename + striParameter;
                }
                else {
                    if (strFileType == "js")
                        Load_JS_CSSfile("Script/" + strFilename, strFileType);
                    else
                        Load_JS_CSSfile("StyleSheet/" + strFilename, strFileType);
                }
            }
            if (strASPXName != "") {
                Load_ASPX_File(strASPXName, DivTab);
            }
            else {
                Load_XML_XSLT_TO_Div(DivTab, strXMLName, strXSLName);
            }
        }
    }
}

var intsrpt
var bustcachevar = 0 //bust potential caching of external pages after initial request? (1=yes, 0=no)
var loadedobjects = ""
var rootdomain = "http://" + window.location.hostname
var bustcacheparameter = ""

function Load_ASPX_File(url, containerid) {
    var page_request = false
    if (window.XMLHttpRequest) // if Mozilla, Safari etc
        page_request = new XMLHttpRequest()
    else if (window.ActiveXObject) { // if IE
        try {
            page_request = new ActiveXObject("Msxml2.XMLHTTP")
        }
        catch (e) {
            try {
                page_request = new ActiveXObject("Microsoft.XMLHTTP")
            }
            catch (e) {
            }
        }
    }
    else
        return false

    page_request.onreadystatechange = function () {
        loadpage(page_request, containerid)
    }

    if (bustcachevar) //if bust caching of external page
        bustcacheparameter = (url.indexOf("?") != -1) ? "&" + new Date().getTime() : "?" + new Date().getTime()

    page_request.open('GET', url + bustcacheparameter, true)
    page_request.send(null)

}

function loadpage(page_request, containerid) {


    if (page_request.readyState == 4 && (page_request.status == 200 || window.location.href.indexOf("http") == -1)) {
        var str_pageOut = page_request.responseText
        document.getElementById(containerid).innerHTML = page_request.responseText;
    }
    else {
        //document.getElementById(containerid).innerHTML="<center><img src='load.gif' /><br>"+ page_request.statusText +"</center>";
    }
}


function loadobjs() {
    if (!document.getElementById)
        return
    for (i = 0; i < arguments.length; i++) {
        var file = arguments[i]
        var fileref = ""
        if (loadedobjects.indexOf(file) == -1) { //Check to see if this object has not already been added to page before proceeding
            if (file.indexOf(".js") != -1) { //If object is a js file
                fileref = document.createElement('script')
                fileref.setAttribute("type", "text/javascript");
                fileref.setAttribute("src", file);
            }
            else if (file.indexOf(".css") != -1) { //If object is a css file
                fileref = document.createElement("link")
                fileref.setAttribute("rel", "stylesheet");
                fileref.setAttribute("type", "text/css");
                fileref.setAttribute("href", file);
            }
        }
        if (fileref != "") {
            document.getElementsByTagName("head").item(0).appendChild(fileref)
            loadedobjects += file + " " //Remember this object as being already added to page
        }
    }
}
//</script>

//<!-- (queryString) For Getting Loading JS and CSS Files 
//Function name :- queryString
//Parameter :- key
//Retrun :- queryString Value
//Action : 
//    -->
//        <script language="javascript" type="text/javascript">

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
function queryString(key) {
    //////debugger;
    strFunctionName = "queryString";
    var page = new PageQuery(window.location.search);
    //Added by AshishP for VAPT
    if (unescape(page.getValue(key)) == 'false')
        return unescape(page.getValue(key));
    else
        return atob(unescape(page.getValue(key)));
    //Added by AshishP for VAPT
}
//function displayItem(key){
//        if(queryString(key)=='false') 
//        {
//                document.write("you didn't enter a ?name=value querystring item.");
//        }else{
//                document.write(queryString(key));
//        }
////}
//</script>

//<!-- (Load_JS_CSSfile) For Getting Loading JS and CSS Files 
//Function name :- Load_JS_CSSfile
//Parameter :- filename, filetype
//Retrund :-
//    Action : Will load the file
//-->
//    <script language="javascript" type="text/javascript">
function Load_JS_CSSfile(filename, filetype) {
    ////debugger;
    filename = filename + "?Version=" + ControllJsXslVer;
    strFunctionName = "Load_JS_CSSfile";
    if (filetype == "js") { //if filename is a external JavaScript file
        var fileref = document.createElement('script')
        fileref.setAttribute("type", "text/javascript")
        fileref.setAttribute("src", filename)
    }
    else if (filetype == "css") { //if filename is an external CSS file
        var fileref = document.createElement("link")
        fileref.setAttribute("rel", "stylesheet")
        fileref.setAttribute("type", "text/css")
        fileref.setAttribute("href", filename)
    }
    if (typeof fileref != "undefined") {
        //alert("i am here")             
        document.onreadystatechange = function () {
            loadpageJSCSS(document)
        }
        document.getElementsByTagName('head')[0].appendChild(fileref)
    }
}


function loadpageJSCSS(page_request) {


    if (page_request.readyState == 4 && (page_request.status == 200 || window.location.href.indexOf("http") == -1)) {

    }
    else {
        //document.getElementById(containerid).innerHTML="<center><img src='load.gif' /><br>"+ page_request.statusText +"</center>";
    }
}

//</script>

//<!-- (Load_XML_XSLT_TO_Div) For Loading XML and XSLT Files 
//Function name :- Load_XML_XSLT_TO_Div
//Parameter :- ImplementerDivName,XMLFileName,XSLTFileName
//Retrund :-
//    Action : Will load the Xml file in Div Specified
//-->
//    <script type="text/javascript">
function loadXMLDoc(fname) {
    strFunctionName = "loadXMLDoc";
    var xmlDoc;
    this.supportActiveX = (Object.getOwnPropertyDescriptor && Object.getOwnPropertyDescriptor(window, "ActiveXObject")) || ("ActiveXObject" in window);
    // code for IE
    if (this.supportActiveX) {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async = false;
        xmlDoc.load(fname);
    }
        // code for Mozilla, Firefox, Opera, etc.
    else if (document.implementation && document.implementation.createDocument) {
        //////debugger;
        if (fname == "") {
            var dm = new DOMParser();
            var b = dm.parseFromString('<?xml version="1.0" encoding="utf-8" ?>', 'text/xml');
            return b;
        }
        xmlDoc = new XMLHttpRequest();
        xmlDoc.open("GET", fname, false);
        // try { xmlDoc.responseType = "msxml-document" } catch (err) { } // Helping IE11
        xmlDoc.send();
        return (new DOMParser().parseFromString(xmlDoc.responseText, 'text/xml'));
    }
    else {
        alert('Your browser cannot handle this script');
    }


    return (xmlDoc);
}

function Load_XML_XSLT_TO_Div(ImplementerDivName, XMLFileName, XSLTFileName) {
    ////debugger;
    strFunctionName = "Load_XML_XSLT_TO_Div";

    var XSLTFileName = XSLTFileName + "?Ver=" + ControllJsXslVer;
    xml = loadXMLDoc(XMLFileName);
    xsl = loadXMLDoc(XSLTFileName);
    this.supportActiveX = (Object.getOwnPropertyDescriptor && Object.getOwnPropertyDescriptor(window, "ActiveXObject")) || ("ActiveXObject" in window);
    // code for IE
    if (this.supportActiveX) {
        ex = xml.transformNode(xsl);
        document.getElementById(ImplementerDivName).innerHTML = ex;
    }
        // code for Mozilla, Firefox, Opera, etc.
    else if (document.implementation && document.implementation.createDocument) {
        xsltProcessor = new XSLTProcessor();
        xsltProcessor.importStylesheet(xsl);
        resultDocument = xsltProcessor.transformToFragment(xml, document);
        //document.getElementById(ImplementerDivName).appendChild(resultDocument);
        if (resultDocument != null) {
            var serializer = new XMLSerializer();//Added/Modify by shubham 
            var str = serializer.serializeToString(resultDocument);
            document.getElementById(ImplementerDivName).innerHTML = str; //Ended
        }
        //ex = xml.transformNode(xsl);
        //document.getElementById(ImplementerDivName).innerHTML = ex;

        //xsltProcessor = new XSLTProcessor();
        //xsltProcessor.importStylesheet(xsl);
        //resultDocument = xsltProcessor.transformToFragment(xml, xsl);
        ////document.getElementById("example").appendChild(resultDocument);
        //document.getElementById(ImplementerDivName).innerHTML = resultDocument;

    }
}

function ClosePopup(url) {
    //alert('This Case Already Forwarded To Next User');
    debugger;
    window.close(url);
}
//Added By Sandeep 27 Apr 2013 ProdDeploy

function CloseMailPopup(url) {
    alert('These Policy Related to Motor You can not create SR for these policy no');
    window.close(url);
}
//Added By Sandeep 27 Apr 2013 ProdDeploy
//        function RefreshParent()
//        {//////debugger;
//        window.opener.location.reload();
//      
//        
//        }



//added by sandeep 17Dec2013 Multiplae Attachment AR000019
function funDownload(MsgId, ProfileId) {
    ////debugger;
    document.getElementById("hdnMsgId").value = MsgId;
    document.getElementById("hdnProfileValue").value = ProfileId;
    //var MsgId = document.getElementById("hdnMsgId").value;
    //var ProfileId = document.getElementById("hdnProfileValue").value;
    document.getElementById("<%=btnDownSubmit.ClientID%>").click();
    //getMailDetails(MsgId, MsgId, '3', 'MstrEmailTab', '');
    //var varCount = App_UserControl_MailContainer.Download(MsgId, ProfileId);
}

//</script>
//<script type="text/javascript">
// Adedd By Ashish for AR-59,This function is used to+ show Lead no and SR No pop up msg start
function closelmspage(AutoLead) {
    document.getElementById("divopenlms").style.display = "none";
    document.getElementById("btnSave").style.display = "block"
    if (AutoLead != "") {
        bootbox.confirm("Lead Created Successfully and Lead No is : " + AutoLead, function (response) {
            if (response) {

                var ExpectedClosureDt = getValue("LoadDataClient.aspx?&Flag=49&SrvcDtlCode=" + document.getElementById("lblShwSerReqNo").innerHTML + "&CS=" + "CF");
                //Added by kalyani on 14 MAR 2017 fpr AR120061 start  
                if (ExpectedClosureDt == "N") {
                    SuccessMsg(queryString("SrvcReqDtlCode"), queryString("WfAssignStt"), queryString("Error"), queryString("Popup"), "");
                }
                else {
                    SuccessMsg(queryString("SrvcReqDtlCode"), queryString("WfAssignStt"), queryString("Error"), queryString("Popup"), ExpectedClosureDt);
                }
                //Added by kalyani on 14 MAR 2017 fpr AR120061 end
            }
            else {
                var ExpectedClosureDt = getValue("LoadDataClient.aspx?&Flag=49&SrvcDtlCode=" + document.getElementById("lblShwSerReqNo").innerHTML + "&CS=" + "CF");
                //Added by kalyani on 14 MAR 2017 fpr AR120061 start  
                if (ExpectedClosureDt == "N") {
                    SuccessMsg(queryString("SrvcReqDtlCode"), queryString("WfAssignStt"), queryString("Error"), queryString("Popup"), "");
                }
                else {
                    SuccessMsg(queryString("SrvcReqDtlCode"), queryString("WfAssignStt"), queryString("Error"), queryString("Popup"), ExpectedClosureDt);
                }
                //Added by kalyani on 14 MAR 2017 fpr AR120061 end
            }
        });
    }
    else {

        bootbox.confirm("Customer is not Interested !", function (response) {
            if (response) {

                var ExpectedClosureDt = getValue("LoadDataClient.aspx?&Flag=49&SrvcDtlCode=" + document.getElementById("lblShwSerReqNo").innerHTML + "&CS=" + "CF");
                if (ExpectedClosureDt == "N") {
                    SuccessMsg(queryString("SrvcReqDtlCode"), queryString("WfAssignStt"), queryString("Error"), queryString("Popup"), "");
                }
                else {
                    SuccessMsg(queryString("SrvcReqDtlCode"), queryString("WfAssignStt"), queryString("Error"), queryString("Popup"), ExpectedClosureDt);
                }
            }
            else {
                var ExpectedClosureDt = getValue("LoadDataClient.aspx?&Flag=49&SrvcDtlCode=" + document.getElementById("lblShwSerReqNo").innerHTML + "&CS=" + "CF");
                if (ExpectedClosureDt == "N") {
                    SuccessMsg(queryString("SrvcReqDtlCode"), queryString("WfAssignStt"), queryString("Error"), queryString("Popup"), "");
                }
                else {
                    SuccessMsg(queryString("SrvcReqDtlCode"), queryString("WfAssignStt"), queryString("Error"), queryString("Popup"), ExpectedClosureDt);
                }
            }
        });

    }

}
// Adedd By Ashish for AR-59,This function is used to show Lead no and SR No pop up msg ENd

// Adedd By Ashish for AR-59,This function is used to Create Lead start
function CreateLead() {
    //debugger;
    //checks whether All mendatory fileds are selected 
    if (CreateOneViewLeadValidation()) {
        hdnpolicyoneview.value = document.getElementById("hdnPolicy").value;
        hdnpolicytypeoneview.value = document.getElementById("hdnpolicyExpirydate").value;
        var ddlcrspiched = document.getElementById("<%= ddlcrspiched.ClientID %>").value

        //proposed lead is "Yes"
        if (document.getElementById("rdYesprpld").checked == true) {
            hdnleadtype.value = document.getElementById("rdYesprpld").value;
            var lob = document.getElementById("hdnLOBCode").value;
            if (document.getElementById("rdYeswrmld").checked == true) {
                hdnWarmTransfer.value = 'Y';
            }
            else {
                hdnWarmTransfer.value = 'N';
            }
        } //proposed lead is "No"
        else if (document.getElementById("rdNoprpld").checked == true) {
            hdnleadtype.value = document.getElementById("rdNoprpld").value;
            var AutoLead = null;
            var lob = null;

            if (document.getElementById("rdYeswrmld").checked == true) {
                hdnWarmTransfer.value = 'Y';
            }
            else {
                hdnWarmTransfer.value = 'N';
            }
            hdnleadno.value = AutoLead;
        }
            // Cross sell lead is "Yes"
        else if (document.getElementById("ddlcrspiched").value == 1) {

            var leadtype = 'Y';
            hdnleadtype.value = leadtype;
            var lob = document.getElementById("hdnLOBCode").value;
            hdnProductInterested.value = document.getElementById("<%= ddlprdintrested.ClientID %>").value;
            //hdnProductInterested.value = ProductInterested;
            hdnPA.value = document.getElementById("<%= ddlCrossSellstatus.ClientID %>").value;
            //hdnPA.value = CrossSellStatus;

        }
            // Cross sell lead is "No"
        else if ((document.getElementById("ddlcrspiched").value == 2)) {

            var leadtype = 'N';
            hdnleadtype.value = leadtype;
        }
        else {
            alert("Please perform some action on Policy.");
        }
        if (document.getElementById("rdYesprpld").checked == true) {
            var AutoLead = getValue("LoadSrvcData.aspx?&Flag=92&PolicyNo=" + hdnpolicyoneview.value + "&PolicyType=" + hdnpolicytypeoneview.value + "&warmtransfer=" + hdnWarmTransfer.value + "&SRNo=" + document.getElementById("hdnSrvcReqDtlCode").value + "&CS=CL");
            hdnleadno.value = AutoLead;

        }
        else if ((ddlcrspiched == 1)) {

            var AutoLead = getValue("LoadSrvcData.aspx?&Flag=92&PolicyNo=" + hdnpolicyoneview.value + "&PolicyType=" + hdnpolicytypeoneview.value + "&warmtransfer=" + "Y" + "&SRNo=" + document.getElementById("hdnSrvcReqDtlCode").value + "&CS=CL");
            hdnleadno.value = AutoLead;

        }
        else if ((document.getElementById("rdNoprpld").checked == true) || (ddlcrspiched == 2)) {

            var AutoLead = "";
        }


        InsertOneviewLeadInfo();
        closelmspage(AutoLead);

        var myExtender = $find('ModalPopupExtenderCustView');
        myExtender.hide();

    }


}
// Adedd By Ashish for AR-59,This function is used to Create Lead end

// Adedd By Ashish for AR-59,This function is used to insert Lead information in the database Start
function InsertOneviewLeadInfo() {
    //debugger
    var XMLDocFS = new ActiveXObject("Msxml2.DOMDocument.3.0");
    XMLDocFS.async = false;
    var SRNo = document.getElementById("hdnSrvcReqDtlCode").value
    if ((document.getElementById("rdYesprpld").checked == true) || (document.getElementById("rdNoprpld").checked == true)) {

        XMLDocFS.load("LoadSrvcData.aspx?&Flag=93&ProposedLead=" + hdnleadtype.value + "&CrossLead=" + "&WarmTransfer=" + hdnWarmTransfer.value + "&ProductInterested=" +
           "&CrossSellStatus=" + "&PolicyNo=" + hdnpolicyoneview.value + "&PolicyType=" + hdnpolicytypeoneview.value + "&LeadNo=" + hdnleadno.value + "&SRNo=" + SRNo + "&CS=" + "CF")

        if ((document.getElementById("rdYesprpld").checked == true)) {
            var AuditTrailCode = getValue("LoadSrvcData.aspx?&Flag=95&LeadNo=" + hdnleadno.value + "&CS=CF");
            var getNewValue = "{'LeadNo':'" + hdnleadno.value + "','UserId':'" + hdnUserID.value + "','AdtTrlCode':'" + AuditTrailCode + "'}";
            ////debugger;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WALoader.aspx/openDailerWebsrvc",
                data: getNewValue,
                dataType: "json",
                success: function (result) {
                    ////debugger;
                    if (result.d != "") {
                        //                                alert("Lead is assing to Dialer.");
                    }
                    else {
                        alert("Lead is not assign.");
                    }
                }
            });
        }
    }
    else if (document.getElementById("ddlcrspiched").value == 2) {
        XMLDocFS.load("LoadSrvcData.aspx?&Flag=93&ProposedLead=" + "&CrossLead=" + hdnleadtype.value + "&WarmTransfer=" + "&ProductInterested=" +
            "&CrossSellStatus=" + "&PolicyNo=" + hdnpolicyoneview.value + "&PolicyType=" + hdnpolicytypeoneview.value + "&LeadNo=" + hdnleadno.value + "&SRNo=" + SRNo + "&CS=" + "CF")

    }
    else {

        XMLDocFS.load("LoadSrvcData.aspx?&Flag=93&ProposedLead=" + "&CrossLead=" + hdnleadtype.value + "&WarmTransfer=" + "&ProductInterested=" + hdnProductInterested.value +
            "&CrossSellStatus=" + hdnPA.value + "&PolicyNo=" + hdnpolicyoneview.value + "&PolicyType=" + hdnpolicytypeoneview.value + "&LeadNo=" + hdnleadno.value + "&SRNo=" + SRNo + "&CS=" + "CF")

        var AuditTrailCode = getValue("LoadSrvcData.aspx?&Flag=95&LeadNo=" + hdnleadno.value + "&CS=CF");
        var getNewValue = "{'LeadNo':'" + hdnleadno.value + "','UserId':'" + hdnUserID.value + "','AdtTrlCode':'" + AuditTrailCode + "'}";
        ////debugger;
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "WALoader.aspx/openDailerWebsrvc",
            data: getNewValue,
            dataType: "json",
            success: function (result) {
                ////debugger;
                if (result.d != "") {
                    //                            alert("Lead is assing to Dialer.");
                }
                else {
                    alert("Lead is not assign.");
                }
            }
        });
    }
}

function openModalCustOneView() {
    var myExtender = $find('ModalPopupExtenderCustView');
    myExtender.show();

}
//test by Shubham
$(document).ready(function () {
    //alert("1");
    //if (document.getElementById("Date") != null) {
    //    alert("1");
    //$("#Date").datepicker({ changeMonth: true, changeYear: true });
    //}

})
//test by Shubham
function ShowReqDtl_new(obj, div) {
    if ($(obj).hasClass('glyphicon-minus')) {
        $(obj).removeClass('glyphicon-minus').addClass('glyphicon-plus')
        $('#' + div).css('display', 'none')
    } else {
        $(obj).removeClass('glyphicon-plus').addClass('glyphicon-minus')
        $('#' + div).css('display', 'block')
    }
}
// Adedd By Ashish for AR-59,This function is used to insert Lead information in the database End
//</script>
function NotificationDivSlide(DivId, IconId) {
    //debugger;
    var ID = "#" + DivId;
    var Icon = "#" + IconId;
    $(document).ready(function () {
        $(Icon).hover(function () {
            $(ID).show(1000);


        },
        function () {
            //This is onMouseOut event

            $(ID).hide(1000);
        });
    });
}


// For common validation --Created by Pravin


function fnValidatePAN(Obj) {
    //Function added by Pravin--PAN Validation

    debugger;
    if (Obj == null) Obj = window.event.srcElement;
    if (Obj.value != "") {
        ObjVal = Obj.value;
        var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
        var code = /([C,P,H,F,A,T,B,L,J,G])/;
        var code_chk = ObjVal.substring(3, 4);
        if (ObjVal.search(panPat) == -1) {
            //alert("Please enter valid PAN Number");
            AlertMsg("Please enter valid PAN Number");
            Obj.value = "";
            Obj.focus();
            return false;
        }
        if (code.test(code_chk) == false) {
            //alert("Please enter valid PAN Number"); //Invaild pan card number
            AlertMsg("Please enter valid PAN Number");
            Obj.value = "";
            return false;
        }
    }
}

function checkemail(str) {
    //var str=document.validation.emailcheck.value
    var filter = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    if (filter.test(str)) { return true; } else { return false; }
}

function checkEmailN(obj) {
    var StrMailID = document.getElementById(obj).value
    //Modified by kalpak for cross browser working
    //var XMLDocFS=new ActiveXObject("Msxml2.DOMDocument.3.0");  
    //XMLDocFS.async = false;
    var x = document.getElementById(obj).value;
    var strTotalLenght = x.length
    var atpos = x.indexOf("@");
    var dotpos = x.lastIndexOf(".");
    var strCheckfirstChar = x.substring(0, 1);
    // if (strCheckfirstChar <= 9) {
    //     alert("Not a valid e-mail address");
    //     document.getElementById(obj).value="";
    //     return false;

    // }

    var lastPrepix = x.substring(dotpos, x.length);
    if (atpos < 3) {
        //alert("Not a valid e-mail address");
        AlertMsg("Please enter valid email address");
        document.getElementById(obj).value = "";
        return false;
    }

    if (lastPrepix == ".com" || lastPrepix == ".net" || lastPrepix == ".org" || lastPrepix == ".biz" || lastPrepix == ".in") {

        if (lastPrepix == ".in") {

            var NewEmailId = x.substring(0, dotpos);
            var dotpos2 = NewEmailId.lastIndexOf(".");
            var lastPrepix2 = NewEmailId.substring(dotpos2, NewEmailId.length);
            if (lastPrepix2 != ".co" || lastPrepix2 == ".co") {

            }
            else {
                //alert("Not a valid e-mail address");
                AlertMsg("Please enter valid email address");
                document.getElementById(obj).value = "";
                return false;
            }
        }
    }

    else {
        //alert("Not a valid e-mail address");
        AlertMsg("Please enter valid email address");
        document.getElementById(obj).value = "";
        return false;
    }
}


function ValidationPassport(Obj) {                                       //Function added by daksh-- Validation
    debugger;
    if (Obj == null) Obj = window.event.srcElement;
    if (Obj.value != "") {
        ObjVal = Obj.value;
        var panPat = /^[A-Z]{1}[0-9]{7}$/;
        //var panPat = /^[A-PR-WYa-pr-wy][1-9]\d\d{4}[1-9]$/;
        if (panPat.test(Obj.value)) {
            return true;
        }
        else {
            //alert("Invalid Passport no");
            AlertMsg("Please enter valid passport number");
            Obj.value = "";
            Obj.focus();
            return false;
        }
    }
}





function ValidationDriving(Obj) {                                       //Function added by daksh Validation
    debugger;
    if (Obj == null) Obj = window.event.srcElement;
    if (Obj.value != "") {
        ObjVal = Obj.value;
        var panPat = /^[A-Z]{2}[0-9]{13}$/;
        //var panPat = /^[A-PR-WYa-pr-wy][1-9]\d\d{4}[1-9]$/;
        if (panPat.test(Obj.value)) {
            return true;
        }
        else {
            //alert("Invalid Drving License no");
            AlertMsg("Please enter valid driving license number");
            Obj.value = "";
            Obj.focus();
            return false;
        }
    }
}



function ValidationVoterId(Obj) {                                       //Function added by daksh-- Validation
    debugger;
    if (Obj == null) Obj = window.event.srcElement;
    if (Obj.value != "") {
        ObjVal = Obj.value;
        var panPat = /^[A-Z]{3}[0-9]{7}$/;
        //var panPat = /^[A-PR-WYa-pr-wy][1-9]\d\d{4}[1-9]$/;
        if (panPat.test(Obj.value)) {
            return true;
        }
        else {
            AlertMsg("Please enter valid voter id number");
            Obj.value = "";
            Obj.focus();
            return false;
        }
    }
}



function fnValidateAdhar(Obj) {                                       //Function added by Pravin--Aadhaar Validation
    debugger;
    if (Obj == null) Obj = window.event.srcElement;
    if (Obj.value != "") {
        var filter = /^\d{4}$/;
        if (filter.test(Obj.value)) {
            return true;
        }
        else {
            AlertMsg("Please enter valid aadhaar card number");
            Obj.value = "";
            Obj.focus();
            return false;
        }
    }
}

function fnValidateEkyc(Obj) {                                       //Function added by Pravin--KYC Validation
    debugger;
    if (Obj == null) Obj = window.event.srcElement;
    if (Obj.value != "") {
        var filter = /^\d{4}$/;
        if (filter.test(Obj.value)) {
            return true;
        }
        else {
            AlertMsg("Please enter valid E-KYC Authentication number");
            Obj.value = "";
            Obj.focus();
            return false;
        }
    }
}



//Added by tushar For Master,s Data Show
function OpenIdentityCodeMasterPage() {
    debugger;
    //var modal = document.getElementById('myModalRaise_Master');
    //var modaliframe = document.getElementById("iframeCFR_Master");
    ////modaliframe.src = "../../Application/CKYC/CommunicationLog_NEW.aspx?refno=" + refno;
    window.open("IdentityCodeMaster.aspx?Status=reg&CrS=" + "CF", 'popupViewSr', 'width=800,height=530,toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
    //$('#myModalRaise_Master').modal();
}

function OpenProofofAddressMaster() {
    debugger;
    //var modal = document.getElementById('myModalRaise_Master');
    //var modaliframe = document.getElementById("iframeCFR_Master");
    //modaliframe.src = "../../Application/CKYC/CommunicationLog_NEW.aspx?refno=" + refno;
    window.open("ProofofAddressMaster.aspx?Status=reg&CrS=" + "CF", 'popupViewSr', 'width=800,height=530,toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
    //$('#myModalRaise_Master').modal();
}
//Added by tushar For Master,s Data Show

//^[a-zA-Z][a-zA-Z '-]*$
function ToChkUnchkChkPOIDocument(id) {//new
    debugger;
    var chk0 = document.getElementById("EmptyPagePlaceholder_GridView1_ChkPOIDocument_0");
    var chk1 = document.getElementById("EmptyPagePlaceholder_GridView1_ChkPOIDocument_1");
    var chk2 = document.getElementById("EmptyPagePlaceholder_GridView1_ChkPOIDocument_2");
    var chk3 = document.getElementById("EmptyPagePlaceholder_GridView1_ChkPOIDocument_3");
    var chk4 = document.getElementById("EmptyPagePlaceholder_GridView1_ChkPOIDocument_4");
    var chk5 = document.getElementById("EmptyPagePlaceholder_GridView1_ChkPOIDocument_5");
    var chk6 = document.getElementById("EmptyPagePlaceholder_GridView1_ChkPOIDocument_6");
    var chkid = document.getElementById(id).value;

    if (id == chk0.id) {
        if (chkid.checked != true) {
            chkid.checked = true;
            chk1.checked = false;
            chk2.checked = false;
            chk3.checked = false;
            chk4.checked = false;
            chk5.checked = false;
            chk6.checked = false;
        }
    }
    else
        if (id == chk1.id) {
            if (chkid.checked != true) {
                chkid.checked = true;
                chk0.checked = false;
                chk2.checked = false;
                chk3.checked = false;
                chk4.checked = false;
                chk5.checked = false;
                chk6.checked = false;
            }
        }
        else
            if (id == chk2.id) {
                if (chkid.checked != true) {
                    chkid.checked = true;
                    chk0.checked = false;
                    chk1.checked = false;
                    chk3.checked = false;
                    chk4.checked = false;
                    chk5.checked = false;
                    chk6.checked = false;
                }
            }
            else
                if (id == chk3.id) {
                    if (chkid.checked != true) {
                        chkid.checked = true;
                        chk0.checked = false;
                        chk1.checked = false;
                        chk2.checked = false;
                        chk4.checked = false;
                        chk5.checked = false;
                        chk6.checked = false;
                    }
                }
                else
                    if (id == chk4.id) {
                        if (chkid.checked != true) {
                            chkid.checked = true;
                            chk0.checked = false;
                            chk2.checked = false;
                            chk3.checked = false;
                            chk1.checked = false;
                            chk5.checked = false;
                            chk6.checked = false;
                        }
                    }
                    else
                        if (id == chk5.id) {
                            if (chkid.checked != true) {
                                chkid.checked = true;
                                chk0.checked = false;
                                chk1.checked = false;
                                chk2.checked = false;
                                chk3.checked = false;
                                chk4.checked = false;
                                chk6.checked = false;
                            }
                        }
                        else
                            if (id == chk6.id) {
                                if (chkid.checked != true) {
                                    chkid.checked = true;
                                    chk0.checked = false;
                                    chk2.checked = false;
                                    chk3.checked = false;
                                    chk4.checked = false;
                                    chk5.checked = false;
                                    chk1.checked = false;
                                }
                            }
                            else { }
}

function callCalender() {
    debugger;
    var dateArr = $("#<%=txtDOB.ClientID%>").val().split('-');
    $("#<%= txtDOB.ClientID%>").datepicker({ maxDate: new Date(), changeMonth: true, changeYear: true, dateFormat: 'dd-mm-yy' });
    $.datepicker.initialized = true;
    $("#<%= txtDOB.ClientID%>").focus();

}

function ValidateDOB(id) {
    debugger;
    var date = document.getElementById(id).value;
    var dateObj = date.split('/');
    if (!getYearDiff(new Date(dateObj[2], dateObj[1] - 1, dateObj[0]))) {
        popup("DOB should not be less then 18 years");
        document.getElementById(id).value = "";
    }
    
}

function getYearDiff(startDate) {
    debugger;
    var endDate = new Date();
    var yearDiff = endDate.getFullYear() - startDate.getFullYear();
    if (startDate.getMonth() > endDate.getMonth()) {
        yearDiff--;
    } else if (startDate.getMonth() === endDate.getMonth()) {
        if (startDate.getDate() > endDate.getDate()) {
            yearDiff--;
        } else if (startDate.getDate() === endDate.getDate()) {
            if (startDate.getHours() > endDate.getHours()) {
                yearDiff--;
            } else if (startDate.getHours() === endDate.getHours()) {
                if (startDate.getMinutes() > endDate.getMinutes()) {
                    yearDiff--;
                }
            }
        }
    }
    if (yearDiff >= 18) {
        return true;
    }
    else {
        return false;
    }
}

function fnValidateNumber(id, No) {
    debugger;
    var Mobile1 = document.getElementById(id).value;
    if (Mobile1 != "") {

        if (parseInt(Mobile1.length) != parseInt(No)) {
            //AlertMsg("Number should be " + No + " digit");
            AlertMsg("Number at least " + No + " digit long");
            document.getElementById(id).value = "";
            document.getElementById(id).focus();
            return false;
        }
    }
}

function lettersOnly() {
    var charCode = event.keyCode;
    if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 8 || charCode == 32 || charCode == 39)
        return true;
    else
        return false;
}

function CheckMaritalStatus(Source) {
    debugger;
    var mStatus = $("#ddlMaritalStatus").val();
    var prefix = $("#cboTitle").val();
    if (prefix == "MS" && (mStatus == "01")) {
        popup("Marital status is invalid");
        if (Source == "MStatus") {
            $("#ddlMaritalStatus").val('');
        }
        else if (Source == "prefix") {
            $("#cboTitle").val('');
        }
    }
}

function CheckGenderPrefix(Sources) {
    debugger;
    var prefix = $("#cboTitle").val();
    var gender = $("#cboGender").val();
    if (prefix == 'MR') {
        if (gender == "F") {

            if (Sources == 'prefix') {
                popup("Prefix cannot be Mr. when gender is female");
                $("#cboTitle").val('');
            }
            else {
                popup("Gender cannot be female when prefix is Mr.");
                $("#cboGender").val('');
            }
        }
    }
    else if (prefix == 'MS' || prefix == 'MRS') {
        if (gender == "M") {
            if (Sources == 'prefix') {
                popup("Prefix cannot be Ms. or Mrs. when gender is male");
                $("#cboTitle").val('');
            }
            else {
                popup("Gender cannot be male when prefix is  Ms. or Mrs.");
                $("#cboGender").val('');
            }
        }
    }
    if (Sources == 'prefix') {
        CheckMaritalStatus(Sources);
    }
}

function CheckFatherSpouce(Sources) {
    debugger;
    var FatherSelected = $("#rbtFS_0").is(':checked');
    if (FatherSelected) {
        var FatherPrefix = $("#cboTitle2").val();
        if (FatherPrefix == "") return;
        if (!(FatherPrefix == "MR" || FatherPrefix == "DR")) {
            if (Sources == "rdoFather") {
                popup("Father prefix cannot be Mrs. or Ms.");
            }
            else {
                popup("Father prefix cannot be Mrs. or Ms.");
                $("#cboTitle2").val("");
            }
        }
    }
}

function validatePAN(id) {
    debugger;
    var val = document.getElementById(id).value;
    if (val == "")
        return;

    var reg = /^[A-Z]{3}P[A-Z]{1}[0-9]{4}[A-Z]{1}$/
    if (!(reg.test(val))) {
        popup("Please enter valid PAN Number.");
        document.getElementById(id).value = "";
    }
}


function validatePOIDoc() {

}

function checkContactNumber(prefix, number, source) {
    var p = $(prefix).val().trim();
    var n = $(number).val().trim();
    if ((p == "" && n != "") || (p != "" && n == "")) {
        d
        if (source == "tele_home") {
            popup("Resident STD code and Telephone number is mandatory");
        }
        else if (source == "tele_off") {
            popup("Office STD code and Telephone number is mandatory");
        }
        else if (source == "mobile") {
            popup("Mobile ISD code and mobile number is mandatory");
        }
        else if (source == "fax") {
            popup("Fax STD code and fax number is mandatory");
        }
        return false;
    }
    return true;
}

function validateEmail(email) {
    debugger;
    if (/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email)) {
        return (true)
    }
    alert("You have entered an invalid email address!")
    return (false)
}

function validateMobileNumber(obj) {
    debugger;
    if ($("#txtMobile").val().trim() == "91") {
        var startWith = ["6", "7", "8", "9"]
        var first = obj.value.split('');

        if (obj.value == "") return;
        if (startWith.indexOf(first[0]) == -1 || obj.value.length != 10) {
            obj.value = "";
            popup("Mobile number should start with  6, 7, 8, 9 and 10 digit long");
        }
    }
  
}

function ShowReqDtl1(divName, btnName) {
    debugger;
    try {
        var objnewdiv = document.getElementById(divName)
        var objnewbtn = document.getElementById(btnName);
        if (objnewdiv.style.display == "block") {
            objnewdiv.style.display = "none";
            objnewbtn.className = 'glyphicon glyphicon-resize-small'
        }
        else {
            objnewdiv.style.display = "block";
            objnewbtn.className = 'glyphicon glyphicon-resize-full'
        }
    }
    catch (err) {
        ShowError(err.description);
    }
}

function CheckSpaces(id) {
    //debugger;
    //alert('1.2');

    var strText = document.getElementById(id).value;
    strText = SpaceTrim(strText);
    document.getElementById(id).value = strText;
    var count = 0;
    //AlertMsg(strText);
    if (strText.length > 0) {
        for (var i = 0; i < strText.length; i++) {
            if (strText.charAt(i) == " ") {
                count++;
            }
        }
        if (count > 2) {
            AlertMsg("More than 2 spaces are not allowed in Given Name");
            document.getElementById(id).focus();
            return false;
        }
    }
}

function AlertMsg(msg) {
    showModal('#ModalAlert', 'Alert', 'alert-warning', '', '', msg);
}

function popup(msg) {
    showModal('#ModalAlert', 'Alert', 'alert-warning', '', '', msg);
}

//function CheckSpaces(id) {
//    debugger;
//    alert('33');
//    alert(id);
//    //var strContent = "EmptyPagePlaceholder";
//    var strText = document.getElementById(id).value;
//    alert(strText);
//    //strText = SpaceTrim(strText);
//    //document.getElementById(strContent + "txtGivenName").value = strText;
//    var count = 0;

//    if (strText.length > 0) {
//        alert('11');
//        for (var i = 0; i < strText.length; i++) {
//            if (strText.charAt(i) == " ") {
//                count++;
//            }
//        }
//        if (count > 2) {
//            alert("More than 2 spaces are not allowed in Given Name");
//            //document.getElementById(id).focus();
//            return false;
//        }
//        else
//        {
//            return true;
//        }
//        alert('22');
//    }
//    return true;
//}

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


function getDatePickerControl(ctrlID) {
    debugger;
    $("#" + ctrlID).datepicker({
        changeMonth: true,
        changeYear: true,
        format: "dd/mm/yyyy",
        autoclose: true
    });
}

$(document).on("click", "[data-toggle='collapse']", function () {
    ////debugger;
    if ($(this).hasClass("glyphicon glyphicon-plus")) {
        $(this).removeClass("glyphicon glyphicon-plus").addClass("glyphicon glyphicon-minus")
    }
    else if ($(this).hasClass("glyphicon glyphicon-minus")) {
        $(this).removeClass("glyphicon glyphicon-minus").addClass("glyphicon glyphicon-plus")
    }
});

function OnChangePOI() {
    document.getElementById("TX_kycPer_IDNo_0").setAttribute("style", "width:310px");
    //Driving Licence
    if (document.getElementById("TX_kycPer_IdType_0").value == "D") {
        document.getElementById("divIdProof").style.display = "block";
        document.getElementById("MaskCodeSpan").style.display = "none";
        document.getElementById("txtMaskCode").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("onblur", "return ValidationDriving(TX_kycPer_IDNo_0)");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("maxlength", "20");
        document.getElementById("TX_kycPer_IDNo_0").removeAttribute("onkeypress");

    }
    //E-KYC Authentication
    if (document.getElementById("TX_kycPer_IdType_0").value == "H") {
        document.getElementById("divIdProof").style.display = "block";
        document.getElementById("MaskCodeSpan").style.display = "table-cell";
        document.getElementById("txtMaskCode").setAttribute("style", "width:140px");
        document.getElementById("txtMaskCode").setAttribute("disabled", "disabled");
        document.getElementById("txtMaskCode").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("style", "width:165px");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("maxlength", "4");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("onblur", "return fnValidateEkyc(TX_kycPer_IDNo_0)");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("onkeypress", "return fncInputNumericValuesOnly()");

    }
    //National Population Register Letter
    if (document.getElementById("TX_kycPer_IdType_0").value == "G") {
        document.getElementById("divIdProof").style.display = "block";
        document.getElementById("MaskCodeSpan").style.display = "none";
        document.getElementById("txtMaskCode").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("maxlength", "20");
        document.getElementById("TX_kycPer_IDNo_0").removeAttribute("onkeypress");

    }

    //NREGA Job Card
    if (document.getElementById("TX_kycPer_IdType_0").value == "F") {
        document.getElementById("divIdProof").style.display = "block";
        document.getElementById("MaskCodeSpan").style.display = "none";
        document.getElementById("txtMaskCode").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("maxlength", "40");
        document.getElementById("TX_kycPer_IDNo_0").removeAttribute("onkeypress");

    }

    //Offline Verification of Aadhaar
    if (document.getElementById("TX_kycPer_IdType_0").value == "I") {
        document.getElementById("divIdProof").style.display = "block";
        document.getElementById("MaskCodeSpan").style.display = "table-cell";
        document.getElementById("txtMaskCode").setAttribute("style", "width:140px");
        document.getElementById("txtMaskCode").setAttribute("disabled", "disabled");
        document.getElementById("txtMaskCode").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("style", "width:165px");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("maxlength", "4");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("onblur", "return fnValidateAdhar(TX_kycPer_IDNo_0)");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("onkeypress", "return fncInputNumericValuesOnly()");

    }

    //Passport
    if (document.getElementById("TX_kycPer_IdType_0").value == "A") {
        document.getElementById("divIdProof").style.display = "block";
        document.getElementById("MaskCodeSpan").style.display = "none";
        document.getElementById("txtMaskCode").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("maxlength", "15");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("onblur", "return ValidationPassport(TX_kycPer_IDNo_0)");
        document.getElementById("TX_kycPer_IDNo_0").removeAttribute("onkeypress");

    }

    //Proof of Possession of Aadhaar
    if (document.getElementById("TX_kycPer_IdType_0").value == "E") {
        document.getElementById("divIdProof").style.display = "block";
        document.getElementById("MaskCodeSpan").style.display = "table-cell";
        document.getElementById("txtMaskCode").setAttribute("style", "width:140px");
        document.getElementById("txtMaskCode").setAttribute("disabled", "disabled");
        document.getElementById("txtMaskCode").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("style", "width:165px");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("maxlength", "4");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("onblur", "return fnValidateAdhar(TX_kycPer_IDNo_0)");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("onkeypress", "return fncInputNumericValuesOnly()");

    }

    //Voter ID Card
    if (document.getElementById("TX_kycPer_IdType_0").value == "B") {
        document.getElementById("divIdProof").style.display = "block";
        document.getElementById("MaskCodeSpan").style.display = "none";
        document.getElementById("txtMaskCode").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("maxlength", "20");
        document.getElementById("TX_kycPer_IDNo_0").setAttribute("onblur", "return ValidationVoterId(TX_kycPer_IDNo_0)");
        document.getElementById("TX_kycPer_IDNo_0").removeAttribute("onkeypress");

    }

}

function OnChangePOA() {

    document.getElementById("TX_kycPer_IDNo_1").setAttribute("style", "width:310px");
    //Driving Licence
    if (document.getElementById("TX_kycPer_IdType_1").value == "03") {
        document.getElementById("divIdProof1").style.display = "block";
        document.getElementById("MaskCodeSpan1").style.display = "none";
        document.getElementById("txtMaskCode1").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_1").style.display = "block";
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("onblur", "return ValidationDriving(TX_kycPer_IDNo_1)");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("maxlength", "20");
        document.getElementById("ddlDeemProfofAddr").style.display = "none";
        document.getElementById("TX_kycPer_IDNo_1").removeAttribute("onkeypress");

    }
    //E-KYC Authentication
    if (document.getElementById("TX_kycPer_IdType_1").value == "09") {
        document.getElementById("divIdProof1").style.display = "block";
        document.getElementById("MaskCodeSpan1").style.display = "table-cell";
        document.getElementById("txtMaskCode1").setAttribute("style", "width:140px");
        document.getElementById("txtMaskCode1").setAttribute("disabled", "disabled");
        document.getElementById("txtMaskCode1").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_1").style.display = "block";
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("style", "width:165px");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("maxlength", "4");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("onblur", "return fnValidateEkyc(TX_kycPer_IDNo_1)");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("onkeypress", "return fncInputNumericValuesOnly()");
        document.getElementById("ddlDeemProfofAddr").style.display = "none";

    }
    //National Population Register Letter
    if (document.getElementById("TX_kycPer_IdType_1").value == "08") {
        document.getElementById("divIdProof1").style.display = "block";
        document.getElementById("MaskCodeSpan1").style.display = "none";
        document.getElementById("txtMaskCode1").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_1").style.display = "block";
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("maxlength", "20");
        document.getElementById("ddlDeemProfofAddr").style.display = "none";
        document.getElementById("TX_kycPer_IDNo_1").removeAttribute("onkeypress");

    }

    //NREGA Job Card
    if (document.getElementById("TX_kycPer_IdType_1").value == "05") {
        document.getElementById("divIdProof1").style.display = "block";
        document.getElementById("MaskCodeSpan1").style.display = "none";
        document.getElementById("txtMaskCode1").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_1").style.display = "block";
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("maxlength", "40");
        document.getElementById("ddlDeemProfofAddr").style.display = "none";
        document.getElementById("TX_kycPer_IDNo_1").removeAttribute("onkeypress");

    }

    //Offline Verification of Aadhaar
    if (document.getElementById("TX_kycPer_IdType_1").value == "10") {
        document.getElementById("divIdProof1").style.display = "block";
        document.getElementById("MaskCodeSpan1").style.display = "table-cell";
        document.getElementById("txtMaskCode1").setAttribute("style", "width:140px");
        document.getElementById("txtMaskCode1").setAttribute("disabled", "disabled");
        document.getElementById("txtMaskCode1").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_1").style.display = "block";
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("style", "width:165px");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("maxlength", "4");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("onblur", "return fnValidateAdhar(TX_kycPer_IDNo_1)");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("onkeypress", "return fncInputNumericValuesOnly()");
        document.getElementById("ddlDeemProfofAddr").style.display = "none";

    }

    //Passport
    if (document.getElementById("TX_kycPer_IdType_1").value == "02") {
        document.getElementById("divIdProof1").style.display = "block";
        document.getElementById("MaskCodeSpan1").style.display = "none";
        document.getElementById("txtMaskCode1").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_1").style.display = "block";
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("maxlength", "15");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("onblur", "return ValidationPassport(TX_kycPer_IDNo_1)");
        document.getElementById("ddlDeemProfofAddr").style.display = "none";
        document.getElementById("TX_kycPer_IDNo_1").removeAttribute("onkeypress");

    }

    //Proof of Possession of Aadhaar
    if (document.getElementById("TX_kycPer_IdType_1").value == "01") {
        document.getElementById("divIdProof1").style.display = "block";
        document.getElementById("MaskCodeSpan1").style.display = "table-cell";
        document.getElementById("txtMaskCode1").setAttribute("style", "width:140px");
        document.getElementById("txtMaskCode1").setAttribute("disabled", "disabled");
        document.getElementById("txtMaskCode1").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_1").style.display = "block";
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("style", "width:165px");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("maxlength", "4");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("onblur", "return fnValidateAdhar(TX_kycPer_IDNo_1)");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("onkeypress", "return fncInputNumericValuesOnly()");
        document.getElementById("ddlDeemProfofAddr").style.display = "none";

    }

    //Voter ID Card
    if (document.getElementById("TX_kycPer_IdType_1").value == "04") {
        document.getElementById("divIdProof1").style.display = "block";
        document.getElementById("MaskCodeSpan1").style.display = "none";
        document.getElementById("txtMaskCode1").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_1").style.display = "block";
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("maxlength", "20");
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("onblur", "return ValidationVoterId(TX_kycPer_IDNo_1)");
        document.getElementById("ddlDeemProfofAddr").style.display = "none";
        document.getElementById("TX_kycPer_IDNo_1").removeAttribute("onkeypress");

    }

    //Deemed Proof of Address- Document Type Code
    if (document.getElementById("TX_kycPer_IdType_1").value == "11") {
        document.getElementById("divIdProof1").style.display = "block";
        document.getElementById("MaskCodeSpan1").style.display = "none";
        document.getElementById("txtMaskCode1").removeAttribute("onblur");
        document.getElementById("TX_kycPer_IDNo_1").style.display = "none";
        document.getElementById("ddlDeemProfofAddr").style.display = "block";
        document.getElementById("TX_kycPer_IDNo_1").removeAttribute("onkeypress");
        FillDropDown("ddlDeemProfofAddr", "GetDataPage.aspx?Flag=5&LookupCode=KDeemProfofAddr&ParamUsage="
 + "" + "&Type=" + 1 + "&CS=" + "CA", 1, 0);

    }

    //Self Declaration
    if (document.getElementById("TX_kycPer_IdType_1").value == "12") {
        document.getElementById("divIdProof1").style.display = "none";
        document.getElementById("MaskCodeSpan1").style.display = "none";
        document.getElementById("TX_kycPer_IDNo_1").style.display = "none";
        document.getElementById("ddlDeemProfofAddr").style.display = "none";


    }

}


function AddressSameAsAbove() {
    if (document.getElementById("TX_KYC_REGISTRATION_AddproofsameasIDproof_0").checked == true) {

        $("#TX_kycPer_IdType_1").find("option:contains(" + $("#TX_kycPer_IdType_0 :selected").text() + ")").attr('selected', 'selected');
        document.getElementById("TX_kycPer_IDNo_1").value = document.getElementById("TX_kycPer_IDNo_0").value;
        OnChangePOA();
        document.getElementById("TX_kycPer_IDNo_1").setAttribute("disabled", "disabled");
        document.getElementById("TX_kycPer_IdType_1").setAttribute("disabled", "disabled");

        document.getElementById("TX_KycCnct_Addr1_1").value = document.getElementById("TX_KycCnct_Addr1_0").value;
        document.getElementById("TX_KycCnct_Addr1_1").setAttribute("disabled", "disabled");
        document.getElementById("TX_KycCnct_Addr2_1").value = document.getElementById("TX_KycCnct_Addr2_0").value;
        document.getElementById("TX_KycCnct_Addr2_1").setAttribute("disabled", "disabled");
        document.getElementById("TX_KycCnct_Addr3_1").value = document.getElementById("TX_KycCnct_Addr3_0").value;
        document.getElementById("TX_KycCnct_Addr3_1").setAttribute("disabled", "disabled");
        document.getElementById("TX_KycCnct_City_1").value = document.getElementById("TX_KycCnct_City_0").value;
        document.getElementById("TX_KycCnct_City_1").setAttribute("disabled", "disabled");

        document.getElementById("TX_KycCnct_PostCode_1").value = document.getElementById("TX_KycCnct_PostCode_0").value;
        document.getElementById("TX_KycCnct_PostCode_0").setAttribute("disabled", "disabled");
        FillStateDisCountryCorresp();
        document.getElementById("TX_KycCnct_District_1").setAttribute("disabled", "disabled");
        document.getElementById("TX_KycCnct_StateCode_1").setAttribute("disabled", "disabled");
        document.getElementById("TX_KycCnct_CntryCode_1").setAttribute("disabled", "disabled");

    }

}

function BindDocumentGrid() {
    debugger;
    var XMLDocFS = null;
    var OutString = "";
    XMLDocFS = _ProvideXml("GetDataPage.aspx?Flag=6&DocName=" + $("#TX_kycPer_IdType_0 :selected").text() + "&DocNo=" + document.getElementById("TX_kycPer_IDNo_0").value + "&CS=CF");

    var DocumentInfo = XMLDocFS.querySelectorAll("DocumentInfo");



    OutString = "<table id='tblDocGridDyn' class='table table-striped table-hover' border='1' style='border: solid #ccc 1px;'>";
    OutString += "<thead class='bg-inverse'><tr>";
    OutString += "<th  align='center' valign='middle'>";
    OutString += "<span id='lblActionDyn'></span>";
    OutString += "</th><th  align='center' valign='middle'>";
    OutString += " <span id='lblDocNameDyn'>Doc ID Name</span></th>";
    OutString += "<th  align='center' valign='middle'><span id='lblDocNoDyn'>Doc ID Number</span></th></tr></thead><tbody>";
    var i = 0;
    //DocumentInfo.forEach(DocumentInfoXmlNode => {

    //    OutString += "<tr><td ><span>";
    //    OutString += "<input id='ChkPOIDocument" + i + "' type='checkbox'/></span></td>";
    //    OutString += "<td><span >" + DocumentInfoXmlNode.children[0].innerHTML + "</span></td>";
    //    OutString += "<td><span >" + DocumentInfoXmlNode.children[1].innerHTML + "</span></td>";
    //    OutString += "</tr>";
    //    i++;
    //});


    OutString += "</tbody></table >";
    document.getElementById("divPerDocGrid").style.display = "block";
    document.getElementById("divPerDocGrid").innerHTML = OutString;
    document.getElementById("tblDocGrid").style.display = "none";
    document.getElementById("TX_kycPer_IdType_0").selectedIndex = 0;
    document.getElementById("TX_kycPer_IDNo_0").value = "";
}

function getHeaderbyID(Code) {
    debugger;
    var Desc = getValue("GetDataPage.aspx?&Flag=7&SegCode=" + Code + "&CS=" + "CA");
    document.getElementById(Code).innerHTML = Desc;

}


function SaveRequest() {
    if (AttributeValidation() == true) {
        //if (ValidatePOIandPOA() == true) {
            debugger;
            var strXml = SaveData();

        SubmitForm("SubmitForm.aspx", strXml, "", "1", queryString("PageID") , "CA");
            
        //}
    }
}

function RemoveSpecifiedCharectr(tempCurrCtrl) {
    try {
        var strReturn = tempCurrCtrl;
        for (var i = 0; i < tempCurrCtrl.length ; i++) {
            strReturn = strReturn.replace("..", ".");
            strReturn = strReturn.replace(",,", ",");
            strReturn = strReturn.replace("  ", " ");
        }
        return strReturn;
    }
    catch (err) {

    }
}

function setDateFormat(txtdate) {//
    debugger;
    try {

        if (isValidDate(txtdate) == true) {
            var date = document.getElementById(txtdate).value;
            var dtArr = new Array();
            //dtArr = date.split("/");
            dtArr = date.split(/[\s,./]+/);
            var month = dtArr[1];
            var val = "";

            if (month == '1' || month == '01') {
                val = 'Jan';
            } else
                if (month == '2' || month == '02') {
                    val = 'Feb';

                } else
                    if (month == '3' || month == '03') {
                        val = 'Mar';

                    } else
                        if (month == '4' || month == '04') {
                            val = 'Apr';

                        } else
                            if (month == '5' || month == '05') {
                                val = 'May';

                            } else
                                if (month == '6' || month == '06') {
                                    val = 'Jun';
                                } else
                                    if (month == '7' || month == '07') {
                                        val = 'Jul';
                                    } else
                                        if (month == '8' || month == '08') {
                                            val = 'Aug';
                                        } else
                                            if (month == '9' || month == '09') {
                                                val = 'Sep';
                                            } else
                                                if (month == '10') {
                                                    val = 'Oct';
                                                } else
                                                    if (month == '11') {
                                                        val = 'Nov';
                                                    } else
                                                        if (month == '12') {
                                                            val = 'Dec';
                                                        }

            if (val != "") {
                document.getElementById(txtdate).value = dtArr[0] + " " + val + " " + dtArr[2]
            }

            return val;
        }
    }
    catch (err) {
        ShowError(err.description);
    }
}

function isValidDate(ctrlId) {
    debugger;
    var subject = document.getElementById(ctrlId).value;
    var dtArr = new Array();
    //dtArr=subject.split(" "); //kp
    dtArr = subject.split(/[\s,./]+/);
    var month = dtArr[1];
    if (month == 'Jan' || month == 'Feb' || month == 'Mar' || month == 'Apr' || month == 'May' || month == 'Jun' || month == 'Jul' || month == 'Aug' || month == 'Sep' || month == 'Oct' || month == 'Nov' || month == 'Dec'
    || month == 'jan' || month == 'feb' || month == 'mar' || month == 'apr' || month == 'may' || month == 'jun' || month == 'jul' || month == 'aug' || month == 'sep' || month == 'oct' || month == 'nov' || month == 'dec') {
        //added by Kalpak 
        if (dtArr[2] == "1900") {
            alert('Please enter valid date.');
            document.getElementById(ctrlId).value = "";
            document.getElementById(ctrlId).focus();
            return false;
        }
        else {
            return true;
        }
        //end
    }
    else if (subject != "") {
        if (subject.match(/^(?:([1-9]|[12][0-9]|3[01])[\- \/.]([1-9]|1[012])[\- \/.](19|20)[0-9]{2})$/) || subject.match(/^(?:(0[1-9]|[12][0-9]|3[01])[\- \/.](0[1-9]|1[012])[\- \/.](19|20)[0-9]{2})$/)
        || subject.match(/^(?:(0[1-9]|[12][0-9]|3[01])[\- \/.]([1-9]|1[012])[\- \/.](19|20)[0-9]{2})$/) || subject.match(/^(?:([1-9]|[12][0-9]|3[01])[\- \/.](0[1-9]|1[012])[\- \/.](19|20)[0-9]{2})$/) ||
        subject.match(/^(?:([1-9]|[12][0-9]|3[01])[\- \-.]([1-9]|1[012])[\- \-.](19|20)[0-9]{2})$/) || subject.match(/^(?:(0[1-9]|[12][0-9]|3[01])[\- \-.](0[1-9]|1[012])[\- \-.](19|20)[0-9]{2})$/)
        || subject.match(/^(?:(0[1-9]|[12][0-9]|3[01])[\- \-.]([1-9]|1[012])[\- \-.](19|20)[0-9]{2})$/) || subject.match(/^(?:([1-9]|[12][0-9]|3[01])[\- \-.](0[1-9]|1[012])[\- \-.](19|20)[0-9]{2})$/)
        ) {
            //added by Kalpak  //kp
            //dtArr=subject.split("/");
            dtArr = subject.split(/[\s,./]+/);
            if (dtArr[2] == "1900") {
                alert('Please enter valid date.');
                document.getElementById(ctrlId).value = "";
                document.getElementById(ctrlId).focus();
                return false;
            }
            else {
                return true;
            }
            //end
        }
        else {
            alert('Please enter valid date.');
            document.getElementById(ctrlId).value = "";
            document.getElementById(ctrlId).focus();
            return false;
        }
    }
}

function ValidatePOIandPOA() {

    if (document.getElementById("TX_kycPer_IdType_0").value == "0") {
        AlertMsg("Please select the Document Type in the proof of Identity");
        return false;
    }

    if (document.getElementById("TX_kycPer_IdType_0").value != "0") {

        if ($("#TX_kycPer_IdType_0 :selected").text() == "Passport") {
            if (document.getElementById("TX_kycPer_IDNo_0").value == "") {
                AlertMsg("Please enter Passport");
                return false;
            }
        }
        if ($("#TX_kycPer_IdType_0 :selected").text() == "Voter ID Card") {
            if (document.getElementById("TX_kycPer_IDNo_0").value == "") {
                AlertMsg("Please enter Voter ID Card");
                return false;
            }
        }
        if ($("#TX_kycPer_IdType_0 :selected").text() == "Driving Licence") {
            if (document.getElementById("TX_kycPer_IDNo_0").value == "") {
                AlertMsg("Please enter Driving Licence");
                return false;
            }
        }
        if ($("#TX_kycPer_IdType_0 :selected").text() == "Proof of Possession of Aadhaar") {
            if (document.getElementById("TX_kycPer_IDNo_0").value == "") {
                AlertMsg("Please enter Proof of Possession of Aadhaar");
                return false;
            }
        }

        if ($("#TX_kycPer_IdType_0 :selected").text() == "NREGA Job Card") {
            if (document.getElementById("TX_kycPer_IDNo_0").value == "") {
                AlertMsg("Please enter NREGA Job Card");
                return false;
            }
        }
        if ($("#TX_kycPer_IdType_0 :selected").text() == "E-KYC Authentication") {
            if (document.getElementById("TX_kycPer_IDNo_0").value == "") {
                AlertMsg("Please enter E-KYC Authentication");
                return false;
            }
        }
        if ($("#TX_kycPer_IdType_0 :selected").text() == "National Population Register Letter") {
            if (document.getElementById("TX_kycPer_IDNo_0").value == "") {
                AlertMsg("Please enter National Population Register Letter");
                return false;
            }
        }
        if ($("#TX_kycPer_IdType_0 :selected").text() == "Offline Verification of Aadhaar") {
            if (document.getElementById("TX_kycPer_IDNo_0").value == "") {
                AlertMsg("Please enter Offline Verification of Aadhaar");
                return false;
            }
        }

    }
                                    
    if (document.getElementById("TX_KycCnct_Addr1_0").value == "") {
        AlertMsg("Please enter address line 1 in the proof of identity and address");
        return false;
    }

    if (document.getElementById("TX_KycCnct_City_0").value == "") {
        AlertMsg("Please enter City/Town/Village in the proof of identity and address");
        return false;
    }

    if (document.getElementById("TX_KycCnct_PostCode_0").value == "0") {
        AlertMsg("Please select pincode in the proof of identity and address");
        return false;
    }

    if (document.getElementById("TX_KYC_REGISTRATION_AddproofsameasIDproof_0").value == false) {
        if (document.getElementById("TX_kycPer_IdType_0").value == "0") {
            AlertMsg("Please select Document Type in the current address");
            return false;
        }

        if (document.getElementById("TX_kycPer_IdType_1").value != "0") {

            if ($("#TX_kycPer_IdType_1 :selected").text() == "Passport") {
                if (document.getElementById("TX_kycPer_IDNo_1").value == "") {
                    AlertMsg("Please enter Passport");
                    return false;
                }
            }
            if ($("#TX_kycPer_IdType_1 :selected").text() == "Voter ID Card") {
                if (document.getElementById("TX_kycPer_IDNo_1").value == "") {
                    AlertMsg("Please enter Voter ID Card");
                    return false;
                }
            }
            if ($("#TX_kycPer_IdType_1 :selected").text() == "Driving Licence") {
                if (document.getElementById("TX_kycPer_IDNo_1").value == "") {
                    AlertMsg("Please enter Driving Licence");
                    return false;
                }
            }
            if ($("#TX_kycPer_IdType_1 :selected").text() == "Proof of Possession of Aadhaar") {
                if (document.getElementById("TX_kycPer_IDNo_1").value == "") {
                    AlertMsg("Please enter Proof of Possession of Aadhaar");
                    return false;
                }
            }

            if ($("#TX_kycPer_IdType_1 :selected").text() == "NREGA Job Card") {
                if (document.getElementById("TX_kycPer_IDNo_1").value == "") {
                    AlertMsg("Please enter NREGA Job Card");
                    return false;
                }
            }
            if ($("#TX_kycPer_IdType_1 :selected").text() == "E-KYC Authentication") {
                if (document.getElementById("TX_kycPer_IDNo_1").value == "") {
                    AlertMsg("Please enter E-KYC Authentication");
                    return false;
                }
            }
            if ($("#TX_kycPer_IdType_1 :selected").text() == "National Population Register Letter") {
                if (document.getElementById("TX_kycPer_IDNo_1").value == "") {
                    AlertMsg("Please enter National Population Register Letter");
                    return false;
                }
            }
            if ($("#TX_kycPer_IdType_1 :selected").text() == "Offline Verification of Aadhaar") {
                if (document.getElementById("TX_kycPer_IDNo_1").value == "") {
                    AlertMsg("Please enter Offline Verification of Aadhaar");
                    return false;
                }
            }
            if ($("#TX_kycPer_IdType_1 :selected").text() == "Deemed Proof of Address- Document Type Code") {
                if (document.getElementById("ddlDeemProfofAddr").value == "0") {
                    AlertMsg("Please select Deemed Proof of Address- Document Type Code");
                    return false;
                }
            }

        }


        if (document.getElementById("TX_KycCnct_Addr1_1").value == "") {
            AlertMsg("Please enter address line 1 in the Current Address");
            return false;
        }
        if (document.getElementById("TX_KycCnct_City_1").value == "") {
            AlertMsg("Please enter City/Town/Village in the Current Address");
            return false;
        }
        if (document.getElementById("TX_KycCnct_PostCode_0").value == "0") {
            AlertMsg("Please select pincode in the Current Address");
            return false;
        }

    }


    return true;


}

function SubmitForm(formAction, setXMLFile,ReferenceNo,MstrEDI_ADD_STTIC,PageID,CS)  
{
    debugger;

    var iframeobj = window.frames["iFrameSubmitForm"];
    var replacesetXMLFile = setXMLFile;
    replacesetXMLFile = replaceSubstring(replacesetXMLFile, '<', '&lt;')
    replacesetXMLFile = replaceSubstring(replacesetXMLFile, '>', '&gt;')

    
    //Purpose : To replace the existing parameter value with the new one.   
    var oGetVars = {};
    var URL = "?";
    if (window.location.search.length > 1) {
        for (var aItKey, nKeyId = 0, aCouples = window.location.search.substr(1).split("&") ; nKeyId < aCouples.length; nKeyId++) {
            //Added by AshishP for VAPT
            var NotDecrptFlag = "N";
            aItKey = aCouples[nKeyId].split("=");
            if (unescape(aItKey[0]) == "MstrEDI_ADD_STTIC") {
                aItKey[1] = MstrEDI_ADD_STTIC;
                NotDecrptFlag = "Y";
            }
            if (unescape(aItKey[0]) == "PageID") {
                aItKey[1] = PageID;
                NotDecrptFlag = "Y";
            }
                     
            if (unescape(aItKey[0]) == "PageID") {
                aItKey[1] = PageID;
                NotDecrptFlag = "Y";
            }

            if (unescape(aItKey[0]) == "encrypt") {

            }
            else if (NotDecrptFlag == "Y") {
                URL = URL + aItKey[0] + "=" + aItKey[1] + "&";
            }
            else {
                URL = URL + aItKey[0] + "=" + atob(aItKey[1]) + "&";
            }
            //Added by AshishP for VAPT
            oGetVars[unescape(aItKey[0])] = aItKey.length > 1 ? unescape(aItKey[1]) : "";
        }
    }
   
    if (MstrEDI_ADD_STTIC == "1") {
        iframeobj._f_SubmitForm(formAction + URL + '&ReferenceNo=' + ReferenceNo + '&CS=' + CS, replacesetXMLFile);
    }
    

}

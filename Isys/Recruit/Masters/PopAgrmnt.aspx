<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/iFrame.master" CodeFile="PopAgrmnt.aspx.cs"
    Inherits="Application_ISys_Recruit_Masters_PopAgrmnt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>

    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <link href="../../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
	<link href="../../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style>
        .clsCenter{
            text-align:center !important;
        }
    </style>
    <script type="text/javascript">
        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../../assets/img/portlet-collapse-icon-white.png')
            }
        }
        function ShowReqDtl1(divName, btnName) {

            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ////ShowError(err.description);
            }
        }

        function ShowReqDiv(divId, btnId, img, chkId, divChk) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + chkId) != null) {
                if (document.getElementById(strContent + chkId).checked == true) {
                    $(document.getElementById(strContent + divId)).slideToggle();
                    if ($(img).attr('src') == "../../../../assets/img/portlet-collapse-icon-white.png") {
                        $(img).attr('src', '../../../../assets/img/portlet-expand-icon-white.png');
                    }
                    else {
                        $(img).attr('src', '../../../../assets/img/portlet-collapse-icon-white.png');
                    }
                }
                else {
                    $(document.getElementById(strContent + divId)).hide();
                    $(document.getElementById(strContent + divChk)).show();
                }
            }
        }


        function ShowDiv(divId) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).animate({
                height: 'toggle'
            });
        }

        function HideDiv(divId) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).animate({ right: '25px' });
        }


        function funEditPopUp(code, sID) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwQTrgBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmQualTrg").src = "PopMstAccCycle.aspx?code=" + code + "&sID=" + sID
            + "&flag=" + document.getElementById(strContent + "hdnFlag").id + "&mdlpopup=mdlVwQTrgBID";
        }

        function doCancel() {
            window.parent.CallParent();
        }

    </script>
    <style type="text/css">
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
            color: white;
        }
        .new_text_new
        {
            color: #066de7;
        }
        .divBorder
        {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        .disablepage
        {
            display: none;
        }
        
        .box
        {
            background-color: #efefef;
            padding-left: 5px;
        }
		.card {
			width: 85% !important;
			position: relative;
			display: flex;
			flex-direction: column;
			min-width: 0;
			word-wrap: break-word;
			background-color: #fff;
			background-clip: border-box;
			border: 1px solid rgba(0,0,0,.125);
			border-radius: .25rem;
		}
		.btn-clear1 {
			color: rgb(0, 204, 204) !important;
			background-color: transparent !important;
			border-color: rgb(0, 204, 204);
			padding-right:20px;
			padding-top:0px;
		}
    </style>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <center>
                        <div class="col-sm-12" style="text-align: right"> 
                                     <asp:LinkButton ID="btnCancel" runat="server" BorderColor="Transparent" OnClientClick="doCancel();" CssClass="btn btn-clear1" TabIndex="44">
                                <span class="glyphicon glyphicon-remove" style="color:#00cccc"> </span>
                                </asp:LinkButton>							
                            </div>
			<div class="card" id="divPannel1" runat="server" >
                <div id="divRwdcollapse" runat="server" style="width: 97%;" class="row rowspacing">
                    <div id="div2" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRwd','Img3');return false;" style="width:96%;padding-left:0px">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;padding-left:28px">
                                
                                <asp:Label ID="Label3" Text="Integration - Agreement" CssClass="control-label HeaderColor" runat="server" />
                            </div>
                            <div class="col-sm-2">
                            </div>
                        </div>
                    </div>
                    <div id="divRwd" runat="server" style="width: 95%;display: block;" class="panel-body">
					 <div class="row rowspacing" >
                        <div class="col-sm-4" style="text-align: left">
                                 <asp:RadioButton Id="rdoOnlne" AutoPostBack="true" Checked="true" runat="server" OnCheckedChanged="rdoOnlne_CheckedChanged"/> &nbsp;&nbsp Online
                            </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:RadioButton Id="rdoOflne" AutoPostBack="true" runat="server" OnCheckedChanged="rdoOflne_CheckedChanged"/> &nbsp;&nbsp Offline
                        </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:RadioButton Id="rdoIntnl" AutoPostBack="true" runat="server" OnCheckedChanged="rdoIntnl_CheckedChanged"/> &nbsp;&nbsp Internal
                            </div>
						 </div>
					 <div id="divEntyDtls" runat="server" class="row rowspacing" >
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblEntyNme" runat="server" CssClass="control-label" Text="Entity Name" Font-Bold="False" ></asp:Label>
							<asp:TextBox ID="txtEntyNme" CssClass="form-control" Enabled="false" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblAddrss" runat="server" CssClass="control-label" Text="Address" Font-Bold="False"></asp:Label>
							<asp:TextBox ID="txtAddrss" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                        </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblAuthSgnNme" runat="server" CssClass="control-label" Text="Authorised Signatory Name" Font-Bold="False" ></asp:Label>
							<asp:TextBox ID="txtAuthSgnNme" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                        </div>
						 </div>
					 <div id="divEntyDtls1" runat="server" class="row rowspacing" >
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblAuthSgnDesg" runat="server" CssClass="control-label" Text="Authorised Signatory Designation" Font-Bold="False"></asp:Label>
							<asp:TextBox ID="txtAuthSgnDesg" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
						 </div>
					 <div class="row rowspacing" >
                        <div class="col-sm-12" style="text-align: right">
                                 <asp:LinkButton ID="btnGnrt" runat="server" CssClass="btn btn-success">
                                 <span class="glyphicon glyphicon-plus" style="color:White"> </span> Generate
                                </asp:LinkButton> 
                                 <asp:LinkButton ID="BtnView" runat="server" Enabled="false" CssClass="btn btn-success">
                                 <span class="glyphicon glyphicon-list-alt" style="color:White"> </span> View
                                </asp:LinkButton> 
                                 <asp:LinkButton ID="BtnDwnld" runat="server" Enabled="false" CssClass="btn btn-success">
                                 <span class="glyphicon glyphicon-download-alt" style="color:White"> </span> Download
                                </asp:LinkButton> 							
                            </div>
					</div>
						<br />
                    </div>
                </div>
			</div>
                <asp:HiddenField ID="hdnCnt" runat="server" />
                <asp:HiddenField ID="hdnFlag" runat="server" />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

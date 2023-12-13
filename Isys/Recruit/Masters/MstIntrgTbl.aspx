<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/iFrame.master" CodeFile="MstIntrgTbl.aspx.cs"
    Inherits="Application_ISys_Recruit_Masters_MstIntrgTbl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />--%>
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
<%--    <link href="../../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />--%>

    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
<%--    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />--%>
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
<%--        $(function () {
            debugger;
            $("#<%= txtcreatedte.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
			});
		});--%>
<%--        function chosedate() {
            debugger;
            $("#<%= txtcreatedte.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
			});
		}--%>
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


        //function funEditPopUp(code, sID) {
        //    var strContent = "ctl00_ContentPlaceHolder1_";
        //    $find("mdlVwQTrgBID").show();
        //    document.getElementById("ctl00_ContentPlaceHolder1_ifrmQualTrg").src = "PopMstAccCycle.aspx?code=" + code + "&sID=" + sID
        //    + "&flag=" + document.getElementById(strContent + "hdnFlag").id + "&mdlpopup=mdlVwQTrgBID";
        //}
        function funEditPopUp(code) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwQTrgBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmQualTrg").src = "PopMstIntrgTbl.aspx?IntrgtId=" + code + "&mdlpopup=mdlVwQTrgBID";
		}
        function funEditPopUp1(code) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwQTrgBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmQualTrg").src = "PopEvntIntrgMppng.aspx?IntrgtId=" + code + "&mdlpopup=mdlVwQTrgBID";
		}
        function funEditPopUp2(code) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwQTrgBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmQualTrg").src = "MstIntrgActnTbl.aspx?IntrgtId=" + code + "&mdlpopup=mdlVwQTrgBID";
		}
        function funEditPopUp3(code) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwQTrgBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmQualTrg").src = "PopAgrmnt.aspx?EntyId=" + code + "&mdlpopup=mdlVwQTrgBID";
		}
        function CallParent() {
			$find("mdlVwQTrgBID").hide();
			location.reload();
		}
        function Openwindow(URL) {
            debugger;
            window.open(URL, '_blank');
        }
    </script>
    <style type="text/css">
        .gridview th {
    padding: 0px;
    height: 40px;
    /* background-color: #53accd !important; */
    /* color: #f2f2f2; */
    border-color: #53accd !important;
    text-align: center;
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
    /* border-top: 1px solid #ccc; */
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
		/*.panel {
			width: 89% !important;
			border-width: 1px !important;
			border-style: solid !important;
			border-color: rgb(125, 213, 250) !important;
			border-image: initial !important;
			padding: 5px 0px 3px !important;
		}*/
		.card {
			width: 89% !important;
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
		.btn-clear
		{
			border-color:white !important;
		}
    </style>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <center>
			<%--<div class="panel panel-success PanelInsideTab" id="divPannel1" runat="server" >--%>
				<div class="card" id="divPannel1" runat="server" >
                <div id="divRwdcollapse" runat="server" style="width: 97%;" class="row rowspacing">
                    <div id="div2" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRwd','Img3');return false;" style="width:96%;padding-left:0px">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;padding-left:28px">
                                
                                <asp:Label ID="Label3" Text="Integration Master Search" CssClass="control-label HeaderColor" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <%-- <span id="Img3" class="glyphicon glyphicon-collapse-down" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>--%>
<%--                                  <span class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>&nbsp;--%>
                            </div>
                        </div>
                    </div>
                    <div id="divRwd" runat="server" style="width: 95%;display: block;" class="panel-body">
<%--					 <div class="row rowspacing" >
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblIntgNme" runat="server" CssClass="control-label" Text="Integration Name" Font-Bold="False" ></asp:Label>
                                <asp:TextBox ID="txtIntgNme" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblIsMndatry" runat="server" CssClass="control-label" Text="Is Mandatory" Font-Bold="False"></asp:Label>
                                    <asp:DropDownList ID="ddlIsMndatry" runat="server" CssClass="form-control">
										<asp:ListItem Value="Y" Text="YES"></asp:ListItem>
										<asp:ListItem Value="N" Text="NO"></asp:ListItem>
                                    </asp:DropDownList>                               
                        </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblIsActv" CssClass="control-label" runat="server" Text="Is Active" Font-Bold="False"></asp:Label>
                                    <asp:DropDownList ID="ddlIsActv" runat="server" CssClass="form-control">
										<asp:ListItem Value="Y" Text="YES"></asp:ListItem>
										<asp:ListItem Value="N" Text="NO"></asp:ListItem>
                                    </asp:DropDownList> 
                            </div>
						 </div>--%>
<%--					 <div class="row rowspacing" >
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblURL" runat="server" CssClass="control-label" Text="Integration URL" Font-Bold="False" ></asp:Label>
                                <asp:TextBox ID="txtURL" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblUsrnm" runat="server" CssClass="control-label" Text="Username" Font-Bold="False"></asp:Label>
								<asp:TextBox ID="txtUsrnm" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>                              
                        </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblPsswrd" CssClass="control-label" runat="server" Text="Password" Font-Bold="False"></asp:Label>
                                    <asp:TextBox ID="txtPsswrd" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox> 
                            </div>
						 </div>--%>
<%--					 <div class="row rowspacing" >
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblIsLcns" CssClass="control-label" runat="server" Text="Is License" Font-Bold="False"></asp:Label>
                                    <asp:DropDownList ID="ddlIsLcns" runat="server" CssClass="form-control">
										<asp:ListItem Value="Y" Text="YES"></asp:ListItem>
										<asp:ListItem Value="N" Text="NO"></asp:ListItem>
                                    </asp:DropDownList> 
                            </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblSrtOrd" runat="server" CssClass="control-label" Text="Sort Order" Font-Bold="False" ></asp:Label>
                                <asp:TextBox ID="txtSrtOrd" Enabled="false" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
                        <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblcreatedte" runat="server" CssClass="control-label" Text="Created Date" Font-Bold="False" ></asp:Label>--%>
                                <%--<asp:TextBox ID="txtcreatedte" CssClass="form-control" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>--%>
<%--							<asp:TextBox ID="txtcreatedte" CssClass="form-control" onmousedown="chosedate();" style="margin-bottom:5px;" runat="server" Font-Bold="False"></asp:TextBox>
                            </div>
					</div>--%>
<%--					 <div class="row rowspacing" >
                        <div class="col-sm-12" style="text-align: center">
                                 <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-success">
                                 <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Save
                                </asp:LinkButton>  
                                     <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-clear" TabIndex="44">
                                <span class="glyphicon glyphicon-remove" style="color:#00cccc"> </span> Cancel
                                </asp:LinkButton>							
                            </div>
					</div>--%>
<%--					 <div class="row rowspacing" >--%>
<%--						 <div class="col-sm-3" style="text-align: left">
							 </div>
						 <div class="col-sm-3" style="text-align: left">
							 </div>--%>
<%--						 <div class="col-sm-3" style="text-align: left">
						 <asp:TextBox ID="txtIntgNme" CssClass="form-control" style="margin-bottom:5px" runat="server" Font-Bold="False"></asp:TextBox>
							 </div>
						 <div class="col-sm-3" style="text-align: left">
                                 <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" BorderColor="White" CssClass="btn btn-clear">
                                 <span class="glyphicon glyphicon-search" style="color:#00cccc"> </span>
                                </asp:LinkButton>  
                                     <asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" BorderColor="White" CssClass="btn btn-clear" TabIndex="44">
                                <span class="glyphicon glyphicon-plus" style="color:#00cccc"> </span>
                                </asp:LinkButton>							
					</div>
						 </div>--%>
<%--						<br />--%>
                        <div id="div5" runat="server" style="width: 107%; border: none; margin: 0px 0 !important;"
                            class="table-scrollable">

					 <div class="row" >
						 <div class="col-sm-12" style="text-align: right;padding-bottom:7px">
						 <asp:TextBox ID="txtIntgNme" placeholder="Search Integration" CssClass="form-control" style="margin-bottom:5px;width: 252px;display: inline;;border:none;border-bottom:1px solid black" runat="server"  Font-Bold="False"></asp:TextBox>
                                 <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" BorderColor="White" CssClass="btn btn-clear">
                                 <span class="glyphicon glyphicon-search" style="color:#00cccc"> </span>
                                </asp:LinkButton>  
                                     <asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" BorderColor="White" CssClass="btn btn-clear" TabIndex="44">
                                <span class="glyphicon glyphicon-plus" style="color:#00cccc"> </span>
                                </asp:LinkButton>							
					</div>
						 </div>


                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_DBFunction" runat="server" CssClass="footable"
                                        AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false"
                                         OnRowDataBound="gv_DBFunction_RowDataBound" PageSize="50">
                                       <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Code" SortExpression="IntrgtId">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCode" runat="server" Text='<%# Bind("IntrgtId")%>'></asp:Label>
                                                </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" SortExpression="IntrgtNme">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesc1" runat="server" Text='<%# Bind("IntrgtNme")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="URL" SortExpression="IntrgtUrl">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
													<asp:LinkButton ID="lnkIntgURL" runat="server" OnClick="lnkIntgURL_Click" Text='<%# Bind("IntrgtUrl")%>'></asp:LinkButton>
                                                    <asp:Label ID="lblIntgURL" runat="server" Visible="false" Text='<%# Bind("IntrgtUrl")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Name" SortExpression="UsrNme">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIntgUsrnme" runat="server" Text='<%# Bind("UsrNme")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Password" Visible="false" SortExpression="PassWrd">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
													<asp:Label ID="lblIntgPsswrdNew" runat="server" Text='<%# Bind("PassWrdNew")%>'></asp:Label>
                                                    <asp:Label ID="lblIntgPsswrd" runat="server" Visible="false" Text='<%# Bind("PassWrd")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
<%--                                            <asp:TemplateField HeaderText="Sort Order" SortExpression="SortOrder">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSrtOrdr" runat="server" Text='<%# Bind("SortOrder")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>--%>
<%--                                            <asp:TemplateField HeaderText="Is License" SortExpression="IsLicens">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
													<asp:Label ID="lblIsLicensDesc" runat="server" Text='<%# Bind("IsLicensDesc")%>'></asp:Label>
                                                    <asp:Label ID="lblIsLicense" runat="server" Visible="false" Text='<%# Bind("IsLicens")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Is Active" SortExpression="IsActv">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
													<asp:Label ID="lblIsActvDesc" runat="server" Text='<%# Bind("IsActvDesc")%>'></asp:Label>
                                                    <asp:Label ID="lblIsActive" runat="server" Visible="false" Text='<%# Bind("IsActv")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
<%--                                            <asp:TemplateField HeaderText="Is Mandatory" SortExpression="IsMndtry">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
													<asp:Label ID="lblIsMndtryDesc" runat="server" Text='<%# Bind("IsMndtryDesc")%>'></asp:Label>
                                                    <asp:Label ID="lblIsMndtry" runat="server" Visible="false" Text='<%# Bind("IsMndtry")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEditRwdTrg" OnClick="lnkEditRwdTrg_Click" runat="server" Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Event">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkMapTrg" OnClick="lnkMapTrg_Click" runat="server" Text="Map"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Steps">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkstpsVew" OnClick="lnkstpsVew_Click" runat="server" Text="View"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Agreement">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkAgrmnt" OnClick="lnkAgrmnt_Click" runat="server" Text="view"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        
                        <center>
                            <div id="divRwdPgTrg" visible="true" runat="server" class="pagination" style="padding-top: 10px;padding-left:483px">
                                <center>
                                    <table>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnprev" Text="<" CssClass="form-submit-button" runat="server" Enabled="false" OnClick="btnprev_Click"
                                                            Width="40px" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" />
                                                        <asp:TextBox runat="server" ID="txtpgrwdtrg" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Enabled="false" OnClick="btnnext_Click"
                                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                             />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                        </center>
						<br />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gventinact" runat="server" CssClass="footable"
                                        AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false"
                                         PageSize="50">
                                       <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Code" SortExpression="IntrgtId">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodeInac" runat="server" Text='<%# Bind("IntrgtId")%>'></asp:Label>
                                                </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" SortExpression="IntrgtNme">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesc1Inac" runat="server" Text='<%# Bind("IntrgtNme")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="URL" SortExpression="IntrgtUrl">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
													<asp:LinkButton ID="lnkIntgURLInac" runat="server" OnClick="lnkIntgURLInac_Click" Text='<%# Bind("IntrgtUrl")%>'></asp:LinkButton>
                                                    <asp:Label ID="lblIntgURLInac" runat="server" Visible="false" Text='<%# Bind("IntrgtUrl")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Name" SortExpression="UsrNme">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIntgUsrnmeInac" runat="server" Text='<%# Bind("UsrNme")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Password" Visible="false" SortExpression="PassWrd">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
													<asp:Label ID="lblIntgPsswrdNewInac" runat="server" Text='<%# Bind("PassWrdNew")%>'></asp:Label>
                                                    <asp:Label ID="lblIntgPsswrdInac" runat="server" Visible="false" Text='<%# Bind("PassWrd")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
<%--                                            <asp:TemplateField HeaderText="Sort Order" SortExpression="SortOrder">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSrtOrdr" runat="server" Text='<%# Bind("SortOrder")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>--%>
<%--                                            <asp:TemplateField HeaderText="Is License" SortExpression="IsLicens">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
													<asp:Label ID="lblIsLicensDesc" runat="server" Text='<%# Bind("IsLicensDesc")%>'></asp:Label>
                                                    <asp:Label ID="lblIsLicense" runat="server" Visible="false" Text='<%# Bind("IsLicens")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Is Active" SortExpression="IsActv">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
													<asp:Label ID="lblIsActvDescInac" runat="server" Text='<%# Bind("IsActvDesc")%>'></asp:Label>
                                                    <asp:Label ID="lblIsActiveInac" runat="server" Visible="false" Text='<%# Bind("IsActv")%>'></asp:Label>
													<asp:Label ID="lblEntyId" runat="server" Visible="false" Text='<%# Bind("EntyId")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
<%--                                            <asp:TemplateField HeaderText="Is Mandatory" SortExpression="IsMndtry">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
													<asp:Label ID="lblIsMndtryDesc" runat="server" Text='<%# Bind("IsMndtryDesc")%>'></asp:Label>
                                                    <asp:Label ID="lblIsMndtry" runat="server" Visible="false" Text='<%# Bind("IsMndtry")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEditRwdTrgInac" OnClick="lnkEditRwdTrgInac_Click" runat="server" Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Event">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkMapTrgInac" OnClick="lnkMapTrgInac_Click" runat="server" Text="Map"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Steps">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkstpsVewInac" OnClick="lnkstpsVewInac_Click" runat="server" Text="View"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Agreement">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkAgrmntInac" OnClick="lnkAgrmntInac_Click" runat="server" Text="view"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        <center>
                            <div id="div1" visible="true" runat="server" class="pagination" style="padding-top: 10px;padding-left:483px">
                                <center>
                                    <table>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnprevinac" Text="<" CssClass="form-submit-button" runat="server" Enabled="false" OnClick="btnprevinac_Click"
                                                            Width="40px" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" />
                                                        <asp:TextBox runat="server" ID="txtpgrwdtrginac" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnextinac" Text=">" CssClass="form-submit-button" runat="server" Enabled="false" OnClick="btnnextinac_Click"
                                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                             />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                        </center>
					</div>
                    </div>
                </div>
			</div>
                <asp:HiddenField ID="hdnCnt" runat="server" />
                <asp:HiddenField ID="hdnFlag" runat="server" />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel runat="server" Height="275px" Width="1020px" ID="pnlMdl" display="none" CssClass="panel panel-success"
        Style="text-align: center; padding: 10px;">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" Height="500px" Width="1020px" ID="pnlQualTrg" display="none" CssClass="card"
        Style="text-align: center;">
        <iframe runat="server" id="ifrmQualTrg" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label4" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVwQTrg" BehaviorID="mdlVwQTrgBID"
        DropShadow="false" TargetControlID="Label4" PopupControlID="pnlQualTrg" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

</asp:Content>

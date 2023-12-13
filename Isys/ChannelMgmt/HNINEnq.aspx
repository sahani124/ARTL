<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HNINEnq.aspx.cs" Inherits="Application_Isys_ChannelMgmt_HNINEnq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />

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
    <script>
        //Ifsc code validation
        function AllowIFSC(id) {
            debugger;
            var val = document.getElementById(id).value.trim();
            if (val) {
                if (val.length == "") {
                    alert("Please Enter IFSC code");
                    return false;
                }
                else if (val.length > 11 || val.length < 11) {
                    alert("IFSC Code Should be 11 digit long");
                    return false;
                }
                else {
                    var regex = /^[a-zA-Z]*$/;
                    var regex_for_alphanum = /^[a-zA-Z0-9]*$/
                    if (!(regex.test(val.substring(0, 4)) && val.charAt(4) == '0' && regex_for_alphanum.test(val.substring(5)))) {
                        alert("Invalid IFSC code format");
                        return false;
                    }
                    else {
                        return true;
                    }
                }
            }
            else {
                alert("Please Enter IFSC code");
                return false;
            }
        }

        function isEmpty(str) {
            if ((str == null) || (str == "") || (str == " "))
                return true;
            return false;
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

        function validatiion() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById("ddlnmbnkhldname").value == null || document.getElementById("ddlnmbnkhldname").value == "") {
                alert("Please Enter Account Holder Name");
                document.getElementById("ddlnmbnkhldname").focus();
                return false;
            }
            if (SpaceTrim(document.getElementById("txtnmbnkacno").value) == null || SpaceTrim(document.getElementById("txtnmbnkacno").value) == "") {
                alert("Please Enter Bank Account No");
                document.getElementById("txtnmbnkacno").focus();
                return false;
            }
            if (SpaceTrim(document.getElementById("ddlnmifscode").value) == null || SpaceTrim(document.getElementById("ddlnmifscode").value) == "") {
                alert("Please Enter Bank IFSC code");
                return false;
            }
            else {
                debugger;
                var ifsc = document.getElementById("ddlnmifscode").value;
                var reg = /[A-Za-z]{4}[0]{1}[A-Za-z0-9]{6}$/;
                if (!ifsc.match(reg)) {
                    alert("Please Enter Correct Bank IFSC code");
                    return false;
                }
            }
            if (document.getElementById("ddlnmddlactype").selectedIndex == 0 || document.getElementById("ddlnmddlactype").selectedIndex == null) {
                alert("Please select Account type");
                document.getElementById("ddlnmddlactype").focus();
                return false;
            }
            if (SpaceTrim(document.getElementById("ddlnmBrnchname").value) == "" || SpaceTrim(document.getElementById("ddlnmBrnchname").value) == null) {
                alert("Please Enter Branch Name");
                document.getElementById("ddlnmBrnchname").focus();
                return false;
            }
            if (document.getElementById("ddlnmBnkname").value == null || document.getElementById("ddlnmBnkname").value == "") {
                alert("Please Enter Bank Name");
                document.getElementById("ddlnmBnkname").focus();
                return false;
            }
            if (document.getElementById("txtnmmicr").value != "") {
                if (document.getElementById("txtnmmicr").value.length != 9) {
                    alert("MICR Code Should be 9 Digit.");
                    document.getElementById("txtnmmicr").focus();
                    return false;
                }
            }
        }

        function NomieeIfsc() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (!AllowIFSC("ddlnmifscode")) {
                return false;
            }
        }

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

        function showerrormsg(vmsg) {
            var vmsg = document.getElementById("<%=lblError2.ClientID%>").value.split(",")
            alert(vmsg);
        }
    </script>

    <style>
        .clsRight {
            text-align: right !important;
        }

        .clsLeft {
            text-align: left !important;
        }

        .clsCenter {
            text-align: center !important;
        }

        .gridview th {
            height: 40px;
            border-color: #53accd !important;
            font-family: VAG Rounded Std Light;
            font-size: 15px;
            white-space: nowrap;
            border-width: 1px;
            border-left: 0px;
            border-right: 0px;
            padding:10px !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="SM1" runat="server">
        </asp:ScriptManager>
        <div class="card PanelInsideTab">
            <div id="divpanel6" runat="server">
                <div id="Div6" runat="server" class="panelheadingAliginment">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <asp:Label ID="Label3" runat="server" Text="Nominee Details" CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="spnnomdtls" class="glyphicon glyphicon-chevron-up" style="float: right; color: #00CCCC; padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('divNomineeDetails','spnnomdtls');return false;"></span>
                        </div>
                    </div>
                </div>
                <div id="divNomineeDetails" style="display: block;" runat="server" class="panel-body panelContent">
                    <div class="row">
                        <div class="col-sm-4" style="text-align: left">
                            <asp:Label ID="Label5" Text="Nominee Name" CssClass="control-label labelSize" runat="server"></asp:Label>
                            <asp:TextBox ID="txtNominee" runat="server" CssClass="form-control " onChange="javascript:this.value=this.value.toUpperCase();" Enabled="false"
                                MaxLength="100" TabIndex="76"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" "
                                TargetControlID="txtNominee">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                        <div class="col-sm-4" style="text-align: left">
                            <asp:Label ID="Label6" Text="DOB" CssClass="control-label labelSize" runat="server"></asp:Label>
                            <asp:TextBox ID="txtNomDob" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control" Enabled="false"></asp:TextBox>

                        </div>
                        <div class="col-sm-4" style="text-align: left">
                            <asp:Label ID="lblNominMob" Text="Nominee Mobile No" CssClass="control-label labelSize" runat="server"></asp:Label>
                            <asp:TextBox ID="txtNominMob" runat="server" CssClass="form-control" Enabled="false"
                                MaxLength="10" TabIndex="80"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender94" runat="server"
                                FilterType="Custom,Numbers"
                                TargetControlID="txtNominMob">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <div class="row rowspacing">
                        <div class="col-sm-4">
                            <asp:Label ID="lblNomneeEmail" CssClass="control-label labelSize" Text="Nominee Email" runat="server"></asp:Label>
                            <asp:TextBox ID="txtNomneeEmail" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();" Enabled="false"
                                MaxLength="100" TabIndex="79"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="Label7" Text="HNIN Code" runat="server" CssClass="control-label labelSize"></asp:Label>
                            <asp:TextBox ID="txthnin" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div id="Div27" runat="server" class="panelheadingAliginment">
                    <div class="row rowspacing">
                        <div class="col-sm-10" style="text-align: left">
                            <asp:Label ID="Label51" runat="server" Text="Nominee Account Details" CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="spnNmdtls" class="glyphicon glyphicon-chevron-up" style="float: right; color: #00CCCC; padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('Nombankdtl','spnNmdtls');return false;"></span>
                        </div>
                    </div>
                </div>

                <div id="Nombankdtl" runat="server" class="panel-body panelContent">
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
                            <asp:TextBox ID="txtnmbnkacno" runat="server" CssClass="form-control mandatory" TabIndex="83" MaxLength="20" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender88" runat="server"
                                FilterType="Custom,Numbers"
                                TargetControlID="txtnmbnkacno">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                        <div class="col-sm-4">
                            <asp:UpdatePanel ID="Updatepanel8" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblnmifscode" runat="server" Text="Bank IFSC Code" CssClass="control-label labelSize"></asp:Label>
                                    <asp:TextBox ID="ddlnmifscode" runat="server" CssClass="form-control mandatory" TabIndex="87" MaxLength="11" OnTextChanged="ddlnmifscode_TextChanged" AutoPostBack="true" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlnmifscode" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-1" style="text-align: right; display: none;">
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
                            <asp:DropDownList ID="ddlnmddlactype" runat="server" CssClass="form-control form-select mandatory" Style="width: 100%" TabIndex="85">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Saving" Value="Saving"></asp:ListItem>
                                <asp:ListItem Text="Current" Value="Current"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <asp:UpdatePanel ID="Updatepanel1" runat="server">
                                <ContentTemplate>
                            <asp:TextBox ID="ddlnmBrnchname" runat="server" CssClass="form-control mandatory" TabIndex="86"></asp:TextBox>
                                    </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlnmifscode" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-4">
                              <asp:UpdatePanel ID="Updatepanel2" runat="server">
                                <ContentTemplate>
                            <asp:TextBox ID="ddlnmBnkname" runat="server" CssClass="form-control mandatory" TabIndex="84" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                         </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlnmifscode" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel></div>
                    </div>
                    <div class="row rowspacing">

                        <div class="col-sm-4">
                            <asp:Label ID="lblnmmicr" runat="server" Text="MICR Code" CssClass="control-label labelSize"></asp:Label>
                            <asp:TextBox ID="txtnmmicr" runat="server" CssClass="form-control" TabIndex="88" MaxLength="9"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender95" runat="server"
                                FilterType="Custom,Numbers"
                                TargetControlID="txtnmmicr">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                    </div>
                </div>
                <br />
                <div id="Div26" runat="server" class="panelheadingAliginment">
                    <div class="row spacebetnrow" id="div25" runat="server" style="text-align: left;">
                        <div class="col-sm-10">
                            <asp:Label ID="Label32" runat="server" CssClass="control-label HeaderColor"
                                Text="Document Upload"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="spndocupld" class="glyphicon glyphicon-chevron-up" style="float: right; color: #00CCCC; padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('div1','spndocupld');return false;"></span>
                        </div>
                    </div>


                </div>

                <div id="div1" runat="server" style="display: block;" class="panel-body" width="100%">
                    <div class="row" id="tblupload" style="margin-bottom: 5px;">
                        <div class="col-sm-12" style="text-align: center;">
                            <asp:Label ID="lblNote" runat="server" Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/PNG/PDF format"
                                ForeColor="red"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="card" runat="server" style="overflow: auto; margin-top: 10px; padding: 10px">
                        <asp:UpdatePanel ID="upddgView" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgView" runat="server" AllowSorting="True"
                                    OnPageIndexChanging="dgView_PageIndexChanging" CssClass="footable"
                                    OnRowCommand="dgView_RowCommand"
                                    OnRowDataBound="dgView_RowDataBound" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True" Width="100%" PageSize="15">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Document Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldocName" runat="server" Font-Size="11px" Text='<%#Bind("ImgDesc01") %>'></asp:Label>
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
                                            <ItemStyle CssClass="clsCenter" />
                                            <HeaderStyle CssClass="clsCenter" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Upload Documents">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                                    <ContentTemplate>
                                                        <asp:FileUpload ID="FileUpload" runat="server"></asp:FileUpload>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_Upload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                          <ItemStyle CssClass="clsLeft" />
                                            <HeaderStyle CssClass="clsLeft" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btn_Upload" runat="server" CssClass="btn btn-success" Style="width: 95px; height: 37px;" Text="Upload" Enabled="false" Visible="false"
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
                                           <ItemStyle CssClass="clsLeft" />
                                            <HeaderStyle CssClass="clsLeft" />
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
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPreview" runat="server" Text="Preview" CommandArgument='<%# Eval("DocCode") %>' CommandName="Preview"
                                                    Font-Size="15px" Style="width: 95px; height: 37px;">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                    </Columns>

                                    <FooterStyle CssClass="GridViewFooter" />
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <HeaderStyle CssClass="gridview th" />
                                    <PagerStyle CssClass="disablepage" />
                                </asp:GridView>
                            </ContentTemplate>

                        </asp:UpdatePanel>

                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12" style="text-align: center;">
                        <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-success" OnClick="btnupdate_Click" OnClientClick="return validatiion();"
                            TabIndex="358">UPDATE
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"> </span> 
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-clear" TabIndex="359" OnClick="btnCancel_Click"> CANCEL 
                        </asp:LinkButton>
                    </div>
                </div>

            </div>
            <asp:Label ID="lblError2" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>

        <asp:UpdatePanel ID="pop1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnl" runat="server" Style="border-color: activeborder; height: 40%; width: 32%; border: solid 1px; border-color: #00cccc; background-color: white; position: fixed; z-index: 100001; left: 426.5px; top: 100px; margin-top: 50px;">
                    <div id="divAlert" runat="server" style="width: 100%; display: block; border: 0px !important; height: 50% !important;" cellpadding="0" cellspacing="0">
                        <div id="Div2" runat="server" style="width: 100% !important">
                            <div id="Div3" runat="server">
                                <center style="color: #034ea2; font-size: 22px; padding: 10px; width: 100%;" cssclass="control-label HeaderColor">INFORMATION</center>
                            </div>
                        </div>
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-12" style="text-align: center;">
                                    <center>
                        <asp:Label ID="lbl2" runat="server" ></asp:Label><br />
                    </center>
                                </div>
                            </div>
                        </div>
                        <br />
                        <center>
            <div class="row">
                <div class="col-sm-12" style="text-align:center;">
                       <asp:LinkButton ID="btnok" runat="server" CssClass="btn btn-success" TabIndex="113" 
                                                    >
                                     <span class="glyphicon glyphicon-ok" style='color:White;'></span> OK 
                                                </asp:LinkButton>
                </div>
            </div>
         
                     </center>



                    </div>
                </asp:Panel>

                <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl2"
                    BehaviorID="mdlpopup" PopupControlID="pnl" BackgroundCssClass="modalPopupBg"
                    OkControlID="btnok" Y="100">
                </ajaxToolkit:ModalPopupExtender>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>

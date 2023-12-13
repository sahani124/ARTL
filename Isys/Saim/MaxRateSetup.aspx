<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="MaxRateSetup.aspx.cs" Inherits="Application_Isys_Saim_MaxRateSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
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
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            debugger;
            $("#<%= txtFrmDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtToDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

            $("#<%= txtEffdate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtCseDt.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });

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
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }


        function validate() {

            var strcontent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strcontent + "txtMaxRateDesc1") != null) {
                if (document.getElementById(strcontent + "txtMaxRateDesc1").value == "") {
                    alert("Please enter max rate description");
                    document.getElementById(strcontent + "txtMaxRateDesc1").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlChn") != null) {
                if (document.getElementById(strcontent + "ddlChn").value == "") {
                    alert("Please select hierarchy name");
                    document.getElementById(strcontent + "ddlChn").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlChnCls") != null) {
                if (document.getElementById(strcontent + "ddlChnCls").value == "") {
                    alert("Please select sub class");
                    document.getElementById(strcontent + "ddlChnCls").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlProductcodeCategory") != null) {
                if (document.getElementById(strcontent + "ddlProductcodeCategory").value == "") {
                    alert("Please select product category");
                    document.getElementById(strcontent + "ddlProductcodeCategory").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlProduct") != null) {
                if (document.getElementById(strcontent + "ddlProduct").value == "") {
                    alert("Please select product");
                    document.getElementById(strcontent + "ddlProduct").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlMaxRatetype") != null) {
                if (document.getElementById(strcontent + "ddlMaxRatetype").value == "") {
                    alert('Please select unit type.');
                    document.getElementById(strcontent + "ddlMaxRatetype").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlMaxRateUSbtype") != null) {
                if (document.getElementById(strcontent + "ddlMaxRateUSbtype").value == "") {
                    alert("Please select unit sub type.");
                    document.getElementById(strcontent + "ddlMaxRateUSbtype").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtMaxRate") != null) {
                if (document.getElementById(strcontent + "txtMaxRate").value == "") {
                    alert("Please enter max rate");
                    document.getElementById(strcontent + "txtMaxRate").focus();
                    return false;
                }
            }


            if (document.getElementById(strcontent + "ddlCategory") != null) {
                if (document.getElementById(strcontent + "ddlCategory").value == "") {
                    alert("Please select category");
                    document.getElementById(strcontent + "ddlCategory").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtFrmDate") != null) {
                if (document.getElementById(strcontent + "txtFrmDate").value == "") {
                    alert("Please enter from date");
                    document.getElementById(strcontent + "txtFrmDate").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtEffdate") != null) {
                if (document.getElementById(strcontent + "txtEffdate").value == "") {
                    alert("Please enter ver. effective date");
                    document.getElementById(strcontent + "txtEffdate").focus();
                    return false;
                }
            }



            //            function ShowReqDtl(divId, btnId, img) {
            //                var strContent = "ctl00_ContentPlaceHolder1_";
            //                $(document.getElementById(strContent + divId)).slideToggle();
            //                if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
            //                    $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            //                }
            //                else {
            //                    $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            //                }
            //            }

            //            function CloseDiv(divId) {
            //                debugger;
            //                var strContent = "ctl00_ContentPlaceHolder1_";
            //                if (document.getElementById(strContent + divId) != null) {
            //                    document.getElementById(strContent + divId).style.display = 'none';
            //                }
            //            }

            //            function funPopUp() {
            //                ////alert('akshay');
            //                var strContent = "ctl00_ContentPlaceHolder1_";
            //                $find("mdlViewBID").show();
            //                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopFrmEditor.aspx?mdlpopup=mdlViewBID&funckey="
            //                    + document.getElementById(strContent + "hdnfunckey").id + "&lstkey=" + document.getElementById(strContent + "hdnlstkey").id
            //                    + "&fldkey=" + document.getElementById(strContent + "hdnfldkey").id
            //                    + "&frml=" + document.getElementById(strContent + "txtFormula").id
            //                    + "&frmlcd=" + document.getElementById(strContent + "hdnFormulaCode").id
            //                   + "&kpicode=" + document.getElementById(strContent + "txtKPICode").value;

            //            }

            //            function funPopUpHyb(kpicode, kpidesc) {
            //                // alert('adscjkbac');
            //                var strContent = "ctl00_ContentPlaceHolder1_";
            //                $find("mdlVwHbBID").show();
            //                document.getElementById("ctl00_ContentPlaceHolder1_ifrmhb").src = "MstTblDesign.aspx?kpidesc=" + kpidesc + "&kpicode=" + kpicode + "&ACT=HYBKPI&mdlpopup=mdlVwHbBID";
        }

        //        function ClearControl() {
        //            debugger;
        //            var strcontent = "ctl00_ContentPlaceHolder1_";
        //            document.getElementById(strcontent + "txtMaxRateDesc1").value == "";
        //            document.getElementById(strcontent + "ddlChn").value == "";
        //            document.getElementById(strcontent + "ddlChnCls").value == "";
        //            document.getElementById(strcontent + "ddlProductcodeCategory").value == "";
        //            document.getElementById(strcontent + "ddlProduct").value == "";
        //            document.getElementById(strcontent + "ddlMaxRatetype").value == "";
        //            document.getElementById(strcontent + "ddlMaxRateUSbtype").value == "";
        //            document.getElementById(strcontent + "txtMaxRate").value == "";
        //            document.getElementById(strcontent + "ddlCategory").value == "";
        //            document.getElementById(strcontent + "txtFrmDate").value == "";
        //            document.getElementById(strcontent + "txtEffdate").value == "";
        //        }
    </script>
    <style type="text/css">
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
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
            vertical-align: top;
        }*/
        
        #ui-datepicker-div
        {
            width: 20.5% !important;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $('#txtFrmDate').datetimepicker();

            $('#txtToDate').datetimepicker();

            $('#txtEffdate').datetimepicker();

            $('#txtCseDt').datetimepicker();
        });
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="divMaxRatehdrcollapse" runat="server" style="width: 97%;" class="panel">
            <div id="Div6" runat="server" class="panel-heading" style="width: 97%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divMaxRatehdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left;font-size:19px;">
                        <%--<span class="glyphicon glyphicon glyphicon-chevron-down" style="color: Orange;"></span>--%>
                        <asp:Label ID="Label1" Text="Max Rate Setup" runat="server" Style="padding-left: 5px;" />
                    </div>
                    <div class="col-sm-2">
                        <span id="myImg" class="glyphicon glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divMaxRatehdr" runat="server" style="width: 96%; display: block" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMaxRateCode" Text="Max Rate Code" runat="server" CssClass="control-label" />
                        <asp:Label ID="lblmratemand" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtMaxRateCode" runat="server" CssClass="form-control" TabIndex="1"
                            placeholder="Max Rate Code" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMaxRateDesc1" Text="Max Rate Description 1" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label3" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtMaxRateDesc1" runat="server" CssClass="form-control" TabIndex="2"
                            placeholder="Max Rate Description 1" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMaxRateDesc2" Text="Max Rate Description 2" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtMaxRateDesc2" runat="server" CssClass="form-control" TabIndex="3"
                            placeholder="Max Rate Description 2" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMaxRateDesc3" Text="Max Rate Description 3" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtMaxRateDesc3" runat="server" CssClass="form-control" TabIndex="4"
                            placeholder="Max Rate Description 3" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCls" Text="Hierarchy Name" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label4" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="updnddlchn" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlChn" runat="server" CssClass="select2-container form-control"
                                    OnSelectedIndexChanged="ddlChn_SelectedIndexChanged" AutoPostBack="true" TabIndex="5">
                                    <%--OnSelectedIndexChanged="ddlChn_SelectedIndexChanged" --%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblSubCls" Text="Sub Class" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label5" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="select2-container form-control"
                                    AutoPostBack="true" TabIndex="6">
                                    <%--OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged"--%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                 <div class="row" style="margin-bottom: 5px;">
                  
                     
                      <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCategory" Text="Category" runat="server" CssClass="control-label" /><asp:Label
                            ID="Label12" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="updnltxtCategory" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" TabIndex="13"
                                    Visible="false" placeholder="Category" />
                                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="10" Enabled="false">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                     
                       <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label2" Text="Product Portfolio" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label14" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlPortfolio" runat="server" CssClass="select2-container form-control"
                                    AutoPostBack="true" TabIndex="5">
                                    <%--OOnSelectedIndexChanged="ddlChn_SelectedIndexChanged""--%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                   
                </div>


                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblProductCode" Text="Product Category" runat="server" CssClass="control-label" />
                        <asp:Label ID="lblProductCodemand" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanelddlProductcodeCategory" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlProductcodeCategory" runat="server" CssClass="select2-container form-control"
                                    AutoPostBack="true" TabIndex="5" OnSelectedIndexChanged="ddlProductcodeCategory_SelectedIndexChanged">
                                    <%--OOnSelectedIndexChanged="ddlChn_SelectedIndexChanged""--%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblProduct" Text="Product" runat="server" CssClass="control-label" />
                        <asp:Label ID="lblProductmand" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="updnlddlProduct" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlProduct" runat="server" CssClass="select2-container form-control"
                                    AutoPostBack="true" TabIndex="6">
                                    <%-- OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged"--%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblKPItype" Text="Unit Type" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label6" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="updnlddlMaxRatetype" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlMaxRatetype" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    OnSelectedIndexChanged="ddlMaxRatetype_SelectedIndexChanged" TabIndex="7">
                                    <%--OnSelectedIndexChanged="ddlKPItype_SelectedIndexChanged"--%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMaxRateUSbtype" Text="Unit Sub Type" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label7" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlMaxRateUSbtype" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="8" OnSelectedIndexChanged="ddlMaxRateUSbtype_SelectedIndexChanged">
                                    <%--OnSelectedIndexChanged="ddlKPISbtype_SelectedIndexChanged"--%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px; display: none">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMsrdOn" Text="Measured As" runat="server" CssClass="control-label" /><asp:Label
                            ID="Label8" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlMeasureAs" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="9">
                                    <%--OnSelectedIndexChanged="ddlMeasureAs_SelectedIndexChanged"--%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblKPIOrg" Text="Max Rate Origin" runat="server" CssClass="control-label" /><asp:Label
                            ID="Label9" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="upnddlMaxRateOrg" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlMaxRateOrg" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="10">
                                    <%--OnSelectedIndexChanged="ddlKPIOrg_SelectedIndexChanged"--%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px; display: none">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblStdMin" Text="Std. Min" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label10" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtStdMin" runat="server" CssClass="form-control" TabIndex="11"
                                    placeholder="Std. Min" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblStdMax" Text="Std. Max" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label11" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtStdMax" runat="server" CssClass="form-control" TabIndex="12"
                                    placeholder="Std. Max" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                   
                    <%-- <div class="col-sm-3" style="text-align: left">
                        <asp:UpdatePanel ID="updnllblSrcUpld" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblSrcUpld" Text="Source of Upload" runat="server" CssClass="control-label"
                                    Visible="false" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSrcUpld" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    Visible="false" TabIndex="10">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>--%>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblmaxraet" Text="Max Rate" runat="server" CssClass="control-label" /><asp:Label
                            ID="Label21" Text="*" runat="server" Style="color: Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="upnltxtMaxRate" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtMaxRate" runat="server" CssClass="form-control" TabIndex="13"
                                    placeholder="MaxRate" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                </div>
                <div style="padding: 10px;">
                    <div id="divdefhdrcollapse" runat="server" style="width: 97%; margin-left: 0px;
                        margin-right: 0px;" class="panel">
                        <div id="Div1" runat="server" class="panel-heading" style="width: 97%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divDefRange','ImgDefRange');return false;">
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left;font-size:19px;">
                                    <%--<span class="glyphicon glyphicon glyphicon-chevron-down" style="color: Orange;"></span>--%>
                                    <asp:Label ID="lblDefRngHdr" Text="Default Range" runat="server" Style="padding-left: 5px;" />
                                </div>
                                <div class="col-sm-2">
                                    <span id="ImgDefRange" class="glyphicon glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                            </div>
                        </div>
                        <div id="divDefRange" runat="server" style="width: 96%; display: block" class="panel-body">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblFrm" Text="From Date" runat="server" CssClass="control-label" /><asp:Label
                                        ID="Label13" Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtFrmDate" runat="server" CssClass="form-control" TabIndex="14"
                                                placeholder="From Date" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblTo" Text="To Date" runat="server" CssClass="control-label" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="updnltxtToDate" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" TabIndex="15"
                                                placeholder="To Date" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblEffdate" Text="Ver. Eff. From" runat="server" CssClass="control-label" />
                                    <asp:Label ID="Label16" Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="updnltxtEffdate" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtEffdate" runat="server" CssClass="form-control" TabIndex="18"
                                                placeholder="Ver. Eff. From" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblCseDt" Text="Ver. Eff. To" runat="server" CssClass="control-label" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="updnltxtCseDt" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCseDt" runat="server" CssClass="form-control" TabIndex="19" placeholder="Ver. Eff. To" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample"  style="width:85px !important"  TabIndex="24"
                            OnClick="btnSave_Click" > 
                                <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                        </asp:LinkButton>
                        <%----%>
                        <asp:LinkButton ID="btnCancel" runat="server" style="background-color:#FFF;color:#f04e5e; width:85px !important" CssClass="btn btn-sample"  TabIndex="25"
                            OnClick="btnCancel_Click">
                                <span class="glyphicon glyphicon-erase" style="color:#f04e5e"></span> Clear
                        </asp:LinkButton>
                        <%--<button type="button" class="btn btn-primary" onclick="ClearControl();">
                            <span class="glyphicon glyphicon-erase" style="color: White"></span>Clear</button>--%>
                        <%-- OnClick="btnCancel_Click"--%>
                        <asp:LinkButton ID="btnClose" runat="server" CssClass="btn btn-sample" TabIndex="26"
                            OnClick="btnClose_Click">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                        </asp:LinkButton>
                        <%--OnClick="btnClose_Click"--%>
                        <asp:Button ID="btnfrml" runat="server" ClientIDMode="Static" Style="display: none;" />
                        <%--   OnClick="btnfrml_Click"--%>
                    </div>
                </div>
            </div>
        </div>
    </center>
    <asp:Panel ID="pnl" runat="server" Width="400px" Height="250px" CssClass="modal-content">
        <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
            INFORMATION
        </div>
        <div class="modal-body" style="text-align: center">
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
        </div>
        <div class="modal-footer" style="text-align: center">
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn blue" />
        </div>
    </asp:Panel>
    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnfunckey" runat="server" />
            <asp:HiddenField ID="hdnlstkey" runat="server" />
            <asp:HiddenField ID="hdnfldkey" runat="server" />
            <asp:HiddenField ID="hdnFormulaCode" runat="server" />
            <asp:HiddenField ID="hdnFormula" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" Height="100%" Width="100%" ID="pnlMdl" display="none" Style="text-align: center;
        padding: 10px;">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" Height="100%" Width="90%" ID="Panel1" display="none" CssClass="panel panel-success"
        Style="text-align: center; padding: 10px;">
        <table style="width: 100%; height: 100%;">
            <tr>
                <td>
                    <iframe runat="server" id="ifrmhb" scrolling="yes" width="100%" frameborder="0" display="none"
                        style="height: 100%;"></iframe>
                </td>
            </tr>
            <tr id="Tr1" runat="server" style="height: 5px">
                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                    <div class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="btnC" runat="server" CssClass="btn btn-primary" TabIndex="25">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                            </asp:LinkButton>
                            <%--OnClick="btnC_Click"--%>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label runat="server" ID="Label17" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVwHb" BehaviorID="mdlVwHbBID"
        DropShadow="false" TargetControlID="Label17" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopCntst.aspx.cs" Inherits="Application_ISys_Saim_PopCntst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <%--  <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <script language="javascript" type="text/javascript" src="~/Scripts/bootstrap-multiselect.js"></script>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .ajax__calendar {
            z-index: 100px;
        }

        .new_text_new {
            color: #066de7;
        }

        .form-submit-button {
            box-shadow: none !important;
        }

        .disablepage {
            display: none;
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

        .align {
            text-align: left;
        }

        .rowalign {
            margin-bottom: 15px;
        }
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }*/
        .checkboxlistformat label {
            margin-left: 8px;
            position: relative;
            display: inline;
        }
    </style>
    <script type="text/javascript">
        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }

        function doOk() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (window.parent.document.getElementById("btncmp") != null) {
                ////alert("btncmp");
                window.parent.document.getElementById("btncmp").click();
                ////alert("btncmp2564654");
            }
            else {
                ///alert("no btncmp");
            }
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (window.parent.document.getElementById("btncmp") != null) {
                ////alert("btncmp");
                window.parent.document.getElementById("btncmp").click();
                ////alert("btncmp2564654");
            }
            else {
                ///alert("no btncmp");
            }
        }


        //function ShowHidePanel(PanelName) {

        //     var objnewdiv = document.getElementById(divName)
        //}

        function Enable() {
            document.getElementById('ctl00_ContentPlaceHolder1_div3').style.display = "none";
            document.getElementById('ctl00_ContentPlaceHolder1_Loading_gif').style.display = "block";

            sleepThenAct();
            document.getElementById('ctl00_ContentPlaceHolder1_Loading_gif').style.display = "none";

        }
        function sleepThenAct(){
         sleepFor(2000);

}


        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
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
        //$(function () {  
        //    $('#lstrulstky').multiselect({  
        //        includeSelectAllOption: true  
        //    });  
        //});
    </script>
    <center style="background-color: white;">
        <div id="divcmphdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-top: 0.5%">
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <span >
                                    <img id="imgCodeIcon1" src="../../../KMI%20Styles/assets/css/Images/contestant_details.jpg"/>
                                </span>&nbsp;
                        <asp:Label ID="lblhdr" Text="SELECT CONTESTANT" runat="server" font-size="19px"/>
                    </div>
                    <div class="col-sm-2">
                        <span id="myImg" class="glyphicon glyphicon-chevron-down"style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px; margin-top:12px"></span>
                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" class="panel-body" style="display: block; margin-top: 0.9%; margin-bottom: 0.9%">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblSlsChnl" Text="Sales Channel" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSlsChnl" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4" OnSelectedIndexChanged="ddlSlsChnl_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label1" Text="Sub Class" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlChnCls" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4" OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label3" Text="Unit Rank" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlUnitRank" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                     <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label2" Text="Participation Definition" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlPartcpDef" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4" OnSelectedIndexChanged="ddlPartcpDef_SelectedIndexChanged">

                                       
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                </div>
                 <div class="row" style="margin-bottom: 5px;" id="divLoc"  runat="server" >
                    <div class="col-sm-3" style="text-align: left">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                        <asp:Label ID="Label4" Text="Location Type" runat="server" CssClass="control-label" visible="False" />
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DdlLocation" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4" visible="False">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                 </div>
                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate> <%--OnClientClick="Enable()"--%>
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample"  OnClick="btnSearch_Click">  
                                        <span class="glyphicon glyphicon-search" style="color: White;"></span> SEARCH
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample" style="background-color:#FFF;color:#f04e5e; width:85px !important" OnClick="btnCancel_Click">
                                        <span class="glyphicon glyphicon-erase" style="color: #f04e5e;"></span> CLEAR
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCncl" runat="server" CssClass="btn btn-sample" OnClientClick="doCancel();return false;">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> CANCEL
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
              

             
               <%-- <div id="Table1" runat="server" class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnCncl" runat="server" CssClass="btn btn-primary" OnClientClick="doCancel();return false;">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                        </asp:LinkButton>
                    </div>
                </div>--%>
            </div>
            </div>

        <%--<2nd panel>--%>
            <div id="div1" runat="server" class="panel" style="margin-left: 2%; margin-top: 0.5%">
            <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div3','myImg1');return false;">
                <div class="row">

                     <div class="col-sm-10" style="text-align: left">

                         <div class="col-sm-6" style="margin-left: -10px !important">
                              <span> <img  src="../../../KMI%20Styles/assets/css/Images/contestant_details.jpg"/>
                                </span>&nbsp;
                        <asp:Label ID="lblhdr1" Text="CONTESTANT DETAILS" runat="server" font-size="19px" />

                         </div>
                         <div class="col-sm-6">
                             <img id="Loading_gif"  style="display:none;"  runat="server" src="../Recruit/assets/img/animated_gif_loader.gif" />  <%--style="margin-top:5px;margin-right:100px" --%>
                         </div>
                  
                         </div>
                    <div class="col-sm-2">
                        <span id="myImg1" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px; margin-top:12px"></span>
                    </div>

                  </div>
                
            </div>
                 <div id="div3" runat="server" class="panel-body" style="display: block; margin-top: 0.9%; margin-bottom: 0.9%">
                 

                      <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div style="display: block; margin-top: 0.9%;margin-bottom: 0.9%">
                            <asp:GridView ID="dgCntst" runat="server" AutoGenerateColumns="false" Width="100%"
                                PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" OnPageIndexChanging="dgCntst_PageIndexChanging"
                                OnSorting="dgCntst_Sorting">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sales Channel" SortExpression="CHN">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("CHN")%>' />
                                            <asp:HiddenField ID="hdnSlsChnl" runat="server" Value='<%# Bind("BizSrc")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Class" SortExpression="CHNCLS">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubCls" runat="server" Text='<%# Bind("CHNCLS")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnSubCls" runat="server" Value='<%# Bind("ChnClsVal")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Type" SortExpression="MEMTYPE">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MEMTYPE")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnMemType" runat="server" Value='<%# Bind("MemTypeVal")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Rank" SortExpression="UnitRank">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUntRnk" runat="server" Text='<%# Bind("UnitRank")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnUntRnk" runat="server" Value='<%# Bind("UnitRank")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Unit Type" SortExpression="Unittype">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUntType" runat="server" Text='<%# Bind("UnitType")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnUntType" runat="server" Value='<%# Bind("UnitType")%>' />
                                             <asp:HiddenField ID="hdnActualUnitType" runat="server" Value='<%# Bind("ActualUnitType")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChkSelect_CheckedChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div id="divPage" visible="false" runat="server" class="pagination">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                 
                </div>
                </div>
        <%--<2nd panel>--%>
        
         <div id="div4" runat="server" class="panel" style="margin-left: 2%; margin-top: 0.5%">
              <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div7','myImg2');return false;">
                <div class="row">
                      <div class="col-sm-10" style="text-align: left">
                         <span> <img  src="../../../KMI%20Styles/assets/css/Images/contestant_details.jpg"/>
                                </span>&nbsp;
                        <asp:Label ID="Label5" Text="COPY FROM EXISTING CONTESTANT" runat="server" font-size="19px" Style="padding-left: 5px;" />
                    </div>
                    <div class="col-sm-2">
                        <span id="myImg2" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px; margin-top:12px"></span>
                    </div>
                    </div>
             </div>
             <div id="div7" runat="server" class="panel-body" style="display: block; margin-top: 0.9%; margin-bottom: 0.9%">
                    <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="LblAddCntstRef" Text="Add Reference Contestant" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlAddCntstRef" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4" OnSelectedIndexChanged="ddlAddCntstRef_SelectedIndexChanged">
                                        <asp:ListItem Value="">--SELECT--</asp:ListItem>
                                        <asp:ListItem Value="Y">YES</asp:ListItem>
                                        <asp:ListItem Value="N">NO</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                     <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblRefcntst" Text="Reference Contestant" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlRefcntst" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4" OnSelectedIndexChanged="ddlRefcntst_SelectedIndexChanged">

                                       
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Lblrulstky" Text="Add Ruleset Key" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:checkboxlist ID="lstrulstky" runat="server" AutoPostBack="false" Align="left"
                                    TabIndex="4" SelectionMode="Multiple" CssClass="checkboxlistformat">
                                </asp:checkboxlist>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                        <div id="tblOK" runat="server" visible="true" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnOK" runat="server" CssClass="btn btn-sample" OnClick="btnOK_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btncancel1" runat="server" style="background-color:#FFF;color:#f04e5e; width:85px !important" CssClass="btn btn-sample" OnClientClick="doCancel();return false;">
                                <span class="glyphicon glyphicon-remove" style="color:#f04e5e"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
         </div>


    </center>
</asp:Content>

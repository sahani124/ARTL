<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="ARTLConfigSetup.aspx.cs"
    Inherits="Application_Admin_ARTLConfigSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
  <%--  <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />

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
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
  <%--  
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    
    
    
    <link href="../../KMI Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href ="../../KMI Styles/Bootstrap/css/bootstrap.min.css" rel ="Stylesheet" type="text/css" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
   
    <script src="../../Styles/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>--%>
    <script language="javascript" type="text/javascript">

        function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
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
    </script>

     <style type="text/css">
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
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #F04E5E;
            color: White;
            white-space: nowrap
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <center>
        <div runat="server" style="width: 95%;" class="panel">
            <div class="row">
                <asp:Label ID="lblMsg" runat="server" Visible="false" ForeColor="Red"></asp:Label>
            </div>
            <%--<div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-success">--%>
                    
                        <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div3','btndivchnDetails');return false;">
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left">
                                    <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                                    <asp:Label ID="lblTitle" runat="server" Text="ARTL Configuration Setup" CssClass="control-label" style="font-size: 10.2pt;"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <span id="btndivchnDetails" class="glyphicon glyphicon-collapse-down" style="float: right;
                                        color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>
                                </div>
                            </div>
                        </div>
                        <div id="div3" runat="server" class="panel-body" style="display: block; overflow: auto;">
                            <asp:GridView ID="gvARTLSetup" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                Width="100%" CssClass="footable" AllowPaging="True"  
                                 AllowSorting="True" PageSize="30" OnRowDataBound="gvARTLSetup_RowDataBound">
                               <RowStyle CssClass="GridViewRowNEW"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="True" HeaderText="Sr.No." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblSRNo" Text='<%# Bind("SRNo") %>'></asp:Label>
                                            <%-- <asp:Label runat="server" ID="lblSNo" Text='<%# Eval("SNo.") %>' ></asp:Label>--%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <%--CssClass="pad"--%>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="True" HeaderText="Configuration Description">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDesc" Text='<%# Eval("Desc01") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                        <%--CssClass="pad"--%>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="True" HeaderText="Configuration Value">
                                        <ItemTemplate>
                                            <asp:UpdatePanel runat="server" ID="uplDDLVALUE">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlValue" CssClass="form-control" AutoPostBack="true" Enabled="true"
                                                        runat="server">
                                                        <%--Width="120"--%>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                                <RowStyle CssClass="sublinkodd"></RowStyle>
                                <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                            </asp:GridView>
                        </div>
                    <%--</div>
                </div>
            </div>--%>
            <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                    
                    <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample"  CausesValidation="false"
                        OnClick="btnSave_Click" TabIndex="43">
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Save
                </asp:LinkButton>
            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample"  CausesValidation="false"
                         TabIndex="43" onclick="btnCancel_Click">
                                  <span class="glyphicon glyphicon-erase BtnGlyphicon"></span>Cancel
                 
               
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </center>
</asp:Content>

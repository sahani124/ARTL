<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MAJOR_MVMNT.aspx.cs" Inherits="Application_Isys_Saim_Masters_MAJOR_MVMNT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"   type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"  rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <script type="text/javascript">
        function funStartStep(id) {
            debugger;

            //            alert(id);
            //  alert("NewChanges apply")

            document.getElementById(id).style.display = "none";

            if (id == "ctl00_ContentPlaceHolder1_lnkbtn_apprv") {

                document.getElementById("ctl00_ContentPlaceHolder1_imgStatus").src = "../../../../images/spinner.gif"
                document.getElementById("ctl00_ContentPlaceHolder1_lblStatus").value = "Waiting"


            }
            if (id == "ctl00_ContentPlaceHolder1_lnkbtn_apprv") {
                document.getElementById("ctl00_ContentPlaceHolder1_imgStatus").src = "../../../../images/spinner.gif"
                document.getElementById("ctl00_ContentPlaceHolder1_lblStatus").value = "Waiting"
            }
            if (id == "ctl00_ContentPlaceHolder1_lnkbtn_apprv") {
                document.getElementById("ctl00_ContentPlaceHolder1_imgStatus").src = "../../../../images/spinner.gif"
                document.getElementById("ctl00_ContentPlaceHolder1_lblStatus").value = "Waiting"
            }


        }

        function gotoHome() {
            parent.location.href = parent.location.href;
        }

        function ShowReqDtl1(divName, btnName) {

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

        function CloseDiv(divId) {

            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + divId) != null) {
                document.getElementById(strContent + divId).style.display = 'none';
            }
        }

        </script>
     <style type="text/css">
        /*.disablepage td {
            display: none;
        }

        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }
        .color-white {
            color: #fff !important;
        }

        .grid-container {
            margin-top: 10px;
            max-height: 300px;
            overflow-y: scroll;
        }*/

        /*.divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
            vertical-align: top;
        }

        .custom {
            width: 100px !important;
        }

        
            .grid-container::-webkit-scrollbar {
                width: 5px;
            }

            .grid-container::-webkit-scrollbar-track {
                background: #f1f1f1;
            }

            /* Handle */
            /*.grid-container::-webkit-scrollbar-thumb {
                background: #888;
            }*/

                /* Handle on hover */

        /*.bg-primary {
            color: #fff !important;
            background-color: #337ab7 !important;
        }

        .p-0 {
            padding: 0px;
        }

        .font-14 {
            font-size: 14px;
        }

        .text-black {
            color: #000;
        }

        .glyphicon {
            color: black;
            margin-left: 5px;
            margin-right: 5px;
            cursor: pointer;
        }

        .CenterAlign {
            text-align: center !important;
        }

        .LeftAlign {
            text-align: left !important;
        }

        .RightAlign {
            text-align: right !important;
        }*/

        /*.multiselect {
            overflow: hidden;
            width: 245px;
        }

        .glyphicon:hover {
            color: #fff;
        }

        .btn.focus, .btn:focus, .btn:hover {
            color: #fff !important;
        }

        .multiselect {
            overflow: hidden;
            width: 245px;
        }

        .multiselect-container {
            max-height: 200px;
            overflow: scroll;
        }*/

            /*.multiselect-container::-webkit-scrollbar {
                width: 7px;
                height: 0px;
            }

            /* Track */
            /*.multiselect-container::-webkit-scrollbar-track {
                background: #f1f1f1;
            }

            /* Handle */
            /*.multiselect-container::-webkit-scrollbar-thumb {
                background: #888;
            }

                /* Handle on hover */
               /* .multiselect-container::-webkit-scrollbar-thumb:hover {
                    background: #555;
                }*/
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: -2147483648%;
            left: -23px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
           .new_text_new {
            color: #066de7;
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

        .disablepage {
            display: none;
        }

        .box {
            background-color: #efefef;
            padding-left: 5px;
        }

        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #F04E5E;
            color: White;
            white-space: nowrap;
        }
         </style>

      <asp:ScriptManager ID="ScriptManagermjrmvmnt" runat="server">
    </asp:ScriptManager>
    <center>
    <div id="div2" runat="server" style="margin-left: 2%; margin-right: 2%; margin-top: 0.2%" class="panel">
  <div id="Div4" runat="server" class="panel-heading" style="margin-left: 2%; margin-right: 2%; margin-top: 0.2%">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="Label2" Text="Major Minor Approval Details Search" runat="server" Font-Size="19px" />
                </div>
                <div class="col-sm-2">
                    <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"
                         onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div3','myImg');return false;"></span>
                </div>
            </div>
        </div>
                </div>
    <%--Panel Body start --%>
      <div id="div3" runat="server" style="width: 96%;" class="panel-body">
          <div class="row" style="margin-bottom: 5px;">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblchnl" Text="Channel" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                            <asp:Label ID="Label4" Text="*" runat="server" Style="color: Red" />
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlchnl" runat="server" AutoPostBack="true" CssClass="form-control"
                                        TabIndex="4" OnSelectedIndexChanged="ddlchnl_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblsubchnl" Text="Sub Channel" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                            <asp:Label ID="Label24" Text="*" runat="server" Style="color: Red" />
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlsubchnl" runat="server" CssClass="form-control" TabIndex="4"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlsubchnl_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

          <div class="row" style="margin-bottom: 5px;">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblmemtyp" Text="Member Type" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                            <asp:Label ID="Label3" Text="*" runat="server" Style="color: Red" />
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlMemtyp" runat="server" AutoPostBack="true" CssClass="form-control"
                                        TabIndex="4" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lbltyp" Text="Type" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                            <asp:Label ID="Label6" Text="*" runat="server" Style="color: Red" />
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddltyp" runat="server" CssClass="select2-container form-control" TabIndex="4"
                                        AutoPostBack="true" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
         
                    <div class="row" style="margin-bottom: 5px;">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblaprul" Text="Appraisal Rule" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                            <asp:Label ID="Label5" Text="*" runat="server" Style="color: Red" />
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlapprul" runat="server" AutoPostBack="true" CssClass="form-control"
                                        TabIndex="4" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
           </div>

          <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
    <div class="row" style="margin-bottom: 12px;">
        <div class="col-sm-12" align="center">
            <asp:LinkButton ID="btnsrch" runat="server" CssClass="btn btn-sample"  TabIndex="17" Visible="true" OnClick="btnsrch_Click" >
               <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
            </asp:LinkButton>
             <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample"  TabIndex="17" OnClientClick="gotoHome(); return false;" >
                 <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
            </asp:LinkButton>
            </div>
        </div>
                        </ContentTemplate>
              </asp:UpdatePanel>
          </div>
        
    <%-- Start Of GRIDVIEW --%>

    <asp:updatepanel id="uppnl" runat="server">
            <ContentTemplate>
                   <div id="divcmpsrchhdrcollapse" runat="server"  style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%"  class="panel ">
               <div id="Div1" runat="server" class="panel-heading" style="margin-left: 2%; margin-right: 2%; margin-top: 0.2%">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="Label1" Text="Major Minor Approval Details Search Result" runat="server" Font-Size="19px" />
                </div>
                <div class="col-sm-2">
                    <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"
                         onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divmjrmvmt','myImg1');return false;"></span>
                </div>
            </div>
        </div>
                       
                  
                       <div id="divmjrmvmt" runat="server" class="table-scrollable" style="width: 100%; border: none; margin: 0px 0 !important;">
                           <div id="divGridMap" runat="server" style="width: 100%; overflow-x:scroll">
                               <asp:UpdatePanel runat="server">
                                   <ContentTemplate>
                                       <asp:GridView ID="dgmvmt" runat="server" AllowPaging="true" AllowSorting="True" AutoGenerateColumns="false" CssClass="footable" HorizontalAlign="Center" PageSize="10" Width="100%">
                                           <RowStyle CssClass="GridViewRowNew" />
                                           <PagerStyle CssClass="disablepage" />
                                           <HeaderStyle CssClass="gridview th" />
                                           <EmptyDataTemplate>
                                               <asp:Label ID="lblerror" runat="server" CssClass="control-label" ForeColor="Red" Text="No records found" />
                                           </EmptyDataTemplate>
                                           <Columns>
                                               <asp:TemplateField HeaderText="Action">
                                                   <ItemTemplate>
                                                       <asp:CheckBox ID="chckmem" runat="server" />
                                                       <%--<asp:LinkButton ID="lnkdelt" Text="Delete" runat="server"  OnClick="lnkdelt_Click"  OnClientClick="return confirm('Are you sure you want to Delete?'); return true;"  /> --%>
                                                   </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Center" />
                                                   <ItemStyle HorizontalAlign="Center" />
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Member code" ItemStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" SortExpression="MEM_CODE">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblmemcd" runat="server" Text='<%# Bind("MEM_CODE")%>'></asp:Label>
                                                       <asp:HiddenField ID="hdnintg_id" runat="server" />
                                                       <asp:Label ID="lblseq" runat="server" Text='<%# Bind("SEQ_NO")%>' Visible="false"></asp:Label>
                                                   </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Left" />
                                                   <ItemStyle CssClass="clsCenter" HorizontalAlign="Left" />
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Member Name" ItemStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" SortExpression="LEGALNAME">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblmemnm" runat="server" Text='<%# Bind("LEGALNAME")%>'></asp:Label>
                                                   </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Left" />
                                                   <ItemStyle CssClass="clsCenter" HorizontalAlign="Left" />
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Current Designation" ItemStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" SortExpression="CURRENT_DESG">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblcDesg" runat="server" Text='<%# Bind("CURRENT_DESG")%>'></asp:Label>
                                                   </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Left" />
                                                   <ItemStyle CssClass="clsCenter" HorizontalAlign="Left" />
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="New Designation" ItemStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" SortExpression="NEW_DESG">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblndesg" runat="server" Text='<%# Bind("NEW_DESG")%>'></asp:Label>
                                                   </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Left" />
                                                   <ItemStyle CssClass="clsCenter" HorizontalAlign="Left" />
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Category" ItemStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" SortExpression="CATEGORY">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblcatg" runat="server" Text='<%# Bind("CATEGORY")%>'></asp:Label>
                                                   </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Left" />
                                                   <ItemStyle CssClass="clsCenter" HorizontalAlign="Left" />
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Type" ItemStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" SortExpression="TYPE">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblTYP" runat="server" Text='<%# Bind("TYPE")%>'></asp:Label>
                                                   </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Left" />
                                                   <ItemStyle CssClass="clsCenter" HorizontalAlign="Left" />
                                               </asp:TemplateField>
                                           </Columns>
                                       </asp:GridView>
                                   </ContentTemplate>
                               </asp:UpdatePanel>
                           </div>
                       </div>
                       
                       <%--<div id="divPage" visible="true" runat="server" class="pagination">--%><%--<center>--%>
                       <table>
                           <tr>
                               <td style="white-space: nowrap;">
                                   <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                       <ContentTemplate>
                                           <asp:Button ID="btnprevious" runat="server" CssClass="form-submit-button" Visible="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Text="&lt;" Width="40px" OnClick="btnprevious_Click" />
                                           <asp:TextBox ID="txtPage" runat="server" CssClass="form-control" ReadOnly="true" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" Visible="false" />
                                           <asp:Button ID="btnnext" runat="server" CssClass="form-submit-button" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Text="&gt;" Width="40px" OnClick="btnnext_Click" Visible="false" />
                                       </ContentTemplate>
                                   </asp:UpdatePanel>
                               </td>
                           </tr>
                       </table>
                       <%-- </center>--%><%--   </div>--%>
                       <asp:LinkButton ID="lnkbtn_apprv" runat="server" CssClass="btn btn-sample" OnClick="lnkbtn_apprv_Click" OnClientClick="funStartStep(this.id)" TabIndex="17" Visible="false"> 
                           <span class="glyphicon glyphicon-check" style="color:White"></span> Approve
                       </asp:LinkButton>
                       <asp:Label ID="lblStatus" runat="server" Style="text-decoration-color:green" Text="" />
                       <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px" />
                     
                       <asp:LinkButton ID="lnk_rjct" runat="server" CssClass="btn btn-sample"   TabIndex="17" OnClick="lnk_rjct_Click" Visible="false">
                            <span class="glyphicon glyphicon-remove" style="color:White"></span> Reject
                       </asp:LinkButton>
                                              
                      
                     
                      
                      
                   </div>
                </ContentTemplate>
        </asp:updatepanel>
        </center>
</asp:Content>


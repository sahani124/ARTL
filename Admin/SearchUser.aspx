<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="SearchUser.aspx.cs" Inherits="Application_Admin_SearchUser1" %>


  

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  


    
<script runat="server">



    protected void lbUserId_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbUserId = (LinkButton)grd.FindControl("lbUserId");

        if (Request.QueryString["Type"] == "AddRole")
        {
            Response.Redirect("~/Application/Admin/UsrSu.aspx?mode=AddRole&UserId=" + lbUserId.Text + "");
        }
        else
        {
            Response.Redirect("~/Application/Admin/UsrSu.aspx?mode=edit&UserId=" + lbUserId.Text + "");
        }
    }
</script>
    <asp:ScriptManager ID="scriptMgr" EnablePartialRendering="true" runat="server"></asp:ScriptManager>

       <%-- start Added by sanoj 29092022--%>

    
   
    <link href="../../KMI Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
     <link href="../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
     <%-- endded Added by sanoj 29092022--%>
   
     <%-- <link href="../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />
  <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>


    <%-- <script src="assets/KMI%20Styles/Bootstrap/datepicker/datetimepicker.js" type="text/javascript"></script>
    <script src="assets/jqueryCalendar/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>--%>
    <link href="../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
    <%-- <link href="../../../assets/KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    
   <%-- <script src="../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
     <link href="../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" language="javascript">
        function ClearSearch() {
            document.getElementById("ctl00_ContentPlaceHolder1_txtUserName").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_txtUserID").value = "";

            var cboPolSts = document.getElementById("ctl00_ContentPlaceHolder1_cboStatus");
            cboPolSts.selectedIndex = 0;

            var cboShowRecord = document.getElementById("ctl00_ContentPlaceHolder1_cboReturnRecord");
            cboShowRecord.selectedIndex = 0;
        }


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
       

        //function ShowReqDtl(divId, btnId) {
        //    debugger;
        //    if (document.getElementById(divId).style.display == "block") {
        //        document.getElementById(divId).style.display = "none";
        //        //document.getElementById(divId).value = '+'
        //        document.getElementById(btnId).value = '+';
        //    }
        //    else {
        //        document.getElementById(divId).style.display = "block";
        //        //document.getElementById(btnId).value = '-'
        //        document.getElementById(btnId).value = '-';
        //    }
        //}
        function doBasicSearch() {//debugger;
            //if(Page_ClientValidate())
            __doPostBack('ctl00$ContentPlaceHolder1_txtUserID', '');

        }

       
       function ClearSearch() {
           document.getElementById("ctl00_ContentPlaceHolder1_txtUserName").value = "";
           document.getElementById("ctl00_ContentPlaceHolder1_txtUserID").value = "";

           var cboPolSts = document.getElementById("ctl00_ContentPlaceHolder1_cboStatus");
           cboPolSts.selectedIndex = 0;

           var cboShowRecord = document.getElementById("ctl00_ContentPlaceHolder1_cboReturnRecord");
           cboShowRecord.selectedIndex = 0;
       }

        function doBasicSearch() {//debugger;
            //if(Page_ClientValidate())
            __doPostBack('ctl00$ContentPlaceHolder1_txtUserID', '');

        }
    
    </script>
    <style type="text/css">
         .clscenter{
           text-align:center!important;
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
        .gridview th
        {
            padding: 3px;
            height: 40px;
            color: White;
            white-space: nowrap;
            
        }
    </style>

    <div class="page-container" style="margin-top: 0px;">
    <div class="card PanelInsideTab" style="margin-left: 2%; margin-right: 2%; margin-top: 1.5%">
        <div class="panel-heading" onclick="ShowReqDtl('div1','btnMap');return false;">
        <div class="row">
            <div class="col-sm-5" style="text-align:left">
                            <asp:Label ID="lblTitle" runat="server" Text="User Enquiry/User Sanction" CssClass="control-label" Font-Size="19px"></asp:Label>
                        </div>
                        <div class="col-sm-5" style="text-align:center">
                            <asp:Label ID="lblModVer" runat="server" CssClass="control-label" Text="Admin/User Enquiry/User Sanction" Font-Size="19px" Visible="false"></asp:Label>
                        </div>
            <div class="col-sm-2">
                <span id="btnMap" class="glyphicon glyphicon-chevron-down" style="float: right;
                                padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
                    </div>
            </div>
    <div class="panel-body" id="div1" style="display: block; margin-top: 0.9%; margin-bottom: 0.9%">
        <div class="row ">
            <div class="col-sm-4" style="text-align: left">
                <asp:Label ID="lblUserID" runat="server" CssClass="control-label"></asp:Label>
                
           
                
               <asp:TextBox ID="txtUserID" runat="server"
                    CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-4" style="text-align: left">
                
                 <asp:Label ID="lblUserName" runat="server" CssClass="control-label"></asp:Label>
           
               
                <asp:TextBox ID="txtUserName" runat="server"  CssClass="form-control"></asp:TextBox>

            </div>
             <div class="col-sm-4" style="text-align: left">
                <asp:Label ID="lblStatus" runat="server" CssClass="control-label"></asp:Label>
           
                <asp:DropDownList ID="cboStatus" runat="server" OnDataBound="cboStatus_DataBound" CssClass="form-control form-select"  AutoPostBack="True">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row rowspacing">
           
            <div class="col-sm-4" style="text-align: left">
                 <asp:Label ID="lblReturnRecord" runat="server" CssClass="control-label"></asp:Label>
           
                 <asp:DropDownList ID="cboReturnRecord" runat="server" CssClass="form-control" AutoPostBack="True">
                    
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row rowapacing">
            <div class="col-sm-12" style="text-align:center">

                <asp:LinkButton ID="btnSearchAdv" runat="server"   CssClass="btn btn-success" OnClientClick="doBasicSearch();return false;" ValidationGroup="checkSearch" >
                    <span class="glyphicon glyphicon-search BtnGlyphicon"></span> Search
                    </asp:LinkButton>
                <asp:LinkButton ID="btnHClear" CssClass="btn btn-clear" OnClientClick="ClearSearch();return false;" runat="server">
                     <span class="glyphicon glyphicon-erase BtnGlyphicon"> </span> Clear </asp:LinkButton>
           </div>
        </div>
    </div>
        </div>
    <%-- 
                   <table class="formtable" cellspacing="1" cellpadding="3" width="96%" align="center">
            <tr>
                <td>
                    <asp:Label ID="l
            
            
            
            
            
            
            
            
            
            
            
            blNoRecord" runat="server" CssClass="subtitle"></asp:Label></td>
            </tr>
            </table>
    --%>
    <div class="card PanelInsideTab"  style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
        <div class="panel-heading">
        <div class="row">
            <div class="col-sm-10" style="text-align:left">
                <asp:Label ID="lblSearchResult" Text="Search Result" CssClass="control-label" runat="server" Font-Size="19px"></asp:Label>
            </div>
            <div  class="col-sm-2">

                <span id="btnpersnl" onclick="ShowReqDtl('searchDiv', 'btnpersnl');return false;" class="glyphicon glyphicon-chevron-down" style="float: right; 
                            padding: 1px 10px ! important; font-size: 18px;"></span>
               
            </div>
        </div>
            </div>
        <div id="searchDiv" style="display: block;width:100%;">
        <div   class="row" style=" margin-left:20px;margin-right:20px;margin-top: 14px;">
                <asp:UpdatePanel ID="upd1" runat="server">

                    <ContentTemplate>


                        <asp:GridView ID="gvResult" runat="server"  AllowSorting="True" CssClass="footable" HeaderStyle-HorizontalAlign="Center" 
                            DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" Style="border-bottom-color: black;" 
                            Width="100%"  AllowPaging="True"  OnPageIndexChanging="gvResult_PageIndexChanging">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                            <EmptyDataTemplate>
                                <center>
                                   <asp:Label ID="lblNoRecord" runat="server" Cssclass="control-label" Text="No Record Found"></asp:Label>
                              </center>
                            </EmptyDataTemplate>
                            <Columns>
                                <%--  <asp:HyperLinkField DataTextField="UserId" SortExpression="UserId" DataNavigateUrlFields="UserId" DataNavigateUrlFormatString="~/Application/Admin/Usrsu.aspx?mode=edit&amp;userid={0}"
                            HeaderText="User ID" />--%>
                                <asp:TemplateField HeaderText="User ID" SortExpression="UserId">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbUserId" runat="server" Text='<%# Bind("UserId") %>'
                                            OnClick="lbUserId_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                     <ItemStyle CssClass="clscenter"/>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UserName" SortExpression="UserName" HeaderText="User Name">
                                     <ItemStyle CssClass="clscenter"/>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Status" SortExpression="UserStatus">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("UserStatus") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserStatusDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle CssClass="clscenter"/>
                                </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtUserID" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtUserName" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cboStatus" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cboReturnRecord" EventName="TextChanged" />
                    </Triggers>

                </asp:UpdatePanel>

            </div>
        </div>
            </div>
    </div>
   </div>
          <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetSearchUserBy"
              TypeName="Adminuser.AdminDAL">
              <SelectParameters>
                  <asp:ControlParameter ControlID="txtUserID" DefaultValue="" Name="UserId" PropertyName="Text"
                      Type="String" />
                  <asp:ControlParameter ControlID="txtUserName" Name="UserName" PropertyName="Text"
                      Type="String" />
                  <asp:ControlParameter ControlID="cboStatus" Name="UserStatus" PropertyName="SelectedValue"
                      Type="String" />
              </SelectParameters>
          </asp:ObjectDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:INSCDirectConnectionString %>"
        SelectCommand="select * from isyslookupparam where lookupcode='userstat'"></asp:SqlDataSource>


</asp:Content>


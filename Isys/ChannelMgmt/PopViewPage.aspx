<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopViewPage.aspx.cs" MasterPageFile="~/iFrame.master" Inherits="Application_Isys_ChannelMgmt_PopViewPage" %>
<%--<Comment>--%>
   <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
 <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />

    
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />

    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../PSSNEW/Script/COMM/CBFRMCommon.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../PSSNEW/Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>

 <script type="text/javascript" src="../../../Scripts/common.js"></script>
 <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
 <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
   <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
   
     <script language="javascript" type="text/javascript">

        function ShowReqDtl(divName, btnName) {
            //debugger;
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
    

        function doCancel() {
         window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

        function doOk(isPrimary, rowid) {
           
        }

        </script>
<style type="text/css">
        
            .btn-subtab
        {
            color:#3c763d;
            background-color:#EDF1cc !important;
            border-color:#d6e9c6;
        }
            
             .btn-tab
        {
            color:#3c763d;
            background-color:#dff0d8;
            border-color:#d6e9c6;
        }
            
             .nav-tabs > li.active > a,
        .nav-tabs > li.active > a:hover,
        .nav-tabs > li.active > a:focus{
            color: #555555;
            background-color: #dff0d8;  
        } 
        
        ul#menu li a:active{background:white;}
            
            
           
            .disablepage
            {
                display: none;
            }
            ul#menu
            {
                padding: 0;
                margin-right: 69%;
            }
            
            ul#menu li
            {
                display: inline;
            }
            
            
            
            ul#menu li a
            {
                background-color: Silver;
                color: black;
                cursor: pointer;
                padding: 10px 20px;
                text-decoration: none;
                border-radius: 4px 4px 0 0;
            }
            ul#menu li a:active
            {
                background: white;
            }
            
            ul#menu li a:hover
            {
                background-color: red;
            }
        </style>
    <asp:ScriptManager ID="scriptMgr" runat="server" />
    <%--<div class="container" style="height: 558px;width: 636px;">--%>
            <%--<div class="panel panel-success" style="margin-top: 9px;margin-left: -10px;margin-bottom: -13px;width:672px;">
            --%>
                
                <div class="panel panel-success" style="margin-top: 3px; display:none;">
                        

                             <div id="divuntcodeHdr" runat="server"  class="panel-heading"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divuntcode','Span4');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>
                              
                            <asp:Label ID="lblhdr" runat="server" Text="Reporting Member Levels" ></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="Span4"  class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
            
             <div id="divuntcode" class="panel-body" runat="server" style="display:none;">
           
        
        <div class="row">
                 <div align="left"  class="col-sm-3">
                    <asp:Label ID="lblmemtyp" runat="server"  CssClass="control-label" Text="Member Code"></asp:Label>
                </div>
                 <div   class="col-sm-8">
                    <asp:TextBox ID="txtmemtyp" runat="server" CssClass="form-control"></asp:TextBox>
                 
              </div>
            </div>
             <div class="row" style="margin-top: 12px;">
                <div class="col-sm-12" align="center">
                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" CausesValidation="true"
                        Text="Update"  OnClientClick="javascript:validate();"
                        TabIndex="43"> <span class="glyphicon glyphicon-search" style='color: White;'></span> Search </asp:LinkButton>&nbsp;&nbsp;  <%--OnClick="btnClear_Click"--%>
                        <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-primary" CausesValidation="true"
                        Text="Update"  OnClientClick="javascript:validate();"
                        TabIndex="43"> <span class="glyphicon glyphicon-erase" style='color: White;'></span> Clear </asp:LinkButton>&nbsp;&nbsp;  <%--OnClick="btnClear_Click"--%>
                     
                </div>
            </div>
            </div>
            </div>
               
             
            <div  >  <%--class="panel"--%>
                <div id="trtitle" style="margin-left:20px" runat="server" class="panel-heading" 
                    onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div1','ctl00_ContentPlaceHolder1_Span1');return false;">
                    <div class="row" id="trDetails" runat="server">
                        <div class="col-sm-5" style="text-align: left">
                            <%--<span class="glyphicon glyphicon-chevron-down" style="color: #034ea2;"></span>--%>
                            <asp:Label ID="lblprospectsearch" runat="server" Text="Reporting Member Levels Results" style="font-size: 19px;"></asp:Label>
                        </div>
                          <div class="col-sm-2" style="margin-left: 310px;">
                           <span id="Img1" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
               <div id="div1" runat="server" style="width: 96%;height:40%; padding: 10px; overflow-x:scroll;" class="panel-body">
             <%--   <div class="row" >
                <div class="col-sm-12" >--%>
               <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" CssClass="standardlabel"
                             Visible="false"/>
                       
                    
                    <asp:UpdatePanel ID="UPDErrMsg" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblErrMsg" runat="server" CssClass="footable" Visible="False"></asp:Label>
                            <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="footable"
                                PageSize="100"  OnRowDataBound="gv_RowDataBound" OnSorting="gv_Sorting" OnPageIndexChanging="gv_PageIndexChanging">
                                  <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                
                                  
                                    <asp:TemplateField HeaderText="Channel Description" SortExpression="ChannelDesc01">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemType_desc" runat="server" Text='<%# Bind("ChannelDesc01") %>'></asp:Label>
                                        </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:TemplateField>

                                    
                                    <asp:TemplateField HeaderText="Sub channel" SortExpression="ChnClsDesc01">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemlevel" runat="server" Text='<%# Bind("ChnClsDesc01") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:TemplateField>

                                 
                                        <asp:TemplateField HeaderText="Member Type" SortExpression="MemTypeDesc01">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemTypeDesc01") %>'></asp:Label>
                                        </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Unit Rank" SortExpression="RptUnitRank">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUntRnk" runat="server" Text='<%# Bind("RptUnitRank") %>'></asp:Label>
                                        </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:TemplateField>

                                    <%-- <asp:TemplateField HeaderText="Hierarchy Name" SortExpression="BizSrc">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBizSrc" runat="server" Text='<%# Bind("BizSrc") %>'></asp:Label>
                                        </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Center" Width="30%" />
                                    </asp:TemplateField>--%>

                                   <%--  <asp:TemplateField HeaderText="Hierarchy Name" SortExpression="BizSrc" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBizSrcCode" runat="server" Text='<%# Bind("chnl") %>'></asp:Label>
                                        </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Center" Width="30%" />
                                    </asp:TemplateField>--%>
                                    <%-- <asp:TemplateField HeaderText="Sub Class" SortExpression="ChnCls">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChnCls" runat="server" Text='<%# Bind("ChnCls") %>'></asp:Label>
                                        </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Center" Width="30%" />
                                    </asp:TemplateField>--%>

                               <%--      <asp:TemplateField HeaderText="Sub Class" SortExpression="subchnl" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChnClscode" runat="server" Text='<%# Bind("subchnl") %>'></asp:Label>
                                        </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Center" Width="30%" />
                                    </asp:TemplateField>--%>
                                     
                                
                                </Columns>
                            </asp:GridView>
                                <div>
                            <br />
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;" CssClass="form-control" ReadOnly="true" />
                                            <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                        </ContentTemplate>
                       
                    </asp:UpdatePanel>
               
          <%--   </div>
                    </div>--%>
                   
                   <%-- <asp:Button ID="btnOK" runat="server" CssClass="standardbutton" Text="OK" onclick="btnOK_Click"  />--%>
              <br />

                    <asp:UpdatePanel ID="UpdOk" runat="server" style="margin-left: 290px;">
                        <ContentTemplate>
                    <%--       <asp:LinkButton ID="btnOK" runat="server" Text="Ok" CssClass="btn btn-primary"
                                    OnClick="btnOK_Click"><span class="glyphicon glyphicon-ok BtnGlyphicon"></span> Ok </asp:LinkButton>--%>
                                      <asp:LinkButton ID="btnCancel" runat="server" OnClientClick="doCancel();return false;" Text="Cancel" CssClass="btn btn-danger">
                                          <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> Cancel </asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 
                                    </div>
                                

                                  </div>

          

          <%--  </div>--%>
                
            
       
   <%--</div>--%>
</asp:Content>

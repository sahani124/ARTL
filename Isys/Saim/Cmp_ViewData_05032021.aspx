<%@ Page Language="C#"  MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="Cmp_ViewData.aspx.cs" Inherits="Application_Isys_Saim_Cmp_ViewData" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
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
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script>
        function funAddmaster1(cmpcode, cntstcode, cmptype, ruletype, RuleSetkey, Cycle) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwd1").src = "CntstStp_INC.aspx?CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&Cmptype=" + cmptype + "&ruletype=" + ruletype+"&RuleSetKey="+RuleSetkey+ "&Cycle="+Cycle
            + "&mdlpopup=mdlVwBID";
        }

        function funAddmaster2(cmpcode, cntstcode, Flag, RuleSetkey, Cycle, RuleCode, Memcode,CategoryCode) {
            debugger;
        //    window.open("CntstStp_INC.aspx");

            window.open("CntstStp_INC.aspx?CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&Flag=" + Flag + "&RuleSetKey=" + RuleSetkey + "&Cycle=" + Cycle + "&RuleCode=" + RuleCode + "&Memcode=" +
            Memcode + "&CategoryCode=" + CategoryCode + "&#divKPIRR", "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=40,left=70,bottom=80,width=1200,height=600");


        }



       
    </script>
    <style type="text/css">
        ul#menu li a:active {
            background: white;
        }
        .gridright
        {

           text-align:right !important;
        }

          .gridleft
        {

           text-align:left !important;
        }
           .gridcenter
        {

           text-align: center !important;
        }




        .disablepage {
            display: none;
        }

        ul#menu {
            padding: 0;
            margin-right: 69%;
        }

            ul#menu li {
                display: inline;
            }

                ul#menu li a {
                    background-color: Silver;
                    color: black;
                    cursor: pointer;
                    padding: 10px 20px;
                    text-decoration: none;
                    border-radius: 4px 4px 0 0;
                }

                    ul#menu li a:active {
                        background: white;
                    }

                    ul#menu li a:hover {
                        background-color: red;
                    }
    </style>

    <center>

       <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="divPart" runat="server" style="width: 97%;" class="panel " Visible="false">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpisrch','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">     
                                <asp:Label ID="lblCmpSrch" style="font-size:19px;" Text="Participating Policies" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate> 
                                        <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> 
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divkpisrch" runat="server" style="width: 96%; padding: 10px;">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvPolicy" runat="server" AutoGenerateColumns="false" Width="100%" Visible="false"
                                    PageSize="10" AllowSorting="True"  AllowPaging="true"   
                                    CssClass="footable" >
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        
                                        <asp:TemplateField HeaderText="Policy No" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpolicyNo" Text='<%# Bind("POLICY_NO") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="Endorsement Type" HeaderStyle-HorizontalAlign="Center"
                             HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center" >

                                            <ItemStyle  CssClass="gridcenter"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblENDT_TYPE" Text='<%# Bind("ENDT_TYPE") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                      
                                        <asp:TemplateField HeaderText="Premium Amount" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Right">
                                             <ItemStyle  CssClass="gridright"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPREM_AMT" Text='<%# Bind("PREM_AMT") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Weightage" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Right">
                                             <ItemStyle  CssClass="gridright"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPROD_WHTG" Text='<%# Bind("PROD_WHTG") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          

                                         <asp:TemplateField HeaderText="Weighted Premium" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Right">
                                             <ItemStyle  CssClass="gridright"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblActualPremAmout" Text='<%# Bind("ActualPremAmout") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Policy Holder Name" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOLICY_HLDR_NM" Text='<%# Bind("POLICY_HLDR_NM") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                           <asp:TemplateField HeaderText="Policy Issue Date" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIssue_Date" Text='<%# Bind("Issue_Date") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Policy Login Date " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLOGIN_DATE" Text='<%# Bind("LOGIN_DATE") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Member Name " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLegalName" Text='<%# Bind("LegalName") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Policy Status " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOLICY_STATUS" Text='<%# Bind("POLICY_STATUS") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                        
                                        <asp:TemplateField HeaderText="Policy Tenure " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOLICY_TENURE" Text='<%# Bind("POLICY_TENURE") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

<%--                                          <asp:TemplateField HeaderText="Action">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkView" runat="server" Text="View" 
                                                          OnClick="lnkView_Click"  ></asp:LinkButton>    

                                                         <%--<asp:LinkButton ID="lnkCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'
                                                        OnClick="lnkCnstCode_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>


                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" Visible="false"
                                    PageSize="10" AllowSorting="True"  AllowPaging="true"   
                                    CssClass="footable" >
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        
                                        <asp:TemplateField HeaderText="Member Code" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="MEM_CODE" Text='<%# Bind("MEM_CODE") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField> 

                                         <asp:TemplateField HeaderText="Member Name" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="MEM_CODE" Text='<%# Bind("LegalName") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField> 

                                        </Columns>
                                     </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div  class="pagination" style="padding: 10px;" >
                            <center>
                                <table>
                                    <caption>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnprevious" runat="server" CssClass="form-submit-button" Enabled="false"  Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Text="&lt;" Width="40px"  />
                                                        <asp:TextBox ID="txtPage" runat="server"  CssClass="form-control" ReadOnly="true" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" />
                                                        <asp:Button ID="btnnext" runat="server" CssClass="form-submit-button"  Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Text="&gt;" Width="40px"  />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </caption>
                                </table>
                            </center>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        

      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div  style="margin-left:2%;margin-right:2%;margin-top:2%;margin-bottom:2%;">

                <div id="divRevised" runat="server"  class="panel " Visible="false">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpisrch','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">     
                                <asp:Label ID="Label1" style="font-size:19px;" Text="Revised Participating Policies" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate> 
                                        <span id="Img2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> 
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divRevisedSearch" runat="server" >

                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvRevPolicy" runat="server" AutoGenerateColumns="false" Width="100%" Visible="true"
                                    PageSize="10" AllowSorting="True"  AllowPaging="true"   
                                    CssClass="footable" >
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        
                                         <asp:TemplateField HeaderText="Action">  
                                                               <HeaderTemplate>
                                                                <asp:CheckBox ID="chkall" runat="server" AutoPostBack="true"  />
                                                                </HeaderTemplate>
                                                       <%--<EditItemTemplate>  
                                                        <asp:CheckBox ID="chkValue" runat="server" />  
                                                    </EditItemTemplate> --%> 
                                                     <ItemTemplate>  
                                                            <asp:CheckBox ID="chkOne" runat="server" />  
                                                       </ItemTemplate>  
                                                     </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Policy No" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRevpolicyNo" Text='<%# Bind("POLICY_NO") %>' runat="server" />

                                                <asp:HiddenField ID="HdnPremiumRegisterID" Value='<%# Bind("PremiumRegisterID") %>' runat="server" />

                                            </ItemTemplate>
                                        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="Endorsement Type" HeaderStyle-HorizontalAlign="Center"
                             HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center" >

                                            <ItemStyle  CssClass="gridcenter"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblENDT_TYPE" Text='<%# Bind("ENDT_TYPE") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                      
                                        <asp:TemplateField HeaderText="Premium Amount" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Right">
                                             <ItemStyle  CssClass="gridright"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPREM_AMT" Text='<%# Bind("PREM_AMT") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          

                                                 <asp:TemplateField HeaderText="Policy Holder Name" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOLICY_HLDR_NM" Text='<%# Bind("POLICY_HLDR_NM") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                           <asp:TemplateField HeaderText="Policy Issue Date" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIssue_Date" Text='<%# Bind("Issue_Date") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Policy Login Date " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLOGIN_DATE" Text='<%# Bind("LOGIN_DATE") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Member Name " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLegalName" Text='<%# Bind("LegalName") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Policy Status " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOLICY_STATUS" Text='<%# Bind("POLICY_STATUS") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                        
                                        <asp:TemplateField HeaderText="Policy Tenure " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOLICY_TENURE" Text='<%# Bind("POLICY_TENURE") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>


                                           <asp:TemplateField HeaderText="Reason For Revised">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                   
                                       
                                    
                                               <asp:DropDownList runat="server" ID="ddlRsnFrResd" AutoPostBack="true" 
                                                CssClass="form-control" Width="100%" >
                                           
                                                 </asp:DropDownList>
                           
                                                </ItemTemplate>
                                            </asp:TemplateField>

<%--                                          <asp:TemplateField HeaderText="Action">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkView" runat="server" Text="View" 
                                                          OnClick="lnkView_Click"  ></asp:LinkButton>    

                                                         <%--<asp:LinkButton ID="lnkCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'
                                                        OnClick="lnkCnstCode_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div  class="pagination" style="padding: 10px;" >
                            <center>
                                <table>
                                    <caption>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanelrev7" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="revbtnprevious" runat="server" CssClass="form-submit-button" Enabled="false"  Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Text="&lt;" Width="40px"  />
                                                        <asp:TextBox ID="revtxtPage" runat="server"  Text="1" CssClass="form-control" ReadOnly="true" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" />
                                                        <asp:Button ID="revbtnnext" runat="server" CssClass="form-submit-button"  Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Text="&gt;" Width="40px"  />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </caption>
                                </table>
                            </center>
                        </div>

                        <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                    
                                <asp:LinkButton ID="btnAddPolicy" runat="server" CssClass="btn btn-sample" OnClick="btnAddPolicy_click">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> Add Policy
                                </asp:LinkButton>
                               <%-- <asp:LinkButton ID="btnClear_Rwd" runat="server" CssClass="btn btn-sample" OnClick="btnClick">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Close
                                </asp:LinkButton>--%>

                    </div>
                </div>


                    </div>



                    <div >

                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdParPolicy" runat="server" AutoGenerateColumns="false" Width="100%" Visible="true"
                                    PageSize="10" AllowSorting="True"  AllowPaging="true"   
                                    CssClass="footable" >
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        
                                         <asp:TemplateField HeaderText="Action">  
                                                               <HeaderTemplate>
                                                                <asp:CheckBox ID="chkall" runat="server" AutoPostBack="true"  />
                                                                </HeaderTemplate>
                                                       <%--<EditItemTemplate>  
                                                        <asp:CheckBox ID="chkValue" runat="server" />  
                                                    </EditItemTemplate> --%> 
                                                     <ItemTemplate>  
                                                            <asp:CheckBox ID="chkOne" runat="server" />  
                                                       </ItemTemplate>  
                                                     </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Policy No" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRevpolicyNo" Text='<%# Bind("POLICY_NO") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="Endorsement Type" HeaderStyle-HorizontalAlign="Center"
                             HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center" >

                                            <ItemStyle  CssClass="gridcenter"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblENDT_TYPE" Text='<%# Bind("ENDT_TYPE") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                      
                                        <asp:TemplateField HeaderText="Premium Amount" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Right">
                                             <ItemStyle  CssClass="gridright"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPREM_AMT" Text='<%# Bind("PREM_AMT") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          

                                                 <asp:TemplateField HeaderText="Policy Holder Name" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOLICY_HLDR_NM" Text='<%# Bind("POLICY_HLDR_NM") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                           <asp:TemplateField HeaderText="Policy Issue Date" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIssue_Date" Text='<%# Bind("Issue_Date") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Policy Login Date " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLOGIN_DATE" Text='<%# Bind("LOGIN_DATE") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Member Name " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLegalName" Text='<%# Bind("LegalName") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Policy Status " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOLICY_STATUS" Text='<%# Bind("POLICY_STATUS") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                        
                                        <asp:TemplateField HeaderText="Policy Tenure " HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOLICY_TENURE" Text='<%# Bind("POLICY_TENURE") %>' runat="server" />
                                               

                                            </ItemTemplate>
                                            </asp:TemplateField>


                                           <asp:TemplateField HeaderText="Reason For Revised">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                   
                                       
                                    
                                               <asp:DropDownList runat="server" ID="ddlRsnFrResd" AutoPostBack="true" 
                                                CssClass="form-control" Width="100%" >
                                           
                                                 </asp:DropDownList>
                           
                                                </ItemTemplate>
                                            </asp:TemplateField>

<%--                                          <asp:TemplateField HeaderText="Action">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkView" runat="server" Text="View" 
                                                          OnClick="lnkView_Click"  ></asp:LinkButton>    

                                                         <%--<asp:LinkButton ID="lnkCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'
                                                        OnClick="lnkCnstCode_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div  class="pagination" style="padding: 10px;" >
                            <center>
                                <table>
                                    <caption>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="Button1" runat="server" CssClass="form-submit-button" Enabled="false"  Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Text="&lt;" Width="40px"  />
                                                        <asp:TextBox ID="TextBox1" runat="server"  Text="1" CssClass="form-control" ReadOnly="true" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" />
                                                        <asp:Button ID="Button2" runat="server" CssClass="form-submit-button"  Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Text="&gt;" Width="40px"  />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </caption>
                                </table>
                            </center>
                        </div>


                    </div>
                </div>

                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        </center>
                </asp:Content>

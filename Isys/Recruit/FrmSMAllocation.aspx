<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FrmSMAllocation.aspx.cs" Inherits="Application_ISys_Recruit_FrmSMAllocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
   <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>


    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    
    <script language="javascript" type="text/javascript">

        function ShowReqDtl12(divName, btnName) {
            //debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-resize-full'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-resize-small'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }
        //for main div
        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {

                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
                else {

                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        function PopupModal() {
            //debugger;
            var modal = $find('mdlcfrdtlsID');

            if (modal) {
                if (modal.show) {
                    modal.show();
                }
                else {
                    alert("nope!");
                }
            }
            else {
                throw modal;
            }
        }

        function funcMgrShowPopup(strbzsrc, strsbclass, strbrnch) {
            debugger;
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopSMDetails.aspx?&field1=" + document.getElementById('<%=txtNwchannelClass.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtNwsubClass.ClientID %>').id + "&bizsrc=" + strbzsrc + "&field7=" + document.getElementById('<%=txtNwbrnch.ClientID %>').id
        + "&subchnl=" + strsbclass + "&untcd=" + strbrnch + "&field4=" + document.getElementById('<%=txtNwEmpCode.ClientID %>').id + "&field5=" + document.getElementById('<%=txtNwSMName.ClientID %>').id
        + "&field6=" + document.getElementById('<%=txtNwagttype.ClientID %>').id + "&field3=" + document.getElementById('<%=txtNwRecruiterCode.ClientID %>').id + "&field8=" + document.getElementById('<%=txtNwcndagttyp.ClientID %>').id + "&field15=" + document.getElementById('<%=hdnUnitCode.ClientID %>').id
        + "&field13=" + document.getElementById('<%=hdnagenttype.ClientID %>').id + "&field14=" + document.getElementById('<%=hdncndagenttype.ClientID %>').id + "&field11=" + document.getElementById('<%=hdnslschnl.ClientID %>').id + "&field12=" + document.getElementById('<%=hdnsubcls.ClientID %>').id
        + "&field16=" + document.getElementById('<%=hdnNwRecruiterCode.ClientID %>').id + "&field17=" + document.getElementById('<%=hdnNwEmpCode.ClientID %>').id + "&field18=" + document.getElementById('<%=hdnNwSMName.ClientID %>').id
        + "&field19=" + document.getElementById('<%=hdnhierarchyname.ClientID %>').id + "&field20=" + document.getElementById('<%=hdnsubclass.ClientID %>').id
        + "&field21=" + document.getElementById('<%=hdnagenttypedesc.ClientID %>').id + "&field22=" + document.getElementById('<%=hdncndagenttypedesc.ClientID %>').id + "&field23=" + document.getElementById('<%=hdnbranchdesc.ClientID %>').id +
         "&mdlpopup=mdlViewBID";
        }
       </script>
       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       
       <div class="container">
       <center>
       
     <%--  <table cellpadding="0" cellspacing="2" style="width: 80%;">
       --%>
        
         <div class="row">
                        <div class="col-sm-12" style="margin-bottom: 5px;">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"  Width="310px"></asp:Label>
                        </div>
                    </div>
        <%--<tr id="tr_message" runat="server" align="center" style="visibility:hidden">
            <td>
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
  --%>
      <div class="panel panel-success">
       <%-- <table id="Table1" class="tableIsys" runat="server" style="border-collapse: separate; left: 0in; position: relative; top: 0px; width: 90%;" >--%>
             <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnWfParam');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align:left; top: 0px; left: 0px;">
                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;">
                        </span>
                        <asp:Label ID="lblTitle" runat="server" Font-Bold="True"  Text="SM Allocation" Height="14px" Font-Size="Small"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="btnWfParam" class="glyphicon glyphicon-collapse-down" style="float: right;
                            color: Orange;padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <%--<tr>
                <td class="test" align="left" colspan="4" style="height:20px;">
                    <asp:Label ID="lblTitle" Text="SM Allocation" Font-Bold="true" runat="server"></asp:Label>
                </td>
            </tr>--%>
           <%-- <tr>
            <td>--%>
            <div id="divSearch" runat="server" class="panel-body" style="overflow:scroll">
                   <div class="row">
                 <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblCndNo" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>
                </div>
                <div class="col-sm-3" >
                    <asp:Label ID="lblCndNoValue" CssClass="control-label" style="margin-bottom: 5px;"  runat="server" Font-Bold="False"></asp:Label>
                </div>
                <div class="col-sm-3" style="text-align: left" >
                    <asp:Label ID="lblAppNo" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>
                </div>
                <div class="col-sm-3" >
                    <asp:Label ID="lblAppNoValue" CssClass="control-label" style="margin-bottom: 5px;"  runat="server" Font-Bold="False"></asp:Label>
                
                </div>
                </div>
                   <div class="row">
                <div class="col-sm-3" style="text-align: left" >
                    <asp:Label ID="lblCndName" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>
               </div>
                <div class="col-sm-3">
                    <asp:Label ID="lblCndNameValue" CssClass="control-label"  style="margin-bottom: 5px;" runat="server" Font-Bold="False"></asp:Label>
               </div>
                <div class="col-sm-3" style="text-align: left" >
                    <asp:Label ID="lblSMName" CssClass="control-label"    runat="server" Font-Bold="False"></asp:Label>
               </div>
                <div class="col-sm-3" >
                    <asp:Label ID="lblSMNameValue" CssClass="control-label" style="margin-bottom: 5px;"  runat="server" Font-Bold="False"></asp:Label>
                </div>
                </div>
                   <div class="row">
                <div class="col-sm-3" style="text-align:left">
                <asp:Label ID="lblBranch" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>
               </div>
                <div class="col-sm-3" >
                                       
                <asp:Label ID="lblBranchValue"  CssClass="control-label" style="margin-bottom: 5px;" runat="server" Font-Bold="False"></asp:Label>
               </div>
                <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblPAN" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>
                </div>
                <div class="col-sm-3" >
                    
                         <asp:Label ID="lblPANValue" CssClass="control-label" style="margin-bottom: 5px;"  runat="server" Font-Bold="False"></asp:Label>
               </div>
               </div>
                   <div class="row">
                <div class="col-sm-3" style="text-align:left">
                    <asp:Label ID="lblMobileNo" CssClass="control-label"  runat="server"></asp:Label>
               </div>

                <div class="col-sm-3" >
                    <asp:Label ID="lblMobileValue" CssClass="control-label" style="margin-bottom: 5px;"  runat="server" Font-Bold="False"></asp:Label>
                </div>
                <div class="col-sm-3" style="text-align:left">
                
                    <asp:Label ID="lblEmail" CssClass="control-label"  runat="server" ></asp:Label>
                    </div>
                <div class="col-sm-3" >
                    <asp:Label ID="lblEmailValue" CssClass="control-label" style="margin-bottom: 5px;"  runat="server" Font-Bold="False"></asp:Label>
              </div>
            </div>
           
           <%-- </td>
            </tr>

        <tr>
            <td>--%>
                <%-- <table class="tableIsys" style="border-collapse: separate; left: 0in; position: relative; top: 0px; width: 90%;" >
                    <tr style="height: 20px;">--%>

                 <div class="panel  panel-success">
              <div class="panel-heading subheader" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_divagndetails','Span1');return false;"
                                                    style="background-color: #EDF1cc !important;">
                                                    <div class="row" align="left">
                                                        <div class="col-sm-10">
                                                            <span class="glyphicon glyphicon-menu-hamburger" style="margin-right: 5px; color: Orange;">
                                                            </span>
                                                            <asp:Label ID="lblpfrecinfotitle" runat="server" Text="Old SM Details" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <span id="Span1" class="glyphicon glyphicon-resize-full" style="float: right; padding: 1px 10px ! important;
                                                                font-size: 18px; color: Orange;"></span>
                                                        </div>
                                                        <%-- <asp:Label ID="Label1" runat="server" CssClass="standardlabel" Font-Bold="True" Text=""></asp:Label>--%>
                                                    </div>
                                                </div>

                        <%--<td colspan="5" align="left" class="test">
                            <asp:Label ID="lblpfrecinfotitle" runat="server" Text="Old SM Details" Font-Bold="True"></asp:Label>
                        </td>--%>
                  <%--  </tr>--%>
                 
                 
                      <div id="divagndetails" runat="server" class="panel-body" style="display: block">
                      <div class="row">
                  
                           <div class="col-sm-3"  style="text-align: left">
                            <asp:Label ID="lblpfSMCode" CssClass="control-label"  runat="server"></asp:Label><span style="color: #ff0000">*</span>
                       </div>
                       <%-- <td id="td_smcode" runat="server" nowrap="nowrap" align="left" class="formcontent"
                            style="width: 28%;">--%>
                            <div  id="td_smcode" class="col-sm-3" runat="server" >
                            <asp:UpdatePanel ID="UpdatePanel001" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtpfSMCode"  runat="server" CssClass="form-control" MaxLength="9" ReadOnly="true"
                                        TabIndex="17"  onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                        InvalidChars="& `''#%!@$^*-_+={}[]()|\:;?><,'~" FilterMode="InvalidChars" TargetControlID="txtpfSMCode"
                                        FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                   <%-- <span style="color: Black">OR</span>--%>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                       </div>
                             <%--<div class="col-sm-1" style="margin-bottom: 5px;">
                            <span style="color: Black">OR</span>
                     </div>--%>
                      <div class="col-sm-3" style="text-align:left">
                        <span  Font-Bold="true" >OR </span> &nbsp;
                            <asp:Label ID="Label5" Text="Employee Code" CssClass="control-label" runat="server"></asp:Label><span style="color: #ff0000">*</span>
                      </div>
                       <div class="col-sm-3" >
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control"  TabIndex="20" ReadOnly="true"
                                         onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        InvalidChars="& `''#%!@$^*-_+={}[]()|\:;?><,'~" FilterMode="InvalidChars" TargetControlID="txtEmpCode"
                                        FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    
                                </ContentTemplate>
                            </asp:UpdatePanel>
                       </div>
                
              <%--      <tr id="trempcode" runat="server">--%>
                       <div class="col-sm-3" style="text-align: left">
                       
                            <asp:Label ID="lblpfSlsChannel" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label><span
                                style="color: #ff0000">*</span>
                                </div>
                     
                          <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSlsChannel" runat="server"  CssClass="form-control" Enabled="false"
                                        TabIndex="19" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                          
                        </div>
                     
                          <div class="col-sm-3" style="text-align: left" >
                            <asp:Label ID="lblpfChnCls" CssClass="control-label" runat="server"></asp:Label>
                            <span style="color: #ff0000">*</span>
                    </div>
                     
                          <div class="col-sm-3" >
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="form-control" Enabled="false"
                                        TabIndex="22" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                           
                      </div>
                     
                          <div class="col-sm-3" style="text-align: left"> 
                            <asp:Label ID="lblpfSMName" CssClass="control-label" runat="server"></asp:Label><span style="color: #ff0000">*</span>
                       </div>
                     
                          <div class="col-sm-3" >
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtSMName" runat="server" style="margin-bottom: 5px;" CssClass="form-control" ReadOnly="true"
                                       TabIndex="26"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                     
                          <div class="col-sm-3" style="text-align:left">
                            <span style="color: #ff0000">
                                <asp:Label ID="lblpfagetype" CssClass="control-label" runat="server" Font-Bold="False" Style="color: black"></asp:Label>*</span>
                        </div>
                     
                          <div class="col-sm-3" >
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlAgntType" runat="server"  Visible="false"  CssClass="form-control"
                                        AutoPostBack="false" TabIndex="23" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlAgnTypes" runat="server"   DataTextField="MemTypeDesc01"
                                        DataValueField="MemType" Enabled="false"  CssClass="form-control" DataSourceID="DSAgnTypes"
                                        TabIndex="24" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:SqlDataSource ID="DSAgnTypes" runat="server" ConnectionString="<%$ ConnectionStrings:INSCCommonConnectionString %>">
                            </asp:SqlDataSource>
                        </div>
                        </div>
                        <div class="row">
                     
                          <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblpfimmleader" CssClass="control-label" runat="server"></asp:Label><span style="color: #ff0000">*</span>
                       </div>
                     
                          <div class="col-sm-3" >
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtBranchCode" runat="server" style="margin-bottom: 5px;"  CssClass="form-control" 
                                        ReadOnly="true" TabIndex="25" ></asp:TextBox>
                                        
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                     
                          <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblCndAgtType" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label><span
                                style="color: #ff0000">*</span>
                         </div>
                     
                          <div class="col-sm-3" >
                            <asp:UpdatePanel ID="updpnlCndAgtType" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCndAgtType" runat="server"  CssClass="form-control" Enabled="false"
                                        TabIndex="27">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                           
                            <asp:HiddenField ID="hdnBizsrc1" runat="server" />
                            <asp:HiddenField ID="hdnChnCls" runat="server" />
                     </div>  
                   
                    </div>
                    </div>
                    </div>
            

          <%--  </td>
        </tr>
        <tr>
            <td>--%>
               <%-- <table class="tableIsys" style="border-collapse: separate; left: 0in; position: relative; top: 0px; width: 90%;" >--%>
                   <div class="panel  panel-success">
            <div class="panel-heading subheader" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_tableIsys','Span2');return false;"
                                                    style="background-color: #EDF1cc !important;">
                                                    <div class="row" align="left">
                                                        <div class="col-sm-10">
                                                            <span class="glyphicon glyphicon-menu-hamburger" style="margin-right: 5px; color: Orange;">
                                                            </span>
                                                            <asp:Label ID="Label1" runat="server" Text="New SM Details" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <span id="Span2" class="glyphicon glyphicon-resize-full" style="float: right; padding: 1px 10px ! important;
                                                                font-size: 18px; color: Orange;"></span>
                                                        </div>
                                                        <%-- <asp:Label ID="Label1" runat="server" CssClass="standardlabel" Font-Bold="True" Text=""></asp:Label>--%>
                                                    </div>
                                                </div>
                  <%--  <tr style="height: 20px;">
                        <td colspan="5" align="left" class="test">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="New SM Details"></asp:Label>
                        </td>
                    </tr>--%>
                 <div id="tableIsys" runat="server" class="panel-body">
                  <div class="row">
                     <div class="col-sm-3" style="text-align: left">

                       
                            <asp:Label ID="lbloldRecruiterCode" CssClass="control-label"  runat="server"></asp:Label><span style="color: #ff0000">*</span>
                      </div>
                      <%--  <td id="td1" runat="server" nowrap="nowrap" align="left" class="formcontent"
                            style="width: 28%;">--%>
                           <div  id="td1" runat="server" class="col-sm-3" >
                                    <asp:TextBox ID="txtNwRecruiterCode" Enabled="false" runat="server" style="margin-bottom: 5px;" CssClass="form-control" MaxLength="9"
                                        TabIndex="17" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox> 
                                        <asp:HiddenField ID="hdnNwRecruiterCode" runat="server" />
                                        <asp:LinkButton ID="lnkSMAllocate" runat="server" Text="SM Allocate" >
                                        </asp:LinkButton>
                                   
                  
                  </div>

                 <%-- <div class="col-sm-1">
                            <span style="color: Black">OR</span>
                    </div>--%>
                        <div class="col-sm-3" style="text-align: left">
                        <span style="color: Black">OR</span> &nbsp;
                            <asp:Label ID="lbloldEmpCode" Text="Employee Code" CssClass="control-label"  runat="server"></asp:Label><span style="color: #ff0000">*</span>
                     
                         </div>
                        <div class="col-sm-3" >
                            
                                    <asp:TextBox ID="txtNwEmpCode" runat="server" Enabled="false" style="margin-bottom: 5px;"  CssClass="form-control"  TabIndex="20"
                                        onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                         <asp:HiddenField ID="hdnNwEmpCode" runat="server" />
                                   
                       </div>
                       </div>
                  <div class="row">
                            <div class="col-sm-3" style="text-align:left">
                    
                   <%-- <tr id="tr1" runat="server">--%>
                        
                            <asp:Label ID="lbloldchannelClass" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label><span
                                style="color: #ff0000">*</span>
                  </div>
                            <div class="col-sm-3" >
                           
                                <asp:TextBox ID="txtNwchannelClass" runat="server" Enabled="false" CssClass="form-control" style="margin-bottom: 5px;"  TabIndex="20"
                                        onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                         <asp:HiddenField ID="hdnslschnl" runat="server" />
                                         <asp:HiddenField ID="hdnhierarchyname" runat="server" />
                                        
                           
                       </div>
                            <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lbloldsubClass" CssClass="control-label"  runat="server"></asp:Label><span style="color: #ff0000">*</span>
                        </div>
                            <div class="col-sm-3" >
                         
                                    <asp:TextBox ID="txtNwsubClass" runat="server" Enabled="false" CssClass="form-control" style="margin-bottom: 5px;"  TabIndex="20"
                                        onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                         <asp:HiddenField ID="hdnsubcls" runat="server" />
                                         <asp:HiddenField ID="hdnsubclass" runat="server" />
                                     
                          
                      </div>
                      </div>
                       <div class="row">
                            <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblOldSMName" CssClass="control-label"  runat="server"></asp:Label><span style="color: #ff0000">*</span>
                      </div>
                            <div class="col-sm-3" >
                          
                                    <asp:TextBox ID="txtNwSMName" runat="server" style="margin-bottom: 5px;" CssClass="form-control"  ReadOnly="true"
                                       TabIndex="26" ></asp:TextBox>
                                        <asp:HiddenField ID="hdnNwSMName" runat="server" />  
                               
                       </div>
                            <div class="col-sm-3" style="text-align:left">
                                <asp:Label ID="lbloldagttype" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>*</span>
                      </div>
                            <div class="col-sm-3" >
                       
                                <asp:TextBox ID="txtNwagttype" runat="server" style="margin-bottom: 5px;" CssClass="form-control"  ReadOnly="true"
                                       TabIndex="26" ></asp:TextBox>
                                        <asp:HiddenField ID="hdnagenttype" runat="server" />
                                         <asp:HiddenField ID="hdnagenttypedesc" runat="server" />
                               </div>

                            <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lbloldbrnch" CssClass="control-label"  runat="server"></asp:Label><span style="color: #ff0000">*</span>
                       </div>
                            <div class="col-sm-3">
                                    <asp:TextBox ID="txtNwbrnch" runat="server"  style="margin-bottom: 5px;" CssClass="form-control"  MaxLength="20"
                                        ReadOnly="true" TabIndex="25"  ></asp:TextBox>
                                       <asp:HiddenField ID="hdnUnitCode" runat="server" />  
                                       <asp:HiddenField ID="hdnbranchdesc" runat="server" />  
                      </div>
                            <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lbloldcndagttyp" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label><span
                                style="color: #ff0000">*</span>
                       </div>
                            <div class="col-sm-3">
                        <asp:TextBox ID="txtNwcndagttyp" runat="server" CssClass="form-control"  style="margin-bottom: 5px;"  MaxLength="20"
                                        ReadOnly="true" TabIndex="25"  Font-Size="10px"></asp:TextBox>
                                     <asp:HiddenField ID="hdncndagenttype" runat="server" />   
                                     <asp:HiddenField ID="hdncndagenttypedesc" runat="server" />  
                            
                     </div>
                    </div>
                    </div>
                    </div>
                    
              <%--  </table>--%>
          <%--  </td>
        </tr>
        <tr>
        <td>--%>
                     <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                             <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-primary" 
                            OnClick="btnSubmit_Click">
                         <span class="glyphicon glyphicon-download BtnGlyphicon"></span> Submit</asp:LinkButton>
                            <%--<asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit"
                                CssClass="standardbutton" Width="114px"></asp:Button>--%>
                                
                           <%-- <asp:Button ID="btnClear" TabIndex="43" OnClick="btnClear_Click" runat="server" Text="Cancel"
                                CssClass="standardbutton" Width="114px"></asp:Button>--%>
                                <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-danger" 
                                    TabIndex="5" runat="server">
                                 <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> Cancel</asp:LinkButton>
                              
                                <input type="hidden" runat="server" id="hdncndbrnch"/>
                       
                          </div>
                              </div>
         <%--   </td></tr>
         </table>--%>
          </div>
         </div>




        <asp:Panel runat="server" ID="pnlMdl" Width="75%" Height="50%" display="none">
        <iframe runat="server" id="ifrmMdlPopup"   width="100%" frameborder="0"
            display="none" style="height: 384%;
    overflow: scroll;
    margin-top: -116px;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender><%-- DropShadow="true"--%><%--pnlMdl--%>
        <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="309px" Height="182px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="panel-heading" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <table>
            <tr>
                <td style="width: 391px">
                    <br />
                    <center>
                        <asp:Label ID="lbl_popup" runat="server"></asp:Label><br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" CssClass="standardbutton" TabIndex="1205" Width="81px" /></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl_popup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
         </center>
         </div>
</asp:Content>


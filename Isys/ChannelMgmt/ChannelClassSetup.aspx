<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChannelClassSetup.aspx.cs"
    Inherits="INSCL.ChannelClassSetup" MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <%--<link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />\--%>



    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
         <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
     <link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
        <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function funcShowPopupLOB() {
            debugger;
            $find("mdlViewBIDLOB").show();
            var prdcode = document.getElementById('<%= hdnprdcode.ClientID%>').value;
            var ProdcodeEdit = document.getElementById('<%= hdnProdcodeEdit.ClientID%>').value;
            var Chntype = document.getElementById('<%= hdnChntype.ClientID%>').value;
            var Chnchncls = document.getElementById('<%= hdnchncls.ClientID%>').value;
            if (document.getElementById('ctl00_ContentPlaceHolder1_lblChannel') != null) {
                var ChnName = document.getElementById('ctl00_ContentPlaceHolder1_lblChannel').innerText;
            }
            else { var ChnName = ""; }

            if (document.getElementById('<%= hdnBizSrc.ClientID%>').value != null) {
                var Bizsrc = document.getElementById('<%= hdnBizSrc.ClientID%>').value;
            }
            else { var Bizsrc = ""; }
            var MemTypeDesc = "";
            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "../../../Application/ISys/ChannelMgmt/LOBDtls.aspx?mdlpopup=" + 'MdlPopExtndrLOB' + "&hdnprodcode=" + prdcode + "&Flag=" + ProdcodeEdit + "&ChnType=" + Chntype + "&ChnName=" + ChnName + "&MemTypeDesc=" + MemTypeDesc + "&Bizsrc=" + Bizsrc + "&Chnchncls=" + Chnchncls;
        }


        function popup() {
            var modal = document.getElementById('myModal');
            modal.style.display = 'block';
            //$("#myModal").modal();
        }

        function ClosePopup()
        {
            var modal = document.getElementById('myModal');
            modal.style.display = 'none';
            //$("#myModal").modal();
        }
       


        debugger;
        function funPopUp() {
            debugger;

            var value = document.getElementById('<%= lblChncls.ClientID%>').value;
            var Header = "Version History Of Subchannel";
            var Flag = "SUBCHANNEL";
            $find("mdlViewBIDLOB").show()
            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "PopupCompanyHistory.aspx?&Code=" + value + "&mdlpopup=mdlViewBIDLOB" + "&Header=" + Header + "&Flag=" + Flag;
        }

        $(function () {
            debugger;
            $("#<%= txtEffDate.ClientID  %>").datepicker({ minDate: '01/04/2021', maxDate: '31/03/2022', dateFormat: 'dd/mm/yy' });
            $("#<%= txtCseDt.ClientID  %>").datepicker({ maxDate: '+365d', minDate: '-0d', dateFormat: 'dd/mm/yy' });
        });


		        function ShowReqDtlNEW(divName, btnName) {
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

          function ShowReqDtl1(divName, btnName) {
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


        function validate() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strContent + "ddlSalesChannel").value == "Select") {
                debugger;
                alert("Please Select Hierarchy Channel Name ");
                document.getElementById(strContent + "ddlSalesChannel").focus();
                return false;
            }


            if (document.getElementById(strContent + "txtChnCls").value == "") {
                alert("Please Enter Hierarchy Sub Class");
                document.getElementById(strContent + "txtChnCls").focus();
                return false;
            }

            if (document.getElementById(strContent + "txtDesc1").value == "") {
                alert("Please Enter Hierarchy Sub Class Description 1");
                document.getElementById(strContent + "txtDesc1").focus();
                return false;
            }

            if (document.getElementById(strContent + "ddlParentSubChnl").value == "Select") {
                alert("Please Select Hierarchy Parent Sub Channel ");
                document.getElementById(strContent + "ddlParentSubChnl").focus();
                return false;
            }

            if (document.getElementById(strContent + "txtEffDate") != null) {
                if (document.getElementById(strContent + "txtEffDate").value == "") {
                    alert("Please Enter Effective Date");
                    document.getElementById(strContent + "txtEffDate").focus();
                    return false;
                }
            }

            if (document.getElementById(strContent + "lblChannel").value == "") {
                alert("Please Enter Hierarchy Sub Class");
                document.getElementById(strContent + "lblChannel").focus();
                return false;
            }

            if (document.getElementById(strContent + "lblChncls").value == "") {
                alert("Please Enter Hierarchy Sub Class");
                document.getElementById(strContent + "lblChncls").focus();
                return false;
            }
        }
    </script>
    <style>
        .rowspacing
        {
            margin-bottom: 10px
        }
    </style>
    <asp:ScriptManager runat="server" ID="ScriptManager1">
    </asp:ScriptManager>
    <%-- <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>--%>
    <center>

     
        <%--modification div--%>
         <div class="panel" id="divModification" runat="server" style="margin-left: 2% !important;margin-right: 2% !important;display:block;display:block;">
<div id="Div18" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divmodifybody','btndivmodify');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label21" runat="server" Text="CORRECTION OR CHANGES IN SUB CLASS SETUP"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="btndivmodify" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>         
           </div>
                <div id="divmodifybody" runat="server" class="panel-body" style="display:block"> 
                   <div class="row" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left;margin-top: 10px;">
                        <asp:Label ID="lblModMode" Text="Mod mode" runat="server"  CssClass="control-label" /> 
                        <span style="color: #ff0000"> *</span>
                        </div>
                         <div class="col-md-3" style="text-align:left"  >
                        <div class="btn-group"  role="group" style="margin-left: -162px;">
                            <asp:UpdatePanel runat="server" ID="upd7">
                          <ContentTemplate>
                        <asp:RadioButtonList  ID="rbCorrection" runat="server"  CellPadding="2" CellSpacing="2"  RepeatDirection="Horizontal"  AutoPostBack="true" OnSelectedIndexChanged="rbCorrection_OnSelectedIndexChanged" >   
                        <asp:ListItem Text="&nbspCorrection&nbsp" Selected="True"  value="CR"  class="btn btn-default"  />
                        <asp:ListItem Text="&nbspChanges&nbsp"  value="CH"  class="btn btn-default" style="margin-left: 0px;"  />
                           </asp:RadioButtonList>
                     </ContentTemplate>

                            </asp:UpdatePanel>
                    </div>
                       </div>
                        <div class="col-md-3">
                     </div>
                      <div class="col-md-3">
                     </div>
                  </div>
            </div>
        </div>
        <%--Hierarchy Sub Class Setup"--%>
        <asp:UpdatePanel ID="UpdatePan" runat="server">
        <ContentTemplate>

        <div class="panel" style ="margin-left: 2% !important;margin-right: 2% !important;">
           <div id="divcmphdrcollapse" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','Span1');return false;">           
                <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                       <asp:Label ID="lblsub" Text="HIERARCHY SUB CLASS SETUP" runat="server"  CssClass="control-label"  Font-Size="19px"/>
                    </div>
                    <div class="col-sm-2">
                        <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
                        
           <div id="divcmphdr" style="display:block;" runat="server" class="panel-body">
               <div class="row rowspacing">
             <div class="col-sm-4" style="text-align:left">
                <span style="color: Red">
                   <asp:Label ID="lblSaleschannel" runat="server" CssClass="control-label" Style="color: Black"></asp:Label> *</span>
            <%-- </div> 
             <div >--%>
                 <asp:TextBox ID="lblChannel" TabIndex="4" runat="server" CssClass="form-control"  Visible="False"></asp:TextBox>
                    <asp:DropDownList  ID="ddlSalesChannel" runat="server" Visible="False" AutoPostBack="true"  CssClass="form-control" TabIndex="2" OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                    </asp:DropDownList> 
              </div>
             <div class="col-sm-4" style="text-align:left">
                <span style="color: Red">
                <asp:Label ID="lblClass" runat="server" CssClass="control-label" Style="color: Black"></asp:Label> *</span>
            <%-- </div>
               
             <div >--%>
                <asp:TextBox ID="txtChnCls" runat="server"  MaxLength="4" Visible="False" TabIndex="3"
                CssClass="form-control"  onChange="javascript:this.value=this.value.toUpperCase();" OnTextChanged="txtChnCls_TextChanged" AutoPostBack="true"></asp:TextBox>                                    
                <asp:TextBox ID="lblChncls" runat="server" CssClass="form-control" Visible="False" TabIndex="4"></asp:TextBox>
           
             <ajaxToolkit:FilteredTextBoxExtender ID="txtChnClsFTX" runat="server"  TargetControlID="txtChnCls"
            FilterType="Custom, LowercaseLetters, UppercaseLetters">
            </ajaxToolkit:FilteredTextBoxExtender>
                 </div>
                     <div class="col-sm-4"  style="text-align:left">
               <asp:UpdatePanel runat="server" ID="UpdatePanel3">
        <ContentTemplate>
                <span style="color: Red">
                <asp:Label ID="lblDesc1" runat="server" CssClass="control-label" Style="color: Black"></asp:Label> *</span><%--shreela--%>
           <%-- </div>                               
             <div >--%>
                <asp:TextBox ID="txtDesc1" runat="server" CssClass="form-control" TabIndex="5"
                MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
             </ContentTemplate>
                   </asp:UpdatePanel>
            </div>          
              </div>
                <div class="row rowspacing">                
              <div class="col-sm-4" style="text-align:left">  
                <asp:Label ID="lblDesc2"  CssClass="control-label" runat="server"></asp:Label>
                 <asp:TextBox ID="txtDesc2" runat="server" CssClass="form-control" TabIndex="6"
                    MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="txtDesc2FTX" runat="server" ValidChars=" "
                    FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers" TargetControlID="txtDesc2">
            </ajaxToolkit:FilteredTextBoxExtender>
            </div>
              <div class="col-sm-4" style="text-align:left">
                <asp:Label ID="lblDesc3" runat="server"  CssClass="control-label"></asp:Label>
                 <asp:TextBox ID="txtDesc3" runat="server" CssClass="form-control" TabIndex="7"
            MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="txtDesc3FTX" runat="server" ValidChars=" "
            FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers" TargetControlID="txtDesc3">
            </ajaxToolkit:FilteredTextBoxExtender>
            </div>
              <div class="col-sm-4" style="text-align:left">
        <%--<span style="color: Red">--%>
        <asp:Label ID="lblSortOrder" runat="server"   CssClass="control-label"  Style="color: Black"></asp:Label><%-- *</span>--%>
                 <asp:UpdatePanel runat="server" ID="UpdatePanel4">
        <ContentTemplate>
                    <%--<asp:TextBox ID="txtSortorder" runat="server"  CssClass="form-control"  TabIndex="8" OnTextChanged="txtSortorder_TextChanged"
                    MaxLength="2" AutoPostBack="true"></asp:TextBox>--%>
            <asp:TextBox ID="txtSortorder" runat="server"  CssClass="form-control"  TabIndex="8"
                    MaxLength="2" AutoPostBack="true"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="txtSortorderFTX" runat="server" ValidChars="01234567890"
                    TargetControlID="txtSortorder" FilterType="Custom, Numbers">
                    </ajaxToolkit:FilteredTextBoxExtender>
             </ContentTemplate>
                   </asp:UpdatePanel>
        </div>
              </div>
            <div class="row rowspacing">
             <div class="col-sm-4" style="text-align:left">
                     <asp:Label ID="lblSubChnlType" Text="Sub Class Type" CssClass="control-label" runat="server" ></asp:Label>
                 <asp:Label ID="lblSubChnl" runat="server" style="display:none;" ></asp:Label> 
                <asp:DropDownList ID="ddlSubChnlType" runat="server" TabIndex="9" CssClass="select2-container form-control"  
                AutoPostBack="false">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem Value="P">P</asp:ListItem>
                <asp:ListItem Value="S">S</asp:ListItem>
                </asp:DropDownList>
            </div>
              <div class="col-sm-4" style="text-align:left">
                     <asp:Label ID="lblPrntSubChnl" Text="Parent Sub Channel" CssClass="control-label" runat="server"></asp:Label>
                           <span style="color: Red"> <asp:Label ID="Label1" runat="server" CssClass="control-label" Style="color: Black"></asp:Label> *</span>
                           <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <ContentTemplate>
                <asp:DropDownList ID="ddlParentSubChnl" runat="server" TabIndex="9" CssClass="select2-container form-control" AutoPostBack="True">
                </asp:DropDownList>
             </ContentTemplate>
          </asp:UpdatePanel>
                      </div>
             </div>
           </div>
        </div>
            </contenttemplate> 
       </asp:UpdatePanel> 

      <br />
        <%--Product Details--%>
        <div class="panel" id="div16" runat="server" style="margin-left: 2%; margin-right: 2%; display:none">
          <div  id="divprodtls" runat="server" >
        <div id="Div17" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divChannel','spnsrch');return false;">  
            <div class="row">
            <div class="col-sm-10" style="text-align:left">
                <asp:Label ID="lblprodname" runat="server" Text="PRODUCT DETAILS"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
            </div>
            <div class="col-sm-2">
                    <span id="spnsrch" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                    padding: 1px 10px ! important; font-size: 18px;"></span>
                    <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true"></asp:Label>
            </div>
        </div> 
    </div>
     
        <div id="divChannel" runat="server" style="width:96.6%;" class="container panel-body" >
        <div class="row">
        <div class="col-sm-8" style="text-align: center">                       
            <asp:LinkButton ID="lnkbtnaddprod" runat="server"  CssClass="btn btn-sample" 
            CausesValidation="false" TabIndex="14" OnClick="lnkbtnaddprod_Click">
            <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Add Product
            </asp:LinkButton>
                </div>
            <div class="col-sm-2">
            <asp:Label ID="lblstatus" CssClass="control-label" Text="Product Status" runat="server" />
        </div> 
            <div class="col-sm-2">
            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control" Enabled="false">
                <asp:ListItem Value="All" Text="All"  Selected="True"> </asp:ListItem>
                    <asp:ListItem Value="A" Text="Active"> </asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
        <br />
        <div id="divProducrGridDtls" runat="server"> 
        <asp:GridView ID="GridProdDtls" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#F6F6F6" CssClass="footable"
            PageSize="10" AllowSorting="True" AllowPaging="True" DataKeyNames="ProductCode,ProductName" OnRowDataBound="GridProdDtls_RowDataBound"> <%--OnRowDataBound="GridProdDtls_RowDataBound"--%>
            <RowStyle CssClass="GridViewRowNew"></RowStyle>
            <PagerStyle CssClass="disablepage" />
            <HeaderStyle CssClass="gridview th" HorizontalAlign="Left" />
            <Columns>                       
                <asp:TemplateField HeaderText="Product Code" HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblProdCode" runat="server" CssClass="standardlabel" Text='<%# Eval("ProductCode").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hndProductCode" runat="server" Value='<%# Eval("ProductCode").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblProdName" CssClass="standardlabel" runat="server" Text='<%# Eval("ProductName").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hndProductName" runat="server" Value='<%# Eval("ProductName").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Effective Date" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblEffFromDate" CssClass="standardlabel" runat="server" Text='<%# Eval("EffFromDate").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hdnEffFromDate" runat="server" Value='<%# Eval("EffFromDate").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="LOB Code" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblLobCode" CssClass="standardlabel" runat="server" Text='<%# Eval("LobCode").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hdnLobCode" runat="server" Value='<%# Eval("LobCode").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" CssClass="standardlabel" runat="server" Text='<%# Eval("Status").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("Status").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cease Date" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblCeaseDtim" CssClass="standardlabel" runat="server" Text='<%# Eval("CeaseDtim").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hdnCeaseDtim" runat="server" Value='<%# Eval("CeaseDtim").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>                  
                        <asp:Button runat="server" ID="lnkdelete" Text="Delete" CommandName="Delete" CssClass="btn btn-sample" /><%--CausesValidation="false"OnClick="lnkdelete_Click"--%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
        <br />
        <center>
            <table id="tblpagination" runat="server" visible="false"> 
                <tr>
                    <td>
                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" /> <%--OnClick="btnprevious_Click"--%>
                        <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 35px; border-style: solid;
                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                        <%--OnClick="btnnext_Click"--%>
                </td>
                </tr>
            </table>
        </center>
        <br />
                  
            <center>  <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false" Width="310px"></asp:Label><%--Style='margin-left: 192px;' --%>
            </center>
    </div>
    </div>
    </div>
        </div>
        <%--Other Details--%>
        <div class="panel" style ="margin-left: 2% !important;margin-right: 2% !important;">
                <div id="divcmpsrchhdrcollapse" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div1','Span2');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                        <asp:Label ID="lblhdr" Text="OTHER DETAILS" runat="server" CssClass="control-label"  Font-Size="19px" />
                 
                    </div>
                    <div class="col-sm-2">
                    
                        <span id="Span2" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>                                   
                 <div id="div1" style="display:block;" runat="server" class="panel-body">
                     <div class="row rowspacing">
                     <div class="col-sm-4" style="text-align:left">
                                <asp:Label ID="lblPer" CssClass="control-label" runat="server" />
                   <asp:TextBox ID="txtFinYr" runat="server" CssClass="form-control" Visible="false" TabIndex="10"/>
                                <asp:DropDownList ID="ddlFinancialYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                                </div>
                     <div class="col-sm-4" style="text-align:left">
                                <asp:Label ID="lblVer" CssClass="control-label" runat="server" />
                               <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                          <ContentTemplate>
                                <asp:TextBox ID="txtVer" runat="server" CssClass="form-control" TabIndex="11"/>
                                
              </ContentTemplate>
          </asp:UpdatePanel>
                                 </div>
                     <div class="col-sm-4" style="text-align:left">
                          <span style="color: Red">
                                <asp:Label ID="lblEffDate" Style="color: Black" runat="server" /> *</span>
                              <asp:TextBox ID="txtEffDate" runat="server" CssClass="form-control" TabIndex="12" style="margin-left:2px;background-color:white !important"/>
                                </div>
                        </div>                      
                        
                          
                             <div class="row rowspacing" style="text-align:left">    
                             <div class="col-sm-4" style="text-align:left">
                                <asp:Label ID="lblCseDt" CssClass="control-label" runat="server" />
                                 <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                                          <ContentTemplate>
                                  <asp:TextBox ID="txtCseDt" runat="server" CssClass="form-control" TabIndex="12" style="margin-left:2px;background-color:white !important"/>
                                        </ContentTemplate>
                         </asp:UpdatePanel> 
                           </div>
                             <div class="col-sm-4" style="text-align:left">
                          <asp:Label ID="lblSubChnStatus" Text="Status" runat="server" CssClass="control-label" /> 
                           <span style="color: #ff0000"> *</span>
                             <asp:DropDownList Enabled="false" id="DropDownList1"  CssClass="form-control"  runat="server">
                        <asp:ListItem   Value="Draft">Draft</asp:ListItem>
                     <asp:ListItem Selected="True" Value="Final">Final</asp:ListItem>
                        </asp:DropDownList>
                      </div>
                           </div>
                    
               <%--//added by Keshav END--%>        
                                
                           
                       
                    </div>
                      </div>
        <%--buttons--%>
        <div class="row" style="margin-top:12px;" id="div2" runat="server">
                    <div class="col-sm-12" align="center">

                         <asp:LinkButton ID="btnSave"  runat="server"  CssClass="btn btn-success" 
                              CausesValidation="false"   TabIndex="14"  OnClick="btnSave_Click" OnClientClick="return validate();"> 
                                   <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon" style="color:White">  </span> SAVE
                                </asp:LinkButton>&nbsp;
       
                         <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-success" CausesValidation="false"
                                 Text="UPDATE" OnClick="btnUpdate_Click"  OnClientClick="return validate();" TabIndex="14" >
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span> UPDATE
                        </asp:LinkButton>  
               
                         <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-clear" TabIndex="15" CausesValidation="False"
                               OnClick="Cancel_Click">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color:#f04e5e"> </span> CANCEL
                             </asp:LinkButton> 

                           &nbsp;
                      <asp:LinkButton ID="btnshowHist" runat="server" CssClass="btn btn-success"  
                              CausesValidation="false" TabIndex="15" OnClientClick="funPopUp();return false;" ><%--onclick="btnshowHist_Click1"--%>
                                 <span class="glyphicon glyphicon-dashboard" style="color:White">  </span> VIEW HISTORY
                                </asp:LinkButton>

                             </div>

                             </div>
    </center>
    <%--modolpopup--%>

    <div class="modal" id="myModal" role="dialog" style="display: none; margin-top: 53px;">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color:white !important">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" Style="margin-left: 96px;color:blue;font-size: 17px;"></asp:Label>

                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-success" data-dismiss="modal" style="margin-right: 115px;" onclick="ClosePopup();">
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK

                    </button>

                </div>
            </div>
        </div>
    </div>



    <asp:Panel runat="server" ID="PnlPopupLOB" Width="1000px" Height="550px" display="none" top="52" left="529px">
        <iframe runat="server" id="IframeLOB" width="100%" frameborder="0" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblpopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopExtndrLOB" BehaviorID="mdlViewBIDLOB"
        DropShadow="false" TargetControlID="lblpopup" PopupControlID="PnlPopupLOB" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>


    <asp:Button ID="btnProductDtls" runat="server" OnClick="btnProductDtls_Click" ClientIDMode="Static"
        Style="display: none;" TabIndex="72" />
    <asp:HiddenField ID="hdnprodctcode" runat="server" />
    <asp:HiddenField ID="hdnprodctNmae" runat="server" />

    <asp:Button ID="btncease" runat="server" ClientIDMode="Static"
        Style="display: none;" TabIndex="72" />
    <asp:HiddenField ID="hdn1" runat="server" />
    <asp:HiddenField ID="hdn2" runat="server" />
    <asp:HiddenField ID="hdn3" runat="server" />
    <asp:HiddenField ID="hdnprdcode" runat="server" />
    <asp:HiddenField ID="hdnProdcodeEdit" runat="server" />
    <asp:HiddenField ID="hdnChntype" runat="server" />
    <asp:HiddenField ID="hdnBizSrc" runat="server" />
    <asp:HiddenField ID="hdnchncls" runat="server" />
    <asp:HiddenField ID="hdnChnlNm" runat="server" />
    <%--</ContentTemplate>
         </asp:UpdatePanel>--%>
    <script type="text/javascript">
        hideRadioSymbol();

        function hideRadioSymbol() {
            debugger;
            var rads = new Array();
            rads = document.getElementsByName('ctl00$ContentPlaceHolder1$rbCorrection'); //Whatever ID u have given to ur radiolist.
            for (var i = 0; i < rads.length; i++)
                document.getElementById(rads.item(i).id).style.display = 'none'; //hide
        }

    </script>
    <script type='text/javascript'>
        $(function () {
            $("[id*=txtEffDate]").attr("readonly", true);
            $("[id*=txtEffDate]").attr.backgroundColor = "white";
            $("[id*=txtCseDt]").attr("readonly", true);
            //$("[id*=txtCseDt]").attr.backgroundColor = "white";
        })
    </script>

</asp:Content>

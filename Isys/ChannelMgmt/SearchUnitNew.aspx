<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchUnitNew.aspx.cs" Inherits="INSCL.SearchUnitNew"
    MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />

    <link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />



    <%--<link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />

     <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet" type="text/css" />
     
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
        <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
        <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"  type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
        --%>

    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
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

    
   <%--  <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>--%>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>

 
     
     
    <script type="text/javascript">
       /* added by sanoj 25052023*/
        function funPopUp(id) {
            debugger;
            //var start = document.getElementById("ctl00_ContentPlaceHolder1_lblChannel");
            //var value = start.textContent;
            //var Header = "Version History Of Channel";
            //var Flag = "CHANNEL";
            //alert(id)
            var strid = id;
            var bizscr = strid.replace("lnkAddMemType", "lblbizsrc");
            var UnitType = strid.replace("lnkAddMemType", "lblUnitType");
            var chncls = strid.replace("lnkAddMemType", "lblchncls");


            //alert(document.getElementById(bizscr).innerText);

            document.getElementById('mdlViewBIDLOB')
            var BizsrcVal = document.getElementById(bizscr).innerText;
            var ChnClsVal = document.getElementById(chncls).innerText;
            var AgentTypeVal = document.getElementById(UnitType).innerText;

            //var abc = $("[id*=mdlViewBIDLOB]").attr("id");
            $find("mdlViewBIDLOB").show()

            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "PopViewPageUnit.aspx?&mdlpopup=mdlViewBIDLOB" + "&Bizsrc=" + BizsrcVal + "&ChnCls=" + ChnClsVal + "&AgentType=" + AgentTypeVal;

            //document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "../../../Application/ISys/ChannelMgmt/LOBDtls.aspx?mdlpopup=MdlPopExtndrLOB" + "&hdnprodcode=" + prdcode + "&Flag=" + ProdcodeEdit + "&Bizsrc=" + Bizsrc + "&ChnType=" + Chntype + "&ChnName=" + ChnName + "&MemTypeDesc=" + MemTypeDesc;
        }
      /*  Endded bybsanoj 25052023*/

        function popup() {
            $("#myModal").modal();
        }

        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }


        function funpopup() {
            var myExtender = $find('mdlpopup1');
            myExtender.show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../ISys/ChannelMgmt/PopSearchUnitNew.aspx";
        }


        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";

            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(document.getElementById(strContent + divId)).slideUp();
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(document.getElementById(strContent + divId)).slideDown();
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }


    </script>
     <style>
   modalpopupmesg{
       background-color: white !important;
    padding: 15px 15px 15px 15px;
   } 
   
.gridview th {
    padding: 10px;
    height: 40px;
    border-color: #53accd !important;
    /*text-align: center;*/
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
} 
.clsCenter{
    text-align:center !important;
}
.clsLeft{
    text-align:left !important;
}
      .panel_over
      {
            margin-left: 0%!important;
            margin-right: 0%!important;
      }
	  .pad{
		  text-align:center !important;
	  }
	  .pad1{
		  text-align:left !important;
	  }
      .pad2{
          display:none !important;
          padding-left: 03px;
          padding-right: 03px;
            
      }
  </style>
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <center >
        <asp:UpdatePanel ID="upUnitType" runat="server">
            <ContentTemplate>
                
                
                <%--<div id="divUnitTypehdrcollapse" runat="server" style="width: 90%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-search"></i>
                                <asp:Label ID="lblChannelUnitTypesetup" runat="server" Style="padding-left: 5px;" />
                                <span style="padding-left: 555px;"></span>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <asp:LinkButton align="right" ID="lbOldHier" OnClick="btnOldHier_Click" Font-Bold="true" Visible="false"
                                    ForeColor="Yellow" Font-Italic="true" Font-Size="Smaller" Text="View Old Hierarchy"
                                    runat="server" />
                                <img id="myImg" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('divUnitTypehdr','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>--%>


                    <div class="panel">
                <div id="divcmphdrcollapse" runat="server" class="panelheadingAliginment"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divUnitTypehdr','btnpersnl');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                       <asp:Label ID="lblChannelUnitTypesetup" runat="server"   CssClass="control-label HeaderColor" Font-Size="19px"/>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>



                    <div id="divUnitTypehdr" style="display:block;" runat="server" class="panel-body">
                       <div class="row">
                      <div class="col-sm-3" style="text-align:left">
                                    <asp:Label ID="lblChnlType" runat="server"  Text="Channel Type"
                                        CssClass="control-label"></asp:Label>
                       </div>
                      <div class="col-sm-9" style="text-align:left">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" CellPadding="2"  CssClass="radiobtn" Width="185px"
                                                CellSpacing="2" RepeatDirection="Horizontal" TabIndex="1" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="&nbspCompany"></asp:ListItem>
                                                <asp:ListItem Value="1" Selected="True" Text="&nbspChannel"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                            </div>
                   </div>
                         <%--<div class="col-sm-3" style="text-align:left">
                         </div>
                          <div class="col-sm-3">
                         </div>--%>
                     
                                 <div class="row">
                                 <div class="col-sm-3" style="text-align:left">
                                    <asp:Label ID="lblSaleschannel" runat="server" CssClass="control-label"></asp:Label>
                              </div>

                               <div class="col-sm-3">
                                    <asp:UpdatePanel runat="server" ID="upnlSalesChannel">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlSalesChannel" runat="server"  
                                            CssClass="form-control" TabIndex="2" AutoPostBack="True" OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged">
                                            </asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    </div>
                               
                                <div class="col-sm-3" style="text-align:left">
                                    <asp:Label ID="lblChnnlClass" runat="server" Height="22px" Width="150px" CssClass="control-label"></asp:Label>
                                    </div>
                               

                                <div class="col-sm-3">
                                    <asp:UpdatePanel runat="server" ID="upnlChnnlClass">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlChnnlClass" runat="server" CssClass="form-control" TabIndex="3">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged">
                                            </asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                           </div>                     
                    </div>

                     
                        <div class="row">
                        <div class="col-sm-12" align="center" style="margin-bottom: 10px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success"   AutoPostback="false" TabIndex="4" Text="SEARCH"
                                    OnClick="btnSearch_Click" >
                                 <span class="glyphicon glyphicon-search" style='color:White;'></span> SEARCH
                                </asp:LinkButton> 
                                  &nbsp;
                                <asp:LinkButton ID="btnClear"    OnClick="btnClear_Click"  CssClass="btn btn-clear" TabIndex="5" Text="CLEAR"
                                    runat="server">
                             <span  style="color:#f04e5e" class="glyphicon glyphicon-erase BtnGlyphicon"> </span> CLEAR </asp:LinkButton>
                            </div>
                            </div>
                            </div>

                </div>

             
         
   




        <table id="tblmsg" runat="server" visible="false" align="center" width="75%">
            <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red" Width="659px"></asp:Label>
                </td>
            </tr>
        </table>
             <%--<br />--%>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <%--<div ID="divcmpsrchhdrcollapse" runat="server" class="divBorder1" 
                            style="width: 90%;">
                            <table class="formtablehdr" style="width: 100%;">
                                <tr ID="trDetails" runat="server" style="height: 30px;">
                                    <td style="padding-left: 5px;">
                                        <i class="fa fa-search"></i>
                                        <asp:Label ID="lblChannelUnitTypeSearch" runat="server" 
                                            Style="padding-left: 5px;" />
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <img id="Img1" src="../../../assets/img/portlet-collapse-icon-white.png" style="padding-right: 10px;"
                                            alt="" onclick="ShowReqDtl('divsrch','Img1','#Img1');" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>--%>


                                   <div id="divDemo" runat="server" visible="false" class="panel" >
                <div id="divcmpsrchhdrcollapse"  runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divsrch','Span1');return false;">           
                          <div class="row" style="margin-bottom: 12px;">
                    <div class="col-sm-10" style="text-align:left">
                        <asp:Label ID="lblChannelUnitTypeSearch" runat="server"  CssClass="control-label" Font-Size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                     <asp:LinkButton align="right" ID="lbOldHier" OnClick="btnOldHier_Click" Font-Bold="true" ForeColor="Yellow"  Visible="false" Font-Italic="true" Font-Size="Smaller" Text="View Old Hierarchy" runat="server" />
                        <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                
                            <div id="divsrch"  runat="server" style="overflow-x: scroll; display: block;width:97%;" >
                                
                                    <asp:UpdatePanel ID="updgDetails" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgDetails" runat="server" AllowPaging="True" 
                                                AllowSorting="True" AutoGenerateColumns="False" 
                                                CssClass="footable" 
                                                HorizontalAlign="Left" OnPageIndexChanging="dgDetails_PageIndexChanging" 
                                                OnRowCommand="dgDetails_RowCommand" OnRowDataBound="dgDetails_RowDataBound" 
                                                OnRowDeleting="dgDetails_RowDeleting" OnSorting="dgDetails_Sorting">
                                                  <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                   
                                                    <asp:BoundField DataField="BizSrcLinkDecs" HeaderStyle-HorizontalAlign="Center" 
                                                      HeaderText="Channel" 
                                                        ItemStyle-HorizontalAlign="Left" SortExpression="BizSrcLinkDecs">
                                                        <ItemStyle CssClass="clsLeft" />
                                                          <HeaderStyle CssClass="clsLeft"  />
                                                         </asp:BoundField>
                                                  
                                                    <asp:BoundField DataField="ChnclsLinkDesc" HeaderStyle-HorizontalAlign="Center" 
                                                       HeaderText="Sub Class" 
                                                        ItemStyle-HorizontalAlign="Left" SortExpression="ChnCls">
                                                        <ItemStyle CssClass="clsLeft" />
                                                          <HeaderStyle CssClass="clsLeft"  />
                                                         </asp:BoundField>
                                                    <asp:BoundField DataField="UnitType" HeaderStyle-HorizontalAlign="Center" 
                                                     HeaderText="Unit Type" 
                                                        ItemStyle-HorizontalAlign="Center" SortExpression="UnitType" >
                                                        <ItemStyle CssClass="clsLeft" />
                                                          <HeaderStyle CssClass="clsLeft"  />
                                                         </asp:BoundField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbluntyp" style='text-align:center' runat="server" Text='<%# Bind("UnitType") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="UnitRank" HeaderStyle-HorizontalAlign="Center" 
                                                       HeaderText="Unit Rank" 
                                                        ItemStyle-HorizontalAlign="Center" SortExpression="UnitRank">
                                                        <ItemStyle CssClass="clsCenter" />
                                                          <HeaderStyle CssClass="clsCenter"  />
                                                         </asp:BoundField>
                                                    <asp:BoundField DataField="UnitLevel" HeaderStyle-HorizontalAlign="Center" 
                                                           HeaderText="Unit Level" 
                                                        ItemStyle-HorizontalAlign="Center" SortExpression="UnitLevel" >
                                                        <ItemStyle CssClass="clsCenter" />
                                                          <HeaderStyle CssClass="clsCenter"  />
                                                         </asp:BoundField>
                                                    <asp:BoundField DataField="UnitDesc01" 
                                                        HeaderText="Unit Type Desc" SortExpression="UnitDesc01">
                                                          <ItemStyle CssClass="clsLeft" />
                                                          <HeaderStyle CssClass="clsLeft"  />
                                                         </asp:BoundField>
                                                    <%--added by sanoj 25052023--%>
                                                    <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkAddMemType" runat="server"  OnClientClick="funPopUp(this.id);return false;"  
                                                                data-toggle="tooltip" data-placement="left" Title="Add new member type below">
                                                              <asp:Image ID="imgMember" runat="server"  ImageUrl="../../../assets/img/Add_member_type.png" style="border-width: 0px;" />
                                                         </asp:LinkButton>
                                                          &nbsp&nbsp;&nbsp&nbsp;
                                                        <asp:LinkButton ID="lnkbtnabove" runat="server"  OnClientClick="funPopUp(this.id);return false;" Visible="false"  
                                                                data-toggle="tooltip" data-placement="left">
                                                              <asp:Image ID="imgabove" runat="server"  style="border-width: 0px;" />
                                                         </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                       <asp:TemplateField  Visible="true" ShowHeader="true" HeaderText="Cease">
                                                        <ItemTemplate>
                                                             <asp:LinkButton ID="DeleteBtn"  runat="server"  
                                                                     > <i aria-hidden="true" class="glyphicon glyphicon-trash" style="color:red;"></i>
                                                                    </asp:LinkButton
                                                                 >
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="clsCenter" />
                                                          <HeaderStyle CssClass="clsCenter"  />
                                                    </asp:TemplateField>

                                                    
                                                       <asp:BoundField DataField="Chncls" HeaderStyle-HorizontalAlign="Center"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                       HeaderText="Sub Class Code" 
                                                        ItemStyle-HorizontalAlign="Left" SortExpression="ChnCls" > 
                                                            <ItemStyle CssClass="clsLeft" />
                                                          <HeaderStyle CssClass="clsLeft"  />
                                                         </asp:BoundField>
                                                           <%--by meena to store Chncls  code--%>

                                                        <asp:TemplateField >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnitType" runat="server" Text='<%#Bind("UnitType")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad2" Font-Bold="False" ></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbizsrc" runat="server" Text='<%#Bind("BizSrc")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad2" Font-Bold="False"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblchncls" runat="server" Text='<%#Bind("ChnCls")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad2" Font-Bold="False"></ItemStyle>
                                                        </asp:TemplateField>
                                                    <%--endded by sanoj 25052023--%>
                                                 
                                                  




                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                               
                                <br />
                                <div ID="divPage" runat="server"   visible="true">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevious" runat="server" CssClass="form-submit-button" 
                                                                Enabled="false" OnClick="btnprevious_Click" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" Text="&lt;" 
                                                                Width="40px" />
                                                            <asp:TextBox ID="txtPage" runat="server" 
                                                                ReadOnly="true" Style="width: 44px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" />
                                                            <asp:Button ID="btnnext" runat="server" CssClass="form-submit-button" 
                                                                OnClick="btnnext_Click" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Text="&gt;" Width="40px" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                               

                                <div class="row">
                        <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnAddnew" runat="server" CssClass="btn btn-success"  style='margin-top:10px;margin-bottom:10px;'
                                OnClick="btnAddnew_Click" TabIndex="6"  Text="ADD NEW"  Visible="false">
                                  <span class="glyphicon glyphicon-plus"></span> ADD NEW
                                 </asp:LinkButton>
                                 &nbsp;
                        <asp:LinkButton ID="btnCopy"  runat="server" CssClass="btn btn-success" style='margin-top:10px;margin-bottom:10px;'
                                OnClick="btnCopy_Click" TabIndex="43" Text="COPY HIERARCHY"  Visible="false">
                                  <span class="glyphicon glyphicon-dashboard" style="color:White"></span> COPY HIERARCHY
                                 </asp:LinkButton>
                               </div>

                                </div>
                                 </div>
                             </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
           <%--     <table>
                    <tr ID="trCopy" runat="server" visible="false">
                        <td align="left" class="formcontent" style="width: 20%;">
                            <asp:Label ID="lblChnl" runat="server" Text="Hierarchy Name"></asp:Label>
                        </td>
                        <td align="left" class="formcontent" style="width: 30%;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlChnl" runat="server" AutoPostBack="True" 
                                        CssClass="standardmenu" Height="21px" 
                                        OnSelectedIndexChanged="ddlChnl_SelectedIndexChanged" Width="220px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td align="left" class="formcontent" style="width: 20%;">
                            <asp:Label ID="lblsubclass" runat="server" Text="Sub Class"></asp:Label>
                        </td>
                        <td align="left" class="formcontent" style="width: 30%;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSubclass" runat="server" CssClass="standardmenu" 
                                        Height="21px" Width="220px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlChnl" 
                                        EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr ID="trCopyBtn" runat="server" visible="false">
                        <td colspan="4" style="text-align: center;">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="standardbutton" 
                                OnClick="btnUpdate_Click" TabIndex="6" Text="UPDATE" Width="80px" />
                        </td>
                    </tr>
                </table>--%>
                <asp:UpdatePanel ID="UpdatePanelCopy" runat="server">
                        <ContentTemplate>
                   <div class="panel" id="divCopy" runat="server" >
                  <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divUnittypecopy','btndivUnittypecopy');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" Text="Hirearchy Copy" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="btndivUnittypecopy" class="glyphicon glyphicon-chevron-down" style="float: right;
                                    color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                        <div id="divUnittypecopy" runat="server" class="panel-body" style="display: block">
                         <div class="row" id="trCopy" runat="server" style="margin-bottom:5px;">
                 <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblChnl" CssClass="control-label" runat="server" Text="Hierarchy Name"></asp:Label>
                        </div>
                         <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlChnl" runat="server" AutoPostBack="True" 
                                       CssClass="form-control"    
                                        OnSelectedIndexChanged="ddlChnl_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                     </div>
                      <div class="col-sm-3" style="text-align:left">
                            <asp:Label ID="lblsubclass" CssClass="control-label" runat="server" Text="Sub Class"></asp:Label>
                       </div>

                         <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSubclass" runat="server" CssClass="form-control"   >
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlChnl" 
                                        EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                       </div>
                   </div>
                   <div class="row" ID="trCopyBtn" runat="server" style="margin-top:12px;">
                    <div class="col-sm-12" align="center">
                         <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sample" Text="Update"  TabIndex="13" CausesValidation="false"
                                OnClick="btnUpdate_Click">
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span> Update
                        </asp:LinkButton> 
                       </div>
                       </div>
               </div>
               </div>
               
              </ContentTemplate>
                    </asp:UpdatePanel>
              <%-- 
                <asp:Panel ID="pnlPopup" runat="server" BorderColor="ActiveBorder" 
                    BorderStyle="Solid" BorderWidth="2px" class="modalpopupmesg" Height="250px" 
                    Width="322px">
                    <table width="100%">
                        <tr align="center">
                            <td class="test" colspan="1" style="height: 32px;" width="100%">
                                INFORMATION
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="width: 391px;">
                                <br />
                                <center>
                                    <asp:Label ID="lblpopup" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                </center>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <center>
                        <asp:Button ID="btnok" runat="server" CssClass="standardbutton" TabIndex="105" 
                            Text="OK" Width="80px" />
                    </center>
                </asp:Panel>--%>
                
                
              <%--  <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" 
                    BackgroundCssClass="modalPopupBg" BehaviorID="mdlpopup" DropShadow="true" 
                    OkControlID="btnok" PopupControlID="pnlPopup" TargetControlID="lblpopup" 
                    Y="100">
                </ajaxToolkit:ModalPopupExtender>--%>

                <div class="modal fade" id="myModal" role="dialog">
                 <div class="modal-dialog modal-sm">
    
  

      <div class="modal-content" style='width:400px;'>
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label16" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button"  class="btn btn-Verify"  data-dismiss="modal"  style='border-radius: 15px;border-radius: 15px;'>
             <span class="glyphicon glyphicon-ok  BtnGlyphicon"> </span> OK
             </button>
        </div>
      </div>
    </div>
  </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <asp:Label ID="lbl_popup1" runat="server"></asp:Label>
    <asp:Panel ID="pnlVersion" runat="server" BorderColor="ActiveBorder" BackColor="White"
        BorderStyle="Solid" BorderWidth="2px" Width="700px" Height="370px">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <table class="formtable">
                    <tr>
                        <td colspan="2">
                            <iframe runat="server" id="ifrmMdlPopup" backcolor="#6B0408" 
                                width="700px" height="370px"   frameborder="1" display="none">
                            </iframe>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" colspan="2">
                            <asp:Button ID="btnclose" Text="Close" runat="server" CssClass="standardbutton" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnclose" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup1" runat="server" TargetControlID="lbl_popup1"
        BehaviorID="mdlpopup1" PopupControlID="pnlVersion" DropShadow="true">
    </ajaxToolkit:ModalPopupExtender>

     <%--Modal popup Setup Div  Added by sanoj for ADD Below Unit Type--%>
    <asp:Panel runat="server" ID="PnlPopupLOB" Width="100%" Height="100%" display="none">
        <iframe runat="server" id="IframeLOB" width="100%" frameborder="0" style="height: 100%;"></iframe>

        <div>Raj</div>
    </asp:Panel>
    <asp:Label runat="server" ID="lblpopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopExtndrLOB" BehaviorID="mdlViewBIDLOB"
        DropShadow="false" TargetControlID="lblpopup" PopupControlID="PnlPopupLOB" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Modal popup Setup Div  Endded by sanoj for ADD Below Unit Type--%>
</asp:Content>

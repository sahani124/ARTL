<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="InitalSetUp.aspx.cs" Inherits="Application_ISys_ChannelMgmt_InitalSetUp" %>

  
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
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>

    <style type="text/css">
  .border-collapse
  {
      border-collapse:inherit;
  }
  .RightBorder
{
   border-right: 3px solid Gray;
   border-collapse:separate;
}

.BottomBorder
{
    border-bottom:3px solid Gray;   
      padding-bottom:3px;
}

.bottom
{
  
}
</style>
 <script type="text/javascript">
        //Added by Rachana on 14/05/2013 for replacing js funOpenPopWinForUntCode with funcShowPopup start


     function funcShowPopup(bizsrc) {
            debugger;
            if (flag = "1") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/ChannelSetup.aspx?ChnTyp=O&flag=V&ChnCls=" + bizsrc + "&mdlpopup=mdlViewBID";
                //            window.open("../../../Application/ISys/ChannelMgmt/ChannelSetup.aspx?ChnTyp=C&flag=V&ChnCls=" + bizsrc , '','height=' + 520 + ',width=' + 1000 + ', toolbar=no,scrollbars=yes,resizable=yes,left=100,top=50,location=0');
                //            return false;
            }
           


        }

        function funcAddPopup() {
            debugger;

                            $find("mdlViewBID").show();
                            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/ChannelSetup.aspx?ChnTyp=C&flag=IN&mdlpopup=mdlViewBID";
//            window.open("../../../Application/ISys/ChannelMgmt/ChannelSetup.aspx?ChnTyp=C&flag=IN", '','height=' + 520 + ',width=' + 1000 + ',toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
//            return false;

        }

        function funcAddSubPopup() {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/ChannelClassSetup.aspx?flag=IN&mdlpopup=mdlViewBID";
            //            window.open("../../../Application/ISys/ChannelMgmt/ChannelSetup.aspx?ChnTyp=C&flag=IN", '','height=' + 520 + ',width=' + 1000 + ',toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
            //            return false;
        }

        function funcAddUR() {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/UnitRank.aspx?&flag=IN&mdlpopup=mdlViewBID";
            //            window.open("../../../Application/ISys/ChannelMgmt/ChannelSetup.aspx?ChnTyp=C&flag=IN", '','height=' + 520 + ',width=' + 1000 + ',toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
            //            return false;
        }

        function funcAddUT() {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/UnitNew.aspx?&flag=IN&mdlpopup=mdlViewBID";
            //            window.open("../../../Application/ISys/ChannelMgmt/ChannelSetup.aspx?ChnTyp=C&flag=IN", '','height=' + 520 + ',width=' + 1000 + ',toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
            //            return false;
        }

        function funcAddMT() {
         $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/AGTLevel.aspx?&flag=IN&mdlpopup=mdlViewBID";
            //            window.open("../../../Application/ISys/ChannelMgmt/ChannelSetup.aspx?ChnTyp=C&flag=IN", '','height=' + 520 + ',width=' + 1000 + ',toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
            //            return false;
        }

        
        </script>
           <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div>
        <table style="Width:100%;margin-left:0px;" cellpadding=0 cellspacing=0 class="border-collapse"><%--border="2"--%>
            <tr>
                <td   class="RightBorder">
               
                    <table width="100%" align="left" style="padding-left:275px;" cellpadding=0 cellspacing=0 class="border-collapse">
                        <tr align="left">
                            <td align="right" valign="top" class="BottomBorder bottom" >
                                <asp:Image ID="ImgCompany" runat="server" src="../../../theme/iflow/Company.jpg" alt="" Width="100px"
                                    Height="103px" />
                            </td>
                            <td  valign="top"  style="padding-right:0px;" class="BottomBorder">
                                <asp:Label ID="Label1" runat="server" Text="Company" CssClass="Head-label"></asp:Label>
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="SetUp of the organization" CssClass="control-label"></asp:Label>
                                <br />
                                 <br />
                                  <br />
                                   <br />
                                    <br />

                                <asp:LinkButton ID="LnkAdd" runat="server" Style="padding-right: 7px;" 
                                   CssClass="btn btn-primary" CausesValidation="true"
                                                          Enabled="false" class="btn btn-default" onclick="LnkAdd_Click"
                                    ><span class="glyphicon glyphicon-plus" style='color: White;'></span> Add</asp:LinkButton>                     
                                <asp:LinkButton ID="LnkView" runat="server" Style="padding-right: 7px;" CssClass="btn btn-primary" CausesValidation="true"
                                                          Enabled="false" class="btn btn-default" onclick="LnkView_Click">
                                     <span class="glyphicon glyphicon-search" style='color: White;'></span> View</asp:LinkButton>
                                <asp:LinkButton ID="LnkChange" runat="server" Style="padding-right: 7px;" CssClass="btn btn-primary" CausesValidation="true"
                                    Enabled="false" class="btn btn-default" onclick="LnkChange_Click">
                                     <span class="glyphicon glyphicon-edit" style='color: White;'></span> Change</asp:LinkButton>
                            </td>
                            
                        </tr>
                    </table>
                    
                </td>

                <td></td>
            </tr>
            <tr>
             <td width="50%" class="RightBorder"></td>
                <td width="50%">
                    <table width="100%" align="left" cellpadding=0 cellspacing=0>
                        <tr align="left">
                            <td width="1%" valign="top" class="BottomBorder bottom">
                                <asp:Image ID="ImgChannel" runat="server" src="../../../theme/iflow/Channel.jpg" alt="" Width="88px" style="margin-left:15px;"
                                    Height="103px" />
                            </td>
                          
                                 
                            <td align="left" width="44%" valign="top" style="padding-left:10px;" class="BottomBorder">
                                <asp:Label ID="Label3" runat="server" Text="Channel" CssClass="Head-label"></asp:Label>
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="SetUp of Channel for organization" CssClass="control-label1"></asp:Label>
                                <br />
                                   <br />
                                 <br />
                                    <br />
                                <asp:LinkButton ID="LnkAddChannel"  
                                runat="server" Style="padding-right: 7px;" 
                                   CssClass="btn btn-primary" CausesValidation="true"
                                                           class="btn btn-default" 
                                    onclick="LnkAddChannel_Click" Enabled="false"><span class="glyphicon glyphicon-plus" style='color: White;'></span> Add</asp:LinkButton>
                                <asp:LinkButton ID="LnkViewChannel" runat="server" Style="padding-right: 7px;" 
                                    CssClass="btn btn-primary" CausesValidation="true"
                                                           class="btn btn-default"  onclick="LnkViewChannel_Click">
                                     <span class="glyphicon glyphicon-search" style='color: White;'></span> View</asp:LinkButton>
                                <asp:LinkButton ID="LnkChangeChannel" runat="server" Style="padding-right: 7px;" CssClass="btn btn-primary" CausesValidation="true"
                                                           class="btn btn-default" 
                                    Enabled="false"><span class="glyphicon glyphicon-edit" style='color: White;'></span>Change</asp:LinkButton>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </td>
               
            </tr>
            <tr>
           
                <td class="RightBorder">
                    <table width="100%" align="left" style="padding-left: 275px" cellpadding=0 cellspacing=0 class="border-collapse">
                        <tr align="Left">
                            <td align="right" valign="top" class="BottomBorder bottom">
                                <asp:Image ID="ImgSubChannel" runat="server" src="../../../theme/iflow/sub1.jpg" alt="" Width="100px"
                                    Height="103px" />
                            </td>
                            <td  valign="top" style="padding-right:0px;" class="BottomBorder">
                                <asp:Label ID="Label5" runat="server" Text="Sub Channel" CssClass="Head-label"></asp:Label>
                                <br />
                                <asp:Label ID="Label6" runat="server" Text="SetUp of SubChannel for respective channels" CssClass="control-label1"></asp:Label>
                                <br />
                                   <br />
                                 <br />  
                                <asp:LinkButton ID="LnkAddSub" runat="server" 
                                    Style="padding-right: 7px;padding-left:13px;"  CssClass="btn btn-primary" CausesValidation="true"
                                                          class="btn btn-default"
                                    onclick="LnkAddSub_Click" Enabled="false">
<span class="glyphicon glyphicon-plus" style='color: White;'></span> Add</asp:LinkButton>
                                <asp:LinkButton ID="LnkViewSub" runat="server" Style="padding-right: 7px;" 
                                     CssClass="btn btn-primary" CausesValidation="true"
                                                          class="btn btn-default" onclick="LnkViewSub_Click"><span class="glyphicon glyphicon-search" style='color: White;'></span> View</asp:LinkButton>
                                <asp:LinkButton ID="LnkChangeSub" runat="server" Style="padding-right: 7px;" 
                                Enabled="false" CssClass="btn btn-primary" CausesValidation="true"
                                                         class="btn btn-default"> <span class="glyphicon glyphicon-edit" style='color: White;'></span> Change</asp:LinkButton>
                            </td>
                           
                        </tr>
                    </table>
                </td>
                 <td></td>
            </tr>
            <tr>
             <td width="50%" class="RightBorder"></td>
                <td >
                    <table width="100%" align="left" cellpadding=0 cellspacing=0>
                        <tr align="left">
                       
                            <td width="1%" valign="top" class="BottomBorder bottom">
                                <%--   <td  align="right"  style="width: 100px">--%>
                                <asp:Image ID="ImgUnitRank" runat="server" src="../../../theme/iflow/UR2.png" alt="" Width="88px" style="margin-left:15px;"
                                    Height="103px" />
                            </td>
                            <td align="left" width="44%" valign="top" class="BottomBorder">
                                <asp:Label ID="Label7" runat="server" Text="Unit Rank" CssClass="Head-label"></asp:Label>
                                <br />
                                <asp:Label ID="Label8" runat="server" Text="SetUp of Unit Rank" CssClass="control-label1"></asp:Label>
                                <br />
                                 <br />
                                 <br />
                                 <br />
                                <asp:LinkButton ID="LnkAddUR" runat="server" 
                                    Style="padding-right: 7px;padding-left:8px;" CssClass="btn btn-primary" CausesValidation="true"
                                                           class="btn btn-default"
                                    onclick="LnkAddUR_Click" Enabled="false"><span class="glyphicon glyphicon-plus" style='color: White;'></span> Add</asp:LinkButton>
                                <asp:LinkButton ID="LnkViewUR" runat="server" Style="padding-right: 7px;"  
                                    CssClass="btn btn-primary" CausesValidation="true"
                                                           class="btn btn-default" onclick="LnkViewUR_Click">
                                                           <span class="glyphicon glyphicon-search" style='color: White;'></span> View</asp:LinkButton>
                                <asp:LinkButton ID="LnkChangeUR" runat="server" Style="padding-right: 7px;" Enabled="false" 
                                CssClass="btn btn-primary" CausesValidation="true"
                                                           class="btn btn-default">
                                                          <span class="glyphicon glyphicon-edit" style='color: White;'></span> Change</asp:LinkButton>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                    </td>
            </tr>
            <tr>
                <td class="RightBorder">
                    <table width="100%" align="left" style="padding-left: 275px" cellpadding=0 cellspacing=0 class="border-collapse">
                        <tr align="left">
                            <td align="right" valign="top" class="BottomBorder bottom" >
                                <asp:Image ID="ImgUnitType" runat="server" src="../../../theme/iflow/UT.png" alt="" Width="88px"
                                    Height="103px" />
                            </td>
                            <td  valign="top" style="padding-right:0px;" class="BottomBorder">
                                <asp:Label ID="Label9" runat="server" Text="Unit Type" CssClass="Head-label"></asp:Label>
                                <br />
                                <asp:Label ID="Label10" runat="server" Text="SetUp of Unit Type " CssClass="control-label1"></asp:Label>
                                <br />
                                   <br />
                                   <br />
                                   <br /> 
                                   
                                <asp:LinkButton ID="LnkAddUT" runat="server" 
                                    Style="padding-right: 7px;padding-left:13px;" CssClass="btn btn-primary" CausesValidation="true"
                                                          class="btn btn-default"
                                    onclick="LnkAddUT_Click" Enabled="false"><span class="glyphicon glyphicon-plus" style='color: White;'></span> Add</asp:LinkButton>
                                <asp:LinkButton ID="LnkViewUT" runat="server" Style="padding-right: 7px;" 
                                   CssClass="btn btn-primary" CausesValidation="true"
                                                           class="btn btn-default" onclick="LnkViewUT_Click">
                                                           <span class="glyphicon glyphicon-search" style='color: White;'></span> View</asp:LinkButton>
                                <asp:LinkButton ID="LnkChangeUT" runat="server" Style="padding-right: 7px;" 
                                CssClass="btn btn-primary" CausesValidation="true"
                                                          Enabled="false" class="btn btn-default"><span class="glyphicon glyphicon-edit" style='color: White;'></span> Change</asp:LinkButton>
                            </td>
                          
                        </tr>
                    </table>
                </td>
                 <td></td>
            </tr>
            <tr>
            <td width="50%" class="RightBorder"></td>
                <td>
                    <table width="100%" align="left" cellpadding=0 cellspacing=0>
                        <tr align="left" >
                              <td width="1%" valign="top" class="BottomBorder bottom">
                                <%--    <td  align="right"  style="width: 100px">--%>
                                <asp:Image ID="ImgMemberType" runat="server" src="../../../theme/iflow/mem4.png" alt="" Width="88px" style="margin-left:15px;"
                                    Height="103px" />
                            </td>
                            <td  align="left"  width="44%" valign="top" class="BottomBorder">
                                <asp:Label ID="Label11" runat="server" Text="Member Type" CssClass="Head-label"></asp:Label>
                                <br />
                                <asp:Label ID="Label12" runat="server" Text="SetUp of Member Type" CssClass="control-label1"></asp:Label>
                                <br />
                                   <br />
                                   <br />
                                      <br />
                                   <br />
                                <asp:LinkButton ID="LnkAddMT" runat="server" 
                                    Style="padding-right: 7px;padding-left:8px;" CssClass="btn btn-primary" CausesValidation="true"
                                                           class="btn btn-default" 
                                    onclick="LnkAddMT_Click" Enabled="false"><span class="glyphicon glyphicon-plus" style='color: White;'></span> Add</asp:LinkButton>
                                <asp:LinkButton ID="LnkViewMT" runat="server" Style="padding-right: 7px;" 
                                     CssClass="btn btn-primary" CausesValidation="true"
                                                          class="btn btn-default" onclick="LnkViewMT_Click"><span class="glyphicon glyphicon-search" style='color: White;'></span> View</asp:LinkButton>
                                <asp:LinkButton ID="LnkChangeMT" runat="server" Style="padding-right: 7px;" 
                                CssClass="btn btn-primary" CausesValidation="true"
                                                          Enabled="false" class="btn btn-default"><span class="glyphicon glyphicon-edit" style='color: White;'></span> Change</asp:LinkButton>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </td>
                 
            </tr>
        </table>
    </div>

       <asp:Panel runat="server" ID="pnlMdl"   CssClass="panel panel-success" style="left:70% !important;"  display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="900" height="420px"  frameborder="0"  
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>


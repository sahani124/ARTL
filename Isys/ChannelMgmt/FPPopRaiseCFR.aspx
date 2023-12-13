<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FPPopRaiseCFR.aspx.cs" Inherits="Application_ISys_ChannelMgmt_FPPopRaiseCFR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Raise CFR </title>

     <%--  added by sanoj 12102022--%>
     <link href="../../../kmi%20styles/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
     <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
     <script type="text/javascript"  src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    
     
     <%--  added by sanoj 12102022--%>



    <script language="javascript" type="text/javascript">
        function doSelect(args1, raised, responded, closed) {
            debugger;
            window.parent.document.getElementById('<%=Request.QueryString["args1"].ToString()%>').disabled = true;
            window.parent.document.getElementById('<%=Request.QueryString["raised"].ToString()%>').innerText = raised;
            window.parent.document.getElementById('<%=Request.QueryString["responded"].ToString()%>').innerText = responded;
            window.parent.document.getElementById('<%=Request.QueryString["closed"].ToString()%>').innerText = closed;
            
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }


        
    </script>
    <style type="text/css">
       /* .style1
        {
            height: 20px;
        }
        .style2
        {
            FONT-FAMILY: Verdana, Tahoma, Arial;
            font-size: 12px;
            background-color: #FAFAFA;
            text-align: left;
            height: 18px;
        }*/
  .clscenter{
        text-align:center!important;
    }
    .clsLeft{
    text-align:left !important;
    padding-left: 10px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="card" id="divAlert" runat="server" style="width: 100%; display: block; border-radius: 2px; background-color: white; margin-top: 0px; margin-left: 1px"
                    cellpadding="0" cellspacing="0">
        <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Visible="False" Width="310px"></asp:Label>
         <div id="TrEmpSearch" runat="server" class="panel-body">
                        <div class="row">
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" Text="Document Type:" CssClass="control-label"
                        ForeColor="DarkBlue"></asp:Label>
                             
                            </div>
                            <div class="col-md-3">
                                 <asp:DropDownList ID="DdlDoctype1" runat="server" AutoPostBack="True" CssClass="form-control form-select" style="font-size: 14px;"
                        OnSelectedIndexChanged="DdlDoctype1_SelectedIndexChanged">
                    </asp:DropDownList>
                                <%--<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="form-control form-select" style="font-size: 14px;"
                                    OnSelectedIndexChanged="DdlDoctype1_SelectedIndexChanged">
                                </asp:DropDownList>--%>

                                	 
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-12">
                               <asp:Label ID="lblcfrraised" runat="server" Text="Raised CFR:" CssClass="control-label"></asp:Label>&nbsp;
                               <asp:Label ID="lblcfrraisedcount" runat="server" CssClass="control-label" Style="color:Red;"></asp:Label>
             
             
                             <asp:Label ID="lblrespond" runat="server" Text="Responded CFR:" CssClass="control-label"></asp:Label>&nbsp;
                             <asp:Label ID="lblcfrrespondcount" runat="server" CssClass="control-label" Style="color:Orange;"></asp:Label>

                                  <asp:Label ID="lblclosed" runat="server" Text="Closed CFR:" CssClass="control-label"></asp:Label>&nbsp;
                <asp:Label ID="lblcfrclosed" runat="server" CssClass="control-label" Style="color:Green;"></asp:Label><br />

                            </div>
                        </div>
                        <br />




        <table class="tableIsys">
            <tr>
                <td align="center" class="test" colspan="6" style="width: 30">
                   <%-- <asp:Label ID="Label2" runat="server" Text="Raise CFR" CssClass="standardlink "></asp:Label>--%>
                </td>
            </tr>
            <tr>
                <td class="formcontent" align="left" colspan="3">
                    
                </td>
                <td class="formcontent" align="left" colspan="3">
                   
                </td>
            </tr>
            <tr>
            <td align="left" class="style2" colspan="2">
                
            </td>
        <%--</tr>
        <tr>--%>
             <td align="left" class="formcontent" colspan="2">
              
            </td>
        </tr>




        </table>


       
            <div style="width: 100%" id="trDgDetails" runat="server">
                   <div id="Div2" runat="server" style="height: 37px;" onclick="ShowReqDtl('divSearch','btnWfParam1');return false;">
                                <div id="trtitle" runat="server" class="row" style="text-align: left">
                                    <div class="col-sm-10">
                                        <asp:Label runat="server" Text="Search Results" CssClass="HeaderColor" Font-Size="19px"></asp:Label>
                                        <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
<%--                                        <span id="btnWfParam1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; font-size: 18px;"></span>--%>
                                    </div>
                                </div>
                            </div>
                <div id="divSearch" runat="server" style="display: block">

                    <%--<asp:GridView ID="dgDetails" runat="server" PagerStyle-HorizontalAlign="Center"
                        PagerStyle-Font-Underline="true"
                        HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" CssClass="footable" 
                        OnRowDataBound="dgDetails_RowDataBound" OnRowUpdating="dgDetails_RowUpdating"
                        Width="100%" OnPageIndexChanging="dgDetails_PageIndexChanging" OnRowCommand="dgDetails_RowCommand" 
                        PageSize="10"> <%----%>
                        <%-- <FooterStyle CssClass="GridViewFooter" />
                          <HeaderStyle CssClass="gridview th" />
                          <RowStyle CssClass="GridViewRowNew" />
                          <PagerStyle CssClass="disablepage" />
                          <SelectedRowStyle CssClass="GridViewSelectedRow" />--%>

                    <asp:GridView ID="dgDetails" runat="server" AllowPaging="True" HorizontalAlign="Center" Style="border-bottom-color: black;"
                                    AutoGenerateColumns="False" CssClass="footable" OnRowCommand="dgDetails_RowCommand" OnRowUpdating="dgDetails_RowUpdating"
                                    PageSize="10" OnPageIndexChanging="dgDetails_PageIndexChanging" OnRowDataBound="dgDetails_RowDataBound">
                                    <FooterStyle CssClass="GridViewFooter" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <RowStyle CssClass="GridViewRowNew" />
                                    <PagerStyle CssClass="disablepage" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRow" />
                        <Columns>
                            <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="False"/>
                            <asp:TemplateField ItemStyle-Width="6%">
                                <ItemTemplate>
                                  <i class="fa fa-flash"></i>
                                    <asp:CheckBox ID="ChkRaise" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Wrap="False"></HeaderStyle>
                                <ItemStyle></ItemStyle>
                            </asp:TemplateField>
                            
                            <asp:TemplateField SortExpression="CFRDesc" HeaderText="CFR Remarks" ItemStyle-Width="350%">
                                <ItemTemplate>
                                    <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRDesc") %>'></asp:Label> 
                                   
                                   <asp:HiddenField ID="hdnDocCode" runat="server" Value='<%# Eval("DocCode") %>'></asp:HiddenField>
                                </ItemTemplate>
                               
                                 <ItemStyle CssClass="clsLeft"/>
                                 <HeaderStyle CssClass="clsLeft" />
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="Additional Remarks" ItemStyle-Width="550%">
                                <ItemTemplate>
                                <asp:Label ID="LblAddRemark" runat="server" Width="300px" Text='<%# Eval("CFRRemark")%>'></asp:Label>  <%--Text='<%# Eval("CFRDesc") %>'--%>
                                <asp:TextBox ID="TxtAddRemark" runat="server"  Visible="false" MaxLength="200"
                                        CssClass="standardtextbox" Width="300px" Text='<%# Eval("CFRRemark")%>'></asp:TextBox> <%--Text='<%# Eval("CFRDesc") %>'--%>
                                </ItemTemplate>
                              
                                <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                <asp:Label ID="LblRemarkid" runat="server" visible ="false" Text='<%# Eval("RemarkId") %>'></asp:Label> 
                                <asp:HiddenField ID="hdnRemarkid" runat="server" Value='<%# Eval("RemarkId") %>'></asp:HiddenField>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                      <%--  <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                        <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Blue"></PagerStyle>
                        <RowStyle CssClass="formsublinkeven" HorizontalAlign="Left" ForeColor="Blue" Font-Size="Small">
                        </RowStyle>--%>
                    </asp:GridView>
                </div>
            </div>
      

             <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="BtnAdd" runat="server" CssClass="btn btn-success" AutoPostBack="false"
                                TabIndex="43" OnClick="BtnAdd_Click" style=" margin-top: 10px; ">
                         <span class="glyphicon glyphicon-plus" style="color: White"> </span> Add
                            </asp:LinkButton>

                            <%--added by ajay sawant 19/4/2018--%>
                        <%--<asp:LinkButton ID="BtnCancel" runat="server" CssClass="btn btn-sample" OnClientClick="doCancel();return false;"> 
                          <span class="glyphicon glyphicon-remove" style="color: White"></span> Cancel

                            </asp:LinkButton> --%>
                        </div>
                        <br />
       

               <div id="trDgViewDtl" class="card" runat="server">

       <%-- <table style="border-collapse: separate; left: 0in; position: relative; top: 10px;
            margin-top: 0px;" class="formtable">
            <tr style="width: 100%" id="tr2" runat="server">
                <td class="style1">--%>
                   <%-- <asp:GridView Style="color: blue" ID="GridView1" runat="server" PagerStyle-HorizontalAlign="Center"
                        PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable"
                        HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width=100%
                         Visible="false" OnPageIndexChanging="GridView1_PageIndexChanging" 
                        onrowcommand="GridView1_RowCommand" onrowdatabound="GridView1_RowDataBound" >--%>
                  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" HorizontalAlign="Center"
                                AutoGenerateColumns="False" CssClass="footable" OnRowCommand="GridView1_RowCommand"
                                PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                                <FooterStyle CssClass="GridViewFooter" />
                                <HeaderStyle CssClass="gridview th" />
                                <RowStyle CssClass="GridViewRowNew" />
                                <PagerStyle CssClass="disablepage" />
                                <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>

                        
                      
                        <Columns>
                            <asp:BoundField DataField="RemarkDesc01" HeaderText="CFR Description" SortExpression="RemarkDesc01"
                                HeaderStyle-CssClass="col" HeaderStyle-Font-Size="13px" HeaderStyle-Height="10px">
                                 <ItemStyle CssClass="clsLeft"/>
                             <HeaderStyle CssClass="clsLeft" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CFRFor" HeaderText="CFR Raised for" SortExpression="CFRFor"
                                HeaderStyle-CssClass="col" HeaderStyle-Font-Size="13px" HeaderStyle-Height="10px">
                                <ItemStyle CssClass="clsLeft"/>
                             <HeaderStyle CssClass="clsLeft" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RemarkId" HeaderText="Remark" SortExpression="RemarkId"
                                HeaderStyle-CssClass="col" HeaderStyle-Font-Size="13px" HeaderStyle-Height="10px" >
                           <ItemStyle CssClass="clsLeft"/>
                             <HeaderStyle CssClass="clsLeft" />
                              </asp:BoundField>
                            <asp:TemplateField HeaderText="Action" >
                                <ItemTemplate>
                                   <i class="fa fa-trash-o"></i>
                                    <asp:LinkButton ID="DeleteBtn" Text="Delete" CommandName="Delete_Product" runat="server" ForeColor="Red" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                <ControlStyle Font-Underline="True" />
                                <FooterStyle Font-Underline="False" />
                                <HeaderStyle CssClass="col" />
                              <HeaderStyle CssClass="clsLeft" />
                            </asp:TemplateField>
                        </Columns>
                       
                      
                    </asp:GridView>
               <%-- </td>
                </tr>
                </table>--%>
                   </div>





             
          

             <br/>

                <div id="Div3" runat="server">
                              <table>
                            <tr>
                                   <td>   <asp:Label ID="lblremark" runat="server" Text="Final Remark:" CssClass="control-label"
                                        ForeColor="#00cccc"></asp:Label>

                                   </td>
                                   <td>
                                         <asp:TextBox ID="txtRemrk" runat="server"  TextMode="multiline"  CssClass="form-control" style=" margin-left: 11px; width: 427px; "></asp:TextBox>
                                   </td>
                                   <td> 
                                                  <asp:LinkButton ID="BtnSubmit" runat="server" style=" margin-left: 17px;" 
                            CssClass="btn btn-success" OnClick="BtnSubmit_Click">
                            SUBMIT
                        </asp:LinkButton>

                                       
                                   </td>
                            </tr>
                        </table>

                         
                        </div>
      
    </div>
         </div>
    </form>
</body>
</html>

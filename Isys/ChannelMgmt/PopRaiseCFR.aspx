<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopRaiseCFR.aspx.cs" Inherits="Application_INSC_Recruit_PopRaiseCFR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--<link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />--%>
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

 
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
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
        function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
            var objnewbtn = document.getElementById(btnName);

            if (objnewdiv.style.display == "block") {
                objnewdiv.style.display = "none";
                //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
            }
            else {
                objnewdiv.style.display = "block";
                // objnewbtn.className = 'glyphicon glyphicon-collapse-down'
            }
        }
        $(function () {
            debugger;
            $('#<%=dgDetails.ClientID %>').footable({
                breakpoints: {

                    phone: 300,
                    tablet: 1000
                }
            });
        });

       

    </script>
    <style type="text/css">
        .disablepage {
            display: none;
        }

        .clscenter{
            text-align:center !important;
        }
        /*.gridview th {
    padding: 3px;
      background-color: #d6d6c2;*/
        }
    </style>
    <%--<style type="text/css">
        .style1
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
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      <%--  <div class="container" style="overflow: auto;">--%>
            <%--  <div>--%>
           
                <div class="card" id="divAlert" runat="server" style="width: 100%; display: block; border-radius: 2px; background-color: white; margin-top: 20px; margin-left: 1px"
                    cellpadding="0" cellspacing="0">

                    <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Visible="False" Width="310px"></asp:Label>
                   
                    <%--       <table class="tableIsys">--%>            <%--<tr>
                <td align="center" class="test" colspan="6" style="width: 30">
                    <asp:Label ID="Label2" runat="server" Text="Raise CFR" CssClass="standardlink "></asp:Label>
                </td>
            </tr>--%>
                    <div id="TrEmpSearch" runat="server" class="panel-body">
                        <div class="row">
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" Text="Document Type" CssClass="control-label" 
                                    ForeColor="DarkBlue"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="DdlDoctype1" runat="server" AutoPostBack="True" CssClass="form-control form-select" style="font-size: 14px;"
                                    OnSelectedIndexChanged="DdlDoctype1_SelectedIndexChanged">
                                </asp:DropDownList>

                                	 
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Label ID="lblcfrraised" runat="server" Text="Raised CFR:" CssClass="control-label"></asp:Label>&nbsp;
                <asp:Label ID="lblcfrraisedcount" runat="server" CssClass="control-label" Style="color: Red;"></asp:Label>
                                &nbsp;&nbsp;
                <asp:Label ID="lblrespond" runat="server" Text="Responded CFR:" CssClass="control-label"></asp:Label>&nbsp;
                <asp:Label ID="lblcfrrespondcount" runat="server" CssClass="control-label" Style="color: Orange;"></asp:Label>
                                &nbsp;&nbsp;
                <asp:Label ID="lblclosed" runat="server" Text="Closed CFR:" CssClass="control-label"></asp:Label>&nbsp;
                <asp:Label ID="lblcfrclosed" runat="server" CssClass="control-label" Style="color: Green;"></asp:Label>
                            </div>
                        </div>
                        <br />
                        <%--  <table style="border-collapse: separate; left: 0in; position: relative; top: 8px;"

            class="formtable">
            <tr style="width: 100%" id="trDgDetails" runat="server">
                <td>--%>
                        <div id="trDgDetails" class="footable" runat="server">
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
                                <%-- <asp:GridView Style="color: blue" ID="dgDetails" runat="server" PagerStyle-HorizontalAlign="Center"
                        PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable"
                        HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" 
                        OnRowDataBound="dgDetails_RowDataBound" OnRowUpdating="dgDetails_RowUpdating"
                        Width="100%" OnPageIndexChanging="dgDetails_PageIndexChanging" OnRowCommand="dgDetails_RowCommand" 
                        PageSize="10">--%>
                                <asp:GridView ID="dgDetails" runat="server" AllowPaging="True" HorizontalAlign="Center" Style="border-bottom-color: black;"
                                    AutoGenerateColumns="False" CssClass="footable" OnRowCommand="dgDetails_RowCommand"
                                    PageSize="10" OnPageIndexChanging="dgDetails_PageIndexChanging" OnRowDataBound="dgDetails_RowDataBound">
                                    <FooterStyle CssClass="GridViewFooter" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <RowStyle CssClass="GridViewRowNew" />
                                    <PagerStyle CssClass="disablepage" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                    <%--      <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>--%>
                                    <Columns>
                                        <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="False" />
                                        <asp:TemplateField ItemStyle-Width="6%">
                                            <ItemTemplate>
                                                <i class="fa fa-flash"></i>
                                                <asp:CheckBox ID="ChkRaise" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="False"></HeaderStyle>
                                            <%--CssClass="test"--%>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="CFRDesc" HeaderText="CFR Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRDesc") %>'></asp:Label>
                                                <%--<asp:TextBox ID="TxtRemark" runat="server" Text='<%# Eval("CFRDesc") %>' Visible="false"
                                        CssClass="standardtextbox" Width="300px"></asp:TextBox>--%>
                                                <asp:HiddenField ID="hdnDocCode" runat="server" Value='<%# Eval("DocCode") %>'></asp:HiddenField>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="pad" />
                                            <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Additional Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="LblAddRemark" runat="server" Text='<%# Eval("CFRRemark")%>'></asp:Label>
                                                <%--Text='<%# Eval("CFRDesc") %>'--%>
                                                <asp:TextBox ID="TxtAddRemark" runat="server" MaxLength="200"
                                                    CssClass="form-control" Text='<%# Eval("CFRRemark")%>'></asp:TextBox>
                                                <%--Text='<%# Eval("CFRDesc") %>'--%>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="pad" />
                                            <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblRemarkid" runat="server" Visible="false" Text='<%# Eval("RemarkId") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnRemarkid" runat="server" Value='<%# Eval("RemarkId") %>'></asp:HiddenField>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>
                            </div>
                        </div>
                        <%--<asp:TextBox ID="TxtRemark" runat="server" Text='<%# Eval("CFRDesc") %>' Visible="false"
                                        CssClass="standardtextbox" Width="300px"></asp:TextBox>--%>
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
                        <%--  <table style="border-collapse: separate; left: 0in; position: relative; top: 10px;
            margin-top: 0px;" class="formtable">
            <tr style="width: 100%" id="tr2" runat="server">
                <td class="style1">--%>
                        <div id="trDgViewDtl" class="card" runat="server">
                            <%--   <asp:GridView Style="color: blue" ID="GridView1" runat="server" PagerStyle-HorizontalAlign="Center"
                        PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable"
                        HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width=100%
                         Visible="false" OnPageIndexChanging="GridView1_PageIndexChanging" 
                        onrowcommand="GridView1_RowCommand" onrowdatabound="GridView1_RowDataBound" 
                        onrowdeleting="GridView1_RowDeleting" >--%>
                            <asp:GridView Style="color: blue" ID="GridView1" runat="server" PagerStyle-HorizontalAlign="Center"
                        PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable"
                        HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width=100%
                         Visible="false" OnPageIndexChanging="GridView1_PageIndexChanging" 
                        onrowcommand="GridView1_RowCommand" onrowdatabound="GridView1_RowDataBound" >
                                <FooterStyle CssClass="GridViewFooter" />
                                <HeaderStyle CssClass="gridview th" />
                                <RowStyle CssClass="GridViewRowNew" />
                                <PagerStyle CssClass="disablepage" />
                                <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>

                                <Columns>
                                    <asp:TemplateField SortExpression="RemarkDesc01" HeaderText="CFR Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarkDesc01" runat="server" Text='<%# Eval("RemarkDesc01") %>' ></asp:Label>
                                            </ItemTemplate>
                                           <%-- <HeaderStyle CssClass="test" Font-Size="Smaller" />--%>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                   

                                    <asp:TemplateField SortExpression="CFRFor" HeaderText="CFRFor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCFRFor" runat="server" Text='<%# Eval("CFRFor") %>' ></asp:Label>
                                            </ItemTemplate>
                                      
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                 
                                                      
                                    <asp:BoundField DataField="RemarkId" HeaderText="Remark"  SortExpression="RemarkId"
                                         HeaderStyle-Height="10px" />
                                    
                                     <asp:TemplateField SortExpression="RemarkId" HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddnlRemark" runat="server" Text='<%# Eval("AddnlRemark") %>' ></asp:Label>
                                            </ItemTemplate>
                                      
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                        </asp:TemplateField>
                                      <%-- <asp:BoundField DataField="AddnlRemark" HeaderText="Action"  SortExpression="RemarkId"
                                       HeaderStyle-Height="10px" />--%>
                                    <asp:TemplateField ShowHeader="false" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="DeleteBtn" Text="" CommandName="Delete" runat="server" ForeColor="Red"> <i class="glyphicon glyphicon-trash" style="color:red;">  </i>  </asp:LinkButton>
                                          
                                             <%-- <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("RemarkId") %>'></asp:HiddenField>--%>
                                        </ItemTemplate>
                                          <ItemStyle CssClass="clscenter"/>
                                      
                                        <ControlStyle Font-Underline="True" />
                                        <FooterStyle Font-Underline="False" />
                                      
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </div>
                        <%-- </td>
                </tr>
                </table--%>
                     

                     
                         


                        <div id="tr_title" runat="server" visible="true">
                            <div align="center" colspan="4" style="width: 30;">
                                <%--class="test"--%>
                                <asp:Label ID="lbltitle" Visible="true" runat="server" CssClass="standardlink"></asp:Label>
                            </div>
                        </div>

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


                    <div class="col-sm-12" align="center">
                      
                      
                    </div>
                    <br />

                </div>

      
           
     
    <%--    </div>--%>

    </form>
</body>
</html>

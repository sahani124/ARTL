<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetunitCodePopUp.aspx.cs" Inherits="INSCL.GetunitCodePopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Unit Search</title>
   
   <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js"
        type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />
    <%-- <script src="assets/KMI%20Styles/Bootstrap/datepicker/datetimepicker.js" type="text/javascript"></script>
    <script src="assets/jqueryCalendar/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>--%>
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../assets/KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
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
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
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
    <script language="javascript" type="text/javascript">

      
      

//    <script language="javascript" type="text/javascript">

    function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    //objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        function doSelect(args1, args2, args3)
        {
           // window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').innerText = doEncodeToParent(args3);
            window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').value = doEncodeToParent(args1);
            window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').focus();
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            return false;
        }

        function doClear()
        {
            document.getElementById("<%=txtUnitCode.ClientID%>").value = "";
            document.getElementById("<%=txtUnitName.ClientID%>").value = "";
        }

        function doCancel()
        {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();


        }

        </script>
   

    
     <style type="text/css">
     
        /*ul#menu
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
        }*/
           .hidscroll {
            margin-left: 0px !important;
            margin-right: 0px !important;
            margin-top: 0px !important;
            margin-bottom: 0px !important;
            border-color: #d6e9c6 !important;
        }
    </style>
  
</head>

  
<body>
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

            

                     <div class="panel " style='margin-top:15px;'>
                <div id="divcmphdrcollapse" runat="server" class="panel-heading"  onclick="ShowReqDtl1('Div2','btnpersnl');return false;">           
                          <div class="row">
                    <div class="col-xs-10" style="text-align:left" >
                        <span style="color: #034ea2; font-size:19px">Unit Code Search</span>
                    </div>
                    <div class="col-xs-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>    


                 <div id="Div2" runat="server" style="display: block;" class="panel-body">
           
                      <div class="col-sm-3" style="text-align:left; margin-bottom: 5px">
                            <asp:Label ID="lblSalesChannel"  CssClass="control-label"  runat="server" ></asp:Label>
                            </div>
                      <div class="col-sm-3" style="margin-bottom:5px;">
                            <asp:DropDownList ID="ddlSlsChannel" runat="server"  CssClass="form-control">
                            </asp:DropDownList>
                            </div>
                    <div class="col-sm-3" style="text-align:left; margin-bottom: 5px">
                            <asp:Label ID="lblUntCode"  CssClass="control-label"  runat="server"></asp:Label>
                            </div>
                          <div class="col-sm-3" style="margin-bottom:5px;">
                            <asp:TextBox ID="txtUnitCode" runat="server" MaxLength="5" CssClass="form-control"></asp:TextBox>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender101" runat="server" InvalidChars=",#$@%^!*()& ''%^~`abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                                  FilterMode="InvalidChars" TargetControlID="txtUnitCode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                           </div>
                                
                               <div class="col-sm-3" style="text-align:left; margin-bottom: 5px">                                
                            <asp:Label ID="lblUntName" CssClass="control-label"  runat="server" ></asp:Label>
                            </div>
                      
                      <div class="col-sm-3" style="margin-bottom:5px;">        
                            <asp:TextBox ID="txtUnitName" runat="server" CssClass="form-control"></asp:TextBox>
                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_GivenName" runat="server"
                                                             FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtUnitName" ValidChars=" " FilterMode="ValidChars">
                    </ajaxToolkit:FilteredTextBoxExtender>
                    </div>

                   
                    
                   
                    <div class="row" style="margin-top:12px;">
                    <div class="col-sm-12" align="center">
       
                         <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" CausesValidation="false"
                                 Text="SEARCH"  OnClick="btnSearch_Click"   OnClientClick="javascript:validate();"  >
                         <span class="glyphicon glyphicon-search" style='color:White;'></span> Search
                        </asp:LinkButton>  
               
                       <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample" CausesValidation="False" OnClientClick="doCancel();return false;"
                               OnClick="btnClear_Click">
                              <span class="glyphicon glyphicon-erase BtnGlyphicon"> </span> Clear
                             </asp:LinkButton> 

                               <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sample" OnClientClick="doCancel();return false;">
                             <span class="glyphicon glyphicon-remove" style="color:white"> </span> Cancel </asp:LinkButton>

                             </div>

                             </div>

                            <br />

                      <div id="demo" style="display:block;overflow-x: scroll;" runat="server" class="panel">  
                <div id="div1" runat="server" class="panel-heading"  onclick="ShowReqDtl1('trDgDetails','Span1');return false;" style="margin: 0px;">           
                          <div class="row">
                    <div class="col-xs-10" style="text-align:left">
                        <span style="color:#034ea2;font-size:19px">Unit Details</span>
                    </div>
                    <div class="col-xs-2">
                        <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>


                  <div id="trDgDetails" runat="server" style="display: block;margin-top: 10px;width: 100%">
                
                            <asp:GridView ID="dgDetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="footable"
                                AllowSorting="true"  RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue"
                                PageSize="8" PagerStyle-Font-Underline="true" PagerStyle-HorizontalAlign="Center" OnSorting="dgDetails_Sorting" 
                                OnPageIndexChanging="dgDetails_PageIndexChanging" OnRowDataBound="dgDetails_RowDataBound">
                                 <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                 <asp:TemplateField HeaderText="Ins Unit Code" HeaderStyle-HorizontalAlign ="Center"  SortExpression="CompUntCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lnkCompUnitCode"  runat="server" Text='<%# Bind("CompUntCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Code" HeaderStyle-HorizontalAlign ="Center"  SortExpression="UnitCode">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkUnitCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Unit Name" DataField="UnitLegalName"  HeaderStyle-HorizontalAlign ="Center" SortExpression="UnitTypeDesc">
                                      <ItemStyle Font-Bold="False" HorizontalAlign="Center" CssClass="padding_css"/>
                                          </asp:BoundField>
                                    <asp:BoundField HeaderText="Unit Type" DataField="UnitTypeDesc" HeaderStyle-HorizontalAlign ="Center" SortExpression="UnitTypeDesc"/>
                                    <asp:BoundField DataField="BizSrc" HeaderText="Channel" HeaderStyle-HorizontalAlign ="Center" SortExpression="BizSrc" />
                                    <asp:BoundField DataField="Chncls" HeaderText="Sub Class" HeaderStyle-HorizontalAlign ="Center" SortExpression="ChnCls" />
                                   <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                      <asp:HiddenField ID="HdnCompCode" Value='<%# Eval("CompUntCode") %>' runat="server" />
                                      </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                               
                            </asp:GridView>

                             </div> 
                              </div>   
                             

                            <div id="divPage"  style='margin-left:148px;display:none;' runat="server" class="pagination">
                        <center>
                            <%--<table>
                                <tr>
                                    <td style="white-space: nowrap;">--%>
                                      
                                                <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtPage" Style="width: 44px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                          
                                  <%--  </td>
                                </tr>
                            </table>--%>
                        </center>
                    </div>
                     <br />
                     <br />
                      <br />
                    
               
                
               
                        <asp:Label ID="lblMessage" Visible="False" style="text-align:center"  ForeColor="Red" runat="server"></asp:Label>
                           
                           
                   </div>
                  
                   </div>            
 
   
    </form>
</body>
</html>

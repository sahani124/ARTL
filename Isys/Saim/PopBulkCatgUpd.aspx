<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopBulkCatgUpd.aspx.cs" Inherits="Application_Isys_Saim_PopBulkCatgUpd" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <script type="text/javascript">
        function doCancel() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();


        }


        function funPopupUpload() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            alert("upload");
            $find("mdlPopBIDUpload").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "ImportExcel.aspx?";
            // document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "ImportExcel.aspx?CmpCode=" + cmpcode +
            // "&mdlpopup=mdlPopBIDUpload";
        }

    </script>
</head>
<body>


    <form id="form1" runat="server">
       
         <div class="container">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       

            
                    <div id="divHybridKPI" runat="server" style="width: 100%;" class="panel">
                        <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divprevdtls','myImg1');return false;">
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left; font-size: 19px;">
                                    <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                    <asp:Label ID="lblBlkUpdTrg" Text="Bulk Upload Target" runat="server" />
                                </div>
                                <div class="col-sm-2">
                                    <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 27/4/2018--%>
                                </div>
                            </div>
                        </div>

                        <div id="div2" runat="server" style="width: 94%;" class="panel-body" >
                               <div class="row">
                               <div class="col-sm-3" style="text-align: left; font-size: 19px;">
                                    
                                    <asp:Label ID="Label1" Text="Upload File" runat="server" />
                                </div>
                                <div class="col-sm-3" style="text-align: left; font-size: 19px;">

                                    <asp:FileUpload ID="FileUpload1" runat="server" ></asp:FileUpload> 
                               </div>
                               </div>
                            </div>
        
                        </div>

             <center>
                    <div class="dvbottom" style="text-align: center;">
                <asp:LinkButton ID="btn_Download" runat="server" CssClass="btn btn-sample" Text="Download Sample File"
                                                                    Visible="true"
                                                                    OnClick="btn_Download_Click"  />

        <asp:LinkButton ID="btn_Upload" runat="server" CssClass="btn btn-sample" Text="Upload"
                                                                    Visible="true" OnClick="btn_Upload_Click"
                                                                     />

            <asp:LinkButton ID="btnCncl" Text="Close" runat="server" CssClass="btn btn-sample"
                OnClick="btnCncl_Click">
                 <span class="glyphicon glyphicon-remove" style="color:White"></span> Close
            </asp:LinkButton>

           
        </div>

        </center>
             </div>


    </form>
</body>
</html>

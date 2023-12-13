<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="BlurImage.aspx.cs" Inherits="_CropImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />


    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <script src="../../../CropScript/js/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../CropScript/js/jquery.Jcrop.min.js" type="text/javascript"></script>
    <link href="../../../CropScript/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
  
    
    <script type="text/javascript">

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
       



        debugger;
        $(function() {                    
            $('#ImFullImage').Jcrop({
                onSelect: updateCoords,
                onChange: updateCoords
            });
        });
        function updateCoords(c) {
            $('#hfX').val(c.x);
            $('#hfY').val(c.y);
            $('#hfHeight').val(c.h);
            $('#hfWidth').val(c.w);
        }
    </script>
</head>
<body>
    <form id="form1"  runat="server"  style="width:100%">



                   <div class="card">
                <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearchDetails','btndivSearchDetails');return false;">           
                          
                        </div>
                       
                             <div id="trInsuranceid1" runat="server" class="panel-body" style="display:block">
                            
                                <div class="row" style="margin-left: 3%; margin-right: 3%; margin-bottom: 5px">
                                  <div class="col-sm-3" style="text-align:left; top: 0px; left: 0px;">
                              
                                    <asp:Label ID="lbldocType" Text="Document Type" runat="server" CssClass="control-label"  Font-Bold="False"></asp:Label>
                              
                                </div>
                              
                               <div class="col-sm-8" style="text-align:left">
                                    <asp:DropDownList ID="ddlDocType" DataTextField="ParamDesc" DataValueField="ParamValue"
                                        runat="server"  CssClass="form-control" AutoPostBack="true" TabIndex="11"
                                        OnSelectedIndexChanged="ddldocType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                </div>
                          
                                 </div>
                              <div class="row" style="margin-top:12px;" id="divButtons" runat="server">
           
                      <div class="col-sm-12" align="center">
                          
                               
           <%-- Original Image: <br />--%>
     <%--ImageUrl="~/Application/ISys/Recruit/UploadedFiles/30000027/30000027_11.JPG"--%>
                 <asp:Image ID="ImFullImage"  runat="server" /><br />
        <asp:LinkButton ID="btnCrop" runat="server" CssClass="btn btn-success" onclick="btnCrop_Click" >
          <span   class="glyphicon glyphicon-edit BtnGlyphicon" ></span> Blur Image
          </asp:LinkButton>
             <%--<asp:Button ID="btncancel"  runat="server" Text="Cancel" CssClass="standardbutton"
               OnClientClick="doCancel();return false;" />--%>
                 <%--<asp:LinkButton ID="btnCancel"  runat="server"  CssClass="btn btn-clear"  OnClientClick="doCancel();return false;"  >
                                    <span class="glyphicon glyphicon-remove" style="color:red"> </span> Cancel
                                    </asp:LinkButton>--%>
           </div>
    </div>
    <br />
   

     <div  runat="server" class="panel-body">
                    <div class="row" align="center">
                     <div class="col-md-3" >
   

        <asp:Image ID="imCropped" runat="server" />
        </div>
        </div>
                          <div class="row" style="margin-top:5px;" align="center">
                       <div id="trcrop" runat ="server">
                    <%--  <tr  id="trcrop" runat ="server" >--%>
                              <%--  <td colspan="4" align="center" style="height: 20px;">--%>
                               <%--  <asp:LinkButton ID="btnok" runat="server" Text="OK" 
                                   onclick="btnok_Click"  />--%> <%--OnClientClick="doCancel();return false;" --%> 
                                   <asp:LinkButton ID="btnok" runat="server"  CssClass="btn btn-success"
                              OnClick="btnok_Click" >
                                  <span class="glyphicon glyphicon-saved" style="color:White"> </span> Ok
                                  </asp:LinkButton>
                                   </div>
                                   </div>
                               

                                
    </div>
    </div>
                          
    <asp:HiddenField ID="hfX" runat="server" />
    <asp:HiddenField ID="hfY" runat="server" />
    <asp:HiddenField ID="hfHeight" runat="server" />
    <asp:HiddenField ID="hfWidth" runat="server" />
    <asp:HiddenField id="hdnCndNo" runat="server" />
  
    
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FPCropImage.aspx.cs" Inherits="Application_ISys_ChannelMgmt_FranchiesEnrollment_FPCropImage" %>

<!DOCTYPE html>

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
           <div class="row" style="margin-top:12px;" id="divButtons" runat="server">
               <div class="col-sm-12" align="center">
				   <asp:Image ID="ImFullImage"  runat="server" /><br />
				   <asp:LinkButton ID="btnCrop" runat="server" CssClass="btn btn-success" onclick="btnCrop_Click" style=" width: 100px;" >
					  <span   class="glyphicon glyphicon-edit" style="color:white" ></span> Crop
				   </asp:LinkButton>
				   <asp:LinkButton ID="btnCancel"  runat="server"  CssClass="btn btn-success" Visible="false"  OnClientClick="doCancel();return false;"  >
					  <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
				   </asp:LinkButton>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageUploadEncoda.aspx.cs" Inherits="CourierNew.AttchementCtr.ImageUploadEncoda" %>



<%@ Register Assembly="Enkode.Imaging" Namespace="Enkode.Imaging.WebControls" TagPrefix="cc1" %>
 

<!DOCTYPE html>

 

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
 
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
	<script src="../AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
 
</head>
<body>
	<script>
	    window.alert = function () { };

	    // or simply
	    alert = function () { };

	    function SetImage(imgName, imgFileCtrName) {
	        


	        window.parent.$("div").removeClass("modal-backdrop");
	        window.parent.LoadCropImageName(imgName, imgFileCtrName);
	    }
	</script>
    <form id="form1" runat="server">
    <div>
	 
        	<cc1:ImageUpload ID="imgup"  Height="300" RequiredHeight="300"  CssClass="bg-gradient-light"   DisplayResizeMessage="true" ConvertNonWebFormatsToJpeg="true"  OutputImageUrl="~/img/BlanckImage.png" OriginalImageUrl="~/img/BlanckImage.png"   runat="server" OnEditSubmit="Imgup_EditSubmit" />
    </div>
		<asp:HiddenField ID="hdFIleName" ClientIDMode="Static" runat="server" />
        <asp:TextBox runat="server" style="display:none" ID="txtFile1" ></asp:TextBox>
    <asp:TextBox runat="server"  style="display:none"  ID="txtFile2" ></asp:TextBox>
    </form>

</body>
</html>

 
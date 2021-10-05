<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUpLoad.ascx.cs" Inherits="CourierNew.UserControl.FileUpLoad" %>
<script type="text/javascript">

    </script>
          <script  type="text/javascript">
         var prefix = 'CPH_';
          	//function SetText() {

          	//	var filename = document.getElementById(prefix + 'FileUpLoad1_filUpload');

          	//	var txtFileName = document.getElementById(prefix + 'FileUpLoad1_txtFileName');
          	//	txtFileName.value = filename.value;
          	//	var message = '';
          	//	if (filename.value =='') {
          			 
          	//			message += "<li>User cant upload image without selecting image.</li>";
          			 
          	//	}
          	//	if (message != '') {
          	//		$("#divError").removeClass('hide');
          	//		$("#dvMsg").html(message);
          	//		$('html, body').animate({ scrollTop: 0 }, 'slow');
          	//		$("#divError").show();
          	//		$("#txtCategoryValue").focus();
          	//		setTimeout(function () { $("#divError").fadeOut(1500); }, 5000);
          	//		return false;
          	//	}	
          	//	else {
          	//		$("#divError").addClass('hide');
          	//		$("#dvMsg").html("");
          	//		return true;
          	//	}
          	//}


</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
    <ContentTemplate>

        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <div  data-toggle="modal"  runat="server" id="dvImgOpner">
            <asp:Image ID="imgFile" runat="server" ClientIDMode="Static"   Height="108px" ImageUrl="~/img/BlanckImage.png" style="cursor:zoom-out!important"
                Width="132px" CssClass="img img-responsive" /></div><br />
            <div class="box-body">
                <table class="row">
                    <tr>
                        <td>
                            <asp:FileUpload ID="filUpload" runat="server" CssClass="form-control" Font-Bold="False" Width="200px"  onchange="ShowpImagePreview(this);" />
                        </td>
                        <td>
                            <asp:Button ID="btnUpload" runat="server" CausesValidation="false" OnClick="btnUpload_Click"
                                OnClientClick="return SetText();" Text="Upload" CssClass="btn btn-success btn-sm" /></td>
                        <td>
                            <asp:Button ID="btnRemove" runat="server" Text="X" OnClick="btnRemove_Click" CssClass="btn btn-danger btn-sm" OnClientClick="if (confirm('Are you sure you want to remove selected image?') == false)  return false;" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="myModal" runat="server" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"       aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-body">
                          <%--  <img src="//placehold.it/1000x1000" class="img-responsive">--%>
                              <asp:Image ID="imgView" runat="server"    ImageUrl="~/img/BlanckImage.png"
                 CssClass="img-responsive" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:Label ID="lblFeedbackOK" runat="server" EnableViewState="false"></asp:Label>
            <asp:Label ID="lblFeedbackKO" runat="server" EnableViewState="false"></asp:Label>
            <asp:Label ID="lblFileName" runat="server" Visible="False"></asp:Label>
            <asp:TextBox runat="server" ID="txtFileName" Style="display: none"></asp:TextBox>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnUpload" />
    </Triggers>
</asp:UpdatePanel>

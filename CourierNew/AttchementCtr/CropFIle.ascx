<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CropFIle.ascx.cs" Inherits="CourierNew.AttchementCtr.CropFIle" %>
<script>
    var imgName = '';
    function OpenImage(img, ModelImageUpload) {
        $('#' + ModelImageUpload).modal('show');
        $('.iframpdf').show();
        $('#' + ModelImageUpload).show(1);
        imgName = img;
        return false;
    }
    function LoadCropImageName(imgeName, LoadCropImageName) {
        $('#' + imgName).attr('src', ".." + imgeName);
        $('#' + LoadCropImageName).val(".." + imgeName);


        $('.iframpdf').hide();
        $('.modal').hide();
    }

    function RemoveItem() {

        var ItemName = $('.cropdocno').val();
        bootbox.dialog({
            message: "<b class='text-red'>Are you sure want to delete " + ItemName + ".?</b>",
            title: "<b class='text-red'>Delete Item ? </b>",
            buttons: {
                success: {
                    label: "No",
                    className: "btn-success",
                    callback: function () {
                        console.log("User declined dialog");
                    }
                },
                danger: {
                    label: "Yes",
                    className: "btn-danger",
                    callback: function () {
                        $('#btnDeletePic').click();
                    }
                }
            }
        });
        return false;

    }

    function AskToRemoveImage(objImgName, objFileName)
    {
        $("#" + objImgName).attr('src', '../img/BlanckImage.png');
        $("#" + objFileName).val('');
        return false;
    }
    //function ValidateImage() {
    //    debugger
    //    var Message = '';
    //    var selectedVal = $(".ddlTYpe option:selected").val();
    //    if ($(".ItemName").val() == "") {
    //        Message += '<li> Please enter document no. </li>';
    //    }
    //    if (selectedVal == "-1") {
    //        Message += '<li> Please select document type. </li>';
    //    }
    //    if ($(".filename").val() == "" || $(".filename").val() == "") {
    //        Message += '<li> Please select correct file. </li>';
    //    }

    //    if (Message != '') {
    //        $("#divError").removeClass('hide');
    //        $("#dvMsg").html(Message);
    //        $('html, body').animate({ scrollTop: 0 }, 'slow');
    //        return false;
    //    }
    //    else {
    //        $("#divError").addClass('hide');
    //        $("#dvMsg").html("");
    //        return true;
    //    }
    //    return true;
    //}

</script>

<asp:Panel ID="Panel1" runat="server" Width="95%">
    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
    <div class="col-lg-12 form-group">

        <div class="col-7 row">

            <div class="row">
                <table>

                    <tr>

                        <td>
                            <asp:Button ID="btnOpnImg" runat="server" CssClass="btn btn-flat btn-success btn-sm" Text="Select Image" /></td>
                        <td>
 
                            <asp:Button ID="btnRemove"  runat="server" Text="Remove" CssClass="btn btn-danger btn-sm"  />
                        </td>
                        <td>
                            <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlTYpe" runat="server" AppendDataBoundItems="true" CssClass="form-control ddlTYpe">
                                <asp:ListItem Text="Select Type" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>


                        <td>
                            <asp:Label ID="lblNo" runat="server" Text="No"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtDocNo" placeholder="Image No" CssClass="from-control cropdocno" Width="150px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <div class="btn-group" id="dvGridBtn" runat="server">
                                <asp:Button ID="btnAddItem" CommandName="ADD" runat="server" CssClass="btn btn-success btn-xs" Text="ADD" Width="60px" OnClick="BtnAddItem_Click"  /><!--OnClick="btnAddItem_Click"-->
                                <asp:Button ID="btnResetItem" CommandName="CANCEL" Style="margin-left: 5px" runat="server" CssClass="btn btn-primary btn-xs" Text="CLEAR" Width="60px" OnClick="BtnAddItem_Click" /><!-- OnClick="btnResetItem_Click" -->
                                <asp:Button ID="btnItemDel" CommandName="DELETE" OnClientClick="return RemoveItem();" runat="server" Style="margin-left: 5px" CssClass="btn btn-danger btn-xs" Visible="false" Text="DELETE" Width="60px" /><!--OnClick="btnAddItem_Click"-->
                                <asp:HiddenField ID="hdPkey" runat="server" Value="0" />
                                <asp:HiddenField ID="hdIndex" runat="server" Value="0" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div data-toggle="modal" runat="server" id="dvPdfOpner" class="row">
                <asp:Image ID="imgFile" runat="server" ImageUrl="~/img/BlanckImage.png" Style="cursor: zoom-out!important"
                    CssClass="img-square" />
            </div>
        </div>
        <div class="col-5 row">
            <div style="max-height: 800px; overflow-y: auto">
                <asp:DataList ID="dlOrderDetail" GridLines="None" RepeatLayout="Table" OnItemDataBound="DlOrderDetail_ItemDataBound" OnItemCommand="DlOrderDetail_ItemCommand" CssClass="table-bordered table table-striped" ShowHeader="true" DataKeyField="AttachmentID" runat="server">
                    <HeaderTemplate>
                        <%-- OnItemCreated="dlTranDetail_ItemCreated"  OnItemDataBound="dlTranDetail_ItemDataBound" OnItemCommand="dlTranDetail_ItemCommand"--%>
                        <th style="width: 50px; text-align: center">Action</th>

                        <th style="width: 130px; text-align: center">Item Image</th>
                        <th style="width: 100px; text-align: center">Type</th>
                        <th style="width: 320px; text-align: center">Name</th>

                    </HeaderTemplate>
                    <ItemTemplate>
                        <td>
                            <asp:Button runat="server" ClientIDMode="Predictable" CommandName="EDIT" CssClass="btn btn-success btn-xs btn-flat" ID="btnEdit" Text="Edit" />

                        <td>
                            <asp:Image runat="server" Height="103" Width="120" ID="imgAttach" ImageUrl='<%# Eval("AttachemntImagePath") %>' />
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblAttName" CssClass="text-right" Text='<%# Eval("AttachemntName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblAttNo" CssClass="text-right" Text='<%# Eval("AttachemntNo") %>'></asp:Label>
                        </td>

                        <asp:HiddenField ID="hdItemFkey" Value='<%# Eval("AttachmentID") %>' runat="server" />
                        <asp:HiddenField runat="server" ID="hdIndex" Value='<%# Eval("Index") %>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>

    </div>
    <div id="myModal" runat="server" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"    aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <%--  <img src="//placehold.it/1000x1000" class="img-responsive">--%>
                    <asp:Image ID="imgView" runat="server" ImageUrl="~/img/BlanckImage.png"
                        CssClass="img-responsive" />
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblFeedbackOK" runat="server" EnableViewState="false"></asp:Label>
    <asp:Label ID="lblFeedbackKO" runat="server" EnableViewState="false"></asp:Label>
    <asp:Label ID="lblFileName" runat="server" Visible="False"></asp:Label>
    <asp:TextBox runat="server" ID="txtFileName" Style="display: none" CssClass="filename"></asp:TextBox>
    <!-------------------------MODEL FOR Image Upload----------------------------------->
    <div id="ModelImageUpload" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"      aria-hidden="true" runat="server">
        <div class="modal-dialog">
            <div class="modal-content" style="height: 1000px; width: 1250px; margin-left: -73%; overflow: hidden">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>

                </div>
                <div class="modal-body" style="height: 980px; overflow: hidden">
                    <iframe style="width: 100%; height: 100%; border: none" id="iframpdf" class="iframpdf" runat="server"></iframe>

                </div>

            </div>
        </div>

    </div>
    <!--------------------------------END----------------------------------------------------->
    <asp:Button runat="server" CommandName="Delete" ClientIDMode="Static" CssClass="hidden" Width="0" ID="btnDeletePic" OnClick="BtnDeletePic_Click1" />
</asp:Panel>

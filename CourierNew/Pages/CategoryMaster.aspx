<%@ Page Title="Category Entry" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="CategoryMaster.aspx.cs" Inherits="CourierNew.Pages.CategoryMaster" %>

<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">

  <span class="hidden">

        SQL_Save  :  CategoryMasterSAVE
        SQL_Get   :  CategoryMasterGET 
        SQL_Search:  CategoryMasterSearch 
    </span>

    <script src="Js/CategoryMasterEntry.js?ver=2"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Category Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '470px';
            }

            //  window.parent.$("#MainModel").addClass ('modal-xl');
        }
    </script>
    <!------------------Step 2 Page Design------->
    <section class="content">
        <div class="container-fluid">
            <div class=" row form-group">
                <!-- form start -->
                <div class="col-lg-3">

                    <div class="form-group">
                        <label>Category Type</label>
                        <asp:DropDownList ID="ddlCategoryName" runat="server" CssClass="form-control form-control-solid form-control-lg ddlCategoryName " AppendDataBoundItems="true">
                        </asp:DropDownList>
               
                    </div>
                    <div class="form-group">
                        <label>Category Name</label>
                        <asp:TextBox ID="txtCatVal" runat="server" CssClass="form-control form-control-solid form-control-lg txtCatVal " placeholder="Category Name"></asp:TextBox>
                      
                    </div>
                    <div class="form-group">
                        <label>Description</label>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-solid form-control-lg txtDescription" TextMode="MultiLine" placeholder="Description"></asp:TextBox>
                       
                    </div>
                    <div class="form-group">

                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlStatus" runat="server">
                            <asp:ListItem Value="True" Selected="True">Active</asp:ListItem>
                            <asp:ListItem Value="False">In Active</asp:ListItem>
                        </asp:DropDownList>
                  
                    </div>
                </div>
                


        </div>
            <div class="card-footer text-center">

                    <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="CategoryMaster" />

                </div>
    </div>

    </section>

</asp:Content>


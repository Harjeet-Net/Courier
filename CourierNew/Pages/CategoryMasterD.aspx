<%@ Page Title="Category Duplicate Entry" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="CategoryMasterD.aspx.cs" Inherits="CourierNew.Pages.CategoryMasterD" %>

<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">
    <span></span>
    <script src="Js/CategoryMasterDEntry.js"></script>
    <section>
        <div class="container-fluid">
            <div class="row form-group">
                <div class="col-lg-3">
                    <div class="form-group">
                        <label>Category Type</label>
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control form-control-solid form-control-lg ddlCategory" AppendDataBoundItems="true">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Category Name</label>
                        <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control form-control-solid form-control-lg txtCategoryName" placeholder="Cateory Name">
                        </asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Descriptions</label>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-solid form-control-lg txtDescription" TextMode="MultiLine" placeholder="Descriptions">
                        </asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-control-solid form-control-lg ddlStatus">
                            <asp:ListItem Selected="True" Value="True">Active</asp:ListItem>
                            <asp:ListItem Value="False">In Active</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
            </div>
            <div class="footer text-center">            
                <TopButton:Buttons ID="btntop" runat="server" VisibleSave="true" VisibleCancel="true" OnMasterEve="btntop_MasterEve" />
               
            </div>
        </div>


    </section>


</asp:Content>

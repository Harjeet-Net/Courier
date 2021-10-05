<%@ Page Title="TemplateMaster" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="TemplateMaster.aspx.cs" Inherits="CourierNew.Pages.TemplateMaster" %>

<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">

    <span class="hidden">
        SQL_Save: TemplateMasterSave
        SQL_Get:  TemplateMasterGet
        SQL_Search:  TemplateMasterSearch
    </span>

    <script src="Js/TemplateMasterEntry.js"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Template Entry');
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
                <div class=" col-lg-3">

                     <div class="form-group">
                        <label>Template Name</label>
                        <asp:TextBox ID="txtTemplateName" runat="server" CssClass="form-control form-control-solid form-control-lg txtTemplateName " placeholder="Template Name"></asp:TextBox>
                       
                    </div>
                    <div class="form-group">
                        <label>Template Type</label>
                        <asp:DropDownList ID="ddlTemplateType" runat="server" CssClass="form-control form-control-solid form-control-lg ddlTemplateType" AppendDataBoundItems="true">
                            <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>
                            <asp:ListItem Value="SMS">SMS</asp:ListItem>
                             <asp:ListItem Value="Mail">Mail</asp:ListItem>
                            <asp:ListItem Value="WhatsApp">WhatsApp</asp:ListItem>
                        </asp:DropDownList>
                       
                    </div> 
                     <div class="form-group">
                        <label>Category Type</label>
                        <asp:DropDownList ID="ddlCategoryKey" runat="server" CssClass="form-control form-control-solid form-control-lg ddlCategoryKey" AppendDataBoundItems="true">
                        </asp:DropDownList>
                    
                    </div>  
                     <div class="form-group">
                        <label>Description</label>
                        <asp:TextBox ID="txtDescriptions" runat="server" CssClass="form-control form-control-solid form-control-lg txtDescriptions " TextMode="MultiLine" placeholder="Enter Description Here"></asp:TextBox>                      
                    </div>
                    
                   
                    <div class="form-group">

                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg" runat="server">
                            <asp:ListItem Value="True" Selected="True">Active</asp:ListItem>
                            <asp:ListItem Value="False">In Active</asp:ListItem>
                        </asp:DropDownList>
                       
                    </div>
                </div>
                


        </div>
            <div class="card-footer text-center">

                    <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="TemplateMaster" />

                </div>
    </div>

    </section>

</asp:Content>


<%@ Page Title="RefTable " Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="RefTable.aspx.cs" Inherits="CourierNew.Pages.RefTable" %>
<%@ Register Src="~/AttchementCtr/CropFIle.ascx" TagPrefix="CropFIle" TagName="CropFIle" %>
<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">
       <span class="hidden">
        SQL_Save:   RefTableSAVE
        SQL_Get:    RefTableGET 
        SQL_Search: RefTableSearch
    </span>
    <script src="Js/RefTableEntry.js?ver=2"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
    <div class="add-btn btntop card fixed-top p-1 text-right">
        <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="RefTable"  />

    </div>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Ref Table Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.minHeight = '350px';

                iframe.style.maxHeight = '700px';
            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }

    </script>
    <!------------------Step 2 Page Design------->
    <section class="content" style="margin-top: 44px;">
        <div class="container-fluid">
            <div class="row form-group">

                <div class="row col-lg-12">
                    <div class="form-group col-lg-4">
                        <label>Module Name</label>
                        <asp:DropDownList ID="ddlREFTYPE" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlREFTYPE">
                            <asp:ListItem Value="-1">Select One</asp:ListItem>
                           <asp:ListItem Value="Food">Food</asp:ListItem>
                           
                        </asp:DropDownList>
                    </div>

                    <div class="form-group col-lg-4">
                        <label>Category Name</label>
                        <asp:DropDownList ID="ddlREFSUBTYPE" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlREFSUBTYPE">
                            <asp:ListItem Value="-1">Select One</asp:ListItem>
                            <asp:ListItem Value="OpportunityLoss">Opportunity Loss</asp:ListItem>
                            <asp:ListItem Value="CampaignType">Campaign Type</asp:ListItem>
                            <asp:ListItem Value="Lead">Lead</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group col-lg-4">
                        <label>Short Name</label>
                        <asp:TextBox ID="txtSHORTNAME" runat="server" CssClass="form-control form-control-solid form-control-lg  txtSHORTNAME " placeholder=" Short Name"></asp:TextBox>
                    </div>
                </div>

                <div class="row col-lg-12">
                    <div class="form-group col-lg-4">
                        <label>Name 1</label>
                        <asp:TextBox ID="txtREFNAME1" runat="server" CssClass="form-control form-control-solid form-control-lg  txtREFNAME1 " placeholder=" Name 1"></asp:TextBox>
                    </div>                  
                    <div class="form-group col-lg-4">
                        <label>Name 2</label>
                        <asp:TextBox ID="txtREFNAME2" runat="server" CssClass="form-control form-control-solid form-control-lg  txtREFNAME2 " placeholder="Name 2"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-4">
                        <label>Name 3</label>
                        <asp:TextBox ID="txtREFNAME3" runat="server" CssClass="form-control form-control-solid form-control-lg  txtREFNAME3 " placeholder="Name 3"></asp:TextBox>
                    </div>
                </div>

                <div class="row col-lg-12">
                     <div class="form-group col-lg-4">
                        <label>Switch 1</label>
                        <asp:TextBox ID="txtSWITCH1" runat="server" CssClass="form-control form-control-solid form-control-lg  txtSWITCH1 " placeholder=" Switch 1"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-4">
                        <label>Switch 2</label>
                        <asp:TextBox ID="txtSWITCH2" runat="server" CssClass="form-control form-control-solid form-control-lg  txtSWITCH2 " placeholder="Switch 2"></asp:TextBox>
                    </div>                  
                    <div class="form-group col-lg-4">
                        <label>Switch 3</label>
                        <asp:TextBox ID="txtSWITCH3" runat="server" CssClass="form-control form-control-solid form-control-lg  txtSWITCH3 " placeholder="Switch 3"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>




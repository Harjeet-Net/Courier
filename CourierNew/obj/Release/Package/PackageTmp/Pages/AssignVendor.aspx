<%@ Page Title="Assign Vendor" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="AssignVendor.aspx.cs" Inherits="CourierNew.Pages.AssignVendor" %>

<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">

    <span class="hidden">SQL_Save  :  AirWayMainVendorUpdate
       
    </span>

    <script src="Js/AssignVendorEntry.js?ver=2"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Assign Vendor');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '300px';
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

                        <label>Vendor Name</label>
                        <asp:DropDownList ID="ddlVendorName" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlVendorName"  runat="server">
                            <asp:ListItem Value="-1" Selected="False">Select</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>



            </div>
            <div class="card-footer text-center">

                <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="AssignVendor" />

            </div>
        </div>
        <div class="hidden">
            <label>Air Way Bill Key</label>
            <asp:TextBox runat="server" class="form-control form-control-solid form-control-lg txtAirWayKey" ID="txtAirWayKey" placeholder="0"></asp:TextBox>

        </div>
    </section>

</asp:Content>


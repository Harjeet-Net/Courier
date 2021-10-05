<%@ Page Title="Assign Driver" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="AssignDriver.aspx.cs" Inherits="CourierNew.Pages.AssignDriver" %>

<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">

  <span class="hidden">
        SQL_Save  :  AirWayMainDriverUpdate      
    </span>

    <script src="Js/AssignDriverEntry.js?ver=2"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Assign Driver');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '320px';
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

                        <label>Driver Name</label>
                        <asp:DropDownList ID="ddlDriverName" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlDriverName" runat="server">
                            <asp:ListItem Value="-1" Selected="False">Select</asp:ListItem>                         
                        </asp:DropDownList>                     
                    </div>
                     <div class="form-group">

                        <label>Vehicle</label>
                        <asp:DropDownList ID="ddlVehicleKey" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlVehicleKey" runat="server">
                            <asp:ListItem Value="-1" Selected="False">Select</asp:ListItem>                         
                        </asp:DropDownList>                     
                    </div>
                </div>
                


        </div>
            <div class="card-footer text-center">

                    <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="AssignDriver" />

                </div>
            <div class="hidden">
              <label>Air Way Bill Key</label>
                  <asp:TextBox runat="server" class="form-control form-control-solid form-control-lg txtAirWayKey"  ID="txtAirWayKey" placeholder="0"></asp:TextBox>
          
    </div>
    </div>

    </section>

</asp:Content>


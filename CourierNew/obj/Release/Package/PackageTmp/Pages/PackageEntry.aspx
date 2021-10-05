<%@ Page Title="Packing List Entry" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="PackageEntry.aspx.cs" Inherits="CourierNew.Pages.PackageEntry" %>

<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">

    <span class="hidden">
        SQL_Save  :  AirWayMain2PackingSAVE
        SQL_Get   :  AirWayMain2PackingGET
        SQL_Get   :  AirWayMain2PackingSEARCH
     
    </span>

    <script src="Js/PackageEntry.js?ver=2"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Packing List Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '120px';
            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }
    </script>
    <!------------------Step 2 Page Design------->
     
    <section class="content">
        <div class="container-fluid">
            <div class=" row form-group">
                <!-- form start -->
                  <div class=" bg-white row col-lg-12">
                    <div class="col-lg-3">
                        <label>Packaging</label>
                        <asp:DropDownList ID="ddlPackingKey" runat="server" CssClass="form-control form-control-solid form-control-lg  ddlPackingKey" AppendDataBoundItems="true">
                            <asp:ListItem Selected="True" Text="Select Packaging" Value="-1"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <div class="col-lg-1">
                        <label>Quantity</label>
                        <asp:TextBox ID="txtQty" runat="server" CssClass="form-control form-control-solid form-control-lg  numeric txtQty" placeholder="Qty"></asp:TextBox>

                    </div>
                    <div class="col-lg-1">
                        <label>Weight</label>
                        <asp:TextBox ID="txtWeight" runat="server" CssClass="form-control form-control-solid form-control-lg  float txtWeight" placeholder="Weight"></asp:TextBox>
                    </div>
                    <div class="col-lg-1">
                        <label>UOM</label>
                        <asp:DropDownList ID="ddlUOM" runat="server" CssClass="form-control form-control-solid form-control-lg ddlUOM" AppendDataBoundItems="true">
                            <asp:ListItem Selected="True" Text="Select" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-3">
                        <table>
                            <tr>
                                <td colspan="5">Dimensions</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtDL" runat="server" CssClass="form-control form-control-solid form-control-lg  float txtDL w-50px " placeholder="L"></asp:TextBox>
                                </td>
                                <td>x
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDW" runat="server" CssClass="form-control form-control-solid form-control-lg  float txtDW w-50px" placeholder="W"></asp:TextBox>
                                </td>
                                <td>x
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDH" runat="server" CssClass="form-control form-control-solid form-control-lg   float txtDH w-50px" placeholder="H"></asp:TextBox>
                                </td>
                                
                            </tr>
                        </table>
                              </div>
                    <div class="col-lg-3">
                        <br />
                           <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="AirwayPackage" />

                    </div>
                </div>

            </div>

        </div>

    </section>
    <div class="hidden">
              <label>Air Way Bill Key</label>
                  <asp:TextBox runat="server" class="form-control form-control-solid form-control-lg txtAirWayKey"  ID="txtAirWayKey" placeholder="0"></asp:TextBox>
          
    </div>
</asp:Content>

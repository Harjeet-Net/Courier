<%@ Page Title="Invoice Details" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="InvoiceDetail.aspx.cs" Inherits="CourierNew.Pages.InvoiceDetail" %>

<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">

    <span class="hidden">
        SQL_Save  :  InvoiceDetailSAVE
        SQL_Get   :  InvoiceDetailGET 
        SQL_Search   :  InvoiceDetailSEARCH 
     
    </span>

    <script src="Js/InvoiceDetailEntry.js?ver=2"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Invoice Detail Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '220px';
            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }
    </script>
    <!------------------Step 2 Page Design------->

    <section class="content">
        <div class="container-fluid">
            <div class=" row form-group">
                <!-- form start -->
                <div class=" row col-lg-12">
                    <div class="col-lg-6">
                        <label>Item Description</label>
                        <asp:TextBox ID="txtItemDescription" runat="server" CssClass="form-control form-control-solid form-control-lg  txtItemDescription" placeholder="Item Description"></asp:TextBox>
                    </div>
                    <div class="col-lg-3">
                        <label>Manufacture From</label>
                        <asp:DropDownList ID="ddlManufactureFrom" runat="server" CssClass="form-control form-control-solid form-control-lg  ddlManufactureFrom" AppendDataBoundItems="true">
                            <asp:ListItem Selected="True" Text="Select Manufacture" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-3">
                        <label>Commodity Code</label>
                        <asp:TextBox ID="txtCommodityCode" runat="server" CssClass="form-control form-control-solid form-control-lg  txtCommodityCode" placeholder="Commodity Code"></asp:TextBox>
                    </div>

                </div>
                <div class=" row col-lg-12 ">
                    <div class="col-lg-1">
                        <label>Quantity</label>
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control form-control-solid form-control-lg  numeric txtQuantity" placeholder="Qty"></asp:TextBox>

                    </div>
                    <div class="col-lg-2">
                        <label>Units</label>
                        <asp:DropDownList ID="ddlQunatityUnit" runat="server" CssClass="form-control form-control-solid form-control-lg  ddlQunatityUnit" AppendDataBoundItems="true">
                            <asp:ListItem Selected="True" Text="Select Unit" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div class="col-md-3  ">

            <table>
                <tr>
                                <td>
                                    Item Value</td>
                            </tr>
                <tr>

                    <td>

                        <asp:TextBox ID="txtItemValue" runat="server" CssClass="form-control form-control-solid form-control-lg float txtItemValue " placeholder="Item Val"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCurrencey" runat="server" CssClass="form-control form-control-solid form-control-lg  ddlCurrencey w-100px " AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="KWD">KWD</asp:ListItem>
                                        <asp:ListItem Value="USD">USD</asp:ListItem>
                                        <asp:ListItem Value="INR">INR</asp:ListItem>
                                    </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
                    
                    <div class="col-lg-3">
                        <table>
                            <tr>
                                <td>Net Weight</td>
                            </tr>
                            <tr>
                                <td class="  col-lg-1">
                                    <asp:TextBox ID="txtNetWeight" runat="server" CssClass="form-control form-control-solid form-control-lg  float txtNetWeight w-100px" placeholder="N Weight"></asp:TextBox>
                                </td>
                                <td class="col-lg-1">
                                    <asp:DropDownList ID="ddlNetWeightUnit" runat="server" CssClass="form-control form-control-solid form-control-lg  ddlNetWeightUnit w-100px" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Text="Select Unit" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-lg-3">
                        <table>
                            <tr>
                                <td>Gross Weight</td>
                            </tr>
                            <tr>
                                <td class="  col-lg-1">
                                    <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="form-control form-control-solid form-control-lg  float txtGrossWeight w-100px" placeholder="G Weight"></asp:TextBox>
                                </td>
                                <td class="  col-lg-1">
                                    <asp:DropDownList ID="ddlGrossWeightUnit" runat="server" CssClass="form-control form-control-solid form-control-lg  ddlGrossWeightUnit w-100px" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Text="Select Unit" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>




            </div>

        </div>
        <div class="col-lg-12 text-center">

            <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="AirwayInvoiceDetail" />

        </div>
    </section>
    <div class="hidden">
        <label>Air Way Bill Key</label>
        <asp:TextBox runat="server" class="form-control form-control-solid form-control-lg txtAirWayKey" ID="txtAirWayKey" placeholder="0"></asp:TextBox>

    </div>
</asp:Content>






<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrShipment.ascx.cs" Inherits="CourierNew.UserControl.CtrShipment" %>

<script src="../UserControl/JS/ShipmentSearch.js?ver=2"></script>
<section class="container">
    <span class="hidden">
        SQL_Save  :  AirWayMainSAVE
        SQL_Get   :  AirWayMainGET
        SQL_Search:  AirWayMainSearch 
    </span>
    <!-- Default box -->
    <!--begin::Card-->
    <div class="">
  
        <div class="">
            <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="HeadTitle"></h3>
                <div class="card-title col-lg">
                    <h3 class="card-label">Operation List</h3>
                </div>
                <div class="card-toolbar row">
                    <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnPrepareShipment" OnClientClick="return Op(10,0);" Text="Prepare Shipment" />
                    <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden" ID="btnLocalShipment" OnClientClick="return Op(11,0);" Text="Local Shipment" />
                </div>

            </div>
            <br />
            <div>
                <div class="row col-lg-12">
                      <div class="form-group hidden">
                        <label>Slot</label>
                       <asp:DropDownList ID="ddlSlot" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlSlot">
                            <asp:ListItem Value="Import">Scheduled</asp:ListItem>
                            <asp:ListItem Value="Export">Week After</asp:ListItem>
                            <asp:ListItem Value="Local">Completed</asp:ListItem>
                            <asp:ListItem Value="Frieght Forwarding">Delay</asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                    <label  class="col-lg-2 control-label">Shipment Type</label>
                     <div class="form-group">
                        
                        <asp:DropDownList ID="ddlTranType" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlTranType">
                            <asp:ListItem Value="-1">Select One</asp:ListItem>
                            <asp:ListItem Value="Import">Import</asp:ListItem>
                            <asp:ListItem Value="Export">Export</asp:ListItem>
                            <asp:ListItem Value="Local">Local</asp:ListItem>                          
                        </asp:DropDownList>
                    </div>
                     <div class="form-group hidden">
                        <label>Type</label>
                        <asp:DropDownList ID="ddlType" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlType">
                            <asp:ListItem Value="Import">Delivery</asp:ListItem>
                            <asp:ListItem Value="Export">Collection</asp:ListItem>
                            <asp:ListItem Value="Local">Local</asp:ListItem>
                            <asp:ListItem Value="Frieght Forwarding">Other Job</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                   

                    

                    <div class=" col-lg-1">
                        <input type="button" value="search" class="btn btn-primary btn-sm" onclick="Bind();" title="click here to search" />
                    </div>


                </div>
                <!-- /.card-body -->

                <!-- /.card-footer-->
            </div>
        </div>
        <!-- /.card -->
        <div>
            <%-- Contain Load  Here --%>
            <div id="dvGrid" style="zoom: 0.9"></div>

        </div>

    </div>
</section>



<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrCashier.ascx.cs" Inherits="CourierNew.UserControl.CtrCashier" %>
<script src="../UserControl/JS/CashierProcessSearch.js?ver=2"></script>
<section class="container">
  <span class="hidden">
        SQL_Save: CashierSave
        SQL_Get:  CashierGet
        SQL_Search:  CashierSearch
    </span>
    <!-- Default box -->
    <!--begin::Card-->
    <div class="">
        <div class="">
            <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="HeadTitle"></h3>
                <div class="card-title col-lg">
                    <h3 class="card-label">Cashier Data</h3>
                </div>
                  <div class="card-toolbar row">
                 <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnDayBegin" OnClientClick="return Op(8,0);" Text=" Day Begin" />
                 
                 <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnDayClose" OnClientClick="return Op(9,0);" Text=" Day Close" />
                </div>

            </div>
            <br />
            <div>
                <div class="row col-lg-12">
                             <label class="col-lg-2 control-label">Type Of Expense</label>
                    <div class="  col-lg-3">
                        <asp:DropDownList ID="ddlExpenseType" runat="server" CssClass="form-control form-control-solid  ddlExpenseType" AppendDataBoundItems="true">
                            <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>
                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                             <asp:ListItem Value="Card">Card</asp:ListItem>
                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                        </asp:DropDownList> </div>

                    <div class=" col-lg-1">

      
                        <input type="button" value="Search" class="btn btn-primary btn-sm" onclick="Bind();" title="Click here to search" />
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



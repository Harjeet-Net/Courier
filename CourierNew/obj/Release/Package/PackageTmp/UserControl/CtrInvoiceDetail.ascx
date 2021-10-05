<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrInvoiceDetail.ascx.cs" Inherits="CourierNew.UserControl.CtrInvoiceDetail" %>
<script src="../UserControl/JS/InvoiceDetailSearch.js?ver=2"></script>
<section class="container">
  <span class="hidden">

        SQL_Save  :  InvoiceDetailSAVE
        SQL_Get   :  InvoiceDetailGET 
        SQL_Get   :  InvoiceDetailSEARCH 
    </span>
    <!-- Default box -->
    <!--begin::Card-->
    <div class="">
  
        <div class="">
            <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="HeadTitle"></h3>
                <div class="card-title col-lg">
                    <h3 class="card-label">Invoice Details</h3>
                </div>
            <%--    <div class="card-toolbar">
                    
                 <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnCatAdd" OnClientClick="return Op(16,0);" Text=" Add Category" />
                 </div>--%>

            </div>
            <div>
                <div class="row col-lg-12"> 
                             <label class="col-lg-2 control-label">Invoice Name</label>
                    <div class="  col-lg-3">
                         <asp:TextBox ID="txtInvoiceKey" runat="server" Wrap="False" CssClass="form-control txtInvoiceKey "  placeHolder="Invoice Name"></asp:TextBox>
                    </div>

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



<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrDriverMaster.ascx.cs" Inherits="CourierNew.UserControl.CtrDriverMaster" %>


    <script src="../UserControl/JS/DriverMasterSearch.js?ver=2"></script>
<section class="container">
           <span class="hidden">

        SQL_Save  :  DriverSave
        SQL_Get   :  DriverGet 
        SQL_Search:  DriverSearch 
    </span>
    <!-- Default box -->
    <!--begin::Card-->
    <div class="">
  
        <div class="">
            <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="H1"></h3>
                <div class="card-title col-lg">
                    <h3 class="card-label">Driver Master</h3>
                </div>
               <div class="card-toolbar">                   
                    <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnCatAdd" OnClientClick="return Op(12,0);" Text=" Add Driver" />
                </div>

            </div>
            <br />
            <div>

                  <div class="row col-lg-12">
                    <label class="col-lg-2 control-label">Driver Full Name</label>
                    <div class="  col-lg-3">
                        <asp:TextBox ID="txtDriverName" runat="server" CssClass="form-control form-control-solid  txtDriverName" placeholder="Enter Full Name"></asp:TextBox>
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
        <div class="card-body">
            <%-- Contain Load  Here --%>
            <div id="dvGrid" style="zoom: 0.9"></div>

        </div>

    </div>
</section>


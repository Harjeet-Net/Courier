<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrCategoryMaster.ascx.cs" Inherits="CourierNew.UserControl.CtrCategoryMaster" %>
<script src="../UserControl/Js/CategoryMasterSearch.js?ver=2"></script>
<section class="container">
  <span class="hidden">

        SQL_Save  :  CategoryMasterSAVE
        SQL_Get   :  CategoryMasterGET 
        SQL_Search:  CategoryMasterSearch 
    </span>
    <!-- Default box -->
    <!--begin::Card-->
    <div class="">

        <div class="">
            <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="HeadTitle"></h3>
                <div class="card-title col-lg">
                    <h3 class="card-label">Category Master</h3>
                </div>
                <div class="card-toolbar">
                    <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnCatAdd" OnClientClick="return Op(2,0);" Text=" Add Category" />
                </div>

            </div>
            <br />
            <div>
                <div class="row col-lg-12">
                    <label class="col-lg-2 control-label">Category Name</label>
                    <div class="  col-lg-3">
                        <asp:DropDownList ID="ddlCategoryName" runat="server" AppendDataBoundItems="True" CssClass="form-control form-control-solid ddlCategoryName" placeholder="Role">
                        </asp:DropDownList>
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



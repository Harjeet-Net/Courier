<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrUserPermission.ascx.cs" Inherits="CourierNew.UserControl.CtrUserPermission" %>

<script src="../UserControl/Js/UserPermissionSearch.js?ver=2"></script>

<section class="container">
  <span class="hidden">
        SQL_Save: UserPermissionUpdate
        SQL_Get:  UserPermissionGet
    </span>
    <!-- Default box -->
    <!--begin::Card-->
    <div class=" ">
  
        <div class="c ">
            <div class="card-header flex-wrap border-0 pt-6 pb-0 row">
                <h3 class="card-title" runat="server" id="HeadTitle"></h3>
                <div class="card-title col-lg">
                    <h3 class="card-label">User Permission</h3>
                </div>
                <div class="card-toolbar">
                    
                   <%-- <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnCatAdd" OnClientClick="return Op(3,0);" Text=" Add Permission" />--%>
                </div>

            </div>
            <div class=" ">
                <div class="row">

                  <%--  <div class="form-group col-lg-3">
                        <label>Category Name</label>
                        <asp:DropDownList ID="ddlCategoryName" runat="server" AppendDataBoundItems="True" CssClass="form-control form-control-solid form-control-lg ddlCategoryName" placeholder="Role">
                            <asp:ListItem Text="Select" Value="-1" />
                        </asp:DropDownList>
                    </div>

                    <div class="form-group col-lg-1">

                        <label class="text-white">.</label>
                        <input type="button" value="Search" class="btn btn-primary btn-sm" onclick="Bind();" title="Click here to search" />
                    </div>--%>


                </div>
                <!-- /.card-body -->

                <!-- /.card-footer-->
            </div>
        </div>
        <!-- /.card -->
        <div class="">
            <%-- Contain Load  Here --%>
            <div id="dvGrid" style="zoom: 0.9"></div>

        </div>

    </div>
</section>


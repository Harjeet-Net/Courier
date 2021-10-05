<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrEmployeeMaster.ascx.cs" Inherits="CourierNew.UserControl.CtrEmployeeMaster" %>
<script src="../UserControl/Js/EmployeeMasterSearch.js?ver=2"></script>
<section class="content">
       <span class="hidden">

        SQL_Save  :  EmployeeSAVE
        SQL_Get   :  EmployeeGET 
        SQL_Search:  EmployeeSearch 
    </span>
    <!-- Default box -->
    <div class="">
  
        <div class="">
            <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="HeadTitle"></h3>
                <div class="card-title col-lg-10">
                    <h3 class="card-label container">Employee Master</h3>
                </div>
                <div class="card-toolbar">
                    
                    <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnCatAdd" OnClientClick="return Op(6,0);" Text=" Add Employee" />
                </div>

            </div>
            <br />
            <div>
              
                <div class="row col-lg-12"> 
                    <label class="col-lg-2 control-label">First Name</label>
                    <div class="  col-lg-3">           
                        <asp:TextBox runat="server"  placeholder="First Name" ID="txtfirstname" class="form-control form-control-solid   txtfirstname"></asp:TextBox>
                    </div>
                    <label class="col-lg-2 control-label">User Role</label>
                    <div class="  col-lg-3">           
                        <asp:DropDownList ID="ddlMainHRRoleID" runat="server" AppendDataBoundItems="True" class="form-control form-control-solid   ddlMainHRRoleID" >
                            <asp:ListItem Text="Select All" Value="-1" />
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
        <div class="card-body">
            <%-- Contain Load  Here --%>
            <div id="dvGrid" style="zoom: 0.9"></div>

        </div>

    </div>
</section>


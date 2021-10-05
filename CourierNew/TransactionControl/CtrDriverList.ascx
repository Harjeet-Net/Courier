<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrDriverList.ascx.cs" Inherits="CourierNew.TransactionControl.CtrDriverList" %>

<%--<script src="../UserControl/Js/CategoryMasterSearch.js?ver=2"></script>--%>
 <div class="border-bottom p-1 text-right">

        <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="UserMaster" />

    </div>
<section class="container">
    <%--<span class="hidden">

        SQL_Save  :  CategoryMasterSAVE
        SQL_Get   :  CategoryMasterGET 
        SQL_Search:  CategoryMasterSearch 
    </span>--%>
     <asp:Label runat="server" ID="ltMsg"></asp:Label>
        <div class="container-fluid">
            <!-- form start -->

            <div class="row form-group">
                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Driver Full Name</label>
                        <asp:TextBox ID="txtDriverName" runat="server" CssClass="form-control form-control-solid form-control-lg txtDriverName" placeholder="Enter Full Name"></asp:TextBox>
                        <span class="form-text text-muted">Please Enter Your Full Name.</span>
                    </div>
                    <div class="form-group">
                        <label>Nationality</label>
                        <asp:DropDownList ID="ddlNationality" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlNationality w-auto" runat="server">
                            <asp:ListItem Value="True" Selected="True">Select One</asp:ListItem>                            
                        </asp:DropDownList>
                        <span class="form-text text-muted">Please Select Your Nationality</span>
                    </div>
                      <div class="form-group">
                        <label>City</label>
                        <asp:DropDownList ID="ddlCity" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlCity w-auto" runat="server">
                            <asp:ListItem Value="True" Selected="True">Select One</asp:ListItem>                            
                        </asp:DropDownList>
                        <span class="form-text text-muted">Please Select Your City</span>
                    </div>
                     <div class="form-group">
                        <label>Country</label>
                        <asp:DropDownList ID="ddlCountry" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlCountry w-auto" runat="server">
                            <asp:ListItem Value="True" Selected="True">Select One</asp:ListItem>                            
                        </asp:DropDownList>
                        <span class="form-text text-muted">Please Select Your Country</span>
                    </div>
                    <div class="form-group">
                        <label>Address</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control form-control-solid form-control-lg txtAddress" placeholder=" Enter Your Address "></asp:TextBox>
                        <span class="form-text text-muted">Please Enter Your Address</span>
                    </div>
                </div>

                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Mobile Number</label>
                        <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control form-control-solid form-control-lg txtMobileNumber" placeholder=" Enter Your Mobile Number  "></asp:TextBox>
                        <span class="form-text text-muted">Please Enter Your Mobile Number</span>
                    </div>
                    <div class="form-group">
                        <label>Email Id</label>
                        <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control form-control-solid form-control-lg txtEmailId" placeholder=" Enter Your Email Id  "></asp:TextBox>
                        <span class="form-text text-muted">Please Enter Your Email Id</span>
                    </div>
                     <div class="form-group">
                        <label>State</label>
                        <asp:DropDownList ID="ddlState" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlState w-auto" runat="server">
                            <asp:ListItem Value="True" Selected="True">Select One</asp:ListItem>                            
                        </asp:DropDownList>
                        <span class="form-text text-muted">Please Select Your State</span>
                    </div>                 
                      <div class="form-group">
                        <label>ZipCode</label>
                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control form-control-solid form-control-lg txtZipCode" placeholder=" Enter Your ZipCode  "></asp:TextBox>
                        <span class="form-text text-muted">Please Enter Your ZipCode</span>
                    </div>
                    <div class="form-group">
                        <label>Vehicle Type</label>
                        <asp:DropDownList ID="ddlVehicleType" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlVehicleType w-auto" runat="server">
                            <asp:ListItem Value="True" Selected="True">Select One</asp:ListItem>                            
                        </asp:DropDownList>
                        <span class="form-text text-muted">Please Select Your Vehicle Type</span>
                    </div>    
                </div>

</div>
</div>

    </section>






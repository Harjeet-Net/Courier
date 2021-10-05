<%@ Page Title="Driver Entry" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="DriverMaster.aspx.cs" Inherits="CourierNew.Pages.DriverMaster" %>

<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">
    
    <script src="Js/DriverMasterEntry.js"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>

     <span class="hidden">
      
        SQL_Save  :  DriverSave
        SQL_Get   :  DriverGet 
        SQL_Search:  DriverSearch 
    </span>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Driver Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '280px';
            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }

    </script>
    <div class="border-bottom p-1 text-right">

        <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="DriverMaster" />

    </div>
    <!------------------Step 2 Page Design------->
    <section class="content">
        <div class=" container-fluid">
            <!-- form start -->
            <br />
            <div class="row form-group">
                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Driver Full Name</label>
                        <asp:TextBox ID="txtDriverName" runat="server" CssClass="form-control form-control-solid form-control-lg txtDriverName" placeholder=" Full Name"></asp:TextBox>                      
                    </div>
                    <div class="row">
                     <div class="form-group col-lg-6">
                        <label>Country</label>
                        <asp:DropDownList ID="ddlCountry" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlCountry  " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Selected="False">Select One</asp:ListItem>              
                        </asp:DropDownList>
                        
                    </div>
                     <div class="form-group col-lg-6">
                        <label>State</label>
                        <asp:DropDownList ID="ddlState" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlState " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem> 
                            <asp:ListItem Value="America">America</asp:ListItem>
                            <asp:ListItem Value="India">India</asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>                       
                    
                    </div>                   
                </div>
                <div class=" col-lg-4">                    
                    <div class="row">
                     
                    <div class="form-group col-lg-6">
                        <label>Email Id</label>
                        <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control form-control-solid form-control-lg txtEmailId" placeholder="  Email Id  "></asp:TextBox>                       
                    </div>
                    <div class="form-group col-lg-6">
                        <label>Vehicle Type</label>
                        <asp:DropDownList ID="ddlVehicleType" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlVehicleType " runat="server">
                            <asp:ListItem Value="-1" Selected="False">Select</asp:ListItem>  
                            <asp:ListItem Value="2-Wheeler">2-Wheeler</asp:ListItem> 
                            <asp:ListItem Value="4-Wheeler">4-Wheeler</asp:ListItem> 
                            <asp:ListItem Value="10-Wheeler">10-Wheeler</asp:ListItem> 
                        </asp:DropDownList>                       
                    </div> 
                        
                    </div>
                    <div class="row">
                    <div class="form-group col-lg-6">
                        <label>City</label>
                        <asp:DropDownList ID="ddlCity" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlCity  " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>                          
                        </asp:DropDownList>
                        
                    </div>
                     <div class="form-group col-lg-6">
                        <label>ZipCode</label>
                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control form-control-solid form-control-lg txtZipCode" placeholder="  ZipCode  "></asp:TextBox>
                        
                    </div>                               
                   </div>
                                       
                  
                    </div>
                  <div class="col-lg-4">  
                     <div class="row">
                     <div class="form-group col-lg-6">
                        <label>Mobile Number</label>
                        <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control form-control-solid form-control-lg txtMobileNumber numeric" placeholder="  Mobile Number  "></asp:TextBox>                       
                    </div>
                 
                     <div class="form-group col-lg-6 ">
                        <label>Nationality</label>
                        <asp:DropDownList ID="ddlNationality" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlNationality" runat="server">
                            <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>                 
                        </asp:DropDownList>
                       
                    </div>
                    </div>
                    
                <div class="form-group">
                        <label>Address</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control form-control-solid form-control-lg txtAddress" TextMode="MultiLine" Columns="3" placeholder="  Address "></asp:TextBox>
                        
                    </div>
                    
                </div>
                  
                </div>        
                
               

</div>

    </section>
</asp:Content>

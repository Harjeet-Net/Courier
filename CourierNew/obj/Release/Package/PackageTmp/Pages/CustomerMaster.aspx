<%@ Page Title="Customer Entry" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="CustomerMaster.aspx.cs" Inherits="CourierNew.Pages.CustomerMaster" %>

<%@ Register Src="~/TransactionControl/CtrAddress.ascx" TagPrefix="CtrAddress" TagName="CtrAddress" %>


<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">

    <script src="Js/CustomerMasterEntry.js?ver=2"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>

   <span class="hidden">

        SQL_Save  :  CustomerSAVE
        SQL_Get   :  CustomerGET 
        SQL_Search:  CustomerSearch 
    </span>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Customer Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '440px';
            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }

    </script>
    <div class="border-bottom p-1 text-right">

        <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true"  OnMasterEve="Buttons_MasterEve" enRole="Customer" IsCustomJs="false" />

    </div>
    <!------------------Step 2 Page Design------->
    <section class="content">
        <div class="container-fluid">
            <!-- form start -->

            <div class="row form-group">
                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Customer Name</label>
                        <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control form-control-solid form-control-lg txtCustomerName" placeholder="Customer Name"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label>Mobile Number</label>
                            <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control form-control-solid form-control-lg txtMobileNumber numeric" placeholder="Mobile Number"></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label>Alternate Number</label>
                            <asp:TextBox ID="txtAlternateNumber" runat="server" CssClass="form-control form-control-solid form-control-lg txtAlternateNumber numeric" placeholder="Alternate Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group  col-lg-6">
                            <label>Country</label>
                            <asp:DropDownList ID="ddlCountry" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlCountry " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSenderCountry_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Selected="False">Select One</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group  col-lg-6">
                            <label>State</label>
                            <asp:DropDownList ID="ddlState" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlState " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSenderState_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label>Email Id</label>
                            <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control form-control-solid form-control-lg txtEmailId" placeholder="Email Id"></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label>Nationality</label>
                            <asp:DropDownList ID="ddlNationality" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlNationality " runat="server">
                                <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label>Reference Number</label>
                            <asp:TextBox ID="txtReferenceNumber" runat="server" CssClass="form-control form-control-solid form-control-lg txtReferenceNumber" placeholder="Reference Number"></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label>Paci Number</label>
                            <asp:TextBox ID="txtPaciNumber" runat="server" CssClass="form-control form-control-solid form-control-lg txtPaciNumber" placeholder="Paci Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label>City</label>
                            <asp:DropDownList ID="ddlCity" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlCity " runat="server">
                                <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-lg-6">
                            <label>ZipCode</label>
                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control form-control-solid form-control-lg txtZipCode" placeholder="ZipCode"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Address</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control form-control-solid form-control-lg txtAddress" TextMode="MultiLine" Columns="4" placeholder="Address" style="height: 138px;"></asp:TextBox>
                    </div>
                      <div class="form-group hidden" id="dvDefault" runat="server">
                           <label>Default Address</label>
                        <asp:DropDownList ID="ddlDefaultAddress" AppendDataBoundItems="true" CssClass="ddlDefaultAddress form-control form-control-lg form-control-solid hidden" runat="server">
<%--                            <asp:ListItem Value="-1" >Select One</asp:ListItem>--%>
                            
                        </asp:DropDownList>
                    </div>
                    
                    <div class="form-group hidden">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" AppendDataBoundItems="true" CssClass="ddlStatus form-control form-control-lg form-control-solid w-105px" runat="server">
                            <asp:ListItem Value="1" Selected="False">Active</asp:ListItem>
                            <asp:ListItem Value="0">In Active</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-lg-12" id="dvAdressgrid" runat="server">
                <div class="row">
                    <div class="col-lg-3"> <h3>Customer Address List </h3></div>
                     <div class="form-group col-lg-1">
                        <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnAddAddress" OnClientClick="return Op(14,0);" Text="Add Address" />
                 </div>
                </div>
                <br />
                <asp:GridView ID="gv" runat="server" CssClass="border-0 table table-bordered table-striped  table-sm"
                    ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataKeyNames="CustomerKey,AddressKey"
                    EmptyDataText="No Record Found">
                    <Columns>
                        <asp:TemplateField HeaderText="Action">
                            
                            <ItemTemplate>
                                 <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-link btn-sm"  OnClientClick='<%# "Op(14,"+ Eval("AddressKey").ToString() +")" %>'  />
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Address Name" DataField="AddressName" />
                        <asp:BoundField HeaderText="Flat" DataField="FlatNo" />
                        <asp:BoundField HeaderText="Floor" DataField="FloorNo" />
                        <asp:BoundField HeaderText="Block" DataField="BlockNo" />
                        <asp:BoundField HeaderText="Country" DataField="CountryName" />
                        <asp:BoundField HeaderText="State" DataField="StateName" />
                        <asp:BoundField HeaderText="City" DataField="CityName" />
                        <asp:BoundField HeaderText="City" DataField="CityName" />
                        <asp:BoundField HeaderText="Address 1" DataField="Address1" />
                        <asp:BoundField HeaderText="Address 2" DataField="Address2" />
                        <asp:BoundField HeaderText="Address 3" DataField="Address3" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row  col-lg-12" id="divAdd" runat="server">
            <h3 >Customer Address Entry</h3>
                  <CtrAddress:CtrAddress runat="server" id="CtrAddress" PageType="Child"  />
        </div>
    </section>
</asp:Content>

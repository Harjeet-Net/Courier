
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrAddress.ascx.cs" Inherits="CourierNew.TransactionControl.CtrAddress" %>


    <script src="Js/CustomerAddressEntry.js?ver=2"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>

    <span class="hidden">
        SQL_Save  :  CustomerAddressSAVE
        SQL_Get   :  CustomerAddressGET 
        SQL_Search:  CustomerAddressSearch 
    </span>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Address Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '450px';
            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }

    </script>
    <div class="border-bottom p-1 text-right">

        <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" IsCustomJs="true" enRole="CustomerAddress" />

    </div>
    <!------------------Step 2 Page Design------->

<section>
    
        <div class="container-fluid">
            <div class="row form-group">
                <div class=" row col-lg-12">
                  
                    <div class="form-group col-lg-3">
                        <label>Address Name</label>
                        <asp:TextBox ID="txtAddressName" runat="server" CssClass="form-control form-control-solid form-control-lg txtAddressName" placeholder="Address Name"></asp:TextBox>
                    </div>
          
                    <div class="form-group col-lg-3">
                        <label>Flat No</label>
                        <asp:TextBox ID="txtFlatNo" runat="server" CssClass="form-control form-control-solid form-control-lg txtFlatNo " placeholder="Flat No"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-3">
                        <label>Floor No</label>
                        <asp:TextBox ID="txtFloorNo" runat="server" CssClass="form-control form-control-solid form-control-lg txtFloorNo " placeholder="Floor No"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-2">
                        <label>Block No</label>
                        <asp:TextBox ID="txtBlockNo" runat="server" CssClass="form-control form-control-solid form-control-lg txtBlockNo " placeholder="Block No"></asp:TextBox>
                    </div>

                </div>
                <div class="row form-group col-lg-12">
                    <div class="form-group col-lg-3">
                        <label>Country</label>
                        <asp:DropDownList ID="ddlCountry" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlCountry " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSenderCountry_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Selected="False">Select One</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-lg-3">
                        <label>State</label>
                        <asp:DropDownList ID="ddlState" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlState " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSenderState_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-lg-3">
                        <label>City</label>
                        <asp:DropDownList ID="ddlCity" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg ddlCity " runat="server">
                            <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
                <div class="row form-group col-lg-12">

                    <div class="col-lg-3 ">
                        <label>Address 1</label>
                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control form-control-solid form-control-lg txtAddress1" placeholder="Address 1"></asp:TextBox>

                    </div>
                    <div class="col-lg-3 ">
                        <label>Address 2</label>
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control form-control-solid form-control-lg txtAddress2" placeholder="Address 2"></asp:TextBox>

                    </div>                          
                    <div class="col-lg-3 ">
                        <label>Address 3</label>
                        <asp:TextBox ID="txtAddress3" runat="server" CssClass="form-control form-control-solid form-control-lg txtAddress3" placeholder="Address 3"></asp:TextBox>
                    </div>
                     <div class="col-lg-2 ">
                    <label>Post Code</label>
                    <asp:TextBox ID="txtPostCode" runat="server" CssClass="form-control form-control-solid form-control-lg txtPostCode numeric" placeholder="Post Code"></asp:TextBox>
                </div>
                </div>
               
      </div>
             <div class="  form-group col-lg-3 hidden">
                        <label>Name</label>
                        <asp:TextBox ID="txtCustomerKey" runat="server" Wrap="False" CssClass="form-control form-control-solid form-control-lg txtCustomerKey " placeHolder="Customer Name"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="auCustomerKey" runat="server"
                            CompletionInterval="100" CompletionListCssClass="completionList"
                            CompletionListHighlightedItemCssClass="itemHighlighted"
                            CompletionListItemCssClass="listItem" ContextKey="Customer"
                            DelimiterCharacters="" EnableCaching="False"
                            Enabled="True" MinimumPrefixLength="1" OnClientItemSelected="OnDxSelected"
                            ServiceMethod="GetAuto" ServicePath="~/Services/AuotSuggess.asmx"
                            TargetControlID="txtCustomerKey" UseContextKey="True">
                        </ajaxToolkit:AutoCompleteExtender>
                        <asp:TextBox ID="auCustomerKeyV" runat="server" CssClass="hidden auCustomerKeyV" Text="0"></asp:TextBox>
                    </div>
            
    </div>

    </section>




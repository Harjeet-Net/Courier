﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrCustomerMaster.ascx.cs" Inherits="CourierNew.UserControl.CtrCustomerMaster" %>


    <script src="../UserControl/JS/CustomerMasterSearch.js?ver=2"></script>
<section class="container">
 <span class="hidden">

        SQL_Save  :  CustomerSAVE
        SQL_Get   :  CustomerGET 
        SQL_Search:  CustomerSearch 
    </span>
    <!-- Default box -->
    <!--begin::Card-->
    <div class="">
  
        <div class="">

              <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="H1"></h3>
                <div class="card-title col-lg">
                    <h3 class="card-label">Customer Master</h3>
                </div>
               <div class="card-toolbar">                    
                    <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnCatAdd" OnClientClick="return Op(13,0);" Text=" Add Customer" />
                </div>

            </div>
            <br />
            <div>

                 <div class="row col-lg-12">

                    <label class="col-lg-2 control-label">Customer Name</label>
                    <div class="col-lg-3">
                         <asp:TextBox ID="txtCustomerKey" runat="server" Wrap="False" CssClass="form-control form-control-solid  txtCustomerKey "  placeHolder="Customer Name"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="auCustomerKey" runat="server"
                            CompletionInterval="100" CompletionListCssClass="completionList"
                            CompletionListHighlightedItemCssClass="itemHighlighted"
                            CompletionListItemCssClass="listItem" ContextKey="Customer"
                            DelimiterCharacters="" EnableCaching="False"
                            Enabled="True" MinimumPrefixLength="1" OnClientItemSelected="OnDxSelected"
                            ServiceMethod="GetAuto" ServicePath="~/Services/AuotSuggess.asmx"
                            TargetControlID="txtCustomerKey" UseContextKey="True">
                        </ajaxToolkit:AutoCompleteExtender>
                        <asp:TextBox ID="auCustomerKeyV" runat="server" CssClass="hidden auCustomerKeyV" Text="0" Width="0%"></asp:TextBox>
                    </div>
                     <label class="col-lg-2 control-label">Mobile Number</label>
                    <div class="  col-lg-3">
                    <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control form-control-solid  txtMobileNumber numeric" placeholder="Mobile Number"></asp:TextBox>
                    </div>
                    <label class="col-lg-2 control-label hidden">Country</label>
                    <div class="col-lg-2 hidden">
                    <asp:DropDownList ID="ddlCountry" AppendDataBoundItems="true" CssClass="form-control form-control-solid  ddlCountry " runat="server" >
                            <asp:ListItem Value="-1" Selected="False">Select One</asp:ListItem>
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


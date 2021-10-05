<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="LocalShipment.aspx.cs" Inherits="CourierNew.Pages.LocalShipment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CP1" runat="server">
     <span class="hidden">
        SQL_Save  :  AirWayMainSAVE
        SQL_Get   :  AirWayMainGET
        SQL_Search:  AirWayMainSearch 
    </span>
     <asp:Label runat="server" ID="ltMsg"></asp:Label>

    <!------------------Step 1 Set Page Size----->
    <script>
        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Local Shipment ');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '800px';

            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }

    </script>
    <!--begin::Page Custom Styles(used by this page)-->
    <link href="/assets/css/pages/wizard/wizard-1.css" rel="stylesheet" type="text/css" />
    <!--end::Wizard-->
    <%--<!--begin::Page Scripts(used by this page)-->
    <script src="/assets/js/pages/custom/wizard/wizard-1 - Copy.js"></script>--%>

     <script src="Js/LocalShipmentEntry.js?ver=2"></script>
   
    <!--end::Page Scripts-->
    <!--begin::Wizard-->
    <section class="content">
        <div class="container-fluid bg-white">

     <!--begin::Wizard-->
                 <div class="wizard wizard-1" id="kt_wizard" data-wizard-state="first" data-wizard-clickable="false">
                        <!--begin::Wizard Nav-->
                        <div class="wizard-nav border-bottom">
                            <div class="wizard-steps p-8 p-lg-10">
                                <!--begin::Wizard Step 1 Nav-->
                                <div class="wizard-step" data-wizard-type="step" data-wizard-state="current">
                                    <div class="wizard-label">
                                        <i class="wizard-icon flaticon-bus-stop"></i>
                                        <h3 class="wizard-title">1. Shipper Details</h3>
                                    </div>
                                    <span class="svg-icon svg-icon-xl wizard-arrow">
                                        <!--begin::Svg Icon | path:assets/media/svg/icons/Navigation/Arrow-right.svg-->
                                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <polygon points="0 0 24 0 24 24 0 24"></polygon>
                                                <rect fill="#000000" opacity="0.3" transform="translate(12.000000, 12.000000) rotate(-90.000000) translate(-12.000000, -12.000000)" x="11" y="5" width="2" height="14" rx="1"></rect>
                                                <path d="M9.70710318,15.7071045 C9.31657888,16.0976288 8.68341391,16.0976288 8.29288961,15.7071045 C7.90236532,15.3165802 7.90236532,14.6834152 8.29288961,14.2928909 L14.2928896,8.29289093 C14.6714686,7.914312 15.281055,7.90106637 15.675721,8.26284357 L21.675721,13.7628436 C22.08284,14.136036 22.1103429,14.7686034 21.7371505,15.1757223 C21.3639581,15.5828413 20.7313908,15.6103443 20.3242718,15.2371519 L15.0300721,10.3841355 L9.70710318,15.7071045 Z" fill="#000000" fill-rule="nonzero" transform="translate(14.999999, 11.999997) scale(1, -1) rotate(90.000000) translate(-14.999999, -11.999997)"></path>
                                            </g>
                                        </svg>
                                        <!--end::Svg Icon-->
                                    </span>
                                </div>
                                <!--end::Wizard Step 1 Nav-->
                                <!--begin::Wizard Step 2 Nav-->
                                <div class="wizard-step" data-wizard-type="step" data-wizard-state="pending">
                                    <div class="wizard-label">
                                        <i class="wizard-icon flaticon-list"></i>
                                        <h3 class="wizard-title">2. Receiver Details</h3>
                                    </div>
                                </div>
                                <!--end::Wizard Step 2 Nav-->

                            </div>
                        </div>
                        <!--end::Wizard Nav-->

                        <div class="">
                            <ul class="nav nav-pills nav-primary bg-white rounded justify-content-center" id="pills-tab" role="tablist">
                               <%-- @*<li class="nav-item nav-item p-3 m-3">
                                        <a class="nav-link font-weight-bolder rounded-right-0 px-8 py-5 active" id="pills-tab-2" data-toggle="pill" href="#kt-pricing-2_content2" aria-expanded="true" aria-controls="kt-pricing-2_content2">Import</a>
                                    </li>*@
                                @*<li class="nav-item nav-item p-3 m-3">
                                        <a class="nav-link font-weight-bolder rounded-0 px-8 py-5" id="pills-tab-3" data-toggle="pill" href="#kt-pricing-2_content3" aria-expanded="true" aria-controls="kt-pricing-2_content3">Export</a>
                                    </li>*@
                                <li class="nav-item nav-item p-3 m-3">
                                    <a class="nav-link font-weight-bolder rounded-0 px-8 py-5 active" id="pills-tab-5" data-toggle="pill" href="#kt-pricing-2_content" aria-expanded="true" aria-controls="kt-pricing-2_content4">Local</a>
                                </li>
                                @*<li class="nav-item nav-item p-3 m-3">
                                        <a class="nav-link font-weight-bolder rounded-left-0 px-8 py-5" id="pills-tab-1" data-toggle="pill" href="#kt-pricing-2_content1" aria-expanded="true" aria-controls="kt-pricing-2_content1">Frieght Forwarding</a>
                                    </li>*@--%>
                            </ul>
                        </div>
                        <div class="hidden">
                      <label>Air Way Bill Key</label>
                      <asp:TextBox runat="server" class="form-control form-control-solid form-control-lg txtAirWayKey" ID="txtAirWayKey" placeholder="0"></asp:TextBox>

                  </div>
                        <div class="card card-custom example example-compact">
                          <%--  @*End Developer Custom Code*@--%>
                            <!--begin::Wizard Body-->
                            <div class="row justify-content-center my-10 px-8 my-lg-15 px-lg-12">
                                <div class="col-xl-12 col-xxl-12">
                                    <!--begin::Wizard Form-->
                                    <div class="form fv-plugins-bootstrap fv-plugins-framework" id="kt_form">

                                        <!--begin::Wizard Step 1-->

                                      <div class="pb-5" data-wizard-type="step-content" data-wizard-state="current">

                                             <h3 class="mb-10 font-weight-bold text-dark">Enter Your Shipper Details</h3>
                                            <input type="hidden" name="AirwayBill.ServiceType" value="">
                                            <div class="form-group fv-plugins-icon-container">
                                                <label>What is Delivery Type?</label><br>
                                                <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                    <label class="btn btn-danger">
                                                        <input type="radio" name="AirwayBill.ServiceType" value="2" checked> Pick Up
                                                    </label>
                                                    <label class="btn btn-danger">
                                                        <input type="radio" name="AirwayBill.ServiceType" value="1"> Delivery
                                                    </label>
                                                </div>
                                            </div>                                     
                                            <!--begin::Input-->
                                            <div class="row">
                                                
                                           
                                            <div class="searchwrapper form-group fv-plugins-icon-container col-lg-5">
                                                <label>Sender Name</label>
<%--                                                <input type="text" class="form-control form-control-solid form-control-lg txtCustomerKey hidden" name="txtCustomerKey" placeholder="Sender Name" >--%>
                                                <asp:TextBox ID="txtCustomerKey" runat="server" Wrap="False" CssClass="form-control form-control-solid form-control-lg txtCustomerKey" placeholder="Sender Name" onblur="SetCustomerdata();"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="auCustomerKey" runat="server"
                                                    CompletionInterval="100" CompletionListCssClass="completionList"
                                                    CompletionListHighlightedItemCssClass="itemHighlighted"
                                                    CompletionListItemCssClass="listItem" ContextKey="Customer"
                                                    DelimiterCharacters="" EnableCaching="False"
                                                    Enabled="True" MinimumPrefixLength="1" OnClientItemSelected="OnDxSelected"
                                                    ServiceMethod="GetAuto" ServicePath="~/Services/AuotSuggess.asmx"
                                                    TargetControlID="txtCustomerKey" UseContextKey="True">
                                                </ajaxToolkit:AutoCompleteExtender>
                                                <asp:TextBox ID="auCustomerKeyV" runat="server" CssClass="hidden auCustomerKeyV" Text="0" ></asp:TextBox>
                                                <div class="fv-plugins-message-container"></div>
                                            </div>
                                            <!--end::Input-->
                                            <!--begin::Input-->
                                            <div class="form-group fv-plugins-icon-container col-lg-5">
                                                <label>Company</label>
                                                <asp:TextBox ID="txtCompanyName" runat="server"  CssClass="form-control form-control-solid form-control-lg txtCompanyName" placeholder="Company" ></asp:TextBox>
                                                <%--<input type="text" class="form-control form-control-solid form-control-lg txtCompanyName"  id="txtCompanyName" runat="server" placeholder="Company" >--%>
                                                <div class="fv-plugins-message-container"></div>
                                            </div>
                                            <!--end::Input-->
                                            <!--begin::Input-->
                                            <div class="form-group fv-plugins-icon-container col-lg-2">
                                                <label>Contact/ Department</label>
<%--                                                <input type="text" class="form-control form-control-solid form-control-lg ddlDepartmentKey hidden" name="ddlDepartmentKey"  >--%>
                                                <asp:DropDownList ID="ddlDepartmentKey" runat="server" AppendDataBoundItems="true"    CssClass="form-control form-control-solid form-control-lg  ddlDepartmentKey">
                                                            <asp:ListItem Value="-1">Select One</asp:ListItem>
                                                        </asp:DropDownList>
                                                <div class="fv-plugins-message-container"></div>
                                            </div>

                                            <!--end::Input-->
                                            </div>
                                            <!--begin::Input-->

                                            <div class="row">
                                                <div class="col-lg-8">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Address</label>
                                                        <asp:DropDownList ID="ddlAddressKey" runat="server" AppendDataBoundItems="true" onchange="return SetAddressdata();" CssClass="form-control form-control-solid form-control-lg  ddlAddressKey">
                                                         <%--   <asp:ListItem Value="-1">Select One</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                 <div class="col-lg-4 row"  style="margin-top: 26px;">
                                                        <asp:Button runat="server"  CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 btnAddAddress" ID="btnAddAddress"   Text="Add Address" />
                                                        <asp:Button runat="server"  CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden btnEditAddress" ID="btnEditAddress"  Text="Edit Address" /> 
                                                </div>
                                            </div>
                                           
                                            <!--end::Input-->
                                            <!--begin::Input-->


                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Email</label>
                                                        <asp:TextBox ID="txtemail" runat="server"  CssClass="form-control form-control-solid form-control-lg txtemail" placeholder="Email" ></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg email" name="email" id="email" runat="server" placeholder="Email" >--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-lg-4">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Reference Number</label>
                                                                                             <asp:TextBox ID="txtreferencenumber" runat="server"  CssClass="form-control form-control-solid form-control-lg txtreferencenumber" placeholder="Reference Number" ></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg referencenumber" name="referencenumber" id="referencenumber" runat="server" placeholder="Reference Number" >--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>PACI Number</label>
                                                        <asp:TextBox ID="txtsenderPACI" runat="server"  CssClass="form-control form-control-solid form-control-lg txtsenderPACI" placeholder="PACI Number" ></asp:TextBox>
                                                       <%--<input type="text" class="form-control form-control-solid form-control-lg senderPACI" name="senderPACI" id="senderPACI" runat="server" placeholder="PACI Number" >--%>	
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                            </div>
                                            <div class="row">
                                                 <div class="col-lg-3">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Origin</label>
                                                        <asp:TextBox ID="ddlSenderCountry" runat="server"  CssClass="form-control form-control-solid form-control-lg ddlSenderCountry" placeholder="Origin" Enabled="false"></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg ddlSenderCountry" name="ddlSenderCountry" id="ddlSenderCountry" runat="server" placeholder="Origin" >	--%>
                                                         <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-lg-3">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>State</label>
                                                        <asp:TextBox ID="ddlSenderState" runat="server"  CssClass="form-control form-control-solid form-control-lg ddlSenderState" placeholder="State" Enabled="false" ></asp:TextBox>
                                                        <%--<input type="text"  class="form-control form-control-solid form-control-lg ddlSenderState" name="ddlSenderState" ID="ddlSenderState" runat="server" placeholder="State" disabled>--%>
                                                    
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                 <div class="col-lg-3">
                                                    <!--begin::Select-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>City</label>
                                                        <asp:TextBox ID="ddlSenderCity" runat="server"  CssClass="form-control form-control-solid form-control-lg ddlSenderCity" placeholder="City" Enabled="false" ></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg ddlSenderCity" name="ddlSenderCity" ID="ddlSenderCity" runat="server" placeholder="City" disabled>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Select-->
                                                </div>
                                                <div class="col-lg-3">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Postcode</label>
                                                        <asp:TextBox ID="txtpostcode" runat="server"  CssClass="form-control form-control-solid form-control-lg txtpostcode" placeholder="Postcode" Enabled="false" ></asp:TextBox>
                                     <%--                   <input type="text" class="form-control form-control-solid form-control-lg postcode" name="postcode" ID="postcode" runat="server" placeholder="Postcode" disabled>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                            </div>
                                           

                                            <!--end::Input-->
                                            <div class="row">
                                                
                                                <div class="col-lg-3">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Mobile Number</label>
                                                        <asp:TextBox ID="txtsenderMobile" runat="server"  CssClass="form-control form-control-solid form-control-lg txtsenderMobile" placeholder="Mobile" Enabled="false" ></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg senderMobile" name="" ID="senderMobile" runat="server"  placeholder="Mobile Number" disabled="disabled" >--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>

                                                <div class="col-lg-3">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Alternative/Other No</label>
                                                        <asp:TextBox ID="txtsenderAltCont" runat="server"  CssClass="form-control form-control-solid form-control-lg txtsenderAltCont" placeholder="Alternative/Other No" Enabled="false" ></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg senderAltCont" name="senderAltCont" ID="senderAltCont" runat="server" placeholder="Alternative/Other No"  disabled="disabled">--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                               <%-- <div class="col-xl-12">
                                                    <button type="button" class="btn btn-dark btn-block mr-2">Save</button>
                                                </div>--%>
                                            </div>

                                        </div>

                                        <!--end::Wizard Step 1-->

                                        <!--begin::Wizard Step 2-->

                                           <div class="pb-5" data-wizard-type="step-content" data-wizard-state="current">
                                            <h3 class="mb-10 font-weight-bold text-dark">Enter Your Receiver Details</h3>
                                            <div class="row">
                                                <!--begin::Input-->
                                                <div class="searchwrapper form-group fv-plugins-icon-container col-lg-5">
                                                    <label>Receiver Name</label>
                                                    <asp:TextBox ID="txtReciverKey" runat="server" Wrap="False" CssClass="form-control form-control-solid form-control-lg  txtReciverKey " placeHolder="Receiver Name" onblur="SetReciverdata();"></asp:TextBox>
                                                    <ajaxToolkit:AutoCompleteExtender ID="auReciverKey" runat="server"
                                                        CompletionInterval="100" CompletionListCssClass="completionList"
                                                        CompletionListHighlightedItemCssClass="itemHighlighted"
                                                        CompletionListItemCssClass="listItem" ContextKey="Customer"
                                                        DelimiterCharacters="" EnableCaching="False"
                                                        Enabled="True" MinimumPrefixLength="1" OnClientItemSelected="OnDxSelected"
                                                        ServiceMethod="GetAuto" ServicePath="~/Services/AuotSuggess.asmx"
                                                        TargetControlID="txtReciverKey" UseContextKey="True">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                    <asp:TextBox ID="auReciverKeyV" runat="server" CssClass="auReciverKeyV hidden" Text="0"></asp:TextBox>
                                                    <div class="fv-plugins-message-container"></div>
                                                </div>
                                                <!--end::Input-->
                                                <!--begin::Input-->
                                                <div class="form-group fv-plugins-icon-container col-lg-5">
                                                    <label>Company</label>
                                                    <asp:TextBox ID="txtReciverKeyCompanyName" runat="server"  CssClass="form-control form-control-solid form-control-lg txtReciverKeyCompanyName" placeholder="Reciver Company"  ></asp:TextBox>
                                                    <%--<input type="text" class="form-control form-control-solid form-control-lg txtReciverKeyCompanyName" name="txtReciverKeyCompanyName" ID="txtReciverKeyCompanyName" runat="server" placeholder="Company">--%>
                                                    <div class="fv-plugins-message-container"></div>
                                                </div>
                                                <!--end::Input-->
                                                <!--begin::Input-->
                                                <div class="form-group fv-plugins-icon-container col-lg-2">
                                                    <label>Contact/ Department</label>
                                                    <asp:DropDownList ID="ddlReciverDepartmentKey" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlReciverDepartmentKey">
                                                        <asp:ListItem Value="-1">Select One</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <div class="fv-plugins-message-container"></div>
                                                </div>
                                                <!--end::Input-->
                                            </div>
                                           
                                            <div class="row">
                                                <div class="col-lg-8">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Address</label>
                                                        <asp:DropDownList ID="ddlReciverAddressKey" runat="server" AppendDataBoundItems="true" onchange="return SetReceiverAddressdata();" CssClass="form-control form-control-solid form-control-lg  ddlReciverAddressKey">
                                                         <%--   <asp:ListItem Value="-1">Select One</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                 <div class="col-lg-4 row"  style="margin-top: 26px;">
                                                        <asp:Button runat="server"  CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="Button1" OnClientClick="return Op(14,0);" Text="Add Address" />
                                                        <asp:Button runat="server"  CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden" ID="Button2" OnClientClick="return Op(14,0);" Text="Edit Address" /> 
                                                </div>
                                                
                                            </div>
                   

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Email</label>
                                                        <asp:TextBox ID="txtRemail" runat="server"  CssClass="form-control form-control-solid form-control-lg txtRemail" placeholder="Email" Enabled="false" ></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg Remail" name="Remail" ID="Remail" runat="server" placeholder="Email" disabled>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-lg-4">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Reference Number</label>
                                                        <asp:TextBox ID="txtRreferencenumber" runat="server"  CssClass="form-control form-control-solid form-control-lg txtRreferencenumber" placeholder="Reference Number" Enabled="false" ></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg Rreferencenumber" name="Rreferencenumber" ID="Rreferencenumber" runat="server" placeholder="Reference Number" disabled >--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-lg-4">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>PACI Number</label>
                                                        <asp:TextBox ID="txtRpaci" runat="server"  CssClass="form-control form-control-solid form-control-lg txtRpaci" placeholder="PACI Number" Enabled="false" ></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg Rpaci" name="Rpaci"  ID="Rpaci" runat="server" placeholder="PACI Number" disabled>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <!--begin::Input-->
                                                   <div class="form-group fv-plugins-icon-container">
                                                        <label>Destination</label>
                                                       <asp:TextBox ID="ddlReceiverCountry" runat="server"  CssClass="form-control form-control-solid form-control-lg ddlReceiverCountry" placeholder="Destination" Enabled="false" ></asp:TextBox>
                                                       <%--<input type="text" class="form-control form-control-solid form-control-lg ddlReceiverCountry"  name="ddlReceiverCountry"  ID="ddlReceiverCountry" runat="server"  placeholder="Destination" disabled>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                 <div class="col-lg-3">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>State</label>
                                                        <asp:TextBox ID="ddlReceiverState" runat="server"  CssClass="form-control form-control-solid form-control-lg ddlReceiverState" placeholder="State" Enabled="false" ></asp:TextBox>
                                                         <%--<input type="text" class="form-control form-control-solid form-control-lg ddlReceiverState"  name="ddlReceiverState"  ID="ddlReceiverState" runat="server"  placeholder="State" disabled>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-lg-3">
                                                    <!--begin::Select-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>City</label>
                                                        <asp:TextBox ID="ddlReceiverCity" runat="server"  CssClass="form-control form-control-solid form-control-lg ddlReceiverCity" placeholder="City" Enabled="false" ></asp:TextBox>
                                                         <%--<input type="text" class="form-control form-control-solid form-control-lg ddlReceiverCity"  name="ddlReceiverCity" ID="ddlReceiverCity" runat="server" placeholder="City" disabled>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Select-->
                                                </div>
                                                <div class="col-lg-3">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Postcode</label>
                                                        <asp:TextBox ID="txtRpostcode" runat="server"  CssClass="form-control form-control-solid form-control-lg txtRpostcode" placeholder="Postcode" Enabled="false" ></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg Rpostcode"  name="Rpostcode"  ID="Rpostcode" runat="server" placeholder="Postcode" disabled>--%>
                                                        <span class="form-text text-muted">Please enter your Postcode.</span>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                
                                            </div>
                                           

                                            <!--end::Input-->
                                            <div class="row">
           
                                                <div class="col-lg-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Mobile Number</label>
                                                        <asp:TextBox ID="txtRmobileno" runat="server"  CssClass="form-control form-control-solid form-control-lg txtRmobileno" placeholder="Mobile Number" Enabled="false" ></asp:TextBox>
                                                       <%-- <input type="text" class="form-control form-control-solid form-control-lg Rmobileno" name="Rmobileno"  ID="Rmobileno" runat="server" placeholder="Mobile Number" disabled>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>

                                                <div class="col-lg-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Alternative/Other No</label>
                                                        <asp:TextBox ID="txtRotherno" runat="server"  CssClass="form-control form-control-solid form-control-lg txtRotherno" placeholder="Alternative/Other No" Enabled="false" ></asp:TextBox>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg Rotherno" name="Rotherno" ID="Rotherno" runat="server" placeholder="Alternative/Other No" disabled>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->

                                                </div>
                                            </div>

                                        </div>

                                        <!--end::Wizard Step 2-->
                                        <!--begin::Wizard Actions-->
                                        <div class="d-flex justify-content-between border-top mt-5 pt-10">
                                            <div class="mr-2">
                                                <button type="button" class="btn btn-light-primary font-weight-bolder text-uppercase px-9 py-4" data-wizard-type="action-prev">Previous</button>
                                            </div>
                                            <div>
<%--                                                <button type="button" class="btn btn-success font-weight-bolder text-uppercase px-9 py-4" data-wizard-type="action-submit" id="PShipment">Submit</button>--%>
                                                <button type="button" class="btn btn-primary font-weight-bolder text-uppercase px-9 py-4" data-wizard-type="action-next">Next</button>
                                            </div>
                                        </div>
                                        <!--end::Wizard Actions-->
                                        <div></div><div></div><div></div><div></div>
                                    </div>
                                    <!--end::Wizard Form-->
                                </div>
                            </div>
                            <!--end::Wizard Body-->
                        </div>
                        <!--end::Wizard-->
                    </div>    
        </div>
    </section>
</asp:Content>

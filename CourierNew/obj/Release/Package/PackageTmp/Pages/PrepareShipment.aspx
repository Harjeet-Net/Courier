<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="PrepareShipment.aspx.cs" Inherits="CourierNew.Pages.PrepareShipment" %>

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
            window.parent.$(".homeframetitle").html('Prepare Shipment ');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '800px';

            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }

    </script>
    <!--begin::Page Custom Styles(used by this page)-->
     <link href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="/assets/plugins/Grid/jquery.dataTables.min.js"></script>
    <link href="/assets/css/pages/wizard/wizard-1.css" rel="stylesheet" type="text/css" />
    <!--end::Wizard-->
    <!--begin::Page Scripts(used by this page)-->
    <%--<script src="/assets/js/pages/custom/wizard/wizard-1 - Copy.js"></script>--%>
<%--    <script src="/assets/js/pages/custom/wizard/wizard-1.js"></script>--%>
     <script src="Js/PrepareShipmentEntry.js?ver=2"></script>
<%--     <script src="Js/CustomerMasterEntry.js?ver=2"></script>
    <script src="Js/CustomerAddressEntry.js"></script>--%>
    <!--end::Page Scripts-->
    <!--begin::Wizard-->
    <section class="content">
        <div class="container-fluid bg-white">
            <input type ="hidden" id="tenentID" value=""/>
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
                                <!--end::Wizard Step 2 Nav-->
                                <!--begin::Wizard Step 2 Nav-->
                               <%-- @*data-wizard-state="pending"*@--%>
                                <div class="wizard-step" data-wizard-type="step">
                                    <div class="wizard-label">
                                        <i class="wizard-icon flaticon-list"></i>
                                        <h3 class="wizard-title">3. Shipment Details</h3>
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
                                <!--end::Wizard Step 2 Nav-->
                                <!--begin::Wizard Step 3 Nav-->
                                <div class="wizard-step" data-wizard-type="step" data-wizard-state="pending">
                                    <div class="wizard-label">
                                        <i class="wizard-icon flaticon-responsive"></i>
                                        <h3 class="wizard-title">4. Select Services</h3>
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
                                <!--end::Wizard Step 3 Nav-->
                                <!--begin::Wizard Step 4 Nav-->
                                <div class="wizard-step" data-wizard-type="step" data-wizard-state="pending">
                                    <div class="wizard-label">
                                        <i class="wizard-icon flaticon-truck"></i>
                                        <h3 class="wizard-title">5. Address Confimation</h3>
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
                                <!--end::Wizard Step 4 Nav-->
                                <!--begin::Wizard Step 5 Nav-->
                                <div class="wizard-step" data-wizard-type="step" data-wizard-state="pending">
                                    <div class="wizard-label">
                                        <i class="wizard-icon flaticon-globe"></i>
                                        <h3 class="wizard-title">6. Review and Submit</h3>
                                    </div>
                                    <span class="svg-icon svg-icon-xl wizard-arrow last">
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
                                <!--end::Wizard Step 5 Nav-->
                            </div>
                        </div>
                        <!--end::Wizard Nav-->

                        <%--<div class="">
                            <ul class="nav nav-pills nav-primary bg-white rounded justify-content-center " id="pills-tab" role="tablist">
                                <li class="nav-item nav-item p-3 m-3">
                                    <a class="nav-link font-weight-bolder rounded-right-0 px-8 py-5 active TranType" id="pills-tab-2" data-toggle="pill" href="#kt-pricing-2_content2" aria-expanded="true" aria-controls="kt-pricing-2_content2">Import</a>
                                </li>
                                <li class="nav-item nav-item p-3 m-3">
                                    <a class="nav-link font-weight-bolder rounded-0 px-8 py-5" id="pills-tab-3 TranType" data-toggle="pill" href="#kt-pricing-2_content3" aria-expanded="true" aria-controls="kt-pricing-2_content3">Export</a>
                                </li>
                                <li class="nav-item nav-item p-3 m-3">
                                    <a class="nav-link font-weight-bolder rounded-0 px-8 py-5" id="pills-tab-4 TranType" data-toggle="pill" href="#kt-pricing-2_content" aria-expanded="true" aria-controls="kt-pricing-2_content4">Local</a>
                                </li>
                                <li class="nav-item nav-item p-3 m-3">
                                    <a class="nav-link font-weight-bolder rounded-left-0 px-8 py-5" id="pills-tab-1 TranType" data-toggle="pill" href="#kt-pricing-2_content1" aria-expanded="true" aria-controls="kt-pricing-2_content1">Frieght Forwarding</a>
                                </li>
                            </ul>
                        </div>--%>


                  <div class="hidden">
                      <label>Air Way Bill Key</label>
                      <asp:TextBox runat="server" class="form-control form-control-solid form-control-lg txtAirWayKey" ID="txtAirWayKey" placeholder="0"></asp:TextBox>

                  </div>

                  <div class="form-group fv-plugins-icon-container">
                      <%--<label>Type</label>--%>
                      <asp:DropDownList ID="ddlTranType" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlTranType">
                          <asp:ListItem Value="Import">Import</asp:ListItem>
                          <asp:ListItem Value="Export">Export</asp:ListItem>
                          <asp:ListItem Value="Local">Local</asp:ListItem>
                          <asp:ListItem Value="Frieght Forwarding">Frieght Forwarding</asp:ListItem>
                      </asp:DropDownList>
                      <div class="fv-plugins-message-container"></div>
                  </div>
      
                        <div class="card card-custom example example-compact">
                           <%-- @*End Developer Custom Code*@--%>
                            <!--begin::Wizard Body-->
                            <div class="row justify-content-center my-10 px-8 my-lg-15 px-lg-12">
                                <div class="col-xl-12 col-xxl-12">
                                    <!--begin::Wizard Form-->
                                    <div class="form fv-plugins-bootstrap fv-plugins-framework" id="kt_form">

                                        <!--begin::Wizard Step 1-->

                                        <div class="pb-5" data-wizard-type="step-content" data-wizard-state="current">
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <h3 class="mb-10 font-weight-bold text-dark">Enter Your Shipper Details</h3>
                                                </div>
                                                <div>
                                                    <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 btnAddSender" OnClientClick="return Op(13,0);" ID="btnAddSender" Text="Add Sender" />
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
                                                        <asp:DropDownList ID="ddlAddressKey" runat="server" ClientIDMode="Static" AppendDataBoundItems="true" onchange="return SetAddressdata(0);" CssClass="form-control form-control-solid form-control-lg  ddlAddressKey">
                                                            <asp:ListItem Value="-1">Select One</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                 <div class="col-lg-4 row"  style="margin-top: 26px;">
                                                        <asp:Button runat="server"  CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden btnAddSenderAddress" ID="btnAddSenderAddress"   Text="Add Address" />
                                                        <asp:Button runat="server"  CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden btnEditSenderAddress" ID="btnEditSenderAddress"  Text="Edit Address" /> 
                                                </div>
                                            </div>
                                           
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
                                             <div class="row">
                                                <div class="col-lg-4">
                                                    <h3 class="mb-10 font-weight-bold text-dark">Enter Your Receiver Details</h3>
                                                </div>
                                                <div>
                                                    <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 btnAddReceiver" OnClientClick="return Op(13,0);" ID="btnAddReceiver" Text="Add Receiver" />
                                                </div>
                                            </div>
                                            
                                            <div class="row">
                                                <!--begin::Input-->
                                                <div class="searchwrapper form-group fv-plugins-icon-container col-lg-5">
                                                    <label>Receiver Name</label>
                                                    <asp:TextBox ID="txtReciverKey" runat="server" Wrap="False" CssClass="form-control form-control-solid form-control-lg  txtReciverKey " placeHolder="Receiver Name" onblur="SetReciverdata(0);"></asp:TextBox>
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
                                                        <asp:DropDownList ID="ddlReciverAddressKey" runat="server" ClientIDMode="Static" AppendDataBoundItems="true" onchange="return SetReceiverAddressdata();" CssClass="form-control form-control-solid form-control-lg  ddlReciverAddressKey">
                                                            <asp:ListItem Value="-1">Select One</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                   <div class="col-lg-4 row"  style="margin-top: 26px;">
                                                        <asp:Button runat="server"  CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden btnAddReceiverAddress" ID="btnAddReceiverAddress"   Text="Add Address" />
                                                        <asp:Button runat="server"  CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden btnEditReceiverAddress" ID="btnEditReceiverAddress"  Text="Edit Address" /> 
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

                                        <!--begin::Wizard Step 3-->
                         <%--partialAdmin--%> <%--Faisal Change--%>
                                         <div class="pb-5 " data-wizard-type="step-content">
                                            <!-- #endregion -->
                                            <!--begin::Input-->
                                            <div class="form-group fv-plugins-icon-container">
                                                <label>What is your shipment content?</label><br>
                                                <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                    <label class="btn btn-danger active text-white"> <%-- Faisal Change--%>
                                                        <asp:RadioButton ID="chkDocuments" runat="server" CssClass="chkDocuments text-white"  onclick="ToggleContent();" GroupName="scontent" />Documents
                                                    </label>
                                                    <label class="btn btn-danger text-white">
                                                        <asp:RadioButton ID="chkParcel" runat="server" Checked="true" CssClass="chkParcel "  onclick="ToggleContent();" GroupName="scontent" /> Parcel
                                                    </label>
                                                </div>
                                                
                                            </div>
                                            <!--end::Input-->
                                            <!--begin::Select-->
                                             <div class="row">
                                                 <div class="form-group fv-plugins-icon-container col-lg-8">
                                                     <label>Packaging Type</label>
                                                     <asp:DropDownList ID="ddlPackingTypeKey" runat="server" AppendDataBoundItems="true"  CssClass="form-control form-control-solid form-control-lg  ddlPackingTypeKey">
                                                            <asp:ListItem Value="-1">Select One</asp:ListItem>
                                                        </asp:DropDownList>
                                           
                                                     <div class="fv-plugins-message-container"></div>
                                                 </div>
                                                  <div class="col-lg-4 row"  style="margin-top: 26px;">
                                                        <input type="button"  Class="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 btnAddPacking" ID="btnAddPacking"  Value="Add Packing" />
                                                          
                                                  </div>
                                             </div>
                                             
                                            <!--end::Select-->
                                             <div class="row col-lg-12">
                                                 <%-- Contain Load  Here --%>
                                                 <div id="dvPackingGrid" style="zoom: 0.9;width: 100%;"></div>

                                             </div>

                                             <div class="row">
                                                 <div class="form-group fv-plugins-icon-container col-lg-8">
                                                     <label>You'll need a customs invoice for this shipment-We can create for you!</label><br>
                                                     <div class="btn-group btn-group-toggle" data-toggle="buttons">

                                                         <label class="btn btn-danger active">

                                                             <asp:RadioButton ID="chkCreateInvoice" runat="server" CssClass="chkCreateInvoice text-white" onclick="ToggleInvoice();" GroupName="invoice" />create invoice
                                                 <%--       <input type="radio" ID="chkCreateInvoice" runat="server" CssClass="chkCreateInvoice" name="invoice" value="CreateInvoice" /> Create Invoice--%>
                                                         </label>
                                                         <label class="btn btn-danger">
                                                             <asp:RadioButton ID="chkUploadedInvoice" runat="server" CssClass="chkUploadedInvoice text-white" onclick="ToggleInvoice();" GroupName="invoice" />Uploaded Invoice
                                                             <%--                                                        <input type="radio" ID="chkUploadedInvoice" runat="server" CssClass="chkUploadedInvoice" name="invoice" value="UploadedInvoice" checked /> Use My Invoice--%>
                                                         </label>

                                                     </div>
                                                 </div>
                                                 <div class="col-lg-4 row" style="margin-top: 26px;">
                                                     <input type="button" class="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 btnAddInvoiceDetail" id="btnAddInvoiceDetail" value="Add Invoice" />

                                                 </div>
                                             </div>
                                            
                                          
                                             <div class="row col-lg-12">
                                                 <%-- Contain Load  Here --%>
                                                 <div id="dvInvoiceGrid" style="zoom: 0.9;width: 100%;"></div>

                                             </div>


                                            <div id="invoiceSection" class="invoiceSection" style="display:block">
                                                <div class="cinvoicee" style="display:none">
                                                    <h4 class="mb-10 font-weight-bold text-dark">Describe each unique item in your shipment separately</h4>
                                                </div>

                                                <div class="form-group fv-plugins-icon-container sinvoicee" id="#sinvoice" style="display:none">Faisal Image Change
                                                     <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <div id="idUploadFile1" class="alert" role="alert" style="display: none"></div>
                                                        </div>
                                                        <div class="form-group">

                                                            <input type="file" class="txtAttachment1" id="txtAttachment1" /><br />
                                                            <input type="button" value="upload" id="btnupload1" onclick="UploadFile();" class="btn btn-default btnupload" />
                                                            <asp:TextBox ID="txtAttachPath1" runat="server" CssClass="form-control txtAttachPath1" ></asp:TextBox>
                                                           
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <div id="idUploadFile2" class="alert" role="alert" style="display: none"></div>
                                                        </div>

                                                        <div class="form-group">
                                                            <input type="file" class="txtAttachment2" id="txtAttachment2" /><br />
                                                            <input type="button" value="upload" id="btnupload" onclick="UploadFile2();" class="btn btn-default btnupload" />
                                                            <asp:TextBox ID="txtAttachPath2" runat="server" CssClass="form-control txtAttachPath2" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                               </div>

                                            </div>

                                            <!--end::Input-->
                                            <!--begin::Input-->
                                            <div class="form-group fv-plugins-icon-container">
                                                <label>Summarize the contents of the shipment?</label>
                                                <%--<input type="text" class="form-control form-control-solid form-control-lg txtShipmentDescription" id="txtShipmentDescription" runat="server" name="txtShipmentDescription" placeholder="Shipment Description" >--%>
                                                <asp:TextBox ID="txtShipmentDescription" runat="server" CssClass="form-control form-control-solid form-control-lg txtShipmentDescription" placeholder="Shipment Description"></asp:TextBox>
                                                <div class="fv-plugins-message-container"></div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>What is the purpose of our shipment?</label>
                                                        <asp:DropDownList ID="ddlShipmentPurpose" runat="server" AppendDataBoundItems="true"   CssClass="form-control form-control-solid form-control-lg  ddlShipmentPurpose">
                                                            <asp:ListItem Value="-1">Select One</asp:ListItem>
                                                            <asp:ListItem Value="Purpose 1">Purpose 1</asp:ListItem>
                                                            <asp:ListItem Value="Purpose 2">Purpose 2</asp:ListItem>
                                                            <asp:ListItem Value="Purpose 3">Purpose 3</asp:ListItem>
                                                        </asp:DropDownList>
                                                        
                                                    </div>

                                                </div>
                                                <!--end::Input-->

                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Shipment Reference/Cost Center</label>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg txtShipmentRefrence" id="txtShipmentRefrence" runat="server" name="txtShipmentRefrence" placeholder="Shipment Reference/Cost Center" value="VIC">--%>
                                                        <asp:TextBox ID="txtShipmentRefrence" runat="server" CssClass="form-control form-control-solid form-control-lg txtShipmentRefrence" placeholder="Shipment Reference/Cost Center" ></asp:TextBox>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>


                                            </div>


                                            <h4 class="mb-10 font-weight-bold text-dark">References And Remarks</h4>

                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Invoice Number</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg txtInvoiceNumber" name="txtInvoiceNumber" placeholder="Enter Invoice Number" value="567 454">
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-6">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Carrier</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg txCarrier" name="txCarrier" placeholder="Carrier" value="30Days">
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Add your own reference for this shipment</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg txtOwnShipmentRefNo" name="txtOwnShipmentRefNo" placeholder="Add your own reference for this shipment" value="30Days">
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>

                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Package Marks</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg txtPackageMarks" name="txtPackageMarks" placeholder="Package Marks" value="231">
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Add a receiver reference for this shipment</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg txtEeceiverReferenceNo" name="txtEeceiverReferenceNo" placeholder="Reference Number" value="11324234234">
                                                        <span class="form-text text-muted">Enter receiver reference </span>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-xl-6">
                                                    <!--begin::Input-- FAISAL CHANGE>
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Other Information</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg" name="destination" placeholder="London" value="Extra Details">
                                                        <span class="form-text text-muted">Enter other Info</span>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                            </div>

                                            <h4 class="mb-10 font-weight-bold text-dark">Duties and Taxes</h4>

                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Types Of Export</label>
                                                        <asp:DropDownList ID="ddlExportType" runat="server" AppendDataBoundItems="true"  CssClass="form-control form-control-solid form-control-lg  ddlExportType">
                                                            <asp:ListItem Value="-1">Select a Preferred Delivery Option</asp:ListItem>
                                                            <asp:ListItem Value="permanent">Permanent</asp:ListItem>
                                                            <asp:ListItem Value="temporary">Temporary</asp:ListItem>
                                                            <asp:ListItem Value="return_repair">Return/ Repair</asp:ListItem>
                                                        </asp:DropDownList>
                                                        
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-6">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Customs Of Trade</label>
                                                        <asp:DropDownList ID="ddlCustomerOfTrade" runat="server" AppendDataBoundItems="true"  CssClass="form-control form-control-solid form-control-lg  ddlCustomerOfTrade">
                                                            <asp:ListItem value="cfr"> CFR - COST ANF FREIGHT</asp:ListItem>
                                                            <asp:ListItem value="cif">
                                                                CIF - COST INSURANCE ANF FREIGHT
                                                            </asp:ListItem>
                                                            <asp:ListItem value="cip">
                                                                CIP - CARRIAGE AND INSURNCE PAID TO
                                                            </asp:ListItem>
                                                            <asp:ListItem value="cpt">
                                                                CPT - CARRIAGE PAID TO
                                                            </asp:ListItem>
                                                            <asp:ListItem value="daf">
                                                                DAF- DELIVERED AT FRONTIER
                                                            </asp:ListItem>
                                                            <asp:ListItem value="dap">
                                                                DAP- DELIVERED AT PLACE
                                                            </asp:ListItem>
                                                            <asp:ListItem value="dat">
                                                                DAT - DELIVERED AT TERMINAL
                                                            </asp:ListItem>
                                                            <asp:ListItem value="ddp">
                                                                DDP - DELIVERED DUTY PAID
                                                            </asp:ListItem>
                                                            <asp:ListItem value="ddu">
                                                                DDU- DELIVERED DUTY UNPAID
                                                            </asp:ListItem>
                                                            <asp:ListItem value="deq">
                                                                DEQ - DELIVERED EX QUAY
                                                            </asp:ListItem>
                                                            <asp:ListItem value="des">
                                                                DES- DELIVERED EX SHIP
                                                            </asp:ListItem>
                                                            <asp:ListItem value="dpu">
                                                                DPU - DELIVERED AT PLACE UNLOADED
                                                            </asp:ListItem>
                                                            <asp:ListItem value="exw">
                                                                EXW - EX WORKS
                                                            </asp:ListItem>
                                                            <asp:ListItem value="fas">
                                                                FAS - FREE ALONGSIDE SHIP
                                                            </asp:ListItem>
                                                            <asp:ListItem value="fca">
                                                                FCA - FREE ON BOARD
                                                            </asp:ListItem>
                                                        </asp:DropDownList>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Reason For Export</label>
                                                        <asp:DropDownList ID="ddlReasonForExport" runat="server" AppendDataBoundItems="true"  CssClass="form-control form-control-solid form-control-lg  ddlReasonForExport">
                                                           <asp:ListItem value="-1">Select a Preferred Reason For Export</asp:ListItem>
                                                            <asp:ListItem value="gift">Gift</asp:ListItem>
                                                            <asp:ListItem value="commercial" selected="True">Commercial</asp:ListItem>
                                                            <asp:ListItem value="personal">Personal,Not for sale</asp:ListItem>
                                                            <asp:ListItem value="sample">Sample</asp:ListItem>
                                                            <asp:ListItem value="ror">Return for Repair</asp:ListItem>
                                                            <asp:ListItem value="rar">Return after Repair</asp:ListItem>
                                                       
                                                        </asp:DropDownList>
                                                       
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>

                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Terms Of Payment</label>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg txtPaymentTerms" id="txtPaymentTerms" runat="server" name="txtPaymentTerms" placeholder="Payment Terms" >--%>
                                                        <asp:TextBox ID="txtPaymentTerms" runat="server" CssClass="form-control form-control-solid form-control-lg txtPaymentTerms" placeholder="Terms Of Payment" ></asp:TextBox>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Place Of Destinations</label>
                                                        <%--<input type="text" class="form-control form-control-solid form-control-lg txtPlaceOfDestination" id="txtPlaceOfDestination" runat="server" name="txtPlaceOfDestination" placeholder="Place Of Destinations" >--%>
                                                        <asp:TextBox ID="txtPlaceOfDestination" runat="server" CssClass="form-control form-control-solid form-control-lg txtPlaceOfDestination" placeholder="Place Of Destinations" ></asp:TextBox>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                            </div>


                                             <h4 class="mb-10 font-weight-bold text-dark">Billing</h4>

                                            <div class="row">
                                                <div class="col-xl-6 row" style="margin-right: 9px;">
                                                    <label class="font-weight-bolder" style="margin-left: 14px;">Payment Type:</label>
                                                    <div class="form-group fv-plugins-icon-container col-xl-5" style="margin-left: 21px;">
                                                        <asp:DropDownList ID="ddlPaymentType" runat="server" AppendDataBoundItems="true"  CssClass="form-control form-control-solid   ddlExportType w-100" style="margin-top: -12px;">
                                                            <asp:ListItem Value="-1">Select Payment Type</asp:ListItem>
                                                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                            <asp:ListItem Value="Credit">Credit</asp:ListItem>
                                                            <asp:ListItem Value="COD">COD</asp:ListItem>
                                                        </asp:DropDownList>
                                                        
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-6">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label class="font-weight-bolder">Freight Charges:</label>
                                                        <asp:label ID="txtFreightCharges" runat="server"  CssClass="txtFreightCharges numeric" Text="0" placeholder="Freight Charges"  ></asp:label>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label class="font-weight-bolder">Chargable Weight:</label>
                                                        <asp:label ID="txtChargableWeight" runat="server"  CssClass="txtChargableWeight numeric" Text="0" placeholder="Chargable Charges"  ></asp:label>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>

                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label class="font-weight-bolder">Consignment Value:</label>
                  <asp:label ID="TextBox2" runat="server"  CssClass="txtConsignmentValue numeric" placeholder="ConsignmentValue" Text="0" ></asp:label>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                
                                            </div>
                                             <div class="row">
                                                <div class="col-xl-6">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label class="font-weight-bolder">Insurance Amount:</label>
                                                        <asp:label ID="txtInsuranceAmount" runat="server"  CssClass="txtInsuranceAmount numeric" Text="0" placeholder="InsuranceAmount"  ></asp:label>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>

                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label class="font-weight-bolder">Other Charges:</label>
                  <asp:label ID="txtOtherCharges" runat="server"  CssClass="txtOtherCharges numeric" placeholder="Other Charges" Text="0"  ></asp:label>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                
                                            </div>
                                             <div class="row">
                                                <div class="col-xl-6">
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label class="font-weight-bolder">Delivery Charges:</label>
                                                        <asp:label ID="txtDeliveryCharges" runat="server"  CssClass="txtDeliveryCharges numeric" Text="0" placeholder="Delivery Charges"  ></asp:label>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                </div>

                                             
                                            </div>


                                           <%-- @*Invoice*@--%> <%--Faisal Change--%>

                                           <%-- <div id="Packagelisthidden" style="visibility:hidden">
                                                <div class="row" id="package_hidden">
                                                    <div class="col-xl-3">
                                                        <!--begin::Input-->
                                                        <div class="form-group fv-plugins-icon-container">
                                                            <select name="" class="form-control form-control-solid form-control-lg">
                                                                <option value="">Select</option>
                                                                <option value="15">Box 15kg</option>
                                                                <option value="B2">Box2(Flat)</option>
                                                                <option value="B3">Box3</option>
                                                                <option value="B4">Box4</option>
                                                            </select>
                                                        </div>
                                                        <!--end::Input-->
                                                    </div>
                                                    <div class="col-xl-1">
                                                        <!--begin::Input-->
                                                        <div class="form-group fv-plugins-icon-container">
                                                            <input type="number" class="form-control form-control-solid form-control-lg quantity" id="quantity0" name="quantity" value="0">
                                                            <span class="form-text text-muted"></span>
                                                            <div class="fv-plugins-message-container"></div>
                                                        </div>
                                                        <!--end::Input-->
                                                    </div>
                                                    <div class="col-xl-2">
                                                        <!--begin::Input-->
                                                        <div class="form-group fv-plugins-icon-container">
                                                            <div class="input-group">
                                                                <input type="number" class="form-control form-control-solid form-control-lg weight" value="0" aria-label="Text input with dropdown button">
                                                                <div class="input-group-append">
                                                                    <select name="weight" class="btn btn-secondary dropdown-toggle">
                                                                        <option value="kg">KG</option>
                                                                        <option value="lb">LB</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!--end::Input-->
                                                    </div>
                                                    <div class="col-xl-4">
                                                        <div class="form-group fv-plugins-icon-container">
                                                            <div style="padding-left:35px">
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-lg-3 offset-lg-1">
                                                                    <!--begin::Input-->
                                                                    <div class="form-group fv-plugins-icon-container">
                                                                        <input type="number" class="form-control form-control-solid form-control-lg" name="width" placeholder="Package Width" value="0">
                                                                        <span class="form-text text-muted">@*Please enter your Package Width in CM.*@</span>
                                                                        <div class="fv-plugins-message-container"></div>
                                                                    </div>
                                                                    <!--end::Input-->
                                                                </div>
                                                                <p>X</p>
                                                                <div class="col-lg-3">
                                                                    <!--begin::Input-->
                                                                    <div class="form-group fv-plugins-icon-container">
                                                                        <input type="number" class="form-control form-control-solid form-control-lg" name="height" placeholder="Package Height" value="0">
                                                                        <span class="form-text text-muted">@*Please enter your Package Height in CM.*@</span>
                                                                        <div class="fv-plugins-message-container"></div>
                                                                    </div>
                                                                    <!--end::Input-->
                                                                </div>
                                                                <p>X</p>
                                                                <div class="col-lg-3">
                                                                    <!--begin::Input-->
                                                                    <div class="form-group fv-plugins-icon-container">
                                                                        <input type="number" class="form-control form-control-solid form-control-lg" name="packagelength" placeholder="Package Length" value="0">
                                                                        <span class="form-text text-muted">@*Please enter your Package Length*@</span>
                                                                        <div class="fv-plugins-message-container"></div>
                                                                    </div>
                                                                    <!--end::Input-->
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-xl-2">
                                                        <div style="text-align:center">
                                                        </div>
                                                        <div class="row">
                                                            <!--begin::Input-->
                                                            <div class="col-lg-6 col-md-12 col-sm-12 ">
                                                                <!--begin::Input-->
                                                                <div class="form-group fv-plugins-icon-container">
                                                                    <div class="topbar-item mr-4">
                                                                        <div class="btn font-weight-bolder btn-sm btn-light-success px-5 copypackage" id="0"> <i class="flaticon2-pie-chart"></i><span>Copy</span></div>
                                                                    </div>
                                                                </div>
                                                                <!--end::Input-->
                                                            </div>
                                                            <div class="col-lg-6  col-md-12 col-sm-12">
                                                                <!--begin::Input-->
                                                                <div class="form-group fv-plugins-icon-container">
                                                                    <div class="topbar-item mr-4">
                                                                        <div class="btn font-weight-bolder btn-sm btn-danger px-5 removepackage" id="0"> <i class="flaticon2-pie-chart"></i> Delete</div>
                                                                    </div>
                                                                </div>
                                                                <!--end::Input-->
                                                            </div>

                                                        </div>

                                                        <!--end::Input-->
                                                    </div>
                                                </div>
                                            </div>--%>

                                        </div>
                                        <!--end::Wizard Step 3-->

                                        <!--begin::Wizard Step 4-->
                                        <div class="pb-5" data-wizard-type="step-content">
                                            <h4 class="mb-10 font-weight-bold text-dark">Select your Services</h4>
                                            <!--begin::Select-->
                                            <!-- #region Prefered Pickup -->

                                            <div class="form-group fv-plugins-icon-container">
                                                <label>Prefered Pickup Type</label>
                                                <asp:DropDownList ID="ddlPickupType" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlPickupType">
                                                    <asp:ListItem Value="-1">Select a Service Type asp:ListItem</asp:ListItem>
                                               
                                                    <asp:ListItem Value="pickup" Selected="True">Pickup</asp:ListItem>
                                                    <asp:ListItem Value="delivery">Delivery</asp:ListItem>
                                                    <asp:ListItem Value="basic">Both pickup and delivery</asp:ListItem>
                                                </asp:DropDownList>

                                                <div class="fv-plugins-message-container"></div>
                                            </div>
                                            <!--end::Select-->
                                            <!--begin::Select-->
                                            <div class="form-group fv-plugins-icon-container">
                                                <label>Preferred Pickup Window</label>
                                                <asp:DropDownList ID="ddlPickupWindow" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlPickupWindow">
                                                    <asp:ListItem Value="-1">Select a Preferred Delivery </asp:ListItem>
                                                    <asp:ListItem Value="morning" Selected="True">Morning Delivery (8:00AM - 11:00AM)</asp:ListItem>
                                                    <asp:ListItem Value="afternoon">Afternoon Delivery (11:00AM - 3:00PM)</asp:ListItem>
                                                    <asp:ListItem Value="evening">Evening Delivery (3:00PM - 7:00PM)</asp:ListItem>
                                                </asp:DropDownList>

                                                <div class="fv-plugins-message-container"></div>
                                            </div>
                                            <!--end::Select-->
                                            <!-- #endregion -->
                                            <!-- #region Prefered Delivery -->
                                            <hr />
                                            <div class="form-group fv-plugins-icon-container">
                                                <label>Prefered Delivery Type</label>
                                                <asp:DropDownList ID="ddlDeliverytype" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlDeliverytype">
                                                    <asp:ListItem Value="-1">Select a Service Type </asp:ListItem>
                                                    <asp:ListItem Value="pickup" Selected="True">Pickup</asp:ListItem>
                                                    <asp:ListItem Value="delivery">Delivery</asp:ListItem>
                                                    <asp:ListItem Value="basic">Both pickup and delivery</asp:ListItem>
                                                </asp:DropDownList>
                                               
                                                <div class="fv-plugins-message-container"></div>
                                            </div>
                                            <!--end::Select-->
                                            <!--begin::Select-->
                                            <div class="form-group fv-plugins-icon-container">
                                                <label>Preferred Delivery Window</label>
                                                <asp:DropDownList ID="ddlDeliveryWindow" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlDeliveryWindow">
                                                    <asp:ListItem Value="-1">Select a Preferred Delivery </asp:ListItem>
                                                    <asp:ListItem Value="morning" Selected="True">Morning Delivery (8:00AM - 11:00AM)</asp:ListItem>
                                                    <asp:ListItem Value="afternoon">Afternoon Delivery (11:00AM - 3:00PM)</asp:ListItem>
                                                    <asp:ListItem Value="evening">Evening Delivery (3:00PM - 7:00PM)</asp:ListItem>
                                                </asp:DropDownList>

                                                <div class="fv-plugins-message-container"></div>
                                            </div>
                                            <!--end::Select-->
                                            <!-- #endregion -->

                                        </div>
                                        <!--end::Wizard Step 4-->
                                        <!--begin::Wizard Step 5-->

                                        <div class="pb-5" data-wizard-type="step-content" data-wizard-state="current">
                                            <h3 class="mb-10 font-weight-bold text-dark">Enter Your Address Confirmation Details</h3>

                                            <div class="form-group fv-plugins-icon-container">
                                                <label>Shipment Type</label><br>
                                                <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                    <label class="btn btn-danger active">
                                                        <input type="radio" name="shipmenttype" value="PickUp" checked="checked" /> Pick Up
                                                    </label>
                                                    <label class="btn btn-danger">
                                                        <input type="radio" name="shipmenttype" value="Delivery" /> Delivery
                                                    </label>
                                                </div>
                                            </div>

                                            <!--begin::Input-->
                                            <div class="form-group fv-plugins-icon-container">
                                                <label>Name</label>
                                                <input type="text" class="form-control form-control-solid form-control-lg" name="name" placeholder="Name" value="Name">
                                                <span class="form-text text-muted">Please enter your Name.</span>
                                                <div class="fv-plugins-message-container"></div>
                                            </div>
                                            <!--end::Input-->
                                            <!--begin::Input-->
                                            <div class="form-group fv-plugins-icon-container">
                                                <label>Company</label>
                                                <input type="text" class="form-control form-control-solid form-control-lg" name="company" placeholder="Company" value="Company">
                                                <span class="form-text text-muted">Please enter your Company.</span>
                                                <div class="fv-plugins-message-container"></div>
                                            </div>
                                            <!--end::Input-->
                                            <!--begin::Input-->
                                            <div class="orm-group fv-plugins-icon-container">
                                                <label>Contact/ Department</label>
                                                <input type="text" class="form-control form-control-solid form-control-lg" name="contact_department" placeholder="Contact / Department" value="Department">
                                                <span class="form-text text-muted">Please enter your Contact/ Department.</span>
                                                <div class="fv-plugins-message-container"></div>
                                            </div>
                                            <!--end::Input-->
                                            <!--begin::Input-->
                                            <div class="form-group">
                                                <label>Address Line 1</label>
                                                <input type="text" class="form-control form-control-solid form-control-lg" name="address1" placeholder="Address Line 1" value="Address Line 1">
                                                <span class="form-text text-muted">Please enter your Address1.</span>
                                            </div>
                                            <!--end::Input-->
                                            <!--begin::Input-->
                                            <div class="form-group">
                                                <label>Address Line 2</label>
                                                <input type="text" class="form-control form-control-solid form-control-lg" name="address2" placeholder="Address Line 2" value="Address Line 2">
                                                <span class="form-text text-muted">Please enter your Address2.</span>
                                            </div>
                                            <!--end::Input-->
                                            <!--begin::Input-->
                                            <div class="form-group">
                                                <label>Address Line 3</label>
                                                <input type="text" class="form-control form-control-solid form-control-lg" name="address3" placeholder="Address Line 3" value="Address Line 3">
                                                <span class="form-text text-muted">Please enter your Address3.</span>
                                            </div>

                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Email</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg" name="email" placeholder="Email" value="riyaz@123">
                                                        <span class="form-text text-muted">Please enter your Email.</span>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Reference Number</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg" name="referencenumber" placeholder="Reference NUmber" value="Reference Number">
       <%--                                                 <span class="form-text text-muted">Please enter your Reference Number.</span>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Postcode</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg" name="postcode" placeholder="Postcode" value="300">
                                               <%--         <span class="form-text text-muted">Please enter your Postcode.</span>--%>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>City</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg" name="city" placeholder="City" value="Melbourne">
                                                        <span class="form-text text-muted">Please enter your City1.</span>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>State</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg" name="state" placeholder="State" value="VIC">
                                                        <span class="form-text text-muted">Please enter your State.</span>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-xl-6">
                                                    <!--begin::Select-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Destination</label>
                                                        <select name="country" class="form-control form-control-solid form-control-lg">
                                                            @foreach (var item in codes)
                                                            {
                                                                <option value="@item.ID">@item.Country_name</option>
                                                            }
                                                        </select>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Select-->
                                                </div>
                                            </div>

                                            <!--end::Input-->
                                            <div class="row">
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>PACI Number</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg" name="phoneno" placeholder="Postcode" value="for local only">
                                                        <span class="form-text text-muted">Please enter your Phone No.</span>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Phone No</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg" name="phoneno" placeholder="Postcode" value="3000">
                                                        <span class="form-text text-muted">Please enter your Phone No.</span>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>
                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Mobile Number</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg" name="mobileno" placeholder="Mobile Number" value="1111111111">
                                                        <span class="form-text text-muted">Please enter your Mobile Number.</span>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>

                                                <div class="col-xl-6">
                                                    <!--begin::Input-->
                                                    <div class="form-group fv-plugins-icon-container">
                                                        <label>Alternative/Other No</label>
                                                        <input type="text" class="form-control form-control-solid form-control-lg" name="otherno" placeholder="Alternative/Other No" value="12121">
                                                        <span class="form-text text-muted">Please enter your Phone No.</span>
                                                        <div class="fv-plugins-message-container"></div>
                                                    </div>
                                                    <!--end::Input-->
                                                </div>




                                                <div class="col-xl-12">
                                                  <%--  <button type="button" class="btn btn-dark btn-block mr-2">Save</button>--%>
                                                </div>
                                            </div>

                                        </div>



                                        <!--end::Wizard Step 5-->
                                        <!--begin::Wizard Step 6-->
                                        <div class="pb-5" data-wizard-type="step-content">
                                            <!--begin::Section-->
                                            <h4 class="mb-10 font-weight-bold text-dark">Review your Details and Submit</h4>
                                            <h6 class="font-weight-bolder mb-3">Current Address:</h6>
                                            <div class="text-dark-50 line-height-lg">
                                                <div>Company</div>
                                                <div>Address Line 2</div>
                                                <div>Melbourne 3000, VIC, Australia</div>
                                            </div>
                                            <div class="separator separator-dashed my-5"></div>
                                            <!--end::Section-->
                                            <!--begin::Section-->
                                            <h6 class="font-weight-bolder mb-3">Delivery Details:</h6>
                                            <div class="text-dark-50 line-height-lg">
                                                <div>Package: Complete Workstation (Monitor, Computer, Keyboard &amp; Mouse)</div>
                                                <div>Weight: 25kg</div>
                                                <div>Dimensions: 110cm (w) x 90cm (h) x 150cm (L)</div>
                                            </div>
                                            <div class="separator separator-dashed my-5"></div>
                                            <!--end::Section-->
                                            <!--begin::Section-->
                                            <h6 class="font-weight-bolder mb-3">Delivery Service Type:</h6>
                                            <div class="text-dark-50 line-height-lg">
                                                <div>Overnight Delivery with Regular Packaging</div>
                                                <div>Preferred Morning (8:00AM - 11:00AM) Delivery</div>
                                            </div>
                                            <div class="separator separator-dashed my-5"></div>
                                            <!--end::Section-->
                                            <!--begin::Section-->
                                            <h6 class="font-weight-bolder mb-3">Delivery Address:</h6>
                                            <div class="text-dark-50 line-height-lg">
                                                <div>Company</div>
                                                <div>Address Line 2</div>
                                                <div>Preston 3072, VIC, Australia</div>
                                            </div>
                                            <!--end::Section-->
                                        </div>
                                        <!--end::Wizard Step 6-->
                                        <!--begin::Wizard Actions-->
                                        <div class="d-flex justify-content-between border-top mt-5 pt-10">
                                            <div class="mr-2">
                                                <button type="button" class="btn btn-light-primary font-weight-bolder text-uppercase px-9 py-4" data-wizard-type="action-prev">Previous</button>
                                            </div>
                                            <div>
                                                <button type="button" class="btn btn-success font-weight-bolder text-uppercase px-9 py-4" data-wizard-type="action-submit" id="PShipment">Submit</button>
                                                <button type="button" class="btn btn-primary font-weight-bolder text-uppercase px-9 py-4" data-wizard-type="action-next">Save & Next</button>
                                            </div>
                                        </div>
                                        <!--end::Wizard Actions-->
                                        <div></div><div></div><div></div><div></div>
                                    </div>
                                    <!--end::Wizard Form-->
                                </div>
                            </div>
                            <!--end::Wizard Body-->
                            
                            <!--end::Wizard-->
                        </div>
                        <!--end::Wizard-->
                    </div>
        </div>
     
    </section>
</asp:Content>

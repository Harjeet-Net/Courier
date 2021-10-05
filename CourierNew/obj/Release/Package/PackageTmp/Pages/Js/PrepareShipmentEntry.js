"use strict";



// Class definition
var KTWizard1 = function () {
    // Base elements
    var _wizardEl;
    var _formEl;
    var _wizardObj;
    var _validations = [];

    // Private functions
    var _initValidation = function () {
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        // Step 1
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                fields: {
                    

                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    // Bootstrap Framework Integration
                    bootstrap: new FormValidation.plugins.Bootstrap({
                        //eleInvalidClass: '',
                        eleValidClass: '',
                    })
                }
            }
        ));

        //// Step 2
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                fields: {
        
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    // Bootstrap Framework Integration
                    bootstrap: new FormValidation.plugins.Bootstrap({
                        //eleInvalidClass: '',
                        eleValidClass: '',
                    })
                }
            }
        ));

        //// Step 3
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                fields: {
        
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    // Bootstrap Framework Integration
                    bootstrap: new FormValidation.plugins.Bootstrap({
                        //eleInvalidClass: '',
                        eleValidClass: '',
                    })
                }
            }
        ));

        // Step 4
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                    fields: {
                        
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger(),
                        // Bootstrap Framework Integration
                        bootstrap: new FormValidation.plugins.Bootstrap({
                            //eleInvalidClass: '',
                            eleValidClass: '',
                        })
                    }
            }
        ));
        //// Step 5
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                //fields: {
                
                
                //},
                //plugins: {
                //    trigger: new FormValidation.plugins.Trigger(),
                //    // Bootstrap Framework Integration
                //    bootstrap: new FormValidation.plugins.Bootstrap({
                //        //eleInvalidClass: '',
                //        eleValidClass: '',
                //    })
                //}
            }
        ));
    }

    var _initWizard = function () {
        // Initialize form wizard
        _wizardObj = new KTWizard(_wizardEl, {
            startStep: 1, // initial active step number
            clickableSteps: false  // allow step clicking
        });

        // Validation before going to next page
        _wizardObj.on('change', function (wizard) {
            if (wizard.getStep() > wizard.getNewStep()) {
                return; // Skip if stepped back
            }

            // Validate form before change wizard step
            var validator = _validations[wizard.getStep() - 1]; // get validator for currnt step

            if (validator) {
                validator.validate().then(async function (status) {
                    var ErrorMsg = ValidatePage(wizard.getStep());
                    if (ErrorMsg.length==0) {
                        //save & next functionality goes here
                        await SaveformValues(wizard.getStep());
                        wizard.goTo(wizard.getNewStep());
                        KTUtil.scrollTop();
                    } else {
                        Swal.fire("Pelase Enter Data.", ErrorMsg, "warning").then(function () {
                            KTUtil.scrollTop();
                        });
                    }
                });
            }

            return false;  // Do not change wizard step, further action will be handled by he validator
        });

        // Change event
        _wizardObj.on('changed', function (wizard) {
            KTUtil.scrollTop();
        });


        // Submit event
        _wizardObj.on('submit', function (wizard) {
            Swal.fire({
                text: "All is good! Please confirm the form submission.",
                icon: "success",
                showCancelButton: true,
                buttonsStyling: false,
                confirmButtonText: "Yes, submit!",
                cancelButtonText: "No, cancel",
                customClass: {
                    confirmButton: "btn font-weight-bold btn-primary",
                    cancelButton: "btn font-weight-bold btn-default"
                }
            }).then(function (result) {
                if (result.value) {
                    //_formEl.submit(); // Submit form
                    //Customajax
                    //var data = JSON.stringify($('#kt_form').serialize()); 
                    var data = ($('#kt_form').serialize());
                    $.ajax(
                        {
                            type: 'POST',
                            dataType: 'json',
                            url: '/Home/PrepareShipment',
                            data: data,
                            success:
                                function (response) {
                                    // Generate HTML table.  
                                    convertJsonToHtmlTable(JSON.parse(response), $("#TableId"));
                                },
                            error:
                                function (response) {
                                    //alert("Error: " + response);
                                }
                        });
                    //Customajax
                } else if (result.dismiss === 'cancel') {
                    Swal.fire({
                        text: "Your form has not been submitted!.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-primary",
                        }
                    });
                }
            });
        });
    }

    return {
        // public functions
        init: function () {
            _wizardEl = KTUtil.getById('kt_wizard');
            _formEl = KTUtil.getById('kt_form');

            _initValidation();
            _initWizard();
        }
    };
}();

jQuery(document).ready(function () {
    KTWizard1.init();

    //$(".ddlAddressKey").empty();
    //$(".ddlAddressKey").append($("<option></option>").val('-1').html('Select One'));
    
    //$(".ddlReciverAddressKey").empty();
    //$(".ddlReciverAddressKey").append($("<option></option>").val('-1').html('Select One'));
});





//  1    OUR CODE SENSE SOftech  //

//Create Invoce/Upload Invoice 

function ToggleInvoice() {

    if ($("#CP1_chkUploadedInvoice").prop("checked")) {

        $(".sinvoicee").css({ "display": "block" });
        $(".cinvoicee").css({ "display": "none" });//Faisal Change

    } else {
        $(".sinvoicee").css({ "display": "none" });
        $(".cinvoicee").css({ "display": "block" });
    }
}

//Start Content Seaction/ invoiceSection
function ToggleContent() {

    if ($("#CP1_chkParcel").prop("checked")) {
        $(".invoiceSection").css({ "display": "block" });
       

    } else {
        $(".invoiceSection").css({ "display": "none" });
    }
}


//START FILL SENDER
function SetCustomerdata() {
    //debugger

    var iCustomerkey = TryParseInt($(".auCustomerKeyV").val());
        $(".btnAddSenderAddress").addClass("hidden");
        $(".btnAddSenderAddress").attr("onclick", "return Op1(14,0," + iCustomerkey+ ")");

        $(".ddlAddressKey").empty();
        if (iCustomerkey > 0) {
            $(".btnAddSenderAddress").removeClass("hidden");
            //$(".btnAddSenderAddress").attr("onclick", "return Op(14, " + iCustomerkey + ")");
                $.ajax({
        type: "POST",
        url: "../Services/AuotSuggess.asmx/CustomerDetailGet",
        data: "{iId: " + iCustomerkey + " }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $(".txtemail").val(data.d.EmailId);
            $(".txtreferencenumber").val(data.d.ReferenceNumber);
            $(".txtsenderPACI").val(data.d.PaciNumber);
            $(".txtsenderMobile").val(data.d.MobileNumber);
            $(".txtsenderAltCont").val(data.d.AlternateNumber);
            $("#CP1_txtCompanyName").val($("#CP1_txtCustomerKey").val());
            $("#CP1_ddlDepartmentKey").val("1120");

            $.each(data.d.LstAddress, function (data, value) {

                $(".ddlAddressKey").append($("<option></option>").val(value.ComboID).html(value.ComboValue));
            })
            if ($(".ddlAddressKey").val() > 0) {
                $("#tenentID").val(data.d.TenentID);
                SetAddressdata(data.d.TenentID);
            }
            else {
                $(".ddlAddressKey").empty();
                $(".ddlAddressKey").append($("<option></option>").val('-1').html('Select One'));
            }

        },
        error: function (e) {
            $("#divError").removeClass('hide');
            $("#dvMsg").html(e.responseText);
            $('html, body').animate({ scrollTop: 0 }, 'slow');
        }
    });
            }
        else {
            return false;
        }
   
}

function SetAddressdata(tenentID) {
    if (tenentID == 0 || tenentID == undefined) {
        tenentID = $("#tenentID").val();
    }
    var iCustomerkey =parseInt( $(".ddlAddressKey option:selected").val());
        $(".btnEditSenderAddress").addClass("hidden");

        if (iCustomerkey > 0) {
            $(".btnEditSenderAddress").removeClass("hidden");
            $(".btnEditSenderAddress").attr("onclick", "return Op(14, " + iCustomerkey + ")");
        $.ajax({
            type: "POST",
            url: "../Services/AuotSuggess.asmx/AddressDetailGet",
            //data: "{iaddresskey: " + iCustomerkey + " }",
            data: "{iaddresskey: " + iCustomerkey + ",tenentId:" + tenentID + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //$(".ddlSenderCountry").val(data.d.CountryName);
                //$(".ddlSenderState").val(data.d.StateName);
                //$(".ddlSenderCity").val(data.d.CityName);
                $("#CP1_ddlSenderCountry").val(data.d.Country);
                $("#CP1_ddlSenderState").val(data.d.State);
                $("#CP1_ddlSenderCity").val(data.d.City);
                $("#CP1_txtpostcode").val(data.d.PostCode);


            },
            error: function (e) {
                $("#divError").removeClass('hide');
                $("#dvMsg").html('There is an error retriving record.AdviceDetailItemRateGet');
                $('html, body').animate({ scrollTop: 0 }, 'slow');
            }
        });
    }
    else {
        return false;
    }


}
//END FILL SENDER

//START FILL Receiver
function SetReciverdata() {
    //debugger

    var iReciverKey = TryParseInt($(".auReciverKeyV").val());
    $(".btnAddReceiverAddress").addClass("hidden");
    $(".btnAddReceiverAddress").attr("onclick", "return Op1(14,0," + iReciverKey + ")");

    $(".ddlReciverAddressKey").empty();
    if (iReciverKey > 0) {
        $(".btnAddReceiverAddress").removeClass("hidden");
            //$(".btnAddReceiverAddress").attr("onclick", "return Op(14, " + iReciverKey + ")");
    $.ajax({
        type: "POST",
        url: "../Services/AuotSuggess.asmx/CustomerDetailGet",
        data: "{iId: " + iReciverKey + " }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $(".txtRemail").val(data.d.EmailId);
            $(".txtRreferencenumber").val(data.d.ReferenceNumber);
            $(".txtRpaci").val(data.d.PaciNumber);
            $(".txtRmobileno").val(data.d.MobileNumber);
            $(".txtRotherno").val(data.d.AlternateNumber);
            $("#CP1_txtCompanyName").val($("#CP1_txtReceiverKey").val());
            $("#CP1_ddlDepartmentKey").val("1120");
            $.each(data.d.LstAddress, function (data, value) {

                $(".ddlReciverAddressKey").append($("<option></option>").val(value.ComboID).html(value.ComboValue));
            })
            if ($(".ddlReciverAddressKey").val() > 0) {
                $("#tenentID").val(data.d.TenentID);
                SetReceiverAddressdata(data.d.TenentID);
            }
            else {
                $(".ddlReciverAddressKey").empty();
                $(".ddlReciverAddressKey").append($("<option></option>").val('-1').html('Select One'));
            }

        },
        error: function (e) {
            $("#divError").removeClass('hide');
            $("#dvMsg").html(e.responseText + 'There is an error retriving record.Receiver Data Get');
            $('html, body').animate({ scrollTop: 0 }, 'slow');
        }
    });
    }
    else {
        return false;
    }
}

function SetReceiverAddressdata(tenentID) {

    if (tenentID == 0 || tenentID == undefined) {
        tenentID = $("#tenentID").val();
    }
    var iReceiverAddress = $(".ddlReciverAddressKey option:selected").val();
    $(".btnEditReceiverAddress").addClass("hidden");
    if (iReceiverAddress > 0) {
        $(".btnEditReceiverAddress").removeClass("hidden");
        $(".btnEditReceiverAddress").attr("onclick", "return Op(14, " + iReceiverAddress + ")");
        $.ajax({
            type: "POST",
            url: "../Services/AuotSuggess.asmx/AddressDetailGet",
            //data: "{iaddresskey: " + iReceiverAddress + " }",
            data: "{iaddresskey: " + iReceiverAddress + ",tenentId:" + tenentID + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //$(".ddlReceiverCountry").val(data.d.CountryName);
                //$(".ddlReceiverState").val(data.d.StateName);
                //$(".ddlReceiverCity").val(data.d.CityName);
                //$(".txtRpostcode").val(data.d.PostCode);
                $("#CP1_ddlReceiverCountry").val(data.d.Country);
                $("#CP1_dddlReceiverState").val(data.d.State);
                $("#CP1_ddlReceiverCity").val(data.d.City);
                $("#CP1_txtpostcode").val(data.d.PostCode);


            },
            error: function (e) {
                $("#divError").removeClass('hide');
                $("#dvMsg").html('There is an error retriving record.Receiver Address Get');
                $('html, body').animate({ scrollTop: 0 }, 'slow');
            }
        });
    }
    else {
        return false;
    }


}
//END FILL Receiver
function ValidatePage(step) {
    var message = '';
    if (step == 1) {
        var CustomerKey = $(".txtCustomerKey").val().trim();
        var CustomerKeyV = TryParseInt($(".auCustomerKeyV").val());

        if (CustomerKey.length == "" || CustomerKeyV == 0) {
            message += "<li>Please Select Customer.</li>";
        }
        if ($(".ddlDepartmentKey option:selected").val() == "-1") {
            message += "<li>Please Select Department.</li>";
        }
        if ($(".txtCompanyName").val().trim() == "") {
            message += "<li> Plese Enter Company Name.</li>";
        }
        if ($(".ddlDepartmentKey option:selected").val() == "-1") {
            message += "<li>Please Select Department.</li>";
        }
        if ($(".ddlAddressKey option:selected").val() == "-1") {
            message += "<li>Please Select Address/Save In Customer Master.</li>";
        }
        if ($(".txtemail").val().trim() == "") {
            message += "<li>Please Enter Email.</li>";
        }
        //if ($(".txtreferencenumber").val().trim() == "") {
        //    message += "<li>Please Enter Reference Number.</li>";
        //}
        //if ($(".txtsenderPACI").val().trim() == "") {
        //    message += "<li>Please Enter PACI Number.</li>";
        //}
        if ($(".ddlSenderCountry").val().trim() == "") {
            message += "<li>Please Enter Origin.</li>";
        }
        if ($(".ddlSenderState").val().trim() == "") {
            message += "<li>Please Enter State.</li>";
        }
        if ($(".ddlSenderCity").val().trim() == "") {
            message += "<li>Please Enter City .</li>";
        }
        //if ($(".txtpostcode").val().trim() == "") {
        //    message += "<li>Please Enter Postcode.</li>";
        //}
        if ($(".txtsenderMobile").val().trim() == "") {
            message += "<li>Please Enter Mobile.</li>";
        }
        //if ($(".txtsenderAltCont").val().trim() == "") {
        //    message += "<li>Please Enter Alternative/Other No.</li>";
        //}
     
      
    }
    else if (step == 2) {
        var tReciverKey = $(".txtReciverKey").val().trim();
        var ReciverKeyV = TryParseInt($(".auReciverKeyV").val());

        if (tReciverKey.length == "" || ReciverKeyV == 0) {
            message += "<li>Please Select Receiver.</li>";
        }
        if ($(".ddlDepartmentKey option:selected").val() == "-1") {
            message += "<li>Please Select Department.</li>";
        }
        if ($(".txtReciverKeyCompanyName").val().trim() == "") {
            message += "<li> Plese Enter Receiver Company Name.</li>";
        }
        if ($(".ddlReciverDepartmentKey option:selected").val() == "-1") {
            message += "<li>Please Select Receiver Department.</li>";
        }
        if ($(".ddlReciverAddressKey option:selected").val() == "-1") {
            message += "<li>Please Select Receiver Address/Save In Customer Master.</li>";
        }
        if ($(".txtRemail").val().trim() == "") {
            message += "<li>Please Enter Receiver Email.</li>";
        }
        //if ($(".txtRreferencenumber").val().trim() == "") {
        //    message += "<li>Please Enter Reciever Reference Number.</li>";
        //}
        //if ($(".txtRpaci").val().trim() == "") {
        //    message += "<li>Please Enter Receiver PACI Number.</li>";
        //}
        if ($(".ddlReceiverCountry").val().trim() == "") {
            message += "<li>Please Enter Receiver Destination.</li>";
        }
        if ($(".ddlReceiverState").val().trim() == "") {
            message += "<li>Please Enter Receiver State.</li>";
        }
        if ($(".ddlReceiverCity").val().trim() == "") {
            message += "<li>please enter receiver city .</li>";
        }
        //if ($(".txtRpostcode").val().trim() == "") {
        //    message += "<li>please enter receiver postcode.</li>";
        //}
        if ($(".txtRmobileno").val().trim() == "") {
            message += "<li>please enter receiver mobile.</li>";
        }
        //if ($(".txtRotherno").val().trim() == "") {
        //    message += "<li>please enter receiver alternative/other no.</li>";
        //}
       

    }
    else if (step == 3) {

        if ($('#dvPackingGrid tr').length < 2) {
            message += "<li>Please Select Atleast One Item Pacakge.</li>";
        }

        if ($("#dvInvoiceGrid tr").length < 2) {
            message += "<li>Please Select Atleast One Item Invoice.</li>";
        }
        if ($(".txtShipmentDescription").val().trim() == "") {
            message += "<li>Please Enter Shipment Description.</li>";
        }
        if ($(".ddlShipmentPurpose option:selected").val() == "-1") {
            message += "<li>Please Select Shipment Purpose.</li>";
        }
        if ($(".txtShipmentRefrence").val().trim() == "") {
            message += "<li>Please Enter Shipment Refrence.</li>";
        }
        if ($(".ddlExportType option:selected").val() == "-1") {
            message += "<li>Please Select Export Type.</li>";
        }
        if ($(".ddlCustomerOfTrade option:selected").val() == "-1") {
            message += "<li>Please Select Customs Of Trade.</li>";
        }

        if ($(".ddlReasonForExport option:selected").val() == "-1") {
            message += "<li>Please Select Reason For Export.</li>";
        }
        if ($(".txtPaymentTerms").val().trim() == "") {
            message += "<li>Please Enter Payment Terms.</li>";
        }
        if ($(".txtPlaceOfDestination").val().trim() == "") {
            message += "<li>Please Enter Place Of Destinations.</li>";
        }

        if ($(".ddlPickupType option:selected").val() == "-1") {
            message += "<li>Please Select Prefered Pickup Type.</li>";
        }
        if ($(".ddlPickupWindow option:selected").val() == "-1") {
            message += "<li>Please Select Preferred Pickup Window.</li>";
        }
        if ($(".ddlDeliverytype option:selected").val() == "-1") {
            message += "<li>Please Select Prefered Delivery Type.</li>";
        }
        if ($(".ddlDeliveryWindow option:selected").val() == "-1") {
            message += "<li>Please Select Preferred Delivery Window.</li>";
        }
        if ($(".ddlPaymentType option:selected").val() == "-1") {
            message += "<li>Please Select Preferred Delivery Window.</li>";
        }
        //ddlPaymentType
        //txtFreightCharges
        //txtChargable Weight Chargable Weight
        //txtConsignmentValue
        //Insurance Amount
        //Other Charges
        //Delivery Charges

    }

    if (message.length > 5) {
        message = '<div class="text-left">' + message + '</div>';
    }
    return message;
}
async function SaveformValues(step) {
   
    if (step > 0 ) {
    

        var today = new Date();
        

        
            var Save = {

                //1.Step SENDER
                TranID: isEmpty($('.txtAirWayKey').val()) ? 0 : parseInt($('.txtAirWayKey').val()),
                TranDate: new Date(today.setDate(today.getDate())),
                TranType: $(".ddlTranType option:selected").val(),
                CustomerKey: $(".auCustomerKeyV").val(),
                CompanyName: $(".txtCompanyName").val(),
                DepartmentKey: $(".ddlDepartmentKey option:selected").val(),
                AddressKey: $(".ddlAddressKey option:selected").val(),



                ////2.Step Receiver

                ReciverKey: $(".auReciverKeyV").val(),
                ReciverKeyCompanyName: $(".txtReciverKeyCompanyName").val(),
                ReciverDepartmentKey: $(".ddlReciverDepartmentKey option:selected").val(),
                ReciverAddressKey: $(".ddlReciverAddressKey option:selected").val(),

                ////3.Step Packaging

                PackingTypeKey: $(".ddlPackingTypeKey option:selected").val(),
                InvoiceType: $('input:radio[name=invoice]:checked').val(),
           
                Attachment1: $(".txtAttachPath1").val(),
                Attachment2: $(".txtAttachPath2").val(),

                ShipmentDescription: $(".txtShipmentDescription").val(),
                ShipmentPurpose: $(".ddlShipmentPurpose option:selected").val(),
                ShipmentRefrence: $(".txtShipmentRefrence").val(),

                //InvoiceNumber: $(".txtInvoiceNumber").val(),
                //Carrier: $(".txtCarrier").val(),
                //OwnShipmentRefNo: $(".txtOwnShipmentRefNo").val(),
                //PackageMarks: $(".txtPackageMarks").val(),
                //EeceiverReferenceNo: $(".txtEeceiverReferenceNo").val(),

                ExportType: $(".ddlExportType option:selected").val(),
                CustomerOfTrade: $(".ddlCustomerOfTrade option:selected").val(),
                ReasonForExport: $(".ddlReasonForExport  option:selected").val(),
                PaymentTerms: $(".txtPaymentTerms").val(),
                PlaceOfDestination: $(".txtPlaceOfDestination").val(),

                //4th Step
                PickupType: $(".ddlPickupType option:selected").val(),
                PickupWindow: $(".ddlPickupWindow  option:selected").val(),
                Deliverytype: $(".ddlDeliverytype   option:selected").val(),
                DeliveryWindow: $(".ddlDeliveryWindow   option:selected").val(),

            }

            $.ajax({
                type: "POST",
                url: "/api/Home/AirWayMainSave",
                data: JSON.stringify(Save),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert("Successfully");
                    $(".txtAirWayKey").val(data);
                    $(".btnAddPacking").removeAttr("onclick");
                    $(".btnAddPacking").attr("onclick", "return Op1(15,0," + $(".txtAirWayKey").val() + ")");
                    $(".btnAddInvoiceDetail").removeAttr("onclick");
                    $(".btnAddInvoiceDetail").attr("onclick", "return Op1(16,0," + $(".txtAirWayKey").val() + ")");
                    //$(".btnAddPacking").click(function () {
                    //    return Op1(15, 0, data);
                    //});
                    //$('#dvC2S').modal('hide');
                    BindPacking(data);
                    BindInvoiceDetail(data);
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
           
        }

}
function UploadFile() {
    if ($('.txtAttachment1').val() == '' ) {

        alert('Please select file');

        return;

    }
    var formdata = new FormData();

    var file = $('.txtAttachment1')[0];

    formdata.append('file', file.files[0]);
       
        $.ajax({
            type: "POST",
            url: "/api/Home/uploadfile",
            data: formdata,
            contentType: false,
            processData: false,
            success: function (data) {
                $('.txtAttachPath1').val(data);
                $('#idUploadFile1').addClass('alert-success').html('<strong>Success!</strong><a href="' + data + '">Open File</a>').show();

            },
            failure: function () {
                $('#idUploadFile1').addClass('alert_error').html('<strong>Failed!</strong> Failed in upload');
            },
            error: function () {
                $('#idUploadFile1').addClass('alert_error').html('<strong>Error!</strong> Error in upload');
            }
        });



}
function UploadFile2() {
    if ($('.txtAttachment2').val() == '') {

        alert('Please select file');

        return;

    }
    var formdata = new FormData();

    var file = $('.txtAttachment2')[0];

    formdata.append('file', file.files[0]);

    $.ajax({
        type: "POST",
        url: "/api/Home/uploadfile",
        data: formdata,
        contentType: false,
        processData: false,
        success: function (data) {
            $('.txtAttachPath2').val(data);
            $('#idUploadFile2').addClass('alert-success').html('<strong>Success!</strong><a href="' + data + '">Open File</a>').show();

        },
        failure: function () {
            $('#idUploadFile2').addClass('alert_error').html('<strong>Failed!</strong> Failed in upload');
        },
        error: function () {
            $('#idUploadFile2').addClass('alert_error').html('<strong>Error!</strong> Error in upload');
        }
    });



}


///Bind Packing & Invoice Detial////
function AddTablePack() {
    $("#dvPackingGrid").empty();
    var str = '';
    str += '  <table id="TableGridPacking" class="datatable-table" width="100%">  ';
    str += '      <thead class="datatable-head">                                        ';
    str += '        <tr class="datatable-row">                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Packing Name</th>                            ';
    str += '       <th>Quantity</th>                            ';
    str += '       <th>UOM</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvPackingGrid").append(str);

}
function Bind() {
    var key = $(".txtAirWayKey").val();
    if (key > 0) {
        BindPacking(key);
        BindInvoiceDetail(key);
    }
    
   
}
function BindPacking(data) {
    AddTablePack();
    var airWayKey = data;


    $('#TableGridPacking').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchAirWayMain2Packing?iAirwayBillKey=' + airWayKey,

            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
        { "data": "RowIndex" },
            { "data": "PackingKeyName" },
        { "data": "Qty" },
        { "data": "UOM" },

        ],
        statusCode: {
            404: function () {
                alert("page not found");
            }
        },
        fnRowCallback: function (row, data, dataIndex) {

            //     $(row).find('td:nth-child(6)').html(data.Status == true ? "Active" : "In Active");

        }
    });

}
function AddTableInvoiceDetail() {
    $("#dvInvoiceGrid").empty();
    var str = '';
    str += '  <table id="TableGridInvoice" class="datatable-table" width="100%">  ';
    str += '      <thead class="datatable-head">                                        ';
    str += '   <tr class="datatable-row">                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Item Description</th>                            ';
    str += '       <th>Manufacture From</th>                            ';
    str += '       <th>Commodity Code</th>                               ';
    str += '       <th>Quantity</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvInvoiceGrid").append(str);

}
function BindInvoiceDetail(data) {
    AddTableInvoiceDetail();
    
    var airWayKey = data;

    $('#TableGridInvoice').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchInvoiceDetail?iAirwayBillKey=' + airWayKey,

            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
        { "data": "RowIndex" },
        { "data": "ItemDescription" },
        { "data": "ManufactureFrom" },
        { "data": "CommodityCode" },
        { "data": "Quantity" },
        ],
        statusCode: {
            404: function () {
                alert("page not found");
            }
        },
        fnRowCallback: function (row, data, dataIndex) {

            //     $(row).find('td:nth-child(6)').html(data.Status == true ? "Active" : "In Active");

        }
    });

}


// END //    Sense Softech Code///
 



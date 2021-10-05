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
                    name: {
                        validators: {
                            notEmpty: {
                                message: 'Name is required'
                            }
                        }
                    },
                    company: {
                        validators: {
                            notEmpty: {
                                message: 'Company is required'
                            }
                        }
                    },
                    address1: {
                        validators: {
                            notEmpty: {
                                message: 'Address1 is required'
                            }
                        }
                    },
                    address2: {
                        validators: {
                            notEmpty: {
                                message: 'Address2 is required'
                            }
                        }
                    },
                    address3: {
                        validators: {
                            notEmpty: {
                                message: 'Address3 is required'
                            }
                        }
                    },
                    contactdepartment: {
                        validators: {
                            notEmpty: {
                                message: 'Contact/Department is required'
                            }
                        }
                    },
                    email: {
                        validators: {
                            notEmpty: {
                                message: 'Email is required'
                            }
                        }
                    },
                    referencenumber: {
                        validators: {
                            notEmpty: {
                                message: 'Reference number is required'
                            }
                        }
                    },
                    postcode: {
                        validators: {
                            notEmpty: {
                                message: 'Postcode is required'
                            }
                        }
                    },
                    city: {
                        validators: {
                            notEmpty: {
                                message: 'City is required'
                            }
                        }
                    },
                    state: {
                        validators: {
                            notEmpty: {
                                message: 'State is required'
                            }
                        }
                    },
                    country: {
                        validators: {
                            notEmpty: {
                                message: 'Country is required'
                            }
                        }
                    },
                    phoneno: {
                        validators: {
                            notEmpty: {
                                message: 'Country is required'
                            }
                        }
                    },
                    mobileno: {
                        validators: {
                            notEmpty: {
                                message: 'Country is required'
                            }
                        }
                    },
                    otherno: {
                        validators: {
                            notEmpty: {
                                message: 'Country is required'
                            }
                        }
                    },
                    paci: {
                        validators: {
                            notEmpty: {
                                message: 'Country is required'
                            }
                        }
                    }
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

        // Step 2
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                fields: {
                    name1: {
                        validators: {
                            notEmpty: {
                                message: 'Package details is required'
                            }
                        }
                    },
                    //weight: {
                    //    validators: {
                    //        notEmpty: {
                    //            message: 'Package weight is required'
                    //        },
                    //        digits: {
                    //            message: 'The value added is not valid'
                    //        }
                    //    }
                    //},
                    //width: {
                    //    validators: {
                    //        notEmpty: {
                    //            message: 'Package width is required'
                    //        },
                    //        digits: {
                    //            message: 'The value added is not valid'
                    //        }
                    //    }
                    //},
                    //height: {
                    //    validators: {
                    //        notEmpty: {
                    //            message: 'Package height is required'
                    //        },
                    //        digits: {
                    //            message: 'The value added is not valid'
                    //        }
                    //    }
                    //},
                    //packagelength: {
                    //    validators: {
                    //        notEmpty: {
                    //            message: 'Package length is required'
                    //        },
                    //        digits: {
                    //            message: 'The value added is not valid'
                    //        }
                    //    }
                    //}
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

        // Step 3
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                fields: {
                    delivery: {
                        validators: {
                            notEmpty: {
                                message: 'Delivery type is required'
                            }
                        }
                    },
                    packaging: {
                        validators: {
                            notEmpty: {
                                message: 'Packaging type is required'
                            }
                        }
                    },
                    preferreddelivery: {
                        validators: {
                            notEmpty: {
                                message: 'Preferred delivery window is required'
                            }
                        }
                    }
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
                //    fields: {
                //        locaddress1: {
                //            validators: {
                //                notEmpty: {
                //                    message: 'Address is required'
                //                }
                //            }
                //        },
                //        locpostcode: {
                //            validators: {
                //                notEmpty: {
                //                    message: 'Postcode is required'
                //                }
                //            }
                //        },
                //        loccity: {
                //            validators: {
                //                notEmpty: {
                //                    message: 'City is required'
                //                }
                //            }
                //        },
                //        locstate: {
                //            validators: {
                //                notEmpty: {
                //                    message: 'State is required'
                //                }
                //            }
                //        },
                //        loccountry: {
                //            validators: {
                //                notEmpty: {
                //                    message: 'Country is required'
                //                }
                //            }
                //        }
                //    },
                //    plugins: {
                //        trigger: new FormValidation.plugins.Trigger(),
                //        // Bootstrap Framework Integration
                //        bootstrap: new FormValidation.plugins.Bootstrap({
                //            //eleInvalidClass: '',
                //            eleValidClass: '',
                //        })
                //    }
            }
        ));
        // Step 5
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                //fields: {
                //    company: {
                //        validators: {
                //            notEmpty: {
                //                message: 'Company is required'
                //            }
                //        }
                //    },
                //    address: {
                //        validators: {
                //            notEmpty: {
                //                message: 'Address is required'
                //            }
                //        }
                //    },
                //    postcode: {
                //        validators: {
                //            notEmpty: {
                //                message: 'Postcode is required'
                //            }
                //        }
                //    },
                //    city: {
                //        validators: {
                //            notEmpty: {
                //                message: 'City is required'
                //            }
                //        }
                //    },
                //    country: {
                //        validators: {
                //            notEmpty: {
                //                message: 'Country is required'
                //            }
                //        }
                //    },
                //    state: {
                //        validators: {
                //            notEmpty: {
                //                message: 'State is required'
                //            }
                //        }
                //    }
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
                    if (status == 'Valid') {
                        //save & next functionality goes here
                        await SaveformValues(wizard.getStep());
                        wizard.goTo(wizard.getNewStep());
                        KTUtil.scrollTop();
                    } else {
                        Swal.fire({
                            text: "Sorry, looks like there are some errors detected, please try again.",
                            icon: "error",
                            buttonsStyling: false,
                            confirmButtonText: "Ok, got it!",
                            customClass: {
                                confirmButton: "btn font-weight-bold btn-light"
                            }
                        }).then(function () {
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
});







// Start Custom Codes

// Start Add Package 
var i = 1;
var C = 1;
$(".partialAdmin").on("click", "#addpackage", function () {
    i++
    var v = document.getElementById("package_hidden").innerHTML;
    var t = "<div class='row packagedetail' id='package_" + i + "' >" + v + "</div>";
    $("#Packagelist").append(t);
    document.querySelector("#package_" + i + " .copypackage").setAttribute("id", i);
    document.querySelector("#package_" + i + " .removepackage").setAttribute("id", i);
    $("#Packagelist .quantity").trigger('click');
    $("#Packagelist .weight").trigger('click');
});
// End Add Package



// Start remove Package 
$(".partialAdmin").on("click", ".removepackage", function () {

    var id = document.getElementById("package_" + this.id).remove();
    $("#Packagelist .quantity").trigger('click');
    $("#Packagelist .weight").trigger('click');
});
// End Add Package


// Start Copy Package 
$(".partialAdmin").on("click", ".copypackage", function () {
    i++
    var v = document.getElementById("package_" + this.id).innerHTML;
    var t = "<div class='row packagedetail' id='package_" + i + "' >" + v + "</div>";
    $("#Packagelist").append(t);
    document.querySelector("#package_" + i + " .copypackage").setAttribute("id", i);
    document.querySelector("#package_" + i + " .removepackage").setAttribute("id", i);
    $("#Packagelist .quantity").trigger('click');
    $("#Packagelist .weight").trigger('click');

});
// End Copy Package

// Start Quantity  
$(".partialAdmin").on("click", ".quantity", function () {
    var quantity = 0;
    $(".quantity").each(function () {
        quantity += parseInt($(this).val());
    });
    $("#quantitys").text(quantity);
    //$(".quantity").val(quantity);
});
// End Quantity


// Start Weight  
$(".partialAdmin").on("click", ".weight", function () {
    var quantity = 0;
    //$(".weight").val($(this).val());
    $(".weight").each(function () {
        quantity += parseInt($(this).val());
    });
    $("#weights").text(quantity);


});
// End Weight


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//Invoce Start


$("input:radio[name=invoice]").on("click", function () {

    var data = $("input:radio[name=invoice]:checked").val()
    if (data === "UploadedInvoice") {

        $(".sinvoicee").css({ "display": "block" });
        $(".cinvoicee").css({ "display": "none" });

    } else {
        $(".sinvoicee").css({ "display": "none" });
        $(".cinvoicee").css({ "display": "block" });
    }

});



//Start Copy Invoce 
//$(".cinvoicee").on("click", function () {
$("#cinvoicelist").on("click", ".copyinvoice", function () {
    C++;
    var v = document.getElementById("cinvoice_" + this.id).innerHTML;
    var t = "<div class='row invoicedetail bg-light-dark px-6 py-8 rounded-xl mr-7 mb-7' id='cinvoice_" + C + "' >" + v + "</div>";
    $("#cinvoicelist").append(t);
    //document.querySelector("#cinvoice_" + i + " .copyinvoice").setAttribute("id", i);
    document.querySelector("#cinvoice_" + C + " .removeinvoice").setAttribute("id", C);
    $("#cinvoicelist .ccurrency").trigger('change');
    $("#cinvoicelist .cquantity").trigger('click');
    $("#cinvoicelist .cnetweight").trigger('click');
    $("#cinvoicelist .cgrossweight").trigger('click');

});
//End Copy Package



// Start Add Invoce 
$("#addinvoice").on("click", function () {
    C++;
    var v = document.getElementById("invoice_hidden").innerHTML;
    //var v = document.getElementById("cinvoice_" + this.id).innerHTML;
    var t = "<div class='row invoicedetail bg-light-dark px-6 py-8 rounded-xl mr-7 mb-7' id='cinvoice_" + C + "' >" + v + "</div>";
    $("#cinvoicelist").append(t);
    //document.querySelector("#cinvoice_" + i + " .copyinvoice").setAttribute("id", i);
    document.querySelector("#cinvoice_" + C + " .removeinvoice").setAttribute("id", C);
    $("#cinvoicelist .ccurrency").trigger('change');
    $("#cinvoicelist .cquantity").trigger('click');
    $("#cinvoicelist .cnetweight").trigger('click');
    $("#cinvoicelist .cgrossweight").trigger('click');

});
// End Add Invoce




// Start remove Invoice 
$("#cinvoicelist").on("click", ".removeinvoice", function () {
    var id = document.getElementById("cinvoice_" + this.id).remove();
    $("#cinvoicelist .ccurrency").trigger('change');
    $("#cinvoicelist .cquantity").trigger('click');
    $("#cinvoicelist .cnetweight").trigger('click');
    $("#cinvoicelist .cgrossweight").trigger('click');
});
// End Add Package



// Start Quantity  
$("#cinvoicelist").on("click", ".cquantity", function () {
    var quantity = 0;
    $(".cquantity").each(function () {
        quantity += parseInt($(this).val());
    });
    $("#cquantitys").text(quantity);
    //$(".quantity").val(quantity);
});
// End Quantity


// Start NetWeight  
$("#cinvoicelist").on("click", ".cnetweight", function () {
    var quantity = 0;
    //$(".weight").val($(this).val());
    $(".cnetweight").each(function () {
        quantity += parseInt($(this).val());
    });
    $("#cnweights").text(quantity);
});
// End Weight

// Start GrossWeight  
$("#cinvoicelist").on("click", ".cgrossweight", function () {
    var quantity = 0;
    //$(".weight").val($(this).val());
    $(".cgrossweight").each(function () {
        quantity += parseInt($(this).val());
    });
    $("#cgweights").text(quantity);


});
// End Weight



// Start GrossWeight  
$("#cinvoicelist").on("click change", ".ccurrency", function () {
    var quantity = 0;
    //$(".weight").val($(this).val());
    $(".ccurrency").each(function () {
        quantity += parseInt($(this).val());
    });
    $("#ccurrencys").text(quantity);
    $("#goodsvalue").text(quantity);


});
// End Weight


//Start PartialView Changing 

$("#pills-tab-4").on("click ", function () {
    $.ajax(
        {
            type: 'get',
            //dataType: 'JSON',
            url: '/Home/PartialAdmin',
            //data: $("#kt_form").serialize(),
            //data: { value: $("#kt_form").serialize() },
            data: { value: 3 },
            success:
                function (response) {
                    // Generate HTML table.  
                    $(".partialAdmin").html(response)
                    //convertJsonToHtmlTable(JSON.parse(response), $("#TableId"));
                },
            error:
                function (response) {
                    alert("Error: " + response);
                }
        });

});
//End PartialView Changing 



//Invoce End


//Start invoiceSection

$("input:radio[name=scontent]").on("click", function () {

    var data = $("input:radio[name=scontent]:checked").val()
    if (data === "parcel") {
        $("#invoiceSection").css({ "display": "block" });

    } else {
        $("#invoiceSection").css({ "display": "none" });
    }

});


//End invoiceSection


async function SaveformValues(step) {
    if (step == 1) {
        debugger;
        //Sender Details
        var obj = {
            CustomerName: $("#txtSenderName").val(),
            CompanyName: $("#txtSenderComapny").val(),
            Department: $("#txtSenderDepartment").val(),
            AddressLine1: $("#txtAddressLine1").val(),
            AddressLine2: $("#txtAddressLine2").val(),
            AddressLine3: $("#txtAddressLine3").val(),
            EmailId: $("#txtSenderEmail").val(),
            ReferenceNumber: $("#txtReferenceNo").val(),
            PostCode: $("#txtPostCode").val(),
            Country: $("#ddlSenderCountry").val(),
            State: $("#ddlSenderState").val(),
            City: $("#ddlSenderCity").val(),
            PaciNumber: $("#txtPaciNumber").val(),
            MobileNumber: $("#txtSenderMobile").val(),
            AlternateNumber: $("#txtAlernateNo").val(),

        }
        $.ajax({
            type: "POST",
            url: '/Home/CreateSenderDetails',
            data: obj,
            dataType: "json",
            success: function (result, status, xhr) {

            },
            error: function (xhr, status, error) {
            }
        });
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//let searchwrapper = document.querySelector(".searchwrapper");
//var inputbox = searchwrapper.querySelector("input");
//inputbsox.onkeyup = (e) => {
//    alert(e.target.value);
//    let emptyarray = [];
//    let userdata = e.target.value;
//    console.log(e.target.value);
//    let suggestion = [];
//    if (userdata) {
//        emptyarray = suggestion.filter((userdata) => {
//            return userdata.toLocaleLowerCase();
//        });
//        emptyarray = emptyarray.map((userdata) => {
//            return userdata = '<li>' + userdata + '</li>';
//        });

//    }
//}


$(document).ready(function () {
    //Country Drop down

    $("#ddlSenderCountry").change();
    $("#ddlReceiverCountry").change();

    $("#ddlSenderCountry").on('change', function () {
        var SelectedCountry = $("#ddlSenderCountry").val();
        if (SelectedCountry != "-1") {
            $.ajax({
                type: "GET",
                url: '/operation/GetStatesFromCountry',
                data: { Country: SelectedCountry },
                async: true,
                dataType: "json",
                success: function (data) {
                    //state
                    var ddlstate = '';
                    for (var i = 0; i < data.states.length; i++) {
                        ddlstate += '<option value="' + data.states[i]["ID"] + '">' + data.states[i]["State_Name"] + '</option>';
                    }
                    $("#ddlSenderState").html(ddlstate);
                    $("#ddlSenderState").change();
                }
            });
        }
        else {
            //$("#ddlBusiness").html('<option value="-1">Please Select a Business</option>');
        }
        return false;
    })

    $("#ddlSenderState").on('change', function () {
        var SelectedCountry = $("#ddlSenderCountry").val();
        var SelectedState = $("#ddlSenderState").val();
        if (SelectedCountry != "-1") {
            $.ajax({
                type: "GET",
                url: '/Operation/GetCitiesFromState',
                data: {
                    Country: SelectedCountry,
                    State: SelectedState
                },
                async: true,
                dataType: "json",
                success: function (data) {
                    console.log('City Data', data);

                    //City
                    var ddlCity = ''
                    for (var i = 0; i < data.cities.length; i++) {
                        ddlCity += '<option value="' + data.cities[i]["ID"] + '">' + data.cities[i]["City_Name"] + '</option>';
                    }
                    $("#ddlSenderCity").html(ddlCity);
                }
            });
        }
        else {
            //$("#ddlBusiness").html('<option value="-1">Please Select a Business</option>');
        }
        return false;
    })


    $("#ddlReceiverCountry").on('change', function () {
        var SelectedCountry = $("#ddlSenderCountry").val();
        if (SelectedCountry != "-1") {
            $.ajax({
                type: "GET",
                url: '/operation/GetStatesFromCountry',
                data: { Country: SelectedCountry },
                async: true,
                dataType: "json",
                success: function (data) {
                    //state
                    var ddlstate = '';
                    for (var i = 0; i < data.states.length; i++) {
                        ddlstate += '<option value="' + data.states[i]["ID"] + '">' + data.states[i]["State_Name"] + '</option>';
                    }
                    $("#ddlReceiverState").html(ddlstate);
                    $("#ddlReceiverState").change();
                }
            });
        }
        else {
            //$("#ddlBusiness").html('<option value="-1">Please Select a Business</option>');
        }
        return false;
    })

    $("#ddlReceiverState").on('change', function () {
        var SelectedCountry = $("#ddlReceiverCountry").val();
        var SelectedState = $("#ddlReceiverState").val();
        if (SelectedCountry != "-1") {
            $.ajax({
                type: "GET",
                url: '/Operation/GetCitiesFromState',
                data: {
                    Country: SelectedCountry,
                    State: SelectedState
                },
                async: true,
                dataType: "json",
                success: function (data) {
                    console.log('City Data', data);

                    //City
                    var ddlCity = ''
                    for (var i = 0; i < data.cities.length; i++) {
                        ddlCity += '<option value="' + data.cities[i]["ID"] + '">' + data.cities[i]["City_Name"] + '</option>';
                    }
                    $("#ddlReceiverCity").html(ddlCity);
                }
            });
        }
        else {
            //$("#ddlBusiness").html('<option value="-1">Please Select a Business</option>');
        }
        return false;
    })


});









// End Custom Codes


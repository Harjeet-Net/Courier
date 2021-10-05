function Validate()
{
    var message = '';
    var txtCustomerName = $(".txtCustomerName").val().trim();
    var txtAddress = $(".txtAddress").val().trim();
    var txtMobileNumber = $(".txtMobileNumber").val().trim();
    var txtEmailId = $(".txtEmailId").val().trim();
    //var txtZipCode = $(".txtZipCode").val().trim();
    //var txtReferenceNumber = $(".txtReferenceNumber").val().trim();
    //var txtPaciNumber = $(".txtPaciNumber").val().trim();
    
 
    if (txtCustomerName.length == "") {
        message += "<li>Please Enter Customer Name.</li>";
    }
    if (txtMobileNumber.length < 8 ) {
        message += "<li>Please Enter Mobile Number.</li>";
    }
    if ($(".txtMobileNumber option:selected").val() == $(".txtAlternateNumber").val()) {
        message += '<li> Mobile No and Alternate No Should Be Diffrent.</li>';
    }
    if (txtEmailId.length == "") {
        message += "<li>Please Enter Email Id.</li>";
    }
    //if (txtReferenceNumber.length == "") {
    //    message += "<li>Please Enter Reference Number.</li>";
    //}
    //if (txtPaciNumber.length == "") {
    //    message += "<li>Please Enter Paci Number.</li>";
    //}
    if ($(".ddlNationality option:selected").val() == -1) {
        message += "<li>Please Select Nationality.</li>";
    }
    if (txtAddress.length == "") {
        message += "<li>Please Enter Address</li>";
    }

    //if (txtZipCode.length == "") {
    //    message += "<li>Please Enter ZipCode</li>";
    //}
    if ($(".ddlCountry option:selected").val() == -1) {
        message += "<li>Please Select Country.</li>";
    }
    if ($(".ddlState option:selected").val() == -1) {
        message += "<li>Please Select State.</li>";
    }
    if ($(".ddlCity option:selected").val() == -1) {
        message += "<li>Please Select City.</li>";
    }
  
    //if ($(".ddlStatus option:selected").val() == -1) {
    //    message += "<li>Please Select Vehicle Type.</li>";
    //}
    
    var Pk = parseInt($("#txtKey").val());
    if (Pk == 0) {
        message += ValMsg();
    }
                                                                                                                                                                                                                                                                                                                                    


    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
         

        return true;
    }
}


 

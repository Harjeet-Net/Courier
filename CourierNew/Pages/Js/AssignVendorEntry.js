function Validate() {

    var message = '';

    if ($(".ddlVendorName option:selected").val() == -1) {
        message += "<li>Please Select Vendor For AirWay Bill.</li>";

    }
    
    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
    return false;
} 
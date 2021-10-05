function Validate() {

    var message = '';
    var VendorName = $(".txtVendorName").val().trim();

    if (VendorName.length == "") {
        message += "<li>Please Enter Vendor Name</li>";
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
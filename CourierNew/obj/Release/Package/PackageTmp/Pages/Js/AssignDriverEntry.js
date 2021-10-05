function Validate() {

    var message = '';

    if ($(".ddlDriverName option:selected").val() == -1) {
        message += "<li>Please Select Driver For AirWay Bill.</li>";
        
    }
    if ($(".ddlVehicleKey option:selected").val() == -1) {
        message += "<li>Please Select Vehicle.</li>";
        
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
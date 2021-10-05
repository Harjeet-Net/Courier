function Validate()
{
    var message = '';
    var txtDriverName = $(".txtDriverName").val().trim();
    var txtAddress = $(".txtAddress").val().trim();
    var txtMobileNumber = $(".txtMobileNumber").val().trim();
    var txtEmailId = $(".txtEmailId").val().trim();
    var txtZipCode = $(".txtZipCode").val().trim();


    if ($(".ddlNationality option:selected").val() == -1) {
        message += "<li>Please Select Nationality.</li>";
    }
    if ($(".ddlCity option:selected").val() == -1) {
        message += "<li>Please Select City.</li>";
    }
    if ($(".ddlCountry option:selected").val() == -1) {
        message += "<li>Please Select Country.</li>";
    }
    if ($(".ddlState option:selected").val() == -1) {
        message += "<li>Please Select State.</li>";
    }
    if ($(".ddlVehicleType option:selected").val() == -1) {
        message += "<li>Please Select Vehicle Type.</li>";
    }
    if (txtDriverName.length == "") {
        message += "<li>Please Enter Driver Name</li>";
    }
    if (txtAddress.length == "") {
        message += "<li>Please Enter Your Address</li>";
    }
    if (txtMobileNumber.length == "") {
        message += "<li>Please Enter Your Mobile Number</li>";
    }
    if (txtEmailId.length == "") {
        message += "<li>Please Enter Your EmailId</li>";
    }
    if (txtZipCode.length == "") {
        message += "<li>Please Enter ZipCode</li>";
    }
 



    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
};

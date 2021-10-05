function ValidateOther()
{
    var message = ValMsg();
 
    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
}

function ValMsg() {
    var message = '';
    //   var CustomerKey = $(".txtCustomerKey").val();
    //   var CustomerKeyV = TryParseInt($(".auCustomerKeyV").val());
    var txtAddressName = $(".txtAddressName").val().trim();
    var txtFlatNo = $(".txtFlatNo").val().trim();
    var txtFloorNo = $(".txtFloorNo").val().trim();
    var txtBlockNo = $(".txtBlockNo").val().trim();
    var txtAddress1 = $(".txtAddress1").val().trim();
    var txtAddress2 = $(".txtAddress2").val().trim();
    var txtAddress3 = $(".txtAddress3").val().trim();
    var txtPostCode = $(".txtPostCode").val().trim();

    //if (CustomerKey.length == "" || CustomerKeyV == 0) {
    //    message += "<li>Please Select Customer.</li>";
    //}
    if (txtFlatNo.length == "") {
        message += "<li>Please Enter Flat No.</li>";
    }
    if (txtFloorNo.length == "") {
        message += "<li>Please Enter Floor No.</li>";
    }
    if (txtBlockNo.length == "") {
        message += "<li>Please Enter Block No.</li>";
    }
    if (txtAddressName.length == "") {
        message += "<li>Please Enter Address</li>";
    }
    if ($(".ddlCountry option:selected").val() == -1) {
        message += "<li>Please Select Country.</li>";
    }
    if ($(".ddlState option:selected").val() == -1) {
        message += "<li>Please Select State.</li>";
    }
    if ($(".ddlCity option:selected").val() == -1) {
        message += "<li>Please Select City.</li>";
    }
    if (txtAddress1.length == "") {
        message += "<li>Please Enter Address 1.</li>";
    }
    if (txtAddress2.length == "") {
        message += "<li>Please Enter Address 2.</li>";
    }
    if (txtAddress3.length == "") {
        message += "<li>Please Enter Address 3.</li>";
    }
    if (txtPostCode.length == "") {
        message += "<li>Please Enter Post Code.</li>";
    }

    return message;


}
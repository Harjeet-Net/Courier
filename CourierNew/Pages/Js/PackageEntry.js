function Validate()
{
    var message = '';

    var txtQty = $(".txtQty").val().trim();
    var txtWeight = $(".txtWeight").val().trim();
    var txtDL = $(".txtDL").val().trim();
    var txtDW = $(".txtDW").val().trim();
    var txtDH = $(".txtDH").val().trim();
 

    if ($(".ddlPackingKey option:selected").val() == -1) {
        message += "<li>Please Select Packing.</li>";
    }
    if (txtQty.length == "") {
        message += "<li>Please Enter Qty.</li>";
    }
    if (txtWeight.length == "") {
        message += "<li>Please Enter Weight.</li>";
    }
    if ($(".ddlUOM option:selected").val() == -1) {
        message += "<li>Please Select UOM.</li>";
    }
    if (txtDL.length == "") {
        message += "<li>Please Enter Length.</li>";
    }
    if (txtDW.length == "") {
        message += "<li>Please Enter Width</li>";
    }    
    if (txtDH.length == "") {
        message += "<li>Please Enter Height.</li>";
    }
    

 
 



    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
};

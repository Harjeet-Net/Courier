function Validate()
{

    var message = '';
    var txtCatVal = $(".txtCatVal").val().trim();

    if ($(".ddlCategoryName option:selected").val() == -1) {
        message += "<li>Please Select Category Type.</li>";

    }
    if (txtCatVal.length == "") {
        message += "<li>Please Enter Category Name.</li>";
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
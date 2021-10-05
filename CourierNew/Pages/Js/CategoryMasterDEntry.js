function Validate()
{

    var message = '';
    var txtCategoryName = $(".txtCategoryName").val().trim();

    if (txtCategoryName.length == '') {
        message += "<li>Please Enter Category Name</li>";
    }
    if ($(".ddlCategory option:selected").val() == -1) {
        message += "<li>Please Select Category Value</li>";
    }
    if (message != '') {
        toastr.error(message)
        return false;
    }
    else {
        return true;
    }
    return false;

    
}
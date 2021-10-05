function Validate() {

    var message = '';

    if ($(".txtTemplateName").val().trim().length < 1) {
        message += "<li>Please Enter Template Name.</li>";
    }
    if ($(".ddlTemplateType option:selected").val() == -1) {
        message += "<li>Please Select Template Type.</li>";

    }
    if ($(".ddlCategoryKey option:selected").val() == -1) {
        message += "<li>Please Select Category Type.</li>";
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
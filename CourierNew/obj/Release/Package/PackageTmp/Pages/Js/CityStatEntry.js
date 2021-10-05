Validate = function () {
    var message = '';

    var txtCityEnglish = $(".txtCityEnglish").val().trim();
    var txtCityArabic = $(".txtCityArabic").val().trim();
    var txtCityOther = $(".txtCityOther").val().trim();


    if ($(".ddlCOUNTRYID option:selected").val() == "-1") {
        message += "<li>Please Select Country.</li>";
    }
    if ($(".ddlStateID option:selected").val() == "-1") {
        message += "<li>Please Select State.</li>";
    }
    if (txtCityEnglish.length == "") {
        message += "<li>Please Enter Name In English.</li>";
    }
    if (txtCityArabic.length == "") {
        message += "<li>Please Enter Name In Arabic.</li>";
    }
    if (txtCityOther.length == "") {
        message += "<li>Please Enter Name In Other. </li>";
    }
    



    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
};

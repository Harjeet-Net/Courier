Validate = function () {
    var message = '';
    var txtSHORTNAME = $(".txtSHORTNAME").val().trim();
    var txtREFNAME1 = $(".txtREFNAME1").val().trim();
    var txtREFNAME2 = $(".txtREFNAME2").val().trim();
    var txtREFNAME3 = $(".txtREFNAME3").val().trim();
    var txtSWITCH1 = $(".txtSWITCH1").val().trim();
    var txtSWITCH2 = $(".txtSWITCH2").val().trim();
    var txtSWITCH3 = $(".txtSWITCH3").val().trim();


    if ($(".ddlREFTYPE option:selected").val() == "-1") {
        message += "<li>Please Select Module Name.</li>";
    }
    if ($(".ddlREFSUBTYPE option:selected").val() == "-1") {
        message += "<li>Please Select Category Name.</li>";
    }   
    if (txtSHORTNAME.length == "") {
        message += "<li>Please Select Short Name</li>";
    }
    if (txtREFNAME1.length == "") {
        message += "<li>Please Select RefName 1</li>";
    }
    if (txtREFNAME2.length == "") {
        message += "<li>Please Select RefName 2</li>";
    }
    if (txtREFNAME3.length == "") {
        message += "<li>Please Select RefName 3</li>";
    }
    if (txtSWITCH1.length == "") {
        message += "<li>Please Select Switch Name 1</li>";
    }
    if (txtSWITCH2.length == "") {
        message += "<li>Please Select Switch Name 2</li>";
    }
    if (txtSWITCH3.length == "") {
        message += "<li>Please Select Switch Name 3</li>";
    }
    



    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
};

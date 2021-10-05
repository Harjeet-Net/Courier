Validate = function () {
    var message = '';
    var txtfirstname = $(".txtfirstname").val().trim();
    var txtlastname = $(".txtlastname ").val().trim();
    //var txtNameEnglish = $(".txtNameEnglish").val().trim();
    var txtname2 = $(".txtname2").val().trim();
    var txtname3 = $(".txtname3").val().trim();
    var txtuserID = $(".txtuserID").val().trim();
    var txtPASSWORD = $(".txtPASSWORD").val().trim();
    var txtemp_mobile = $(".txtemp_mobile").val().trim();


    if (txtfirstname.length == "") {
        message += "<li>Enter First Name</li>";
    }
    if (txtlastname.length == "") {
        message += "<li>Enter Last Name</li>";
    }
    //if (txtNameEnglish.length == "") {
    //    message += "<li>Enter Name In English</li>";
    //}
    if (txtname2.length == "") {
        message += "<li>Enter Name In Arabic</li>";
    }
    if (txtname3.length == "") {
        message += "<li>Enter Name In French</li>";
    }
    if (txtemp_mobile.length == "") {
        message += "<li>Enter Mobile No</li>";
    }
    if (txtuserID.length == "") {
        message += "<li>Enter Login Details</li>";
    }
    if (txtPASSWORD.length == "") {
        message += "<li>Enter Password</li>";
    }
    if ($(".ddlMainHRRoleID option:selected").val() == "-1") {
        message += "<li>Please Select Role.</li>";
    }
    //if ($(".ddlActive option:selected").val() == "-1") {
    //    message += "<li>Please Select Status.</li>";
    //}
  
 
    


    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
};


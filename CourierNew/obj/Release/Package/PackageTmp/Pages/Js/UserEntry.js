Validate = function () {

    var message = '';
    var Name = $(".txtUserFullName").val().trim();
    var UserCode = $(".txtUserCode").val().trim();    
    var UserName = $(".txtUserName").val().trim();
    var UserPassword = $(".txtUserPassword").val().trim();
    var AllowToAccesLogin = $(".allowlogin option:selected").val();
   
   

    
    if (UserCode.length == "") {
        message += "<li>Please Enter Employee Code.</li>";
    }
    if (Name.length < 3) {
        message += "<li>Please Enter Employee Name.</li>";
    }
    if ($(".ddlUserRoleKey option:selected").val() == "-1") {
        message += "<li>Please Select Position.</li>";
    }
    if (AllowToAccesLogin == "YES") {
        if (UserName.length < 3) {
            message += "<li>Please Enter User Name.</li>";
        }
        if (UserPassword.length < 3) {
            message += "<li>Please Enter Password.</li>";
        }
        if ($(".ddlUserRoleKey option:selected").text() == "Select One") {
            message += "<li>Please Select Position.</li>";
        }
    }


    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
}

ToggleCred = function () {
    $(".acclogin").hide();
    if ($(".allowlogin option:selected").val() == 'YES') {
        $(".acclogin").show();
    }
}

ToggleRoute = function () {
    $(".accroute").hide();
    if ($(".ddlUserRoleKey option:selected").text() == 'DELIVERY PERSON') {
        $(".accroute").show();
    }
}

$(document).ready(function () {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    function EndRequestHandler(sender, args) {
        ToggleCred();
        ToggleRoute();
        resetpassword();
    }
});

$(document).ready(
    function () {
        ToggleCred();
        ToggleRoute();
        resetpassword();
    }
);

function resetpassword() {
    $("input").attr("autocomplete", "off");
    var txtKey = $("#txtKey").val();
    SetDefaultfocus('CP1_txtUserCode');
    var key = TryParseInt(txtKey);
    if (key == 0) {
        setTimeout(function () {
            $(".txtUserName").val('');
            $(".txtUserPassword").val('');
        }, 5000);
    }
}
$(document).on('click', '.toggle-password', function () {

    $(this).toggleClass("fa-eye fa-eye-slash");

    var input = $(".txtUserPassword");
    input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password')
});
function OpenModelAttr() {
    $("div").removeClass("modal-backdrop");
    return false;
}       

var specialKeys = new Array();
specialKeys.push(8); //Backspace
$(function () {
    $(".numeric").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
        $(".error").css("display", ret ? "none" : "inline");
        return ret;
    });
    $(".numeric").bind("paste", function (e) {
        return false;
    });
    $(".numeric").bind("drop", function (e) {
        return false;
    });
});
/***********************Float************************************/
$(function () {
    $(".float").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode
        if (keyCode == 46 && $(this).val().indexOf('.') > -1) {
            return false;
        }
        var ret = ((keyCode >= 48 && keyCode <= 57 || keyCode == 46) || specialKeys.indexOf(keyCode) != -1);
        $(".error").css("display", ret ? "none" : "inline");
        return ret;
    });
    $(".float").bind("paste", function (e) {
        return false;
    });
    $(".float").bind("drop", function (e) {
        return false;
    });
});

function ValidateEmail(email) {
    var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    return expr.test(email);
};

$(document).ready(function () {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

    function EndRequestHandler(sender, args) {
        $(function () {
            $(".numeric").bind("keypress", function (e) {
                var keyCode = e.which ? e.which : e.keyCode
                var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
                $(".error").css("display", ret ? "none" : "inline");
                return ret;
            });
            $(".numeric").bind("paste", function (e) {
                return false;
            });
            $(".numeric").bind("drop", function (e) {
                return false;
            });
        });
        /***********************Float************************************/
        $(function () {
            $(".float").bind("keypress", function (e) {
                var keyCode = e.which ? e.which : e.keyCode
                if (keyCode == 46 && $(this).val().indexOf('.') > -1) {
                    return false;
                }
                var ret = ((keyCode >= 48 && keyCode <= 57 || keyCode == 46) || specialKeys.indexOf(keyCode) != -1);
                $(".error").css("display", ret ? "none" : "inline");
                return ret;
            });
            $(".float").bind("paste", function (e) {
                return false;
            });
            $(".float").bind("drop", function (e) {
                return false;
            });
        });
    }

});

function ChangeToUpper() {
    key = window.event.which || window.event.keyCode;

    if ((key > 0x60) && (key < 0x7B))
        window.event.keyCode = key - 0x20;
}
function formatNumber(obj) {
    var num = $("#" + obj).val().replace(",", "");
    num += '';
    x = num.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }

    $("#" + obj).val(x1 + x2);

}
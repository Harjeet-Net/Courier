 
 
$(document).ready(
    //function () {
    //    setInterval(KeepSessionAlive, 600000);
    //    if ($('.select2') != null)
    //        $('.select2').select2();
    //}
);
$(document).ready(function () {
    //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    //function EndRequestHandler(sender, args) {
    //    if ($('.select2') != null)
    //        $('.select2').select2();
    //}
});


/*********Page enum name must be similar to page name******************** */
var pages = {
      "UserEntry": 1
    , "CategoryMaster": 2
    , "UserPermission": 3
    , "TemplateMaster": 4
    , "RefTable": 5
    , "EmployeeMaster": 6
    , "CityState": 7
    , "DayBegin": 8
    , "DayClose": 9
    , "PrepareShipment": 10
    , "LocalShipment": 11
    , "DriverMaster": 12
    , "CustomerMaster": 13
    , "CustomerAddress": 14
    , "PackageEntry": 15
    , "InvoiceDetail": 16
    , "AssignVendor": 17
    , "AssignDriver": 18
    , "FinanceMaster" : 19

   

};
 
function Op( page, key) {

    //$('.frameShortcut').attr('src', function (i, val) { return val; });
    var Index = parseInt(page);
 
    $('.frameShortcut').attr('src', '../Pages/' + Object.keys(pages).find(k => pages[k] === Index) +'.aspx?PK=' + key);
    $('#ModelPopupDialog').modal('show');
  
    return false;
}
function Op1(page, key,parentkey) {

    //$('.frameShortcut').attr('src', function (i, val) { return val; });
    var Index = parseInt(page);

    $('.frameShortcut').attr('src', '../Pages/' + Object.keys(pages).find(k => pages[k] === Index) + '.aspx?PK=' + key + '&parentkey=' + parentkey);
    $('#ModelPopupDialog').modal('show');

    return false;
}
function OpenModel(model) {

 
    $('#' + model).modal('show');

    return false;
}
function OpenModelWithAtt(model,trgctr) {
    var ctrVal = $("." + trgctr).val();
    if (ctrVal.length < 3) {
        toastr.error("Please Entere Attchment Name");
        return false;
    }

    $('#' + model).modal('show');

    return false;
}
function resizeIframe(obj) {
    obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px';
}
function resetiframe() {
    $("#frameShortcut").height(100);
    $("#frameShortcut").attr('src', 'Blank.html');

}
Message = function (messageType, message) { 
    if (messageType == "Success") {
        toastr.success(message);
    }
    if (messageType == "Faliure") {
        toastr.error(message);
    }
    if (messageType == "Warrning") {
        toastr.warning(message);
    }
}


function HideError(obj) {
    $("#" + obj).addClass('hidden');
}
 
function Delete() {
    var PageTitle = window.parent.$(".homeframetitle").text();
    bootbox.dialog({
        message: " <span class='text-red'>Are you sure want to delete this record.? </span> ",
        title: "<h4 class='text-red'>Delete " + PageTitle +"</h3>",
        buttons: {
            success: {
                label: "No",
                className: "btn-success",
                callback: function () {
                    console.log("User declined dialog");
                }
            },
            danger: {
                label: "Yes",
                className: "btn-danger",
                callback: function () {
                    $("#btnDelete").click();
                }
            },
        }
    });
    return false;
}
function SetDefaultfocus(name) {
    setTimeout(function () { $('input[id="' + name + '"]').focus() }, 1000);
}
function KeepSessionAlive() {
    $.post("../KeepSessionAlive.ashx");
}

/*****************AUTO SUGESS SET KEY ******************/
function OnDxSelected(source, eventArgs) {
    var results = eval('(' + eventArgs.get_value() + ')');
    var SetToId = source._id + 'V';
    if (document.getElementById(SetToId).value != null) {
        document.getElementById(SetToId).value = results;
    }

}
function OnDxSelectedGrid(source, eventArgs) {
    var results = eval('(' + eventArgs.get_value() + ')');
    var SetToId = source._element.id;
    if ($("." + SetToId) != null) {
        $("." + SetToId).val(results);
    }

}
function LeaveList(source) {

    var targettextbox = source._element.id;
    if ($("#" + targettextbox).val().length < 3) {
        $("#" + targettextbox).removeClass('alert-danger');
    }

    if ($("#" + source._id + "V").val() != "0") {
        $("#" + targettextbox).removeClass('alert-danger');
    }
    else {
        $("#" + targettextbox).addClass('alert-danger');
    }
}
function LeaveListGrid(source) {

    var targettextbox = source._element.id;
    if ($("#" + targettextbox).val().length < 3) {
        $("#" + targettextbox).removeClass('alert-danger');
    }

    if ($("#" + source._completionListItemCssClass).val() != "0") {
        $("#" + targettextbox).removeClass('alert-danger');
    }
    else {
        $("#" + targettextbox).addClass('alert-danger');
    }
}
function BindList(source) {

    var targettextbox = source._element.id;
    $("#" + source._id + "V").val("0");
    if ($("#" + source._completionListElement.id).is(':visible')) {
        $("#" + targettextbox).removeClass('alert-danger');

    }
    else {
        $("#" + targettextbox).addClass('alert-danger');
    }
}
function BindListGrid(source) {

    var targettextbox = source._element.id;
    $("#" + source._completionListItemCssClass).val("0");
    if ($("#" + source._completionListElement.id).is(':visible')) {
        $("#" + targettextbox).removeClass('alert-danger');

    }
    else {
        $("#" + targettextbox).addClass('alert-danger');
    }
}
function SetZeorOnCategoryChange(objval, objAuto) {
    if (objval.length > 1) {
        document.getElementById(objAuto).value = '0';
    }
}
function TryParseInt(str) {
    if (str == undefined) {
        return 0;
    }
    var defaultValue = 0;
    var retValue = defaultValue;
    if (str !== null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseInt(str);
            }
        }
    }
    return retValue;
}
function TryParseFloat(str) {
    if (str == undefined) {
        return 0;
    }
    var defaultValue = 0;
    var retValue = defaultValue;
    if (str !== null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseFloat(str);
            }
        }
    }
    return retValue;
}
function isEmpty(val) {
    return (val === undefined || val == null || val.length <= 0) ? true : false;
}

//round(1.005, 2); // 1.01
function round(value, decimals) {
    return Number(Math.round(value + 'e' + decimals) + 'e-' + decimals);
}

function ShowpImagePreview(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#imgFile').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
function DisableButtons() {
    var inputs = document.getElementsByTagName("INPUT");
    for (var i in inputs) {
        if (inputs[i].type == "button" || inputs[i].type == "submit") {
            inputs[i].disabled = true;
        }
    }
}
window.onbeforeunload = DisableButtons;

function hideaction() {
    $(".btn").hide();
}
function  ActiveTab(tab){
    $('.nav-item a[href="#' + tab+'"]').trigger('click');
} function htmlEncode(value) {
    return $('<div/>').text(value).html();
}

function htmlDecode(value) {
    return $('<div/>').html(value).text();
}
DateDIff = function (objVal) {
    var today = new Date();
    var formdate;
    if (objVal == '1 Week') {
        formdate = new Date(today.setDate(today.getDate() - 7));
    }
    else if (objVal == '1 Month') {
        formdate = new Date(today.setMonth(today.getMonth() - 1));
    }
    else if (objVal == '1 Year') {
        formdate = today.setFullYear(today.getFullYear() - 1);
    }
    else {
        formdate = new Date();
    }
    $('.fd').val(GetMMDDYY(formdate));
    $('.td').val(GetMMDDYY(new Date()));
}
function GetMMDDYY(data)  {

    var fullDate = new Date(data)

    //Thu May 19 2011 17:25:38 GMT+1000 {}

    //convert month to 2 digits
 
    var twoDigitMonth = fullDate.getMonth()+1;
    if (twoDigitMonth < 10) {
        twoDigitMonth = '0' + (fullDate.getMonth()+1 );
    }
    var twoDigiDay = fullDate.getDate();
    if (twoDigiDay < 10) {
        twoDigiDay = '0' + (fullDate.getDate() );
    }

    var currentDate = twoDigiDay + "/" + twoDigitMonth + "/" + fullDate.getFullYear();
    return currentDate;
}

PrintReport = function (reportname, key) {
    $("div").removeClass("modal-backdrop");
    NewWindow("Reports/ReportWithoutMaster.aspx?ReportName=" + reportname + "&PageKey=" + key + "", 'PrintReport', 1024, 768, 1);
    return false;
}
function RemoveModelBack() {
    $("div").removeClass("modal-backdrop");
}
function CloseModel(objName) {
    $('#' + objName).modal('hide');
    RemoveModelBack();
    return false;
}
function ConvertMMDDYYY( date) { 
 
    var d = new Date(date.split("/").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yy = d.getFullYear();
    var newdate = yy + "/" + mm + "/" + dd;
    return newdate;
}

var win = null;
function NewWindow(mypage, myname, w, h, scroll) {
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
    settings =
        'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable'
    win = window.open(mypage, myname, settings)
    win.focus();

}

OpenFilter = function () {
    $(".card").removeClass("collapsed-card");
    $(">card-body").show();

}

function setcolor(ahref, ulmenu) {
    $("#" + ahref).addClass("nav-item active");
    $("#" + ulmenu).addClass("nav-item has-treeview menu-open");
    $(".nav nav-treeview").attr("style", "display:block");
}

function BindCombo(dropdown, ComboOther, othercri) {
    $("." + dropdown).empty();
    $("." + dropdown).append($("<option></option>").val('-1').html('Select One'));

    $.ajax({
        type: "POST",
        url: "../Services/AuotSuggess.asmx/FillOtherCombo",
        data: "{ComboOther:'" + ComboOther + "',cri:'" + othercri + "'}",
        dataType: "json",
        contentType: "application/json",
        success: function (res) {

            $.each(res.d, function (data, value) {

                $("." + dropdown).append($("<option></option>").val(value.ComboID).html(value.ComboValue));
            })
        }

    });

}
function Validate()
{
    var message = '';
   // var txtDateandtime = $(".txtDateandtime").val().trim();
    var txtEmployee = $(".txtEmployeeName").val().trim();
    var txtCashinHand = $(".txtCashAmount").val().trim();
    var txtChequeAmount = $(".txtChequeAmount").val().trim();
    var txtCash = $(".txtCash").val().trim();


    if ($(".ddlExpenseType option:selected").val() == "-1") {
        message += "<li>Please Select Type Of Expense.</li>";
    }
    if ($(".ddlShiftType option:selected").val() == "-1") {
        message += "<li>Please Select Shift.</li>";
    }
    //if (txtDateandtime.length == "") {
    //    message += "<li>Please Select Date and time</li>";
    //}
    if (txtEmployee.length == "") {
        message += "<li>Please Enter Employee.</li>";
    }
    if (txtCashinHand.length == "") {
        message += "<li>Please Enter Cash in Hand.</li>";
    }
    if (txtChequeAmount.length == "") {
        message += "<li>Please Enter Cheque Amount.</li>";
    }
    if (txtCash.length == "") {
        message += "<li>Please Enter Cash Received.</li>";
    }
 



    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
};

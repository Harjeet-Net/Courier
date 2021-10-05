function Validate()
{
    var message = '';
    var txtDateandtime = $(".txtDateandtime").val().trim();
    var txtEmployeeName = $(".txtEmployeeName").val().trim();
    var txtCashAmount = $(".txtCashAmount").val().trim();
    var txtChequeAmount = $(".txtChequeAmount").val().trim();
    var txtCashReceive = $(".txtCashReceive").val().trim();


    if ($(".ddlExpenseType option:selected").val() == "-1") {
        message += "<li>Please Select Type Of Expense.</li>";
    }
    if ($(".ddlShiftType option:selected").val() == "-1") {
        message += "<li>Please Select Shift.</li>";
    }
    if (txtDateandtime.length == "") {
        message += "<li>Please Select Date and time</li>";
    }
    if (txtEmployeeName.length == "") {
        message += "<li>Please Select Employee</li>";
    }
    if (txtCashAmount.length == "") {
        message += "<li>Please Select Cash in Hand</li>";
    }
    if (txtChequeAmount.length == "") {
        message += "<li>Please Select Cheque Amount</li>";
    }
    if (txtCashReceive.length == "") {
        message += "<li>Please Select Cash</li>";
    }
 



    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
};

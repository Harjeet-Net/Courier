function Validate()
{
    var message = '';
    var txtAgreedAmount = $(".txtAgreedAmount").val().trim();
    var txtReference = $(".txtReference").val().trim();
 


    if ($(".ddlExpenseType option:selected").val() == "-1") {
        message += "<li>Please Select Expense Type.</li>";
    }     
    if (txtAgreedAmount.length == "") {
        message += "<li>Please Enter Amount</li>";
    }
    if (txtReference.length == "") {
        message += "<li>Please Enter Reference</li>";
    }
  
  
    



    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
};

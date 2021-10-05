function Validate()
{
    var message = '';

    var txtItemDescription = $(".txtItemDescription").val().trim();
    var txtCommodityCode = $(".txtCommodityCode").val().trim();
    var txtQuantity = $(".txtQuantity").val().trim();
    var txtItemValue = $(".txtItemValue").val().trim();
    var txtNetWeight = $(".txtNetWeight").val().trim();
    var txtGrossWeight = $(".txtGrossWeight").val().trim();
 
    if (txtItemDescription.length == "") {
        message += "<li>Please Enter Item Description.</li>";
    }
    if ($(".ddlManufactureFrom option:selected").val() == -1) {
        message += "<li>Please Select Manufacture.</li>";
    }
    if (txtCommodityCode.length == "") {
        message += "<li>Please Enter Commodity Code.</li>";
    }
    if (txtQuantity.length == "") {
        message += "<li>Please Enter Quantity.</li>";
    }
    if ($(".ddlQunatityUnit option:selected").val() == -1) {
        message += "<li>Please Select Qunatity Unit.</li>";
    }

    if (txtItemValue.length == "") {
        message += "<li>Please Enter ItemValue</li>";
    }  
    if ($(".ddlCurrencey option:selected").val() == -1) {
        message += "<li>Please Select Currencey.</li>";
    }
    if (txtNetWeight.length == "") {
        message += "<li>Please Enter Net Weight.</li>";
    }
    if ($(".ddlNetWeightUnit option:selected").val() == -1) {
        message += "<li>Please Select NetWeight Unit.</li>";
    }
    if (txtGrossWeight.length == "") {
        message += "<li>Please Enter Gross Weight.</li>";
    }
    if ($(".ddlGrossWeightUnit option:selected").val() == -1) {
        message += "<li>Please Select GrossWeight Unit.</li>";
    }
   
   
    
    
   
   
    

 
 



    if (message != '') {
        toastr.error(message);
        return false;
    }
    else {
        return true;
    }
};

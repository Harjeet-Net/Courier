function Validate() {
    return true;
}

function CheckAll(objCalss ,objVal) { 
    $(".gvrole tr ." + objCalss+ "  input:checkbox").each(function (index, item) {
              $(item).prop("checked", $($(objVal)[0].children[0]).prop("checked"));
         }
    );
}

 
 
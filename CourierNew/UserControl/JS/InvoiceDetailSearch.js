function AddTableInvoiceDetail() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="datatable-table" width="100%">  ';
    str += '      <thead class="datatable-head">                                        ';
    str += '   <tr class="datatable-row">                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Item Description</th>                            ';
    str += '       <th>Manufacture From</th>                            ';
    str += '       <th>Commodity Code</th>                               ';
    str += '       <th>Quantity</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function BindInvoiceDetail(data) {
    AddTableInvoiceDetail();
    //var InvoiceKey = $(".txtInvoiceKey").val();
 

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchInvoiceDetail?iAirwayBillKey=' + data,
               
            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
            { "data": "RowIndex" },
            { "data": "ItemDescription" },
            { "data": "ManufactureFrom" },
            { "data": "CommodityCode" },
            { "data": "Quantity" },
        ],
        statusCode: {
            404: function () {
                alert("page not found");
            }
        },
        fnRowCallback: function (row, data, dataIndex) {

       //     $(row).find('td:nth-child(6)').html(data.Status == true ? "Active" : "In Active");

        }
    });

}


$(document).ready(
    function () {
        BindInvoiceDetail();
        setcolor('lnkTemplateMaster', 'ulConfig');
    }

);
function Confirm() { alert('hi'); }

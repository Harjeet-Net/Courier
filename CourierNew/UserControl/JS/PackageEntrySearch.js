function AddTablePack() {
    $("#dvPackingGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="datatable-table" width="100%">  ';
    str += '      <thead class="datatable-head">                                        ';
    str += '        <tr class="datatable-row">                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Packing Name</th>                            ';
    str += '       <th>Quantity</th>                            ';
    str += '       <th>UOM</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvPackingGrid").append(str);

}

function BindPacking() {
    AddTablePack();
    var PackingKey = $(".ddlPackingKey").val();
 

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchClsAirWayMain2Packing?iPackingKey=' + PackingKey,
               
            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
            { "data": "RowIndex" },
            { "data": "PackingKey" },
            { "data": "Qty" },
            { "data": "UOM" },
           
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
        BindPacking();
        setcolor('lnkTemplateMaster', 'ulConfig');
    }

);
function Confirm() { alert('hi'); }

function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="datatable-table" width="100%">  ';
    str += '      <thead class="datatable-head">                                        ';
    str += '   <tr class="datatable-row">                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Customer Name</th>                            ';
    str += '       <th>Address Name</th>                            ';
    //str += '       <th>Country</th>                               ';
    //str += '       <th>State</th>                               ';
    //str += '       <th>City</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
    var CustomerKey = $(".auCustomerKeyV").val();
 

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchCustomerAddress?iCustomerKey=' + CustomerKey,
               
            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
            { "data": "RowIndex" },
            { "data": "CustomerName" },
            { "data": "AddressName" },
            //{ "data": "Country" },
            //{ "data": "State" },
            //{ "data": "City" },
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
        Bind();
        setcolor('lnkTemplateMaster', 'ulConfig');
    }

);
function Confirm() { alert('hi'); }

function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="datatable-table" width="100%">  ';
    str += '      <thead class="datatable-head">                                        ';
    str += '   <tr class="datatable-row">                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Driver Name</th>                            ';
    str += '       <th>Nationality</th>                            ';
    str += '       <th>City</th>                               ';
    str += '       <th>Country</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
    var txtDriverName = $(".txtDriverName").val();

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchDriver?sDriverName=' + txtDriverName,
            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
        { "data": "RowIndex" },
        { "data": "DriverName" },
        { "data": "Nationality" },
        { "data": "City" },
        { "data": "Country" },
        ],
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }, fnRowCallback: function (row, data, dataIndex) {

         //   $(row).find('td:nth-child(5)').html(data.Status == 1 ? "Active" : "In Active");

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

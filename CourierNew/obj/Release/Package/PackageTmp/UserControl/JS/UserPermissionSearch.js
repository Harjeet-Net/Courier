
function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="ui celled table" width="100%">  ';
    str += '      <thead>                                        ';
    str += '   <tr>                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Role</th>                            ';
    str += '       <th>Active</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
    $('#TableGrid').DataTable({
        ajax:
        {
            url: '../api/Search/Client_RoleGet',
            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
        { "data": "RowIndex" },
        { "data": "CatVal" },
        { "data": "Status" },
        ],
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }, fnRowCallback: function (row, data, dataIndex) {

            $(row).find('td:nth-child(4)').html(data.Status == '1' ? "Active" : "In Active");


        }
    });

}


$(document).ready(
    function () {
        Bind();
        setcolor('lnkUserPermission', 'ulConfig');
    }

);
function Confirm() { alert('hi'); }

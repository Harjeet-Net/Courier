
function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="ui celled table" width="100%">  ';
    str += '      <thead>                                        ';
    str += '   <tr>                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Employee Code</th>                            ';
    str += '       <th>Employee Name</th>                            ';
    str += '       <th>Position</th>                            ';
    str += '       <th>Status</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
 
    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchUserMaster',
            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
            { "data": "RowIndex" },
            { "data": "UserCode" },
            { "data": "UserFullName" },
            { "data": "UserRoleName" },
            { "data": "UserActive" },
        ],
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }, fnRowCallback: function (row, data, dataIndex) {

            $(row).find('td:nth-child(6)').html(data.UserActive == 1 ? "Active" : "In Active");

        }
    });

}


$(document).ready(
    function () {
        Bind();
        setcolor('lnkUserMaster', 'ulConfig');
    }

);
function Confirm() { alert('hi'); }

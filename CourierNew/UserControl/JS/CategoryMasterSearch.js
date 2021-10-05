
function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="datatable-table" width="100%">  ';
    str += '      <thead class="datatable-head">                                        ';
    str += '   <tr class="datatable-row">                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Category Type</th>                            ';
    str += '       <th>Category Name</th>                            ';
    str += '       <th>Status</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
    var pinCategoryName = $(".ddlCategoryName option:selected").val();

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchCategoryMaster?sCategoryName=' + pinCategoryName,
            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
        { "data": "RowIndex" },
        { "data": "CategoryName" },
        { "data": "CatVal" },
        { "data": "Status" },
        ],
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }, fnRowCallback: function (row, data, dataIndex) {

            $(row).find('td:nth-child(5)').html(data.Status == 1 ? "Active" : "In Active");

        }
    });

}


$(document).ready(
    function () {
        Bind();
        setcolor('lnkCategoryMaster', 'ulConfig');
    }

);
function Confirm() { alert('hi'); }

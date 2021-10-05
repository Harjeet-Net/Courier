function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="ui celled table" width="100%">  ';
    str += '      <thead>                                        ';
    str += '   <tr>                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Module Name</th>                            ';
    str += '       <th>Category Name </th>                            ';
    str += '       <th>Short Name</th>                               ';
    str += '       <th>Ref Name</th>                               ';
    str += '       <th>Switch Name</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
    var ddlREFTYPE = $(".ddlREFTYPE option:selected").val();
    var ddlREFSUBTYPE = $(".ddlREFSUBTYPE option:selected").val();

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchREFTABLE?sREFTYPE=' + ddlREFTYPE +
                '&sREFSUBTYPE=' + ddlREFSUBTYPE,
            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
        { "data": "RowIndex" },
        { "data": "REFTYPE" },
        { "data": "REFSUBTYPE" },
        { "data": "SHORTNAME" },
        { "data": "REFNAME1" },
        { "data": "SWITCH1" },
        ],
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }
        //, fnRowCallback: function (row, data, dataIndex) {

        //    $(row).find('td:nth-child(5)').html(data.Status == 1 ? "Active" : "In Active");

        //}
    });

}


$(document).ready(
    function () {
        Bind();
        setcolor('lnkRefTable', 'ulSubscriptions');
    }

);
function Confirm() { alert('hi'); }

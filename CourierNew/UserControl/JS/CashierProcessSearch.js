
function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="datatable-table" width="100%">  ';
    str += '      <thead class="datatable-head">                                        ';
    str += '        <tr class="datatable-row">                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Employee Name</th>                            ';
    str += '       <th>Expense Type</th>                            ';
    str += '       <th>Shift Type</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
    var ExpenseType = $(".ddlExpenseType option:selected").val();

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchCashier?sExpenseType=' + ExpenseType,
            dataSrc: '[]',
            colReorder: true
        },
        columns: [
        { "data": "Button" },
        { "data": "RowIndex" },
        { "data": "EmployeeName" },
        { "data": "ExpenseType" },
        { "data": "ShiftType" },
       
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

function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="ui celled table"  width="100%"  >  ';
    str += '      <thead>                                       ';
    str += '   <tr >                                             ';
    str += '       <th width="5%">Action</th>                   ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>First Name</th>                       ';
    str += '       <th>Last Name</th>                        ';
    str += '       <th>Employee</th>                               ';
    str += '       <th>Role Name</th>                          ';
    str += '   </tr>                                            ';
    str += '  </thead>                                          ';
    str += '   </table> ';
    $("#dvGrid").append(str);
}
function Bind() {
    AddTable();
    var firstname = $(".txtfirstname").val();
    var MainHRRoleID = $(".ddlMainHRRoleID option:selected").val();

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchEmployee?sfirstname=' + firstname +
                '&iMainHRRoleID=' + MainHRRoleID,

            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
            { "data": "RowIndex" },
            { "data": "firstname" },
            { "data": "lastname" },
            { "data": "userID" },     
            { "data": "MainHRRoleID" },
        ],


       paging: true,



        statusCode: {
            404: function () {
                alert("page not found");
            }
        }

        , fnRowCallback: function (row, data, dataIndex) {
        //    if (data.TaskDate != null)
        //        $(row).find('td:nth-child(2)').html(GetMMDDYY(data.TaskDate));

        }



    });

}

$(document).ready(
    function () {
        Bind();
        //setcolor('lnkEmployeeMaster', 'ulEmployee');
    }

);  
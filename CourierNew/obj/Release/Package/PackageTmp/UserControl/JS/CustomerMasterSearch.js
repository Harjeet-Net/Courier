function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="datatable-table" width="100%">  ';
    str += '      <thead class="datatable-head">                                        ';
    str += '   <tr class="datatable-row">                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Customer Name</th>                            ';
    str += '       <th>Nationality</th>                            ';
    str += '       <th>Mobile</th>                               ';
    str += '       <th>Status</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
    var CustomerKeyV = $(".auCustomerKeyV").val();
    var MobileNumber = $(".txtMobileNumber").val();
    var Country = $(".ddlCountry option:selected").val();

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchCustomer?iID=' + CustomerKeyV +
                '&sMobileNumber=' + MobileNumber + 
                '&sCountry=' + Country,
            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
            { "data": "RowIndex" },
            { "data": "CustomerName" },
            { "data": "Nationality" },
            { "data": "MobileNumber" },
            { "data": "Status" },
        ],
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }, fnRowCallback: function (row, data, dataIndex) {

            $(row).find('td:nth-child(6)').html(data.Status == true ? "Active" : "In Active");

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

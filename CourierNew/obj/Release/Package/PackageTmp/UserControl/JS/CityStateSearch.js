
function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="ui celled table" width="100%">  ';
    str += '      <thead>                                        ';
    str += '   <tr>                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Country Name</th>                            ';
    str += '       <th>State Name </th>                            ';
    str += '       <th>City English</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
    var ddlStateID = $(".ddlStateID option:selected").val();
    var ddlCOUNTRYID = $(".ddlCOUNTRYID option:selected").val();

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchCityStatesCounty?iCOUNTRYID=' + ddlCOUNTRYID +
                '&iStateID=' + ddlStateID,
            dataSrc: '[]',
            colReorder: true
        },
        columns: [{ "data": "Button" },
        { "data": "RowIndex" },
        { "data": "CountryName" },
        { "data": "StateName" },
        { "data": "CityEnglish" },
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
        setcolor('lnkCategoryMaster', 'liConfig');
    }

);
function Confirm() { alert('hi'); }

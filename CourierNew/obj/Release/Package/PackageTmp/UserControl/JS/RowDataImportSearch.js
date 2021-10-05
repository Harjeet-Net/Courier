
function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="ui celled table" width="100%">  ';
    str += '      <thead>';
    str += '   <tr>';
    str += '       <th width="5%">Action</th>';
    str += '       <th>Sr No</th>';
    str += '       <th>AWB No</th>';
    str += '       <th>Record  Date</th>';
    str += '       <th>Shipper Name</th>';
    str += '       <th>Receiver Name</th>';
    str += '       <th style="width:100px">Location</th>';
    str += '       <th style="width:100px">Destination</th>';
    str += '   </tr>';
    str += '  </thead>';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
 
    //var eid = $(".eid").val();
    //var assignto = $(".assignto option:selected").val();
    //var status = $(".status option:selected").val();
    //var LocationKey = $(".location option:selected").val();
    //var RouteKey = $(".ddlRouteKey option:selected").val();
    //var StreetKey = $(".ddlStreetKey option:selected").val();
    //var fd = $(".fd").val();
    //var td = $(".td").val();
    //var CustomerKeyV = 0 ;
    //var RootStatus = 'Select All';
    //var driverstatus = 'Select All';
    //var mobile = $(".mobile").val();
    //var driverkey = 0;
    //$('#TableGrid').DataTable({
    //    ajax:
    //    {
    //        url: '/api/Search/Client_SearchCustomerMaster?&sEID=' + eid +
    //            '&iAssignTo=' + assignto +
    //            '&sStatus=' + status +
    //            '&sFromDate=' + fd +
    //            '&sToDate=' + td +
    //            '&iLocationkey=' + LocationKey +
    //            '&iRouteKey=' + RouteKey +
    //            '&sRootStatus=' + RootStatus +
    //            '&smobile=' + mobile  +
    //            '&sDriverStatus=' + driverstatus +
    //            '&iDriverkey=' + driverkey +
    //            '&iStreetKey=' + StreetKey +
    //            '&iCustomerKey=' + CustomerKeyV,
    //        dataSrc: '[]',
    //        colReorder: true
    //    },
    //    columns: [{ "data": "Button" },
    //        { "data": "RowIndex" },
    //        { "data": "EID" },
    //        { "data": "RecordDate" },
    //        { "data": "CustomerName" },
    //        { "data": "Mobile" },
    //        { "data": "LocationName" },
    //        { "data": "StreetName" },
    //        { "data": "AssignToName" },
    //        { "data": "Status" },
    //    ],
    //    statusCode: {
    //        404: function () {
    //            alert("page not found");
    //        }
    //    }, fnRowCallback: function (row, data, dataIndex) {

    //       //  $(row).find('td:nth-child(4)').html(data.Status.to);
    //        $(row).find('td:nth-child(4)').html(GetMMDDYY(data.RecordDate));
    //    }, "pageLength": 10
    //});

}
function Reset() {
    //$(".eid").val('');
    //$(".assignto option:selected").val('0');
    //$(".ddlRouteKey option:selected").val('-1');
    //$(".ddlStreetKey option:selected").val('-1');
    //$(".status option:selected").val('New');
    //$(".fd").val('');
    //$(".td").val('');
    //$(".location option:selected").val('0');
    //$(".mobile").val('');

    Bind();
}

$(document).ready(
    function () {
        Bind();
        setcolor('lnkRowDataImport', 'ulSettings');
    }

);
function Confirm() { alert('hi'); }


function OpenModelDataAssign() {

    //$("div").removeClass("modal-backdrop");
    //$('.ModelEmployee').modal('show');

    //return false;
}

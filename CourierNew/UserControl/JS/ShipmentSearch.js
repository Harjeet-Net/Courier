
function AddTable() {
    $("#dvGrid").empty();
    var str = '';
    str += '  <table id="TableGrid" class="datatable-table" width="100%">  ';
    str += '      <thead class="datatable-head">                                        ';
    str += '   <tr class="datatable-row">                                              ';
    str += '       <th width="5%">Action</th>                               ';
    str += '       <th>Sr No</th>                                ';
    str += '       <th>Date</th>                            ';
    str += '       <th>AWB No</th>                            ';
    str += '       <th>Type</th>                               ';
    str += '       <th>Sender Name</th>                               ';
    str += '       <th>Receiver Name</th>                               ';
    str += '       <th>Pickup Type</th>                               ';
    str += '   </tr>                                             ';
    str += '  </thead>                                           ';

    $("#dvGrid").append(str);

}

function Bind() {
    AddTable();
    var TranType = $(".ddlTranType option:selected").val();

    $('#TableGrid').DataTable({
        ajax:
        {
            url: '/api/Search/Client_SearchAirWayMain?sTranType=' + TranType,
            dataSrc: '[]',
            colReorder: true
        },
        columns: [
            { "data": "Button" },
            { "data": "RowIndex" },
            { "data": "TranDate" },
            { "data": "TranNo" },
            { "data": "TranType" },
            { "data": "SenderName" },
            { "data": "ReceiverName" },
            { "data": "PickupType" },
       
        ],
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }, fnRowCallback: function (row, data, dataIndex) {
            if (data.TranDate != null)
                $(row).find('td:nth-child(3)').html(GetMMDDYY(data.TranDate));
            var jkey = data.TranID;
            var btn = '';
            btn +=' <div class="dropdown dropdown-inline mr-2">';
            btn +='     <button type="button" class="btn btn-light-primary font-weight-bolder dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">';
            btn +='         <span class="svg-icon svg-icon-md">';
            btn +='             <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">';
            btn +='			<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">';
            btn +='                 <rect x="0" y="0" width="24" height="24" />';
            btn +='                 <path d="M5,8.6862915 L5,5 L8.6862915,5 L11.5857864,2.10050506 L14.4852814,5 L19,5 L19,9.51471863 L21.4852814,12 L19,14.4852814 L19,19 L14.4852814,19 L11.5857864,21.8994949 L8.6862915,19 L5,19 L5,15.3137085 L1.6862915,12 L5,8.6862915 Z M12,15 C13.6568542,15 15,13.6568542 15,12 C15,10.3431458 13.6568542,9 12,9 C10.3431458,9 9,10.3431458 9,12 C9,13.6568542 10.3431458,15 12,15 Z" fill="#000000" />';
            btn +='             </g>';
            btn +='		</svg>';
            btn +='	</span></button>';
            btn +=' <div class="dropdown-menu dropdown-menu-sm dropdown-menu-right">';
            btn +='     <ul class="navi flex-column navi-hover py-2">';
            btn +='         <li class="navi-header font-weight-bolder text-uppercase font-size-sm text-primary pb-2">Choose an option:</li>';
            btn += '         <li class="navi-item">';
            btn += '             <a href="#" onclick="return PrintJob(' + jkey +');" class="navi-link">';
            btn += '                 <span class="navi-icon">';
            btn += '                     <i class="la la-copy"></i>';
            btn += '                 </span>';
            btn += '                 <span class="navi-text">Print AWB</span>';
            btn += '             </a>';
            btn += '         </li>';
            btn += '         <li class="navi-item">';
            btn += '             <a href="#"  onclick="return Op(10,' + jkey +');" class="navi-link">';
            btn +='                 <span class="navi-icon">';
            btn +='                     <i class="la la-print"></i>';
            btn +='                 </span>';
            btn +='                 <span class="navi-text">Edit AWB</span>';
            btn +='             </a>';
            btn +='         </li>';
            btn +='         <li class="navi-item">';
            btn += '             <a href="#" onclick="return Op1(17,0,' +  jkey +');" class="navi-link">';
            btn +='                 <span class="navi-icon">';
            btn +='                     <i class="la la-file-excel-o"></i>';
            btn +='                 </span>';
            btn +='                 <span class="navi-text">Assign Vendor</span>';
            btn +='             </a>';
            btn +='         </li>';
            btn +='         <li class="navi-item">';
            btn += '             <a href="#" onclick="return Op1(18,0,' + jkey +');" class="navi-link">';
            btn +='                 <span class="navi-icon">';
            btn +='                     <i class="la la-file-text-o"></i>';
            btn +='                 </span>';
            btn +='                 <span class="navi-text">Assign Driver</span>';
            btn +='             </a>';
            btn +='         </li>';
            btn +='         <li class="navi-item">';
            btn += '             <a href="#" onclick="return Op1(19,0' + jkey +');" class="navi-link">';
            btn +='                 <span class="navi-icon">';
            btn +='                     <i class="la la-file-pdf-o"></i>';
            btn +='                 </span>';
            btn +='                 <span class="navi-text">Add Expense</span>';
            btn +='             </a>';
            btn +='         </li>';
            btn +='     </ul>';
            btn +=' </div>';
            btn +='</div >';
            $(row).find('td:nth-child(1)').html(btn);

        }
    });

}

PrintJob = function (jkey) {
    //window.open('../Reports/Report_Jobcard.aspx?jkey=' + jkey);
    newwindow = window.open('../Reports/Report_AwbAirWayBill.aspx?airwayKey=' + jkey, "Print Jon Card", 'height=1500,width=1200');
    if (window.focus) { newwindow.focus() }
    return false;
}
$(document).ready(
    function () {
        Bind();
        //setcolor('lnkTemplateMaster', 'ulConfig');
    }

);
function Confirm() { alert('hi'); }

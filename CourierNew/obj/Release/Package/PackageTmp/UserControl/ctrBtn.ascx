<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrBtn.ascx.cs" Inherits="CourierNew.UserControl.ctrBtn" %>
<style>
 
    .TextTitle {
        font-size: 18px;
    }
</style>
<section  id="seactionhead">
 
    <div class="col-md-12  add-btn btntop" id="buttons" runat="server">
      <asp:Button ID="lnkSave"
            ToolTip="Save Record"
            runat="server"
            Style="margin-right: 5px;"
            CssClass="btn btn-primary btn-sm"
            ClientIDMode="Predictable"
            OnClick="btnSave_Click"
            Text="Save" />

        <asp:Button ID="lnkReset"
            ToolTip="Cancel"
            runat="server"
            Style="margin-right: 5px;"
            CssClass="btn btn-primary btn-sm"
            ClientIDMode="Predictable"
            OnClick="btnSave_Click"
            Text="Cancel" />

        <asp:Button ID="lnkDelRecord"
            ToolTip="Delete Record"
            runat="server"
            Style="margin-right: 5px;"
            CssClass="btn btn-primary btn-sm"
            ClientIDMode="Predictable"
            OnClick="btnSave_Click"
            Text="Delete" />

        <asp:Button ID="lnkSearch"
            ToolTip="Search Record"
            runat="server"
            Style="margin-right: 5px;"
            CssClass="btn btn-primary btn-sm"
            ClientIDMode="Predictable"
            OnClick="btnSave_Click"
            Text="Search" />

 
        <asp:Button ID="lnkPrint"
            ToolTip="Print Document"
            runat="server"
            Style="margin-right: 5px;"
            CssClass="btn btn-primary btn-sm"
            Text="Print" />

        <asp:Button ID="lnkViewLog"
            ToolTip="View Log"
            runat="server"
            Style="margin-right: 5px;"
            CssClass="btn btn-primary btn-sm hidden"
            Text="View Log" 
       
            />

    </div>
</section>

<!---------Hidden Field----->
<asp:TextBox ID="txtkeyFromButton" runat="server" ClientIDMode="Static" Text="0" CssClass="hidden"></asp:TextBox>
<asp:Button ID="btnLoadData" runat="server" OnClick="btnSave_Click" ClientIDMode="Static" CssClass="hidden" Text="LoadData" />
<asp:Button ID="btnDelete" ClientIDMode="Static" Style="display: none" runat="server" Text= "Delete"    CssClass=" hidden" OnClick="btnSave_Click" />
 <script>
     function OpenModelViewLog(page) {
         var Table = '<table class="table small table-bordered  dataTable" cellspacing="0" id="CPH_gv" style="border-collapse:collapse;width: 100%;">';
         Table += '  <tbody id="content">';

        
         $('#ModelLog').modal('show');
         var fd = $(".fromdate").val();
         var td = $(".todate").val();
         var uri = '/api/Search/Client_ViewLog?sTableName=' + page + '&sFromDate=' + fd + '&sToDate=' + td ;
         jQuery(document).ready(function ($) {

             $.getJSON(uri)
                 .done(function (data) {
                     $("#content").html(data);


                 })
                 .fail(function (jqXHR, textStatus, err) {
                     $('#student').text('error' + err);
                 })


         });
         Table += '</tbody>';
         Table += '</table>';
         $(".data").html(Table);
         return false;
     }
 </script>
  
<%@ Page Title="Day Begin" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="DayBegin.aspx.cs" Inherits="CourierNew.Pages.DayBegin" %>


<%@ Register Src="~/TransactionControl/CtrCashierProcess.ascx" TagPrefix="ctr" TagName="CtrCashierProcess" %>


<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">

    <span class="hidden">
        SQL_Save: CashierSave
        SQL_Get:  CashierGet
        SQL_Search:  CashierSearch
    </span>
   
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Day Begin Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '500px';
            }

            //  window.parent.$("#MainModel").addClass ('modal-xl');

        }
    </script>
    <ctr:CtrCashierProcess runat="server" id="CtrCashierProcess" PageType="DayBegin" />
</asp:Content>

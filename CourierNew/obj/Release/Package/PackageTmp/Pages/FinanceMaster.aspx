<%@ Page Title="Expense Entry" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="FinanceMaster.aspx.cs" Inherits="CourierNew.Pages.FinanceMaster" %>

<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">

  <span class="hidden">

        SQL_Save  :  FinancialSAVE
        SQL_Get   :  FinancialGET
       
    </span>

    <script src="Js/FinanceMasterEntry.js?ver=2"></script>
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Expense Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '470px';
            }

            //  window.parent.$("#MainModel").addClass ('modal-xl');
        }
    </script>
    <!------------------Step 2 Page Design------->
    <section class="content">
        <div class="container-fluid">
            <div class=" row form-group">
                <!-- form start -->
                <div class="col-lg-3">

                    <div class="form-group">
                        <label>Expense Type</label>
                        <asp:DropDownList ID="ddlExpenseType" runat="server" CssClass="form-control form-control-solid form-control-lg ddlExpenseType" AppendDataBoundItems="true">
                        <asp:ListItem Value="-1" Selected="False">Select One</asp:ListItem>
                        <asp:ListItem Value="DEBIT">DEBIT</asp:ListItem>
                        </asp:DropDownList>
                  
                    </div>
                    <div class="form-group">
                        <label>Amount</label>
                        <asp:TextBox ID="txtAgreedAmount" runat="server" CssClass="form-control form-control-solid form-control-lg txtAgreedAmount numeric" placeholder="Amount"></asp:TextBox>
                     
                    </div>
                    <div class="form-group">
                        <label>Reference</label>
                        <asp:TextBox ID="txtReference" runat="server" CssClass="form-control form-control-solid form-control-lg txtReference " placeholder="Reference"></asp:TextBox>
                        
                    </div>
                     <div class="form-group">
                        <label>Remarks</label>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control form-control-solid form-control-lg  txtRemarks" TextMode="MultiLine" placeholder="Remarks"></asp:TextBox>
                        
                    </div>
                </div>
                


        </div>
            <div class="card-footer text-center">

                    <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="FinanceMaster" />

                </div>
    </div>

    </section>

</asp:Content>


<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrCashierProcess.ascx.cs" Inherits="CourierNew.TransactionControl.CtrCashierProcess" %>
<script src="../Pages/Js/DayBeginEntry.js?ver=2"></script>
<asp:Literal runat="server" ID="ltMsg"></asp:Literal>


 <span class="hidden">
        SQL_Save: CashierSave
        SQL_Get:  CashierGet
        SQL_Search:  CashierSearch
    </span>

<section class="container">
    
        <div class="container-fluid">
            <div class=" row form-group">
                <!-- form start -->
                <div class=" col-lg-3">

                     
                     
                    <div class="form-group">
                        <label>Type Of Expense</label>
                        <asp:DropDownList ID="ddlExpenseType" runat="server" CssClass="form-control form-control-solid form-control-lg ddlExpenseType" AppendDataBoundItems="true">
                            <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>
                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                             <asp:ListItem Value="Card">Card</asp:ListItem>
                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                        </asp:DropDownList>
                       
                    </div> 
                    <div class="form-group hidden">
                        <label>Date and time</label>
                        <asp:TextBox ID="txtDateandTime" data-mask="date" runat="server" CssClass="form-control form-control-solid form-control-lg txtDateandtime" placeholder="DD/MM/YYYY"></asp:TextBox>
                        
                    </div>
                    <div class="form-group">
                        <label>Shift</label>
                        <asp:DropDownList ID="ddlShiftType" runat="server" CssClass="form-control form-control-solid form-control-lg ddlShiftType " AppendDataBoundItems="true">
                        <asp:ListItem Value="-1" Selected="True">Select One</asp:ListItem>
                        <asp:ListItem Value="Morning">Morning</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Night">Night</asp:ListItem>
                        </asp:DropDownList>
                    </div>  
                    <div class="form-group">
                        <label>Employee Name</label>
                        <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control form-control-solid form-control-lg txtEmployeeName "  placeholder="Enter Employee Name"></asp:TextBox>                      
                    </div>
                     <div class="form-group">
                        <label>Cash in Hand</label>
                        <asp:TextBox ID="txtCashAmount" runat="server" CssClass="form-control form-control-solid form-control-lg txtCashAmount numeric"  placeholder="Enter Cash in Hand"></asp:TextBox>                      
                    </div>
                     <div class="form-group">
                        <label>Cheque Amount in Hand</label>
                        <asp:TextBox ID="txtChequeAmount" runat="server" CssClass="form-control form-control-solid form-control-lg txtChequeAmount numeric"  placeholder="Enter Cheque Amount in Hand"></asp:TextBox>                      
                    </div>
                     <div class="form-group">
                        <label>Cash Received from Earlier Shift</label>
                        <asp:TextBox ID="txtCashReceive" runat="server" CssClass="form-control form-control-solid form-control-lg txtCash numeric"  placeholder="Enter Cash Received from Earlier Shift"></asp:TextBox>                      
                    </div>

                   
                </div>
                


        </div>
            <div class="card-footer text-center">

                    <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="CashierProcess" />

                </div>
    </div>

    </section>


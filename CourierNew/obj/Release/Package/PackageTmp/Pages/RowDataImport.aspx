<%@ Page Title="Prepare Shipment Bulk" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RowDataImport.aspx.cs" Inherits="CourierNew.Pages.RowDataImport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../UserControl/JS/RowDataImportSearch.js?ver=1.2"></script>
    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
    <span class="hidden">SQL_Save:  CourierImportSave 
    </span>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row col-lg-12">
                <div>
                    <fieldset class="m-3 shadow">
                        <h3>Row Data Import</h3>
                        <div id="dvsearch" class="container-fluid">
                            <div class="form-group row">
                                <div class="col-lg-9">
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control p-1" ToolTip="Please select only *.xls or *.xlsx" />
                                </div>
                                <div class="col-lg-3">
                                    <asp:Button ID="btnUploadFile" runat="server" OnClick="btnUploadFile_Click" Text="Upload" CssClass="btn btn-primary" />
                                </div>
                                    <div class="col-lg-12 text-center">
                               <a href="../Sample/Sample_Import_PrepareShipment.xlsx" class="font font-italic" title="Please don't change header.Empty row can failed your import." style="text-decoration: underline;" target="_blank" >
                                   Downlad Sample File
                               </a>
                                        </div>
                            </div>


                        </div>
                    </fieldset>
                </div>
                
            </div>


            <%--<fieldset class="m-3 shadow">
                <h3>Import Bulk Data Analysis</h3>
                <br />
               <%-- <div id="dvPatientData" class="container-fluid">
                    <div class="form-group row">

                        
                        <div class="col-lg-3">
                            <label>Record From Date</label>

                            <table>
                                <tr>

                                    <td>

                                        <asp:TextBox runat="server" data-mask="date" placeholder="DD/MM/YYYY" ID="txtfromdate" CssClass="form-control fd ">		</asp:TextBox>

                                    </td>
                                    <td>
                                        <img id="Img1" src="../img/Calendar.png" alt="Click here to select  date" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                            TodaysDateFormat="dd/MM/yyyy" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" ClearTime="True"
                                            PopupButtonID="Img1"></ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-lg-3">
                            <label>Record To Date</label>
                            <table>
                                <tr>
                                    <td>

                                        <asp:TextBox runat="server" data-mask="date" placeholder="DD/MM/YYYY" ID="txttodate" CssClass="form-control td">		</asp:TextBox>

                                    </td>
                                    <td>
                                        <img id="Img2" src="../img/Calendar.png" alt="Click here to select  date" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                            TodaysDateFormat="dd/MM/yyyy" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" ClearTime="True"
                                            PopupButtonID="Img2"></ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </div>
                              
                        <div class="col-lg-3">
                            <br />
                            <input type="button" value="Search" class="btn btn-primary " onclick="Bind();" title="Click here to search" />
                            <asp:Button ID="tbnReset" runat="server" OnClientClick="Reset();" Text="Reset" CssClass="btn btn-primary" />
                        </div>
                    </div>
                   
                        
                      
                    </div>--%>
                </div>
                <%--<div class="row  col-lg-12" style="zoom: 0.9">
                    <div id="dvGrid" style="width: 100%"></div>
                </div>
            </fieldset>--%>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadFile" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Title="Prepare Shipment List" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LocalShipmentImportExcel.aspx.cs" Inherits="CourierNew.Pages.LocalShipmentImportExcel" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
    <span class="hidden">SQL_Save:  CourierImportSave 
    </span>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <div class=" col-lg-12">
                    <fieldset class="m-3 shadow">
                        <h3>Upload Prepare Shipment List (MS Excel)</h3>
                        <div id="dvsearch" class="container-fluid">
                            <div class="form-group row">
                                <div class="col-lg-9">
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control p-1" ToolTip="Please select only *.xls or *.xlsx" />
                                </div>
                                <div class="col-lg-3">
                                    <asp:Button ID="btnUploadFile" runat="server" OnClick="btnUploadFile_Click" Text="Import MS Excel" CssClass="btn btn-primary" />
                                </div>
                                <div class="col-lg-12 text-center">
                                    <span><strong>Note: </strong>Download MS Excel Sample Format. <strong><a href="../Sample/Sample_Import_PrepareShipment.xlsx" class="font font-italic" title="Please don't change header.Empty row can failed your import." style="text-decoration: underline;" target="_blank">Click here</a></strong> to download.						
                                    </span>
                                    <%--<a href="../Sample/Sample_Import_PrepareShipment.xlsx" class="font font-italic" title="Please don't change header.Empty row can failed your import." style="text-decoration: underline;" target="_blank">Downlad Sample File
                                    </a>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <telerik:RadGrid ID="RadGridDetail" runat="server" Width="100%" RenderMode="Lightweight"
                                        AllowFilteringByColumn="true" AllowSorting="False" AutoGenerateColumns="False" 
                                        GridLines="None" AllowPaging="false" PageSize="200" OnNeedDataSource="RadGridDetail_NeedDataSource"
                                        OnPreRender="RadGridDetail_PreRender">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView AllowAutomaticInserts="True" EditMode="PopUp" DataKeyNames="TempID">
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="ckboxShipmentTempSelectAll" runat="server" Text="Select All" AutoPostBack="true" OnCheckedChanged="ckboxShipmentTempSelectAll_CheckedChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfTempID" runat="server" Value='<%#Bind("TempID") %>'></asp:HiddenField>
                                                        <asp:CheckBox ID="ckboxShipmentTemp" runat="server" AutoPostBack="true" OnCheckedChanged="ckboxShipmentTemp_CheckedChanged" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="25px" Font-Size="14px" />
                                                    <ItemStyle Width="20px" />
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridBoundColumn DataField="AWBDate" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Date" AutoPostBackOnFilter="true" DataFormatString="{0: dd/MM/yyyy}">
                                                    <HeaderStyle HorizontalAlign="left" Width="30px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="30px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="AirwayBillNo" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Awb No" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="50px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="50px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="AWBType" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Type" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="30px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="30px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="DriverName" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Driver Name" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="60px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="60px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="ShipperName" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Shipper Name" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="50px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="50px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="ConsigneeName" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Consignee Name" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="50px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="50px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="ConsigneeAdd1" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Consignee Address1" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="75px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="75px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="ConsigneeAdd2" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Consignee Address2" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="75px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="75px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="ConsigneeAdd3" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Consignee Address3" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="75px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="75px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="ConsigneeCityId" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="cityId" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="30px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="30px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="ConsigneeTelephone" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Consignee Telephone" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="30px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="left" Width="30px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="ConsigneePCS" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="PCS" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="30px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="ConsigneeWeight" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="Weight" AutoPostBackOnFilter="true">
                                                    <HeaderStyle HorizontalAlign="left" Width="25px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="25px" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="ConsigneeNetAmount" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    ShowFilterIcon="true" HeaderText="NetAmount" AutoPostBackOnFilter="true"
                                                    DataType="System.Decimal" DataFormatString="{0:#.##}">
                                                    <HeaderStyle HorizontalAlign="left" Width="25px" Font-Size="14px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="25px" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <%--<ClientSettings EnableRowHoverStyle="false">
                                            <Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
                                            <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="" />
                                        </ClientSettings>--%>
                                    </telerik:RadGrid>
                                    <%--<telerik:RadGrid ID="RadGridDetail" runat="server">
                                        <MasterTableView ShowHeader="true">
                                            <ItemStyle Width="550px" />
                                        </MasterTableView>
                                        <ClientSettings>
                                            <Scrolling AllowScroll="true" />
                                        </ClientSettings>
                                    </telerik:RadGrid>--%>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadFile" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

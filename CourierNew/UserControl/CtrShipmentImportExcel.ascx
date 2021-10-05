<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrShipmentImportExcel.ascx.cs" Inherits="CourierNew.UserControl.CtrShipmentImportExcel" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<script src="../UserControl/JS/ShipmentExcel.js?ver=2"></script>
<style>
    #TableGrid {
        display: block;
        overflow-x: auto;
        white-space: nowrap;
        margin-top:5px;
    }
</style>
<section class="container">
    <!-- Default box -->
    <!--begin::Card-->

    <div class="">
        <div class="">
            <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="HeadTitle"></h3>
                <div class="card-title col-lg" style="margin-bottom: .25rem;">
                    <h3 class="card-label">Prepare Shipment List (MS Excel)</h3>
                </div>
            </div>
            <br />
            <div>
                <div class="row">
                    <div class="col-md-9">
                        <label class="control-label">Upload File</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control p-1" ToolTip="Please select only *.xls or *.xlsx" />
                    </div>
                    <div class=" col-md-3" style="margin-top: 25px;">
                        <%--<asp:Button ID="btnUploadFile" runat="server" OnClick="btnUploadFile_Click" Text="Import MS-Excel" CssClass="btn btn-primary" />--%>
                        <asp:Button ID="btnUploadFiles" runat="server" Text="Import MS-Excel" CssClass="btn btn-primary" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <span><strong>Note: </strong>Download MS Excel Sample Format. <strong><a href="../Sample/LOCALAWBImportFormat.xlsx" class="font font-italic" title="Please don't change header.Empty row can failed your import." style="text-decoration: underline;" target="_blank">Click here</a></strong> to download.						
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.card -->
        <%--<div style="margin-top: 10px;">
            <telerik:RadGrid ID="RadGridDetail" runat="server" Width="100%" RenderMode="Lightweight"
                AllowFilteringByColumn="true" AllowSorting="true" AutoGenerateColumns="False"
                GridLines="None" AllowPaging="false" PageSize="200" OnNeedDataSource="RadGridDetail_NeedDataSource"
                OnPreRender="RadGridDetail_PreRender">
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView AllowAutomaticInserts="True" EditMode="PopUp" DataKeyNames="TempID">
                    <Columns>
                        <telerik:GridTemplateColumn AllowFiltering="false">
                            <HeaderTemplate>
                                <asp:CheckBox ID="ckboxShipmentTempSelectAll" runat="server" ToolTip="Select All" AutoPostBack="true" OnCheckedChanged="ckboxShipmentTempSelectAll_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfTempID" runat="server" Value='<%#Bind("TempID") %>'></asp:HiddenField>
                                <asp:CheckBox ID="ckboxShipmentTemp" runat="server" AutoPostBack="true" OnCheckedChanged="ckboxShipmentTemp_CheckedChanged" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="25px" Font-Size="14px" />
                            <ItemStyle Width="20px" />
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Action">
                            <ItemTemplate>
                                <a href="#" class="btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1" tooltip="Edit"  onclick="return Op(2,1);">
                                    <span class="svg-icon svg-icon-3">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <path opacity="0.3" d="M21.4 8.35303L19.241 10.511L13.485 4.755L15.643 2.59595C16.0248 2.21423 16.5426 1.99988 17.0825 1.99988C17.6224 1.99988 18.1402 2.21423 18.522 2.59595L21.4 5.474C21.7817 5.85581 21.9962 6.37355 21.9962 6.91345C21.9962 7.45335 21.7817 7.97122 21.4 8.35303ZM3.68699 21.932L9.88699 19.865L4.13099 14.109L2.06399 20.309C1.98815 20.5354 1.97703 20.7787 2.03189 21.0111C2.08674 21.2436 2.2054 21.4561 2.37449 21.6248C2.54359 21.7934 2.75641 21.9115 2.989 21.9658C3.22158 22.0201 3.4647 22.0084 3.69099 21.932H3.68699Z" fill="black"></path>
                                            <path d="M5.574 21.3L3.692 21.928C3.46591 22.0032 3.22334 22.0141 2.99144 21.9594C2.75954 21.9046 2.54744 21.7864 2.3789 21.6179C2.21036 21.4495 2.09202 21.2375 2.03711 21.0056C1.9822 20.7737 1.99289 20.5312 2.06799 20.3051L2.696 18.422L5.574 21.3ZM4.13499 14.105L9.891 19.861L19.245 10.507L13.489 4.75098L4.13499 14.105Z" fill="black"></path>
                                        </svg>
                                    </span>
                                    <!--end::Svg Icon-->
                                </a>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20px" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </telerik:GridTemplateColumn>

                        <telerik:GridBoundColumn DataField="AWBDate" AllowFiltering="true" CurrentFilterFunction="Contains" AllowSorting="true" SortExpression="AWBDate"
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
                <ClientSettings EnableRowHoverStyle="false">
                    <Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="" />
                </ClientSettings>
            </telerik:RadGrid>
        </div>--%>

        <div>
            <%-- Contain Load  Here --%>
            <div id="dvGrid" style="zoom: 0.9;margin-top: 10px;"></div>
        </div>

    </div>
</section>

<script>
    $("#btnUpload").click(function (evt) {
        var fileUpload = $("#FileUpload1").get(0);
        var files = fileUpload.files;

        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }

        $.ajax({
            url: "FileUploadHandler.ashx",
            type: "POST",
            data: data,
            contentType: false,
            processData: false,
            success: function (result) { alert(result); },
            error: function (err) {
                alert(err.statusText)
            }
        });

        evt.preventDefault();
    }); 
</script>

<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Report_AwbAirWayBill.aspx.cs" Inherits="CourierNew.Reports.Report_AwbAirWayBill" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>

</head>
<body>
   
    

    <form id="form1" runat="server">
        <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
          
    <div style="width:100%;text-align:left">
        <rsweb:ReportViewer ID="rptViewer" runat="server" BorderStyle="Solid" BorderWidth="1px" DocumentMapWidth="100%" SizeToReportContent="True" Width="100%"></rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>


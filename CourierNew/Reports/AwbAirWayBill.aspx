<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AwbAirWayBill.aspx.cs" Inherits="Courier2.Reports.AwbAirWayBill" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
        </div>
        <rsweb:ReportViewer ID="RVAwbAirWayBill" runat="server" Width="1150" Height="600"   ></rsweb:ReportViewer>
      <%--  <rsweb:ReportViewer ID="RVAwbAirWayBill" runat="server">
        </rsweb:ReportViewer>--%>
    </form>
</body>
</html>

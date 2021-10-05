<%@ Page Title="User Entry" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="UserEntry.aspx.cs" Inherits="CourierNew.Pages.UserEntry" %>

<%@ Register Src="~/AttchementCtr/CropFIle.ascx" TagPrefix="CropFIle" TagName="CropFIle" %>


<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">
    <script src="Js/UserEntry.js?ver=1"></script>

    <asp:Label runat="server" ID="ltMsg"></asp:Label>

     <span class="hidden">
        SQL_Save: UserMasterSAVE
        SQL_Get:  UserMasterGET
        SQL_Search:  UserMasterSEARCH
        SQL_Autheincate:  UserAutehnticate
    </span>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Employee Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '450px';
            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }

    </script>
    <div class="border-bottom p-1 text-right">

        <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="UserMaster" />

    </div>
    <!------------------Step 2 Page Design------->
    <section class="content">
        <div class="container-fluid">
            <!-- form start -->

            <div class="row form-group">
                <div class="col-lg-3">
                    <div class="form-group">
                        <label>Employee Code</label>
                        <asp:TextBox ID="txtUserCode" runat="server" CssClass="form-control form-control-solid form-control-lg txtUserCode" placeholder="User Code"></asp:TextBox>
                    
                    </div>
                    <div class="form-group">
                        <label>Employee Name</label>
                        <asp:TextBox ID="txtUserFullName" runat="server" CssClass="form-control form-control-solid form-control-lg txtUserFullName" placeholder="User Full Name"></asp:TextBox>
                    
                    </div>


                    <div class="form-group">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg w-auto ddlStatus" runat="server">
                            <asp:ListItem Value="True" Selected="True">Active</asp:ListItem>
                            <asp:ListItem Value="False">In Active</asp:ListItem>
                        </asp:DropDownList>
                     
                    </div>
                </div>
                <div class="col-lg-2">
                    <div class="form-group">
                        <label>Position</label>
                        <asp:DropDownList ID="ddlUserRoleKey" runat="server" AppendDataBoundItems="True" class="form-control form-control-solid form-control-lg ddlUserRoleKey" onchange="ToggleRoute()" placeholder="Role">
                            <asp:ListItem Text="Select" Value="-1" />
                        </asp:DropDownList>
                       
                    </div>
                    <div class="form-group acclogin">
                        <label>User Name</label>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control  form-control-solid form-control-lg txtUserName " placeholder="User Name"></asp:TextBox>
                 
                    </div>
                    <div class="form-group acclogin">
                        <label>Password</label>
                        <span toggle="#password-field" class="fa fa-fw fa-eye field_icon toggle-password"></span>
                        <asp:TextBox ID="txtUserPassword" runat="server" CssClass="form-control form-control-solid form-control-lg txtUserPassword " placeholder="Password" autocomplete="off" TextMode="Password"></asp:TextBox>
                     
                    </div>


                </div>

                <div class="col-lg-3">
                    <label>User Image</label>
                    <CropFIle:CropFIle runat="server" ControlMode="Single" RequestPage="UerMaster" ID="crpUserImage" Height="100" Width="100" />
                </div>

            </div>


        </div>
    </section>
    <asp:DropDownList ID="ddlPosition" runat="server" AppendDataBoundItems="True" class="form-control form-control-solid form-control-lg hidden">
        <asp:ListItem Text="Select One" Value="-1" />
    </asp:DropDownList>
    <span class="form-text text-muted hidden">Please Select One</span>
    <div class="form-group hidden">
        <label>Login</label>
        <asp:DropDownList ID="ddlAllowToAccessLogin" AppendDataBoundItems="true" onclick="ToggleCred();" CssClass="form-control form-control-solid form-control-lg allowlogin hi" runat="server">
            <asp:ListItem Value="YES" Selected="True">YES</asp:ListItem>
            <asp:ListItem Value="No">No</asp:ListItem>
        </asp:DropDownList>
   
    </div>
</asp:Content>

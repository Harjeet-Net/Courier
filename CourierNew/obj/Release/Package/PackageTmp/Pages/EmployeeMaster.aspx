<%@ Page Title="Employee Entry " Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="EmployeeMaster.aspx.cs" Inherits="CourierNew.Pages.EmployeeMaster" %>

<%@ Register Src="~/AttchementCtr/CropFIle.ascx" TagPrefix="CropFIle" TagName="CropFIle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CP1" runat="server">
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
    <script src="Js/EmployeeMasterEntry.js?ver=2"></script>
    <span class="hidden">
        SQL_Save  :  EmployeeSAVE
        SQL_Get   :  EmployeeGET 
        SQL_Search:  EmployeeSearch 
    </span>

    <!------------------Step 1 Set Page Size----->
    <script>
        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('Employee Entry ');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '400px';
            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }

    </script>
    <div class="card-footer text-right">

        <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="EmployeeMaster"  />

    </div>
    <!------------------Step 2 Page Design------->
    <section class="content">
        <div class="container-fluid">
            <div class=" row form-group">
                <!-- form start -->
                <div class="col-lg-3">

                    <div class="form-group">
                        <label>First Name</label>
                        <asp:TextBox runat="server" placeholder="First Name" ID="txtfirstname" class="form-control form-control-solid form-control-lg  txtfirstname"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Name Arabic</label>
                        <asp:TextBox runat="server" placeholder="Name Arabic" ID="txtname2" class="form-control form-control-solid form-control-lg  txtname2"></asp:TextBox>
                    </div>
                    <div class="form-group hidden">
                        <label>Name English</label>
                        <asp:TextBox runat="server" placeholder="Name English" ID="txtNameEnglish" class="form-control form-control-solid form-control-lg  txtNameEnglish"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>User Role</label>
                        <asp:DropDownList ID="ddlMainHRRoleID" runat="server" AppendDataBoundItems="True" class="form-control form-control-solid form-control-lg  ddlMainHRRoleID" placeholder="Role">
                            <asp:ListItem Text="Select" Value="-1" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label>Last Name</label>
                        <asp:TextBox runat="server" placeholder="Last Name" ID="txtlastname" class="form-control form-control-solid form-control-lg  txtlastname"></asp:TextBox>

                    </div>
                    <div class="form-group">
                        <label>Name French</label>
                        <asp:TextBox runat="server" placeholder="Name French" ID="txtname3" class="form-control form-control-solid form-control-lg  txtname3"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Login/Name In English</label>
                        <asp:TextBox runat="server" placeholder="login" ID="txtuserID" class="form-control form-control-solid form-control-lg  txtuserID"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label>Mobile No/Employee</label>
                        <asp:TextBox runat="server" placeholder="Mobile No" ID="txtemp_mobile" class="form-control form-control-solid form-control-lg numeric  txtemp_mobile"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlActive" AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlActive w-auto" runat="server">
                            <asp:ListItem Value="True" Selected="True">Active</asp:ListItem>
                            <asp:ListItem Value="False">In Active</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group acclogin">
                        <label>Password</label>
                       <!-- <span toggle="#password-field" class="fa fa-fw fa-eye field_icon toggle-password "></span> -->
                        <asp:TextBox ID="txtPASSWORD" runat="server" CssClass="form-control form-control-solid form-control-lg  txtPASSWORD  ReqFld " placeholder="Password" autocomplete="off" TextMode="Password"></asp:TextBox>
                    </div>

                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label>Employee Image</label>
                        <CropFIle:CropFIle runat="server" ControlMode="Single" RequestPage="UerMaster" ID="crpUserImage" Height="100" Width="100" />
                    </div>
        </div>
                <div class="col-lg-3 hidden">
                    <div class="form-group">
                        <label>Studen_LoginID </label>
                        <asp:TextBox runat="server" placeholder="lOGIN ID" ID="txtStuden_LoginID" class="form-control form-control-solid form-control-lg  txtemp_mobile"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Date</label>
                        <asp:TextBox runat="server" placeholder="DD/MM/YYYY" ID="txtjoined_date" class="form-control form-control-solid form-control-lg  txtjoined_date"></asp:TextBox>
                    </div>
                    <div class="form-group hidden">
                        <label>Employee</label>
                        <asp:TextBox runat="server" placeholder="Employee" ID="txtEmployee" class="form-control form-control-solid form-control-lg  txtEmployee"></asp:TextBox>
                    </div>
                </div>

            </div>
            
             
        </div>
    </section>
</asp:Content>





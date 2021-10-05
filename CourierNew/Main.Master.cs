using BL.AuthenticationAndSession;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew
{
    public partial class Main : ClsPageBaseMaster
    {

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            //ClsCommonUI.LogOut(Page);
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionData"] == null)
            {
                Response.Redirect("~/Login");
            }

            var userData = ClsSessionData.GetLoginUserDataFromSession();
            if (userData != null)
            {
                //lblUserName.Text = userData.UserName;
                //lblUserDropDown.Text = userData.UserFullName;

                ////   var FileName = userData.UserIM == null ? "" : "data:image/png;base64," + Convert.ToBase64String(item.UserImageByte, 0, item.UserImageByte.Length);

                //imgUser.ImageUrl = userData.UserImage;
                //imgBigUser.ImageUrl = userData.UserImage;
                //ltCompanyName.Text = userData.CompanyName;
                //lblRole.Text = userData.UserRoleName;
            }

            //lnkCategoryMaster.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.CategoryMaster, enRoleType.View);
            //lnkUserPermission.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.UserPermission, enRoleType.View);
            //lnkUserMaster.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.UserMaster, enRoleType.View);
            //lnkTemplateMaster.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.TemplateMaster, enRoleType.View);
            //lnkRefTable.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.RefTable,enRoleType.View);
            //lnkEmployeeMaster.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.EmployeeMaster, enRoleType.View);
            //lnkCityState.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.CityState, enRoleType.View);
            //lnkDriverMaster.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.DriverMaster, enRoleType.View);
            //lnkCustomer.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.Customer, enRoleType.View);
            //lnkCustomerAddress.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.CustomerAddress, enRoleType.View);
            //lnkShipment.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.Shipments, enRoleType.View);
            //lnkCashierProcess.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.CashierProcess, enRoleType.View);
            //lnkShipmentImportExcel.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.ShipmentImportExcel, enRoleType.View);
            
            //lnkDayBegin.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.DayBegin, enRoleType.View);
            //lnkDayClose.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.DayClose, enRoleType.View);
            //lnkPrepareShipment.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.PrepareShipment, enRoleType.View);
            //lnkLocalShipment.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.LocalShipment, enRoleType.View);
            //txtUniversalDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //txtCompany.Text = ClsSessionKeys.CompanyKey.ToString();
            //lnkCourierBulkImport.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.CourierBulkImport, enRoleType.View);

        }

        protected void Menu_Click(object sender, EventArgs e)
        {
            var command = ((LinkButton)sender).CommandName;
            txtCtr.Text = command;
            InitPage(txtCtr.Text);
            LoadControl();

        }

        private void InitPage(String pinPage)
        {
            String PageHeader = "";// String .Format ("Welcome to {0}" ,clsVariables.CompanyName);
           
            if ("CategoryMaster" == pinPage)
            {
                PageHeader = "Category Entry";
            }
            else if ("UserEntry" == pinPage)
            {
                PageHeader = "User Entry";
            }
            else if ("UserPermission" == pinPage)
            {
                PageHeader = "User Permission";
            }

            if ("RefTable" == pinPage)
            {
                PageHeader = "Ref Table";
            }
            if ("EmployeeMaster" == pinPage)
            {
                PageHeader = "Employee Master";
            }
            if ("CityState" == pinPage)
            {
                PageHeader = "City State";
            }
            if ("TemplateMaster" == pinPage)
            {
                PageHeader = "Template Master";
            }
            if ("DriverMaster" == pinPage)
            {
                PageHeader = "Driver Master";
            }
            if ("CustomerMaster" == pinPage)
            {
                PageHeader = "Customer Master";
            }
            if ("CustomerAddress" == pinPage)
            {
                PageHeader = "Customer Address";
            }
            if ("Shipment" == pinPage)
            {
                PageHeader = "Opertaion List";
            }
            if ("CashierProcess" == pinPage)
            {
                PageHeader = "Cashier Process";
            }
            if ("ShipmentImportExcel" == pinPage)
            {
                PageHeader = "Shipment Import Excel";
            }

            //lblPageName.Text = PageHeader;
            this.Page.Title = PageHeader;

        }

        private void LoadControl()
        {
            try
            {
                if (txtCtr.Text.Length > 3)
                {
                    foreach (Control objctr in ContentPlaceHolder1.Controls)
                    {
                        ContentPlaceHolder1.Controls.Remove(objctr);
                    }
                    ContentPlaceHolder1.Controls.Clear();
                    var ctr = ClsCommonUI.AddControlToPage(this.Page, txtCtr.Text, txtParentKey.Text);

                    ContentPlaceHolder1.Controls.Add(ctr);

                }
            }
            catch (Exception)
            {
                ContentPlaceHolder1.Controls.Clear();
                var ctr = ClsCommonUI.AddControlToPage(this.Page, txtCtr.Text);

                ContentPlaceHolder1.Controls.Add(ctr);
            }

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
    }
}
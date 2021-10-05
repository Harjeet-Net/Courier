using BL.DriverMaster;
using CommonEntity;
using System;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class DriverMaster : ClsPageBase, INweEntryWeb
    {
        #region "Fix Code"
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    InitForm();
                }
                PageName = this.Page.Title;
                ltMsg.Text = "";

            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            
        }
        public void Buttons_MasterEve(object sender, EventArgs e)
        {
            try
            {

                string ActionID;
                string ActionName;
                if (sender is LinkButton)
                {
                    ActionID = ((LinkButton)sender).ID;
                    ActionName = ((LinkButton)sender).Text;
                }
                else
                {
                    ActionID = ((Button)sender).ID;
                    ActionName = ((Button)sender).Text;
                }
                switch (ActionID)
                {
                    case "btnSaveAndClose":
                        if (SaveForm("Save") == true)
                        {

                        }
                        break;
                    case "lnkSave":
                    case "lnkDelRecord":
                    case "btnDelete":

                        if (SaveForm(ActionName.Contains("Delete") ? "DELETE" : "SAVE") == true)
                        {
                            MessageJquery(PageName + " save ", enMessageBoxType.Success);
                            ResetFormControls();
                        }
                        break;
                    case "lnkAddNew":
                        btnTop.PageKey = 0;
                        ResetFormControls();
                        break;
                    case "lnkSearch":
                        break;
                    case "lnkReset":
                        ResetFormControls();
                        break;
                    case "btnLoadData":
                        LoadFormData();
                        break;
                }
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            
        }
        public void InitForm()
        {
            try
            {
                /***********Codeing Start*********************/
                ClsFillCombo.FillOtherCombo(ddlCountry, enComboOther.CountryName);
                ClsFillCombo.FillCategory(ddlNationality, enCategory.Nationality);
                //ClsFillCombo.FillOtherCombo(ddlCity, enComboOther.CityName);
                /***********Codeing End*********************/

                PagePrimaryKey = FNC.Conv(ClsCommonUI.HandlNullString(Request.QueryString["PK"]), enDataType.INT);
                btnTop.PageKey = PagePrimaryKey;
                if (PagePrimaryKey > 0)
                {
               //     ClsFillCombo.FillOtherCombo(ListBox1, enComboOther.RouteUnAssignWithOwn, PagePrimaryKey.ToString());

                    LoadFormData();
                }
                else
                {
                   
                    ResetFormControls();
                }
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
        #endregion

        public bool SaveForm(string mode)
        {
            try
            {
                /***********Codeing Start*********************/
                ClsDriver objSave = new ClsDriver();
                string Message = string.Empty;

                objSave.Id          = PagePrimaryKey;
            //  objSave.PageType    = txtPageType    .Text.Trim();
            //  objSave.TenentID    = txtTenentID    .Text.Trim();
                objSave.DriverName  = txtDriverName  .Text.Trim();
                objSave.MobileNumber= txtMobileNumber.Text.Trim();
                objSave.VehicleType = ddlVehicleType.SelectedValue;
                objSave.EmailId     = txtEmailId     .Text.Trim();
                objSave.Nationality = ddlNationality.SelectedValue;
                objSave.Address     = txtAddress     .Text.Trim();
                objSave.Country     = ddlCountry     .SelectedValue;
                objSave.City        = ddlCity        .SelectedValue;
                objSave.State       = ddlState       .SelectedValue;
                objSave.ZipCode     = txtZipCode     .Text.Trim();
         //     objSave.Status      = txtStatus      .Text.Trim();

                /***********Codeing Start*********************/

                if (mode == enAction.DELETE.ToString())
                {
                    objSave.Action = enAction.DELETE;
                }
                else
                {
                    objSave.Action = PagePrimaryKey == 0 ? enAction.ADD : enAction.UPDATE;
                }

                int result = objSave.AddUpdateDelete();
                if (result > 0)
                {
                   
                    btnTop.PageKey = 0;
                    return true;
                }
            }

            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            return false;
        }
        public void LoadFormData()
        {
            ClsDriver objSearch = new ClsDriver();

            try
            {
                /***********Codeing Start*********************/
                objSearch.Id = PagePrimaryKey;
                var lstLoad = objSearch.GetDriver();


                foreach (var item in lstLoad)
                {
                
                   
                   
                    txtDriverName.Text = item.DriverName; 
                    txtMobileNumber.Text = item.MobileNumber;
                    ddlVehicleType.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlVehicleType, item.VehicleType);
                    txtEmailId.Text = item.EmailId ;
                    ddlNationality.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlNationality, item.Nationality);
                    txtAddress.Text = item.Address;
                    ddlCountry.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlCountry, item.Country);
                    FillStateByCountry(ddlCountry.SelectedValue);
                    ddlCity.SelectedIndex= ClsCommonUI.SetDropdowValue(ddlCity, item.City); 
                    ddlState.SelectedIndex= ClsCommonUI.SetDropdowValue(ddlState, item.State);
                    FillCityByState(ddlState.SelectedValue);
                    txtZipCode.Text = item.ZipCode;  
                 // txtStatus .Text = item.Status;






                };
                /***********Codeing End*********************/
                btnTop.PageKey = PagePrimaryKey;
                btnTop.IsAddUpdateRecord = true;
                btnTop.VisibleDelRecord = true;
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                btnTop.IsAddUpdateRecord = true;
                btnTop.PageKey = PagePrimaryKey;
                btnTop.InitForm();
            }

        }
        public void ResetFormControls()
        {
            try
            {
                //FIX CODE
                PagePrimaryKey = 0;
                /***********Codeing Start*********************/
   


                txtDriverName.Text  = String.Empty;
                txtMobileNumber.Text  = String.Empty;
                ddlVehicleType.Text  = String.Empty;
                txtEmailId.Text  = String.Empty;
                ddlNationality.SelectedIndex  = -1;
                txtAddress.Text  = String.Empty;
                ddlCountry.SelectedIndex  = -1;
                ddlCity.SelectedIndex  = -1;
                ddlState.SelectedIndex  = -1;
                txtZipCode.Text  = String.Empty;
         //     txtStatus.Text = String.Empty;



                /***********Codeing End*********************/

            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
           
        }

        private void FillStateByCountry(String sCountryKey)
        {
            try { ClsFillCombo.FillOtherCombo(ddlState, enComboOther.StateNameByCountry, sCountryKey); }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStateByCountry(ddlCountry.SelectedValue);
        }

        private void FillCityByState(String sStateKey)
        {
            try { ClsFillCombo.FillOtherCombo(ddlCity, enComboOther.CityNameByState, sStateKey); }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCityByState(ddlState.SelectedValue);
        }


    }
}